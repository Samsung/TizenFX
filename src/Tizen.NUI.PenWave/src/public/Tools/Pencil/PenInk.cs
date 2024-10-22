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

using System;
using System.ComponentModel;
using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.PenWave
{
    public class PenInk
    {
        private List<Color> mAvailableColors;
        private List<float> mAvailableSizes;
        private List<PWEngine.BrushType> mBrushTypes;

        public PenInk(List<Color> colors, List<float> sizes)
        {
            List<PWEngine.BrushType> brushTypes = new List<PWEngine.BrushType>();
            foreach (PWEngine.BrushType item in Enum.GetValues(typeof(PWEngine.BrushType)))
            {
                brushTypes.Add(item);
            }
            InitialPenInk(colors, sizes, brushTypes);
        }

        public PenInk(List<Color> colors, List<float> sizes, List<PWEngine.BrushType> brushTypes)
        {
            InitialPenInk(colors, sizes, brushTypes);
        }

        private void InitialPenInk(List<Color> colors, List<float> sizes, List<PWEngine.BrushType> brushTypes)
        {
            mAvailableColors = colors;
            mAvailableSizes = sizes;
            mBrushTypes = brushTypes;
        }

        public List<Color> GetColors()
        {
            return mAvailableColors;
        }

        public List<float> GetSizes()
        {
            return mAvailableSizes;
        }

        public List<PWEngine.BrushType> GetBrushTypes()
        {
            return mBrushTypes;
        }
    }
}