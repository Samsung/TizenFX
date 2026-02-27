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
        internal static partial class TextureSet
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextureSet_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_TextureSet", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteTextureSet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextureSet_SetTexture", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetTexture(IntPtr jarg1, uint jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextureSet_RemoveTexture", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RemoveTexture(IntPtr textureSet, uint index);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextureSet_GetTexture", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetTexture(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextureSet_SetSampler", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetSampler(IntPtr jarg1, uint jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextureSet_RemoveSampler", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RemoveSampler(IntPtr textureSet, uint index);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextureSet_GetSampler", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetSampler(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextureSet_GetTextureCount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetTextureCount(IntPtr jarg1);
        }
    }
}





