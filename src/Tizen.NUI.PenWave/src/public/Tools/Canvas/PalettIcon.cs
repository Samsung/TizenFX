/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
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

using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.PenWave
{
    public class PalettIcon : Icon
    {
        public PalettIcon() : base()
        {
            InitializeIcon(new Color("#17234d"));
        }

        protected override string GetDefaultImageUrl()
        {
            return $"{FrameworkInformation.ResourcePath}images/light/icon_color_palette.png";
        }

        protected override string GetSelectedImageUrl()
        {
            return $"{FrameworkInformation.ResourcePath}images/light/color_icon_selected.png";
        }

        public override bool IconClick(object sender, View.TouchEventArgs args)
        {
            if (base.IconClick(sender, args))
            {
                Tizen.Log.Info("NUI", $"PalettIcon\n");
            }
            return true;
        }

    }
}
