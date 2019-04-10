using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class NDalicMeshVisual
        {
            static NDalicMeshVisual()
            {
                Tizen.Log.Error("NUI", "NDalicMeshVisual");
            }


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_MESH_VISUAL_OBJECT_URL_get")]
            public static extern int MESH_VISUAL_OBJECT_URL_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_MESH_VISUAL_MATERIAL_URL_get")]
            public static extern int MESH_VISUAL_MATERIAL_URL_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_MESH_VISUAL_TEXTURES_PATH_get")]
            public static extern int MESH_VISUAL_TEXTURES_PATH_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_MESH_VISUAL_SHADING_MODE_get")]
            public static extern int MESH_VISUAL_SHADING_MODE_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_MESH_VISUAL_USE_MIPMAPPING_get")]
            public static extern int MESH_VISUAL_USE_MIPMAPPING_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_MESH_VISUAL_USE_SOFT_NORMALS_get")]
            public static extern int MESH_VISUAL_USE_SOFT_NORMALS_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_MESH_VISUAL_LIGHT_POSITION_get")]
            public static extern int MESH_VISUAL_LIGHT_POSITION_get();
        }
    }
}
