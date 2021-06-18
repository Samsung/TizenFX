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
    [Description("public/Layouting/AbsoluteLayout")]

    public class PublicAbsoluteLayoutTest
    {
        private const string tag = "NUITEST";
        private static bool flagOnMeasureOverride;
        private static bool flagOnLayoutOverride;
        internal class MyAbsoluteLayout : AbsoluteLayout
        {
            public MyAbsoluteLayout() : base()
            { }

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
        [Description("AbsoluteLayout constructor")]
        [Property("SPEC", "Tizen.NUI.AbsoluteLayout.AbsoluteLayout C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AbsoluteLayoutConstructor()
        {
            tlog.Debug(tag, $"AbsoluteLayoutConstructor START");

            var testingTarget = new AbsoluteLayout();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<AbsoluteLayout>(testingTarget, "Should return AbsoluteLayout instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AbsoluteLayoutConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AbsoluteLayout OnMeasure")]
        [Property("SPEC", "Tizen.NUI.AbsoluteLayout.OnMeasure M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AbsoluteLayoutOnMeasure()
        {
            tlog.Debug(tag, $"AbsoluteLayoutOnMeasure START");

            flagOnMeasureOverride = false;
            Assert.False(flagOnMeasureOverride, "flagOnMeasureOverride should be false initial");

            LayoutItem layoutItem = new LinearLayout();

            View view = new View()
            {
                ExcludeLayouting = false,
                Size = new Size(100, 150),
                Layout = new AbsoluteLayout()
            };

            layoutItem.AttachToOwner(view);

            var testingTarget = new MyAbsoluteLayout();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<AbsoluteLayout>(testingTarget, "Should be an instance of AbsoluteLayout type.");

            testingTarget.AttachToOwner(view);
            testingTarget.Add(layoutItem);

            MeasureSpecification measureWidth = new MeasureSpecification(new LayoutLength(50.0f), MeasureSpecification.ModeType.AtMost);
            MeasureSpecification measureHeight = new MeasureSpecification(new LayoutLength(50.0f), MeasureSpecification.ModeType.AtMost);

            testingTarget.OnMeasureTest(measureWidth, measureHeight);
            Assert.True(flagOnMeasureOverride, "AbsoluteLayout overridden method not invoked.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AbsoluteLayoutOnMeasure END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AbsoluteLayout OnLayout")]
        [Property("SPEC", "Tizen.NUI.AbsoluteLayout.OnLayout M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AbsoluteLayoutOnLayout()
        {
            tlog.Debug(tag, $"AbsoluteLayoutOnLayout START");

            flagOnLayoutOverride = false;
            Assert.False(flagOnLayoutOverride, "flagOnLayoutOverride should be false initial");

            LayoutItem layoutItem = new LinearLayout();

            View view = new View()
            {
                ExcludeLayouting = false,
                Size = new Size(100, 150),
                Layout = new AbsoluteLayout()
            };

            layoutItem.AttachToOwner(view);

            var testingTarget = new MyAbsoluteLayout();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<AbsoluteLayout>(testingTarget, "Should be an instance of AbsoluteLayout type.");

            testingTarget.AttachToOwner(view);
            testingTarget.Add(layoutItem);

            testingTarget.OnLayoutTest(true, new LayoutLength(5), new LayoutLength(5), new LayoutLength(10), new LayoutLength(10));
            Assert.True(flagOnLayoutOverride, "AbsoluteLayout overridden method not invoked.");

            // Test with false parameter
            flagOnLayoutOverride = false;
            Assert.False(flagOnLayoutOverride, "flagOnLayoutOverride should be false initial");
            testingTarget.OnLayoutTest(false, new LayoutLength(5), new LayoutLength(5), new LayoutLength(10), new LayoutLength(10));
            Assert.True(flagOnLayoutOverride, "AbsoluteLayout overridden method not invoked with false parameter.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AbsoluteLayoutOnLayout END (OK)");
        }
    }
}
