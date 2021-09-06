using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/WebView/WebSecurityOriginList")]
    public class InternalWebSecurityOriginListTest
    {
        private const string tag = "NUITEST";

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
        [Description("WebSecurityOriginList constructor.")]
        [Property("SPEC", "Tizen.NUI.WebSecurityOriginList.WebSecurityOriginList C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebSecurityOriginListConstructor()
        {
            tlog.Debug(tag, $"WebSecurityOriginListConstructor START");

            using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                var testingTarget = new WebSecurityOriginList(webview.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<WebSecurityOriginList>(testingTarget, "Should return WebSecurityOriginList instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"WebSecurityOriginListConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebSecurityOriginList ItemCount.")]
        [Property("SPEC", "Tizen.NUI.WebSecurityOriginList.ItemCount A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebSecurityOriginListItemCount()
        {
            tlog.Debug(tag, $"WebSecurityOriginListItemCount START");

            using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                var testingTarget = new WebSecurityOriginList(webview.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<WebSecurityOriginList>(testingTarget, "Should return WebSecurityOriginList instance.");

                tlog.Debug(tag, "ItemCount : " + testingTarget.ItemCount);

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"WebSecurityOriginListItemCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebSecurityOriginList GetItemAtIndex.")]
        [Property("SPEC", "Tizen.NUI.WebSecurityOriginList.GetItemAtIndex A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebSecurityOriginListGetItemAtIndex()
        {
            tlog.Debug(tag, $"WebSecurityOriginListGetItemAtIndex START");

            using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                webview.LoadUrl("http://www.baidu.com");

                var testingTarget = new WebSecurityOriginList(webview.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<WebSecurityOriginList>(testingTarget, "Should return WebSecurityOriginList instance.");

                var result = testingTarget.GetItemAtIndex(0);
                tlog.Debug(tag, "GetItemAtIndex : " + result);

                webview.ClearCache();
                webview.ClearCookies();

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"WebSecurityOriginListGetItemAtIndex END (OK)");
        }
    }
}
