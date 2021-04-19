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
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContentPage : Page
    {
        private AppBar appBar = null;
        private View content = null;

        /// <summary>
        /// Creates a new instance of a ContentPage.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContentPage() : base()
        {
            // AppBar and Content are located vertically.
            Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Vertical,
            };

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
        /// AppBar of ContentPage. AppBar is added to Children automatically.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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

                appBar.Weight = 0.0f;

                ResetContent();
            }
        }

        /// <summary>
        /// Content of ContentPage. Content is added to Children automatically.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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

                content.Weight = 1.0f;

                ResetContent();
            }
        }

        private void ResetContent()
        {
            // To keep the order of AppBar and Content, the existing contents are
            // removed and added again.
            if ((appBar != null) && Children.Contains(appBar))
            {
                Remove(appBar);
            }

            if ((content != null) && Children.Contains(content))
            {
                Remove(content);
            }

            if (appBar != null)
            {
                Add(appBar);
            }

            if (content != null)
            {
                Add(content);
            }
        }
    }
}
