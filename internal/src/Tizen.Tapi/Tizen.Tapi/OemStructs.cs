/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Tapi
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct OemDataStruct
    {
        internal uint OemId;
        internal uint Length;
        internal IntPtr Data;
    }

    internal static class OemStructConversions
    {
        internal static OemData ConvertOemStruct(OemDataStruct info)
        {
            OemData data = new OemData();
            data.OemId = info.OemId;
            int length = Convert.ToInt32(info.Length);
            data.OemDataInfo = new byte[length];
            Marshal.Copy(info.Data, data.OemDataInfo, 0, length);
            return data;
        }
    }
}
