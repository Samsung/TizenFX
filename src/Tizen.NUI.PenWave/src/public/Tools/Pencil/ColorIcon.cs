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
        private string mColorHex;
        private Color mColor;
        private ImageView mImgView;
        private ImageView mBorder;

        public ColorIcon(Tizen.NUI.Color color) : base()
        {
            this.Size2D = new Size2D(48, 48);
            // mColorHex = colorHex;
            mColorHex = ToHex(color);
            mColor = color;

            string url = string.Format("{0}{1}/color_icon_base.png", FrameworkInformation.ResourcePath + "images/", "light");

             //Additional components settings
            mImgView = new ImageView();
            mImgView.Size2D = new Size2D(48, 48);
            mImgView.Color = mColor;

            mImgView.ResourceUrl = url;
            this.Add(mImgView);

            mBorder = new ImageView();
            mBorder.Size2D = new Size2D(48, 48);
            mImgView.Add(mBorder);

            this.TouchEvent += IconClick;
        }

        public override void OnStateChanged()
        {
            mBorder.ResourceUrl = string.Empty;
            // mBorder.ResourceUrl = string.Format("{0}{1}/color_icon_selected.png", FrameworkInformation.ResourcePath, "light");
            // mBorder.ResourceUrl = string.Format("{0}{1}/color_icon_selected.png", FrameworkInformation.ResourcePath, "light");

        }

        protected bool IconClick(object sender, View.TouchEventArgs args)
        {
            if (args.Touch.GetState(0) == PointStateType.Down)
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

        public string GetColorHex()
        {
            return mColorHex;
        }
    }
}