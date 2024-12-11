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

namespace Tizen.NUI
{
    /// <summary>
    /// Enumeration for instances of properties belonging to the Renderer class.
    /// </summary>
    internal class RendererProperty
    {
        internal static readonly int DepthIndex = Interop.Renderer.DepthIndexGet();
        internal static readonly int FaceCullingMode = Interop.Renderer.FaceCullingModeGet();
        internal static readonly int BlendMode = Interop.Renderer.BlendModeGet();
        internal static readonly int BlendEquationRgb = Interop.Renderer.BlendEquationRgbGet();
        internal static readonly int BlendEquationAlpha = Interop.Renderer.BlendEquationAlphaGet();
        internal static readonly int BlendFactorSrcRgb = Interop.Renderer.BlendFactorSrcRgbGet();
        internal static readonly int BlendFactorDestRgb = Interop.Renderer.BlendFactorDestRgbGet();
        internal static readonly int BlendFactorSrcAlpha = Interop.Renderer.BlendFactorSrcAlphaGet();
        internal static readonly int BlendFactorDestAlpha = Interop.Renderer.BlendFactorDestAlphaGet();
        internal static readonly int BlendColor = Interop.Renderer.BlendColorGet();
        internal static readonly int BlendPreMultipliedAlpha = Interop.Renderer.BlendPreMultipliedAlphaGet();
        internal static readonly int IndexRangeFirst = Interop.Renderer.IndexRangeFirstGet();
        internal static readonly int IndexRangeCount = Interop.Renderer.IndexRangeCountGet();
        internal static readonly int DepthWriteMode = Interop.Renderer.DepthWriteModeGet();
        internal static readonly int DepthFunction = Interop.Renderer.DepthFunctionGet();
        internal static readonly int DepthTestMode = Interop.Renderer.DepthTestModeGet();
        internal static readonly int RenderMode = Interop.Renderer.RenderModeGet();
        internal static readonly int StencilFunction = Interop.Renderer.StencilFunctionGet();
        internal static readonly int StencilFunctionMask = Interop.Renderer.StencilFunctionMaskGet();
        internal static readonly int StencilFunctionReference = Interop.Renderer.StencilFunctionReferenceGet();
        internal static readonly int StencilMask = Interop.Renderer.StencilMaskGet();
        internal static readonly int StencilOperationOnFail = Interop.Renderer.StencilOperationOnFailGet();
        internal static readonly int StencilOperationOnZFail = Interop.Renderer.StencilOperationOnZFailGet();
        internal static readonly int StencilOperationOnZPass = Interop.Renderer.StencilOperationOnZPassGet();
    }
}