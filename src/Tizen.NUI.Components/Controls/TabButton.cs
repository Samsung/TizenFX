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
        public override void OnInitialize()
        {
            base.OnInitialize();

            AccessibilityRole = Role.PageTab;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            styleApplied = false;

            base.ApplyStyle(viewStyle);

            tabButtonStyle = viewStyle as TabButtonStyle;

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
        public new string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                UpdateSizeAndSpacing();
            }
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new string IconURL
        {
            get
            {
                return base.IconURL;
            }
            set
            {
                base.IconURL = value;
                UpdateSizeAndSpacing();
            }
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
                // Dispose children explicitly
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
            UpdateSizeAndSpacing();
        }

        private void Initialize()
        {
            Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Vertical,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };

            WidthSpecification = LayoutParamPolicies.MatchParent;

            AccessibilityHighlightable = true;
        }

        private void UpdateSizeAndSpacing()
        {
            if (styleApplied == false)
            {
                return;
            }

            bool isEmptyIcon = false;
            bool isEmptyText = false;

            if (String.IsNullOrEmpty(Icon.ResourceUrl))
            {
                isEmptyIcon = true;
            }

            if (String.IsNullOrEmpty(TextLabel.Text))
            {
                isEmptyText = true;
            }

            if (isEmptyIcon)
            {
                if (Children.Contains(Icon))
                {
                    Remove(Icon);
                }
            }
            else if (Children.Contains(Icon) == false)
            {
                Add(Icon);
            }

            if (isEmptyText)
            {
                if (Children.Contains(TextLabel))
                {
                    Remove(TextLabel);
                }
            }
            else if (Children.Contains(TextLabel) == false)
            {
                Add(TextLabel);
            }

            if (tabButtonStyle != null)
            {
                Padding = tabButtonStyle.Padding;

                // Text only
                if (isEmptyIcon && !isEmptyText)
                {
                    if (tabButtonStyle.Size != null)
                    {
                        WidthSpecification = (int)tabButtonStyle.Size.Width;
                        HeightSpecification = (int)tabButtonStyle.Size.Height;
                    }

                    if ((tabButtonStyle.Text != null) && (tabButtonStyle.Text.PixelSize != null) && (tabButtonStyle.Text.PixelSize.Normal != null))
                    {
                        TextLabel.PixelSize = (float)tabButtonStyle.Text.PixelSize.Normal;
                    }
                }
                // Icon only
                else if (!isEmptyIcon && isEmptyText)
                {
                    if (tabButtonStyle.SizeWithIconOnly != null)
                    {
                        WidthSpecification = (int)tabButtonStyle.SizeWithIconOnly.Width;
                        HeightSpecification = (int)tabButtonStyle.SizeWithIconOnly.Height;
                    }

                    if (tabButtonStyle.IconSizeWithIconOnly != null)
                    {
                        Icon.WidthSpecification = (int)tabButtonStyle.IconSizeWithIconOnly.Width;
                        Icon.HeightSpecification = (int)tabButtonStyle.IconSizeWithIconOnly.Height;
                    }
                }
                // Icon and Text
                else if (!isEmptyIcon && !isEmptyText)
                {
                    if (tabButtonStyle.SizeWithIcon != null)
                    {
                        WidthSpecification = (int)tabButtonStyle.SizeWithIcon.Width;
                        HeightSpecification = (int)tabButtonStyle.SizeWithIcon.Height;
                    }

                    if ((tabButtonStyle.Icon != null) && (tabButtonStyle.Icon.Size != null))
                    {
                        Icon.WidthSpecification = (int)tabButtonStyle.Icon.Size.Width;
                        Icon.HeightSpecification = (int)tabButtonStyle.Icon.Size.Height;
                    }

                    TextLabel.PixelSize = tabButtonStyle.TextSizeWithIcon;
                }
                // Nothing
                else
                {
                    if (tabButtonStyle.Size != null)
                    {
                        WidthSpecification = (int)tabButtonStyle.Size.Width;
                        HeightSpecification = (int)tabButtonStyle.Size.Height;
                    }
                }
            }
        }
    }
}
