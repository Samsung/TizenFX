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

namespace Tizen.NUI.Binding
{
    [TypeConverter(typeof(FlowDirectionConverter))]
    internal enum FlowDirection
    {
        MatchParent = 0,
        LeftToRight = 1,
        RightToLeft = 2,
    }

    [Xaml.TypeConversion(typeof(FlowDirection))]
    internal class FlowDirectionConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            if (value != null)
            {
                if (Enum.TryParse(value, out FlowDirection direction))
                    return direction;

                if (value.Equals("ltr", StringComparison.OrdinalIgnoreCase))
                    return FlowDirection.LeftToRight;
                if (value.Equals("rtl", StringComparison.OrdinalIgnoreCase))
                    return FlowDirection.RightToLeft;
                if (value.Equals("inherit", StringComparison.OrdinalIgnoreCase))
                    return FlowDirection.MatchParent;
            }
            throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" into {1}", value, typeof(FlowDirection)));
        }
    }
}
