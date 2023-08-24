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
    [Description("internal/XamlBinding/GestureRecognizer")]
    public class InternalGestureRecognizerTest
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
        [Description("GestureRecognizer constructor")]
        [Property("SPEC", "Tizen.NUI.Binding.GestureRecognizer.GestureRecognizer C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void GestureRecognizerConstructor()
        {
            tlog.Debug(tag, $"GestureRecognizerConstructor START");

            var testingTarget = new GestureRecognizer();
            Assert.IsNotNull(testingTarget, "Can't create success object GestureRecognizer.");

            tlog.Debug(tag, $"GestureRecognizerConstructor END");
        }

    }
}
