/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    public partial struct UIColor
    {
        /// <summary>
        /// The default color. (This is to distinguish from transparent)
        /// </summary>
        public static readonly UIColor Default = new (-1, -1, -1, -1);

        /// <summary>
        /// The transparent color.
        /// </summary>
        public static readonly UIColor Transparent = new (0, 0, 0, 0);

        /// <summary>
        /// The transparent color.
        /// </summary>
        public static readonly UIColor Black = new (0, 0, 0, 1);

        /// <summary>
        /// The white color.
        /// </summary>
        public static readonly UIColor White = new (1, 1, 1, 1);

        /// <summary>
        /// The gray color.
        /// </summary>
        public static readonly UIColor Gray = new (0.5f, 0.5f, 0.5f, 1);

        /// <summary>
        /// The red color.
        /// </summary>
        public static readonly UIColor Red = new (1, 0, 0, 1);

        /// <summary>
        /// The green color.
        /// </summary>
        public static readonly UIColor Green = new (0, 1, 0, 1);

        /// <summary>
        /// The blue color.
        /// </summary>
        public static readonly UIColor Blue = new (0, 0, 1, 1);

        /// <summary>
        /// The yellow color.
        /// </summary>
        public static readonly UIColor Yellow = new (1, 1, 0, 1);

        /// <summary>
        /// The cyan color.
        /// </summary>
        public static readonly UIColor Cyan = new (0, 1, 1, 1);

        /// <summary>
        /// The magenta color.
        /// </summary>
        public static readonly UIColor Magenta = new (1, 0, 1, 1);
    }
}
