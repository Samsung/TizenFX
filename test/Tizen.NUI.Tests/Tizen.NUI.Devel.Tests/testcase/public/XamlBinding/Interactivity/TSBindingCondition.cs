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
    [Description("public/XamlBinding/Interactivity/BindingCondition")]
    internal class PublicBindingConditionTest
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
        [Description("BindingCondition BindingCondition ")]
        [Property("SPEC", "Tizen.NUI.Binding.BindingCondition.BindingCondition  C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void BindingConditionConstructor()
        {
            tlog.Debug(tag, $"BindingConditionConstructor START");
            BindingCondition mb = new BindingCondition();
            Assert.IsNotNull(mb, "Should not be null");
            tlog.Debug(tag, $"BindingConditionConstructor END");
        }

        [Test]
        [Category("P1")]
        [Description("BindingCondition Binding")]
        [Property("SPEC", "Tizen.NUI.Binding.BindingCondition.Binding  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void BindingTest()
        {
            tlog.Debug(tag, $"BindingTest START");
            BindingCondition mb = new BindingCondition();
            Assert.IsNotNull(mb, "Should not be null");
            var ret = mb.Binding; //null
            Assert.IsNull(ret, "Should be null");
            mb.Binding = ret;
            tlog.Debug(tag, $"BindingTest END");
        }

        [Test]
        [Category("P1")]
        [Description("BindingCondition Binding")]
        [Property("SPEC", "Tizen.NUI.Binding.BindingCondition.Binding  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void BindingTest2()
        {
            tlog.Debug(tag, $"BindingTest2 START");
            BindingCondition mb = new BindingCondition();
            Assert.IsNotNull(mb, "Should not be null");
            var b = new Binding.Binding();
            mb.Binding = b;
            var ret = mb.Binding; //null
            Assert.AreEqual(b, ret, "Should be equal");
            
            tlog.Debug(tag, $"BindingTest2 END");
        }

        [Test]
        [Category("P2")]
        [Description("BindingCondition Binding")]
        [Property("SPEC", "Tizen.NUI.Binding.BindingCondition.Binding  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void BindingTest3()
        {
            tlog.Debug(tag, $"BindingTest3 START");
            BindingCondition mb = new BindingCondition();
            Assert.IsNotNull(mb, "Should not be null");
            var b = new Binding.Binding();
            mb.IsSealed = true;
            Assert.Throws<InvalidOperationException>(() => mb.Binding = b);
            tlog.Debug(tag, $"BindingTest3 END");
        }

        [Test]
        [Category("P1")]
        [Description("BindingCondition Value")]
        [Property("SPEC", "Tizen.NUI.Binding.BindingCondition.Value  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ValueTest()
        {
            tlog.Debug(tag, $"ValueTest START");
            try
            {
                BindingCondition mb = new BindingCondition();
                Assert.IsNotNull(mb, "Should not be null");
                var ret = mb.Value;
                Assert.IsNotNull(mb, "Should not be null");
                mb.Value = ret;
            }
            catch(Exception e)
            {
                Assert.Fail("Should not thow exception: " + e.Message);
            }
            tlog.Debug(tag, $"ValueTest END");
        }

        [Test]
        [Category("P1")]
        [Description("BindingCondition Value")]
        [Property("SPEC", "Tizen.NUI.Binding.BindingCondition.Value  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ValueTest2()
        {
            tlog.Debug(tag, $"ValueTest2 START");
            try
            {
                BindingCondition mb = new BindingCondition();
                Assert.IsNotNull(mb, "Should not be null");
                var ret = new View();
                mb.Value = ret;
                Assert.AreEqual(ret, mb.Value, "Should be equal");
            }
            catch (Exception e)
            {
                Assert.Fail("Should not thow exception: " + e.Message);
            }
            tlog.Debug(tag, $"ValueTest2 END");
        }

        [Test]
        [Category("P1")]
        [Description("BindingCondition Value")]
        [Property("SPEC", "Tizen.NUI.Binding.BindingCondition.Value  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ValueTest3()
        {
            tlog.Debug(tag, $"ValueTest3 START");

            BindingCondition mb = new BindingCondition();
            Assert.IsNotNull(mb, "Should not be null");
            var ret = new View();
            mb.IsSealed = true;
            Assert.Throws<InvalidOperationException>(() => mb.Value = ret);
            
            tlog.Debug(tag, $"ValueTest3 END");
        }

        [Test]
        [Category("P1")]
        [Description("BindingCondition GetState ")]
        [Property("SPEC", "Tizen.NUI.Binding.BindingCondition.GetState  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void GetStateTest()
        {
            tlog.Debug(tag, $"GetStateTest START");
            try { 
                BindingCondition mb = new BindingCondition();
                Assert.IsNotNull(mb, "Should not be null");
                var ret = mb.GetState(new View());
                Assert.AreEqual(true, ret, "Should be equal");
                //Assert.Throws<ArgumentNullException>(() => mb.AttachedTo(null));
            }
            catch (Exception e)
            {
                Assert.Fail("Should not thow exception: " + e.Message);
            }

            tlog.Debug(tag, $"GetStateTest END");
        }

        [Test]
        [Category("P1")]
        [Description("BindingCondition SetUp")]
        [Property("SPEC", "Tizen.NUI.Binding.BindingCondition.SetUp M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void SetUpTest()
        {
            tlog.Debug(tag, $"SetUpTest START");
            try
            {
                BindingCondition mb = new BindingCondition();
                Assert.IsNotNull(mb, "Should not be null");
                mb.SetUp(new View());
                //Assert.Throws<ArgumentNullException>(() => mb.AttachedTo(null));
            }
            catch (Exception e)
            {
                Assert.Fail("Should not thow exception: " + e.Message);
            }

            tlog.Debug(tag, $"SetUpTest END");
        }

        [Test]
        [Category("P1")]
        [Description("BindingCondition TearDown")]
        [Property("SPEC", "Tizen.NUI.Binding.BindingCondition.TearDown M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void TearDownTest()
        {
            tlog.Debug(tag, $"TearDownTest START");
            try
            {
                BindingCondition mb = new BindingCondition();
                Assert.IsNotNull(mb, "Should not be null");
                mb.TearDown(new View());
                //Assert.Throws<ArgumentNullException>(() => mb.AttachedTo(null));
            }
            catch (Exception e)
            {
                Assert.Fail("Should not thow exception: " + e.Message);
            }

            tlog.Debug(tag, $"TearDownTest END");
        }
    }
}