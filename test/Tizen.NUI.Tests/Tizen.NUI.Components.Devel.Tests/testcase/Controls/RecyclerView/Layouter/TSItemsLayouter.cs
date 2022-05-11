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
    public class ItemsLayouterTest
    {
        private const string tag = "NUITEST";

        internal class ItemsLayouterImpl : ItemsLayouter
        {
            public ItemsLayouterImpl() : base()
            { }

            public override float CalculateLayoutOrientationSize()
            {
                return base.CalculateLayoutOrientationSize();
            }

            public override float CalculateCandidateScrollPosition(float scrollPosition)
            {
                return base.CalculateCandidateScrollPosition(scrollPosition);
            }

            public override void NotifyDataSetChanged()
            {
                base.NotifyDataSetChanged();
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
        [Description("ItemsLayouter CalculateLayoutOrientationSize.")]
        [Property("SPEC", "Tizen.NUI.Components.ItemsLayouter.CalculateLayoutOrientationSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemsLayouterCalculateLayoutOrientationSize()
        {
            tlog.Debug(tag, $"ItemsLayouterCalculateLayoutOrientationSize START");

            var view = new CollectionView(new List<string>() { "123", "456", "789" })
            {
                Header = new RecyclerViewItem(),
                Footer = new RecyclerViewItem(),
                IsGrouped = true,
            };
            Assert.IsNotNull(view, "Should not be null");

#pragma warning disable Reflection // The code contains reflection
            view.GroupFooterTemplate = new DataTemplate(typeof(RecyclerViewItem));
#pragma warning restore Reflection // The code contains reflection
#pragma warning disable Reflection // The code contains reflection
            view.GroupHeaderTemplate = new DataTemplate(typeof(RecyclerViewItem));
#pragma warning restore Reflection // The code contains reflection
#pragma warning disable Reflection // The code contains reflection
            view.ItemTemplate = new DataTemplate(typeof(RecyclerViewItem));
#pragma warning restore Reflection // The code contains reflection

            var itemsLayouter = new ItemsLayouterImpl();
            Assert.IsNotNull(itemsLayouter, "Should not be null");

            itemsLayouter.Initialize(view);

            try
            {
                itemsLayouter.CalculateLayoutOrientationSize();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            view.Dispose();
            itemsLayouter.Dispose();

            tlog.Debug(tag, $"ItemsLayouterCalculateLayoutOrientationSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemsLayouter CalculateCandidateScrollPosition.")]
        [Property("SPEC", "Tizen.NUI.Components.ItemsLayouter.CalculateCandidateScrollPosition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemsLayouterCalculateCandidateScrollPosition()
        {
            tlog.Debug(tag, $"ItemsLayouterCalculateCandidateScrollPosition START");

            var view = new CollectionView(new List<string>() { "123", "456", "789" })
            {
                Header = new RecyclerViewItem(),
                Footer = new RecyclerViewItem(),
                IsGrouped = true,
            };
            Assert.IsNotNull(view, "Should not be null");

#pragma warning disable Reflection // The code contains reflection
            view.GroupFooterTemplate = new DataTemplate(typeof(RecyclerViewItem));
#pragma warning restore Reflection // The code contains reflection
#pragma warning disable Reflection // The code contains reflection
            view.GroupHeaderTemplate = new DataTemplate(typeof(RecyclerViewItem));
#pragma warning restore Reflection // The code contains reflection
#pragma warning disable Reflection // The code contains reflection
            view.ItemTemplate = new DataTemplate(typeof(RecyclerViewItem));
#pragma warning restore Reflection // The code contains reflection

            var itemsLayouter = new ItemsLayouterImpl();
            Assert.IsNotNull(itemsLayouter, "Should not be null");

            itemsLayouter.Initialize(view);

            try
            {
                itemsLayouter.CalculateCandidateScrollPosition(0.3f);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            view.Dispose();
            itemsLayouter.Dispose();

            tlog.Debug(tag, $"ItemsLayouterCalculateCandidateScrollPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemsLayouter NotifyDataSetChanged.")]
        [Property("SPEC", "Tizen.NUI.Components.ItemsLayouter.NotifyDataSetChanged M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemsLayouterNotifyDataSetChanged()
        {
            tlog.Debug(tag, $"ItemsLayouterNotifyDataSetChanged START");

            var view = new CollectionView(new List<string>() { "123", "456", "789" })
            {
                Header = new RecyclerViewItem(),
                Footer = new RecyclerViewItem(),
                IsGrouped = true,
            };
            Assert.IsNotNull(view, "Should not be null");

#pragma warning disable Reflection // The code contains reflection
            view.GroupFooterTemplate = new DataTemplate(typeof(RecyclerViewItem));
#pragma warning restore Reflection // The code contains reflection
#pragma warning disable Reflection // The code contains reflection
            view.GroupHeaderTemplate = new DataTemplate(typeof(RecyclerViewItem));
#pragma warning restore Reflection // The code contains reflection
#pragma warning disable Reflection // The code contains reflection
            view.ItemTemplate = new DataTemplate(typeof(RecyclerViewItem));
#pragma warning restore Reflection // The code contains reflection

            var itemsLayouter = new ItemsLayouterImpl();
            Assert.IsNotNull(itemsLayouter, "Should not be null");

            itemsLayouter.Initialize(view);

            try
            {
                itemsLayouter.NotifyDataSetChanged();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            view.Dispose();
            itemsLayouter.Dispose();

            tlog.Debug(tag, $"ItemsLayouterNotifyDataSetChanged END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ItemsLayouter RequestNextFocusableView.")]
        [Property("SPEC", "Tizen.NUI.Components.ItemsLayouter.RequestNextFocusableView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "xiaohui.fang@samsung.com")]
        public void ItemsLayouterRequestNextFocusableView()
        {
            tlog.Debug(tag, $"ItemsLayouterRequestNextFocusableView");

            var view = new CollectionView(new List<string>() { "123", "456" })
            {
                Header = new RecyclerViewItem(),
                Footer = new RecyclerViewItem(),
                IsGrouped = true,
            };
            Assert.IsNotNull(view, "Should not be null");

#pragma warning disable Reflection // The code contains reflection
            view.GroupFooterTemplate = new DataTemplate(typeof(RecyclerViewItem));
#pragma warning restore Reflection // The code contains reflection
#pragma warning disable Reflection // The code contains reflection
            view.GroupHeaderTemplate = new DataTemplate(typeof(RecyclerViewItem));
#pragma warning restore Reflection // The code contains reflection
#pragma warning disable Reflection // The code contains reflection
            view.ItemTemplate = new DataTemplate(typeof(RecyclerViewItem));
#pragma warning restore Reflection // The code contains reflection

            var itemsLayouter = new ItemsLayouterImpl();
            Assert.IsNotNull(itemsLayouter, "Should not be null");

            itemsLayouter.Initialize(view);
            itemsLayouter.RequestLayout(100.0f);

            var source = new CustomGroupItemSource(view)
            {
                Position = 1,
            };

            var orientationSize = itemsLayouter.CalculateLayoutOrientationSize();
            tlog.Debug(tag, "orientationSize : " + orientationSize);

            var scrollPosition = itemsLayouter.CalculateCandidateScrollPosition(0.0f);
            tlog.Debug(tag, "scrollPosition : " + scrollPosition);

            itemsLayouter.NotifyItemRangeInserted(source, 0, 10);

            itemsLayouter.RequestNextFocusableView(view, View.FocusDirection.Up, true);
            itemsLayouter.RequestNextFocusableView(view, View.FocusDirection.Down, true);
            itemsLayouter.RequestNextFocusableView(view, View.FocusDirection.PageUp, true);
            itemsLayouter.RequestNextFocusableView(view, View.FocusDirection.PageDown, true);
            itemsLayouter.RequestNextFocusableView(view, View.FocusDirection.Left, true);
            itemsLayouter.RequestNextFocusableView(view, View.FocusDirection.Right, true);

            view.Dispose();
            itemsLayouter.Dispose();

            source.Dispose();

            tlog.Debug(tag, $"ItemsLayouterRequestNextFocusableView END (OK)");
        }
    }
}
