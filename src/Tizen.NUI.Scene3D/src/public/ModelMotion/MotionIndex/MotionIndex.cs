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
    /// Index of motion value. It will be used to specify the target of motion applied.
    ///
    /// There are three kinds of MotionIndex : <see cref="MotionPropertyIndex"/>, <see cref="MotionTransformIndex"/> and <see cref="BlendShapeIndex"/>.
    /// MotionPropertyIndex will be used for control whole kind of properties.
    /// The <see cref="MotionData"/> loaded from files / buffer will have this kind of MotionIndex.
    ///
    /// MotionTransformIndex will be used for control the <see cref="ModelNode"/>'s Position / Orientation / Scale, or each components.
    /// BlendShapeIndex will be used for control some blend shape animation.
    ///
    /// We can use this class below cases
    /// - ModelNodeId (string key) , MotionTransformIndex         : Target is ModelNode's transform property
    /// - ModelNodeId (int key)    , MotionTransformIndex         : Target is ModelNode's transform property [not implemented yet]
    /// - ModelNodeId (string key) , BlendShapeIndex (int key)    : Target is ModelNode's BlendShape
    /// - ModelNodeId (string key) , BlendShapeIndex (string key) : Target is ModelNode's BlendShape
    /// - ModelNodeId (int key)    , BlendShapeIndex (int key)    : Target is ModelNode's BlendShape [not implemented yet]
    /// - ModelNodeId (int key)    , BlendShapeIndex (string key) : Target is ModelNode's BlendShape [not implemented yet]
    /// - ModelNodeId (null)       , BlendShapeIndex (string key) : Target is all ModelNode's BlendShape
    /// All other cases are invalid.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class MotionIndex : BaseHandle
    {
        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="motionIndex">Source object to copy.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MotionIndex(MotionIndex motionIndex) : this(Interop.MotionIndex.NewMotionIndex(MotionIndex.getCPtr(motionIndex)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Assignment operator.
        /// </summary>
        /// <param name="motionIndex">Source object to be assigned.</param>
        /// <returns>Reference to this.</returns>
        internal MotionIndex Assign(MotionIndex motionIndex)
        {
            MotionIndex ret = new MotionIndex(Interop.MotionIndex.MotionIndexAssign(SwigCPtr, MotionIndex.getCPtr(motionIndex)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal MotionIndex(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// The id of ModelNode. If you want to apply to all ModelNodes who has BlendShape string, let this value as null.
        /// </summary>
         [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyKey ModelNodeId
        {
            get
            {
                return GetModelNodeId();
            }
            set
            {
                SetModelNodeId(value);
            }
        }

        internal void SetModelNodeId(PropertyKey modelNodeId)
        {
            Interop.MotionIndex.SetModelNodeId(SwigCPtr, Property.getCPtr(modelNodeId));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PropertyKey GetModelNodeId()
        {
            IntPtr cPtr = Interop.MotionIndex.GetModelNodeId(SwigCPtr);
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
            Interop.MotionIndex.DeleteMotionIndex(swigCPtr);
        }
    }
}
