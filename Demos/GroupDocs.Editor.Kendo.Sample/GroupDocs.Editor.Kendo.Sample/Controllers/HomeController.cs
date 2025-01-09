using GroupDocs.Editor.Options;
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
}