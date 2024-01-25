using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Reflection;
using System.Collections.Generic;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/XamlBinding/MultiCondition")]
    public class InternalMultiConditionTest
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
        [Description("MultiCondition constructor")]
        [Property("SPEC", "Tizen.NUI.Binding.MultiCondition.MultiCondition C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void MultiConditionConstructor()
        {
            tlog.Debug(tag, $"MultiConditionConstructor START");

            var testingTarget = new MultiCondition();
            Assert.IsNotNull(testingTarget, "Can't create success object MultiCondition.");
            Assert.IsInstanceOf<MultiCondition>(testingTarget, "Should return MultiCondition instance.");

            Assert.False(testingTarget.GetState(new View()), "Should be false");

            tlog.Debug(tag, $"MultiConditionConstructor END");
        }

        [Test]
        [Category("P1")]
        [Description("MultiCondition OnSealed")]
        [Property("SPEC", "Tizen.NUI.Binding.MultiCondition.OnSealed M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void OnSealed()
        {
            tlog.Debug(tag, $"OnSealed START");
            try
            {
                var testingTarget = new MultiCondition();
                Assert.IsNotNull(testingTarget, "Can't create success object MultiCondition.");
                testingTarget.Conditions.Add(new BindingCondition());
                testingTarget.OnSealed();
                var v = new View();
                testingTarget.SetUp(v);
                testingTarget.TearDown(v);
            }
            catch(Exception e)
            {
                Assert.Fail("Catch exception: " + e.Message.ToString());
            }
            tlog.Debug(tag, $"OnSealed END");
        }
    }
}
