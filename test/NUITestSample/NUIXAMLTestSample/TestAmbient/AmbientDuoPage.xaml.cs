/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.Examples
{
    public partial class AmbientDuoPage : ContentPage
    {

        public AmbientDuoPage(Window win) : base (win)
        {
            InitializeComponent();
            Root.BackgroundImage = "/home/owner/apps_rw/org.tizen.example.NUIXAMLTestSample/res/images/ambient/photoduo_img_bg_01_no9patch.png";
            ClearEvent += OnClearEvent;
            Root.Opacity = 0.0f;
        }

        /// <summary>
        /// To make the ContentPage instance be disposed.
        /// </summary>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
            }

            ClearEvent -= OnClearEvent;

            base.Dispose(type);
        }

        public override void SetFocus()
        {
            Console.WriteLine("AmbientDuoPage focused.");
            Animation animation = new Animation(2000);
            animation.AnimateTo(Root, "Opacity", 1.0f);
            animation.Play();
        }

        private void OnClearEvent(object obj, EventArgs e)
        {
            Root.BackgroundImage = "/home/owner/apps_rw/org.tizen.example.NUIXAMLTestSample/res/images/ambient/photoduo_img_bg_01_no9patch.png";
        }
    }
}