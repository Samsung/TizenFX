using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/WebView/WebSettings")]
    public class InternalWebSettingsTest
    {
        private const string tag = "NUITEST";
        private string url = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

        private static string[] runtimeArgs = { "Tizen.NUI.Devel.Tests", "--enable-dali-window", "--enable-spatial-navigation" };
        private const string USER_AGENT = "Mozilla/5.0 (SMART-TV; Linux; Tizen 6.0) AppleWebKit/537.36 (KHTML, like Gecko) SamsungBrowser/4.0 Chrome/76.0.3809.146 TV Safari/537.36";
        private Tizen.NUI.BaseComponents.WebView webView = null;

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");

            webView = new Tizen.NUI.BaseComponents.WebView(runtimeArgs)
            {
                Size = new Size(500, 200),
                UserAgent = USER_AGENT
            };

            webView.LoadUrl("http://www.baidu.com");
        }

        [TearDown]
        public void Destroy()
        {
            webView.ClearCache();
            webView.ClearCookies();
            webView.Dispose();
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("WebSettings MixedContentsAllowed.")]
        [Property("SPEC", "Tizen.NUI.WebSettings.MixedContentsAllowed A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebSettingsMixedContentsAllowed()
        {
            tlog.Debug(tag, $"WebSettingsMixedContentsAllowed START");

            var webSettings = webView.Settings;
            tlog.Debug(tag, "MixedContentsAllowed : " + webSettings.MixedContentsAllowed);

            webSettings.MixedContentsAllowed = true;
            Assert.AreEqual(true, webSettings.MixedContentsAllowed, "Should be equal!");

            webSettings.MixedContentsAllowed = false;
            Assert.AreEqual(false, webSettings.MixedContentsAllowed, "Should be equal!");

            webSettings.Dispose();
            tlog.Debug(tag, $"WebSettingsMixedContentsAllowed END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebSettings SpatialNavigationEnabled.")]
        [Property("SPEC", "Tizen.NUI.WebSettings.SpatialNavigationEnabled A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebSettingsSpatialNavigationEnabled()
        {
            tlog.Debug(tag, $"WebSettingsSpatialNavigationEnabled START");

            var webSettings = webView.Settings;
            tlog.Debug(tag, "SpatialNavigationEnabled : " + webSettings.SpatialNavigationEnabled);

            webSettings.SpatialNavigationEnabled = true;
            Assert.AreEqual(true, webSettings.SpatialNavigationEnabled, "Should be equal!");

            webSettings.SpatialNavigationEnabled = false;
            Assert.AreEqual(false, webSettings.SpatialNavigationEnabled, "Should be equal!");

            webSettings.Dispose();
            tlog.Debug(tag, $"WebSettingsSpatialNavigationEnabled END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebSettings WebSecurityEnabled.")]
        [Property("SPEC", "Tizen.NUI.WebSettings.WebSecurityEnabled A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebSettingsWebSecurityEnabled()
        {
            tlog.Debug(tag, $"WebSettingsWebSecurityEnabled START");

            var webSettings = webView.Settings;
            tlog.Debug(tag, "WebSecurityEnabled : " + webSettings.WebSecurityEnabled);

            webSettings.WebSecurityEnabled = true;
            Assert.AreEqual(true, webSettings.WebSecurityEnabled, "Should be equal!");

            webSettings.WebSecurityEnabled = false;
            Assert.AreEqual(false, webSettings.WebSecurityEnabled, "Should be equal!");

            webSettings.Dispose();
            tlog.Debug(tag, $"WebSettingsWebSecurityEnabled END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebSettings CacheBuilderEnabled.")]
        [Property("SPEC", "Tizen.NUI.WebSettings.CacheBuilderEnabled A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebSettingsCacheBuilderEnabled()
        {
            tlog.Debug(tag, $"WebSettingsCacheBuilderEnabled START");

            var webSettings = webView.Settings;
            tlog.Debug(tag, "CacheBuilderEnabled : " + webSettings.CacheBuilderEnabled);

            webSettings.CacheBuilderEnabled = true;
            Assert.AreEqual(true, webSettings.CacheBuilderEnabled, "Should be equal!");

            webSettings.CacheBuilderEnabled = false;
            Assert.AreEqual(false, webSettings.CacheBuilderEnabled, "Should be equal!");

            webSettings.Dispose();
            tlog.Debug(tag, $"WebSettingsCacheBuilderEnabled END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebSettings DoNotTrackEnabled.")]
        [Property("SPEC", "Tizen.NUI.WebSettings.DoNotTrackEnabled A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebSettingsDoNotTrackEnabled()
        {
            tlog.Debug(tag, $"WebSettingsDoNotTrackEnabled START");

            var webSettings = webView.Settings;
            tlog.Debug(tag, "DoNotTrackEnabled : " + webSettings.DoNotTrackEnabled);

            webSettings.DoNotTrackEnabled = true;
            Assert.AreEqual(true, webSettings.DoNotTrackEnabled, "Should be equal!");

            webSettings.DoNotTrackEnabled = false;
            Assert.AreEqual(false, webSettings.DoNotTrackEnabled, "Should be equal!");

            webSettings.Dispose();
            tlog.Debug(tag, $"WebSettingsDoNotTrackEnabled END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebSettings ScrollbarThumbFocusNotificationsUsed.")]
        [Property("SPEC", "Tizen.NUI.WebSettings.ScrollbarThumbFocusNotificationsUsed A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebSettingsScrollbarThumbFocusNotificationsUsed()
        {
            tlog.Debug(tag, $"WebSettingsScrollbarThumbFocusNotificationsUsed START");

            var webSettings = webView.Settings;
            tlog.Debug(tag, "ScrollbarThumbFocusNotificationsUsed : " + webSettings.ScrollbarThumbFocusNotificationsUsed);

            webSettings.ScrollbarThumbFocusNotificationsUsed = true;
            tlog.Debug(tag, "ScrollbarThumbFocusNotificationsUsed : " + webSettings.ScrollbarThumbFocusNotificationsUsed);

            webSettings.DoNotTrackEnabled = false;
            tlog.Debug(tag, "ScrollbarThumbFocusNotificationsUsed : " + webSettings.ScrollbarThumbFocusNotificationsUsed);

            webSettings.Dispose();
            tlog.Debug(tag, $"WebSettingsScrollbarThumbFocusNotificationsUsed END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebSettings FileAccessFromExternalUrlAllowed.")]
        [Property("SPEC", "Tizen.NUI.WebSettings.FileAccessFromExternalUrlAllowed A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebSettingsFileAccessFromExternalUrlAllowed()
        {
            tlog.Debug(tag, $"WebSettingsFileAccessFromExternalUrlAllowed START");

            var webSettings = webView.Settings;
            tlog.Debug(tag, "FileAccessFromExternalUrlAllowed : " + webSettings.FileAccessFromExternalUrlAllowed);

            webSettings.FileAccessFromExternalUrlAllowed = true;
            Assert.AreEqual(true, webSettings.FileAccessFromExternalUrlAllowed, "Should be equal!");

            webSettings.FileAccessFromExternalUrlAllowed = false;
            Assert.AreEqual(false, webSettings.FileAccessFromExternalUrlAllowed, "Should be equal!");

            webSettings.Dispose();
            tlog.Debug(tag, $"WebSettingsFileAccessFromExternalUrlAllowed END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebSettings AutoFittingEnabled.")]
        [Property("SPEC", "Tizen.NUI.WebSettings.AutoFittingEnabled A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebSettingsAutoFittingEnabled()
        {
            tlog.Debug(tag, $"WebSettingsAutoFittingEnabled START");

            var webSettings = webView.Settings;
            tlog.Debug(tag, "AutoFittingEnabled : " + webSettings.AutoFittingEnabled);

            webSettings.AutoFittingEnabled = true;
            Assert.AreEqual(true, webSettings.AutoFittingEnabled, "Should be equal!");

            webSettings.AutoFittingEnabled = false;
            Assert.AreEqual(false, webSettings.AutoFittingEnabled, "Should be equal!");

            webSettings.Dispose();
            tlog.Debug(tag, $"WebSettingsAutoFittingEnabled END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebSettings PluginsEnabled.")]
        [Property("SPEC", "Tizen.NUI.WebSettings.PluginsEnabled A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebSettingsPluginsEnabled()
        {
            tlog.Debug(tag, $"WebSettingsPluginsEnabled START");

            var webSettings = webView.Settings;
            tlog.Debug(tag, "PluginsEnabled : " + webSettings.PluginsEnabled);

            webSettings.PluginsEnabled = true;
            Assert.AreEqual(true, webSettings.PluginsEnabled, "Should be equal!");

            webSettings.PluginsEnabled = false;
            Assert.AreEqual(false, webSettings.PluginsEnabled, "Should be equal!");

            webSettings.Dispose();
            tlog.Debug(tag, $"WebSettingsPluginsEnabled END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebSettings PrivateBrowsingEnabled.")]
        [Property("SPEC", "Tizen.NUI.WebSettings.PrivateBrowsingEnabled A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebSettingsPrivateBrowsingEnabled()
        {
            tlog.Debug(tag, $"WebSettingsPrivateBrowsingEnabled START");

            var webSettings = webView.Settings;
            tlog.Debug(tag, "PrivateBrowsingEnabled : " + webSettings.PrivateBrowsingEnabled);

            webSettings.PrivateBrowsingEnabled = true;
            tlog.Debug(tag, "PrivateBrowsingEnabled : " + webSettings.PrivateBrowsingEnabled);

            webSettings.PrivateBrowsingEnabled = false;
            tlog.Debug(tag, "PrivateBrowsingEnabled : " + webSettings.PrivateBrowsingEnabled);

            webSettings.Dispose();
            tlog.Debug(tag, $"WebSettingsPrivateBrowsingEnabled END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebSettings LinkMagnifierEnabled.")]
        [Property("SPEC", "Tizen.NUI.WebSettings.LinkMagnifierEnabled A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebSettingsLinkMagnifierEnabled()
        {
            tlog.Debug(tag, $"WebSettingsLinkMagnifierEnabled START");

            var webSettings = webView.Settings;
            tlog.Debug(tag, "LinkMagnifierEnabled : " + webSettings.LinkMagnifierEnabled);

            webSettings.LinkMagnifierEnabled = true;
            tlog.Debug(tag, "LinkMagnifierEnabled : " + webSettings.LinkMagnifierEnabled);

            webSettings.LinkMagnifierEnabled = false;
            tlog.Debug(tag, "LinkMagnifierEnabled : " + webSettings.LinkMagnifierEnabled);

            webSettings.Dispose();
            tlog.Debug(tag, $"WebSettingsLinkMagnifierEnabled END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebSettings KeypadWithoutUserActionUsed.")]
        [Property("SPEC", "Tizen.NUI.WebSettings.KeypadWithoutUserActionUsed A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebSettingsKeypadWithoutUserActionUsed()
        {
            tlog.Debug(tag, $"WebSettingsKeypadWithoutUserActionUsed START");

            var webSettings = webView.Settings;
            tlog.Debug(tag, "KeypadWithoutUserActionUsed : " + webSettings.KeypadWithoutUserActionUsed);

            webSettings.KeypadWithoutUserActionUsed = true;
            Assert.AreEqual(true, webSettings.KeypadWithoutUserActionUsed, "Should be equal!");

            webSettings.KeypadWithoutUserActionUsed = false;
            Assert.AreEqual(false, webSettings.KeypadWithoutUserActionUsed, "Should be equal!");

            webSettings.Dispose();
            tlog.Debug(tag, $"WebSettingsKeypadWithoutUserActionUsed END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebSettings AutofillPasswordFormEnabled.")]
        [Property("SPEC", "Tizen.NUI.WebSettings.AutofillPasswordFormEnabled A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebSettingsAutofillPasswordFormEnabled()
        {
            tlog.Debug(tag, $"WebSettingsAutofillPasswordFormEnabled START");

            var webSettings = webView.Settings;
            tlog.Debug(tag, "AutofillPasswordFormEnabled : " + webSettings.AutofillPasswordFormEnabled);

            webSettings.AutofillPasswordFormEnabled = true;
            Assert.AreEqual(true, webSettings.AutofillPasswordFormEnabled, "Should be equal!");

            webSettings.AutofillPasswordFormEnabled = false;
            Assert.AreEqual(false, webSettings.AutofillPasswordFormEnabled, "Should be equal!");

            webSettings.Dispose();
            tlog.Debug(tag, $"WebSettingsAutofillPasswordFormEnabled END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebSettings FormCandidateDataEnabled.")]
        [Property("SPEC", "Tizen.NUI.WebSettings.FormCandidateDataEnabled A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebSettingsFormCandidateDataEnabled()
        {
            tlog.Debug(tag, $"WebSettingsFormCandidateDataEnabled START");

            var webSettings = webView.Settings;
            tlog.Debug(tag, "FormCandidateDataEnabled : " + webSettings.FormCandidateDataEnabled);

            webSettings.FormCandidateDataEnabled = true;
            Assert.AreEqual(true, webSettings.FormCandidateDataEnabled, "Should be equal!");

            webSettings.FormCandidateDataEnabled = false;
            Assert.AreEqual(false, webSettings.FormCandidateDataEnabled, "Should be equal!");

            webSettings.Dispose();
            tlog.Debug(tag, $"WebSettingsFormCandidateDataEnabled END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebSettings TextSelectionEnabled.")]
        [Property("SPEC", "Tizen.NUI.WebSettings.TextSelectionEnabled A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebSettingsTextSelectionEnabled()
        {
            tlog.Debug(tag, $"WebSettingsTextSelectionEnabled START");

            var webSettings = webView.Settings;
            tlog.Debug(tag, "TextSelectionEnabled : " + webSettings.TextSelectionEnabled);

            webSettings.TextSelectionEnabled = true;
            Assert.AreEqual(true, webSettings.TextSelectionEnabled, "Should be equal!");

            webSettings.TextSelectionEnabled = false;
            Assert.AreEqual(false, webSettings.TextSelectionEnabled, "Should be equal!");

            webSettings.Dispose();
            tlog.Debug(tag, $"WebSettingsTextSelectionEnabled END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebSettings TextAutosizingEnabled.")]
        [Property("SPEC", "Tizen.NUI.WebSettings.TextAutosizingEnabled A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebSettingsTextAutosizingEnabled()
        {
            tlog.Debug(tag, $"WebSettingsTextAutosizingEnabled START");

            var webSettings = webView.Settings;
            tlog.Debug(tag, "TextAutosizingEnabled : " + webSettings.TextAutosizingEnabled);

            webSettings.TextAutosizingEnabled = true;
            Assert.AreEqual(true, webSettings.TextAutosizingEnabled, "Should be equal!");

            webSettings.TextAutosizingEnabled = false;
            Assert.AreEqual(false, webSettings.TextAutosizingEnabled, "Should be equal!");

            webSettings.Dispose();
            tlog.Debug(tag, $"WebSettingsTextAutosizingEnabled END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebSettings ArrowScrollEnabled.")]
        [Property("SPEC", "Tizen.NUI.WebSettings.ArrowScrollEnabled A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebSettingsArrowScrollEnabled()
        {
            tlog.Debug(tag, $"WebSettingsArrowScrollEnabled START");

            var webSettings = webView.Settings;
            tlog.Debug(tag, "ArrowScrollEnabled : " + webSettings.ArrowScrollEnabled);

            webSettings.ArrowScrollEnabled = true;
            tlog.Debug(tag, "ArrowScrollEnabled" + webSettings.ArrowScrollEnabled);

            webSettings.ArrowScrollEnabled = false;
            tlog.Debug(tag, "ArrowScrollEnabled" + webSettings.ArrowScrollEnabled);

            webSettings.Dispose();
            tlog.Debug(tag, $"WebSettingsArrowScrollEnabled END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebSettings ClipboardEnabled.")]
        [Property("SPEC", "Tizen.NUI.WebSettings.ClipboardEnabled A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebSettingsClipboardEnabled()
        {
            tlog.Debug(tag, $"WebSettingsClipboardEnabled START");

            var webSettings = webView.Settings;
            tlog.Debug(tag, "ClipboardEnabled : " + webSettings.ClipboardEnabled);

            webSettings.ClipboardEnabled = true;
            tlog.Debug(tag, "ClipboardEnabled" + webSettings.ClipboardEnabled);

            webSettings.ClipboardEnabled = false;
            tlog.Debug(tag, "ClipboardEnabled" + webSettings.ClipboardEnabled);

            webSettings.Dispose();
            tlog.Debug(tag, $"WebSettingsClipboardEnabled END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebSettings ImePanelEnabled.")]
        [Property("SPEC", "Tizen.NUI.WebSettings.ImePanelEnabled A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebSettingsImePanelEnabled()
        {
            tlog.Debug(tag, $"WebSettingsImePanelEnabled START");

            var webSettings = webView.Settings;
            tlog.Debug(tag, "ImePanelEnabled : " + webSettings.ImePanelEnabled);

            webSettings.ImePanelEnabled = true;
            Assert.AreEqual(true, webSettings.ImePanelEnabled, "Should be equal!");

            webSettings.ImePanelEnabled = false;
            Assert.AreEqual(false, webSettings.ImePanelEnabled, "Should be equal!");

            webSettings.Dispose();
            tlog.Debug(tag, $"WebSettingsImePanelEnabled END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebSettings ScriptsOpenWindowsAllowed.")]
        [Property("SPEC", "Tizen.NUI.WebSettings.ScriptsOpenWindowsAllowed A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebSettingsScriptsOpenWindowsAllowed()
        {
            tlog.Debug(tag, $"WebSettingsScriptsOpenWindowsAllowed START");

            var webSettings = webView.Settings;
            tlog.Debug(tag, "ScriptsOpenWindowsAllowed : " + webSettings.ScriptsOpenWindowsAllowed);

            webSettings.ScriptsOpenWindowsAllowed = true;
            Assert.AreEqual(true, webSettings.ScriptsOpenWindowsAllowed, "Should be equal!");

            webSettings.ScriptsOpenWindowsAllowed = false;
            Assert.AreEqual(false, webSettings.ScriptsOpenWindowsAllowed, "Should be equal!");

            webSettings.Dispose();
            tlog.Debug(tag, $"WebSettingsScriptsOpenWindowsAllowed END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebSettings ViewportMetaTag.")]
        [Property("SPEC", "Tizen.NUI.WebSettings.ViewportMetaTag A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebSettingsViewportMetaTag()
        {
            tlog.Debug(tag, $"WebSettingsViewportMetaTag START");

            var webSettings = webView.Settings;
            tlog.Debug(tag, "ViewportMetaTag : " + webSettings.ViewportMetaTag);

            webSettings.ViewportMetaTag = true;
            Assert.AreEqual(true, webSettings.ViewportMetaTag, "Should be equal!");

            webSettings.ViewportMetaTag = false;
            Assert.AreEqual(false, webSettings.ViewportMetaTag, "Should be equal!");

            webSettings.Dispose();
            tlog.Debug(tag, $"WebSettingsViewportMetaTag END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebSettings ZoomForced.")]
        [Property("SPEC", "Tizen.NUI.WebSettings.ZoomForced A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebSettingsZoomForced()
        {
            tlog.Debug(tag, $"WebSettingsZoomForced START");

            var webSettings = webView.Settings;
            tlog.Debug(tag, "ZoomForced : " + webSettings.ZoomForced);

            webSettings.ZoomForced = true;
            Assert.AreEqual(true, webSettings.ZoomForced, "Should be equal!");

            webSettings.ZoomForced = false;
            Assert.AreEqual(false, webSettings.ZoomForced, "Should be equal!");

            webSettings.Dispose();
            tlog.Debug(tag, $"WebSettingsZoomForced END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebSettings TextZoomEnabled.")]
        [Property("SPEC", "Tizen.NUI.WebSettings.TextZoomEnabled A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebSettingsTextZoomEnabled()
        {
            tlog.Debug(tag, $"WebSettingsTextZoomEnabled START");

            var webSettings = webView.Settings;
            tlog.Debug(tag, "TextZoomEnabled : " + webSettings.TextZoomEnabled);

            webSettings.TextZoomEnabled = true;
            Assert.AreEqual(true, webSettings.TextZoomEnabled, "Should be equal!");

            webSettings.TextZoomEnabled = false;
            Assert.AreEqual(false, webSettings.TextZoomEnabled, "Should be equal!");

            webSettings.Dispose();
            tlog.Debug(tag, $"WebSettingsTextZoomEnabled END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebSettings EnableExtraFeature.")]
        [Property("SPEC", "Tizen.NUI.WebSettings.EnableExtraFeature M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebSettingsEnableExtraFeature()
        {
            tlog.Debug(tag, $"WebSettingsEnableExtraFeature START");

            var webSettings = webView.Settings;

            try
            {
                webSettings.EnableExtraFeature("TextFontEnabled", false);
                tlog.Debug(tag, "IsExtraFeatureEnabled : " + webSettings.IsExtraFeatureEnabled("TextFontEnabled"));
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            webSettings.Dispose();
            tlog.Debug(tag, $"WebSettingsEnableExtraFeature END (OK)");
        }
    }
}
