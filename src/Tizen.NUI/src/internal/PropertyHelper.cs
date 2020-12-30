/*
 * Copyright(c) 2017 Samsung Electronics Co., Ltd.
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
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    internal static class PropertyHelper
    {
        /// <summary>
        /// Note that, when you update this dictionary, please update visualPropertyTableMinKeyLength also.
        /// Dictionary "lowercasePropertyName, (visualIndex, propertyIndex, relatedProperty)"
        /// </summary>
        private static readonly Dictionary<string, (int, int, string)> visualPropertyTable = new Dictionary<string, (int, int, string)>()
        {
            { "backgroundColor", (View.Property.BACKGROUND, ColorVisualProperty.MixColor, null) },
            { "backgroundOpacity", (View.Property.BACKGROUND, Visual.Property.Opacity, null) },
            { "boxShadow.BlurRadius", (View.Property.SHADOW, ColorVisualProperty.BlurRadius, null) },
            { "boxShadow.Color", (View.Property.SHADOW, ColorVisualProperty.MixColor, null) },
            { "boxShadow.Offset", (View.Property.SHADOW, (int)VisualTransformPropertyType.Offset, null) },
            { "boxShadow.Opacity", (View.Property.SHADOW, Visual.Property.Opacity, null) },
            { "cornerRadius", (View.Property.BACKGROUND, Visual.Property.CornerRadius, "shadow.CornerRadius") },
            { "imageShadow.Offset", (View.Property.SHADOW, (int)VisualTransformPropertyType.Offset, null) },
            { "shadow.CornerRadius", (View.Property.SHADOW, Visual.Property.CornerRadius, null) },
        };

        /// <summary>
        /// This value is minimum string key length of visualPropertyTable.
        /// </summary>
        private const int visualPropertyTableMinKeyLength = 12;

        ///<summary>
        /// Returns a Property if stringProperty is a valid index
        ///</summary>
        internal static Property GetPropertyFromString(Animatable handle, string stringProperty)
        {
            // Convert property string to be lowercase
            StringBuilder sb = new StringBuilder(stringProperty);
            sb[0] = (char)(sb[0] | 0x20);
            string str = sb.ToString();

            Property property = GetProperty(handle, str);

            if (property == null || property.propertyIndex == Property.InvalidIndex)
            {
                throw new System.ArgumentException("string property is invalid");
            }

            return property;
        }

        private static Property GetProperty(Animatable handle, string lowercaseViewProperty)
        {
            Property property = new Property(handle, lowercaseViewProperty);
            if (property.propertyIndex != Property.InvalidIndex)
            {
                return property;
            }
            return GetVisualProperty(handle, lowercaseViewProperty);
        }

        private static Property GetVisualProperty(Animatable handle, string lowercaseViewProperty)
        {
            View view = handle as View;

            if (view == null) return null;

            int length = lowercaseViewProperty.Length;

            if (length < visualPropertyTableMinKeyLength)
            {
                return null;
            }

            (int, int, string) found;
            if (!visualPropertyTable.TryGetValue(lowercaseViewProperty, out found))
            {
                return null;
            }

            var propertyIntPtr = Interop.View.GetVisualProperty(view.SwigCPtr, found.Item1, found.Item2);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            var result = new Property(propertyIntPtr, true);

            if (found.Item3 != null)
            {
                Property relatedProperty = GetProperty(handle, found.Item3);
                if (relatedProperty != null && relatedProperty.propertyIndex != Property.InvalidIndex)
                {
                    result.RelatedProperty = relatedProperty;
                }
            }

            return result;
        }
    }
}
