/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
using System.Globalization;
using System.Linq;
using System.Reflection;

using Tizen.NUI;

namespace Tizen.NUI.Binding
{
    internal class ExtentsTypeConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            if (value != null)
            {
                string[] parts = value.Split(TypeConverter.UnifiedDelimiter);
                if (parts.Length == 4)
                {
                    return new Extents((ushort)GraphicsTypeManager.Instance.ConvertScriptToPixel(parts[0].Trim()),
                                       (ushort)GraphicsTypeManager.Instance.ConvertScriptToPixel(parts[1].Trim()),
                                       (ushort)GraphicsTypeManager.Instance.ConvertScriptToPixel(parts[2].Trim()),
                                       (ushort)GraphicsTypeManager.Instance.ConvertScriptToPixel(parts[3].Trim()));
                }
                else if (parts.Length == 1)
                {
                    return new Extents(ushort.Parse(parts[0].Trim(), CultureInfo.InvariantCulture));
                }
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(Extents)}");
        }

        public override string ConvertToString(object value)
        {
            Extents extents = (Extents)value;
            return extents.Start.ToString() + TypeConverter.UnifiedDelimiter + extents.End.ToString() + TypeConverter.UnifiedDelimiter + extents.Top.ToString() + TypeConverter.UnifiedDelimiter + extents.Bottom.ToString();
        }
    }
}
