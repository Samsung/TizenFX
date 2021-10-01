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
    [Description("internal/XamlBinding/MergedStyle")]
    public class InternalMergedStyleTest
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
        [Description("MergedStyle constructor")]
        [Property("SPEC", "Tizen.NUI.Binding.MergedStyle.MergedStyle C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void MergedStyleConstructor()
        {
            tlog.Debug(tag, $"MergedStyleConstructor START");

            var testingTarget = new MergedStyle(typeof(View), new View());
            Assert.IsNotNull(testingTarget, "Can't create success object MergedStyle.");

            var sc = testingTarget.StyleClass;
            testingTarget.StyleClass = sc;
            Assert.AreEqual(sc, testingTarget.StyleClass, "Should be equal");

            testingTarget.StyleClass = new List<string>() { "style" };
            tlog.Debug(tag, $"MergedStyleConstructor END");
        }

    }
}
