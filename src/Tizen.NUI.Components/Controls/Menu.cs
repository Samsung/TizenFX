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
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Menu : Control
    {
        private ScrollableBase scrollableBase = null;
        private IEnumerable<MenuItem> menuItems = null;
        private MenuItemGroup menuItemGroup = null;
        private Position2D anchorPosition = new Position2D(0, 0);

        /// <summary>
        /// Creates a new instance of Menu.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Menu() : base()
        {
            Initialize();
        }

        /// <summary>
        /// Dispose Menu and all children on it.
        /// </summary>
        /// <param name="type">Dispose type.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                if (menuItems != null)
                {
                    foreach (MenuItem menuItem in menuItems)
                    {
                        Utility.Dispose(menuItem);
                    }
                }

                menuItemGroup = null;

                if (anchorPosition != null)
                {
                    anchorPosition.Dispose();
                    anchorPosition = null;
                }

                Utility.Dispose(scrollableBase);
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Menu items in Menu.
        /// </summary>
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
                        if (scrollableBase.Children?.Contains(oldItem) == true)
                        {
                            scrollableBase.Children.Remove(oldItem);
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
                    scrollableBase.Add(item);
                    menuItemGroup.Add(item);
                }
            }
        }

        /// <summary>
        /// Anchor position of Menu.
        /// Menu is displayed at the anchor position.
        /// If there is no enough space to display menu at the anchor position,
        /// then menu is displayed at the proper position near anchor position.
        /// </summary>
        public Position2D AnchorPosition
        {
            get
            {
                return anchorPosition;
            }

            set
            {
                if (anchorPosition == value)
                {
                    return;
                }

                anchorPosition = value;
                if (anchorPosition == null)
                {
                    return;
                }

                CalculateSizeAndPosition();
            }
        }

        /// <inheritdoc/>
        public override void OnRelayout(Vector2 size, RelayoutContainer container)
        {
            base.OnRelayout(size, container);

            CalculateSizeAndPosition();
        }

        private void Initialize()
        {
            Layout = new AbsoluteLayout();

            WidthSpecification = LayoutParamPolicies.WrapContent;

            scrollableBase = new ScrollableBase()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                },
                ScrollingDirection = ScrollableBase.Direction.Vertical,
                ScrollEnabled = true,
                HideScrollbar = false,
            };
            Add(scrollableBase);

            menuItemGroup = new MenuItemGroup();
        }

        private void CalculateSizeAndPosition()
        {
            var parent = GetParent() as View;

            if ((AnchorPosition == null) || (parent == null))
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

            var parentPosition = new Position2D((int)parent.ScreenPosition.X, (int)parent.ScreenPosition.Y);
            var parentSize = new Size2D(parent.Size2D.Width, parent.Size2D.Height);

            int menuPosX = AnchorPosition.X;
            int menuPosY = AnchorPosition.Y;
            int menuSizeW = Size2D.Width;
            int menuSizeH = Size2D.Height;

            // Check if menu is not inside parent's boundary in x coordinate system.
            if (AnchorPosition.X + Size2D.Width > parentPosition.X + parentSize.Width)
            {
                menuPosX = parentPosition.X + parentSize.Width - Size2D.Width;

                if (menuPosX < parentPosition.X)
                {
                    menuPosX = parentPosition.X;
                    menuSizeW = parentSize.Width;
                }
            }

            // Check if menu is not inside parent's boundary in y coordinate system.
            if (AnchorPosition.Y + Size2D.Height > parentPosition.Y + parentSize.Height)
            {
                menuPosY = parentPosition.Y + parentSize.Height - Size2D.Height;

                if (menuPosY < parentPosition.Y)
                {
                    menuPosY = parentPosition.Y;
                    menuSizeH = parentSize.Height;
                }
            }

            Position2D = new Position2D(menuPosX, menuPosY);
            Size2D = new Size2D(menuSizeW, menuSizeH);

            parentPosition.Dispose();
            parentSize.Dispose();
        }
    }
}
