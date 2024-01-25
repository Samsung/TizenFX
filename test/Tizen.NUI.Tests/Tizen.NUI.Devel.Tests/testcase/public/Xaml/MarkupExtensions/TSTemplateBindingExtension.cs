using NUnit.Framework;
using System;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/xaml/MarkupExtensions/TemplateBindingExtension")]
    public class PublicTemplateBindingExtensionTest
    {
        private const string tag = "NUITEST";
        private TemplateBindingExtension tExtension;

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            tExtension = new TemplateBindingExtension();
        }

        [TearDown]
        public void Destroy()
        {
            tExtension = null;
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("TemplateBindingExtension TemplateBindingExtension")]
        [Property("SPEC", "Tizen.NUI.TemplateBindingExtension.TemplateBindingExtension C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void TemplateBindingExtensionConstructor()
        {
            tlog.Debug(tag, $"TemplateBindingExtensionConstructor START");

            TemplateBindingExtension templateBindingExtension = new TemplateBindingExtension();
            Assert.IsNotNull(templateBindingExtension, "null TemplateBindingExtension");
            Assert.IsInstanceOf<TemplateBindingExtension>(templateBindingExtension, "Should return TemplateBindingExtension instance.");

            tlog.Debug(tag, $"TemplateBindingExtensionConstructor END");
        }
		
        [Test]
        [Category("P1")]
        [Description("TemplateBindingExtension Path")]
        [Property("SPEC", "Tizen.NUI.TemplateBindingExtension.Path A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void TemplateBindingExtensionPath()
        {
            tlog.Debug(tag, $"TemplateBindingExtensionPath START");

            try
            {
                var path = tExtension.Path;
                tExtension.Path = path;
                Assert.AreEqual(path, tExtension.Path, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"TemplateBindingExtensionPath END");
        }

        [Test]
        [Category("P1")]
        [Description("TemplateBindingExtension Mode")]
        [Property("SPEC", "Tizen.NUI.TemplateBindingExtension.Mode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void TemplateBindingExtensionMode()
        {
            tlog.Debug(tag, $"TemplateBindingExtensionMode START");

            try
            {
                var mode = tExtension.Mode;
                tExtension.Mode = mode;
                Assert.AreEqual(mode, tExtension.Mode, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"TemplateBindingExtensionMode END");
        }

        [Test]
        [Category("P1")]
        [Description("TemplateBindingExtension Converter")]
        [Property("SPEC", "Tizen.NUI.TemplateBindingExtension.Converter A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void TemplateBindingExtensionConverter()
        {
            tlog.Debug(tag, $"TemplateBindingExtensionConverter START");

            try
            {
                var converter = tExtension.Converter;
                tExtension.Converter = converter;
                Assert.AreEqual(converter, tExtension.Converter, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"TemplateBindingExtensionConverter END");
        }

        [Test]
        [Category("P1")]
        [Description("TemplateBindingExtension ConverterParameter")]
        [Property("SPEC", "Tizen.NUI.TemplateBindingExtension.ConverterParameter A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void TemplateBindingExtensionConverterParameter()
        {
            tlog.Debug(tag, $"TemplateBindingExtensionConverterParameter START");

            try
            {
                var param = tExtension.ConverterParameter;
                tExtension.ConverterParameter = param;
                Assert.AreEqual(param, tExtension.ConverterParameter, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"TemplateBindingExtensionConverterParameter END");
        }

        [Test]
        [Category("P1")]
        [Description("TemplateBindingExtension StringFormat")]
        [Property("SPEC", "Tizen.NUI.TemplateBindingExtension.StringFormat A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void TemplateBindingExtensionStringFormat()
        {
            tlog.Debug(tag, $"TemplateBindingExtensionStringFormat START");

            try
            {
                var format = tExtension.StringFormat;
                tExtension.StringFormat = format;
                Assert.AreEqual(format, tExtension.StringFormat, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"TemplateBindingExtensionStringFormat END");
        }
    }
}