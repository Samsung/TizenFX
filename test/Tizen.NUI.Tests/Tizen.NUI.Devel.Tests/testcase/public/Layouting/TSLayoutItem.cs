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
    [Description("public/Layouting/LayoutItem")]
    public class PublicLayoutItemTest
    {
        private const string tag = "NUITEST";
        private static bool flagOnMeasureOverride;
        private static bool flagOnLayoutOverride;
        private static bool flagOnUnparentOverride;
        private static bool flagOnAttachedToOwnerOverride;

        // LayoutGroup used for testing
        private static bool flagOnMeasureLayoutGroupOverride;
        private static bool flagOnLayoutOverrideLayoutGroup;

        internal class MyLayoutItem : LayoutItem
        {
            public MyLayoutItem() : base()
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

            public void OnUnparentTest()
            {
                OnUnparent();
            }
            protected override void OnUnparent()
            {
                flagOnUnparentOverride = true;
                base.OnUnparent();
            }

            public void OnAttachedToOwnerTest()
            {
                OnAttachedToOwner();
            }
            protected override void OnAttachedToOwner()
            {
                flagOnAttachedToOwnerOverride = true;
                base.OnAttachedToOwner();
            }

            public MeasuredSize ResolveSizeAndState(LayoutLength size, MeasureSpecification measureSpecification, MeasuredSize.StateType childMeasuredState)
            {
                return base.ResolveSizeAndState(size, measureSpecification, childMeasuredState);
            }

            public void SetMeasuredDimensions(MeasuredSize measuredWidth, MeasuredSize measuredHeight)
            {
                base.SetMeasuredDimensions(measuredWidth, measuredHeight);
            }
        }

        // LayoutGroup used for testing LayoutItem Layout and Measure functions.
        internal class MyLayoutGroup : LayoutGroup
        {
            public MyLayoutGroup() : base()
            { }

            public int ChildCount()
            {
                return LayoutChildren.Count;
            }

            // This method needs to call protected method, OnMeasure for the test cases.
            public void OnMeasureTest(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
            {
                OnMeasure(widthMeasureSpec, heightMeasureSpec);
            }
            protected override void OnMeasure(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
            {
                flagOnMeasureLayoutGroupOverride = true;
                base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
            }

            public void OnLayoutTest(bool changed, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
            {
                OnLayout(changed, left, top, right, bottom);
            }
            protected override void OnLayout(bool changed, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
            {
                flagOnLayoutOverrideLayoutGroup = true;
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
        [Description("LayoutItem constructor")]
        [Property("SPEC", "Tizen.NUI.LayoutItem.LayoutItem C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutItemConstructor()
        {
            tlog.Debug(tag, $"LayoutItemConstructor START");

            var testingTarget = new LayoutItem();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutItem>(testingTarget, "Should return LayoutItem instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"LayoutItemConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutItem Owner")]
        [Property("SPEC", "Tizen.NUI.LayoutItem.Owner A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutItemOwner()
        {
            tlog.Debug(tag, $"LayoutItemOwner START");

            var testingTarget = new LayoutItem();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutItem>(testingTarget, "Should return LayoutItem instance.");

            View view = new View()
            {
                Layout = testingTarget,
                Name = "parentView"
            };
            Assert.AreEqual(testingTarget.Owner.Name, "parentView", "Should be the parent View.");

            view.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"LayoutItemOwner END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutItem SetPositionByLayout")]
        [Property("SPEC", "Tizen.NUI.LayoutItem.SetPositionByLayout A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutItemSetPositionByLayout()
        {
            tlog.Debug(tag, $"LayoutItemSetPositionByLayout START");

            var testingTarget = new LayoutItem();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutItem>(testingTarget, "Should return LayoutItem instance.");

            Assert.IsTrue(testingTarget.SetPositionByLayout);

            View view = new View()
            {
                ExcludeLayouting = false,
                Size = new Size(100, 150),
                Layout = new LinearLayout()
                {
                    LayoutWithTransition = true
                }
            };
            testingTarget.AttachToOwner(view);

            testingTarget.SetPositionByLayout = false;
            Assert.IsFalse(testingTarget.SetPositionByLayout);
            Assert.IsTrue(testingTarget.Owner.ExcludeLayouting);

            view.Dispose();
            testingTarget?.Dispose();
            tlog.Debug(tag, $"LayoutItemSetPositionByLayout END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutItem Margin")]
        [Property("SPEC", "Tizen.NUI.LayoutItem.Margin A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutItemMargin()
        {
            tlog.Debug(tag, $"LayoutItemMargin START");

            var testingTarget = new LayoutItem();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutItem>(testingTarget, "Should return LayoutItem instance.");

            testingTarget.Margin = new Extents(5, 10, 15, 0);
            Assert.AreEqual(testingTarget.Margin.End, 10, "Should be 10.");
            Assert.AreEqual(testingTarget.Margin.Start, 5, "Should be 5.");
            Assert.AreEqual(testingTarget.Margin.Top, 15, "Should be 15.");
            Assert.AreEqual(testingTarget.Margin.Bottom, 0, "Should be 0.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"LayoutItemMargin END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutItem Padding")]
        [Property("SPEC", "Tizen.NUI.LayoutItem.Padding A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutItemPadding()
        {
            tlog.Debug(tag, $"LayoutItemPadding START");

            var testingTarget = new LayoutItem();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutItem>(testingTarget, "Should return LayoutItem instance.");

            testingTarget.Padding = new Extents(5, 10, 15, 0);
            Assert.AreEqual(testingTarget.Padding.End, 10, "Should be 10.");
            Assert.AreEqual(testingTarget.Padding.Start, 5, "Should be 5.");
            Assert.AreEqual(testingTarget.Padding.Top, 15, "Should be 15.");
            Assert.AreEqual(testingTarget.Padding.Bottom, 0, "Should be 0.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"LayoutItemPadding END (OK)");
        }


        [Test]
        [Category("P1")]
        [Description("LayoutItem SuggestedMinimumWidth")]
        [Property("SPEC", "Tizen.NUI.LayoutItem.SuggestedMinimumWidth A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutItemSuggestedMinimumWidth()
        {
            tlog.Debug(tag, $"LayoutItemSuggestedMinimumWidth START");

            var testingTarget = new LayoutItem();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutItem>(testingTarget, "Should return LayoutItem instance.");

            View view = new View()
            {
                Layout = testingTarget,
                Name = "parentView",
                MinimumSize = new Size2D(10, 10)
            };

            float suggestedMinimumWidth = testingTarget.SuggestedMinimumWidth.AsRoundedValue();
            Assert.AreEqual(suggestedMinimumWidth, 10, "Should be 10.");

            view.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"LayoutItemSuggestedMinimumWidth END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutItem SuggestedMinimumHeight")]
        [Property("SPEC", "Tizen.NUI.LayoutItem.SuggestedMinimumHeight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutItemSuggestedMinimumHeight()
        {
            tlog.Debug(tag, $"LayoutItemSuggestedMinimumHeight START");

            var testingTarget = new LayoutItem();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutItem>(testingTarget, "Should return LayoutItem instance.");

            View view = new View()
            {
                Layout = testingTarget,
                Name = "parentView",
                MinimumSize = new Size2D(10, 10)
            };

            float suggestedMinimumHeight = testingTarget.SuggestedMinimumHeight.AsRoundedValue();
            Assert.AreEqual(suggestedMinimumHeight, 10, "Should be 10.");

            view.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"LayoutItemSuggestedMinimumHeight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutItem MeasuredWidth")]
        [Property("SPEC", "Tizen.NUI.LayoutItem.MeasuredWidth A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutItemMeasuredWidth()
        {
            tlog.Debug(tag, $"LayoutItemMeasuredWidth START");

            var testingTarget = new LayoutItem();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutItem>(testingTarget, "Should return LayoutItem instance.");

            testingTarget.MeasuredWidth = new MeasuredSize(new LayoutLength(100), MeasuredSize.StateType.MeasuredSizeOK);
            Assert.AreEqual(testingTarget.MeasuredWidth.Size.AsRoundedValue(), 100.0, "Should be value set");

            testingTarget.Dispose();
            tlog.Debug(tag, $"LayoutItemMeasuredWidth END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutItem MeasuredHeight")]
        [Property("SPEC", "Tizen.NUI.LayoutItem.MeasuredHeight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutItemMeasuredHeight()
        {
            tlog.Debug(tag, $"LayoutItemMeasuredHeight START");

            var testingTarget = new LayoutItem();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutItem>(testingTarget, "Should return LayoutItem instance.");

            testingTarget.MeasuredHeight = new MeasuredSize(new LayoutLength(100), MeasuredSize.StateType.MeasuredSizeOK);
            Assert.AreEqual(testingTarget.MeasuredHeight.Size.AsRoundedValue(), 100.0, "Should be value set");

            testingTarget.Dispose();
            tlog.Debug(tag, $"LayoutItemMeasuredHeight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutItem GetDefaultSize")]
        [Property("SPEC", "Tizen.NUI.LayoutItem.GetDefaultSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutItemGetDefaultSize()
        {
            tlog.Debug(tag, $"LayoutItemGetDefaultSize START");

            MeasureSpecification measuredLength = new MeasureSpecification(new LayoutLength(50.0f), MeasureSpecification.ModeType.Exactly);
            LayoutLength length = new LayoutLength(10);
            LayoutLength result = LayoutItem.GetDefaultSize(length, measuredLength);
            Assert.AreEqual(50.0f, result.AsRoundedValue(), "Should be value set");

            tlog.Debug(tag, $"LayoutItemGetDefaultSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutItem GetParent")]
        [Property("SPEC", "Tizen.NUI.LayoutItem.GetParent M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutItemGetParent()
        {
            tlog.Debug(tag, $"LayoutItemGetParent START");

            var testingTarget = new LayoutItem();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutItem>(testingTarget, "Should return LayoutItem instance.");
            
            Assert.AreEqual(null, testingTarget.GetParent(), "Should be null if not set");

            testingTarget.Dispose();
            tlog.Debug(tag, $"LayoutItemGetParent END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutItem OnMeasure")]
        [Property("SPEC", "Tizen.NUI.LayoutItem.OnMeasure M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutItemOnMeasure()
        {
            tlog.Debug(tag, $"LayoutItemOnMeasure START");

            flagOnMeasureOverride = false;
            Assert.False(flagOnMeasureOverride, "flagOnMeasureOverride should be false initial");

            var testingTarget = new MyLayoutItem();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutItem>(testingTarget, "Should be an instance of LayoutItem type.");

            View view = new View()
            {
                ExcludeLayouting = false,
                Size = new Size(100, 150)
            };

            testingTarget.AttachToOwner(view);

            MeasureSpecification measureWidth = new MeasureSpecification(new LayoutLength(50.0f), MeasureSpecification.ModeType.Exactly);
            MeasureSpecification measureHeight = new MeasureSpecification(new LayoutLength(50.0f), MeasureSpecification.ModeType.Exactly);

            testingTarget.OnMeasureTest(measureWidth, measureHeight);
            Assert.True(flagOnMeasureOverride, "LayoutItem overridden method not invoked.");

            /** MeasureSpecification.ModeType.Atmost & Unspecified */
            flagOnMeasureOverride = false;
            Assert.False(flagOnMeasureOverride, "flagOnMeasureOverride should be false initial");

            MeasureSpecification measureWidth2 = new MeasureSpecification(new LayoutLength(50.0f), MeasureSpecification.ModeType.AtMost);
            MeasureSpecification measureHeight2 = new MeasureSpecification(new LayoutLength(50.0f), MeasureSpecification.ModeType.Unspecified);

            testingTarget.OnMeasureTest(measureWidth2, measureHeight2);
            Assert.True(flagOnMeasureOverride, "LayoutItem overridden method not invoked.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"LayoutItemOnMeasure END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutItem OnLayout")]
        [Property("SPEC", "Tizen.NUI.LayoutItem.OnLayout M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutItemOnLayout()
        {
            tlog.Debug(tag, $"LayoutItemOnLayout START");

            flagOnLayoutOverride = false;
            Assert.False(flagOnLayoutOverride, "flagOnLayoutOverride should be false initially");

            var testingTarget = new MyLayoutItem();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutItem>(testingTarget, "Should be an instance of LayoutItem type.");

            testingTarget.OnLayoutTest(true, new LayoutLength(5), new LayoutLength(5), new LayoutLength(10), new LayoutLength(10));
            Assert.True(flagOnLayoutOverride, "LayoutItem overridden method not invoked.");

            // Test with false parameter
            flagOnLayoutOverride = false;
            Assert.False(flagOnLayoutOverride, "flagOnLayoutOverride should be false initially");

            testingTarget.OnLayoutTest(false, new LayoutLength(5), new LayoutLength(5), new LayoutLength(10), new LayoutLength(10));
            Assert.True(flagOnLayoutOverride, "LayoutItem overridden method not invoked with false parameter.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"LayoutItemOnLayout END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutItem OnUnparent")]
        [Property("SPEC", "Tizen.NUI.LayoutItem.OnUnparent M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutItemOnUnparent()
        {
            tlog.Debug(tag, $"LayoutItemOnUnparent START");

            flagOnUnparentOverride = false;
            Assert.False(flagOnUnparentOverride, "flag should be false initially");

            var testingTarget = new MyLayoutItem();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutItem>(testingTarget, "Should be an instance of LayoutItem type.");

            testingTarget.OnUnparentTest();
            Assert.True(flagOnUnparentOverride, "LayoutItem overridden method not invoked.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"LayoutItemOnUnparent END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutItem OnAttachedToOwner")]
        [Property("SPEC", "Tizen.NUI.LayoutItem.OnAttachedToOwner M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutItemOnAttachedToOwner()
        {
            tlog.Debug(tag, $"LayoutItemOnAttachedToOwner START");

            flagOnAttachedToOwnerOverride = false;
            Assert.False(flagOnAttachedToOwnerOverride, "flag should be false initially");

            var testingTarget = new MyLayoutItem();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutItem>(testingTarget, "Should be an instance of LayoutItem type.");

            testingTarget.OnAttachedToOwnerTest();
            Assert.True(flagOnAttachedToOwnerOverride, "LayoutItem overridden method not invoked.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"LayoutItemOnAttachedToOwner END (OK)");
        }


        [Test]
        [Category("P1")]
        [Description("LayoutItem ResolveSizeAndSize")]
        [Property("SPEC", "Tizen.NUI.LayoutItem.ResolveSizeAndState M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutItemResolveSizeAndState()
        {
            tlog.Debug(tag, $"LayoutItemResolveSizeAndState START");

            var testingTarget = new MyLayoutItem();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutItem>(testingTarget, "Should be an instance of LayoutItem type.");

            MeasureSpecification measureSpec = new MeasureSpecification(new LayoutLength(10), MeasureSpecification.ModeType.Exactly);

            MeasuredSize measuredSize = testingTarget.ResolveSizeAndState(new LayoutLength(50), measureSpec, MeasuredSize.StateType.MeasuredSizeOK);

            Assert.AreEqual(measureSpec.GetSize().AsRoundedValue(), 10, "measuredSize not resolved correctly");

            testingTarget.Dispose();
            tlog.Debug(tag, $"LayoutItemResolveSizeAndState END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutItem SetMeasuredDimensions")]
        [Property("SPEC", "Tizen.NUI.LayoutItem.SetMeasuredDimensions M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutItemSetMeasuredDimensions()
        {
            tlog.Debug(tag, $"LayoutItemSetMeasuredDimensions START");

            var testingTarget = new MyLayoutItem();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutItem>(testingTarget, "Should be an instance of LayoutItem type.");

            MeasuredSize measuredWidth = new MeasuredSize(new LayoutLength(100), MeasuredSize.StateType.MeasuredSizeOK);
            MeasuredSize measuredHeight = new MeasuredSize(new LayoutLength(50), MeasuredSize.StateType.MeasuredSizeOK);

            testingTarget.SetMeasuredDimensions(measuredWidth, measuredHeight);

            Assert.AreEqual(100, testingTarget.MeasuredWidth.Size.AsRoundedValue(), "Should be value set");
            Assert.AreEqual(50, testingTarget.MeasuredHeight.Size.AsRoundedValue(), "Should be value set");

            testingTarget.Dispose();
            tlog.Debug(tag, $"LayoutItemSetMeasuredDimensions END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutItem RequestLayout")]
        [Property("SPEC", "Tizen.NUI.LayoutItem.RequestLayout M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutItemRequestLayout()
        {
            tlog.Debug(tag, $"LayoutItemRequestLayout START");

            var testingTarget = new LayoutItem();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutItem>(testingTarget, "Should be an instance of LayoutGroup type.");

            LayoutGroup layoutGroup = new LayoutGroup();
            testingTarget.SetParent(layoutGroup);

            try
            {
                testingTarget.RequestLayout(); // Ensures a layout pass is needed.
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            layoutGroup.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"LayoutItemRequestLayout END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutItem Measure")]
        [Property("SPEC", "Tizen.NUI.LayoutItem.Measure M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutItemMeasure()
        {
            tlog.Debug(tag, $"LayoutItemMeasure START");

            var testingTarget = new MyLayoutItem();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutItem>(testingTarget, "Should be an instance of LayoutGroup type.");

            View view = new View()
            {
                ExcludeLayouting = false,
                Size = new Size(100, 150)
            };
            testingTarget.AttachToOwner(view);

            LayoutGroup layoutGroup = new LayoutGroup();
            testingTarget.SetParent(layoutGroup);

            testingTarget.RequestLayout(); // Ensures a layout pass is needed.

            MeasureSpecification imposedWidth = new MeasureSpecification(new LayoutLength(300.0f), MeasureSpecification.ModeType.Exactly);
            MeasureSpecification imposedHeight = new MeasureSpecification(new LayoutLength(300.0f), MeasureSpecification.ModeType.Exactly);
            try
            {
                testingTarget.Measure(imposedWidth, imposedHeight);
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            layoutGroup.Dispose();
            testingTarget.Dispose();
            view.Dispose();
            tlog.Debug(tag, $"LayoutItemMeasure END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutItem Layout")]
        [Property("SPEC", "Tizen.NUI.LayoutItem.Layout M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutItemLayout()
        {
            tlog.Debug(tag, $"LayoutItemLayout START");

            var testingTarget = new MyLayoutItem();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutItem>(testingTarget, "Should be an instance of LayoutGroup type.");

            View view = new View()
            {
                ExcludeLayouting = false,
                Size = new Size(100, 150),
                Layout = new LinearLayout()
                {
                    LayoutWithTransition = true
                }
            };
            testingTarget.AttachToOwner(view);

            try
            {
                testingTarget.Layout(new LayoutLength(0), new LayoutLength(10), new LayoutLength(0), new LayoutLength(5));
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            view.Dispose();
            testingTarget?.Dispose();
            tlog.Debug(tag, $"LayoutItemLayout END (OK)");
        }
    }
}
