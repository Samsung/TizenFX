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
        internal static partial class FlexContainer
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FlexContainer_Property_CONTENT_DIRECTION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ContentDirectionGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FlexContainer_Property_FLEX_DIRECTION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int FlexDirectionGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FlexContainer_Property_FLEX_WRAP_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int FlexWrapGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FlexContainer_Property_JUSTIFY_CONTENT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int JustifyContentGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FlexContainer_Property_ALIGN_ITEMS_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int AlignItemsGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FlexContainer_Property_ALIGN_CONTENT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int AlignContentGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FlexContainer_ChildProperty_FLEX_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ChildPropertyFlexGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FlexContainer_ChildProperty_ALIGN_SELF_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ChildPropertyAlignSelfGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FlexContainer_ChildProperty_FLEX_MARGIN_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ChildPropertyFlexMarginGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_FlexContainer", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteFlexContainer(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FlexContainer_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New();
        }
    }
}





