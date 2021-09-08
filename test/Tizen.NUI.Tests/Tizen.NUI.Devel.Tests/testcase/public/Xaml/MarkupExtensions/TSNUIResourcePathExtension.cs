using NUnit.Framework;
using System;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/xaml/MarkupExtensions/NUIResourcePathExtension")]
    public class PublicNUIResourcePathExtensionTest
    {
        private const string tag = "NUITEST";
        private NUIResourcePathExtension resPath;

        internal class IServiceProviderImpl : IServiceProvider
        {
            public object GetService(Type serviceType) { return null; }
        }

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            resPath = new NUIResourcePathExtension();
        }

        [TearDown]
        public void Destroy()
        {
            resPath = null;
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("NUIResourcePathExtension FilePath")]
        [Property("SPEC", "Tizen.NUI.NUIResourcePathExtension.FilePath A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void NUIResourcePathExtensionFilePath()
        {
            tlog.Debug(tag, $"NUIResourcePathExtensionFilePath START");

            try
            {
                string tmp = resPath.FilePath;
                resPath.FilePath = tmp;
                Assert.AreEqual(tmp, resPath.FilePath, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"NUIResourcePathExtensionFilePath END");
        }

        [Test]
        [Category("P1")]
        [Description("NUIResourcePathExtension ProvideValue")]
        [Property("SPEC", "Tizen.NUI.NUIResourcePathExtension.ProvideValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void NUIResourcePathExtensionProvideValue()
        {
            tlog.Debug(tag, $"NUIResourcePathExtensionProvideValue START");

            try
            {
                resPath.ProvideValue(new IServiceProviderImpl());
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"NUIResourcePathExtensionProvideValue END");
        }
    }
}