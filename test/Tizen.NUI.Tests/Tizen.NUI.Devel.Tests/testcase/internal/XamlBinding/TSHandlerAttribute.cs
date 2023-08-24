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
    [Description("internal/XamlBinding/HandlerAttribute")]
    public class InternalHandlerAttributeTest
    {
        private const string tag = "NUITEST";

        internal class MyHandlerAttribute : HandlerAttribute
        {
            public MyHandlerAttribute(Type handler, Type target) : base(handler, target)
            {}
        }

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
        [Description("HandlerAttribute constructor")]
        [Property("SPEC", "Tizen.NUI.Binding.HandlerAttribute.HandlerAttribute C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void HandlerAttributeConstructor()
        {
            tlog.Debug(tag, $"HandlerAttributeConstructor START");
            var ft = typeof(float);
            var it = typeof(int);
            var testingTarget = new MyHandlerAttribute(it, ft);
            Assert.IsNotNull(testingTarget, "Can't create success object HandlerAttribute.");
            Assert.IsInstanceOf<MyHandlerAttribute>(testingTarget, "Should return HandlerAttribute instance.");

            Assert.AreEqual(it, testingTarget.HandlerType, "Should be equal");
            Assert.AreEqual(ft, testingTarget.TargetType, "Should be equal");
            Assert.AreEqual(true, testingTarget.ShouldRegister(), "Should be equal");

            tlog.Debug(tag, $"HandlerAttributeConstructor END");
        }
    }
}
