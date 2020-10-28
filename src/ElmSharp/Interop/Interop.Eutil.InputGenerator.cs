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
    internal static partial class Eutil
    {
        [DllImport(Libraries.Eutil)]
        internal static extern IntPtr efl_util_input_initialize_generator(int devType);

        [DllImport(Libraries.Eutil)]
        internal static extern IntPtr efl_util_input_initialize_generator_with_name(int devType, string name);

        [DllImport(Libraries.Eutil)]
        internal static extern int efl_util_input_deinitialize_generator(IntPtr inputgenH);

        [DllImport(Libraries.Eutil)]
        internal static extern int efl_util_input_generate_key(IntPtr inputgenH, string keyName, int pressed);

        [DllImport(Libraries.Eutil)]
        internal static extern int efl_util_input_generate_touch(IntPtr inputgenH, int idx, int touchType, int x, int y);

        [DllImport(Libraries.Eutil)]
        internal static extern int efl_util_input_generate_pointer(IntPtr inputgenH, int buttons, int pointerType, int x, int y);
    }
}