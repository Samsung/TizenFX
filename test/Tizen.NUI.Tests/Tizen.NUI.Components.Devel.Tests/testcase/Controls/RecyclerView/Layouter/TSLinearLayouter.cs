using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Controls/RecyclerView/Layouter")]
    public class TSLinearLayouter
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

        private object GetBinding(View view)
        {
            return null;
        }

        [Test]
        [Category("P1")]
        [Description("LinearLayouter Initialize.")]
        [Property("SPEC", "Tizen.NUI.Components.LinearLayouter.Initialize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "xiaohui.fang@samsung.com")]
        public void LinearLayouterInitialize()
        {
            tlog.Debug(tag, $"LinearLayouterInitialize START");

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

            var linearLayouter = new LinearLayouter();
            Assert.IsNotNull(linearLayouter, "Should not be null");

            linearLayouter.Initialize(view);

            linearLayouter.Padding = new Extents(0, 0, 0, 0);

            view.Dispose();
            linearLayouter.Dispose();

            tlog.Debug(tag, $"LinearLayouterInitialize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LinearLayouter RequestLayout.")]
        [Property("SPEC", "Tizen.NUI.Components.LinearLayouter.RequestLayout M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "xiaohui.fang@samsung.com")]
        public void LinearLayouterRequestLayout()
        {
            tlog.Debug(tag, $"LinearLayouterRequestLayout START");

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

            var linearLayouter = new LinearLayouter();
            Assert.IsNotNull(linearLayouter, "Should not be null");

            linearLayouter.Initialize(view);

            linearLayouter.RequestLayout(5.0f);

            linearLayouter.RequestLayout(150.0f, true);

            view.Dispose();
            linearLayouter.Dispose();

            tlog.Debug(tag, $"LinearLayouterRequestLayout END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LinearLayouter Clear.")]
        [Property("SPEC", "Tizen.NUI.Components.LinearLayouter.Clear M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "xiaohui.fang@samsung.com")]
        public void LinearLayouterClear()
        {
            tlog.Debug(tag, $"LinearLayouterClear START");

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

            var linearLayouter = new LinearLayouter();
            Assert.IsNotNull(linearLayouter, "Should not be null");

            linearLayouter.Initialize(view);
            linearLayouter.RequestLayout(100.0f);
            linearLayouter.Clear();

            view.Dispose();
            linearLayouter.Dispose();

            tlog.Debug(tag, $"LinearLayouterClear END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LinearLayouter NotifyItemSizeChanged.")]
        [Property("SPEC", "Tizen.NUI.Components.LinearLayouter.NotifyItemSizeChanged M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "xiaohui.fang@samsung.com")]
        public void LinearLayouterNotifyItemSizeChanged()
        {
            tlog.Debug(tag, $"LinearLayouterNotifyItemSizeChanged");

            var view = new CollectionView(new List<string>() { "123" })
            {
                Header = new RecyclerViewItem(),
                IsGrouped = false,
            };
            Assert.IsNotNull(view, "Should not be null");

            view.GroupHeaderTemplate = new DataTemplate(typeof(RecyclerViewItem));
            view.ItemTemplate = new DataTemplate(typeof(RecyclerViewItem));

            var emptySource = new CustomEmptySource();

            var linearLayouter = new LinearLayouter();
            Assert.IsNotNull(linearLayouter, "Should not be null");

            linearLayouter.Initialize(view);

            var item = new RecyclerViewItem()
            {
                Size = new Size(200, 100),
            };
            //linearLayouter.NotifyItemSizeChanged(item);
            item.Dispose();

            view.Dispose();
            linearLayouter.Dispose();

            tlog.Debug(tag, $"LinearLayouterNotifyItemSizeChanged END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LinearLayouter NotifyItemInserted.")]
        [Property("SPEC", "Tizen.NUI.Components.LinearLayouter.NotifyItemInserted M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "xiaohui.fang@samsung.com")]
        public void LinearLayouterNotifyItemInserted()
        {
            tlog.Debug(tag, $"LinearLayouterNotifyItemInserted");

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

            var linearLayouter = new LinearLayouter();
            Assert.IsNotNull(linearLayouter, "Should not be null");

            linearLayouter.Initialize(view);
            linearLayouter.RequestLayout(100.0f);

            var source = new CustomGroupItemSource(view)
            {
                Position = 1,
            };
            linearLayouter.NotifyItemInserted(source, 0);

            source.Position = 4;
            linearLayouter.NotifyItemInserted(source, 0);

            linearLayouter.NotifyItemInserted(source, 1);

            var emptySource = new CustomEmptySource();
            linearLayouter.NotifyItemInserted(emptySource, 1);

            view.Dispose();
            linearLayouter.Dispose();

            source.Dispose();
            emptySource.Dispose();

            tlog.Debug(tag, $"LinearLayouterNotifyItemInserted END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LinearLayouter NotifyItemRangeInserted.")]
        [Property("SPEC", "Tizen.NUI.Components.LinearLayouter.NotifyItemRangeInserted M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "xiaohui.fang@samsung.com")]
        public void LinearLayouterNotifyItemRangeInserted()
        {
            tlog.Debug(tag, $"LinearLayouterNotifyItemRangeInserted");

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

            var linearLayouter = new LinearLayouter();
            Assert.IsNotNull(linearLayouter, "Should not be null");

            linearLayouter.Initialize(view);
            linearLayouter.RequestLayout(100.0f);

            var source = new CustomGroupItemSource(view)
            {
                Position = 1,
                FooterIndex = 2,
            };
            linearLayouter.NotifyItemRangeInserted(source, 0, 3);

            source.Position = 6;
            linearLayouter.NotifyItemRangeInserted(source, 0, 1);

            linearLayouter.NotifyItemRangeInserted(source, 1, 1);

            view.Dispose();
            linearLayouter.Dispose();

            source.Dispose();

            tlog.Debug(tag, $"LinearLayouterNotifyItemRangeInserted END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LinearLayouter NotifyItemRemoved.")]
        [Property("SPEC", "Tizen.NUI.Components.LinearLayouter.NotifyItemRemoved M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "xiaohui.fang@samsung.com")]
        public void LinearLayouterNotifyItemRemoved()
        {
            tlog.Debug(tag, $"LinearLayouterNotifyItemRemoved");

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

            var linearLayouter = new LinearLayouter();
            Assert.IsNotNull(linearLayouter, "Should not be null");

            linearLayouter.Initialize(view);
            linearLayouter.RequestLayout(100.0f);

            var source = new CustomGroupItemSource(view)
            {
                Position = 1,
            };

            linearLayouter.NotifyItemRangeInserted(source, 0, 1);
            linearLayouter.NotifyItemRemoved(source, 0);

            linearLayouter.NotifyItemRangeInserted(source, 0, 2);
            linearLayouter.NotifyItemRemoved(source, 1);

            var emptySource = new CustomEmptySource();
            linearLayouter.NotifyItemInserted(emptySource, 1);
            linearLayouter.NotifyItemRemoved(emptySource, 1);

            view.Dispose();
            linearLayouter.Dispose();

            source.Dispose();
            emptySource.Dispose();

            tlog.Debug(tag, $"LinearLayouterNotifyItemRemoved END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LinearLayouter NotifyItemRangeRemoved.")]
        [Property("SPEC", "Tizen.NUI.Components.LinearLayouter.NotifyItemRangeRemoved M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "xiaohui.fang@samsung.com")]
        public void LinearLayouterNotifyItemRangeRemoved()
        {
            tlog.Debug(tag, $"LinearLayouterNotifyItemRangeRemoved");

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

            var linearLayouter = new LinearLayouter();
            Assert.IsNotNull(linearLayouter, "Should not be null");

            linearLayouter.Initialize(view);
            linearLayouter.RequestLayout(100.0f);

            var source = new CustomGroupItemSource(view)
            {
                Position = 1,
            };

            linearLayouter.NotifyItemRangeInserted(source, 0, 1);
            linearLayouter.NotifyItemRangeRemoved(source, 0, 1);

            view.Dispose();
            linearLayouter.Dispose();

            source.Dispose();

            tlog.Debug(tag, $"LinearLayouterNotifyItemRangeRemoved END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LinearLayouter NotifyItemMoved.")]
        [Property("SPEC", "Tizen.NUI.Components.LinearLayouter.NotifyItemMoved M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "xiaohui.fang@samsung.com")]
        public void LinearLayouterNotifyItemMoved()
        {
            tlog.Debug(tag, $"LinearLayouterNotifyItemMoved");

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

            var linearLayouter = new LinearLayouter();
            Assert.IsNotNull(linearLayouter, "Should not be null");

            linearLayouter.Initialize(view);
            linearLayouter.RequestLayout(100.0f);

            var source = new CustomGroupItemSource(view)
            {
                Position = 1,
            };

            linearLayouter.NotifyItemRangeInserted(source, 0, 10);
            linearLayouter.NotifyItemMoved(source, 1, 22);

            view.Dispose();
            linearLayouter.Dispose();

            source.Dispose();

            tlog.Debug(tag, $"LinearLayouterNotifyItemMoved END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LinearLayouter NotifyItemRangeMoved.")]
        [Property("SPEC", "Tizen.NUI.Components.LinearLayouter.NotifyItemRangeMoved M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "xiaohui.fang@samsung.com")]
        public void LinearLayouterNotifyItemRangeMoved()
        {
            tlog.Debug(tag, $"LinearLayouterNotifyItemRangeMoved");

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

            var linearLayouter = new LinearLayouter();
            Assert.IsNotNull(linearLayouter, "Should not be null");

            linearLayouter.Initialize(view);
            linearLayouter.RequestLayout(100.0f);

            var source = new CustomGroupItemSource(view)
            {
                Position = 1,
            };

            var orientationSize = linearLayouter.CalculateLayoutOrientationSize();
            Assert.AreEqual(orientationSize, 6);

            var scrollPosition = linearLayouter.CalculateCandidateScrollPosition(0.0f);
            Assert.AreEqual(scrollPosition, 0.0f);

            linearLayouter.NotifyItemRangeInserted(source, 0, 10);
            linearLayouter.NotifyItemRangeMoved(source, 11, 16, 5);

            view.Dispose();
            linearLayouter.Dispose();

            source.Dispose();

            tlog.Debug(tag, $"LinearLayouterNotifyItemRangeMoved END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LinearLayouter RequestNextFocusableView.")]
        [Property("SPEC", "Tizen.NUI.Components.LinearLayouter.RequestNextFocusableView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "xiaohui.fang@samsung.com")]
        public void LinearLayouterRequestNextFocusableView()
        {
            tlog.Debug(tag, $"LinearLayouterRequestNextFocusableView");

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

            var linearLayouter = new LinearLayouter();
            Assert.IsNotNull(linearLayouter, "Should not be null");

            linearLayouter.Initialize(view);
            linearLayouter.RequestLayout(100.0f);

            var source = new CustomGroupItemSource(view)
            {
                Position = 1,
            };

            var orientationSize = linearLayouter.CalculateLayoutOrientationSize();
            Assert.AreEqual(orientationSize, 6);

            var scrollPosition = linearLayouter.CalculateCandidateScrollPosition(0.0f);
            Assert.AreEqual(scrollPosition, 0.0f);

            linearLayouter.NotifyItemRangeInserted(source, 0, 10);

            linearLayouter.RequestNextFocusableView(view, View.FocusDirection.Up, true);
            linearLayouter.RequestNextFocusableView(view, View.FocusDirection.Down, true);
            linearLayouter.RequestNextFocusableView(view, View.FocusDirection.PageUp, true);
            linearLayouter.RequestNextFocusableView(view, View.FocusDirection.PageDown, true);
            linearLayouter.RequestNextFocusableView(view, View.FocusDirection.Left, true);
            linearLayouter.RequestNextFocusableView(view, View.FocusDirection.Right, true);

            view.Dispose();
            linearLayouter.Dispose();

            source.Dispose();

            tlog.Debug(tag, $"LinearLayouterRequestNextFocusableView END (OK)");
        }
    }
}
