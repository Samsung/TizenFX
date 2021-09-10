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
    [Description("public/XamlBinding/Interactivity/EventTrigger")]
    internal class PublicEventTriggerTest
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
        [Description("EventTrigger EventTrigger ")]
        [Property("SPEC", "Tizen.NUI.Binding.EventTrigger.EventTrigger  C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void EventTriggerConstructor()
        {
            tlog.Debug(tag, $"EventTriggerConstructor START");
            EventTrigger dt = new EventTrigger();
            Assert.IsNotNull(dt, "Should not be null");
            tlog.Debug(tag, $"EventTriggerConstructor END");
        }

        [Test]
        [Category("P1")]
        [Description("EventTrigger Actions")]
        [Property("SPEC", "Tizen.NUI.Binding.EventTrigger.Actions  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        public void ActionsTest()
        {
            tlog.Debug(tag, $"ActionsTest START");
            EventTrigger dt = new EventTrigger();
            Assert.IsNotNull(dt, "Should not be null");
            var ret = dt.Actions;
            Assert.AreEqual(0, ret.Count, "Should be equal");

            tlog.Debug(tag, $"ActionsTest END");
        }

        [Test]
        [Category("P1")]
        [Description("EventTrigger Event")]
        [Property("SPEC", "Tizen.NUI.Binding.EventTrigger.Event  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void EventTest()
        {
            tlog.Debug(tag, $"EventTest START");
            EventTrigger dt = new EventTrigger();
            Assert.IsNotNull(dt, "Should not be null");
            var ret = dt.Event; //null
            Assert.IsNull(ret, "Should be null");
            dt.Event = ret;
            tlog.Debug(tag, $"EventTest END");
        }

        [Test]
        [Category("P1")]
        [Description("EventTrigger Event")]
        [Property("SPEC", "Tizen.NUI.Binding.EventTrigger.Event  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void EventTest2()
        {
            tlog.Debug(tag, $"BindingTest2 START");
            EventTrigger dt = new EventTrigger();
            Assert.IsNotNull(dt, "Should not be null");
            var b = "Clicked";
            dt.Event = b;

            tlog.Debug(tag, $"BindingTest2 END");
        }


        [Test]
        [Category("P1")]
        [Description("EventTrigger OnAttachedTo")]
        [Property("SPEC", "Tizen.NUI.Binding.EventTrigger.OnAttachedTo  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void OnAttachedToTest()
        {
            tlog.Debug(tag, $"OnAttachedToTest START");
            try
            {
                EventTrigger dt = new EventTrigger();
                Assert.IsNotNull(dt, "Should not be null");
                dt.OnAttachedTo(new View());
            }
            catch (Exception e)
            {
                Assert.Fail("Should not thow exception: " + e.Message);
            }
            tlog.Debug(tag, $"OnAttachedToTest END");
        }

        [Test]
        [Category("P1")]
        [Description("EventTrigger OnDetachingFrom")]
        [Property("SPEC", "Tizen.NUI.Binding.EventTrigger.OnDetachingFrom  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void OnDetachingFromTest()
        {
            tlog.Debug(tag, $"OnDetachingFromTest START");
            try
            {
                EventTrigger dt = new EventTrigger();
                Assert.IsNotNull(dt, "Should not be null");
                dt.OnDetachingFrom(new View());
            }
            catch (Exception e)
            {
                Assert.Fail("Should not thow exception: " + e.Message);
            }
            tlog.Debug(tag, $"OnDetachingFromTest END");
        }

        [Test]
        [Category("P1")]
        [Description("EventTrigger OnSeal")]
        [Property("SPEC", "Tizen.NUI.Binding.EventTrigger.OnSeal  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void OnSealTest()
        {
            tlog.Debug(tag, $"OnSealTest START");
            try
            {
                EventTrigger dt = new EventTrigger();
                Assert.IsNotNull(dt, "Should not be null");
                dt.OnSeal();
            }
            catch (Exception e)
            {
                Assert.Fail("Should not thow exception: " + e.Message);
            }
            tlog.Debug(tag, $"OnSealTest END");
        }

    }
}