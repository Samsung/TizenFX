using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Reflection;
using System.Collections.Generic;
using Tizen.NUI.Binding;
using System.Threading;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/XamlBinding/TizenPlatformServices")]
    public class InternalTizenPlatformServicesTest
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
        [Description("TizenPlatformServices constructor")]
        [Property("SPEC", "Tizen.NUI.Binding.TizenPlatformServices.TizenPlatformServices C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void TizenPlatformServicesConstructor()
        {
            tlog.Debug(tag, $"TizenPlatformServicesConstructor START");

            var testingTarget = new TizenPlatformServices();
            Assert.IsNotNull(testingTarget, "Can't create success object TizenPlatformServices.");
            Assert.IsInstanceOf<TizenPlatformServices>(testingTarget, "Should return TizenPlatformServices instance.");

            tlog.Debug(tag, $"TizenPlatformServicesConstructor END");
        }

        [Test]
        [Category("P1")]
        [Description("TizenPlatformServices BeginInvokeOnMainThread")]
        [Property("SPEC", "Tizen.NUI.Binding.TizenPlatformServices.BeginInvokeOnMainThread M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void BeginInvokeOnMainThread()
        {
            tlog.Debug(tag, $"BeginInvokeOnMainThread START");

            try
            {
                var testingTarget = new TizenPlatformServices();
                Assert.IsNotNull(testingTarget, "Can't create success object TizenPlatformServices.");

                testingTarget.BeginInvokeOnMainThread(() => new View());
            }
            catch(Exception e)
            {
                Assert.Fail("Catch exception " + e.Message.ToString());
            }
            tlog.Debug(tag, $"BeginInvokeOnMainThread END");
        }

        [Test]
        [Category("P1")]
        [Description("TizenPlatformServices StartTimer")]
        [Property("SPEC", "Tizen.NUI.Binding.TizenPlatformServices.StartTimer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void StartTimer()
        {
            tlog.Debug(tag, $"StartTimer START");

            try
            {
                var testingTarget = new TizenPlatformServices();
                Assert.IsNotNull(testingTarget, "Can't create success object TizenPlatformServices.");

                testingTarget.StartTimer(new TimeSpan(10), () => false);
            }
            catch (Exception e)
            {
                Assert.Fail("Catch exception " + e.Message.ToString());
            }
            tlog.Debug(tag, $"StartTimer END");
        }

        [Test]
        [Category("P1")]
        [Description("TizenPlatformServices GetStreamAsync")]
        [Property("SPEC", "Tizen.NUI.Binding.TizenPlatformServices.GetStreamAsync M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void GetStreamAsync()
        {
            tlog.Debug(tag, $"GetStreamAsync START");

            try
            {
                var testingTarget = new TizenPlatformServices();
                Assert.IsNotNull(testingTarget, "Can't create success object TizenPlatformServices.");

                testingTarget.GetStreamAsync(new Uri("https://www.tizen.org/sites/all/themes/tizen_theme/logo.png"), CancellationToken.None);
            }
            catch (Exception e)
            {
                Assert.Fail("Catch exception " + e.Message.ToString());
            }
            tlog.Debug(tag, $"GetStreamAsync END");
        }

        [Test]
        [Category("P1")]
        [Description("TizenPlatformServices GetAssemblies")]
        [Property("SPEC", "Tizen.NUI.Binding.TizenPlatformServices.GetAssemblies M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void GetAssemblies()
        {
            tlog.Debug(tag, $"GetAssemblies START");

            try
            {
                var testingTarget = new TizenPlatformServices();
                Assert.IsNotNull(testingTarget, "Can't create success object TizenPlatformServices.");

                Assert.IsNotNull(testingTarget.GetAssemblies(), "Should not be null");
            }
            catch (Exception e)
            {
                Assert.Fail("Catch exception " + e.Message.ToString());
            }
            tlog.Debug(tag, $"GetAssemblies END");
        }

        [Test]
        [Category("P1")]
        [Description("TizenPlatformServices GetMD5Hash")]
        [Property("SPEC", "Tizen.NUI.Binding.TizenPlatformServices.GetMD5Hash M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void GetMD5Hash()
        {
            tlog.Debug(tag, $"GetMD5Hash START");

            try
            {
                var testingTarget = new TizenPlatformServices();
                Assert.IsNotNull(testingTarget, "Can't create success object TizenPlatformServices.");

                Assert.IsNotNull(testingTarget.GetMD5Hash("ABCDEFG"), "Should not be null");
            }
            catch (Exception e)
            {
                Assert.Fail("Catch exception " + e.Message.ToString());
            }
            tlog.Debug(tag, $"GetMD5Hash END");
        }

        [Test]
        [Category("P1")]
        [Description("TizenPlatformServices QuitApplication")]
        [Property("SPEC", "Tizen.NUI.Binding.TizenPlatformServices.QuitApplication M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void QuitApplication()
        {
            tlog.Debug(tag, $"QuitApplication START");

            try
            {
                var testingTarget = new TizenPlatformServices();
                Assert.IsNotNull(testingTarget, "Can't create success object TizenPlatformServices.");

                testingTarget.QuitApplication();
            }
            catch (Exception e)
            {
                Assert.Fail("Catch exception " + e.Message.ToString());
            }
            tlog.Debug(tag, $"QuitApplication END");
        }

        [Test]
        [Category("P1")]
        [Description("TizenPlatformServices IsInvokeRequired")]
        [Property("SPEC", "Tizen.NUI.Binding.TizenPlatformServices.IsInvokeRequired M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void IsInvokeRequired()
        {
            tlog.Debug(tag, $"IsInvokeRequired START");

            try
            {
                var testingTarget = new TizenPlatformServices();
                Assert.IsNotNull(testingTarget, "Can't create success object TizenPlatformServices.");

                Assert.True(testingTarget.IsInvokeRequired, "Should be true");
            }
            catch (Exception e)
            {
                Assert.Fail("Catch exception " + e.Message.ToString());
            }
            tlog.Debug(tag, $"IsInvokeRequired END");
        }

        [Test]
        [Category("P1")]
        [Description("TizenPlatformServices RuntimePlatform ")]
        [Property("SPEC", "Tizen.NUI.Binding.TizenPlatformServices.RuntimePlatform  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void RuntimePlatform()
        {
            tlog.Debug(tag, $"RuntimePlatform  START");

            try
            {
                var testingTarget = new TizenPlatformServices();
                Assert.IsNotNull(testingTarget, "Can't create success object TizenPlatformServices.");

                Assert.AreEqual(Device.Tizen, testingTarget.RuntimePlatform, "Should be equal");
            }
            catch (Exception e)
            {
                Assert.Fail("Catch exception " + e.Message.ToString());
            }
            tlog.Debug(tag, $"RuntimePlatform END");
        }
    }
}
