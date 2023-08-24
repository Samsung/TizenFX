/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
namespace Tizen.NUI
{
    using global::System;
    using global::System.Runtime.InteropServices;

    /// <summary>
    /// An abstract base class for Constraints.
    /// This class only use for inhouse currently.
    /// 
    /// This can be used to constrain a property of an object, after animations have been applied.
    /// Constraints are applied in the following order:
    ///  - Constraints are applied to on-stage views in a depth-first traversal.
    ///  - For each view, the constraints are applied in the same order as the calls to Apply().
    ///  - Constraints are not applied to off-stage views.
    /// 
    /// Create a constraint using one of the New method depending on the type of callback functions used.
    /// 
    /// Note : This function will called every frame. Maybe reduce performance if you applyed too many constraints.
    /// 
    /// TODO : AddSource(ConstraintSource); API need to be implemented.
    ///   To implement this, we have to bind ConstraintSource.
    /// TODO : Currently We don't support custom functions.
    ///   To implement this, we have to bind PropertyInputContainer
    /// </summary>
    internal class Constraint : BaseHandle
    {
        internal Constraint(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Apply current constraint.
        /// Constraint will work until Remove called.
        /// </summary>
        internal void Apply()
        {
            Interop.Constraint.Apply(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
        /// <summary>
        /// Remove current constraint.
        /// </summary>
        internal void Remove()
        {
            Interop.Constraint.Remove(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }


        /// <summary>
        /// Remove action. Determine the target values action after remove current constriant.
        /// Default is RemoveActionType.Bake
        /// </summary>
        internal RemoveActionType RemoveAction
        {
            set => Interop.Constraint.SetRemoveAction(SwigCPtr, (int)value);
            get => (RemoveActionType) Interop.Constraint.GetRemoveAction(SwigCPtr);
        }
        
        /// <summary>
        /// Tag number. It will be useful when you want to seperate constraints
        /// </summary>
        internal uint Tag
        {
            set => Interop.Constraint.SetTag(SwigCPtr, value);
            get => Interop.Constraint.GetTag(SwigCPtr);
        }

        /// <summary>
        /// Get constrainted target object
        /// </summary>
        internal BaseHandle GetTargetObject()
        {
            BaseHandle handle = new BaseHandle(Interop.Constraint.GetTargetObject(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return handle;
        }
        /// <summary>
        /// Get constrainted target property index
        /// </summary>
        internal int GetTargetPropert()
        {
            int index = Interop.Constraint.GetTargetProperty(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return index;
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="type"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if(disposed)
            {
                return;
            }
            if(type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
            }
            base.Dispose(type);
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(HandleRef swigCPtr)
        {
            Interop.Constraint.DeleteConstraint(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
        
        /// <summary>
        /// Determinate how objects property will be when constraint removed.
        /// Default is Bake.
        /// </summary>
        internal enum RemoveActionType
        {
            /// <summary>
            /// Target objects property will bake when constraint removed.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Bake,
            /// <summary>
            /// Target objects property will be original value when constraint removed.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Discard,
        }
    }
}
