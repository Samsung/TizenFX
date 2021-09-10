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
    [Description("public/XamlBinding/Interactivity/DataTrigger")]
    internal class PublicDataTriggerTest
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
        [Description("DataTrigger DataTrigger ")]
        [Property("SPEC", "Tizen.NUI.Binding.DataTrigger.DataTrigger  C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void DataTriggerConstructor()
        {
            tlog.Debug(tag, $"DataTriggerConstructor START");
            DataTrigger dt = new DataTrigger(typeof(View));
            Assert.IsNotNull(dt, "Should not be null");
            tlog.Debug(tag, $"DataTriggerConstructor END");
        }

        [Test]
        [Category("P1")]
        [Description("DataTrigger Binding")]
        [Property("SPEC", "Tizen.NUI.Binding.DataTrigger.Binding  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void BindingTest()
        {
            tlog.Debug(tag, $"BindingTest START");
            DataTrigger dt = new DataTrigger(typeof(View));
            Assert.IsNotNull(dt, "Should not be null");
            var ret = dt.Binding; //null
            Assert.IsNull(ret, "Should be null");
            dt.Binding = ret;
            tlog.Debug(tag, $"BindingTest END");
        }

        [Test]
        [Category("P1")]
        [Description("DataTrigger Binding")]
        [Property("SPEC", "Tizen.NUI.Binding.DataTrigger.Binding  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void BindingTest2()
        {
            tlog.Debug(tag, $"BindingTest2 START");
            DataTrigger dt = new DataTrigger(typeof(View));
            Assert.IsNotNull(dt, "Should not be null");
            var b = new Binding.Binding();
            dt.Binding = b;

            tlog.Debug(tag, $"BindingTest2 END");
        }

        [Test]
        [Category("P1")]
        [Description("DataTrigger Setters")]
        [Property("SPEC", "Tizen.NUI.Binding.DataTrigger.Setters  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        public void SettersTest()
        {
            tlog.Debug(tag, $"SettersTest START");
            DataTrigger dt = new DataTrigger(typeof(View));
            Assert.IsNotNull(dt, "Should not be null");
            var ret = dt.Setters;
            Assert.AreEqual(0, ret.Count, "Should be equal");

            tlog.Debug(tag, $"SettersTest END");
        }

        [Test]
        [Category("P1")]
        [Description("DataTrigger Value")]
        [Property("SPEC", "Tizen.NUI.Binding.DataTrigger.Value  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ValueTest()
        {
            tlog.Debug(tag, $"IsSealedTest2 START");
            DataTrigger dt = new DataTrigger(typeof(View));
            Assert.IsNotNull(dt, "Should not be null");
            var ret = dt.Value;
            dt.Value = ret;
            Assert.AreEqual(ret, dt.Value, "Should be equal");
            dt.Value = 0;
            tlog.Debug(tag, $"IsSealedTest2 END");
        }
    }
}