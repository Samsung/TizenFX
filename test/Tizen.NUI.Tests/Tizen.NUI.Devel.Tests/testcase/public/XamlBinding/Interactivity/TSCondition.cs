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
    [Description("public/XamlBinding/Interactivity/Condition")]
    internal class PublicConditionTest
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
        [Description("Condition Condition ")]
        [Property("SPEC", "Tizen.NUI.Binding.Condition.Condition  C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void ConditionConstructor()
        {
            tlog.Debug(tag, $"ConditionConstructor START");
            BindingCondition mb = new BindingCondition();
            Assert.IsNotNull(mb, "Should not be null");
            tlog.Debug(tag, $"ConditionConstructor END");
        }

        [Test]
        [Category("P1")]
        [Description("Condition ConditionChanged")]
        [Property("SPEC", "Tizen.NUI.Binding.Condition.ConditionChanged  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ConditionChangedTest()
        {
            tlog.Debug(tag, $"ConditionChangedTest START");
            BindingCondition mb = new BindingCondition();
            Assert.IsNotNull(mb, "Should not be null");
            var ret = mb.ConditionChanged; //null
            Assert.IsNull(ret, "Should be null");
            mb.ConditionChanged = ret;
            tlog.Debug(tag, $"ConditionChangedTest END");
        }

        [Test]
        [Category("P1")]
        [Description("Condition Binding")]
        [Property("SPEC", "Tizen.NUI.Binding.Condition.ConditionChanged  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ConditionChangedTest2()
        {
            tlog.Debug(tag, $"ConditionChangedTest2 START");
            BindingCondition mb = new BindingCondition();
            Assert.IsNotNull(mb, "Should not be null");
            var ac = (Action<BindableObject, bool, bool>)((bindable, b, c) => throw new Exception());
            mb.ConditionChanged = ac;
            
            tlog.Debug(tag, $"ConditionChangedTest2 END");
        }

        [Test]
        [Category("P1")]
        [Description("Condition IsSealed")]
        [Property("SPEC", "Tizen.NUI.Binding.Condition.IsSealed  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void IsSealedTest()
        {
            tlog.Debug(tag, $"IsSealedTest START");
            BindingCondition mb = new BindingCondition();
            Assert.IsNotNull(mb, "Should not be null");
            var ret = mb.IsSealed;
            Assert.AreEqual(false, ret, "Should be equal");
            mb.IsSealed = ret;
            tlog.Debug(tag, $"IsSealedTest END");
        }

        [Test]
        [Category("P2")]
        [Description("Condition IsSealed")]
        [Property("SPEC", "Tizen.NUI.Binding.Condition.IsSealed  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void IsSealedTest2()
        {
            tlog.Debug(tag, $"IsSealedTest2 START");
            BindingCondition mb = new BindingCondition();
            Assert.IsNotNull(mb, "Should not be null");
            mb.IsSealed = true;
            Assert.AreEqual(true, mb.IsSealed, "Should be equal");
            Assert.Throws<InvalidOperationException>(() => mb.IsSealed = false);
            tlog.Debug(tag, $"IsSealedTest2 END");
        }
    }
}