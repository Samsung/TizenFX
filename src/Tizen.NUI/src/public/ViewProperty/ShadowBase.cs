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

        private static readonly Vector2 noExtents = new Vector2(0, 0);

        private static readonly Vector2 absoluteTransformPolicy = new Vector2((int)VisualTransformPolicyType.Absolute, (int)VisualTransformPolicyType.Absolute);


        /// <summary>
        /// The location offset value from the View
        /// </summary>
        protected internal Vector2 offset;

        /// <summary>
        /// The size value in extension length
        /// </summary>
        protected internal Vector2 extents;

        /// <summary>
        /// The output property map
        /// </summary>
        protected internal PropertyMap propertyMap;

        /// <summary>
        /// Constructor
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ShadowBase() : this(noOffset, noExtents)
        {
        }

        /// <summary>
        /// Copy Constructor
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ShadowBase(ShadowBase other) : this(other.offset, other.extents)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        private ShadowBase(Vector2 offset, Vector2 extents)
        {
            propertyMap = new PropertyMap();

            Offset = offset;
            Extents = extents;
        }

        private void OnOffsetOrSizeChanged(float x, float y)
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
                offset = new Vector2(OnOffsetOrSizeChanged, value ?? noOffset);
                OnPropertyChanged?.Invoke(this);
            }
        }

        /// <summary>
        /// The value indicates percentage of the container size. <br />
        /// e.g. (0.5f, 1.0f) means 50% of the container's width and 100% of container's height.
        /// </summary>
        /// <Remarks> It is not guaranteed that this would work well. It will be removed in the next version.</Remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 Scale
        {
            get
            {
                return new Vector2();
            }
            set
            {
            }
        }

        /// <summary>
        /// The shadow will extend its size by specified amount of length.<br />
        /// If the value is negative then the shadow will shrink.
        /// For example, when View's size is (100, 100) and the Shadow's Extents is (5, -5),
        /// the output shadow will have size (105, 95).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 Extents
        {
            get
            {
                return extents;
            }
            set
            {
                extents = new Vector2(OnOffsetOrSizeChanged, value ?? noExtents);
                OnPropertyChanged?.Invoke(this);
            }
        }

        private PropertyValue GetTransformMap(BaseComponents.View attachedView)
        {
            var transformMap = new PropertyMap();

            if (!offset.Equals(noOffset))
            {
                transformMap[(int)VisualTransformPropertyType.OffsetPolicy] = new PropertyValue(absoluteTransformPolicy);
                transformMap[(int)VisualTransformPropertyType.Offset] = PropertyValue.CreateWithGuard(offset);
            }

            if (!extents.Equals(noExtents))
            {
                var viewSize = new Vector2(attachedView.GetRelayoutSize(DimensionType.Width), attachedView.GetRelayoutSize(DimensionType.Height));
                var shadowSize = viewSize + extents;

                transformMap[(int)VisualTransformPropertyType.SizePolicy] = new PropertyValue(absoluteTransformPolicy);
                transformMap[(int)VisualTransformPropertyType.Size] = PropertyValue.CreateWithGuard(shadowSize);
            }

            return transformMap.Count() == 0 ? new PropertyValue() : new PropertyValue(transformMap);
        }

        abstract internal bool IsValid();

        internal bool HasValidSizeExtents()
        {
            return IsValid() && !extents.Equals(noExtents);
        }

        static internal PropertyValue ToPropertyValue(ShadowBase instance, BaseComponents.View attachedView)
        {
            if (instance == null || !instance.IsValid())
            {
                return new PropertyValue();
            }

            if (attachedView.CornerRadius > 0)
            {
                instance.propertyMap[Visual.Property.CornerRadius] = new PropertyValue(attachedView.CornerRadius);
            }

            instance.propertyMap[Visual.Property.Transform] = instance.GetTransformMap(attachedView);

            return new PropertyValue(instance.propertyMap);
        }
    }
}


