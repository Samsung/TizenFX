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

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class NDalicMeshVisual
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_MESH_VISUAL_OBJECT_URL_get")]
            public static extern int MeshVisualObjectUrlGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_MESH_VISUAL_MATERIAL_URL_get")]
            public static extern int MeshVisualMaterialUrlGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_MESH_VISUAL_TEXTURES_PATH_get")]
            public static extern int MeshVisualTexturesPathGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_MESH_VISUAL_SHADING_MODE_get")]
            public static extern int MeshVisualShadingModeGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_MESH_VISUAL_USE_MIPMAPPING_get")]
            public static extern int MeshVisualUseMipmappingGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_MESH_VISUAL_USE_SOFT_NORMALS_get")]
            public static extern int MeshVisualUseSoftNormalsGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_MESH_VISUAL_LIGHT_POSITION_get")]
            public static extern int MeshVisualLightPositionGet();
        }
    }
}
