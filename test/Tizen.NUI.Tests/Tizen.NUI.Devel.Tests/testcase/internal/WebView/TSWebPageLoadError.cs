using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Threading.Tasks;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/WebView/WebPageLoadError")]
    public class InternalWebPageLoadErrorTest
    {
        private const string tag = "NUITEST";
        private string url = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";
        private static string[] runtimeArgs = { "Tizen.NUI.Devel.Tests", "--enable-dali-window", "--enable-spatial-navigation" };
        private const string USER_AGENT = "Mozilla/5.0 (SMART-TV; Linux; Tizen 6.0) AppleWebKit/537.36 (KHTML, like Gecko) SamsungBrowser/4.0 Chrome/76.0.3809.146 TV Safari/537.36";

        internal class MyWebPageLoadError : WebPageLoadError
        {
            public MyWebPageLoadError(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
            { }

            public void OnReleaseSwigCPtr(global::System.Runtime.InteropServices.HandleRef swigCPtr)
            {
                base.ReleaseSwigCPtr(swigCPtr);
            }
        }

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
        }

        [TearDown]
        public void Destroy()
        {
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("WebPageLoadError constructor.")]
        [Property("SPEC", "Tizen.NUI.WebPageLoadError.WebPageLoadError C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebPageLoadErrorConstructor()
        {
            tlog.Debug(tag, $"WebPageLoadErrorConstructor START");

            using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                var testingTarget = new WebPageLoadError(webview.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<WebPageLoadError>(testingTarget, "Should return WebPageLoadError instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"WebPageLoadErrorConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebPageLoadError ReleaseSwigCPtr.")]
        [Property("SPEC", "Tizen.NUI.WebPageLoadError.ReleaseSwigCPtr C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebPageLoadErrorReleaseSwigCPtr()
        {
            tlog.Debug(tag, $"WebPageLoadErrorReleaseSwigCPtr START");

            using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                var testingTarget = new MyWebPageLoadError(webview.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<WebPageLoadError>(testingTarget, "Should return WebPageLoadError instance.");

                try
                {
                    testingTarget.OnReleaseSwigCPtr(testingTarget.SwigCPtr);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }

            tlog.Debug(tag, $"WebPageLoadErrorReleaseSwigCPtr END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebPageLoadError Url.")]
        [Property("SPEC", "Tizen.NUI.WebPageLoadError.Url A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebPageLoadErrorUrl()
        {
            tlog.Debug(tag, $"WebPageLoadErrorUrl START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView(runtimeArgs)
            {
                Size = new Size(500, 200),
                UserAgent = USER_AGENT
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return Tizen.NUI.BaseComponents.WebView instance.");

            testingTarget.PageLoadError += OnPageLoadError;
            NUIApplication.GetDefaultWindow().Add(testingTarget);

            testingTarget.LoadUrl("http://111");

            await Task.Delay(10000);
            testingTarget.ClearCache();
            testingTarget.ClearCookies();
            NUIApplication.GetDefaultWindow().Remove(testingTarget);

            testingTarget.Dispose();
            tlog.Debug(tag, $"WebPageLoadErrorUrl END (OK)");
        }

        private void OnPageLoadError(object sender, WebViewPageLoadErrorEventArgs e)
        {
            Log.Info(tag, $"load error, Url: {e.PageLoadError.Url}");
            Log.Info(tag, $"load error, Code: {e.PageLoadError.Code}");
            Log.Info(tag, $"load error, Description: {e.PageLoadError.Description}");
            Log.Info(tag, $"load error, Type: {e.PageLoadError.Type}");
        }
    }
}
