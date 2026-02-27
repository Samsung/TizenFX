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
        internal static partial class ImageView
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_Property_IMAGE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ImageGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_Property_PRE_MULTIPLIED_ALPHA_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int PreMultipliedAlphaGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_Property_PIXEL_AREA_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int PixelAreaGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_Property_PLACEHOLDER_IMAGE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int PlaceHolderImageGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_Property_TRANSITION_EFFECT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int TransitionEffectGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_Property_TRANSITION_EFFECT_OPTION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int TransitionEffectOptionGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_New__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_New__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New(string jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_New__SWIG_3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New(string jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ImageView", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteImageView(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_SetImage__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetImage(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_SetImage__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetImage(IntPtr jarg1, string jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ImageVisual_Actions_RELOAD_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ImageVisualActionReloadGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_New__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr ImageView_New__SWIG_0();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_New__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr ImageView_New__SWIG_2(string jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_New__SWIG_3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr ImageView_New__SWIG_3(string jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_SWIGUpcast", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr ImageView_SWIGUpcast(global::System.IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_SetImage__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ImageView_SetImage__SWIG_1(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_SetImage__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ImageView_SetImage__SWIG_2(IntPtr jarg1, string jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ImageView", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void delete_ImageView(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_Property_IMAGE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ImageView_Property_IMAGE_get();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_Property_PRE_MULTIPLIED_ALPHA_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ImageView_Property_PRE_MULTIPLIED_ALPHA_get();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ImageView_Property_PIXEL_AREA_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ImageView_Property_PIXEL_AREA_get();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ImageVisual_Actions_RELOAD_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ImageView_IMAGE_VISUAL_ACTION_RELOAD_get();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ImageVisual_Actions_PLAY_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ImageView_IMAGE_VISUAL_ACTION_PLAY_get();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ImageVisual_Actions_PAUSE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ImageView_IMAGE_VISUAL_ACTION_PAUSE_get();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ImageVisual_Actions_STOP_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ImageView_IMAGE_VISUAL_ACTION_STOP_get();
        }
    }
}





