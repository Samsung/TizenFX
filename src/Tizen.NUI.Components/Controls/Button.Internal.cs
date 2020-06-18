using System;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components.Extension;

namespace Tizen.NUI.Components
{
    public partial class Button
    {
        private ImageView overlayImage;
        private TextLabel buttonText;
        private ImageView buttonIcon;

        private EventHandler<StateChangedEventArgs> stateChangeHander;

        private bool isSelected = false;
        private bool isEnabled = true;
        private bool isPressed = false;

        private StringSelector textSelector = new StringSelector();
        private StringSelector translatableTextSelector = new StringSelector();
        private ColorSelector textColorSelector = new ColorSelector();
        private FloatSelector pointSizeSelector = new FloatSelector();

        private StringSelector iconURLSelector = new StringSelector();

        /// <summary>
        /// The last touch information triggering selected state change.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected Touch SelectionChangedByTouch { get; set; }

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
            return new TextLabel();
        }

        /// <summary>
        /// Creates Button's icon part.
        /// </summary>
        /// <return>The created Button's icon part.</return>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual ImageView CreateIcon()
        {
            return new ImageView();
        }

        /// <summary>
        /// Creates Button's overlay image part.
        /// </summary>
        /// <return>The created Button's overlay image part.</return>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual ImageView CreateOverlayImage()
        {
            return new ImageView();
        }

        /// <summary>
        /// Called when the Button is Clicked by a user
        /// </summary>
        /// <param name="eventArgs">The click information.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnClick(ClickEventArgs eventArgs)
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

        /// <summary>
        /// Update Button State.
        /// </summary>
        /// <param name="touchInfo">The touch information in case the state has changed by touching.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void UpdateState()
        {
            ControlStates sourceState = ControlState;
            ControlStates targetState;

            if (isEnabled)
            {
                if (isPressed)
                {
                    // Pressed
                    targetState = ControlStates.Pressed;
                }
                else
                {
                    // Normal
                    targetState = ControlStates.Normal;

                    // Selected
                    targetState |= (IsSelected ? ControlStates.Selected : 0);

                    // Focused, SelectedFocused
                    targetState |= (IsFocused ? ControlStates.Focused : 0);
                }
            }
            else
            {
                // Disabled
                targetState = ControlStates.Disabled;

                // DisabledSelected, DisabledFocused
                targetState |= (IsSelected ? ControlStates.Selected : (IsFocused ? ControlStates.Focused : 0));
            }

            if (sourceState != targetState)
            {
                ControlState = targetState;

                OnUpdate();

                StateChangedEventArgs e = new StateChangedEventArgs
                {
                    PreviousState = sourceState,
                    CurrentState = targetState
                };
                stateChangeHander?.Invoke(this, e);

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
            if (Style.IconRelativeOrientation == null || Icon == null || TextLabel == null)
            {
                return;
            }
            TextLabel.WidthResizePolicy = ResizePolicyType.Fixed;
            TextLabel.HeightResizePolicy = ResizePolicyType.Fixed;
            int textPaddingStart = Style.TextPadding.Start;
            int textPaddingEnd = Style.TextPadding.End;
            int textPaddingTop = Style.TextPadding.Top;
            int textPaddingBottom = Style.TextPadding.Bottom;

            int iconPaddingStart = Style.IconPadding.Start;
            int iconPaddingEnd = Style.IconPadding.End;
            int iconPaddingTop = Style.IconPadding.Top;
            int iconPaddingBottom = Style.IconPadding.Bottom;

            if (IconRelativeOrientation == IconOrientation.Top || IconRelativeOrientation == IconOrientation.Bottom)
            {
                TextLabel.SizeWidth = SizeWidth - textPaddingStart - textPaddingEnd;
                TextLabel.SizeHeight = SizeHeight - textPaddingTop - textPaddingBottom - iconPaddingTop - iconPaddingBottom - Icon.SizeHeight;
            }
            else
            {
                TextLabel.SizeWidth = SizeWidth - textPaddingStart - textPaddingEnd - iconPaddingStart - iconPaddingEnd - Icon.SizeWidth;
                TextLabel.SizeHeight = SizeHeight - textPaddingTop - textPaddingBottom;
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
            if (Style.IconRelativeOrientation == null || Icon == null || TextLabel == null)
            {
                return;
            }

            var buttonIcon = Icon;
            var buttonText = TextLabel;

            int textPaddingStart = Style.TextPadding.Start;
            int textPaddingEnd = Style.TextPadding.End;
            int textPaddingTop = Style.TextPadding.Top;
            int textPaddingBottom = Style.TextPadding.Bottom;

            int iconPaddingStart = Style.IconPadding.Start;
            int iconPaddingEnd = Style.IconPadding.End;
            int iconPaddingTop = Style.IconPadding.Top;
            int iconPaddingBottom = Style.IconPadding.Bottom;

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
        /// Theme change callback when theme is changed, this callback will be trigger.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event data</param>
        /// <since_tizen> 8 </since_tizen>
        protected override void OnThemeChangedEvent(object sender, StyleManager.ThemeChangeEventArgs e)
        {
            ButtonStyle buttonStyle = StyleManager.Instance.GetViewStyle(StyleName) as ButtonStyle;
            if (buttonStyle != null)
            {
                Style.CopyFrom(buttonStyle);
                UpdateUIContent();
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

                if (Icon != null)
                {
                    Utility.Dispose(Icon);
                }
                if (TextLabel != null)
                {
                    Utility.Dispose(TextLabel);
                }
                if (OverlayImage != null)
                {
                    Utility.Dispose(OverlayImage);
                }
            }

            base.Dispose(type);
        }

        /// <summary>
        /// It is hijack by using protected, style copy problem when class inherited from Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        private void Initialize()
        {
            var style = (ButtonStyle)Style;
            EnableControlStatePropagation = true;
            UpdateState();
            LayoutDirectionChanged += OnLayoutDirectionChanged;
        }

        private void UpdateUIContent()
        {
            MeasureText();
            LayoutChild();

            Sensitive = isEnabled;
        }

        private void OnLayoutDirectionChanged(object sender, LayoutDirectionChangedEventArgs e)
        {
            MeasureText();
            LayoutChild();
        }

        private void OnClickInternal(ClickEventArgs eventArgs)
        {
            Command?.Execute(CommandParameter);
            OnClick(eventArgs);
            Extension?.OnClick(this, eventArgs);
            ClickEvent?.Invoke(this, eventArgs);
        }

        private void OnIconRelayout(object sender, EventArgs e)
        {
            MeasureText();
            LayoutChild();
        }

    }
}
