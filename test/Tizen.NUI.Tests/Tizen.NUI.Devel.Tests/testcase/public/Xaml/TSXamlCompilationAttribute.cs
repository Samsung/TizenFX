using NUnit.Framework;
using System;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/xaml/XamlCompilationAttribute")]
    public class PublicXamlCompilationAttributeTest
    {
        private const string tag = "NUITEST";
        private XamlCompilationAttribute compilationAttr;
        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            compilationAttr = new XamlCompilationAttribute(new XamlCompilationOptions());
        }

        [TearDown]
        public void Destroy()
        {
            compilationAttr = null;
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

            var testingTarget = new XamlCompilationAttribute(xamlCompilationOptions);
            Assert.IsNotNull(testingTarget, "null XamlCompilationAttribute");
            Assert.IsInstanceOf<XamlCompilationAttribute>(testingTarget, "Should return XamlCompilationAttribute instance.");

            testingTarget = null;
            tlog.Debug(tag, $"XamlCompilationAttributeConstructor END (OK)");
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
                XamlCompilationOptions option = compilationAttr.XamlCompilationOptions;
                compilationAttr.XamlCompilationOptions = option;
                Assert.AreEqual(option, compilationAttr.XamlCompilationOptions, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"XamlCompilationAttributeXamlCompilationOptions END");
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
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"XamlCExtensionsIsCompiled END");
        }
    }
}