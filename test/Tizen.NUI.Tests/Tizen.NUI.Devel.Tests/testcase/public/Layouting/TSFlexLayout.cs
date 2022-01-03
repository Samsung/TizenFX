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
    [Description("public/Layouting/FlexLayout")]
    public class PublicFlexLayoutTest
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

        private static bool flagOnMeasureOverride;
        private static bool flagOnLayoutOverride;
        private static bool flagOnChildAddOverride;
        private static bool flagOnChildRemoveOverride;
        internal class MyFlexLayout : FlexLayout
        {
            public MyFlexLayout() : base()
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

            public void OnChildAddTest(LayoutItem child)
            {
                OnChildAdd(child);
            }
            protected override void OnChildAdd(LayoutItem child)
            {
                flagOnChildAddOverride = true;
                base.OnChildAdd(child);
            }

            public void OnChildRemoveTest(LayoutItem child)
            {
                OnChildRemove(child);
            }
            protected override void OnChildRemove(LayoutItem child)
            {
                flagOnChildRemoveOverride = true;
                base.OnChildRemove(child);
            }
        }

        [Test]
        [Category("P1")]
        [Description("FlexLayout constructor")]
        [Property("SPEC", "Tizen.NUI.FlexLayout.FlexLayout C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FlexLayoutConstructor()
        {
            tlog.Debug(tag, $"FlexLayoutConstructor START");

            var testingTarget = new FlexLayout();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<FlexLayout>(testingTarget, "Should return FlexLayout instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"FlexLayoutConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexLayout SetFlexAlignmentSelf")]
        [Property("SPEC", "Tizen.NUI.FlexLayout.SetFlexAlignmentSelf M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FlexLayoutSetFlexAlignmentSelf()
        {
            tlog.Debug(tag, $"FlexLayoutSetFlexAlignmentSelf START");

            View view = new View()
            {
                Size = new Size(400, 400),
                BackgroundColor = Color.White,
                Layout = new FlexLayout()
                {
                    Direction = FlexLayout.FlexDirection.Column,
                }
            };

            try
            {
                FlexLayout.SetFlexAlignmentSelf(view, FlexLayout.AlignmentType.FlexStart);
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            view.Dispose();
            tlog.Debug(tag, $"FlexLayoutSetFlexAlignmentSelf END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexLayout GetFlexAlignmentSelf")]
        [Property("SPEC", "Tizen.NUI.FlexLayout.GetFlexAlignmentSelf M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FlexLayoutGetFlexAlignmentSelf()
        {
            tlog.Debug(tag, $"FlexLayoutGetFlexAlignmentSelf START");

            View view = new View()
            {
                Size = new Size(400, 400),
                BackgroundColor = Color.White,
                Layout = new FlexLayout()
                {
                    Direction = FlexLayout.FlexDirection.Column,
                }
            };

            FlexLayout.SetFlexAlignmentSelf(view, FlexLayout.AlignmentType.FlexStart);
            var result = FlexLayout.GetFlexAlignmentSelf(view);
            Assert.AreEqual(FlexLayout.AlignmentType.FlexStart, result, "should be equal!");

            view.Dispose();
            tlog.Debug(tag, $"FlexLayoutGetFlexAlignmentSelf END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexLayout SetFlexPositionType")]
        [Property("SPEC", "Tizen.NUI.FlexLayout.SetFlexPositionType M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FlexLayoutSetFlexPositionType()
        {
            tlog.Debug(tag, $"FlexLayoutSetFlexPositionType START");

            View view = new View()
            {
                Size = new Size(400, 400),
                BackgroundColor = Color.White,
                Layout = new FlexLayout()
                {
                    Direction = FlexLayout.FlexDirection.Column,
                }
            };

            try
            {
                FlexLayout.SetFlexPositionType(view, FlexLayout.PositionType.Relative);
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            view.Dispose();
            tlog.Debug(tag, $"FlexLayoutSetFlexPositionType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexLayout GetFlexPositionType")]
        [Property("SPEC", "Tizen.NUI.FlexLayout.GetFlexPositionType M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FlexLayoutGetFlexPositionType()
        {
            tlog.Debug(tag, $"FlexLayoutGetFlexPositionType START");

            View view = new View()
            {
                Size = new Size(400, 400),
                BackgroundColor = Color.White,
                Layout = new FlexLayout()
                {
                    Direction = FlexLayout.FlexDirection.Column,
                }
            };

            FlexLayout.SetFlexPositionType(view, FlexLayout.PositionType.Relative);
            var result = FlexLayout.GetFlexPositionType(view);
            Assert.AreEqual(FlexLayout.PositionType.Relative, result, "should be equal!");

            view.Dispose();
            tlog.Debug(tag, $"FlexLayoutGetFlexPositionType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexLayout SetFlexAspectRatio")]
        [Property("SPEC", "Tizen.NUI.FlexLayout.SetFlexAspectRatio M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FlexLayoutSetFlexAspectRatio()
        {
            tlog.Debug(tag, $"FlexLayoutSetFlexAspectRatio START");

            View view = new View()
            {
                Size = new Size(400, 400),
                BackgroundColor = Color.White,
                Layout = new FlexLayout()
                {
                    Direction = FlexLayout.FlexDirection.Column,
                }
            };

            try
            {
                FlexLayout.SetFlexAspectRatio(view, 0.3f);
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            view.Dispose();
            tlog.Debug(tag, $"FlexLayoutSetFlexAspectRatio END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexLayout GetFlexAspectRatio")]
        [Property("SPEC", "Tizen.NUI.FlexLayout.GetFlexAspectRatio M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FlexLayoutGetFlexAspectRatio()
        {
            tlog.Debug(tag, $"FlexLayoutGetFlexAspectRatio START");

            View view = new View()
            {
                Size = new Size(400, 400),
                BackgroundColor = Color.White,
                Layout = new FlexLayout()
                {
                    Direction = FlexLayout.FlexDirection.Column,
                }
            };

            FlexLayout.SetFlexAspectRatio(view, 0.3f);
            var result = FlexLayout.GetFlexAspectRatio(view);
            Assert.AreEqual(0.3f, result, "should be equal!");

            view.Dispose();
            tlog.Debug(tag, $"FlexLayoutGetFlexAspectRatio END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexLayout SetFlexBasis")]
        [Property("SPEC", "Tizen.NUI.FlexLayout.SetFlexBasis M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FlexLayoutSetFlexBasis()
        {
            tlog.Debug(tag, $"FlexLayoutSetFlexBasis START");

            View view = new View()
            {
                Size = new Size(400, 400),
                BackgroundColor = Color.White,
                Layout = new FlexLayout()
                {
                    Direction = FlexLayout.FlexDirection.Column,
                }
            };

            try
            {
                FlexLayout.SetFlexBasis(view, 0.6f);
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            view.Dispose();
            tlog.Debug(tag, $"FlexLayoutSetFlexBasis END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexLayout GetFlexBasis")]
        [Property("SPEC", "Tizen.NUI.FlexLayout.GetFlexBasis M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FlexLayoutGetFlexBasis()
        {
            tlog.Debug(tag, $"FlexLayoutGetFlexBasis START");

            View view = new View()
            {
                Size = new Size(400, 400),
                BackgroundColor = Color.White,
                Layout = new FlexLayout()
                {
                    Direction = FlexLayout.FlexDirection.Column,
                }
            };

            FlexLayout.SetFlexBasis(view, 0.6f);
            var result = FlexLayout.GetFlexBasis(view);
            Assert.AreEqual(0.6f, result, "should be equal!");

            view.Dispose();
            tlog.Debug(tag, $"FlexLayoutGetFlexBasis END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexLayout SetFlexShrink")]
        [Property("SPEC", "Tizen.NUI.FlexLayout.SetFlexShrink M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FlexLayoutSetFlexShrink()
        {
            tlog.Debug(tag, $"FlexLayoutSetFlexShrink START");

            View view = new View()
            {
                Size = new Size(400, 400),
                BackgroundColor = Color.White,
                Layout = new FlexLayout()
                {
                    Direction = FlexLayout.FlexDirection.Column,
                }
            };

            try
            {
                FlexLayout.SetFlexShrink(view, 0.9f);
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            view.Dispose();
            tlog.Debug(tag, $"FlexLayoutSetFlexShrink END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexLayout GetFlexShrink")]
        [Property("SPEC", "Tizen.NUI.FlexLayout.GetFlexShrink M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FlexLayoutGetFlexShrink()
        {
            tlog.Debug(tag, $"FlexLayoutGetFlexShrink START");

            View view = new View()
            {
                Size = new Size(400, 400),
                BackgroundColor = Color.White,
                Layout = new FlexLayout()
                {
                    Direction = FlexLayout.FlexDirection.Column,
                }
            };

            FlexLayout.SetFlexShrink(view, 0.9f);
            var result = FlexLayout.GetFlexShrink(view);
            Assert.AreEqual(0.9f, result, "should be equal!");

            view.Dispose();
            tlog.Debug(tag, $"FlexLayoutGetFlexShrink END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexLayout SetFlexGrow")]
        [Property("SPEC", "Tizen.NUI.FlexLayout.SetFlexGrow M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FlexLayoutSetFlexGrow()
        {
            tlog.Debug(tag, $"FlexLayoutSetFlexGrow START");

            View view = new View()
            {
                Size = new Size(400, 400),
                BackgroundColor = Color.White,
                Layout = new FlexLayout()
                {
                    Direction = FlexLayout.FlexDirection.Column,
                }
            };

            try
            {
                FlexLayout.SetFlexGrow(view, 0.2f);
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            view.Dispose();
            tlog.Debug(tag, $"FlexLayoutSetFlexGrow END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexLayout GetFlexGrow")]
        [Property("SPEC", "Tizen.NUI.FlexLayout.GetFlexGrow M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FlexLayoutGetFlexGrow()
        {
            tlog.Debug(tag, $"FlexLayoutGetFlexGrow START");

            View view = new View()
            {
                Size = new Size(400, 400),
                BackgroundColor = Color.White,
                Layout = new FlexLayout()
                {
                    Direction = FlexLayout.FlexDirection.Column,
                }
            };

            FlexLayout.SetFlexGrow(view, 0.2f);
            var result = FlexLayout.GetFlexGrow(view);
            Assert.AreEqual(0.2f, result, "should be equal!");

            view.Dispose();
            tlog.Debug(tag, $"FlexLayoutGetFlexGrow END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexLayout Direction")]
        [Property("SPEC", "Tizen.NUI.FlexLayout.Direction A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FlexLayoutDirection()
        {
            tlog.Debug(tag, $"FlexLayoutDirection START");

            var testingTarget = new FlexLayout();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<FlexLayout>(testingTarget, "Should return FlexLayout instance.");

            testingTarget.Direction = FlexLayout.FlexDirection.Column;
            Assert.AreEqual(testingTarget.Direction, FlexLayout.FlexDirection.Column, "Should be Column.");

            testingTarget.Direction = FlexLayout.FlexDirection.Row;
            Assert.AreEqual(testingTarget.Direction, FlexLayout.FlexDirection.Row, "Should be Row.");

            testingTarget.Direction = FlexLayout.FlexDirection.ColumnReverse;
            Assert.AreEqual(testingTarget.Direction, FlexLayout.FlexDirection.ColumnReverse, "Should be ColumnReverse.");

            testingTarget.Direction = FlexLayout.FlexDirection.RowReverse;
            Assert.AreEqual(testingTarget.Direction, FlexLayout.FlexDirection.RowReverse, "Should be RowReverse.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"FlexLayoutDirection END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexLayout Justification")]
        [Property("SPEC", "Tizen.NUI.FlexLayout.Justification A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FlexLayoutJustification()
        {
            tlog.Debug(tag, $"FlexLayoutJustification START");

            var testingTarget = new FlexLayout();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<FlexLayout>(testingTarget, "Should return FlexLayout instance.");

            testingTarget.Justification = FlexLayout.FlexJustification.FlexStart;
            Assert.AreEqual(testingTarget.Justification, FlexLayout.FlexJustification.FlexStart, "Should be FlexStart.");

            testingTarget.Justification = FlexLayout.FlexJustification.FlexEnd;
            Assert.AreEqual(testingTarget.Justification, FlexLayout.FlexJustification.FlexEnd, "Should be FlexEnd.");

            testingTarget.Justification = FlexLayout.FlexJustification.Center;
            Assert.AreEqual(testingTarget.Justification, FlexLayout.FlexJustification.Center, "Should be Center.");

            testingTarget.Justification = FlexLayout.FlexJustification.SpaceBetween;
            Assert.AreEqual(testingTarget.Justification, FlexLayout.FlexJustification.SpaceBetween, "Should be SpaceBetween.");

            testingTarget.Justification = FlexLayout.FlexJustification.SpaceAround;
            Assert.AreEqual(testingTarget.Justification, FlexLayout.FlexJustification.SpaceAround, "Should be SpaceAround.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"FlexLayoutJustification END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexLayout WrapType")]
        [Property("SPEC", "Tizen.NUI.FlexLayout.WrapType A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FlexLayoutWrapType()
        {
            tlog.Debug(tag, $"FlexLayoutWrapType START");

            var testingTarget = new FlexLayout();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<FlexLayout>(testingTarget, "Should return FlexLayout instance.");

            testingTarget.WrapType = FlexLayout.FlexWrapType.NoWrap;
            Assert.AreEqual(testingTarget.WrapType, FlexLayout.FlexWrapType.NoWrap, "Should be NoWrap.");

            testingTarget.WrapType = FlexLayout.FlexWrapType.Wrap;
            Assert.AreEqual(testingTarget.WrapType, FlexLayout.FlexWrapType.Wrap, "Should be Wrap.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"FlexLayoutWrapType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexLayout Alignment")]
        [Property("SPEC", "Tizen.NUI.FlexLayout.Alignment A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FlexLayoutAlignment()
        {
            tlog.Debug(tag, $"FlexLayoutAlignment START");

            var testingTarget = new FlexLayout();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<FlexLayout>(testingTarget, "Should return FlexLayout instance.");

            testingTarget.Alignment = FlexLayout.AlignmentType.FlexStart;
            Assert.AreEqual(testingTarget.Alignment, FlexLayout.AlignmentType.FlexStart, "Should be FlexStart.");

            testingTarget.Alignment = FlexLayout.AlignmentType.FlexEnd;
            Assert.AreEqual(testingTarget.Alignment, FlexLayout.AlignmentType.FlexEnd, "Should be FlexEnd.");

            testingTarget.Alignment = FlexLayout.AlignmentType.Auto;
            Assert.AreEqual(testingTarget.Alignment, FlexLayout.AlignmentType.Auto, "Should be Auto.");

            testingTarget.Alignment = FlexLayout.AlignmentType.Center;
            Assert.AreEqual(testingTarget.Alignment, FlexLayout.AlignmentType.Center, "Should be Center.");

            testingTarget.Alignment = FlexLayout.AlignmentType.Stretch;
            Assert.AreEqual(testingTarget.Alignment, FlexLayout.AlignmentType.Stretch, "Should be Stretch.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"FlexLayoutAlignment END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexLayout ItemsAlignment")]
        [Property("SPEC", "Tizen.NUI.FlexLayout.ItemsAlignment A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FlexLayoutItemsAlignment()
        {
            tlog.Debug(tag, $"FlexLayoutItemsAlignment START");

            var testingTarget = new FlexLayout();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<FlexLayout>(testingTarget, "Should return FlexLayout instance.");

            testingTarget.ItemsAlignment = FlexLayout.AlignmentType.FlexStart;
            Assert.AreEqual(testingTarget.ItemsAlignment, FlexLayout.AlignmentType.FlexStart, "Should be FlexStart.");

            testingTarget.ItemsAlignment = FlexLayout.AlignmentType.FlexEnd;
            Assert.AreEqual(testingTarget.ItemsAlignment, FlexLayout.AlignmentType.FlexEnd, "Should be FlexEnd.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"FlexLayoutItemsAlignment END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexLayout OnMeasure")]
        [Property("SPEC", "Tizen.NUI.FlexLayout.OnMeasure M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FlexLayoutOnMeasure()
        {
            tlog.Debug(tag, $"FlexLayoutOnMeasure START");

            flagOnMeasureOverride = false;
            Assert.False(flagOnMeasureOverride, "flagOnMeasureOverride should be false initial");

            LayoutItem layoutItem = new LinearLayout();

            View view = new View()
            {
                ExcludeLayouting = false,
                Size = new Size(100, 150),
                Layout = new FlexLayout()
            };

            layoutItem.AttachToOwner(view);

            var testingTarget = new MyFlexLayout();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<FlexLayout>(testingTarget, "Should be an instance of FlexLayout type.");

            testingTarget.AttachToOwner(view);
            testingTarget.Add(layoutItem);

            MeasureSpecification measureWidth = new MeasureSpecification(new LayoutLength(50.0f), MeasureSpecification.ModeType.Exactly);
            MeasureSpecification measureHeight = new MeasureSpecification(new LayoutLength(50.0f), MeasureSpecification.ModeType.AtMost);

            testingTarget.OnMeasureTest(measureWidth, measureHeight);
            Assert.True(flagOnMeasureOverride, "FlexLayout overridden method not invoked.");

            tlog.Debug(tag, $"FlexLayoutOnMeasure END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexLayout OnLayout")]
        [Property("SPEC", "Tizen.NUI.FlexLayout.OnLayout M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FlexLayoutOnLayout()
        {
            tlog.Debug(tag, $"FlexLayoutOnLayout START");

            flagOnLayoutOverride = false;
            Assert.False(flagOnLayoutOverride, "flagOnLayoutOverride should be false initial");

            LayoutItem layoutItem = new LinearLayout();

            View view = new View()
            {
                ExcludeLayouting = false,
                Size = new Size(100, 150),
                Layout = new FlexLayout()
            };

            layoutItem.AttachToOwner(view);

            var testingTarget = new MyFlexLayout();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<FlexLayout>(testingTarget, "Should be an instance of FlexLayout type.");

            testingTarget.AttachToOwner(view);
            testingTarget.Add(layoutItem);

            testingTarget.OnLayoutTest(true, new LayoutLength(5), new LayoutLength(5), new LayoutLength(10), new LayoutLength(10));
            Assert.True(flagOnLayoutOverride, "FlexLayout overridden method not invoked.");

            // Test with false parameter
            flagOnLayoutOverride = false;
            Assert.False(flagOnLayoutOverride, "flagOnLayoutOverride should be false initial");
            testingTarget.OnLayoutTest(false, new LayoutLength(5), new LayoutLength(5), new LayoutLength(10), new LayoutLength(10));
            Assert.True(flagOnLayoutOverride, "FlexLayout overridden method not invoked with false parameter.");

            tlog.Debug(tag, $"FlexLayoutOnLayout END (OK)");
        }
    }
}
