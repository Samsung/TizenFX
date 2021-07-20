using NUnit.Framework;
using System;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/xaml/MarkupExtensions/NUIResourcePathExtension")]
    internal class PublicNUIResourcePathExtensionTest
    {
        private const string tag = "NUITEST";
        private static NUIResourcePathExtension n1;

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            n1 = new NUIResourcePathExtension();
        }

        [TearDown]
        public void Destroy()
        {
            n1 = null;
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("NUIResourcePathExtension NUIResourcePathExtension")]
        [Property("SPEC", "Tizen.NUI.NUIResourcePathExtension.NUIResourcePathExtension C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void NUIResourcePathExtensionConstructor()
        {
            tlog.Debug(tag, $"NUIResourcePathExtensionConstructor START");

            NUIResourcePathExtension nUIResourcePathExtension = new NUIResourcePathExtension();

            tlog.Debug(tag, $"NUIResourcePathExtensionConstructor END (OK)");
            Assert.Pass("NUIResourcePathExtensionConstructor");
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
                string tmp = n1.FilePath;
                n1.FilePath = tmp;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"NUIResourcePathExtensionFilePath END (OK)");
            Assert.Pass("NUIResourcePathExtensionFilePath");
        }

        private class IServiceProviderimplement : IServiceProvider
        {
            public object GetService(Type serviceType)
            {
                return null;
            }
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
                IServiceProviderimplement serviceProviderimplement = new IServiceProviderimplement();
                n1.ProvideValue(serviceProviderimplement);
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"NUIResourcePathExtensionProvideValue END (OK)");
            Assert.Pass("NUIResourcePathExtensionProvideValue");
        }
    }
}