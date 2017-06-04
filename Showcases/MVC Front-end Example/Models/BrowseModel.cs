using System.Collections.Generic;

namespace TinyMce.MvcSample.Models
{
    public sealed class BrowseModel
    {
        public bool HasLicense { get; set; }

        public string BrowseableFolder { get; set; }

        public List<SampleDocumentInfo> Documents { get; set; }
    }
}