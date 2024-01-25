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
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Tizen.Multimedia
{
    internal static class ValidationUtil
    {
        internal static void ValidateEnum(Type enumType, object value, string paramName)
        {
            if (!Enum.IsDefined(enumType, value))
            {
                throw new ArgumentException($"Invalid { enumType.Name } value : { value }", paramName);
            }
        }

        internal static void ValidateFlagsEnum<T>(T value, T allMasks, string paramName) where T : IConvertible
        {
            if (((~allMasks.ToInt32(CultureInfo.InvariantCulture)) & value.ToInt32(CultureInfo.InvariantCulture)) != 0)
            {
                throw new ArgumentException($"Invalid { typeof(T).Name } value : { value }", paramName);
            }
        }

        internal static void ValidateFeatureSupported(string featureKey)
        {
            if (Features.IsSupported(featureKey) == false)
            {
                throw new NotSupportedException($"The feature({featureKey}) is not supported.");
            }
        }

        internal static void ValidateIsNullOrEmpty(string value, string paramName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(paramName);
            }

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(paramName + " is a zero-length string.", paramName);
            }
        }

        internal static void ValidateIsAny<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null || !enumerable.Any<T>())
            {
                throw new ArgumentNullException(nameof(enumerable));
            }
        }
    }
}
