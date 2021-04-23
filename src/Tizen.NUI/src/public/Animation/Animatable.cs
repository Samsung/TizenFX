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
using System.ComponentModel;
using System.Text;

namespace Tizen.NUI
{

    /// <summary>
    /// Animatable.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Animatable : BaseHandle
    {

        /// <summary>
        /// Create an instance of animatable.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Animatable() : this(Interop.Handle.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        internal Animatable(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
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
            string ret = Interop.Handle.GetPropertyName(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
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

            int ret = Interop.Handle.GetPropertyIndex(SwigCPtr, str);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
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
            bool ret = Interop.Handle.IsPropertyWritable(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
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
            bool ret = Interop.Handle.IsPropertyAnimatable(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
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
            PropertyType ret = (PropertyType)Interop.Handle.GetPropertyType(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
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
            Tizen.NUI.Object.SetProperty(SwigCPtr, index, propertyValue);
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
            int ret = Interop.Handle.RegisterProperty(SwigCPtr, name, PropertyValue.getCPtr(propertyValue));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
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
            int ret = Interop.Handle.RegisterProperty(SwigCPtr, name, PropertyValue.getCPtr(propertyValue), (int)accessMode);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
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
            PropertyValue ret = Tizen.NUI.Object.GetProperty(SwigCPtr, index);
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
            Property properties = PropertyHelper.GetPropertyFromString(this, property);
            PropertyNotification ret = new PropertyNotification(Interop.Handle.AddPropertyNotification(SwigCPtr, properties.propertyIndex, PropertyCondition.getCPtr(condition)), true);
            properties.Dispose();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Removes a property notification from this object.
        /// </summary>
        /// <param name="propertyNotification">The propertyNotification to be removed.</param>
        /// <since_tizen> 4 </since_tizen>
        public void RemovePropertyNotification(PropertyNotification propertyNotification)
        {
            Interop.Handle.RemovePropertyNotification(SwigCPtr, PropertyNotification.getCPtr(propertyNotification));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Removes a property notification from this object.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public void RemovePropertyNotifications()
        {
            Interop.Handle.RemovePropertyNotifications(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Animatable obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        internal uint GetPropertyCount()
        {
            uint ret = Interop.HandleInternal.HandleGetPropertyCount(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal PropertyNotification AddPropertyNotification(int index, int componentIndex, PropertyCondition condition)
        {
            PropertyNotification ret = new PropertyNotification(Interop.Handle.AddPropertyNotification(SwigCPtr, index, componentIndex, PropertyCondition.getCPtr(condition)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void RemoveConstraints()
        {
            Interop.HandleInternal.HandleRemoveConstraints(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void RemoveConstraints(uint tag)
        {
            Interop.HandleInternal.HandleRemoveConstraints(SwigCPtr, tag);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Handle.DeleteHandle(swigCPtr);
        }
    }
}
