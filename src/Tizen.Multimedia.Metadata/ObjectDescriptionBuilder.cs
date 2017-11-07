/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Reflection;
using System.Text;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Represents a point in 2D space.
    /// </summary>
    internal static class ObjectDescriptionBuilder
    {
        internal static string BuildWithProperties(object obj)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var property in obj.GetType().GetRuntimeProperties())
            {
                object value = property.GetValue(obj);

                sb.Append(property.Name).Append("=");

                bool isObjectType = Convert.GetTypeCode(value) == TypeCode.Object;

                if (isObjectType)
                {
                    sb.Append("[").Append(value).Append("]");
                }
                else
                {
                    sb.Append(value);
                }

                sb.Append(", ");
            }
            if (sb.Length >= 2)
            {
                sb.Remove(sb.Length - 2, 2);
            }

            return sb.ToString();
        }
    }
}
