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
    /// The class storing extra data for a TextLabel to optimize size of it.
    /// </summary>
    internal class TextLabelSelectorData
    {
        public TriggerableSelector<string> TranslatableText { get; } = new TriggerableSelector<string>(TextLabel.TranslatableTextProperty);
        public TriggerableSelector<string> Text { get; } = new TriggerableSelector<string>(TextLabel.TextProperty);
        public TriggerableSelector<string> FontFamily { get; } = new TriggerableSelector<string>(TextLabel.FontFamilyProperty);
        public TriggerableSelector<Color> TextColor { get; } = new TriggerableSelector<Color>(TextLabel.TextColorProperty, GetTextColor);
        public TriggerableSelector<float?> PointSize { get; } = new TriggerableSelector<float?>(TextLabel.PointSizeProperty);
        public TriggerableSelector<TextShadow> TextShadow { get; } = new TriggerableSelector<TextShadow>(TextLabel.TextShadowProperty);

        public virtual void Reset(View view)
        {
            TranslatableText.Reset(view);
            Text.Reset(view);
            FontFamily.Reset(view);
            TextColor.Reset(view);
            PointSize.Reset(view);
            TextShadow.Reset(view);
        }

        private static Color GetTextColor(View view)
        {
            Color color = new Color();
            if (view.GetProperty(TextLabel.Property.TEXT_COLOR).Get(color))
            {
                return color;
            }
            return null;
        }
    }
}
