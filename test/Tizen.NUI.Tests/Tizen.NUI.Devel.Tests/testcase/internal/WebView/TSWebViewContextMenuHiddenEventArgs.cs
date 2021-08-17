using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/WebView/WebViewContextMenuHiddenEventArgs")]
    public class InternalWebViewContextMenuHiddenEventArgsTest
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
        //[Description("WebViewContextMenuHiddenEventArgs constructor.")]
        //[Property("SPEC", "Tizen.NUI.WebViewContextMenuHiddenEventArgs.WebViewContextMenuHiddenEventArgs C")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "CONSTR")]
        //[Property("COVPARAM", "")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WebViewContextMenuHiddenEventArgsConstructor()
        //{
        //    tlog.Debug(tag, $"WebViewContextMenuHiddenEventArgsConstructor START");

        //    using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
        //    {
        //        WebContextMenu menu = new WebContextMenu(webview.SwigCPtr.Handle, false);

        //        var testingTarget = new WebViewContextMenuHiddenEventArgs(menu);
        //        Assert.IsNotNull(testingTarget, "null handle");
        //        Assert.IsInstanceOf<WebViewContextMenuHiddenEventArgs>(testingTarget, "Should return WebViewContextMenuHiddenEventArgs instance.");

        //        menu.Dispose();
        //    }

        //    tlog.Debug(tag, $"WebViewContextMenuHiddenEventArgsConstructor END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("WebViewContextMenuHiddenEventArgs ContextMenu.")]
        //[Property("SPEC", "Tizen.NUI.WebViewContextMenuHiddenEventArgs.ContextMenu A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRO")]
        //[Property("COVPARAM", "")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WebViewContextMenuHiddenEventArgsContextMenu()
        //{
        //    tlog.Debug(tag, $"WebViewContextMenuHiddenEventArgsContextMenu START");

        //    using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
        //    {
        //        WebContextMenu menu = new WebContextMenu(webview.SwigCPtr.Handle, false);

        //        var testingTarget = new WebViewContextMenuHiddenEventArgs(menu);
        //        Assert.IsNotNull(testingTarget, "null handle");
        //        Assert.IsInstanceOf<WebViewContextMenuHiddenEventArgs>(testingTarget, "Should return WebViewContextMenuHiddenEventArgs instance.");

        //        var result = testingTarget.ContextMenu;
        //        tlog.Debug(tag, "ContextMenu : " + result);

        //        menu.Dispose();
        //    }

        //    tlog.Debug(tag, $"WebViewContextMenuHiddenEventArgsContextMenu END (OK)");
        //}
    }
}
