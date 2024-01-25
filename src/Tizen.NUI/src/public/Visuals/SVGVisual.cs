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
    /// A class encapsulating the property map of the SVG visual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class SVGVisual : VisualMap
    {
        private string url = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public SVGVisual() : base()
        {
        }

        /// <summary>
        /// The url of the svg resource.
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
        /// Compose the out visual map.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected override void ComposingPropertyMap()
        {
            if (url != null)
            {
                _outputVisualMap = new PropertyMap();
                PropertyValue temp = new PropertyValue((int)Visual.Type.SVG);
                _outputVisualMap.Add(Visual.Property.Type, temp);
                temp.Dispose();
                temp = new PropertyValue(url);
                _outputVisualMap.Add(ImageVisualProperty.URL, temp);
                temp.Dispose();
                base.ComposingPropertyMap();
            }
        }
    }
}
