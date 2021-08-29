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
    [Description("internal/WebView/WebPolicyDecisionMaker")]
    public class InternalWebPolicyDecisionMakerTest
    {
        private const string tag = "NUITEST";
        private string url = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";
        private static string[] runtimeArgs = { "Tizen.NUI.Devel.Tests", "--enable-dali-window", "--enable-spatial-navigation" };
        private const string USER_AGENT = "Mozilla/5.0 (SMART-TV; Linux; Tizen 6.0) AppleWebKit/537.36 (KHTML, like Gecko) SamsungBrowser/4.0 Chrome/76.0.3809.146 TV Safari/537.36";

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
        [Description("WebPolicyDecisionMaker Url.")]
        [Property("SPEC", "Tizen.NUI.WebPolicyDecisionMaker.Url A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebPolicyDecisionMakerUrl()
        {
            tlog.Debug(tag, $"WebViewResponsePolicyDecidedEventArgsConstructor START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView(runtimeArgs)
            {
                Size = new Size(500, 200),
                UserAgent = USER_AGENT
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return Tizen.NUI.BaseComponents.WebView instance.");

            testingTarget.ResponsePolicyDecided += OnResponsePolicyDecided;
            NUIApplication.GetDefaultWindow().Add(testingTarget);
            
            testingTarget.LoadUrl("https://www.youtube.com");

            await Task.Delay(30000);
            testingTarget.ClearCache();
            testingTarget.ClearCookies();
            NUIApplication.GetDefaultWindow().Remove(testingTarget);

            testingTarget.Dispose();
            tlog.Debug(tag, $"WebPolicyDecisionMakerUrl END (OK)");
        }

        private void OnResponsePolicyDecided(object sender, WebViewResponsePolicyDecidedEventArgs e)
        {
            tlog.Info(tag, $"response policy decided, Url: {e.ResponsePolicyDecisionMaker.Url}");
            tlog.Info(tag, $"response policy decided, Cookie: {e.ResponsePolicyDecisionMaker.Cookie}");
            tlog.Info(tag, $"response policy decided, PolicyDecisionType: {e.ResponsePolicyDecisionMaker.PolicyDecisionType}");
            tlog.Info(tag, $"response policy decided, ResponseMime: {e.ResponsePolicyDecisionMaker.ResponseMime}");
            tlog.Info(tag, $"response policy decided, ResponseStatusCode: {e.ResponsePolicyDecisionMaker.ResponseStatusCode}");
            tlog.Info(tag, $"response policy decided, DecisionNavigationType: {e.ResponsePolicyDecisionMaker.DecisionNavigationType}");
            tlog.Info(tag, $"response policy decided, Scheme: {e.ResponsePolicyDecisionMaker.Scheme}");
            if (e.ResponsePolicyDecisionMaker.Frame != null)
            {
                tlog.Info(tag, $"response policy decided, Frame.IsMainFrame: {e.ResponsePolicyDecisionMaker.Frame.IsMainFrame}");
            }
            e.ResponsePolicyDecisionMaker.Ignore();
            e.ResponsePolicyDecisionMaker.Suspend();
            e.ResponsePolicyDecisionMaker.Use();
        }
    }
}
