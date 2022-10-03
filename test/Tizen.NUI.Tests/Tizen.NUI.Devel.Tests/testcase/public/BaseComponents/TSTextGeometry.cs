using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/BaseComponents/TextGeometry")]
    public class PublicTextGeometryTest
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
        [Description("TextGeometry GetLineBoundingRectangleTextEditor")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextGeometry.GetLineBoundingRectangleTextEditor M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "s.al-jammal@partner.samsung.com")]
        public void GetLineBoundingRectangleTextEditor()
        {
            tlog.Debug(tag, $"GetLineBoundingRectangleTextEditor START");

            rect<float> expectedLineGeometry = {0.0, 0.0, 0.0, 0.0};

            var testingTarget = new TextEditor();
            Assert.IsNotNull(testingTarget, "Can't create success object TextEditor");
            Assert.IsInstanceOf<TextEditor>(testingTarget, "Should be an instance of TextEditor type.");

            var lineGeometry = TextGeometry.GetLineBoundingRectangleTextEditor(testingTarget, 0);
            Assert.IsNotNull(lineGeometry, "Null object is detected!");
            Assert.IsTrue(lineGeometry == expectedLineGeometry, "Should be equal!");

            tlog.Debug(tag, $"GetLineBoundingRectangleTextEditor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextGeometry GetLineBoundingRectangleTextField")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextGeometry.GetLineBoundingRectangleTextField M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "s.al-jammal@partner.samsung.com")]
        public void GetLineBoundingRectangleTextField()
        {
            tlog.Debug(tag, $"GetLineBoundingRectangleTextField START");

            rect<float> expectedLineGeometry = {0.0, 0.0, 0.0, 0.0};

            var testingTarget = new TextField();
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            var lineGeometry = TextGeometry.GetLineBoundingRectangleTextField(testingTarget, 0);
            Assert.IsNotNull(lineGeometry, "Null object is detected!");
            Assert.IsTrue(lineGeometry == expectedLineGeometry, "Should be equal!");

            tlog.Debug(tag, $"GetLineBoundingRectangleTextField END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextGeometry GetLineBoundingRectangleTextLabel")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextGeometry.GetLineBoundingRectangleTextLabel M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "s.al-jammal@partner.samsung.com")]
        public void GetLineBoundingRectangleTextLabel()
        {
            tlog.Debug(tag, $"GetLineBoundingRectangleTextLabel START");

            rect<float> expectedLineGeometry = {0.0, 0.0, 0.0, 0.0};

            var testingTarget = new TextLabel();
            Assert.IsNotNull(testingTarget, "Can't create success object TextLabel");
            Assert.IsInstanceOf<TextLabel>(testingTarget, "Should be an instance of TextLabel type.");

            var lineGeometry = TextGeometry.GetLineBoundingRectangleTextLabel(testingTarget, 0);
            Assert.IsNotNull(lineGeometry, "Null object is detected!");
            Assert.IsTrue(lineGeometry == expectedLineGeometry, "Should be equal!");

            tlog.Debug(tag, $"GetLineBoundingRectangleTextLabel END (OK)");
        }

    }
}
