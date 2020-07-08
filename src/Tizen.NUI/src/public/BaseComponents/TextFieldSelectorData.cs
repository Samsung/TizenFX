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
    internal class TextFieldSelectorData : TextLabelSelectorData
    {
        public TriggerableSelector<string> TranslatablePlaceholderText { get; } = new TriggerableSelector<string>(TextField.TranslatablePlaceholderTextProperty);
        public TriggerableSelector<Vector4> PlaceholderTextColor { get; } = new TriggerableSelector<Vector4>(TextField.PlaceholderTextColorProperty, delegate (View view)
        {
            Vector4 color = new Vector4();
            if (view.GetProperty(TextField.Property.PLACEHOLDER_TEXT_COLOR).Get(color))
            {
                return color;
            }
            return null;
        });

        public TriggerableSelector<Vector4> PrimaryCursorColor { get; } = new TriggerableSelector<Vector4>(TextField.PrimaryCursorColorProperty, delegate (View view)
        {
            Vector4 color = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            if (view.GetProperty(TextField.Property.PRIMARY_CURSOR_COLOR).Get(color))
            {
                return color;
            }
            return null;
        });

        public override void Reset(View view)
        {
            TranslatablePlaceholderText.Reset(view);
            PlaceholderTextColor.Reset(view);
            PrimaryCursorColor.Reset(view);

            base.Reset(view);
        }
    }
}
