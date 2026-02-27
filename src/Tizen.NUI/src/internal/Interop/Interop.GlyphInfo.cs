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
        internal static partial class GlytphInfo
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_GlyphInfo__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewGlyphInfo();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_GlyphInfo__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewGlyphInfo(uint jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlyphInfo_fontId_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GlyphInfoFontIdSet(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlyphInfo_fontId_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GlyphInfoFontIdGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlyphInfo_index_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GlyphInfoIndexSet(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlyphInfo_index_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GlyphInfoIndexGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlyphInfo_width_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GlyphInfoWidthSet(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlyphInfo_width_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GlyphInfoWidthGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlyphInfo_height_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GlyphInfoHeightSet(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlyphInfo_height_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GlyphInfoHeightGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlyphInfo_xBearing_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GlyphInfoXBearingSet(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlyphInfo_xBearing_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GlyphInfoXBearingGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlyphInfo_yBearing_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GlyphInfoYBearingSet(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlyphInfo_yBearing_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GlyphInfoYBearingGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlyphInfo_advance_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GlyphInfoAdvanceSet(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlyphInfo_advance_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GlyphInfoAdvanceGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlyphInfo_scaleFactor_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GlyphInfoScaleFactorSet(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlyphInfo_scaleFactor_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GlyphInfoScaleFactorGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_GlyphInfo", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteGlyphInfo(IntPtr jarg1);
        }
    }
}





