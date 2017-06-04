using GroupDocs.Editor;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.Mvc;
using TinyMce.MvcSample.Models;

namespace TinyMce.MvcSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            InitData initData = (InitData)Session["initData"];
            if (initData.HasLicenseFile)
            {
                using (System.IO.FileStream license = System.IO.File.OpenRead(initData.LicenseFilePath))
                {
                    License lic = new License();
                    lic.SetLicense(license);
            }
            }
            if (initData.HasSampleFolder)
            {
                List<SampleDocumentInfo> sampleDocs = Repository.PrepareSampleDocuments(initData.SampleDocumentsFolderPath);
                BrowseModel bm = new BrowseModel()
                {
                    Documents = sampleDocs,
                    BrowseableFolder = initData.SampleDocumentsFolderPath
                };
                return View("Browse", bm);
            }
            else
            {
                return View("Error", (object)"Cannot find a folder with sample documents. Please add it to the 'config.xml'");
            }
        }

        public ActionResult EditExistent(string fullPath)
        {
            string storageFolderPath = ((InitData)Session["initData"]).FullStoragePath;
            string preparedFolderName = Repository.PrepareFilename(fullPath);
            string fullStorageItemFolderPath = System.IO.Path.Combine(storageFolderPath, preparedFolderName);
            Repository.ClearOrCreate(fullStorageItemFolderPath);
            string originalFolderPath = System.IO.Path.Combine(fullStorageItemFolderPath, Constants.OriginalFolderName);
            Repository.ClearOrCreate(originalFolderPath);

            string resourceRequestPrefix = string.Format("GetResource?htmlDocumentFolderName={0}&resourceFilename=", preparedFolderName);

            string bodyContent;
            using (System.IO.FileStream inputDoc = System.IO.File.OpenRead(fullPath))
            using (InputHtmlDocument htmlDoc = EditorHandler.ToHtml(inputDoc))
            {
                string externalResourcePrefix = "GetResource?htmlDocumentFolderName=" + preparedFolderName + "&resourceFilename=";
                bodyContent = htmlDoc.GetBodyContent(externalResourcePrefix);
                string resultantHtmlDocPath = System.IO.Path.Combine(originalFolderPath, Constants.HtmlFilename);
                htmlDoc.Save(resultantHtmlDocPath);
                string cssText = htmlDoc.GetCssContent(resourceRequestPrefix);
                string resourceFolderPath = System.IO.Path.Combine(originalFolderPath, Constants.HtmlResourceFolderName);
                string cssFilePath = System.IO.Path.Combine(resourceFolderPath, Constants.CssFilename);
                System.IO.File.WriteAllText(cssFilePath, cssText);
            }

            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            List<SelectListItem> listItems = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Selected = true,
                    Text = "(default)",
                    Value = 0.ToString()
                }
            };
            foreach (CultureInfo culture in cultures)
            {
                listItems.Add(new SelectListItem()
                {
                    Selected = false,
                    Text = culture.EnglishName,
                    Value = culture.LCID.ToString(CultureInfo.InvariantCulture)
                });
            }

            EditModel em = new EditModel()
            {
                EditableDocumentName = System.IO.Path.GetFileName(fullPath),
                CssRelativePath = resourceRequestPrefix + Constants.CssFilename,
                HtmlContent = bodyContent,
                Locales = listItems,
                IsNewDocument = false
            };
            return View("Edit", em);
        }

        [HttpGet]
        public ActionResult PrepareNew()
        {
            return View(new NewDocumentModel());
        }

        [HttpPost]
        public ActionResult CreateNew(NewDocumentModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.Forbidden);
            }
            string storageFolderPath = ((InitData)Session["initData"]).FullStoragePath;
            string fullPath = inputModel.PrepareFolderStructure(storageFolderPath);

            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            List<SelectListItem> listItems = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Selected = true,
                    Text = "(default)",
                    Value = 0.ToString()
                }
            };
            foreach (CultureInfo culture in cultures)
            {
                listItems.Add(new SelectListItem()
                {
                    Selected = false,
                    Text = culture.EnglishName,
                    Value = culture.LCID.ToString(CultureInfo.InvariantCulture)
                });
            }
            EditModel em = new EditModel()
            {
                EditableDocumentName = System.IO.Path.GetFileName(fullPath),
                CssRelativePath = string.Empty,
                HtmlContent = string.Empty,
                Locales = listItems,
                IsNewDocument = true
            };
            return View("Edit", em);
        }

        [HttpPost]
        public JsonResult Process()
        {
            //obtaining input raw data
            HttpRequestBase request = this.Request;
            System.IO.Stream s = request.InputStream;
            string rawContent;
            using (System.IO.StreamReader reader = new System.IO.StreamReader(s))
            {
                rawContent = reader.ReadToEnd();
            }
            GenerateWordsModel gwm = GenerateWordsModel.ExtractData(rawContent);

            string preparedDocumentFolderName = Repository.PrepareFilename(gwm.DocumentName);
            string storageFolderPath = ((InitData)Session["initData"]).FullStoragePath;
            string itemFolderPath = System.IO.Path.Combine(storageFolderPath, preparedDocumentFolderName);

            gwm.GenerateWordsDoc(itemFolderPath);
            var result = new
            {
                wordDownloadLink = string.Format("GetOutputDocument?documentName={0}", gwm.DocumentName)
            };
            return Json(result);
        }

        [HttpGet]
        public ActionResult GetResource(string htmlDocumentFolderName, string resourceFilename, string isEditedSubfolder)
        {
            bool useEditedSubfolder = String.IsNullOrWhiteSpace(isEditedSubfolder) == false && isEditedSubfolder == "1";
            if (htmlDocumentFolderName == null) { throw new ArgumentNullException("htmlDocumentFolderName"); }
            if (resourceFilename == null) { throw new ArgumentNullException("resourceFilename"); }
            string storageFolderPath = ((InitData)Session["initData"]).FullStoragePath;
            string itemFolderPath = System.IO.Path.Combine(storageFolderPath, htmlDocumentFolderName);
            if (!System.IO.Directory.Exists(itemFolderPath))
            {
                return HttpNotFound("Cannot find a main item folder '" + htmlDocumentFolderName + "' in the 'Storage' subfolder");
            }
            string originalOrEditedSubfolderPath;
            if (useEditedSubfolder)
            {
                string editedFolderPath = System.IO.Path.Combine(itemFolderPath, Constants.EditedFolderName);
                if (!System.IO.Directory.Exists(editedFolderPath))
                {
                    return HttpNotFound("Cannot find an 'edited' subfolder '" + editedFolderPath + "' in main item folder");
                }
                originalOrEditedSubfolderPath = editedFolderPath;
            }
            else
            {
                string originalFolderPath = System.IO.Path.Combine(itemFolderPath, Constants.OriginalFolderName);
                if (!System.IO.Directory.Exists(originalFolderPath))
                {
                    return HttpNotFound("Cannot find an 'original' subfolder '" + originalFolderPath + "' in main item folder");
                }
                originalOrEditedSubfolderPath = originalFolderPath;
            }

            string resourceFolderPath = System.IO.Path.Combine(originalOrEditedSubfolderPath, Constants.HtmlResourceFolderName);
            if (!System.IO.Directory.Exists(resourceFolderPath))
            {
                return HttpNotFound(string.Format("Cannot find a resource subfolder '{0}' in the main item folder '{1}'",
                    resourceFolderPath, htmlDocumentFolderName));
            }
            string resourceFilePath = System.IO.Path.Combine(resourceFolderPath, resourceFilename);
            if (!System.IO.File.Exists(resourceFilePath))
            {
                return HttpNotFound("Cannot find a target resource file '" + resourceFilename + "' in the resource subfolder");
            }
            return File(resourceFilePath, GroupDocs.Editor.HtmlCss.Resources.ResourceTypeDetector.DetectTypeFromFilename(resourceFilename).MimeCode);
        }

        [HttpGet]
        public ActionResult GetOutputDocument(string documentName)
        {
            if (documentName == null) { throw new ArgumentNullException("documentName"); }
            string preparedDocumentFolderName = Repository.PrepareFilename(documentName);

            string storageFolderPath = ((InitData)Session["initData"]).FullStoragePath;
            string fullStorageItemFolderPath = System.IO.Path.Combine(storageFolderPath, preparedDocumentFolderName);
            if (!System.IO.Directory.Exists(fullStorageItemFolderPath))
            {
                return HttpNotFound("Cannot find a main document folder '" + preparedDocumentFolderName + "' in the 'Storage' subfolder");
            }

            var outputName = string.Format("output{0}", Path.GetExtension(documentName));
            string documentFilePath = System.IO.Path.Combine(fullStorageItemFolderPath, outputName);
            if (!System.IO.File.Exists(documentFilePath))
            {
                return HttpNotFound(string.Format("Cannot find a target resource file '{0}/{1}' in the document folder", preparedDocumentFolderName, outputName));
            }
            return File(documentFilePath, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", documentName);
        }

        /// <summary>
        /// Get image by name
        /// </summary>
        public ActionResult GetImage(string imageId)
        {
            string path = Server.MapPath(string.Format("~/Storage/{0}", imageId));
            return File(path, "image/jpeg");
        }

        /// <summary>
        /// Upload image
        /// </summary>
        public ActionResult UploadImage(HttpPostedFileBase file)
        {
            string path = Server.MapPath(string.Format("~/Storage/{0}", file.FileName));
            file.SaveAs(path);

            Uri uri = new Uri(string.Format("GetImage?imageId={0}", file.FileName), UriKind.Relative);
            return Json(new { location = uri });
        }

        public ActionResult UploadCustom()
        {
            string documentName = this.Request.Form["documentName"];
            HttpPostedFileBase uploadedImage = this.Request.Files["file"];
            if (string.IsNullOrWhiteSpace(documentName) || uploadedImage == null || uploadedImage.ContentLength < 1)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            string storageFolderPath = ((InitData)Session["initData"]).FullStoragePath;
            string preparedDocumentName = Repository.PrepareFilename(documentName);
            string itemPath = System.IO.Path.Combine(storageFolderPath, preparedDocumentName);
            Repository.CreateFolderIfNotExists(itemPath);
            string editedFolderPath = System.IO.Path.Combine(itemPath, Constants.EditedFolderName);
            Repository.CreateFolderIfNotExists(editedFolderPath);
            string resourceFolderPath = System.IO.Path.Combine(editedFolderPath, Constants.HtmlResourceFolderName);
            Repository.CreateFolderIfNotExists(resourceFolderPath);
            string imageFilename = System.IO.Path.Combine(resourceFolderPath, uploadedImage.FileName);
            uploadedImage.SaveAs(imageFilename);
            string imageRequestUri = string.Format("GetResource?htmlDocumentFolderName={0}&resourceFilename={1}&isEditedSubfolder=1",
                preparedDocumentName, uploadedImage.FileName);
            var result = new
            {
                location = imageRequestUri
            };
            return Json(result);
        }
    }
}