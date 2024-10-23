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
using System.Linq;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.PenWave
{
    public class PenInk
    {
        public List<Color> Colors { get; private set; }
        public List<float> Sizes { get; private set; }
        public List<PWEngine.BrushType> BrushTypes { get; private set; }

        private Color mCurrentColor;
        private float mCurrentSize;
        private PWEngine.BrushType mCurrentBrushType;

        private List<Color> InitializeDefaultColors()
        {
            return new List<Color>
            {
                new Color("#F7B32C"),
                new Color("#FD5703"),
                new Color("#DA1727"),
                new Color("#FF00A8"),
                new Color("#74BFB8"),
                new Color("#4087C5"),
                new Color("#070044"),
                new Color("#0E0E0E"),
            };
        }

        private List<float> InitializeDefaultSizes()
        {
            return new List<float> { 3.0f, 6.5f, 12.0f };
        }

        private List<PWEngine.BrushType> InitializeDefaultBrushTypes()
        {
            List<PWEngine.BrushType> brushTypes = new List<PWEngine.BrushType>();
            foreach (PWEngine.BrushType item in Enum.GetValues(typeof(PWEngine.BrushType)))
            {
                brushTypes.Add(item);
            }
            return brushTypes;
        }

        public PenInk()
        {
            Colors = InitializeDefaultColors();
            Sizes = InitializeDefaultSizes();
            BrushTypes = InitializeDefaultBrushTypes();
            mCurrentColor = Colors.First();
            mCurrentSize = Sizes.First();
            mCurrentBrushType = BrushTypes.First();
        }

        public PenInk(List<Color> colors, List<float> sizes, List<PWEngine.BrushType> brushTypes)
        {
            Colors = colors;
            Sizes = sizes;
            BrushTypes = BrushTypes;

            mCurrentColor = Colors.First();
            mCurrentSize = Sizes.First();
            mCurrentBrushType = BrushTypes.First();
        }

        public void SetCurrentColor(Color color)
        {
            mCurrentColor = color;
        }

        public void SetCurrentSize(float size)
        {
            mCurrentSize = size;
        }

        public void SetCurrentBrushType(PWEngine.BrushType brushType)
        {
            mCurrentBrushType = brushType;
        }

        public Color GetCurrentColor() => mCurrentColor;
        public float GetCurrentSize() => mCurrentSize;
        public PWEngine.BrushType GetCurrentBrushType() => mCurrentBrushType;

    }
}