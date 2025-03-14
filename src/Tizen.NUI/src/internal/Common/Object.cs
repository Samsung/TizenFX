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

using global::System.Runtime.InteropServices;

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
        public static PropertyValue GetCurrentProperty(global::System.Runtime.InteropServices.HandleRef handle, int index)
        {
            if (handle.Handle == System.IntPtr.Zero)
            {
                throw new System.InvalidOperationException("Error! NUI's native dali object is already disposed. OR the native dali object handle of NUI becomes null!");
            }

            PropertyValue ret = new PropertyValue(Interop.Handle.GetCurrentProperty(handle, index), true);
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

        internal static int InternalSetPropertyString(HandleRef actor, int propertyType, string valString)
        {
            if (actor.Handle == System.IntPtr.Zero)
            {
                throw new System.InvalidOperationException("Error! NUI's native dali object is already disposed. OR the native dali object handle of NUI becomes null!");
            }
            var ret = Interop.Actor.InternalSetPropertyString(actor, propertyType, valString);

            if (NDalicPINVOKE.SWIGPendingException.Pending)
            {
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            return ret;
        }

        internal static string InternalGetPropertyString(HandleRef actor, int propertyType)
        {
            if (actor.Handle == System.IntPtr.Zero)
            {
                throw new System.InvalidOperationException("Error! NUI's native dali object is already disposed. OR the native dali object handle of NUI becomes null!");
            }
            var ret = Interop.Actor.InternalGetPropertyString(actor, propertyType);

            if (NDalicPINVOKE.SWIGPendingException.Pending)
            {
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            return ret;
        }

        internal static int InternalSetPropertyBool(HandleRef actor, int propertyType, bool valBool)
        {
            if (actor.Handle == System.IntPtr.Zero)
            {
                throw new System.InvalidOperationException("Error! NUI's native dali object is already disposed. OR the native dali object handle of NUI becomes null!");
            }
            var ret = Interop.Actor.InternalSetPropertyBool(actor, propertyType, valBool);

            if (NDalicPINVOKE.SWIGPendingException.Pending)
            {
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            return ret;
        }

        internal static bool InternalGetPropertyBool(HandleRef actor, int propertyType)
        {
            if (actor.Handle == System.IntPtr.Zero)
            {
                throw new System.InvalidOperationException("Error! NUI's native dali object is already disposed. OR the native dali object handle of NUI becomes null!");
            }
            var ret = Interop.Actor.InternalGetPropertyBool(actor, propertyType);

            if (NDalicPINVOKE.SWIGPendingException.Pending)
            {
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            return ret;
        }

        internal static int InternalSetPropertyVector4(HandleRef actor, int propertyType, HandleRef vector4)
        {
            if (actor.Handle == System.IntPtr.Zero)
            {
                throw new System.InvalidOperationException("Error! NUI's native dali object is already disposed. OR the native dali object handle of NUI becomes null!");
            }
            var ret = Interop.Actor.InternalSetPropertyVector4(actor, propertyType, vector4);

            if (NDalicPINVOKE.SWIGPendingException.Pending)
            {
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            return ret;
        }

        internal static int InternalRetrievingPropertyVector4(HandleRef actor, int propertyType, HandleRef retrievingVector4)
        {
            if (actor.Handle == System.IntPtr.Zero)
            {
                throw new System.InvalidOperationException("Error! NUI's native dali object is already disposed. OR the native dali object handle of NUI becomes null!");
            }
            var ret = Interop.Actor.InternalRetrievingPropertyVector4(actor, propertyType, retrievingVector4);

            if (NDalicPINVOKE.SWIGPendingException.Pending)
            {
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            return ret;
        }

        internal static int InternalGetPropertyInt(HandleRef actor, int propertyType)
        {
            if (actor.Handle == System.IntPtr.Zero)
            {
                throw new System.InvalidOperationException("Error! NUI's native dali object is already disposed. OR the native dali object handle of NUI becomes null!");
            }
            var ret = Interop.Actor.InternalGetPropertyInt(actor, propertyType);

            if (NDalicPINVOKE.SWIGPendingException.Pending)
            {
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            return ret;
        }

        internal static int InternalSetPropertyInt(HandleRef actor, int propertyType, int valInt)
        {
            if (actor.Handle == System.IntPtr.Zero)
            {
                throw new System.InvalidOperationException("Error! NUI's native dali object is already disposed. OR the native dali object handle of NUI becomes null!");
            }
            var ret = Interop.Actor.InternalSetPropertyInt(actor, propertyType, valInt);

            if (NDalicPINVOKE.SWIGPendingException.Pending)
            {
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            return ret;
        }

        internal static int InternalRetrievingPropertyVector3(HandleRef actor, int propertyType, HandleRef retrievingVector3)
        {
            if (actor.Handle == System.IntPtr.Zero)
            {
                throw new System.InvalidOperationException("Error! NUI's native dali object is already disposed. OR the native dali object handle of NUI becomes null!");
            }
            var ret = Interop.Actor.InternalRetrievingPropertyVector3(actor, propertyType, retrievingVector3);

            if (NDalicPINVOKE.SWIGPendingException.Pending)
            {
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            return ret;
        }

        internal static int InternalSetPropertyVector3(HandleRef actor, int propertyType, HandleRef vector3)
        {
            if (actor.Handle == System.IntPtr.Zero)
            {
                throw new System.InvalidOperationException("Error! NUI's native dali object is already disposed. OR the native dali object handle of NUI becomes null!");
            }
            var ret = Interop.Actor.InternalSetPropertyVector3(actor, propertyType, vector3);

            if (NDalicPINVOKE.SWIGPendingException.Pending)
            {
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            return ret;
        }

        internal static float InternalGetPropertyFloat(HandleRef actor, int propertyType)
        {
            if (actor.Handle == System.IntPtr.Zero)
            {
                throw new System.InvalidOperationException("Error! NUI's native dali object is already disposed. OR the native dali object handle of NUI becomes null!");
            }
            var ret = Interop.Actor.InternalGetPropertyFloat(actor, propertyType);

            if (NDalicPINVOKE.SWIGPendingException.Pending)
            {
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            return ret;
        }

        internal static int InternalSetPropertyFloat(HandleRef actor, int propertyType, float valFloat)
        {
            if (actor.Handle == System.IntPtr.Zero)
            {
                throw new System.InvalidOperationException("Error! NUI's native dali object is already disposed. OR the native dali object handle of NUI becomes null!");
            }
            var ret = Interop.Actor.InternalSetPropertyFloat(actor, propertyType, valFloat);

            if (NDalicPINVOKE.SWIGPendingException.Pending)
            {
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            return ret;
        }

        internal static int InternalRetrievingPropertyVector2(HandleRef actor, int propertyType, HandleRef retrievingVector2)
        {
            if (actor.Handle == System.IntPtr.Zero)
            {
                throw new System.InvalidOperationException("Error! NUI's native dali object is already disposed. OR the native dali object handle of NUI becomes null!");
            }
            var ret = Interop.Actor.InternalRetrievingPropertyVector2(actor, propertyType, retrievingVector2);

            if (NDalicPINVOKE.SWIGPendingException.Pending)
            {
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            return ret;
        }

        internal static int InternalSetPropertyVector2(HandleRef actor, int propertyType, HandleRef vector2)
        {
            if (actor.Handle == System.IntPtr.Zero)
            {
                throw new System.InvalidOperationException("Error! NUI's native dali object is already disposed. OR the native dali object handle of NUI becomes null!");
            }
            var ret = Interop.Actor.InternalSetPropertyVector2(actor, propertyType, vector2);

            if (NDalicPINVOKE.SWIGPendingException.Pending)
            {
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            return ret;
        }

        internal static int InternalRetrievingPropertyVector2ActualVector3(HandleRef actor, int propertyType, HandleRef retrievingVector2)
        {
            if (actor.Handle == System.IntPtr.Zero)
            {
                throw new System.InvalidOperationException("Error! NUI's native dali object is already disposed. OR the native dali object handle of NUI becomes null!");
            }
            var ret = Interop.Actor.InternalRetrievingPropertyVector2ActualVector3(actor, propertyType, retrievingVector2);

            if (NDalicPINVOKE.SWIGPendingException.Pending)
            {
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            return ret;
        }

        internal static int InternalSetPropertyVector2ActualVector3(HandleRef actor, int propertyType, HandleRef vector2)
        {
            if (actor.Handle == System.IntPtr.Zero)
            {
                throw new System.InvalidOperationException("Error! NUI's native dali object is already disposed. OR the native dali object handle of NUI becomes null!");
            }
            var ret = Interop.Actor.InternalSetPropertyVector2ActualVector3(actor, propertyType, vector2);

            if (NDalicPINVOKE.SWIGPendingException.Pending)
            {
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            return ret;
        }

        internal static int InternalRetrievingVisualPropertyInt(HandleRef actor, int visualIndex, int visualPropertyIndex, out int retrievingInt)
        {
            if (actor.Handle == System.IntPtr.Zero)
            {
                throw new System.InvalidOperationException("Error! NUI's native dali object is already disposed. OR the native dali object handle of NUI becomes null!");
            }
            var ret = Interop.View.InternalRetrievingVisualPropertyInt(actor, visualIndex, visualPropertyIndex, out retrievingInt);
            NDalicPINVOKE.ThrowExceptionIfExists();
            return ret;
        }

        internal static int InternalRetrievingVisualPropertyVector4(HandleRef actor, int visualIndex, int visualPropertyIndex, HandleRef retrievingVector4)
        {
            if (actor.Handle == System.IntPtr.Zero)
            {
                throw new System.InvalidOperationException("Error! NUI's native dali object is already disposed. OR the native dali object handle of NUI becomes null!");
            }
            var ret = Interop.View.InternalRetrievingVisualPropertyVector4(actor, visualIndex, visualPropertyIndex, retrievingVector4);
            NDalicPINVOKE.ThrowExceptionIfExists();
            return ret;
        }

        /// <summary>
        /// Sets color value (vector4) to actor.
        /// </summary>
        /// <remark>
        /// This is not thread safe.
        /// </remark>
        internal static void InternalSetPropertyColor(HandleRef actor, int propertyType, UIColor color)
        {
            if (actor.Handle == System.IntPtr.Zero)
            {
                throw new System.InvalidOperationException("Error! NUI's native dali object is already disposed. OR the native dali object handle of NUI becomes null!");
            }

            ReusablePool<Vector4>.GetOne((vector4, actor, propertyType, color) =>
            {
                vector4.Reset(color);
                _ = Interop.Actor.InternalSetPropertyVector4(actor, propertyType, vector4.SwigCPtr);
                NDalicPINVOKE.ThrowExceptionIfExists();
            }, actor, propertyType, color);
        }

        /// <summary>
        /// GEts color value (vector4) from actor.
        /// </summary>
        /// <remark>
        /// This is not thread safe.
        /// </remark>
        internal static UIColor InternalRetrievingVisualPropertyColor(HandleRef actor, int visualIndex, int visualPropertyIndex)
        {
            if (actor.Handle == System.IntPtr.Zero)
            {
                throw new System.InvalidOperationException("Error! NUI's native dali object is already disposed. OR the native dali object handle of NUI becomes null!");
            }

            return ReusablePool<Vector4>.GetOne((vector4, actor, visualIndex, visualPropertyIndex) =>
            {
                vector4.Reset();
                _ = Interop.View.InternalRetrievingVisualPropertyVector4(actor, visualIndex, visualPropertyIndex, vector4.SwigCPtr);
                NDalicPINVOKE.ThrowExceptionIfExists();
                return UIColor.From(vector4);
            }, actor, visualIndex, visualPropertyIndex);
        }

        internal static void InternalSetPropertyMap(HandleRef actor, int propertyType, HandleRef map)
        {
            if (actor.Handle == System.IntPtr.Zero)
            {
                throw new System.InvalidOperationException("Error! NUI's native dali object is already disposed. OR the native dali object handle of NUI becomes null!");
            }
            _ = Interop.Actor.InternalSetPropertyMap(actor, propertyType, map);
            NDalicPINVOKE.ThrowExceptionIfExists();
        }
    }
}
