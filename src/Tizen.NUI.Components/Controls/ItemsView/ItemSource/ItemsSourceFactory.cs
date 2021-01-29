using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
//using AndroidX.RecyclerView.Widget; ??? need to find whot it needs? adapter?

namespace Tizen.NUI.Components
{
    internal static class ItemsSourceFactory
    {
        public static IItemSource Create(IEnumerable itemsSource, ICollectionChangedNotifier notifier)
        {
            if (itemsSource == null)
            {
                return new EmptySource();
            }

            switch (itemsSource)
            {
                case IList list when itemsSource is INotifyCollectionChanged:
                    return new ObservableItemSource(new MarshalingObservableCollection(list), notifier);
                case IEnumerable _ when itemsSource is INotifyCollectionChanged:
                    return new ObservableItemSource(itemsSource, notifier);
                case IEnumerable<object> generic:
                    return new ListSource(generic);
            }

            return new ListSource(itemsSource);
        }

        public static IItemSource Create(ItemsView itemsView)
        {
            return Create(itemsView.ItemsSource, itemsView);
        }

        public static IGroupableItemSource Create(CollectionView colView)
        {
            var source = colView.ItemsSource;

            if (colView.IsGrouped && source != null)
                return new ObservableGroupedSource(colView, colView);

            else
                return new UngroupedItemSource(Create(colView.ItemsSource, colView));
        }
    }
}
