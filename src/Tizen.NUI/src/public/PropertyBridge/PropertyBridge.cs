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

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void StringGetterDelegate(IntPtr obj, [MarshalAs(UnmanagedType.LPUTF8Str)] string propertyName, IntPtr result);

        public static void RegisterStringGetter()
        {
            _stringGetterDelegate = InternalStringGetter;
            IntPtr funcPtr = Marshal.GetFunctionPointerForDelegate(_stringGetterDelegate);
            Interop.PropertyBridge.RegisterStringGetter(funcPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private static void InternalStringGetter(IntPtr obj, string propertyName, IntPtr result)
        {
            if (obj == IntPtr.Zero || string.IsNullOrEmpty(propertyName))
                return;

            if (Registry.GetManagedBaseHandleFromRefObject(obj) is not View view)
                return;

            if (view is not IPropertyProvider provider)
                return;

            string value = provider.GetStringProperty(propertyName);
            Tizen.Log.Info("NUI", $"Property:{propertyName}, value:{value}");
            Interop.StringToVoidSignal.SetResult(result, value ?? string.Empty);
        }
    }
}
