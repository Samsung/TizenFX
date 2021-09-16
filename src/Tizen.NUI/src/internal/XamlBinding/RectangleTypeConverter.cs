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
                if (xywh.Length == 4)
                {
                    x = GraphicsTypeManager.Instance.ConvertScriptToPixel(xywh[0]);
                    y = GraphicsTypeManager.Instance.ConvertScriptToPixel(xywh[1]);
                    w = GraphicsTypeManager.Instance.ConvertScriptToPixel(xywh[2]);
                    h = GraphicsTypeManager.Instance.ConvertScriptToPixel(xywh[3]);
                    return new Rectangle((int)x, (int)y, (int)w, (int)h);
                }
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
