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
        public TriggerableSelector<string> TranslatableText { get; private set; }
        public TriggerableSelector<string> Text { get; private set; }
        public TriggerableSelector<string> FontFamily { get; private set; }
        public TriggerableSelector<Color> TextColor { get; private set; }
        public TriggerableSelector<float?> PointSize { get; private set; }
        public TriggerableSelector<float?> PixelSize { get; private set; }
        public TriggerableSelector<TextShadow> TextShadow { get; private set; }

        public TriggerableSelector<string> EnsureTranslatableText() => TranslatableText ?? (TranslatableText = new TriggerableSelector<string>(TextLabel.TranslatableTextProperty));
        public TriggerableSelector<string> EnsureText() => Text ?? (Text = new TriggerableSelector<string>(TextLabel.TextProperty));
        public TriggerableSelector<string> EnsureFontFamily() => FontFamily ?? (FontFamily = new TriggerableSelector<string>(TextLabel.FontFamilyProperty));
        public TriggerableSelector<Color> EnsureTextColor() => TextColor ?? (TextColor = new TriggerableSelector<Color>(TextLabel.TextColorProperty));
        public TriggerableSelector<float?> EnsurePointSize() => PointSize ?? (PointSize = new TriggerableSelector<float?>(TextLabel.PointSizeProperty));
        public TriggerableSelector<float?> EnsurePixelSize() => PixelSize ?? (PixelSize = new TriggerableSelector<float?>(TextLabel.PixelSizeProperty));
        public TriggerableSelector<TextShadow> EnsureTextShadow() => TextShadow ?? (TextShadow = new TriggerableSelector<TextShadow>(TextLabel.TextShadowProperty));

        public virtual void Reset(View view)
        {
            TranslatableText?.Reset(view);
            Text?.Reset(view);
            FontFamily?.Reset(view);
            TextColor?.Reset(view);
            PointSize?.Reset(view);
            PixelSize?.Reset(view);
            TextShadow?.Reset(view);
        }
    }
}
