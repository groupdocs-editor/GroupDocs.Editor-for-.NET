using System.Collections.Generic;
using System.Web.Mvc;

namespace TinyMce.MvcSample.Models
{
    public sealed class EditModel
    {
        public EditModel()
        {
            
        }

        [AllowHtml]
        public string HtmlContent { get; set; }

        public string EditableDocumentName { get; set; }

        public string CssRelativePath { get; set; }

        public List<SelectListItem> Locales { get; set; }

        public bool IsNewDocument { get; set; }
    }
}