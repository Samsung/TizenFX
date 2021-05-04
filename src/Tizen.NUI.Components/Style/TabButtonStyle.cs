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
        /// Gets or Sets the Line Style at the top of TabButton.
        /// </summary>
        internal ViewStyle TopLine { get; set; } = new ViewStyle();

        /// <summary>
        /// Gets or Sets the Line Style at the bottom of TabButton.
        /// </summary>
        internal ViewStyle BottomLine { get; set; } = new ViewStyle();

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);

            if (bindableObject is TabButtonStyle tabButtonStyle)
            {
                TopLine.CopyFrom(tabButtonStyle.TopLine);
                BottomLine.CopyFrom(tabButtonStyle.BottomLine);
            }
        }
    }
}
