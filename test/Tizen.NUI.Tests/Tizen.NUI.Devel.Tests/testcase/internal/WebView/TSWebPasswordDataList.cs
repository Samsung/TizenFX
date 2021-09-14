using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/WebView/WebPasswordDataList")]
    public class InternalWebPasswordDataListTest
    {
        private const string tag = "NUITEST";
        private string url = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

        internal class MyWebPasswordDataList : WebPasswordDataList
        {
            public MyWebPasswordDataList(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
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
        [Description("WebPasswordDataList constructor.")]
        [Property("SPEC", "Tizen.NUI.WebPasswordDataList.WebPasswordDataList C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebPasswordDataListConstructor()
        {
            tlog.Debug(tag, $"WebPasswordDataListConstructor START");

            using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                var testingTarget = new WebPasswordDataList(webview.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<WebPasswordDataList>(testingTarget, "Should return WebPasswordDataList instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"WebPasswordDataListConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebPasswordDataList ItemCount.")]
        [Property("SPEC", "Tizen.NUI.WebPasswordDataList.ItemCount A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebPasswordDataListItemCount()
        {
            tlog.Debug(tag, $"WebPasswordDataListItemCount START");

            using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                webview.LoadUrl(url);

                var testingTarget = new WebPasswordDataList(webview.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<WebPasswordDataList>(testingTarget, "Should return WebPasswordDataList instance.");

                tlog.Error(tag, "ItemCount : " + testingTarget.ItemCount);

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"WebPasswordDataListItemCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebPasswordDataList GetItemAtIndex.")]
        [Property("SPEC", "Tizen.NUI.WebPasswordDataList.GetItemAtIndex M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebPasswordDataListGetItemAtIndex()
        {
            tlog.Debug(tag, $"WebPasswordDataListGetItemAtIndex START");

            using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                webview.LoadUrl(url);

                var testingTarget = new WebPasswordDataList(webview.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<WebPasswordDataList>(testingTarget, "Should return WebPasswordDataList instance.");

                tlog.Error(tag, "Item : " + testingTarget.GetItemAtIndex(0));

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"WebPasswordDataListGetItemAtIndex END (OK)");
        }
    }
}
