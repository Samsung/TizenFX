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
        // Note that, when you update this dictionary, please update visualPropertyTableMinKeyLength also.
        private static readonly Dictionary<string, (int, int)> visualPropertyTable = new Dictionary<string, (int, int)>()
        {
            { "backgroundColor", (View.Property.BACKGROUND, ColorVisualProperty.MixColor) },
            { "boxShadow.Offset", (View.Property.SHADOW, (int)VisualTransformPropertyType.Offset) },
            { "boxShadow.Color", (View.Property.SHADOW, ColorVisualProperty.MixColor) },
            { "boxShadow.BlurRadius", (View.Property.SHADOW, ColorVisualProperty.BlurRadius) },
            { "imageShadow.Offset", (View.Property.SHADOW, (int)VisualTransformPropertyType.Offset) },
        };

        // This value is minimum string key length of visualPropertyTable.
        private static readonly int visualPropertyTableMinKeyLength = 15;


        // Note that, when you update this dictionary, please update visualPropertyDoubleTableMinKeyLength also.
        private static readonly Dictionary<string, ((int, int), (int, int))> visualPropertyDoubleTable = new Dictionary<string, ((int, int), (int, int))>()
        {
            { "cornerRadius", ((View.Property.BACKGROUND, Visual.Property.CornerRadius),
                                (View.Property.SHADOW, Visual.Property.CornerRadius)) },
        };

        // This value is minimum string key length of visualPropertyDoubleTable.
        private static readonly int visualPropertyDoubleTableMinKeyLength = 12;

        ///<summary>
        /// Returns a Property if stringProperty is a valid index
        ///</summary>
        internal static Property GetPropertyFromString(Animatable handle, string stringProperty)
        {
            // Convert property string to be lowercase
            StringBuilder sb = new StringBuilder(stringProperty);
            sb[0] = (char)(sb[0] | 0x20);
            string str = sb.ToString();

            Property property = new Property(handle, str);
            if (property.propertyIndex == Property.InvalidIndex)
            {
                throw new System.ArgumentException("string property is invalid");
            }

            return property;
        }

        internal static Property[] GetPropertiesFromString(Animatable handle, string stringProperty)
        {
            // Convert property string to be lowercase
            StringBuilder sb = new StringBuilder(stringProperty);
            sb[0] = (char)(sb[0] | 0x20);
            string str = sb.ToString();

            Property property = new Property(handle, str);
            if (property.propertyIndex != Property.InvalidIndex)
            {
                return new Property[] { property };
            }

            var visualProperties = GetVisualProperties(handle, str);

            if (visualProperties == null)
            {
                throw new System.ArgumentException("string property is invalid");
            }

            return visualProperties;
        }

        private static Property[] GetVisualProperties(Animatable handle, string lowercaseViewProperty)
        {
            View view = handle as View;

            if (view == null) return null;

            int length = lowercaseViewProperty.Length;

            (int, int) found;
            if (length >= visualPropertyTableMinKeyLength && visualPropertyTable.TryGetValue(lowercaseViewProperty, out found))
            {
                var propertyIntPtr = Interop.View.GetVisualProperty(view.SwigCPtr, found.Item1, found.Item2);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return new Property[] { new Property(propertyIntPtr, true) };
            }

            ((int, int), (int, int)) foundDouble;
            if (length >= visualPropertyDoubleTableMinKeyLength && visualPropertyDoubleTable.TryGetValue(lowercaseViewProperty, out foundDouble))
            {
                var property1IntPtr = Interop.View.GetVisualProperty(view.SwigCPtr, foundDouble.Item1.Item1, foundDouble.Item1.Item2);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                var property2IntPtr = Interop.View.GetVisualProperty(view.SwigCPtr, foundDouble.Item2.Item1, foundDouble.Item2.Item2);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                return new Property[] { new Property(property1IntPtr, true), new Property(property2IntPtr, true) };
            }

            return null;
        }
    }
}
