/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
        private bool styleApplied = false;

        /// <summary>
        /// Get accessibility name.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override string AccessibilityGetName()
        {
            return Text;
        }

        /// <summary>
        /// Prevents from showing child widgets in AT-SPI tree.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override bool AccessibilityShouldReportZeroChildren()
        {
            return true;
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
            return new TextLabel
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                AccessibilityHighlightable = false,
            };
        }

        /// <summary>
        /// Creates Button's icon part.
        /// </summary>
        /// <return>The created Button's icon part.</return>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual ImageView CreateIcon()
        {
            return new ImageView
            {
                AccessibilityHighlightable = false
            };
        }

        /// <summary>
        /// Creates Button's overlay image part.
        /// </summary>
        /// <return>The created Button's overlay image part.</return>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual ImageView CreateOverlayImage()
        {
            return new ImageView
            {
                PositionUsesPivotPoint = true,
                ParentOrigin = NUI.ParentOrigin.Center,
                PivotPoint = NUI.PivotPoint.Center,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                AccessibilityHighlightable = false
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
                        bool clicked = isPressed && IsEnabled;

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
        /// Update Button State.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void UpdateState()
        {
            if (!styleApplied) return;

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
                Extension?.OnDispose(this);

                if (buttonIcon != null)
                {
                    Utility.Dispose(buttonIcon);
                }
                if (buttonText != null)
                {
                    Utility.Dispose(buttonText);
                }
                if (overlayImage != null)
                {
                    Utility.Dispose(overlayImage);
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
            SetAccessibilityConstructor(Role.PushButton);

            AccessibilityHighlightable = true;
            EnableControlStatePropagation = true;

            AccessibilityManager.Instance.SetAccessibilityAttribute(this, AccessibilityManager.AccessibilityAttribute.Trait, "Button");

            buttonText = CreateText();
            buttonIcon = CreateIcon();
            LayoutItems();

#if PROFILE_MOBILE
            Feedback = true;
#endif
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

            if (IconRelativeOrientation == IconOrientation.Left)
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    LinearAlignment = itemAlignment,
                    CellPadding = itemSpacing ?? new Size2D(0, 0)
                };

                Add(buttonIcon);
                Add(buttonText);
            }
            else if (IconRelativeOrientation == IconOrientation.Right)
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    LinearAlignment = itemAlignment,
                    CellPadding = itemSpacing ?? new Size2D(0, 0)
                };

                Add(buttonText);
                Add(buttonIcon);
            }
            else if (IconRelativeOrientation == IconOrientation.Top)
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    LinearAlignment = itemAlignment,
                    CellPadding = itemSpacing ?? new Size2D(0, 0)
                };

                Add(buttonIcon);
                Add(buttonText);
            }
            else if (IconRelativeOrientation == IconOrientation.Bottom)
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    LinearAlignment = itemAlignment,
                    CellPadding = itemSpacing ?? new Size2D(0, 0)
                };

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
            Extents iconMargin = buttonIcon.Margin ?? new Extents(0);
            Extents textMargin = buttonText.Margin ?? new Extents(0);

            if (buttonIcon.Size.Width != 0 && buttonIcon.Size.Height != 0)
            {
                lengthWithoutText = buttonIcon.Size.Width;

                if (!String.IsNullOrEmpty(buttonText.Text))
                {
                    cellPadding = itemSpacing;

                    if (iconRelativeOrientation == IconOrientation.Left || iconRelativeOrientation == IconOrientation.Right)
                    {
                        lengthWithoutText += (itemSpacing?.Width ?? 0) + iconMargin.Start + iconMargin.End + textMargin.Start + textMargin.End;
                    }
                    else
                    {
                        lengthWithoutText += (itemSpacing?.Height ?? 0) + iconMargin.Top + iconMargin.Bottom + textMargin.Top + textMargin.Bottom;
                    }
                }
            }

            layout.CellPadding = cellPadding ?? new Size2D(0, 0);

            // If the button has fixed width and the text is not empty, the text should not exceed button boundary.
            if (WidthSpecification != LayoutParamPolicies.WrapContent && !String.IsNullOrEmpty(buttonText.Text))
            {
                buttonText.MaximumSize = new Size2D((int)Math.Max(size.Width - lengthWithoutText, Math.Max(buttonText.MinimumSize.Width, 1)), (int)size.Height);
            }
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

        internal override bool OnAccessibilityActivated()
        {
            using (var key = new Key())
            {
                key.State = Key.StateType.Down;
                key.KeyPressedName = "Return";

                // Touch Down
                OnKey(key);

                // Touch Up
                key.State = Key.StateType.Up;
                OnKey(key);
            }

            return true;
        }
    }
}
