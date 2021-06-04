using System;
using System.IO;
using System.Web.Http;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using GroupDocs.Editor.Live.Demos.UI.Models;
using System.Linq;
using System.Web;
using GroupDocs.Editor.HtmlCss.Resources;
using System.Collections.Generic;
using GroupDocs.Editor.Options;

namespace GroupDocs.Editor.Live.Demos.UI.Controllers
{
	public class GroupDocsEditorController : ApiControllerBase
	{
		[HttpGet]
		[ActionName("GetAllEditorSupportedFormats")]
		public async Task<Response> GetAllEditorSupportedFormats()
		{
			string logMsg = "ControllerName: GetAllEditorSupportedFormats";

			try
			{
				string strFromExtensions = "DOC, DOCX, DOCM, DOT, DOTM, DOTX, FlatOPC, ODT, OTT, RTF, WordML, XLS, XLT, XLSX, XLSM, XLTX, XLTM, XLSB, XLAM, SXC, SpreadsheetML, ODS, FODS, DIF, DSV, CSV, TSV, PPT, PPT, PPTX, PPTM, PPS, PPSX, PPSM, POT, POTX, POTM, ODP, OTP, TXT, HTML, XML, ";
				strFromExtensions = strFromExtensions.Trim().Trim(',');

				return await Task.FromResult(new Response
				{
					OutputType = strFromExtensions,
					StatusCode = 200
				});
			}
			catch (Exception exc)
			{
				return new Response
				{
					Status = exc.Message,
					StatusCode = 500,
					Text = exc.ToString()
				};
			}
		}

		[HttpGet]
		[ActionName("EditorPageHtml")]
		public async Task<Response> GetEditorPageHtml(string file, string folderName)
		{
			string logMsg = "ControllerName: GetEditorPageHtml, Path: " + folderName + "/" + file;
			FileStream original = null;
			try
			{
				string originalFilePath = AppSettings.WorkingDirectory + folderName + "/" + file;
				string originalOutfilePath = AppSettings.OutputDirectory + folderName + "/" + file;

				if (!Directory.Exists(AppSettings.OutputDirectory + folderName))
					Directory.CreateDirectory(AppSettings.OutputDirectory + folderName);

				if (!System.IO.File.Exists(originalOutfilePath))
				{
					System.IO.File.Copy(originalFilePath, originalOutfilePath, true);
				}
				if (Path.GetExtension(originalOutfilePath).ToLower().Contains("htm"))
				{
					//  Obtain HTML document with embedded resources
					string cssContent = System.IO.File.ReadAllText(originalOutfilePath);
					return await Task.FromResult(new Response
					{
						OutputType = cssContent,
						StatusCode = 200
					});
				}
				else
				{
					string htmlContent = "";
					using (GroupDocs.Editor.Editor editor = new GroupDocs.Editor.Editor(delegate { return System.IO.File.OpenRead(originalOutfilePath); }))
					{
						// Obtain editable document from original DOCX document
						EditableDocument editableDocument = editor.Edit();
						htmlContent = editableDocument.GetEmbeddedHtml();
					}

					return await Task.FromResult(new Response
					{
						OutputType = htmlContent,
						StatusCode = 200
					});
				}
			}
			catch (Exception exc)
			{
				if (original != null)
					original.Close();

				return new Response { OutputType = "<b>An error has occured:</b> " + exc.Message.ToLower() + "<br /><h3>Input document type is unsupported.</h3><p>You may convert this file to other supported format and continue with document editing<br /><b>please click here for <a href='https://products.groupdocs.app/conversion'>free online GroupDocs Conversion</a>.</b> or visit: https://products.groupdocs.app/conversion </p>", StatusCode = 200 };
			}
		}

		[HttpPost]
		[ActionName("UpdateContents")]
		public Response UpdateContents(string file, string folderName)
		{
			string logMsg = "Editor App: ControllerName: UpdateContents, path: " + folderName + "/" + file;
			FileStream original = null;

			try
			{
				var httpRequest = HttpContext.Current.Request;
				var jsonObject = httpRequest.Params["htmlContents"];

				string deserialized = httpRequest.Params["htmlContents"];  //JsonConvert.DeserializeObject<string>(jsonObject);
				if (!deserialized.Contains("<body>"))
				{
					deserialized = deserialized.Insert(0, "<!DOCTYPE html><html xmlns=\"http://www.w3.org/1999/xhtml\" xml:lang=\"en-gb\" lang=\"en-gb\" dir=\"ltr\"><head>");
					deserialized = deserialized.Replace("<div class=\"documentMainContent\">", "</head><body><div class=\"documentMainContent\">");
					deserialized += "</body></html>";
				}

				string outfileName = "Updated_" + file;
				string outFolder = AppSettings.OutputDirectory + folderName;
				string outfilePath = outFolder + "/" + outfileName;

				if (Path.GetExtension(file).ToLower().Contains("htm"))
				{
					System.IO.File.WriteAllText(outfilePath, deserialized);
				}
				else
				{
					string originalOutfilePath = AppSettings.OutputDirectory + folderName + "/" + file;
					GroupDocs.Editor.Editor editor = new GroupDocs.Editor.Editor(delegate { return System.IO.File.OpenRead(originalOutfilePath); });

					EditableDocument beforeEdit = editor.Edit();// GetEditOptions(Path.GetExtension(outfilePath).Replace(".", "")));

					string originalContent = beforeEdit.GetContent();
					List<IHtmlResource> allResources = beforeEdit.AllResources;
					EditableDocument afterEdit = EditableDocument.FromMarkup(deserialized, allResources);

					if (!System.IO.File.Exists(outfilePath))
					{
						original = System.IO.File.Create(outfilePath);
					}
					else
					{
						original = System.IO.File.Open(outfilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
					}

					editor.Save(afterEdit, original, GetSaveOptions(Path.GetExtension(outfilePath).Replace(".", "")));
					beforeEdit.Dispose();
					afterEdit.Dispose();
					editor.Dispose();
					original.Close();
				}

				return new Response
				{
					OutputType = "Successful",
					StatusCode = 200
				};
			}
			catch (Exception exc)
			{
				if (original != null)
					original.Close();

				throw exc;
			}
		}

		IEditOptions GetEditOptions(string extension)
		{
			if (Enum.GetNames(typeof(WordProcessingEditOptions)).Contains(extension))
				return new WordProcessingEditOptions(true);
			else if (Enum.GetNames(typeof(SpreadsheetEditOptions)).Contains(extension))
				return new SpreadsheetEditOptions() { ExcludeHiddenWorksheets = true, WorksheetIndex = 0 };
			else if (Enum.GetNames(typeof(TextEditOptions)).Contains(extension))
				return new TextEditOptions() { EnablePagination = true };
			else
				return new WordProcessingEditOptions(true);
		}

		ISaveOptions GetSaveOptions(string extension)
		{
			if ((Formats.WordProcessingFormats.All).Select(t => t.Extension).Contains(extension))
				return new WordProcessingSaveOptions(Formats.WordProcessingFormats.FromExtension(extension)) { EnablePagination = true };
			else if ("pdf".Contains(extension))
				return new PdfSaveOptions();
			else if ((Formats.SpreadsheetFormats.All).Select(t => t.Extension).Contains(extension))
				return new SpreadsheetSaveOptions(Formats.SpreadsheetFormats.FromExtension(extension));
			else if ((Formats.PresentationFormats.All).Select(t => t.Extension).Contains(extension))
				return new PresentationSaveOptions(Formats.PresentationFormats.FromExtension(extension));
			else if ((Formats.TextualFormats.All).Select(t => t.Extension).Contains(extension))
				return new TextSaveOptions();
			else
				return new WordProcessingSaveOptions(Formats.WordProcessingFormats.FromExtension(extension)) { EnablePagination = true };
		}

		[HttpGet]
		[ActionName("DownloadDocument")]
		public HttpResponseMessage DownloadDocument(string file, string folderName, bool isUpdated)
		{
			string logMsg = "ControllerName: EditorDownloadDocument";
			FileStream original = null;
			try
			{
				file = file.Replace("../", "").Replace("//", "");
				folderName = folderName.Replace("../", "").Replace("//", "");
				string originalFilePath = AppSettings.OutputDirectory + folderName + "/" + file;
				string originalOutfilePath = AppSettings.OutputDirectory + folderName + "/" + (isUpdated ? "Updated_" + file : file);
				string parentFolder = Directory.GetParent(System.IO.Path.Combine(originalOutfilePath, @"..\..")).ToString();

				if (parentFolder.ToLower().Equals(AppSettings.FilesBaseDirectory))
				{
					if (!System.IO.File.Exists(originalOutfilePath))
					{
						System.IO.File.Copy(originalFilePath, originalOutfilePath, true);
					}
					try
					{
						original = System.IO.File.Open(originalOutfilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
					}
					catch (Exception x)
					{
						throw x;
					}
				}
				using (var ms = new MemoryStream())
				{
					original.CopyTo(ms);
					original.Close();
					var result = new HttpResponseMessage(HttpStatusCode.OK)
					{
						Content = new ByteArrayContent(ms.ToArray())
					};
					result.Content.Headers.ContentDisposition =
					new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
					{
						FileName = (isUpdated ? "Updated_" + file : file)
					};

					result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

					return result;
				}
			}
			catch (Exception exc)
			{
				if (original != null)
					original.Close();
                
				throw exc;
			}
		}

		[HttpGet]
		[ActionName("DownloadPdfDocument")]
		public HttpResponseMessage DownloadPdfDocument(string file, string folderName, bool isPdf)
		{
			string logMsg = "ControllerName: EditorDownloadPdfDocument";
			FileStream original = null;
			try
			{
				file = file.Replace("../", "").Replace("//", "");
				folderName = folderName.Replace("../", "").Replace("//", "");
				string originalFilePath = AppSettings.OutputDirectory + folderName + "/" + "Updated_" + file;
				string originalOutfilePath = AppSettings.OutputDirectory + folderName + "/" + (isPdf ? "Updated_" + Path.GetFileNameWithoutExtension(file) + ".pdf" : "Updated_" + file);
				string parentFolder = Directory.GetParent(System.IO.Path.Combine(originalOutfilePath, @"..\..")).ToString();

				if (!parentFolder.ToLower().Equals(AppSettings.FilesBaseDirectory))
				{
					throw new Exception("Invalid file path.");
				}
				try
				{
					GroupDocs.Editor.Editor editor = new GroupDocs.Editor.Editor(originalOutfilePath);
					EditableDocument beforeEdit = editor.Edit();

					string originalContent = beforeEdit.GetContent();
					List<IHtmlResource> allResources = beforeEdit.AllResources;
					EditableDocument afterEdit = EditableDocument.FromMarkup(originalContent, allResources);

					if (!System.IO.File.Exists(originalFilePath))
					{
						System.IO.File.Copy(originalFilePath.Replace("Updated_", ""), originalFilePath, true);
					}

					editor.Save(afterEdit, original, GetSaveOptions("pdf"));
					beforeEdit.Dispose();
					afterEdit.Dispose();
					editor.Dispose();
					original.Close();

					string cssContent = "";
					string outFolder = AppSettings.OutputDirectory + folderName;
					if (Path.GetExtension(originalOutfilePath).ToLower().Contains("htm"))
					{
						//  Obtain HTML document with embedded resources
						cssContent = System.IO.File.ReadAllText(originalOutfilePath);
					}
					else
					{
						original = System.IO.File.Open(originalFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
					}

					original = System.IO.File.Open(originalOutfilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
				}
				catch (Exception x)
				{
					if (original != null)
						original.Close();

					throw x;
				}

				using (var ms = new MemoryStream())
				{
					original.CopyTo(ms);
					original.Close();
					var result = new HttpResponseMessage(HttpStatusCode.OK)
					{
						Content = new ByteArrayContent(ms.ToArray())
					};
					result.Content.Headers.ContentDisposition =
					new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
					{
						FileName = (isPdf ? "Updated_" + Path.GetFileNameWithoutExtension(file) + ".pdf" : "Updated_" + file)
					};

					result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

					return result;
				}
			}
			catch (Exception exc)
			{
				if (original != null)
					original.Close();

				throw exc;
			}
		}
	}
}