/* Copyright (c) 2022 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using System;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// This class provides a basic item for CollectionView.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public partial class RecyclerViewItem : Control
    {
        /// <summary>
        /// Property of boolean Enable flag.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public new static readonly BindableProperty IsEnabledProperty = View.IsEnabledProperty;

        /// <summary>
        /// Property of boolean Selected flag.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public static readonly BindableProperty IsSelectedProperty = null;
        internal static void SetInternalIsSelectedProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (RecyclerViewItem)bindable;
                instance.SetInternalIsSelected((bool)newValue);
            }
        }
        internal static object GetInternalIsSelectedProperty(BindableObject bindable)
        {
            var instance = (RecyclerViewItem)bindable;
            return instance.GetInternalIsSelected();
        }

        /// <summary>
        /// Property of boolean Selectable flag.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public static readonly BindableProperty IsSelectableProperty = null;
        internal static void SetInternalIsSelectableProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (RecyclerViewItem)bindable;
                instance.SetInternalIsSelectable((bool)newValue);
            }
        }
        internal static object GetInternalIsSelectableProperty(BindableObject bindable)
        {
            var instance = (RecyclerViewItem)bindable;
            return instance.GetInternalIsSelectable();
        }

        private bool isSelected = false;
        private bool isSelectable = true;

        static RecyclerViewItem()
        {
            if (NUIApplication.IsUsingXaml)
            {
                IsSelectedProperty = BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(RecyclerViewItem), false,
                    propertyChanged: SetInternalIsSelectedProperty, defaultValueCreator: GetInternalIsSelectedProperty);
                IsSelectableProperty = BindableProperty.Create(nameof(IsSelectable), typeof(bool), typeof(RecyclerViewItem), true,
                    propertyChanged: SetInternalIsSelectableProperty, defaultValueCreator: GetInternalIsSelectableProperty);
            }
        }

        /// <summary>
        /// Creates a new instance of RecyclerViewItem.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public RecyclerViewItem() : base()
        {
        }

        /// <summary>
        /// Creates a new instance of RecyclerViewItem with style.
        /// </summary>
        /// <param name="style">Create RecyclerViewItem by special style defined in UX.</param>
        /// <since_tizen> 9 </since_tizen>
        public RecyclerViewItem(string style) : base(style)
        {
        }

        /// <summary>
        /// Creates a new instance of a RecyclerViewItem with style.
        /// </summary>
        /// <param name="itemStyle">Create RecyclerViewItem by style customized by user.</param>
        /// <since_tizen> 9 </since_tizen>
        public RecyclerViewItem(RecyclerViewItemStyle itemStyle) : base(itemStyle)
        {
        }

        /// <summary>
        /// An event for the RecyclerViewItem clicked signal which can be used to subscribe or unsubscribe the event handler provided by the user.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public event EventHandler<ClickedEventArgs> Clicked;

        /// <summary>
        /// Flag to decide RecyclerViewItem can be selected or not.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public bool IsSelectable
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(IsSelectableProperty);
                }
                else
                {
                    return GetInternalIsSelectable();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(IsSelectableProperty, value);
                }
                else
                {
                    SetInternalIsSelectable(value);
                }
                OnPropertyChanged(nameof(IsSelectable));
            }
        }

        private void SetInternalIsSelectable(bool newValue)
        {
            bool newSelectable = newValue;
            if (isSelectable != newSelectable)
            {
                isSelectable = newSelectable;
                UpdateState();
            }
        }

        private bool GetInternalIsSelectable()
        {
            return isSelectable;
        }

        /// <summary>
        /// Flag to decide selected state in RecyclerViewItem.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public bool IsSelected
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(IsSelectedProperty);
                }
                else
                {
                    return GetInternalIsSelected();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(IsSelectedProperty, value);
                }
                else
                {
                    SetInternalIsSelected(value);
                }
                OnPropertyChanged(nameof(IsSelected));
            }
        }

        private void SetInternalIsSelected(bool newValue)
        {
            bool newSelected = newValue;
            if (isSelected != newSelected)
            {
                isSelected = newSelected;

                if (isSelectable)
                {
                    UpdateState();
                }
                if (ParentItemsView is CollectionView collectionView)
                {
                    var context = BindingContext;
                    if (collectionView.SelectionMode is ItemSelectionMode.Single ||
                        collectionView.SelectionMode is ItemSelectionMode.SingleAlways)
                    {
                        if (newSelected && collectionView.SelectedItem != context)
                        {
                            collectionView.SelectedItem = context;
                        }
                        else if (!newSelected && collectionView.SelectedItem == context)
                        {
                            collectionView.SelectedItem = null;
                        }
                    }
                    else if (collectionView.SelectionMode is ItemSelectionMode.Multiple)
                    {
                        var selectedList = collectionView.SelectedItems;
                        if (selectedList != null && context != null)
                        {
                            bool contains = selectedList.Contains(context);
                            if (newSelected && !contains)
                            {
                                selectedList.Add(context);
                            }
                            else if (!newSelected && contains)
                            {
                                selectedList.Remove(context);
                            }
                        }
                    }
                }
            }
        }

        private bool GetInternalIsSelected()
        {
            return isSelectable && isSelected;
        }

        /// <summary>
        /// Flag to decide enabled state in RecyclerViewItem.
        /// Set enabled state false makes item untouchable and unfocusable.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public new bool IsEnabled
        {
            get => base.IsEnabled;
            set
            {
                base.IsEnabled = value;
            }
        }

        /// <summary>
        /// Data index which is binded to item.
        /// Can access to data using this index.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Index { get; internal set; } = 0;

        /// <summary>
        /// DataTemplate of this view object
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DataTemplate Template { get; internal set; }

        /// <summary>
        /// State of Realization
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsRealized { get; internal set; }

        /// <summary>
        /// State of Pressed.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsPressed { get; set; } = false;

        /// <summary>
        /// Boolean flag to check this item is header.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsHeader { get; set; }

        /// <summary>
        /// Boolean flag to check this item is footer.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsFooter { get; set; }

        /// <summary>
        /// Boolean flag to check this item is group header.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsGroupHeader { get; set; }

        /// <summary>
        /// Boolean flag to check this item is group footer.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsGroupFooter { get; set; }


        /// <summary>
        /// Called after a key event is received by the view that has had its focus set.
        /// </summary>
        /// <param name="key">The key event.</param>
        /// <returns>True if the key event should be consumed.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool OnKey(Key key)
        {
            bool clicked = false;

            if (!IsEnabled || null == key)
            {
                return false;
            }

            if (key.State == Key.StateType.Down)
            {
                if (key.KeyPressedName == "Return")
                {
                    IsPressed = true;
                    UpdateState();
                }
            }
            else if (key.State == Key.StateType.Up)
            {
                if (key.KeyPressedName == "Return")
                {
                    clicked = IsPressed && IsEnabled;

                    IsPressed = false;

                    if (IsSelectable && BindingContext != null && ParentItemsView is CollectionView colView)
                    {
                        switch (colView.SelectionMode)
                        {
                            case ItemSelectionMode.Single:
                                colView.SelectedItem = IsSelected ? null : BindingContext;
                                break;
                            case ItemSelectionMode.SingleAlways:
                                if (colView.SelectedItem != BindingContext)
                                    colView.SelectedItem = BindingContext;
                                break;
                            case ItemSelectionMode.Multiple:
                                var selectedItems = colView.SelectedItems;
                                if (selectedItems.Contains(BindingContext)) selectedItems.Remove(BindingContext);
                                else selectedItems.Add(BindingContext);
                                break;
                            case ItemSelectionMode.None:
                                break;
                        }
                    }
                    else if (IsSelectable)
                    {
                        IsSelected = !IsSelected;
                    }

                    if (clicked)
                    {
                        ClickedEventArgs eventArgs = new ClickedEventArgs();
                        OnClickedInternal(eventArgs);
                    }

                    UpdateState();
                }
            }
            return base.OnKey(key) || clicked;
        }

        /// <summary>
        /// Called when the control gain key input focus. Should be overridden by derived classes if they need to customize what happens when the focus is gained.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnFocusGained()
        {
            base.OnFocusGained();
            UpdateState();
        }

        /// <summary>
        /// Called when the control loses key input focus.
        /// Should be overridden by derived classes if they need to customize
        /// what happens when the focus is lost.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnFocusLost()
        {
            base.OnFocusLost();
            UpdateState();
        }

        /// <summary>
        /// Apply style to RecyclerViewItem.
        /// </summary>
        /// <param name="viewStyle">The style to apply.</param>
        /// <since_tizen> 9 </since_tizen>
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            styleApplied = false;

            base.ApplyStyle(viewStyle);
            if (viewStyle != null)
            {
                //Extension = RecyclerViewItemStyle.CreateExtension();
                //FIXME : currently padding and margin are not applied by ApplyStyle automatically as missing binding features.
                Padding = new Extents(viewStyle.Padding);
                Margin = new Extents(viewStyle.Margin);
            }

            styleApplied = true;
        }

        /// <summary>
        /// Get ViewItem style.
        /// </summary>
        /// <returns>The default ViewItem style.</returns>
        /// <since_tizen> 9 </since_tizen>
        protected override ViewStyle CreateViewStyle()
        {
            return new RecyclerViewItemStyle();
        }

        /// <summary>
        /// Called when the ViewItem is Clicked by a user
        /// </summary>
        /// <param name="eventArgs">The click information.</param>
        /// <since_tizen> 9 </since_tizen>
        protected virtual void OnClicked(ClickedEventArgs eventArgs)
        {
            //Console.WriteLine("On Clicked Called {0}", this.Index);
        }

        /// <inheritdoc/>
        /// <since_tizen> 9 </since_tizen>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                //
            }

            base.Dispose(type);
        }
    }
}
