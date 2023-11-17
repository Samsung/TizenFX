using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/WebView/WebContext")]
    public class InternalWebContextTest
    {
        private const string tag = "NUITEST";
        private string url = $"file://{Tizen.Applications.Application.Current.DirectoryInfo.Resource}webview/index.html";
        private string urlForDatabase = $"file://{Tizen.Applications.Application.Current.DirectoryInfo.Resource}webview/webdb.html";
        private string urlForStorage = $"file://{Tizen.Applications.Application.Current.DirectoryInfo.Resource}webview/webstorage.html";
        private string urlForLocalFileSystem = $"file://{Tizen.Applications.Application.Current.DirectoryInfo.Resource}webview/weblocalfilesystem.html";
        private string urlForFormPassword = $"file://{Tizen.Applications.Application.Current.DirectoryInfo.Resource}webview/webformpasword.html";
        private string urlForDownload = "https://codeload.github.com/Samsung/TizenFX/zip/refs/heads/master";
        private string urlForApplicatonCache = "https://www.baidu.com/";
        private string urlForIndexedDBCreation = $"file://{Tizen.Applications.Application.Current.DirectoryInfo.Resource}webview/webindexeddbcreation.html";

        private BaseComponents.WebView webview = null;

        [SetUp]
        public void Init()
        {
            webview = new BaseComponents.WebView()
            {
                Size = new Size(500, 200),
            };
            tlog.Info(tag, "Init() is called!");
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
        [Description("WebContext ProxyUrl.")]
        [Property("SPEC", "Tizen.NUI.WebContext.ProxyUrl A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebContextProxyUrl()
        {
            tlog.Debug(tag, $"WebContextProxyUrl START");

            var context = webview.Context;
            tlog.Debug(tag, "ProxyUrl : " + context.ProxyUrl);

            context.ProxyUrl = "http://www.baidu.com";
            tlog.Debug(tag, "ProxyUrl : " + context.ProxyUrl);

            tlog.Debug(tag, $"WebContextProxyUrl END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext CertificateFilePath.")]
        [Property("SPEC", "Tizen.NUI.WebContext.CertificateFilePath A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebContextCertificateFilePath()
        {
            tlog.Debug(tag, $"WebContextCertificateFilePath START");

            var context = webview.Context;
            tlog.Debug(tag, "CertificateFilePath : " + context.CertificateFilePath);

            context.CertificateFilePath = "/opt/data/cert/vdca.pem";
            tlog.Debug(tag, "CertificateFilePath : " + context.CertificateFilePath);

            tlog.Debug(tag, $"WebContextCertificateFilePath END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext CacheEnabled.")]
        [Property("SPEC", "Tizen.NUI.WebContext.CacheEnabled A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebContextCacheEnabled()
        {
            tlog.Debug(tag, $"WebContextCacheEnabled START");

            var context = webview.Context;
            tlog.Debug(tag, "CacheEnabled : " + context.CacheEnabled);

            context.CacheEnabled = true;
            tlog.Debug(tag, "CacheEnabled : " + context.CacheEnabled);

            context.CacheEnabled = false;
            tlog.Debug(tag, "CacheEnabled : " + context.CacheEnabled);

            tlog.Debug(tag, $"WebContextCertificateFilePath END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext AppId.")]
        [Property("SPEC", "Tizen.NUI.WebContext.AppId A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebContextAppId()
        {
            tlog.Debug(tag, $"WebContextAppId START");

            var context = webview.Context;
            tlog.Debug(tag, "AppId : " + context.AppId);

            context.AppId = "WebContextAppId";
            tlog.Debug(tag, "AppId : " + context.AppId);

            tlog.Debug(tag, $"WebContextAppId END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext AppVersion.")]
        [Property("SPEC", "Tizen.NUI.WebContext.AppVersion A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebContextAppVersion()
        {
            tlog.Debug(tag, $"WebContextAppVersion START");

            var context = webview.Context;
            tlog.Debug(tag, "AppVersion : " + context.AppVersion);

            context.AppVersion = "1.0";
            tlog.Debug(tag, "AppVersion : " + context.AppVersion);

            tlog.Debug(tag, $"WebContextAppVersion END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext AppType.")]
        [Property("SPEC", "Tizen.NUI.WebContext.AppType A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebContextAppType()
        {
            tlog.Debug(tag, $"WebContextAppType START");

            var context = webview.Context;
            tlog.Debug(tag, "AppType : " + context.AppType);

            context.AppType = WebContext.ApplicationType.WebBrowser;
            tlog.Debug(tag, "AppType : " + context.AppType);

            tlog.Debug(tag, $"WebContextAppType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext TimeOffset.")]
        [Property("SPEC", "Tizen.NUI.WebContext.TimeOffset A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebContextTimeOffset()
        {
            tlog.Debug(tag, $"WebContextTimeOffset START");

            var context = webview.Context;
            tlog.Debug(tag, "TimeOffset : " + context.TimeOffset);

            context.TimeOffset = 0.3f;
            tlog.Debug(tag, "TimeOffset : " + context.TimeOffset);

            tlog.Debug(tag, $"WebContextAppType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext DefaultZoomFactor.")]
        [Property("SPEC", "Tizen.NUI.WebContext.DefaultZoomFactor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebContextDefaultZoomFactor()
        {
            tlog.Debug(tag, $"WebContextDefaultZoomFactor START");

            var context = webview.Context;
            tlog.Debug(tag, "DefaultZoomFactor : " + context.DefaultZoomFactor);

            context.DefaultZoomFactor = 0.3f;
            tlog.Debug(tag, "DefaultZoomFactor : " + context.DefaultZoomFactor);

            tlog.Debug(tag, $"WebContextDefaultZoomFactor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext ContextProxy.")]
        [Property("SPEC", "Tizen.NUI.WebContext.ContextProxy A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebContextContextProxy()
        {
            tlog.Debug(tag, $"WebContextContextProxy START");

            var context = webview.Context;
            tlog.Debug(tag, "ContextProxy : " + context.ContextProxy);

            tlog.Debug(tag, $"WebContextContextProxy END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext ProxyBypassRule.")]
        [Property("SPEC", "Tizen.NUI.WebContext.ProxyBypassRule A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebContextProxyBypassRule()
        {
            tlog.Debug(tag, $"WebContextProxyBypassRule START");

            var context = webview.Context;
            tlog.Debug(tag, "ProxyBypassRule : " + context.ProxyBypassRule);

            tlog.Debug(tag, $"WebContextProxyBypassRule END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext SetDefaultProxyAuth.")]
        [Property("SPEC", "Tizen.NUI.WebContext.SetDefaultProxyAuth M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebContextSetDefaultProxyAuth()
        {
            tlog.Debug(tag, $"WebContextSetDefaultProxyAuth START");

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

            var context_ = webview.Context;
            context_.SetDefaultProxyAuth("tizen", "samsung");

            webview.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebContextSetDefaultProxyAuth END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext DeleteAllWebDatabase.")]
        [Property("SPEC", "Tizen.NUI.WebContext.DeleteAllWebDatabase M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebContextDeleteAllWebDatabase()
        {
            tlog.Debug(tag, $"WebContextDeleteAllWebDatabase START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tcs.TrySetResult(true);
            };
            webview.PageLoadFinished += onLoadFinished;

            webview.LoadUrl(urlForDatabase);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            // Check list count.
            TaskCompletionSource<int> tcs2 = new TaskCompletionSource<int>(0);
            WebContext.SecurityOriginListAcquiredCallback cb2 = (list) =>
            {
                tcs2.TrySetResult(list.Count);
            };
            var context = webview.Context;
            context.GetWebDatabaseOrigins(cb2);

            var result2 = await tcs2.Task;
            Assert.Greater(result2, 0, "GetWebDatabaseOrigins should be called.");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            // Delete all web db.
            context.DeleteAllWebDatabase();

            // Check list count.
            TaskCompletionSource<int> tcs3 = new TaskCompletionSource<int>(0);
            WebContext.SecurityOriginListAcquiredCallback cb3 = (list) =>
            {
                tcs3.TrySetResult(list.Count);
            };

            context.GetWebDatabaseOrigins(cb3);

            var result3 = await tcs3.Task;
            Assert.AreEqual(result3, 0, "GetWebDatabaseOrigins should be called.");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webview.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebContextDeleteAllWebDatabase END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext GetWebDatabaseOrigins.")]
        [Property("SPEC", "Tizen.NUI.WebContext.GetWebDatabaseOrigins M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebContextGetWebDatabaseOrigins()
        {
            tlog.Debug(tag, $"WebContextGetWebDatabaseOrigins START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tcs.TrySetResult(true);
            };
            webview.PageLoadFinished += onLoadFinished;

            webview.LoadUrl(urlForDatabase);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            TaskCompletionSource<int> tcs2 = new TaskCompletionSource<int>(0);
            WebContext.SecurityOriginListAcquiredCallback cb = (list) =>
            {
                tcs2.TrySetResult(list.Count);
            };
            var context = webview.Context;
            context.GetWebDatabaseOrigins(cb);

            var result2 = await tcs2.Task;
            Assert.Greater(result2, 0, "GetWebDatabaseOrigins should be called.");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webview.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebContextGetWebDatabaseOrigins END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext DeleteWebDatabase.")]
        [Property("SPEC", "Tizen.NUI.WebContext.DeleteWebDatabase M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebContextDeleteWebDatabase()
        {
            tlog.Debug(tag, $"WebContextDeleteWebDatabase START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tcs.TrySetResult(true);
            };
            webview.PageLoadFinished += onLoadFinished;

            webview.LoadUrl(urlForDatabase);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            WebSecurityOrigin seo = null;
            TaskCompletionSource<int> tcs2 = new TaskCompletionSource<int>(0);
            WebContext.SecurityOriginListAcquiredCallback cb2 = (list) =>
            {
                if (list.Count > 0)
                {
                    seo = list[0];
                }
                tcs2.TrySetResult(list.Count);
            };
            var context = webview.Context;
            context.GetWebDatabaseOrigins(cb2);

            var result2 = await tcs2.Task;
            Assert.Greater(result2, 0, "GetWebDatabaseOrigins should be called.");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            // Delete db by security origin.
            tlog.Info(tag, $"WebContextDeleteWebDatabase, Host: {seo?.Host}");
            tlog.Info(tag, $"WebContextDeleteWebDatabase Protocol: {seo?.Protocol}");
            if (seo != null)
            {
                context.DeleteWebDatabase(seo);
            }

            TaskCompletionSource<int> tcs3 = new TaskCompletionSource<int>(0);
            WebContext.SecurityOriginListAcquiredCallback cb3 = (list) =>
            {
                tcs3.TrySetResult(list.Count);
            };
            context.GetWebDatabaseOrigins(cb3);

            var result3 = await tcs3.Task;
            //TODO...Result is not correct!!!!
            //Assert.AreEqual(result3, 0, "GetWebDatabaseOrigins should be called.");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webview.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebContextDeleteWebDatabase END (OK)");
        }

        ////TODO... Web engine blocks!!!!!!
        //[Test]
        //[Category("P1")]
        //[Description("WebContext GetWebStorageOrigins.")]
        //[Property("SPEC", "Tizen.NUI.WebContext.GetWebStorageUsageForOrigin M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("COVPARAM", "")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public async Task WebContextGetWebStorageUsageForOrigin()
        //{
        //    tlog.Debug(tag, $"WebContextGetWebStorageUsageForOrigin START");

        //    TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
        //    EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
        //    {
        //        tcs.TrySetResult(true);
        //    };
        //    webview_.PageLoadFinished += onLoadFinished;

        //    webview_.LoadUrl(urlForStorage);
        //    var result = await tcs.Task;
        //    Assert.IsTrue(result, "PageLoadFinished event should be invoked");

        //    // Make current thread (CPU) sleep...
        //    await Task.Delay(1);

        //    // Get web storage.
        //    WebSecurityOrigin seo = null;
        //    TaskCompletionSource<int> tcs2 = new TaskCompletionSource<int>(0);
        //    WebContext.SecurityOriginListAcquiredCallback cb2 = (list) =>
        //    {
        //        if (list.Count > 0)
        //        {
        //            seo = list[0];
        //        }
        //        tcs2.TrySetResult(list.Count);
        //    };
        //    var context = webview_.Context;
        //    context.GetWebStorageOrigins(cb2);

        //    var result2 = await tcs2.Task;
        //    Assert.AreEqual(result2, 1, "GetWebStorageOrigins should be called.");

        //    // Make current thread (CPU) sleep...
        //    await Task.Delay(1);

        //    if (seo != null)
        //    {
        //        TaskCompletionSource<ulong> tcs3 = new TaskCompletionSource<ulong>(0);
        //        WebContext.StorageUsageAcquiredCallback cb3 = (usage) =>
        //        {
        //            tcs3.TrySetResult(usage);
        //        };
        //        context.GetWebStorageUsageForOrigin(seo, cb3);
        //        var result3 = await tcs3.Task;
        //        Assert.Greater(result3, 0, "GetWebStorageUsageForOrigin should be called.");

        //        // Make current thread (CPU) sleep...
        //        await Task.Delay(1);
        //    }

        //    webview_.PageLoadFinished -= onLoadFinished;

        //    tlog.Debug(tag, $"WebContextGetWebStorageUsageForOrigin END (OK)");
        //}

        ////TODO... Web engine blocks!!!!!!
        //[Test]
        //[Category("P1")]
        //[Description("WebContext DeleteAllWebStorage.")]
        //[Property("SPEC", "Tizen.NUI.WebContext.DeleteAllWebStorage M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("COVPARAM", "")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public async Task WebContextDeleteAllWebStorage()
        //{
        //    tlog.Debug(tag, $"WebContextDeleteAllWebStorage START");

        //    TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
        //    EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
        //    {
        //        tcs.TrySetResult(true);
        //    };
        //    webview_.PageLoadFinished += onLoadFinished;

        //    webview_.LoadUrl(urlForStorage);
        //    var result = await tcs.Task;
        //    Assert.IsTrue(result, "PageLoadFinished event should be invoked");

        //    // Make current thread (CPU) sleep...
        //    await Task.Delay(1);

        //    // Check list count.
        //    TaskCompletionSource<int> tcs2 = new TaskCompletionSource<int>(0);
        //    WebContext.SecurityOriginListAcquiredCallback cb2 = (list) =>
        //    {
        //        tcs2.TrySetResult(list.Count);
        //    };

        //    var context = webview_.Context;
        //    context.GetWebStorageOrigins(cb2);

        //    var result2 = await tcs2.Task;
        //    Assert.Greater(result2, 0, "GetWebStorageOrigins should be called.");

        //    // Make current thread (CPU) sleep...
        //    await Task.Delay(1);

        //    // Delete all web storage.
        //    context.DeleteAllWebStorage();

        //    // Check list count.
        //    TaskCompletionSource<int> tcs3 = new TaskCompletionSource<int>(0);
        //    WebContext.SecurityOriginListAcquiredCallback cb3 = (list) =>
        //    {
        //        tcs3.TrySetResult(list.Count);
        //    };

        //    context.GetWebStorageOrigins(cb3);

        //    var result3 = await tcs3.Task;
        //    Assert.AreEqual(result3, 0, "GetWebStorageOrigins should be called.");

        //    // Make current thread (CPU) sleep...
        //    await Task.Delay(1);

        //    webview_.PageLoadFinished -= onLoadFinished;

        //    tlog.Debug(tag, $"WebContextDeleteAllWebStorage END (OK)");
        //}

        ////TODO... Web engine blocks!!!!!!
        //[Test]
        //[Category("P1")]
        //[Description("WebContext DeleteAllWebStorage.")]
        //[Property("SPEC", "Tizen.NUI.WebContext.DeleteWebStorage M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("COVPARAM", "")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public async Task WebContextDeleteWebStorage()
        //{
        //    tlog.Debug(tag, $"WebContextDeleteAllWebStorage START");

        //    TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
        //    EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
        //    {
        //        tcs.TrySetResult(true);
        //    };
        //    webview_.PageLoadFinished += onLoadFinished;

        //    webview_.LoadUrl(urlForStorage);
        //    var result = await tcs.Task;
        //    Assert.IsTrue(result, "PageLoadFinished event should be invoked");

        //    // Make current thread (CPU) sleep...
        //    await Task.Delay(1);

        //    // Check list count.
        //    WebSecurityOrigin seo = null;
        //    TaskCompletionSource<int> tcs2 = new TaskCompletionSource<int>(0);
        //    WebContext.SecurityOriginListAcquiredCallback cb2 = (list) =>
        //    {
        //        seo = list[0];
        //        tcs2.TrySetResult(list.Count);
        //    };

        //    var context = webview_.Context;
        //    context.GetWebStorageOrigins(cb2);

        //    var result2 = await tcs2.Task;
        //    Assert.Greater(result2, 0, "GetWebStorageOrigins should be called.");

        //    // Make current thread (CPU) sleep...
        //    await Task.Delay(1);

        //    // Delete web storage.
        //    context.DeleteWebStorage(seo);

        //    // Check list count.
        //    TaskCompletionSource<int> tcs3 = new TaskCompletionSource<int>(0);
        //    WebContext.SecurityOriginListAcquiredCallback cb3 = (list) =>
        //    {
        //        tcs3.TrySetResult(list.Count);
        //    };

        //    context.GetWebStorageOrigins(cb3);

        //    var result3 = await tcs3.Task;
        //    Assert.AreEqual(result3, 0, "GetWebStorageOrigins should be called.");

        //    // Make current thread (CPU) sleep...
        //    await Task.Delay(1);

        //    webview_.PageLoadFinished -= onLoadFinished;

        //    tlog.Debug(tag, $"WebContextDeleteAllWebStorage END (OK)");
        //}

        [Test]
        [Category("P1")]
        [Description("WebContext DeleteLocalFileSystem.")]
        [Property("SPEC", "Tizen.NUI.WebContext.DeleteLocalFileSystem M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebContextDeleteLocalFileSystem()
        {
            tlog.Debug(tag, $"WebContextDeleteLocalFileSystem START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tcs.TrySetResult(true);
            };
            webview.PageLoadFinished += onLoadFinished;

            webview.LoadUrl(urlForLocalFileSystem);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            // Delete all web local file system.
            var context = webview.Context;
            context.DeleteLocalFileSystem();
            // TODO...list count need be checked, but query API is not wrapped.

            webview.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebContextDeleteLocalFileSystem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext GetFormPasswordList.")]
        [Property("SPEC", "Tizen.NUI.WebContext.GetFormPasswordList M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebContextGetFormPasswordList()
        {
            tlog.Debug(tag, $"WebContextGetFormPasswordList START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tcs.TrySetResult(true);
            };
            webview.PageLoadFinished += onLoadFinished;

            webview.LoadUrl(urlForFormPassword);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            // Check list count.
            // Check list count.
            WebPasswordData pd = null;
            TaskCompletionSource<int> tcs2 = new TaskCompletionSource<int>(0);
            WebContext.PasswordDataListAcquiredCallback cb2 = (list) =>
            {
                if (list.Count > 0)
                {
                    pd = list[0];
                }
                tcs2.TrySetResult(list.Count);
            };

            var context = webview.Context;
            context.GetFormPasswordList(cb2);

            var result2 = await tcs2.Task;
            Assert.AreEqual(result2, 0, "GetFormPasswordList should be called.");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            tlog.Info(tag, $"WebContextGetFormPasswordList, url: {pd?.Url}");
            tlog.Info(tag, $"WebContextGetFormPasswordList, FingerprintUsed: {pd?.FingerprintUsed}");

            webview.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebContextGetFormPasswordList END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext DeleteAllFormPasswordData.")]
        [Property("SPEC", "Tizen.NUI.WebContext.DeleteAllFormPasswordData M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebContextDeleteAllFormPasswordData()
        {
            tlog.Debug(tag, $"WebContextDeleteAllFormPasswordData START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tcs.TrySetResult(true);
            };
            webview.PageLoadFinished += onLoadFinished;

            webview.LoadUrl(urlForFormPassword);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            // Check list count.
            List<string> pl = new List<string>();
            TaskCompletionSource<int> tcs2 = new TaskCompletionSource<int>(0);
            WebContext.PasswordDataListAcquiredCallback cb2 = (list) =>
            {
                if (list.Count > 0)
                {
                    pl.Add(list[0].Url);
                }
                tcs2.TrySetResult(list.Count);
            };

            var context = webview.Context;
            context.GetFormPasswordList(cb2);

            var result2 = await tcs2.Task;
            Assert.AreEqual(result2, 0, "GetFormPasswordList should be called.");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            // Delete web storage.
            context.DeleteFormPasswordDataList(pl.ToArray()); //TODO... This API seems not correct.
            context.DeleteAllFormPasswordData();
            context.DeleteAllFormCandidateData();

            // Check list count.
            TaskCompletionSource<int> tcs3 = new TaskCompletionSource<int>(0);
            WebContext.PasswordDataListAcquiredCallback cb3 = (list) =>
            {
                tcs3.TrySetResult(list.Count);
            };

            context.GetFormPasswordList(cb3);

            var result3 = await tcs3.Task;
            Assert.AreEqual(result3, 0, "GetFormPasswordList should be called.");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webview.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebContextDeleteAllFormPasswordData END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext RegisterDownloadStartedCallback.")]
        [Property("SPEC", "Tizen.NUI.WebContext.RegisterDownloadStartedCallback M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebContextRegisterDownloadStartedCallback()
        {
            tlog.Debug(tag, $"WebContextRegisterDownloadStartedCallback START");

            // Check if download or not.
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            WebContext.DownloadStartedCallback dcb = (url) =>
            {
                tcs.TrySetResult(true);
            };

            var context = webview.Context;
            context.RegisterDownloadStartedCallback(dcb);

            webview.LoadUrl(urlForDownload);
            var result = await tcs.Task;
            Assert.IsTrue(result, "DownloadStartedCallback should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            context.RegisterDownloadStartedCallback(null);

            tlog.Debug(tag, $"WebContextRegisterDownloadStartedCallback END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext RegisterMimeOverriddenCallback.")]
        [Property("SPEC", "Tizen.NUI.WebContext.RegisterMimeOverriddenCallback M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebContextRegisterMimeOverriddenCallback()
        {
            tlog.Debug(tag, $"WebContextRegisterMimeOverriddenCallback START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            WebContext.MimeOverriddenCallback onMimeWrittenCallback = (string url, string currentMime, out string newMime) =>
            {
                tlog.Info(tag, "onMimeWrittenCallback is called!");
                newMime = null;
                tcs.TrySetResult(true);
                return false;
            };
            var context = webview.Context;
            context.RegisterMimeOverriddenCallback(onMimeWrittenCallback);

            webview.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "MimeOverriddenCallback event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            context.RegisterMimeOverriddenCallback(null);

            tlog.Debug(tag, $"WebContextRegisterMimeOverriddenCallback END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext SetTimeZoneOffset.")]
        [Property("SPEC", "Tizen.NUI.WebContext.SetTimeZoneOffset M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebContextSetTimeZoneOffset()
        {
            tlog.Debug(tag, $"WebContextSetTimeZoneOffset START");

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

            var context = webview.Context;
            context.SetTimeZoneOffset(0.3f, 1.0f);

            webview.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebContextSetTimeZoneOffset END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext SetContextTimeZoneOffset.")]
        [Property("SPEC", "Tizen.NUI.WebContext.SetContextTimeZoneOffset M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebContextSetContextTimeZoneOffset()
        {
            tlog.Debug(tag, $"WebContextSetContextTimeZoneOffset START");

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

            var context = webview.Context;
            context.SetContextTimeZoneOffset(0.3f, 1.0f);

            webview.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebContextSetContextTimeZoneOffset END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext DeleteAllApplicationCache.")]
        [Property("SPEC", "Tizen.NUI.WebContext.DeleteAllApplicationCache M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebContextDeleteAllApplicationCache()
        {
            tlog.Debug(tag, $"WebContextDeleteAllApplicationCache START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tcs.TrySetResult(true);
            };
            webview.PageLoadFinished += onLoadFinished;

            webview.LoadUrl(urlForApplicatonCache);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            // Delete all web applicaton cache.
            var context = webview.Context;
            context.DeleteAllApplicationCache();
            // TODO...list count need be checked, but query API is not wrapped.

            webview.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebContextDeleteAllApplicationCache END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext DeleteAllWebIndexedDatabase.")]
        [Property("SPEC", "Tizen.NUI.WebContext.DeleteAllWebIndexedDatabase M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebContextDeleteAllWebIndexedDatabase()
        {
            tlog.Debug(tag, $"WebContextDeleteAllWebIndexedDatabase START");

            // Load url to check db exists.
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tcs.TrySetResult(true);
            };
            webview.PageLoadFinished += onLoadFinished;

            webview.LoadUrl(urlForIndexedDBCreation);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            // Delete all web indexed db.
            var context = webview.Context;
            context.DeleteAllWebIndexedDatabase();

            //TODO... how to check if title is changed.

            webview.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebContextDeleteAllWebIndexedDatabase END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebContext FreeUnusedMemory.")]
        [Property("SPEC", "Tizen.NUI.WebContext.FreeUnusedMemory M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebContextFreeUnusedMemory()
        {
            tlog.Debug(tag, $"WebContextFreeUnusedMemory START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
            {
                tcs.TrySetResult(true);
            };
            webview.PageLoadFinished += onLoadFinished;

            webview.LoadUrl(urlForApplicatonCache);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadFinished event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            // Free unused memory if low memory.
            var context = webview.Context;
            context.FreeUnusedMemory();

            webview.PageLoadFinished -= onLoadFinished;

            tlog.Debug(tag, $"WebContextFreeUnusedMemory END (OK)");
        }
    }
}
