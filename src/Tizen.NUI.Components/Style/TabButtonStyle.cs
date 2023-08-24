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
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// TabButtonStyle is a class which saves TabButton's ux data.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TabButtonStyle : ButtonStyle
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        static TabButtonStyle() { }

        /// <summary>
        /// Creates a new instance of a TabButtonStyle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TabButtonStyle() : base()
        {
        }

        /// <summary>
        /// Creates a new instance of a TabButtonStyle with style.
        /// </summary>
        /// <param name="style">Create TabButtonStyle by style customized by user.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TabButtonStyle(TabButtonStyle style) : base(style)
        {
        }

        /// <summary>
        /// Gets or sets the size of a view with icon for the width, the height, and the depth.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size SizeWithIcon { get; set; } = new Size();

        /// <summary>
        /// Gets or sets the size of a view with icon only for the width, the height, and the depth.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size SizeWithIconOnly { get; set; } = new Size();

        /// <summary>
        /// Gets or sets the size of icon with icon only for the width, the height, and the depth.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size IconSizeWithIconOnly { get; set; } = new Size();

        /// <summary>
        /// Gets or sets the text font size with icon.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float TextSizeWithIcon { get; set; }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);

            if (bindableObject is TabButtonStyle tabButtonStyle)
            {
                SizeWithIcon = new Size(tabButtonStyle.SizeWithIcon);
                SizeWithIconOnly = new Size(tabButtonStyle.SizeWithIconOnly);
                IconSizeWithIconOnly = new Size(tabButtonStyle.IconSizeWithIconOnly);
                TextSizeWithIcon = tabButtonStyle.TextSizeWithIcon;
            }
        }
    }
}
