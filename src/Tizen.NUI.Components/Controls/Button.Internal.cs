using System;
using System.ComponentModel;
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
                PositionUsesPivotPoint = true,
                ParentOrigin = NUI.ParentOrigin.Center,
                PivotPoint = NUI.PivotPoint.Center,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                AccessibilityHighlightable = false
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
                PositionUsesPivotPoint = true,
                ParentOrigin = NUI.ParentOrigin.Center,
                PivotPoint = NUI.PivotPoint.Center,
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
            UpdateUIContent();

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
        /// Measure text, it can be override.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void MeasureText()
        {
            if (buttonIcon == null || buttonText == null)
            {
                return;
            }
            buttonText.WidthResizePolicy = ResizePolicyType.Fixed;
            buttonText.HeightResizePolicy = ResizePolicyType.Fixed;

            var textPadding = TextPadding;
            int textPaddingStart = textPadding.Start;
            int textPaddingEnd = textPadding.End;
            int textPaddingTop = textPadding.Top;
            int textPaddingBottom = textPadding.Bottom;

            var iconPadding = IconPadding;
            int iconPaddingStart = iconPadding.Start;
            int iconPaddingEnd = iconPadding.End;
            int iconPaddingTop = iconPadding.Top;
            int iconPaddingBottom = iconPadding.Bottom;

            if (IconRelativeOrientation == IconOrientation.Top || IconRelativeOrientation == IconOrientation.Bottom)
            {
                buttonText.SizeWidth = SizeWidth - textPaddingStart - textPaddingEnd;
                buttonText.SizeHeight = SizeHeight - textPaddingTop - textPaddingBottom - iconPaddingTop - iconPaddingBottom - buttonIcon.SizeHeight;
            }
            else
            {
                buttonText.SizeWidth = SizeWidth - textPaddingStart - textPaddingEnd - iconPaddingStart - iconPaddingEnd - buttonIcon.SizeWidth;
                buttonText.SizeHeight = SizeHeight - textPaddingTop - textPaddingBottom;
            }
        }

        /// <summary>
        /// Layout child, it can be override.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void LayoutChild()
        {
            if (buttonIcon == null || buttonText == null)
            {
                return;
            }

            var textPadding = TextPadding;
            int textPaddingStart = textPadding.Start;
            int textPaddingEnd = textPadding.End;
            int textPaddingTop = textPadding.Top;
            int textPaddingBottom = textPadding.Bottom;

            var iconPadding = IconPadding;
            int iconPaddingStart = iconPadding.Start;
            int iconPaddingEnd = iconPadding.End;
            int iconPaddingTop = iconPadding.Top;
            int iconPaddingBottom = iconPadding.Bottom;

            switch (IconRelativeOrientation)
            {
                case IconOrientation.Top:
                    buttonIcon.PositionUsesPivotPoint = true;
                    buttonIcon.ParentOrigin = NUI.ParentOrigin.TopCenter;
                    buttonIcon.PivotPoint = NUI.PivotPoint.TopCenter;
                    buttonIcon.Position2D = new Position2D(0, iconPaddingTop);

                    buttonText.PositionUsesPivotPoint = true;
                    buttonText.ParentOrigin = NUI.ParentOrigin.BottomCenter;
                    buttonText.PivotPoint = NUI.PivotPoint.BottomCenter;
                    buttonText.Position2D = new Position2D(0, -textPaddingBottom);
                    break;
                case IconOrientation.Bottom:
                    buttonIcon.PositionUsesPivotPoint = true;
                    buttonIcon.ParentOrigin = NUI.ParentOrigin.BottomCenter;
                    buttonIcon.PivotPoint = NUI.PivotPoint.BottomCenter;
                    buttonIcon.Position2D = new Position2D(0, -iconPaddingBottom);

                    buttonText.PositionUsesPivotPoint = true;
                    buttonText.ParentOrigin = NUI.ParentOrigin.TopCenter;
                    buttonText.PivotPoint = NUI.PivotPoint.TopCenter;
                    buttonText.Position2D = new Position2D(0, textPaddingTop);
                    break;
                case IconOrientation.Left:
                    if (LayoutDirection == ViewLayoutDirectionType.LTR)
                    {
                        buttonIcon.PositionUsesPivotPoint = true;
                        buttonIcon.ParentOrigin = NUI.ParentOrigin.CenterLeft;
                        buttonIcon.PivotPoint = NUI.PivotPoint.CenterLeft;
                        buttonIcon.Position2D = new Position2D(iconPaddingStart, 0);

                        buttonText.PositionUsesPivotPoint = true;
                        buttonText.ParentOrigin = NUI.ParentOrigin.CenterRight;
                        buttonText.PivotPoint = NUI.PivotPoint.CenterRight;
                        buttonText.Position2D = new Position2D(-textPaddingEnd, 0);
                    }
                    else
                    {
                        buttonIcon.PositionUsesPivotPoint = true;
                        buttonIcon.ParentOrigin = NUI.ParentOrigin.CenterRight;
                        buttonIcon.PivotPoint = NUI.PivotPoint.CenterRight;
                        buttonIcon.Position2D = new Position2D(-iconPaddingStart, 0);

                        buttonText.PositionUsesPivotPoint = true;
                        buttonText.ParentOrigin = NUI.ParentOrigin.CenterLeft;
                        buttonText.PivotPoint = NUI.PivotPoint.CenterLeft;
                        buttonText.Position2D = new Position2D(textPaddingEnd, 0);
                    }

                    break;
                case IconOrientation.Right:
                    if (LayoutDirection == ViewLayoutDirectionType.RTL)
                    {
                        buttonIcon.PositionUsesPivotPoint = true;
                        buttonIcon.ParentOrigin = NUI.ParentOrigin.CenterLeft;
                        buttonIcon.PivotPoint = NUI.PivotPoint.CenterLeft;
                        buttonIcon.Position2D = new Position2D(iconPaddingEnd, 0);

                        buttonText.PositionUsesPivotPoint = true;
                        buttonText.ParentOrigin = NUI.ParentOrigin.CenterRight;
                        buttonText.PivotPoint = NUI.PivotPoint.CenterRight;
                        buttonText.Position2D = new Position2D(-textPaddingStart, 0);
                    }
                    else
                    {
                        buttonIcon.PositionUsesPivotPoint = true;
                        buttonIcon.ParentOrigin = NUI.ParentOrigin.CenterRight;
                        buttonIcon.PivotPoint = NUI.PivotPoint.CenterRight;
                        buttonIcon.Position2D = new Position2D(-iconPaddingEnd, 0);

                        buttonText.PositionUsesPivotPoint = true;
                        buttonText.ParentOrigin = NUI.ParentOrigin.CenterLeft;
                        buttonText.PivotPoint = NUI.PivotPoint.CenterLeft;
                        buttonText.Position2D = new Position2D(textPaddingStart, 0);
                    }
                    break;
                default:
                    break;
            }
            if (string.IsNullOrEmpty(buttonText.Text))
            {
                buttonIcon.ParentOrigin = NUI.ParentOrigin.Center;
                buttonIcon.PivotPoint = NUI.PivotPoint.Center;
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
        /// Initilizes AT-SPI object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnInitialize()
        {
            base.OnInitialize();
            SetAccessibilityConstructor(Role.PushButton);
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
        /// It is hijack by using protected, style copy problem when class inherited from Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        private void Initialize()
        {
            AccessibilityHighlightable = true;
            EnableControlStatePropagation = true;
            UpdateState();
            LayoutDirectionChanged += OnLayoutDirectionChanged;

            AccessibilityManager.Instance.SetAccessibilityAttribute(this, AccessibilityManager.AccessibilityAttribute.Trait, "Button");

            #if PROFILE_MOBILE
                Feedback = true;
            #endif
        }

        private void UpdateUIContent()
        {
            MeasureText();
            LayoutChild();

            Sensitive = IsEnabled;
        }

        private void OnLayoutDirectionChanged(object sender, LayoutDirectionChangedEventArgs e)
        {
            MeasureText();
            LayoutChild();
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

        private void OnIconRelayout(object sender, EventArgs e)
        {
            MeasureText();
            LayoutChild();
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
