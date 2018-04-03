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

internal static partial class Interop
{
    internal static partial class Eo
    {
        [DllImport(Libraries.Eo)]
        internal static extern IntPtr efl_class_get(IntPtr obj);

        [DllImport(Libraries.Eo, EntryPoint = "efl_class_name_get", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, CharSet = CharSet.Ansi)]
        internal static extern IntPtr _efl_class_name_get(IntPtr klass);

        internal static string efl_class_name_get(IntPtr obj)
        {
            var name = _efl_class_name_get(obj);
            return Marshal.PtrToStringAnsi(name);
        }

    }

}