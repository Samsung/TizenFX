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
        internal static partial class Shape
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_AddRect", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool AddRect(IntPtr jarg1, float jarg2, float jarg3, float jarg4, float jarg5, float jarg6, float jarg7);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_AddCircle", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool AddCircle(IntPtr jarg1, float jarg2, float jarg3, float jarg4, float jarg5);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_AddArc", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool AddArc(IntPtr jarg1, float jarg2, float jarg3, float jarg4, float jarg5, float jarg6, [MarshalAs(UnmanagedType.U1)] bool jarg7);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_AddMoveTo", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool AddMoveTo(IntPtr jarg1, float jarg2, float jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_AddLineTo", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool AddLineTo(IntPtr jarg1, float jarg2, float jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_AddCubicTo", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool AddCubicTo(IntPtr jarg1, float jarg2, float jarg3, float jarg4, float jarg5, float jarg6, float jarg7);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_AddPath", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial void AddPath(IntPtr pShape, [global::System.Runtime.InteropServices.In, global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPArray)] BaseComponents.VectorGraphics.PathCommandType[] commands, uint commandCount, [global::System.Runtime.InteropServices.In, global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPArray)] float[] points, uint pointCount);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_Close", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool Close(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_ResetPath", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool ResetPath(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_SetFillColor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetFillColor(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_GetFillColor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetFillColor(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_SetFillRule", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetFillRule(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_GetFillRule", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetFillRule(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_SetStrokeWidth", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetStrokeWidth(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_GetStrokeWidth", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetStrokeWidth(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_SetStrokeColor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetStrokeColor(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_GetStrokeColor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetStrokeColor(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_SetStrokeDash", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetStrokeDash(IntPtr jarg1, [global::System.Runtime.InteropServices.In, global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPArray)] float[] jarg2, uint jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_GetStrokeDashIndexOf", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetStrokeDashIndexOf(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_GetStrokeDashCount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetStrokeDashCount(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_SetStrokeCap", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetStrokeCap(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_GetStrokeCap", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetStrokeCap(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_SetStrokeJoin", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetStrokeJoin(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shape_GetStrokeJoin", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetStrokeJoin(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shapep_SetFillGradient", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool SetFillGradient(IntPtr pShape, IntPtr pGradient);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shapep_GetFillGradient", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetFillGradient(IntPtr pShape);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shapep_SetStrokeGradient", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool SetStrokeGradient(IntPtr pShape, IntPtr pGradient);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Shapep_GetStrokeGradient", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetStrokeGradient(IntPtr pShape);
        }
    }
}





