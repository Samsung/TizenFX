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
        internal static partial class Path
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Path_Property_POINTS_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int PointsGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Path_Property_CONTROL_POINTS_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ControlPointsGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Path_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Path", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeletePath(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Path_AddPoint", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AddPoint(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Path_AddControlPoint", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AddControlPoint(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Path_GenerateControlPoints", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GenerateControlPoints(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Path_Sample", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Sample(IntPtr jarg1, float jarg2, IntPtr jarg3, IntPtr jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Path_GetPoint", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetPoint(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Path_GetControlPoint", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetControlPoint(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Path_GetPointCount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetPointCount(IntPtr jarg1);
        }
    }
}





