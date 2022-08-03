﻿using GroupDocs.Editor.MVC.Products.Common.Entity.Web;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupDocs.Editor.MVC.Products.Editor.Entity.Web.Request
{
    public class EditDocumentRequest : LoadDocumentEntity
    {
        [JsonProperty]
        private String content;

        [JsonProperty]
        private String password;

        [JsonProperty]
        private int pageNumber;

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

        public int getPageNumber()
        {
            return pageNumber;
        }

        public void setPageNumber(int pageNumber)
        {
            this.pageNumber = pageNumber;
        }
    }
}