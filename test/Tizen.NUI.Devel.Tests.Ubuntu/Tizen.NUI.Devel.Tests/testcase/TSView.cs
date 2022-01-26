using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/BaseComponents/View")]
    public class InternalViewTest
    {
        private const string tag = "NUITEST";
        private const int testSize = 100;
        private const int testPosition = 100;

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
        [Description("internal API test in Ubuntu, View.ColorMode")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.ColorMode")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public void ColorMode_CHECK_DEFAULT_VALUE()
        {
            /* TEST CODE */
            View testView = new View();
            var colormode = testView.ColorMode;

            Assert.AreEqual(Tizen.NUI.ColorMode.UseOwnMultiplyParentAlpha, colormode, "colormode should be UseOwnMultiplyParentAlpha");

            testView.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("internal API test in Ubuntu, View.ColorMode")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.ColorMode")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public void ColorMode_CHECK_DEFAULT_VALUE_WITH_ADDED_VIEW()
        {
            /* TEST CODE */
            View testView = new View()
            {
                Size = new Size(testSize, testSize, 0),
                Position = new Position(testPosition, testPosition, 0),
                BackgroundColor = Color.Red,
            };
            NUIApplication.GetDefaultWindow().Add(testView);

            var colormode = testView.ColorMode;

            Assert.AreEqual(Tizen.NUI.ColorMode.UseOwnMultiplyParentAlpha, colormode, "colormode should be UseOwnMultiplyParentAlpha");

            testView.Unparent();
            testView.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("internal API test in Ubuntu, View.ColorMode")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.ColorMode")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public void ColorMode_SET_GET_VALUE()
        {
            /* TEST CODE */
            View testView = new View();

            testView.ColorMode = Tizen.NUI.ColorMode.UseOwnColor;
            Assert.AreEqual(Tizen.NUI.ColorMode.UseOwnColor, testView.ColorMode, "colormode should be UseOwnColor");

            testView.ColorMode = Tizen.NUI.ColorMode.UseParentColor;
            Assert.AreEqual(Tizen.NUI.ColorMode.UseParentColor, testView.ColorMode, "colormode should be UseParentColor");

            testView.ColorMode = Tizen.NUI.ColorMode.UseOwnMultiplyParentColor;
            Assert.AreEqual(Tizen.NUI.ColorMode.UseOwnMultiplyParentColor, testView.ColorMode, "colormode should be UseOwnMultiplyParentColor");

            testView.ColorMode = Tizen.NUI.ColorMode.UseOwnMultiplyParentAlpha;
            Assert.AreEqual(Tizen.NUI.ColorMode.UseOwnMultiplyParentAlpha, testView.ColorMode, "colormode should be UseOwnMultiplyParentAlpha");

            testView.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("internal API test in Ubuntu, View.ColorMode")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.ColorMode")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public void ColorMode_SET_GET_VALUE_WITH_ADDED_VIEW()
        {
            /* TEST CODE */
            View testView = new View()
            {
                Size = new Size(testSize, testSize, 0),
                Position = new Position(testPosition, testPosition, 0),
                BackgroundColor = Color.Red,
            };
            NUIApplication.GetDefaultWindow().Add(testView);

            testView.ColorMode = Tizen.NUI.ColorMode.UseOwnColor;
            Assert.AreEqual(Tizen.NUI.ColorMode.UseOwnColor, testView.ColorMode, "colormode should be UseOwnColor");

            testView.ColorMode = Tizen.NUI.ColorMode.UseParentColor;
            Assert.AreEqual(Tizen.NUI.ColorMode.UseParentColor, testView.ColorMode, "colormode should be UseParentColor");

            testView.ColorMode = Tizen.NUI.ColorMode.UseOwnMultiplyParentColor;
            Assert.AreEqual(Tizen.NUI.ColorMode.UseOwnMultiplyParentColor, testView.ColorMode, "colormode should be UseOwnMultiplyParentColor");

            testView.ColorMode = Tizen.NUI.ColorMode.UseOwnMultiplyParentAlpha;
            Assert.AreEqual(Tizen.NUI.ColorMode.UseOwnMultiplyParentAlpha, testView.ColorMode, "colormode should be UseOwnMultiplyParentAlpha");

            testView.Unparent();
            testView.Dispose();
        }

    }
}
