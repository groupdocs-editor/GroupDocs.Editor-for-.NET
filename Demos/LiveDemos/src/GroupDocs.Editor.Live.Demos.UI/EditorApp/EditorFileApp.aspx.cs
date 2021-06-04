using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GroupDocs.Editor.Live.Demos.UI.Models;
using GroupDocs.Editor.Live.Demos.UI.Config;
using GroupDocs.Editor.Live.Demos.UI.Helpers;
using System.Globalization;
using System.Text.RegularExpressions;

namespace GroupDocs.Editor.Live.Demos.UI.EditorApp
{
	public partial class EditorFileApp : BasePage
	{
		public string fileFormat = "";
		public string metatitle = "";
		public string metadescription = "";
		public string metakeywords = "";

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
                Configuration.GroupDocsAppsAPIBasePath = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/";
                Configuration.FileDownloadLink = Configuration.GroupDocsAppsAPIBasePath + "DownloadFile.aspx";

                metatitle = "Free Online Document Editor";
				metadescription = "Edit your documents. 100% free online document editor, edit documents like Word, Excel, Powerpoint, PDF, HTML, Openoffice, free online document editor, ilove documents, secure and easy to use! GroupDocs.App — advanced online tool that solving any problems with any files.";
				metakeywords = "Edit documents, View documents, update documents contents, edit documents like Word, Excel, Powerpoint, PDF, HTML, Openoffice, free online document editor, ilove documents";
				hdescription.InnerHtml = "Fast and Secure Editor for more than 50 types of documents, from any device with a modern browser like Chrome, Opera and Firefox.";

				string validationExpression = "";
				string validFileExtensions = GetValidFileExtensions(validationExpression);
				string supportedFileExtensions = "";

				if (Page.RouteData.Values["fileformat"] != null)
				{
					if (!Page.RouteData.Values["fileformat"].ToString().ToLower().Equals("total"))
					{
						fileFormat = Page.RouteData.Values["fileformat"].ToString();
						validationExpression = "." + fileFormat.ToLower();
						validFileExtensions = fileFormat;
						supportedFileExtensions = fileFormat;
					}
				}
				else
				{
					Response response = GroupDocsEditorApiHelper.GetAllEditorSupportedFormats();
					if (response == null)
					{
						throw new Exception(Resources["APIResponseTime"]);
					}
					else if (response.StatusCode == 200)
					{
						if (response.OutputType.Length > 0)
						{
							validationExpression = "." + response.OutputType.Replace(", ", "|.").ToLower();
							validFileExtensions = response.OutputType;
							supportedFileExtensions = response.OutputType;
						}
					}
				}

				ValidateFileType.ValidationExpression = @"(.*?)(" + validationExpression.ToLower() + "|" + validationExpression.ToUpper() + ")$";

				int index = supportedFileExtensions.LastIndexOf(",");
				if (index != -1)
				{
					string substr = supportedFileExtensions.Substring(index);
					string str = substr.Replace(",", " or");
					supportedFileExtensions = supportedFileExtensions.Replace(substr, str);
				}

				ValidateFileType.ErrorMessage = Resources["InvalidFileExtension"] + " " + supportedFileExtensions;

				aPoweredBy.InnerText = "GroupDocs.Editor";
				aPoweredBy.HRef = "https://products.GroupDocs.com/editor";

				hFeatureTitle.InnerText = "GroupDocs Editor App";
				hPageTitle.InnerHtml = "Edit your documents online from anywhere";

				hdnAllowedFileTypes.Value = validFileExtensions.ToLower();

				btnView.Text = Resources["btnViewNow"];
				rfvFile.ErrorMessage = Resources["SelectorDropFileMessage"];
				h4para.InnerText = string.Format(Resources["EditorFeature1Description"], "");

				if (Page.RouteData.Values["fileformat"] != null)
				{
					if (!Page.RouteData.Values["fileformat"].ToString().ToLower().Equals("total"))
					{
						hheading.InnerHtml = "Free Online  " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " Editor";
						hdescription.InnerHtml = "View, edit & download " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " document online from any device, with a modern browser like Chrome, Opera and Firefox.";

						metatitle = "Free Online " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " Document Editor";
						metadescription = "Edit your " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " files/documents. 100% free online " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " document editor, " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " editor, edit documents like Word, Excel, Powerpoint, PDF, JPG, HTML, EPUB & images, " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + ", free online " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " document editor, ilove " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " documents, secure and easy to use! GroupDocs.App — advanced online tool that solving any problems with any files.";
						metakeywords = "Edit " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " documents, View " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " documents in editor, update " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " document contents online, ilove " + Page.RouteData.Values["fileformat"].ToString().ToUpper() + " documents";

						fileFormat = Page.RouteData.Values["fileformat"].ToString().ToUpper() + " ";
					}
				}
			}

			Page.Title = metatitle;
			Page.MetaDescription = metadescription;
		}

		private string GetValidFileExtensions(string validationExpression)
		{
			string validFileExtensions = validationExpression.Replace(".", "").Replace("|", ", ").ToUpper();

			int index = validFileExtensions.LastIndexOf(",");
			if (index != -1)
			{
				string substr = validFileExtensions.Substring(index);
				string str = substr.Replace(",", " or");
				validFileExtensions = validFileExtensions.Replace(substr, str);
			}

			return validFileExtensions;
		}

		private string TitleCase(string value)
		{
			return new CultureInfo("en-US", false).TextInfo.ToTitleCase(value);
		}

		protected void btnView_Click(object sender, EventArgs e)
		{
			if (IsValid)
			{
                Configuration.GroupDocsAppsAPIBasePath = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/";
                Configuration.FileDownloadLink = Configuration.GroupDocsAppsAPIBasePath + "DownloadFile.aspx";                

                // Access the File using the Name of HTML INPUT File.
                HttpPostedFile postedFile = Request.Files["ctl00$MainContent$FileUpload1"];

				pMessage.Attributes.Remove("class");
				pMessage.InnerHtml = "";

				// Check if File is available.                

				if (postedFile != null && postedFile.ContentLength > 0)
				{
					// remove any invalid character from the filename.
					string fn = Regex.Replace(System.IO.Path.GetFileName(postedFile.FileName).Trim(), @"\A(?!(?:COM[0-9]|CON|LPT[0-9]|NUL|PRN|AUX|com[0-9]|con|lpt[0-9]|nul|prn|aux)|[\s\.])[^\\\/:*"" ?<>|]{ 1,254}\z", "");
					fn = fn.Replace(" ", String.Empty);

					string SaveLocation = Configuration.AssetPath + fn;
					SaveLocation = SaveLocation.Replace("'", "");

					try
					{
						postedFile.SaveAs(SaveLocation);
						var isFileUploaded = FileManager.UploadFile(SaveLocation, "emailTo.Value");

						if ((isFileUploaded != null) && (isFileUploaded.FileName.Trim() != ""))
						{
							Response.Redirect("/editor/" + isFileUploaded.FolderId + "/" + HttpUtility.UrlEncode(isFileUploaded.FileName.Trim()) + "/");
						}
					}
					catch (Exception ex)
					{
						pMessage.InnerHtml = "Error: " + ex.Message;
						pMessage.Attributes.Add("class", "alert alert-danger");
					}
				}
			}
		}
	}
}