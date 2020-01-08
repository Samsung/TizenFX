/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
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
    /// The property map class that has transform property for one of its items.
    /// This class can be used to convert visual properties to map.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    abstract public class ShadowBase
    {
        internal delegate void PropertyChangedCallback(ShadowBase instance);

        internal PropertyChangedCallback OnPropertyChanged = null;

        private static readonly Vector2 noOffset = new Vector2(0, 0);

        private static readonly Vector2 noScale = new Vector2(1, 1);

        private static readonly Vector2 absoluteTransformPolicy = new Vector2((int)VisualTransformPolicyType.Absolute, (int)VisualTransformPolicyType.Absolute);


        /// <summary>
        /// The location offset value from the View
        /// </summary>
        protected internal Vector2 offset;

        /// <summary>
        /// The size value in scale
        /// </summary>
        protected internal Vector2 scale;

        /// <summary>
        /// The output property map
        /// </summary>
        protected internal PropertyMap propertyMap;

        /// <summary>
        /// Constructor
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ShadowBase() : this(noOffset, noScale)
        {
        }

        /// <summary>
        /// Copy Constructor
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ShadowBase(ShadowBase other) : this(other.offset, other.scale)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        protected internal ShadowBase(Vector2 offset, Vector2 scale)
        {
            propertyMap = new PropertyMap();

            Offset = offset;
            Scale = scale;
        }

        private void OnOffsetChanged(float x, float y)
        {
            OnPropertyChanged?.Invoke(this);
        }

        private void OnScaleChanged(float widht, float height)
        {
            OnPropertyChanged?.Invoke(this);
        }

        /// <summary>
        /// The position offset value (x, y) from the top left corner.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 Offset
        {
            get
            {
                return offset;
            }
            set
            {
                offset = new Vector2(OnOffsetChanged, value ?? noOffset);
                OnPropertyChanged?.Invoke(this);
            }
        }

        /// <summary>
        /// The value indicates percentage of the container size. <br />
        /// e.g. (0.5f, 1.0f) means 50% of the container's width and 100% of container's height.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 Scale
        {
            get
            {
                return scale;
            }
            set
            {
                scale = new Vector2(OnScaleChanged, value ?? noScale);
                OnPropertyChanged?.Invoke(this);
            }
        }

        private PropertyValue GetTransformMap()
        {
            var transformMap = new PropertyMap();

            if (!offset.Equals(noOffset))
            {
                transformMap[(int)VisualTransformPropertyType.OffsetPolicy] = new PropertyValue(absoluteTransformPolicy);
                transformMap[(int)VisualTransformPropertyType.Offset] = PropertyValue.CreateWithGuard(offset);
            }

            if (!scale.Equals(noScale))
            {
                transformMap[(int)VisualTransformPropertyType.Size] = PropertyValue.CreateWithGuard(scale);
            }

            return transformMap.Count() == 0 ? new PropertyValue() : new PropertyValue(transformMap);
        }

        abstract internal bool IsValid();

        static internal PropertyValue ToPropertyValue(ShadowBase instance)
        {
            if (instance == null || !instance.IsValid())
            {
                return new PropertyValue();
            }

            instance.propertyMap[Visual.Property.Transform] = instance.GetTransformMap();

            return new PropertyValue(instance.propertyMap);
        }
    }
}


