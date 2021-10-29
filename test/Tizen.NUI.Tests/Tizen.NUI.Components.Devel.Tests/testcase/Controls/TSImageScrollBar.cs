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
    [Description("Controls/ImageScrollBar")]
    public class ImageScrollBarTest
    {
        private const string tag = "NUITEST";
        private string path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

        [Obsolete]
        internal class MyScrollBar : ScrollBar
        {
            public MyScrollBar() : base()
            { }

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
        [Description("ScrollBar constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.ScrollBar.ScrollBar C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void ScrollBarConstructor()
        {
            tlog.Debug(tag, $"ScrollBarConstructor START");

            var testingTarget = new ScrollBar();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ScrollBar>(testingTarget, "Should return ScrollBar instance.");

            testingTarget.MinValue = 0;
            tlog.Debug(tag, "MinValue : " + testingTarget.MinValue);
            
            testingTarget.MaxValue = 100;
            tlog.Debug(tag, "MaxValue : " + testingTarget.MaxValue);

            testingTarget.Duration = 3;
            tlog.Debug(tag, "Duration : " + testingTarget.Duration);

            testingTarget.CurrentValue = 30;
            tlog.Debug(tag, "CurrentValue : " + testingTarget.CurrentValue);

            try
            {
                testingTarget.SetCurrentValue(50, true);
                tlog.Debug(tag, "CurrentValue : " + testingTarget.CurrentValue);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollBarConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollBar constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.ScrollBar.ScrollBar C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void ScrollBarConstructorWithScrollBarStyle()
        {
            tlog.Debug(tag, $"ScrollBarConstructorWithScrollBarStyle START");

            ScrollBarStyle style = new ScrollBarStyle()
            { 
                Size = new Size(30, 2),
                HeightResizePolicy = ResizePolicyType.Fixed,
            };

            var testingTarget = new ScrollBar(style);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ScrollBar>(testingTarget, "Should return ScrollBar instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollBarConstructorWithScrollBarStyle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollBar Direction.")]
        [Property("SPEC", "Tizen.NUI.Components.ScrollBar.Direction A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void ScrollBarDirection()
        {
            tlog.Debug(tag, $"ScrollBarDirection START");

            var testingTarget = new ScrollBar()
            {
                Direction = ScrollBar.DirectionType.Vertical,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ScrollBar>(testingTarget, "Should return ScrollBar instance.");

            tlog.Debug(tag, "Direction : " + testingTarget.Direction);

            testingTarget.Direction = ScrollBar.DirectionType.Horizontal;
            tlog.Debug(tag, "Direction : " + testingTarget.Direction);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollBarDirection END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollBar ThumbSize.")]
        [Property("SPEC", "Tizen.NUI.Components.ScrollBar.ThumbSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void ScrollBarThumbSize()
        {
            tlog.Debug(tag, $"ScrollBarThumbSize START");

            var testingTarget = new ScrollBar()
            {
                Direction = ScrollBar.DirectionType.Vertical,
                ThumbSize = new Size(10, 5)
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ScrollBar>(testingTarget, "Should return ScrollBar instance.");

            tlog.Debug(tag, "ThumbSize : " + testingTarget.ThumbSize);

            testingTarget.ThumbSize = new Size(8, 4);
            tlog.Debug(tag, "ThumbSize : " + testingTarget.ThumbSize);

            testingTarget.ThumbColor = Color.Yellow;
            tlog.Debug(tag, "ThumbColor : " + testingTarget.ThumbColor);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollBarThumbSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollBar TrackImageURL.")]
        [Property("SPEC", "Tizen.NUI.Components.ScrollBar.TrackImageURL A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void ScrollBarTrackImageURL()
        {
            tlog.Debug(tag, $"ScrollBarTrackImageURL START");

            var testingTarget = new ScrollBar()
            {
                Direction = ScrollBar.DirectionType.Vertical,
                ThumbSize = new Size(10, 5)
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ScrollBar>(testingTarget, "Should return ScrollBar instance.");

            testingTarget.TrackImageURL = path;
            tlog.Debug(tag, "TrackImageURL : " + testingTarget.TrackImageURL);

            testingTarget.TrackColor = Color.Black;
            tlog.Debug(tag, "TrackColor : " + testingTarget.TrackColor);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollBarTrackImageURL END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollBar CreateViewStyle.")]
        [Property("SPEC", "Tizen.NUI.Components.ScrollBar.CreateViewStyle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void ScrollBarCreateViewStyle()
        {
            tlog.Debug(tag, $"ScrollBarCreateViewStyle START");

            var testingTarget = new MyScrollBar();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ScrollBar>(testingTarget, "Should return ScrollBar instance.");

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
            tlog.Debug(tag, $"ScrollBarCreateViewStyle END (OK)");
        }
    }
}
