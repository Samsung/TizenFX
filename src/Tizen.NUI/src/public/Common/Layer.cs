/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    /// <summary>
    /// Layers provide a mechanism for overlaying groups of actors on top of each other.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Layer : Container
    {
        private Window window;
        private int layoutCount;

        private EventHandler<VisibilityChangedEventArgs> visibilityChangedEventHandler;
        private VisibilityChangedEventCallbackType visibilityChangedEventCallback;

        private EventHandler<AggregatedVisibilityChangedEventArgs> aggregatedVisibilityChangedEventHandler;
        private AggregatedVisibilityChangedEventCallbackType aggregatedVisibilityChangedEventCallback;

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VisibilityChangedEventCallbackType(IntPtr data, bool visibility, VisibilityChangeType type);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void AggregatedVisibilityChangedEventCallbackType(IntPtr data, bool visibility);

        private static int aliveCount;

        /// <summary>
        /// Default constructor of Layer class to create a Layer object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Layer() : this(Interop.Layer.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            this.SetAnchorPoint(Tizen.NUI.PivotPoint.TopLeft);
            this.SetResizePolicy(ResizePolicyType.FillToParent, DimensionType.AllDimensions);
        }

        internal Layer(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
            ++aliveCount;
        }

        /// <summary>
        /// Dispose.
        /// Releases unmanaged and optionally managed resources.
        /// </summary>
        /// <remarks>
        /// When overriding this method, you need to distinguish between explicit and implicit conditions. For explicit conditions, release both managed and unmanaged resources. For implicit conditions, only release unmanaged resources.
        /// </remarks>
        /// <param name="type">Explicit to release both managed and unmanaged resources. Implicit to release only unmanaged resources.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (Disposed)
            {
                return;
            }

            if (visibilityChangedEventCallback != null)
            {
                NUILog.Debug($"[Dispose] visibilityChangedEventCallback");

                Interop.ActorSignal.VisibilityChangedDisconnect(GetBaseHandleCPtrHandleRef, visibilityChangedEventCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExistsDebug();
                visibilityChangedEventCallback = null;
            }

            if (aggregatedVisibilityChangedEventCallback != null)
            {
                NUILog.Debug($"[Dispose] aggregatedVisibilityChangedEventCallback");

                Interop.ActorSignal.AggregatedVisibilityChangedDisconnect(GetBaseHandleCPtrHandleRef, aggregatedVisibilityChangedEventCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExistsDebug();
                aggregatedVisibilityChangedEventCallback = null;
            }

            LayoutCount = 0;

            --aliveCount;

            base.Dispose(type);
        }

        /// <summary>
        /// Enumeration for the behavior of the layer.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum LayerBehavior
        {
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
            LayerUI,

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
        /// Sets the viewport (in window coordinates), type rectangle.
        /// The contents of the layer will not be visible outside this box, when ViewportEnabled is true.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public Rectangle Viewport
        {
            get
            {
                if (ClippingEnabled)
                {
                    Rectangle ret = new Rectangle(Interop.Layer.GetClippingBox(SwigCPtr), true);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                    return ret;
                }
                else
                {
                    // Clipping not enabled so return the window size
                    Size2D windowSize = window?.Size;
                    Rectangle ret = new Rectangle(0, 0, windowSize.Width, windowSize.Height);
                    return ret;
                }
            }
            set
            {
                Interop.Layer.SetClippingBox(SwigCPtr, Rectangle.getCPtr(value));
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
                var pValue = GetProperty(View.Property.OPACITY);
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                SetProperty(View.Property.OPACITY, temp);
                temp.Dispose();
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
                var pValue = GetProperty(View.Property.VISIBLE);
                pValue.Get(out temp);
                pValue.Dispose();
                return temp;
            }
            set
            {
                var temp = new Tizen.NUI.PropertyValue(value);
                SetProperty(View.Property.VISIBLE, temp);
                temp.Dispose();
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

        /// <summary>
        /// Internal only property to enable or disable clipping, type boolean.
        /// By default, this is false, i.e., the viewport of the layer is the entire window.
        /// </summary>
        internal bool ClippingEnabled
        {
            get
            {
                bool ret = Interop.Layer.IsClipping(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
            set
            {
                Interop.Layer.SetClipping(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Gets the Layer's ID
        /// Readonly
        /// </summary>
        /// <remarks>Hidden-API</remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint ID
        {
            get
            {
                return GetId();
            }
        }

        /// <summary>
        /// Gets of sets the flag to identify the Layer will be ignored or not.
        /// If the Layer is marked as ignored, it will not be rendered and will be excluded from render thread computation.
        /// So, the render thread properties like WorldPosition and WorldColor become inaccurate.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Ignored
        {
            set => SetInternalIgnored(value);
            get => IsInternalIgnored();
        }

        /// <summary>
        /// Gets the number of currently alived Layer object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int AliveCount => aliveCount;

        private void SetInternalIgnored(bool ignored)
        {
            Interop.Actor.SetIgnored(SwigCPtr, ignored);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private bool IsInternalIgnored()
        {
            bool isIgnored = Interop.Actor.IsIgnored(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return isIgnored;
        }


        /// From the Container base class.

        /// <summary>
        /// Adds a child view to this layer.
        /// </summary>
        /// <seealso cref="Container.Add">
        /// </seealso>
        /// <exception cref="ArgumentNullException"> Thrown when child is null. </exception>
        /// <since_tizen> 4 </since_tizen>
        public override void Add(View child)
        {
            if (null == child)
            {
                throw new ArgumentNullException(nameof(child));
            }

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

                LayoutCount += child.LayoutCount;

                Interop.Actor.Add(SwigCPtr, View.getCPtr(child));
                if (NDalicPINVOKE.SWIGPendingException.Pending)
                    throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                Children.Add(child);
                OnChildAdded(child);
            }
        }

        /// <summary>
        /// Removes a child view from this layer. If the view was not a child of this layer, this is a no-op.
        /// </summary>
        /// <seealso cref="Container.Remove">
        /// </seealso>
        /// <exception cref="ArgumentNullException"> Thrown when child is null. </exception>
        /// <since_tizen> 4 </since_tizen>
        public override void Remove(View child)
        {
            if (null == child)
            {
                throw new ArgumentNullException(nameof(child));
            }
            if (child.GetParent() == null) // Early out if child parent is null.
                return;

            if (child.GetParent() != this)
            {
                //throw new System.InvalidOperationException("You have deleted a view that is not a child of this layer.");
                Tizen.Log.Error("NUI", "You have deleted a view that is not a child of this layer.");
                return;
            }
            Interop.Actor.Remove(SwigCPtr, View.getCPtr(child));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            Children.Remove(child);
            child.InternalParent = null;
            OnChildRemoved(child);
            LayoutCount -= child.LayoutCount;
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
        [Obsolete("This has been deprecated in API9 and will be removed in API11. Use ChildCount property instead")]
        public override uint GetChildCount()
        {
            return Convert.ToUInt32(Children.Count);
        }

        /// <summary>
        /// Downcasts a handle to layer handle.
        /// </summary>
        /// <exception cref="ArgumentNullException"> Thrown when handle is null. </exception>
        /// <since_tizen> 3 </since_tizen>
        /// Do not use this, that will be deprecated. Use as keyword instead.
        [Obsolete("Do not use this, that will be deprecated. Use as keyword instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Layer DownCast(BaseHandle handle)
        {
            if (null == handle)
            {
                throw new ArgumentNullException(nameof(handle));
            }
            Layer ret = Registry.GetManagedBaseHandleFromNativePtr(handle) as Layer;
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
            IntPtr cPtr = Interop.Actor.FindChildById(SwigCPtr, id);
            View ret = this.GetInstanceSafely<View>(cPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal override View FindCurrentChildById(uint id)
        {
            return FindChildById(id);
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View FindChildByName(string viewName)
        {
            //to fix memory leak issue, match the handle count with native side.
            IntPtr cPtr = Interop.Actor.FindChildByName(SwigCPtr, viewName);
            View ret = this.GetInstanceSafely<View>(cPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Increments the depth of the layer.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Method used to raise the object, not event")]
        public void Raise()
        {
            var parentChildren = window?.LayersChildren;
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
            var parentChildren = window?.LayersChildren;
            if (parentChildren != null)
            {
                int currentIdx = parentChildren.IndexOf(this);
                int idx = window.IsBorderEnabled ? 1 : 0;

                if (currentIdx > idx && currentIdx < parentChildren.Count)
                {
                    var low = parentChildren[currentIdx - 1];
                    LowerBelow(low);
                }
            }
        }

        /// <summary>
        /// Raises the layer to the top.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Method used to raise the object, not event")]
        public void RaiseToTop()
        {
            var parentChildren = window?.LayersChildren;

            if (parentChildren != null)
            {
                parentChildren.Remove(this);
                parentChildren.Add(this);

                Interop.Layer.RaiseToTop(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Lowers the layer to the bottom.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void LowerToBottom()
        {
            var parentChildren = window?.LayersChildren;

            if (parentChildren != null)
            {
                parentChildren.Remove(this);
                parentChildren.Insert(0, this);

                Interop.Layer.LowerToBottom(SwigCPtr);

                if (window.IsBorderEnabled)
                {
                    Layer bottomLayer = window.GetBorderWindowBottomLayer();
                    parentChildren.Remove(bottomLayer);
                    parentChildren.Insert(0, bottomLayer);
                    Interop.Layer.LowerToBottom(Layer.getCPtr(bottomLayer));
                }
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
            RaiseAbove(target);
        }

        /// <summary>
        /// Moves the layer directly below the given layer.<br />
        /// After the call, this layer's depth will be immediately below target.<br />
        /// </summary>
        /// <param name="target">The layer to get below of.</param>
        /// <since_tizen> 3 </since_tizen>
        public void MoveBelow(Layer target)
        {
            LowerBelow(target);
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetAnchorPoint(Vector3 anchorPoint)
        {
            Interop.Actor.SetAnchorPoint(SwigCPtr, Vector3.getCPtr(anchorPoint));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetSize(float width, float height)
        {
            Interop.ActorInternal.SetSize(SwigCPtr, width, height);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetParentOrigin(Vector3 parentOrigin)
        {
            Interop.ActorInternal.SetParentOrigin(SwigCPtr, Vector3.getCPtr(parentOrigin));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetResizePolicy(ResizePolicyType policy, DimensionType dimension)
        {
            Interop.Actor.SetResizePolicy(SwigCPtr, (int)policy, (int)dimension);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Inhouse API.
        /// This allows the user to specify whether this layer should consume touch (including gestures).
        /// If set, any layers behind this layer will not be hit-test.
        /// </summary>
        /// <param name="consume">Whether the layer should consume touch (including gestures).</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetTouchConsumed(bool consume)
        {
            Interop.Layer.SetTouchConsumed(SwigCPtr, consume);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Inhouse API.
        /// This allows the user to specify whether this layer should consume hover.
        /// If set, any layers behind this layer will not be hit-test.
        /// </summary>
        /// <param name="consume">Whether the layer should consume hover</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetHoverConsumed(bool consume)
        {
            Interop.Layer.SetHoverConsumed(SwigCPtr, consume);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// An event for visibility change which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when the visible property of this or a parent view is changed.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<VisibilityChangedEventArgs> VisibilityChanged
        {
            add
            {
                if (visibilityChangedEventHandler == null)
                {
                    visibilityChangedEventCallback = OnVisibilityChanged;
                    Interop.ActorSignal.VisibilityChangedConnect(SwigCPtr, visibilityChangedEventCallback.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                }
                visibilityChangedEventHandler += value;
            }

            remove
            {
                visibilityChangedEventHandler -= value;
                if (visibilityChangedEventHandler == null && visibilityChangedEventCallback != null)
                {
                    Interop.ActorSignal.VisibilityChangedDisconnect(SwigCPtr, visibilityChangedEventCallback.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                    visibilityChangedEventCallback = null;
                }
            }
        }
        /// <summary>
        /// An event for aggregated visibility change which can be used to subscribe or unsubscribe the event handler.<br />
        /// This event is sent when visible property of this or any of its parents (right up to the root) and Window changes.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<AggregatedVisibilityChangedEventArgs> AggregatedVisibilityChanged
        {
            add
            {
                if (aggregatedVisibilityChangedEventHandler == null)
                {
                    aggregatedVisibilityChangedEventCallback = OnAggregatedVisibilityChanged;
                    Interop.ActorSignal.AggregatedVisibilityChangedConnect(SwigCPtr, aggregatedVisibilityChangedEventCallback.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                }
                aggregatedVisibilityChangedEventHandler += value;
            }

            remove
            {
                aggregatedVisibilityChangedEventHandler -= value;
                if (aggregatedVisibilityChangedEventHandler == null && aggregatedVisibilityChangedEventCallback != null)
                {
                    Interop.ActorSignal.AggregatedVisibilityChangedDisconnect(SwigCPtr, aggregatedVisibilityChangedEventCallback.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                    aggregatedVisibilityChangedEventCallback = null;
                }
            }
        }

        /// <summary>
        /// Event arguments of visibility changed.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class VisibilityChangedEventArgs : EventArgs
        {
            private Layer layer;
            private bool visibility;

            /// <summary>
            /// The layer whose visibility has changed.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Layer Layer
            {
                get
                {
                    return layer;
                }
                set
                {
                    layer = value;
                }
            }

            /// <summary>
            /// Whether the layer is now visible or not.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool Visibility
            {
                get
                {
                    return visibility;
                }
                set
                {
                    visibility = value;
                }
            }
        }

        internal uint GetDepth()
        {
            var parentChildren = window?.LayersChildren;
            if (parentChildren != null)
            {
                int idx = parentChildren.IndexOf(this);
                if (idx >= 0)
                {
                    return Convert.ToUInt32(idx); ;
                }
            }
            return 0u;
        }
        internal void RaiseAbove(Layer target)
        {
            var parentChildren = window?.LayersChildren;
            if (parentChildren != null)
            {
                int currentIndex = parentChildren.IndexOf(this);
                int targetIndex = parentChildren.IndexOf(target);

                if (currentIndex < 0 || targetIndex < 0 ||
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

                    Interop.Layer.MoveAbove(SwigCPtr, Layer.getCPtr(target));
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
            }
        }

        internal void LowerBelow(Layer target)
        {
            var parentChildren = window?.LayersChildren;

            if (parentChildren != null)
            {
                int currentIndex = parentChildren.IndexOf(this);
                int targetIndex = parentChildren.IndexOf(target);

                if (currentIndex < 0 || targetIndex < 0 ||
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

                    Interop.Layer.MoveBelow(SwigCPtr, Layer.getCPtr(target));
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
            }
        }


        internal bool IsTouchConsumed()
        {
            bool ret = Interop.Layer.IsTouchConsumed(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
        internal bool IsHoverConsumed()
        {
            bool ret = Interop.Layer.IsHoverConsumed(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void AddViewToLayerList(View view)
        {
            Children.Add(view);
        }

        internal void RemoveViewFromLayerList(View view)
        {
            Children.Remove(view);
        }

        internal string GetName()
        {
            string ret = Interop.Actor.GetName(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetName(string name)
        {
            Interop.Actor.SetName(SwigCPtr, name);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetWindow(Window win)
        {
            if (window == win) return;

            if (window != null)
            {
                window.LayoutController.LayoutCount -= LayoutCount;
            }

            window = win;

            if (window != null)
            {
                window.LayoutController.LayoutCount += LayoutCount;
            }
        }

        internal uint GetId()
        {
            uint ret = Interop.Actor.GetId(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// The number of layouts of children views.
        /// This can be used to set/unset Process callback to calculate Layout.
        /// </summary>
        internal int LayoutCount
        {
            get
            {
                return layoutCount;
            }

            set
            {
                if (layoutCount == value) return;

                if (value < 0) throw new global::System.ArgumentOutOfRangeException(nameof(LayoutCount), "LayoutCount(" + LayoutCount + ") should not be less than zero");

                if (window != null)
                {
                    int diff = value - layoutCount;
                    window.LayoutController.LayoutCount += diff;
                }
                layoutCount = value;
            }
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Layer.DeleteLayer(swigCPtr);
        }

        private void SetBehavior(LayerBehavior behavior)
        {
            Interop.Layer.SetBehavior(SwigCPtr, (int)behavior);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private LayerBehavior GetBehavior()
        {
            Layer.LayerBehavior ret = (Layer.LayerBehavior)Interop.Layer.GetBehavior(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal class Property
        {
            internal static readonly int BEHAVIOR = Interop.Layer.BehaviorGet();
        }

        // Callback for View visibility change signal
        // type is not used because layer does not have parent so layer's visibility cannot be changed by its parent.
        private void OnVisibilityChanged(IntPtr data, bool visibility, VisibilityChangeType type)
        {
            VisibilityChangedEventArgs e = new VisibilityChangedEventArgs();
            if (data != IntPtr.Zero)
            {
                e.Layer = Registry.GetManagedBaseHandleFromNativePtr(data) as Layer;
            }
            e.Visibility = visibility;

            if (visibilityChangedEventHandler != null)
            {
                visibilityChangedEventHandler(this, e);
            }
        }

        // Callback for Layer aggregated visibility change signal
        private void OnAggregatedVisibilityChanged(IntPtr data, bool visibility)
        {
            AggregatedVisibilityChangedEventArgs e = new AggregatedVisibilityChangedEventArgs();
            e.Visibility = visibility;

            if (aggregatedVisibilityChangedEventHandler != null)
            {
                aggregatedVisibilityChangedEventHandler(this, e);
            }
        }
    }
}
