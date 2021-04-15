/* Copyright (c) 2021 Samsung Electronics Co., Ltd.
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
        public static readonly BindableProperty IsEnabledProperty = BindableProperty.Create(nameof(IsEnabled), typeof(bool), typeof(RecyclerViewItem), true, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (RecyclerViewItem)bindable;
            if (newValue != null)
            {
                bool newEnabled = (bool)newValue;
                if (instance.isEnabled != newEnabled)
                {
                    instance.isEnabled = newEnabled;
                    instance.UpdateState();
                }
            }
        },
        defaultValueCreator: (bindable) => ((RecyclerViewItem)bindable).isEnabled);

        /// <summary>
        /// Property of boolean Selected flag.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(RecyclerViewItem), true, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (RecyclerViewItem)bindable;
            if (newValue != null)
            {
                bool newSelected = (bool)newValue;
                if (instance.isSelected != newSelected)
                {
                    instance.isSelected = newSelected;

                    if (instance.isSelectable)
                    {
                        instance.UpdateState();
                    }
                }
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (RecyclerViewItem)bindable;
            return instance.isSelectable && instance.isSelected;
        });

        /// <summary>
        /// Property of boolean Selectable flag.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public static readonly BindableProperty IsSelectableProperty = BindableProperty.Create(nameof(IsSelectable), typeof(bool), typeof(RecyclerViewItem), true, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (RecyclerViewItem)bindable;
            if (newValue != null)
            {
                bool newSelectable = (bool)newValue;
                if (instance.isSelectable != newSelectable)
                {
                    instance.isSelectable = newSelectable;
                    instance.UpdateState();
                }
            }
        },
        defaultValueCreator: (bindable) => ((RecyclerViewItem)bindable).isSelectable);

        private bool isSelected = false;
        private bool isSelectable = true;
        private bool isEnabled = true;
        private RecyclerViewItemStyle ItemStyle => ViewStyle as RecyclerViewItemStyle;

        static RecyclerViewItem() { }

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
            get => (bool)GetValue(IsSelectableProperty);
            set => SetValue(IsSelectableProperty, value);
        }

        /// <summary>
        /// Flag to decide selected state in RecyclerViewItem.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public bool IsSelected
        {
            get => (bool)GetValue(IsSelectedProperty);
            set => SetValue(IsSelectedProperty, value);
        }

        /// <summary>
        /// Flag to decide enabled state in RecyclerViewItem.
        /// Set enabled state false makes item untouchable and unfocusable.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public bool IsEnabled
        {
            get => (bool)GetValue(IsEnabledProperty);
            set => SetValue(IsEnabledProperty, value);
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
        internal bool IsHeader { get; set; }
        internal bool IsFooter { get; set; }
        internal bool IsPressed { get; set; } = false;

        /// <summary>
        /// Called after a key event is received by the view that has had its focus set.
        /// </summary>
        /// <param name="key">The key event.</param>
        /// <returns>True if the key event should be consumed.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool OnKey(Key key)
        {
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
                    bool clicked = IsPressed && IsEnabled;

                    IsPressed = false;

                    if (IsSelectable)
                    {
                        // Extension : Extension?.SetTouchInfo(touch);
                        if (ParentItemsView as CollectionView)
                        {
                            CollectionView colView = ParentItemsView as CollectionView;
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
                    }
                    else
                    {
                        UpdateState();
                    }

                    if (clicked)
                    {
                        ClickedEventArgs eventArgs = new ClickedEventArgs();
                        OnClickedInternal(eventArgs);
                    }
                }
            }
            return base.OnKey(key);
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
