using System.Net.Http;
using System.Net.Http.Headers;
using GroupDocs.Editor.Live.Demos.UI.Config;
using GroupDocs.Editor.Live.Demos.UI.Models;
using System.IO;
using System.Diagnostics;
using System;

namespace GroupDocs.Editor.Live.Demos.UI.Helpers
{
	public class GroupDocsEditorApiHelper : ApiHelperBase
	{
		public static Response GetAllEditorSupportedFormats()
		{
			Response EditorResponse = null;

			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				System.Threading.Tasks.Task taskUpload = client.GetAsync(Configuration.GroupDocsAppsAPIBasePath + "api/GroupDocsEditor/GetAllEditorSupportedFormats").ContinueWith(task =>
				{
					if (task.Status == System.Threading.Tasks.TaskStatus.RanToCompletion)
					{
						HttpResponseMessage response = task.Result;
						if (response.IsSuccessStatusCode)
						{
							EditorResponse = response.Content.ReadAsAsync<Response>().Result;
						}
					}
				});
				taskUpload.Wait();
			}

			return EditorResponse;
		}
	}
}