using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    class TestDefaultGridItem : DefaultGridItem
    {
        public void LayoutTest()
        {
            base.LayoutChild();
        }

        public void MeasureChildTest()
        {
            base.MeasureChild();
        }
    }

    [TestFixture]
    [Description("Controls/RecyclerView/Item/DefaultGridItem")]
    class TSDefaultGridItem
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
        [Description("DefaultGridItem constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultGridItem C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void DefaultGridItemConstructor()
        {
            tlog.Debug(tag, $"DefaultGridItem START");

            var testingTarget = new DefaultGridItem();

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<DefaultGridItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultGridItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultGridItem constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultGridItem C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void DefaultGridItemConstructorWithStyle()
        {
            tlog.Debug(tag, $"DefaultGridItem START");

            var testingTarget = new DefaultGridItem("Tizen.NUI.Components.DefaultGridItem");

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<DefaultGridItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultGridItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultGridItem constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultGridItem C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void DefaultGridItemConstructorWithItemStyle()
        {
            tlog.Debug(tag, $"DefaultGridItem START");

            var itemStyle = new DefaultGridItemStyle()
            {
                Padding = new Extents(0, 0, 0, 0),
                Margin = new Extents(5, 5, 5, 5),
                Label = new TextLabelStyle()
                {
                    SizeHeight = 60,
                    PixelSize = 24,
                    LineWrapMode = LineWrapMode.Character,
                    ThemeChangeSensitive = false
                },
                Badge = new ViewStyle()
                {
                    Margin = new Extents(5, 5, 5, 5),
                },
            };

            var testingTarget = new DefaultGridItem(itemStyle);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<DefaultGridItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultGridItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultGridItem Image.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultGridItem.Image A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public async Task DefaultGridItemImage()
        {
            tlog.Debug(tag, $"DefaultGridItem START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler onAddedToWindow = (s, e) => { tcs.TrySetResult(true); };

            var testingTarget = new DefaultGridItem();
            testingTarget.AddedToWindow += onAddedToWindow;
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<DefaultGridItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Image = new ImageView()
            {
                WidthSpecification = 170,
                HeightSpecification = 170,
            };
            Assert.IsNotNull(testingTarget.Image, "DefaultGridItem image should not be null.");

            testingTarget.Image.WidthSpecification = 180;

            Window.Instance.Add(testingTarget);
            var result = await tcs.Task;
            Assert.IsTrue(result, "Relayout event should be invoked");

            if (testingTarget != null)
            {
                Window.Instance.Remove(testingTarget);
                testingTarget.Dispose();
            }
            tlog.Debug(tag, $"DefaultGridItem END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("DefaultGridItem Image.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultGridItem.Image A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public async Task DefaultGridItemImageNull()
        {
            tlog.Debug(tag, $"DefaultGridItem START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler onRelayout = (s, e) => { tcs.TrySetResult(true); };

            var testingTarget = new DefaultGridItem();
            testingTarget.Relayout += onRelayout;

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<DefaultGridItem>(testingTarget, "should be an instance of testing target class!");

            Window.Instance.Add(testingTarget);
            var result = await tcs.Task;
            Assert.IsTrue(result, "Relayout event should be invoked");

            Assert.IsNotNull(testingTarget.Image, "DefaultGridItem image should not be null.");

            if (testingTarget != null)
            {
                Window.Instance.Remove(testingTarget);
                testingTarget.Dispose();
                testingTarget = null;
            }
            tlog.Debug(tag, $"DefaultGridItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultGridItem Badge.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultGridItem.Badge A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void DefaultGridItemBadge()
        {
            tlog.Debug(tag, $"DefaultGridItem START");

            var testingTarget = new DefaultGridItem();

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<DefaultGridItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Badge = new ImageView()
            {
                WidthSpecification = 170,
                HeightSpecification = 170,
            };
            Assert.IsNotNull(testingTarget.Badge, "DefaultGridItem Badge should not be null.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultGridItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultGridItem Label.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultGridItem.Label A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void DefaultGridItemLabel()
        {
            tlog.Debug(tag, $"DefaultGridItem START");

            var testingTarget = new DefaultGridItem();

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<DefaultGridItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Label = new TextLabel()
            {
                WidthSpecification = 170,
                HeightSpecification = 170,
            };
            Assert.IsNotNull(testingTarget.Label, "DefaultGridItem Label should not be null.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultGridItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultGridItem Text.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultGridItem.Text A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void DefaultGridItemText()
        {
            tlog.Debug(tag, $"DefaultGridItem START");

            var testingTarget = new DefaultGridItem();

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<DefaultGridItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Text = "test";
            Assert.AreEqual(testingTarget.Text, "test", "DefaultGridItem Text should be equal to original text.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultGridItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultGridItem LabelOrientationType.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultGridItem.LabelOrientationType A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void DefaultGridItemLabelOrientationType()
        {
            tlog.Debug(tag, $"DefaultGridItem START");

            var testingTarget = new DefaultGridItem();

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<DefaultGridItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.LabelOrientationType = DefaultGridItem.LabelOrientation.InsideBottom;
            Assert.AreEqual(testingTarget.LabelOrientationType, DefaultGridItem.LabelOrientation.InsideBottom, "DefaultGridItem LabelOrientationType should be equal to original value.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultGridItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultGridItem ApplyStyle.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultGridItem.ApplyStyle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void DefaultGridItemApplyStyle()
        {
            tlog.Debug(tag, $"DefaultGridItem START");

            var testingTarget = new DefaultGridItem();

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<DefaultGridItem>(testingTarget, "should be an instance of testing target class!");

            var itemStyle = new DefaultGridItemStyle()
            {
                Padding = new Extents(0, 0, 0, 0),
                Margin = new Extents(5, 5, 5, 5),
                Label = new TextLabelStyle()
                {
                    SizeHeight = 60,
                    PixelSize = 24,
                    LineWrapMode = LineWrapMode.Character,
                    ThemeChangeSensitive = false
                },
                Badge = new ViewStyle()
                {
                    Margin = new Extents(5, 5, 5, 5),
                },
            };

            testingTarget.ApplyStyle(itemStyle);
            Assert.IsNotNull(testingTarget.Label, "DefaultGridItem Label should not be null.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultGridItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultGridItem LayoutChild.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultGridItem.LayoutChild M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void DefaultGridItemLayoutChildOutsideBottom()
        {
            tlog.Debug(tag, $"DefaultGridItem START");

            var testingTarget = new TestDefaultGridItem();

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<DefaultGridItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.LabelOrientationType = DefaultGridItem.LabelOrientation.OutsideBottom;
            testingTarget.Image = new ImageView()
            {
                WidthSpecification = 170,
                HeightSpecification = 170,
            };
            Assert.IsNotNull(testingTarget.Image, "DefaultGridItem image should not be null.");
            testingTarget.Badge = new ImageView()
            {
                WidthSpecification = 170,
                HeightSpecification = 170,
            };
            Assert.IsNotNull(testingTarget.Badge, "DefaultGridItem Badge should not be null.");
            testingTarget.Label = new TextLabel()
            {
                WidthSpecification = 170,
                HeightSpecification = 170,
            };
            Assert.IsNotNull(testingTarget.Label, "DefaultGridItem Label should not be null.");
            testingTarget.LayoutTest();

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultGridItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultGridItem LayoutChild.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultGridItem.LayoutChild M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void DefaultGridItemLayoutChildOutsideTop()
        {
            tlog.Debug(tag, $"DefaultGridItem START");

            var testingTarget = new TestDefaultGridItem();

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<DefaultGridItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.LabelOrientationType = DefaultGridItem.LabelOrientation.OutsideTop;
            testingTarget.Image = new ImageView()
            {
                WidthSpecification = 170,
                HeightSpecification = 170,
            };
            Assert.IsNotNull(testingTarget.Image, "DefaultGridItem image should not be null.");
            testingTarget.Badge = new ImageView()
            {
                WidthSpecification = 170,
                HeightSpecification = 170,
            };
            Assert.IsNotNull(testingTarget.Badge, "DefaultGridItem Badge should not be null.");
            testingTarget.Label = new TextLabel()
            {
                WidthSpecification = 170,
                HeightSpecification = 170,
            };
            Assert.IsNotNull(testingTarget.Label, "DefaultGridItem Label should not be null.");
            testingTarget.LayoutTest();

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultGridItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultGridItem LayoutChild.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultGridItem.LayoutChild M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void DefaultGridItemLayoutChildInsideBottom()
        {
            tlog.Debug(tag, $"DefaultGridItem START");

            var testingTarget = new TestDefaultGridItem();

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<DefaultGridItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.LabelOrientationType = DefaultGridItem.LabelOrientation.InsideBottom;
            testingTarget.Image = new ImageView()
            {
                WidthSpecification = 170,
                HeightSpecification = 170,
            };
            Assert.IsNotNull(testingTarget.Image, "DefaultGridItem image should not be null.");
            testingTarget.Badge = new ImageView()
            {
                WidthSpecification = 170,
                HeightSpecification = 170,
            };
            Assert.IsNotNull(testingTarget.Badge, "DefaultGridItem Badge should not be null.");
            testingTarget.Label = new TextLabel()
            {
                WidthSpecification = 170,
                HeightSpecification = 170,
            };
            Assert.IsNotNull(testingTarget.Label, "DefaultGridItem Label should not be null.");
            testingTarget.LayoutTest();

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultGridItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultGridItem LayoutChild.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultGridItem.LayoutChild M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void DefaultGridItemLayoutChildInsideTop()
        {
            tlog.Debug(tag, $"DefaultGridItem START");

            var testingTarget = new TestDefaultGridItem();

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<DefaultGridItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.LabelOrientationType = DefaultGridItem.LabelOrientation.InsideTop;
            testingTarget.Image = new ImageView()
            {
                WidthSpecification = 170,
                HeightSpecification = 170,
            };
            Assert.IsNotNull(testingTarget.Image, "DefaultGridItem image should not be null.");
            testingTarget.Badge = new ImageView()
            {
                WidthSpecification = 170,
                HeightSpecification = 170,
            };
            Assert.IsNotNull(testingTarget.Badge, "DefaultGridItem Badge should not be null.");
            testingTarget.LayoutTest();

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultGridItem END (OK)");
        }


        [Test]
        [Category("P1")]
        [Description("DefaultGridItem MeasureChild.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultGridItem.MeasureChild M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void DefaultGridItemMeasureChild()
        {
            tlog.Debug(tag, $"DefaultGridItem START");

            var testingTarget = new TestDefaultGridItem();

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<DefaultGridItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.LabelOrientationType = DefaultGridItem.LabelOrientation.InsideTop;
            testingTarget.Image = new ImageView()
            {
                WidthSpecification = 170,
                HeightSpecification = 170,
            };
            Assert.IsNotNull(testingTarget.Image, "DefaultGridItem image should not be null.");
            testingTarget.Badge = new ImageView()
            {
                WidthSpecification = 170,
                HeightSpecification = 170,
            };
            Assert.IsNotNull(testingTarget.Badge, "DefaultGridItem Badge should not be null.");
            testingTarget.Label = new TextLabel()
            {
                WidthSpecification = 170,
                HeightSpecification = 170,
            };
            Assert.IsNotNull(testingTarget.Label, "DefaultGridItem Label should not be null.");
            testingTarget.MeasureChildTest();

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultGridItem END (OK)");
        }
    }
}
