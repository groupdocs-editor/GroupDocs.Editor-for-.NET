using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TinyMce.MvcSample.Models
{
    public sealed class SampleDocumentInfo
    {
        private readonly string _filename;

        private readonly string _fullPath;

        private readonly DateTime _lastModificationDate;

        private readonly int _size;

        public SampleDocumentInfo(string filename, string fullPath, DateTime lastModificationDate, int size)
        {
            this._filename = filename;
            this._fullPath = fullPath;
            this._lastModificationDate = lastModificationDate;
            this._size = size;
        }

        public string Filename
        {
            get { return this._filename; }
        }

        public string FullPath
        {
            get { return this._fullPath; }
        }

        public DateTime LastModificationDate
        {
            get { return this._lastModificationDate; }
        }

        public int Size
        {
            get { return this._size; }
        }
    }
}