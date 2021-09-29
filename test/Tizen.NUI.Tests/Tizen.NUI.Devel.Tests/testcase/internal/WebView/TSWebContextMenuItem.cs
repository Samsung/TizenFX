using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests 
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/WebView/WebContextMenuItem")]
    public class InternalWebContextMenuItemTest
    {
        private const string tag = "NUITEST";
        private string url = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

        internal class MyWebContextMenuItem : WebContextMenuItem
        {
            public MyWebContextMenuItem(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
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
        [Description("WebContextMenuItem constructor.")]
        [Property("SPEC", "Tizen.NUI.WebContextMenuItem.WebContextMenuItem C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebContextMenuItemConstructor()
        {
            tlog.Debug(tag, $"WebContextMenuItemConstructor START");

            using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                WebContextMenu menu = new WebContextMenu(webview.SwigCPtr.Handle, false);

                var testingTarget = new WebContextMenuItem(menu.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<WebContextMenuItem>(testingTarget, "Should return WebContextMenuItem instance.");

                menu.Dispose();
                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"WebContextMenuItemConstructor END (OK)");
        }
    }
}
