using NUnit.Framework;
using System;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/XamlBinding/TypedBinding")]
    internal class PublicTypedBindingTest
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
        [Description("TypedBinding Mode")]
        [Property("SPEC", "Tizen.NUI.Binding.TypedBinding.Mode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ModeTest()
        {
            tlog.Debug(tag, $"ModeTest START");
            Binding.Binding t2 = new Binding.Binding("Test");
            Assert.IsNotNull(t2, "null Binding");
            Assert.IsInstanceOf<Binding.Binding>(t2, "Should return TypedBinding instance.");
            var ret = t2.Mode;
            Assert.AreEqual(BindingMode.Default, ret, "Should be equal");

            tlog.Debug(tag, $"ModeTest END");
        }

        [Test]
        [Category("P1")]
        [Description("TypedBinding StringFormat")]
        [Property("SPEC", "Tizen.NUI.Binding.TypedBinding.StringFormat A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void StringFormatTest()
        {
            tlog.Debug(tag, $"StringFormatTest START");
            Binding.Binding t2 = new Binding.Binding("Test");
            Assert.IsNotNull(t2, "null Binding");
            Assert.IsInstanceOf<Binding.Binding>(t2, "Should return TypedBinding instance.");

            var ret = t2.StringFormat;
            Assert.IsNull(ret, "null StringFormat");

            tlog.Debug(tag, $"StringFormatTest END");
        }

        [Test]
        [Category("P1")]
        [Description("TypedBinding TargetNullValue")]
        [Property("SPEC", "Tizen.NUI.Binding.TypedBinding.TargetNullValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void TargetNullValueTest()
        {
            tlog.Debug(tag, $"TargetNullValueTest START");
            Binding.Binding t2 = new Binding.Binding("Test");
            Assert.IsNotNull(t2, "null Binding");
            Assert.IsInstanceOf<Binding.Binding>(t2, "Should return Binding instance.");

            var ret = t2.TargetNullValue;
            Assert.IsNull(ret, "null TargetNullValue");

            tlog.Debug(tag, $"TargetNullValueTest END");
        }

        [Test]
        [Category("P1")]
        [Description("TypedBinding FallbackValue")]
        [Property("SPEC", "Tizen.NUI.Binding.TypedBinding.FallbackValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void FallbackValueTest()
        {
            tlog.Debug(tag, $"FallbackValueTest START");
            Binding.Binding t2 = new Binding.Binding("Test");
            Assert.IsNotNull(t2, "null Binding");
            Assert.IsInstanceOf<Binding.Binding>(t2, "Should return Binding instance.");

            var ret = t2.FallbackValue;
            Assert.IsNull(ret, "null FallbackValue");

            tlog.Debug(tag, $"FallbackValueTest END");
        }

        [Test]
        [Category("P1")]
        [Description("TypedBinding AllowChaining")]
        [Property("SPEC", "Tizen.NUI.Binding.TypedBinding.AllowChaining  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void AllowChainingTest()
        {
            tlog.Debug(tag, $"AllowChainingTest START");
            try
            {
                Binding.Binding t2 = new Binding.Binding("Test");
                Assert.IsNotNull(t2, "null Binding");
                t2.AllowChaining = true;
                Assert.True(t2.AllowChaining, "Should be true");
                t2.AllowChaining = false;
                Assert.False(t2.AllowChaining, "Should be false"); ;
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"AllowChainingTest END");
        }

        [Test]
        [Category("P1")]
        [Description("TypedBinding Context ")]
        [Property("SPEC", "Tizen.NUI.Binding.TypedBinding.Context   A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ContextTest()
        {
            tlog.Debug(tag, $"ContextTest START");
            try
            {
                Binding.Binding t2 = new Binding.Binding("Test");
                Assert.IsNotNull(t2, "null Binding");
                t2.Context = null;
                Assert.IsNull(t2.Context, "Should go here");
                
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"ContextTest END");
        }

        [Test]
        [Category("P1")]
        [Description("TypedBinding IsApplied ")]
        [Property("SPEC", "Tizen.NUI.Binding.TypedBinding.IsApplied   A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void IsAppliedTest()
        {
            tlog.Debug(tag, $"ContextTest START");
            try
            {
                Binding.Binding t2 = new Binding.Binding("Test");
                Assert.IsNotNull(t2, "null Binding");
                Assert.IsFalse(t2.IsApplied, "Should be false by default");

            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"ContextTest END");
        }

        [Test]
        [Category("P1")]
        [Description("TypedBinding  Apply")]
        [Property("SPEC", "Tizen.NUI.Binding.TypedBinding.Clone M")]
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