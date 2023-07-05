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
    /// Specialized <see cref="MotionIndex"/> to control blend shape.
    /// We can control the blend shape by index (when we set BlendShapeId as IndexKey),
    /// or by name (when we set BlendShapeId as StringKey).
    ///
    /// <see cref="MotionValue"/> should be float type.
    ///
    /// <code>
    /// BlendShapeIndex blendShapeIndex0 = new BlendShapeIndex(new PropertyKey("nodeName"), new PropertyKey(0u));
    /// BlendShapeIndex blendShapeIndex1 = new BlendShapeIndex(new PropertyKey("nodeName"), new PropertyKey("Target_1"));
    ///
    /// // We can change the property later.
    /// BlendShapeIndex blendShapeIndex2 = new BlendShapeIndex;
    /// blendShapeIndex2.ModelNodeId = new PropertyKey("nodeName");
    /// blendShapeIndex2.BlendShapeId = new PropertyKey("Target_2");
    /// </code>
    ///
    /// Specially, if ModelNodeId is invalid and BlendShapeId is StringKey,
    /// It will control all ModelNode that has the inputed blend shape name.
    ///
    /// <code>
    /// // If "node0" and "node1" has same BlendShape named "Smile",
    /// // blendShapeIndexAll will control both nodes.
    /// BlendShapeIndex blendShapeIndexAll = new BlendShapeIndex(new PropertyKey("Smile"));
    ///
    /// BlendShapeIndex blendShapeIndex0 = new BlendShapeIndex(new PropertyKey("node0"), new PropertyKey("Smile"));
    /// BlendShapeIndex blendShapeIndex1 = new BlendShapeIndex(new PropertyKey("node1"), new PropertyKey("Smile"));
    /// </code>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class BlendShapeIndex : MotionIndex
    {
        /// <summary>
        /// Create an initialized blend shape index.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BlendShapeIndex() : this(Interop.MotionIndex.BlendShapeIndexNew(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Create an initialized blend shape index with invalid node id, and input blend shape id.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BlendShapeIndex(PropertyKey blendShapeId) : this(Interop.MotionIndex.BlendShapeIndexNew(PropertyKey.getCPtr(blendShapeId)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Create an initialized blend shape index with input node id, and input blend shape id.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BlendShapeIndex(PropertyKey modelNodeId, PropertyKey blendShapeId) : this(Interop.MotionIndex.BlendShapeIndexNew(PropertyKey.getCPtr(modelNodeId), PropertyKey.getCPtr(blendShapeId)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="blendShapeIndex">Source object to copy.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BlendShapeIndex(BlendShapeIndex blendShapeIndex) : this(Interop.MotionIndex.NewBlendShapeIndex(BlendShapeIndex.getCPtr(blendShapeIndex)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Assignment operator.
        /// </summary>
        /// <param name="blendShapeIndex">Source object to be assigned.</param>
        /// <returns>Reference to this.</returns>
        internal BlendShapeIndex Assign(BlendShapeIndex blendShapeIndex)
        {
            BlendShapeIndex ret = new BlendShapeIndex(Interop.MotionIndex.BlendShapeIndexAssign(SwigCPtr, BlendShapeIndex.getCPtr(blendShapeIndex)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal BlendShapeIndex(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// The key of blend shape.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyKey BlendShapeId
        {
            get
            {
                return GetBlendShapeId();
            }
            set
            {
                SetBlendShapeId(value);
            }
        }

        internal void SetBlendShapeId(PropertyKey blendShapeId)
        {
            Interop.MotionIndex.SetBlendShapeId(SwigCPtr, Property.getCPtr(blendShapeId));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PropertyKey GetBlendShapeId()
        {
            IntPtr cPtr = Interop.MotionIndex.GetBlendShapeId(SwigCPtr);
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
            Interop.MotionIndex.DeleteBlendShapeIndex(swigCPtr);
        }
    }
}
