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

namespace Tizen.NUI
{

    /// <summary>
    /// The platform provided shadow drawing for View
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Shadow : TransformablePropertyMap
    {
        private static readonly Color noColor = new Color(0, 0, 0, 0);

        private static readonly Color defaultColor = new Color(0, 0, 0, 0.5f);

        private Color color;

        private uint blurRadius;

        /// <summary>
        /// Constructor
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Shadow() : base()
        {
            Color = defaultColor;
        }

        /// <summary>
        /// The boolean conversion
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static implicit operator Shadow(bool value)
        {
            Shadow shadow = new Shadow()
            {
                Color = value ? defaultColor : noColor,
            };
            return shadow;
        }

        private void OnColorChanged(float r, float g, float b, float a)
        {
            UpdateColor();
        }

        private void UpdateColor()
        {
            propertyMap[ColorVisualProperty.MixColor] = PropertyValue.CreateWithGuard(color);
            OnPropertyChanged?.Invoke(this);
        }

        private void UpdateBlurRadius()
        {
            // TODO update blur radius value in the property map
            OnPropertyChanged?.Invoke(this);
        }

        /// <summary>
        /// The color for the shadow.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
                UpdateColor();
            }
        }

        /// <summary>
        /// The blur radius value for the shadow. Bigger value, much blurry.
        /// </summary>
        private uint BlurRadius
        {
            get
            {
                return blurRadius;
            }
            set
            {
                blurRadius = value;
                UpdateBlurRadius();
            }
        }

        override internal string ToDebugString()
        {
            string result = "";
            // TODO
            return result;
        }

        override internal bool IsValid()
        {
            return color != null && color.A != 0;
        }

        static internal new PropertyValue ToPropertyValue(TransformablePropertyMap instance)
        {
            if (instance == null || !instance.IsValid())
            {
                return new PropertyValue();
            }

            // TODO to be other blurable visual in the future
            instance.propertyMap.Insert(Visual.Property.Type, new PropertyValue((int)Visual.Type.Color));

            return new PropertyValue(instance.propertyMap);
        }
    }
}


