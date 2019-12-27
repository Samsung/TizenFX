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
    /// <summary>Widget container that allows objects bigger than itself to be put inside it, and provides scrolling functionality so the whole content is visible.
    /// 
    /// Some widgets have scrolling capabilities (like <see cref="CoreUI.UI.List"/>) that allow big content to be shown inside a small viewport, using the well-known scrollbar objects. Some other widgets (like <see cref="CoreUI.UI.Box"/>, for example) cannot scroll by themselves and therefore would not be fully visible when placed inside a viewport smaller than them.
    /// 
    /// The <see cref="CoreUI.UI.Scroller"/> is a helper class that provides scrolling capabilities for widgets which don&apos;t have them. In the above example, simply putting the <see cref="CoreUI.UI.Box"/> inside a <see cref="CoreUI.UI.Scroller"/> (using <see cref="CoreUI.IContent.SetContent"/>) would give it the ability to scroll.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.Scroller.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public class Scroller : CoreUI.UI.LayoutBase, CoreUI.IContent, CoreUI.UI.IScrollable, CoreUI.UI.IScrollBar
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(Scroller))
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
            efl_ui_scroller_class_get();

        /// <summary>Initializes a new instance of the <see cref="Scroller"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="CoreUI.UI.Widget.SetStyle" /></param>
        public Scroller(CoreUI.Object parent, System.String style = null) : base(efl_ui_scroller_class_get(), parent)
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
        protected Scroller(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Scroller"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal Scroller(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Scroller"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected Scroller(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }


        /// <summary>Sent after the content is set or unset using the current content object.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.ContentContentChangedEventArgs"/></value>
        public event EventHandler<CoreUI.ContentContentChangedEventArgs> ContentChanged
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.ContentContentChangedEventArgs{ Arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Gfx.IEntity) });
                string key = "_EFL_CONTENT_EVENT_CONTENT_CHANGED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_CONTENT_EVENT_CONTENT_CHANGED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event ContentChanged.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnContentChanged(CoreUI.ContentContentChangedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = e.Arg.NativeHandle;
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_CONTENT_EVENT_CONTENT_CHANGED", info, null);
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

        /// <summary>Sub-object currently set as this object&apos;s single content.
        /// 
        /// If it is set multiple times, previous sub-objects are removed first. Therefore, if an invalid <c>content</c> is set the object will become empty (it will have no sub-object).</summary>
        /// <returns>The sub-object.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.Gfx.IEntity GetContent() {
            var _ret_var = CoreUI.IContentNativeMethods.efl_content_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Sub-object currently set as this object&apos;s single content.
        /// 
        /// If it is set multiple times, previous sub-objects are removed first. Therefore, if an invalid <c>content</c> is set the object will become empty (it will have no sub-object).</summary>
        /// <param name="content">The sub-object.</param>
        /// <returns><c>true</c> if <c>content</c> was successfully swallowed.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool SetContent(CoreUI.Gfx.IEntity content) {
            var _ret_var = CoreUI.IContentNativeMethods.efl_content_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), content);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Remove the sub-object currently set as content of this object and return it. This object becomes empty.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>Unswallowed object</returns>
        public virtual CoreUI.Gfx.IEntity UnsetContent() {
            var _ret_var = CoreUI.IContentNativeMethods.efl_content_unset_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
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

        /// <summary>Sub-object currently set as this object&apos;s single content.
        /// 
        /// If it is set multiple times, previous sub-objects are removed first. Therefore, if an invalid <c>content</c> is set the object will become empty (it will have no sub-object).</summary>
        /// <value>The sub-object.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Gfx.IEntity Content {
            get { return GetContent(); }
            set { SetContent(value); }
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

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.UI.Scroller.efl_ui_scroller_class_get();
        }

        /// <summary>Wrapper for native methods and virtual method delegates.
        /// For internal use by generated code only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new class NativeMethods : CoreUI.UI.LayoutBase.NativeMethods
        {
            /// <summary>Gets the list of Eo operations to override.
        /// </summary>
            /// <returns>The list of Eo operations to be overload.</returns>
            internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
            {
                var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
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
                return CoreUI.UI.Scroller.efl_ui_scroller_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

namespace CoreUI.UI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class ScrollerExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.Gfx.IEntity> Content<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Scroller, T>magic = null) where T : CoreUI.UI.Scroller {
            return new CoreUI.BindableProperty<CoreUI.Gfx.IEntity>("content", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.DataTypes.Position2D> ContentPos<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Scroller, T>magic = null) where T : CoreUI.UI.Scroller {
            return new CoreUI.BindableProperty<CoreUI.DataTypes.Position2D>("content_pos", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> ScrollFreeze<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Scroller, T>magic = null) where T : CoreUI.UI.Scroller {
            return new CoreUI.BindableProperty<bool>("scroll_freeze", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> ScrollHold<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Scroller, T>magic = null) where T : CoreUI.UI.Scroller {
            return new CoreUI.BindableProperty<bool>("scroll_hold", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.UI.LayoutOrientation> MovementBlock<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Scroller, T>magic = null) where T : CoreUI.UI.Scroller {
            return new CoreUI.BindableProperty<CoreUI.UI.LayoutOrientation>("movement_block", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.DataTypes.Position2D> StepSize<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Scroller, T>magic = null) where T : CoreUI.UI.Scroller {
            return new CoreUI.BindableProperty<CoreUI.DataTypes.Position2D>("step_size", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

