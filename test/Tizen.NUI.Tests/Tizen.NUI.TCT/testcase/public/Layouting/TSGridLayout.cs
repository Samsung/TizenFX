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
    [Description("public/Layouting/GridLayout")]
    public class PublicGridLayoutTest
    {
        private const string tag = "NUITEST";
        private static bool flagOnMeasureOverride;
        private static bool flagOnLayoutOverride;
        internal class MyGridLayout : GridLayout
        {
            public MyGridLayout() : base()
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
        [Description("GridLayout constructor")]
        [Property("SPEC", "Tizen.NUI.GridLayout.GridLayout C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GridLayoutConstructor()
        {
            tlog.Debug(tag, $"GridLayoutConstructor START");

            var testingTarget = new GridLayout();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<GridLayout>(testingTarget, "Should return GridLayout instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"GridLayoutConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GridLayout SetColumn")]
        [Property("SPEC", "Tizen.NUI.GridLayout.SetColumn M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GridLayoutSetColumn()
        {
            tlog.Debug(tag, $"GridLayoutSetColumn START");

            View view = new View()
            {
                Size = new Size(400, 400),
                BackgroundColor = Color.White,
                Layout = new GridLayout()
                {
                    GridOrientation = GridLayout.Orientation.Horizontal
                }
            };

            try 
            {
                GridLayout.SetColumn(view, 3);
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
            
            tlog.Debug(tag, $"GridLayoutSetColumn END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GridLayout GetColumn")]
        [Property("SPEC", "Tizen.NUI.GridLayout.GetColumn M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GridLayoutGetColumn()
        {
            tlog.Debug(tag, $"GridLayoutGetColumn START");

            View view = new View()
            {
                Size = new Size(400, 400),
                BackgroundColor = Color.White,
                Layout = new GridLayout()
                {
                    GridOrientation = GridLayout.Orientation.Horizontal
                }
            };

            GridLayout.SetColumn(view, 3);
            Assert.AreEqual(3, GridLayout.GetColumn(view), "should be equal!");

            tlog.Debug(tag, $"GridLayoutGetColumn END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GridLayout SetColumnSpan")]
        [Property("SPEC", "Tizen.NUI.GridLayout.SetColumnSpan M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GridLayoutSetColumnSpan()
        {
            tlog.Debug(tag, $"GridLayoutSetColumnSpan START");

            View view = new View()
            {
                Size = new Size(400, 400),
                BackgroundColor = Color.White,
                Layout = new GridLayout()
                {
                    GridOrientation = GridLayout.Orientation.Horizontal
                }
            };

            try
            {
                GridLayout.SetColumnSpan(view, 10);
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"GridLayoutSetColumnSpan END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GridLayout GetColumnSpan")]
        [Property("SPEC", "Tizen.NUI.GridLayout.GetColumnSpan M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GridLayoutGetColumnSpan()
        {
            tlog.Debug(tag, $"GridLayoutGetColumnSpan START");

            View view = new View()
            {
                Size = new Size(400, 400),
                BackgroundColor = Color.White,
                Layout = new GridLayout()
                {
                    GridOrientation = GridLayout.Orientation.Horizontal
                }
            };

            GridLayout.SetColumnSpan(view, 10);
            Assert.AreEqual(10, GridLayout.GetColumnSpan(view), "should be equal!");

            tlog.Debug(tag, $"GridLayoutGetColumnSpan END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GridLayout SetRow")]
        [Property("SPEC", "Tizen.NUI.GridLayout.SetRow M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GridLayoutSetRow()
        {
            tlog.Debug(tag, $"GridLayoutSetRow START");

            View view = new View()
            {
                Size = new Size(400, 400),
                BackgroundColor = Color.White,
                Layout = new GridLayout()
                {
                    GridOrientation = GridLayout.Orientation.Horizontal
                }
            };

            try
            {
                GridLayout.SetRow(view, 2);
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"GridLayoutSetRow END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GridLayout GetRow")]
        [Property("SPEC", "Tizen.NUI.GridLayout.GetRow M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GridLayoutGetRow()
        {
            tlog.Debug(tag, $"GridLayoutGetRow START");

            View view = new View()
            {
                Size = new Size(400, 400),
                BackgroundColor = Color.White,
                Layout = new GridLayout()
                {
                    GridOrientation = GridLayout.Orientation.Horizontal
                }
            };

            GridLayout.SetRow(view, 2);
            Assert.AreEqual(2, GridLayout.GetRow(view), "should be equal!");

            tlog.Debug(tag, $"GridLayoutGetRow END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GridLayout SetRowSpan")]
        [Property("SPEC", "Tizen.NUI.GridLayout.SetRowSpan M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GridLayoutSetRowSpan()
        {
            tlog.Debug(tag, $"GridLayoutSetRowSpan START");

            View view = new View()
            {
                Size = new Size(400, 400),
                BackgroundColor = Color.White,
                Layout = new GridLayout()
                {
                    GridOrientation = GridLayout.Orientation.Horizontal
                }
            };

            try
            {
                GridLayout.SetRowSpan(view, 5);
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"GridLayoutSetRowSpan END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GridLayout GetRowSpan")]
        [Property("SPEC", "Tizen.NUI.GridLayout.GetRowSpan M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GridLayoutGetRowSpan()
        {
            tlog.Debug(tag, $"GridLayoutGetRowSpan START");

            View view = new View()
            {
                Size = new Size(400, 400),
                BackgroundColor = Color.White,
                Layout = new GridLayout()
                {
                    GridOrientation = GridLayout.Orientation.Horizontal
                }
            };

            GridLayout.SetRowSpan(view, 5);
            Assert.AreEqual(5, GridLayout.GetRowSpan(view), "should be equal!");

            tlog.Debug(tag, $"GridLayoutGetRowSpan END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GridLayout SetHorizontalStretch")]
        [Property("SPEC", "Tizen.NUI.GridLayout.SetHorizontalStretch M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GridLayoutSetHorizontalStretch()
        {
            tlog.Debug(tag, $"GridLayoutSetHorizontalStretch START");

            View view = new View()
            {
                Size = new Size(400, 400),
                BackgroundColor = Color.White,
                Layout = new GridLayout()
                {
                    GridOrientation = GridLayout.Orientation.Horizontal
                }
            };

            try
            {
                GridLayout.SetHorizontalStretch(view, GridLayout.StretchFlags.Fill);
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"GridLayoutSetHorizontalStretch END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GridLayout GetHorizontalStretch")]
        [Property("SPEC", "Tizen.NUI.GridLayout.GetHorizontalStretch M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GridLayoutGetHorizontalStretch()
        {
            tlog.Debug(tag, $"GridLayoutGetHorizontalStretch START");

            View view = new View()
            {
                Size = new Size(400, 400),
                BackgroundColor = Color.White,
                Layout = new GridLayout()
                {
                    GridOrientation = GridLayout.Orientation.Horizontal
                }
            };

            GridLayout.SetHorizontalStretch(view, GridLayout.StretchFlags.Fill);
            Assert.AreEqual(GridLayout.StretchFlags.Fill, GridLayout.GetHorizontalStretch(view), "should be equal!");

            tlog.Debug(tag, $"GridLayoutGetHorizontalStretch END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GridLayout SetVerticalStretch")]
        [Property("SPEC", "Tizen.NUI.GridLayout.SetVerticalStretch M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GridLayoutSetVerticalStretch()
        {
            tlog.Debug(tag, $"GridLayoutSetVerticalStretch START");

            View view = new View()
            {
                Size = new Size(400, 400),
                BackgroundColor = Color.White,
                Layout = new GridLayout()
                {
                    GridOrientation = GridLayout.Orientation.Horizontal
                }
            };

            try
            {
                GridLayout.SetVerticalStretch(view, GridLayout.StretchFlags.Expand);
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"GridLayoutSetVerticalStretch END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GridLayout GetVerticalStretch")]
        [Property("SPEC", "Tizen.NUI.GridLayout.GetVerticalStretch M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GridLayoutGetVerticalStretch()
        {
            tlog.Debug(tag, $"GridLayoutGetVerticalStretch START");

            View view = new View()
            {
                Size = new Size(400, 400),
                BackgroundColor = Color.White,
                Layout = new GridLayout()
                {
                    GridOrientation = GridLayout.Orientation.Horizontal
                }
            };

            GridLayout.SetVerticalStretch(view, GridLayout.StretchFlags.Expand);
            Assert.AreEqual(GridLayout.StretchFlags.Expand, GridLayout.GetVerticalStretch(view), "should be equal!");

            tlog.Debug(tag, $"GridLayoutGetVerticalStretch END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GridLayout SetHorizontalAlignment")]
        [Property("SPEC", "Tizen.NUI.GridLayout.SetHorizontalAlignment M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GridLayoutSetHorizontalAlignment()
        {
            tlog.Debug(tag, $"GridLayoutSetHorizontalAlignment START");

            View view = new View()
            {
                Size = new Size(400, 400),
                BackgroundColor = Color.White,
                Layout = new GridLayout()
                {
                    GridOrientation = GridLayout.Orientation.Horizontal
                }
            };

            try
            {
                GridLayout.SetHorizontalAlignment(view, GridLayout.Alignment.Start);
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"GridLayoutSetHorizontalAlignment END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GridLayout GetHorizontalAlignment")]
        [Property("SPEC", "Tizen.NUI.GridLayout.GetHorizontalAlignment M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GridLayoutGetHorizontalAlignment()
        {
            tlog.Debug(tag, $"GridLayoutGetHorizontalAlignment START");

            View view = new View()
            {
                Size = new Size(400, 400),
                BackgroundColor = Color.White,
                Layout = new GridLayout()
                {
                    GridOrientation = GridLayout.Orientation.Horizontal
                }
            };

            GridLayout.SetHorizontalAlignment(view, GridLayout.Alignment.Start);
            Assert.AreEqual(GridLayout.Alignment.Start, GridLayout.GetHorizontalAlignment(view), "should be equal!");

            tlog.Debug(tag, $"GridLayoutGetHorizontalAlignment END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GridLayout SetVerticalAlignment")]
        [Property("SPEC", "Tizen.NUI.GridLayout.SetVerticalAlignment M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GridLayoutSetVerticalAlignment()
        {
            tlog.Debug(tag, $"GridLayoutSetVerticalAlignment START");

            View view = new View()
            {
                Size = new Size(400, 400),
                BackgroundColor = Color.White,
                Layout = new GridLayout()
                {
                    GridOrientation = GridLayout.Orientation.Horizontal
                }
            };

            try
            {
                GridLayout.SetVerticalAlignment(view, GridLayout.Alignment.Center);
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"GridLayoutSetVerticalAlignment END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GridLayout GetVerticalAlignment")]
        [Property("SPEC", "Tizen.NUI.GridLayout.GetVerticalAlignment M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GridLayoutGetVerticalAlignment()
        {
            tlog.Debug(tag, $"GridLayoutGetVerticalAlignment START");

            View view = new View()
            {
                Size = new Size(400, 400),
                BackgroundColor = Color.White,
                Layout = new GridLayout()
                {
                    GridOrientation = GridLayout.Orientation.Horizontal
                }
            };

            GridLayout.SetVerticalAlignment(view, GridLayout.Alignment.Center);
            Assert.AreEqual(GridLayout.Alignment.Center, GridLayout.GetVerticalAlignment(view), "should be equal!");

            tlog.Debug(tag, $"GridLayoutGetVerticalAlignment END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GridLayout Columns")]
        [Property("SPEC", "Tizen.NUI.GridLayout.Columns A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GridLayoutColumns()
        {
            tlog.Debug(tag, $"GridLayoutColumns START");

            var testingTarget = new GridLayout();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutGroup>(testingTarget, "Should return GridLayout instance.");

            testingTarget.Columns = 2;
            Assert.AreEqual(2, testingTarget.Columns, "Should be 2.");

            testingTarget.Columns = 1;
            Assert.AreEqual(1, testingTarget.Columns, "Should be 1.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"GridLayoutColumns END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GridLayout ColumnSpacing")]
        [Property("SPEC", "Tizen.NUI.GridLayout.ColumnSpacing A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GridLayoutColumnSpacing()
        {
            tlog.Debug(tag, $"GridLayoutColumns START");

            var testingTarget = new GridLayout();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutGroup>(testingTarget, "Should return GridLayout instance.");

            testingTarget.Columns = 2;
            Assert.AreEqual(2, testingTarget.Columns, "Should be 2.");

            testingTarget.ColumnSpacing = 1;
            Assert.AreEqual(1, testingTarget.ColumnSpacing, "Should be 1.");

            testingTarget.ColumnSpacing = 2;
            Assert.AreEqual(2, testingTarget.ColumnSpacing, "Should be 1.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"GridLayoutColumns END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GridLayout Rows")]
        [Property("SPEC", "Tizen.NUI.GridLayout.Rows A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GridLayoutRows()
        {
            tlog.Debug(tag, $"GridLayoutRows START");

            var testingTarget = new GridLayout();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutGroup>(testingTarget, "Should return GridLayout instance.");

            testingTarget.Rows = 2;
            Assert.AreEqual(2, testingTarget.Rows, "Should be 2.");

            testingTarget.Rows = 1;
            Assert.AreEqual(1, testingTarget.Rows, "Should be 1.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"GridLayoutRows END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GridLayout RowSpacing")]
        [Property("SPEC", "Tizen.NUI.GridLayout.RowSpacing A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GridLayoutRowSpacing()
        {
            tlog.Debug(tag, $"GridLayoutRowSpacing START");

            var testingTarget = new GridLayout();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutGroup>(testingTarget, "Should return GridLayout instance.");

            testingTarget.RowSpacing = 10.0f;
            Assert.AreEqual(10.0f, testingTarget.RowSpacing, "Should be 10.0f.");

            testingTarget.RowSpacing = 20.0f;
            Assert.AreEqual(20.0f, testingTarget.RowSpacing, "Should be 20.0f.");

            testingTarget.RowSpacing = -10.0f;
            Assert.AreEqual(0.0f, testingTarget.RowSpacing, "Should be 0.0f.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"GridLayoutRowSpacing END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GridLayout GridOrientation")]
        [Property("SPEC", "Tizen.NUI.GridLayout.GridOrientation A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GridLayoutGridOrientation()
        {
            tlog.Debug(tag, $"GridLayoutGridOrientation START");

            var testingTarget = new GridLayout();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutGroup>(testingTarget, "Should return GridLayout instance.");

            testingTarget.GridOrientation = GridLayout.Orientation.Horizontal;
            Assert.AreEqual(GridLayout.Orientation.Horizontal, testingTarget.GridOrientation, "Should be equal!");

            testingTarget.GridOrientation = GridLayout.Orientation.Horizontal;
            Assert.AreEqual(GridLayout.Orientation.Horizontal, testingTarget.GridOrientation, "Should be equal!");

            testingTarget.GridOrientation = GridLayout.Orientation.Vertical;
            Assert.AreEqual(GridLayout.Orientation.Vertical, testingTarget.GridOrientation, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"GridLayoutGridOrientation END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GridLayout OnMeasure")]
        [Property("SPEC", "Tizen.NUI.GridLayout.OnMeasure M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GridLayoutOnMeasure()
        {
            tlog.Debug(tag, $"GridLayoutOnMeasure START");

            flagOnMeasureOverride = false;
            Assert.False(flagOnMeasureOverride, "flagOnMeasureOverride should be false initial");

            var testingTarget = new MyGridLayout();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<GridLayout>(testingTarget, "Should be an instance of GridLayout type.");

            MeasureSpecification measureWidth = new MeasureSpecification(new LayoutLength(50.0f), MeasureSpecification.ModeType.Exactly);
            MeasureSpecification measureHeight = new MeasureSpecification(new LayoutLength(50.0f), MeasureSpecification.ModeType.Exactly);

            testingTarget.OnMeasureTest(measureWidth, measureHeight);
            Assert.True(flagOnMeasureOverride, "GridLayout overridden method not invoked.");

            // !MeasureSpecification.ModeType.Exactly
            flagOnMeasureOverride = false;
            Assert.False(flagOnMeasureOverride, "flagOnMeasureOverride should be false initial");

            MeasureSpecification measureWidth2 = new MeasureSpecification(new LayoutLength(50.0f), MeasureSpecification.ModeType.AtMost);
            MeasureSpecification measureHeight2 = new MeasureSpecification(new LayoutLength(50.0f), MeasureSpecification.ModeType.Unspecified);

            testingTarget.OnMeasureTest(measureWidth2, measureHeight2);
            Assert.True(flagOnMeasureOverride, "GridLayout overridden method not invoked.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"GridLayoutOnMeasure END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GridLayout OnLayout")]
        [Property("SPEC", "Tizen.NUI.GridLayout.OnLayout M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GridLayoutOnLayout()
        {
            tlog.Debug(tag, $"GridLayoutOnLayout START");

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

            var testingTarget = new MyGridLayout();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<GridLayout>(testingTarget, "Should be an instance of GridLayout type.");

            testingTarget.AttachToOwner(view);
            testingTarget.Add(layoutItem);

            MeasureSpecification measureWidth = new MeasureSpecification(new LayoutLength(50.0f), MeasureSpecification.ModeType.Exactly);
            MeasureSpecification measureHeight = new MeasureSpecification(new LayoutLength(50.0f), MeasureSpecification.ModeType.Exactly);

            testingTarget.OnMeasureTest(measureWidth, measureHeight);

            testingTarget.OnLayoutTest(true, new LayoutLength(5), new LayoutLength(5), new LayoutLength(10), new LayoutLength(10));
            Assert.True(flagOnLayoutOverride, "GridLayout overridden method not invoked.");

            // Test with false parameter
            flagOnLayoutOverride = false;
            Assert.False(flagOnLayoutOverride, "flagOnLayoutOverride should be false initial");
            testingTarget.OnLayoutTest(false, new LayoutLength(10), new LayoutLength(10), new LayoutLength(20), new LayoutLength(20));
            Assert.True(flagOnLayoutOverride, "GridLayout overridden method not invoked.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"GridLayoutOnLayout END (OK)");
        }
    }
}
