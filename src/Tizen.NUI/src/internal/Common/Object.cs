/*
 * Copyright(c) 2017 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    /// <summary>
    /// Static Helper class for Property
    /// Internal
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    internal static class Object
    {
        public static PropertyValue GetProperty(global::System.Runtime.InteropServices.HandleRef handle, int index)
        {
            if (handle.Handle == System.IntPtr.Zero)
            {
                throw new System.InvalidOperationException("Error! NUI's native dali object is already disposed. OR the native dali object handle of NUI becomes null!");
            }

            PropertyValue ret = new PropertyValue(Interop.Handle.GetProperty(handle, index), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static void SetProperty(global::System.Runtime.InteropServices.HandleRef handle, int index, PropertyValue propertyValue)
        {
            if (handle.Handle == System.IntPtr.Zero)
            {
                throw new System.InvalidOperationException("Error! NUI's native dali object is already disposed. OR the native dali object handle of NUI becomes null!");
            }

            Interop.Handle.SetProperty(handle, index, PropertyValue.getCPtr(propertyValue));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
    }
}
