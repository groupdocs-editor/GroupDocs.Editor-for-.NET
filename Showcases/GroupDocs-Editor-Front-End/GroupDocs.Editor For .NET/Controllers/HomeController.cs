using GroupDocs.Editor;
using GroupDocs.Editor.Words.HtmlToWords;
using GroupDocs.Editor_For.NET.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroupDocs.Editor_For.NET.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(string id)
        {
            List<Document> allDocuments = Utils.Documents;
            if (!string.IsNullOrEmpty(id))
            {
                Document myDocument = Utils.GetDocument(id);
                ViewBag.MyDocument = myDocument;
            }
            return View(allDocuments);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Update(FormCollection form)
        {
            List<Document> allDocuments = Utils.Documents;
            int index = int.Parse(form["id"].ToString());

            Document myDocument = Utils.GetDocument(index.ToString());
            
     
            myDocument.Name = form["Name"].ToString();
            myDocument.HTML = form["HTML"].ToString();
            myDocument.LastUpdated = DateTime.Now.ToString();

            allDocuments.RemoveAt(index-1);
            allDocuments.Insert(index-1, myDocument);

            Utils.Documents = allDocuments;
            ViewBag.MyDocument = myDocument;
            return RedirectToAction("Index","Home",myDocument.SrNo.ToString());
        }
        [ValidateInput(false)]
        public ActionResult Download(string id, string format)
        {
            string LicenseFilePath = ConfigurationManager.AppSettings["LicenseFilePath"];
            if (System.IO.File.Exists(LicenseFilePath))
            {
                GroupDocs.Editor.License license = new GroupDocs.Editor.License(); // Instantiate GroupDocs.Editor license
                license.SetLicense(LicenseFilePath); // Apply GroupDocs.Editor license using license path
            }

            Document myDocument = Utils.GetDocument(id);

            WordFormats saveFormat = Utils.GetSaveFormat(format);
            string password = string.Empty;
            WordsSaveOptions saveOptions = new WordsSaveOptions(saveFormat, password);
            string resourcesDirectory = Server.MapPath("/App_Data/Samples");
            string resultFileName = myDocument.Name + "." + format;
            string resultFilePath = Server.MapPath("/App_Data/Downloads") + "\\" + resultFileName;

            using (OutputHtmlDocument htmlDoc = OutputHtmlDocument.FromMarkup(myDocument.HTML, resourcesDirectory))
            {
                using (System.IO.FileStream outputFile = System.IO.File.Create(resultFilePath))
                {
                    EditorHandler.ToDocument(htmlDoc, outputFile, saveOptions);
                    return File(resultFilePath, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", resultFileName);
                }
            }
        }
    }
}