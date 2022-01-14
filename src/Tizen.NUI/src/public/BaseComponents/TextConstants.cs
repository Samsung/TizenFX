// Copyright (c) 2021 Samsung Electronics Co., Ltd.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Tizen.NUI.Text
{
    /// <summary>
    /// A struct to pass data of TextFit PropertyMap. <br />
    /// </summary>
    /// <remarks>
    /// The TextFit struct is used as an argument to SetTextFit and GetTextFit methods. <br />
    /// See <see cref="Tizen.NUI.BaseComponents.TextLabel.SetTextFit"/> and <see cref="Tizen.NUI.BaseComponents.TextLabel.GetTextFit"/>. <br />
    /// </remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct TextFit
    {
        /// <summary>
        /// True to enable the text fit or false to disable (the default value is false).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Enable { get; set; }

        /// <summary>
        /// Minimum Size for text fit (if null, the default value is 10.0f).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? MinSize { get; set; }

        /// <summary>
        /// Maximum Size for text fit (if null, the default value is 100.0f).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? MaxSize { get; set; }

        /// <summary>
        /// Step Size for font increase (if null, the default value is 1.0f).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? StepSize { get; set; }

        /// <summary>
        /// The size type of font, PointSize or PixelSize (the default value is PointSize).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FontSizeType FontSizeType { get; set; }

        /// <summary>
        /// Font Size for text fit
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? FontSize { get; set; }
    }
}