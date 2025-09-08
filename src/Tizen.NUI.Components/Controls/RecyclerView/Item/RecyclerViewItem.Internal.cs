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

namespace Tizen.NUI.Components
{
    public partial class RecyclerViewItem
    {
        internal RecyclerView ParentItemsView = null;
        internal object ParentGroup = null;
        private bool styleApplied = false;

        /// <summary>
        /// Update ViewItem State.
        /// </summary>
        internal void UpdateState()
        {
            if (!styleApplied) return;

            ControlState sourceState = ControlState;
            ControlState targetState;

            // Normal, Disabled
            targetState = IsEnabled ? ControlState.Normal : ControlState.Disabled;

            // Selected, DisabledSelected
            if (IsSelected) targetState += ControlState.Selected;

            // Pressed, PressedSelected
            if (IsPressed) targetState += ControlState.Pressed;

            // Focused, FocusedPressed, FocusedPressedSelected, DisabledFocused, DisabledSelectedFocused
            if (IsFocused) targetState += ControlState.Focused;

            if (sourceState != targetState)
            {
                ControlState = targetState;
                OnUpdate();
            }
        }

        /// <summary>
        /// Called when the ViewItem need to be updated
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate()
        {
            base.OnUpdate();
            UpdateContent();
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override bool HandleControlStateOnTouch(Touch touch)
        {
            if (!IsEnabled || null == touch)
            {
                return false;
            }

            PointStateType state = touch.GetState(0);

            switch (state)
            {
                case PointStateType.Down:
                    IsPressed = true;
                    UpdateState();
                    return true;
                case PointStateType.Interrupted:
                case PointStateType.Motion:
                case PointStateType.Leave:
                    IsPressed = false;
                    UpdateState();
                    return false;
                case PointStateType.Up:
                    {
                        bool clicked = IsPressed && IsEnabled;
                        IsPressed = false;

                        if (!clicked) return true;

                        if (IsSelectable && BindingContext != null && ParentItemsView is CollectionView colView)
                        {
                            switch (colView.SelectionMode)
                            {
                                case ItemSelectionMode.Single:
                                    colView.SelectedItem = IsSelected ? null : BindingContext;
                                    break;
                                case ItemSelectionMode.SingleAlways:
                                    if (colView.SelectedItem != BindingContext)
                                    {
                                        colView.SelectedItem = BindingContext;
                                    }
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

                        return true;
                    }
                default:
                    break;
            }
            return base.HandleControlStateOnTouch(touch);
        }


        /// <summary>
        /// Measure child, it can be override.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void MeasureChild()
        {
        }

        /// <summary>
        /// Layout child, it can be override.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void LayoutChild()
        {
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnControlStateChanged(ControlStateChangedEventArgs controlStateChangedInfo)
        {
            if (controlStateChangedInfo == null) throw new ArgumentNullException(nameof(controlStateChangedInfo));
            base.OnControlStateChanged(controlStateChangedInfo);

            var stateEnabled = !controlStateChangedInfo.CurrentState.Contains(ControlState.Disabled);

            if (IsEnabled != stateEnabled)
            {
                IsEnabled = stateEnabled;
            }

            var statePressed = controlStateChangedInfo.CurrentState.Contains(ControlState.Pressed);

            if (IsPressed != statePressed)
            {
                IsPressed = statePressed;
            }

            if (IsSelectable)
            {
                var stateSelected = controlStateChangedInfo.CurrentState.Contains(ControlState.Selected);

                if (IsSelected != stateSelected)
                {
                    IsSelected = stateSelected;
                }
            }
        }

        /// <summary>
        /// Initializes AT-SPI object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnInitialize()
        {
            base.OnInitialize();
            Layout = new AbsoluteLayout();
            UpdateState();

            AccessibilityRole = Role.ListItem;
            AccessibilityHighlightable = true;
        }

        /// <summary>
        /// Update the Content. it can be override.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void UpdateContent()
        {
            MeasureChild();
            LayoutChild();
        }

                /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnEnabled(bool enabled)
        {
            base.OnEnabled(enabled);
            UpdateState();
        }



        /// FIXME!! This has to be done in Element or View class.
        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnBindingContextChanged()
        {
            PropagateBindingContext(this);
            base.OnBindingContextChanged();
        }

        private void PropagateBindingContext(View parent)
        {
            if (parent?.Children == null) return;
            foreach (View child in parent.Children)
            {
                SetChildInheritedBindingContext(child, BindingContext);
                PropagateBindingContext(child);
            }

        }

        private void OnClickedInternal(ClickedEventArgs eventArgs)
        {
            Command?.Execute(CommandParameter);
            OnClicked(eventArgs);

            Clicked?.Invoke(this, eventArgs);
        }
    }
}
