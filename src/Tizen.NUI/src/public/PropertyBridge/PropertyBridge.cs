/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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
    internal static class PropertyBridge
    {
        private static StringGetterDelegate _stringGetterDelegate;

        static PropertyBridge()
        {
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate string StringGetterDelegate(IntPtr obj, [MarshalAs(UnmanagedType.LPStr)] string propertyName);

        public static void RegisterStringGetter()
        {
            _stringGetterDelegate = InternalStringGetter;
            IntPtr funcPtr = Marshal.GetFunctionPointerForDelegate(_stringGetterDelegate);
            Interop.PropertyBridge.RegisterStringGetter(funcPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private static string InternalStringGetter(IntPtr obj, string propertyName)
        {
            if (obj != IntPtr.Zero)
            {
                View view = Registry.GetManagedBaseHandleFromNativePtr(obj) as View;
                if (view != null && view is IPropertyProvider provider)
                {
                    return provider.GetStringProperty(propertyName);
                }
            }
            return null;
        }
    }
}
