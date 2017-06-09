/** Copyright (c) 2017 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    using Tizen.NUI.BaseComponents;

    /// <summary>
    /// Layers provide a mechanism for overlaying groups of actors on top of each other.
    /// </summary>
    public class Layer : Animatable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal Layer(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.Layer_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Layer obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

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

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    NDalicPINVOKE.delete_Layer(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }


        internal class Property
        {
            internal static readonly int BEHAVIOR = NDalicPINVOKE.Layer_Property_BEHAVIOR_get();
        }

        /// <summary>
        /// Creates a Layer object.
        /// </summary>
        public Layer() : this(NDalicPINVOKE.Layer_New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }
        /// <summary>
        /// Downcasts a handle to Layer handle.<br>
        /// If handle points to a Layer, the downcast produces valid handle.<br>
        /// If not, the returned handle is left uninitialized.<br>
        /// </summary>
        /// <param name="handle">Handle to an object</param>
        /// <returns>Handle to a Layer or an uninitialized handle</returns>
        internal new static Layer DownCast(BaseHandle handle)
        {
            Layer ret = new Layer(NDalicPINVOKE.Layer_DownCast(BaseHandle.getCPtr(handle)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Search through this layer's hierarchy for an view with the given unique ID.
        /// </summary>
        /// <pre>This layer(the parent) has been initialized.</pre>
        /// <remarks>The actor itself is also considered in the search.</remarks>
        /// <param name="child">The id of the child to find</param>
        /// <returns> A handle to the view if found, or an empty handle if not. </returns>
        public View FindChildById(uint id)
        {
            View ret = new View(NDalicPINVOKE.Actor_FindChildById(swigCPtr, id), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Adds a child view to this layer.
        /// </summary>
        /// <pre>This layer(the parent) has been initialized. The child view has been initialized. The child view is not the same as the parent layer.</pre>
        /// <post>The child will be referenced by its parent. This means that the child will be kept alive, even if the handle passed into this method is reset or destroyed.</post>
        /// <remarks>If the child already has a parent, it will be removed from old parent and reparented to this layer. This may change child's position, color, scale etc as it now inherits them from this layer.</remarks>
        /// <param name="child">The child</param>
        public void Add(View child)
        {
            NDalicPINVOKE.Actor_Add(swigCPtr, View.getCPtr(child));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Removes a child View from this layer. If the view was not a child of this layer, this is a no-op.
        /// </summary>
        /// <pre>This layer(the parent) has been initialized. The child view is not the same as the parent view.</pre>
        /// <param name="child">The child</param>
        public void Remove(View child)
        {
            NDalicPINVOKE.Actor_Remove(swigCPtr, View.getCPtr(child));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Queries the depth of the layer.<br>
        /// 0 is the bottom most layer, higher number is on top.<br>
        /// </summary>
        public uint Depth
        {
            get
            {
                return GetDepth();
            }
        }

        internal uint GetDepth()
        {
            uint ret = NDalicPINVOKE.Layer_GetDepth(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Increments the depth of the layer.
        /// </summary>
        public void Raise()
        {
            NDalicPINVOKE.Layer_Raise(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Decrements the depth of the layer.
        /// </summary>
        public void Lower()
        {
            NDalicPINVOKE.Layer_Lower(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void RaiseAbove(Layer target)
        {
            NDalicPINVOKE.Layer_RaiseAbove(swigCPtr, Layer.getCPtr(target));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void LowerBelow(Layer target)
        {
            NDalicPINVOKE.Layer_LowerBelow(swigCPtr, Layer.getCPtr(target));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Raises the layer to the top.
        /// </summary>
        public void RaiseToTop()
        {
            NDalicPINVOKE.Layer_RaiseToTop(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Lowers the layer to the bottom.
        /// </summary>
        public void LowerToBottom()
        {
            NDalicPINVOKE.Layer_LowerToBottom(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Moves the layer directly above the given layer.<br>
        /// After the call, this layers depth will be immediately above target.<br>
        /// </summary>
        /// <param name="target">Layer to get on top of</param>
        public void MoveAbove(Layer target)
        {
            NDalicPINVOKE.Layer_MoveAbove(swigCPtr, Layer.getCPtr(target));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Moves the layer directly below the given layer.<br>
        /// After the call, this layers depth will be immediately below target.<br>
        /// </summary>
        /// <param name="target">Layer to get below of</param>
        public void MoveBelow(Layer target)
        {
            NDalicPINVOKE.Layer_MoveBelow(swigCPtr, Layer.getCPtr(target));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private void SetBehavior(LayerBehavior behavior)
        {
            NDalicPINVOKE.Layer_SetBehavior(swigCPtr, (int)behavior);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private LayerBehavior GetBehavior()
        {
            Layer.LayerBehavior ret = (Layer.LayerBehavior)NDalicPINVOKE.Layer_GetBehavior(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetSortFunction(SWIGTYPE_p_f_r_q_const__Dali__Vector3__float function)
        {
            NDalicPINVOKE.Layer_SetSortFunction(swigCPtr, SWIGTYPE_p_f_r_q_const__Dali__Vector3__float.getCPtr(function));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetTouchConsumed(bool consume)
        {
            NDalicPINVOKE.Layer_SetTouchConsumed(swigCPtr, consume);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal bool IsTouchConsumed()
        {
            bool ret = NDalicPINVOKE.Layer_IsTouchConsumed(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetHoverConsumed(bool consume)
        {
            NDalicPINVOKE.Layer_SetHoverConsumed(swigCPtr, consume);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal bool IsHoverConsumed()
        {
            bool ret = NDalicPINVOKE.Layer_IsHoverConsumed(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves child view by index.
        /// </summary>
        /// <pre>The View has been initialized.</pre>
        /// <param name="index">The index of the child to retrieve</param>
        /// <returns>The view for the given index or empty handle if children not initialized</returns>
        public View GetChildAt(uint index)
        {
            System.IntPtr cPtr = NDalicPINVOKE.Actor_GetChildAt(swigCPtr, index);
            cPtr = NDalicPINVOKE.View_SWIGUpcast(cPtr);
            cPtr = NDalicPINVOKE.Handle_SWIGUpcast(cPtr);

            BaseHandle ret = new BaseHandle(cPtr, false);

            View temp = ViewRegistry.GetViewFromBaseHandle(ret);

            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            return temp ?? null;
        }

        /// <summary>
        /// Enumeration for the behavior of the layer.
        /// </summary>
        public enum LayerBehavior
        {
            Layer2D,
            LayerUI = Layer2D,
            Layer3D
        }

        internal enum TreeDepthMultiplier
        {
            TREE_DEPTH_MULTIPLIER = 10000
        }

        /// <summary>
        /// Layer Behavior, type String(Layer.LayerBehavior)
        /// </summary>
        public Layer.LayerBehavior Behavior
        {
            get
            {
                return GetBehavior();
            }
            set
            {
                SetBehavior(value);
            }
        }

        /// <summary>
        /// Retrieves and sets the Layer's opacity.<br>
        /// </summary>
        public float Opacity
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.OPACITY).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.OPACITY, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Retrieves and sets the Layer's visibility.
        /// </summary>
        public bool Visibility
        {
            get
            {
                bool temp = false;
                GetProperty(View.Property.VISIBLE).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.VISIBLE, new Tizen.NUI.PropertyValue(value));
            }
        }
    }
}
