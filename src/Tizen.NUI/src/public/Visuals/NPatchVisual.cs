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

namespace Tizen.NUI
{
    /// <summary>
    /// A class encapsulating the property map of the n-patch image visual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class NPatchVisual : VisualMap
    {
        private string url = null;
        private bool? borderOnly = null;
        private Rectangle border = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public NPatchVisual() : base()
        {
        }

        /// <summary>
        /// Gets or sets the URL of the image.<br />
        /// Mandatory.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string URL
        {
            get
            {
                return url;
            }
            set
            {
                url = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets whether to draw the borders only (If true).<br />
        /// If not specified, the default is false.<br />
        /// For n-patch images only.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool BorderOnly
        {
            get
            {
                return borderOnly ?? false;
            }
            set
            {
                borderOnly = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// The border of the image is in the order: left, right, bottom, top.<br />
        /// For n-patch images only.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Rectangle Border
        {
            get
            {
                return border;
            }
            set
            {
                border = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Compose the out visual map.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected override void ComposingPropertyMap()
        {
            if (url != null)
            {
                _outputVisualMap = new PropertyMap();
                PropertyValue temp = new PropertyValue((int)Visual.Type.NPatch);
                _outputVisualMap.Add(Visual.Property.Type, temp);
                temp.Dispose();

                temp = new PropertyValue(url);
                _outputVisualMap.Add(NpatchImageVisualProperty.URL, temp);
                temp.Dispose();

                if (borderOnly != null)
                {
                    temp = new PropertyValue((bool)borderOnly);
                    _outputVisualMap.Add(NpatchImageVisualProperty.BorderOnly, temp);
                    temp.Dispose();
                }

                if (border != null)
                {
                    temp = new PropertyValue(border);
                    _outputVisualMap.Add(NpatchImageVisualProperty.Border, temp);
                    temp.Dispose();
                }
                base.ComposingPropertyMap();
            }
        }
    }
}
