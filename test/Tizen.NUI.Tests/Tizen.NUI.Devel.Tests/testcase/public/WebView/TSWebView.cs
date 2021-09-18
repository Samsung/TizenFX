using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/WebView/WebView")]
    public class PublicWebViewTest
    {
        private const string tag = "NUITEST";
        private string url = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

        private void JsCallback(string arg) { }
        private void VideoCallback (bool arg) { }
        private void GeolocationCallback (string arg1, string arg2) { }
        private void PromptCallback (string arg1, string arg2) { }

        internal class MyWebView : Tizen.NUI.BaseComponents.WebView
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
            tlog.Info(tag, "Init() is called!");
        }

        [TearDown]
        public void Destroy()
        {
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

            var testingTarget = new Tizen.NUI.BaseComponents.WebView();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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

            Tizen.NUI.BaseComponents.WebView view = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView(view);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            view.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"WebViewConstructorWithWebView END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView constructor.")]
        [Property("SPEC", "Tizen.NUI.WebView.WebView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewConstructorWithArray()
        {
            tlog.Debug(tag, $"WebViewConstructorWithArray START");

            string[] arr = new string[1] { "Tizen.NUI.Devel.Tests" };

            var testingTarget = new Tizen.NUI.BaseComponents.WebView(arr);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
            tlog.Debug(tag, $"WebViewConstructorWithArray END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView PageLoadStarted.")]
        [Property("SPEC", "Tizen.NUI.WebView.PageLoadStarted A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewPageLoadStarted()
        {
            tlog.Debug(tag, $"WebViewPageLoadStarted START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            testingTarget.PageLoadStarted += OnLoadStarted;
            testingTarget.PageLoadStarted -= OnLoadStarted;

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
            tlog.Debug(tag, $"WebViewPageLoadStarted END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView PageLoading.")]
        [Property("SPEC", "Tizen.NUI.WebView.PageLoading A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewPageLoading()
        {
            tlog.Debug(tag, $"WebViewPageLoading START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            testingTarget.PageLoading += OnLoading;
            testingTarget.PageLoading -= OnLoading;

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
            tlog.Debug(tag, $"WebViewPageLoading END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView PageLoadFinished.")]
        [Property("SPEC", "Tizen.NUI.WebView.PageLoadFinished A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewPageLoadFinished()
        {
            tlog.Debug(tag, $"WebViewPageLoadFinished START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            testingTarget.PageLoadFinished += OnLoadFinished;
            testingTarget.PageLoadFinished -= OnLoadFinished;

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
            tlog.Debug(tag, $"WebViewPageLoadFinished END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView PageLoadError.")]
        [Property("SPEC", "Tizen.NUI.WebView.PageLoadError A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewPageLoadError()
        {
            tlog.Debug(tag, $"WebViewPageLoadError START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            testingTarget.PageLoadError += OnLoadError;
            testingTarget.PageLoadError -= OnLoadError;

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
            tlog.Debug(tag, $"WebViewPageLoadError END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView ScrollEdgeReached.")]
        [Property("SPEC", "Tizen.NUI.WebView.ScrollEdgeReached A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewScrollEdgeReached()
        {
            tlog.Debug(tag, $"WebViewScrollEdgeReached START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            testingTarget.ScrollEdgeReached += OnEdgeReached;
            testingTarget.ScrollEdgeReached -= OnEdgeReached;

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
            tlog.Debug(tag, $"WebViewPageLoadError END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView UrlChanged.")]
        [Property("SPEC", "Tizen.NUI.WebView.UrlChanged A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewUrlChanged()
        {
            tlog.Debug(tag, $"WebViewUrlChanged START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            testingTarget.UrlChanged += OnUrlChange;
            testingTarget.UrlChanged -= OnUrlChange;

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
            tlog.Debug(tag, $"WebViewUrlChanged END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView FormRepostPolicyDecided.")]
        [Property("SPEC", "Tizen.NUI.WebView.FormRepostPolicyDecided A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewFormRepostPolicyDecided()
        {
            tlog.Debug(tag, $"WebViewFormRepostPolicyDecided START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            testingTarget.FormRepostPolicyDecided += OnFormRepostPolicyDecide;
            testingTarget.FormRepostPolicyDecided -= OnFormRepostPolicyDecide;

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
            tlog.Debug(tag, $"WebViewFormRepostPolicyDecided END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView FrameRendered.")]
        [Property("SPEC", "Tizen.NUI.WebView.FrameRendered A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewFrameRendered()
        {
            tlog.Debug(tag, $"WebViewFrameRendered START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            testingTarget.FrameRendered += OnFrameRender;
            testingTarget.FrameRendered -= OnFrameRender;

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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
        public void WebViewResponsePolicyDecided()
        {
            tlog.Debug(tag, $"WebViewResponsePolicyDecided START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            testingTarget.ResponsePolicyDecided += OnResponsePolicyDecide;
            testingTarget.ResponsePolicyDecided -= OnResponsePolicyDecide;

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
            tlog.Debug(tag, $"WebViewResponsePolicyDecided END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView CertificateConfirmed.")]
        [Property("SPEC", "Tizen.NUI.WebView.CertificateConfirmed A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewCertificateConfirmed()
        {
            tlog.Debug(tag, $"WebViewCertificateConfirmed START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            testingTarget.CertificateConfirmed += OnCertificateConfirme;
            testingTarget.CertificateConfirmed -= OnCertificateConfirme;

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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
        public void WebViewSslCertificateChanged()
        {
            tlog.Debug(tag, $"WebViewSslCertificateChanged START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            testingTarget.SslCertificateChanged += OnSslCertificateChange;
            testingTarget.SslCertificateChanged -= OnSslCertificateChange;

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
            tlog.Debug(tag, $"WebViewSslCertificateChanged END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView HttpAuthRequested.")]
        [Property("SPEC", "Tizen.NUI.WebView.HttpAuthRequested A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewHttpAuthRequested()
        {
            tlog.Debug(tag, $"WebViewHttpAuthRequested START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            testingTarget.HttpAuthRequested += OnHttpAuthRequeste;
            testingTarget.HttpAuthRequested -= OnHttpAuthRequeste;

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
            tlog.Debug(tag, $"WebViewHttpAuthRequested END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView ConsoleMessageReceived.")]
        [Property("SPEC", "Tizen.NUI.WebView.ConsoleMessageReceived A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewConsoleMessageReceived()
        {
            tlog.Debug(tag, $"WebViewHttpAuthRequested START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            testingTarget.ConsoleMessageReceived += OnConsoleMessageReceive;
            testingTarget.ConsoleMessageReceived -= OnConsoleMessageReceive;

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            var result = testingTarget.BackForwardList;
            tlog.Debug(tag, "ForwardList : " + result);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            var result = testingTarget.Context;
            tlog.Debug(tag, "Context : " + result);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            var result = testingTarget.CookieManager;
            tlog.Debug(tag, "CookieManager : " + result);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            var result = testingTarget.Settings;
            tlog.Debug(tag, "Settings : " + result);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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
        public void WebViewUrl()
        {
            tlog.Debug(tag, $"WebViewUrl START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            testingTarget.Url = url;
            tlog.Debug(tag, "Url : " + testingTarget.Url);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            testingTarget.CacheModel = Tizen.NUI.CacheModel.DocumentViewer;
            tlog.Debug(tag, "CacheModel : " + testingTarget.CacheModel);

            testingTarget.CacheModel = Tizen.NUI.CacheModel.DocumentBrowser;
            tlog.Debug(tag, "CacheModel : " + testingTarget.CacheModel);

            testingTarget.CacheModel = Tizen.NUI.CacheModel.PrimaryWebBrowser;
            tlog.Debug(tag, "CacheModel : " + testingTarget.CacheModel);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            testingTarget.CookieAcceptPolicy = (CookieAcceptPolicy)Tizen.NUI.WebCookieManager.CookieAcceptPolicyType.NoThirdParty;
            tlog.Debug(tag, "CookieAcceptPolicy : " + testingTarget.CookieAcceptPolicy);

            testingTarget.CookieAcceptPolicy = (CookieAcceptPolicy)Tizen.NUI.WebCookieManager.CookieAcceptPolicyType.Always;
            tlog.Debug(tag, "CookieAcceptPolicy : " + testingTarget.CookieAcceptPolicy);

            testingTarget.CookieAcceptPolicy = (CookieAcceptPolicy)Tizen.NUI.WebCookieManager.CookieAcceptPolicyType.Never;
            tlog.Debug(tag, "CookieAcceptPolicy : " + testingTarget.CookieAcceptPolicy);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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
        public void WebViewUserAgent()
        {
            tlog.Debug(tag, $"WebViewUserAgent START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            testingTarget.UserAgent = "Mozilla/5.0 (Linux; Android 4.2.1; M040 Build/JOP40D) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/31.0.1650.59 Mobile Safari/537.36";
            tlog.Debug(tag, "UserAgent : " + testingTarget.UserAgent);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            testingTarget.EnableJavaScript = true;
            tlog.Debug(tag, "EnableJavaScript : " + testingTarget.EnableJavaScript);

            testingTarget.EnableJavaScript = false;
            tlog.Debug(tag, "EnableJavaScript : " + testingTarget.EnableJavaScript);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            testingTarget.LoadImagesAutomatically = true;
            tlog.Debug(tag, "LoadImagesAutomatically : " + testingTarget.LoadImagesAutomatically);

            testingTarget.LoadImagesAutomatically = false;
            tlog.Debug(tag, "LoadImagesAutomatically : " + testingTarget.LoadImagesAutomatically);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            var result = testingTarget.DefaultTextEncodingName;
            tlog.Debug(tag, "DefaultTextEncodingName : " + result);

            testingTarget.DefaultTextEncodingName = "gbk";
            tlog.Debug(tag, "DefaultTextEncodingName : " + result);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            var result = testingTarget.DefaultFontSize;
            tlog.Debug(tag, "DefaultFontSize : " + result);

            testingTarget.DefaultFontSize = 32;
            tlog.Debug(tag, "DefaultFontSize : " + result);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
            tlog.Debug(tag, $"WebViewDefaultFontSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView ScrollPosition.")]
        [Property("SPEC", "Tizen.NUI.WebView.ScrollPosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewScrollPosition()
        {
            tlog.Debug(tag, $"WebViewScrollPosition START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            testingTarget.ScrollPosition = new Position(0.2f, 0.1f);
            tlog.Debug(tag, "ScrollPositionX : " + testingTarget.ScrollPosition.X);
            tlog.Debug(tag, "ScrollPositionY : " + testingTarget.ScrollPosition.Y);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
            tlog.Debug(tag, $"WebViewScrollPosition END (OK)");
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

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            tlog.Debug(tag, "Width : " + testingTarget.ScrollSize.Width);
            tlog.Debug(tag, "Height : " + testingTarget.ScrollSize.Height);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            tlog.Debug(tag, "Width : " + testingTarget.ContentSize.Width);
            tlog.Debug(tag, "Height : " + testingTarget.ContentSize.Height);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            testingTarget.VideoHoleEnabled = true;
            tlog.Debug(tag, "VideoHoleEnabled : " + testingTarget.VideoHoleEnabled);

            testingTarget.VideoHoleEnabled = false;
            tlog.Debug(tag, "VideoHoleEnabled : " + testingTarget.VideoHoleEnabled);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            testingTarget.MouseEventsEnabled = true;
            tlog.Debug(tag, "MouseEventsEnabled : " + testingTarget.MouseEventsEnabled);

            testingTarget.MouseEventsEnabled = false;
            tlog.Debug(tag, "MouseEventsEnabled : " + testingTarget.MouseEventsEnabled);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            testingTarget.KeyEventsEnabled = true;
            tlog.Debug(tag, "KeyEventsEnabled : " + testingTarget.KeyEventsEnabled);

            testingTarget.KeyEventsEnabled = false;
            tlog.Debug(tag, "KeyEventsEnabled : " + testingTarget.KeyEventsEnabled);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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
        public void WebViewContentBackgroundColor()
        {
            tlog.Debug(tag, $"WebViewContentBackgroundColor START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            testingTarget.ContentBackgroundColor = Color.Cyan;
            tlog.Debug(tag, "ContentBackgroundColor : " + testingTarget.ContentBackgroundColor);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            testingTarget.TilesClearedWhenHidden = true;
            tlog.Debug(tag, "TilesClearedWhenHidden : " + testingTarget.TilesClearedWhenHidden);

            testingTarget.TilesClearedWhenHidden = false;
            tlog.Debug(tag, "TilesClearedWhenHidden : " + testingTarget.TilesClearedWhenHidden);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            testingTarget.TileCoverAreaMultiplier = 0.3f;
            tlog.Debug(tag, "TileCoverAreaMultiplier : " + testingTarget.TileCoverAreaMultiplier);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            testingTarget.CursorEnabledByClient = true;
            tlog.Debug(tag, "CursorEnabledByClient : " + testingTarget.CursorEnabledByClient);

            testingTarget.CursorEnabledByClient = false;
            tlog.Debug(tag, "CursorEnabledByClient : " + testingTarget.CursorEnabledByClient);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            tlog.Debug(tag, "SelectedText : " + testingTarget.SelectedText);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            tlog.Debug(tag, "Title : " + testingTarget.Title);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            tlog.Debug(tag, "Favicon : " + testingTarget.Favicon);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            testingTarget.PageZoomFactor = 0.3f;
            tlog.Debug(tag, "PageZoomFactor : " + testingTarget.PageZoomFactor);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            testingTarget.TextZoomFactor = 0.2f;
            tlog.Debug(tag, "TextZoomFactor : " + testingTarget.TextZoomFactor);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            tlog.Debug(tag, "LoadProgressPercentage : " + testingTarget.LoadProgressPercentage);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
            tlog.Debug(tag, $"WebViewLoadProgressPercentage END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView LoadUrl.")]
        [Property("SPEC", "Tizen.NUI.WebView.LoadUrl M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewLoadUrl()
        {
            tlog.Debug(tag, $"WebViewLoadUrl START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            try
            {
                testingTarget.LoadUrl(url);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();
            testingTarget.Dispose();
            tlog.Debug(tag, $"WebViewLoadUrl END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView LoadHtmlString.")]
        [Property("SPEC", "Tizen.NUI.WebView.LoadHtmlString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewLoadHtmlString()
        {
            tlog.Debug(tag, $"WebViewLoadHtmlString START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            try
            {
                testingTarget.LoadHtmlString("<html><head lang=\"en\"></head></html>");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();
            testingTarget.Dispose();
            tlog.Debug(tag, $"WebViewLoadHtmlString END (OK)");
        }

        //[Test]
        //[Category("P1")]
        //[Description("WebView LoadHtmlStringOverrideCurrentEntry.")]
        //[Property("SPEC", "Tizen.NUI.WebView.LoadHtmlStringOverrideCurrentEntry M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("COVPARAM", "")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WebViewLoadHtmlStringOverrideCurrentEntry()
        //{
        //    tlog.Debug(tag, $"WebViewLoadHtmlStringOverrideCurrentEntry START");

        //    var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
        //    Assert.IsNotNull(testingTarget, "null handle");
        //    Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

        //    try
        //    {
        //        testingTarget.LoadHtmlStringOverrideCurrentEntry("<html><head lang=\"en\"></head></html>", "http://www.runoob.com/jsref/prop-doc-baseuri.html", "");
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception : Failed!");
        //    }

        //    testingTarget.ClearCache();
        //    testingTarget.ClearCookies();
        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"WebViewLoadHtmlStringOverrideCurrentEntry END (OK)");
        //}

        [Test]
        [Category("P1")]
        [Description("WebView LoadContents.")]
        [Property("SPEC", "Tizen.NUI.WebView.LoadContents M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewLoadContents()
        {
            tlog.Debug(tag, $"WebViewLoadContents START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            try
            {
                testingTarget.LoadContents("body", 18, " ", "gbk", "http://www.runoob.com/jsref/prop-doc-baseuri.html");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();
            testingTarget.Dispose();
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
        public void WebViewReload()
        {
            tlog.Debug(tag, $"WebViewReload START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            try
            {
                testingTarget.Reload();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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
        public void WebViewReloadWithoutCache()
        {
            tlog.Debug(tag, $"WebViewReloadWithoutCache START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            try
            {
                testingTarget.ReloadWithoutCache();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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
        public void WebViewStopLoading()
        {
            tlog.Debug(tag, $"WebViewStopLoading START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            try
            {
                testingTarget.StopLoading();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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
        public void WebViewSuspend()
        {
            tlog.Debug(tag, $"WebViewSuspend START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            try
            {
                testingTarget.Suspend();
                testingTarget.Resume();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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
        public void WebViewSuspendNetworkLoading()
        {
            tlog.Debug(tag, $"WebViewSuspendNetworkLoading START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            try
            {
                testingTarget.SuspendNetworkLoading();
                testingTarget.ResumeNetworkLoading();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            var result = testingTarget.AddCustomHeader("customHeader_title", "font-size: 32rpx");
            tlog.Debug(tag, "AddCustomHeader : " + result);

            result = testingTarget.RemoveCustomHeader("customHeader_title");
            tlog.Debug(tag, "RemoveCustomHeader : " + result);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
            tlog.Debug(tag, $"WebViewAddCustomHeader END (OK)");
        }

        //[Test]
        //[Category("P1")]
        //[Description("WebView StartInspectorServer.")]
        //[Property("SPEC", "Tizen.NUI.WebView.StartInspectorServer M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("COVPARAM", "")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WebViewStartInspectorServer()
        //{
        //    tlog.Debug(tag, $"WebViewStartInspectorServer START");

        //    var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
        //    Assert.IsNotNull(testingTarget, "null handle");
        //    Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

        //    testingTarget.LoadUrl("https://www.cnblogs.com/softidea/p/5745369.html");

        //    var startValue = testingTarget.StartInspectorServer(5678);
        //    tlog.Debug(tag, "StartInspectorServer : " + startValue);

        //    var stopValue = testingTarget.StopInspectorServer();
        //    tlog.Debug(tag, "StopInspectorServer : " + stopValue);

        //    testingTarget.ClearCache();
        //    testingTarget.ClearCookies();

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"WebViewStartInspectorServer END (OK)");
        //}

        [Test]
        [Category("P1")]
        [Description("WebView ScrollBy.")]
        [Property("SPEC", "Tizen.NUI.WebView.ScrollBy M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewScrollBy()
        {
            tlog.Debug(tag, $"WebViewScrollBy START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            try
            {
                testingTarget.ScrollBy(1, 1);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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
        public void WebViewScrollEdgeBy()
        {
            tlog.Debug(tag, $"WebViewScrollEdgeBy START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            var result = testingTarget.ScrollEdgeBy(1, 1);
            tlog.Debug(tag, "ScrollEdgeBy : " + result);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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
        public void WebViewGoBack()
        {
            tlog.Debug(tag, $"WebViewGoBack START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            try
            {
                testingTarget.GoBack();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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
        public void WebViewGoForward()
        {
            tlog.Debug(tag, $"WebViewGoForward START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            try
            {
                testingTarget.GoForward();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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
        public void WebViewCanGoBack()
        {
            tlog.Debug(tag, $"WebViewCanGoBack START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            var result = testingTarget.CanGoBack();
            tlog.Debug(tag, "CanGoBack : " + result);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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
        public void WebViewCanGoForward()
        {
            tlog.Debug(tag, $"WebViewCanGoForward START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            var result = testingTarget.CanGoForward();
            tlog.Debug(tag, "CanGoForward : " + result);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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
        public void WebViewEvaluateJavaScript()
        {
            tlog.Debug(tag, $"WebViewEvaluateJavaScript START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            try
            {
                testingTarget.EvaluateJavaScript("<script type=\"text / javascript\">document.write(\"page\");</script>");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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
        public void WebViewAddJavaScriptMessageHandler()
        {
            tlog.Debug(tag, $"WebViewAddJavaScriptMessageHandler START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            try
            {
                testingTarget.AddJavaScriptMessageHandler("AllowOrigin", JsCallback);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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
        public void WebViewRegisterJavaScriptAlertCallback()
        {
            tlog.Debug(tag, $"WebViewRegisterJavaScriptAlertCallback START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            try
            {
                testingTarget.RegisterJavaScriptAlertCallback(JsCallback);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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
        public void WebViewRegisterJavaScriptConfirmCallback()
        {
            tlog.Debug(tag, $"WebViewRegisterJavaScriptConfirmCallback START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            try
            {
                testingTarget.RegisterJavaScriptConfirmCallback(JsCallback);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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
        public void WebViewRegisterJavaScriptPromptCallback()
        {
            tlog.Debug(tag, $"WebViewRegisterJavaScriptPromptCallback START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            try
            {
                testingTarget.RegisterJavaScriptPromptCallback(PromptCallback);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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
        public void WebViewClearAllTilesResources()
        {
            tlog.Debug(tag, $"WebViewClearAllTilesResources START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            try
            {
                testingTarget.ClearAllTilesResources();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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
        public void WebViewClearHistory()
        {
            tlog.Debug(tag, $"WebViewClearHistory START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            try
            {
                testingTarget.ClearHistory();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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
        public void WebViewSetScaleFactor()
        {
            tlog.Debug(tag, $"WebViewSetScaleFactor START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            try
            {
                using (Vector2 point = new Vector2(1.0f, 1.0f))
                {
                    testingTarget.SetScaleFactor(0.2f, point);

                    var result = testingTarget.GetScaleFactor();
                    tlog.Debug(tag, "ScaleFactor : " + result);
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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
        public void WebViewActivateAccessibility()
        {
            tlog.Debug(tag, $"WebViewActivateAccessibility START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            try
            {
                testingTarget.ActivateAccessibility(false);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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
        public void WebViewHighlightText()
        {
            tlog.Debug(tag, $"WebViewHighlightText START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            try
            {
                testingTarget.HighlightText("web", Tizen.NUI.BaseComponents.WebView.FindOption.AtWordStart, 3);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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
        public void WebViewAddDynamicCertificatePath()
        {
            tlog.Debug(tag, $"WebViewAddDynamicCertificatePath START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            try
            {
                testingTarget.AddDynamicCertificatePath("127.0.0.0", "/");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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
        public void WebViewCheckVideoPlayingAsynchronously()
        {
            tlog.Debug(tag, $"WebViewCheckVideoPlayingAsynchronously START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            try
            {
                testingTarget.CheckVideoPlayingAsynchronously(VideoCallback);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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
        public void WebViewRegisterGeolocationPermissionCallback()
        {
            tlog.Debug(tag, $"WebViewRegisterGeolocationPermissionCallback START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            try
            {
                testingTarget.RegisterGeolocationPermissionCallback(GeolocationCallback);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
            tlog.Debug(tag, $"WebViewRegisterGeolocationPermissionCallback END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView ClearCache.")]
        [Property("SPEC", "Tizen.NUI.WebView.ClearCache M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewClearCache()
        {
            tlog.Debug(tag, $"WebViewClearCache START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            try
            {
                testingTarget.ClearCache();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
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
        public void WebViewClearCookies()
        {
            tlog.Debug(tag, $"WebViewClearCookies START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            try
            {
                testingTarget.ClearCookies();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
            tlog.Debug(tag, $"WebViewClearCookies END (OK)");
        }

        //[Test]
        //[Category("P1")]
        //[Description("WebView SetTtsFocus.")]
        //[Property("SPEC", "Tizen.NUI.WebView.SetTtsFocus M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("COVPARAM", "")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WebViewSetTtsFocus()
        //{
        //    tlog.Debug(tag, $"WebViewSetTtsFocus START");

        //    var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
        //    Assert.IsNotNull(testingTarget, "null handle");
        //    Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

        //    try
        //    {
        //        testingTarget.SetTtsFocus(false);
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception : Failed!");
        //    }

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"WebViewSetTtsFocus END (OK)");
        //}

        [Test]
        [Category("P1")]
        [Description("WebView DownCast.")]
        [Property("SPEC", "Tizen.NUI.WebView.DownCast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewDownCast()
        {
            tlog.Debug(tag, $"WebViewDownCast START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            try
            {
                Tizen.NUI.BaseComponents.WebView.DownCast(testingTarget);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
            tlog.Debug(tag, $"WebViewDownCast END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebView Assign.")]
        [Property("SPEC", "Tizen.NUI.WebView.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewAssign()
        {
            tlog.Debug(tag, $"WebViewAssign START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            try
            {
                testingTarget.Assign(testingTarget);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.ClearCache();
            testingTarget.ClearCookies();

            testingTarget.Dispose();
            tlog.Debug(tag, $"WebViewAssign END (OK)");
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

        //[Test]
        //[Category("P1")]
        //[Description("WebView ContextMenuShown.")]
        //[Property("SPEC", "Tizen.NUI.WebView.ContextMenuShown A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("COVPARAM", "")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WebViewContextMenuShown()
        //{
        //    tlog.Debug(tag, $"WebViewContextMenuShown START");

        //    var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
        //    Assert.IsNotNull(testingTarget, "null handle");
        //    Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

        //    testingTarget.ContextMenuShown += OnContextMenuShow;
        //    testingTarget.ContextMenuShown -= OnContextMenuShow;

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"WebViewContextMenuShown END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("WebView ContextMenuHidden.")]
        //[Property("SPEC", "Tizen.NUI.WebView.ContextMenuHidden A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("COVPARAM", "")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WebViewContextMenuHidden()
        //{
        //    tlog.Debug(tag, $"WebViewContextMenuHidden START");

        //    var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
        //    Assert.IsNotNull(testingTarget, "null handle");
        //    Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

        //    testingTarget.ContextMenuHidden += OnContextMenuHide;
        //    testingTarget.ContextMenuHidden -= OnContextMenuHide;

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"WebViewContextMenuHidden END (OK)");
        //}

        private void OnLoadStarted(object sender, WebViewPageLoadEventArgs e) { }
        private void OnLoading(object sender, WebViewPageLoadEventArgs e) { }
        private void OnLoadFinished(object sender, WebViewPageLoadEventArgs e) { }
        private void OnLoadError(object sender, WebViewPageLoadErrorEventArgs e) { }
        private void OnEdgeReached(object sender, WebViewScrollEdgeReachedEventArgs e) { }
        private void OnUrlChange(object sender, WebViewUrlChangedEventArgs e) { }
        private void OnFormRepostPolicyDecide(object sender, WebViewFormRepostPolicyDecidedEventArgs e) { }
        private void OnFrameRender(object sender, EventArgs e) { }
        private void OnResponsePolicyDecide(object sender, WebViewResponsePolicyDecidedEventArgs e) { }
        private void OnCertificateConfirme(object sender, WebViewCertificateReceivedEventArgs e) { }
        private void OnSslCertificateChange(object sender, WebViewCertificateReceivedEventArgs e) {  }
        private void OnHttpAuthRequeste(object sender, WebViewHttpAuthRequestedEventArgs e) { }
        private void OnConsoleMessageReceive(object sender, WebViewConsoleMessageReceivedEventArgs e) { }
        //private void OnContextMenuShow(object sender, WebViewContextMenuShownEventArgs e) { }
        //private void OnContextMenuHide(object sender, WebViewContextMenuHiddenEventArgs e) { }
    }
}