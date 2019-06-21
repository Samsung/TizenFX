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
    /// ProgressAttributes is a class which saves Progress's ux data.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ProgressAttributes : ViewAttributes
    {
        /// <summary>
        /// Creates a new instance of a ProgressAttributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ProgressAttributes() : base() { }

        /// <summary>
        /// Creates a new instance of a ProgressAttributes with attributes.
        /// </summary>
        /// <param name="attributes">Create ProgressAttributes by attributes customized by user.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ProgressAttributes(ProgressAttributes attributes) : base(attributes)
        {
            if (null == attributes)
            {
                return;
            }

            if (null != attributes.TrackImageAttributes)
            {
                TrackImageAttributes = attributes.TrackImageAttributes.Clone() as ImageAttributes;
            }

            if (null != attributes.ProgressImageAttributes)
            {
                ProgressImageAttributes = attributes.ProgressImageAttributes.Clone() as ImageAttributes;
            }

            if (null != attributes.BufferImageAttributes)
            {
                BufferImageAttributes = attributes.BufferImageAttributes.Clone() as ImageAttributes;
            }

            if (null != attributes.LoadingImageAttributes)
            {
                LoadingImageAttributes = attributes.LoadingImageAttributes.Clone() as ImageAttributes;
            }
        }

        /// <summary>
        /// Get or set Track Image Attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes TrackImageAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Get or set Progress Image Attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes ProgressImageAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Get or set Buffer Image Attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes BufferImageAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Get or set LoadingImageAttributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes LoadingImageAttributes
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
            return new ProgressAttributes(this);
        }
    }
}
