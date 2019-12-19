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
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// InputFieldAttributes is a class which saves InputField's ux data.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class InputFieldStyle : ControlStyle
    {
        /// <summary>
        /// Creates a new instance of a InputFieldAttributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public InputFieldStyle() : base()
        {
            BackgroundImageAttributes = new ImageViewStyle();
            InputBoxAttributes = new TextFieldStyle();
        }

        /// <summary>
        /// Creates a new instance of a InputFieldStyle with Style.
        /// </summary>
        /// <param name="attrs">Create InputFieldStyle by Style customized by user.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public InputFieldStyle(InputFieldStyle attrs) : base(attrs)
        {
            if (null == attrs)
            {
                return;
            }

            BackgroundImageAttributes = new ImageViewStyle();
            InputBoxAttributes = new TextFieldStyle();

            if (null != attrs.BackgroundImageAttributes)
            {
                BackgroundImageAttributes.CopyFrom(attrs.BackgroundImageAttributes);
            }
            if (null != attrs.InputBoxAttributes)
            {
                InputBoxAttributes.CopyFrom(attrs.InputBoxAttributes);
            }
            if (null != attrs.Space)
            {
                Space = attrs.Space;
            }
        }

        /// <summary>
        /// Gets or sets background image attributes of input field.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageViewStyle BackgroundImageAttributes { get; set; }

        /// <summary>
        /// Gets or sets input box attributes of input field.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextFieldStyle InputBoxAttributes { get; set; }

        /// <summary>
        /// Gets or sets space.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? Space { get; set; } 

        /// <summary>
        /// Attributes's clone function.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void CopyFrom(BindableObject bindableObject)
        {
            InputFieldStyle inputFieldAttributes = bindableObject as InputFieldStyle;

            if (null != inputFieldAttributes)
            {
                Space = inputFieldAttributes.Space;

                if (null != inputFieldAttributes.BackgroundImageAttributes)
                {
                    BackgroundImageAttributes.CopyFrom(inputFieldAttributes.BackgroundImageAttributes);
                }

                if (null != inputFieldAttributes.InputBoxAttributes)
                {
                    InputBoxAttributes.CopyFrom(inputFieldAttributes.InputBoxAttributes);
                }
            }
        }
    }
}
