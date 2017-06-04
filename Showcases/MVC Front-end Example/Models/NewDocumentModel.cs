using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Web.Mvc;

namespace TinyMce.MvcSample.Models
{
    public class NewDocumentModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Filename should be specified")]
        [DataType(DataType.Text)]
        [StringLength(maximumLength: 250, MinimumLength = 4, ErrorMessage = "Filename is too short or too long")]
        public string NewDocumentName { get; set; }

        public List<SelectListItem> Locales { get; set; }

        internal string PrepareFolderStructure(string storageFolderPath)
        {
            string preparedFilename = Repository.PrepareFilename(this.NewDocumentName);
            string newItemPath = Path.Combine(storageFolderPath, preparedFilename);
            Directory.CreateDirectory(newItemPath);
            return newItemPath;
        }
    }
}