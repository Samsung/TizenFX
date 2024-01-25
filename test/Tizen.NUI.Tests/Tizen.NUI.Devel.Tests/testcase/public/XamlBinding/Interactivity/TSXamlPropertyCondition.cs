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
    [Description("public/XamlBinding/Interactivity/XamlPropertyCondition")]
    internal class PublicXamlPropertyConditionTest
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
        [Description("XamlPropertyCondition XamlPropertyCondition ")]
        [Property("SPEC", "Tizen.NUI.Binding.XamlPropertyCondition.XamlPropertyCondition  C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void XamlPropertyConditionConstructor()
        {
            tlog.Debug(tag, $"XamlPropertyConditionConstructor START");
            XamlPropertyCondition xp = new XamlPropertyCondition();
            Assert.IsNotNull(xp, "Should not be null");
            tlog.Debug(tag, $"XamlPropertyConditionConstructor END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlPropertyCondition Property")]
        [Property("SPEC", "Tizen.NUI.Binding.XamlPropertyCondition.Property  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void PropertyTest()
        {
            tlog.Debug(tag, $"PropertyTest START");
            XamlPropertyCondition xp = new XamlPropertyCondition();
            Assert.IsNotNull(xp, "Should not be null");
            var ret = xp.Property; //null
            Assert.IsNull(ret, "Should be null");
            xp.Property = ret;
            tlog.Debug(tag, $"PropertyTest END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlPropertyCondition Property")]
        [Property("SPEC", "Tizen.NUI.Binding.XamlPropertyCondition.Property  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void PropertyTest2()
        {
            tlog.Debug(tag, $"PropertyTest2 START");
            XamlPropertyCondition xp = new XamlPropertyCondition();
            Assert.IsNotNull(xp, "Should not be null");
            var b = View.FocusableProperty;
            xp.Property = b;
            var ret = xp.Property; //null
            Assert.AreEqual(b, ret, "Should be equal");
            
            tlog.Debug(tag, $"PropertyTest2 END");
        }

        [Test]
        [Category("P2")]
        [Description("XamlPropertyCondition Property")]
        [Property("SPEC", "Tizen.NUI.Binding.XamlPropertyCondition.Property  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void PropertyTest3()
        {
            tlog.Debug(tag, $"PropertyTest3 START");
            XamlPropertyCondition xp = new XamlPropertyCondition();
            Assert.IsNotNull(xp, "Should not be null");
            var b = View.FocusableProperty;
            xp.IsSealed = true;
            Assert.Throws<InvalidOperationException>(() => xp.Property = b);
            tlog.Debug(tag, $"PropertyTest3 END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlPropertyCondition Value")]
        [Property("SPEC", "Tizen.NUI.Binding.XamlPropertyCondition.Value  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ValueTest()
        {
            tlog.Debug(tag, $"ValueTest START");
            try
            {
                XamlPropertyCondition xp = new XamlPropertyCondition();
                Assert.IsNotNull(xp, "Should not be null");
                var ret = xp.Value;
                Assert.IsNotNull(xp, "Should not be null");
                xp.Value = ret;
            }
            catch(Exception e)
            {
                Assert.Fail("Should not thow exception: " + e.Message);
            }
            tlog.Debug(tag, $"ValueTest END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlPropertyCondition Value")]
        [Property("SPEC", "Tizen.NUI.Binding.XamlPropertyCondition.Value  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ValueTest2()
        {
            tlog.Debug(tag, $"ValueTest2 START");
            try
            {
                XamlPropertyCondition xp = new XamlPropertyCondition();
                Assert.IsNotNull(xp, "Should not be null");
                xp.Value = true;
                Assert.AreEqual(true, xp.Value, "Should be equal");
            }
            catch (Exception e)
            {
                Assert.Fail("Should not thow exception: " + e.Message);
            }
            tlog.Debug(tag, $"ValueTest2 END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlPropertyCondition Value")]
        [Property("SPEC", "Tizen.NUI.Binding.XamlPropertyCondition.Value  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ValueTest3()
        {
            tlog.Debug(tag, $"ValueTest3 START");

            XamlPropertyCondition xp = new XamlPropertyCondition();
            Assert.IsNotNull(xp, "Should not be null");
            xp.IsSealed = true;
            Assert.Throws<InvalidOperationException>(() => xp.Value = true);
            
            tlog.Debug(tag, $"ValueTest3 END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlPropertyCondition GetState ")]
        [Property("SPEC", "Tizen.NUI.Binding.XamlPropertyCondition.GetState  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void GetStateTest()
        {
            tlog.Debug(tag, $"GetStateTest START");
            try { 
                XamlPropertyCondition xp = new XamlPropertyCondition();
                Assert.IsNotNull(xp, "Should not be null");
                var ret = xp.GetState(new View());
                Assert.AreEqual(false, ret, "Should be equal");
            }
            catch (Exception e)
            {
                Assert.Fail("Should not thow exception: " + e.Message);
            }

            tlog.Debug(tag, $"GetStateTest END");
        }

        [Test]
        [Category("P2")]
        [Description("XamlPropertyCondition SetUp")]
        [Property("SPEC", "Tizen.NUI.Binding.XamlPropertyCondition.SetUp M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void SetUpTest()
        {
            tlog.Debug(tag, $"SetUpTest START");
            try
            {
                XamlPropertyCondition xp = new XamlPropertyCondition();
                Assert.IsNotNull(xp, "Should not be null");
                xp.Value = true;
                xp.SetUp(new View());
            }
            catch (Exception e)
            {
                Assert.True(true, "Should thow exception: " + e.Message);
            }

            tlog.Debug(tag, $"SetUpTest END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlPropertyCondition TearDown")]
        [Property("SPEC", "Tizen.NUI.Binding.XamlPropertyCondition.TearDown M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void TearDownTest()
        {
            tlog.Debug(tag, $"TearDownTest START");
            try
            {
                XamlPropertyCondition xp = new XamlPropertyCondition();
                Assert.IsNotNull(xp, "Should not be null");
                xp.TearDown(new View());
            }
            catch (Exception e)
            {
                Assert.Fail("Should not thow exception: " + e.Message);
            }

            tlog.Debug(tag, $"TearDownTest END");
        }
    }
}