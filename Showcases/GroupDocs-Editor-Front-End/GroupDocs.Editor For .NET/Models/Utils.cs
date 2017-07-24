using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;
using GroupDocs.Editor.Words.HtmlToWords;
using GroupDocs.Editor;

namespace GroupDocs.Editor_For.NET.Models
{
    public class Utils
    {
        private static List<Document> _docs;
        public static List<Document> Documents
        {
            get
            {
                if (_docs == null || _docs.Count == 0)
                    return GetDefaultDocuments();
                else
                    return _docs;
            }
            set
            {
                _docs = value;
            }
        }
        internal static Document GetDocument(string SrNo)
        {
            return Documents.First(m => m.SrNo.ToString() == SrNo);
        }
        private static List<Document> GetDefaultDocuments()
        {
            List<Document> Documents = new List<Document>();

            string SampleHTMLDirectory = HostingEnvironment.MapPath("/App_Data/Samples");
            string[] HTMLFiles = Directory.GetFiles(SampleHTMLDirectory);
            int SrNo = 0;
            foreach (string SampleHTMlFile in HTMLFiles)
            {
                if (Path.GetExtension(SampleHTMlFile) == ".html")
                {
                    string Name = Path.GetFileNameWithoutExtension(SampleHTMlFile);
                    string HTML = File.ReadAllText(SampleHTMlFile);
                    int size = HTML.Length;

                    Document SampleDocument = new Document() { SrNo = SrNo, Name = Name, HTML = HTML, Size = size, LastUpdated = "default" };
                    Documents.Add(SampleDocument);
                }
                if (Path.GetExtension(SampleHTMlFile) == ".doc" || Path.GetExtension(SampleHTMlFile) == ".docx")
                {
                    string Name = Path.GetFileNameWithoutExtension(SampleHTMlFile);
                    string HTML = "";
                    // Obtain document stream
                    Stream sourceStream = File.Open(SampleHTMlFile, FileMode.Open, FileAccess.Read);
                    using (InputHtmlDocument htmlDoc = EditorHandler.ToHtml(sourceStream))
                    {
                        // Obtain HTML document content
                        HTML = htmlDoc.GetContent();
                    }
                    // close stream object to release file for other methods.
                    sourceStream.Close();


                    //string Name = Path.GetFileNameWithoutExtension(SampleHTMlFile);
                    //string HTML = File.ReadAllText(SampleHTMlFile);
                    int size = HTML.Length;

                    Document SampleDocument = new Document() { SrNo = SrNo, Name = Name, HTML = HTML, Size = size, LastUpdated = "default" };
                    Documents.Add(SampleDocument);
                }
                SrNo++;
            }
            return Documents;
        }

        internal static WordFormats GetSaveFormat(string ext)
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