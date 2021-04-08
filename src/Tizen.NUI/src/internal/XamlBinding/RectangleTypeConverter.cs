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
using System.ComponentModel;
using System.Globalization;

using Tizen.NUI;

namespace Tizen.NUI.Binding
{
    //Internal used, will never open
    [Xaml.ProvideCompiled("Tizen.NUI.Xaml.Core.XamlC.RectangleTypeConverter")]
    [Xaml.TypeConversion(typeof(Rectangle))]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class RectangleTypeConverter : TypeConverter
    {
        //Internal used, will never open
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override object ConvertFromInvariantString(string value)
        {
            if (value != null)
            {
                double x, y, w, h;
                string[] xywh = value.Split(',');
                if (xywh.Length == 4 && double.TryParse(xywh[0], NumberStyles.Number, CultureInfo.InvariantCulture, out x) && double.TryParse(xywh[1], NumberStyles.Number, CultureInfo.InvariantCulture, out y) &&
                    double.TryParse(xywh[2], NumberStyles.Number, CultureInfo.InvariantCulture, out w) && double.TryParse(xywh[3], NumberStyles.Number, CultureInfo.InvariantCulture, out h))
                    return new Rectangle((int)x, (int)y, (int)w, (int)h);
            }

            throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" into {1}", value, typeof(Rectangle)));
        }

        //Internal used, will never open
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ConvertToString(object value)
        {
            Rectangle rect = value as Rectangle;
            if (null != rect)
            {
                return rect.X.ToString() + " " + rect.Y.ToString() + " " + rect.Width.ToString() + " " + rect.Height.ToString();
            }
            else
            {
                return null;
            }
        }
    }
}
