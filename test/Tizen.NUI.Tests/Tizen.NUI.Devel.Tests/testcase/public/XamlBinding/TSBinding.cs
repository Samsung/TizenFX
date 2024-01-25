using NUnit.Framework;
using System;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/XamlBinding/Binding")]
    internal class PublicBindingTest
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
        [Description("Binding Binding")]
        [Property("SPEC", "Tizen.NUI.Binding.Binding.Binding C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void BindingConstructor()
        {
            tlog.Debug(tag, $"BindingConstructor START");
            Binding.Binding t2 = new Binding.Binding();
            Assert.IsNotNull(t2, "null Binding");
            Assert.IsInstanceOf<Binding.Binding>(t2, "Should return Binding instance.");
            tlog.Debug(tag, $"BindingConstructor END");
        }

        [Test]
        [Category("P2")]
        [Description("Binding Binding")]
        [Property("SPEC", "Tizen.NUI.Binding.Binding.Binding C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "string,BindingMode,IValueConverter,object,string,object")]
        public void BindingConstructor2()
        {
            tlog.Debug(tag, $"BindingConstructor2 START");
            Assert.Throws<ArgumentNullException>(() => new Binding.Binding(null));

            tlog.Debug(tag, $"BindingConstructor2 END");
        }

        [Test]
        [Category("P2")]
        [Description("Binding Binding")]
        [Property("SPEC", "Tizen.NUI.Binding.Binding.Binding C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "string,BindingMode,IValueConverter,object,string,object")]
        public void BindingConstructor3()
        {
            tlog.Debug(tag, $"BindingConstructor3 START");
            Assert.Throws<ArgumentException>(() => new Binding.Binding(""));

            tlog.Debug(tag, $"BindingConstructor3 END");
        }

        [Test]
        [Category("P1")]
        [Description("Binding Binding")]
        [Property("SPEC", "Tizen.NUI.Binding.Binding.Converter A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ConverterTest()
        {
            tlog.Debug(tag, $"ConverterTest START");
            Binding.Binding t2 = new Binding.Binding("Test");
            Assert.IsNotNull(t2, "null Binding");
            Assert.IsInstanceOf<Binding.Binding>(t2, "Should return Binding instance.");
            var ret = t2.Converter;
            Assert.IsNull(ret, "null Converter");

            tlog.Debug(tag, $"ConverterTest END");
        }

        [Test]
        [Category("P1")]
        [Description("Binding ConverterParameter")]
        [Property("SPEC", "Tizen.NUI.Binding.Binding.ConverterParameter A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ConverterParameterTest()
        {
            tlog.Debug(tag, $"ConverterParameterTest START");
            Binding.Binding t2 = new Binding.Binding("Test");
            Assert.IsNotNull(t2, "null Binding");
            Assert.IsInstanceOf<Binding.Binding>(t2, "Should return Binding instance.");

            var ret = t2.ConverterParameter;
            Assert.IsNull(ret, "null ConverterParameter");

            tlog.Debug(tag, $"ConverterParameterTest END");
        }

        [Test]
        [Category("P1")]
        [Description("Binding Path")]
        [Property("SPEC", "Tizen.NUI.Binding.Binding.Path A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void PathTest()
        {
            tlog.Debug(tag, $"PathTest START");
            Binding.Binding t2 = new Binding.Binding("Test");
            Assert.IsNotNull(t2, "null Binding");
            Assert.IsInstanceOf<Binding.Binding>(t2, "Should return Binding instance.");

            var ret = t2.Path;
            Assert.AreEqual("Test", ret, "null Path");

            tlog.Debug(tag, $"PathTest END");
        }

        [Test]
        [Category("P1")]
        [Description("Binding ConverterParameter")]
        [Property("SPEC", "Tizen.NUI.Binding.Binding.Source A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void SourceTest()
        {
            tlog.Debug(tag, $"SourceTest START");
            Binding.Binding t2 = new Binding.Binding("Test");
            Assert.IsNotNull(t2, "null Binding");
            Assert.IsInstanceOf<Binding.Binding>(t2, "Should return Binding instance.");

            var ret = t2.Source;
            Assert.IsNull(ret, "null Source");

            tlog.Debug(tag, $"SourceTest END");
        }

        [Test]
        [Category("P1")]
        [Description("Binding  Apply")]
        [Property("SPEC", "Tizen.NUI.Binding.Binding.Apply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void ApplyTest()
        {
            tlog.Debug(tag, $"ApplyTest START");
            try
            {
                Binding.Binding t2 = new Binding.Binding("Test");
                Assert.IsNotNull(t2, "null Binding");
                t2.Apply(false);
                Assert.True(true, "Should go here"); ;
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"ApplyTest END");
        }

        [Test]
        [Category("P1")]
        [Description("Binding  Apply")]
        [Property("SPEC", "Tizen.NUI.Binding.Binding.Clone M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void CloneTest()
        {
            tlog.Debug(tag, $"CloneTest START");
            try
            {
                Binding.Binding t2 = new Binding.Binding("Test");
                Assert.IsNotNull(t2, "null Binding");
                Binding.Binding c = t2.Clone() as Binding.Binding;
                Assert.IsNotNull(c, "null Binding");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"CloneTest END");
        }
    }
}