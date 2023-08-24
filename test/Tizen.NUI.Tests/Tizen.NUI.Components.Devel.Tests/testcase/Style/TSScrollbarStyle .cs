using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using System.Threading.Tasks;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Style/ScrollbarStyle")]
    public class ScrollbarStyleTest
    {
        private const string tag = "NUITEST";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

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
        [Description("ScrollbarStyle constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.ScrollbarStyle.ScrollbarStyle C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollbarStyleConstructor()
        {
            tlog.Debug(tag, $"ScrollbarStyleConstructor START");

            ScrollbarStyle style = new ScrollbarStyle()
            {
                BackgroundColor = Color.Cyan,
                TrackThickness = 1.0f,
                TrackColor = Color.Red,
                ThumbThickness = 0.3f,
                ThumbColor = Color.Green,
                ThumbVerticalImageUrl = image_path,
                ThumbHorizontalImageUrl = image_path,
                TrackPadding = 0,
            };
            var testingTarget = new ScrollbarStyle(style);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ScrollbarStyle>(testingTarget, "Should return ScrollbarStyle instance.");

            tlog.Debug(tag, "TrackThickness : " + testingTarget.TrackThickness);
            tlog.Debug(tag, "TrackColor : " + testingTarget.TrackColor);
            tlog.Debug(tag, "ThumbThickness : " + testingTarget.ThumbThickness);
            tlog.Debug(tag, "ThumbColor : " + testingTarget.ThumbColor);
            tlog.Debug(tag, "ThumbVerticalImageUrl : " + testingTarget.ThumbVerticalImageUrl);
            tlog.Debug(tag, "ThumbHorizontalImageUrl : " + testingTarget.ThumbHorizontalImageUrl);
            tlog.Debug(tag, "TrackPadding : " + testingTarget.TrackPadding);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollbarStyleConstructor END (OK)");
        }
    }
}
