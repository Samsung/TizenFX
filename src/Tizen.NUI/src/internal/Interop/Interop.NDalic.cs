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
        internal static partial class NDalic
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DaliAssertMessage", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DaliAssertMessage(string jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NextPowerOfTwo", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint NextPowerOfTwo(uint jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_IsPowerOfTwo", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsPowerOfTwo(uint jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GetRangedEpsilon", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetRangedEpsilon(float jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_EqualsZero", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool EqualsZero(float jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Equals__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool Equals(float jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Equals__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool Equals(float jarg1, float jarg2, float jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Round", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float Round(float jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WrapInDomain", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float WrapInDomain(float jarg1, float jarg2, float jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ShortestDistanceInDomain", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float ShortestDistanceInDomain(float jarg1, float jarg2, float jarg3, float jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GetName", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string GetName(int jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GetImplementation", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetImplementation(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_HasAlpha", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool HasAlpha(int jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GetBytesPerPixel", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetBytesPerPixel(int jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GetAlphaOffsetAndMask", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GetAlphaOffsetAndMask(int jarg1, IntPtr jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GetDeviceName", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string GetDeviceName(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GetDeviceClass", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetDeviceClass(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GetDeviceSubClass", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetDeviceSubClass(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Raise", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Raise(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Lower", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Lower(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RaiseToTop", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RaiseToTop(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_LowerToBottom", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void LowerToBottom(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RaiseAbove", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RaiseAbove(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_LowerBelow", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void LowerBelow(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_SetCustomAlgorithm", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetCustomAlgorithm(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_AnimatablePropertyRegistration__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewAnimatablePropertyRegistration(IntPtr jarg1, string jarg2, int jarg3, int jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_AnimatablePropertyRegistration__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewAnimatablePropertyRegistration(IntPtr jarg1, string jarg2, int jarg3, IntPtr jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_AnimatablePropertyRegistration", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteAnimatablePropertyRegistration(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ChildPropertyRegistration", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewChildPropertyRegistration(IntPtr jarg1, string jarg2, int jarg3, int jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ChildPropertyRegistration", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteChildPropertyRegistration(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_RelayoutContainer", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteRelayoutContainer(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RelayoutContainer_Add", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RelayoutContainerAdd(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3);
        }
    }
}





