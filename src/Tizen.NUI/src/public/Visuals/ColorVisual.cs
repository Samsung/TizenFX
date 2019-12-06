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
    /// A class encapsulating the property map of the color visual.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class ColorVisual : VisualMap
    {
        private Color _mixColorForColorVisual = null;
        private bool? _renderIfTransparent = false;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ColorVisual() : base()
        {
        }

        /// <summary>
        /// Gets or sets the solid color required.<br />
        /// Mandatory.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Color Color
        {
            get
            {
                return _mixColorForColorVisual;
            }
            set
            {
                _mixColorForColorVisual = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Gets or sets whether to render if the MixColor is transparent.
        /// By default it is false, which means that the ColorVisual will not render if the MIX_COLOR is transparent.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public bool RenderIfTransparent
        {
            get
            {
                return _renderIfTransparent ?? (false);
            }
            set
            {
                _renderIfTransparent = value;
                UpdateVisual();
            }
        }

        /// <summary>
        /// Compose the out visual map.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected override void ComposingPropertyMap()
        {
            if (_mixColorForColorVisual != null)
            {
                _outputVisualMap = new PropertyMap();
                _outputVisualMap.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Color));
                _outputVisualMap.Add(ColorVisualProperty.MixColor, new PropertyValue(_mixColorForColorVisual));
                if (_shader != null) { _outputVisualMap.Add(Visual.Property.Shader, new PropertyValue(_shader)); }
                if (_premultipliedAlpha != null) { _outputVisualMap.Add(Visual.Property.PremultipliedAlpha, new PropertyValue((bool)_premultipliedAlpha)); }
                if (_opacity != null) { _outputVisualMap.Add(Visual.Property.Opacity, new PropertyValue((float)_opacity)); }
                if (_renderIfTransparent != null) { _outputVisualMap.Add(ColorVisualProperty.RenderIfTransparent, new PropertyValue((bool)_renderIfTransparent)); }
                if (_visualFittingMode != null) { _outputVisualMap.Add(Visual.Property.VisualFittingMode, new PropertyValue((int)_visualFittingMode)); }
            }
        }
    }
}
