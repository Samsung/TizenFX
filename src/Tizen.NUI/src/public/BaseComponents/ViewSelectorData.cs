/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
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
    /// The class storing extra data for a View to optimize size of it.
    /// </summary>
    internal class ViewSelectorData
    {
        public TriggerableSelector<Color> BackgroundColor { get; } = new TriggerableSelector<Color>(View.BackgroundColorProperty, delegate (View view)
        {
            var background = view.Background;
            int visualType = 0;
            background.Find(Visual.Property.Type)?.Get(out visualType);

            if (visualType == (int)Visual.Type.Color)
            {
                Color backgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
                background.Find(ColorVisualProperty.MixColor)?.Get(backgroundColor);
                return backgroundColor;
            }
            return null;
        });
        public TriggerableSelector<string> BackgroundImage { get; } = new TriggerableSelector<string>(View.BackgroundImageProperty, delegate (View view)
        {
            string backgroundImage = null;
            view.Background.Find(ImageVisualProperty.URL)?.Get(out backgroundImage);
            return backgroundImage;
        });
        public TriggerableSelector<Rectangle> BackgroundImageBorder { get; } = new TriggerableSelector<Rectangle>(View.BackgroundImageBorderProperty);
        public TriggerableSelector<Color> Color { get; } = new TriggerableSelector<Color>(View.ColorProperty, delegate (View view)
        {
            Color color = new Color();
            if (view.GetProperty(Interop.ActorProperty.ColorGet()).Get(color))
            {
                return color;
            }
            return null;
        });
        public TriggerableSelector<float?> Opacity { get; } = new TriggerableSelector<float?>(View.OpacityProperty);
        public TriggerableSelector<ImageShadow> ImageShadow { get; } = new TriggerableSelector<ImageShadow>(View.ImageShadowProperty);
        public TriggerableSelector<Shadow> BoxShadow { get; } = new TriggerableSelector<Shadow>(View.BoxShadowProperty);

        public void Reset(View view)
        {
            BackgroundColor.Reset(view);
            BackgroundImage.Reset(view);
            BackgroundImageBorder.Reset(view);
            Color.Reset(view);
            Opacity.Reset(view);
            ImageShadow.Reset(view);
            BoxShadow.Reset(view);
        }
    }
}
