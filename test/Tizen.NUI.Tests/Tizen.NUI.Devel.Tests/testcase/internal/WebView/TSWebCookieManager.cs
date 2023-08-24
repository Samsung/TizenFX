using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Threading.Tasks;
using Tizen.WebView;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/WebView/WebCookieManager")]
    public class InternalWebCookieManagerTest
    {
        private const string tag = "NUITEST";
        private string urlForCookies = "https://www.baidu.com/";
        private BaseComponents.WebView webview;
        private WebCookieManager _cookieManager;
        private const string cookiePath = "/home/owner/.cookie";

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            webview = new BaseComponents.WebView()
            {
                Size = new Size(500, 200),
            };
            _cookieManager = webview.CookieManager;
        }

        [TearDown]
        public void Destroy()
        {
            tlog.Info(tag, "Destroy() is being called!");
            webview.Dispose();
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("WebCookieManager CookieChanged.")]
        [Property("SPEC", "Tizen.NUI.WebCookieManager.CookieAcceptPolicy A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebCookieManagerCookieAcceptPolicy()
        {
            tlog.Debug(tag, $"WebCookieManagerCookieAcceptPolicy START");

            _cookieManager.CookieAcceptPolicy = WebCookieManager.CookieAcceptPolicyType.Never;
            _cookieManager.SetPersistentStorage(cookiePath, WebCookieManager.CookiePersistentStorageType.SqlLite);

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tlog.Info(tag, "onLoadFinished is called!");
                tcs.TrySetResult(true);
            };
            webview.PageLoadFinished += onLoadFinished;

            webview.LoadUrl(urlForCookies);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            Assert.AreEqual(_cookieManager.CookieAcceptPolicy, WebCookieManager.CookieAcceptPolicyType.Never, "Failed to set CookieAcceptPolicyType!");

            webview.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebCookieManagerCookieAcceptPolicy END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebCookieManager CookieChanged.")]
        [Property("SPEC", "Tizen.NUI.WebCookieManager.CookieChanged E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebCookieManagerCookieChanged()
        {
            tlog.Debug(tag, $"WebCookieManagerCookieChanged START");

            _cookieManager.CookieAcceptPolicy = WebCookieManager.CookieAcceptPolicyType.Always;
            _cookieManager.SetPersistentStorage(cookiePath, WebCookieManager.CookiePersistentStorageType.SqlLite);

            TaskCompletionSource<bool> tcs1 = new TaskCompletionSource<bool>(false);

            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tlog.Info(tag, "onLoadFinished is called!");
                tcs1.TrySetResult(true);
            };
            webview.PageLoadFinished += onLoadFinished;

            webview.LoadUrl(urlForCookies);

            var result = await tcs1.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            TaskCompletionSource<bool> tcs2 = new TaskCompletionSource<bool>(false);
            EventHandler<EventArgs> onCookieChanged = (s, e) =>
            {
                tlog.Info(tag, "CookieChanged is called!");
                tcs2.TrySetResult(true);
            };

            _cookieManager.CookieChanged += onCookieChanged;

            const string addCookies = "document.cookie = \"username=John Doe\";";
            BaseComponents.WebView.JavaScriptMessageHandler onEvaluateJS = (message) =>
            {
                tlog.Info(tag, $"EvaluateJavaScript is called!, result is {message}");
            };
            webview.EvaluateJavaScript(addCookies, onEvaluateJS);

            tlog.Info(tag, "EvaluateJavaScript is called!");

            var result2 = await tcs2.Task;
            Assert.IsTrue(result2, "CookieChanged event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webview.PageLoadFinished -= onLoadFinished;
            _cookieManager.CookieChanged -= onCookieChanged;

            tlog.Debug(tag, $"WebCookieManagerCookieChanged END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebCookieManager CookieChanged.")]
        [Property("SPEC", "Tizen.NUI.WebCookieManager.ClearCookies M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebCookieManagerClearCookies()
        {
            tlog.Debug(tag, $"WebCookieManagerClearCookies START");

            _cookieManager.CookieAcceptPolicy = WebCookieManager.CookieAcceptPolicyType.Always;
            _cookieManager.SetPersistentStorage(cookiePath, WebCookieManager.CookiePersistentStorageType.SqlLite);

            TaskCompletionSource<bool> tcs1 = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tlog.Info(tag, "onLoadFinished is called!");
                tcs1.TrySetResult(true);
            };
            webview.PageLoadFinished += onLoadFinished;

            webview.LoadUrl(urlForCookies);
            var result = await tcs1.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            // Clear cookies.
            _cookieManager.ClearCookies(); //

            webview.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebCookieManagerClearCookies END (OK)");
        }
    }
}
