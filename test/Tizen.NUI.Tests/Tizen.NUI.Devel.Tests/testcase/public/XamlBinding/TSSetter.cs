using NUnit.Framework;
using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/XamlBinding/Setter")]
    internal class PublicSetterTest
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
        [Description("Setter Setter")]
        [Property("SPEC", "Tizen.NUI.Binding.Setter.Setter C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void SetterConstructor()
        {
            tlog.Debug(tag, $"SetterConstructor START");

            try
            {
                Setter t2 = new Setter();
                Assert.IsNotNull(t2, "null Setter");
                Assert.IsInstanceOf<Setter>(t2, "Should return Setter instance.");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"SetterConstructor END");
        }

        //[Test]
        //[Category("P2")]
        //[Description("Setter Setter")]
        //[Property("SPEC", "Tizen.NUI.Binding.Setter.Setter C")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "CONSTR")]
        //public void SetterConstructor2()
        //{
        //    tlog.Debug(tag, $"SetterConstructor2 START");
        //    Assert.Throws<ArgumentNullException>(() => new Setter());
        //    tlog.Debug(tag, $"SetterConstructor2 END");
        //}

        [Test]
        [Category("P1")]
        [Description("Setter  Property ")]
        [Property("SPEC", "Tizen.NUI.Binding.Setter.Property   A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void PropertyTest1()
        {
            tlog.Debug(tag, $"PropertyTest1 START");
            try
            {
                Setter t2 = new Setter();
                Assert.IsNotNull(t2, "null Setter");
                t2.Property = View.NameProperty;

                Assert.AreEqual(View.NameProperty, t2.Property, "Should be equal");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"PropertyTest1 END");
        }

        [Test]
        [Category("P1")]
        [Description("Setter  Value")]
        [Property("SPEC", "Tizen.NUI.Binding.Setter.Value  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ValueTest1()
        {
            tlog.Debug(tag, $"ValueTest1 START");
            try
            {
                Setter t2 = new Setter();
                Assert.IsNotNull(t2, "null Setter");
                View view = new View();
                t2.Value = view;

                Assert.AreEqual(view, t2.Value, "Should be equal");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"ValueTest1 END");
        }

        [Test]
        [Category("P1")]
        [Description("Setter  Apply")]
        [Property("SPEC", "Tizen.NUI.Binding.Setter.Apply  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void ApplyTest1()
        {
            tlog.Debug(tag, $"ApplyTest1 START");
            try
            {
                Setter t2 = new Setter();
                Assert.IsNotNull(t2, "null Setter");
                View view = new View();
                t2.Apply(view);
                t2.UnApply(view);
                t2.Property = View.NameProperty;
                t2.Apply(view);
                t2.UnApply(view);
                view.Name = "View1";
                t2.Apply(view);
                t2.UnApply(view);
                Assert.True(true, "Should go here");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"ApplyTest1 END");
        }

        [Test]
        [Category("P2")]
        [Description("Setter  Apply")]
        [Property("SPEC", "Tizen.NUI.Binding.Setter.Apply  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void ApplyTest2()
        {
            tlog.Debug(tag, $"ApplyTest2 START");
            Setter t2 = new Setter();
            Assert.IsNotNull(t2, "null Setter");
            Assert.Throws<ArgumentNullException>(() => t2.Apply(null));
            Assert.Throws<ArgumentNullException>(() => t2.UnApply(null));
            tlog.Debug(tag, $"ApplyTest2 END");
        }
    }
}