using NUnit.Framework;
using System;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/xaml/MarkupExtensions/BindingExtension")]
    public class PublicBindingExtensionTest
    {
        private const string tag = "NUITEST";
        private BindingExtension b1;

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            b1 = new BindingExtension();
        }

        [TearDown]
        public void Destroy()
        {
            b1 = null;
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("BindingExtension BindingExtension")]
        [Property("SPEC", "Tizen.NUI.BindingExtension.BindingExtension C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void BindingExtensionConstructor()
        {
            tlog.Debug(tag, $"BindingExtensionConstructor START");

            BindingExtension binding = new BindingExtension();

            tlog.Debug(tag, $"BindingExtensionConstructor END (OK)");
            Assert.Pass("BindingExtensionConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("BindingExtension Path")]
        [Property("SPEC", "Tizen.NUI.BindingExtension.Path A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void BindingExtensionPath()
        {
            tlog.Debug(tag, $"BindingExtensionPath START");

            try
            {
                string s1 = b1.Path;
                b1.Path = s1;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"BindingExtensionPath END (OK)");
            Assert.Pass("BindingExtensionPath");
        }

        [Test]
        [Category("P1")]
        [Description("BindingExtension Mode")]
        [Property("SPEC", "Tizen.NUI.BindingExtension.Mode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void BindingExtensionMode()
        {
            tlog.Debug(tag, $"BindingExtensionMode START");

            try
            {
                BindingMode tmp = b1.Mode;
                b1.Mode = tmp;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"BindingExtensionMode END (OK)");
            Assert.Pass("BindingExtensionMode");
        }

        [Test]
        [Category("P1")]
        [Description("BindingExtension Converter")]
        [Property("SPEC", "Tizen.NUI.BindingExtension.Converter A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void BindingExtensionConverter()
        {
            tlog.Debug(tag, $"BindingExtensionConverter START");

            try
            {
                IValueConverter tmp = b1.Converter;
                b1.Converter = tmp;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"BindingExtensionConverter END (OK)");
            Assert.Pass("BindingExtensionConverter");
        }

        [Test]
        [Category("P1")]
        [Description("BindingExtension ConverterParameter")]
        [Property("SPEC", "Tizen.NUI.BindingExtension.ConverterParameter A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void BindingExtensionConverterParameter()
        {
            tlog.Debug(tag, $"BindingExtensionConverterParameter START");

            try
            {
                object tmp = b1.ConverterParameter;
                b1.ConverterParameter = tmp;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"BindingExtensionConverterParameter END (OK)");
            Assert.Pass("BindingExtensionConverterParameter");
        }

        [Test]
        [Category("P1")]
        [Description("BindingExtension StringFormat")]
        [Property("SPEC", "Tizen.NUI.BindingExtension.StringFormat A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void BindingExtensionStringFormat()
        {
            tlog.Debug(tag, $"BindingExtensionStringFormat START");

            try
            {
                string tmp = b1.StringFormat;
                b1.StringFormat = tmp;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"BindingExtensionStringFormat END (OK)");
            Assert.Pass("BindingExtensionStringFormat");
        }

        [Test]
        [Category("P1")]
        [Description("BindingExtension Source")]
        [Property("SPEC", "Tizen.NUI.BindingExtension.Source A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void BindingExtensionSource()
        {
            tlog.Debug(tag, $"BindingExtensionSource START");

            try
            {
                object tmp = b1.Source;
                b1.Source = tmp;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"BindingExtensionSource END (OK)");
            Assert.Pass("BindingExtensionSource");
        }

        [Test]
        [Category("P1")]
        [Description("BindingExtension UpdateSourceEventName")]
        [Property("SPEC", "Tizen.NUI.BindingExtension.UpdateSourceEventName A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void BindingExtensionUpdateSourceEventName()
        {
            tlog.Debug(tag, $"BindingExtensionUpdateSourceEventName START");

            try
            {
                string tmp = b1.UpdateSourceEventName;
                b1.UpdateSourceEventName = tmp;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"BindingExtensionUpdateSourceEventName END (OK)");
            Assert.Pass("BindingExtensionUpdateSourceEventName");
        }

        [Test]
        [Category("P1")]
        [Description("BindingExtension TargetNullValue")]
        [Property("SPEC", "Tizen.NUI.BindingExtension.TargetNullValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void BindingExtensionTargetNullValue()
        {
            tlog.Debug(tag, $"BindingExtensionTargetNullValue START");

            try
            {
                object tmp = b1.TargetNullValue;
                b1.TargetNullValue = tmp;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"BindingExtensionTargetNullValue END (OK)");
            Assert.Pass("BindingExtensionTargetNullValue");
        }

        [Test]
        [Category("P1")]
        [Description("BindingExtension FallbackValue")]
        [Property("SPEC", "Tizen.NUI.BindingExtension.FallbackValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void BindingExtensionFallbackValue()
        {
            tlog.Debug(tag, $"BindingExtensionFallbackValue START");

            try
            {
                object tmp = b1.FallbackValue;
                b1.FallbackValue = tmp;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"BindingExtensionFallbackValue END (OK)");
            Assert.Pass("BindingExtensionFallbackValue");
        }

        [Test]
        [Category("P1")]
        [Description("BindingExtension TypedBinding")]
        [Property("SPEC", "Tizen.NUI.BindingExtension.TypedBinding A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void BindingExtensionTypedBinding()
        {
            tlog.Debug(tag, $"BindingExtensionTypedBinding START");

            try
            {
                TypedBindingBase tmp = b1.TypedBinding;
                b1.TypedBinding = tmp;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"BindingExtensionTypedBinding END (OK)");
            Assert.Pass("BindingExtensionTypedBinding");
        }
    }
}