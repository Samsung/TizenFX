using System;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components.Extension;
using Tizen.NUI.Accessibility; // To use AccessibilityManager

namespace Tizen.NUI.Components
{
    public partial class RecyclerViewItem
    {
        internal RecyclerView ParentItemsView = null;
        internal object ParentGroup = null;
        internal bool isGroupHeader;
        internal bool isGroupFooter;
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

        internal override bool OnAccessibilityActivated()
        {
            if (!IsEnabled)
            {
                return false;
            }

            // Touch Down
            IsPressed = true;
            UpdateState();

            // Touch Up
            bool clicked = IsPressed && IsEnabled;
            IsPressed = false;

            if (IsSelectable)
            {
                //IsSelected = !IsSelected;
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
            return true;
        }

        /// <summary>
        /// Called when the ViewItem is Clicked by a user
        /// </summary>
        /// <param name="eventArgs">The click information.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnClicked(ClickedEventArgs eventArgs)
        {
            //Console.WriteLine("On Clicked Called {0}", this.Index);
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
                    IsPressed = false;
                    UpdateState();
                    return true;
                case PointStateType.Up:
                    {
                        bool clicked = IsPressed && IsEnabled;
                        IsPressed = false;

                        if (!clicked) return true;

                        if (IsSelectable)
                        {
                            if (ParentItemsView as CollectionView)
                            {
                                CollectionView colView = ParentItemsView as CollectionView;
                                switch (colView.SelectionMode)
                                {
                                    case ItemSelectionMode.SingleSelection:
                                        colView.SelectedItem = IsSelected ? null : BindingContext;
                                        break;
                                    case ItemSelectionMode.MultipleSelections:
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
                            // Extension : Extension?.SetTouchInfo(touch);
                            UpdateState();
                        }

                        if (clicked)
                        {
                            ClickedEventArgs eventArgs = new ClickedEventArgs();
                            OnClickedInternal(eventArgs);
                        }

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

        /// <summary>
        /// Dispose Item and all children on it.
        /// </summary>
        /// <param name="type">Dispose type.</param>
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
        }

        /// <summary>
        /// Get ViewItem style.
        /// </summary>
        /// <returns>The default ViewItem style.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ViewStyle CreateViewStyle()
        {
            return new RecyclerViewItemStyle();
        }

        /// <summary>
        /// It is hijack by using protected, style copy problem when class inherited from Button.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private void Initialize()
        {
            //FIXME!
            IsCreateByXaml = true;
            Layout = new AbsoluteLayout();
            UpdateState();

            AccessibilityManager.Instance.SetAccessibilityAttribute(this, AccessibilityManager.AccessibilityAttribute.Trait, "ViewItem");
        }

        /// <summary>
        /// Update the Content. it can be override.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void UpdateContent()
        {
            MeasureChild();
            LayoutChild();

            Sensitive = IsEnabled;
        }


        /// FIXME!! This has to be done in Element or View class.
        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnBindingContextChanged()
        {
            foreach (View child in Children)
            {
                SetChildInheritedBindingContext(child, BindingContext);
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
