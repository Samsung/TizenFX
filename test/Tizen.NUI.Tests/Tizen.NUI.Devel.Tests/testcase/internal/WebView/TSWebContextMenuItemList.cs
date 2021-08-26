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
    [Description("internal/WebView/WebContextMenuItemList")]
    public class InternalWebContextMenuItemListTest
    {
        private const string tag = "NUITEST";
        private string url = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";
        private static string[] runtimeArgs = { "Tizen.NUI.Devel.Tests", "--enable-dali-window", "--enable-spatial-navigation" };
        private const string USER_AGENT = "Mozilla/5.0 (SMART-TV; Linux; Tizen 6.0) AppleWebKit/537.36 (KHTML, like Gecko) SamsungBrowser/4.0 Chrome/76.0.3809.146 TV Safari/537.36";

        internal class MyWebContextMenuItemList : WebContextMenuItemList
        {
            public MyWebContextMenuItemList(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
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
        [Description("WebContextMenuItemList constructor.")]
        [Property("SPEC", "Tizen.NUI.WebContextMenuItemList.WebContextMenuItemList C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebContextMenuItemListConstructor()
        {
            tlog.Debug(tag, $"WebContextMenuItemListConstructor START");

            using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                WebContextMenu menu = new WebContextMenu(webview.SwigCPtr.Handle, false);

                var testingTarget = new WebContextMenuItemList(menu.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<WebContextMenuItemList>(testingTarget, "Should return WebContextMenuItemList instance.");

                menu.Dispose();
                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"WebContextMenuItemListConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContextMenuItemList ItemCount.")]
        [Property("SPEC", "Tizen.NUI.WebContextMenuItemList.ItemCount A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebContextMenuItemListItemCount()
        {
            tlog.Debug(tag, $"WebContextMenuItemListItemCount START");

            var webview = new Tizen.NUI.BaseComponents.WebView(runtimeArgs)
            {
                Size = new Size(500, 200),
                UserAgent = USER_AGENT
            };
            Assert.IsNotNull(webview, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(webview, "Should return Tizen.NUI.BaseComponents.WebView instance.");

            webview.LoadUrl("http://www.163.com");

            var testingTarget = new WebContextMenuItemList(webview.SwigCPtr.Handle, false);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<WebContextMenuItemList>(testingTarget, "Should return WebContextMenuItemList instance.");
           
            tlog.Error(tag, "ItemCount : " + testingTarget.ItemCount);

            testingTarget.Dispose();
            tlog.Debug(tag, $"WebContextMenuItemListItemCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContextMenuItemList GetItemAtIndex.")]
        [Property("SPEC", "Tizen.NUI.WebContextMenuItemList.GetItemAtIndex M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebContextMenuItemListGetItemAtIndex()
        {
            tlog.Debug(tag, $"WebContextMenuItemListGetItemAtIndex START");

            using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                webview.LoadUrl(url);
                WebContextMenu menu = new WebContextMenu(webview.SwigCPtr.Handle, false);

                var testingTarget = new WebContextMenuItemList(menu.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<WebContextMenuItemList>(testingTarget, "Should return WebContextMenuItemList instance.");

                var result = testingTarget.GetItemAtIndex(0);
                tlog.Error(tag, "WebContextMenuItem  : " + result);

                menu.Dispose();
                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"WebContextMenuItemListGetItemAtIndex END (OK)");
        }
    }
}
