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
        [Description("TextGeometry GetTextSize on TextEditor")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextGeometry.GetTextSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "s.al-jammal@partner.samsung.com")]
        public void GetTextSizeTextEditor()
        {
            tlog.Debug(tag, $"GetTextSizeTextEditor START");

            int expectedSizeOfList = 0;

            var testingTarget = new TextEditor();
            Assert.IsNotNull(testingTarget, "Can't create success object TextEditor");
            Assert.IsInstanceOf<TextEditor>(testingTarget, "Should be an instance of TextEditor type.");

            var actualSizeList = TextGeometry.GetTextSize(testingTarget, 0,0);
            Assert.IsNotNull(actualSizeList, "Null object is detected!");
            Assert.IsTrue(actualSizeList.Count == expectedSizeOfList, "Should be true!");

            tlog.Debug(tag, $"GetTextSizeTextEditor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextGeometry GetTextSize on TextField")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextGeometry.GetTextSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "s.al-jammal@partner.samsung.com")]
        public void GetTextSizeTextField()
        {
            tlog.Debug(tag, $"GetTextSizeTextField START");

            int expectedSizeOfList = 0;

            var testingTarget = new TextField();
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            var actualSizeList = TextGeometry.GetTextSize(testingTarget, 0,0);
            Assert.IsNotNull(actualSizeList, "Null object is detected!");
            Assert.IsTrue(actualSizeList.Count == expectedSizeOfList, "Should be true!");

            tlog.Debug(tag, $"GetTextSizeTextField END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextGeometry GetTextSize on TextLabel")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextGeometry.GetTextSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "s.al-jammal@partner.samsung.com")]
        public void GetTextSizeTextLabel()
        {
            tlog.Debug(tag, $"GetTextSizeTextLabel START");

            int expectedSizeOfList = 0;

            var testingTarget = new TextLabel();
            Assert.IsNotNull(testingTarget, "Can't create success object TextLabel");
            Assert.IsInstanceOf<TextLabel>(testingTarget, "Should be an instance of TextLabel type.");

            var actualSizeList = TextGeometry.GetTextSize(testingTarget, 0,0);
            Assert.IsNotNull(actualSizeList, "Null object is detected!");
            Assert.IsTrue(actualSizeList.Count == expectedSizeOfList, "Should be true!");

            tlog.Debug(tag, $"GetTextSizeTextLabel END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextGeometry GetTextPosition on TextEditor")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextGeometry.GetTextPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "s.al-jammal@partner.samsung.com")]
        public void GetTextPositionTextEditor()
        {
            tlog.Debug(tag, $"GetTextPositionTextEditor START");

            int expectedPositionOfList = 0;

            var testingTarget = new TextEditor();
            Assert.IsNotNull(testingTarget, "Can't create success object TextEditor");
            Assert.IsInstanceOf<TextEditor>(testingTarget, "Should be an instance of TextEditor type.");

            var actualPositionList = TextGeometry.GetTextPosition(testingTarget, 0,0);
            Assert.IsNotNull(actualPositionList, "Null object is detected!");
            Assert.IsTrue(actualPositionList.Count == expectedPositionOfList, "Should be true!");

            tlog.Debug(tag, $"GetTextPositionTextEditor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextGeometry GetTextPosition on TextField")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextGeometry.GetTextPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "s.al-jammal@partner.samsung.com")]
        public void GetTextPositionTextField()
        {
            tlog.Debug(tag, $"GetTextPositionTextField START");

            int expectedPositionOfList = 0;

            var testingTarget = new TextField();
            Assert.IsNotNull(testingTarget, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(testingTarget, "Should be an instance of TextField type.");

            var actualPositionList = TextGeometry.GetTextPosition(testingTarget, 0,0);
            Assert.IsNotNull(actualPositionList, "Null object is detected!");
            Assert.IsTrue(actualPositionList.Count == expectedPositionOfList, "Should be true!");

            tlog.Debug(tag, $"GetTextPositionTextField END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextGeometry GetTextPosition on TextLabel")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextGeometry.GetTextPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "s.al-jammal@partner.samsung.com")]
        public void GetTextPositionTextLabel()
        {
            tlog.Debug(tag, $"GetTextPositionTextLabel START");

            int expectedPositionOfList = 0;

            var testingTarget = new TextLabel();
            Assert.IsNotNull(testingTarget, "Can't create success object TextLabel");
            Assert.IsInstanceOf<TextLabel>(testingTarget, "Should be an instance of TextLabel type.");

            var actualPositionList = TextGeometry.GetTextPosition(testingTarget, 0,0);
            Assert.IsNotNull(actualPositionList, "Null object is detected!");
            Assert.IsTrue(actualPositionList.Count == expectedPositionOfList, "Should be true!");

            tlog.Debug(tag, $"GetTextPositionTextLabel END (OK)");
        }


    }
}
