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

using System.Text;

namespace Tizen.NUI
{

    /// <summary>
    /// Animatable.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Animatable : BaseHandle
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        /// <summary>
        /// Create an instance of animatable.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Animatable() : this(Interop.Handle.Handle_New(), true)
        {
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();

        }

        internal Animatable(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.Handle.Handle_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        /// <summary>
        /// Enumeration for Handle's capabilities that can be queried.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum Capability
        {
            /// <summary>
            /// Some objects support dynamic property creation at run-time.
            /// New properties are registered by calling RegisterProperty() with an unused property name.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            DYNAMIC_PROPERTIES = 0x01
        }

        /// <summary>
        /// Queries the name of a property.
        /// </summary>
        /// <param name="index">The index of the property.</param>
        /// <returns>The name of the property.</returns>
        /// <since_tizen> 3 </since_tizen>
        public string GetPropertyName(int index)
        {
            string ret = Interop.Handle.Handle_GetPropertyName(swigCPtr, index);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Queries the index of a property.
        /// </summary>
        /// <param name="name">The name of the property.</param>
        /// <returns>The index of the property.</returns>
        /// <since_tizen> 3 </since_tizen>
        public int GetPropertyIndex(string name)
        {
            // Convert property string to be lowercase
            StringBuilder sb = new StringBuilder(name);
            sb[0] = (char)(sb[0] | 0x20);
            string str = sb.ToString();

            int ret = Interop.Handle.Handle_GetPropertyIndex(swigCPtr, str);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Queries whether a property can be writable.
        /// </summary>
        /// <param name="index">The index of the property.</param>
        /// <returns>True if the property is writable.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool IsPropertyWritable(int index)
        {
            bool ret = Interop.Handle.Handle_IsPropertyWritable(swigCPtr, index);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// whether a writable property can be the target of an animation.
        /// </summary>
        /// <param name="index">The index of the property.</param>
        /// <returns>True if the property is animatable.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool IsPropertyAnimatable(int index)
        {
            bool ret = Interop.Handle.Handle_IsPropertyAnimatable(swigCPtr, index);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Queries the type of a property.
        /// </summary>
        /// <param name="index">The index of the property.</param>
        /// <returns>The type of the property.</returns>
        /// <since_tizen> 3 </since_tizen>
        public PropertyType GetPropertyType(int index)
        {
            PropertyType ret = (PropertyType)Interop.Handle.Handle_GetPropertyType(swigCPtr, index);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the value of an existing property.
        /// </summary>
        /// <param name="index">The index of the property.</param>
        /// <param name="propertyValue">The new value of the property.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetProperty(int index, PropertyValue propertyValue)
        {
            Tizen.NUI.Object.SetProperty(swigCPtr, index, propertyValue);
        }

        /// <summary>
        /// Registers a new animatable property.
        /// </summary>
        /// <param name="name">The name of the property.</param>
        /// <param name="propertyValue">The new value of the property.</param>
        /// <returns>The type of the property.</returns>
        /// <since_tizen> 3 </since_tizen>
        public int RegisterProperty(string name, PropertyValue propertyValue)
        {
            int ret = Interop.Handle.Handle_RegisterProperty__SWIG_0(swigCPtr, name, PropertyValue.getCPtr(propertyValue));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Registers a new animatable property.
        /// </summary>
        /// <param name="name">The name of the property.</param>
        /// <param name="propertyValue">The new value of the property.</param>
        /// <param name="accessMode">The property access mode (writable, animatable etc).</param>
        /// <returns>The type of the property.</returns>
        /// <since_tizen> 3 </since_tizen>
        public int RegisterProperty(string name, PropertyValue propertyValue, PropertyAccessMode accessMode)
        {
            int ret = Interop.Handle.Handle_RegisterProperty__SWIG_1(swigCPtr, name, PropertyValue.getCPtr(propertyValue), (int)accessMode);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves a property value.
        /// </summary>
        /// <param name="index">The index of the property.</param>
        /// <returns>The property value.</returns>
        /// <since_tizen> 3 </since_tizen>
        public PropertyValue GetProperty(int index)
        {
            PropertyValue ret = Tizen.NUI.Object.GetProperty(swigCPtr, index);
            return ret;
        }

        /// <summary>
        /// Adds a property notification to this object.
        /// </summary>
        /// <param name="property">The name of the property.</param>
        /// <param name="condition">The notification will be triggered when this condition is satisfied.</param>
        /// <returns>A handle to the newly created PropertyNotification.</returns>
        /// <since_tizen> 4 </since_tizen>
        public PropertyNotification AddPropertyNotification(string property, PropertyCondition condition)
        {
            PropertyNotification ret = new PropertyNotification(Interop.Handle.Handle_AddPropertyNotification__SWIG_0(swigCPtr, PropertyHelper.GetPropertyFromString(this, property).propertyIndex, PropertyCondition.getCPtr(condition)), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Removes a property notification from this object.
        /// </summary>
        /// <param name="propertyNotification">The propertyNotification to be removed.</param>
        /// <since_tizen> 4 </since_tizen>
        public void RemovePropertyNotification(PropertyNotification propertyNotification)
        {
            Interop.Handle.Handle_RemovePropertyNotification(swigCPtr, PropertyNotification.getCPtr(propertyNotification));
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Removes a property notification from this object.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public void RemovePropertyNotifications()
        {
            Interop.Handle.Handle_RemovePropertyNotifications(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Animatable obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal uint GetPropertyCount()
        {
            uint ret = Interop.HandleInternal.Handle_GetPropertyCount(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        internal PropertyNotification AddPropertyNotification(int index, int componentIndex, PropertyCondition condition)
        {
            PropertyNotification ret = new PropertyNotification(Interop.Handle.Handle_AddPropertyNotification__SWIG_1(swigCPtr, index, componentIndex, PropertyCondition.getCPtr(condition)), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void RemoveConstraints()
        {
            Interop.HandleInternal.Handle_RemoveConstraints__SWIG_0(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        internal void RemoveConstraints(uint tag)
        {
            Interop.HandleInternal.Handle_RemoveConstraints__SWIG_1(swigCPtr, tag);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// To make the Animatable instance be disposed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.

            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    Interop.Handle.delete_Handle(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

    }

}
