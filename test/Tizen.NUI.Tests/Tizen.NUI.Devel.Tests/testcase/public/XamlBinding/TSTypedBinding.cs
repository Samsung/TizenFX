using NUnit.Framework;
using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/XamlBinding/TypedBinding")]
    internal class PublicTypedBindingTest
    {
        private const string tag = "NUITEST";

        internal class MyTypedBindingBase : TypedBindingBase
        {
            internal override BindingBase Clone()
            {
                return null;
            }
        }

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
        [Description("TypedBindingBase Converter")]
        [Property("SPEC", "Tizen.NUI.Binding.TypedBindingBase.Converter A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ConverterTest()
        {
            tlog.Debug(tag, $"ConverterTest START");
            MyTypedBindingBase mt = new MyTypedBindingBase();
            Assert.IsNotNull(mt, "null Binding");
            var ret = mt.Converter;
            mt.Converter = ret;
            Assert.AreEqual(ret, mt.Converter, "Should be equal");

            tlog.Debug(tag, $"ConverterTest END");
        }

        [Test]
        [Category("P1")]
        [Description("TypedBindingBase ConverterParameter")]
        [Property("SPEC", "Tizen.NUI.Binding.TypedBindingBase.ConverterParameter A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ConverterParameterTest()
        {
            tlog.Debug(tag, $"ConverterParameterTest START");
            MyTypedBindingBase mt = new MyTypedBindingBase();
            Assert.IsNotNull(mt, "null Binding");
            var ret = mt.ConverterParameter;
            mt.ConverterParameter = ret;
            Assert.AreEqual(ret, mt.ConverterParameter, "Should be equal");

            tlog.Debug(tag, $"ConverterParameterTest END");
        }

        [Test]
        [Category("P1")]
        [Description("TypedBindingBase Source")]
        [Property("SPEC", "Tizen.NUI.Binding.TypedBindingBase.Source A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void SourceTest()
        {
            tlog.Debug(tag, $"SourceTest START");
            MyTypedBindingBase mt = new MyTypedBindingBase();
            Assert.IsNotNull(mt, "null Binding");
            var ret = mt.Source;
            mt.Source = ret;
            Assert.AreEqual(ret, mt.Source, "Should be equal");

            tlog.Debug(tag, $"SourceTest END");
        }

        [Test]
        [Category("P1")]
        [Description("TypedBindingBase UpdateSourceEventName")]
        [Property("SPEC", "Tizen.NUI.Binding.TypedBindingBase.UpdateSourceEventName A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void UpdateSourceEventNameTest()
        {
            tlog.Debug(tag, $"UpdateSourceEventNameTest START");
            MyTypedBindingBase mt = new MyTypedBindingBase();
            Assert.IsNotNull(mt, "null Binding");
            var ret = mt.UpdateSourceEventName;
            mt.UpdateSourceEventName = ret;
            Assert.AreEqual(ret, mt.UpdateSourceEventName, "Should be equal");

            tlog.Debug(tag, $"UpdateSourceEventNameTest END");
        }

        [Test]
        [Category("P1")]
        [Description("TypedBinding<TSource, TProperty> TypedBinding<TSource, TProperty>")]
        [Property("SPEC", "Tizen.NUI.Binding.TypedBinding<TSource, TProperty>.TypedBinding<TSource, TProperty> C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void TypedBindingConstructor()
        {
            tlog.Debug(tag, $"TypedBindingConstructor START");
            Func<View, FocusEffect> getter = (v) => new FocusEffect();
            var mt = new TypedBinding<View, FocusEffect>(getter, null,  null);
            Assert.IsNotNull(mt, "null TypedBinding");
            Assert.IsInstanceOf<TypedBinding<View, FocusEffect>>(mt, "Should return TypedBinding instance.");
            tlog.Debug(tag, $"TypedBindingConstructor END");
        }

        [Test]
        [Category("P2")]
        [Description("TypedBinding<TSource, TProperty> TypedBinding<TSource, TProperty>")]
        [Property("SPEC", "Tizen.NUI.Binding.TypedBinding<TSource, TProperty>.TypedBinding<TSource, TProperty> C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void TypedBindingConstructor2()
        {
            tlog.Debug(tag, $"TypedBindingConstructor2 START");
            Assert.Throws<ArgumentNullException>(() => new TypedBinding<View, FocusEffect>(null, null, null));
            tlog.Debug(tag, $"TypedBindingConstructor2 END");
        }

        [Test]
        [Category("P1")]
        [Description("TypedBinding<TSource, TProperty> Apply")]
        [Property("SPEC", "Tizen.NUI.Binding.TypedBinding<TSource, TProperty>.Apply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void ApplyTest()
        {
            tlog.Debug(tag, $"ApplyTest START");
            try
            {
                Func<View, FocusEffect> getter = (v) => new FocusEffect();
                var mt = new TypedBinding<View, FocusEffect>(getter, null, null);
                Assert.IsNotNull(mt, "null TypedBinding");

                mt.Apply();
            }
            catch (InvalidOperationException e)
            {
                Assert.True(true, "Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"ApplyTest END");
        }

        [Test]
        [Category("P1")]
        [Description("TypedBinding<TSource, TProperty> Apply")]
        [Property("SPEC", "Tizen.NUI.Binding.TypedBinding<TSource, TProperty>.Apply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void ApplyTest2()
        {
            tlog.Debug(tag, $"ApplyTest2 START");
            try
            {
                Func<View, FocusEffect> getter = (v) => new FocusEffect();
                var mt = new TypedBinding<View, FocusEffect>(getter, null, null);
                Assert.IsNotNull(mt, "null TypedBinding");

                mt.Apply(null, new View(), View.FocusableProperty);
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"ApplyTest2 END");
        }

        [Test]
        [Category("P1")]
        [Description("TypedBinding<TSource, TProperty> Clone")]
        [Property("SPEC", "Tizen.NUI.Binding.TypedBinding<TSource, TProperty>.Clone M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void CloneTest()
        {
            tlog.Debug(tag, $"CloneTest START");
            try
            {
                Func<View, FocusEffect> getter = (v) => new FocusEffect();
                var mt = new TypedBinding<View, FocusEffect>(getter, null, null);
                Assert.IsNotNull(mt, "null TypedBinding");

                var ret = mt.Clone();
                Assert.IsNotNull(mt, "null TypedBinding");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"CloneTest END");
        }

        [Test]
        [Category("P1")]
        [Description("TypedBinding<TSource, TProperty> GetSourceValue")]
        [Property("SPEC", "Tizen.NUI.Binding.TypedBinding<TSource, TProperty>.GetSourceValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void GetSourceValueTest()
        {
            tlog.Debug(tag, $"GetSourceValueTest START");
            try
            {
                Func<View, FocusEffect> getter = (v) => new FocusEffect();
                var mt = new TypedBinding<View, FocusEffect>(getter, null, null);
                Assert.IsNotNull(mt, "null TypedBinding");

                var ret = mt.GetSourceValue(new View(), typeof(bool));
                Assert.IsNotNull(mt, "null TypedBinding");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"GetSourceValueTest END");
        }

        [Test]
        [Category("P1")]
        [Description("TypedBinding<TSource, TProperty> GetTargetValue")]
        [Property("SPEC", "Tizen.NUI.Binding.TypedBinding<TSource, TProperty>.GetTargetValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void GetTargetValueTest()
        {
            tlog.Debug(tag, $"GetTargetValueTest START");
            try
            {
                Func<View, FocusEffect> getter = (v) => new FocusEffect();
                var mt = new TypedBinding<View, FocusEffect>(getter, null, null);
                Assert.IsNotNull(mt, "null TypedBinding");

                var ret = mt.GetTargetValue(new View(), typeof(bool));
                Assert.IsNotNull(mt, "null TypedBinding");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"GetTargetValueTest END");
        }

        [Test]
        [Category("P1")]
        [Description("TypedBinding<TSource, TProperty> Unapply")]
        [Property("SPEC", "Tizen.NUI.Binding.TypedBinding<TSource, TProperty>.Unapply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void UnapplyTest()
        {
            tlog.Debug(tag, $"UnapplyTest START");
            try
            {
                Func<View, FocusEffect> getter = (v) => new FocusEffect();
                var mt = new TypedBinding<View, FocusEffect>(getter, null, null);
                Assert.IsNotNull(mt, "null TypedBinding");

                mt.Unapply();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"UnapplyTest END");
        }

        [Test]
        [Category("P1")]
        [Description("TypedBinding<TSource, TProperty> ApplyCore")]
        [Property("SPEC", "Tizen.NUI.Binding.TypedBinding<TSource, TProperty>.ApplyCore M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void ApplyCoreTest()
        {
            tlog.Debug(tag, $"ApplyCoreTest START");
            try
            {
                Func<View, FocusEffect> getter = (v) => new FocusEffect();
                var mt = new TypedBinding<View, FocusEffect>(getter, null, null);
                Assert.IsNotNull(mt, "null TypedBinding");

                mt.ApplyCore(new View(), new View(), View.FocusableProperty);
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"ApplyCoreTest END");
        }

    }
}