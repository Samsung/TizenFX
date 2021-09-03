using NUnit.Framework;
using System;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/xaml/MarkupExtensions/ApplicationResourcePathExtension ")]
    public class PublicApplicationResourcePathExtensionTest
    {
        private const string tag = "NUITEST";
        private ApplicationResourcePathExtension path;

        internal class IServiceProviderImpl : IServiceProvider
        {
            public object GetService(Type serviceType) { return null; }
        }

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            path = new ApplicationResourcePathExtension();
        }

        [TearDown]
        public void Destroy()
        {
            path = null;
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("ApplicationResourcePathExtension FilePath ")]
        [Property("SPEC", "Tizen.NUI.ApplicationResourcePathExtension.FilePath A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ApplicationResourcePathExtensionFilePath()
        {
            tlog.Debug(tag, $"ApplicationResourcePathExtensionFilePath START");

            try
            {
                string file = path.FilePath;
                path.FilePath = file;
                Assert.AreEqual(file, path.FilePath, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ApplicationResourcePathExtensionFilePath END");
        }

        [Test]
        [Category("P1")]
        [Description("ApplicationResourcePathExtension ProvideValue ")]
        [Property("SPEC", "Tizen.NUI.ApplicationResourcePathExtension.ProvideValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ApplicationResourcePathExtensionProvideValue()
        {
            tlog.Debug(tag, $"ApplicationResourcePathExtensionProvideValue START");

            try
            {
                path.ProvideValue(new IServiceProviderImpl());
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ApplicationResourcePathExtensionProvideValue END");
        }
    }
}