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
using Tizen.NUI.BaseComponents;
using Tizen.NUI.UIComponents;

namespace Tizen.NUI.Examples
{
    public class AmbientMultiPage3 : ContentPage
    {

        public AmbientMultiPage3(Window win) : base (win)
        {
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

            base.Dispose(type);
        }

        public override void SetFocus()
        {
            Console.WriteLine("AmbientMulti3Page focused.");
            Animation animation = new Animation(2000);
            animation.AnimateTo(Root, "Opacity", 1.0f);
            animation.Finished += (obj, e) => {Console.WriteLine("animation finished.");};
            animation.Play();
        }
    }
}