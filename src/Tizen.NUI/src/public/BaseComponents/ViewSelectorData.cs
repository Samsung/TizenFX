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
using System.Diagnostics;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// The class storing extra selector properties of view that is rared used.
    /// </summary>
    internal class ViewSelectorData
    {
        internal ViewSelectorData() { }

        public TriggerableSelector<Color> BackgroundColor{ get; set; }
        public TriggerableSelector<string> BackgroundImage{ get; set; }
        public TriggerableSelector<Rectangle> BackgroundImageBorder{ get; set; }
        public TriggerableSelector<Color> Color{ get; set; }
        public TriggerableSelector<float?> Opacity{ get; set; }
        public TriggerableSelector<ImageShadow> ImageShadow{ get; set; }
        public TriggerableSelector<Shadow> BoxShadow{ get; set; }

        public void ClearBackground(View view)
        {
            BackgroundColor?.Reset(view);
            BackgroundImage?.Reset(view);
            BackgroundImageBorder?.Reset(view);
            BackgroundColor = null;
            BackgroundImage = null;
            BackgroundImageBorder = null;
        }
        public void ClearShadow(View view)
        {
            ImageShadow?.Reset(view);
            BoxShadow?.Reset(view);
            ImageShadow = null;
            BoxShadow = null;
        }

        public void Reset(View view)
        {
            BackgroundColor?.Reset(view);
            BackgroundImage?.Reset(view);
            BackgroundImageBorder?.Reset(view);
            Color?.Reset(view);
            Opacity?.Reset(view);
            ImageShadow?.Reset(view);
            BoxShadow?.Reset(view);
        }
    }
}


