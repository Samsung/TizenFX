/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Security;
using System.Runtime.InteropServices;

namespace OpenTK.Platform.SDL2
{
    internal partial class SDL
    {
        [SuppressUnmanagedCodeSecurity]
        [DllImport(lib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetMainReady", ExactSpelling = true)]
        public static extern void SetMainReady();

        [SuppressUnmanagedCodeSecurity]
        [DllImport(lib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_tizen_app_init", ExactSpelling = true)]
        public static extern int TizenAppInit(int argc, string[] argv);

        [SuppressUnmanagedCodeSecurity]
        [DllImport(lib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetHint", ExactSpelling = true)]
        public static extern IntPtr SetHint(string name, string value);
    }
}
