using GroupDocs.Editor.WebForms.Products.Common.Entity.Web;
using Newtonsoft.Json;
using System;

namespace GroupDocs.Editor.WebForms.Products.Editor.Entity.Web.Request
{
    public class EditDocumentRequest : LoadDocumentEntity
    {
        [JsonProperty]
        private String content;

        [JsonProperty]
        private String password;

        public String getContent()
        {
            return content;
        }

        public void setContent(String content)
        {
            this.content = content;
        }

        public String getPassword()
        {
            return password;
        }

        public void setPassword(String password)
        {
            this.password = password;
        }
    }
}