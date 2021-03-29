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
    /// The class storing extra data for a TextField to optimize size of it.
    /// </summary>
    internal class TextFieldSelectorData
    {
        public TriggerableSelector<string> TranslatableText { get; private set; }
        public TriggerableSelector<string> Text { get; private set; }
        public TriggerableSelector<string> FontFamily { get; private set; }
        public TriggerableSelector<Color> TextColor { get; private set; }
        public TriggerableSelector<float?> PointSize { get; private set; }
        public TriggerableSelector<float?> PixelSize { get; private set; }
        public TriggerableSelector<string> TranslatablePlaceholderText { get; private set; }
        public TriggerableSelector<string> TranslatablePlaceholderTextFocused { get; private set; }
        public TriggerableSelector<Vector4> PlaceholderTextColor { get; private set; }
        public TriggerableSelector<Vector4> PrimaryCursorColor { get; private set; }

        public TriggerableSelector<string> EnsureTranslatableText() => TranslatableText ?? (TranslatableText = new TriggerableSelector<string>(TextField.TranslatableTextProperty));
        public TriggerableSelector<string> EnsureText() => Text ?? (Text = new TriggerableSelector<string>(TextField.TextProperty));
        public TriggerableSelector<string> EnsureFontFamily() => FontFamily ?? (FontFamily = new TriggerableSelector<string>(TextField.FontFamilyProperty));
        public TriggerableSelector<Color> EnsureTextColor() => TextColor ?? (TextColor = new TriggerableSelector<Color>(TextField.TextColorProperty));
        public TriggerableSelector<float?> EnsurePointSize() => PointSize ?? (PointSize = new TriggerableSelector<float?>(TextField.PointSizeProperty));
        public TriggerableSelector<float?> EnsurePixelSize() => PixelSize ?? (PixelSize = new TriggerableSelector<float?>(TextField.PixelSizeProperty));
        public TriggerableSelector<string> EnsureTranslatablePlaceholderText() => TranslatablePlaceholderText ?? (TranslatablePlaceholderText = new TriggerableSelector<string>(TextField.TranslatablePlaceholderTextProperty));
        public TriggerableSelector<string> EnsureTranslatablePlaceholderTextFocused() => TranslatablePlaceholderTextFocused ?? (TranslatablePlaceholderTextFocused = new TriggerableSelector<string>(TextField.TranslatablePlaceholderTextFocusedProperty));
        public TriggerableSelector<Vector4> EnsurePlaceholderTextColor() =>  PlaceholderTextColor ?? (PlaceholderTextColor = new TriggerableSelector<Vector4>(TextField.PlaceholderTextColorProperty));
        public TriggerableSelector<Vector4> EnsurePrimaryCursorColor() => PrimaryCursorColor ?? (PrimaryCursorColor = new TriggerableSelector<Vector4>(TextField.PrimaryCursorColorProperty));

        public void Reset(View view)
        {
            TranslatableText?.Reset(view);
            Text?.Reset(view);
            FontFamily?.Reset(view);
            TextColor?.Reset(view);
            PointSize?.Reset(view);
            PixelSize?.Reset(view);
            TranslatablePlaceholderText?.Reset(view);
            TranslatablePlaceholderTextFocused?.Reset(view);
            PlaceholderTextColor?.Reset(view);
            PrimaryCursorColor?.Reset(view);
        }
    }
}
