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
        private ApplicationResourcePathExtension a1;

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            a1 = new ApplicationResourcePathExtension();
        }

        [TearDown]
        public void Destroy()
        {
            a1 = null;
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("ApplicationResourcePathExtension ApplicationResourcePathExtension")]
        [Property("SPEC", "Tizen.NUI.ApplicationResourcePathExtension.ApplicationResourcePathExtension C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void ApplicationResourcePathExtensionConstructor()
        {
            tlog.Debug(tag, $"ApplicationResourcePathExtensionConstructor START");

            ApplicationResourcePathExtension applicationResourcePathExtension = new ApplicationResourcePathExtension();

            tlog.Debug(tag, $"ApplicationResourcePathExtensionConstructor END (OK)");
            Assert.Pass("ApplicationResourcePathExtensionConstructor");
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
                string s1 = a1.FilePath;
                a1.FilePath = s1;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ApplicationResourcePathExtensionFilePath END (OK)");
            Assert.Pass("ApplicationResourcePathExtensionFilePath");
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
        [Description("ApplicationResourcePathExtension ProvideValue ")]
        [Property("SPEC", "Tizen.NUI.ApplicationResourcePathExtension.ProvideValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ApplicationResourcePathExtensionProvideValue()
        {
            tlog.Debug(tag, $"ApplicationResourcePathExtensionProvideValue START");

            try
            {
                IServiceProviderimplement serviceProviderimplement = new IServiceProviderimplement();
                a1.ProvideValue(serviceProviderimplement);
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ApplicationResourcePathExtensionProvideValue END (OK)");
            Assert.Pass("ApplicationResourcePathExtensionProvideValue");
        }
    }
}