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
    [Description("internal/WebView/WebFormRepostPolicyDecisionMaker")]
    public class InternalWebFormRepostPolicyDecisionMakerTest
    {
        private const string tag = "NUITEST";
        private string url = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";
        private static string[] runtimeArgs = { "Tizen.NUI.Devel.Tests", "--enable-dali-window", "--enable-spatial-navigation" };
        private const string USER_AGENT = "Mozilla/5.0 (SMART-TV; Linux; Tizen 6.0) AppleWebKit/537.36 (KHTML, like Gecko) SamsungBrowser/4.0 Chrome/76.0.3809.146 TV Safari/537.36";

        internal class MyWebFormRepostPolicyDecisionMaker : WebFormRepostPolicyDecisionMaker
        {
            public MyWebFormRepostPolicyDecisionMaker(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
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
        [Description("WebFormRepostPolicyDecisionMaker constructor.")]
        [Property("SPEC", "Tizen.NUI.WebFormRepostPolicyDecisionMaker.WebFormRepostPolicyDecisionMaker C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebFormRepostPolicyDecisionMakerConstructor()
        {
            tlog.Debug(tag, $"WebFormRepostPolicyDecisionMakerConstructor START");

            using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                var testingTarget = new WebFormRepostPolicyDecisionMaker(webview.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<WebFormRepostPolicyDecisionMaker>(testingTarget, "Should return WebFormRepostPolicyDecisionMaker instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"WebFormRepostPolicyDecisionMakerConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebFormRepostPolicyDecisionMaker Reply.")]
        [Property("SPEC", "Tizen.NUI.WebFormRepostPolicyDecisionMaker.Reply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebFormRepostPolicyDecisionMakerReply()
        {
            tlog.Debug(tag, $"WebFormRepostPolicyDecisionMakerReply START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView(runtimeArgs)
            {
                Size = new Size(500, 200),
                UserAgent = USER_AGENT
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return Tizen.NUI.BaseComponents.WebView instance.");

            testingTarget.FormRepostPolicyDecided += OnFormRepostPolicyDecided;
            NUIApplication.GetDefaultWindow().Add(testingTarget);

            testingTarget.LoadUrl("http://www.163.com");

            await Task.Delay(10000);
            testingTarget.ClearCache();
            testingTarget.ClearCookies();
            NUIApplication.GetDefaultWindow().Remove(testingTarget);

            testingTarget.Dispose();
            tlog.Debug(tag, $"WebFormRepostPolicyDecisionMakerReply END (OK)");
        }

        private void OnFormRepostPolicyDecided(object sender, WebViewFormRepostPolicyDecidedEventArgs e)
        {
            tlog.Info(tag, $"form repost policy decided");
            e.FormRepostPolicyDecisionMaker.Reply(false);
        }
    }
}
