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
    [Description("Controls/Scrollbar")]
    public class ScrollbarTest
    {
        private const string tag = "NUITEST";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

        internal class MyScrollbar : Scrollbar
        {
            public MyScrollbar() : base()
            { }

            public void OnDispose(DisposeTypes types)
            {
                base.Dispose(types);
            }

            public void OnCreateViewStyle()
            {
                base.CreateViewStyle();
            }
        }

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
        [Description("Scrollbar constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.Scrollbar.Scrollbar C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollbarConstructor()
        {
            tlog.Debug(tag, $"ScrollbarConstructor START");

            var testingTarget = new Scrollbar(100.0f, 50.0f, 20.0f, false);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Scrollbar>(testingTarget, "Should return Scrollbar instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollbarConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Scrollbar constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.Scrollbar.Scrollbar C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollbarConstructorWithScrollbarStyle()
        {
            tlog.Debug(tag, $"ScrollbarConstructorWithScrollbarStyle START");

            ScrollbarStyle style = new ScrollbarStyle()
            {
                Size = new Size(100, 2),
            };

            var testingTarget = new Scrollbar(style);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Scrollbar>(testingTarget, "Should return Scrollbar instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollbarConstructorWithScrollbarStyle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Scrollbar TrackThickness.")]
        [Property("SPEC", "Tizen.NUI.Components.Scrollbar.TrackThickness A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollbarTrackThickness()
        {
            tlog.Debug(tag, $"ScrollbarTrackThickness START");

            var testingTarget = new Scrollbar(100.0f, 2, 40, true);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Scrollbar>(testingTarget, "Should return Scrollbar instance.");

            testingTarget.TrackThickness = 13.0f;
            testingTarget.ThumbThickness = 3.0f;

            testingTarget.TrackColor = Color.Blue;
            tlog.Debug(tag, "TrackColor : " + testingTarget.TrackColor);

            testingTarget.ThumbColor = Color.Black;
            tlog.Debug(tag, "ThumbColor : " + testingTarget.ThumbColor);

            testingTarget.ThumbVerticalImageUrl = image_path;
            tlog.Debug(tag, "ThumbVerticalImageUrl : " + testingTarget.ThumbVerticalImageUrl);

            testingTarget.ThumbHorizontalImageUrl = image_path;
            tlog.Debug(tag, "ThumbHorizontalImageUrl : " + testingTarget.ThumbHorizontalImageUrl);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollbarTrackThickness END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Scrollbar ScrollPosition.")]
        [Property("SPEC", "Tizen.NUI.Components.Scrollbar.ScrollPosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollbarScrollPosition()
        {
            tlog.Debug(tag, $"ScrollbarScrollPosition START");

            var testingTarget = new Scrollbar(100.0f, 2, 40, true);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Scrollbar>(testingTarget, "Should return Scrollbar instance.");

            tlog.Debug(tag, "ScrollPosition : " + testingTarget.ScrollPosition);
            tlog.Debug(tag, "ScrollCurrentPosition : " + testingTarget.ScrollCurrentPosition);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollbarScrollPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Scrollbar Update.")]
        [Property("SPEC", "Tizen.NUI.Components.Scrollbar.Update M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollbarUpdate()
        {
            tlog.Debug(tag, $"ScrollbarUpdate START");

            var testingTarget = new Scrollbar(100.0f, 2, 40, true);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Scrollbar>(testingTarget, "Should return Scrollbar instance.");

            try
            {
                testingTarget.OnInitialize();
                testingTarget.Update(100.0f, 80, 200, null);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollbarUpdate END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Scrollbar ScrollTo.")]
        [Property("SPEC", "Tizen.NUI.Components.Scrollbar.ScrollTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollbarScrollTo()
        {
            tlog.Debug(tag, $"ScrollbarScrollTo START");

            var testingTarget = new Scrollbar(100.0f, 2, 40, true);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Scrollbar>(testingTarget, "Should return Scrollbar instance.");

            try
            {
                testingTarget.OnInitialize();
                testingTarget.ScrollTo(80, 200, null);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollbarScrollTo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Scrollbar CreateViewStyle.")]
        [Property("SPEC", "Tizen.NUI.Components.Scrollbar.CreateViewStyle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollbarCreateViewStyle()
        {
            tlog.Debug(tag, $"ScrollbarCreateViewStyle START");

            var testingTarget = new MyScrollbar();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Scrollbar>(testingTarget, "Should return Scrollbar instance.");

            try
            {
                testingTarget.OnCreateViewStyle();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollbarScrollTo END (OK)");
        }
    }
}
