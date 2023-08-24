using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [NUnit.Framework.Description("Controls/RecyclerView/RecyclerView")]
    class RecyclerViewTest
    {
        private const string tag = "NUITEST";
        public List<TestItem> Source { get; private set; } = new List<TestItem>();

        public void CreateTestSource(int count)
        {
            var Rand = new Random();

            for (int i = 0; i < count; i++)
                Source.Add(new TestItem(i, $"Test Item [{i}]", new Color(((float)(Rand.Next(255)) / 255), ((float)(Rand.Next(255)) / 255), ((float)(Rand.Next(255)) / 255), 1)));
        }

        internal class ItemsLayouterImpl : ItemsLayouter
        {
            public ItemsLayouterImpl() : base()
            { }
        }

        internal class TestItem
        {
            int index;
            string name;
            Color color;
            bool isSelected;

            public TestItem(int itemIndex, string itemName, Color itemColor)
            {
                Index = itemIndex;
                Name = itemName;
                BgColor = itemColor;
                IsSelected = false;
            }

            public int Index
            {
                get => index;
                set { index = value; }
            }

            public string Name
            {
                get => name;
                set { name = value; }
            }

            public Color BgColor
            {
                get => color;
                set { color = value; }
            }

            public bool IsSelected
            {
                get => isSelected;
                set { isSelected = value; }
            }
        }

        internal class RecyclerViewImpl : RecyclerView
        {
            public RecyclerViewImpl() : base()
            {
                base.InternalItemsLayouter = new ItemsLayouterImpl();
            }

            public float OnAdjustTargetPositionOfScrollAnimation(float position)
            {
                return base.AdjustTargetPositionOfScrollAnimation(position);
            }

            public void OnScrollingImpl(object source, ScrollEventArgs args)
            {
                base.OnScrolling(source, args);
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
        [Description("RecyclerView ItemsSource.")]
        [Property("SPEC", "Tizen.NUI.Components.RecyclerView.ItemsSource A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RecyclerViewItemsSource()
        {
            tlog.Debug(tag, $"RecyclerViewItemsSource START");

            var testingTarget = new RecyclerViewImpl()
            { 
                Size = new Size(Window.Instance.WindowSize.Width, Window.Instance.WindowSize.Height),
            };
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<RecyclerView>(testingTarget, "should be an instance of testing target class!");

            CreateTestSource(50);
            testingTarget.ItemsSource = Source;
            tlog.Debug(tag, "ItemSouce : " + testingTarget.ItemsSource);

            testingTarget.ItemTemplate = new DataTemplate(() =>
            {
                var item = new RecyclerViewItem()
                {
                    HeightSpecification = LayoutParamPolicies.MatchParent,
                    WidthSpecification = 200,
                };
                item.SetBinding(View.BackgroundColorProperty, "BgColor");

                var label = new TextLabel()
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                    PivotPoint = Tizen.NUI.PivotPoint.Center,
                    PositionUsesPivotPoint = true,
                };
                label.PixelSize = 30;
                label.SetBinding(TextLabel.TextProperty, "Index");
                item.Add(label);

                return item;
            });
            tlog.Debug(tag, "ItemTemplate : " + testingTarget.ItemTemplate);

            // OnRelayout
            CreateTestSource(100);
            testingTarget.ItemsSource = Source;
            tlog.Debug(tag, "ItemSouce : " + testingTarget.ItemsSource);

            testingTarget.Dispose();
            tlog.Debug(tag, $"RecyclerViewItemsSource END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RecyclerView AdjustTargetPositionOfScrollAnimation.")]
        [Property("SPEC", "Tizen.NUI.Components.RecyclerView.AdjustTargetPositionOfScrollAnimation M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RecyclerViewAdjustTargetPositionOfScrollAnimation()
        {
            tlog.Debug(tag, $"RecyclerViewAdjustTargetPositionOfScrollAnimation START");

            var testingTarget = new RecyclerViewImpl()
            {
                Size = new Size(Window.Instance.WindowSize.Width, Window.Instance.WindowSize.Height),
            };
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<RecyclerView>(testingTarget, "should be an instance of testing target class!");

            CreateTestSource(50);
            testingTarget.ItemsSource = Source;
            tlog.Debug(tag, "ItemSouce : " + testingTarget.ItemsSource);

            testingTarget.ItemTemplate = new DataTemplate(() =>
            {
                var item = new RecyclerViewItem()
                {
                    HeightSpecification = LayoutParamPolicies.MatchParent,
                    WidthSpecification = 200,
                };
                item.SetBinding(View.BackgroundColorProperty, "BgColor");

                var label = new TextLabel()
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                    PivotPoint = Tizen.NUI.PivotPoint.Center,
                    PositionUsesPivotPoint = true,
                };
                label.PixelSize = 30;
                label.SetBinding(TextLabel.TextProperty, "Index");
                item.Add(label);

                return item;
            });
            tlog.Debug(tag, "ItemTemplate : " + testingTarget.ItemTemplate);

            try
            {
                testingTarget.OnAdjustTargetPositionOfScrollAnimation(300.0f);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RecyclerViewAdjustTargetPositionOfScrollAnimation END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RecyclerView OnScrolling.")]
        [Property("SPEC", "Tizen.NUI.Components.RecyclerView.OnScrolling M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RecyclerViewOnScrolling()
        {
            tlog.Debug(tag, $"RecyclerViewOnScrolling START");

            var testingTarget = new RecyclerViewImpl()
            {
                Size = new Size(Window.Instance.WindowSize.Width, Window.Instance.WindowSize.Height),
            };

            CreateTestSource(50);
            testingTarget.ItemsSource = Source;


            testingTarget.ItemTemplate = new DataTemplate(() =>
            {
                var item = new RecyclerViewItem()
                {
                    HeightSpecification = LayoutParamPolicies.MatchParent,
                    WidthSpecification = 200,
                };
                item.SetBinding(View.BackgroundColorProperty, "BgColor");

                var label = new TextLabel()
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                    PivotPoint = Tizen.NUI.PivotPoint.Center,
                    PositionUsesPivotPoint = true,
                };
                label.PixelSize = 30;
                label.SetBinding(TextLabel.TextProperty, "Index");
                item.Add(label);

                return item;
            });

            using (Position pos = new Position(1000, 800))
            {
                testingTarget.OnScrollingImpl(testingTarget, new ScrollEventArgs(pos));
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RecyclerViewOnScrolling END (OK)");
        }
    }
}
