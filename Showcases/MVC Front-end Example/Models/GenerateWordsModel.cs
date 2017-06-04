using GroupDocs.Editor;
using GroupDocs.Editor.Words.HtmlToWords;
using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Web;

namespace TinyMce.MvcSample.Models
{
    public sealed class GenerateWordsModel
    {
        #region Fields

        private readonly string _documentName;

        private readonly string _closingPassword;

        private readonly string _editedDocumentHtmlContent;

        private readonly bool _isNewArticle;

        private readonly CultureInfo _locale;

        private readonly CultureInfo _localeRtl;

        private readonly CultureInfo _localeEa;

        #endregion Fields

        private GenerateWordsModel(string documentName, string closingPassword, string editedDocumentHtmlContent, bool isNewArticle,
            int locale, int localeRtl, int localeEa)
        {
            this._documentName = documentName;
            this._closingPassword = closingPassword;
            this._editedDocumentHtmlContent = editedDocumentHtmlContent;
            this._isNewArticle = isNewArticle;
            if (locale == 0)
            {
                _locale = null;
            }
            else
            {
                _locale = CultureInfo.GetCultureInfo(locale);
            }
            if (localeRtl == 0)
            {
                _localeRtl = null;
            }
            else
            {
                _localeRtl = CultureInfo.GetCultureInfo(localeRtl);
            }
            if (localeEa == 0)
            {
                _localeEa = null;
            }
            else
            {
                _localeEa = CultureInfo.GetCultureInfo(localeEa);
            }
        }

        public static GenerateWordsModel ExtractData(string rawContent)
        {
            NameValueCollection qscoll = HttpUtility.ParseQueryString(rawContent);
            string documentName = qscoll["documentName"];
            string password = qscoll["password"];
            string rawHtmlContent = qscoll["content"];
            string newArticleRaw = qscoll["isNewArticle"];
            bool isNewArticle = !string.IsNullOrWhiteSpace(newArticleRaw) && newArticleRaw == "1";
            string rawLocale = qscoll["locale"];
            string rawLocaleRtl = qscoll["localeRtl"];
            string rawLocaleEa = qscoll["localeEa"];
            return new GenerateWordsModel(documentName, password, rawHtmlContent, isNewArticle,
                Convert.ToInt32(rawLocale), Convert.ToInt32(rawLocaleRtl), Convert.ToInt32(rawLocaleEa));
        }

        public string DocumentName
        {
            get { return this._documentName; }
        }

        public string GenerateWordsDoc(string itemFolderPath)
        {
            string ext = itemFolderPath.Split('_').LastOrDefault();

            string targetFilePath = System.IO.Path.Combine(itemFolderPath, string.Format("output.{0}", ext));
            string editedFolderPath = System.IO.Path.Combine(itemFolderPath, Constants.EditedFolderName);
            Repository.CreateFolderIfNotExists(editedFolderPath);
            string editedResourceFolderPath = System.IO.Path.Combine(itemFolderPath, Constants.EditedFolderName, Constants.HtmlResourceFolderName);
            string newHtmlFilePath = System.IO.Path.Combine(itemFolderPath, Constants.EditedFolderName, Constants.HtmlFilename);

            if (!this._isNewArticle)
            {
                string originalResourceFolderPath = System.IO.Path.Combine(itemFolderPath, Constants.OriginalFolderName, Constants.HtmlResourceFolderName);
                Repository.Copy(originalResourceFolderPath, editedResourceFolderPath);
            }
            else //if (this._isNewArticle)
            {
                Repository.CreateFolderIfNotExists(editedResourceFolderPath);
            }

            using (OutputHtmlDocument editedHtmlDoc = OutputHtmlDocument.FromMarkup(this._editedDocumentHtmlContent, editedResourceFolderPath))
            {
                // the commented source code below is not necessary for this particular scenario, but shows a way to establish an association 
                // between links and resources in more complex scenarios, when link doesn't contain resource name at all
                /*
                editedHtmlDoc.LinkToResourceMapper = delegate(string linkToResource, List<IHtmlResource> resources)
                {
                    foreach (IHtmlResource htmlResource in resources)
                    {
                        if (linkToResource.Contains(htmlResource.FilenameWithExtension))
                        {
                            return htmlResource;
                        }
                    }
                    return null;
                };
                */
                System.IO.File.WriteAllText(newHtmlFilePath, editedHtmlDoc.HtmlMarkup);

                WordFormats saveFormat = GetSaveFormat(ext);
                WordsSaveOptions saveOptions = new WordsSaveOptions(saveFormat, this._closingPassword);
                saveOptions.Locale = this._locale;
                saveOptions.LocaleBi = this._localeRtl;
                saveOptions.LocaleFarEast = this._localeEa;

                using (System.IO.FileStream outputStream = System.IO.File.Create(targetFilePath))
                {
                    EditorHandler.ToDocument(editedHtmlDoc, outputStream, saveOptions);
                }
            }
            return targetFilePath;
        }

        private static WordFormats GetSaveFormat(string ext)
        {
            WordFormats saveFormat;
            switch (ext)
            {
                case "txt":
                    saveFormat = WordFormats.Text;
                    break;
                case "doc":
                    saveFormat = WordFormats.Doc;
                    break;
                case "dot":
                    saveFormat = WordFormats.Dot;
                    break;
                case "dotx":
                    saveFormat = WordFormats.Dotx;
                    break;
                case "docm":
                    saveFormat = WordFormats.Docm;
                    break;
                case "odt":
                    saveFormat = WordFormats.Odt;
                    break;
                case "ott":
                    saveFormat = WordFormats.Ott;
                    break;
                case "html":
                    saveFormat = WordFormats.Html;
                    break;
                case "mhtml":
                    saveFormat = WordFormats.Mhtml;
                    break;
                case "rtf":
                    saveFormat = WordFormats.Rtf;
                    break;
                case "xml":
                    saveFormat = WordFormats.WordML;
                    break;
                default:
                    saveFormat = WordFormats.Docx;
                    break;
            }
            return saveFormat;
        }
    }
}