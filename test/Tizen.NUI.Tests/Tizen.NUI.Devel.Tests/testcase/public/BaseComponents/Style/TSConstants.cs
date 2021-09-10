using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/BaseComponents/Style/Constants")]
    public class PublicConstantsTest
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
        [Description("ControlStatesExtension FromControlStateClass.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.ControlStatesExtension.FromControlStateClass M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ControlStatesExtensionFromControlStateClass()
        {
            tlog.Debug(tag, $"ControlStatesExtensionFromControlStateClass START");

            var result = ControlStatesExtension.FromControlStateClass(ControlState.Normal);
            Assert.AreEqual(ControlStates.Normal, result, "Should be equal!");

            result = ControlStatesExtension.FromControlStateClass(ControlState.Focused);
            Assert.AreEqual(ControlStates.Focused, result, "Should be equal!");

            result = ControlStatesExtension.FromControlStateClass(ControlState.Disabled);
            Assert.AreEqual(ControlStates.Disabled, result, "Should be equal!");

            result = ControlStatesExtension.FromControlStateClass(ControlState.Selected);
            Assert.AreEqual(ControlStates.Selected, result, "Should be equal!");

            result = ControlStatesExtension.FromControlStateClass(ControlState.Pressed);
            Assert.AreEqual(ControlStates.Pressed, result, "Should be equal!");

            result = ControlStatesExtension.FromControlStateClass(ControlState.DisabledFocused);
            Assert.AreEqual(ControlStates.DisabledFocused, result, "Should be equal!");

            result = ControlStatesExtension.FromControlStateClass(ControlState.SelectedFocused);
            Assert.AreEqual(ControlStates.SelectedFocused, result, "Should be equal!");

            result = ControlStatesExtension.FromControlStateClass(ControlState.DisabledSelected);
            Assert.AreEqual(ControlStates.DisabledSelected, result, "Should be equal!");

            result = ControlStatesExtension.FromControlStateClass(ControlState.All);
            Assert.AreEqual(ControlStates.Normal, result, "Should be equal!");

            tlog.Debug(tag, $"ControlStatesExtensionFromControlStateClass END (OK)");
        }
    }
}
