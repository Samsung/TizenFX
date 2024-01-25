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
using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// MenuStyle is a class which saves Menu's ux data.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class MenuStyle : ControlStyle
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        static MenuStyle() { }

        /// <summary>
        /// Creates a new instance of an MenuStyle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MenuStyle() : base()
        {
        }

        /// <summary>
        /// Creates a new instance of an MenuStyle with style.
        /// The given style is copied to the new instance.
        /// </summary>
        /// <param name="style">Creates MenuStyle by style customized by user.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MenuStyle(MenuStyle style) : base(style)
        {
        }

        /// <summary>
        /// Gets or sets the Menu Content style.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewStyle Content { get; set; } = new ViewStyle();

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);

            if (bindableObject is MenuStyle menuStyle)
            {
                Content.CopyFrom(menuStyle.Content);
            }
        }
    }
}
