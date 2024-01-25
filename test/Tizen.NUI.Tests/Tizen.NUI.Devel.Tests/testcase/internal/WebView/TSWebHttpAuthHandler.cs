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
    [Description("internal/WebView/WebHttpAuthHandler")]
    public class InternalWebHttpAuthHandlerTest
    {
        private const string tag = "NUITEST";
        private string urlForHttpAuth = "https://review.tizen.org/gerrit/#/";
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
        //[Description("WebHttpAuthHandler CancelCredential.")]
        //[Property("SPEC", "Tizen.NUI.WebHttpAuthHandler.CancelCredential M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRO")]
        //[Property("COVPARAM", "")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public async Task WebHttpAuthHandlerCancelCredential()
        //{
        //    tlog.Debug(tag, $"WebHttpAuthHandlerRealm START");

        //    TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
        //    EventHandler<WebViewHttpAuthRequestedEventArgs> onHttpAuthRequested = (s, e) =>
        //    {
        //        tlog.Info(tag, $"HttpAuthRequested, Url: {e.HttpAuthHandler.Realm}");
        //        e.HttpAuthHandler.CancelCredential();
        //        tcs.TrySetResult(true);
        //    };

        //    webview_.HttpAuthRequested += onHttpAuthRequested;

        //    webview_.LoadUrl(urlForHttpAuth);
        //    var result = await tcs.Task;
        //    Assert.IsTrue(result, "HttpAuthRequested event should be invoked.");

        //    // Make current thread (CPU) sleep...
        //    await Task.Delay(1);

        //    webview_.HttpAuthRequested -= onHttpAuthRequested;

        //    tlog.Debug(tag, $"WebHttpAuthHandlerRealm END (OK)");
        //}

        //TODO... This TC will be blocked because web engine does not support it any longer.
        //[Test]
        //[Category("P1")]
        //[Description("WebHttpAuthHandler UseCredential.")]
        //[Property("SPEC", "Tizen.NUI.WebHttpAuthHandler.UseCredential M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRO")]
        //[Property("COVPARAM", "")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public async Task WebHttpAuthHandlerUseCredential()
        //{
        //    tlog.Debug(tag, $"WebHttpAuthHandlerRealm START");

        //    TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
        //    EventHandler<WebViewHttpAuthRequestedEventArgs> onHttpAuthRequested = (s, e) =>
        //    {
        //        tlog.Info(tag, $"HttpAuthRequested, Url: {e.HttpAuthHandler.Realm}");
        //        e.HttpAuthHandler.UseCredential("tizen", "samsung");
        //        tcs.TrySetResult(true);
        //    };

        //    webview_.HttpAuthRequested += onHttpAuthRequested;

        //    webview_.LoadUrl(urlForHttpAuth);
        //    var result = await tcs.Task;
        //    Assert.IsTrue(result, "HttpAuthRequested event should be invoked.");

        //    // Make current thread (CPU) sleep...
        //    await Task.Delay(1);

        //    webview_.HttpAuthRequested -= onHttpAuthRequested;

        //    tlog.Debug(tag, $"WebHttpAuthHandlerRealm END (OK)");
        //}

        //TODO... This TC will be blocked because web engine does not support it any longer.
        //[Test]
        //[Category("P1")]
        //[Description("WebHttpAuthHandler Suspend.")]
        //[Property("SPEC", "Tizen.NUI.WebHttpAuthHandler.Suspend M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRO")]
        //[Property("COVPARAM", "")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public async Task WebHttpAuthHandlerSuspend()
        //{
        //    tlog.Debug(tag, $"WebHttpAuthHandlerRealm START");

        //    TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
        //    EventHandler<WebViewHttpAuthRequestedEventArgs> onHttpAuthRequested = (s, e) =>
        //    {
        //        tlog.Info(tag, $"HttpAuthRequested, Url: {e.HttpAuthHandler.Realm}");
        //        e.HttpAuthHandler.Suspend();
        //        tcs.TrySetResult(true);
        //    };

        //    webview_.HttpAuthRequested += onHttpAuthRequested;

        //    webview_.LoadUrl(urlForHttpAuth);
        //    var result = await tcs.Task;
        //    Assert.IsTrue(result, "HttpAuthRequested event should be invoked.");

        //    // Make current thread (CPU) sleep...
        //    await Task.Delay(1);

        //    webview_.HttpAuthRequested -= onHttpAuthRequested;

        //    tlog.Debug(tag, $"WebHttpAuthHandlerRealm END (OK)");
        //}
    }   
}
