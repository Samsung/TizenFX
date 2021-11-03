using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using System.Collections.Generic;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Controls/RecyclerView/Layouter")]
    public class TSGridLayouter
    {
        private const string tag = "NUITEST";
        private string path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "index.xml";

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
        [Description("GridLayouter Initialize.")]
        [Property("SPEC", "Tizen.NUI.Components.GridLayouter.Initialize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "xiaohui.fang@samsung.com")]
        public void GridLayouterInitialize()
        {
            tlog.Debug(tag, $"GridLayouterInitialize START");

            var view = new CollectionView(new List<string>() { "123", "456", "789" })
            {
                Header = new RecyclerViewItem(),
                Footer = new RecyclerViewItem(),
                IsGrouped = true,
            };
            Assert.IsNotNull(view, "Should not be null");

            view.GroupFooterTemplate = new DataTemplate(typeof(RecyclerViewItem));
            view.GroupHeaderTemplate = new DataTemplate(typeof(RecyclerViewItem));
            view.ItemTemplate = new DataTemplate(typeof(RecyclerViewItem));

            var gridLayouter = new GridLayouter();
            Assert.IsNotNull(gridLayouter, "Should not be null");

            gridLayouter.Initialize(view);

            view.Dispose();
            gridLayouter.Dispose();

            tlog.Debug(tag, $"GridLayouterInitialize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GridLayouter RequestLayout.")]
        [Property("SPEC", "Tizen.NUI.Components.GridLayouter.RequestLayout M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "xiaohui.fang@samsung.com")]
        public void GridLayouterRequestLayout()
        {
            tlog.Debug(tag, $"GridLayouterRequestLayout START");

            var view = new CollectionView(new List<string>() { "123", "456", "789" })
            {
                Header = new RecyclerViewItem(),
                Footer = new RecyclerViewItem(),
                IsGrouped = true,
            };
            Assert.IsNotNull(view, "Should not be null");

            view.GroupFooterTemplate = new DataTemplate(typeof(RecyclerViewItem));
            view.GroupHeaderTemplate = new DataTemplate(typeof(RecyclerViewItem));
            view.ItemTemplate = new DataTemplate(typeof(RecyclerViewItem));

            var gridLayouter = new GridLayouter();
            Assert.IsNotNull(gridLayouter, "Should not be null");

            gridLayouter.Initialize(view);

            gridLayouter.RequestLayout(5.0f);

            gridLayouter.RequestLayout(150.0f, true);

            view.Dispose();
            gridLayouter.Dispose();

            tlog.Debug(tag, $"GridLayouterRequestLayout END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GridLayouter Clear.")]
        [Property("SPEC", "Tizen.NUI.Components.GridLayouter.Clear M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "xiaohui.fang@samsung.com")]
        public void GridLayouterClear()
        {
            tlog.Debug(tag, $"GridLayouterClear START");

            var view = new CollectionView(new List<string>() { "123", "456" })
            {
                Header = new RecyclerViewItem(),
                Footer = new RecyclerViewItem(),
                IsGrouped = true,
            };
            Assert.IsNotNull(view, "Should not be null");

            view.GroupFooterTemplate = new DataTemplate(typeof(RecyclerViewItem));
            view.GroupHeaderTemplate = new DataTemplate(typeof(RecyclerViewItem));
            view.ItemTemplate = new DataTemplate(typeof(RecyclerViewItem));

            var gridLayouter = new GridLayouter();
            Assert.IsNotNull(gridLayouter, "Should not be null");

            gridLayouter.Initialize(view);
            gridLayouter.RequestLayout(100.0f);
            gridLayouter.Clear();

            view.Dispose();
            gridLayouter.Dispose();

            tlog.Debug(tag, $"GridLayouterClear END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GridLayouter NotifyItemInserted.")]
        [Property("SPEC", "Tizen.NUI.Components.GridLayouter.NotifyItemInserted M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "xiaohui.fang@samsung.com")]
        public void GridLayouterNotifyItemInserted()
        {
            tlog.Debug(tag, $"GridLayouterNotifyItemInserted");

            var view = new CollectionView(new List<string>() { "123", "456" })
            {
                Header = new RecyclerViewItem(),
                Footer = new RecyclerViewItem(),
                IsGrouped = true,
            };
            Assert.IsNotNull(view, "Should not be null");

            view.GroupFooterTemplate = new DataTemplate(typeof(RecyclerViewItem));
            view.GroupHeaderTemplate = new DataTemplate(typeof(RecyclerViewItem));
            view.ItemTemplate = new DataTemplate(typeof(RecyclerViewItem));

            var gridLayouter = new GridLayouter();
            Assert.IsNotNull(gridLayouter, "Should not be null");

            gridLayouter.Initialize(view);
            gridLayouter.RequestLayout(100.0f);

            var source = new CustomGroupItemSource(view)
            {
                Position = 1,
            };
            gridLayouter.NotifyItemInserted(source, 0);

            source.Position = 4;
            gridLayouter.NotifyItemInserted(source, 0);

            gridLayouter.NotifyItemInserted(source, 1);

            var emptySource = new CustomEmptySource();
            gridLayouter.NotifyItemInserted(emptySource, 1);

            var item = new RecyclerViewItem()
            {
                Size = new Size(200, 100),
            };
            gridLayouter.NotifyItemSizeChanged(item);
            item.Dispose();

            view.Dispose();
            gridLayouter.Dispose();

            source.Dispose();
            emptySource.Dispose();

            tlog.Debug(tag, $"GridLayouterNotifyItemInserted END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GridLayouter NotifyItemRangeInserted.")]
        [Property("SPEC", "Tizen.NUI.Components.GridLayouter.NotifyItemRangeInserted M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "xiaohui.fang@samsung.com")]
        public void GridLayouterNotifyItemRangeInserted()
        {
            tlog.Debug(tag, $"GridLayouterNotifyItemRangeInserted");

            var view = new CollectionView(new List<string>() { "123", "456" })
            {
                Header = new RecyclerViewItem(),
                Footer = new RecyclerViewItem(),
                IsGrouped = true,
            };
            Assert.IsNotNull(view, "Should not be null");

            view.GroupFooterTemplate = new DataTemplate(typeof(RecyclerViewItem));
            view.GroupHeaderTemplate = new DataTemplate(typeof(RecyclerViewItem));
            view.ItemTemplate = new DataTemplate(typeof(RecyclerViewItem));

            var gridLayouter = new GridLayouter();
            Assert.IsNotNull(gridLayouter, "Should not be null");

            gridLayouter.Initialize(view);
            gridLayouter.RequestLayout(100.0f);

            var source = new CustomGroupItemSource(view)
            {
                Position = 1,
                FooterIndex = 2,
            };
            gridLayouter.NotifyItemRangeInserted(source, 0, 3);

            source.Position = 6;
            gridLayouter.NotifyItemRangeInserted(source, 0, 1);

            gridLayouter.NotifyItemRangeInserted(source, 1, 1);

            view.Dispose();
            gridLayouter.Dispose();

            source.Dispose();

            tlog.Debug(tag, $"GridLayouterNotifyItemRangeInserted END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GridLayouter NotifyItemRemoved.")]
        [Property("SPEC", "Tizen.NUI.Components.GridLayouter.NotifyItemRemoved M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "xiaohui.fang@samsung.com")]
        public void GridLayouterNotifyItemRemoved()
        {
            tlog.Debug(tag, $"GridLayouterNotifyItemRemoved");

            var view = new CollectionView(new List<string>() { "123", "456" })
            {
                Header = new RecyclerViewItem(),
                Footer = new RecyclerViewItem(),
                IsGrouped = true,
            };
            Assert.IsNotNull(view, "Should not be null");

            view.GroupFooterTemplate = new DataTemplate(typeof(RecyclerViewItem));
            view.GroupHeaderTemplate = new DataTemplate(typeof(RecyclerViewItem));
            view.ItemTemplate = new DataTemplate(typeof(RecyclerViewItem));

            var gridLayouter = new GridLayouter();
            Assert.IsNotNull(gridLayouter, "Should not be null");

            gridLayouter.Initialize(view);
            gridLayouter.RequestLayout(100.0f);

            var source = new CustomGroupItemSource(view)
            {
                Position = 1,
            };

            gridLayouter.NotifyItemRangeInserted(source, 0, 1);
            gridLayouter.NotifyItemRemoved(source, 0);

            gridLayouter.NotifyItemRangeInserted(source, 0, 2);
            gridLayouter.NotifyItemRemoved(source, 1);

            var emptySource = new CustomEmptySource();
            gridLayouter.NotifyItemInserted(emptySource, 1);
            gridLayouter.NotifyItemRemoved(emptySource, 1);

            view.Dispose();
            gridLayouter.Dispose();

            source.Dispose();
            emptySource.Dispose();

            tlog.Debug(tag, $"GridLayouterNotifyItemRemoved END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GridLayouter NotifyItemRangeRemoved.")]
        [Property("SPEC", "Tizen.NUI.Components.GridLayouter.NotifyItemRangeRemoved M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "xiaohui.fang@samsung.com")]
        public void GridLayouterNotifyItemRangeRemoved()
        {
            tlog.Debug(tag, $"GridLayouterNotifyItemRangeRemoved");

            var view = new CollectionView(new List<string>() { "123", "456" })
            {
                Header = new RecyclerViewItem(),
                Footer = new RecyclerViewItem(),
                IsGrouped = true,
            };
            Assert.IsNotNull(view, "Should not be null");

            view.GroupFooterTemplate = new DataTemplate(typeof(RecyclerViewItem));
            view.GroupHeaderTemplate = new DataTemplate(typeof(RecyclerViewItem));
            view.ItemTemplate = new DataTemplate(typeof(RecyclerViewItem));

            var gridLayouter = new GridLayouter();
            Assert.IsNotNull(gridLayouter, "Should not be null");

            gridLayouter.Initialize(view);
            gridLayouter.RequestLayout(100.0f);

            var source = new CustomGroupItemSource(view)
            {
                Position = 1,
            };

            gridLayouter.NotifyItemRangeInserted(source, 0, 1);
            gridLayouter.NotifyItemRangeRemoved(source, 0, 1);

            view.Dispose();
            gridLayouter.Dispose();

            source.Dispose();

            tlog.Debug(tag, $"GridLayouterNotifyItemRangeRemoved END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GridLayouter NotifyItemMoved.")]
        [Property("SPEC", "Tizen.NUI.Components.GridLayouter.NotifyItemMoved M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "xiaohui.fang@samsung.com")]
        public void GridLayouterNotifyItemMoved()
        {
            tlog.Debug(tag, $"GridLayouterNotifyItemMoved");

            var view = new CollectionView(new List<string>() { "123", "456" })
            {
                Header = new RecyclerViewItem(),
                Footer = new RecyclerViewItem(),
                IsGrouped = true,
            };
            Assert.IsNotNull(view, "Should not be null");

            view.GroupFooterTemplate = new DataTemplate(typeof(RecyclerViewItem));
            view.GroupHeaderTemplate = new DataTemplate(typeof(RecyclerViewItem));
            view.ItemTemplate = new DataTemplate(typeof(RecyclerViewItem));

            var gridLayouter = new GridLayouter();
            Assert.IsNotNull(gridLayouter, "Should not be null");

            gridLayouter.Initialize(view);
            gridLayouter.RequestLayout(100.0f);

            var source = new CustomGroupItemSource(view)
            {
                Position = 1,
            };

            gridLayouter.NotifyItemRangeInserted(source, 0, 10);
            gridLayouter.NotifyItemMoved(source, 1, 22);

            view.Dispose();
            gridLayouter.Dispose();

            source.Dispose();

            tlog.Debug(tag, $"GridLayouterNotifyItemMoved END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GridLayouter NotifyItemRangeMoved.")]
        [Property("SPEC", "Tizen.NUI.Components.GridLayouter.NotifyItemRangeMoved M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "xiaohui.fang@samsung.com")]
        public void GridLayouterNotifyItemRangeMoved()
        {
            tlog.Debug(tag, $"GridLayouterNotifyItemRangeMoved");

            var view = new CollectionView(new List<string>() { "123", "456" })
            {
                Header = new RecyclerViewItem(),
                Footer = new RecyclerViewItem(),
                IsGrouped = true,
            };
            Assert.IsNotNull(view, "Should not be null");

            view.GroupFooterTemplate = new DataTemplate(typeof(RecyclerViewItem));
            view.GroupHeaderTemplate = new DataTemplate(typeof(RecyclerViewItem));
            view.ItemTemplate = new DataTemplate(typeof(RecyclerViewItem));

            var gridLayouter = new GridLayouter();
            Assert.IsNotNull(gridLayouter, "Should not be null");

            gridLayouter.Initialize(view);
            gridLayouter.RequestLayout(100.0f);

            var source = new CustomGroupItemSource(view)
            {
                Position = 1,
            };

            var orientationSize = gridLayouter.CalculateLayoutOrientationSize();
            Assert.AreEqual(orientationSize, 6);

            var scrollPosition = gridLayouter.CalculateCandidateScrollPosition(0.0f);
            Assert.AreEqual(scrollPosition, 0.0f);

            gridLayouter.NotifyItemRangeInserted(source, 0, 10);
            gridLayouter.NotifyItemRangeMoved(source, 11, 16, 5);

            view.Dispose();
            gridLayouter.Dispose();

            source.Dispose();

            tlog.Debug(tag, $"GridLayouterNotifyItemRangeMoved END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GridLayouter RequestNextFocusableView.")]
        [Property("SPEC", "Tizen.NUI.Components.GridLayouter.RequestNextFocusableView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "xiaohui.fang@samsung.com")]
        public void GridLayouterRequestNextFocusableView()
        {
            tlog.Debug(tag, $"GridLayouterRequestNextFocusableView");

            var view = new CollectionView(new List<string>() { "123", "456" })
            {
                Header = new RecyclerViewItem(),
                Footer = new RecyclerViewItem(),
                IsGrouped = true,
            };
            Assert.IsNotNull(view, "Should not be null");

            view.GroupFooterTemplate = new DataTemplate(typeof(RecyclerViewItem));
            view.GroupHeaderTemplate = new DataTemplate(typeof(RecyclerViewItem));
            view.ItemTemplate = new DataTemplate(typeof(RecyclerViewItem));

            var gridLayouter = new GridLayouter();
            Assert.IsNotNull(gridLayouter, "Should not be null");

            gridLayouter.Initialize(view);
            gridLayouter.RequestLayout(100.0f);

            var source = new CustomGroupItemSource(view)
            {
                Position = 1,
            };

            var orientationSize = gridLayouter.CalculateLayoutOrientationSize();
            Assert.AreEqual(orientationSize, 6);

            var scrollPosition = gridLayouter.CalculateCandidateScrollPosition(0.0f);
            Assert.AreEqual(scrollPosition, 0.0f);

            gridLayouter.NotifyItemRangeInserted(source, 0, 10);

            gridLayouter.RequestNextFocusableView(view, View.FocusDirection.Up, true);
            gridLayouter.RequestNextFocusableView(view, View.FocusDirection.Down, true);
            gridLayouter.RequestNextFocusableView(view, View.FocusDirection.PageUp, true);
            gridLayouter.RequestNextFocusableView(view, View.FocusDirection.PageDown, true);
            gridLayouter.RequestNextFocusableView(view, View.FocusDirection.Left, true);
            gridLayouter.RequestNextFocusableView(view, View.FocusDirection.Right, true);

            view.Dispose();
            gridLayouter.Dispose();

            source.Dispose();

            tlog.Debug(tag, $"GridLayouterRequestNextFocusableView END (OK)");
        }
    }
}
