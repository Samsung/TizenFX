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
    [Description("public/WebView/WebPageLoadError")]
    public class PublicWebPageLoadErrorTest
    {
        private const string tag = "NUITEST";
        private const string errorUrl = "file:///file_that_does_not_exist.html";
        private BaseComponents.WebView webview = null;

        [SetUp]
        public void Init()
        {
            webview = new BaseComponents.WebView()
            {
                Size = new Size(500, 200)
            };
            tlog.Info(tag, "Init() is called!");
        }

        [TearDown]
        public void Destroy()
        {
            webview.Dispose();
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("WebPageLoadError Url.")]
        [Property("SPEC", "Tizen.NUI.WebPageLoadError.Url A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebPageLoadError()
        {
            tlog.Debug(tag, $"WebPageLoadErrorUrl START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadErrorEventArgs> onLoadError = (s, e) =>
            {
                bool failed = true;
                var url = e.PageLoadError.Url;
                Log.Info(tag, $"load error, Url: {url}");
                if (url is string && url.Equals(errorUrl))
                {
                    failed = false;
                }

                var code = e.PageLoadError.Code;
                Log.Info(tag, $"load error, Code: {code}");
                if (code.GetType() == typeof(WebPageLoadError.ErrorCode) && (code.Equals(NUI.WebPageLoadError.ErrorCode.CannotLookupHost) || code.Equals(NUI.WebPageLoadError.ErrorCode.Unknown)))
                {
                    failed = false;
                }

                var type = e.PageLoadError.Type;
                Log.Info(tag, $"load error, Type: {type}");
                if (type.GetType() == typeof(WebPageLoadError.ErrorType) && type.Equals(NUI.WebPageLoadError.ErrorType.Network))
                {
                    failed = false;
                }

                var description = e.PageLoadError.Description;
                Log.Info(tag, $"load error, Description: {description}");
                if (description is string)
                {
                    failed = false;
                }

                tcs.TrySetResult(!failed);
            };

            webview.PageLoadError += onLoadError;

            webview.LoadUrl(errorUrl);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadError should be invoked.");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webview.PageLoadError -= onLoadError;

            tlog.Debug(tag, $"WebPageLoadErrorUrl END (OK)");
        }
    }
}
