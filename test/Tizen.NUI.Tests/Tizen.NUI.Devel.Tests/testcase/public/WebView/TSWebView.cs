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
    [Description("public/WebView/WebView")]
    public class PublicWebViewTest
    {
        private const string tag = "NUITEST";
        private string url = $"file://{Applications.Application.Current.DirectoryInfo.Resource}webview/index.html";
        private string secondUrl = $"file://{Applications.Application.Current.DirectoryInfo.Resource}webview/second.html";
        private string urlForNavigationPolicyTest = "http://www.google.com";
        private string urlForCertificateConfirmTest = "https://wrong.host.badssl.com/";
        private string urlForResponsePolicyTest = "http://www.samsung.com";
        private string urlForConsoleMessageTest = $"file://{Applications.Application.Current.DirectoryInfo.Resource}webview/console_info.html";

        private static string[] runtimeArgs = { "--enable-dali-window", "--enable-spatial-navigation" };
        private const string USER_AGENT = "Mozilla/5.0 (SMART-TV; Linux; Tizen 6.0) AppleWebKit/537.36 (KHTML, like Gecko) SamsungBrowser/4.0 Chrome/76.0.3809.146 TV Safari/537.36";
        private BaseComponents.WebView webView = null;

        private void JsCallback(string arg) { }
        private void VideoCallback(bool arg) { }
        private void GeolocationCallback(string arg1, string arg2) { }
        private void PromptCallback(string arg1, string arg2) { }
        private void PlainReceivedCallback(string arg2) { }
        private void ScreenshotAcquiredCallbackCase(ImageView image) { }

        internal class MyWebView : BaseComponents.WebView
        {
            public MyWebView() : base()
            { }

            public void OnDispose(DisposeTypes type)
            {
                base.Dispose(type);
            }
        }

        [SetUp]
        public void Init()
        {
            webView = new BaseComponents.WebView(runtimeArgs)
            {
                Size = new Size(150, 100),
            };
            tlog.Info(tag, "Init() is called!");
        }

        [TearDown]
        public void Destroy()
        {
            tlog.Info(tag, "Destroy() is being called!");
            webView.Dispose();
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("WebView constructor.")]
        [Property("SPEC", "Tizen.NUI.WebView.WebView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewConstructor()
        {
            tlog.Debug(tag, $"WebViewConstructor START");

            Assert.IsNotNull(webView, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(webView, "Should return WebView instance.");

            tlog.Debug(tag, $"WebViewConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView constructor.")]
        [Property("SPEC", "Tizen.NUI.WebView.WebView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewConstructorWithLocaleAndTimezone()
        {
            tlog.Debug(tag, $"WebViewConstructorWithLocaleAndTimezone START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            testingTarget?.Dispose();
            tlog.Debug(tag, $"WebViewConstructorWithLocaleAndTimezone END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView constructor.")]
        [Property("SPEC", "Tizen.NUI.WebView.WebView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewConstructorWithWebView()
        {
            tlog.Debug(tag, $"WebViewConstructorWithWebView START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView(webView);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"WebViewConstructorWithWebView END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView PageLoadStarted.")]
        [Property("SPEC", "Tizen.NUI.WebView.PageLoadStarted E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewPageLoadStarted()
        {
            tlog.Debug(tag, $"WebViewPageLoadStarted START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadStarted = (s, e) => { tcs.TrySetResult(true); };
            webView.PageLoadStarted += onLoadStarted;

            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadStarted event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.PageLoadStarted -= onLoadStarted;

            tlog.Debug(tag, $"WebViewPageLoadStarted END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView PageLoading.")]
        [Property("SPEC", "Tizen.NUI.WebView.PageLoading E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewPageLoading()
        {
            tlog.Debug(tag, $"WebViewPageLoading START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoading = (s, e) => { tcs.TrySetResult(true); };
            webView.PageLoading += onLoading;

            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoading event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.PageLoading -= onLoading;

            tlog.Debug(tag, $"WebViewPageLoading END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView PageLoadFinished.")]
        [Property("SPEC", "Tizen.NUI.WebView.PageLoadFinished E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewPageLoadFinished()
        {
            tlog.Debug(tag, $"WebViewPageLoadFinished START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) => { tcs.TrySetResult(true); };
            webView.PageLoadFinished += onLoadFinished;

            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebViewPageLoadFinished END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView UrlChanged.")]
        [Property("SPEC", "Tizen.NUI.WebView.UrlChanged E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewUrlChanged()
        {
            tlog.Debug(tag, $"WebViewUrlChanged START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);

            EventHandler<WebViewUrlChangedEventArgs> onUrlChange = (s, e) =>
            {
                Assert.IsNotNull(e.NewPageUrl, "New page url should not be null");
                tcs.TrySetResult(true);
            };
            webView.UrlChanged += onUrlChange;

            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "UrlChanged event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.UrlChanged -= onUrlChange;

            tlog.Debug(tag, $"WebViewUrlChanged END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView FrameRendered.")]
        [Property("SPEC", "Tizen.NUI.WebView.FrameRendered A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewFrameRendered()
        {
            tlog.Debug(tag, $"WebViewFrameRendered START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<EventArgs> onFrameRender = (s, e) => { tcs.TrySetResult(true); };
            webView.FrameRendered += onFrameRender;

            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "FrameRendered event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.FrameRendered -= onFrameRender;

            tlog.Debug(tag, $"WebViewFrameRendered END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView ResponsePolicyDecided.")]
        [Property("SPEC", "Tizen.NUI.WebView.ResponsePolicyDecided A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewResponsePolicyDecided()
        {
            tlog.Debug(tag, $"WebViewResponsePolicyDecided START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPolicyDecidedEventArgs> onResponsePolicyDecide = (s, e) => { tcs.TrySetResult(true); };
            webView.ResponsePolicyDecided += onResponsePolicyDecide;

            webView.LoadUrl(urlForResponsePolicyTest);
            var result = await tcs.Task;
            Assert.IsTrue(result, "ResponsePolicyDecided event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.ResponsePolicyDecided -= onResponsePolicyDecide;

            tlog.Debug(tag, $"WebViewResponsePolicyDecided END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView NavigationPolicyDecided.")]
        [Property("SPEC", "Tizen.NUI.WebView.NavigationPolicyDecided A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewNavigationPolicyDecided()
        {
            tlog.Debug(tag, $"WebViewNavigationPolicyDecided START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);

            EventHandler<WebViewPolicyDecidedEventArgs> onNavigationPolicyDecided = (s, e) =>
            {
                tlog.Info(tag, "onNavigationPolicyDecided is being called!");
                tcs.TrySetResult(true);
            };
            webView.NavigationPolicyDecided += onNavigationPolicyDecided;

            webView.LoadUrl(urlForNavigationPolicyTest);
            var result = await tcs.Task;
            Assert.IsTrue(result, "NavigationPolicyDecided event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.NavigationPolicyDecided -= onNavigationPolicyDecided;

            tlog.Debug(tag, $"WebViewNavigationPolicyDecided END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView CertificateConfirmed.")]
        [Property("SPEC", "Tizen.NUI.WebView.CertificateConfirmed A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewCertificateConfirmed()
        {
            tlog.Debug(tag, $"WebViewCertificateConfirmed START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);

            EventHandler<WebViewCertificateReceivedEventArgs> onCertificateConfirme = (s, e) =>
            {
                tlog.Info(tag, "CertificateConfirmed is being called!");
                tcs.TrySetResult(true);
            };
            webView.CertificateConfirmed += onCertificateConfirme;

            webView.LoadUrl(urlForCertificateConfirmTest);
            var result = await tcs.Task;
            Assert.IsTrue(result, "CertificateConfirmed event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.CertificateConfirmed -= onCertificateConfirme;

            tlog.Debug(tag, $"WebViewCertificateConfirmed END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView SslCertificateChanged.")]
        [Property("SPEC", "Tizen.NUI.WebView.SslCertificateChanged A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewSslCertificateChanged()
        {
            tlog.Debug(tag, $"WebViewSslCertificateChanged START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewCertificateReceivedEventArgs> onSslCertificateChange = (s, e) => { tcs.TrySetResult(true); };
            webView.SslCertificateChanged += onSslCertificateChange;

            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "SslCertificateChanged event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.SslCertificateChanged -= onSslCertificateChange;

            tlog.Debug(tag, $"WebViewSslCertificateChanged END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView ConsoleMessageReceived.")]
        [Property("SPEC", "Tizen.NUI.WebView.ConsoleMessageReceived A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewConsoleMessageReceived()
        {
            tlog.Debug(tag, $"WebViewConsoleMessageReceived START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewConsoleMessageReceivedEventArgs> onConsoleMessageReceive = (s, e) => { tcs.TrySetResult(true); };
            webView.ConsoleMessageReceived += onConsoleMessageReceive;

            webView.LoadUrl(urlForConsoleMessageTest);
            var result = await tcs.Task;
            Assert.IsTrue(result, "ConsoleMessageReceived event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.ConsoleMessageReceived -= onConsoleMessageReceive;

            tlog.Debug(tag, $"WebViewConsoleMessageReceived END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView BackForwardList.")]
        [Property("SPEC", "Tizen.NUI.WebView.BackForwardList A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewBackForwardList()
        {
            tlog.Debug(tag, $"WebViewBackForwardList START");

            var result = webView.BackForwardList;
            tlog.Debug(tag, "ForwardList : " + result);

            tlog.Debug(tag, $"WebViewBackForwardList END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView Context.")]
        [Property("SPEC", "Tizen.NUI.WebView.Context A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewContext()
        {
            tlog.Debug(tag, $"WebViewContext START");

            var result = webView.Context;
            tlog.Debug(tag, "Context : " + result);

            tlog.Debug(tag, $"WebViewContext END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView CookieManager.")]
        [Property("SPEC", "Tizen.NUI.WebView.CookieManager A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewCookieManager()
        {
            tlog.Debug(tag, $"WebViewCookieManager START");

            var result = webView.CookieManager;
            tlog.Debug(tag, "CookieManager : " + result);

            tlog.Debug(tag, $"WebViewCookieManager END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView Settings.")]
        [Property("SPEC", "Tizen.NUI.WebView.Settings A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewSettings()
        {
            tlog.Debug(tag, $"WebViewSettings START");

            var result = webView.Settings;
            tlog.Debug(tag, "Settings : " + result);

            tlog.Debug(tag, $"WebViewSettings END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView Url.")]
        [Property("SPEC", "Tizen.NUI.WebView.Url A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewUrl()
        {
            tlog.Debug(tag, $"WebViewUrl START");
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tcs.TrySetResult(true);
            };
            webView.PageLoadFinished += onLoadFinished;

            webView.Url = url;
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, "Url : " + webView.Url);
            tlog.Debug(tag, $"WebViewUrl END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView CacheModel.")]
        [Property("SPEC", "Tizen.NUI.WebView.CacheModel A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewCacheModel()
        {
            tlog.Debug(tag, $"WebViewCacheModel START");

            webView.CacheModel = Tizen.NUI.CacheModel.DocumentViewer;
            tlog.Debug(tag, "CacheModel : " + webView.CacheModel);

            webView.CacheModel = Tizen.NUI.CacheModel.DocumentBrowser;
            tlog.Debug(tag, "CacheModel : " + webView.CacheModel);

            webView.CacheModel = Tizen.NUI.CacheModel.PrimaryWebBrowser;
            tlog.Debug(tag, "CacheModel : " + webView.CacheModel);

            tlog.Debug(tag, $"WebViewCacheModel END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView CookieAcceptPolicy.")]
        [Property("SPEC", "Tizen.NUI.WebView.CookieAcceptPolicy A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewCookieAcceptPolicy()
        {
            tlog.Debug(tag, $"WebViewCookieAcceptPolicy START");

            webView.CookieAcceptPolicy = (CookieAcceptPolicy)Tizen.NUI.WebCookieManager.CookieAcceptPolicyType.NoThirdParty;
            tlog.Debug(tag, "CookieAcceptPolicy : " + webView.CookieAcceptPolicy);

            webView.CookieAcceptPolicy = (CookieAcceptPolicy)Tizen.NUI.WebCookieManager.CookieAcceptPolicyType.Always;
            tlog.Debug(tag, "CookieAcceptPolicy : " + webView.CookieAcceptPolicy);

            webView.CookieAcceptPolicy = (CookieAcceptPolicy)Tizen.NUI.WebCookieManager.CookieAcceptPolicyType.Never;
            tlog.Debug(tag, "CookieAcceptPolicy : " + webView.CookieAcceptPolicy);

            tlog.Debug(tag, $"WebViewCookieAcceptPolicy END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView UserAgent.")]
        [Property("SPEC", "Tizen.NUI.WebView.UserAgent A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewUserAgent()
        {
            tlog.Debug(tag, $"WebViewUserAgent START");

            webView.UserAgent = USER_AGENT;
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tcs.TrySetResult(true);
            };
            webView.PageLoadFinished += onLoadFinished;
            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, "UserAgent : " + webView.UserAgent);
            tlog.Debug(tag, $"WebViewUserAgent END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView EnableJavaScript.")]
        [Property("SPEC", "Tizen.NUI.WebView.EnableJavaScript A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewEnableJavaScript()
        {
            tlog.Debug(tag, $"WebViewEnableJavaScript START");

            webView.EnableJavaScript = true;
            tlog.Debug(tag, "EnableJavaScript : " + webView.EnableJavaScript);

            webView.EnableJavaScript = false;
            tlog.Debug(tag, "EnableJavaScript : " + webView.EnableJavaScript);

            tlog.Debug(tag, $"WebViewEnableJavaScript END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView LoadImagesAutomatically.")]
        [Property("SPEC", "Tizen.NUI.WebView.LoadImagesAutomatically A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewLoadImagesAutomatically()
        {
            tlog.Debug(tag, $"WebViewLoadImagesAutomatically START");

            webView.LoadImagesAutomatically = true;
            tlog.Debug(tag, "LoadImagesAutomatically : " + webView.LoadImagesAutomatically);

            webView.LoadImagesAutomatically = false;
            tlog.Debug(tag, "LoadImagesAutomatically : " + webView.LoadImagesAutomatically);

            tlog.Debug(tag, $"WebViewLoadImagesAutomatically END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView DefaultTextEncodingName.")]
        [Property("SPEC", "Tizen.NUI.WebView.DefaultTextEncodingName A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewDefaultTextEncodingName()
        {
            tlog.Debug(tag, $"WebViewDefaultTextEncodingName START");

            var result = webView.DefaultTextEncodingName;
            tlog.Debug(tag, "DefaultTextEncodingName : " + result);

            webView.DefaultTextEncodingName = "gbk";
            tlog.Debug(tag, "DefaultTextEncodingName : " + result);

            tlog.Debug(tag, $"WebViewDefaultTextEncodingName END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView DefaultFontSize.")]
        [Property("SPEC", "Tizen.NUI.WebView.DefaultFontSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewDefaultFontSize()
        {
            tlog.Debug(tag, $"WebViewDefaultFontSize START");

            var result = webView.DefaultFontSize;
            tlog.Debug(tag, "DefaultFontSize : " + result);

            webView.DefaultFontSize = 32;
            tlog.Debug(tag, "DefaultFontSize : " + result);

            tlog.Debug(tag, $"WebViewDefaultFontSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView ScrollSize.")]
        [Property("SPEC", "Tizen.NUI.WebView.ScrollSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewScrollSize()
        {
            tlog.Debug(tag, $"WebViewScrollSize START");

            tlog.Debug(tag, "Width : " + webView.ScrollSize.Width);
            tlog.Debug(tag, "Height : " + webView.ScrollSize.Height);

            tlog.Debug(tag, $"WebViewScrollSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView ContentSize.")]
        [Property("SPEC", "Tizen.NUI.WebView.ContentSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewContentSize()
        {
            tlog.Debug(tag, $"WebViewContentSize START");

            tlog.Debug(tag, "Width : " + webView.ContentSize.Width);
            tlog.Debug(tag, "Height : " + webView.ContentSize.Height);

            tlog.Debug(tag, $"WebViewContentSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView VideoHoleEnabled.")]
        [Property("SPEC", "Tizen.NUI.WebView.VideoHoleEnabled A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewVideoHoleEnabled()
        {
            tlog.Debug(tag, $"WebViewVideoHoleEnabled START");

            webView.VideoHoleEnabled = true;
            tlog.Debug(tag, "VideoHoleEnabled : " + webView.VideoHoleEnabled);

            webView.VideoHoleEnabled = false;
            tlog.Debug(tag, "VideoHoleEnabled : " + webView.VideoHoleEnabled);

            tlog.Debug(tag, $"WebViewVideoHoleEnabled END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView MouseEventsEnabled.")]
        [Property("SPEC", "Tizen.NUI.WebView.MouseEventsEnabled A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewMouseEventsEnabled()
        {
            tlog.Debug(tag, $"WebViewMouseEventsEnabled START");

            webView.MouseEventsEnabled = true;
            tlog.Debug(tag, "MouseEventsEnabled : " + webView.MouseEventsEnabled);

            webView.MouseEventsEnabled = false;
            tlog.Debug(tag, "MouseEventsEnabled : " + webView.MouseEventsEnabled);

            tlog.Debug(tag, $"WebViewMouseEventsEnabled END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView KeyEventsEnabled.")]
        [Property("SPEC", "Tizen.NUI.WebView.KeyEventsEnabled A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewKeyEventsEnabled()
        {
            tlog.Debug(tag, $"WebViewKeyEventsEnabled START");

            webView.KeyEventsEnabled = true;
            tlog.Debug(tag, "KeyEventsEnabled : " + webView.KeyEventsEnabled);

            webView.KeyEventsEnabled = false;
            tlog.Debug(tag, "KeyEventsEnabled : " + webView.KeyEventsEnabled);

            tlog.Debug(tag, $"WebViewKeyEventsEnabled END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView ContentBackgroundColor.")]
        [Property("SPEC", "Tizen.NUI.WebView.ContentBackgroundColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewContentBackgroundColor()
        {
            tlog.Debug(tag, $"WebViewContentBackgroundColor START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                webView.ContentBackgroundColor = new Vector4(0.3f, 0.5f, 1.0f, 0.0f);
                tcs.TrySetResult(true);
            };
            webView.PageLoadFinished += onLoadFinished;
            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, "ContentBackgroundColor : " + webView.ContentBackgroundColor);

            tlog.Debug(tag, $"WebViewContentBackgroundColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView TilesClearedWhenHidden.")]
        [Property("SPEC", "Tizen.NUI.WebView.TilesClearedWhenHidden A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewTilesClearedWhenHidden()
        {
            tlog.Debug(tag, $"WebViewTilesClearedWhenHidden START");

            webView.TilesClearedWhenHidden = true;
            tlog.Debug(tag, "TilesClearedWhenHidden : " + webView.TilesClearedWhenHidden);

            webView.TilesClearedWhenHidden = false;
            tlog.Debug(tag, "TilesClearedWhenHidden : " + webView.TilesClearedWhenHidden);

            tlog.Debug(tag, $"WebViewTilesClearedWhenHidden END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView TileCoverAreaMultiplier.")]
        [Property("SPEC", "Tizen.NUI.WebView.TileCoverAreaMultiplier A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewTileCoverAreaMultiplier()
        {
            tlog.Debug(tag, $"WebViewTileCoverAreaMultiplier START");

            webView.TileCoverAreaMultiplier = 0.3f;
            tlog.Debug(tag, "TileCoverAreaMultiplier : " + webView.TileCoverAreaMultiplier);

            tlog.Debug(tag, $"WebViewTileCoverAreaMultiplier END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView CursorEnabledByClient.")]
        [Property("SPEC", "Tizen.NUI.WebView.CursorEnabledByClient A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewCursorEnabledByClient()
        {
            tlog.Debug(tag, $"WebViewCursorEnabledByClient START");

            webView.CursorEnabledByClient = true;
            tlog.Debug(tag, "CursorEnabledByClient : " + webView.CursorEnabledByClient);

            webView.CursorEnabledByClient = false;
            tlog.Debug(tag, "CursorEnabledByClient : " + webView.CursorEnabledByClient);

            tlog.Debug(tag, $"WebViewCursorEnabledByClient END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView SelectedText.")]
        [Property("SPEC", "Tizen.NUI.WebView.SelectedText A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewSelectedText()
        {
            tlog.Debug(tag, $"WebViewSelectedText START");

            var text = webView.SelectedText;
            tlog.Debug(tag, "SelectedText : " + text);

            tlog.Debug(tag, $"WebViewSelectedText END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView Title.")]
        [Property("SPEC", "Tizen.NUI.WebView.Title A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewTitle()
        {
            tlog.Debug(tag, $"WebViewTitle START");

            var title = webView.Title;
            tlog.Debug(tag, "Title : " + title);

            tlog.Debug(tag, $"WebViewTitle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView Favicon.")]
        [Property("SPEC", "Tizen.NUI.WebView.Favicon A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewFavicon()
        {
            tlog.Debug(tag, $"WebViewFavicon START");

            var fav = webView.Favicon;
            tlog.Debug(tag, "Favicon : " + fav);

            tlog.Debug(tag, $"WebViewFavicon END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView PageZoomFactor.")]
        [Property("SPEC", "Tizen.NUI.WebView.PageZoomFactor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewPageZoomFactor()
        {
            tlog.Debug(tag, $"WebViewPageZoomFactor START");

            webView.PageZoomFactor = 0.3f;
            tlog.Debug(tag, "PageZoomFactor : " + webView.PageZoomFactor);

            tlog.Debug(tag, $"WebViewPageZoomFactor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView TextZoomFactor.")]
        [Property("SPEC", "Tizen.NUI.WebView.TextZoomFactor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewTextZoomFactor()
        {
            tlog.Debug(tag, $"WebViewTextZoomFactor START");

            webView.TextZoomFactor = 0.2f;
            tlog.Debug(tag, "TextZoomFactor : " + webView.TextZoomFactor);

            tlog.Debug(tag, $"WebViewTextZoomFactor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView LoadProgressPercentage.")]
        [Property("SPEC", "Tizen.NUI.WebView.LoadProgressPercentage A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewLoadProgressPercentage()
        {
            tlog.Debug(tag, $"WebViewLoadProgressPercentage START");

            var result = webView.LoadProgressPercentage;
            tlog.Debug(tag, "LoadProgressPercentage : " + result);

            tlog.Debug(tag, $"WebViewLoadProgressPercentage END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView LoadHtmlString.")]
        [Property("SPEC", "Tizen.NUI.WebView.LoadHtmlString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewLoadHtmlString()
        {
            tlog.Debug(tag, $"WebViewLoadHtmlString START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tlog.Info(tag, "onLoadFinished is called!");
                tcs.TrySetResult(true);
            };
            webView.PageLoadFinished += onLoadFinished;

            webView.LoadHtmlString("<html><head lang=\"en\"></head></html>");

            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebViewLoadHtmlString END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView LoadHTMLString.")]
        [Property("SPEC", "Tizen.NUI.WebView.LoadHTMLString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewLoadHTMLString()
        {
            tlog.Debug(tag, $"WebViewLoadHTMLString START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tlog.Info(tag, "onLoadFinished is called!");
                tcs.TrySetResult(true);
            };
            webView.PageLoadFinished += onLoadFinished;

            webView.LoadHTMLString("<html><head lang=\"en\"></head></html>");

            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebViewLoadHTMLString END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView LoadContents.")]
        [Property("SPEC", "Tizen.NUI.WebView.LoadContents M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewLoadContents()
        {
            tlog.Debug(tag, $"WebViewLoadContents START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tlog.Info(tag, "onLoadFinished is called!");
                tcs.TrySetResult(true);
            };
            webView.PageLoadFinished += onLoadFinished;

            webView.LoadContents("body", 18, " ", "gbk", null);

            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebViewLoadContents END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView Reload.")]
        [Property("SPEC", "Tizen.NUI.WebView.Reload M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewReload()
        {
            tlog.Debug(tag, $"WebViewReload START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tlog.Info(tag, "onLoadFinished is called!");
                tcs.TrySetResult(true);
            };
            webView.PageLoadFinished += onLoadFinished;

            webView.LoadUrl(url);

            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.Reload();

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebViewReload END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView ReloadWithoutCache.")]
        [Property("SPEC", "Tizen.NUI.WebView.ReloadWithoutCache M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewReloadWithoutCache()
        {
            tlog.Debug(tag, $"WebViewReloadWithoutCache START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tlog.Info(tag, "onLoadFinished is called!");
                tcs.TrySetResult(true);
            };
            webView.PageLoadFinished += onLoadFinished;

            webView.LoadUrl(url);

            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.ReloadWithoutCache();

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebViewReloadWithoutCache END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView StopLoading.")]
        [Property("SPEC", "Tizen.NUI.WebView.StopLoading M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewStopLoading()
        {
            tlog.Debug(tag, $"WebViewStopLoading START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadStarted = (s, e) =>
            {
                tlog.Info(tag, "onLoadFinished is called!");
                tcs.TrySetResult(true);
            };
            webView.PageLoadStarted += onLoadStarted;

            webView.LoadUrl(url);

            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadStarted event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.StopLoading();

            webView.PageLoadStarted -= onLoadStarted;

            tlog.Debug(tag, $"WebViewStopLoading END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView Suspend.")]
        [Property("SPEC", "Tizen.NUI.WebView.Suspend M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewSuspend()
        {
            tlog.Debug(tag, $"WebViewSuspend START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tlog.Info(tag, "onLoadFinished is called!");          
                tcs.TrySetResult(true);
            };
            webView.PageLoadFinished += onLoadFinished;
            webView.LoadUrl(url);

            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.Suspend();
            webView.Resume();

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebViewSuspend END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView SuspendNetworkLoading.")]
        [Property("SPEC", "Tizen.NUI.WebView.SuspendNetworkLoading M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewSuspendNetworkLoading()
        {
            tlog.Debug(tag, $"WebViewSuspendNetworkLoading START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tlog.Info(tag, "onLoadFinished is called!");
                tcs.TrySetResult(true);
            };
            webView.PageLoadFinished += onLoadFinished;

            webView.LoadUrl(url);

            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.SuspendNetworkLoading();
            webView.ResumeNetworkLoading();

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebViewSuspendNetworkLoading END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView AddCustomHeader.")]
        [Property("SPEC", "Tizen.NUI.WebView.AddCustomHeader M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewAddCustomHeader()
        {
            tlog.Debug(tag, $"WebViewAddCustomHeader START");

            var result = webView.AddCustomHeader("customHeader_title", "font-size: 32rpx");
            tlog.Debug(tag, "AddCustomHeader : " + result);

            result = webView.RemoveCustomHeader("customHeader_title");
            tlog.Debug(tag, "RemoveCustomHeader : " + result);

            tlog.Debug(tag, $"WebViewAddCustomHeader END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView ScrollBy.")]
        [Property("SPEC", "Tizen.NUI.WebView.ScrollBy M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewScrollBy()
        {
            tlog.Debug(tag, $"WebViewScrollBy START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tlog.Info(tag, "onLoadFinished is called!");
                tcs.TrySetResult(true);
            };
            webView.PageLoadFinished += onLoadFinished;

            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "ScrollEdgeReached event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.ScrollBy(0, 60);

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebViewScrollBy END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView ScrollEdgeBy.")]
        [Property("SPEC", "Tizen.NUI.WebView.ScrollEdgeBy M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewScrollEdgeBy()
        {
            tlog.Debug(tag, $"WebViewScrollEdgeBy START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tlog.Info(tag, "onLoadFinished is called!");
                tcs.TrySetResult(true);
            };
            webView.PageLoadFinished += onLoadFinished;

            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.ScrollEdgeBy(0, 60);

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebViewScrollEdgeBy END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView GoBack.")]
        [Property("SPEC", "Tizen.NUI.WebView.GoBack M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewGoBack()
        {
            tlog.Debug(tag, $"WebViewGoBack START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                if (webView.Url.Contains("index.html"))
                {
                    tlog.Info(tag, "onLoadFinished is called!");
                    webView.LoadUrl(secondUrl);
                }
                else
                {
                    tlog.Info(tag, "onLoadFinished is called!");
                    tcs.TrySetResult(true);
                }
            };
            webView.PageLoadFinished += onLoadFinished;

            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.GoBack();

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebViewGoBack END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView GoForward.")]
        [Property("SPEC", "Tizen.NUI.WebView.GoForward M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewGoForward()
        {
            tlog.Debug(tag, $"WebViewGoForward START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                if (webView.Url.Contains("index.html"))
                {
                    tlog.Info(tag, "onLoadFinished is called!");
                    webView.LoadUrl(secondUrl);
                }
                else
                {
                    tlog.Info(tag, "onLoadFinished is called!");
                    tcs.TrySetResult(true);
                }
            };
            webView.PageLoadFinished += onLoadFinished;

            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.GoBack();
            webView.GoForward();

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebViewGoForward END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView CanGoBack.")]
        [Property("SPEC", "Tizen.NUI.WebView.CanGoBack M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewCanGoBack()
        {
            tlog.Debug(tag, $"WebViewCanGoBack START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                if (webView.Url.Contains("index.html"))
                {
                    tlog.Info(tag, "onLoadFinished is called!");
                    webView.LoadUrl(secondUrl);
                }
                else
                {
                    tlog.Info(tag, "onLoadFinished is called!");
                    tcs.TrySetResult(true);
                }
            };
            webView.PageLoadFinished += onLoadFinished;

            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            var canGo = webView.CanGoBack();
            Assert.IsTrue(canGo, "CanGoBack should be invoked");

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebViewCanGoBack END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView CanGoForward.")]
        [Property("SPEC", "Tizen.NUI.WebView.CanGoForward M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewCanGoForward()
        {
            tlog.Debug(tag, $"WebViewCanGoForward START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                if (webView.Url.Contains("index.html"))
                {
                    tlog.Info(tag, "onLoadFinished is called!");
                    webView.LoadUrl(secondUrl);
                }
                else
                {
                    tlog.Info(tag, "onLoadFinished is called!");
                    tcs.TrySetResult(true);
                }
            };
            webView.PageLoadFinished += onLoadFinished;

            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            if (webView.CanGoForward())
            {
                webView.GoBack();
            }

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebViewCanGoForward END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView EvaluateJavaScript.")]
        [Property("SPEC", "Tizen.NUI.WebView.EvaluateJavaScript M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewEvaluateJavaScript()
        {
            tlog.Debug(tag, $"WebViewEvaluateJavaScript START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tlog.Info(tag, "onLoadFinished is called!");
                tcs.TrySetResult(true);
            };
            webView.PageLoadFinished += onLoadFinished;

            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.EvaluateJavaScript("<script type=\"text / javascript\">document.write(\"page\");</script>");

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebViewEvaluateJavaScript END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView AddJavaScriptMessageHandler.")]
        [Property("SPEC", "Tizen.NUI.WebView.AddJavaScriptMessageHandler M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewAddJavaScriptMessageHandler()
        {
            tlog.Debug(tag, $"WebViewAddJavaScriptMessageHandler START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tlog.Info(tag, "onLoadFinished is called!");
                tcs.TrySetResult(true);
            };
            webView.PageLoadFinished += onLoadFinished;

            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.AddJavaScriptMessageHandler("AllowOrigin", JsCallback);

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebViewAddJavaScriptMessageHandler END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView RegisterJavaScriptAlertCallback.")]
        [Property("SPEC", "Tizen.NUI.WebView.RegisterJavaScriptAlertCallback M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewRegisterJavaScriptAlertCallback()
        {
            tlog.Debug(tag, $"WebViewRegisterJavaScriptAlertCallback START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tlog.Info(tag, "onLoadFinished is called!");
                tcs.TrySetResult(true);
            };
            webView.PageLoadFinished += onLoadFinished;

            webView.RegisterJavaScriptAlertCallback(JsCallback);

            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebViewRegisterJavaScriptAlertCallback END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView RegisterJavaScriptConfirmCallback.")]
        [Property("SPEC", "Tizen.NUI.WebView.RegisterJavaScriptConfirmCallback M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewRegisterJavaScriptConfirmCallback()
        {
            tlog.Debug(tag, $"WebViewRegisterJavaScriptConfirmCallback START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tlog.Info(tag, "onLoadFinished is called!");
                tcs.TrySetResult(true);
            };
            webView.PageLoadFinished += onLoadFinished;

            webView.RegisterJavaScriptConfirmCallback(JsCallback);

            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebViewRegisterJavaScriptConfirmCallback END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView RegisterJavaScriptPromptCallback.")]
        [Property("SPEC", "Tizen.NUI.WebView.RegisterJavaScriptPromptCallback M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewRegisterJavaScriptPromptCallback()
        {
            tlog.Debug(tag, $"WebViewRegisterJavaScriptPromptCallback START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tlog.Info(tag, "onLoadFinished is called!");
                tcs.TrySetResult(true);
            };
            webView.PageLoadFinished += onLoadFinished;

            webView.RegisterJavaScriptPromptCallback(PromptCallback);

            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebViewRegisterJavaScriptPromptCallback END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView ClearAllTilesResources.")]
        [Property("SPEC", "Tizen.NUI.WebView.ClearAllTilesResources M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewClearAllTilesResources()
        {
            tlog.Debug(tag, $"WebViewClearAllTilesResources START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tlog.Info(tag, "onLoadFinished is called!");
                tcs.TrySetResult(true);
            };
            webView.PageLoadFinished += onLoadFinished;

            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.ClearAllTilesResources();

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebViewClearAllTilesResources END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView ClearHistory.")]
        [Property("SPEC", "Tizen.NUI.WebView.ClearHistory M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewClearHistory()
        {
            tlog.Debug(tag, $"WebViewClearHistory START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tlog.Info(tag, "onLoadFinished is called!");
                tcs.TrySetResult(true);
            };
            webView.PageLoadFinished += onLoadFinished;

            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.ClearHistory();

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebViewClearHistory END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView SetScaleFactor.")]
        [Property("SPEC", "Tizen.NUI.WebView.SetScaleFactor M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewSetScaleFactor()
        {
            tlog.Debug(tag, $"WebViewSetScaleFactor START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tlog.Info(tag, "onLoadFinished is called!");
                tcs.TrySetResult(true);
            };
            webView.PageLoadFinished += onLoadFinished;

            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            using (Vector2 point = new Vector2(1.0f, 1.0f))
            {
                webView.SetScaleFactor(0.2f, point);

                var factor = webView.GetScaleFactor();
                tlog.Debug(tag, "ScaleFactor : " + factor);
            }

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebViewSetScaleFactor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView ActivateAccessibility.")]
        [Property("SPEC", "Tizen.NUI.WebView.ActivateAccessibility M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewActivateAccessibility()
        {
            tlog.Debug(tag, $"WebViewActivateAccessibility START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tlog.Info(tag, "onLoadFinished is called!");
                tcs.TrySetResult(true);
            };
            webView.PageLoadFinished += onLoadFinished;

            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.ActivateAccessibility(false);

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebViewActivateAccessibility END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView HighlightText.")]
        [Property("SPEC", "Tizen.NUI.WebView.HighlightText M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewHighlightText()
        {
            tlog.Debug(tag, $"WebViewHighlightText START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tlog.Info(tag, "onLoadFinished is called!");
                tcs.TrySetResult(true);
            };
            webView.PageLoadFinished += onLoadFinished;

            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.HighlightText("web", BaseComponents.WebView.FindOption.AtWordStart, 3);

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebViewHighlightText END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView AddDynamicCertificatePath.")]
        [Property("SPEC", "Tizen.NUI.WebView.AddDynamicCertificatePath M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewAddDynamicCertificatePath()
        {
            tlog.Debug(tag, $"WebViewAddDynamicCertificatePath START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tlog.Info(tag, "onLoadFinished is called!");
                tcs.TrySetResult(true);
            };
            webView.PageLoadFinished += onLoadFinished;

            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.AddDynamicCertificatePath("127.0.0.0", "/");

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebViewAddDynamicCertificatePath END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView CheckVideoPlayingAsynchronously.")]
        [Property("SPEC", "Tizen.NUI.WebView.CheckVideoPlayingAsynchronously M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewCheckVideoPlayingAsynchronously()
        {
            tlog.Debug(tag, $"WebViewCheckVideoPlayingAsynchronously START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tlog.Info(tag, "onLoadFinished is called!");
                tcs.TrySetResult(true);
            };
            webView.PageLoadFinished += onLoadFinished;

            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.CheckVideoPlayingAsynchronously(VideoCallback);

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebViewCheckVideoPlayingAsynchronously END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView RegisterGeolocationPermissionCallback.")]
        [Property("SPEC", "Tizen.NUI.WebView.RegisterGeolocationPermissionCallback M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewRegisterGeolocationPermissionCallback()
        {
            tlog.Debug(tag, $"WebViewRegisterGeolocationPermissionCallback START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tlog.Info(tag, "onLoadFinished is called!");
                tcs.TrySetResult(true);
            };
            webView.PageLoadFinished += onLoadFinished;

            webView.RegisterGeolocationPermissionCallback(GeolocationCallback);

            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebViewRegisterGeolocationPermissionCallback END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView GetPlainTextAsynchronously.")]
        [Property("SPEC", "Tizen.NUI.WebView.GetPlainTextAsynchronously M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewGetPlainTextAsynchronously()
        {
            tlog.Debug(tag, $"WebViewGetPlainTextAsynchronously START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tlog.Info(tag, "onLoadFinished is called!");
                tcs.TrySetResult(true);
            };
            webView.PageLoadFinished += onLoadFinished;

            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.GetPlainTextAsynchronously(PlainReceivedCallback);

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebViewGetPlainTextAsynchronously END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView SetTtsFocus.")]
        [Property("SPEC", "Tizen.NUI.WebView.SetTtsFocus M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewSetTtsFocus()
        {
            tlog.Debug(tag, $"WebViewSetTtsFocus START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tlog.Info(tag, "onLoadFinished is called!");
                tcs.TrySetResult(true);
            };
            webView.PageLoadFinished += onLoadFinished;

            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.SetTtsFocus(true);

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebViewSetTtsFocus END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView GetScreenshot.")]
        [Property("SPEC", "Tizen.NUI.WebView.GetScreenshot M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewGetScreenshot()
        {
            tlog.Debug(tag, $"WebViewGetScreenshot START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tlog.Info(tag, "onLoadFinished is called!");
                tcs.TrySetResult(true);
            };
            webView.PageLoadFinished += onLoadFinished;

            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            var factor = webView.GetScaleFactor();
            webView.GetScreenshot(new Rectangle(5, 6, 100, 200), factor);

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebViewGetScreenshot END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView GetScreenshotAsynchronously.")]
        [Property("SPEC", "Tizen.NUI.WebView.GetScreenshotAsynchronously M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewGetScreenshotAsynchronously()
        {
            tlog.Debug(tag, $"WebViewGetScreenshotAsynchronously START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tlog.Info(tag, "onLoadFinished is called!");
                tcs.TrySetResult(true);
            };
            webView.PageLoadFinished += onLoadFinished;

            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            var factor = webView.GetScaleFactor();
            webView.GetScreenshotAsynchronously(new Rectangle(5, 6, 50, 50), factor, ScreenshotAcquiredCallbackCase);

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebViewGetScreenshotAsynchronously END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView EvaluateJavaScript.")]
        [Property("SPEC", "Tizen.NUI.WebView.EvaluateJavaScript M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewEvaluateJavaScriptWithCallback()
        {
            tlog.Debug(tag, $"WebViewEvaluateJavaScriptWithCallback START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tlog.Info(tag, "onLoadFinished is called!");
                tcs.TrySetResult(true);
            };
            webView.PageLoadFinished += onLoadFinished;

            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.EvaluateJavaScript("<script type=\"text / javascript\">document.write(\"page\");</script>", JsCallback);

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebViewEvaluateJavaScriptWithCallback END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView ClearCache.")]
        [Property("SPEC", "Tizen.NUI.WebView.ClearCache M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewClearCache()
        {
            tlog.Debug(tag, $"WebViewClearCache START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tlog.Info(tag, "onLoadFinished is called!");
                tcs.TrySetResult(true);
            };
            webView.PageLoadFinished += onLoadFinished;

            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.ClearCache();

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebViewClearCache END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView ClearCookies.")]
        [Property("SPEC", "Tizen.NUI.WebView.ClearCookies M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewClearCookies()
        {
            tlog.Debug(tag, $"WebViewClearCookies START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tlog.Info(tag, "onLoadFinished is called!");
                tcs.TrySetResult(true);
            };
            webView.PageLoadFinished += onLoadFinished;

            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.ClearCookies();

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebViewClearCookies END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView DownCast.")]
        [Property("SPEC", "Tizen.NUI.WebView.DownCast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewDownCast()
        {
            tlog.Debug(tag, $"WebViewDownCast START");

            BaseComponents.WebView.DownCast(webView);

            await Task.Delay(1);

            tlog.Debug(tag, $"WebViewDownCast END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView Dispose.")]
        [Property("SPEC", "Tizen.NUI.WebView.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewDispose()
        {
            tlog.Debug(tag, $"WebViewDispose START");

            var testingTarget = new MyWebView();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            testingTarget.OnDispose(DisposeTypes.Explicit);
            //disposed
            testingTarget.OnDispose(DisposeTypes.Explicit);

            tlog.Debug(tag, $"WebViewDispose END (OK)");
        }
    }
}