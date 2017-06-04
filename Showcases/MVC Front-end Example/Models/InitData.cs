using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TinyMce.MvcSample.Models
{
    public sealed class InitData
    {
        private readonly string _licenseFilePath;

        private readonly string _sampleDocumentsFolderPath;

        private readonly string _storageSubpath;

        private string _fullStoragePath;

        public InitData(string licenseFilePath, string sampleDocumentsFolderPath, string storageSubpath)
        {
            this._licenseFilePath = licenseFilePath;
            this._sampleDocumentsFolderPath = sampleDocumentsFolderPath;
            this._storageSubpath = storageSubpath;
        }

        public bool HasSampleFolder
        {
            get { return !string.IsNullOrWhiteSpace(this._sampleDocumentsFolderPath); }
        }

        public bool HasLicenseFile
        {
            get { return !string.IsNullOrWhiteSpace(this._licenseFilePath); }
        }

        public string LicenseFilePath
        {
            get { return this._licenseFilePath; }
        }

        public string SampleDocumentsFolderPath
        {
            get { return this._sampleDocumentsFolderPath; }
        }

        public string StorageSubpath
        {
            get { return this._storageSubpath; }
        }

        public void SetStoragePath(string fullStoragePath)
        {
            this._fullStoragePath = fullStoragePath;
        }

        public string FullStoragePath
        {
            get
            {
                if (this._fullStoragePath == null)
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    return this._fullStoragePath;
                }
            }
        }
    }
}