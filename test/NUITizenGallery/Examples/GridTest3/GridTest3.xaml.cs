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
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    public partial class GridTest3Page : ContentPage
    {
        public GridTest3Page()
        {
            InitializeComponent();
            var btnStyle = new ButtonStyle();
            var btnStyle1 = new ButtonStyle();
            var btnStyle2 = new ButtonStyle();
            var btnStyle3 = new ButtonStyle();
            btnStyle.BackgroundColor = new Selector<Tizen.NUI.Color>
            {
                Normal = Tizen.NUI.Color.Blue,
                Pressed = Tizen.NUI.Color.DarkBlue,
            };
            btnStyle1.BackgroundColor = new Selector<Tizen.NUI.Color>
            {
                Normal = Tizen.NUI.Color.Red,
                Pressed = Tizen.NUI.Color.DarkRed,
            };
            btnStyle2.BackgroundColor = new Selector<Tizen.NUI.Color>
            {
                Normal = Tizen.NUI.Color.LightSeaGreen,
                Pressed = Tizen.NUI.Color.SeaGreen,
            };
            btnStyle3.BackgroundColor = new Selector<Tizen.NUI.Color>
            {
                Normal = Tizen.NUI.Color.Yellow,
                Pressed = Tizen.NUI.Color.Orange,
            };

            btnClear.ApplyStyle(btnStyle);
            btnUp.ApplyStyle(btnStyle);
            btnProc.ApplyStyle(btnStyle);
            btnDiv.ApplyStyle(btnStyle);
            btnMultiply.ApplyStyle(btnStyle);
            btnMinus.ApplyStyle(btnStyle);
            btnPlus.ApplyStyle(btnStyle);
            btnDot.ApplyStyle(btnStyle3);
            btnEqual.ApplyStyle(btnStyle1);
            btn0.ApplyStyle(btnStyle2);
            btn1.ApplyStyle(btnStyle2);
            btn2.ApplyStyle(btnStyle2);
            btn3.ApplyStyle(btnStyle2);
            btn4.ApplyStyle(btnStyle2);
            btn5.ApplyStyle(btnStyle2);
            btn6.ApplyStyle(btnStyle2);
            btn7.ApplyStyle(btnStyle2);
            btn8.ApplyStyle(btnStyle2);
            btn9.ApplyStyle(btnStyle2);
        }
        protected override void Dispose(DisposeTypes type)
        {
            if (Disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                RemoveAllChildren(true);
            }

            base.Dispose(type);
        }

        private void RemoveAllChildren(bool dispose = false)
        {
            RecursiveRemoveChildren(this, dispose);
        }

        private void RecursiveRemoveChildren(View parent, bool dispose)
        {
            if (parent == null)
            {
                return;
            }

            int maxChild = (int)parent.ChildCount;
            for (int i = maxChild - 1; i >= 0; --i)
            {
                View child = parent.GetChildAt((uint)i);
                if (child == null)
                {
                    continue;
                }

                RecursiveRemoveChildren(child, dispose);
                parent.Remove(child);
                if (dispose)
                {
                    child.Dispose();
                }
            }
        }
    }
}

