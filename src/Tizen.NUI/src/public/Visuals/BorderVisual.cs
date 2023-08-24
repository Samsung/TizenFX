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
    /// A class encapsulating the property map of the border visual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class BorderVisual : VisualMap
    {
        private Color color = null;
        private float? size = null;
        private bool? antiAliasing = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public BorderVisual() : base()
        {
        }

        /// <summary>
        /// Gets or sets the color of the border.<br />
        /// Mandatory.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets the width of the border (in pixels).<br />
        /// Mandatory.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float BorderSize
        {
            get
            {
                return size ?? (-1.0f);
            }
            set
            {
                size = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets whether the anti-aliasing of the border is required.<br />
        /// If not supplied, the default is false.<br />
        /// Optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool AntiAliasing
        {
            get
            {
                return antiAliasing ?? (false);
            }
            set
            {
                antiAliasing = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Compose the out visual map.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected override void ComposingPropertyMap()
        {
            if (color != null && size != null)
            {
                _outputVisualMap = new PropertyMap();
                PropertyValue temp = new PropertyValue((int)Visual.Type.Border);
                _outputVisualMap.Add(Visual.Property.Type, temp);
                temp.Dispose();

                temp = new PropertyValue((float)size);
                _outputVisualMap.Add(BorderVisualProperty.Size, temp);
                temp.Dispose();

                temp = new PropertyValue(color);
                _outputVisualMap.Add(BorderVisualProperty.Color, temp);
                temp.Dispose();

                if (antiAliasing != null)
                {
                    temp = new PropertyValue((bool)antiAliasing);
                    _outputVisualMap.Add(BorderVisualProperty.AntiAliasing, temp);
                    temp.Dispose();
                }
                base.ComposingPropertyMap();
            }
        }
    }
}
