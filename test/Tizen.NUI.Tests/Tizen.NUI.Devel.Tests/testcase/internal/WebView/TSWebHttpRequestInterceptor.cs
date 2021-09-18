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
    [Description("internal/WebView/WebHttpRequestInterceptor")]
    public class InternalWebHttpRequestInterceptorTest
    {
        private const string tag = "NUITEST";
        private string url = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";
        private static string[] runtimeArgs = { "Tizen.NUI.Devel.Tests", "--enable-dali-window", "--enable-spatial-navigation" };
        private const string USER_AGENT = "Mozilla/5.0 (SMART-TV; Linux; Tizen 6.0) AppleWebKit/537.36 (KHTML, like Gecko) SamsungBrowser/4.0 Chrome/76.0.3809.146 TV Safari/537.36";

        internal class MyWebHttpRequestInterceptor : WebHttpRequestInterceptor
        {
            public MyWebHttpRequestInterceptor(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
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
        [Description("WebHttpRequestInterceptor constructor.")]
        [Property("SPEC", "Tizen.NUI.WebHttpRequestInterceptor.WebHttpRequestInterceptor C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebHttpRequestInterceptorConstructor()
        {
            tlog.Debug(tag, $"WebHttpRequestInterceptorConstructor START");

            using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                var testingTarget = new WebHttpRequestInterceptor(webview.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<WebHttpRequestInterceptor>(testingTarget, "Should return WebHttpRequestInterceptor instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"WebHttpRequestInterceptorConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebHttpRequestInterceptor ReleaseSwigCPtr.")]
        [Property("SPEC", "Tizen.NUI.WebHttpRequestInterceptor.ReleaseSwigCPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebHttpRequestInterceptorReleaseSwigCPtr()
        {
            tlog.Debug(tag, $"WebHttpRequestInterceptorReleaseSwigCPtr START");

            using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                var testingTarget = new MyWebHttpRequestInterceptor(webview.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<WebHttpRequestInterceptor>(testingTarget, "Should return WebHttpRequestInterceptor instance.");

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

            tlog.Debug(tag, $"WebHttpRequestInterceptorReleaseSwigCPtr END (OK)");
        }
    }
}
