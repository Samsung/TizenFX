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

namespace Tizen.NUI.CommonUI
{
    /// <summary>
    /// PaginationAttributes used to config the pagination represent.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class PaginationAttributes : ViewAttributes
    {
        /// <summary>
        /// Creates a new instance of a PaginationAttributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PaginationAttributes() : base() { }
        /// <summary>
        /// Creates a new instance of a PaginationAttributes using attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PaginationAttributes(PaginationAttributes attributes) : base(attributes)
        {
            if (attributes == null)
            {
                return;
            }

            if (attributes.IndicatorSize != null)
            {
                IndicatorSize = new Size2D(attributes.IndicatorSize.Width, attributes.IndicatorSize.Height);
            }
            if (attributes.IndicatorBackgroundURL != null)
            {
                IndicatorBackgroundURL = attributes.IndicatorBackgroundURL.Clone() as string;
            }
            if (attributes.IndicatorSelectURL != null)
            {
                IndicatorSelectURL = attributes.IndicatorSelectURL.Clone() as string;
            }
            IndicatorSpacing = attributes.IndicatorSpacing;
        }

        /// <summary>
        /// Gets or sets the size of the indicator.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D IndicatorSize
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the background resource of indicator.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string IndicatorBackgroundURL
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the resource of the select indicator.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string IndicatorSelectURL
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the space of the indicator.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int IndicatorSpacing
        {
            get;
            set;
        }


        /// <summary>
        /// Retrieves a copy of PaginationAttributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Attributes Clone()
        {
            return new PaginationAttributes(this);
        }

    }
}
