using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class ImageView
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_Property_IMAGE_get")]
            public static extern int ImageGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_Property_PRE_MULTIPLIED_ALPHA_get")]
            public static extern int PreMultipliedAlphaGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_Property_PIXEL_AREA_get")]
            public static extern int PixelAreaGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ImageView_Property")]
            public static extern global::System.IntPtr NewImageViewProperty();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ImageView_Property")]
            public static extern void DeleteImageViewProperty(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ImageView__SWIG_0")]
            public static extern global::System.IntPtr NewImageView();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_New__SWIG_0")]
            public static extern global::System.IntPtr New();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_New__SWIG_1")]
            public static extern global::System.IntPtr New(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_New__SWIG_2")]
            public static extern global::System.IntPtr New(string jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_New__SWIG_3")]
            public static extern global::System.IntPtr New(string jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ImageView")]
            public static extern void DeleteImageView(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ImageView__SWIG_1")]
            public static extern global::System.IntPtr NewImageView(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_Assign")]
            public static extern global::System.IntPtr Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_DownCast")]
            public static extern global::System.IntPtr DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_SetImage__SWIG_0")]
            public static extern void SetImage(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_SetImage__SWIG_1")]
            public static extern void SetImage(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_SetImage__SWIG_2")]
            public static extern void SetImage(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_GetImage")]
            public static extern global::System.IntPtr GetImage(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_SWIGUpcast")]
            public static extern global::System.IntPtr Upcast(global::System.IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ImageView_IMAGE_VISUAL_ACTION_RELOAD_get")]
            public static extern int ImageVisualActionReloadGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ImageView_IMAGE_VISUAL_ACTION_PLAY_get")]
            public static extern int ImageVisualActionPlayGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ImageView_IMAGE_VISUAL_ACTION_PAUSE_get")]
            public static extern int ImageVisualActionPauseGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ImageView_IMAGE_VISUAL_ACTION_STOP_get")]
            public static extern int ImageVisualActionStopGet();


            [Obsolete("Please do not use this! Deprecated in API9, will be removed in API11! Please use ImageView.New(...) instead!")]
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_New__SWIG_0")]
            public static extern global::System.IntPtr ImageView_New__SWIG_0();

            [Obsolete("Please do not use this! Deprecated in API9, will be removed in API11! Please use ImageView.New(...) instead!")]
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_New__SWIG_2")]
            public static extern global::System.IntPtr ImageView_New__SWIG_2(string jarg1);

            [Obsolete("Please do not use this! Deprecated in API9, will be removed in API11! Please use ImageView.New(...) instead!")]
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_New__SWIG_3")]
            public static extern global::System.IntPtr ImageView_New__SWIG_3(string jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [Obsolete("Please do not use this! Deprecated in API9, will be removed in API11! Please use ImageView.Upcast(...) instead!")]
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_SWIGUpcast")]
            public static extern global::System.IntPtr ImageView_SWIGUpcast(global::System.IntPtr jarg1);

            [Obsolete("Please do not use this! Deprecated in API9, will be removed in API11! Please use ImageView.SetImage(...) instead!")]
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_SetImage__SWIG_1")]
            public static extern void ImageView_SetImage__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

            [Obsolete("Please do not use this! Deprecated in API9, will be removed in API11! Please use ImageView.SetImage(...) instead!")]
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_SetImage__SWIG_2")]
            public static extern void ImageView_SetImage__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [Obsolete("Please do not use this! Deprecated in API9, will be removed in API11! Please use ImageView.DeleteImageView(...) instead!")]
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ImageView")]
            public static extern void delete_ImageView(global::System.Runtime.InteropServices.HandleRef jarg1);

            [Obsolete("Please do not use this! Deprecated in API9, will be removed in API11! Please use ImageView.ImageGet(...) instead!")]
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_Property_IMAGE_get")]
            public static extern int ImageView_Property_IMAGE_get();

            [Obsolete("Please do not use this! Deprecated in API9, will be removed in API11! Please use ImageView.PreMultipliedAlphaGet(...) instead!")]
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_Property_PRE_MULTIPLIED_ALPHA_get")]
            public static extern int ImageView_Property_PRE_MULTIPLIED_ALPHA_get();

            [Obsolete("Please do not use this! Deprecated in API9, will be removed in API11! Please use ImageView.PixelAreaGet(...) instead!")]
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_Property_PIXEL_AREA_get")]
            public static extern int ImageView_Property_PIXEL_AREA_get();

            [Obsolete("Please do not use this! Deprecated in API9, will be removed in API11! Please use ImageView.ImageVisualActionReloadGet(...) instead!")]
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ImageView_IMAGE_VISUAL_ACTION_RELOAD_get")]
            public static extern int ImageView_IMAGE_VISUAL_ACTION_RELOAD_get();

            [Obsolete("Please do not use this! Deprecated in API9, will be removed in API11! Please use ImageView.ImageVisualActionPlayGet(...) instead!")]
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ImageView_IMAGE_VISUAL_ACTION_PLAY_get")]
            public static extern int ImageView_IMAGE_VISUAL_ACTION_PLAY_get();

            [Obsolete("Please do not use this! Deprecated in API9, will be removed in API11! Please use ImageView.ImageVisualActionPauseGet(...) instead!")]
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ImageView_IMAGE_VISUAL_ACTION_PAUSE_get")]
            public static extern int ImageView_IMAGE_VISUAL_ACTION_PAUSE_get();

            [Obsolete("Please do not use this! Deprecated in API9, will be removed in API11! Please use ImageView.ImageVisualActionStopGet(...) instead!")]
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ImageView_IMAGE_VISUAL_ACTION_STOP_get")]
            public static extern int ImageView_IMAGE_VISUAL_ACTION_STOP_get();
        }
    }
}
