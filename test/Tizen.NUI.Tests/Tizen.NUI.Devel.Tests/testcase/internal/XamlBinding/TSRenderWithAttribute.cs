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
    [Description("internal/XamlBinding/RenderWithAttribute")]
    public class InternalRenderWithAttributeTest
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
        [Description("RenderWithAttribute constructor")]
        [Property("SPEC", "Tizen.NUI.Binding.RenderWithAttribute.RenderWithAttribute C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void RenderWithAttributeConstructor()
        {
            tlog.Debug(tag, $"RenderWithAttributeConstructor START");

            var it = typeof(int);
            var testingTarget = new RenderWithAttribute(it);
            Assert.IsNotNull(testingTarget, "Can't create success object RenderWithAttribute.");
            Assert.IsInstanceOf<RenderWithAttribute>(testingTarget, "Should return RenderWithAttribute instance.");

            Assert.AreEqual(it, testingTarget.Type, "Should be equal");

            tlog.Debug(tag, $"RenderWithAttributeConstructor END");
        }
    }
}
