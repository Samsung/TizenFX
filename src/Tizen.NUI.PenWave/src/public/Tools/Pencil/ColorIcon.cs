/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
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
using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.PenWave
{
    public class ColorIcon : Icon
    {
        private readonly string mColorHex;
        private readonly Color mColor;

        public ColorIcon(Tizen.NUI.Color color) : base()
        {
            mColorHex = ToHex(color);
            mColor = color;

            string url = $"{FrameworkInformation.ResourcePath}images/light/color_icon_base.png";

            InitializeIcon(url, mColor);
            this.TouchEvent += IconClick;
        }

        public override bool IconClick(object sender, View.TouchEventArgs args)
        {
            if (base.IconClick(sender, args))
            {
                PWEngine.SetStrokeColor(GetColorHex(), 1.0f);
            }
            return true;
        }

        private string ToHex(Color color)
        {
            var red = (uint)(color.R * 255);
            var green = (uint)(color.G * 255);
            var blue = (uint)(color.B * 255);
            return $"#{red:X2}{green:X2}{blue:X2}";
        }

        public string GetColorHex() => mColorHex;
    }
}
