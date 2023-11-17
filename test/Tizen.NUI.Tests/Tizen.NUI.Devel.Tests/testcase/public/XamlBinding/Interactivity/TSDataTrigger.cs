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

#pragma warning disable Reflection // The code contains reflection
            DataTrigger dt = new DataTrigger(typeof(View));
#pragma warning restore Reflection // The code contains reflection
            Assert.IsNotNull(dt, "Should not be null");
            
            tlog.Debug(tag, $"DataTriggerConstructor END");
        }

        [Test]
        [Category("P1")]
        [Description("DataTrigger Binding")]
        [Property("SPEC", "Tizen.NUI.Binding.DataTrigger.Binding  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void DataTriggerBindingWithNull()
        {
            tlog.Debug(tag, $"DataTriggerBindingWithNull START");

#pragma warning disable Reflection // The code contains reflection
            DataTrigger dt = new DataTrigger(typeof(View));
#pragma warning restore Reflection // The code contains reflection
            Assert.IsNotNull(dt, "Should not be null");
            
            var ret = dt.Binding; //null
            Assert.IsNull(ret, "Should be null");
            dt.Binding = ret;
            
            tlog.Debug(tag, $"DataTriggerBindingWithNull END");
        }

        [Test]
        [Category("P1")]
        [Description("DataTrigger Binding")]
        [Property("SPEC", "Tizen.NUI.Binding.DataTrigger.Binding  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void DataTriggerBinding()
        {
            tlog.Debug(tag, $"DataTriggerBinding START");

#pragma warning disable Reflection // The code contains reflection
            DataTrigger dt = new DataTrigger(typeof(View));
#pragma warning restore Reflection // The code contains reflection
            Assert.IsNotNull(dt, "Should not be null");

            var b = new Binding.Binding();
            dt.Binding = b;

            tlog.Debug(tag, $"DataTriggerBinding END");
        }

        [Test]
        [Category("P1")]
        [Description("DataTrigger Setters")]
        [Property("SPEC", "Tizen.NUI.Binding.DataTrigger.Setters  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        public void DataTriggerSetters()
        {
            tlog.Debug(tag, $"DataTriggerSetters START");

#pragma warning disable Reflection // The code contains reflection
            DataTrigger dt = new DataTrigger(typeof(View));
#pragma warning restore Reflection // The code contains reflection
            Assert.IsNotNull(dt, "Should not be null");

            var ret = dt.Setters;
            Assert.AreEqual(0, ret.Count, "Should be equal");

            tlog.Debug(tag, $"DataTriggerSetters END");
        }

        [Test]
        [Category("P1")]
        [Description("DataTrigger Value")]
        [Property("SPEC", "Tizen.NUI.Binding.DataTrigger.Value  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Obsolete]
        public void DataTriggerValue()
        {
            tlog.Debug(tag, $"DataTriggerValue START");

#pragma warning disable Reflection // The code contains reflection
            DataTrigger dt = new DataTrigger(typeof(View));
#pragma warning restore Reflection // The code contains reflection
            Assert.IsNotNull(dt, "Should not be null");
            var ret = dt.Value;
            dt.Value = ret;
            Assert.AreEqual(ret, dt.Value, "Should be equal");
            dt.Value = 0;
            
            tlog.Debug(tag, $"DataTriggerValue END");
        }
    }
}