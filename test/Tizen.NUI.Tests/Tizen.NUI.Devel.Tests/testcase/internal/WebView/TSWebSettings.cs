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
    [Description("internal/WebView/WebSettings")]
    public class InternalWebSettingsTest
    {
        private const string tag = "NUITEST";
        private string url = $"file://{Tizen.Applications.Application.Current.DirectoryInfo.Resource}webview/index.html";

        private BaseComponents.WebView webview = null;

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            webview = new BaseComponents.WebView()
            {
                Size = new Size(500, 200),
            };
        }

        [TearDown]
        public void Destroy()
        {
            tlog.Info(tag, "Destroy() is being called!");
            webview.Dispose();
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
        public async Task WebSettingsMixedContentsAllowed()
        {
            tlog.Debug(tag, $"WebSettingsMixedContentsAllowed START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tcs.TrySetResult(true);
            };
            webview.PageLoadFinished += onLoadFinished;

            webview.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webview.PageLoadFinished -= onLoadFinished;

            var webSettings = webview.Settings;
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
        public async Task WebSettingsSpatialNavigationEnabled()
        {
            tlog.Debug(tag, $"WebSettingsSpatialNavigationEnabled START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tcs.TrySetResult(true);
            };
            webview.PageLoadFinished += onLoadFinished;

            webview.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webview.PageLoadFinished -= onLoadFinished;

            var webSettings = webview.Settings;
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
        public async Task WebSettingsWebSecurityEnabled()
        {
            tlog.Debug(tag, $"WebSettingsWebSecurityEnabled START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tcs.TrySetResult(true);
            };
            webview.PageLoadFinished += onLoadFinished;

            webview.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webview.PageLoadFinished -= onLoadFinished;

            var webSettings = webview.Settings;
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
        public async Task WebSettingsCacheBuilderEnabled()
        {
            tlog.Debug(tag, $"WebSettingsCacheBuilderEnabled START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tcs.TrySetResult(true);
            };
            webview.PageLoadFinished += onLoadFinished;

            webview.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webview.PageLoadFinished -= onLoadFinished;

            var webSettings = webview.Settings;
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
        public async Task WebSettingsDoNotTrackEnabled()
        {
            tlog.Debug(tag, $"WebSettingsDoNotTrackEnabled START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tcs.TrySetResult(true);
            };
            webview.PageLoadFinished += onLoadFinished;

            webview.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webview.PageLoadFinished -= onLoadFinished;

            var webSettings = webview.Settings;
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
        public async Task WebSettingsScrollbarThumbFocusNotificationsUsed()
        {
            tlog.Debug(tag, $"WebSettingsScrollbarThumbFocusNotificationsUsed START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tcs.TrySetResult(true);
            };
            webview.PageLoadFinished += onLoadFinished;

            webview.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webview.PageLoadFinished -= onLoadFinished;

            var webSettings = webview.Settings;
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
        public async Task WebSettingsFileAccessFromExternalUrlAllowed()
        {
            tlog.Debug(tag, $"WebSettingsFileAccessFromExternalUrlAllowed START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tcs.TrySetResult(true);
            };
            webview.PageLoadFinished += onLoadFinished;

            webview.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webview.PageLoadFinished -= onLoadFinished;

            var webSettings = webview.Settings;
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
        public async Task WebSettingsAutoFittingEnabled()
        {
            tlog.Debug(tag, $"WebSettingsAutoFittingEnabled START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tcs.TrySetResult(true);
            };
            webview.PageLoadFinished += onLoadFinished;

            webview.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webview.PageLoadFinished -= onLoadFinished;

            var webSettings = webview.Settings;
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
        public async Task WebSettingsPluginsEnabled()
        {
            tlog.Debug(tag, $"WebSettingsPluginsEnabled START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tcs.TrySetResult(true);
            };
            webview.PageLoadFinished += onLoadFinished;

            webview.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webview.PageLoadFinished -= onLoadFinished;

            var webSettings = webview.Settings;
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
        public async Task WebSettingsPrivateBrowsingEnabled()
        {
            tlog.Debug(tag, $"WebSettingsPrivateBrowsingEnabled START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tcs.TrySetResult(true);
            };
            webview.PageLoadFinished += onLoadFinished;

            webview.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webview.PageLoadFinished -= onLoadFinished;

            var webSettings = webview.Settings;
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
        public async Task WebSettingsLinkMagnifierEnabled()
        {
            tlog.Debug(tag, $"WebSettingsLinkMagnifierEnabled START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tcs.TrySetResult(true);
            };
            webview.PageLoadFinished += onLoadFinished;

            webview.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webview.PageLoadFinished -= onLoadFinished;

            var webSettings = webview.Settings;
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
        public async Task WebSettingsKeypadWithoutUserActionUsed()
        {
            tlog.Debug(tag, $"WebSettingsKeypadWithoutUserActionUsed START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tcs.TrySetResult(true);
            };
            webview.PageLoadFinished += onLoadFinished;

            webview.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webview.PageLoadFinished -= onLoadFinished;

            var webSettings = webview.Settings;
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
        public async Task WebSettingsAutofillPasswordFormEnabled()
        {
            tlog.Debug(tag, $"WebSettingsAutofillPasswordFormEnabled START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tcs.TrySetResult(true);
            };
            webview.PageLoadFinished += onLoadFinished;

            webview.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webview.PageLoadFinished -= onLoadFinished;

            var webSettings = webview.Settings;
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
        public async Task WebSettingsFormCandidateDataEnabled()
        {
            tlog.Debug(tag, $"WebSettingsFormCandidateDataEnabled START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tcs.TrySetResult(true);
            };
            webview.PageLoadFinished += onLoadFinished;

            webview.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webview.PageLoadFinished -= onLoadFinished;

            var webSettings = webview.Settings;
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
        public async Task WebSettingsTextSelectionEnabled()
        {
            tlog.Debug(tag, $"WebSettingsTextSelectionEnabled START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tcs.TrySetResult(true);
            };
            webview.PageLoadFinished += onLoadFinished;

            webview.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webview.PageLoadFinished -= onLoadFinished;

            var webSettings = webview.Settings;
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
        public async Task WebSettingsTextAutosizingEnabled()
        {
            tlog.Debug(tag, $"WebSettingsTextAutosizingEnabled START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tcs.TrySetResult(true);
            };
            webview.PageLoadFinished += onLoadFinished;

            webview.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webview.PageLoadFinished -= onLoadFinished;

            var webSettings = webview.Settings;
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
        public async Task WebSettingsArrowScrollEnabled()
        {
            tlog.Debug(tag, $"WebSettingsArrowScrollEnabled START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tcs.TrySetResult(true);
            };
            webview.PageLoadFinished += onLoadFinished;

            webview.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webview.PageLoadFinished -= onLoadFinished;

            var webSettings = webview.Settings;
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
        public async Task WebSettingsClipboardEnabled()
        {
            tlog.Debug(tag, $"WebSettingsClipboardEnabled START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tcs.TrySetResult(true);
            };
            webview.PageLoadFinished += onLoadFinished;

            webview.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webview.PageLoadFinished -= onLoadFinished;

            var webSettings = webview.Settings;
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
        public async Task WebSettingsImePanelEnabled()
        {
            tlog.Debug(tag, $"WebSettingsImePanelEnabled START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tcs.TrySetResult(true);
            };
            webview.PageLoadFinished += onLoadFinished;

            webview.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webview.PageLoadFinished -= onLoadFinished;

            var webSettings = webview.Settings;
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
        public async Task WebSettingsScriptsOpenWindowsAllowed()
        {
            tlog.Debug(tag, $"WebSettingsScriptsOpenWindowsAllowed START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tcs.TrySetResult(true);
            };
            webview.PageLoadFinished += onLoadFinished;

            webview.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webview.PageLoadFinished -= onLoadFinished;

            var webSettings = webview.Settings;
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
        public async Task WebSettingsViewportMetaTag()
        {
            tlog.Debug(tag, $"WebSettingsViewportMetaTag START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tcs.TrySetResult(true);
            };
            webview.PageLoadFinished += onLoadFinished;

            webview.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webview.PageLoadFinished -= onLoadFinished;

            var webSettings = webview.Settings;
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
        public async Task WebSettingsZoomForced()
        {
            tlog.Debug(tag, $"WebSettingsZoomForced START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tcs.TrySetResult(true);
            };
            webview.PageLoadFinished += onLoadFinished;

            webview.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webview.PageLoadFinished -= onLoadFinished;

            var webSettings = webview.Settings;
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
        public async Task WebSettingsTextZoomEnabled()
        {
            tlog.Debug(tag, $"WebSettingsTextZoomEnabled START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tcs.TrySetResult(true);
            };
            webview.PageLoadFinished += onLoadFinished;

            webview.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webview.PageLoadFinished -= onLoadFinished;

            var webSettings = webview.Settings;
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
        public async Task WebSettingsEnableExtraFeature()
        {
            tlog.Debug(tag, $"WebSettingsEnableExtraFeature START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tcs.TrySetResult(true);
            };
            webview.PageLoadFinished += onLoadFinished;

            webview.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webview.PageLoadFinished -= onLoadFinished;

            var webSettings = webview.Settings;

            bool newValue = !webSettings.IsExtraFeatureEnabled("longpress,enable");
            webSettings.EnableExtraFeature("longpress,enable", newValue);

            webSettings.Dispose();

            tlog.Debug(tag, $"WebSettingsEnableExtraFeature END (OK)");
        }
    }
}
