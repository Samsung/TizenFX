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

using System.Collections.Generic;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// Menu is a class which contains a set of MenuItems and has one of them selected.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class Menu : Control
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

        /// <summary>
        /// Creates a new instance of Menu.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Menu() : base()
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
                if (menuItems != null)
                {
                    foreach (var oldItem in menuItems)
                    {
                        if (content.Children?.Contains(oldItem) == true)
                        {
                            content.Remove(oldItem);
                        }
                    }
                }

                menuItems = value;

                if (menuItems == null)
                {
                    return;
                }

                foreach (var item in menuItems)
                {
                    content.Add(item);
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
        }

        /// <summary>
        /// Dismiss the Menu.
        /// The Menu becomes hidden and disposed.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public void Dismiss()
        {
            Hide();
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

            Content = CreateDefaultContent();

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
            CalculateMenuSize();

            CalculateMenuPosition();

            CalculateScrimPosition();
        }

        // Calculate menu's size based on content's size
        private void CalculateMenuSize()
        {
            if (Content == null)
            {
                return;
            }

            if (Size2D.Equals(Content.Size2D) == false)
            {
                Size2D = new Size2D(Content.Size2D.Width, Content.Size2D.Height);
            }
        }

        private View GetRootView()
        {
            View root = this;
            View parent = GetParent() as View;

            while (parent)
            {
                root = parent;
                parent = parent.GetParent() as View;
            }

            return root;
        }

        // Calculate menu's position based on Anchor and parent's positions.
        // If there is not enought space, then menu's size can be also resized.
        private void CalculateMenuPosition()
        {
            if ((Anchor == null) || (Content == null))
            {
                return;
            }

            if (Items == null)
            {
                return;
            }

            if ((Size2D.Width == 0) && (Size2D.Height == 0))
            {
                return;
            }

            int menuScreenPosX = 0;
            int menuScreenPosY = 0;

            if (HorizontalPositionToAnchor == RelativePosition.Start)
            {
                if (GetRootView().LayoutDirection == ViewLayoutDirectionType.LTR)
                {
                    menuScreenPosX = (int)Anchor.ScreenPosition.X - Size2D.Width;
                }
                else
                {
                    menuScreenPosX = (int)Anchor.ScreenPosition.X + Anchor.Margin.Start + Anchor.Size2D.Width + Anchor.Margin.End;
                }
            }
            else if (HorizontalPositionToAnchor == RelativePosition.Center)
            {
                menuScreenPosX = (int)Anchor.ScreenPosition.X + Anchor.Margin.Start + (Anchor.Size2D.Width / 2) - (Size2D.Width / 2);
            }
            else
            {
                if (GetRootView().LayoutDirection == ViewLayoutDirectionType.LTR)
                {
                    menuScreenPosX = (int)Anchor.ScreenPosition.X + Anchor.Margin.Start + Anchor.Size2D.Width + Anchor.Margin.End;
                }
                else
                {
                    menuScreenPosX = (int)Anchor.ScreenPosition.X - Size2D.Width;
                }
            }

            if (VerticalPositionToAnchor == RelativePosition.Start)
            {
                menuScreenPosY = (int)Anchor.ScreenPosition.Y - Size2D.Height;
            }
            else if (VerticalPositionToAnchor == RelativePosition.Center)
            {
                menuScreenPosY = (int)Anchor.ScreenPosition.Y + Anchor.Margin.Top + (Anchor.Size2D.Height / 2) - (Size2D.Height / 2);
            }
            else
            {
                menuScreenPosY = (int)Anchor.ScreenPosition.Y + Anchor.Margin.Top + Anchor.Size2D.Height + Anchor.Margin.Bottom;
            }

            int menuSizeW = Size2D.Width;
            int menuSizeH = Size2D.Height;

            // Check if menu is not inside parent's boundary in x coordinate system.
            if (menuScreenPosX + Size2D.Width > Window.Size.Width)
            {
                menuScreenPosX = Window.Size.Width - Size2D.Width;

                if (menuScreenPosX < 0)
                {
                    menuScreenPosX = 0;
                    menuSizeW = Window.Size.Width;
                }
            }
            else if (menuScreenPosX < 0)
            {
                menuScreenPosX = 0;
                menuSizeW = Window.Size.Width;
            }

            // Check if menu is not inside parent's boundary in y coordinate system.
            if (menuScreenPosY + Size2D.Height > Window.Size.Height)
            {
                menuScreenPosY = Window.Size.Height - Size2D.Height;

                if (menuScreenPosY < 0)
                {
                    menuScreenPosY = 0;
                    menuSizeH = Window.Size.Height;
                }
            }
            else if (menuScreenPosY < 0)
            {
                menuScreenPosY = 0;
                menuSizeH = Window.Size.Height;
            }

            // Position is relative to parent's coordinate system.
            var menuPosX = menuScreenPosX;
            var menuPosY = menuScreenPosY;

            if ((Position2D.X != menuPosX) || (Position2D.Y != menuPosY) || (Size2D.Width != menuSizeW) || (Size2D.Height != menuSizeH))
            {
                Position2D = new Position2D(menuPosX, menuPosY);
                Size2D = new Size2D(menuSizeW, menuSizeH);
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
            if ((Scrim.Position2D.X != -Position2D.X) || (Scrim.Position2D.Y != -Position2D.Y))
            {
                Scrim.Position2D = new Position2D(-Position2D.X, -Position2D.Y);
            }
        }
    }
}
