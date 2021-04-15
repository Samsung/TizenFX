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
using Tizen.NUI.Components.Extension;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// DefaultLinearItemStyle is a class which saves DefaultLinearItem's ux data.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class DefaultLinearItemStyle : RecyclerViewItemStyle
    {
        static DefaultLinearItemStyle() { }

        /// <summary>
        /// Creates a new instance of a DefaultLinearItemStyle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DefaultLinearItemStyle() : base()
        {
        }

        /// <summary>
        /// Creates a new instance of a DefaultLinearItemStyle with style.
        /// </summary>
        /// <param name="style">Create DefaultLinearItemStyle by style customized by user.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DefaultLinearItemStyle(DefaultLinearItemStyle style) : base(style)
        {
        }

        /// <summary>
        /// Label Text's style.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLabelStyle Label { get; set; } = new TextLabelStyle();

        /// <summary>
        /// Sublabel Text's style.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLabelStyle SubLabel { get; set; } = new TextLabelStyle();

        /// <summary>
        /// Icon's style.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewStyle Icon { get; set; } = new ViewStyle();

        /// <summary>
        /// Extra's style.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewStyle Extra { get; set; } = new ViewStyle();

        /// <summary>
        /// Seperator's style.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewStyle Seperator { get; set; } = new ViewStyle();

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);

            if (bindableObject is DefaultLinearItemStyle RecyclerViewItemStyle)
            {
                Label.CopyFrom(RecyclerViewItemStyle.Label);
                SubLabel.CopyFrom(RecyclerViewItemStyle.SubLabel);
                Icon.CopyFrom(RecyclerViewItemStyle.Icon);
                Extra.CopyFrom(RecyclerViewItemStyle.Extra);
                Seperator.CopyFrom(RecyclerViewItemStyle.Seperator);
            }
        }
    }
}
