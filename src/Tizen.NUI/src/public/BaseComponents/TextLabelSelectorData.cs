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
    /// The class storing extra data for a TextLabel to optimize size of it.
    /// </summary>
    internal class TextLabelSelectorData
    {
        public TriggerableSelector<string> TranslatableText { get; set; }
        public TriggerableSelector<string> Text { get; set; }
        public TriggerableSelector<string> FontFamily { get; set; }
        public TriggerableSelector<Color> TextColor { get; set; }
        public TriggerableSelector<float?> PointSize { get; set; }
        public TriggerableSelector<float?> PixelSize { get; set; }
        public TriggerableSelector<TextShadow> TextShadow { get; set; }

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
