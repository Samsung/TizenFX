/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Runtime.InteropServices;
using Tizen.Applications.Cion;

using ErrorCode = Interop.Cion.ErrorCode;

internal static partial class Interop
{
    internal static partial class CionConnectionResult
    {
        [DllImport(Libraries.Cion, EntryPoint = "cion_connection_result_get_status")]
        internal static extern ErrorCode CionConnectionResultGetStatus(IntPtr result, out ConnectionStatus status);

        [DllImport(Libraries.Cion, EntryPoint = "cion_connection_result_get_reason")]
        internal static extern ErrorCode CionConnectionResultGetReason(IntPtr result, out string reason);
    }
}
