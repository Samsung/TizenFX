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

using global::System;
using global::System.Runtime.InteropServices;
using global::System.Runtime.InteropServices.Marshalling;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class Renderer
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_Range_BACKGROUND_EFFECT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int RangesBackgroundEffectGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_Range_BACKGROUND_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int RangesBackgroundGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_Range_CONTENT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int RangesContentGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_Range_DECORATION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int RangesDecorationGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_Range_FOREGROUND_EFFECT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int RangesForegroundEffectGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_Property_DEPTH_INDEX_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int DepthIndexGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_Property_FACE_CULLING_MODE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int FaceCullingModeGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_Property_BLEND_MODE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int BlendModeGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_Property_BLEND_EQUATION_RGB_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int BlendEquationRgbGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_Property_BLEND_EQUATION_ALPHA_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int BlendEquationAlphaGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_Property_BLEND_FACTOR_SRC_RGB_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int BlendFactorSrcRgbGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_Property_BLEND_FACTOR_DEST_RGB_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int BlendFactorDestRgbGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_Property_BLEND_FACTOR_SRC_ALPHA_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int BlendFactorSrcAlphaGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_Property_BLEND_FACTOR_DEST_ALPHA_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int BlendFactorDestAlphaGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_Property_BLEND_COLOR_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int BlendColorGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_Property_BLEND_PRE_MULTIPLIED_ALPHA_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int BlendPreMultipliedAlphaGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_Property_INDEX_RANGE_FIRST_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int IndexRangeFirstGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_Property_INDEX_RANGE_COUNT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int IndexRangeCountGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_Property_DEPTH_WRITE_MODE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int DepthWriteModeGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_Property_DEPTH_FUNCTION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int DepthFunctionGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_Property_DEPTH_TEST_MODE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int DepthTestModeGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_Property_RENDER_MODE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int RenderModeGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_Property_STENCIL_FUNCTION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int StencilFunctionGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_Property_STENCIL_FUNCTION_MASK_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int StencilFunctionMaskGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_Property_STENCIL_FUNCTION_REFERENCE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int StencilFunctionReferenceGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_Property_STENCIL_MASK_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int StencilMaskGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_Property_STENCIL_OPERATION_ON_FAIL_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int StencilOperationOnFailGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_Property_STENCIL_OPERATION_ON_Z_FAIL_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int StencilOperationOnZFailGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_Property_STENCIL_OPERATION_ON_Z_PASS_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int StencilOperationOnZPassGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_Property_MIX_COLOR_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int MixColorGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_Property_MIX_COLOR_RED_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int MixColorRedGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_Property_MIX_COLOR_GREEN_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int MixColorGreenGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_Property_MIX_COLOR_BLUE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int MixColorBlueGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_Property_OPACITY_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int MixColorOpacityGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_Property_RENDERING_BEHAVIOR_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int RenderingBehaviorGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_Property_BLEND_EQUATION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int BlendEquationGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_Property_INSTANCE_COUNT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InstanceCountGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_Property_UPDATE_AREA_EXTENTS_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int UpdateAreaExtentsGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_NewWithoutGeometryAndShader", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Renderer", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteRenderer(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_SetGeometry", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetGeometry(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_SetIndexRange", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetIndexRange(IntPtr jarg1, int jarg2, int jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_SetTextures", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetTextures(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_GetTextures", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetTextures(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Renderer_SetShader", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetShader(IntPtr jarg1, IntPtr jarg2);
        }
    }
}





