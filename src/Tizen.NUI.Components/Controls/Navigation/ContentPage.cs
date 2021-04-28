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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// The ContentPage class is a class which is a formatted full screen page.
    /// ContentPage contains title app bar and content.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class ContentPage : Page
    {
        private AppBar appBar = null;
        private View content = null;

        /// <summary>
        /// Creates a new instance of a ContentPage.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public ContentPage() : base()
        {
            Layout = new AbsoluteLayout();

            // ContentPage fills to parent by default.
            WidthResizePolicy = ResizePolicyType.FillToParent;
            HeightResizePolicy = ResizePolicyType.FillToParent;
        }

        /// <summary>
        /// Dispose ContentPage and all children on it.
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
                if (appBar != null)
                {
                    Utility.Dispose(appBar);
                }

                if (content != null)
                {
                    Utility.Dispose(content);
                }
            }

            base.Dispose(type);
        }

        /// <summary>
        /// AppBar of ContentPage.
        /// AppBar is added as a child of ContentPage automatically.
        /// AppBar is positioned at the top of the Page.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public AppBar AppBar
        {
            get
            {
                return appBar;
            }
            set
            {
                if (appBar == value)
                {
                    return;
                }

                if (appBar != null)
                {
                    Remove(appBar);
                }

                appBar = value;
                if (appBar == null)
                {
                    return;
                }

                Add(appBar);

                CalculatePosition();
            }
        }

        /// <summary>
        /// Content of ContentPage.
        /// Content is added as a child of ContentPage automatically.
        /// Content is positioned below AppBar.
        /// Content is resized to fill the full screen except AppBar.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public View Content
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

                CalculatePosition();
            }
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnRelayout(Vector2 size, RelayoutContainer container)
        {
            base.OnRelayout(size, container);

            CalculatePosition();
        }

        // Calculate appBar and content's positions.
        private void CalculatePosition()
        {
            // If ContentPage size has not been set yet, then content size cannot be calculated.
            if ((Size2D.Width == 0) && (Size2D.Height == 0))
            {
                return;
            }

            if (appBar != null)
            {
                int appBarPosX = Position2D.X + Padding.Start + appBar.Margin.Top;
                int appBarPosY = Position2D.Y + Padding.Top + appBar.Margin.Top;

                appBar.Position2D = new Position2D(appBarPosX, appBarPosY);

                if ((appBar.WidthSpecification == LayoutParamPolicies.MatchParent) || (appBar.HeightSpecification == LayoutParamPolicies.MatchParent))
                {
                    int appBarSizeW = appBar.Size2D.Width;
                    int appBarSizeH = appBar.Size2D.Height;

                    if (appBar.WidthSpecification == LayoutParamPolicies.MatchParent)
                    {
                        appBarSizeW = Size2D.Width - Padding.Start - Padding.End - appBar.Margin.Start - appBar.Margin.End;
                    }

                    if (appBar.HeightSpecification == LayoutParamPolicies.MatchParent)
                    {
                        appBarSizeH = Size2D.Height - Padding.Top - Padding.Bottom - appBar.Margin.Top - appBar.Margin.Bottom;
                    }

                    appBar.Size2D = new Size2D(appBarSizeW, appBarSizeH);
                }
            }

            if (content != null)
            {
                int contentPosX = Position2D.X + Padding.Start + content.Margin.Start;
                int contentPosY = Position2D.Y + Padding.Top + content.Margin.Top + (appBar?.Size2D.Height ?? 0);

                content.Position2D = new Position2D(contentPosX, contentPosY);

                if ((content.WidthSpecification == LayoutParamPolicies.MatchParent) || (content.HeightSpecification == LayoutParamPolicies.MatchParent))
                {
                    int contentSizeW = content.Size2D.Width;
                    int contentSizeH = content.Size2D.Height;

                    if (content.WidthSpecification == LayoutParamPolicies.MatchParent)
                    {
                        contentSizeW = Size2D.Width - Padding.Start - Padding.End - content.Margin.Start - content.Margin.End;
                    }

                    if (content.HeightSpecification == LayoutParamPolicies.MatchParent)
                    {
                        contentSizeH = Size2D.Height - Padding.Top - Padding.Bottom - content.Margin.Top - content.Margin.Bottom - (appBar?.Size2D.Height ?? 0);
                    }

                    content.Size2D = new Size2D(contentSizeW, contentSizeH);
                }
            }
        }
    }
}
