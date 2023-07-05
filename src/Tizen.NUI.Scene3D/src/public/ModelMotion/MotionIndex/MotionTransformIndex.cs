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
    /// Specialized <see cref="MotionIndex"/> to control transform.
    /// It will be used when app developer don't care about Property index list,
    /// but want to change the transform properties anyway fast enough.
    ///
    /// Each TransformTypes has their own matched <see cref="MotionValue"/> type.
    /// </summary>
    /// <example>
    /// <code>
    /// MotionTransformIndex position = new MotionTransformIndex(new PropertyKey("nodeName"), MotionTransformIndex.TransformTypes.Position);
    ///
    /// // We can change the property later.
    /// MotionTransformIndex orientation = new MotionTransformIndex();
    /// orientation.ModelNodeId = new PropertyKey("nodeName");
    /// orientation.TransformType = MotionTransformIndex.TransformTypes.Orientation;
    /// </code>
    /// </example>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class MotionTransformIndex : MotionIndex
    {
        /// <summary>
        /// The list of component types what this MotionIndex can control.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1717:Only FlagsAttribute enums should have plural names")]
        public enum TransformTypes
        {
            /// <summary>
            /// Invalid type.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Invalid = -1,

            /// <summary>
            /// The position of ModelNode. MotionValue should be Vector3.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Position = 0,

            /// <summary>
            /// The x position of ModelNode. MotionValue should be float.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            PositionX,

            /// <summary>
            /// The y position of ModelNode. MotionValue should be float.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            PositionY,

            /// <summary>
            /// The z position of ModelNode. MotionValue should be float.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            PositionZ,

            /// <summary>
            /// The orientation of ModelNode. MotionValue should be Rotation.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Orientation,

            /// <summary>
            /// The scale of ModelNode. MotionValue should be Vector3.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Scale,

            /// <summary>
            /// The x scale of ModelNode. MotionValue should be float.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            ScaleX,

            /// <summary>
            /// The y scale of ModelNode. MotionValue should be float.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            ScaleY,

            /// <summary>
            /// The z scale of ModelNode. MotionValue should be float.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            ScaleZ,
        }

        /// <summary>
        /// Create an initialized blend shape index.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MotionTransformIndex() : this(Interop.MotionIndex.MotionTransformIndexNew(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Create an initialized blend shape index with input node id, and transform type.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MotionTransformIndex(PropertyKey modelNodeId, TransformTypes transformType) : this(Interop.MotionIndex.MotionTransformIndexNew(PropertyKey.getCPtr(modelNodeId), (int)transformType), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="motionTransformIndex">Source object to copy.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MotionTransformIndex(MotionTransformIndex motionTransformIndex) : this(Interop.MotionIndex.NewMotionTransformIndex(MotionTransformIndex.getCPtr(motionTransformIndex)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Assignment operator.
        /// </summary>
        /// <param name="motionTransformIndex">Source object to be assigned.</param>
        /// <returns>Reference to this.</returns>
        internal MotionTransformIndex Assign(MotionTransformIndex motionTransformIndex)
        {
            MotionTransformIndex ret = new MotionTransformIndex(Interop.MotionIndex.MotionTransformIndexAssign(SwigCPtr, MotionTransformIndex.getCPtr(motionTransformIndex)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal MotionTransformIndex(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// The component type what this MotionIndex want to control.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TransformTypes TransformType
        {
            get
            {
                return GetTransformType();
            }
            set
            {
                SetTransformType(value);
            }
        }

        internal void SetTransformType(TransformTypes transformType)
        {
            Interop.MotionIndex.SetTransformType(SwigCPtr, (int)transformType);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal TransformTypes GetTransformType()
        {
            int ret = Interop.MotionIndex.GetTransformType(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return (TransformTypes)ret;
        }

        /// <summary>
        /// Release swigCPtr.
        /// </summary>
        // This will be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(global::System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.MotionIndex.DeleteMotionTransformIndex(swigCPtr);
        }
    }
}
