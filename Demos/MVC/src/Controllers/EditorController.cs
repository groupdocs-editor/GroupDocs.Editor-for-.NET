using System.Web.Mvc;

namespace GroupDocs.Editor.MVC.Controllers
{
    /// <summary>
    /// Editor Web page controller
    /// </summary>
    public class EditorController : Controller
    {       
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}