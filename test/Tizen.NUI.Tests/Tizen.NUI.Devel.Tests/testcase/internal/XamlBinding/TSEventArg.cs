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
    [Description("internal/XamlBinding/EventArg")]
    public class InternalEventArgTest
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
        [Description("EventArg constructor")]
        [Property("SPEC", "Tizen.NUI.Binding.EventArg.EventArg C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void EventArgConstructor()
        {
            tlog.Debug(tag, $"EventArgConstructor START");

            var testingTarget = new EventArg<int>(10);
            Assert.IsNotNull(testingTarget, "Can't create success object EventArg.");
            Assert.IsInstanceOf<EventArg<int>>(testingTarget, "Should return EventArg instance.");

            Assert.AreEqual(10, testingTarget.Data, "Should be equal");
            
            tlog.Debug(tag, $"EventArgConstructor END");
        }
    }
}
