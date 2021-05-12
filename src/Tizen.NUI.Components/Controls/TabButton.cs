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
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// TabButton is a class which is used for selecting one content in a TabView.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class TabButton : SelectButton
    {
        private bool selectedAgain = false;

        private TabButtonStyle tabButtonStyle = null;

        private bool styleApplied = false;

        private View topLine = null;
        private View bottomLine = null; // Visible only if TabButton is selected or pressed.

        /// <summary>
        /// Creates a new instance of TabButton.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public TabButton()
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of TabButton.
        /// </summary>
        /// <param name="style">Creates TabButton by special style defined in UX.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TabButton(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of TabButton.
        /// </summary>
        /// <param name="tabButtonStyle">Creates TabButton by style customized by user.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TabButton(TabButtonStyle tabButtonStyle) : base(tabButtonStyle)
        {
            Initialize();
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            styleApplied = false;

            base.ApplyStyle(viewStyle);

            tabButtonStyle = viewStyle as TabButtonStyle;

            //Apply TopLine style.
            if (tabButtonStyle?.TopLine != null)
            {
                topLine?.ApplyStyle(tabButtonStyle.TopLine);
            }

            //Apply BottomLine style.
            if (tabButtonStyle?.BottomLine != null)
            {
                bottomLine?.ApplyStyle(tabButtonStyle.BottomLine);
            }

            styleApplied = true;

            //Calculate children's sizes and positions based on padding sizes.
            LayoutItems();
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool OnKey(Key key)
        {
            if ((IsEnabled == false) || (key == null))
            {
                return false;
            }

            if (key.State == Key.StateType.Up)
            {
                if (key.KeyPressedName == "Return")
                {
                    if (IsSelected == true)
                    {
                        selectedAgain = true;
                    }
                }
            }

            bool ret = base.OnKey(key);

            if (selectedAgain == true)
            {
                IsSelected = true;
                selectedAgain = false;
            }

            return ret;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnRelayout(Vector2 size, RelayoutContainer container)
        {
            base.OnRelayout(size, container);
            UpdateSizeAndSpacing();
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                if (topLine != null)
                {
                    Utility.Dispose(topLine);
                }

                if (bottomLine != null)
                {
                    Utility.Dispose(bottomLine);
                }
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Gets TabButton style.
        /// </summary>
        /// <returns>The default TabButton style.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ViewStyle CreateViewStyle()
        {
            return new TabButtonStyle();
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override bool HandleControlStateOnTouch(Touch touch)
        {
            if ((IsEnabled == false) || (touch == null))
            {
                return false;
            }

            PointStateType state = touch.GetState(0);
            switch (state)
            {
                case PointStateType.Up:
                    if (IsSelected == true)
                    {
                        selectedAgain = true;
                    }
                    break;
                default:
                    break;
            }

            bool ret = base.HandleControlStateOnTouch(touch);

            if (selectedAgain == true)
            {
                IsSelected = true;
                selectedAgain = false;
            }

            return ret;
        }

        /// <inheritdoc/>
        [SuppressMessage("Microsoft.Design",
                         "CA1062: Validate arguments of public methods",
                         MessageId = "controlStateChangedInfo",
                         Justification = "OnControlStateChanged is called when controlState is changed so controlStateChangedInfo cannot be null.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnControlStateChanged(ControlStateChangedEventArgs controlStateChangedInfo)
        {
            if (controlStateChangedInfo.PreviousState.Contains(ControlState.Selected) != controlStateChangedInfo.CurrentState.Contains(ControlState.Selected))
            {
                // TabButton does not invoke SelectedChanged if button or key is
                // unpressed while its state is selected.
                if (selectedAgain == true)
                {
                    return;
                }

                base.OnControlStateChanged(controlStateChangedInfo);
            }
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void LayoutItems()
        {
            if ((Icon == null) && (TextLabel == null))
            {
                return;
            }

            // Icon is added in Button.LayoutItems().
            if ((Icon != null) && (Children.Contains(Icon) == false))
            {
                Add(Icon);
            }

            // TextLabel is added in Button.LayoutItems().
            if ((TextLabel != null) && (Children.Contains(TextLabel) == false))
            {
                Add(TextLabel);
            }
        }

        private void Initialize()
        {
            Layout = new AbsoluteLayout();

            topLine = new View(tabButtonStyle?.TopLine);
            Add(topLine);

            bottomLine = new View(tabButtonStyle?.BottomLine);
            Add(bottomLine);
        }

        private void UpdateSizeAndSpacing()
        {
            if (styleApplied == false)
            {
                return;
            }

            if ((Icon == null) && (TextLabel == null))
            {
                return;
            }

            // FIXME: set Selector<Extents> to padding
            var padding = new Extents(40, 40, 24, 24);
            var iconPadding = IconPadding;
            var textPadding = TextPadding;

            // Calculate size of TextLabel.
            if (TextLabel != null)
            {
                // TODO: Other orientation cases are not implemented yet.
                if ((IconRelativeOrientation == IconOrientation.Left) || (IconRelativeOrientation == IconOrientation.Right))
                {
                    var naturalWidthSum = (ushort)padding?.Start + (ushort)padding?.End + iconPadding.Start + iconPadding.End + (float)Icon?.SizeWidth + TextLabel.GetNaturalSize().Width;
                    var naturalWidthDiff = SizeWidth - naturalWidthSum;

                    if (naturalWidthDiff > 0)
                    {
                        TextLabel.SizeWidth = TextLabel.GetNaturalSize().Width;
                    }
                    else
                    {
                        TextLabel.SizeWidth = SizeWidth - (ushort)padding?.Start - (ushort)padding?.End - iconPadding.Start - iconPadding.End - textPadding.Start - textPadding.End - (float)Icon?.SizeWidth;
                    }
                }
            }

            // Calculate positions of Icon and TextLabel.
            switch (IconRelativeOrientation)
            {
                // TODO: Other orientation cases are not implemented yet.
                case IconOrientation.Left:
                    if (LayoutDirection == ViewLayoutDirectionType.LTR)
                    {
                        if (Icon != null)
                        {
                            float iconX = 0;
                            float iconY = (ushort)padding?.Top + iconPadding.Top;

                            if (string.IsNullOrEmpty(TextLabel?.Text))
                            {
                                iconX = (SizeWidth - Icon.SizeWidth) / 2;
                            }
                            else
                            {
                                var widthSum = (ushort)padding?.Start + (ushort)padding?.End + iconPadding.Start + iconPadding.End + textPadding.Start + textPadding.End + Icon.SizeWidth + (float)TextLabel?.SizeWidth;
                                var widthDiff = SizeWidth - widthSum;

                                if (widthDiff > 0)
                                {
                                    iconX = (ushort)padding?.Start + iconPadding.Start + (widthDiff / 2);
                                }
                                else
                                {
                                    iconX = (ushort)padding?.Start + iconPadding.Start;
                                }
                            }

                            Icon.Position = new Position(iconX, iconY);
                        }

                        if (TextLabel != null)
                        {
                            TextLabel.HorizontalAlignment = HorizontalAlignment.Begin;

                            float textX = 0;
                            float textY = 0;

                            if (string.IsNullOrEmpty(Icon?.ResourceUrl))
                            {
                                textX = (SizeWidth - TextLabel.SizeWidth) / 2;
                                textY = (ushort)padding?.Top + textPadding.Top;
                            }
                            else
                            {
                                textX = (float)Icon?.PositionX + (float)Icon?.SizeWidth;
                                textY = (ushort)padding?.Top + textPadding.Top + (((float)Icon?.SizeHeight - TextLabel.SizeHeight) / 2);
                            }

                            TextLabel.Position = new Position(textX, textY);
                        }
                    }
                    break;
                default:
                    break;
            }

            padding?.Dispose();
        }
    }
}
