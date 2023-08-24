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
        private BindingExtension binding;

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            binding = new BindingExtension();
        }

        [TearDown]
        public void Destroy()
        {
            binding = null;
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
            Assert.IsNotNull(binding, "null BindingExtension");
            Assert.IsInstanceOf<BindingExtension>(binding, "Should return BindingExtension instance.");

            tlog.Debug(tag, $"BindingExtensionConstructor END");
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
                string str = binding.Path;
                binding.Path = str;
                Assert.AreEqual(str, binding.Path, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"BindingExtensionPath END");
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
                var mode = binding.Mode;
                binding.Mode = mode;
                Assert.AreEqual(mode, binding.Mode, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"BindingExtensionMode END");
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
                var converter = binding.Converter;
                binding.Converter = converter;
                Assert.AreEqual(converter, binding.Converter, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"BindingExtensionConverter END");
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
                var param = binding.ConverterParameter;
                binding.ConverterParameter = param;
                Assert.AreEqual(param, binding.ConverterParameter, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"BindingExtensionConverterParameter END");
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
                var format = binding.StringFormat;
                binding.StringFormat = format;
                Assert.AreEqual(format, binding.StringFormat, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"BindingExtensionStringFormat END");
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
                var source = binding.Source;
                binding.Source = source;
                Assert.AreEqual(source, binding.Source, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"BindingExtensionSource END");
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
                var name = binding.UpdateSourceEventName;
                binding.UpdateSourceEventName = name;
                Assert.AreEqual(name, binding.UpdateSourceEventName, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"BindingExtensionUpdateSourceEventName END");
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
                var value = binding.TargetNullValue;
                binding.TargetNullValue = value;
                Assert.AreEqual(value, binding.TargetNullValue, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"BindingExtensionTargetNullValue END");
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
                var value = binding.FallbackValue;
                binding.FallbackValue = value;
                Assert.AreEqual(value, binding.FallbackValue, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"BindingExtensionFallbackValue END");
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
                var type = binding.TypedBinding;
                binding.TypedBinding = type;
                Assert.AreEqual(type, binding.TypedBinding, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"BindingExtensionTypedBinding END");
        }
    }
}