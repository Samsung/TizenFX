/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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
using System.Diagnostics;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components.Extension;
using Tizen.NUI.Accessibility; // To use AccessibilityManager

namespace Tizen.NUI.Components
{
    public partial class Button
    {
        private ImageView overlayImage;
        private TextLabel buttonText;
        private ImageView buttonIcon;
        private Vector2 size;

        private EventHandler<StateChangedEventArgs> stateChangeHandler;

        private bool isPressed = false;
        internal int styleApplying = 0;

        /// <summary>
        /// Gets accessibility name.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override string AccessibilityGetName()
        {
            return Text;
        }

        /// <summary>
        /// The ButtonExtension instance that is injected by ButtonStyle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected ButtonExtension Extension { get; set; }

        /// <summary>
        /// Creates Button's text part.
        /// </summary>
        /// <return>The created Button's text part.</return>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual TextLabel CreateText()
        {
            return new TextLabel()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                AccessibilityHidden = true,
            };
        }

        /// <summary>
        /// Creates Button's icon part.
        /// </summary>
        /// <return>The created Button's icon part.</return>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual ImageView CreateIcon()
        {
            return new ImageView()
            {
                AccessibilityHidden = true,
            };
        }

        /// <summary>
        /// Creates Button's overlay image part.
        /// </summary>
        /// <return>The created Button's overlay image part.</return>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual ImageView CreateOverlayImage()
        {
            return new ImageView()
            {
                PositionUsesPivotPoint = true,
                ParentOrigin = NUI.ParentOrigin.Center,
                PivotPoint = NUI.PivotPoint.Center,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                AccessibilityHidden = true,
            };
        }

        /// <summary>
        /// Called when the Button is Clicked by a user
        /// </summary>
        /// <param name="eventArgs">The click information.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnClicked(ClickedEventArgs eventArgs)
        {
        }

        /// <summary>
        /// Get Button style.
        /// </summary>
        /// <returns>The default button style.</returns>
        /// <since_tizen> 8 </since_tizen>
        protected override ViewStyle CreateViewStyle()
        {
            return new ButtonStyle();
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate()
        {
            base.OnUpdate();
            Extension?.OnRelayout(this);
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
                    isPressed = true;
                    Extension?.SetTouchInfo(touch);
                    UpdateState();
                    return true;
                case PointStateType.Interrupted:
                    isPressed = false;
                    UpdateState();
                    return true;
                case PointStateType.Up:
                    {
                        if (!isPressed)
                        {
                            return false;
                        }

                        isPressed = false;

                        if (IsSelectable)
                        {
                            Extension?.SetTouchInfo(touch);
                            IsSelected = !IsSelected;
                        }
                        else
                        {
                            Extension?.SetTouchInfo(touch);
                            UpdateState();
                        }

                        ClickedEventArgs eventArgs = new ClickedEventArgs();
                        OnClickedInternal(eventArgs, touch);

                        return true;
                    }
                default:
                    break;
            }
            return base.HandleControlStateOnTouch(touch);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnEnabled(bool enabled)
        {
            base.OnEnabled(enabled);
            UpdateState();
        }

        /// <summary>
        /// Update Button State.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void UpdateState()
        {
            if (styleApplying > 0) return;

            ControlState sourceState = ControlState;
            ControlState targetState;

            // Normal, Disabled
            targetState = IsEnabled ? ControlState.Normal : ControlState.Disabled;

            // Selected, DisabledSelected
            if (IsSelected) targetState += ControlState.Selected;

            // Pressed, PressedSelected
            if (isPressed) targetState += ControlState.Pressed;

            // Focused, FocusedPressed, FocusedPressedSelected, DisabledFocused, DisabledSelectedFocused
            if (IsFocused) targetState += ControlState.Focused;

            if (sourceState != targetState)
            {
                ControlState = targetState;
                OnUpdate();

                StateChangedEventArgs e = new StateChangedEventArgs
                {
                    PreviousState = ControlStatesExtension.FromControlStateClass(sourceState),
                    CurrentState = ControlStatesExtension.FromControlStateClass(targetState)
                };
                stateChangeHandler?.Invoke(this, e);

                Extension?.OnControlStateChanged(this, new ControlStateChangedEventArgs(sourceState, targetState));
            }
        }

        /// <summary>
        /// Dispose Button and all children on it.
        /// </summary>
        /// <param name="type">Dispose type.</param>
        /// <since_tizen> 6 </since_tizen>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                if (Extension != null)
                {
                    Extension.OnDispose(this);
                    Extension = null;
                }

                if (buttonIcon != null)
                {
                    Utility.Dispose(buttonIcon);
                    buttonIcon = null;
                }
                if (buttonText != null)
                {
                    Utility.Dispose(buttonText);
                    buttonText = null;
                }
                if (overlayImage != null)
                {
                    Utility.Dispose(overlayImage);
                    overlayImage = null;
                }
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Initializes AT-SPI object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnInitialize()
        {
            base.OnInitialize();

            AccessibilityRole = Role.PushButton;
            AccessibilityHighlightable = true;
            EnableControlStatePropagation = true;

            AccessibilityManager.Instance.SetAccessibilityAttribute(this, AccessibilityManager.AccessibilityAttribute.Trait, "Button");

            buttonText = CreateText();
            buttonIcon = CreateIcon();
            LayoutItems();

            Feedback = true;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnRelayout(Vector2 size, RelayoutContainer container)
        {
            if (size == null) return;

            if (size.Equals(this.size))
            {
                return;
            }

            this.size = new Vector2(size);

            UpdateSizeAndSpacing();
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnControlStateChanged(ControlStateChangedEventArgs controlStateChangedInfo)
        {
            base.OnControlStateChanged(controlStateChangedInfo);

            var stateEnabled = !controlStateChangedInfo.CurrentState.Contains(ControlState.Disabled);

            if (IsEnabled != stateEnabled)
            {
                IsEnabled = stateEnabled;
            }

            var statePressed = controlStateChangedInfo.CurrentState.Contains(ControlState.Pressed);

            if (isPressed != statePressed)
            {
                isPressed = statePressed;
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
        /// Put sub items (e.g. buttonText, buttonIcon) to the right place.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void LayoutItems()
        {
            if (buttonIcon == null || buttonText == null)
            {
                return;
            }

            buttonIcon.Unparent();
            buttonText.Unparent();
            overlayImage?.Unparent();

#pragma warning disable CA2000
            Size2D cellPadding = String.IsNullOrEmpty(buttonText.Text) ? new Size2D(0, 0) : itemSpacing;
#pragma warning restore CA2000

            var linearLayout = Layout as LinearLayout;
            if (linearLayout == null) Layout = (linearLayout = new LinearLayout());

            if (IconRelativeOrientation == IconOrientation.Left)
            {
                linearLayout.LinearOrientation = LinearLayout.Orientation.Horizontal;
                linearLayout.HorizontalAlignment = itemHorizontalAlignment;
                linearLayout.VerticalAlignment = itemVerticalAlignment;
                linearLayout.CellPadding = cellPadding;

                Add(buttonIcon);
                Add(buttonText);
            }
            else if (IconRelativeOrientation == IconOrientation.Right)
            {
                linearLayout.LinearOrientation = LinearLayout.Orientation.Horizontal;
                linearLayout.HorizontalAlignment = itemHorizontalAlignment;
                linearLayout.VerticalAlignment = itemVerticalAlignment;
                linearLayout.CellPadding = cellPadding;

                Add(buttonText);
                Add(buttonIcon);
            }
            else if (IconRelativeOrientation == IconOrientation.Top)
            {
                linearLayout.LinearOrientation = LinearLayout.Orientation.Vertical;
                linearLayout.HorizontalAlignment = itemHorizontalAlignment;
                linearLayout.VerticalAlignment = itemVerticalAlignment;
                linearLayout.CellPadding = cellPadding;

                Add(buttonIcon);
                Add(buttonText);
            }
            else if (IconRelativeOrientation == IconOrientation.Bottom)
            {
                linearLayout.LinearOrientation = LinearLayout.Orientation.Vertical;
                linearLayout.HorizontalAlignment = itemHorizontalAlignment;
                linearLayout.VerticalAlignment = itemVerticalAlignment;
                linearLayout.CellPadding = cellPadding;

                Add(buttonText);
                Add(buttonIcon);
            }

            if (overlayImage != null)
            {
                overlayImage.ExcludeLayouting = true;
                Add(overlayImage);
            }
        }

        private void UpdateSizeAndSpacing()
        {
            if (size == null || buttonIcon == null || buttonText == null)
            {
                return;
            }

            LinearLayout layout = Layout as LinearLayout;

            if (layout == null)
            {
                return;
            }

            float lengthWithoutText = 0;
            Size2D cellPadding = null;

            if (buttonIcon.Size.Width != 0 && buttonIcon.Size.Height != 0)
            {
                if (!string.IsNullOrEmpty(buttonText.Text))
                {
                    cellPadding = itemSpacing;

                    Extents iconMargin = buttonIcon.Margin ?? new Extents(0);
                    Extents textMargin = buttonText.Margin ?? new Extents(0);

                    if (iconRelativeOrientation == IconOrientation.Left || iconRelativeOrientation == IconOrientation.Right)
                    {
                        lengthWithoutText += buttonIcon.Size.Width;
                        lengthWithoutText += (itemSpacing?.Width ?? 0) + iconMargin.Start + iconMargin.End + textMargin.Start + textMargin.End + Padding.Start + Padding.End;
                    }
                    else
                    {
                        lengthWithoutText += textMargin.Start + textMargin.End + Padding.Start + Padding.End;
                    }
                }
            }

            layout.CellPadding = cellPadding ?? new Size2D(0, 0);

            // If the button has fixed width and the text is not empty, the text should not exceed button boundary.
            if (WidthSpecification != LayoutParamPolicies.WrapContent && !string.IsNullOrEmpty(buttonText.Text))
            {
                buttonText.MaximumSize = new Size2D((int)Math.Max(size.Width - lengthWithoutText, Math.Max(buttonText.MinimumSize.Width, 1)), (int)size.Height);
            }
        }

        private void OnClickedInternal(ClickedEventArgs eventArgs, Touch touch)
        {
            // If GrabTouchAfterLeave is true, Up will result in Finished rather than Interrupted even if it is out of the button area.
            // So, it is necessary to check whether it is Up in the button area.
            if (GrabTouchAfterLeave == true)
            {
                Vector2 localPosition = touch.GetLocalPosition(0);
                if ((localPosition != null && Size != null &&
                    0 <= localPosition.X && localPosition.X <= Size.Width &&
                    0 <= localPosition.Y && localPosition.Y <= Size.Height) == false)
                {
                    return;
                }
            }
            OnClickedInternal(eventArgs);
        }

        private void OnClickedInternal(ClickedEventArgs eventArgs)
        {
            Command?.Execute(CommandParameter);
            OnClicked(eventArgs);
            Extension?.OnClicked(this, eventArgs);

            ClickEventArgs nestedEventArgs = new ClickEventArgs();
            ClickEvent?.Invoke(this, nestedEventArgs);
            Clicked?.Invoke(this, eventArgs);
        }
    }
}
