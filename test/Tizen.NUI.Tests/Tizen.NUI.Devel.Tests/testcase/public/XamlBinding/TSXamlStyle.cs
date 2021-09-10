using NUnit.Framework;
using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/XamlBinding/XamlStyle")]
    internal class PublicXamlStyleTest
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
        [Description("XamlStyle XamlStyle")]
        [Property("SPEC", "Tizen.NUI.Binding.XamlStyle.XamlStyle C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void XamlStyleConstructor()
        {
            tlog.Debug(tag, $"XamlStyleConstructor START");

            try
            {
                XamlStyle t2 = new XamlStyle(typeof(View));
                Assert.IsNotNull(t2, "null XamlStyle");
                Assert.IsInstanceOf<XamlStyle>(t2, "Should return XamlStyle instance.");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlStyleConstructor END");
        }

        [Test]
        [Category("P2")]
        [Description("XamlStyle XamlStyle")]
        [Property("SPEC", "Tizen.NUI.Binding.XamlStyle.XamlStyle C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void XamlStyleConstructor2()
        {
            tlog.Debug(tag, $"XamlStyleConstructor2 START");
            Assert.Throws<ArgumentNullException>(() => new XamlStyle(null));
            tlog.Debug(tag, $"XamlStyleConstructor2 END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlStyle  ApplyToDerivedTypes  ")]
        [Property("SPEC", "Tizen.NUI.Binding.XamlStyle.ApplyToDerivedTypes    A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ApplyToDerivedTypesTest1()
        {
            tlog.Debug(tag, $"ApplyToDerivedTypesTest1 START");
            try
            {
                XamlStyle t2 = new XamlStyle(typeof(View));
                Assert.IsNotNull(t2, "null XamlStyle");
                t2.ApplyToDerivedTypes = true;
                Assert.AreEqual(true, t2.ApplyToDerivedTypes, "Should be equal");

                t2.ApplyToDerivedTypes = false;
                Assert.AreEqual(false, t2.ApplyToDerivedTypes, "Should be equal");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"ApplyToDerivedTypesTest1 END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlStyle  BasedOn")]
        [Property("SPEC", "Tizen.NUI.Binding.XamlStyle.BasedOn  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void BasedOnTest1()
        {
            tlog.Debug(tag, $"BasedOnTest1 START");
            try
            {
                XamlStyle t1 = new XamlStyle(typeof(View));
                Assert.IsNotNull(t1, "null XamlStyle");
                XamlStyle t2 = new XamlStyle(typeof(ImageView));
                t2.BasedOn = t1;
                Assert.AreEqual(t1, t2.BasedOn, "Should be equal");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"BasedOnTest1 END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlStyle  BaseResourceKey")]
        [Property("SPEC", "Tizen.NUI.Binding.XamlStyle.BaseResourceKey  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void BaseResourceKeyTest1()
        {
            tlog.Debug(tag, $"BaseResourceKeyTest1 START");
            try
            {
                XamlStyle t2 = new XamlStyle(typeof(View));
                Assert.IsNotNull(t2, "null XamlStyle");
                t2.BaseResourceKey = "baseStyle";
                Assert.AreEqual("baseStyle", t2.BaseResourceKey, "Should be equal");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"BaseResourceKeyTest1 END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlStyle  CanCascade ")]
        [Property("SPEC", "Tizen.NUI.Binding.XamlStyle.CanCascade   A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void CanCascadeTest1()
        {
            tlog.Debug(tag, $"CanCascadeTest1 START");
            try
            {
                XamlStyle t2 = new XamlStyle(typeof(View));
                Assert.IsNotNull(t2, "null XamlStyle");
                t2.CanCascade = true;
                Assert.AreEqual(true, t2.CanCascade, "Should be equal");
                t2.CanCascade = false;
                Assert.AreEqual(false, t2.CanCascade, "Should be equal");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"CanCascadeTest1 END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlStyle  Class ")]
        [Property("SPEC", "Tizen.NUI.Binding.XamlStyle.Class   A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ClassTest1()
        {
            tlog.Debug(tag, $"ClassTest1 START");
            try
            {
                XamlStyle t2 = new XamlStyle(typeof(View));
                Assert.IsNotNull(t2, "null XamlStyle");
                t2.Class = "baseStyle";
                Assert.AreEqual("baseStyle", t2.Class, "Should be equal");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"ClassTest1 END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlStyle  Setters")]
        [Property("SPEC", "Tizen.NUI.Binding.XamlStyle.Setters   A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        public void SettersTest1()
        {
            tlog.Debug(tag, $"SettersTest1 START");
            try
            {
                XamlStyle t2 = new XamlStyle(typeof(View));
                Assert.IsNotNull(t2, "null XamlStyle");
                Assert.AreEqual(0, t2.Setters.Count, "Should be equal");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"SettersTest1 END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlStyle  TargetType ")]
        [Property("SPEC", "Tizen.NUI.Binding.XamlStyle.TargetType    A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        public void TargetTypeTest1()
        {
            tlog.Debug(tag, $"TargetTypeTest1 START");
            try
            {
                Type type = typeof(View);
                XamlStyle t2 = new XamlStyle(type);
                Assert.IsNotNull(t2, "null XamlStyle");
                Assert.AreEqual(type, t2.TargetType, "Should be equal");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"TargetTypeTest1 END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlStyle  Apply")]
        [Property("SPEC", "Tizen.NUI.Binding.XamlStyle.Apply   A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void ApplyTest1()
        {
            tlog.Debug(tag, $"ApplyTest1 START");
            try
            {
                View view = new View();
                Assert.IsNotNull(view, "null View");
                var style = view.MergedStyle;
                Assert.IsNotNull(style, "null MergedStyle");
                style.Style = new XamlStyle(typeof(View));
                style.Apply(view);
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"ApplyTest1 END");
        }

        //[Test]
        //[Category("P2")]
        //[Description("XamlStyle  Apply")]
        //[Property("SPEC", "Tizen.NUI.Binding.XamlStyle.Apply  M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MCST")]
        //public void ApplyTest2()
        //{
        //    tlog.Debug(tag, $"ApplyTest2 START");
        //    XamlStyle t2 = new XamlStyle(typeof(View));
        //    Assert.IsNotNull(t2, "null XamlStyle");
        //    Assert.Throws<ArgumentNullException>(() => t2.Apply(null));
        //    Assert.Throws<ArgumentNullException>(() => t2.UnApply(null));
        //    tlog.Debug(tag, $"ApplyTest2 END");
        //}
    }
}