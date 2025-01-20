using GroupDocs.Editor.Formats;
using GroupDocs.Editor.HtmlCss.Resources;
using GroupDocs.Editor.Options;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GroupDocs.Editor.Kendo.Sample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var filePath = Server.MapPath("~/Content/DocumentSample.docx");
            using (Editor editor = new Editor(filePath))
            {
                WordProcessingEditOptions options = new WordProcessingEditOptions(true);
                EditableDocument editableDocument = editor.Edit(options);

                // Get the HTML with embedded styles
                var resp = new HtmlResponse
                {
                    FileName = "DocumentSample.docx",
                    Content = editableDocument.GetEmbeddedHtml()

                };
                return View(resp);

            }
        }

        [HttpPost]
        public JsonResult SaveWordFile(SaveDetailsModel saveDetails)
        {
            if (saveDetails == null)
            {
                return Json(new { Success = false, Message = "Invalid data received." });
            }

            try
            {
                var filePath = Server.MapPath("~/Content/DocumentSample_edited.docx");
                var filePathOriginal = Server.MapPath("~/Content/DocumentSample.docx");
                EditableDocument afterEdit = EditableDocument.FromMarkup($"<body>{saveDetails.EditorData}</body>", new List<IHtmlResource>());
                WordProcessingSaveOptions saveOptions = new WordProcessingSaveOptions(WordProcessingFormats.Docx)
                {
                    EnablePagination = true
                };

                using (Editor editor = new Editor(filePathOriginal))
                {
                    editor.Save(afterEdit, filePath, saveOptions);
                }
                // Return success response
                return Json(new { Success = true, Message = $"File details saved successfully to {filePath}" });
            }
            catch (Exception ex)
            {
                // Handle exceptions and return error response
                return Json(new { Success = false, ex.Message });
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

    public class HtmlResponse
    {
        public string FileName { get; set; }
        public string Content { get; set; }
    }

    public class SaveDetailsModel
    {
        public string FileId { get; set; }
        public string GUID { get; set; }
        public string EditorData { get; set; }
    }
}