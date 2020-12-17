using System;
using System.Collections.Generic;
using System.Text;

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
