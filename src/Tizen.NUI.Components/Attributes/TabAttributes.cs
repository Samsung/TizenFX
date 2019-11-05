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
    /// TabAttributes is a class which saves Tab's ux data.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TabAttributes : ViewAttributes
    {
        /// <summary>
        /// Creates a new instance of a TabAttributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TabAttributes() : base()
        {
            Space = new Extents(0, 0, 0, 0);
            UseTextNaturalSize = false;
            ItemSpace = 0;
        }

        /// <summary>
        /// Creates a new instance of a TabAttributes with attributes.
        /// </summary>
        /// <param name="attributes">Create TabAttributes by attributes customized by user.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TabAttributes(TabAttributes attributes) : base(attributes)
        {
            if (null == attributes)
            {
                return;
            }

            if (attributes.UnderLineAttributes != null)
            {
                UnderLineAttributes = attributes.UnderLineAttributes.Clone() as ViewAttributes;
            }

            if (attributes.TextAttributes != null)
            {
                TextAttributes = attributes.TextAttributes.Clone() as TextAttributes;
            }

            if (attributes.Space != null)
            {
                Space = new Extents(attributes.Space.Start, attributes.Space.End, attributes.Space.Top, attributes.Space.Bottom);
            }
            else
            {
                Space = new Extents(0, 0, 0, 0);
            }
            ItemSpace = attributes.ItemSpace;
            UseTextNaturalSize = attributes.UseTextNaturalSize;
        }

        /// <summary>
        /// UnderLine's attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewAttributes UnderLineAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Text's attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextAttributes TextAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Flag to decide if item is fill with item text's natural width.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool UseTextNaturalSize
        {
            get;
            set;
        }

        /// <summary>
        /// Gap between items.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int ItemSpace
        {
            get;
            set;
        }

        /// <summary>
        /// Space in Tab.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Extents Space
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
            return new TabAttributes(this);
        }
    }
}
