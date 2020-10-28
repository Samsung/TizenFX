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
    public abstract class ShadowBase
    {
        private static readonly Vector2 noOffset = new Vector2(0, 0);

        private static readonly Vector2 noExtents = new Vector2(0, 0);

        /// <summary>
        /// Constructor
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected ShadowBase() : this(noOffset, noExtents)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected ShadowBase(Vector2 offset, Vector2 extents)
        {
            Offset = offset;
            Extents = extents;
        }

        /// <summary></summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal protected ShadowBase(PropertyMap propertyMap)
        {
            Offset = noOffset;
            Extents = noExtents;

            if (propertyMap == null)
            {
                return;
            }

            SetPropertyMap(propertyMap);
        }

        /// <summary>
        /// Copy Constructor
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected ShadowBase(ShadowBase other) : this(other.Offset, other.Extents)
        {
        }

        /// <summary>
        /// The position offset value (x, y) from the top left corner.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 Offset { get; set; }

        /// <summary>
        /// The shadow will extend its size by specified amount of length.<br />
        /// If the value is negative then the shadow will shrink.
        /// For example, when View's size is (100, 100) and the Shadow's Extents is (5, -5),
        /// the output shadow will have size (105, 95).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 Extents { get; set; }

        /// <summary></summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator ==(ShadowBase shadow1, ShadowBase shadow2)
        {
            return object.ReferenceEquals(shadow1, null) ? object.ReferenceEquals(shadow2, null) : shadow1.Equals(shadow2);
        }

        /// <summary></summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator !=(ShadowBase shadow1, ShadowBase shadow2)
        {
            return !(shadow1 == shadow2);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object other)
        {
            if ((other == null) || ! this.GetType().Equals(other.GetType())) 
            {
                return false;
            }
            
            var otherShadow = (ShadowBase)other;

            if (!((Offset == null) ? otherShadow.Offset == null : Offset.Equals(otherShadow.Offset)))
            {
                return false;
            }

            return ((Extents == null) ? otherShadow.Extents == null : Extents.Equals(otherShadow.Extents));
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = Offset == null ? 0 : Offset.GetHashCode();
                hash = (hash * 7) + (Extents == null ? 0 : Extents.GetHashCode());
                return hash;
            }
        }

        internal abstract bool IsEmpty();

        internal PropertyValue ToPropertyValue(BaseComponents.View attachedView)
        {
            if (IsEmpty())
            {
                return new PropertyValue();
            }

            var map = GetPropertyMap();

            if (attachedView.CornerRadius > 0)
            {
                map[Visual.Property.CornerRadius] = new PropertyValue(attachedView.CornerRadius);
            }

            map[Visual.Property.Transform] = GetTransformMap();

            return new PropertyValue(map);
        }

        /// <summary>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual PropertyMap GetPropertyMap()
        {
            PropertyMap map = new PropertyMap();

            return map;
        }

        /// <summary>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual bool SetPropertyMap(PropertyMap propertyMap)
        {
            if (propertyMap == null)
            {
                return false;
            }

            var transformProperty = propertyMap.Find(Visual.Property.Transform);

            if (transformProperty == null)
            {
                // No transform map
                return true;
            }

            var transformMap = new PropertyMap();

            if (transformProperty.Get(transformMap))
            {
                SetTransformMap(transformMap);
            }

            return true;
        }

        private PropertyValue GetTransformMap()
        {
            var transformMap = new PropertyMap();

            if (!Offset.Equals(noOffset))
            {
                transformMap[(int)VisualTransformPropertyType.OffsetPolicy] = new PropertyValue(new Vector2((int)VisualTransformPolicyType.Absolute, (int)VisualTransformPolicyType.Absolute));
                transformMap[(int)VisualTransformPropertyType.Offset] = PropertyValue.CreateWithGuard(Offset);
            }

            if (!Extents.Equals(noExtents))
            {
                transformMap[(int)VisualTransformPropertyType.ExtraSize] = PropertyValue.CreateWithGuard(Extents);
            }

            return transformMap.Count() == 0 ? new PropertyValue() : new PropertyValue(transformMap);
        }

        /// <summary>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private void SetTransformMap(PropertyMap transformMap)
        {
            if (transformMap == null)
            {
                return;
            }

            transformMap.Find((int)VisualTransformPropertyType.Offset)?.Get(Offset);
            transformMap.Find((int)VisualTransformPropertyType.ExtraSize)?.Get(Extents);
        }
    }
}


