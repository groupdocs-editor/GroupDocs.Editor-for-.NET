using GroupDocs.Editor.Formats;
using GroupDocs.Editor.Metadata;
using GroupDocs.Editor.Options;
using GroupDocs.Editor.WebForms.Products.Common.Entity.Web;
using GroupDocs.Editor.WebForms.Products.Common.Resources;
using GroupDocs.Editor.WebForms.Products.Common.Util.Comparator;
using GroupDocs.Editor.WebForms.Products.Editor.Config;
using GroupDocs.Editor.WebForms.Products.Editor.Entity.Web.Request;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GroupDocs.Editor.WebForms.Products.Editor.Controllers
{
    /// <summary>
    /// EditorApiController
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EditorApiController : ApiController
    {
        private static readonly Common.Config.GlobalConfiguration globalConfiguration =
            new Common.Config.GlobalConfiguration();

        private const string _postfixEdited = "_edited";

        /// <summary>
        /// Load configuration
        /// </summary>
        /// <returns>Editor configuration</returns>
        [HttpGet]
        [Route("loadConfig")]
        public EditorConfiguration LoadConfig()
        {
            return globalConfiguration.GetEditorConfiguration();
        }

        /// <summary>
        /// Get all files and directories from storage
        /// </summary>
        /// <param name="postedData">Post data</param>
        /// <returns>List of files and directories</returns>
        [HttpPost]
        [Route("loadFileTree")]
        public HttpResponseMessage loadFileTree(PostedDataEntity postedData)
        {
            // get request body
            string relDirPath = postedData.path;

            // get file list from storage path
            try
            {
                // get all the files from a directory
                relDirPath = string.IsNullOrEmpty(relDirPath)
                    ? globalConfiguration.GetEditorConfiguration().GetFilesDirectory()
                    : Path.Combine(globalConfiguration.GetEditorConfiguration().GetFilesDirectory(), relDirPath);

                List<FileDescriptionEntity> fileList = new List<FileDescriptionEntity>();
                List<string> allFiles = new List<string>(Directory.GetFiles(relDirPath));
                allFiles.AddRange(Directory.GetDirectories(relDirPath));

                allFiles.Sort(new FileNameComparator());
                allFiles.Sort(new FileTypeComparator());

                foreach (string file in allFiles)
                {
                    FileInfo fileInfo = new FileInfo(file);

                    // check if current file/folder is hidden
                    if (!fileInfo.Attributes.HasFlag(FileAttributes.Hidden) &&
                        !Path.GetFileName(file)
                            .Equals(Path.GetFileName(globalConfiguration.GetEditorConfiguration()
                                .GetFilesDirectory())) &&
                        !Path.GetFileName(file).StartsWith("."))
                    {
                        FileDescriptionEntity fileDescription = new FileDescriptionEntity();
                        fileDescription.guid = Path.GetFullPath(file);
                        fileDescription.name = Path.GetFileName(file);

                        // set is directory true/false
                        fileDescription.isDirectory = fileInfo.Attributes.HasFlag(FileAttributes.Directory);

                        // set file size
                        if (!fileDescription.isDirectory)
                        {
                            fileDescription.size = fileInfo.Length;
                        }

                        // add object to array list
                        fileList.Add(fileDescription);
                    }
                }

                return Request.CreateResponse(HttpStatusCode.OK, fileList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    new Resources().GenerateException(ex));
            }
        }

        /// <summary>
        /// Load supported file types
        /// </summary>
        /// <returns>Editor configuration</returns>
        [HttpGet]
        [Route("loadFormats")]
        public List<string> LoadFormats()
        {
            return PrepareFormats();
        }

        /// <summary>
        /// Load document description
        /// </summary>
        /// <param name="postedData">Post data</param>
        /// <returns>Document info object</returns>
        [HttpPost]
        [Route("loadDocumentDescription")]
        public HttpResponseMessage LoadDocumentDescription(PostedDataEntity postedData)
        {
            try
            {
                LoadDocumentEntity loadDocumentEntity = LoadDocument(postedData.guid, postedData.password);
                // return document description
                return Request.CreateResponse(HttpStatusCode.OK, loadDocumentEntity);
            }
            catch (PasswordRequiredException ex)
            {
                // set exception message
                return Request.CreateResponse(HttpStatusCode.Forbidden,
                    new Resources().GenerateException(ex, postedData.password));
            }
            catch (Exception ex)
            {
                // set exception message
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    new Resources().GenerateException(ex, postedData.password));
            }
        }

        /// <summary>
        /// Download curerntly viewed document
        /// </summary>
        /// <param name="path">Path of the document to download</param>
        /// <returns>Document stream as attachement</returns>
        [HttpGet]
        [Route("downloadDocument")]
        public HttpResponseMessage DownloadDocument(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                if (File.Exists(path))
                {
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                    var fileStream = new FileStream(path, FileMode.Open);
                    response.Content = new StreamContent(fileStream);
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                    response.Content.Headers.ContentDisposition.FileName = Path.GetFileName(path);
                    return response;
                }
            }

            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        /// <summary>
        /// Upload document
        /// </summary>
        /// <returns>Uploaded document object</returns>
        [HttpPost]
        [Route("uploadDocument")]
        public HttpResponseMessage UploadDocument()
        {
            try
            {
                string url = HttpContext.Current.Request.Form["url"];

                // get documents storage path
                string documentStoragePath = globalConfiguration.GetEditorConfiguration().GetFilesDirectory();
                bool rewrite = bool.Parse(HttpContext.Current.Request.Form["rewrite"]);
                string fileSavePath = "";

                if (string.IsNullOrEmpty(url))
                {
                    // Get the uploaded document from the Files collection
                    var httpPostedFile = HttpContext.Current.Request.Files["file"];
                    if (httpPostedFile != null)
                    {
                        fileSavePath = rewrite
                            ? Path.Combine(documentStoragePath, httpPostedFile.FileName)
                            : Resources.GetFreeFileName(documentStoragePath, httpPostedFile.FileName);

                        // Save the uploaded file to "UploadedFiles" folder
                        httpPostedFile.SaveAs(fileSavePath);
                    }
                }
                else
                {
                    using (WebClient client = new WebClient())
                    {
                        // get file name from the URL
                        Uri uri = new Uri(url);
                        string fileName = Path.GetFileName(uri.LocalPath);

                        fileSavePath = rewrite
                            ? Path.Combine(documentStoragePath, fileName)
                            : Resources.GetFreeFileName(documentStoragePath, fileName);

                        // Download the Web resource and save it into the current filesystem folder.
                        client.DownloadFile(url, fileSavePath);
                    }
                }

                UploadedDocumentEntity uploadedDocument = new UploadedDocumentEntity();
                uploadedDocument.guid = fileSavePath;
                return Request.CreateResponse(HttpStatusCode.OK, uploadedDocument);
            }
            catch (Exception ex)
            {
                // set exception message
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    new Resources().GenerateException(ex));
            }
        }

        /// <summary>
        /// Load document description
        /// </summary>
        /// <param name="postedData">Post data</param>
        /// <returns>Document info object</returns>
        [HttpPost]
        [Route("saveFile")]
        public HttpResponseMessage SaveFile(EditDocumentRequest postedData)
        {
            try
            {
                string htmlContent = postedData.getContent(); // Initialize with HTML markup of the edited document
                string guid = postedData.GetGuid();
                string password = postedData.getPassword();
                string saveFilePath =
                    Path.Combine(globalConfiguration.GetEditorConfiguration().GetFilesDirectory(), guid);

                string tempFilename = Path.GetFileNameWithoutExtension(saveFilePath);
                string original = guid;

                if (!tempFilename
                        .EndsWith(_postfixEdited, StringComparison.InvariantCultureIgnoreCase))
                {
                    tempFilename = Path.GetFileNameWithoutExtension(saveFilePath) + _postfixEdited;
                }
                else
                {
                    original = Path.Combine(Path.GetDirectoryName(saveFilePath) ?? string.Empty,
                        tempFilename.Substring(0, tempFilename.Length - _postfixEdited.Length) +
                        Path.GetExtension(saveFilePath));
                }

                string tempPath = Path.Combine(Path.GetDirectoryName(saveFilePath) ?? string.Empty,
                    tempFilename + Path.GetExtension(saveFilePath));

                ILoadOptions loadOptions = GetLoadOptions(guid);
                if (loadOptions != null)
                {
                    loadOptions.Password = password;
                }

                // Instantiate Editor object by loading the input file
                using (GroupDocs.Editor.Editor editor =
                       new GroupDocs.Editor.Editor(original, delegate { return loadOptions; }))
                {
                    EditableDocument htmlContentDoc = EditableDocument.FromMarkup(htmlContent, null);
                    var saveOptions = GetSaveOptions(guid, password);
                    editor.Save(htmlContentDoc, tempPath, saveOptions);
                }

                LoadDocumentEntity loadDocumentEntity = LoadDocument(tempPath, password);

                // return document description
                return Request.CreateResponse(HttpStatusCode.OK, loadDocumentEntity);
            }
            catch (Exception ex)
            {
                // set exception message
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    new Resources().GenerateException(ex, postedData.getPassword()));
            }
        }

        /// <summary>
        /// Load document description
        /// </summary>
        /// <param name="postedData">Post data</param>
        /// <returns>Document info object</returns>
        [HttpPost]
        [Route("createFile")]
        public HttpResponseMessage CreateFile(EditDocumentRequest postedData)
        {
            try
            {
                string htmlContent = postedData.getContent();
                string guid = postedData.GetGuid();
                string saveFilePath =
                    Path.Combine(globalConfiguration.GetEditorConfiguration().GetFilesDirectory(), guid);
                string tempFilename = Path.GetFileNameWithoutExtension(saveFilePath) + "_tmp";
                string tempPath = Path.Combine(Path.GetDirectoryName(saveFilePath) ?? string.Empty,
                    tempFilename + Path.GetExtension(saveFilePath));

                File.Create(saveFilePath).Dispose();

                using (EditableDocument newFile = EditableDocument.FromMarkup(htmlContent, null))
                {
                    using (GroupDocs.Editor.Editor editor = new GroupDocs.Editor.Editor(saveFilePath))
                    {
                        var saveOptions = GetSaveOptions(saveFilePath, string.Empty);

                        using (FileStream outputStream = File.Create(tempPath))
                        {
                            editor.Save(newFile, outputStream, saveOptions);
                        }
                    }
                }

                if (File.Exists(saveFilePath))
                {
                    File.Delete(saveFilePath);
                }

                File.Move(tempPath, saveFilePath);

                LoadDocumentEntity loadDocumentEntity = LoadDocument(saveFilePath, "");

                // return document description
                return Request.CreateResponse(HttpStatusCode.OK, loadDocumentEntity);
            }
            catch (Exception ex)
            {
                // set exception message
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    new Resources().GenerateException(ex, postedData.getPassword()));
            }
        }

        private static ILoadOptions GetLoadOptions(string guid)
        {
            string extension = Path.GetExtension(guid).Replace(".", "").ToLowerInvariant();
            ILoadOptions options = null;

            foreach (var item in typeof(WordProcessingFormats).GetFields())
            {
                if (item.Name.ToLowerInvariant().Equals("auto"))
                {
                    continue;
                }

                if (item.Name.ToLowerInvariant().Equals(extension))
                {
                    options = new WordProcessingLoadOptions();
                    break;
                }
            }

            foreach (var item in typeof(PresentationFormats).GetFields())
            {
                if (item.Name.ToLowerInvariant().Equals("auto"))
                {
                    continue;
                }

                if (item.Name.ToLowerInvariant().Equals(extension))
                {
                    options = new PresentationLoadOptions();
                    break;
                }
            }

            foreach (var item in typeof(SpreadsheetFormats).GetFields())
            {
                if (item.Name.ToLowerInvariant().Equals("auto"))
                {
                    continue;
                }

                if (item.Name.ToLowerInvariant().Equals(extension))
                {
                    options = new SpreadsheetLoadOptions();
                    break;
                }
            }

            return options;
        }

        private static IEditOptions GetEditOptions(string guid)
        {
            string extension = Path.GetExtension(guid).Replace(".", "").ToLowerInvariant();

            if (extension.ToLowerInvariant().Equals("txt"))
            {
                return new TextEditOptions();
            }
            else
            {
                foreach (var item in typeof(WordProcessingFormats).GetFields())
                {
                    if (item.Name.ToLowerInvariant().Equals("auto"))
                    {
                        continue;
                    }

                    if (item.Name.ToLowerInvariant().Equals(extension))
                    {
                        return new WordProcessingEditOptions(true);
                    }
                }

                foreach (var item in typeof(PresentationFormats).GetFields())
                {
                    if (item.Name.ToLowerInvariant().Equals("auto"))
                    {
                        continue;
                    }

                    if (item.Name.ToLowerInvariant().Equals(extension))
                    {
                        return new PresentationEditOptions();
                    }
                }

                return new SpreadsheetEditOptions();
            }
        }

        private static ISaveOptions GetSaveOptions(string guid, string password)
        {
            string extension = Path.GetExtension(guid).Replace(".", "").ToLowerInvariant();
            if (extension.ToLowerInvariant().Equals("txt"))
            {
                return new TextSaveOptions();
            }
            else
            {
                foreach (var item in typeof(WordProcessingFormats).GetFields())
                {
                    if (item.Name.ToLowerInvariant().Equals("auto"))
                    {
                        continue;
                    }

                    if (!item.Name.ToLowerInvariant().Equals(extension))
                    {
                        continue;
                    }

                    WordProcessingSaveOptions wordProcessingSaveOptions =
                        new WordProcessingSaveOptions(WordProcessingFormats.FromExtension(extension));
                    wordProcessingSaveOptions.EnablePagination = true;
                    wordProcessingSaveOptions.Password = password;
                    return wordProcessingSaveOptions;
                }

                foreach (var item in typeof(PresentationFormats).GetFields())
                {
                    if (item.Name.ToLowerInvariant().Equals("auto"))
                    {
                        continue;
                    }

                    if (!item.Name.ToLowerInvariant().Equals(extension))
                    {
                        continue;
                    }

                    PresentationSaveOptions presentationSaveOptions =
                        new PresentationSaveOptions(PresentationFormats.FromExtension(extension));
                    presentationSaveOptions.Password = password;
                    return presentationSaveOptions;
                }

                SpreadsheetSaveOptions spreadsheetSaveOptions =
                    new SpreadsheetSaveOptions(SpreadsheetFormats.FromExtension(extension));
                spreadsheetSaveOptions.Password = password;
                return spreadsheetSaveOptions;

            }
        }

        private static List<string> PrepareFormats()
        {
            List<string> outputListItems = new List<string>();

            using (IEnumerator<WordProcessingFormats> sequenceEnum = WordProcessingFormats.All.GetEnumerator())
            {
                while (sequenceEnum.MoveNext())
                {
                    outputListItems.Add(sequenceEnum.Current.Extension);
                }
            }

            using (IEnumerator<SpreadsheetFormats> sequenceEnum = SpreadsheetFormats.All.GetEnumerator())
            {
                while (sequenceEnum.MoveNext())
                {
                    outputListItems.Add(sequenceEnum.Current.Extension);
                }
            }

            using (IEnumerator<PresentationFormats> sequenceEnum = PresentationFormats.All.GetEnumerator())
            {
                while (sequenceEnum.MoveNext())
                {
                    outputListItems.Add(sequenceEnum.Current.Extension);
                }
            }

            return outputListItems.Distinct().ToList();
        }

        private static LoadDocumentEntity LoadDocument(string guid, string password)
        {
            LoadDocumentEntity loadDocumentEntity = new LoadDocumentEntity();
            loadDocumentEntity.SetGuid(guid);
            ILoadOptions loadOptions = GetLoadOptions(guid);
            if (loadOptions != null)
            {
                loadOptions.Password = password;
            }

            // Instantiate Editor object by loading the input file
            using (GroupDocs.Editor.Editor editor =
                   new GroupDocs.Editor.Editor(guid, delegate { return loadOptions; }))
            {
                IDocumentInfo documentInfo = editor.GetDocumentInfo(password);

                var editOptions = GetEditOptions(guid);
                if (editOptions is WordProcessingEditOptions)
                {
                    // Open input document for edit — obtain an intermediate document, that can be edited
                    using (EditableDocument beforeEdit = editor.Edit(editOptions))
                    {
                        string allEmbeddedInsideString = beforeEdit.GetEmbeddedHtml();
                        PageDescriptionEntity page = new PageDescriptionEntity();
                        page.SetData(allEmbeddedInsideString);
                        loadDocumentEntity.SetPages(page);
                    }
                }
                else if (editOptions is SpreadsheetEditOptions)
                {
                    for (var i = 0; i < documentInfo.PageCount; i++)
                    {
                        // Let's create an intermediate EditableDocument from the i tab
                        SpreadsheetEditOptions sheetEditOptions = new SpreadsheetEditOptions();
                        sheetEditOptions.WorksheetIndex = i; // index is 0-based
                        using (EditableDocument tabBeforeEdit = editor.Edit(sheetEditOptions))
                        {
                            // Get document as a single base64-encoded string, where all resources (images, fonts, etc) 
                            // are embedded inside this string along with main textual content
                            string allEmbeddedInsideString = tabBeforeEdit.GetEmbeddedHtml();
                            PageDescriptionEntity page = new PageDescriptionEntity();
                            page.SetData(allEmbeddedInsideString);
                            page.number = i + 1;
                            loadDocumentEntity.SetPages(page);
                        }
                    }
                }
                else if (editOptions is PresentationEditOptions)
                {
                    for (var i = 0; i < documentInfo.PageCount; i++)
                    {
                        // Create editing options
                        PresentationEditOptions presentationEditOptions = new PresentationEditOptions();
                        // Specify slide index from original document.
                        (editOptions as PresentationEditOptions).SlideNumber = i; // Because index is 0-based, it is 1st slide
                        using (EditableDocument slideBeforeEdit = editor.Edit(presentationEditOptions))
                        {
                            // Get document as a single base64-encoded string, where all resources (images, fonts, etc) 
                            // are embedded inside this string along with main textual content
                            string allEmbeddedInsideString = slideBeforeEdit.GetEmbeddedHtml();
                            PageDescriptionEntity page = new PageDescriptionEntity();
                            page.SetData(allEmbeddedInsideString);
                            page.number = i + 1;
                            loadDocumentEntity.SetPages(page);
                        }
                    }
                }
            }

            return loadDocumentEntity;
        }
    }
}

