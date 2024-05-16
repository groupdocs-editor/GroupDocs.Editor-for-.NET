using GroupDocs.Editor.MVC.Controllers;
using GroupDocs.Editor.MVC.Products.Common.Entity.Web;
using Huygens;
using MvcContrib.TestHelper;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Routing;

namespace GroupDocs.Editor.MVC.Test
{
    [TestFixture]
    public static class EditorControllerTest
    {


        [SetUp]
        public static void TestInitialize()
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        [TearDown]
        public static void TearDown()
        {
            RouteTable.Routes.Clear();
        }

        [Test]
        public static void ViewStatusTest()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "/../../../src";
            using (var server = new DirectServer(path))
            {
                var request = new SerialisableRequest
                {
                    Method = "GET",
                    RequestUri = "/editor",
                    Content = null
                };

                var result = server.DirectCall(request);
                Assert.That(result.StatusCode, Is.EqualTo(200));
            }
        }

        [Test]
        public static void ViewMapControllerTest()
        {
            "~/editor".Route().ShouldMapTo<EditorController>(x => x.Index());
        }

        [Test]
        public static void FileTreeStatusCodeTest()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "/../../../src";
            using (var server = new DirectServer(path))
            {

                PostedDataEntity requestData = new PostedDataEntity();
                requestData.path = "";

                var request = new SerialisableRequest
                {
                    Method = "POST",
                    RequestUri = "/loadfiletree",
                    Content = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(requestData)),
                    Headers = new Dictionary<string, string>{
                        { "Content-Type", "application/json"},
                        { "Content-Length", JsonConvert.SerializeObject(requestData).Length.ToString()}
                    }
                };

                var result = server.DirectCall(request);
                Assert.That(result.StatusCode, Is.EqualTo(200));
            }
        }
    }
}
