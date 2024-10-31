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
    public abstract class Icon : View
    {
        public event Action IconSelected;

        protected ImageView mImgView;
        protected ImageView mBorder;

        private int mDefaultSize = 48;

        public Icon()
        {
            Layout = new LinearLayout()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            this.Size2D = new Size2D(mDefaultSize, mDefaultSize);

            this.TouchEvent += IconClick;
        }

        protected void InitializeIcon(string baseResourceUrl, Color color)
        {
            mImgView = new ImageView
            {
                Size2D = new Size2D(mDefaultSize, mDefaultSize),
                Color = color,
                ResourceUrl = baseResourceUrl
            };
            this.Add(mImgView);

            mBorder = new ImageView
            {
                Size2D = new Size2D(mDefaultSize, mDefaultSize),
            };
        }


        public virtual void OnStateChanged()
        {
            mBorder.ResourceUrl = $"{FrameworkInformation.ResourcePath}images/light/color_icon_selected.png";
        }

        public virtual bool IconClick(object sender, View.TouchEventArgs args)
        {
            if (args.Touch.GetState(0) == PointStateType.Down)
            {
                IconSelected?.Invoke();
                return true;
            }
            return false;
        }
    }
}


