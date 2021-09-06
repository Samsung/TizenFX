using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/WebView/WebBackForwardList")]
    public class InternalWebBackForwardListTest
    {
        private const string tag = "NUITEST";
        private string url = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

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
        [Description("WebBackForwardList ItemCount.")]
        [Property("SPEC", "Tizen.NUI.WebBackForwardList.ItemCount A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebBackForwardListConstructor()
        {
            tlog.Debug(tag, $"WebBackForwardListConstructor START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            tlog.Debug(tag, "ItemCount : " + testingTarget.BackForwardList.ItemCount);

            testingTarget.Dispose();
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
        public void WebBackForwardListGetCurrentItem()
        {
            tlog.Debug(tag, $"WebBackForwardListGetCurrentItem START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            tlog.Debug(tag, "GetCurrentItem : " + testingTarget.BackForwardList.GetCurrentItem());

            testingTarget.Dispose();
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
        public void WebBackForwardListGetPreviousItem()
        {
            tlog.Debug(tag, $"WebBackForwardListGetPreviousItem START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            tlog.Debug(tag, "GetCurrentItem : " + testingTarget.BackForwardList.GetPreviousItem());

            testingTarget.Dispose();
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
        public void WebBackForwardListGetNextItem()
        {
            tlog.Debug(tag, $"WebBackForwardListGetNextItem START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            tlog.Debug(tag, "GetNextItem : " + testingTarget.BackForwardList.GetNextItem());

            testingTarget.Dispose();
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
        public void WebBackForwardListGetItemAtIndex()
        {
            tlog.Debug(tag, $"WebBackForwardListGetItemAtIndex START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            tlog.Debug(tag, "GetItemAtIndex : " + testingTarget.BackForwardList.GetItemAtIndex(0));

            testingTarget.Dispose();
            tlog.Debug(tag, $"WebBackForwardListGetItemAtIndex END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebBackForwardList GetBackwardItems.")]
        [Property("SPEC", "Tizen.NUI.WebBackForwardList.GetBackwardItems M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebBackForwardListGetBackwardItems()
        {
            tlog.Debug(tag, $"WebBackForwardListGetBackwardItems START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            tlog.Debug(tag, "GetBackwardItems : " + testingTarget.BackForwardList.GetBackwardItems(0));

            testingTarget.Dispose();
            tlog.Debug(tag, $"WebBackForwardListGetBackwardItems END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebBackForwardList GetForwardItems.")]
        [Property("SPEC", "Tizen.NUI.WebBackForwardList.GetForwardItems M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebBackForwardListGetForwardItems()
        {
            tlog.Debug(tag, $"WebBackForwardListGetForwardItems START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return WebView instance.");

            tlog.Debug(tag, "GetForwardItems : " + testingTarget.BackForwardList.GetForwardItems(0));

            testingTarget.Dispose();
            tlog.Debug(tag, $"WebBackForwardListGetForwardItems END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebBackForwardListItem Url.")]
        [Property("SPEC", "Tizen.NUI.WebBackForwardListItem.Url A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebBackForwardListItemUrl()
        {
            tlog.Debug(tag, $"WebBackForwardListItemUrl START");

            using (Tizen.NUI.BaseComponents.WebView webView = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                var testingTarget = webView.BackForwardList.GetCurrentItem();
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<WebBackForwardListItem>(testingTarget, "Should return WebBackForwardListItem instance.");

                tlog.Debug(tag, "Url : " + testingTarget.Url);

                testingTarget.Dispose();
            }

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
        public void WebBackForwardListItemTitle()
        {
            tlog.Debug(tag, $"WebBackForwardListItemTitle START");

            using (Tizen.NUI.BaseComponents.WebView webView = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                var testingTarget = webView.BackForwardList.GetCurrentItem();
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<WebBackForwardListItem>(testingTarget, "Should return WebBackForwardListItem instance.");

                tlog.Debug(tag, "Title : " + testingTarget.Title);

                testingTarget.Dispose();
            }

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
        public void WebBackForwardListItemOriginalUrl()
        {
            tlog.Debug(tag, $"WebBackForwardListItemOriginalUrl START");

            using (Tizen.NUI.BaseComponents.WebView webView = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                var testingTarget = webView.BackForwardList.GetCurrentItem();
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<WebBackForwardListItem>(testingTarget, "Should return WebBackForwardListItem instance.");

                tlog.Debug(tag, "OriginalUrl : " + testingTarget.OriginalUrl);

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"WebBackForwardListItemOriginalUrl END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebBackForwardSubList ItemCount.")]
        [Property("SPEC", "Tizen.NUI.WebBackForwardSubList.ItemCount A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebBackForwardSubListItemCount()
        {
            tlog.Debug(tag, $"WebBackForwardSubListItemCount START");

            using (Tizen.NUI.BaseComponents.WebView webView = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                webView.LoadUrl("https://www.cnblogs.com/softidea/p/5745369.html");

                var testingTarget = webView.BackForwardList.GetBackwardItems(0);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<WebBackForwardSubList>(testingTarget, "Should return WebBackForwardSubList instance.");

                tlog.Error(tag, "ItemCount : " + testingTarget.ItemCount);

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"WebBackForwardSubListItemCount END (OK)");
        }
    }
}
