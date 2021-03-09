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

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// The class storing extra selector properties of view that is rared used.
    /// </summary>
    internal class ViewSelectorData
    {
        internal ViewSelectorData() { }

        public TriggerableSelector<Color> BackgroundColor { get;  private set; }
        public TriggerableSelector<string> BackgroundImage { get;  private set; }
        public TriggerableSelector<Rectangle> BackgroundImageBorder { get;  private set; }
        public TriggerableSelector<Color> Color { get;  private set; }
        public TriggerableSelector<float?> Opacity { get;  private set; }
        public TriggerableSelector<ImageShadow> ImageShadow { get;  private set; }
        public TriggerableSelector<Shadow> BoxShadow { get;  private set; }

        public TriggerableSelector<Color> EnsureBackgroundColor() => BackgroundColor ?? (BackgroundColor = new TriggerableSelector<Color>(View.BackgroundColorProperty));
        public TriggerableSelector<string> EnsureBackgroundImage() => BackgroundImage ?? (BackgroundImage = new TriggerableSelector<string>(View.BackgroundImageProperty));
        public TriggerableSelector<Rectangle> EnsureBackgroundImageBorder() => BackgroundImageBorder ?? (BackgroundImageBorder = new TriggerableSelector<Rectangle>(View.BackgroundImageBorderProperty));      
        public TriggerableSelector<Color> EnsureColor() => Color ?? (Color = new TriggerableSelector<Color>(View.ColorProperty));
        public TriggerableSelector<float?> EnsureOpacity() => Opacity ?? (Opacity = new TriggerableSelector<float?>(View.OpacityProperty));
        public TriggerableSelector<ImageShadow> EnsureImageShadow() => ImageShadow ?? (ImageShadow = new TriggerableSelector<ImageShadow>(View.ImageShadowProperty));
        public TriggerableSelector<Shadow> EnsureBoxShadow() => BoxShadow ?? (BoxShadow = new TriggerableSelector<Shadow>(View.BoxShadowProperty));

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


