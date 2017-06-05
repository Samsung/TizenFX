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
using System.Diagnostics;
using static Interop.MetadataExtractor;

namespace Tizen.Multimedia
{
    internal static class ValueConverter
    {
        internal static int? ToNullableInt(string str)
        {
            if (int.TryParse(str, out var value))
            {
                return value;
            }
            return null;
        }

        internal static int ToInt(string str)
        {
            return int.TryParse(str, out var value) ? value : 0;
        }

        internal static double? ToNullableDouble(string str)
        {
            if (double.TryParse(str, out var value))
            {
                return value;
            }
            return null;
        }
    }
}