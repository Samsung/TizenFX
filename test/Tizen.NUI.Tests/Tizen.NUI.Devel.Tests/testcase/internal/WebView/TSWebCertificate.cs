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
    [Description("internal/WebView/WebCertificate")]
    public class InternalWebCertificateTest
    {
        private const string tag = "NUITEST";
        private string url = $"file://{Applications.Application.Current.DirectoryInfo.Resource}webview/index.html";
        private BaseComponents.WebView webView = null;

        [SetUp]
        public void Init()
        {
            webView = new BaseComponents.WebView()
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
        [Description("WebCertificate constructor.")]
        [Property("SPEC", "Tizen.NUI.WebCertificate.WebCertificate C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebCertificateConstructor()
        {
            tlog.Debug(tag, $"WebCertificateConstructor START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewCertificateReceivedEventArgs> onSslCertificateChange = (s, e) =>
            {
                Assert.IsNotNull(e.Certificate, "null handle");
                Assert.IsInstanceOf<WebCertificate>(e.Certificate, "Should return WebCertificate instance.");
                tcs.TrySetResult(true);
            };
            webView.SslCertificateChanged += onSslCertificateChange;

            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "SslCertificateChanged event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.SslCertificateChanged -= onSslCertificateChange;

            tlog.Debug(tag, $"WebCertificateConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebCertificate Allow.")]
        [Property("SPEC", "Tizen.NUI.WebCertificate.Allow M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebCertificateAllow()
        {
            tlog.Debug(tag, $"WebCertificateIsFromMainFrame START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewCertificateReceivedEventArgs> onSslCertificateChange = (s, e) =>
            {
                Assert.IsTrue(e.Certificate.PemData == null || e.Certificate.PemData.Length == 0, "Certificate has no pem data.");
                Assert.IsFalse(e.Certificate.IsFromMainFrame, "Certificate is not from main frame.");
                Assert.IsFalse(e.Certificate.IsContextSecure, "Certificate is not context secure.");
                e.Certificate.Allow(false);
                tcs.TrySetResult(true);
            };
            webView.SslCertificateChanged += onSslCertificateChange;

            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "SslCertificateChanged event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.SslCertificateChanged -= onSslCertificateChange;

            tlog.Debug(tag, $"WebCertificateIsFromMainFrame END (OK)");
        }
    }
}
