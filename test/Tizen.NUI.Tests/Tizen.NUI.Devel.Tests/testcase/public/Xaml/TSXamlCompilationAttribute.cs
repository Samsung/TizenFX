using NUnit.Framework;
using System;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/xaml/XamlCompilationAttribute")]
    internal class PublicXamlCompilationAttributeTest
    {
        private const string tag = "NUITEST";
        private static XamlCompilationAttribute x1;
        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            XamlCompilationOptions xamlCompilationOptions = new XamlCompilationOptions();

            x1 = new XamlCompilationAttribute(xamlCompilationOptions);
        }

        [TearDown]
        public void Destroy()
        {
            x1 = null;
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("XamlCompilationAttribute XamlCompilationAttribute")]
        [Property("SPEC", "Tizen.NUI.XamlCompilationAttribute.XamlCompilationAttribute C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void XamlCompilationAttributeConstructor()
        {
            tlog.Debug(tag, $"XamlCompilationAttributeConstructor START");

            XamlCompilationOptions xamlCompilationOptions = new XamlCompilationOptions();

            XamlCompilationAttribute x2 = new XamlCompilationAttribute(xamlCompilationOptions);

            x2 = null;
            tlog.Debug(tag, $"XamlCompilationAttributeConstructor END (OK)");
            Assert.Pass("XamlCompilationAttributeConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("XamlCompilationAttribute XamlCompilationOptions ")]
        [Property("SPEC", "Tizen.NUI.XamlCompilationAttribute.XamlCompilationOptions  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void XamlCompilationAttributeXamlCompilationOptions()
        {
            tlog.Debug(tag, $"XamlCompilationAttributeXamlCompilationOptions START");
            try
            {
                XamlCompilationOptions option = x1.XamlCompilationOptions;
                x1.XamlCompilationOptions = option;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"XamlCompilationAttributeXamlCompilationOptions END (OK)");
            Assert.Pass("XamlCompilationAttributeXamlCompilationOptions");
        }

        [Test]
        [Category("P1")]
        [Description("XamlCExtensions IsCompiled ")]
        [Property("SPEC", "Tizen.NUI.XamlCExtensions.IsCompiled M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void XamlCompilationAttributeIsCompiled()
        {
            tlog.Debug(tag, $"XamlCExtensionsIsCompiled START");
            try
            {
                Tizen.NUI.Xaml.XamlCExtensions.IsCompiled(typeof(string));
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"XamlCExtensionsIsCompiled END (OK)");
            Assert.Pass("XamlCExtensionsIsCompiled");
        }
    }
}