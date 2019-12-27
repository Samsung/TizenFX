/*
 * Copyright 2019 by its authors. See AUTHORS.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
namespace CoreUI.UI {
    /// <summary>This widget displays a list of items in an arrangement controlled by an external <see cref="CoreUI.UI.Collection.PositionManager"/> object. By using different <see cref="CoreUI.UI.Collection.PositionManager"/> objects this widget can show unidimensional lists or two-dimensional grids of items, for example.
    /// 
    /// This class is intended to act as a base for widgets like <see cref="CoreUI.UI.List"/> or <see cref="CoreUI.UI.Grid"/>, which hide this complexity from the user.
    /// 
    /// Items are added using the <see cref="CoreUI.IPackLinear"/> interface and must be of <see cref="CoreUI.UI.Item"/> type.
    /// 
    /// The direction of the arrangement can be controlled through <see cref="CoreUI.UI.ILayoutOrientable.Orientation"/>.
    /// 
    /// If all items do not fit in the current widget size scrolling facilities are provided.
    /// 
    /// Items inside this widget can be selected according to the <see cref="CoreUI.UI.IMultiSelectable.SelectMode"/> policy, and the selection can be retrieved with <see cref="CoreUI.UI.IMultiSelectableObjectRange.NewSelectedIterator"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.Collection.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public class Collection : CoreUI.UI.LayoutBase, CoreUI.IPack, CoreUI.IPackLinear, CoreUI.UI.ILayoutOrientable, CoreUI.UI.IMultiSelectable, CoreUI.UI.IMultiSelectableObjectRange, CoreUI.UI.IScrollable, CoreUI.UI.IScrollBar, CoreUI.UI.ISingleSelectable
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(Collection))
                {
                    return GetCoreUIClassStatic();
                }
                else
                {
                    return CoreUI.Wrapper.ClassRegister.klassFromType[((object)this).GetType()];
                }
            }
        }

        [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Elementary)] internal static extern System.IntPtr
            efl_ui_collection_class_get();

        /// <summary>Initializes a new instance of the <see cref="Collection"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="CoreUI.UI.Widget.SetStyle" /></param>
        public Collection(CoreUI.Object parent, System.String style = null) : base(efl_ui_collection_class_get(), parent)
        {
            if (CoreUI.Wrapper.Globals.ParamHelperCheck(style))
            {
                SetStyle(CoreUI.Wrapper.Globals.GetParamHelper(style));
            }

            FinishInstantiation();
        }

        /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
        /// Do not call this constructor directly.
        /// </summary>
        /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
        protected Collection(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Collection"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal Collection(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Collection"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected Collection(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }


        /// <summary>Called when scroll operation starts.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler ScrollStarted
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_UI_EVENT_SCROLL_STARTED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_EVENT_SCROLL_STARTED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event ScrollStarted.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnScrollStarted()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_EVENT_SCROLL_STARTED", IntPtr.Zero, null);
        }

        /// <summary>Called when scrolling.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler ScrollChanged
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_UI_EVENT_SCROLL_CHANGED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_EVENT_SCROLL_CHANGED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event ScrollChanged.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnScrollChanged()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_EVENT_SCROLL_CHANGED", IntPtr.Zero, null);
        }

        /// <summary>Called when scroll operation finishes.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler ScrollFinished
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_UI_EVENT_SCROLL_FINISHED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_EVENT_SCROLL_FINISHED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event ScrollFinished.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnScrollFinished()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_EVENT_SCROLL_FINISHED", IntPtr.Zero, null);
        }

        /// <summary>Called when scrolling upwards.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler ScrollUp
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_UI_EVENT_SCROLL_UP";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_EVENT_SCROLL_UP";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event ScrollUp.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnScrollUp()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_EVENT_SCROLL_UP", IntPtr.Zero, null);
        }

        /// <summary>Called when scrolling downwards.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler ScrollDown
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_UI_EVENT_SCROLL_DOWN";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_EVENT_SCROLL_DOWN";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event ScrollDown.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnScrollDown()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_EVENT_SCROLL_DOWN", IntPtr.Zero, null);
        }

        /// <summary>Called when scrolling left.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler ScrollLeft
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_UI_EVENT_SCROLL_LEFT";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_EVENT_SCROLL_LEFT";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event ScrollLeft.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnScrollLeft()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_EVENT_SCROLL_LEFT", IntPtr.Zero, null);
        }

        /// <summary>Called when scrolling right.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler ScrollRight
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_UI_EVENT_SCROLL_RIGHT";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_EVENT_SCROLL_RIGHT";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event ScrollRight.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnScrollRight()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_EVENT_SCROLL_RIGHT", IntPtr.Zero, null);
        }

        /// <summary>Called when hitting the top edge.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler EdgeUp
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_UI_EVENT_EDGE_UP";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_EVENT_EDGE_UP";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event EdgeUp.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnEdgeUp()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_EVENT_EDGE_UP", IntPtr.Zero, null);
        }

        /// <summary>Called when hitting the bottom edge.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler EdgeDown
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_UI_EVENT_EDGE_DOWN";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_EVENT_EDGE_DOWN";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event EdgeDown.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnEdgeDown()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_EVENT_EDGE_DOWN", IntPtr.Zero, null);
        }

        /// <summary>Called when hitting the left edge.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler EdgeLeft
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_UI_EVENT_EDGE_LEFT";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_EVENT_EDGE_LEFT";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event EdgeLeft.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnEdgeLeft()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_EVENT_EDGE_LEFT", IntPtr.Zero, null);
        }

        /// <summary>Called when hitting the right edge.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler EdgeRight
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_UI_EVENT_EDGE_RIGHT";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_EVENT_EDGE_RIGHT";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event EdgeRight.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnEdgeRight()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_EVENT_EDGE_RIGHT", IntPtr.Zero, null);
        }

        /// <summary>Called when scroll animation starts.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler ScrollAnimStarted
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_UI_EVENT_SCROLL_ANIM_STARTED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_EVENT_SCROLL_ANIM_STARTED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event ScrollAnimStarted.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnScrollAnimStarted()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_EVENT_SCROLL_ANIM_STARTED", IntPtr.Zero, null);
        }

        /// <summary>Called when scroll animation finishes.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler ScrollAnimFinished
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_UI_EVENT_SCROLL_ANIM_FINISHED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_EVENT_SCROLL_ANIM_FINISHED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event ScrollAnimFinished.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnScrollAnimFinished()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_EVENT_SCROLL_ANIM_FINISHED", IntPtr.Zero, null);
        }

        /// <summary>Called when scroll drag starts.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler ScrollDragStarted
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_UI_EVENT_SCROLL_DRAG_STARTED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_EVENT_SCROLL_DRAG_STARTED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event ScrollDragStarted.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnScrollDragStarted()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_EVENT_SCROLL_DRAG_STARTED", IntPtr.Zero, null);
        }

        /// <summary>Called when scroll drag finishes.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler ScrollDragFinished
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_UI_EVENT_SCROLL_DRAG_FINISHED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_EVENT_SCROLL_DRAG_FINISHED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event ScrollDragFinished.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnScrollDragFinished()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_EVENT_SCROLL_DRAG_FINISHED", IntPtr.Zero, null);
        }

        /// <summary>Called when scroll destination is finalized.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.ScrollableScrollDestinationFinalizedEventArgs"/></value>
        public event EventHandler<CoreUI.UI.ScrollableScrollDestinationFinalizedEventArgs> ScrollDestinationFinalized
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.ScrollableScrollDestinationFinalizedEventArgs{ Arg =  info });
                string key = "_EFL_UI_EVENT_SCROLL_DESTINATION_FINALIZED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_EVENT_SCROLL_DESTINATION_FINALIZED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event ScrollDestinationFinalized.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnScrollDestinationFinalized(CoreUI.UI.ScrollableScrollDestinationFinalizedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.Arg));
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_EVENT_SCROLL_DESTINATION_FINALIZED", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Emitted when thumb is pressed.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.ScrollBarBarPressedEventArgs"/></value>
        public event EventHandler<CoreUI.UI.ScrollBarBarPressedEventArgs> BarPressed
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.ScrollBarBarPressedEventArgs{ Arg =  (CoreUI.UI.LayoutOrientation)info });
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_PRESSED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_PRESSED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event BarPressed.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnBarPressed(CoreUI.UI.ScrollBarBarPressedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = CoreUI.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(e.Arg);
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_SCROLLBAR_EVENT_BAR_PRESSED", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Emitted when thumb is unpressed.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.ScrollBarBarUnpressedEventArgs"/></value>
        public event EventHandler<CoreUI.UI.ScrollBarBarUnpressedEventArgs> BarUnpressed
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.ScrollBarBarUnpressedEventArgs{ Arg =  (CoreUI.UI.LayoutOrientation)info });
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_UNPRESSED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_UNPRESSED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event BarUnpressed.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnBarUnpressed(CoreUI.UI.ScrollBarBarUnpressedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = CoreUI.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(e.Arg);
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_SCROLLBAR_EVENT_BAR_UNPRESSED", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Emitted when thumb is dragged.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.ScrollBarBarDraggedEventArgs"/></value>
        public event EventHandler<CoreUI.UI.ScrollBarBarDraggedEventArgs> BarDragged
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.ScrollBarBarDraggedEventArgs{ Arg =  (CoreUI.UI.LayoutOrientation)info });
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_DRAGGED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_DRAGGED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event BarDragged.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnBarDragged(CoreUI.UI.ScrollBarBarDraggedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = CoreUI.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(e.Arg);
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_SCROLLBAR_EVENT_BAR_DRAGGED", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Emitted when thumb size has changed.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler BarSizeChanged
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_SIZE_CHANGED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_SIZE_CHANGED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event BarSizeChanged.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnBarSizeChanged()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_SCROLLBAR_EVENT_BAR_SIZE_CHANGED", IntPtr.Zero, null);
        }

        /// <summary>Emitted when thumb position has changed.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler BarPosChanged
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_POS_CHANGED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_POS_CHANGED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event BarPosChanged.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnBarPosChanged()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_SCROLLBAR_EVENT_BAR_POS_CHANGED", IntPtr.Zero, null);
        }

        /// <summary>Emitted when scrollbar is shown.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.ScrollBarBarShowEventArgs"/></value>
        public event EventHandler<CoreUI.UI.ScrollBarBarShowEventArgs> BarShow
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.ScrollBarBarShowEventArgs{ Arg =  (CoreUI.UI.LayoutOrientation)info });
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_SHOW";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_SHOW";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event BarShow.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnBarShow(CoreUI.UI.ScrollBarBarShowEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = CoreUI.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(e.Arg);
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_SCROLLBAR_EVENT_BAR_SHOW", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Emitted when scrollbar is hidden.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.ScrollBarBarHideEventArgs"/></value>
        public event EventHandler<CoreUI.UI.ScrollBarBarHideEventArgs> BarHide
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.ScrollBarBarHideEventArgs{ Arg =  (CoreUI.UI.LayoutOrientation)info });
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_HIDE";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_SCROLLBAR_EVENT_BAR_HIDE";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event BarHide.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnBarHide(CoreUI.UI.ScrollBarBarHideEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = CoreUI.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(e.Arg);
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_SCROLLBAR_EVENT_BAR_HIDE", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Emitted when there is a change in the selection state. This event will collect all the item selection change events that are happening within one loop iteration. This means, you will only get this event once, even if a lot of items have changed. If you are interested in detailed changes, subscribe to the individual <see cref="CoreUI.UI.ISelectable.SelectedChanged"/> events of each item.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler SelectionChanged
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_UI_SELECTABLE_EVENT_SELECTION_CHANGED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_SELECTABLE_EVENT_SELECTION_CHANGED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event SelectionChanged.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnSelectionChanged()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_SELECTABLE_EVENT_SELECTION_CHANGED", IntPtr.Zero, null);
        }

        /// <summary>Position manager object that handles placement of items.</summary>
        /// <returns>A borrowed handle to the item container.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.UI.PositionManager.IEntity GetPositionManager() {
            var _ret_var = CoreUI.UI.Collection.NativeMethods.efl_ui_collection_position_manager_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Position manager object that handles placement of items.</summary>
        /// <param name="position_manager">Ownership is passed to the item container.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetPositionManager(CoreUI.UI.PositionManager.IEntity position_manager) {
            CoreUI.UI.Collection.NativeMethods.efl_ui_collection_position_manager_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), position_manager);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Brings the passed item into the viewport.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="item">The target to move into view.</param>
        /// <param name="animation">If you want to have an animated transition.</param>
        public virtual void ItemScroll(CoreUI.UI.Item item, bool animation) {
            CoreUI.UI.Collection.NativeMethods.efl_ui_collection_item_scroll_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), item, animation);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Brings the passed item into the viewport and align it.
        /// 
        /// <c>align</c> selects the final position of the object inside the viewport. 0.0 will move the object to the first visible position inside the viewport, 1.0 will move it to the last visible position, and values in between will move it accordingly to positions in between, along the scrolling axis.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="item">The target to move into view.</param>
        /// <param name="align">0.0 to have this item at the upper or left side of the viewport, 1.0 to have this item at the lower or right side of the viewport.</param>
        /// <param name="animation">If you want to have an animated transition.</param>
        public virtual void ItemScrollAlign(CoreUI.UI.Item item, double align, bool animation) {
            CoreUI.UI.Collection.NativeMethods.efl_ui_collection_item_scroll_align_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), item, align, animation);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Removes all packed sub-objects and unreferences them.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns><c>true</c> on success, <c>false</c> otherwise.</returns>
        public virtual bool ClearPack() {
            var _ret_var = CoreUI.IPackNativeMethods.efl_pack_clear_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Removes all packed sub-objects without unreferencing them.
        /// 
        /// Use with caution.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns><c>true</c> on success, <c>false</c> otherwise.</returns>
        public virtual bool UnpackAll() {
            var _ret_var = CoreUI.IPackNativeMethods.efl_pack_unpack_all_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Removes an existing sub-object from the container without deleting it.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="subobj">The sub-object to unpack.</param>
        /// <returns><c>false</c> if <c>subobj</c> wasn&apos;t in the container or couldn&apos;t be removed.</returns>
        public virtual bool Unpack(CoreUI.Gfx.IEntity subobj) {
            var _ret_var = CoreUI.IPackNativeMethods.efl_pack_unpack_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), subobj);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Adds a sub-object to this container.
        /// 
        /// Depending on the container this will either fill in the default spot, replacing any already existing element or append to the end of the container if there is no default part.
        /// 
        /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="CoreUI.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="subobj">The object to pack.</param>
        /// <returns><c>false</c> if <c>subobj</c> could not be packed.</returns>
        public virtual bool Pack(CoreUI.Gfx.IEntity subobj) {
            var _ret_var = CoreUI.IPackNativeMethods.efl_pack_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), subobj);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Prepend an object at the beginning of this container.
        /// 
        /// This is the same as <see cref="CoreUI.IPackLinear.PackAt"/> with a <c>0</c> index.
        /// 
        /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="CoreUI.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="subobj">Object to pack at the beginning.</param>
        /// <returns><c>false</c> if <c>subobj</c> could not be packed.</returns>
        public virtual bool PackBegin(CoreUI.Gfx.IEntity subobj) {
            var _ret_var = CoreUI.IPackLinearNativeMethods.efl_pack_begin_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), subobj);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Append object at the end of this container.
        /// 
        /// This is the same as <see cref="CoreUI.IPackLinear.PackAt"/> with a <c>-1</c> index.
        /// 
        /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="CoreUI.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="subobj">Object to pack at the end.</param>
        /// <returns><c>false</c> if <c>subobj</c> could not be packed.</returns>
        public virtual bool PackEnd(CoreUI.Gfx.IEntity subobj) {
            var _ret_var = CoreUI.IPackLinearNativeMethods.efl_pack_end_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), subobj);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Prepend an object before the <c>existing</c> sub-object.
        /// 
        /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="CoreUI.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.
        /// 
        /// If <c>existing</c> is <c>NULL</c> this method behaves like <see cref="CoreUI.IPackLinear.PackBegin"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="subobj">Object to pack before <c>existing</c>.</param>
        /// <param name="existing">Existing reference sub-object. Must already belong to the container or be <c>NULL</c>.</param>
        /// <returns><c>false</c> if <c>existing</c> could not be found or <c>subobj</c> could not be packed.</returns>
        public virtual bool PackBefore(CoreUI.Gfx.IEntity subobj, CoreUI.Gfx.IEntity existing) {
            var _ret_var = CoreUI.IPackLinearNativeMethods.efl_pack_before_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), subobj, existing);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Append an object after the <c>existing</c> sub-object.
        /// 
        /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="CoreUI.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.
        /// 
        /// If <c>existing</c> is <c>NULL</c> this method behaves like <see cref="CoreUI.IPackLinear.PackEnd"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="subobj">Object to pack after <c>existing</c>.</param>
        /// <param name="existing">Existing reference sub-object. Must already belong to the container or be <c>NULL</c>.</param>
        /// <returns><c>false</c> if <c>existing</c> could not be found or <c>subobj</c> could not be packed.</returns>
        public virtual bool PackAfter(CoreUI.Gfx.IEntity subobj, CoreUI.Gfx.IEntity existing) {
            var _ret_var = CoreUI.IPackLinearNativeMethods.efl_pack_after_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), subobj, existing);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Inserts <c>subobj</c> BEFORE the sub-object at position <c>index</c>.
        /// 
        /// <c>index</c> ranges from <c>-count</c> to <c>count-1</c>, where positive numbers go from first sub-object (<c>0</c>) to last (<c>count-1</c>), and negative numbers go from last sub-object (<c>-1</c>) to first (<c>-count</c>). <c>count</c> is the number of sub-objects currently in the container as returned by <see cref="CoreUI.IContainer.ContentCount"/>.
        /// 
        /// If <c>index</c> is less than <c>-count</c>, it will trigger <see cref="CoreUI.IPackLinear.PackBegin"/> whereas <c>index</c> greater than <c>count-1</c> will trigger <see cref="CoreUI.IPackLinear.PackEnd"/>.
        /// 
        /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="CoreUI.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="subobj">Object to pack.</param>
        /// <param name="index">Index of existing sub-object to insert BEFORE. Valid range is <c>-count</c> to <c>count-1</c>).</param>
        /// <returns><c>false</c> if <c>subobj</c> could not be packed.</returns>
        public virtual bool PackAt(CoreUI.Gfx.IEntity subobj, int index) {
            var _ret_var = CoreUI.IPackLinearNativeMethods.efl_pack_at_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), subobj, index);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Sub-object at a given <c>index</c> in this container.
        /// 
        /// <c>index</c> ranges from <c>-count</c> to <c>count-1</c>, where positive numbers go from first sub-object (<c>0</c>) to last (<c>count-1</c>), and negative numbers go from last sub-object (<c>-1</c>) to first (<c>-count</c>). <c>count</c> is the number of sub-objects currently in the container as returned by <see cref="CoreUI.IContainer.ContentCount"/>.
        /// 
        /// If <c>index</c> is less than <c>-count</c>, it will return the first sub-object whereas <c>index</c> greater than <c>count-1</c> will return the last sub-object.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="index">Index of the existing sub-object to retrieve. Valid range is <c>-count</c> to <c>count-1</c>.</param>
        /// <returns>The sub-object contained at the given <c>index</c>.</returns>
        public virtual CoreUI.Gfx.IEntity GetPackContent(int index) {
            var _ret_var = CoreUI.IPackLinearNativeMethods.efl_pack_content_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), index);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Get the index of a sub-object in this container.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="subobj">An existing sub-object in this container.</param>
        /// <returns>-1 in case <c>subobj</c> is not found, or the index of <c>subobj</c> in the range <c>0</c> to <c>count-1</c>.</returns>
        public virtual int GetPackIndex(CoreUI.Gfx.IEntity subobj) {
            var _ret_var = CoreUI.IPackLinearNativeMethods.efl_pack_index_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), subobj);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Pop out (remove) the sub-object at the specified <c>index</c>.
        /// 
        /// <c>index</c> ranges from <c>-count</c> to <c>count-1</c>, where positive numbers go from first sub-object (<c>0</c>) to last (<c>count-1</c>), and negative numbers go from last sub-object (<c>-1</c>) to first (<c>-count</c>). <c>count</c> is the number of sub-objects currently in the container as returned by <see cref="CoreUI.IContainer.ContentCount"/>.
        /// 
        /// If <c>index</c> is less than -<c>count</c>, it will remove the first sub-object whereas <c>index</c> greater than <c>count</c>-1 will remove the last sub-object.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="index">Index of the sub-object to remove. Valid range is <c>-count</c> to <c>count-1</c>.</param>
        /// <returns>The sub-object if it could be removed.</returns>
        public virtual CoreUI.Gfx.IEntity PackUnpackAt(int index) {
            var _ret_var = CoreUI.IPackLinearNativeMethods.efl_pack_unpack_at_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), index);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Control the direction of a given widget.
        /// 
        /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
        /// 
        /// Mirroring as defined in <span class="text-muted">CoreUI.UI.II18n (object still in beta stage)</span> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
        /// <returns>Direction of the widget.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.UI.LayoutOrientation GetOrientation() {
            var _ret_var = CoreUI.UI.ILayoutOrientableNativeMethods.efl_ui_layout_orientation_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Control the direction of a given widget.
        /// 
        /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
        /// 
        /// Mirroring as defined in <span class="text-muted">CoreUI.UI.II18n (object still in beta stage)</span> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
        /// <param name="dir">Direction of the widget.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetOrientation(CoreUI.UI.LayoutOrientation dir) {
            CoreUI.UI.ILayoutOrientableNativeMethods.efl_ui_layout_orientation_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), dir);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The mode type for children selection.</summary>
        /// <returns>Type of selection of children</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.UI.SelectMode GetSelectMode() {
            var _ret_var = CoreUI.UI.IMultiSelectableNativeMethods.efl_ui_multi_selectable_select_mode_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The mode type for children selection.</summary>
        /// <param name="mode">Type of selection of children</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetSelectMode(CoreUI.UI.SelectMode mode) {
            CoreUI.UI.IMultiSelectableNativeMethods.efl_ui_multi_selectable_select_mode_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), mode);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Select all <see cref="CoreUI.UI.ISelectable"/></summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SelectAll() {
            CoreUI.UI.IMultiSelectableNativeMethods.efl_ui_multi_selectable_all_select_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Unselect all <see cref="CoreUI.UI.ISelectable"/></summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void UnselectAll() {
            CoreUI.UI.IMultiSelectableNativeMethods.efl_ui_multi_selectable_all_unselect_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Get the selected items in an iterator. The iterator sequence will be decided by selection.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>User has to free the iterator after usage.</returns>
        public virtual IEnumerable<CoreUI.UI.ISelectable> NewSelectedIterator() {
            var _ret_var = CoreUI.UI.IMultiSelectableObjectRangeNativeMethods.efl_ui_multi_selectable_selected_iterator_new_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return CoreUI.Wrapper.Globals.IteratorToIEnumerable<CoreUI.UI.ISelectable>(_ret_var);
        }

        /// <summary>Position of the content inside the scroller.</summary>
        /// <returns>The position is a virtual value, where <c>0,0</c> means the top-left corner.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Position2D GetContentPos() {
            var _ret_var = CoreUI.UI.IScrollableNativeMethods.efl_ui_scrollable_content_pos_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Position of the content inside the scroller.</summary>
        /// <param name="pos">The position is a virtual value, where <c>0,0</c> means the top-left corner.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetContentPos(CoreUI.DataTypes.Position2D pos) {
            CoreUI.DataTypes.Position2D _in_pos = pos;
CoreUI.UI.IScrollableNativeMethods.efl_ui_scrollable_content_pos_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), _in_pos);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Current size of the content, for convenience.</summary>
        /// <returns>The content size in pixels.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Size2D GetContentSize() {
            var _ret_var = CoreUI.UI.IScrollableNativeMethods.efl_ui_scrollable_content_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Current position and size of the viewport (or scroller window), for convenience.
        /// 
        /// This is the viewport through which the content is displayed.</summary>
        /// <returns>It is absolute geometry.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Rect GetViewportGeometry() {
            var _ret_var = CoreUI.UI.IScrollableNativeMethods.efl_ui_scrollable_viewport_geometry_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>When scrolling, the scroller may &quot;bounce&quot; when reaching the edge of the content object. This is a visual way to indicate the end has been reached. This is enabled by default for both axes. This property determines if bouncing is enabled in each axis. When bouncing is disabled, scrolling just stops upon reaching the end of the content.</summary>
        /// <param name="horiz">Horizontal bouncing is enabled.</param>
        /// <param name="vert">Vertical bouncing is enabled.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetBounceEnabled(out bool horiz, out bool vert) {
            CoreUI.UI.IScrollableNativeMethods.efl_ui_scrollable_bounce_enabled_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out horiz, out vert);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>When scrolling, the scroller may &quot;bounce&quot; when reaching the edge of the content object. This is a visual way to indicate the end has been reached. This is enabled by default for both axes. This property determines if bouncing is enabled in each axis. When bouncing is disabled, scrolling just stops upon reaching the end of the content.</summary>
        /// <param name="horiz">Horizontal bouncing is enabled.</param>
        /// <param name="vert">Vertical bouncing is enabled.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetBounceEnabled(bool horiz, bool vert) {
            CoreUI.UI.IScrollableNativeMethods.efl_ui_scrollable_bounce_enabled_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), horiz, vert);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Freezes scrolling movement (by input of a user). Unlike <see cref="CoreUI.UI.IScrollable.MovementBlock"/>, this property freezes bidirectionally. If you want to freeze in only one direction, see <see cref="CoreUI.UI.IScrollable.MovementBlock"/>.</summary>
        /// <returns><c>true</c> if freeze.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetScrollFreeze() {
            var _ret_var = CoreUI.UI.IScrollableNativeMethods.efl_ui_scrollable_scroll_freeze_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Freezes scrolling movement (by input of a user). Unlike <see cref="CoreUI.UI.IScrollable.MovementBlock"/>, this property freezes bidirectionally. If you want to freeze in only one direction, see <see cref="CoreUI.UI.IScrollable.MovementBlock"/>.</summary>
        /// <param name="freeze"><c>true</c> if freeze.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetScrollFreeze(bool freeze) {
            CoreUI.UI.IScrollableNativeMethods.efl_ui_scrollable_scroll_freeze_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), freeze);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>When hold turns on, it only scrolls by holding action.</summary>
        /// <returns><c>true</c> if hold.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetScrollHold() {
            var _ret_var = CoreUI.UI.IScrollableNativeMethods.efl_ui_scrollable_scroll_hold_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>When hold turns on, it only scrolls by holding action.</summary>
        /// <param name="hold"><c>true</c> if hold.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetScrollHold(bool hold) {
            CoreUI.UI.IScrollableNativeMethods.efl_ui_scrollable_scroll_hold_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), hold);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Controls infinite looping for a scroller.</summary>
        /// <param name="loop_h">Scroll horizontal looping is enabled.</param>
        /// <param name="loop_v">Scroll vertical looping is enabled.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetLooping(out bool loop_h, out bool loop_v) {
            CoreUI.UI.IScrollableNativeMethods.efl_ui_scrollable_looping_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out loop_h, out loop_v);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Controls infinite looping for a scroller.</summary>
        /// <param name="loop_h">Scroll horizontal looping is enabled.</param>
        /// <param name="loop_v">Scroll vertical looping is enabled.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetLooping(bool loop_h, bool loop_v) {
            CoreUI.UI.IScrollableNativeMethods.efl_ui_scrollable_looping_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), loop_h, loop_v);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Blocking of scrolling (per axis).
        /// 
        /// This function will block scrolling movement (by input of a user) in a given direction. You can disable movements in the X axis, the Y axis or both. The default value is <see cref="CoreUI.UI.LayoutOrientation.Default"/> meaning that movements are allowed in both directions.</summary>
        /// <returns>Which axis (or axes) to block.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.UI.LayoutOrientation GetMovementBlock() {
            var _ret_var = CoreUI.UI.IScrollableNativeMethods.efl_ui_scrollable_movement_block_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Blocking of scrolling (per axis).
        /// 
        /// This function will block scrolling movement (by input of a user) in a given direction. You can disable movements in the X axis, the Y axis or both. The default value is <see cref="CoreUI.UI.LayoutOrientation.Default"/> meaning that movements are allowed in both directions.</summary>
        /// <param name="block">Which axis (or axes) to block.<br/>The default value is <see cref="CoreUI.UI.LayoutOrientation.Default"/>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetMovementBlock(CoreUI.UI.LayoutOrientation block) {
            CoreUI.UI.IScrollableNativeMethods.efl_ui_scrollable_movement_block_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), block);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Control scrolling gravity on the scrollable.
        /// 
        /// The gravity defines how the scroller will adjust its view when the size of the scroller contents increases.
        /// 
        /// The scroller will adjust the view to glue itself as follows: <c>x=0.0</c> to stay where it is relative to the left edge of the content. <c>x=1.0</c> to stay where it is relative to the right edge of the content. <c>y=0.0</c> to stay where it is relative to the top edge of the content. <c>y=1.0</c> to stay where it is relative to the bottom edge of the content.</summary>
        /// <param name="x">Horizontal scrolling gravity.<br/>The default value is <c>0.000000</c>.</param>
        /// <param name="y">Vertical scrolling gravity.<br/>The default value is <c>0.000000</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetGravity(out double x, out double y) {
            CoreUI.UI.IScrollableNativeMethods.efl_ui_scrollable_gravity_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out x, out y);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Control scrolling gravity on the scrollable.
        /// 
        /// The gravity defines how the scroller will adjust its view when the size of the scroller contents increases.
        /// 
        /// The scroller will adjust the view to glue itself as follows: <c>x=0.0</c> to stay where it is relative to the left edge of the content. <c>x=1.0</c> to stay where it is relative to the right edge of the content. <c>y=0.0</c> to stay where it is relative to the top edge of the content. <c>y=1.0</c> to stay where it is relative to the bottom edge of the content.</summary>
        /// <param name="x">Horizontal scrolling gravity.<br/>The default value is <c>0.000000</c>.</param>
        /// <param name="y">Vertical scrolling gravity.<br/>The default value is <c>0.000000</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetGravity(double x, double y) {
            CoreUI.UI.IScrollableNativeMethods.efl_ui_scrollable_gravity_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), x, y);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Prevent the scrollable from being smaller than the minimum size of the content.
        /// 
        /// By default the scroller will be as small as its design allows, irrespective of its content. This will make the scroller minimum size the right size horizontally and/or vertically to perfectly fit its content in that direction.</summary>
        /// <param name="w">Whether to limit the minimum horizontal size.</param>
        /// <param name="h">Whether to limit the minimum vertical size.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetMatchContent(bool w, bool h) {
            CoreUI.UI.IScrollableNativeMethods.efl_ui_scrollable_match_content_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), w, h);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Amount to scroll in response to cursor key presses.</summary>
        /// <returns>The step size in pixels.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Position2D GetStepSize() {
            var _ret_var = CoreUI.UI.IScrollableNativeMethods.efl_ui_scrollable_step_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Amount to scroll in response to cursor key presses.</summary>
        /// <param name="step">The step size in pixels.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetStepSize(CoreUI.DataTypes.Position2D step) {
            CoreUI.DataTypes.Position2D _in_step = step;
CoreUI.UI.IScrollableNativeMethods.efl_ui_scrollable_step_size_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), _in_step);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Show a specific virtual region within the scroller content object.
        /// 
        /// This will ensure all (or part if it does not fit) of the designated region in the virtual content object (<c>0,0</c> starting at the top-left of the virtual content object) is shown within the scroller. This allows the scroller to &quot;smoothly slide&quot; to this location (if configuration in general calls for transitions). It may not jump immediately to the new location and make take a while and show other content along the way.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="rect">The position where to scroll and the size user want to see.</param>
        /// <param name="animation">Whether to scroll with animation or not.</param>
        public virtual void Scroll(CoreUI.DataTypes.Rect rect, bool animation) {
            CoreUI.DataTypes.Rect _in_rect = rect;
CoreUI.UI.IScrollableNativeMethods.efl_ui_scrollable_scroll_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), _in_rect, animation);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>ScrollBar visibility mode, for each of the scrollbars.</summary>
        /// <param name="hbar">Horizontal scrollbar mode.<br/>The default value is <see cref="CoreUI.UI.ScrollBarMode.Auto"/>.</param>
        /// <param name="vbar">Vertical scrollbar mode.<br/>The default value is <see cref="CoreUI.UI.ScrollBarMode.Auto"/>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetBarMode(out CoreUI.UI.ScrollBarMode hbar, out CoreUI.UI.ScrollBarMode vbar) {
            CoreUI.UI.IScrollBarNativeMethods.efl_ui_scrollbar_bar_mode_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out hbar, out vbar);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>ScrollBar visibility mode, for each of the scrollbars.</summary>
        /// <param name="hbar">Horizontal scrollbar mode.<br/>The default value is <see cref="CoreUI.UI.ScrollBarMode.Auto"/>.</param>
        /// <param name="vbar">Vertical scrollbar mode.<br/>The default value is <see cref="CoreUI.UI.ScrollBarMode.Auto"/>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetBarMode(CoreUI.UI.ScrollBarMode hbar, CoreUI.UI.ScrollBarMode vbar) {
            CoreUI.UI.IScrollBarNativeMethods.efl_ui_scrollbar_bar_mode_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), hbar, vbar);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>This returns the relative size the thumb should have, given the current size of the viewport and the content. <c>0.0</c> means the viewport is much smaller than the content: the thumb will have its minimum size. <c>1.0</c> means the viewport has the same size as the content (or bigger): the thumb will have the same size as the scrollbar and cannot move.</summary>
        /// <param name="width">Value between <c>0.0</c> and <c>1.0</c>.</param>
        /// <param name="height">Value between <c>0.0</c> and <c>1.0</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetBarSize(out double width, out double height) {
            CoreUI.UI.IScrollBarNativeMethods.efl_ui_scrollbar_bar_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out width, out height);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Position of the thumb (the draggable zone) inside the scrollbar. It is calculated based on current position of the viewport inside the total content.</summary>
        /// <param name="posx">Value between <c>0.0</c> (the left side of the thumb is touching the left edge of the widget) and <c>1.0</c> (the right side of the thumb is touching the right edge of the widget).</param>
        /// <param name="posy">Value between <c>0.0</c> (the top side of the thumb is touching the top edge of the widget) and <c>1.0</c> (the bottom side of the thumb is touching the bottom edge of the widget).</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetBarPosition(out double posx, out double posy) {
            CoreUI.UI.IScrollBarNativeMethods.efl_ui_scrollbar_bar_position_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out posx, out posy);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Position of the thumb (the draggable zone) inside the scrollbar. It is calculated based on current position of the viewport inside the total content.</summary>
        /// <param name="posx">Value between <c>0.0</c> (the left side of the thumb is touching the left edge of the widget) and <c>1.0</c> (the right side of the thumb is touching the right edge of the widget).</param>
        /// <param name="posy">Value between <c>0.0</c> (the top side of the thumb is touching the top edge of the widget) and <c>1.0</c> (the bottom side of the thumb is touching the bottom edge of the widget).</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetBarPosition(double posx, double posy) {
            CoreUI.UI.IScrollBarNativeMethods.efl_ui_scrollbar_bar_position_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), posx, posy);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Current visibility state of the scrollbars. This is useful in <see cref="CoreUI.UI.ScrollBarMode.Auto"/> mode where EFL decides if the scrollbars are shown or hidden. See also the @[.bar,show] and @[.bar,hide] events.</summary>
        /// <param name="hbar">Whether the horizontal scrollbar is currently visible.</param>
        /// <param name="vbar">Whether the vertical scrollbar is currently visible.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetBarVisibility(out bool hbar, out bool vbar) {
            CoreUI.UI.IScrollBarNativeMethods.efl_ui_scrollbar_bar_visibility_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out hbar, out vbar);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The selectable that was selected most recently.</summary>
        /// <returns>The latest selected item.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.UI.ISelectable GetLastSelected() {
            var _ret_var = CoreUI.UI.ISingleSelectableNativeMethods.efl_ui_selectable_last_selected_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>A object that will be selected in case nothing is selected
        /// 
        /// A object set to this property will be selected instead of no item being selected. Which means, there will be always at least one element selected. If this property is <c>NULL</c>, the state of &quot;no item is selected&quot; can be reached.
        /// 
        /// Setting this property as a result of selection events results in undefined behavior.</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.UI.ISelectable GetFallbackSelection() {
            var _ret_var = CoreUI.UI.ISingleSelectableNativeMethods.efl_ui_selectable_fallback_selection_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>A object that will be selected in case nothing is selected
        /// 
        /// A object set to this property will be selected instead of no item being selected. Which means, there will be always at least one element selected. If this property is <c>NULL</c>, the state of &quot;no item is selected&quot; can be reached.
        /// 
        /// Setting this property as a result of selection events results in undefined behavior.</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetFallbackSelection(CoreUI.UI.ISelectable fallback) {
            CoreUI.UI.ISingleSelectableNativeMethods.efl_ui_selectable_fallback_selection_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), fallback);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>This controlls if a selected item can be deselected due to clicking</summary>
        /// <returns><c>true</c> if clicking while selected results in a state change to unselected</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetAllowManualDeselection() {
            var _ret_var = CoreUI.UI.ISingleSelectableNativeMethods.efl_ui_selectable_allow_manual_deselection_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>This controlls if a selected item can be deselected due to clicking</summary>
        /// <param name="allow_manual_deselection"><c>true</c> if clicking while selected results in a state change to unselected</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetAllowManualDeselection(bool allow_manual_deselection) {
            CoreUI.UI.ISingleSelectableNativeMethods.efl_ui_selectable_allow_manual_deselection_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), allow_manual_deselection);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Position manager object that handles placement of items.</summary>
        /// <value>Ownership is passed to the item container.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.UI.PositionManager.IEntity PositionManager {
            get { return GetPositionManager(); }
            set { SetPositionManager(value); }
        }

        /// <summary>Control the direction of a given widget.
        /// 
        /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
        /// 
        /// Mirroring as defined in <span class="text-muted">CoreUI.UI.II18n (object still in beta stage)</span> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
        /// <value>Direction of the widget.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.UI.LayoutOrientation Orientation {
            get { return GetOrientation(); }
            set { SetOrientation(value); }
        }

        /// <summary>The mode type for children selection.</summary>
        /// <value>Type of selection of children</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.UI.SelectMode SelectMode {
            get { return GetSelectMode(); }
            set { SetSelectMode(value); }
        }

        /// <summary>Position of the content inside the scroller.</summary>
        /// <value>The position is a virtual value, where <c>0,0</c> means the top-left corner.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Position2D ContentPos {
            get { return GetContentPos(); }
            set { SetContentPos(value); }
        }

        /// <summary>Current size of the content, for convenience.</summary>
        /// <value>The content size in pixels.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Size2D ContentSize {
            get { return GetContentSize(); }
        }

        /// <summary>Current position and size of the viewport (or scroller window), for convenience.
        /// 
        /// This is the viewport through which the content is displayed.</summary>
        /// <value>It is absolute geometry.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Rect ViewportGeometry {
            get { return GetViewportGeometry(); }
        }

        /// <summary>When scrolling, the scroller may &quot;bounce&quot; when reaching the edge of the content object. This is a visual way to indicate the end has been reached. This is enabled by default for both axes. This property determines if bouncing is enabled in each axis. When bouncing is disabled, scrolling just stops upon reaching the end of the content.</summary>
        /// <value>Horizontal bouncing is enabled.</value>
        /// <since_tizen> 6 </since_tizen>
        public (bool, bool) BounceEnabled {
            get {
                bool _out_horiz = default(bool);
                bool _out_vert = default(bool);
                GetBounceEnabled(out _out_horiz, out _out_vert);
                return (_out_horiz, _out_vert);
            }
            set { SetBounceEnabled( value.Item1,  value.Item2); }
        }

        /// <summary>Freezes scrolling movement (by input of a user). Unlike <see cref="CoreUI.UI.IScrollable.MovementBlock"/>, this property freezes bidirectionally. If you want to freeze in only one direction, see <see cref="CoreUI.UI.IScrollable.MovementBlock"/>.</summary>
        /// <value><c>true</c> if freeze.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool ScrollFreeze {
            get { return GetScrollFreeze(); }
            set { SetScrollFreeze(value); }
        }

        /// <summary>When hold turns on, it only scrolls by holding action.</summary>
        /// <value><c>true</c> if hold.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool ScrollHold {
            get { return GetScrollHold(); }
            set { SetScrollHold(value); }
        }

        /// <summary>Controls infinite looping for a scroller.</summary>
        /// <value>Scroll horizontal looping is enabled.</value>
        /// <since_tizen> 6 </since_tizen>
        public (bool, bool) Looping {
            get {
                bool _out_loop_h = default(bool);
                bool _out_loop_v = default(bool);
                GetLooping(out _out_loop_h, out _out_loop_v);
                return (_out_loop_h, _out_loop_v);
            }
            set { SetLooping( value.Item1,  value.Item2); }
        }

        /// <summary>Blocking of scrolling (per axis).
        /// 
        /// This function will block scrolling movement (by input of a user) in a given direction. You can disable movements in the X axis, the Y axis or both. The default value is <see cref="CoreUI.UI.LayoutOrientation.Default"/> meaning that movements are allowed in both directions.</summary>
        /// <value>Which axis (or axes) to block.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.UI.LayoutOrientation MovementBlock {
            get { return GetMovementBlock(); }
            set { SetMovementBlock(value); }
        }

        /// <summary>Control scrolling gravity on the scrollable.
        /// 
        /// The gravity defines how the scroller will adjust its view when the size of the scroller contents increases.
        /// 
        /// The scroller will adjust the view to glue itself as follows: <c>x=0.0</c> to stay where it is relative to the left edge of the content. <c>x=1.0</c> to stay where it is relative to the right edge of the content. <c>y=0.0</c> to stay where it is relative to the top edge of the content. <c>y=1.0</c> to stay where it is relative to the bottom edge of the content.</summary>
        /// <value>Horizontal scrolling gravity.</value>
        /// <since_tizen> 6 </since_tizen>
        public (double, double) Gravity {
            get {
                double _out_x = default(double);
                double _out_y = default(double);
                GetGravity(out _out_x, out _out_y);
                return (_out_x, _out_y);
            }
            set { SetGravity( value.Item1,  value.Item2); }
        }

        /// <summary>Amount to scroll in response to cursor key presses.</summary>
        /// <value>The step size in pixels.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Position2D StepSize {
            get { return GetStepSize(); }
            set { SetStepSize(value); }
        }

        /// <summary>ScrollBar visibility mode, for each of the scrollbars.</summary>
        /// <value>Horizontal scrollbar mode.</value>
        /// <since_tizen> 6 </since_tizen>
        public (CoreUI.UI.ScrollBarMode, CoreUI.UI.ScrollBarMode) BarMode {
            get {
                CoreUI.UI.ScrollBarMode _out_hbar = default(CoreUI.UI.ScrollBarMode);
                CoreUI.UI.ScrollBarMode _out_vbar = default(CoreUI.UI.ScrollBarMode);
                GetBarMode(out _out_hbar, out _out_vbar);
                return (_out_hbar, _out_vbar);
            }
            set { SetBarMode( value.Item1,  value.Item2); }
        }

        /// <summary>This returns the relative size the thumb should have, given the current size of the viewport and the content. <c>0.0</c> means the viewport is much smaller than the content: the thumb will have its minimum size. <c>1.0</c> means the viewport has the same size as the content (or bigger): the thumb will have the same size as the scrollbar and cannot move.</summary>
        /// <since_tizen> 6 </since_tizen>
        public (double, double) BarSize {
            get {
                double _out_width = default(double);
                double _out_height = default(double);
                GetBarSize(out _out_width, out _out_height);
                return (_out_width, _out_height);
            }
        }

        /// <summary>Position of the thumb (the draggable zone) inside the scrollbar. It is calculated based on current position of the viewport inside the total content.</summary>
        /// <value>Value between <c>0.0</c> (the left side of the thumb is touching the left edge of the widget) and <c>1.0</c> (the right side of the thumb is touching the right edge of the widget).</value>
        /// <since_tizen> 6 </since_tizen>
        public (double, double) BarPosition {
            get {
                double _out_posx = default(double);
                double _out_posy = default(double);
                GetBarPosition(out _out_posx, out _out_posy);
                return (_out_posx, _out_posy);
            }
            set { SetBarPosition( value.Item1,  value.Item2); }
        }

        /// <summary>Current visibility state of the scrollbars. This is useful in <see cref="CoreUI.UI.ScrollBarMode.Auto"/> mode where EFL decides if the scrollbars are shown or hidden. See also the @[.bar,show] and @[.bar,hide] events.</summary>
        /// <since_tizen> 6 </since_tizen>
        public (bool, bool) BarVisibility {
            get {
                bool _out_hbar = default(bool);
                bool _out_vbar = default(bool);
                GetBarVisibility(out _out_hbar, out _out_vbar);
                return (_out_hbar, _out_vbar);
            }
        }

        /// <summary>The selectable that was selected most recently.</summary>
        /// <value>The latest selected item.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.UI.ISelectable LastSelected {
            get { return GetLastSelected(); }
        }

        /// <summary>A object that will be selected in case nothing is selected
        /// 
        /// A object set to this property will be selected instead of no item being selected. Which means, there will be always at least one element selected. If this property is <c>NULL</c>, the state of &quot;no item is selected&quot; can be reached.
        /// 
        /// Setting this property as a result of selection events results in undefined behavior.</summary>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.UI.ISelectable FallbackSelection {
            get { return GetFallbackSelection(); }
            set { SetFallbackSelection(value); }
        }

        /// <summary>This controlls if a selected item can be deselected due to clicking</summary>
        /// <value><c>true</c> if clicking while selected results in a state change to unselected</value>
        /// <since_tizen> 6 </since_tizen>
        public bool AllowManualDeselection {
            get { return GetAllowManualDeselection(); }
            set { SetAllowManualDeselection(value); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.UI.Collection.efl_ui_collection_class_get();
        }

        /// <summary>Wrapper for native methods and virtual method delegates.
        /// For internal use by generated code only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new class NativeMethods : CoreUI.UI.LayoutBase.NativeMethods
        {
            private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Elementary);

            /// <summary>Gets the list of Eo operations to override.
        /// </summary>
            /// <returns>The list of Eo operations to be overload.</returns>
            internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
            {
                var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
                var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

                if (efl_ui_collection_position_manager_get_static_delegate == null)
                {
                    efl_ui_collection_position_manager_get_static_delegate = new efl_ui_collection_position_manager_get_delegate(position_manager_get);
                }

                if (methods.Contains("GetPositionManager"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_collection_position_manager_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_collection_position_manager_get_static_delegate) });
                }

                if (efl_ui_collection_position_manager_set_static_delegate == null)
                {
                    efl_ui_collection_position_manager_set_static_delegate = new efl_ui_collection_position_manager_set_delegate(position_manager_set);
                }

                if (methods.Contains("SetPositionManager"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_collection_position_manager_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_collection_position_manager_set_static_delegate) });
                }

                if (efl_ui_collection_item_scroll_static_delegate == null)
                {
                    efl_ui_collection_item_scroll_static_delegate = new efl_ui_collection_item_scroll_delegate(item_scroll);
                }

                if (methods.Contains("ItemScroll"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_collection_item_scroll"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_collection_item_scroll_static_delegate) });
                }

                if (efl_ui_collection_item_scroll_align_static_delegate == null)
                {
                    efl_ui_collection_item_scroll_align_static_delegate = new efl_ui_collection_item_scroll_align_delegate(item_scroll_align);
                }

                if (methods.Contains("ItemScrollAlign"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_collection_item_scroll_align"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_collection_item_scroll_align_static_delegate) });
                }

                if (includeInherited)
                {
                    var all_interfaces = type.GetInterfaces();
                    foreach (var iface in all_interfaces)
                    {
                        var moredescs = ((CoreUI.Wrapper.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is CoreUI.Wrapper.NativeClass))?.GetEoOps(type, false);
                        if (moredescs != null)
                            descs.AddRange(moredescs);
                    }
                }
                descs.AddRange(base.GetEoOps(type, false));
                return descs;
            }

            /// <summary>Returns the Eo class for the native methods of this class.
            /// </summary>
            /// <returns>The native class pointer.</returns>
            internal override IntPtr GetCoreUIClass()
            {
                return CoreUI.UI.Collection.efl_ui_collection_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            private delegate CoreUI.UI.PositionManager.IEntity efl_ui_collection_position_manager_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            internal delegate CoreUI.UI.PositionManager.IEntity efl_ui_collection_position_manager_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_collection_position_manager_get_api_delegate> efl_ui_collection_position_manager_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_collection_position_manager_get_api_delegate>(Module, "efl_ui_collection_position_manager_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.UI.PositionManager.IEntity position_manager_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_collection_position_manager_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.UI.PositionManager.IEntity _ret_var = default(CoreUI.UI.PositionManager.IEntity);
                    try
                    {
                        _ret_var = ((Collection)ws.Target).GetPositionManager();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_ui_collection_position_manager_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_collection_position_manager_get_delegate efl_ui_collection_position_manager_get_static_delegate;

            
            private delegate void efl_ui_collection_position_manager_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoMove))] CoreUI.UI.PositionManager.IEntity position_manager);

            
            internal delegate void efl_ui_collection_position_manager_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoMove))] CoreUI.UI.PositionManager.IEntity position_manager);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_collection_position_manager_set_api_delegate> efl_ui_collection_position_manager_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_collection_position_manager_set_api_delegate>(Module, "efl_ui_collection_position_manager_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void position_manager_set(System.IntPtr obj, System.IntPtr pd, CoreUI.UI.PositionManager.IEntity position_manager)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_collection_position_manager_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Collection)ws.Target).SetPositionManager(position_manager);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_collection_position_manager_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), position_manager);
                }
            }

            private static efl_ui_collection_position_manager_set_delegate efl_ui_collection_position_manager_set_static_delegate;

            
            private delegate void efl_ui_collection_item_scroll_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.UI.Item item, [MarshalAs(UnmanagedType.U1)] bool animation);

            
            internal delegate void efl_ui_collection_item_scroll_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.UI.Item item, [MarshalAs(UnmanagedType.U1)] bool animation);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_collection_item_scroll_api_delegate> efl_ui_collection_item_scroll_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_collection_item_scroll_api_delegate>(Module, "efl_ui_collection_item_scroll");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void item_scroll(System.IntPtr obj, System.IntPtr pd, CoreUI.UI.Item item, bool animation)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_collection_item_scroll was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Collection)ws.Target).ItemScroll(item, animation);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_collection_item_scroll_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), item, animation);
                }
            }

            private static efl_ui_collection_item_scroll_delegate efl_ui_collection_item_scroll_static_delegate;

            
            private delegate void efl_ui_collection_item_scroll_align_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.UI.Item item,  double align, [MarshalAs(UnmanagedType.U1)] bool animation);

            
            internal delegate void efl_ui_collection_item_scroll_align_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.UI.Item item,  double align, [MarshalAs(UnmanagedType.U1)] bool animation);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_collection_item_scroll_align_api_delegate> efl_ui_collection_item_scroll_align_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_collection_item_scroll_align_api_delegate>(Module, "efl_ui_collection_item_scroll_align");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void item_scroll_align(System.IntPtr obj, System.IntPtr pd, CoreUI.UI.Item item, double align, bool animation)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_collection_item_scroll_align was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Collection)ws.Target).ItemScrollAlign(item, align, animation);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_collection_item_scroll_align_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), item, align, animation);
                }
            }

            private static efl_ui_collection_item_scroll_align_delegate efl_ui_collection_item_scroll_align_static_delegate;

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

namespace CoreUI.UI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class CollectionExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.UI.PositionManager.IEntity> PositionManager<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Collection, T>magic = null) where T : CoreUI.UI.Collection {
            return new CoreUI.BindableProperty<CoreUI.UI.PositionManager.IEntity>("position_manager", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.UI.LayoutOrientation> Orientation<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Collection, T>magic = null) where T : CoreUI.UI.Collection {
            return new CoreUI.BindableProperty<CoreUI.UI.LayoutOrientation>("orientation", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.UI.SelectMode> SelectMode<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Collection, T>magic = null) where T : CoreUI.UI.Collection {
            return new CoreUI.BindableProperty<CoreUI.UI.SelectMode>("select_mode", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.DataTypes.Position2D> ContentPos<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Collection, T>magic = null) where T : CoreUI.UI.Collection {
            return new CoreUI.BindableProperty<CoreUI.DataTypes.Position2D>("content_pos", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> ScrollFreeze<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Collection, T>magic = null) where T : CoreUI.UI.Collection {
            return new CoreUI.BindableProperty<bool>("scroll_freeze", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> ScrollHold<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Collection, T>magic = null) where T : CoreUI.UI.Collection {
            return new CoreUI.BindableProperty<bool>("scroll_hold", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.UI.LayoutOrientation> MovementBlock<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Collection, T>magic = null) where T : CoreUI.UI.Collection {
            return new CoreUI.BindableProperty<CoreUI.UI.LayoutOrientation>("movement_block", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.DataTypes.Position2D> StepSize<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Collection, T>magic = null) where T : CoreUI.UI.Collection {
            return new CoreUI.BindableProperty<CoreUI.DataTypes.Position2D>("step_size", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.UI.ISelectable> FallbackSelection<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Collection, T>magic = null) where T : CoreUI.UI.Collection {
            return new CoreUI.BindableProperty<CoreUI.UI.ISelectable>("fallback_selection", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> AllowManualDeselection<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Collection, T>magic = null) where T : CoreUI.UI.Collection {
            return new CoreUI.BindableProperty<bool>("allow_manual_deselection", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

