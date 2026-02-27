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
        internal static partial class Visual
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Visual_Property_TRANSFORM_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int TransformGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Visual_Property_PREMULTIPLIED_ALPHA_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int PremultipliedAlphaGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Visual_Property_MIX_COLOR_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int MixColorGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Image_Visual_BORDER_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ImageVisualBorderGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Visual_Actions_UPDATE_PROPERTY_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetActionUpdateProperty();
        }
    }
}





