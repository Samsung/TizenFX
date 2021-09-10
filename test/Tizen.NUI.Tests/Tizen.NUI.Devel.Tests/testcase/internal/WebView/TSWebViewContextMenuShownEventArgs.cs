using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/WebView/WebViewContextMenuShownEventArgs")]
    public class InternalWebViewContextMenuShownEventArgsTest
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

        //[Test]
        //[Category("P1")]
        //[Description("WebViewContextMenuShownEventArgs constructor.")]
        //[Property("SPEC", "Tizen.NUI.WebViewContextMenuShownEventArgs.WebViewContextMenuShownEventArgs C")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "CONSTR")]
        //[Property("COVPARAM", "")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WebViewContextMenuShownEventArgsConstructor()
        //{
        //    tlog.Debug(tag, $"WebViewContextMenuShownEventArgsConstructor START");

        //    using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
        //    {
        //        WebContextMenu menu = new WebContextMenu(webview.SwigCPtr.Handle, false);

        //        var testingTarget = new WebViewContextMenuShownEventArgs(menu);
        //        Assert.IsNotNull(testingTarget, "null handle");
        //        Assert.IsInstanceOf<WebViewContextMenuShownEventArgs>(testingTarget, "Should return WebViewContextMenuShownEventArgs instance.");

        //        menu.Dispose();
        //    }

        //    tlog.Debug(tag, $"WebViewContextMenuShownEventArgsConstructor END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("WebViewContextMenuShownEventArgs ContextMenu.")]
        //[Property("SPEC", "Tizen.NUI.WebViewContextMenuShownEventArgs.ContextMenu A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRO")]
        //[Property("COVPARAM", "")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WebViewContextMenuShownEventArgsContextMenu()
        //{
        //    tlog.Debug(tag, $"WebViewContextMenuShownEventArgsContextMenu START");

        //    using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
        //    {
        //        WebContextMenu menu = new WebContextMenu(webview.SwigCPtr.Handle, false);

        //        var testingTarget = new WebViewContextMenuShownEventArgs(menu);
        //        Assert.IsNotNull(testingTarget, "null handle");
        //        Assert.IsInstanceOf<WebViewContextMenuShownEventArgs>(testingTarget, "Should return WebViewContextMenuShownEventArgs instance.");

        //        var result = testingTarget.ContextMenu;
        //        tlog.Debug(tag, "ContextMenu : " + result);

        //        menu.Dispose();
        //    }

        //    tlog.Debug(tag, $"WebViewContextMenuShownEventArgsContextMenu END (OK)");
        //}
    }
}
