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
    /// The property map class that has transform property for one of its items.
    /// This class can be used to convert visual properties to map.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    abstract public class TransformablePropertyMap
    {
        internal delegate void PropertyChangedCallback(TransformablePropertyMap instance);

        internal PropertyChangedCallback OnPropertyChanged = null;

        private static readonly Vector2 noOffset = new Vector2(0, 0);

        private static readonly Vector2 noScale = new Vector2(1, 1);

        private static readonly Vector2 defaultOffset = new Vector2(0, 0);

        private static readonly Vector2 defaultOffsetPolicy = new Vector2((int)VisualTransformPolicyType.Absolute, (int)VisualTransformPolicyType.Absolute);


        /// <summary>
        /// The offset value that tansform should have in common
        /// </summary>
        protected internal Vector2 offset = defaultOffset;

        /// <summary>
        /// The size value in scale that tansform should have in common
        /// </summary>
        protected internal Vector2 scale = noScale;

        /// <summary>
        /// The output property map
        /// </summary>
        protected internal PropertyMap propertyMap;

        /// <summary>
        /// The transform property map
        /// </summary>
        protected internal PropertyMap transformMap;

        /// <summary>
        /// Constructor
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TransformablePropertyMap()
        {
            // Initialize maps
            propertyMap = new PropertyMap();
            transformMap = new PropertyMap();

            // Offet has default value, so need to update map
            transformMap[(int)VisualTransformPropertyType.OffsetPolicy] = new PropertyValue(defaultOffsetPolicy);
            transformMap[(int)VisualTransformPropertyType.Offset] = PropertyValue.CreateWithGuard(offset);
            propertyMap[Visual.Property.Transform] = new PropertyValue(transformMap);
        }

        private void OnOffsetChanged(float x, float y)
        {
            UpdateOffset();
        }

        private void OnScaleChanged(float widht, float height)
        {
            UpdateScale();
        }

        private void UpdateOffset()
        {
            if (!ClearTransformMapIfNeeds())
            {
                transformMap[(int)VisualTransformPropertyType.Offset] = PropertyValue.CreateWithGuard(offset);
                propertyMap[Visual.Property.Transform] = new PropertyValue(transformMap);
            }
            OnPropertyChanged?.Invoke(this);
        }

        private void UpdateScale()
        {
            if (!ClearTransformMapIfNeeds())
            {
                transformMap[(int)VisualTransformPropertyType.Size] = PropertyValue.CreateWithGuard(scale);
                propertyMap[Visual.Property.Transform] = new PropertyValue(transformMap);
            }
            OnPropertyChanged?.Invoke(this);
        }

        /// <summary>
        /// Indicates whether the transform map is needed or not.
        /// This checks offset and scale values are valid.
        /// It can be overwritten in the derived class.
        /// </summary>
        virtual protected internal bool NeedTransformMap()
        {
            return (offset != null && !offset.Equals(noOffset)) || (scale != null && !scale.Equals(noScale));
        }

        /// <summary>
        /// If this map does not need to have transform property(= no offset and no size),
        /// clear existing transform map and return true.
        /// Return false when it needs to transform.
        /// </summary>
        protected internal bool ClearTransformMapIfNeeds()
        {
            if (!NeedTransformMap())
            {
                transformMap.Clear();
                transformMap[(int)VisualTransformPropertyType.OffsetPolicy] = new PropertyValue(defaultOffsetPolicy);
                propertyMap[Visual.Property.Transform] = new PropertyValue();
                return true;
            }
            return false;
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
                offset = value == null? null : new Vector2(OnOffsetChanged, value);
                UpdateOffset();
            }
        }

        /// <summary>
        /// The value indicates percentage of the container size. <br />
        /// e.g. (0.5f, 1.0f) means 50% of the container's width and 100% of container's height.
        /// </summary>
        public Vector2 Scale
        {
            get
            {
                return scale;
            }
            set
            {
                scale = value == null? null : new Vector2(OnScaleChanged, value);
                UpdateScale();
            }
        }

        abstract internal string ToDebugString();

        abstract internal bool IsValid();

        static internal PropertyValue ToPropertyValue(TransformablePropertyMap instance)
        {
            return (instance != null && instance.IsValid()) ? new PropertyValue(instance.propertyMap) : new PropertyValue();
        }
    }
}


