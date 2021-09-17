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
    [Description("internal/XamlBinding/ResolutionGroupNameAttribute")]
    public class InternalResolutionGroupNameAttributeTest
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
        [Description("ResolutionGroupNameAttribute constructor")]
        [Property("SPEC", "Tizen.NUI.Binding.ResolutionGroupNameAttribute.ResolutionGroupNameAttribute C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void ResolutionGroupNameAttributeConstructor()
        {
            tlog.Debug(tag, $"ResolutionGroupNameAttributeConstructor START");

            var testingTarget = new ResolutionGroupNameAttribute("test");
            Assert.IsNotNull(testingTarget, "Can't create success object ResolutionGroupNameAttribute.");
            Assert.IsInstanceOf<ResolutionGroupNameAttribute>(testingTarget, "Should return ResolutionGroupNameAttribute instance.");

            Assert.AreEqual("test", testingTarget.ShortName, "Should be equal");

            tlog.Debug(tag, $"ResolutionGroupNameAttributeConstructor END");
        }
    }
}
