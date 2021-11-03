using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using System.Threading.Tasks;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Controls/RecyclerView/ItemSource/CollectionView")]
    class TSCollectionView
    {
        private const string tag = "NUITEST";

        private class TestModel : ObservableCollection<string>
        {
            private string[] namePool = {
                "Cat",
                "Boy",
                "Arm muscle",
                "Girl",
                "House",
                "Cafe",
                "Statue",
                "Sea",
                "hosepipe",
                "Police",
                "Rainbow",
                "Icicle",
                "Tower with the Moon",
                "Giraffe",
                "Camel",
                "Zebra",
                "Red Light",
                "Banana",
                "Lion",
                "Espresso",
            };

            public TestModel()
            {
                CreateData(this, 20);
            }

            private ObservableCollection<string> CreateData(ObservableCollection<string> result, int count)
            {
                for (int i = 0; i < count; i++)
                {
                    result.Add(namePool[i % 20]);
                }
                return result;
            }
        }

        private DataTemplate testDataTemplate;

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");

            testDataTemplate = new DataTemplate(() =>
            {
                var rand = new Random();
                DefaultLinearItem item = new DefaultLinearItem();
                //Set Width Specification as MatchParent to fit the Item width with parent View.
                item.WidthSpecification = LayoutParamPolicies.MatchParent;

                //Decorate Label
                item.Label.SetBinding(TextLabel.TextProperty, "ViewLabel");
                item.Label.HorizontalAlignment = HorizontalAlignment.Begin;

                //Decorate SubLabel
                if ((rand.Next() % 2) == 0)
                {
                    item.SubLabel.SetBinding(TextLabel.TextProperty, "Name");
                    item.SubLabel.HorizontalAlignment = HorizontalAlignment.Begin;
                }

                return item;
            });
        }

        [TearDown]
        public void Destroy()
        {
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("CollectionView constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.CollectionView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void CollectionViewConstructor()
        {
            tlog.Debug(tag, $"CollectionViewConstructor START");

            var testingTarget = new CollectionView();

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<CollectionView>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CollectionViewConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CollectionView constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.CollectionView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void CollectionViewConstructorWithItemsSource()
        {
            tlog.Debug(tag, $"CollectionViewConstructorWithItemsSource START");

            var model = new TestModel();
            var testingTarget = new CollectionView(model);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<CollectionView>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CollectionViewConstructorWithItemsSource END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CollectionView constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.CollectionView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void CollectionViewConstructorWithItemsSourceLayouterTemplate()
        {
            tlog.Debug(tag, $"CollectionViewConstructorWithItemsSourceLayouterTemplate START");

            var model = new TestModel();
            var testingTarget = new CollectionView(model, new LinearLayouter(), testDataTemplate);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<CollectionView>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CollectionViewConstructorWithItemsSourceLayouterTemplate END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CollectionView ItemsSource.")]
        [Property("SPEC", "Tizen.NUI.Components.CollectionView.ItemsSource A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void CollectionViewItemsSource()
        {
            tlog.Debug(tag, $"CollectionViewItemsSource START");

            var testingTarget = new CollectionView();

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<CollectionView>(testingTarget, "should be an instance of testing target class!");

            testingTarget.ItemsSource = new TestModel();
            Assert.IsNotNull(testingTarget.ItemsSource, "should be not null");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CollectionViewItemsSource END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CollectionView ItemTemplate.")]
        [Property("SPEC", "Tizen.NUI.Components.CollectionView.ItemTemplate A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void CollectionViewItemTemplate()
        {
            tlog.Debug(tag, $"CollectionViewItemTemplate START");

            var testingTarget = new CollectionView();

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<CollectionView>(testingTarget, "should be an instance of testing target class!");

            testingTarget.ItemTemplate = testDataTemplate;
            Assert.IsNotNull(testingTarget.ItemTemplate, "should be not null");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CollectionViewItemTemplate END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("CollectionView ItemTemplate.")]
        [Property("SPEC", "Tizen.NUI.Components.CollectionView.ItemTemplate A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void CollectionViewItemTemplateNull()
        {
            tlog.Debug(tag, $"CollectionViewItemTemplateNull START");

            var testingTarget = new CollectionView();

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<CollectionView>(testingTarget, "should be an instance of testing target class!");

            testingTarget.ItemTemplate = null;
            Assert.IsNull(testingTarget.ItemTemplate, "should be null");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CollectionViewItemTemplateNull END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CollectionView ItemsLayouter.")]
        [Property("SPEC", "Tizen.NUI.Components.CollectionView.ItemsLayouter A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void CollectionViewItemsLayouter()
        {
            tlog.Debug(tag, $"CollectionViewItemsLayouter START");

            var testingTarget = new CollectionView();

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<CollectionView>(testingTarget, "should be an instance of testing target class!");

            testingTarget.ItemsLayouter = new LinearLayouter();
            Assert.IsNotNull(testingTarget.ItemsLayouter, "should not be null");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CollectionViewItemsLayouter END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("CollectionView ItemsLayouter.")]
        [Property("SPEC", "Tizen.NUI.Components.CollectionView.ItemsLayouter A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void CollectionViewItemsLayouterNull()
        {
            tlog.Debug(tag, $"CollectionViewItemsLayouterNull START");

            var testingTarget = new CollectionView();

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<CollectionView>(testingTarget, "should be an instance of testing target class!");

            testingTarget.ItemsLayouter = null;
            Assert.IsNull(testingTarget.ItemsLayouter, "should be null");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CollectionViewItemsLayouterNull END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CollectionView ScrollingDirection.")]
        [Property("SPEC", "Tizen.NUI.Components.CollectionView.ScrollingDirection A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void CollectionViewScrollingDirection()
        {
            tlog.Debug(tag, $"CollectionViewScrollingDirection START");

            var testingTarget = new CollectionView();

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<CollectionView>(testingTarget, "should be an instance of testing target class!");

            testingTarget.ScrollingDirection = ScrollableBase.Direction.Horizontal;
            Assert.AreEqual(testingTarget.ScrollingDirection, ScrollableBase.Direction.Horizontal, "should be horizontal");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CollectionViewScrollingDirection END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CollectionView SelectedItem.")]
        [Property("SPEC", "Tizen.NUI.Components.CollectionView.SelectedItem A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void CollectionViewSelectedItem()
        {
            tlog.Debug(tag, $"CollectionViewSelectedItem START");

            var model = new TestModel();
            var testingTarget = new CollectionView(model);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<CollectionView>(testingTarget, "should be an instance of testing target class!");

            testingTarget.SelectedItem = "Cat";
            Assert.AreEqual(testingTarget.SelectedItem, "Cat", "Some items should be selected");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CollectionViewSelectedItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CollectionView SelectedItems.")]
        [Property("SPEC", "Tizen.NUI.Components.CollectionView.SelectedItems A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void CollectionViewSelectedItems()
        {
            tlog.Debug(tag, $"CollectionViewSelectedItems START");

            var model = new TestModel();
            var testingTarget = new CollectionView(model);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<CollectionView>(testingTarget, "should be an instance of testing target class!");

            tlog.Debug(tag, "SelectedItems : " + testingTarget.SelectedItems);

            testingTarget.Dispose();
            tlog.Debug(tag, $"CollectionViewSelectedItems END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CollectionView SelectionMode.")]
        [Property("SPEC", "Tizen.NUI.Components.CollectionView.SelectionMode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void CollectionViewSelectionMode()
        {
            tlog.Debug(tag, $"CollectionViewSelectionMode START");

            var model = new TestModel();
            var testingTarget = new CollectionView(model);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<CollectionView>(testingTarget, "should be an instance of testing target class!");

            testingTarget.SelectionMode = ItemSelectionMode.None;
            Assert.AreEqual(testingTarget.SelectionMode, ItemSelectionMode.None, "Selection mode is none.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CollectionViewSelectionMode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CollectionView SelectionChangedCommand.")]
        [Property("SPEC", "Tizen.NUI.Components.CollectionView.SelectionChangedCommand A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void CollectionViewSelectionChangedCommand()
        {
            tlog.Debug(tag, $"CollectionViewSelectionChangedCommand START");

            var model = new TestModel();
            var testingTarget = new CollectionView(model);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<CollectionView>(testingTarget, "should be an instance of testing target class!");

            testingTarget.SelectionChangedCommand = null;
            Assert.IsNull(testingTarget.SelectionChangedCommand, "Selection change command is null.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CollectionViewSelectionChangedCommand END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CollectionView SelectionChangedCommandParameter.")]
        [Property("SPEC", "Tizen.NUI.Components.CollectionView.SelectionChangedCommandParameter A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void CollectionViewSelectionChangedCommandParameter()
        {
            tlog.Debug(tag, $"CollectionViewSelectionChangedCommandParameter START");

            var model = new TestModel();
            var testingTarget = new CollectionView(model);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<CollectionView>(testingTarget, "should be an instance of testing target class!");

            testingTarget.SelectionChangedCommandParameter = null;
            Assert.IsNull(testingTarget.SelectionChangedCommandParameter, "Selection change command parameter is null.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CollectionViewSelectionChangedCommandParameter END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CollectionView Header.")]
        [Property("SPEC", "Tizen.NUI.Components.CollectionView.Header A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void CollectionViewHeader()
        {
            tlog.Debug(tag, $"CollectionViewHeader START");

            var model = new TestModel();
            var testingTarget = new CollectionView(model);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<CollectionView>(testingTarget, "should be an instance of testing target class!");

            DefaultTitleItem myTitle = new DefaultTitleItem();
            myTitle.Text = "test";
            testingTarget.Header = myTitle;
            Assert.IsNotNull(testingTarget.Header, "should be header.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CollectionViewHeader END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CollectionView Footer.")]
        [Property("SPEC", "Tizen.NUI.Components.CollectionView.Footer A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void CollectionViewFooter()
        {
            tlog.Debug(tag, $"CollectionViewFooter START");

            var model = new TestModel();
            var testingTarget = new CollectionView(model);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<CollectionView>(testingTarget, "should be an instance of testing target class!");

            DefaultTitleItem myTitle = new DefaultTitleItem();
            myTitle.Text = "test";
            testingTarget.Footer = myTitle;
            Assert.IsNotNull(testingTarget.Footer, "should be footer.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CollectionViewFooter END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CollectionView IsGrouped.")]
        [Property("SPEC", "Tizen.NUI.Components.CollectionView.IsGrouped A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void CollectionViewIsGrouped()
        {
            tlog.Debug(tag, $"CollectionViewIsGrouped START");

            var model = new TestModel();
            var testingTarget = new CollectionView(model);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<CollectionView>(testingTarget, "should be an instance of testing target class!");

            testingTarget.IsGrouped = true;
            Assert.IsTrue(testingTarget.IsGrouped, "should be grouped.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CollectionViewIsGrouped END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CollectionView GroupHeaderTemplate.")]
        [Property("SPEC", "Tizen.NUI.Components.CollectionView.GroupHeaderTemplate A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void CollectionViewGroupHeaderTemplate()
        {
            tlog.Debug(tag, $"CollectionViewGroupHeaderTemplate START");

            var model = new TestModel();
            var testingTarget = new CollectionView(model);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<CollectionView>(testingTarget, "should be an instance of testing target class!");

            testingTarget.GroupHeaderTemplate = testDataTemplate;
            Assert.IsNotNull(testingTarget.GroupHeaderTemplate, "should not be null.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CollectionViewGroupHeaderTemplate END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CollectionView GroupFooterTemplate.")]
        [Property("SPEC", "Tizen.NUI.Components.CollectionView.GroupFooterTemplate A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void CollectionViewGroupFooterTemplate()
        {
            tlog.Debug(tag, $"CollectionViewGroupFooterTemplate START");

            var model = new TestModel();
            var testingTarget = new CollectionView(model);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<CollectionView>(testingTarget, "should be an instance of testing target class!");

            testingTarget.GroupFooterTemplate = testDataTemplate;
            Assert.IsNotNull(testingTarget.GroupFooterTemplate, "should not be null.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CollectionViewGroupFooterTemplate END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CollectionView InternalItemSource.")]
        [Property("SPEC", "Tizen.NUI.Components.CollectionView.InternalItemSource A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void CollectionViewInternalItemSource()
        {
            tlog.Debug(tag, $"CollectionViewInternalItemSource START");

            var model = new TestModel();
            var testingTarget = new CollectionView(model);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<CollectionView>(testingTarget, "should be an instance of testing target class!");

            testingTarget.InternalItemSource = null;
            Assert.IsNull(testingTarget.InternalItemSource, "should be null.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CollectionViewInternalItemSource END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CollectionView SizingStrategy.")]
        [Property("SPEC", "Tizen.NUI.Components.CollectionView.SizingStrategy A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void CollectionViewSizingStrategy()
        {
            tlog.Debug(tag, $"CollectionViewSizingStrategy START");

            var model = new TestModel();
            var testingTarget = new CollectionView(model);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<CollectionView>(testingTarget, "should be an instance of testing target class!");

            testingTarget.SizingStrategy = ItemSizingStrategy.MeasureFirst;
            Assert.AreEqual(testingTarget.SizingStrategy, ItemSizingStrategy.MeasureFirst, "should be equal.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CollectionViewSizingStrategy END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CollectionView UpdateSelectedItems.")]
        [Property("SPEC", "Tizen.NUI.Components.CollectionView.UpdateSelectedItems M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void CollectionViewUpdateSelectedItems()
        {
            tlog.Debug(tag, $"CollectionViewUpdateSelectedItems START");

            var model = new TestModel();
            var testingTarget = new CollectionView(model);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<CollectionView>(testingTarget, "should be an instance of testing target class!");

            try
            {
                testingTarget.UpdateSelectedItems(null);
            }
            catch (ArgumentNullException)
            {
                testingTarget.Dispose();
                tlog.Debug(tag, $"CollectionViewUpdateSelectedItems END (OK)");
                Assert.Pass("Caught ArgumentNullException :  Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("CollectionView ScrollTo.")]
        [Property("SPEC", "Tizen.NUI.Components.CollectionView.ScrollTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void CollectionViewUpdateScrollTo()
        {
            tlog.Debug(tag, $"CollectionViewUpdateScrollTo START");

            var model = new TestModel();
            var testingTarget = new CollectionView(model, new LinearLayouter(), testDataTemplate);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<CollectionView>(testingTarget, "should be an instance of testing target class!");

            testingTarget.ScrollTo(123.0f, false);
            tlog.Debug(tag, "SelectedItems : " + testingTarget.SelectedItems);

            testingTarget.Dispose();
            tlog.Debug(tag, $"CollectionViewUpdateScrollTo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CollectionView ScrollToIndex.")]
        [Property("SPEC", "Tizen.NUI.Components.CollectionView.ScrollToIndex M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void CollectionViewScrollToIndex()
        {
            tlog.Debug(tag, $"CollectionViewScrollToIndex START");

            var model = new TestModel();
            var testingTarget = new CollectionView(model, new LinearLayouter(), testDataTemplate);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<CollectionView>(testingTarget, "should be an instance of testing target class!");

            testingTarget.ScrollToIndex(5);
            tlog.Debug(tag, "SelectedItems : " + testingTarget.SelectedItems);

            testingTarget.Dispose();
            tlog.Debug(tag, $"CollectionViewScrollToIndex END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CollectionView GetNextFocusableView.")]
        [Property("SPEC", "Tizen.NUI.Components.CollectionView.GetNextFocusableView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public async Task CollectionViewGetNextFocusableView()
        {
            tlog.Debug(tag, $"CollectionViewGetNextFocusableView START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler onAddedToWindow = (s, e) => { tcs.TrySetResult(true); };

            var model = new TestModel();
            var testingTarget = new CollectionView(model, new LinearLayouter(), testDataTemplate);
            testingTarget.AddedToWindow += onAddedToWindow;
            testingTarget.Size = new Size(100, 100);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<CollectionView>(testingTarget, "should be an instance of testing target class!");

            Window.Instance.Add(testingTarget);
            var result = await tcs.Task;
            Assert.IsTrue(result, "Relayout event should be invoked");

            testingTarget.GetNextFocusableView(null, View.FocusDirection.Down, false);
            tlog.Debug(tag, "SelectedItems : " + testingTarget.SelectedItems);

            if (testingTarget != null)
            {
                Window.Instance.Remove(testingTarget);
                testingTarget.Dispose();
                testingTarget = null;
            }
            tlog.Debug(tag, $"CollectionViewGetNextFocusableView END (OK)");
        }
    }
}
