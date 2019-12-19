/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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

using System;
using System.Runtime.InteropServices;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    internal static class Extensions
    {
        public static T GetInstanceSafely<T>(this object wrapper, IntPtr cPtr) where T : BaseHandle
        {
            HandleRef CPtr = new HandleRef(wrapper, cPtr);
            T ret = Registry.GetManagedBaseHandleFromNativePtr(CPtr.Handle) as T;
            Interop.BaseHandle.delete_BaseHandle(CPtr);
            CPtr = new HandleRef(null, IntPtr.Zero);
            return ret;
        }
    }
}
