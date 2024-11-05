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
        public event Action<object> IconSelected;

        protected ImageView defaultImage;
        protected ImageView selectedImage;

        private int mDefaultSize = 48;
        private bool isSelected;

        public bool Selected
        {
            get => isSelected;
            set
            {
                isSelected = value;
                UpdateIconState();
            }
        }

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

        protected void InitializeIcon(Color color)
        {
            defaultImage = new ImageView
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                Color = color,
                ResourceUrl = GetDefaultImageUrl()
            };
            this.Add(defaultImage);

            selectedImage = new ImageView
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                ResourceUrl = GetSelectedImageUrl()
            };
            defaultImage.Add(selectedImage);
            selectedImage.Hide();
        }


        public virtual void UpdateIconState()
        {
            Tizen.Log.Error("NUI", $"UpdateIconState!!!!!!!!!!!!!!!!!!!!!!!!!!!\n");
            if(isSelected) selectedImage.Show();
            else selectedImage.Hide();
        }

        public virtual bool IconClick(object sender, View.TouchEventArgs args)
        {
            if (args.Touch.GetState(0) == PointStateType.Down)
            {
                IconSelected?.Invoke(sender);
                return true;
            }
            return false;
        }

        protected abstract string GetDefaultImageUrl();
        protected abstract string GetSelectedImageUrl();
    }
}


