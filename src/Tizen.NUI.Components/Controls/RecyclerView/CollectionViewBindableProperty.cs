using System.ComponentModel;
using System.Windows.Input;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    public partial class CollectionView
    {
        /// <summary>
        /// ItemTemplateProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly new BindableProperty ItemTemplateProperty = BindableProperty.Create(nameof(ItemTemplate), typeof(DataTemplate), typeof(CollectionView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (CollectionView)bindable;
            if (newValue != null)
            {
                instance.InternalItemTemplate = newValue as DataTemplate;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (CollectionView)bindable;
            return instance.InternalItemTemplate;
        });

        /// <summary>
        /// ItemsLayouterProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ItemsLayouterProperty = BindableProperty.Create(nameof(ItemsLayouter), typeof(ItemsLayouter), typeof(CollectionView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (CollectionView)bindable;
            if (newValue != null)
            {
                instance.InternalItemsLayouter = newValue as ItemsLayouter;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (CollectionView)bindable;
            return instance.InternalItemsLayouter;
        });

        /// <summary>
        /// ScrollingDirectionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly new BindableProperty ScrollingDirectionProperty = BindableProperty.Create(nameof(ScrollingDirection), typeof(Tizen.NUI.Components.ScrollableBase.Direction), typeof(CollectionView), default(Direction), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (CollectionView)bindable;
            if (newValue != null)
            {
                instance.InternalScrollingDirection = (Direction)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (CollectionView)bindable;
            return instance.InternalScrollingDirection;
        });

        /// <summary>
        /// SelectionChangedCommandProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionChangedCommandProperty = BindableProperty.Create(nameof(SelectionChangedCommand), typeof(ICommand), typeof(CollectionView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (CollectionView)bindable;
            if (newValue != null)
            {
                instance.InternalSelectionChangedCommand = newValue as ICommand;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (CollectionView)bindable;
            return instance.InternalSelectionChangedCommand;
        });

        /// <summary>
        /// SelectionChangedCommandParameterProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionChangedCommandParameterProperty = BindableProperty.Create(nameof(SelectionChangedCommandParameter), typeof(object), typeof(CollectionView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (CollectionView)bindable;
            if (newValue != null)
            {
                instance.InternalSelectionChangedCommandParameter = newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (CollectionView)bindable;
            return instance.InternalSelectionChangedCommandParameter;
        });

        /// <summary>
        /// HeaderProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HeaderProperty = BindableProperty.Create(nameof(Header), typeof(RecyclerViewItem), typeof(CollectionView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (CollectionView)bindable;
            if (newValue != null)
            {
                instance.InternalHeader = newValue as RecyclerViewItem;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (CollectionView)bindable;
            return instance.InternalHeader;
        });

        /// <summary>
        /// FooterProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FooterProperty = BindableProperty.Create(nameof(Footer), typeof(RecyclerViewItem), typeof(CollectionView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (CollectionView)bindable;
            if (newValue != null)
            {
                instance.InternalFooter = newValue as RecyclerViewItem;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (CollectionView)bindable;
            return instance.InternalFooter;
        });

        /// <summary>
        /// IsGroupedProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IsGroupedProperty = BindableProperty.Create(nameof(IsGrouped), typeof(bool), typeof(CollectionView), default(bool), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (CollectionView)bindable;
            if (newValue != null)
            {
                instance.InternalIsGrouped = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (CollectionView)bindable;
            return instance.InternalIsGrouped;
        });

        /// <summary>
        /// GroupHeaderTemplateProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty GroupHeaderTemplateProperty = BindableProperty.Create(nameof(GroupHeaderTemplate), typeof(DataTemplate), typeof(CollectionView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (CollectionView)bindable;
            if (newValue != null)
            {
                instance.InternalGroupHeaderTemplate = newValue as DataTemplate;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (CollectionView)bindable;
            return instance.InternalGroupHeaderTemplate;
        });

        /// <summary>
        /// GroupFooterTemplateProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty GroupFooterTemplateProperty = BindableProperty.Create(nameof(GroupFooterTemplate), typeof(DataTemplate), typeof(CollectionView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (CollectionView)bindable;
            if (newValue != null)
            {
                instance.InternalGroupFooterTemplate = newValue as DataTemplate;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (CollectionView)bindable;
            return instance.InternalGroupFooterTemplate;
        });
    }
}
