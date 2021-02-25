using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class NDalicVisual
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VISUAL_PROPERTY_TYPE_get")]
            public static extern int VisualPropertyTypeGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VISUAL_PROPERTY_SHADER_get")]
            public static extern int VisualPropertyShaderGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VISUAL_SHADER_VERTEX_get")]
            public static extern int VisualShaderVertexGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VISUAL_SHADER_FRAGMENT_get")]
            public static extern int VisualShaderFragmentGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VISUAL_SHADER_SUBDIVIDE_GRID_X_get")]
            public static extern int VisualShaderSubdivideGridXGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VISUAL_SHADER_SUBDIVIDE_GRID_Y_get")]
            public static extern int VisualShaderSubdivideGridYGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VISUAL_SHADER_HINTS_get")]
            public static extern int VisualShaderHintsGet();
        }
    }
}
