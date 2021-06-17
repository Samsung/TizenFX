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
    [Description("public/Layouting/LinearLayout")]
    public class PublicLinearLayoutTest
    {
        private const string tag = "NUITEST";
        private static bool flagOnMeasureOverride;
        private static bool flagOnLayoutOverride;
        public class MyLinearLayout : LinearLayout
        {
            public MyLinearLayout() : base()
            { }

            // This method needs to call protected method, OnMeasure for the test cases.
            public void OnMeasureTest(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
            {
                OnMeasure(widthMeasureSpec, heightMeasureSpec);
            }
            protected override void OnMeasure(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
            {
                flagOnMeasureOverride = true;
                base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
            }

            public void OnLayoutTest(bool changed, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
            {
                OnLayout(changed, left, top, right, bottom);
            }
            protected override void OnLayout(bool changed, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
            {
                flagOnLayoutOverride = true;
                base.OnLayout(changed, left, top, right, bottom);
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
        [Description("LinearLayout constructor")]
        [Property("SPEC", "Tizen.NUI.LinearLayout.LinearLayout C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LinearLayoutConstructor()
        {
            tlog.Debug(tag, $"LinearLayoutConstructor START");

            var testingTarget = new LinearLayout();
            Assert.IsNotNull(testingTarget, "null handle returned");
            Assert.IsInstanceOf<LinearLayout>(testingTarget, "Should return LinearLayout instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"LinearLayoutConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LinearLayout LinearOrientation")]
        [Property("SPEC", "Tizen.NUI.LinearLayout.LinearOrientation A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LinearLayoutLinearOrientation()
        {
            tlog.Debug(tag, $"LinearLayoutLinearOrientation START");

            var testingTarget = new LinearLayout();
            Assert.IsNotNull(testingTarget, "null handle returned");
            Assert.IsInstanceOf<LinearLayout>(testingTarget, "Should return LinearLayout instance.");

            testingTarget.LinearOrientation = LinearLayout.Orientation.Vertical;
            Assert.AreEqual(testingTarget.LinearOrientation, LinearLayout.Orientation.Vertical, "Should be Vertical.");

            testingTarget.LinearOrientation = LinearLayout.Orientation.Horizontal;
            Assert.AreEqual(testingTarget.LinearOrientation, LinearLayout.Orientation.Horizontal, "Should be Horizontal.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"LinearLayoutLinearOrientation END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LinearLayout LinearAlignment")]
        [Property("SPEC", "Tizen.NUI.LinearLayout.LinearAlignment A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LinearLayoutLinearAlignment()
        {
            tlog.Debug(tag, $"LinearLayoutLinearAlignment START");

            var testingTarget = new LinearLayout();
            Assert.IsNotNull(testingTarget, "null handle returned");
            Assert.IsInstanceOf<LinearLayout>(testingTarget, "Should return LinearLayout instance.");

            testingTarget.LinearAlignment = LinearLayout.Alignment.End;
            Assert.AreEqual(testingTarget.LinearAlignment, LinearLayout.Alignment.End, "Should be End.");

            testingTarget.LinearAlignment = LinearLayout.Alignment.Center;
            Assert.AreEqual(testingTarget.LinearAlignment, LinearLayout.Alignment.Center, "Should be Center.");

            testingTarget.LinearAlignment = LinearLayout.Alignment.Begin;
            Assert.AreEqual(testingTarget.LinearAlignment, LinearLayout.Alignment.Begin, "Should be Begin.");

            testingTarget.LinearAlignment = LinearLayout.Alignment.CenterHorizontal;
            Assert.AreEqual(testingTarget.LinearAlignment, LinearLayout.Alignment.CenterHorizontal, "Should be CenterHorizontal.");

            testingTarget.LinearAlignment = LinearLayout.Alignment.Top;
            Assert.AreEqual(testingTarget.LinearAlignment, LinearLayout.Alignment.Top, "Should be Top.");

            testingTarget.LinearAlignment = LinearLayout.Alignment.Bottom;
            Assert.AreEqual(testingTarget.LinearAlignment, LinearLayout.Alignment.Bottom, "Should be Bottom.");

            testingTarget.LinearAlignment = LinearLayout.Alignment.CenterVertical;
            Assert.AreEqual(testingTarget.LinearAlignment, LinearLayout.Alignment.CenterVertical, "Should be CenterVertical.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"LinearLayoutLinearAlignment END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LinearLayout cell padding")]
        [Property("SPEC", "Tizen.NUI.LinearLayout.CellPadding A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LinearLayoutCellPadding()
        {
            tlog.Debug(tag, $"LinearLayoutCellPadding START");

            var testingTarget = new LinearLayout();
            Assert.IsNotNull(testingTarget, "null handle returned");
            Assert.IsInstanceOf<LinearLayout>(testingTarget, "Should return LinearLayout instance.");

            testingTarget.CellPadding = new Size2D(6, 8);
            Assert.AreEqual(testingTarget.CellPadding.Width, 6, "Should be equal.");
            Assert.AreEqual(testingTarget.CellPadding.Height, 8, "Should be equal.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"LinearLayoutCellPadding END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LinearLayout OnMeasure")]
        [Property("SPEC", "Tizen.NUI.LinearLayout.OnMeasure M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LinearLayoutOnMeasure()
        {
            tlog.Debug(tag, $"LinearLayoutOnMeasure START");

            flagOnMeasureOverride = false;
            Assert.False(flagOnMeasureOverride, "flagOnMeasureOverride should be false initial");

            LayoutItem layoutItem = new LinearLayout();

            View view = new View()
            {
                ExcludeLayouting = false,
                Weight = 10,
                WidthSpecification = 0,
                HeightSpecification = 0,
                Layout = new LinearLayout()
            };

            layoutItem.AttachToOwner(view);

            var testingTarget = new MyLinearLayout();
            Assert.IsNotNull(testingTarget, "null handle returned");
            Assert.IsInstanceOf<LinearLayout>(testingTarget, "Should be an instance of LinearLayout type.");

            testingTarget.AttachToOwner(view);
            testingTarget.Add(layoutItem);

            MeasureSpecification measureWidth = new MeasureSpecification(new LayoutLength(50.0f), MeasureSpecification.ModeType.Exactly);
            MeasureSpecification measureHeight = new MeasureSpecification(new LayoutLength(50.0f), MeasureSpecification.ModeType.Exactly);

            /** 
             * isExactly is true
             * useExcessSpace is true :(childLayout.Owner.WidthSpecification == 0) && (childWeight > 0)      
             */
            testingTarget.OnMeasureTest(measureWidth, measureHeight);
            Assert.True(flagOnMeasureOverride, "LinearLayout overridden method not invoked.");

            /** 
             * isExactly is false
             * useExcessSpace is true :(childLayout.Owner.WidthSpecification == 0) && (childWeight > 0)      
             */
            flagOnMeasureOverride = false;
            Assert.False(flagOnMeasureOverride, "flagOnMeasureOverride should be false initial");

            MeasureSpecification measureWidth2 = new MeasureSpecification(new LayoutLength(50.0f), MeasureSpecification.ModeType.AtMost);
            MeasureSpecification measureHeight2 = new MeasureSpecification(new LayoutLength(50.0f), MeasureSpecification.ModeType.Unspecified);

            testingTarget.OnMeasureTest(measureWidth2, measureHeight2);
            Assert.True(flagOnMeasureOverride, "LinearLayout overridden method not invoked.");

            /**
             *  matchHeight
             *  heightMode != MeasureSpecification.ModeType.Exactly && childDesiredHeight == LayoutParamPolicies.MatchParent
             */
            view.HeightSpecification = LayoutParamPolicies.MatchParent;
            testingTarget.OnMeasureTest(measureWidth2, measureHeight2);

            /**Test LinearLayout.Orientation.Vertical */
            testingTarget.LinearOrientation = LinearLayout.Orientation.Vertical;
            view.HeightSpecification = 0;

            flagOnMeasureOverride = false;
            Assert.False(flagOnMeasureOverride, "flagOnMeasureOverride should be false initial");

            /** 
             * isExactly is true
             * useExcessSpace is true :(childLayout.Owner.HeightSpecification == 0) && (childWeight > 0)
             */
            testingTarget.OnMeasureTest(measureWidth, measureHeight);
            Assert.True(flagOnMeasureOverride, "LinearLayout overridden method not invoked.");

            flagOnMeasureOverride = false;
            Assert.False(flagOnMeasureOverride, "flagOnMeasureOverride should be false initial");

            /** 
             * isExactly is true
             * useExcessSpace is true :(childLayout.Owner.HeightSpecification == 0) && (childWeight > 0)
             * 
             * matchWidth
             * widthMode != MeasureSpecification.ModeType.Exactly && childDesiredWidth == LayoutParamPolicies.MatchParent
             */
            view.WidthSpecification = LayoutParamPolicies.MatchParent;
            testingTarget.OnMeasureTest(measureWidth2, measureHeight2);
            Assert.True(flagOnMeasureOverride, "LinearLayout overridden method not invoked.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"LinearLayoutOnMeasure END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LinearLayout OnLayout")]
        [Property("SPEC", "Tizen.NUI.LinearLayout.OnLayout M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LinearLayoutOnLayout()
        {
            tlog.Debug(tag, $"LinearLayoutOnLayout START");

            flagOnLayoutOverride = false;
            Assert.False(flagOnLayoutOverride, "flagOnLayoutOverride should be false initial");

            LayoutItem layoutItem = new LinearLayout();

            View view = new View()
            {
                ExcludeLayouting = false,
                Weight = 10,
                WidthSpecification = 0,
                HeightSpecification = 0,
                Layout = new LinearLayout(),
                LayoutDirection = ViewLayoutDirectionType.RTL
            };

            layoutItem.AttachToOwner(view);

            var testingTarget = new MyLinearLayout()
            {
                LinearAlignment = LinearLayout.Alignment.Begin,
            };
            Assert.IsNotNull(testingTarget, "null handle returned");
            Assert.IsInstanceOf<LinearLayout>(testingTarget, "Should be an instance of LinearLayout type.");

            testingTarget.AttachToOwner(view);
            testingTarget.Add(layoutItem);

            testingTarget.OnLayoutTest(true, new LayoutLength(5), new LayoutLength(5), new LayoutLength(10), new LayoutLength(10));
            Assert.True(flagOnLayoutOverride, "LinearLayout overridden method not invoked.");

            /** Alignment.End */
            flagOnLayoutOverride = false;
            Assert.False(flagOnLayoutOverride, "flagOnLayoutOverride should be false initial");

            testingTarget.LinearAlignment = LinearLayout.Alignment.End;

            testingTarget.OnLayoutTest(true, new LayoutLength(5), new LayoutLength(5), new LayoutLength(10), new LayoutLength(10));
            Assert.True(flagOnLayoutOverride, "LinearLayout overridden method not invoked.");

            /** Alignment.CenterHorizontal */
            flagOnLayoutOverride = false;
            Assert.False(flagOnLayoutOverride, "flagOnLayoutOverride should be false initial");

            testingTarget.LinearAlignment = LinearLayout.Alignment.CenterHorizontal;

            testingTarget.OnLayoutTest(true, new LayoutLength(5), new LayoutLength(5), new LayoutLength(10), new LayoutLength(10));
            Assert.True(flagOnLayoutOverride, "LinearLayout overridden method not invoked.");

            /** Alignment.Center */
            flagOnLayoutOverride = false;
            Assert.False(flagOnLayoutOverride, "flagOnLayoutOverride should be false initial");

            testingTarget.LinearAlignment = LinearLayout.Alignment.Center;

            testingTarget.OnLayoutTest(true, new LayoutLength(5), new LayoutLength(5), new LayoutLength(10), new LayoutLength(10));
            Assert.True(flagOnLayoutOverride, "LinearLayout overridden method not invoked.");

            /** Alignment.CenterVertical */
            flagOnLayoutOverride = false;
            Assert.False(flagOnLayoutOverride, "flagOnLayoutOverride should be false initial");

            testingTarget.LinearAlignment = LinearLayout.Alignment.CenterVertical;

            testingTarget.OnLayoutTest(true, new LayoutLength(5), new LayoutLength(5), new LayoutLength(10), new LayoutLength(10));
            Assert.True(flagOnLayoutOverride, "LinearLayout overridden method not invoked.");

            /** Alignment.Bottom */
            flagOnLayoutOverride = false;
            Assert.False(flagOnLayoutOverride, "flagOnLayoutOverride should be false initial");

            testingTarget.LinearAlignment = LinearLayout.Alignment.Bottom;

            testingTarget.OnLayoutTest(true, new LayoutLength(5), new LayoutLength(5), new LayoutLength(10), new LayoutLength(10));
            Assert.True(flagOnLayoutOverride, "LinearLayout overridden method not invoked.");

            /** Alignment.Top */
            flagOnLayoutOverride = false;
            Assert.False(flagOnLayoutOverride, "flagOnLayoutOverride should be false initial");

            testingTarget.LinearAlignment = LinearLayout.Alignment.Top;

            testingTarget.OnLayoutTest(true, new LayoutLength(5), new LayoutLength(5), new LayoutLength(10), new LayoutLength(10));
            Assert.True(flagOnLayoutOverride, "LinearLayout overridden method not invoked.");

            /** Owner.LayoutDirection == ViewLayoutDirectionType.LTR */
            view.LayoutDirection = ViewLayoutDirectionType.LTR;

            flagOnLayoutOverride = false;
            Assert.False(flagOnLayoutOverride, "flagOnLayoutOverride should be false initial");

            testingTarget.OnLayoutTest(true, new LayoutLength(5), new LayoutLength(5), new LayoutLength(10), new LayoutLength(10));
            Assert.True(flagOnLayoutOverride, "LinearLayout overridden method not invoked.");

            /** Alignment.End */
            flagOnLayoutOverride = false;
            Assert.False(flagOnLayoutOverride, "flagOnLayoutOverride should be false initial");

            testingTarget.LinearAlignment = LinearLayout.Alignment.End;

            testingTarget.OnLayoutTest(true, new LayoutLength(5), new LayoutLength(5), new LayoutLength(10), new LayoutLength(10));
            Assert.True(flagOnLayoutOverride, "LinearLayout overridden method not invoked.");

            /** Alignment.CenterHorizontal */
            flagOnLayoutOverride = false;
            Assert.False(flagOnLayoutOverride, "flagOnLayoutOverride should be false initial");

            testingTarget.LinearAlignment = LinearLayout.Alignment.CenterHorizontal;

            testingTarget.OnLayoutTest(true, new LayoutLength(5), new LayoutLength(5), new LayoutLength(10), new LayoutLength(10));
            Assert.True(flagOnLayoutOverride, "LinearLayout overridden method not invoked.");

            /** Alignment.Center */
            flagOnLayoutOverride = false;
            Assert.False(flagOnLayoutOverride, "flagOnLayoutOverride should be false initial");

            testingTarget.LinearAlignment = LinearLayout.Alignment.Center;

            testingTarget.OnLayoutTest(true, new LayoutLength(5), new LayoutLength(5), new LayoutLength(10), new LayoutLength(10));
            Assert.True(flagOnLayoutOverride, "LinearLayout overridden method not invoked.");

            /** Alignment.CenterVertical */
            flagOnLayoutOverride = false;
            Assert.False(flagOnLayoutOverride, "flagOnLayoutOverride should be false initial");

            testingTarget.LinearAlignment = LinearLayout.Alignment.CenterVertical;

            testingTarget.OnLayoutTest(true, new LayoutLength(5), new LayoutLength(5), new LayoutLength(10), new LayoutLength(10));
            Assert.True(flagOnLayoutOverride, "LinearLayout overridden method not invoked.");

            /** Alignment.Bottom */
            flagOnLayoutOverride = false;
            Assert.False(flagOnLayoutOverride, "flagOnLayoutOverride should be false initial");

            testingTarget.LinearAlignment = LinearLayout.Alignment.Bottom;

            testingTarget.OnLayoutTest(true, new LayoutLength(5), new LayoutLength(5), new LayoutLength(10), new LayoutLength(10));
            Assert.True(flagOnLayoutOverride, "LinearLayout overridden method not invoked.");

            /** Alignment.Begin */
            flagOnLayoutOverride = false;
            Assert.False(flagOnLayoutOverride, "flagOnLayoutOverride should be false initial");

            testingTarget.LinearAlignment = LinearLayout.Alignment.Begin;

            testingTarget.OnLayoutTest(true, new LayoutLength(5), new LayoutLength(5), new LayoutLength(10), new LayoutLength(10));
            Assert.True(flagOnLayoutOverride, "LinearLayout overridden method not invoked.");

            /**
             * Test LinearLayout.Orientation.Vertical 
             */
            flagOnLayoutOverride = false;
            Assert.False(flagOnLayoutOverride, "flagOnLayoutOverride should be false initial");

            testingTarget.LinearOrientation = LinearLayout.Orientation.Vertical;

            /** Alignment.Bottom */
            flagOnLayoutOverride = false;
            Assert.False(flagOnLayoutOverride, "flagOnLayoutOverride should be false initial");

            testingTarget.LinearAlignment = LinearLayout.Alignment.Bottom;

            testingTarget.OnLayoutTest(true, new LayoutLength(5), new LayoutLength(5), new LayoutLength(10), new LayoutLength(10));
            Assert.True(flagOnLayoutOverride, "LinearLayout overridden method not invoked.");

            /** Alignment.Center */
            flagOnLayoutOverride = false;
            Assert.False(flagOnLayoutOverride, "flagOnLayoutOverride should be false initial");

            testingTarget.LinearAlignment = LinearLayout.Alignment.Center;

            testingTarget.OnLayoutTest(true, new LayoutLength(5), new LayoutLength(5), new LayoutLength(10), new LayoutLength(10));
            Assert.True(flagOnLayoutOverride, "LinearLayout overridden method not invoked.");

            /** Alignment.End */
            flagOnLayoutOverride = false;
            Assert.False(flagOnLayoutOverride, "flagOnLayoutOverride should be false initial");

            testingTarget.LinearAlignment = LinearLayout.Alignment.End;

            testingTarget.OnLayoutTest(true, new LayoutLength(5), new LayoutLength(5), new LayoutLength(10), new LayoutLength(10));
            Assert.True(flagOnLayoutOverride, "LinearLayout overridden method not invoked.");

            /**Test false method override works with false flag too */
            flagOnLayoutOverride = false;
            Assert.False(flagOnLayoutOverride, "flagOnLayoutOverride should be false initial");

            testingTarget.OnLayoutTest(false, new LayoutLength(10), new LayoutLength(10), new LayoutLength(20), new LayoutLength(20));
            Assert.True(flagOnLayoutOverride, "LinearLayout overridden method not invoked.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"LinearLayoutOnLayout END (OK)");
        }
    }
}
