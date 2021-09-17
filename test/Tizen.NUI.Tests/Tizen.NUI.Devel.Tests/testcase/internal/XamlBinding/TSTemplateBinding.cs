using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Reflection;
using System.Collections.Generic;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/XamlBinding/TemplateBinding")]
    public class InternalTemplateBindingTest
    {
        private const string tag = "NUITEST";

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
        }

        [TearDown]
        public void Destroy()
        {
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("TemplateBinding constructor")]
        [Property("SPEC", "Tizen.NUI.Binding.TemplateBinding.TemplateBinding C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void TemplateBindingConstructor()
        {
            tlog.Debug(tag, $"TemplateBindingConstructor START");

            var testingTarget = new TemplateBinding("{Binding template}");
            Assert.IsNotNull(testingTarget, "Can't create success object TemplateBinding.");
            Assert.IsInstanceOf<TemplateBinding>(testingTarget, "Should return TemplateBinding instance.");

            tlog.Debug(tag, $"TemplateBindingConstructor END");
        }

        [Test]
        [Category("P2")]
        [Description("TemplateBinding constructor")]
        [Property("SPEC", "Tizen.NUI.Binding.TemplateBinding.TemplateBinding C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void TemplateBindingConstructor2()
        {
            tlog.Debug(tag, $"TemplateBindingConstructor2 START");

            Assert.Throws<ArgumentNullException>(() => new TemplateBinding(null), "Can't create success object TemplateBinding.");
            Assert.Throws<ArgumentException>(() => new TemplateBinding(""), "Can't create success object TemplateBinding.");

            tlog.Debug(tag, $"TemplateBindingConstructor2 END");
        }

        [Test]
        [Category("P1")]
        [Description("TemplateBinding Converter")]
        [Property("SPEC", "Tizen.NUI.Binding.TemplateBinding.Converter A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void Converter()
        {
            tlog.Debug(tag, $"Converter START");

            var testingTarget = new TemplateBinding("{Binding template}");
            Assert.IsNotNull(testingTarget, "Can't create success object TemplateBinding.");
            var ret = testingTarget.Converter;
            testingTarget.Converter = ret;
            tlog.Debug(tag, $"Converter END");
        }

        [Test]
        [Category("P1")]
        [Description("TemplateBinding ConverterParameter")]
        [Property("SPEC", "Tizen.NUI.Binding.TemplateBinding.ConverterParameter A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ConverterParameter()
        {
            tlog.Debug(tag, $"ConverterParameter START");

            var testingTarget = new TemplateBinding("{Binding template}");
            Assert.IsNotNull(testingTarget, "Can't create success object TemplateBinding.");
            var ret = testingTarget.ConverterParameter;
            testingTarget.ConverterParameter = ret;
            tlog.Debug(tag, $"ConverterParameter END");
        }

        [Test]
        [Category("P1")]
        [Description("TemplateBinding Path")]
        [Property("SPEC", "Tizen.NUI.Binding.TemplateBinding.Path A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void Path()
        {
            tlog.Debug(tag, $"Path START");

            var testingTarget = new TemplateBinding("{Binding template}");
            Assert.IsNotNull(testingTarget, "Can't create success object TemplateBinding.");
            var ret = testingTarget.Path;
            testingTarget.Path = ret;
            tlog.Debug(tag, $"Path END");
        }

        [Test]
        [Category("P1")]
        [Description("TemplateBinding Apply")]
        [Property("SPEC", "Tizen.NUI.Binding.TemplateBinding.Apply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void Apply()
        {
            tlog.Debug(tag, $"Apply START");
            try
            {
                var testingTarget = new TemplateBinding("{Binding template}");
                Assert.IsNotNull(testingTarget, "Can't create success object TemplateBinding.");
                testingTarget.Apply(false);
                testingTarget.Unapply(false);
            }
            catch(Exception e)
            {
                Assert.Fail("Catch exception: " + e.Message.ToString());
            }
            tlog.Debug(tag, $"Apply END");
        }

        [Test]
        [Category("P1")]
        [Description("TemplateBinding Apply")]
        [Property("SPEC", "Tizen.NUI.Binding.TemplateBinding.Apply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void Apply2()
        {
            tlog.Debug(tag, $"Apply2 START");
            try
            {
                var testingTarget = new TemplateBinding("{Binding template}");
                Assert.IsNotNull(testingTarget, "Can't create success object TemplateBinding.");
                testingTarget.Apply(null, new View(), View.FocusableProperty);
            }
            catch (Exception e)
            {
                Assert.Fail("Catch exception: " + e.Message.ToString());
            }
            tlog.Debug(tag, $"Apply2 END");
        }

        [Test]
        [Category("P1")]
        [Description("TemplateBinding Apply")]
        [Property("SPEC", "Tizen.NUI.Binding.TemplateBinding.Apply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void Apply3()
        {
            tlog.Debug(tag, $"Apply3 START");
            try{
                var testingTarget = new TemplateBinding("{Binding template}");
                testingTarget.Apply(null, null, View.FocusableProperty); //InvalidOperationException
            }
            catch(Exception e){
                Assert.Fail("Catch exception: " + e.Message.ToString());
            }
            tlog.Debug(tag, $"Apply3 END");
        }

        [Test]
        [Category("P1")]
        [Description("TemplateBinding Clone")]
        [Property("SPEC", "Tizen.NUI.Binding.TemplateBinding.Clone M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void Clone()
        {
            tlog.Debug(tag, $"Clone START");
            try
            {
                var testingTarget = new TemplateBinding("{Binding template}");
                Assert.IsNotNull(testingTarget, "Can't create success object TemplateBinding.");
                testingTarget.Clone();
            }
            catch (Exception e)
            {
                Assert.Fail("Catch exception: " + e.Message.ToString());
            }
            tlog.Debug(tag, $"Clone END");
        }

        [Test]
        [Category("P1")]
        [Description("TemplateBinding GetSourceValue")]
        [Property("SPEC", "Tizen.NUI.Binding.TemplateBinding.GetSourceValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void GetSourceValue()
        {
            tlog.Debug(tag, $"GetSourceValue START");
            try
            {
                var testingTarget = new TemplateBinding("{Binding template}");
                Assert.IsNotNull(testingTarget, "Can't create success object TemplateBinding.");
                testingTarget.GetSourceValue(null, typeof(bool));
                testingTarget.GetTargetValue(null, typeof(bool));
            }
            catch (Exception e)
            {
                Assert.Fail("Catch exception: " + e.Message.ToString());
            }
            tlog.Debug(tag, $"GetSourceValue END");
        }
    }
}
