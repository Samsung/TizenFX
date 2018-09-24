/*
 * Copyright(c) 2018 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Tizen.NUI
{

    /// <summary>
    /// Layers provide a mechanism for overlaying groups of actors on top of each other.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Layer : Container
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        private global::System.IntPtr rootLayoutIntPtr;
        private global::System.Runtime.InteropServices.HandleRef rootLayoutCPtr;

        internal Layer(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.Layer_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            // Create a root layout (AbsoluteLayout) that is invisible to the user but enables layouts added to this Layer.
            // Enables layouts added to the Layer to have a parent layout.  As parent layout is needed to store measure spec properties.
            rootLayoutIntPtr = NDalicManualPINVOKE.Window_NewRootLayout();
            // Store HandleRef used by Add()
            rootLayoutCPtr = new global::System.Runtime.InteropServices.HandleRef(this, rootLayoutIntPtr);
            // Add the root layout created above to this layer.
            NDalicPINVOKE.Actor_Add( swigCPtr, rootLayoutCPtr );
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Layer obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// From the Container base class.

        /// <summary>
        /// Adds a child view to this layer.
        /// </summary>
        /// <seealso cref="Container.Add">
        /// </seealso>
        /// <since_tizen> 4 </since_tizen>
        public override void Add(View child)
        {
            Container oldParent = child.GetParent();
            if (oldParent != this)
            {
                if (oldParent != null)
                {
                    oldParent.Remove(child);
                }
                else
                {
                    child.InternalParent = this;
                }

                NDalicPINVOKE.Actor_Add( rootLayoutCPtr , View.getCPtr(child));
                if (NDalicPINVOKE.SWIGPendingException.Pending)
                    throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                Children.Add(child);
            }
        }

        /// <summary>
        /// Removes a child view from this layer. If the view was not a child of this layer, this is a no-op.
        /// </summary>
        /// <seealso cref="Container.Remove">
        /// </seealso>
        /// <since_tizen> 4 </since_tizen>
        public override void Remove(View child)
        {
            NDalicPINVOKE.Actor_Remove( rootLayoutCPtr, View.getCPtr(child));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            Children.Remove(child);
            child.InternalParent = null;
        }

        /// <summary>
        /// Retrieves a child view by the index.
        /// </summary>
        /// <pre>The view has been initialized.</pre>
        /// <param name="index">The index of the child to retrieve.</param>
        /// <returns>The view for the given index or empty handle if children not initialized.</returns>
        /// <since_tizen> 4 </since_tizen>
        public override View GetChildAt(uint index)
        {
            if (index < Children.Count)
            {
                return Children[Convert.ToInt32(index)];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Get parent of the layer.
        /// </summary>
        /// <returns>The view's container</returns>
        /// <since_tizen> 4 </since_tizen>
        public override Container GetParent()
        {
            return null;
        }

        /// <summary>
        /// Get the child count of the layer.
        /// </summary>
        /// <returns>The child count of the layer.</returns>
        /// <since_tizen> 4 </since_tizen>
        public override uint GetChildCount()
        {
            return Convert.ToUInt32(Children.Count);
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// <since_tizen> 3 </since_tizen>
        public Layer() : this(NDalicPINVOKE.Layer_New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            if(Window.Instance != null)
            {
                this.SetAnchorPoint(Tizen.NUI.PivotPoint.TopLeft);
                this.SetResizePolicy(ResizePolicyType.FillToParent, DimensionType.AllDimensions);
            }
        }
        internal void SetAnchorPoint(Vector3 anchorPoint)
        {
            NDalicPINVOKE.Actor_SetAnchorPoint(swigCPtr, Vector3.getCPtr(anchorPoint));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
        internal void SetResizePolicy(ResizePolicyType policy, DimensionType dimension)
        {
            NDalicPINVOKE.Actor_SetResizePolicy(swigCPtr, (int)policy, (int)dimension);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Downcasts a handle to layer handle.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// Please do not use! this will be deprecated!
        /// Instead please use as keyword.
        [Obsolete("Please do not use! This will be deprecated! Please use as keyword instead!")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Layer DownCast(BaseHandle handle)
        {
            Layer ret =  Registry.GetManagedBaseHandleFromNativePtr(handle) as Layer;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Search through this layer's hierarchy for a view with the given unique ID.
        /// </summary>
        /// <pre>This layer (the parent) has been initialized.</pre>
        /// <remarks>The actor itself is also considered in the search.</remarks>
        /// <param name="id">The id of the child to find</param>
        /// <returns> A handle to the view if found, or an empty handle if not. </returns>
        /// <since_tizen> 3 </since_tizen>
        public View FindChildById(uint id)
        {
            //to fix memory leak issue, match the handle count with native side.
            IntPtr cPtr = NDalicPINVOKE.Actor_FindChildById(swigCPtr, id);
            HandleRef CPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            View ret = Registry.GetManagedBaseHandleFromNativePtr(CPtr.Handle) as View;
            NDalicPINVOKE.delete_BaseHandle(CPtr);
            CPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);

            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Queries the depth of the layer.<br />
        /// 0 is the bottommost layer, higher number is on the top.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public uint Depth
        {
            get
            {
                return GetDepth();
            }
        }

        internal uint GetDepth()
        {
            var parentChildren = Window.Instance.LayersChildren;
            if(parentChildren != null)
            {
                int idx = parentChildren.IndexOf(this);
                if (idx >= 0)
                {
                    return Convert.ToUInt32(idx); ;
                }
            }
            return 0u;
        }

        /// <summary>
        /// Increments the depth of the layer.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Raise()
        {
            var parentChildren = Window.Instance.LayersChildren;
            if (parentChildren != null)
            {
                int currentIdx = parentChildren.IndexOf(this);

                if (currentIdx >= 0 && currentIdx < parentChildren.Count - 1)
                {
                    var upper = parentChildren[currentIdx + 1];
                    RaiseAbove(upper);
                }
            }
        }

        /// <summary>
        /// Decrements the depth of the layer.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Lower()
        {
            var parentChildren = Window.Instance.LayersChildren;
            if (parentChildren != null)
            {
                int currentIdx = parentChildren.IndexOf(this);

                if (currentIdx > 0 && currentIdx < parentChildren.Count)
                {
                    var low = parentChildren[currentIdx - 1];
                    LowerBelow(low);
                }
            }
        }

        internal void RaiseAbove(Layer target)
        {
            var parentChildren = Window.Instance.LayersChildren;
            if (parentChildren != null)
            {
                int currentIndex = parentChildren.IndexOf(this);
                int targetIndex = parentChildren.IndexOf(target);

                if(currentIndex < 0 || targetIndex < 0 ||
                    currentIndex >= parentChildren.Count || targetIndex >= parentChildren.Count)
                {
                    NUILog.Error("index should be bigger than 0 and less than children of layer count");
                    return;
                }

                // If the currentIndex is less than the target index and the target has the same parent.
                if (currentIndex < targetIndex)
                {
                    parentChildren.Remove(this);
                    parentChildren.Insert(targetIndex, this);

                    NDalicPINVOKE.Layer_MoveAbove(swigCPtr, Layer.getCPtr(target));
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
            }
        }

        internal void LowerBelow(Layer target)
        {
            var parentChildren = Window.Instance.LayersChildren;

            if (parentChildren != null)
            {
                int currentIndex = parentChildren.IndexOf(this);
                int targetIndex = parentChildren.IndexOf(target);

                if(currentIndex < 0 || targetIndex < 0 ||
                    currentIndex >= parentChildren.Count || targetIndex >= parentChildren.Count)
                {
                    NUILog.Error("index should be bigger than 0 and less than children of layer count");
                    return;
                }

                // If the currentIndex is not already the 0th index and the target has the same parent.
                if ((currentIndex != 0) && (targetIndex != -1) &&
                    (currentIndex > targetIndex))
                {
                    parentChildren.Remove(this);
                    parentChildren.Insert(targetIndex, this);

                    NDalicPINVOKE.Layer_MoveBelow(swigCPtr, Layer.getCPtr(target));
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
            }
        }

        /// <summary>
        /// Raises the layer to the top.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void RaiseToTop()
        {
            var parentChildren = Window.Instance.LayersChildren;

            if (parentChildren != null)
            {
                parentChildren.Remove(this);
                parentChildren.Add(this);

                NDalicPINVOKE.Layer_RaiseToTop(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Lowers the layer to the bottom.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void LowerToBottom()
        {
            var parentChildren = Window.Instance.LayersChildren;

            if (parentChildren != null)
            {
                parentChildren.Remove(this);
                parentChildren.Insert(0, this);

                NDalicPINVOKE.Layer_LowerToBottom(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

        }

        /// <summary>
        /// Moves the layer directly above the given layer.<br />
        /// After the call, this layer's depth will be immediately above target.<br />
        /// </summary>
        /// <param name="target">The layer to get on top of.</param>
        /// <since_tizen> 3 </since_tizen>
        public void MoveAbove(Layer target)
        {
            NDalicPINVOKE.Layer_MoveAbove(swigCPtr, Layer.getCPtr(target));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Moves the layer directly below the given layer.<br />
        /// After the call, this layer's depth will be immediately below target.<br />
        /// </summary>
        /// <param name="target">The layer to get below of.</param>
        /// <since_tizen> 3 </since_tizen>
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

        internal void AddViewToLayerList( View view )
        {
            Children.Add(view);
        }

        internal void RemoveViewFromLayerList( View view )
        {
            Children.Remove(view);
        }

        /// <summary>
        /// Enumeration for the behavior of the layer.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum LayerBehavior
        {
            /// <summary>
            /// UI control rendering mode.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Layer2D,
            /// <summary>
            /// UI control rendering mode (default mode).
            /// This mode is designed for UI controls that can overlap. In this
            /// mode renderer order will be respective to the tree hierarchy of
            /// Actors.<br />
            /// The rendering order is depth first, so for the following actor tree,
            /// A will be drawn first, then B, D, E, then C, F.  This ensures that
            /// overlapping actors are drawn as expected (whereas, with breadth first
            /// traversal, the actors would interleave).<br />
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            LayerUI = Layer2D,
            /// <summary>
            /// Layer will use depth test.
            /// This mode is designed for a 3 dimensional scene where actors in front
            /// of other actors will obscure them, i.e. the actors are sorted by the
            /// distance from the camera.<br />
            /// When using this mode, a depth test will be used. A depth clear will
            /// happen for each layer, which means actors in a layer "above" other
            /// layers will be rendered in front of actors in those layers regardless
            /// of their Z positions (see Layer::Raise() and Layer::Lower()).<br />
            /// Opaque renderers are drawn first and write to the depth buffer.  Then
            /// transparent renderers are drawn with depth test enabled but depth
            /// write switched off.  Transparent renderers are drawn based on their
            /// distance from the camera.  A renderer's DEPTH_INDEX property is used to
            /// offset the distance to the camera when ordering transparent renderers.
            /// This is useful if you want to define the draw order of two or more
            /// transparent renderers that are equal distance from the camera.  Unlike
            /// LAYER_UI, parent-child relationship does not affect rendering order at
            /// all.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Layer3D
        }

        internal enum TreeDepthMultiplier
        {
            TREE_DEPTH_MULTIPLIER = 10000
        }

        /// <summary>
        /// Layer behavior, type String (Layer.LayerBehavior).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Internal only property to enable or disable clipping, type boolean.
        /// By default, this is false, i.e., the viewport of the layer is the entire window.
        /// </summary>
        internal bool ClippingEnabled
        {
            get
            {
                bool ret = NDalicPINVOKE.Layer_IsClipping(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
            set
            {
                NDalicPINVOKE.Layer_SetClipping(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Sets the viewport (in window coordinates), type rectangle.
        /// The contents of the layer will not be visible outside this box, when ViewportEnabled is true.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public Rectangle Viewport
        {
            get
            {
                if( ClippingEnabled )
                {
                  Rectangle ret = new Rectangle(NDalicPINVOKE.Layer_GetClippingBox(swigCPtr), true);
                  if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                  return ret;
                }
                else
                {
                  // Clipping not enabled so return the window size
                  Size2D windowSize = Window.Instance.Size;
                  Rectangle ret = new Rectangle(0, 0, windowSize.Width, windowSize.Height);
                  return ret;
                }
            }
            set
            {
                NDalicPINVOKE.Layer_SetClippingBox__SWIG_1(swigCPtr, Rectangle.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                ClippingEnabled = true;
            }
        }

        /// <summary>
        /// Retrieves and sets the layer's opacity.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Retrieves and sets the layer's visibility.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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

        /// <summary>
        /// Get the number of children held by the layer.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public new uint ChildCount
        {
            get
            {
                return Convert.ToUInt32(Children.Count);
            }
        }

        /// <summary>
        /// Gets or sets the layer's name.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Name
        {
            get
            {
                return GetName();
            }
            set
            {
                SetName(value);
            }
        }

        internal string GetName()
        {
            string ret = NDalicPINVOKE.Actor_GetName(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetName(string name)
        {
            NDalicPINVOKE.Actor_SetName(swigCPtr, name);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

    }
}