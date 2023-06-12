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
    [Description("internal/WebView/WebBackForwardList")]
    public class InternalWebBackForwardListTest
    {
        private const string tag = "NUITEST";
        private string url = $"file://{Applications.Application.Current.DirectoryInfo.Resource}webview/index.html";
        private string secondUrl = $"file://{Applications.Application.Current.DirectoryInfo.Resource}webview/second.html";
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
        [Description("WebBackForwardList ItemCount.")]
        [Property("SPEC", "Tizen.NUI.WebBackForwardList.ItemCount A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebBackForwardListConstructor()
        {
            tlog.Debug(tag, $"WebBackForwardListConstructor START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tlog.Info(tag, "onLoadFinished is called!");
                tcs.TrySetResult(true);
            };
            webView.PageLoadFinished += onLoadFinished;

            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked.");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            Assert.IsNotNull(webView.BackForwardList, "null handle");
            Assert.IsInstanceOf<WebBackForwardList>(webView.BackForwardList, "Should return WebBackForwardList instance.");
            Assert.Greater(webView.BackForwardList.ItemCount, 0, "ItemCount should be greater than 0.");

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebBackForwardListConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebBackForwardList GetCurrentItem.")]
        [Property("SPEC", "Tizen.NUI.WebBackForwardList.GetCurrentItem M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebBackForwardListGetCurrentItem()
        {
            tlog.Debug(tag, $"WebBackForwardListGetCurrentItem START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tlog.Info(tag, "onLoadFinished is called!");
                tcs.TrySetResult(true);
            };
            webView.PageLoadFinished += onLoadFinished;

            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked.");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            Assert.IsNotNull(webView.BackForwardList.GetCurrentItem(), "handle should not be null.");

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebBackForwardListGetCurrentItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebBackForwardList GetPreviousItem.")]
        [Property("SPEC", "Tizen.NUI.WebBackForwardList.GetPreviousItem M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebBackForwardListGetPreviousItem()
        {
            tlog.Debug(tag, $"WebBackForwardListGetPreviousItem START");

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

            webView.PageLoadFinished -= onLoadFinished;

            // Load second url.
            TaskCompletionSource<bool> tcs2 = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished2 = (s, e) =>
            {
                tlog.Info(tag, "onLoadFinished is called!");
                tcs2.TrySetResult(true);
            };
            webView.PageLoadFinished += onLoadFinished2;

            webView.LoadUrl(secondUrl);
            var result2 = await tcs2.Task;
            Assert.IsTrue(result2, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            Assert.IsNotNull(webView.BackForwardList.GetPreviousItem(), "handle should not be null.");

            webView.PageLoadFinished -= onLoadFinished2;

            tlog.Debug(tag, $"WebBackForwardListGetPreviousItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebBackForwardList GetNextItem.")]
        [Property("SPEC", "Tizen.NUI.WebBackForwardList.GetNextItem M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebBackForwardListGetNextItem()
        {
            tlog.Debug(tag, $"WebBackForwardListGetNextItem START");

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

            webView.PageLoadFinished -= onLoadFinished;

            // Load second url.
            TaskCompletionSource<bool> tcs2 = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished2 = (s, e) =>
            {
                tlog.Info(tag, "onLoadFinished is called!");
                tcs2.TrySetResult(true);
            };
            webView.PageLoadFinished += onLoadFinished2;

            webView.LoadUrl(secondUrl);
            var result2 = await tcs2.Task;
            Assert.IsTrue(result2, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.GoBack();
            Assert.IsNotNull(webView.BackForwardList.GetNextItem(), "handle should not be null.");

            webView.PageLoadFinished -= onLoadFinished2;

            tlog.Debug(tag, $"WebBackForwardListGetNextItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebBackForwardList GetItemAtIndex.")]
        [Property("SPEC", "Tizen.NUI.WebBackForwardList.GetItemAtIndex M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebBackForwardListGetItemAtIndex()
        {
            tlog.Debug(tag, $"WebBackForwardListGetItemAtIndex START");

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

            webView.PageLoadFinished -= onLoadFinished;

            // Load second url.
            TaskCompletionSource<bool> tcs2 = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished2 = (s, e) =>
            {
                tlog.Info(tag, "onLoadFinished is called!");
                tcs2.TrySetResult(true);
            };
            webView.PageLoadFinished += onLoadFinished2;

            webView.LoadUrl(secondUrl);
            var result2 = await tcs2.Task;
            Assert.IsTrue(result2, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            Assert.IsNotNull(webView.BackForwardList.GetItemAtIndex(0), "handle should not be null.");

            webView.PageLoadFinished -= onLoadFinished2;

            tlog.Debug(tag, $"WebBackForwardListGetItemAtIndex END (OK)");
        }

        //[Test]
        //[Category("P1")]
        //[Description("WebBackForwardList GetBackwardItems.")]
        //[Property("SPEC", "Tizen.NUI.WebBackForwardList.GetBackwardItems M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("COVPARAM", "")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public async Task WebBackForwardListGetBackwardItems()
        //{
        //    tlog.Debug(tag, $"WebBackForwardListGetBackwardItems START");

        //    TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
        //    EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
        //    {
        //        tlog.Info(tag, "onLoadFinished is called!");
        //        tcs.TrySetResult(true);
        //    };
        //    webView.PageLoadFinished += onLoadFinished;

        //    webView.LoadUrl(url);
        //    var result = await tcs.Task;
        //    Assert.IsTrue(result, "PageLoadFinished event should be invoked");

        //    // Make current thread (CPU) sleep...
        //    await Task.Delay(1);

        //    webView.PageLoadFinished -= onLoadFinished;

        //    // Load second url.
        //    TaskCompletionSource<bool> tcs2 = new TaskCompletionSource<bool>(false);
        //    EventHandler<WebViewPageLoadEventArgs> onLoadFinished2 = (s, e) =>
        //    {
        //        tlog.Info(tag, "onLoadFinished is called!");
        //        tcs2.TrySetResult(true);
        //    };
        //    webView.PageLoadFinished += onLoadFinished2;

        //    webView.LoadUrl(secondUrl);
        //    var result2 = await tcs2.Task;
        //    Assert.IsTrue(result2, "PageLoadFinished event should be invoked");

        //    // Make current thread (CPU) sleep...
        //    await Task.Delay(1);

        //    Assert.IsNotNull(webView.BackForwardList.GetBackwardItems(1), "handle should not be null.");

        //    webView.PageLoadFinished -= onLoadFinished2;

        //    tlog.Debug(tag, $"WebBackForwardListGetBackwardItems END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("WebBackForwardList GetForwardItems.")]
        //[Property("SPEC", "Tizen.NUI.WebBackForwardList.GetForwardItems M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("COVPARAM", "")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public async Task WebBackForwardListGetForwardItems()
        //{
        //    tlog.Debug(tag, $"WebBackForwardListGetForwardItems START");

        //    TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
        //    EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
        //    {
        //        tlog.Info(tag, "onLoadFinished is called!");
        //        tcs.TrySetResult(true);
        //    };
        //    webView.PageLoadFinished += onLoadFinished;

        //    webView.LoadUrl(url);
        //    var result = await tcs.Task;
        //    Assert.IsTrue(result, "PageLoadFinished event should be invoked");

        //    // Make current thread (CPU) sleep...
        //    await Task.Delay(1);

        //    webView.PageLoadFinished -= onLoadFinished;

        //    // Load second url.
        //    TaskCompletionSource<bool> tcs2 = new TaskCompletionSource<bool>(false);
        //    EventHandler<WebViewPageLoadEventArgs> onLoadFinished2 = (s, e) =>
        //    {
        //        tlog.Info(tag, "onLoadFinished is called!");
        //        tcs2.TrySetResult(true);
        //    };
        //    webView.PageLoadFinished += onLoadFinished2;

        //    webView.LoadUrl(secondUrl);
        //    var result2 = await tcs2.Task;
        //    Assert.IsTrue(result2, "PageLoadFinished event should be invoked");

        //    // Make current thread (CPU) sleep...
        //    await Task.Delay(1);

        //    webView.GoBack();
        //    Assert.IsNotNull(webView.BackForwardList.GetForwardItems(1), "handle should not be null.");

        //    webView.PageLoadFinished -= onLoadFinished2;

        //    tlog.Debug(tag, $"WebBackForwardListGetForwardItems END (OK)");
        //}

        [Test]
        [Category("P1")]
        [Description("WebBackForwardListItem Url.")]
        [Property("SPEC", "Tizen.NUI.WebBackForwardListItem.Url A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebBackForwardListItemUrl()
        {
            tlog.Debug(tag, $"WebBackForwardListItemUrl START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tlog.Info(tag, "onLoadFinished is called!");
                tcs.TrySetResult(true);
            };
            webView.PageLoadFinished += onLoadFinished;

            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked.");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            var testingTarget = webView.BackForwardList.GetCurrentItem();
            Assert.IsNotNull(testingTarget, "Handle should not be null.");
            Assert.IsNotNull(testingTarget.Url, "Url should not be null.");
            Assert.IsTrue(testingTarget.Url.Contains("index.html"), "Url of current item should contain a correct string.");

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebBackForwardListItemUrl END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebBackForwardListItem Title.")]
        [Property("SPEC", "Tizen.NUI.WebBackForwardListItem.Title A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebBackForwardListItemTitle()
        {
            tlog.Debug(tag, $"WebBackForwardListItemTitle START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tlog.Info(tag, "onLoadFinished is called!");
                tcs.TrySetResult(true);
            };
            webView.PageLoadFinished += onLoadFinished;

            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked.");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            var testingTarget = webView.BackForwardList.GetCurrentItem();
            Assert.IsNotNull(testingTarget, "handle should not be null.");
            Assert.IsNotNull(testingTarget.Title, "Title should not be null.");
            Assert.IsTrue(testingTarget.Title.Contains("Title"), "Title of current item should contain a correct string.");

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebBackForwardListItemTitle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebBackForwardListItem OriginalUrl.")]
        [Property("SPEC", "Tizen.NUI.WebBackForwardListItem.OriginalUrl A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebBackForwardListItemOriginalUrl()
        {
            tlog.Debug(tag, $"WebBackForwardListItemOriginalUrl START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tlog.Info(tag, "onLoadFinished is called!");
                tcs.TrySetResult(true);
            };
            webView.PageLoadFinished += onLoadFinished;

            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked.");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            var testingTarget = webView.BackForwardList.GetCurrentItem();
            Assert.IsNotNull(testingTarget, "Handle should not be null.");
            Assert.IsNotNull(testingTarget.OriginalUrl, "Url should not be null.");
            Assert.IsTrue(testingTarget.OriginalUrl.Contains("index.html"), "Url of current item should contain a correct string.");

            webView.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebBackForwardListItemOriginalUrl END (OK)");
        }
    }
}
