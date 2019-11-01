/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.Components
{
    /// <summary>
    /// ColorVisualAttributes is a class which saves Button's ux data.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ColorVisualAttributes : VisualAttributes
    {
        /// <summary>
        /// Creates a new instance of a ColorVisualAttributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ColorVisualAttributes() : base() { }

        /// <summary>
        /// Creates a new instance of a ColorVisualAttributes with attributes.
        /// </summary>
        /// <param name="attributes">Create ButtonAttributes by attributes customized by user.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ColorVisualAttributes(ColorVisualAttributes attributes) : base(attributes)
        {
            if (null == attributes)
            {
                return;
            }

            Color = attributes.Color?.Clone() as ColorSelector;
            RenderIfTransparent = attributes.RenderIfTransparent;
        }

        /// <summary>
        /// Gets or sets the color of the color visual.<br />
        /// Mandatory.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public ColorSelector Color
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether to render if transparent.<br />
        /// If not specified, the default is false.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public bool? RenderIfTransparent
        {
            get;
            set;
        }

        /// <summary>
        /// Attributes's clone function.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Attributes Clone()
        {
            return new ColorVisualAttributes(this);
        }
    }
}
