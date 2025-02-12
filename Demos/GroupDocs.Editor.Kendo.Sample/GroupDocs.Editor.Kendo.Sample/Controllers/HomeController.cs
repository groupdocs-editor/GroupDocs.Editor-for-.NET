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
        public ActionResult Presentation(int slideIndex)
        {
            var filePath = Server.MapPath("~/Content/basic-presentation.pptx");
            using (Editor editor = new Editor(filePath))
            {
                PresentationEditOptions options = new PresentationEditOptions();
                options.SlideNumber = slideIndex;
                EditableDocument editableDocument = editor.Edit(options);

                // Get the HTML with embedded styles
                var resp = new PresentationHtmlResponse
                {
                    FileName = "basic-presentation.pptx",
                    Content = editableDocument.GetEmbeddedHtml(),
                    SlideIndex = slideIndex
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
                EditableDocument afterEdit = EditableDocument.FromMarkup(saveDetails.EditorData, new List<IHtmlResource>());
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


        [HttpPost]
        public JsonResult SavePresentation(SavePresentationDetailsModel saveDetails)
        {
            if (saveDetails == null)
            {
                return Json(new { Success = false, Message = "Invalid data received." });
            }

            try
            {
                var filePath = Server.MapPath("~/Content/presentation_edited.pptx");
                var filePathOriginal = Server.MapPath("~/Content/basic-presentation.pptx");
                EditableDocument afterEdit = EditableDocument.FromMarkup(saveDetails.EditorData, new List<IHtmlResource>());
                PresentationSaveOptions saveOptions = new PresentationSaveOptions(PresentationFormats.Pptx)
                {
                    SlideNumber = saveDetails.SlideIndex + 1
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
    }

    public class HtmlResponse
    {
        public string FileName { get; set; }
        public string Content { get; set; }
    }

    public class PresentationHtmlResponse
    {
        public string FileName { get; set; }
        public string Content { get; set; }
        public int SlideIndex { get; set; }

    }

    public class SaveDetailsModel
    {
        public string FileId { get; set; }
        public string GUID { get; set; }
        public string EditorData { get; set; }
    }

    public class SavePresentationDetailsModel
    {
        public string FileId { get; set; }
        public string GUID { get; set; }
        public string EditorData { get; set; }
        public int SlideIndex { get; set; }
    }
}