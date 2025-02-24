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

using System.Collections.Generic;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// Menu is a class which contains a set of MenuItems and has one of them selected.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public partial class Menu : Control
    {
        private Window window = null;
        private Layer layer = null;
        private View content = null;
        private View scrim = null;
        private View anchor = null;
        private IEnumerable<MenuItem> menuItems = null;
        private MenuItemGroup menuItemGroup = null;
        private RelativePosition horizontalPosition = RelativePosition.Center;
        private RelativePosition verticalPosition = RelativePosition.Center;
        private MenuStyle menuStyle = null;
        private bool styleApplied = false;

        static Menu()
        {
            if (NUIApplication.IsUsingXaml)
            {
                AnchorProperty = BindableProperty.Create(nameof(Anchor), typeof(View), typeof(Menu), null,
                    propertyChanged: SetInternalAnchorProperty, defaultValueCreator: GetInternalAnchorProperty);
                HorizontalPositionToAnchorProperty = BindableProperty.Create(nameof(HorizontalPositionToAnchor), typeof(Tizen.NUI.Components.Menu.RelativePosition), typeof(Menu), default(RelativePosition),
                    propertyChanged: SetInternalHorizontalPositionToAnchorProperty, defaultValueCreator: GetInternalHorizontalPositionToAnchorProperty);
                VerticalPositionToAnchorProperty = BindableProperty.Create(nameof(VerticalPositionToAnchor), typeof(Tizen.NUI.Components.Menu.RelativePosition), typeof(Menu), default(RelativePosition),
                    propertyChanged: SetInternalVerticalPositionToAnchorProperty, defaultValueCreator: GetInternalVerticalPositionToAnchorProperty);
            }
        }

        /// <summary>
        /// Creates a new instance of Menu.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Menu() : base()
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of Menu.
        /// </summary>
        /// <param name="style">Creates Menu by special style defined in UX.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Menu(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a Menu with style.
        /// </summary>
        /// <param name="style">A style applied to the newly created Menu.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Menu(MenuStyle style) : base(style)
        {
            Initialize();
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
                if (Content != null)
                {
                    if (menuItems != null)
                    {
                        foreach (MenuItem menuItem in menuItems)
                        {
                            Content.Remove(menuItem);
                        }
                    }

                    Utility.Dispose(Content);
                }

                Utility.Dispose(Scrim);

                menuItemGroup = null;

                layer.Remove(this);
                Window.RemoveLayer(layer);
                layer.Dispose();
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Applies style to MenuItem.
        /// </summary>
        /// <param name="viewStyle">The style to apply.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            styleApplied = false;

            base.ApplyStyle(viewStyle);

            menuStyle = viewStyle as MenuStyle;
            if (menuStyle != null)
            {
                Content?.ApplyStyle(menuStyle.Content);
            }

            styleApplied = true;
        }

        /// <summary>The Menu's relative position to Anchor.</summary>
        /// <since_tizen> 9 </since_tizen>
        public enum RelativePosition
        {
            /// <summary>
            /// At the start of the Anchor.
            /// If this is used with <see cref="HorizontalPositionToAnchor"/>, then Menu is positioned to the left (LTR) of the Anchor or right (RTL) of the Anchor.
            /// If this is used with <see cref="VerticalPositionToAnchor"/>, then Menu is positioned to the top of the Anchor.
            ///</summary>
            /// <since_tizen> 9 </since_tizen>
            Start = 0,
            /// <summary>
            /// At the center of the Anchor.
            /// If this is used with <see cref="HorizontalPositionToAnchor"/> or <see cref="VerticalPositionToAnchor"/>, then Menu is positioned to the middle of the Anchor.
            /// </summary>
            /// <since_tizen> 9 </since_tizen>
            Center = 1,
            /// <summary>
            /// At the end of the Anchor.
            /// If this is used with <see cref="HorizontalPositionToAnchor"/>, then Menu is positioned to the right (LTR) of the Anchor or left (RTL) of the Anchor.
            /// If this is used with <see cref="VerticalPositionToAnchor"/>, then Menu is positioned to the bottom of the Anchor.
            /// </summary>
            /// <since_tizen> 9 </since_tizen>
            End = 2,
        }

        /// <summary>
        /// Menu items in Menu.
        /// Menu items are not automatically disposed when Menu is disposed.
        /// Therefore, please dispose Menu items when you dispose Menu.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public IEnumerable<MenuItem> Items
        {
            get
            {
                return menuItems;
            }

            set
            {
                if (Content == null)
                {
                    Content = CreateDefaultContent();
                    if (styleApplied && (menuStyle != null))
                    {
                        Content.ApplyStyle(menuStyle.Content);
                    }
                }

                if (menuItems != null)
                {
                    foreach (var oldItem in menuItems)
                    {
                        if (Content.Children?.Contains(oldItem) == true)
                        {
                            Content.Remove(oldItem);
                        }
                    }
                }

                menuItems = value;

                if (menuItems == null)
                {
                    Content.SetVisible(false);
                    return;
                }

                if (Content.Visibility == false)
                {
                    Content.SetVisible(true);
                }

                foreach (var item in menuItems)
                {
                    Content.Add(item);
                    menuItemGroup.Add(item);
                }
            }
        }

        /// <summary>
        /// Anchor of Menu.
        /// Menu is displayed at the anchor's position.
        /// If there is not enough space to display menu at the anchor's position,
        /// then menu is displayed at the proper position near anchor's position.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public View Anchor
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(AnchorProperty) as View;
                }
                else
                {
                    return GetInternalAnchorProperty(this) as View;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(AnchorProperty, value);
                }
                else
                {
                    SetInternalAnchorProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }
        private View InternalAnchor
        {
            get
            {
                return anchor;
            }

            set
            {
                if (anchor == value)
                {
                    return;
                }

                anchor = value;
                if (anchor == null)
                {
                    return;
                }

                CalculateSizeAndPosition();
            }
        }

        /// <summary>
        /// The horizontal position of Menu relative to Anchor.
        /// If Anchor is not set, then RelativePosition does not work.
        /// If RelativePosition is Start, then Menu is displayed at the start of Anchor.
        /// If RelativePosition is Center, then Menu is displayed at the center of Anchor.
        /// If RelativePosition is End, then Menu is displayed at the end of Anchor.
        /// If there is not enough space to display menu at the anchor's position,
        /// then menu is displayed at the proper position near anchor's position.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public RelativePosition HorizontalPositionToAnchor
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (RelativePosition)GetValue(HorizontalPositionToAnchorProperty);
                }
                else
                {
                    return (RelativePosition)GetInternalHorizontalPositionToAnchorProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(HorizontalPositionToAnchorProperty, value);
                }
                else
                {
                    SetInternalHorizontalPositionToAnchorProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }
        private RelativePosition InternalHorizontalPositionToAnchor
        {
            get
            {
                return horizontalPosition;
            }

            set
            {
                if (horizontalPosition == value)
                {
                    return;
                }

                horizontalPosition = value;

                CalculateSizeAndPosition();
            }
        }

        /// <summary>
        /// The vertical position of Menu relative to Anchor.
        /// If Anchor is not set, then RelativePosition does not work.
        /// If RelativePosition is Start, then Menu is displayed at the start of Anchor.
        /// If RelativePosition is Center, then Menu is displayed at the center of Anchor.
        /// If RelativePosition is End, then Menu is displayed at the end of Anchor.
        /// If there is not enough space to display menu at the anchor's position,
        /// then menu is displayed at the proper position near anchor's position.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public RelativePosition VerticalPositionToAnchor
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (RelativePosition)GetValue(VerticalPositionToAnchorProperty);
                }
                else
                {
                    return (RelativePosition)GetInternalVerticalPositionToAnchorProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(VerticalPositionToAnchorProperty, value);
                }
                else
                {
                    SetInternalVerticalPositionToAnchorProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }
        private RelativePosition InternalVerticalPositionToAnchor
        {
            get
            {
                return verticalPosition;
            }

            set
            {
                if (verticalPosition == value)
                {
                    return;
                }

                verticalPosition = value;

                CalculateSizeAndPosition();
            }
        }

        /// <summary>
        /// Gets Menu style.
        /// </summary>
        /// <returns>The default Menu style.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ViewStyle CreateViewStyle()
        {
            return new MenuStyle();
        }

        /// <summary>
        /// Content of Menu.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected View Content
        {
            get
            {
                return content;
            }
            set
            {
                if (content == value)
                {
                    return;
                }

                if (content != null)
                {
                    Remove(content);
                }

                content = value;
                if (content == null)
                {
                    return;
                }

                Add(content);

                if (Scrim != null)
                {
                    content.RaiseAbove(Scrim);
                }
            }
        }

        /// <summary>
        /// Scrim of Menu.
        /// Scrim is the screen region outside Menu.
        /// If Scrim is touched, then Menu is dismissed.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected View Scrim
        {
            get
            {
                return scrim;
            }
            set
            {
                if (scrim == value)
                {
                    return;
                }

                if (scrim != null)
                {
                    Remove(scrim);
                }

                scrim = value;
                if (scrim == null)
                {
                    return;
                }

                Add(scrim);

                if (Content != null)
                {
                    Content.RaiseAbove(scrim);
                }
            }
        }

        private Window Window
        {
            get
            {
                if (window == null)
                {
                    window = NUIApplication.GetDefaultWindow();
                }

                return window;
            }
            set
            {
                if (window == value)
                {
                    return;
                }

                window = value;
            }
        }

        /// <summary>
        /// Post the Menu.
        /// The Menu is displayed.
        /// </summary>
        /// <param name="window">The Window where Menu is displayed.</param>
        /// <since_tizen> 9 </since_tizen>
        public void Post(Window window = null)
        {
            if (window == null)
            {
                window = NUIApplication.GetDefaultWindow();
            }

            Window = window;

            Window.AddLayer(layer);
            layer.RaiseToTop();

            CalculateSizeAndPosition();
            RegisterDefaultLabel();
            NotifyAccessibilityStatesChange(new AccessibilityStates(AccessibilityState.Visible, AccessibilityState.Showing), AccessibilityStatesNotifyMode.Recursive);
        }

        /// <summary>
        /// Dismiss the Menu.
        /// The Menu becomes hidden and disposed.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public void Dismiss()
        {
            Hide();
            UnregisterDefaultLabel();
            NotifyAccessibilityStatesChange(new AccessibilityStates(AccessibilityState.Visible, AccessibilityState.Showing), AccessibilityStatesNotifyMode.Recursive);
            Dispose();
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnRelayout(Vector2 size, RelayoutContainer container)
        {
            base.OnRelayout(size, container);

            CalculateSizeAndPosition();
        }

        private void Initialize()
        {
            Layout = new AbsoluteLayout();

            WidthSpecification = LayoutParamPolicies.WrapContent;
            HeightSpecification = LayoutParamPolicies.WrapContent;

            // Menu is added to Anchor so Menu should exclude layouting because
            // if Anchor has Layout, then Menu is displayed at an incorrect position.
            ExcludeLayouting = true;

            Scrim = CreateDefaultScrim();

            menuItemGroup = new MenuItemGroup();

            layer = new Layer();
            layer.Add(this);
        }

        private ScrollableBase CreateDefaultContent()
        {
            return new ScrollableBase()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                },
                ScrollingDirection = ScrollableBase.Direction.Vertical,
                ScrollEnabled = true,
                HideScrollbar = false,
                ClippingMode = ClippingModeType.ClipChildren,
            };
        }

        private View CreateDefaultScrim()
        {
            var scrim = new VisualView()
            {
                // Scrim is added to Menu so Scrim should exclude layouting
                // not to enlarge Menu size.
                ExcludeLayouting = true,
                BackgroundColor = Color.Transparent,
                Size = new Size(NUIApplication.GetDefaultWindow().Size),
                DispatchParentGestureEvents = false,
            };

            scrim.TouchEvent += (object source, TouchEventArgs e) =>
            {
                if (e.Touch.GetState(0) == PointStateType.Up)
                {
                    this.Dismiss();
                }
                return true;
            };

            return scrim;
        }

        private void CalculateSizeAndPosition()
        {
            CalculateMenuPosition();

            CalculateScrimPosition();
        }

        private View GetRootView()
        {
            View root = this;
            View parent = GetParent() as View;

            while (parent)
            {
                root = parent;
                parent = parent?.GetParent() as View;
            }

            return root;
        }

        // Calculate menu's position based on Anchor and parent's positions.
        // If there is not enought space, then menu's size can be also resized.
        private void CalculateMenuPosition()
        {
            if (Anchor == null)
            {
                return;
            }

            if (SizeWidth.Equals(0) && SizeHeight.Equals(0))
            {
                return;
            }

            float menuScreenPosX = 0;
            float menuScreenPosY = 0;

            if (HorizontalPositionToAnchor == RelativePosition.Start)
            {
                if (GetRootView().LayoutDirection == ViewLayoutDirectionType.LTR)
                {
                    menuScreenPosX = Anchor.ScreenPosition.X - SizeWidth;
                }
                else
                {
                    menuScreenPosX = Anchor.ScreenPosition.X + Anchor.Margin.Start + Anchor.SizeWidth + Anchor.Margin.End;
                }
            }
            else if (HorizontalPositionToAnchor == RelativePosition.Center)
            {
                menuScreenPosX = Anchor.ScreenPosition.X + Anchor.Margin.Start + (Anchor.SizeWidth / 2) - (SizeWidth / 2);
            }
            else
            {
                if (GetRootView().LayoutDirection == ViewLayoutDirectionType.LTR)
                {
                    menuScreenPosX = Anchor.ScreenPosition.X + Anchor.Margin.Start + Anchor.SizeWidth + Anchor.Margin.End;
                }
                else
                {
                    menuScreenPosX = Anchor.ScreenPosition.X - SizeWidth;
                }
            }

            if (VerticalPositionToAnchor == RelativePosition.Start)
            {
                menuScreenPosY = Anchor.ScreenPosition.Y - SizeHeight;
            }
            else if (VerticalPositionToAnchor == RelativePosition.Center)
            {
                menuScreenPosY = Anchor.ScreenPosition.Y + Anchor.Margin.Top + (Anchor.SizeHeight / 2) - (SizeHeight / 2);
            }
            else
            {
                menuScreenPosY = Anchor.ScreenPosition.Y + Anchor.Margin.Top + Anchor.SizeHeight + Anchor.Margin.Bottom;
            }

            float menuSizeW = SizeWidth;
            float menuSizeH = SizeHeight;

            // Check if menu is not inside parent's boundary in x coordinate system.
            if (menuScreenPosX + SizeWidth > Window.Size.Width)
            {
                if (HorizontalPositionToAnchor == RelativePosition.Center)
                {
                    menuScreenPosX = Window.Size.Width - SizeWidth;
                }
                else
                {
                    menuSizeW = Window.Size.Width - menuScreenPosX;
                }
            }
            if (menuScreenPosX < 0)
            {
                menuScreenPosX = 0;

                if (menuSizeW > Window.Size.Width)
                {
                    menuSizeW = Window.Size.Width;
                }
            }

            // Check if menu is not inside parent's boundary in y coordinate system.
            if (menuScreenPosY + SizeHeight > Window.Size.Height)
            {
                if (VerticalPositionToAnchor == RelativePosition.Center)
                {
                    menuScreenPosY = Window.Size.Height - SizeHeight;
                }
                else
                {
                    menuSizeH = Window.Size.Height - menuScreenPosY;
                }
            }
            if (menuScreenPosY < 0)
            {
                menuScreenPosY = 0;

                if (menuSizeH > Window.Size.Height)
                {
                    menuSizeH = Window.Size.Height;
                }
            }

            // Position is relative to parent's coordinate system.
            var menuPosX = menuScreenPosX;
            var menuPosY = menuScreenPosY;

            if (!PositionX.Equals(menuPosX) || !PositionY.Equals(menuPosY) || !SizeWidth.Equals(menuSizeW) || !SizeHeight.Equals(menuSizeH))
            {
                Position = new Position(menuPosX, menuPosY);
                Size = new Size(menuSizeW, menuSizeH);
            }
        }

        // Calculate scrim's position based on menu's position
        private void CalculateScrimPosition()
        {
            if (Scrim == null)
            {
                return;
            }

            // Menu's Position should be updated before doing this calculation.
            if (!Scrim.PositionX.Equals(-PositionX) || !Scrim.PositionY.Equals(-PositionY))
            {
                Scrim.Position = new Position(-PositionX, -PositionY);
            }
        }

        /// <summary>
        /// Initialize AT-SPI object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnInitialize()
        {
            base.OnInitialize();
            AccessibilityRole = Role.PopupMenu;
        }

        /// <summary>
        /// Informs AT-SPI bridge about the set of AT-SPI states associated with this object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override AccessibilityStates AccessibilityCalculateStates()
        {
            var states = base.AccessibilityCalculateStates();

            states[AccessibilityState.Modal] = true;

            return states;
        }
    }
}
