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

namespace Tizen.NUI
{
    /// <summary>
    /// A condition that can be evaluated on a Property Value
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class PropertyCondition : BaseHandle
    {

        /// <summary>
        /// Create a property condition instance.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public PropertyCondition() : this(Interop.PropertyCondition.NewPropertyCondition(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PropertyCondition(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Retrieves the arguments that this condition uses.
        /// </summary>
        /// <returns>The arguments used for this condition.</returns>
        /// <since_tizen> 4 </since_tizen>
        public uint GetArgumentCount()
        {
            uint ret = Interop.PropertyCondition.GetArgumentCount(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves the arguments that this condition uses
        /// </summary>
        /// <param name="index">The condition index to get the argument.</param>
        /// <returns>The arguments used for this condition.</returns>
        /// <since_tizen> 4 </since_tizen>
        public float GetArgument(uint index)
        {
            float ret = Interop.PropertyCondition.GetArgument(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// LessThan condition compares whether property is less than arg.
        /// </summary>
        /// <param name="arg">The argument for the condition.</param>
        /// <returns>A property condition function object.</returns>
        /// <since_tizen> 4 </since_tizen>
        public static PropertyCondition LessThan(float arg)
        {
            PropertyCondition ret = new PropertyCondition(Interop.PropertyCondition.LessThanCondition(arg), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// GreaterThan condition compares whether property is greater than arg.
        /// </summary>
        /// <param name="arg">The argument for the condition.</param>
        /// <returns>A property condition function object.</returns>
        /// <since_tizen> 4 </since_tizen>
        public static PropertyCondition GreaterThan(float arg)
        {
            PropertyCondition ret = new PropertyCondition(Interop.PropertyCondition.GreaterThanCondition(arg), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Inside condition compares whether property is greater than arg0 and less than arg1.
        /// </summary>
        /// <param name="arg0">The first argument for the condition.</param>
        /// <param name="arg1">The second argument for the condition.</param>
        /// <returns>A property condition function object.</returns>
        /// <since_tizen> 4 </since_tizen>
        public static PropertyCondition Inside(float arg0, float arg1)
        {
            PropertyCondition ret = new PropertyCondition(Interop.PropertyCondition.InsideCondition(arg0, arg1), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Outside condition compares whether property is less than arg0 or greater than arg1
        /// </summary>
        /// <param name="arg0">The first argument for the condition.</param>
        /// <param name="arg1">The second argument for the condition.</param>
        /// <returns>A property condition function object.</returns>
        /// <since_tizen> 4 </since_tizen>
        public static PropertyCondition Outside(float arg0, float arg1)
        {
            PropertyCondition ret = new PropertyCondition(Interop.PropertyCondition.OutsideCondition(arg0, arg1), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Detects when a property changes by stepAmount from initialValue, in both positive and negative directions. This will continue checking for multiples of stepAmount.
        /// </summary>
        /// <param name="stepAmount">The step size required to trigger condition.</param>
        /// <param name="initialValue">The initial value to step from.</param>
        /// <returns>A property condition function object.</returns>
        /// <since_tizen> 4 </since_tizen>
        public static PropertyCondition Step(float stepAmount, float initialValue)
        {
            PropertyCondition ret = new PropertyCondition(Interop.PropertyCondition.StepCondition(stepAmount, initialValue), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Receives notifications as a property goes above/below the inputted values. Values must be ordered and can be either ascending or descending.
        /// </summary>
        /// <param name="stepAmount">List of values to receive notifications for as a property crosses them.</param>
        /// <returns>A property condition function object.</returns>
        /// <since_tizen> 4 </since_tizen>
        public static PropertyCondition Step(float stepAmount)
        {
            PropertyCondition ret = new PropertyCondition(Interop.PropertyCondition.StepCondition(stepAmount), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(PropertyCondition obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.PropertyCondition.DeletePropertyCondition(swigCPtr);
        }
    }
}
