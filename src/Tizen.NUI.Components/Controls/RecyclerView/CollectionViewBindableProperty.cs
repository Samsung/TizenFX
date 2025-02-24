using System;
using System.ComponentModel;
using System.Windows.Input;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    public partial class CollectionView
    {
        /// <summary>
        /// ItemsLayouterProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ItemsLayouterProperty = null;
        internal static void SetInternalItemsLayouterProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = bindable as CollectionView;
            if (instance == null)
            {
                throw new Exception("Bindable object is not CollectionView.");
            }
            if (newValue != null)
            {
                instance.InternalItemsLayouter = newValue as ItemsLayouter;
            }
        }
        internal static object GetInternalItemsLayouterProperty(BindableObject bindable)
        {
            var instance = bindable as CollectionView;
            if (instance == null)
            {
                throw new Exception("Bindable object is not CollectionView.");
            }
            return instance.InternalItemsLayouter;
        }

        /// <summary>
        /// ScrollingDirectionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly new BindableProperty ScrollingDirectionProperty = null;
        internal static void SetInternalScrollingDirectionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = bindable as CollectionView;
            if (instance == null)
            {
                throw new Exception("Bindable object is not CollectionView.");
            }
            if (newValue != null)
            {
                instance.InternalScrollingDirection = (Direction)newValue;
            }
        }
        internal static object GetInternalScrollingDirectionProperty(BindableObject bindable)
        {
            var instance = bindable as CollectionView;
            if (instance == null)
            {
                throw new Exception("Bindable object is not CollectionView.");
            }
            return instance.InternalScrollingDirection;
        }

        /// <summary>
        /// SelectionChangedCommandProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionChangedCommandProperty = null;
        internal static void SetInternalSelectionChangedCommandProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = bindable as CollectionView;
            if (instance == null)
            {
                throw new Exception("Bindable object is not CollectionView.");
            }
            if (newValue != null)
            {
                instance.InternalSelectionChangedCommand = newValue as ICommand;
            }
        }
        internal static object GetInternalSelectionChangedCommandProperty(BindableObject bindable)
        {
            var instance = bindable as CollectionView;
            if (instance == null)
            {
                throw new Exception("Bindable object is not CollectionView.");
            }
            return instance.InternalSelectionChangedCommand;
        }

        /// <summary>
        /// SelectionChangedCommandParameterProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionChangedCommandParameterProperty = null;
        internal static void SetInternalSelectionChangedCommandParameterProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = bindable as CollectionView;
            if (instance == null)
            {
                throw new Exception("Bindable object is not CollectionView.");
            }
            if (newValue != null)
            {
                instance.InternalSelectionChangedCommandParameter = newValue;
            }
        }
        internal static object GetInternalSelectionChangedCommandParameterProperty(BindableObject bindable)
        {
            var instance = bindable as CollectionView;
            if (instance == null)
            {
                throw new Exception("Bindable object is not CollectionView.");
            }
            return instance.InternalSelectionChangedCommandParameter;
        }

        /// <summary>
        /// HeaderProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HeaderProperty = null;
        internal static void SetInternalHeaderProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = bindable as CollectionView;
            if (instance == null)
            {
                throw new Exception("Bindable object is not CollectionView.");
            }
            if (newValue != null)
            {
                instance.InternalHeader = newValue as RecyclerViewItem;
            }
        }
        internal static object GetInternalHeaderProperty(BindableObject bindable)
        {
            var instance = bindable as CollectionView;
            if (instance == null)
            {
                throw new Exception("Bindable object is not CollectionView.");
            }
            return instance.InternalHeader;
        }

        /// <summary>
        /// FooterProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FooterProperty = null;
        internal static void SetInternalFooterProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = bindable as CollectionView;
            if (instance == null)
            {
                throw new Exception("Bindable object is not CollectionView.");
            }
            if (newValue != null)
            {
                instance.InternalFooter = newValue as RecyclerViewItem;
            }
        }
        internal static object GetInternalFooterProperty(BindableObject bindable)
        {
            var instance = bindable as CollectionView;
            if (instance == null)
            {
                throw new Exception("Bindable object is not CollectionView.");
            }
            return instance.InternalFooter;
        }

        /// <summary>
        /// IsGroupedProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IsGroupedProperty = null;
        internal static void SetInternalIsGroupedProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = bindable as CollectionView;
            if (instance == null)
            {
                throw new Exception("Bindable object is not CollectionView.");
            }
            if (newValue != null)
            {
                instance.InternalIsGrouped = (bool)newValue;
            }
        }
        internal static object GetInternalIsGroupedProperty(BindableObject bindable)
        {
            var instance = bindable as CollectionView;
            if (instance == null)
            {
                throw new Exception("Bindable object is not CollectionView.");
            }
            return instance.InternalIsGrouped;
        }

        /// <summary>
        /// GroupHeaderTemplateProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty GroupHeaderTemplateProperty = null;
        internal static void SetInternalGroupHeaderTemplateProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = bindable as CollectionView;
            if (instance == null)
            {
                throw new Exception("Bindable object is not CollectionView.");
            }
            if (newValue != null)
            {
                instance.InternalGroupHeaderTemplate = newValue as DataTemplate;
            }
        }
        internal static object GetInternalGroupHeaderTemplateProperty(BindableObject bindable)
        {
            var instance = bindable as CollectionView;
            if (instance == null)
            {
                throw new Exception("Bindable object is not CollectionView.");
            }
            return instance.InternalGroupHeaderTemplate;
        }

        /// <summary>
        /// GroupFooterTemplateProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty GroupFooterTemplateProperty = null;
        internal static void SetInternalGroupFooterTemplateProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = bindable as CollectionView;
            if (instance == null)
            {
                throw new Exception("Bindable object is not CollectionView.");
            }
            if (newValue != null)
            {
                instance.InternalGroupFooterTemplate = newValue as DataTemplate;
            }
        }
        internal static object GetInternalGroupFooterTemplateProperty(BindableObject bindable)
        {
            var instance = bindable as CollectionView;
            if (instance == null)
            {
                throw new Exception("Bindable object is not CollectionView.");
            }
            return instance.InternalGroupFooterTemplate;
        }
    }
}
