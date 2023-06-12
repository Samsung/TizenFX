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
    [Description("internal/WebView/WebHitTestResult")]
    public class InternalWebHitTestResultTest
    {
        private const string tag = "NUITEST";
        private string url = $"file://{Tizen.Applications.Application.Current.DirectoryInfo.Resource}webview/index.html";
        private BaseComponents.WebView webview_;

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            webview_ = new BaseComponents.WebView()
            {
                Size = new Size(500, 200),
            };
        }

        [TearDown]
        public void Destroy()
        {
            tlog.Info(tag, "Destroy() is being called!");
            webview_.Dispose();
            tlog.Info(tag, "Destroy() is called!");
        }

        //TODO... This TC will be blocked because web engine does not support it any longer.
        //[Test]
        //[Category("P1")]
        //[Description("WebHitTestResult constructor.")]
        //[Property("SPEC", "Tizen.NUI.WebHitTestResult.WebHitTestResult C")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "CONSTR")]
        //[Property("COVPARAM", "")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public async Task WebHitTestResultConstructor()
        //{
        //    tlog.Debug(tag, $"WebHitTestResultConstructor START");

        //    TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);

        //    BaseComponents.WebView.HitTestFinishedCallback onHitTestFinished = (test) =>
        //    {
        //        tlog.Info("WebView", $"------------hit test finished-------");
        //        tlog.Info("WebView", $"WebHitTestResult, TestResultContext: {test.TestResultContext}");
        //        tlog.Info("WebView", $"WebHitTestResult, LinkUrl: {test.LinkUrl}");
        //        tlog.Info("WebView", $"WebHitTestResult, LinkTitle: {test.LinkTitle}");
        //        tlog.Info("WebView", $"WebHitTestResult, LinkLabel: {test.LinkLabel}");
        //        tlog.Info("WebView", $"WebHitTestResult, ImageUrl: {test.ImageUrl}");
        //        tlog.Info("WebView", $"WebHitTestResult, MediaUrl: {test.MediaUrl}");
        //        tlog.Info("WebView", $"WebHitTestResult, TagName: {test.TagName}");
        //        tlog.Info("WebView", $"WebHitTestResult, NodeValue: {test.NodeValue}");
        //        if (test.Attributes != null)
        //        {
        //            tlog.Info("WebView", $"WebHitTestResult, Attributes: {test.Attributes}");
        //        }
        //        tlog.Info("WebView", $"WebHitTestResult, ImageFileNameExtension: {test.ImageFileNameExtension}");
        //        ImageView imageView = test.Image;
        //        if (imageView != null)
        //        {
        //            tlog.Info("WebView", $"WebHitTestResult, Got image view");
        //        }
        //        tcs.TrySetResult(true);
        //    };

        //    EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
        //    {
        //        tlog.Info(tag, "onLoadFinished is called!");
                
        //        bool succeeded = webview_.HitTestAsynchronously(50, 50, BaseComponents.WebView.HitTestMode.Default, onHitTestFinished);
        //        Assert.IsTrue(succeeded, "HitTestAsynchronously should be invoked");
        //    };
        //    webview_.PageLoadFinished += onLoadFinished;

        //    webview_.LoadUrl(url);
        //    var result = await tcs.Task;
        //    Assert.IsTrue(result, "PageLoadFinished event & HitTestAsynchronously should be invoked");

        //    // Make current thread (CPU) sleep...
        //    await Task.Delay(1);

        //    webview_.PageLoadFinished -= onLoadFinished;

        //    tlog.Debug(tag, $"WebHitTestResultConstructor END (OK)");
        //}
    }
}
