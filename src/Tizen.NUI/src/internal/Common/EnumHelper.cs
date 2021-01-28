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

using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Tizen.NUI
{
    /// <summary>
    /// Enum help class.
    /// </summary>
    internal static class EnumHelper
    {
        /// <summary>
        /// Get the description from the numeric value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns>The description of the numeric value.</returns>
        public static string GetDescription<T>(this T value) where T : struct
        {
            string result = value.ToString();
            FieldInfo info = typeof(T).GetField(result);
            var attributes = info.GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (null != attributes?.FirstOrDefault() && (attributes.First() as DescriptionAttribute) != null)
            {
                result = (attributes.First() as DescriptionAttribute).Description;
            }

            return result;
        }

        /// <summary>
        /// Get the numeric value from the description.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="description"></param>
        /// <returns>The numeric value.</returns>
        public static T GetValueByDescription<T>(this string description) where T : struct
        {
            Type type = typeof(T);
            foreach (var field in type.GetFields())
            {
                if (description == field.Name)
                {
                    return (T)field.GetValue(null);
                }

                var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (null != attributes?.FirstOrDefault())
                {
                    if (description == attributes.First().Description)
                    {
                        return (T)field.GetValue(null);
                    }
                }
            }

            return (T)type.GetFields(BindingFlags.Public | BindingFlags.Static).FirstOrDefault().GetValue(null);
            //throw new ArgumentException($"{description} can't be found.", "Description");
        }

        /// <summary>
        /// Get the numeric value from string representation of the name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns>The numeric value.</returns>
        public static T GetValue<T>(this string value) where T : struct
        {
            T result;
            if (Enum.TryParse(value, true, out result))
            {
                return result;
            }

            throw new ArgumentException($"{value} can't be found.", nameof(value));
        }
    }
}
