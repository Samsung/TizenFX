/*
 * Copyright(c) 2023 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;
using System.Collections.Generic;
using Tizen.NUI;

namespace Tizen.NUI.Scene3D
{
    /// <summary>
    /// This MotionValue be used for target value of each <see cref="MotionIndex"/>.
    /// We can get and set MotionValue as 2 types : PropertyValue and KeyFrames.
    ///
    /// Each types will be cross-converted internally.
    /// For example, when we set PropertyValue, we can get KeyFrames with 2 frames, and target value is set.
    /// </summary>
    /// <remarks>
    /// The type of property should be matched with MotionIndex required.
    /// </remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class MotionValue : BaseHandle
    {
        /// <summary>
        /// Determine whether current stored value is PropertyValue, or KeyFrames.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum ValueType
        {
            /// <summary>
            /// Value is null, or invalid class.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Invalid = -1,

            /// <summary>
            /// Value is PropertyValue.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Property = 0,

            /// <summary>
            /// Value is KeyFrames.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            KeyFrames,
        }

        /// <summary>
        /// Create an initialized motion value with invalid.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MotionValue() : this(Interop.MotionValue.MotionValueNew(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Create an initialized motion value with PropertyValue.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MotionValue(PropertyValue propertyValue) : this(Interop.MotionValue.MotionValueNewPropertyValue(PropertyValue.getCPtr(propertyValue)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Create an initialized motion value with KeyFrames.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MotionValue(KeyFrames keyFrames) : this(Interop.MotionValue.MotionValueNewKeyFrames(KeyFrames.getCPtr(keyFrames)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="motionValue">Source object to copy.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MotionValue(MotionValue motionValue) : this(Interop.MotionValue.NewMotionValue(MotionValue.getCPtr(motionValue)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Assignment operator.
        /// </summary>
        /// <param name="motionValue">Source object to be assigned.</param>
        /// <returns>Reference to this.</returns>
        internal MotionValue Assign(MotionValue motionValue)
        {
            MotionValue ret = new MotionValue(Interop.MotionValue.MotionValueAssign(SwigCPtr, MotionValue.getCPtr(motionValue)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal MotionValue(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }


        /// <summary>
        /// Get or set the value as PropertyValue type.
        /// If ValueType is ValueType.KeyFrames, it will return last value of stored KeyFrames.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyValue PropertyValue
        {
            get
            {
                return GetPropertyValue();
            }
            set
            {
                SetPropertyValue(value);
            }
        }

        /// <summary>
        /// Get or set the value as KeyFrames type.
        /// If ValueType is ValueType.PropertyValue, it will create new KeyFrames by stored PropertyValue.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public KeyFrames KeyFramesValue
        {
            get
            {
                return GetKeyFrames();
            }
            set
            {
                SetKeyFrames(value);
            }
        }

        /// <summary>
        /// Get the type of value what we set.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ValueType Type
        {
            get
            {
                return GetMotionValueType();
            }
        }

        /// <summary>
        /// Invalidate the value what we set.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Invalidate()
        {
            Interop.MotionValue.Clear(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetPropertyValue(PropertyValue propertyValue)
        {
            Interop.MotionValue.SetValuePropertyValue(SwigCPtr, PropertyValue.getCPtr(propertyValue));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PropertyValue GetPropertyValue()
        {
            IntPtr cPtr = Interop.MotionValue.GetPropertyValue(SwigCPtr);
            PropertyValue ret = new PropertyValue(cPtr, true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
        internal void SetKeyFrames(KeyFrames keyFrames)
        {
            Interop.MotionValue.SetValueKeyFrames(SwigCPtr, KeyFrames.getCPtr(keyFrames));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal KeyFrames GetKeyFrames()
        {
            IntPtr cPtr = Interop.MotionValue.GetKeyFrames(SwigCPtr);
            KeyFrames ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as KeyFrames;
            if (ret == null)
            {
                // Register new animation into Registry.
                ret = new KeyFrames(cPtr, true);
            }
            else
            {
                // We found matched NUI animation. Reduce cPtr reference count.
                HandleRef handle = new HandleRef(this, cPtr);
                Tizen.NUI.Interop.KeyFrames.DeleteKeyFrames(handle);
                handle = new HandleRef(null, IntPtr.Zero);
            }
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ValueType GetMotionValueType()
        {
            int ret = Interop.MotionValue.GetValueType(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return (ValueType)ret;
        }

        /// <summary>
        /// Release swigCPtr.
        /// </summary>
        // This will be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(global::System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.MotionValue.DeleteMotionValue(swigCPtr);
        }
    }
}
