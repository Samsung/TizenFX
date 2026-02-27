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
        internal static partial class NDalicVisual
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VISUAL_PROPERTY_TYPE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int VisualPropertyTypeGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VISUAL_PROPERTY_SHADER_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int VisualPropertyShaderGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VISUAL_SHADER_VERTEX_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int VisualShaderVertexGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VISUAL_SHADER_FRAGMENT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int VisualShaderFragmentGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VISUAL_SHADER_SUBDIVIDE_GRID_X_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int VisualShaderSubdivideGridXGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VISUAL_SHADER_SUBDIVIDE_GRID_Y_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int VisualShaderSubdivideGridYGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VISUAL_SHADER_HINTS_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int VisualShaderHintsGet();
        }
    }
}





