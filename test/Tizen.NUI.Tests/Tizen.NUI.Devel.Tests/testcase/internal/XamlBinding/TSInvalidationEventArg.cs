using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Reflection;
using System.Collections.Generic;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/XamlBinding/InvalidationEventArgs")]
    public class InternalInvalidationEventArgsTest
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
        [Description("InvalidationEventArgs constructor")]
        [Property("SPEC", "Tizen.NUI.Binding.InvalidationEventArgs.InvalidationEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void InvalidationEventArgsConstructor()
        {
            tlog.Debug(tag, $"InvalidationEventArgsConstructor START");

            var testingTarget = new InvalidationEventArgs(InvalidationTrigger.Undefined);
            Assert.IsNotNull(testingTarget, "Can't create success object InvalidationEventArgs.");
            Assert.IsInstanceOf<InvalidationEventArgs>(testingTarget, "Should return InvalidationEventArgs instance.");

            Assert.AreEqual(InvalidationTrigger.Undefined, testingTarget.Trigger, "Should be equal");
            
            tlog.Debug(tag, $"InvalidationEventArgsConstructor END");
        }
    }
}
