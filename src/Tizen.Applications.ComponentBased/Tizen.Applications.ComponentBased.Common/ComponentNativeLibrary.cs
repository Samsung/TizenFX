/*
 * Copyright (c) 2026 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Runtime.InteropServices;

namespace Tizen.Applications.ComponentBased.Common
{
    internal static class ComponentNativeLibrary
    {
        private static readonly object sync = new object();
        private static string selectedLibrary;

        // Call before binding any component callbacks or invoking component APIs.
        internal static void UseLibrary(string libraryName)
        {
            lock (sync)
            {
                if (selectedLibrary != null)
                {
                    if (selectedLibrary != libraryName)
                    {
                        throw new InvalidOperationException("The component native library is already selected.");
                    }
                    return;
                }

                var assembly = typeof(ComponentNativeLibrary).Assembly;
                IntPtr handle = NativeLibrary.Load(libraryName, assembly, null);
                try
                {
                    NativeLibrary.SetDllImportResolver(assembly, (name, requestingAssembly, searchPath) =>
                        name == Interop.Libraries.CompCoreBase ? handle : IntPtr.Zero);
                }
                catch
                {
                    NativeLibrary.Free(handle);
                    throw;
                }

                // The resolver retains the handle for the lifetime of native callbacks.
                selectedLibrary = libraryName;
            }
        }
    }
}
