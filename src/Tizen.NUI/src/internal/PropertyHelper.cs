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
using System.Text;

namespace Tizen.NUI
{
    internal static class PropertyHelper
    {
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
            if (property.propertyIndex == Property.INVALID_INDEX)
            {
                throw new System.ArgumentException("string property is invalid");
            }

            return property;
        }
    }
}
