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

using System;
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// The Text Shadow for TextLabel.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TextShadow : Disposable, ICloneable
    {
        private readonly PropertyMap propertyMap = null;

        internal delegate void PropertyChangedCallback(TextShadow instance);

        /// <summary>
        /// Constructor
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextShadow(Color color, Vector2 offset, float blurRadius)
        {
            propertyMap = new PropertyMap();

            Color = color;
            propertyMap["color"] = PropertyValue.CreateWithGuard(Color);

            Offset = offset;
            propertyMap["offset"] = PropertyValue.CreateWithGuard(Offset);

            BlurRadius = blurRadius;
            propertyMap["blurRadius"] = new PropertyValue(BlurRadius);
        }

        /// <summary>	
        /// destructor. This is HiddenAPI. recommended not to use in public.	
        /// </summary>	
        [EditorBrowsable(EditorBrowsableState.Never)]
        ~TextShadow()
        {
            Dispose();
        }

        /// <summary>
        /// Deep copy method
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object Clone()
        {
            return new TextShadow(Color, Offset, BlurRadius);
        }

        /// <summary>
        /// Deep copy method (static)
        /// This provides nullity check.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static object Clone(TextShadow instance)
        {
            return instance == null ? null : new TextShadow(instance.Color, instance.Offset, instance.BlurRadius);
        }

        /// <summary>
        /// The color for the shadow of text.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color Color { get; } = Color.Black;

        /// <summary>
        /// The offset for the shadow of text.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 Offset { get; } = Vector2.Zero;

        /// <summary>
        /// The blur radius of the shadow of text.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float BlurRadius { get; } = 0.0f;

        internal TextShadow(PropertyMap propertyMap)
        {
            this.propertyMap = new PropertyMap(propertyMap);
        }

        internal TextShadow(TextShadow other)
        {
            propertyMap = new PropertyMap();

            Color = other.Color;
            propertyMap["color"] = PropertyValue.CreateWithGuard(Color);

            Offset = other.Offset;
            propertyMap["offset"] = PropertyValue.CreateWithGuard(Offset);

            BlurRadius = other.BlurRadius;
            propertyMap["blurRadius"] = new PropertyValue(BlurRadius);
        }

        static internal PropertyValue ToPropertyValue(TextShadow instance)
        {
            if (instance == null)
            {
                return new PropertyValue();
            }

            return new PropertyValue(instance.propertyMap);
        }


        /// <summary>
        /// Releases any unmanaged resources used by this object. Can also dispose any other disposable objects.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            propertyMap?.Dispose();
            Color?.Dispose();
            Offset?.Dispose();

            base.Dispose();
        }
    }
}
