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
    public class ColorIcon : View
    {
        private string mColorHex;
        private Color mColor;
        private ImageView mImgView;
        private ImageView mBorder;

        private static string ImageResourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/";

        public ColorIcon(string colorHex)
        {
            Layout = new LinearLayout()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };

            mColorHex = colorHex;
            mColor = new Tizen.NUI.Color(colorHex);

            string url = string.Format("{0}{1}/color_icon_base.png", ImageResourcePath, "light");

             //Additional components settings
            mImgView = new ImageView();
            mImgView.Size2D = new Size2D(48, 48);
            mImgView.Color = mColor;

            mImgView.ResourceUrl = url;
            this.Add(mImgView);

            mBorder = new ImageView();
            mBorder.Size2D = new Size2D(48, 48);
            mImgView.Add(mBorder);
        }

        public void OnStateChanged()
        {
            mBorder.ResourceUrl = string.Empty;
            // mBorder.ResourceUrl = string.Format("{0}{1}/color_icon_selected.png", ImageResourcePath, "light");
            // mBorder.ResourceUrl = string.Format("{0}{1}/color_icon_selected.png", ImageResourcePath, "light");

        }

        public string GetColorHex()
        {
            return mColorHex;
        }
    }
}