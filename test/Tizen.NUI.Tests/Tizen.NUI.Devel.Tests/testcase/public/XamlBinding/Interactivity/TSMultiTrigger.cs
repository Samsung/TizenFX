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
    [Description("public/XamlBinding/Interactivity/MultiTrigger")]
    internal class PublicMultiTriggerTest
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
        [Description("MultiTrigger MultiTrigger ")]
        [Property("SPEC", "Tizen.NUI.Binding.MultiTrigger.MultiTrigger  C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void MultiTriggerConstructor()
        {
            tlog.Debug(tag, $"MultiTriggerConstructor START");
            MultiTrigger dt = new MultiTrigger(typeof(View));
            Assert.IsNotNull(dt, "Should not be null");
            tlog.Debug(tag, $"MultiTriggerConstructor END");
        }

        [Test]
        [Category("P1")]
        [Description("MultiTrigger Conditions")]
        [Property("SPEC", "Tizen.NUI.Binding.MultiTrigger.Conditions  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        public void ConditionsTest()
        {
            tlog.Debug(tag, $"ConditionsTest START");
            MultiTrigger dt = new MultiTrigger(typeof(View));
            Assert.IsNotNull(dt, "Should not be null");
            var ret = dt.Conditions;
            Assert.AreEqual(0, ret.Count, "Should be equal");

            tlog.Debug(tag, $"ConditionsTest END");
        }

        [Test]
        [Category("P1")]
        [Description("MultiTrigger Setters")]
        [Property("SPEC", "Tizen.NUI.Binding.MultiTrigger.Setters  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        public void SettersTest()
        {
            tlog.Debug(tag, $"SettersTest START");
            MultiTrigger dt = new MultiTrigger(typeof(View));
            Assert.IsNotNull(dt, "Should not be null");
            var ret = dt.Setters; //null
            Assert.AreEqual(0, ret.Count, "Should be equal");
            tlog.Debug(tag, $"SettersTest END");
        }

    }
}