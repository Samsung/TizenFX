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

            Tizen.NUI.PaddingType expectedLineGeometry = new Tizen.NUI.PaddingType(0, 0, 0, 0);

            var testingTarget = new TextEditor();
            Assert.IsNotNull(testingTarget, "Can't create success object TextEditor");
            Assert.IsInstanceOf<TextEditor>(testingTarget, "Should be an instance of TextEditor type.");

            var lineGeometry = TextGeometry.GetLineBoundingRectangle(testingTarget, 0);
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

            Tizen.NUI.PaddingType expectedLineGeometry = new Tizen.NUI.PaddingType(0, 0, 0, 0);

            var testingTarget = new TextField();
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            var lineGeometry = TextGeometry.GetLineBoundingRectangle(testingTarget, 0);
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

            Tizen.NUI.PaddingType expectedLineGeometry = new Tizen.NUI.PaddingType(0, 0, 0, 0);

            var testingTarget = new TextLabel();
            Assert.IsNotNull(testingTarget, "Can't create success object TextLabel");
            Assert.IsInstanceOf<TextLabel>(testingTarget, "Should be an instance of TextLabel type.");

            var lineGeometry = TextGeometry.GetLineBoundingRectangle(testingTarget, 0);
            Assert.IsNotNull(lineGeometry, "Null object is detected!");
            Assert.IsTrue(lineGeometry == expectedLineGeometry, "Should be equal!");

            tlog.Debug(tag, $"GetLineBoundingRectangleTextLabel END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextGeometry GetCharacterBoundingRectangleTextEditor")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextGeometry.GetCharacterBoundingRectangleTextEditor M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "s.al-jammal@partner.samsung.com")]
        public void GetCharacterBoundingRectangleTextEditor()
        {
            tlog.Debug(tag, $"GetCharacterBoundingRectangleTextEditor START");

            Tizen.NUI.PaddingType expectedCharGeometry = new Tizen.NUI.PaddingType(0, 0, 0, 0);

            var testingTarget = new TextEditor();
            Assert.IsNotNull(testingTarget, "Can't create success object TextEditor");
            Assert.IsInstanceOf<TextEditor>(testingTarget, "Should be an instance of TextEditor type.");

            var charGeometry = TextGeometry.GetCharacterBoundingRectangle(testingTarget, 0);
            Assert.IsNotNull(charGeometry, "Null object is detected!");
            Assert.IsTrue(charGeometry == expectedCharGeometry, "Should be equal!");

            tlog.Debug(tag, $"GetCharacterBoundingRectangleTextEditor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextGeometry GetCharacterBoundingRectangleTextField")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextGeometry.GetCharacterBoundingRectangleTextField M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "s.al-jammal@partner.samsung.com")]
        public void GetCharacterBoundingRectangleTextField()
        {
            tlog.Debug(tag, $"GetCharacterBoundingRectangleTextField START");

            Tizen.NUI.PaddingType expectedCharGeometry = new Tizen.NUI.PaddingType(0, 0, 0, 0);

            var testingTarget = new TextField();
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            var charGeometry = TextGeometry.GetCharacterBoundingRectangle(testingTarget, 0);
            Assert.IsNotNull(charGeometry, "Null object is detected!");
            Assert.IsTrue(charGeometry == expectedCharGeometry, "Should be equal!");

            tlog.Debug(tag, $"GetCharacterBoundingRectangleTextField END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextGeometry GetCharacterBoundingRectangleTextLabel")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextGeometry.GetCharacterBoundingRectangleTextLabel M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "s.al-jammal@partner.samsung.com")]
        public void GetCharacterBoundingRectangleTextLabel()
        {
            tlog.Debug(tag, $"GetCharacterBoundingRectangleTextLabel START");

            Tizen.NUI.PaddingType expectedCharGeometry = new Tizen.NUI.PaddingType(0, 0, 0, 0);

            var testingTarget = new TextLabel();
            Assert.IsNotNull(testingTarget, "Can't create success object TextLabel");
            Assert.IsInstanceOf<TextLabel>(testingTarget, "Should be an instance of TextLabel type.");

            var charGeometry = TextGeometry.GetCharacterBoundingRectangle(testingTarget, 0);
            Assert.IsNotNull(charGeometry, "Null object is detected!");
            Assert.IsTrue(charGeometry == expectedCharGeometry, "Should be equal!");

            tlog.Debug(tag, $"GetCharacterBoundingRectangleTextLabel END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextGeometry GetCharacterIndexAtPositionTextEditor")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextGeometry.GetCharacterIndexAtPositionTextEditor M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "s.al-jammal@partner.samsung.com")]
        public void GetCharacterIndexAtPositionTextEditor()
        {
            tlog.Debug(tag, $"GetCharacterIndexAtPositionTextEditor START");

            int expectedCharacterIndex = -1;

            var testingTarget = new TextEditor();
            Assert.IsNotNull(testingTarget, "Can't create success object TextEditor");
            Assert.IsInstanceOf<TextEditor>(testingTarget, "Should be an instance of TextEditor type.");

            var characterIndex = TextGeometry.GetCharacterIndexAtPosition(testingTarget, 0, 0);
            Assert.IsNotNull(characterIndex, "Null object is detected!");
            Assert.IsTrue(characterIndex == expectedCharacterIndex, "Should be equal!");

            tlog.Debug(tag, $"GetCharacterIndexAtPositionTextEditor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextGeometry GetCharacterIndexAtPositionTextField")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextGeometry.GetCharacterIndexAtPositionTextField M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "s.al-jammal@partner.samsung.com")]
        public void GetCharacterIndexAtPositionTextField()
        {
            tlog.Debug(tag, $"GetCharacterIndexAtPositionTextField START");

            int expectedCharacterIndex = -1;

            var testingTarget = new TextField();
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            var characterIndex = TextGeometry.GetCharacterIndexAtPosition(testingTarget, 0, 0);
            Assert.IsNotNull(characterIndex, "Null object is detected!");
            Assert.IsTrue(characterIndex == expectedCharacterIndex, "Should be equal!");

            tlog.Debug(tag, $"GetCharacterIndexAtPositionTextField END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextGeometry GetCharacterIndexAtPositionTextLabel")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextGeometry.GetCharacterIndexAtPositionTextLabel M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "s.al-jammal@partner.samsung.com")]
        public void GetCharacterIndexAtPositionTextLabel()
        {
            tlog.Debug(tag, $"GetCharacterIndexAtPositionTextLabel START");

            int expectedCharacterIndex = -1;

            var testingTarget = new TextLabel();
            Assert.IsNotNull(testingTarget, "Can't create success object TextLabel");
            Assert.IsInstanceOf<TextLabel>(testingTarget, "Should be an instance of TextLabel type.");

            var characterIndex = TextGeometry.GetCharacterIndexAtPosition(testingTarget, 0, 0);
            Assert.IsNotNull(characterIndex, "Null object is detected!");
            Assert.IsTrue(characterIndex == expectedCharacterIndex, "Should be equal!");

            tlog.Debug(tag, $"GetCharacterIndexAtPositionTextLabel END (OK)");
        }
    }
}
