using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    public partial class CollectionView
    {
        /// <summary>
        /// Binding Property of selected item in single selection.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public static readonly BindableProperty SelectedItemProperty = null;
        internal static void SetInternalSelectedItemProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var colView = bindable as CollectionView;
            if (colView == null)
            {
                throw new Exception("Bindable object is not CollectionView.");
            }

            oldValue = colView.selectedItem;
            colView.selectedItem = newValue;

            var args = new SelectionChangedEventArgs(oldValue, newValue);
            foreach (RecyclerViewItem item in colView.ContentContainer.Children.Where((item) => item is RecyclerViewItem))
            {
                if (item.BindingContext == null)
                {
                    continue;
                }

                if (item.BindingContext == oldValue)
                {
                    item.IsSelected = false;
                }
                else if (item.BindingContext == newValue)
                {
                    item.IsSelected = true;
                }
            }
            SelectionPropertyChanged(colView, args);
        }
        internal static object GetInternalSelectedItemProperty(BindableObject bindable)
        {
            var colView = bindable as CollectionView;
            if (colView == null)
            {
                throw new Exception("Bindable object is not CollectionView.");
            }
            return colView.selectedItem;
        }

        /// <summary>
        /// Binding Property of selected items list in multiple selection.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public static readonly BindableProperty SelectedItemsProperty = null;
        internal static void SetInternalSelectedItemsProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var colView = bindable as CollectionView;
            if (colView == null)
            {
                throw new Exception("Bindable object is not CollectionView.");
            }

            var oldSelection = colView.selectedItems ?? selectEmpty;
            //FIXME : CoerceSelectedItems calls only isCreatedByXaml
            var newSelection = (SelectionList)CoerceSelectedItems(colView, newValue);
            colView.selectedItems = newSelection;
            colView.SelectedItemsPropertyChanged(oldSelection, newSelection);
        }
        internal static object GetInternalSelectedItemsProperty(BindableObject bindable)
        {
            var colView = bindable as CollectionView;
            if (colView == null)
            {
                throw new Exception("Bindable object is not CollectionView.");
            }
            return colView.GetInternalSelectedItems();
        }

        /// <summary>
        /// Binding Property of selected items list in multiple selection.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public static readonly BindableProperty SelectionModeProperty = null;
        internal static void SetInternalSelectionModeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var colView = bindable as CollectionView;
            if (colView == null)
            {
                throw new Exception("Bindable object is not CollectionView.");
            }
            colView.SetInternalSelectionMode((ItemSelectionMode)newValue);
        }
        internal static object GetInternalSelectionModeProperty(BindableObject bindable)
        {
            var colView = bindable as CollectionView;
            if (colView == null)
            {
                throw new Exception("Bindable object is not CollectionView.");
            }
            return colView.GetInternalSelectionMode();
        }

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
        internal static new void SetInternalScrollingDirectionProperty(BindableObject bindable, object oldValue, object newValue)
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
        internal static new object GetInternalScrollingDirectionProperty(BindableObject bindable)
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
