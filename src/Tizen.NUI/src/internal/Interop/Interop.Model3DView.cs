using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class Model3DView
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Model3dView_Property_GEOMETRY_URL_get")]
            public static extern int GeometryUrlGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Model3dView_Property_MATERIAL_URL_get")]
            public static extern int MaterialUrlGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Model3dView_Property_IMAGES_URL_get")]
            public static extern int ImagesUrlGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Model3dView_Property_ILLUMINATION_TYPE_get")]
            public static extern int IlluminationTypeGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Model3dView_Property_TEXTURE0_URL_get")]
            public static extern int Texture0UrlGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Model3dView_Property_TEXTURE1_URL_get")]
            public static extern int Texture1UrlGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Model3dView_Property_TEXTURE2_URL_get")]
            public static extern int Texture2UrlGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Model3dView_Property_LIGHT_POSITION_get")]
            public static extern int LightPositionGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Model3dView_Property")]
            public static extern global::System.IntPtr NewModel3dViewProperty();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Model3dView_Property")]
            public static extern void DeleteModel3dViewProperty(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Model3dView_New__SWIG_0")]
            public static extern global::System.IntPtr Model3dViewNew();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Model3dView_New__SWIG_1")]
            public static extern global::System.IntPtr Model3dViewNew(string jarg1, string jarg2, string jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Model3dView__SWIG_0")]
            public static extern global::System.IntPtr NewModel3dView();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Model3dView")]
            public static extern void DeleteModel3dView(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Model3dView__SWIG_1")]
            public static extern global::System.IntPtr NewModel3dView(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Model3dView_Assign")]
            public static extern global::System.IntPtr Model3dViewAssign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Model3dView_DownCast")]
            public static extern global::System.IntPtr Model3dViewDownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Model3dView_SWIGUpcast")]
            public static extern global::System.IntPtr Model3dViewUpcast(global::System.IntPtr jarg1);
        }
    }
}
