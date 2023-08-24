using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Style/ImageScrollBarStyle")]
    public class StyleImageScrollBarStyleTest
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
        [Description("ScrollBarStyle constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.ScrollBarStyle.ScrollBarStyle C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollBarStyleConstructor()
        {
            tlog.Debug(tag, $"ScrollBarStyleConstructor START");

            var testingTarget = new ScrollBarStyle();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ScrollBarStyle>(testingTarget, "Should return ScrollBarStyle instance.");

            tlog.Debug(tag, $"ScrollBarStyleConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollBarStyle constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.ScrollBarStyle.ScrollBarStyle C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollBarStyleConstructorWithScrollBarStyle()
        {
            tlog.Debug(tag, $"ScrollBarStyleConstructorWithScrollBarStyle START");

            ScrollBarStyle style = new ScrollBarStyle();

            var testingTarget = new ScrollBarStyle(style);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ScrollBarStyle>(testingTarget, "Should return ScrollBarStyle instance.");

            tlog.Debug(tag, $"ScrollBarStyleConstructorWithScrollBarStyle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollBarStyle Track.")]
        [Property("SPEC", "Tizen.NUI.Components.ScrollBarStyle.Track A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollBarStyleTrack()
        {
            tlog.Debug(tag, $"ScrollBarStyleTrack START");

            var testingTarget = new ScrollBarStyle();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ScrollBarStyle>(testingTarget, "Should return ScrollBarStyle instance.");

            ImageViewStyle track = new ImageViewStyle()
            {
                BackgroundColor = Color.Blue,
            };

            testingTarget.Track = track;
            tlog.Debug(tag, "Track : " + testingTarget.Track);

            tlog.Debug(tag, $"ScrollBarStyleTrack END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollBarStyle Thumb.")]
        [Property("SPEC", "Tizen.NUI.Components.ScrollBarStyle.Thumb A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollBarStyleThumb()
        {
            tlog.Debug(tag, $"ScrollBarStyleThumb START");

            var testingTarget = new ScrollBarStyle();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ScrollBarStyle>(testingTarget, "Should return ScrollBarStyle instance.");

            ImageViewStyle thumb = new ImageViewStyle()
            {
                BackgroundColor = Color.Green,
            };

            testingTarget.Thumb = thumb;
            tlog.Debug(tag, "Thumb : " + testingTarget.Thumb);

            tlog.Debug(tag, $"ScrollBarStyleThumb END (OK)");
        }
    }
}
