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
        private static TemplateBindingExtension t1;

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            t1 = new TemplateBindingExtension();
        }

        [TearDown]
        public void Destroy()
        {
            t1 = null;
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

            tlog.Debug(tag, $"TemplateBindingExtensionConstructor END (OK)");
            Assert.Pass("TemplateBindingExtensionConstructor");
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
                string tmp = t1.Path;
                t1.Path = tmp;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"TemplateBindingExtensionPath END (OK)");
            Assert.Pass("TemplateBindingExtensionPath");
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
                BindingMode tmp = t1.Mode;
                t1.Mode = tmp;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"TemplateBindingExtensionMode END (OK)");
            Assert.Pass("TemplateBindingExtensionMode");
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
                IValueConverter tmp = t1.Converter;
                t1.Converter = tmp;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"TemplateBindingExtensionConverter END (OK)");
            Assert.Pass("TemplateBindingExtensionConverter");
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
                object tmp = t1.ConverterParameter;
                t1.ConverterParameter = tmp;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"TemplateBindingExtensionConverterParameter END (OK)");
            Assert.Pass("TemplateBindingExtensionConverterParameter");
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
                string tmp = t1.StringFormat;
                t1.StringFormat = tmp;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"TemplateBindingExtensionStringFormat END (OK)");
            Assert.Pass("TemplateBindingExtensionStringFormat");
        }
    }
}