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
using System.Runtime.CompilerServices;

namespace Tizen.NUI
{

    /// <summary>
    /// The class that represents an object capable of animation is the parent class of the minimum unit of visual, View. 
    /// When a property is an animatable property, it means that its value can change continuously as the target of an animation. 
    /// In this case, if a property notification callback is set, you can receive the callback according to the changing values. 
    /// Additionally, users can also add their own properties.
    /// </summary>
    /// <example><code>
    /// View view = new View()
    /// {
    ///     Size2D = new Size2D(100, 100),
    ///     Position2D = new Position2D(100, 100),
    ///     BackgroundColor = Color.Red,
    /// };
    ///
    /// Window.Default.Add(view);
    /// Animation animation = new Animation();
    /// const float destinationValue = 300.0f;
    /// const int startTime = 0; // animation starts at 0 second point. no delay.
    /// const int endTime = 5000; // animation ends at 5 second point.
    /// animation.AnimateTo(view, "PositionX", destinationValue, startTime, endTime, new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseInSine));
    /// animation.Play();
    ///
    /// PropertyNotification propertyNotification = view.AddPropertyNotification("position", PropertyCondition.Step(10.0f));
    /// propertyNotification.Notified += (object source, PropertyNotification.NotifyEventArgs args) =>
    /// {
    ///     Animatable target = args.PropertyNotification.GetTarget();
    ///     if (target is View viewTarget)
    ///     {
    ///         Tizen.Log.Debug("NUI", $"postion changed! ({viewTarget.CurrentPosition.X},{viewTarget.CurrentPosition.Y})");
    ///     }
    /// };
    ///
    /// Animatable animatable = new Animatable();
    /// int myPropertyIndex = animatable.RegisterProperty("myProperty", new PropertyValue(100), PropertyAccessMode.ReadWrite);
    /// animatable.GetProperty(myPropertyIndex).Get(out int aValue);
    /// Tizen.Log.Debug("NUI", $"myProperty value : {aValue} (should be 100)");
    ///
    /// animatable.SetProperty(myPropertyIndex, new PropertyValue(200));
    /// animatable.GetProperty(myPropertyIndex).Get(out aValue);
    /// Tizen.Log.Debug("NUI", $"myProperty value : {aValue} (should be 200)");
    /// </code></example>
    /// <since_tizen> 3 </since_tizen>
    public class Animatable : BaseHandle
    {
        static internal new void Preload()
        {
            BaseHandle.Preload();
            // Do nothing. Just call for load static values.
        }

        /// <summary>
        /// Create an instance of animatable.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Animatable() : this(Interop.Handle.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Animatable(global::System.IntPtr cPtr, bool cMemoryOwn) : this(cPtr, cMemoryOwn, cMemoryOwn)
        {
        }

        internal Animatable(global::System.IntPtr cPtr, bool cMemoryOwn, bool cRegister) : base(cPtr, cMemoryOwn, cRegister)
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
        /// Sets the value of an existing property.
        /// </summary>
        /// <param name="name">The index of the property.</param>
        /// <param name="propertyValue">The new value of the property.</param>
        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetProperty(string name, PropertyValue propertyValue)
        {
            var propertyName = LowerFirstLetter(name);
            Property property = new Property(this, propertyName);
            if (property.PropertyIndex == Property.InvalidIndex)
            {
                Tizen.Log.Error("NUI", "Invalid property name\n");
            }
            else
            {
                Tizen.NUI.Object.SetProperty(SwigCPtr, property.PropertyIndex, propertyValue);
            }
            property.Dispose();
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
        /// Retrieves the latest rendered frame value of the property.
        /// </summary>
        /// <param name="index">The index of the property.</param>
        /// <returns>The property value.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyValue GetCurrentProperty(int index)
        {
            PropertyValue ret = Tizen.NUI.Object.GetCurrentProperty(SwigCPtr, index);
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
            PropertyNotification ret = new PropertyNotification(Interop.Handle.AddPropertyNotification(SwigCPtr, properties.PropertyIndex, PropertyCondition.getCPtr(condition)), true);
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

        private static unsafe string LowerFirstLetter(string original)
        {
            if (string.IsNullOrEmpty(original) || char.IsLower(original[0]))
                return original;

            fixed (char* chars = original)
            {
                chars[0] = char.ToLower(chars[0]);
            }

            return original;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Handle.DeleteHandle(swigCPtr);
        }
    }
}
