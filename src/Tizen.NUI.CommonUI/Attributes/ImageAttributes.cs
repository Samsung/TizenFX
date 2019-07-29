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
    /// The image view attributes class.
    /// </summary>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ImageAttributes : ViewAttributes
    {
        /// <summary>
        /// Construct ImageAttributes.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes() : base() { }
        /// <summary>
        /// Construct with specified attribute.
        /// </summary>
        /// <param name="attributes">The specified ImageAttributes.</param>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes(ImageAttributes attributes) : base(attributes)
        {
            if (attributes == null)
            {
                return;
            }

            if (attributes.ResourceURL != null)
            {
                ResourceURL = attributes.ResourceURL.Clone() as StringSelector;
            }

            if (attributes.Border != null)
            {
                Border = attributes.Border.Clone() as RectangleSelector;
            }
        }
        /// <summary>
        /// Image URL.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StringSelector ResourceURL
        {
            get;
            set;
        }
        /// <summary>
        /// Image border.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RectangleSelector Border
        {
            get;
            set;
        }
        /// <summary>
        /// Attributes's clone function.
        /// </summary>
        /// <returns> Return the attributes clone.</returns>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Attributes Clone()
        {
            return new ImageAttributes(this);
        }

    }
}
