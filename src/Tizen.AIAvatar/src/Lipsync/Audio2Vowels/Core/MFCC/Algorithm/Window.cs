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
using System.Linq;

namespace Tizen.AIAvatar
{
    internal class Window
    {
        private float[] _window;

        public Window(int size)
        {
            _window = Hamming(size);
        }

        public void Apply(float[] block)
        {
            if (block.Length < _window.Length) return;

            for (int i = 0; i < _window.Length; i++)
            {
                block[i] *= _window[i];
            }
        }

        public static float[] Hamming(int length)
        {
            var n = 2 * Math.PI / (length - 1);
            return Enumerable.Range(0, length)
                             .Select(i => 0.54f - 0.46f * Math.Cos(i * n))
                             .Select(v => (float)v)
                             .ToArray();
        }
    }
}