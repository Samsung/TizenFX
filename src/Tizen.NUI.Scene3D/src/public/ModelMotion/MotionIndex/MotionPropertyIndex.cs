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
using System.ComponentModel;
using System.Collections.Generic;
using Tizen.NUI;

namespace Tizen.NUI.Scene3D
{
    /// <summary>
    /// Basic <see cref="MotionIndex"/> to control Property.
    /// It can control more general case.
    /// </summary>
    /// <example>
    /// <code>
    /// MotionPropertyIndex color = new MotionPropertyIndex(new PropertyKey("nodeName"), new PropertyKey("color"));
    ///
    /// // We can change the property later.
    /// MotionPropertyIndex custom = newMotionPropertyIndex();
    /// orientation.ModelNodeId = new PropertyKey("nodeName");
    /// orientation.PropertyId = new PropertyKey("some_custom_property");
    ///
    /// // Note that all cases of MotionTransformIndex can be controled by MotionPropertyIndex
    /// // Both position0 and position1 can control the node's Position.
    /// MotionTransformIndex position0 = new MotionTransformIndex(new PropertyKey("nodeName"), MotionTransformIndex.TransformTypes.Position);
    /// MotionPropertyIndex  position1 = new MotionPropertyIndex(new PropertyKey("nodeName"), new PropertyKey("position"));
    ///
    /// </code>
    /// </example>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class MotionPropertyIndex : MotionIndex
    {
        /// <summary>
        /// Create an initialized motion property index.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MotionPropertyIndex() : this(Interop.MotionIndex.MotionPropertyIndexNew(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Create an initialized motion property index with given node ID and property ID.
        /// </summary>
        /// <param name="modelNodeId">Node ID for this motion index</param>
        /// <param name="propertyId">Property ID for this motion index</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MotionPropertyIndex(PropertyKey modelNodeId, PropertyKey propertyId) : this(Interop.MotionIndex.MotionPropertyIndexNew(PropertyKey.getCPtr(modelNodeId), PropertyKey.getCPtr(propertyId)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Create an initialized motion property index with given node string ID and property string ID.
        /// </summary>
        /// <param name="modelNodeName">Node string ID for this motion index</param>
        /// <param name="propertyName">Property string ID for this motion index</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MotionPropertyIndex(string modelNodeName, string propertyName) : this(Interop.MotionIndex.MotionPropertyIndexNew(PropertyKey.getCPtr(new PropertyKey(modelNodeName)), PropertyKey.getCPtr(new PropertyKey(propertyName))), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="motionPropertyIndex">Source object to copy.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MotionPropertyIndex(MotionPropertyIndex motionPropertyIndex) : this(Interop.MotionIndex.NewMotionPropertyIndex(MotionPropertyIndex.getCPtr(motionPropertyIndex)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Assignment operator.
        /// </summary>
        /// <param name="motionPropertyIndex">Source object to be assigned.</param>
        /// <returns>Reference to this.</returns>
        internal MotionPropertyIndex Assign(MotionPropertyIndex motionPropertyIndex)
        {
            MotionPropertyIndex ret = new MotionPropertyIndex(Interop.MotionIndex.MotionPropertyIndexAssign(SwigCPtr, MotionPropertyIndex.getCPtr(motionPropertyIndex)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal MotionPropertyIndex(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// The key of property
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyKey PropertyId
        {
            get
            {
                return GetPropertyId();
            }
            set
            {
                SetPropertyId(value);
            }
        }

        internal void SetPropertyId(PropertyKey propertyId)
        {
            Interop.MotionIndex.SetPropertyId(SwigCPtr, Property.getCPtr(propertyId));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PropertyKey GetPropertyId()
        {
            IntPtr cPtr = Interop.MotionIndex.GetPropertyId(SwigCPtr);
            PropertyKey ret = new PropertyKey(cPtr, true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Release swigCPtr.
        /// </summary>
        // This will be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(global::System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.MotionIndex.DeleteMotionPropertyIndex(swigCPtr);
        }
    }
}
