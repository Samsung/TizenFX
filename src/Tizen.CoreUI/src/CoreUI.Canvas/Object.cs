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
namespace CoreUI.Canvas {
    /// <summary>Event argument wrapper for event <see cref="CoreUI.Canvas.Object.AnimatorTick"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class ObjectAnimatorTickEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Animator tick synchronized with screen vsync if possible.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.EventAnimatorTick Arg { get; set; }
    }

    /// <summary>CoreUI canvas object abstract class</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Canvas.Object.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public abstract class Object : CoreUI.LoopConsumer, CoreUI.Canvas.IObjectAnimation, CoreUI.Canvas.IPointer, CoreUI.Gfx.IColor, CoreUI.Gfx.IEntity, CoreUI.Gfx.IHint, CoreUI.Gfx.IMapping, CoreUI.Gfx.IStack, CoreUI.Input.IInterface
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(Object))
                {
                    return GetCoreUIClassStatic();
                }
                else
                {
                    return CoreUI.Wrapper.ClassRegister.klassFromType[((object)this).GetType()];
                }
            }
        }

        [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Evas)] internal static extern System.IntPtr
            efl_canvas_object_class_get();

        /// <summary>Initializes a new instance of the <see cref="Object"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
        public Object(CoreUI.Object parent= null) : base(efl_canvas_object_class_get(), parent)
        {
            FinishInstantiation();
        }

        /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
        /// Do not call this constructor directly.
        /// </summary>
        /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
        protected Object(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Object"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal Object(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        [CoreUI.Wrapper.PrivateNativeClass]
        private class ObjectRealized : Object
        {
            private ObjectRealized(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
            {
            }
        }
        /// <summary>Initializes a new instance of the <see cref="Object"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected Object(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }

        /// <summary>Animator tick synchronized with screen vsync if possible.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Canvas.ObjectAnimatorTickEventArgs"/></value>
        public event EventHandler<CoreUI.Canvas.ObjectAnimatorTickEventArgs> AnimatorTick
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Canvas.ObjectAnimatorTickEventArgs{ Arg =  info });
                string key = "_EFL_CANVAS_OBJECT_EVENT_ANIMATOR_TICK";
                AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_CANVAS_OBJECT_EVENT_ANIMATOR_TICK";
                RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
            }
        }

        /// <summary>Method to raise event AnimatorTick.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnAnimatorTick(CoreUI.Canvas.ObjectAnimatorTickEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.Arg));
            CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_CANVAS_OBJECT_EVENT_ANIMATOR_TICK", info, (p) => Marshal.FreeHGlobal(p));
        }


        /// <summary>The animation object got changed.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Canvas.ObjectAnimationAnimationChangedEventArgs"/></value>
        public event EventHandler<CoreUI.Canvas.ObjectAnimationAnimationChangedEventArgs> AnimationChanged
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Canvas.ObjectAnimationAnimationChangedEventArgs{ Arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Canvas.Animation) });
                string key = "_EFL_CANVAS_OBJECT_ANIMATION_EVENT_ANIMATION_CHANGED";
                AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_CANVAS_OBJECT_ANIMATION_EVENT_ANIMATION_CHANGED";
                RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
            }
        }

        /// <summary>Method to raise event AnimationChanged.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnAnimationChanged(CoreUI.Canvas.ObjectAnimationAnimationChangedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = e.Arg.NativeHandle;
            CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_CANVAS_OBJECT_ANIMATION_EVENT_ANIMATION_CHANGED", info, null);
        }

        /// <summary>The animation progress got changed.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Canvas.ObjectAnimationAnimationProgressUpdatedEventArgs"/></value>
        public event EventHandler<CoreUI.Canvas.ObjectAnimationAnimationProgressUpdatedEventArgs> AnimationProgressUpdated
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Canvas.ObjectAnimationAnimationProgressUpdatedEventArgs{ Arg = CoreUI.DataTypes.PrimitiveConversion.PointerToManaged<double>(info) });
                string key = "_EFL_CANVAS_OBJECT_ANIMATION_EVENT_ANIMATION_PROGRESS_UPDATED";
                AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_CANVAS_OBJECT_ANIMATION_EVENT_ANIMATION_PROGRESS_UPDATED";
                RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
            }
        }

        /// <summary>Method to raise event AnimationProgressUpdated.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnAnimationProgressUpdated(CoreUI.Canvas.ObjectAnimationAnimationProgressUpdatedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = CoreUI.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(e.Arg);
            CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_CANVAS_OBJECT_ANIMATION_EVENT_ANIMATION_PROGRESS_UPDATED", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Object&apos;s visibility state changed, the event value is the new state.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Gfx.EntityVisibilityChangedEventArgs"/></value>
        public event EventHandler<CoreUI.Gfx.EntityVisibilityChangedEventArgs> VisibilityChanged
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Gfx.EntityVisibilityChangedEventArgs{ Arg = Marshal.ReadByte(info) != 0 });
                string key = "_EFL_GFX_ENTITY_EVENT_VISIBILITY_CHANGED";
                AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_GFX_ENTITY_EVENT_VISIBILITY_CHANGED";
                RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
            }
        }

        /// <summary>Method to raise event VisibilityChanged.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnVisibilityChanged(CoreUI.Gfx.EntityVisibilityChangedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = CoreUI.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(e.Arg ? (byte) 1 : (byte) 0);
            CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_GFX_ENTITY_EVENT_VISIBILITY_CHANGED", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Object was moved, its position during the event is the new one.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Gfx.EntityPositionChangedEventArgs"/></value>
        public event EventHandler<CoreUI.Gfx.EntityPositionChangedEventArgs> PositionChanged
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Gfx.EntityPositionChangedEventArgs{ Arg =  info });
                string key = "_EFL_GFX_ENTITY_EVENT_POSITION_CHANGED";
                AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_GFX_ENTITY_EVENT_POSITION_CHANGED";
                RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
            }
        }

        /// <summary>Method to raise event PositionChanged.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnPositionChanged(CoreUI.Gfx.EntityPositionChangedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.Arg));
            CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_GFX_ENTITY_EVENT_POSITION_CHANGED", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Object was resized, its size during the event is the new one.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Gfx.EntitySizeChangedEventArgs"/></value>
        public event EventHandler<CoreUI.Gfx.EntitySizeChangedEventArgs> SizeChanged
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Gfx.EntitySizeChangedEventArgs{ Arg =  info });
                string key = "_EFL_GFX_ENTITY_EVENT_SIZE_CHANGED";
                AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_GFX_ENTITY_EVENT_SIZE_CHANGED";
                RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
            }
        }

        /// <summary>Method to raise event SizeChanged.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnSizeChanged(CoreUI.Gfx.EntitySizeChangedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.Arg));
            CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_GFX_ENTITY_EVENT_SIZE_CHANGED", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Object hints changed.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler HintsChanged
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_GFX_ENTITY_EVENT_HINTS_CHANGED";
                AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_GFX_ENTITY_EVENT_HINTS_CHANGED";
                RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
            }
        }

        /// <summary>Method to raise event HintsChanged.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnHintsChanged()
        {
            CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_GFX_ENTITY_EVENT_HINTS_CHANGED", IntPtr.Zero, null);
        }

        /// <summary>Object stacking was changed.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler StackingChanged
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_GFX_ENTITY_EVENT_STACKING_CHANGED";
                AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_GFX_ENTITY_EVENT_STACKING_CHANGED";
                RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
            }
        }

        /// <summary>Method to raise event StackingChanged.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnStackingChanged()
        {
            CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_GFX_ENTITY_EVENT_STACKING_CHANGED", IntPtr.Zero, null);
        }

        /// <summary>Main pointer move (current and previous positions are known).</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.InterfacePointerMoveEventArgs"/></value>
        public event EventHandler<CoreUI.Input.InterfacePointerMoveEventArgs> PointerMove
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.InterfacePointerMoveEventArgs{ Arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Input.Pointer) });
                string key = "_EFL_EVENT_POINTER_MOVE";
                AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_EVENT_POINTER_MOVE";
                RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
            }
        }

        /// <summary>Method to raise event PointerMove.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnPointerMove(CoreUI.Input.InterfacePointerMoveEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = e.Arg.NativeHandle;
            CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_EVENT_POINTER_MOVE", info, null);
        }

        /// <summary>Main pointer button pressed (button id is known).</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.InterfacePointerDownEventArgs"/></value>
        public event EventHandler<CoreUI.Input.InterfacePointerDownEventArgs> PointerDown
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.InterfacePointerDownEventArgs{ Arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Input.Pointer) });
                string key = "_EFL_EVENT_POINTER_DOWN";
                AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_EVENT_POINTER_DOWN";
                RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
            }
        }

        /// <summary>Method to raise event PointerDown.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnPointerDown(CoreUI.Input.InterfacePointerDownEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = e.Arg.NativeHandle;
            CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_EVENT_POINTER_DOWN", info, null);
        }

        /// <summary>Main pointer button released (button id is known).</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.InterfacePointerUpEventArgs"/></value>
        public event EventHandler<CoreUI.Input.InterfacePointerUpEventArgs> PointerUp
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.InterfacePointerUpEventArgs{ Arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Input.Pointer) });
                string key = "_EFL_EVENT_POINTER_UP";
                AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_EVENT_POINTER_UP";
                RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
            }
        }

        /// <summary>Method to raise event PointerUp.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnPointerUp(CoreUI.Input.InterfacePointerUpEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = e.Arg.NativeHandle;
            CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_EVENT_POINTER_UP", info, null);
        }

        /// <summary>Main pointer button press was cancelled (button id is known). This can happen in rare cases when the window manager passes the focus to a more urgent window, for instance. You probably don&apos;t need to listen to this event, as it will be accompanied by an up event.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.InterfacePointerCancelEventArgs"/></value>
        public event EventHandler<CoreUI.Input.InterfacePointerCancelEventArgs> PointerCancel
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.InterfacePointerCancelEventArgs{ Arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Input.Pointer) });
                string key = "_EFL_EVENT_POINTER_CANCEL";
                AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_EVENT_POINTER_CANCEL";
                RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
            }
        }

        /// <summary>Method to raise event PointerCancel.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnPointerCancel(CoreUI.Input.InterfacePointerCancelEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = e.Arg.NativeHandle;
            CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_EVENT_POINTER_CANCEL", info, null);
        }

        /// <summary>Pointer entered a window or a widget.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.InterfacePointerInEventArgs"/></value>
        public event EventHandler<CoreUI.Input.InterfacePointerInEventArgs> PointerIn
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.InterfacePointerInEventArgs{ Arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Input.Pointer) });
                string key = "_EFL_EVENT_POINTER_IN";
                AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_EVENT_POINTER_IN";
                RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
            }
        }

        /// <summary>Method to raise event PointerIn.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnPointerIn(CoreUI.Input.InterfacePointerInEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = e.Arg.NativeHandle;
            CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_EVENT_POINTER_IN", info, null);
        }

        /// <summary>Pointer left a window or a widget.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.InterfacePointerOutEventArgs"/></value>
        public event EventHandler<CoreUI.Input.InterfacePointerOutEventArgs> PointerOut
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.InterfacePointerOutEventArgs{ Arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Input.Pointer) });
                string key = "_EFL_EVENT_POINTER_OUT";
                AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_EVENT_POINTER_OUT";
                RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
            }
        }

        /// <summary>Method to raise event PointerOut.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnPointerOut(CoreUI.Input.InterfacePointerOutEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = e.Arg.NativeHandle;
            CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_EVENT_POINTER_OUT", info, null);
        }

        /// <summary>Mouse wheel event.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.InterfacePointerWheelEventArgs"/></value>
        public event EventHandler<CoreUI.Input.InterfacePointerWheelEventArgs> PointerWheel
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.InterfacePointerWheelEventArgs{ Arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Input.Pointer) });
                string key = "_EFL_EVENT_POINTER_WHEEL";
                AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_EVENT_POINTER_WHEEL";
                RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
            }
        }

        /// <summary>Method to raise event PointerWheel.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnPointerWheel(CoreUI.Input.InterfacePointerWheelEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = e.Arg.NativeHandle;
            CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_EVENT_POINTER_WHEEL", info, null);
        }

        /// <summary>Pen or other axis event update.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.InterfacePointerAxisEventArgs"/></value>
        public event EventHandler<CoreUI.Input.InterfacePointerAxisEventArgs> PointerAxis
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.InterfacePointerAxisEventArgs{ Arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Input.Pointer) });
                string key = "_EFL_EVENT_POINTER_AXIS";
                AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_EVENT_POINTER_AXIS";
                RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
            }
        }

        /// <summary>Method to raise event PointerAxis.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnPointerAxis(CoreUI.Input.InterfacePointerAxisEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = e.Arg.NativeHandle;
            CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_EVENT_POINTER_AXIS", info, null);
        }

        /// <summary>Finger moved (current and previous positions are known).</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.InterfaceFingerMoveEventArgs"/></value>
        public event EventHandler<CoreUI.Input.InterfaceFingerMoveEventArgs> FingerMove
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.InterfaceFingerMoveEventArgs{ Arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Input.Pointer) });
                string key = "_EFL_EVENT_FINGER_MOVE";
                AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_EVENT_FINGER_MOVE";
                RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
            }
        }

        /// <summary>Method to raise event FingerMove.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnFingerMove(CoreUI.Input.InterfaceFingerMoveEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = e.Arg.NativeHandle;
            CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_EVENT_FINGER_MOVE", info, null);
        }

        /// <summary>Finger pressed (finger id is known).</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.InterfaceFingerDownEventArgs"/></value>
        public event EventHandler<CoreUI.Input.InterfaceFingerDownEventArgs> FingerDown
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.InterfaceFingerDownEventArgs{ Arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Input.Pointer) });
                string key = "_EFL_EVENT_FINGER_DOWN";
                AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_EVENT_FINGER_DOWN";
                RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
            }
        }

        /// <summary>Method to raise event FingerDown.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnFingerDown(CoreUI.Input.InterfaceFingerDownEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = e.Arg.NativeHandle;
            CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_EVENT_FINGER_DOWN", info, null);
        }

        /// <summary>Finger released (finger id is known).</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.InterfaceFingerUpEventArgs"/></value>
        public event EventHandler<CoreUI.Input.InterfaceFingerUpEventArgs> FingerUp
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.InterfaceFingerUpEventArgs{ Arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Input.Pointer) });
                string key = "_EFL_EVENT_FINGER_UP";
                AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_EVENT_FINGER_UP";
                RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
            }
        }

        /// <summary>Method to raise event FingerUp.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnFingerUp(CoreUI.Input.InterfaceFingerUpEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = e.Arg.NativeHandle;
            CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_EVENT_FINGER_UP", info, null);
        }

        /// <summary>Keyboard key press.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.InterfaceKeyDownEventArgs"/></value>
        public event EventHandler<CoreUI.Input.InterfaceKeyDownEventArgs> KeyDown
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.InterfaceKeyDownEventArgs{ Arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Input.Key) });
                string key = "_EFL_EVENT_KEY_DOWN";
                AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_EVENT_KEY_DOWN";
                RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
            }
        }

        /// <summary>Method to raise event KeyDown.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnKeyDown(CoreUI.Input.InterfaceKeyDownEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = e.Arg.NativeHandle;
            CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_EVENT_KEY_DOWN", info, null);
        }

        /// <summary>Keyboard key release.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.InterfaceKeyUpEventArgs"/></value>
        public event EventHandler<CoreUI.Input.InterfaceKeyUpEventArgs> KeyUp
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.InterfaceKeyUpEventArgs{ Arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Input.Key) });
                string key = "_EFL_EVENT_KEY_UP";
                AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_EVENT_KEY_UP";
                RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
            }
        }

        /// <summary>Method to raise event KeyUp.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnKeyUp(CoreUI.Input.InterfaceKeyUpEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = e.Arg.NativeHandle;
            CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_EVENT_KEY_UP", info, null);
        }

        /// <summary>All input events are on hold or resumed.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.InterfaceHoldEventArgs"/></value>
        public event EventHandler<CoreUI.Input.InterfaceHoldEventArgs> Hold
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.InterfaceHoldEventArgs{ Arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Input.Hold) });
                string key = "_EFL_EVENT_HOLD";
                AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_EVENT_HOLD";
                RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
            }
        }

        /// <summary>Method to raise event Hold.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnHold(CoreUI.Input.InterfaceHoldEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = e.Arg.NativeHandle;
            CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_EVENT_HOLD", info, null);
        }

        /// <summary>A focus in event.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.InterfaceFocusInEventArgs"/></value>
        public event EventHandler<CoreUI.Input.InterfaceFocusInEventArgs> FocusIn
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.InterfaceFocusInEventArgs{ Arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Input.Focus) });
                string key = "_EFL_EVENT_FOCUS_IN";
                AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_EVENT_FOCUS_IN";
                RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
            }
        }

        /// <summary>Method to raise event FocusIn.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnFocusIn(CoreUI.Input.InterfaceFocusInEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = e.Arg.NativeHandle;
            CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_EVENT_FOCUS_IN", info, null);
        }

        /// <summary>A focus out event.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.InterfaceFocusOutEventArgs"/></value>
        public event EventHandler<CoreUI.Input.InterfaceFocusOutEventArgs> FocusOut
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.InterfaceFocusOutEventArgs{ Arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Input.Focus) });
                string key = "_EFL_EVENT_FOCUS_OUT";
                AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_EVENT_FOCUS_OUT";
                RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
            }
        }

        /// <summary>Method to raise event FocusOut.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnFocusOut(CoreUI.Input.InterfaceFocusOutEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = e.Arg.NativeHandle;
            CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_EVENT_FOCUS_OUT", info, null);
        }

        /// <summary>Render mode to be used for compositing the Evas object.
        /// 
        /// Only two modes are supported: - <see cref="CoreUI.Gfx.RenderOp.Blend"/> means the object will be merged on top of objects below it using simple alpha compositing. - <see cref="CoreUI.Gfx.RenderOp.Copy"/> means this object&apos;s pixels will replace everything that is below, making this object opaque.
        /// 
        /// Please do not assume that <see cref="CoreUI.Gfx.RenderOp.Copy"/> mode can be used to &quot;poke&quot; holes in a window (to see through it), as only the compositor can ensure that. Copy mode should only be used with otherwise opaque widgets or inside non-window surfaces (e.g. a transparent background inside a buffer canvas).</summary>
        /// <returns>Blend or copy.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.Gfx.RenderOp GetRenderOp() {
            var _ret_var = CoreUI.Canvas.Object.NativeMethods.efl_canvas_object_render_op_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Render mode to be used for compositing the Evas object.
        /// 
        /// Only two modes are supported: - <see cref="CoreUI.Gfx.RenderOp.Blend"/> means the object will be merged on top of objects below it using simple alpha compositing. - <see cref="CoreUI.Gfx.RenderOp.Copy"/> means this object&apos;s pixels will replace everything that is below, making this object opaque.
        /// 
        /// Please do not assume that <see cref="CoreUI.Gfx.RenderOp.Copy"/> mode can be used to &quot;poke&quot; holes in a window (to see through it), as only the compositor can ensure that. Copy mode should only be used with otherwise opaque widgets or inside non-window surfaces (e.g. a transparent background inside a buffer canvas).</summary>
        /// <param name="render_op">Blend or copy.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetRenderOp(CoreUI.Gfx.RenderOp render_op) {
            CoreUI.Canvas.Object.NativeMethods.efl_canvas_object_render_op_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), render_op);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Clip one object to another.
        /// 
        /// This property will clip the object <c>obj</c> to the area occupied by the object <c>clip</c>. This means the object <c>obj</c> will only be visible within the area occupied by the clipping object (<c>clip</c>).
        /// 
        /// The color of the object being clipped will be multiplied by the color of the clipping one, so the resulting color for the former will be &quot;RESULT = (OBJ * CLIP) / (255 * 255)&quot;, per color element (red, green, blue and alpha).
        /// 
        /// Clipping is recursive, so clipping objects may be clipped by others, and their color will in term be multiplied. You may not set up circular clipping lists (i.e. object 1 clips object 2, which clips object 1): the behavior of Evas is undefined in this case.
        /// 
        /// Objects which do not clip others are visible in the canvas as normal; those that clip one or more objects become invisible themselves, only affecting what they clip. If an object ceases to have other objects being clipped by it, it will become visible again.
        /// 
        /// The visibility of an object affects the objects that are clipped by it, so if the object clipping others is not shown (as in <see cref="CoreUI.Gfx.IEntity.Visible"/>), the objects clipped by it will not be shown  either.
        /// 
        /// If <c>obj</c> was being clipped by another object when this function is  called, it gets implicitly removed from the old clipper&apos;s domain and is made now to be clipped by its new clipper.
        /// 
        /// If <c>clip</c> is <c>null</c>, this call will disable clipping for the object i.e. its visibility and color get detached from the previous clipper. If it wasn&apos;t, this has no effect.
        /// 
        /// <b>NOTE: </b>Only rectangle and image (masks) objects can be used as clippers. Anything else will result in undefined behaviour.</summary>
        /// <returns>The object to clip <c>obj</c> by.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.Canvas.Object GetClipper() {
            var _ret_var = CoreUI.Canvas.Object.NativeMethods.efl_canvas_object_clipper_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Clip one object to another.
        /// 
        /// This property will clip the object <c>obj</c> to the area occupied by the object <c>clip</c>. This means the object <c>obj</c> will only be visible within the area occupied by the clipping object (<c>clip</c>).
        /// 
        /// The color of the object being clipped will be multiplied by the color of the clipping one, so the resulting color for the former will be &quot;RESULT = (OBJ * CLIP) / (255 * 255)&quot;, per color element (red, green, blue and alpha).
        /// 
        /// Clipping is recursive, so clipping objects may be clipped by others, and their color will in term be multiplied. You may not set up circular clipping lists (i.e. object 1 clips object 2, which clips object 1): the behavior of Evas is undefined in this case.
        /// 
        /// Objects which do not clip others are visible in the canvas as normal; those that clip one or more objects become invisible themselves, only affecting what they clip. If an object ceases to have other objects being clipped by it, it will become visible again.
        /// 
        /// The visibility of an object affects the objects that are clipped by it, so if the object clipping others is not shown (as in <see cref="CoreUI.Gfx.IEntity.Visible"/>), the objects clipped by it will not be shown  either.
        /// 
        /// If <c>obj</c> was being clipped by another object when this function is  called, it gets implicitly removed from the old clipper&apos;s domain and is made now to be clipped by its new clipper.
        /// 
        /// If <c>clip</c> is <c>null</c>, this call will disable clipping for the object i.e. its visibility and color get detached from the previous clipper. If it wasn&apos;t, this has no effect.
        /// 
        /// <b>NOTE: </b>Only rectangle and image (masks) objects can be used as clippers. Anything else will result in undefined behaviour.</summary>
        /// <param name="clipper">The object to clip <c>obj</c> by.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetClipper(CoreUI.Canvas.Object clipper) {
            CoreUI.Canvas.Object.NativeMethods.efl_canvas_object_clipper_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), clipper);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Whether an Evas object is to repeat events to objects below it.
        /// 
        /// If <c>repeat</c> is <c>true</c>, it will make events on <c>obj</c> to also be repeated for the next lower object in the objects&apos; stack (see see <see cref="CoreUI.Gfx.IStack.GetBelow"/>).
        /// 
        /// If <c>repeat</c> is <c>false</c>, events occurring on <c>obj</c> will be processed only on it.</summary>
        /// <returns>Whether <c>obj</c> is to repeat events (<c>true</c>) or not (<c>false</c>).</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetRepeatEvents() {
            var _ret_var = CoreUI.Canvas.Object.NativeMethods.efl_canvas_object_repeat_events_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Whether an Evas object is to repeat events to objects below it.
        /// 
        /// If <c>repeat</c> is <c>true</c>, it will make events on <c>obj</c> to also be repeated for the next lower object in the objects&apos; stack (see see <see cref="CoreUI.Gfx.IStack.GetBelow"/>).
        /// 
        /// If <c>repeat</c> is <c>false</c>, events occurring on <c>obj</c> will be processed only on it.</summary>
        /// <param name="repeat">Whether <c>obj</c> is to repeat events (<c>true</c>) or not (<c>false</c>).</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetRepeatEvents(bool repeat) {
            CoreUI.Canvas.Object.NativeMethods.efl_canvas_object_repeat_events_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), repeat);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Indicates that this object is the keyboard event receiver on its canvas.
        /// 
        /// Changing focus only affects where (key) input events go. There can be only one object focused at any time. If <c>focus</c> is <c>true</c>, <c>obj</c> will be set as the currently focused object and it will receive all keyboard events that are not exclusive key grabs on other objects. See also <span class="text-muted">CoreUI.Canvas.Object.CheckSeatFocus (object still in beta stage)</span>, <span class="text-muted">CoreUI.Canvas.Object.AddSeatFocus (object still in beta stage)</span>, <span class="text-muted">CoreUI.Canvas.Object.DelSeatFocus (object still in beta stage)</span>.</summary>
        /// <returns><c>true</c> when set as focused or <c>false</c> otherwise.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetKeyFocus() {
            var _ret_var = CoreUI.Canvas.Object.NativeMethods.efl_canvas_object_key_focus_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Indicates that this object is the keyboard event receiver on its canvas.
        /// 
        /// Changing focus only affects where (key) input events go. There can be only one object focused at any time. If <c>focus</c> is <c>true</c>, <c>obj</c> will be set as the currently focused object and it will receive all keyboard events that are not exclusive key grabs on other objects. See also <span class="text-muted">CoreUI.Canvas.Object.CheckSeatFocus (object still in beta stage)</span>, <span class="text-muted">CoreUI.Canvas.Object.AddSeatFocus (object still in beta stage)</span>, <span class="text-muted">CoreUI.Canvas.Object.DelSeatFocus (object still in beta stage)</span>.</summary>
        /// <param name="focus"><c>true</c> when set as focused or <c>false</c> otherwise.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetKeyFocus(bool focus) {
            CoreUI.Canvas.Object.NativeMethods.efl_canvas_object_key_focus_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), focus);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Check if this object is focused.</summary>
        /// <returns><c>true</c> if focused by at least one seat or <c>false</c> otherwise.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetSeatFocus() {
            var _ret_var = CoreUI.Canvas.Object.NativeMethods.efl_canvas_object_seat_focus_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Whether to use precise (usually expensive) point collision detection for a given Evas object.
        /// 
        /// Use this property to make Evas treat objects&apos; transparent areas as not belonging to it with regard to mouse pointer events. By default, all of the object&apos;s boundary rectangle will be taken in account for them.
        /// 
        /// <b>WARNING: </b>By using precise point collision detection you&apos;ll be making Evas more resource intensive.</summary>
        /// <returns>Whether to use precise point collision detection.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetPreciseIsInside() {
            var _ret_var = CoreUI.Canvas.Object.NativeMethods.efl_canvas_object_precise_is_inside_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Whether to use precise (usually expensive) point collision detection for a given Evas object.
        /// 
        /// Use this property to make Evas treat objects&apos; transparent areas as not belonging to it with regard to mouse pointer events. By default, all of the object&apos;s boundary rectangle will be taken in account for them.
        /// 
        /// <b>WARNING: </b>By using precise point collision detection you&apos;ll be making Evas more resource intensive.</summary>
        /// <param name="precise">Whether to use precise point collision detection.<br/>The default value is <c>false</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetPreciseIsInside(bool precise) {
            CoreUI.Canvas.Object.NativeMethods.efl_canvas_object_precise_is_inside_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), precise);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Whether events on a smart object&apos;s member should be propagated up to its parent.
        /// 
        /// This function has no effect if <c>obj</c> is not a member of a smart object.
        /// 
        /// If <c>prop</c> is <c>true</c>, events occurring on this object will be propagated on to the smart object of which <c>obj</c> is a member. If <c>prop</c> is <c>false</c>, events occurring on this object will not be propagated on to the smart object of which <c>obj</c> is a member.
        /// 
        /// See also <see cref="CoreUI.Canvas.Object.SetRepeatEvents"/>, <see cref="CoreUI.Canvas.Object.SetPassEvents"/>.</summary>
        /// <returns>Whether to propagate events.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetPropagateEvents() {
            var _ret_var = CoreUI.Canvas.Object.NativeMethods.efl_canvas_object_propagate_events_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Whether events on a smart object&apos;s member should be propagated up to its parent.
        /// 
        /// This function has no effect if <c>obj</c> is not a member of a smart object.
        /// 
        /// If <c>prop</c> is <c>true</c>, events occurring on this object will be propagated on to the smart object of which <c>obj</c> is a member. If <c>prop</c> is <c>false</c>, events occurring on this object will not be propagated on to the smart object of which <c>obj</c> is a member.
        /// 
        /// See also <see cref="CoreUI.Canvas.Object.SetRepeatEvents"/>, <see cref="CoreUI.Canvas.Object.SetPassEvents"/>.</summary>
        /// <param name="propagate">Whether to propagate events.<br/>The default value is <c>true</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetPropagateEvents(bool propagate) {
            CoreUI.Canvas.Object.NativeMethods.efl_canvas_object_propagate_events_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), propagate);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Whether an Evas object is to pass (ignore) events.
        /// 
        /// If <c>pass</c> is <c>true</c>, it will make events on <c>obj</c> to be ignored. They will be triggered on the next lower object (that is not set to pass events), instead (see <see cref="CoreUI.Gfx.IStack.GetBelow"/>).
        /// 
        /// If <c>pass</c> is <c>false</c> events will be processed on that object as normal.
        /// 
        /// See also <see cref="CoreUI.Canvas.Object.SetRepeatEvents"/>, <see cref="CoreUI.Canvas.Object.SetPropagateEvents"/></summary>
        /// <returns>Whether <c>obj</c> is to pass events (<c>true</c>) or not (<c>false</c>).</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetPassEvents() {
            var _ret_var = CoreUI.Canvas.Object.NativeMethods.efl_canvas_object_pass_events_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Whether an Evas object is to pass (ignore) events.
        /// 
        /// If <c>pass</c> is <c>true</c>, it will make events on <c>obj</c> to be ignored. They will be triggered on the next lower object (that is not set to pass events), instead (see <see cref="CoreUI.Gfx.IStack.GetBelow"/>).
        /// 
        /// If <c>pass</c> is <c>false</c> events will be processed on that object as normal.
        /// 
        /// See also <see cref="CoreUI.Canvas.Object.SetRepeatEvents"/>, <see cref="CoreUI.Canvas.Object.SetPropagateEvents"/></summary>
        /// <param name="pass">Whether <c>obj</c> is to pass events (<c>true</c>) or not (<c>false</c>).</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetPassEvents(bool pass) {
            CoreUI.Canvas.Object.NativeMethods.efl_canvas_object_pass_events_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), pass);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Whether or not the given Evas object is to be drawn anti-aliased.</summary>
        /// <returns><c>true</c> if the object is to be anti_aliased, <c>false</c> otherwise.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetAntiAlias() {
            var _ret_var = CoreUI.Canvas.Object.NativeMethods.efl_canvas_object_anti_alias_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Whether or not the given Evas object is to be drawn anti-aliased.</summary>
        /// <param name="anti_alias"><c>true</c> if the object is to be anti_aliased, <c>false</c> otherwise.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetAntiAlias(bool anti_alias) {
            CoreUI.Canvas.Object.NativeMethods.efl_canvas_object_anti_alias_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), anti_alias);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>List of objects currently clipped by <c>obj</c>.
        /// 
        /// This returns the internal list handle containing all objects clipped by the object <c>obj</c>. If none are clipped by it, the call returns <c>null</c>. This list is only valid until the clip list is changed and should be fetched again with another call to this function if any objects being clipped by this object are unclipped, clipped by a new object, deleted or get the clipper deleted. These operations will invalidate the list returned, so it should not be used anymore after that point. Any use of the list after this may have undefined results, possibly leading to crashes.
        /// 
        /// See also <see cref="CoreUI.Canvas.Object.Clipper"/>.</summary>
        /// <returns>An iterator over the list of objects clipped by <c>obj</c>.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual IEnumerable<CoreUI.Canvas.Object> GetClippedObjects() {
            var _ret_var = CoreUI.Canvas.Object.NativeMethods.efl_canvas_object_clipped_objects_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return CoreUI.Wrapper.Globals.IteratorToIEnumerable<CoreUI.Canvas.Object>(_ret_var);
        }

        /// <summary>Gets the parent smart object of a given Evas object, if it has one.
        /// 
        /// This can be different from <see cref="CoreUI.Object.Parent"/> because this one is used internally for rendering and the normal parent is what the user expects to be the parent.</summary>
        /// <returns>The parent smart object of <c>obj</c> or <c>null</c>.</returns>
        /// <since_tizen> 6 </since_tizen>
        protected virtual CoreUI.Canvas.Object GetRenderParent() {
            var _ret_var = CoreUI.Canvas.Object.NativeMethods.efl_canvas_object_render_parent_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>This handles text paragraph direction of the given object. Even if the given object is not textblock or text, its smart child objects can inherit the paragraph direction from the given object. The default paragraph direction is <c>inherit</c>.</summary>
        /// <returns>Paragraph direction for the given object.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.TextBidirectionalType GetParagraphDirection() {
            var _ret_var = CoreUI.Canvas.Object.NativeMethods.efl_canvas_object_paragraph_direction_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>This handles text paragraph direction of the given object. Even if the given object is not textblock or text, its smart child objects can inherit the paragraph direction from the given object. The default paragraph direction is <c>inherit</c>.</summary>
        /// <param name="dir">Paragraph direction for the given object.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetParagraphDirection(CoreUI.TextBidirectionalType dir) {
            CoreUI.Canvas.Object.NativeMethods.efl_canvas_object_paragraph_direction_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), dir);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Disables all rendering on the canvas.
        /// 
        /// This flag will be used to indicate to Evas that this object should never be rendered on the canvas under any circumstances. In particular, this is useful to avoid drawing clipper objects (or masks) even when they don&apos;t clip any object. This can also be used to replace the old source_visible flag with proxy objects.
        /// 
        /// This is different to the visible property, as even visible objects marked as &quot;no-render&quot; will never appear on screen. But those objects can still be used as proxy sources or clippers. When hidden, all &quot;no-render&quot; objects will completely disappear from the canvas, and hide their clippees or be invisible when used as proxy sources.</summary>
        /// <returns>Enable &quot;no-render&quot; mode.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetNoRender() {
            var _ret_var = CoreUI.Canvas.Object.NativeMethods.efl_canvas_object_no_render_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Disables all rendering on the canvas.
        /// 
        /// This flag will be used to indicate to Evas that this object should never be rendered on the canvas under any circumstances. In particular, this is useful to avoid drawing clipper objects (or masks) even when they don&apos;t clip any object. This can also be used to replace the old source_visible flag with proxy objects.
        /// 
        /// This is different to the visible property, as even visible objects marked as &quot;no-render&quot; will never appear on screen. But those objects can still be used as proxy sources or clippers. When hidden, all &quot;no-render&quot; objects will completely disappear from the canvas, and hide their clippees or be invisible when used as proxy sources.</summary>
        /// <param name="enable">Enable &quot;no-render&quot; mode.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetNoRender(bool enable) {
            CoreUI.Canvas.Object.NativeMethods.efl_canvas_object_no_render_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), enable);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Whether the coordinates are logically inside the object.
        /// 
        /// A value of <c>true</c> indicates the position is logically inside the object, and <c>false</c> implies it is logically outside the object.
        /// 
        /// If <c>obj</c> is not a valid object, the return value is undefined.</summary>
        /// <param name="pos">The coordinates in pixels.</param>
        /// <returns><c>true</c> if the coordinates are inside the object, <c>false</c> otherwise</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetCoordsInside(CoreUI.DataTypes.Position2D pos) {
            CoreUI.DataTypes.Position2D _in_pos = pos;
var _ret_var = CoreUI.Canvas.Object.NativeMethods.efl_canvas_object_coords_inside_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), _in_pos);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Returns the number of objects clipped by <c>obj</c></summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>The number of objects clipped by <c>obj</c></returns>
        public virtual uint ClippedObjectsCount() {
            var _ret_var = CoreUI.Canvas.Object.NativeMethods.efl_canvas_object_clipped_objects_count_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Requests <c>keyname</c> key events be directed to <c>obj</c>.
        /// 
        /// Key grabs allow one or more objects to receive key events for specific key strokes even if other objects have focus. Whenever a key is grabbed, only the objects grabbing it will get the events for the given keys.
        /// 
        /// <c>keyname</c> is a platform dependent symbolic name for the key pressed.
        /// 
        /// <c>modifiers</c> and <c>not_modifiers</c> are bit masks of all the modifiers that must and mustn&apos;t, respectively, be pressed along with <c>keyname</c> key in order to trigger this new key grab. Modifiers can be things such as Shift and Ctrl as well as user defined types via ref evas_key_modifier_add. <c>exclusive</c> will make the given object the only one permitted to grab the given key. If given <c>true</c>, subsequent calls on this function with different <c>obj</c> arguments will fail, unless the key is ungrabbed again.
        /// 
        /// <b>WARNING: </b>Providing impossible modifier sets creates undefined behavior.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="keyname">The key to request events for.</param>
        /// <param name="modifiers">A combination of modifier keys that must be present to trigger the event.</param>
        /// <param name="not_modifiers">A combination of modifier keys that must not be present to trigger the event.</param>
        /// <param name="exclusive">Request that the <c>obj</c> is the only object receiving the <c>keyname</c> events.</param>
        /// <returns><c>true</c> if the call succeeded, <c>false</c> otherwise.</returns>
        public virtual bool GrabKey(System.String keyname, CoreUI.Input.Modifier modifiers, CoreUI.Input.Modifier not_modifiers, bool exclusive) {
            var _ret_var = CoreUI.Canvas.Object.NativeMethods.efl_canvas_object_key_grab_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), keyname, modifiers, not_modifiers, exclusive);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Removes the grab on <c>keyname</c> key events by <c>obj</c>.
        /// 
        /// Removes a key grab on <c>obj</c> if <c>keyname</c>, <c>modifiers</c>, and <c>not_modifiers</c> match.
        /// 
        /// See also <see cref="CoreUI.Canvas.Object.GrabKey"/>, <see cref="CoreUI.Canvas.Object.GetKeyFocus"/>, <see cref="CoreUI.Canvas.Object.SetKeyFocus"/>, and the legacy API evas_focus_get.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="keyname">The key the grab is set for.</param>
        /// <param name="modifiers">A mask of modifiers that must be present to trigger the event.</param>
        /// <param name="not_modifiers">A mask of modifiers that must not not be present to trigger the event.</param>
        public virtual void UngrabKey(System.String keyname, CoreUI.Input.Modifier modifiers, CoreUI.Input.Modifier not_modifiers) {
            CoreUI.Canvas.Object.NativeMethods.efl_canvas_object_key_ungrab_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), keyname, modifiers, not_modifiers);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The animation that is currently played on the canvas object.
        /// 
        /// <c>null</c> in case that there is no animation running.</summary>
        /// <returns>The animation which is currently applied on this object.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.Canvas.Animation GetAnimation() {
            var _ret_var = CoreUI.Canvas.IObjectAnimationNativeMethods.efl_canvas_object_animation_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The current progress of the animation, between <c>0.0</c> and <c>1.0</c>.
        /// 
        /// Even if the animation is going backwards (speed &lt; 0.0) the progress will still go from <c>0.0</c> to <c>1.0</c>.
        /// 
        /// If there is no animation going on, this will return <c>-1.0</c>.</summary>
        /// <returns>Current progress of the animation.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual double GetAnimationProgress() {
            var _ret_var = CoreUI.Canvas.IObjectAnimationNativeMethods.efl_canvas_object_animation_progress_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Pause the animation.
        /// 
        /// <see cref="CoreUI.Canvas.IObjectAnimation.GetAnimation"/> will not be unset. When <c>pause</c> is <c>false</c>, the animation will be resumed at the same progress it was when it was paused.</summary>
        /// <returns>Paused state.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetAnimationPause() {
            var _ret_var = CoreUI.Canvas.IObjectAnimationNativeMethods.efl_canvas_object_animation_pause_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Pause the animation.
        /// 
        /// <see cref="CoreUI.Canvas.IObjectAnimation.GetAnimation"/> will not be unset. When <c>pause</c> is <c>false</c>, the animation will be resumed at the same progress it was when it was paused.</summary>
        /// <param name="pause">Paused state.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetAnimationPause(bool pause) {
            CoreUI.Canvas.IObjectAnimationNativeMethods.efl_canvas_object_animation_pause_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), pause);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Start a new animation.
        /// 
        /// If there is an animation going on, it is stopped and the previous <see cref="CoreUI.Canvas.IObjectAnimation.GetAnimation"/> object is replaced. Its lifetime is adjusted accordingly.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="animation">The animation to start. When not needed anymore, the reference that was passed is given up.</param>
        /// <param name="speed">The speed of the playback. <c>1.0</c> is normal playback. Negative values mean reverse playback.</param>
        /// <param name="starting_progress">The progress point where to start. Must be between <c>0.0</c> and <c>1.0</c>. Useful to revert an animation which has already started.</param>
        public virtual void AnimationStart(CoreUI.Canvas.Animation animation, double speed, double starting_progress) {
            CoreUI.Canvas.IObjectAnimationNativeMethods.efl_canvas_object_animation_start_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), animation, speed, starting_progress);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Stop the animation.
        /// 
        /// After this call, <see cref="CoreUI.Canvas.IObjectAnimation.GetAnimation"/> will return <c>null</c>. The reference that was taken during <see cref="CoreUI.Canvas.IObjectAnimation.AnimationStart"/> will be given up.</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void AnimationStop() {
            CoreUI.Canvas.IObjectAnimationNativeMethods.efl_canvas_object_animation_stop_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The general/main color of the given Evas object.
        /// 
        /// Represents the main color&apos;s RGB component (and alpha channel) values, which range from 0 to 255. For the alpha channel, which defines the object&apos;s transparency level, 0 means totally transparent, while 255 means opaque. These color values are premultiplied by the alpha value.
        /// 
        /// Usually you&apos;ll use this attribute for text and rectangle objects, where the main color is the only color. If set for objects which themselves have colors, like the images one, those colors get modulated by this one.
        /// 
        /// All newly created Evas rectangles get the default color values of 255 255 255 255 (opaque white).
        /// 
        /// When reading this property, use <c>NULL</c> pointers on the components you&apos;re not interested in and they&apos;ll be ignored by the function.</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetColor(out int r, out int g, out int b, out int a) {
            CoreUI.Gfx.IColorNativeMethods.efl_gfx_color_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out r, out g, out b, out a);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The general/main color of the given Evas object.
        /// 
        /// Represents the main color&apos;s RGB component (and alpha channel) values, which range from 0 to 255. For the alpha channel, which defines the object&apos;s transparency level, 0 means totally transparent, while 255 means opaque. These color values are premultiplied by the alpha value.
        /// 
        /// Usually you&apos;ll use this attribute for text and rectangle objects, where the main color is the only color. If set for objects which themselves have colors, like the images one, those colors get modulated by this one.
        /// 
        /// All newly created Evas rectangles get the default color values of 255 255 255 255 (opaque white).
        /// 
        /// When reading this property, use <c>NULL</c> pointers on the components you&apos;re not interested in and they&apos;ll be ignored by the function.</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetColor(int r, int g, int b, int a) {
            CoreUI.Gfx.IColorNativeMethods.efl_gfx_color_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), r, g, b, a);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Hexadecimal color code of given Evas object (#RRGGBBAA).</summary>
        /// <returns>the hex color code.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual System.String GetColorCode() {
            var _ret_var = CoreUI.Gfx.IColorNativeMethods.efl_gfx_color_code_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Hexadecimal color code of given Evas object (#RRGGBBAA).</summary>
        /// <param name="colorcode">the hex color code.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetColorCode(System.String colorcode) {
            CoreUI.Gfx.IColorNativeMethods.efl_gfx_color_code_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), colorcode);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The 2D position of a canvas object.
        /// 
        /// The position is absolute, in pixels, relative to the top-left corner of the window, within its border decorations (application space).<br/>
        /// <b>Note:</b> Retrieves the position of the given canvas object.</summary>
        /// <returns>A 2D coordinate in pixel units.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Position2D GetPosition() {
            var _ret_var = CoreUI.Gfx.IEntityNativeMethods.efl_gfx_entity_position_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The 2D position of a canvas object.
        /// 
        /// The position is absolute, in pixels, relative to the top-left corner of the window, within its border decorations (application space).<br/>
        /// <b>Note:</b> Moves the given canvas object to the given location inside its canvas&apos; viewport. If unchanged this call may be entirely skipped, but if changed this will trigger move events, as well as potential pointer,in or pointer,out events.</summary>
        /// <param name="pos">A 2D coordinate in pixel units.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetPosition(CoreUI.DataTypes.Position2D pos) {
            CoreUI.DataTypes.Position2D _in_pos = pos;
CoreUI.Gfx.IEntityNativeMethods.efl_gfx_entity_position_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), _in_pos);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The 2D size of a canvas object.<br/>
        /// <b>Note:</b> Retrieves the (rectangular) size of the given Evas object.</summary>
        /// <returns>A 2D size in pixel units.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Size2D GetSize() {
            var _ret_var = CoreUI.Gfx.IEntityNativeMethods.efl_gfx_entity_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The 2D size of a canvas object.<br/>
        /// <b>Note:</b> Changes the size of the given object.
        /// 
        /// Note that setting the actual size of an object might be the job of its container, so this function might have no effect. Look at <see cref="CoreUI.Gfx.IHint"/> instead, when manipulating widgets.</summary>
        /// <param name="size">A 2D size in pixel units.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetSize(CoreUI.DataTypes.Size2D size) {
            CoreUI.DataTypes.Size2D _in_size = size;
CoreUI.Gfx.IEntityNativeMethods.efl_gfx_entity_size_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), _in_size);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Rectangular geometry that combines both position and size.</summary>
        /// <returns>The X,Y position and W,H size, in pixels.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Rect GetGeometry() {
            var _ret_var = CoreUI.Gfx.IEntityNativeMethods.efl_gfx_entity_geometry_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Rectangular geometry that combines both position and size.</summary>
        /// <param name="rect">The X,Y position and W,H size, in pixels.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetGeometry(CoreUI.DataTypes.Rect rect) {
            CoreUI.DataTypes.Rect _in_rect = rect;
CoreUI.Gfx.IEntityNativeMethods.efl_gfx_entity_geometry_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), _in_rect);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The visibility of a canvas object.
        /// 
        /// All canvas objects will become visible by default just before render. This means that it is not required to call <see cref="CoreUI.Gfx.IEntity.SetVisible"/> after creating an object unless you want to create it without showing it. Note that this behavior is new since 1.21, and only applies to canvas objects created with the EO API (i.e. not the legacy C-only API). Other types of Gfx objects may or may not be visible by default.
        /// 
        /// Note that many other parameters can prevent a visible object from actually being &quot;visible&quot; on screen. For instance if its color is fully transparent, or its parent is hidden, or it is clipped out, etc...<br/>
        /// <b>Note:</b> Retrieves whether or not the given canvas object is visible.</summary>
        /// <returns><c>true</c> if to make the object visible, <c>false</c> otherwise</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetVisible() {
            var _ret_var = CoreUI.Gfx.IEntityNativeMethods.efl_gfx_entity_visible_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The visibility of a canvas object.
        /// 
        /// All canvas objects will become visible by default just before render. This means that it is not required to call <see cref="CoreUI.Gfx.IEntity.SetVisible"/> after creating an object unless you want to create it without showing it. Note that this behavior is new since 1.21, and only applies to canvas objects created with the EO API (i.e. not the legacy C-only API). Other types of Gfx objects may or may not be visible by default.
        /// 
        /// Note that many other parameters can prevent a visible object from actually being &quot;visible&quot; on screen. For instance if its color is fully transparent, or its parent is hidden, or it is clipped out, etc...<br/>
        /// <b>Note:</b> Shows or hides this object.</summary>
        /// <param name="v"><c>true</c> if to make the object visible, <c>false</c> otherwise</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetVisible(bool v) {
            CoreUI.Gfx.IEntityNativeMethods.efl_gfx_entity_visible_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), v);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The scaling factor of an object.
        /// 
        /// This property is an individual scaling factor on the object (Edje or UI widget). This property (or Edje&apos;s global scaling factor, when applicable), will affect this object&apos;s part sizes. If scale is not zero, then the individual scaling will override any global scaling set, for the object obj&apos;s parts. Set it back to zero to get the effects of the global scaling again.
        /// 
        /// <b>WARNING: </b>In Edje, only parts which, at EDC level, had the &quot;scale&quot; property set to 1, will be affected by this function. Check the complete &quot;syntax reference&quot; for EDC files.<br/>
        /// <b>Note:</b> Gets an object&apos;s scaling factor.</summary>
        /// <returns>The scaling factor.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual double GetScale() {
            var _ret_var = CoreUI.Gfx.IEntityNativeMethods.efl_gfx_entity_scale_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The scaling factor of an object.
        /// 
        /// This property is an individual scaling factor on the object (Edje or UI widget). This property (or Edje&apos;s global scaling factor, when applicable), will affect this object&apos;s part sizes. If scale is not zero, then the individual scaling will override any global scaling set, for the object obj&apos;s parts. Set it back to zero to get the effects of the global scaling again.
        /// 
        /// <b>WARNING: </b>In Edje, only parts which, at EDC level, had the &quot;scale&quot; property set to 1, will be affected by this function. Check the complete &quot;syntax reference&quot; for EDC files.<br/>
        /// <b>Note:</b> Sets the scaling factor of an object.</summary>
        /// <param name="scale">The scaling factor.<br/>The default value is <c>0.000000</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetScale(double scale) {
            CoreUI.Gfx.IEntityNativeMethods.efl_gfx_entity_scale_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), scale);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Defines the aspect ratio to respect when scaling this object.
        /// 
        /// The aspect ratio is defined as the width / height ratio of the object. Depending on the object and its container, this hint may or may not be fully respected.
        /// 
        /// If any of the given aspect ratio terms are 0, the object&apos;s container will ignore the aspect and scale this object to occupy the whole available area, for any given policy.</summary>
        /// <param name="mode">Mode of interpretation.</param>
        /// <param name="sz">Base size to use for aspecting.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetHintAspect(out CoreUI.Gfx.HintAspect mode, out CoreUI.DataTypes.Size2D sz) {
            var _out_sz = new CoreUI.DataTypes.Size2D();
CoreUI.Gfx.IHintNativeMethods.efl_gfx_hint_aspect_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out mode, out _out_sz);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
sz = _out_sz;
            
        }

        /// <summary>Defines the aspect ratio to respect when scaling this object.
        /// 
        /// The aspect ratio is defined as the width / height ratio of the object. Depending on the object and its container, this hint may or may not be fully respected.
        /// 
        /// If any of the given aspect ratio terms are 0, the object&apos;s container will ignore the aspect and scale this object to occupy the whole available area, for any given policy.</summary>
        /// <param name="mode">Mode of interpretation.</param>
        /// <param name="sz">Base size to use for aspecting.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetHintAspect(CoreUI.Gfx.HintAspect mode, CoreUI.DataTypes.Size2D sz) {
            CoreUI.DataTypes.Size2D _in_sz = sz;
CoreUI.Gfx.IHintNativeMethods.efl_gfx_hint_aspect_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), mode, _in_sz);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Hints on the object&apos;s maximum size.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
        /// 
        /// The object container is in charge of fetching this property and placing the object accordingly.
        /// 
        /// Values -1 will be treated as unset hint components, when queried by managers.
        /// 
        /// <b>NOTE: </b>Smart objects (such as elementary) can have their own hint policy. So calling this API may or may not affect the size of smart objects.
        /// 
        /// <b>NOTE: </b>It is an error for the <see cref="CoreUI.Gfx.IHint.HintSizeMax"/> to be smaller in either axis than <see cref="CoreUI.Gfx.IHint.HintSizeMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.</summary>
        /// <returns>Maximum size (hint) in pixels, (-1, -1) by default for canvas objects).</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Size2D GetHintSizeMax() {
            var _ret_var = CoreUI.Gfx.IHintNativeMethods.efl_gfx_hint_size_max_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Hints on the object&apos;s maximum size.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
        /// 
        /// The object container is in charge of fetching this property and placing the object accordingly.
        /// 
        /// Values -1 will be treated as unset hint components, when queried by managers.
        /// 
        /// <b>NOTE: </b>Smart objects (such as elementary) can have their own hint policy. So calling this API may or may not affect the size of smart objects.
        /// 
        /// <b>NOTE: </b>It is an error for the <see cref="CoreUI.Gfx.IHint.HintSizeMax"/> to be smaller in either axis than <see cref="CoreUI.Gfx.IHint.HintSizeMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.</summary>
        /// <param name="sz">Maximum size (hint) in pixels, (-1, -1) by default for canvas objects).</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetHintSizeMax(CoreUI.DataTypes.Size2D sz) {
            CoreUI.DataTypes.Size2D _in_sz = sz;
CoreUI.Gfx.IHintNativeMethods.efl_gfx_hint_size_max_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), _in_sz);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Internal hints for an object&apos;s maximum size.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
        /// 
        /// Values -1 will be treated as unset hint components, when queried by managers.
        /// 
        /// <b>NOTE: </b>This property is internal and meant for widget developers to define the absolute maximum size of the object. EFL itself sets this size internally, so any change to it from an application might be ignored. Applications should use <see cref="CoreUI.Gfx.IHint.HintSizeMax"/> instead.
        /// 
        /// <b>NOTE: </b>It is an error for the <see cref="CoreUI.Gfx.IHint.HintSizeRestrictedMax"/> to be smaller in either axis than <see cref="CoreUI.Gfx.IHint.HintSizeRestrictedMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.</summary>
        /// <returns>Maximum size (hint) in pixels.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Size2D GetHintSizeRestrictedMax() {
            var _ret_var = CoreUI.Gfx.IHintNativeMethods.efl_gfx_hint_size_restricted_max_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Internal hints for an object&apos;s maximum size.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
        /// 
        /// Values -1 will be treated as unset hint components, when queried by managers.
        /// 
        /// <b>NOTE: </b>This property is internal and meant for widget developers to define the absolute maximum size of the object. EFL itself sets this size internally, so any change to it from an application might be ignored. Applications should use <see cref="CoreUI.Gfx.IHint.HintSizeMax"/> instead.
        /// 
        /// <b>NOTE: </b>It is an error for the <see cref="CoreUI.Gfx.IHint.HintSizeRestrictedMax"/> to be smaller in either axis than <see cref="CoreUI.Gfx.IHint.HintSizeRestrictedMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.<br/>
        /// <b>Note:</b> This function is protected as it is meant for widgets to indicate their &quot;intrinsic&quot; maximum size.</summary>
        /// <param name="sz">Maximum size (hint) in pixels.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void SetHintSizeRestrictedMax(CoreUI.DataTypes.Size2D sz) {
            CoreUI.DataTypes.Size2D _in_sz = sz;
CoreUI.Gfx.IHintNativeMethods.efl_gfx_hint_size_restricted_max_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), _in_sz);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Read-only maximum size combining both <see cref="CoreUI.Gfx.IHint.HintSizeRestrictedMax"/> and <see cref="CoreUI.Gfx.IHint.HintSizeMax"/> hints.
        /// 
        /// <see cref="CoreUI.Gfx.IHint.HintSizeRestrictedMax"/> is intended for mostly internal usage and widget developers, and <see cref="CoreUI.Gfx.IHint.HintSizeMax"/> is intended to be set from application side. <see cref="CoreUI.Gfx.IHint.GetHintSizeCombinedMax"/> combines both values by taking their repective maximum (in both width and height), and is used internally to get an object&apos;s maximum size.</summary>
        /// <returns>Maximum size (hint) in pixels.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Size2D GetHintSizeCombinedMax() {
            var _ret_var = CoreUI.Gfx.IHintNativeMethods.efl_gfx_hint_size_combined_max_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Hints on the object&apos;s minimum size.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate. The object container is in charge of fetching this property and placing the object accordingly.
        /// 
        /// Value 0 will be treated as unset hint components, when queried by managers.
        /// 
        /// <b>NOTE: </b>This property is meant to be set by applications and not by EFL itself. Use this to request a specific size (treated as minimum size).
        /// 
        /// <b>NOTE: </b>It is an error for the <see cref="CoreUI.Gfx.IHint.HintSizeMax"/> to be smaller in either axis than <see cref="CoreUI.Gfx.IHint.HintSizeMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.</summary>
        /// <returns>Minimum size (hint) in pixels.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Size2D GetHintSizeMin() {
            var _ret_var = CoreUI.Gfx.IHintNativeMethods.efl_gfx_hint_size_min_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Hints on the object&apos;s minimum size.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate. The object container is in charge of fetching this property and placing the object accordingly.
        /// 
        /// Value 0 will be treated as unset hint components, when queried by managers.
        /// 
        /// <b>NOTE: </b>This property is meant to be set by applications and not by EFL itself. Use this to request a specific size (treated as minimum size).
        /// 
        /// <b>NOTE: </b>It is an error for the <see cref="CoreUI.Gfx.IHint.HintSizeMax"/> to be smaller in either axis than <see cref="CoreUI.Gfx.IHint.HintSizeMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.</summary>
        /// <param name="sz">Minimum size (hint) in pixels.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetHintSizeMin(CoreUI.DataTypes.Size2D sz) {
            CoreUI.DataTypes.Size2D _in_sz = sz;
CoreUI.Gfx.IHintNativeMethods.efl_gfx_hint_size_min_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), _in_sz);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Internal hints for an object&apos;s minimum size.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
        /// 
        /// Values 0 will be treated as unset hint components, when queried by managers.
        /// 
        /// <b>NOTE: </b>This property is internal and meant for widget developers to define the absolute minimum size of the object. EFL itself sets this size internally, so any change to it from an application might be ignored. Use <see cref="CoreUI.Gfx.IHint.HintSizeMin"/> instead.
        /// 
        /// <b>NOTE: </b>It is an error for the <see cref="CoreUI.Gfx.IHint.HintSizeRestrictedMax"/> to be smaller in either axis than <see cref="CoreUI.Gfx.IHint.HintSizeRestrictedMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.<br/>
        /// <b>Note:</b> Get the &quot;intrinsic&quot; minimum size of this object.</summary>
        /// <returns>Minimum size (hint) in pixels.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Size2D GetHintSizeRestrictedMin() {
            var _ret_var = CoreUI.Gfx.IHintNativeMethods.efl_gfx_hint_size_restricted_min_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Internal hints for an object&apos;s minimum size.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
        /// 
        /// Values 0 will be treated as unset hint components, when queried by managers.
        /// 
        /// <b>NOTE: </b>This property is internal and meant for widget developers to define the absolute minimum size of the object. EFL itself sets this size internally, so any change to it from an application might be ignored. Use <see cref="CoreUI.Gfx.IHint.HintSizeMin"/> instead.
        /// 
        /// <b>NOTE: </b>It is an error for the <see cref="CoreUI.Gfx.IHint.HintSizeRestrictedMax"/> to be smaller in either axis than <see cref="CoreUI.Gfx.IHint.HintSizeRestrictedMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.<br/>
        /// <b>Note:</b> This function is protected as it is meant for widgets to indicate their &quot;intrinsic&quot; minimum size.</summary>
        /// <param name="sz">Minimum size (hint) in pixels.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void SetHintSizeRestrictedMin(CoreUI.DataTypes.Size2D sz) {
            CoreUI.DataTypes.Size2D _in_sz = sz;
CoreUI.Gfx.IHintNativeMethods.efl_gfx_hint_size_restricted_min_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), _in_sz);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Read-only minimum size combining both <see cref="CoreUI.Gfx.IHint.HintSizeRestrictedMin"/> and <see cref="CoreUI.Gfx.IHint.HintSizeMin"/> hints.
        /// 
        /// <see cref="CoreUI.Gfx.IHint.HintSizeRestrictedMin"/> is intended for mostly internal usage and widget developers, and <see cref="CoreUI.Gfx.IHint.HintSizeMin"/> is intended to be set from application side. <see cref="CoreUI.Gfx.IHint.GetHintSizeCombinedMin"/> combines both values by taking their repective maximum (in both width and height), and is used internally to get an object&apos;s minimum size.</summary>
        /// <returns>Minimum size (hint) in pixels.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Size2D GetHintSizeCombinedMin() {
            var _ret_var = CoreUI.Gfx.IHintNativeMethods.efl_gfx_hint_size_combined_min_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Hints for an object&apos;s margin or padding space.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
        /// 
        /// The object container is in charge of fetching this property and placing the object accordingly.
        /// 
        /// <b>NOTE: </b>Smart objects (such as elementary) can have their own hint policy. So calling this API may or may not affect the size of smart objects.</summary>
        /// <param name="l">Integer to specify left padding.</param>
        /// <param name="r">Integer to specify right padding.</param>
        /// <param name="t">Integer to specify top padding.</param>
        /// <param name="b">Integer to specify bottom padding.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetHintMargin(out int l, out int r, out int t, out int b) {
            CoreUI.Gfx.IHintNativeMethods.efl_gfx_hint_margin_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out l, out r, out t, out b);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Hints for an object&apos;s margin or padding space.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
        /// 
        /// The object container is in charge of fetching this property and placing the object accordingly.
        /// 
        /// <b>NOTE: </b>Smart objects (such as elementary) can have their own hint policy. So calling this API may or may not affect the size of smart objects.</summary>
        /// <param name="l">Integer to specify left padding.</param>
        /// <param name="r">Integer to specify right padding.</param>
        /// <param name="t">Integer to specify top padding.</param>
        /// <param name="b">Integer to specify bottom padding.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetHintMargin(int l, int r, int t, int b) {
            CoreUI.Gfx.IHintNativeMethods.efl_gfx_hint_margin_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), l, r, t, b);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Hints for an object&apos;s weight.
        /// 
        /// This is a hint on how a container object should resize a given child within its area. Containers may adhere to the simpler logic of just expanding the child object&apos;s dimensions to fit its own (see the <see cref="CoreUI.Gfx.Constants.HintExpand"/> helper weight macro) or the complete one of taking each child&apos;s weight hint as real weights to how much of its size to allocate for them in each axis. A container is supposed to, after normalizing the weights of its children (with weight  hints), distribut the space it has to layout them by those factors -- most weighted children get larger in this process than the least ones.
        /// 
        /// Accepted values are zero or positive values. Some containers might use this hint as a boolean, but some others might consider it as a proportion, see documentation of each container.
        /// 
        /// <b>NOTE: </b>Default weight hint values are 0.0, for both axis.</summary>
        /// <param name="x">Non-negative double value to use as horizontal weight hint.</param>
        /// <param name="y">Non-negative double value to use as vertical weight hint.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetHintWeight(out double x, out double y) {
            CoreUI.Gfx.IHintNativeMethods.efl_gfx_hint_weight_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out x, out y);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Hints for an object&apos;s weight.
        /// 
        /// This is a hint on how a container object should resize a given child within its area. Containers may adhere to the simpler logic of just expanding the child object&apos;s dimensions to fit its own (see the <see cref="CoreUI.Gfx.Constants.HintExpand"/> helper weight macro) or the complete one of taking each child&apos;s weight hint as real weights to how much of its size to allocate for them in each axis. A container is supposed to, after normalizing the weights of its children (with weight  hints), distribut the space it has to layout them by those factors -- most weighted children get larger in this process than the least ones.
        /// 
        /// Accepted values are zero or positive values. Some containers might use this hint as a boolean, but some others might consider it as a proportion, see documentation of each container.
        /// 
        /// <b>NOTE: </b>Default weight hint values are 0.0, for both axis.</summary>
        /// <param name="x">Non-negative double value to use as horizontal weight hint.</param>
        /// <param name="y">Non-negative double value to use as vertical weight hint.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetHintWeight(double x, double y) {
            CoreUI.Gfx.IHintNativeMethods.efl_gfx_hint_weight_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), x, y);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Hints for an object&apos;s alignment.
        /// 
        /// These are hints on how to align this object inside the boundaries of its container/manager.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.</summary>
        /// <param name="x">Controls the horizontal alignment.<br/>The default value is <c>0.500000</c>.</param>
        /// <param name="y">Controls the vertical alignment.<br/>The default value is <c>0.500000</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetHintAlign(out CoreUI.Gfx.Align x, out CoreUI.Gfx.Align y) {
            CoreUI.Gfx.IHintNativeMethods.efl_gfx_hint_align_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out x, out y);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Hints for an object&apos;s alignment.
        /// 
        /// These are hints on how to align this object inside the boundaries of its container/manager.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.</summary>
        /// <param name="x">Controls the horizontal alignment.<br/>The default value is <c>0.500000</c>.</param>
        /// <param name="y">Controls the vertical alignment.<br/>The default value is <c>0.500000</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetHintAlign(CoreUI.Gfx.Align x, CoreUI.Gfx.Align y) {
            CoreUI.Gfx.IHintNativeMethods.efl_gfx_hint_align_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), x, y);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Hints for an object&apos;s fill property that used to specify &quot;justify&quot; or &quot;fill&quot; by some users. <see cref="CoreUI.Gfx.IHint.HintFill"/> specify whether to fill the space inside the boundaries of a container/manager.
        /// 
        /// Maximum hints should be enforced with higher priority, if they are set. Also, any <see cref="CoreUI.Gfx.IHint.HintMargin"/> set on objects should add up to the object space on the final scene composition.
        /// 
        /// See documentation of possible users: in Evas, they are the <see cref="CoreUI.UI.Box"/> &quot;box&quot; and <see cref="CoreUI.UI.Table"/> &quot;table&quot; smart objects.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
        /// 
        /// <b>NOTE: </b>Default fill hint values are true, for both axes.</summary>
        /// <param name="x"><c>true</c> if to fill the object space, <c>false</c> otherwise, to use as horizontal fill hint.</param>
        /// <param name="y"><c>true</c> if to fill the object space, <c>false</c> otherwise, to use as vertical fill hint.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetHintFill(out bool x, out bool y) {
            CoreUI.Gfx.IHintNativeMethods.efl_gfx_hint_fill_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out x, out y);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Hints for an object&apos;s fill property that used to specify &quot;justify&quot; or &quot;fill&quot; by some users. <see cref="CoreUI.Gfx.IHint.HintFill"/> specify whether to fill the space inside the boundaries of a container/manager.
        /// 
        /// Maximum hints should be enforced with higher priority, if they are set. Also, any <see cref="CoreUI.Gfx.IHint.HintMargin"/> set on objects should add up to the object space on the final scene composition.
        /// 
        /// See documentation of possible users: in Evas, they are the <see cref="CoreUI.UI.Box"/> &quot;box&quot; and <see cref="CoreUI.UI.Table"/> &quot;table&quot; smart objects.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
        /// 
        /// <b>NOTE: </b>Default fill hint values are true, for both axes.</summary>
        /// <param name="x"><c>true</c> if to fill the object space, <c>false</c> otherwise, to use as horizontal fill hint.</param>
        /// <param name="y"><c>true</c> if to fill the object space, <c>false</c> otherwise, to use as vertical fill hint.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetHintFill(bool x, bool y) {
            CoreUI.Gfx.IHintNativeMethods.efl_gfx_hint_fill_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), x, y);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Number of points of a map.
        /// 
        /// This sets the number of points of map. Currently, the number of points must be multiples of 4.</summary>
        /// <returns>The number of points of map</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual int GetMappingPointCount() {
            var _ret_var = CoreUI.Gfx.IMappingNativeMethods.efl_gfx_mapping_point_count_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Number of points of a map.
        /// 
        /// This sets the number of points of map. Currently, the number of points must be multiples of 4.</summary>
        /// <param name="count">The number of points of map</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetMappingPointCount(int count) {
            CoreUI.Gfx.IMappingNativeMethods.efl_gfx_mapping_point_count_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), count);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Clockwise state of a map (read-only).
        /// 
        /// This determines if the output points (X and Y. Z is not used) are clockwise or counter-clockwise. This can be used for &quot;back-face culling&quot;. This is where you hide objects that &quot;face away&quot; from you. In this case objects that are not clockwise.</summary>
        /// <returns><c>true</c> if clockwise, <c>false</c> if counter clockwise</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetMappingClockwise() {
            var _ret_var = CoreUI.Gfx.IMappingNativeMethods.efl_gfx_mapping_clockwise_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Smoothing state for map rendering.
        /// 
        /// This sets smoothing for map rendering. If the object is a type that has its own smoothing settings, then both the smooth settings for this object and the map must be turned off. By default smooth maps are enabled.</summary>
        /// <returns><c>true</c> by default.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetMappingSmooth() {
            var _ret_var = CoreUI.Gfx.IMappingNativeMethods.efl_gfx_mapping_smooth_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Smoothing state for map rendering.
        /// 
        /// This sets smoothing for map rendering. If the object is a type that has its own smoothing settings, then both the smooth settings for this object and the map must be turned off. By default smooth maps are enabled.</summary>
        /// <param name="smooth"><c>true</c> by default.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetMappingSmooth(bool smooth) {
            CoreUI.Gfx.IMappingNativeMethods.efl_gfx_mapping_smooth_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), smooth);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Alpha flag for map rendering.
        /// 
        /// This sets alpha flag for map rendering. If the object is a type that has its own alpha settings, then this will take precedence. Only image objects support this currently (<span class="text-muted">CoreUI.Canvas.Image (object still in beta stage)</span> and its friends). Setting this to off stops alpha blending of the map area, and is useful if you know the object and/or all sub-objects is 100% solid.
        /// 
        /// Note that this may conflict with <see cref="CoreUI.Gfx.IMapping.MappingSmooth"/> depending on which algorithm is used for anti-aliasing.</summary>
        /// <returns><c>true</c> by default.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetMappingAlpha() {
            var _ret_var = CoreUI.Gfx.IMappingNativeMethods.efl_gfx_mapping_alpha_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Alpha flag for map rendering.
        /// 
        /// This sets alpha flag for map rendering. If the object is a type that has its own alpha settings, then this will take precedence. Only image objects support this currently (<span class="text-muted">CoreUI.Canvas.Image (object still in beta stage)</span> and its friends). Setting this to off stops alpha blending of the map area, and is useful if you know the object and/or all sub-objects is 100% solid.
        /// 
        /// Note that this may conflict with <see cref="CoreUI.Gfx.IMapping.MappingSmooth"/> depending on which algorithm is used for anti-aliasing.</summary>
        /// <param name="alpha"><c>true</c> by default.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetMappingAlpha(bool alpha) {
            CoreUI.Gfx.IMappingNativeMethods.efl_gfx_mapping_alpha_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), alpha);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>A point&apos;s absolute coordinate on the canvas.
        /// 
        /// This sets/gets the fixed point&apos;s coordinate in the map. Note that points describe the outline of a quadrangle and are ordered either clockwise or counter-clockwise. Try to keep your quadrangles concave and non-complex. Though these polygon modes may work, they may not render a desired set of output. The quadrangle will use points 0 and 1 , 1 and 2, 2 and 3, and 3 and 0 to describe the edges of the quadrangle.
        /// 
        /// The X and Y and Z coordinates are in canvas units. Z is optional and may or may not be honored in drawing. Z is a hint and does not affect the X and Y rendered coordinates. It may be used for calculating fills with perspective correct rendering.
        /// 
        /// Remember all coordinates are canvas global ones as with move and resize in the canvas.
        /// 
        /// This property can be read to get the 4 points positions on the canvas, or set to manually place them.</summary>
        /// <param name="idx">ID of the point, from 0 to 3 (included).</param>
        /// <param name="x">Point X coordinate in absolute pixel coordinates.</param>
        /// <param name="y">Point Y coordinate in absolute pixel coordinates.</param>
        /// <param name="z">Point Z coordinate hint (pre-perspective transform).</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetMappingCoordAbsolute(int idx, out double x, out double y, out double z) {
            CoreUI.Gfx.IMappingNativeMethods.efl_gfx_mapping_coord_absolute_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), idx, out x, out y, out z);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>A point&apos;s absolute coordinate on the canvas.
        /// 
        /// This sets/gets the fixed point&apos;s coordinate in the map. Note that points describe the outline of a quadrangle and are ordered either clockwise or counter-clockwise. Try to keep your quadrangles concave and non-complex. Though these polygon modes may work, they may not render a desired set of output. The quadrangle will use points 0 and 1 , 1 and 2, 2 and 3, and 3 and 0 to describe the edges of the quadrangle.
        /// 
        /// The X and Y and Z coordinates are in canvas units. Z is optional and may or may not be honored in drawing. Z is a hint and does not affect the X and Y rendered coordinates. It may be used for calculating fills with perspective correct rendering.
        /// 
        /// Remember all coordinates are canvas global ones as with move and resize in the canvas.
        /// 
        /// This property can be read to get the 4 points positions on the canvas, or set to manually place them.</summary>
        /// <param name="idx">ID of the point, from 0 to 3 (included).</param>
        /// <param name="x">Point X coordinate in absolute pixel coordinates.</param>
        /// <param name="y">Point Y coordinate in absolute pixel coordinates.</param>
        /// <param name="z">Point Z coordinate hint (pre-perspective transform).</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetMappingCoordAbsolute(int idx, double x, double y, double z) {
            CoreUI.Gfx.IMappingNativeMethods.efl_gfx_mapping_coord_absolute_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), idx, x, y, z);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Map point&apos;s U and V texture source point.
        /// 
        /// This sets/gets the U and V coordinates for the point. This determines which coordinate in the source image is mapped to the given point, much like OpenGL and textures. Valid values range from 0.0 to 1.0.
        /// 
        /// By default the points are set in a clockwise order, as such: - 0: top-left, i.e. (0.0, 0.0), - 1: top-right, i.e. (1.0, 0.0), - 2: bottom-right, i.e. (1.0, 1.0), - 3: bottom-left, i.e. (0.0, 1.0).</summary>
        /// <param name="idx">ID of the point, from 0 to 3 (included).</param>
        /// <param name="u">Relative X coordinate within the image, from 0 to 1.</param>
        /// <param name="v">Relative Y coordinate within the image, from 0 to 1.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetMappingUv(int idx, out double u, out double v) {
            CoreUI.Gfx.IMappingNativeMethods.efl_gfx_mapping_uv_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), idx, out u, out v);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Map point&apos;s U and V texture source point.
        /// 
        /// This sets/gets the U and V coordinates for the point. This determines which coordinate in the source image is mapped to the given point, much like OpenGL and textures. Valid values range from 0.0 to 1.0.
        /// 
        /// By default the points are set in a clockwise order, as such: - 0: top-left, i.e. (0.0, 0.0), - 1: top-right, i.e. (1.0, 0.0), - 2: bottom-right, i.e. (1.0, 1.0), - 3: bottom-left, i.e. (0.0, 1.0).</summary>
        /// <param name="idx">ID of the point, from 0 to 3 (included).</param>
        /// <param name="u">Relative X coordinate within the image, from 0 to 1.</param>
        /// <param name="v">Relative Y coordinate within the image, from 0 to 1.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetMappingUv(int idx, double u, double v) {
            CoreUI.Gfx.IMappingNativeMethods.efl_gfx_mapping_uv_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), idx, u, v);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Color of a vertex in the map.
        /// 
        /// This sets the color of the vertex in the map. Colors will be linearly interpolated between vertex points through the map. Color will multiply the &quot;texture&quot; pixels (like GL_MODULATE in OpenGL). The default color of a vertex in a map is white solid (255, 255, 255, 255) which means it will have no affect on modifying the texture pixels.
        /// 
        /// The color values must be premultiplied (ie. <c>a</c> &gt;= {<c>r</c>, <c>g</c>, <c>b</c>}).</summary>
        /// <param name="idx">ID of the point, from 0 to 3 (included). -1 can be used to set the color for all points, but it is invalid for get().</param>
        /// <param name="r">Red (0 - 255)</param>
        /// <param name="g">Green (0 - 255)</param>
        /// <param name="b">Blue (0 - 255)</param>
        /// <param name="a">Alpha (0 - 255)</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetMappingColor(int idx, out int r, out int g, out int b, out int a) {
            CoreUI.Gfx.IMappingNativeMethods.efl_gfx_mapping_color_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), idx, out r, out g, out b, out a);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Color of a vertex in the map.
        /// 
        /// This sets the color of the vertex in the map. Colors will be linearly interpolated between vertex points through the map. Color will multiply the &quot;texture&quot; pixels (like GL_MODULATE in OpenGL). The default color of a vertex in a map is white solid (255, 255, 255, 255) which means it will have no affect on modifying the texture pixels.
        /// 
        /// The color values must be premultiplied (ie. <c>a</c> &gt;= {<c>r</c>, <c>g</c>, <c>b</c>}).</summary>
        /// <param name="idx">ID of the point, from 0 to 3 (included). -1 can be used to set the color for all points, but it is invalid for get().</param>
        /// <param name="r">Red (0 - 255)</param>
        /// <param name="g">Green (0 - 255)</param>
        /// <param name="b">Blue (0 - 255)</param>
        /// <param name="a">Alpha (0 - 255)</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetMappingColor(int idx, int r, int g, int b, int a) {
            CoreUI.Gfx.IMappingNativeMethods.efl_gfx_mapping_color_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), idx, r, g, b, a);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Read-only property indicating whether an object is mapped.
        /// 
        /// This will be <c>true</c> if any transformation is applied to this object.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns><c>true</c> if the object is mapped.</returns>
        public virtual bool HasMapping() {
            var _ret_var = CoreUI.Gfx.IMappingNativeMethods.efl_gfx_mapping_has_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Resets the map transformation to its default state.
        /// 
        /// This will reset all transformations to identity, meaning the points&apos; colors, positions and UV coordinates will be reset to their default values. <see cref="CoreUI.Gfx.IMapping.HasMapping"/> will then return <c>false</c>. This function will not modify the values of <see cref="CoreUI.Gfx.IMapping.MappingSmooth"/> or <see cref="CoreUI.Gfx.IMapping.MappingAlpha"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void ResetMapping() {
            CoreUI.Gfx.IMappingNativeMethods.efl_gfx_mapping_reset_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Apply a translation to the object using map.
        /// 
        /// This does not change the real geometry of the object but will affect its visible position.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="dx">Distance in pixels along the X axis.</param>
        /// <param name="dy">Distance in pixels along the Y axis.</param>
        /// <param name="dz">Distance in pixels along the Z axis.</param>
        public virtual void Translate(double dx, double dy, double dz) {
            CoreUI.Gfx.IMappingNativeMethods.efl_gfx_mapping_translate_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), dx, dy, dz);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Apply a rotation to the object.
        /// 
        /// This rotates the object clockwise by <c>degrees</c> degrees, around the center specified by the relative position (<c>cx</c>, <c>cy</c>) in the <c>pivot</c> object. If <c>pivot</c> is <c>null</c> then this object is used as its own pivot center. 360 degrees is a full rotation, equivalent to no rotation. Negative values for <c>degrees</c> will rotate clockwise by that amount.
        /// 
        /// The coordinates are set relative to the given <c>pivot</c> object. If its geometry changes, then the absolute position of the rotation center will change accordingly.
        /// 
        /// By default, the center is at (0.5, 0.5). 0.0 means left or top while 1.0 means right or bottom of the <c>pivot</c> object.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="degrees">CCW rotation in degrees.</param>
        /// <param name="pivot">A pivot object for the center point, can be <c>null</c>.</param>
        /// <param name="cx">X relative coordinate of the center point.</param>
        /// <param name="cy">y relative coordinate of the center point.</param>
        public virtual void Rotate(double degrees, CoreUI.Gfx.IEntity pivot, double cx, double cy) {
            CoreUI.Gfx.IMappingNativeMethods.efl_gfx_mapping_rotate_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), degrees, pivot, cx, cy);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Rotate the object around 3 axes in 3D.
        /// 
        /// This will rotate in 3D, not just around the &quot;Z&quot; axis as is the case with <see cref="CoreUI.Gfx.IMapping.Rotate"/>. You can rotate around the X, Y and Z axes. The Z axis points &quot;into&quot; the screen with low values at the screen and higher values further away. The X axis runs from left to right on the screen and the Y axis from top to bottom.
        /// 
        /// As with <see cref="CoreUI.Gfx.IMapping.Rotate"/>, you provide a pivot and center point to rotate around (in 3D). The Z coordinate of this center point is an absolute value, and not a relative one like X and Y, as objects are flat in a 2D space.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="dx">Rotation in degrees around X axis (0 to 360).</param>
        /// <param name="dy">Rotation in degrees around Y axis (0 to 360).</param>
        /// <param name="dz">Rotation in degrees around Z axis (0 to 360).</param>
        /// <param name="pivot">A pivot object for the center point, can be <c>null</c>.</param>
        /// <param name="cx">X relative coordinate of the center point.</param>
        /// <param name="cy">y relative coordinate of the center point.</param>
        /// <param name="cz">Z absolute coordinate of the center point.</param>
        public virtual void Rotate3d(double dx, double dy, double dz, CoreUI.Gfx.IEntity pivot, double cx, double cy, double cz) {
            CoreUI.Gfx.IMappingNativeMethods.efl_gfx_mapping_rotate_3d_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), dx, dy, dz, pivot, cx, cy, cz);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Rotate the object in 3D using a unit quaternion.
        /// 
        /// This is similar to <see cref="CoreUI.Gfx.IMapping.Rotate3d"/> but uses a unit quaternion (also known as versor) rather than a direct angle-based rotation around a center point. Use this to avoid gimbal locks.
        /// 
        /// As with <see cref="CoreUI.Gfx.IMapping.Rotate"/>, you provide a pivot and center point to rotate around (in 3D). The Z coordinate of this center point is an absolute value, and not a relative one like X and Y, as objects are flat in a 2D space.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="qx">The x component of the imaginary part of the quaternion.</param>
        /// <param name="qy">The y component of the imaginary part of the quaternion.</param>
        /// <param name="qz">The z component of the imaginary part of the quaternion.</param>
        /// <param name="qw">The w component of the real part of the quaternion.</param>
        /// <param name="pivot">A pivot object for the center point, can be <c>null</c>.</param>
        /// <param name="cx">X relative coordinate of the center point.</param>
        /// <param name="cy">y relative coordinate of the center point.</param>
        /// <param name="cz">Z absolute coordinate of the center point.</param>
        public virtual void RotateQuat(double qx, double qy, double qz, double qw, CoreUI.Gfx.IEntity pivot, double cx, double cy, double cz) {
            CoreUI.Gfx.IMappingNativeMethods.efl_gfx_mapping_rotate_quat_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), qx, qy, qz, qw, pivot, cx, cy, cz);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Apply a zoom to the object.
        /// 
        /// This zooms the points of the map from a center point. That center is defined by <c>cx</c> and <c>cy</c>. The <c>zoomx</c> and <c>zoomy</c> parameters specify how much to zoom in the X and Y direction respectively. A value of 1.0 means &quot;don&apos;t zoom&quot;. 2.0 means &quot;double the size&quot;. 0.5 is &quot;half the size&quot; etc.
        /// 
        /// By default, the center is at (0.5, 0.5). 0.0 means left or top while 1.0 means right or bottom.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="zoomx">Zoom in X direction</param>
        /// <param name="zoomy">Zoom in Y direction</param>
        /// <param name="pivot">A pivot object for the center point, can be <c>null</c>.</param>
        /// <param name="cx">X relative coordinate of the center point.</param>
        /// <param name="cy">y relative coordinate of the center point.</param>
        public virtual void Zoom(double zoomx, double zoomy, CoreUI.Gfx.IEntity pivot, double cx, double cy) {
            CoreUI.Gfx.IMappingNativeMethods.efl_gfx_mapping_zoom_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), zoomx, zoomy, pivot, cx, cy);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Apply a lighting effect on the object.
        /// 
        /// This is used to apply lighting calculations (from a single light source) to a given mapped object. The R, G and B values of each vertex will be modified to reflect the lighting based on the light point coordinates, the light color and the ambient color, and at what angle the map is facing the light source. A surface should have its points be declared in a clockwise fashion if the face is &quot;facing&quot; towards you (as opposed to away from you) as faces have a &quot;logical&quot; side for lighting.
        /// 
        /// The coordinates are set relative to the given <c>pivot</c> object. If its geometry changes, then the absolute position of the rotation center will change accordingly. The Z position is absolute. If the <c>pivot</c> is <c>null</c> then this object will be its own pivot.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="pivot">A pivot object for the light point, can be <c>null</c>.</param>
        /// <param name="lx">X relative coordinate in space of light point.</param>
        /// <param name="ly">Y relative coordinate in space of light point.</param>
        /// <param name="lz">Z absolute coordinate in space of light point.</param>
        /// <param name="lr">Light red value (0 - 255).</param>
        /// <param name="lg">Light green value (0 - 255).</param>
        /// <param name="lb">Light blue value (0 - 255).</param>
        /// <param name="ar">Ambient color red value (0 - 255).</param>
        /// <param name="ag">Ambient color green value (0 - 255).</param>
        /// <param name="ab">Ambient color blue value (0 - 255).</param>
        public virtual void Lighting3d(CoreUI.Gfx.IEntity pivot, double lx, double ly, double lz, int lr, int lg, int lb, int ar, int ag, int ab) {
            CoreUI.Gfx.IMappingNativeMethods.efl_gfx_mapping_lighting_3d_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), pivot, lx, ly, lz, lr, lg, lb, ar, ag, ab);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Apply a perspective transform to the map
        /// 
        /// This applies a given perspective (3D) to the map coordinates. X, Y and Z values are used. The px and py points specify the &quot;infinite distance&quot; point in the 3D conversion (where all lines converge to like when artists draw 3D by hand). The <c>z0</c> value specifies the z value at which there is a 1:1 mapping between spatial coordinates and screen coordinates. Any points on this z value will not have their X and Y values modified in the transform. Those further away (Z value higher) will shrink into the distance, and those under this value will expand and become bigger. The <c>foc</c> value determines the &quot;focal length&quot; of the camera. This is in reality the distance between the camera lens plane itself (at or closer than this rendering results are undefined) and the &quot;z0&quot; z value. This allows for some &quot;depth&quot; control and <c>foc</c> must be greater than 0.
        /// 
        /// The coordinates are set relative to the given <c>pivot</c> object. If its geometry changes, then the absolute position of the rotation center will change accordingly. The Z position is absolute. If the <c>pivot</c> is <c>null</c> then this object will be its own pivot.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="pivot">A pivot object for the infinite point, can be <c>null</c>.</param>
        /// <param name="px">The perspective distance X relative coordinate.</param>
        /// <param name="py">The perspective distance Y relative coordinate.</param>
        /// <param name="z0">The &quot;0&quot; Z plane value.</param>
        /// <param name="foc">The focal distance, must be greater than 0.</param>
        public virtual void Perspective3d(CoreUI.Gfx.IEntity pivot, double px, double py, double z0, double foc) {
            CoreUI.Gfx.IMappingNativeMethods.efl_gfx_mapping_perspective_3d_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), pivot, px, py, z0, foc);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Apply a rotation to the object, using absolute coordinates.
        /// 
        /// This rotates the object clockwise by <c>degrees</c> degrees, around the center specified by the relative position (<c>cx</c>, <c>cy</c>) in the <c>pivot</c> object. If <c>pivot</c> is <c>null</c> then this object is used as its own pivot center. 360 degrees is a full rotation, equivalent to no rotation. Negative values for <c>degrees</c> will rotate clockwise by that amount.
        /// 
        /// The given coordinates are absolute values in pixels. See also <see cref="CoreUI.Gfx.IMapping.Rotate"/> for a relative coordinate version.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="degrees">CCW rotation in degrees.</param>
        /// <param name="cx">X absolute coordinate in pixels of the center point.</param>
        /// <param name="cy">y absolute coordinate in pixels of the center point.</param>
        public virtual void RotateAbsolute(double degrees, double cx, double cy) {
            CoreUI.Gfx.IMappingNativeMethods.efl_gfx_mapping_rotate_absolute_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), degrees, cx, cy);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Rotate the object around 3 axes in 3D, using absolute coordinates.
        /// 
        /// This will rotate in 3D and not just around the &quot;Z&quot; axis as the case with <see cref="CoreUI.Gfx.IMapping.Rotate"/>. This will rotate around the X, Y and Z axes. The Z axis points &quot;into&quot; the screen with low values at the screen and higher values further away. The X axis runs from left to right on the screen and the Y axis from top to bottom.
        /// 
        /// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="CoreUI.Gfx.IMapping.Rotate3d"/> for a pivot-based 3D rotation.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="dx">Rotation in degrees around X axis (0 to 360).</param>
        /// <param name="dy">Rotation in degrees around Y axis (0 to 360).</param>
        /// <param name="dz">Rotation in degrees around Z axis (0 to 360).</param>
        /// <param name="cx">X absolute coordinate in pixels of the center point.</param>
        /// <param name="cy">y absolute coordinate in pixels of the center point.</param>
        /// <param name="cz">Z absolute coordinate of the center point.</param>
        public virtual void Rotate3dAbsolute(double dx, double dy, double dz, double cx, double cy, double cz) {
            CoreUI.Gfx.IMappingNativeMethods.efl_gfx_mapping_rotate_3d_absolute_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), dx, dy, dz, cx, cy, cz);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Rotate the object in 3D using a unit quaternion, using absolute coordinates.
        /// 
        /// This is similar to <see cref="CoreUI.Gfx.IMapping.Rotate3d"/> but uses a unit quaternion (also known as versor) rather than a direct angle-based rotation around a center point. Use this to avoid gimbal locks.
        /// 
        /// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="CoreUI.Gfx.IMapping.RotateQuat"/> for a pivot-based 3D rotation.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="qx">The x component of the imaginary part of the quaternion.</param>
        /// <param name="qy">The y component of the imaginary part of the quaternion.</param>
        /// <param name="qz">The z component of the imaginary part of the quaternion.</param>
        /// <param name="qw">The w component of the real part of the quaternion.</param>
        /// <param name="cx">X absolute coordinate in pixels of the center point.</param>
        /// <param name="cy">y absolute coordinate in pixels of the center point.</param>
        /// <param name="cz">Z absolute coordinate of the center point.</param>
        public virtual void RotateQuatAbsolute(double qx, double qy, double qz, double qw, double cx, double cy, double cz) {
            CoreUI.Gfx.IMappingNativeMethods.efl_gfx_mapping_rotate_quat_absolute_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), qx, qy, qz, qw, cx, cy, cz);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Apply a zoom to the object, using absolute coordinates.
        /// 
        /// This zooms the points of the map from a center point. That center is defined by <c>cx</c> and <c>cy</c>. The <c>zoomx</c> and <c>zoomy</c> parameters specify how much to zoom in the X and Y direction respectively. A value of 1.0 means &quot;don&apos;t zoom&quot;. 2.0 means &quot;double the size&quot;. 0.5 is &quot;half the size&quot; etc.
        /// 
        /// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="CoreUI.Gfx.IMapping.Zoom"/> for a pivot-based zoom.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="zoomx">Zoom in X direction</param>
        /// <param name="zoomy">Zoom in Y direction</param>
        /// <param name="cx">X absolute coordinate in pixels of the center point.</param>
        /// <param name="cy">y absolute coordinate in pixels of the center point.</param>
        public virtual void ZoomAbsolute(double zoomx, double zoomy, double cx, double cy) {
            CoreUI.Gfx.IMappingNativeMethods.efl_gfx_mapping_zoom_absolute_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), zoomx, zoomy, cx, cy);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Apply a lighting effect to the object.
        /// 
        /// This is used to apply lighting calculations (from a single light source) to a given mapped object. The RGB values of each vertex will be modified to reflect the lighting based on the light point coordinates, the light color, the ambient color and at what angle the map is facing the light source. A surface should have its points be declared in a clockwise fashion if the face is &quot;facing&quot; towards you (as opposed to away from you) as faces have a &quot;logical&quot; side for lighting.
        /// 
        /// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="CoreUI.Gfx.IMapping.Lighting3d"/> for a pivot-based lighting effect.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="lx">X absolute coordinate in pixels of the light point.</param>
        /// <param name="ly">y absolute coordinate in pixels of the light point.</param>
        /// <param name="lz">Z absolute coordinate in space of light point.</param>
        /// <param name="lr">Light red value (0 - 255).</param>
        /// <param name="lg">Light green value (0 - 255).</param>
        /// <param name="lb">Light blue value (0 - 255).</param>
        /// <param name="ar">Ambient color red value (0 - 255).</param>
        /// <param name="ag">Ambient color green value (0 - 255).</param>
        /// <param name="ab">Ambient color blue value (0 - 255).</param>
        public virtual void Lighting3dAbsolute(double lx, double ly, double lz, int lr, int lg, int lb, int ar, int ag, int ab) {
            CoreUI.Gfx.IMappingNativeMethods.efl_gfx_mapping_lighting_3d_absolute_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), lx, ly, lz, lr, lg, lb, ar, ag, ab);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Apply a perspective transform to the map
        /// 
        /// This applies a given perspective (3D) to the map coordinates. X, Y and Z values are used. The px and py points specify the &quot;infinite distance&quot; point in the 3D conversion (where all lines converge to like when artists draw 3D by hand). The <c>z0</c> value specifies the z value at which there is a 1:1 mapping between spatial coordinates and screen coordinates. Any points on this z value will not have their X and Y values modified in the transform. Those further away (Z value higher) will shrink into the distance, and those less than this value will expand and become bigger. The <c>foc</c> value determines the &quot;focal length&quot; of the camera. This is in reality the distance between the camera lens plane itself (at or closer than this rendering results are undefined) and the &quot;z0&quot; z value. This allows for some &quot;depth&quot; control and <c>foc</c> must be greater than 0.
        /// 
        /// The coordinates of the center point are given in absolute canvas coordinates. See also <see cref="CoreUI.Gfx.IMapping.Perspective3d"/> for a pivot-based perspective effect.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="px">The perspective distance X relative coordinate.</param>
        /// <param name="py">The perspective distance Y relative coordinate.</param>
        /// <param name="z0">The &quot;0&quot; Z plane value.</param>
        /// <param name="foc">The focal distance, must be greater than 0.</param>
        public virtual void Perspective3dAbsolute(double px, double py, double z0, double foc) {
            CoreUI.Gfx.IMappingNativeMethods.efl_gfx_mapping_perspective_3d_absolute_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), px, py, z0, foc);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The layer of its canvas that the given object will be part of.
        /// 
        /// If you don&apos;t use this property, you&apos;ll be dealing with a unique layer of objects (the default one). Additional layers are handy when you don&apos;t want a set of objects to interfere with another set with regard to stacking. Two layers are completely disjoint in that matter.
        /// 
        /// This is a low-level function, which you&apos;d be using when something should be always on top, for example.
        /// 
        /// <b>WARNING: </b>Don&apos;t change the layer of smart objects&apos; children. Smart objects have a layer of their own, which should contain all their child objects.</summary>
        /// <returns>The number of the layer to place the object on. Must be between <see cref="CoreUI.Gfx.Constants.StackLayerMin"/> and <see cref="CoreUI.Gfx.Constants.StackLayerMax"/>.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual short GetLayer() {
            var _ret_var = CoreUI.Gfx.IStackNativeMethods.efl_gfx_stack_layer_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The layer of its canvas that the given object will be part of.
        /// 
        /// If you don&apos;t use this property, you&apos;ll be dealing with a unique layer of objects (the default one). Additional layers are handy when you don&apos;t want a set of objects to interfere with another set with regard to stacking. Two layers are completely disjoint in that matter.
        /// 
        /// This is a low-level function, which you&apos;d be using when something should be always on top, for example.
        /// 
        /// <b>WARNING: </b>Don&apos;t change the layer of smart objects&apos; children. Smart objects have a layer of their own, which should contain all their child objects.</summary>
        /// <param name="l">The number of the layer to place the object on. Must be between <see cref="CoreUI.Gfx.Constants.StackLayerMin"/> and <see cref="CoreUI.Gfx.Constants.StackLayerMax"/>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetLayer(short l) {
            CoreUI.Gfx.IStackNativeMethods.efl_gfx_stack_layer_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), l);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The Evas object stacked right below this object.
        /// 
        /// This function will traverse layers in its search, if there are objects on layers below the one <c>obj</c> is placed at.
        /// 
        /// See also <see cref="CoreUI.Gfx.IStack.Layer"/>.</summary>
        /// <returns>The <see cref="CoreUI.Gfx.IStack"/> object directly below <c>obj</c>, if any, or <c>null</c>, if none.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.Gfx.IStack GetBelow() {
            var _ret_var = CoreUI.Gfx.IStackNativeMethods.efl_gfx_stack_below_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Get the Evas object stacked right above this object.
        /// 
        /// This function will traverse layers in its search, if there are objects on layers above the one <c>obj</c> is placed at.
        /// 
        /// See also <see cref="CoreUI.Gfx.IStack.Layer"/> and <see cref="CoreUI.Gfx.IStack.GetBelow"/></summary>
        /// <returns>The <see cref="CoreUI.Gfx.IStack"/> object directly below <c>obj</c>, if any, or <c>null</c>, if none.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.Gfx.IStack GetAbove() {
            var _ret_var = CoreUI.Gfx.IStackNativeMethods.efl_gfx_stack_above_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Stack <c>obj</c> immediately <c>below</c>
        /// 
        /// Objects, in a given canvas, are stacked in the order they&apos;re added. This means that, if they overlap, the highest ones will cover the lowest ones, in that order. This function is a way to change the stacking order for the objects.
        /// 
        /// Its intended to be used with objects belonging to the same layer in a given canvas, otherwise it will fail (and accomplish nothing).
        /// 
        /// If you have smart objects on your canvas and <c>obj</c> is a member of one of them, then <c>below</c> must also be a member of the same smart object.
        /// 
        /// Similarly, if <c>obj</c> is not a member of a smart object, <c>below</c> must not be either.
        /// 
        /// See also <see cref="CoreUI.Gfx.IStack.GetLayer"/>, <see cref="CoreUI.Gfx.IStack.SetLayer"/> and <see cref="CoreUI.Gfx.IStack.StackBelow"/></summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="below">The object below which to stack</param>
        public virtual void StackBelow(CoreUI.Gfx.IStack below) {
            CoreUI.Gfx.IStackNativeMethods.efl_gfx_stack_below_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), below);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Raise <c>obj</c> to the top of its layer.
        /// 
        /// <c>obj</c> will, then, be the highest one in the layer it belongs to. Object on other layers won&apos;t get touched.
        /// 
        /// See also <see cref="CoreUI.Gfx.IStack.StackAbove"/>, <see cref="CoreUI.Gfx.IStack.StackBelow"/> and <see cref="CoreUI.Gfx.IStack.LowerToBottom"/></summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void RaiseToTop() {
            CoreUI.Gfx.IStackNativeMethods.efl_gfx_stack_raise_to_top_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Stack <c>obj</c> immediately <c>above</c>
        /// 
        /// Objects, in a given canvas, are stacked in the order they&apos;re added. This means that, if they overlap, the highest ones will cover the lowest ones, in that order. This function is a way to change the stacking order for the objects.
        /// 
        /// Its intended to be used with objects belonging to the same layer in a given canvas, otherwise it will fail (and accomplish nothing).
        /// 
        /// If you have smart objects on your canvas and <c>obj</c> is a member of one of them, then <c>above</c> must also be a member of the same smart object.
        /// 
        /// Similarly, if <c>obj</c> is not a member of a smart object, <c>above</c> must not be either.
        /// 
        /// See also <see cref="CoreUI.Gfx.IStack.GetLayer"/>, <see cref="CoreUI.Gfx.IStack.SetLayer"/> and <see cref="CoreUI.Gfx.IStack.StackBelow"/></summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="above">The object above which to stack</param>
        public virtual void StackAbove(CoreUI.Gfx.IStack above) {
            CoreUI.Gfx.IStackNativeMethods.efl_gfx_stack_above_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), above);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Lower <c>obj</c> to the bottom of its layer.
        /// 
        /// <c>obj</c> will, then, be the lowest one in the layer it belongs to. Objects on other layers won&apos;t get touched.
        /// 
        /// See also <see cref="CoreUI.Gfx.IStack.StackAbove"/>, <see cref="CoreUI.Gfx.IStack.StackBelow"/> and <see cref="CoreUI.Gfx.IStack.RaiseToTop"/></summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void LowerToBottom() {
            CoreUI.Gfx.IStackNativeMethods.efl_gfx_stack_lower_to_bottom_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Render mode to be used for compositing the Evas object.
        /// 
        /// Only two modes are supported: - <see cref="CoreUI.Gfx.RenderOp.Blend"/> means the object will be merged on top of objects below it using simple alpha compositing. - <see cref="CoreUI.Gfx.RenderOp.Copy"/> means this object&apos;s pixels will replace everything that is below, making this object opaque.
        /// 
        /// Please do not assume that <see cref="CoreUI.Gfx.RenderOp.Copy"/> mode can be used to &quot;poke&quot; holes in a window (to see through it), as only the compositor can ensure that. Copy mode should only be used with otherwise opaque widgets or inside non-window surfaces (e.g. a transparent background inside a buffer canvas).</summary>
        /// <value>Blend or copy.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Gfx.RenderOp RenderOp {
            get { return GetRenderOp(); }
            set { SetRenderOp(value); }
        }

        /// <summary>Clip one object to another.
        /// 
        /// This property will clip the object <c>obj</c> to the area occupied by the object <c>clip</c>. This means the object <c>obj</c> will only be visible within the area occupied by the clipping object (<c>clip</c>).
        /// 
        /// The color of the object being clipped will be multiplied by the color of the clipping one, so the resulting color for the former will be &quot;RESULT = (OBJ * CLIP) / (255 * 255)&quot;, per color element (red, green, blue and alpha).
        /// 
        /// Clipping is recursive, so clipping objects may be clipped by others, and their color will in term be multiplied. You may not set up circular clipping lists (i.e. object 1 clips object 2, which clips object 1): the behavior of Evas is undefined in this case.
        /// 
        /// Objects which do not clip others are visible in the canvas as normal; those that clip one or more objects become invisible themselves, only affecting what they clip. If an object ceases to have other objects being clipped by it, it will become visible again.
        /// 
        /// The visibility of an object affects the objects that are clipped by it, so if the object clipping others is not shown (as in <see cref="CoreUI.Gfx.IEntity.Visible"/>), the objects clipped by it will not be shown  either.
        /// 
        /// If <c>obj</c> was being clipped by another object when this function is  called, it gets implicitly removed from the old clipper&apos;s domain and is made now to be clipped by its new clipper.
        /// 
        /// If <c>clip</c> is <c>null</c>, this call will disable clipping for the object i.e. its visibility and color get detached from the previous clipper. If it wasn&apos;t, this has no effect.
        /// 
        /// <b>NOTE: </b>Only rectangle and image (masks) objects can be used as clippers. Anything else will result in undefined behaviour.</summary>
        /// <value>The object to clip <c>obj</c> by.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Canvas.Object Clipper {
            get { return GetClipper(); }
            set { SetClipper(value); }
        }

        /// <summary>Whether an Evas object is to repeat events to objects below it.
        /// 
        /// If <c>repeat</c> is <c>true</c>, it will make events on <c>obj</c> to also be repeated for the next lower object in the objects&apos; stack (see see <see cref="CoreUI.Gfx.IStack.GetBelow"/>).
        /// 
        /// If <c>repeat</c> is <c>false</c>, events occurring on <c>obj</c> will be processed only on it.</summary>
        /// <value>Whether <c>obj</c> is to repeat events (<c>true</c>) or not (<c>false</c>).</value>
        /// <since_tizen> 6 </since_tizen>
        public bool RepeatEvents {
            get { return GetRepeatEvents(); }
            set { SetRepeatEvents(value); }
        }

        /// <summary>Indicates that this object is the keyboard event receiver on its canvas.
        /// 
        /// Changing focus only affects where (key) input events go. There can be only one object focused at any time. If <c>focus</c> is <c>true</c>, <c>obj</c> will be set as the currently focused object and it will receive all keyboard events that are not exclusive key grabs on other objects. See also <span class="text-muted">CoreUI.Canvas.Object.CheckSeatFocus (object still in beta stage)</span>, <span class="text-muted">CoreUI.Canvas.Object.AddSeatFocus (object still in beta stage)</span>, <span class="text-muted">CoreUI.Canvas.Object.DelSeatFocus (object still in beta stage)</span>.</summary>
        /// <value><c>true</c> when set as focused or <c>false</c> otherwise.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool KeyFocus {
            get { return GetKeyFocus(); }
            set { SetKeyFocus(value); }
        }

        /// <summary>Check if this object is focused.</summary>
        /// <value><c>true</c> if focused by at least one seat or <c>false</c> otherwise.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool SeatFocus {
            get { return GetSeatFocus(); }
        }

        /// <summary>Whether to use precise (usually expensive) point collision detection for a given Evas object.
        /// 
        /// Use this property to make Evas treat objects&apos; transparent areas as not belonging to it with regard to mouse pointer events. By default, all of the object&apos;s boundary rectangle will be taken in account for them.
        /// 
        /// <b>WARNING: </b>By using precise point collision detection you&apos;ll be making Evas more resource intensive.</summary>
        /// <value>Whether to use precise point collision detection.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool PreciseIsInside {
            get { return GetPreciseIsInside(); }
            set { SetPreciseIsInside(value); }
        }

        /// <summary>Whether events on a smart object&apos;s member should be propagated up to its parent.
        /// 
        /// This function has no effect if <c>obj</c> is not a member of a smart object.
        /// 
        /// If <c>prop</c> is <c>true</c>, events occurring on this object will be propagated on to the smart object of which <c>obj</c> is a member. If <c>prop</c> is <c>false</c>, events occurring on this object will not be propagated on to the smart object of which <c>obj</c> is a member.
        /// 
        /// See also <see cref="CoreUI.Canvas.Object.SetRepeatEvents"/>, <see cref="CoreUI.Canvas.Object.SetPassEvents"/>.</summary>
        /// <value>Whether to propagate events.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool PropagateEvents {
            get { return GetPropagateEvents(); }
            set { SetPropagateEvents(value); }
        }

        /// <summary>Whether an Evas object is to pass (ignore) events.
        /// 
        /// If <c>pass</c> is <c>true</c>, it will make events on <c>obj</c> to be ignored. They will be triggered on the next lower object (that is not set to pass events), instead (see <see cref="CoreUI.Gfx.IStack.GetBelow"/>).
        /// 
        /// If <c>pass</c> is <c>false</c> events will be processed on that object as normal.
        /// 
        /// See also <see cref="CoreUI.Canvas.Object.SetRepeatEvents"/>, <see cref="CoreUI.Canvas.Object.SetPropagateEvents"/></summary>
        /// <value>Whether <c>obj</c> is to pass events (<c>true</c>) or not (<c>false</c>).</value>
        /// <since_tizen> 6 </since_tizen>
        public bool PassEvents {
            get { return GetPassEvents(); }
            set { SetPassEvents(value); }
        }

        /// <summary>Whether or not the given Evas object is to be drawn anti-aliased.</summary>
        /// <value><c>true</c> if the object is to be anti_aliased, <c>false</c> otherwise.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool AntiAlias {
            get { return GetAntiAlias(); }
            set { SetAntiAlias(value); }
        }

        /// <summary>List of objects currently clipped by <c>obj</c>.
        /// 
        /// This returns the internal list handle containing all objects clipped by the object <c>obj</c>. If none are clipped by it, the call returns <c>null</c>. This list is only valid until the clip list is changed and should be fetched again with another call to this function if any objects being clipped by this object are unclipped, clipped by a new object, deleted or get the clipper deleted. These operations will invalidate the list returned, so it should not be used anymore after that point. Any use of the list after this may have undefined results, possibly leading to crashes.
        /// 
        /// See also <see cref="CoreUI.Canvas.Object.Clipper"/>.</summary>
        /// <value>An iterator over the list of objects clipped by <c>obj</c>.</value>
        /// <since_tizen> 6 </since_tizen>
        public IEnumerable<CoreUI.Canvas.Object> ClippedObjects {
            get { return GetClippedObjects(); }
        }

        /// <summary>Gets the parent smart object of a given Evas object, if it has one.
        /// 
        /// This can be different from <see cref="CoreUI.Object.Parent"/> because this one is used internally for rendering and the normal parent is what the user expects to be the parent.</summary>
        /// <value>The parent smart object of <c>obj</c> or <c>null</c>.</value>
        /// <since_tizen> 6 </since_tizen>
        protected CoreUI.Canvas.Object RenderParent {
            get { return GetRenderParent(); }
        }

        /// <summary>This handles text paragraph direction of the given object. Even if the given object is not textblock or text, its smart child objects can inherit the paragraph direction from the given object. The default paragraph direction is <c>inherit</c>.</summary>
        /// <value>Paragraph direction for the given object.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.TextBidirectionalType ParagraphDirection {
            get { return GetParagraphDirection(); }
            set { SetParagraphDirection(value); }
        }

        /// <summary>Disables all rendering on the canvas.
        /// 
        /// This flag will be used to indicate to Evas that this object should never be rendered on the canvas under any circumstances. In particular, this is useful to avoid drawing clipper objects (or masks) even when they don&apos;t clip any object. This can also be used to replace the old source_visible flag with proxy objects.
        /// 
        /// This is different to the visible property, as even visible objects marked as &quot;no-render&quot; will never appear on screen. But those objects can still be used as proxy sources or clippers. When hidden, all &quot;no-render&quot; objects will completely disappear from the canvas, and hide their clippees or be invisible when used as proxy sources.</summary>
        /// <value>Enable &quot;no-render&quot; mode.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool NoRender {
            get { return GetNoRender(); }
            set { SetNoRender(value); }
        }

        /// <summary>The animation that is currently played on the canvas object.
        /// 
        /// <c>null</c> in case that there is no animation running.</summary>
        /// <value>The animation which is currently applied on this object.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Canvas.Animation Animation {
            get { return GetAnimation(); }
        }

        /// <summary>The current progress of the animation, between <c>0.0</c> and <c>1.0</c>.
        /// 
        /// Even if the animation is going backwards (speed &lt; 0.0) the progress will still go from <c>0.0</c> to <c>1.0</c>.
        /// 
        /// If there is no animation going on, this will return <c>-1.0</c>.</summary>
        /// <value>Current progress of the animation.</value>
        /// <since_tizen> 6 </since_tizen>
        public double AnimationProgress {
            get { return GetAnimationProgress(); }
        }

        /// <summary>Pause the animation.
        /// 
        /// <see cref="CoreUI.Canvas.IObjectAnimation.GetAnimation"/> will not be unset. When <c>pause</c> is <c>false</c>, the animation will be resumed at the same progress it was when it was paused.</summary>
        /// <value>Paused state.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool AnimationPause {
            get { return GetAnimationPause(); }
            set { SetAnimationPause(value); }
        }

        /// <summary>The general/main color of the given Evas object.
        /// 
        /// Represents the main color&apos;s RGB component (and alpha channel) values, which range from 0 to 255. For the alpha channel, which defines the object&apos;s transparency level, 0 means totally transparent, while 255 means opaque. These color values are premultiplied by the alpha value.
        /// 
        /// Usually you&apos;ll use this attribute for text and rectangle objects, where the main color is the only color. If set for objects which themselves have colors, like the images one, those colors get modulated by this one.
        /// 
        /// All newly created Evas rectangles get the default color values of 255 255 255 255 (opaque white).
        /// 
        /// When reading this property, use <c>NULL</c> pointers on the components you&apos;re not interested in and they&apos;ll be ignored by the function.</summary>
        /// <since_tizen> 6 </since_tizen>
        public (int, int, int, int) Color {
            get {
                int _out_r = default(int);
                int _out_g = default(int);
                int _out_b = default(int);
                int _out_a = default(int);
                GetColor(out _out_r, out _out_g, out _out_b, out _out_a);
                return (_out_r, _out_g, _out_b, _out_a);
            }
            set { SetColor( value.Item1,  value.Item2,  value.Item3,  value.Item4); }
        }

        /// <summary>Hexadecimal color code of given Evas object (#RRGGBBAA).</summary>
        /// <value>the hex color code.</value>
        /// <since_tizen> 6 </since_tizen>
        public System.String ColorCode {
            get { return GetColorCode(); }
            set { SetColorCode(value); }
        }

        /// <summary>The 2D position of a canvas object.
        /// 
        /// The position is absolute, in pixels, relative to the top-left corner of the window, within its border decorations (application space).<br/>
        /// <b>Note on writing:</b> Moves the given canvas object to the given location inside its canvas&apos; viewport. If unchanged this call may be entirely skipped, but if changed this will trigger move events, as well as potential pointer,in or pointer,out events.<br/>
        /// <b>Note on reading:</b> Retrieves the position of the given canvas object.</summary>
        /// <value>A 2D coordinate in pixel units.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Position2D Position {
            get { return GetPosition(); }
            set { SetPosition(value); }
        }

        /// <summary>The 2D size of a canvas object.<br/>
        /// <b>Note on writing:</b> Changes the size of the given object.
        /// 
        /// Note that setting the actual size of an object might be the job of its container, so this function might have no effect. Look at <see cref="CoreUI.Gfx.IHint"/> instead, when manipulating widgets.<br/>
        /// <b>Note on reading:</b> Retrieves the (rectangular) size of the given Evas object.</summary>
        /// <value>A 2D size in pixel units.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Size2D Size {
            get { return GetSize(); }
            set { SetSize(value); }
        }

        /// <summary>Rectangular geometry that combines both position and size.</summary>
        /// <value>The X,Y position and W,H size, in pixels.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Rect Geometry {
            get { return GetGeometry(); }
            set { SetGeometry(value); }
        }

        /// <summary>The visibility of a canvas object.
        /// 
        /// All canvas objects will become visible by default just before render. This means that it is not required to call <see cref="CoreUI.Gfx.IEntity.SetVisible"/> after creating an object unless you want to create it without showing it. Note that this behavior is new since 1.21, and only applies to canvas objects created with the EO API (i.e. not the legacy C-only API). Other types of Gfx objects may or may not be visible by default.
        /// 
        /// Note that many other parameters can prevent a visible object from actually being &quot;visible&quot; on screen. For instance if its color is fully transparent, or its parent is hidden, or it is clipped out, etc...<br/>
        /// <b>Note on writing:</b> Shows or hides this object.<br/>
        /// <b>Note on reading:</b> Retrieves whether or not the given canvas object is visible.</summary>
        /// <value><c>true</c> if to make the object visible, <c>false</c> otherwise</value>
        /// <since_tizen> 6 </since_tizen>
        public bool Visible {
            get { return GetVisible(); }
            set { SetVisible(value); }
        }

        /// <summary>The scaling factor of an object.
        /// 
        /// This property is an individual scaling factor on the object (Edje or UI widget). This property (or Edje&apos;s global scaling factor, when applicable), will affect this object&apos;s part sizes. If scale is not zero, then the individual scaling will override any global scaling set, for the object obj&apos;s parts. Set it back to zero to get the effects of the global scaling again.
        /// 
        /// <b>WARNING: </b>In Edje, only parts which, at EDC level, had the &quot;scale&quot; property set to 1, will be affected by this function. Check the complete &quot;syntax reference&quot; for EDC files.<br/>
        /// <b>Note on writing:</b> Sets the scaling factor of an object.<br/>
        /// <b>Note on reading:</b> Gets an object&apos;s scaling factor.</summary>
        /// <value>The scaling factor.</value>
        /// <since_tizen> 6 </since_tizen>
        public double Scale {
            get { return GetScale(); }
            set { SetScale(value); }
        }

        /// <summary>Defines the aspect ratio to respect when scaling this object.
        /// 
        /// The aspect ratio is defined as the width / height ratio of the object. Depending on the object and its container, this hint may or may not be fully respected.
        /// 
        /// If any of the given aspect ratio terms are 0, the object&apos;s container will ignore the aspect and scale this object to occupy the whole available area, for any given policy.</summary>
        /// <value>Mode of interpretation.</value>
        /// <since_tizen> 6 </since_tizen>
        public (CoreUI.Gfx.HintAspect, CoreUI.DataTypes.Size2D) HintAspect {
            get {
                CoreUI.Gfx.HintAspect _out_mode = default(CoreUI.Gfx.HintAspect);
                CoreUI.DataTypes.Size2D _out_sz = default(CoreUI.DataTypes.Size2D);
                GetHintAspect(out _out_mode, out _out_sz);
                return (_out_mode, _out_sz);
            }
            set { SetHintAspect( value.Item1,  value.Item2); }
        }

        /// <summary>Hints on the object&apos;s maximum size.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
        /// 
        /// The object container is in charge of fetching this property and placing the object accordingly.
        /// 
        /// Values -1 will be treated as unset hint components, when queried by managers.
        /// 
        /// <b>NOTE: </b>Smart objects (such as elementary) can have their own hint policy. So calling this API may or may not affect the size of smart objects.
        /// 
        /// <b>NOTE: </b>It is an error for the <see cref="CoreUI.Gfx.IHint.HintSizeMax"/> to be smaller in either axis than <see cref="CoreUI.Gfx.IHint.HintSizeMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.</summary>
        /// <value>Maximum size (hint) in pixels, (-1, -1) by default for canvas objects).</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Size2D HintSizeMax {
            get { return GetHintSizeMax(); }
            set { SetHintSizeMax(value); }
        }

        /// <summary>Internal hints for an object&apos;s maximum size.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
        /// 
        /// Values -1 will be treated as unset hint components, when queried by managers.
        /// 
        /// <b>NOTE: </b>This property is internal and meant for widget developers to define the absolute maximum size of the object. EFL itself sets this size internally, so any change to it from an application might be ignored. Applications should use <see cref="CoreUI.Gfx.IHint.HintSizeMax"/> instead.
        /// 
        /// <b>NOTE: </b>It is an error for the <see cref="CoreUI.Gfx.IHint.HintSizeRestrictedMax"/> to be smaller in either axis than <see cref="CoreUI.Gfx.IHint.HintSizeRestrictedMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.<br/>
        /// <b>Note on writing:</b> This function is protected as it is meant for widgets to indicate their &quot;intrinsic&quot; maximum size.</summary>
        /// <value>Maximum size (hint) in pixels.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Size2D HintSizeRestrictedMax {
            get { return GetHintSizeRestrictedMax(); }
            protected set { SetHintSizeRestrictedMax(value); }
        }

        /// <summary>Read-only maximum size combining both <see cref="CoreUI.Gfx.IHint.HintSizeRestrictedMax"/> and <see cref="CoreUI.Gfx.IHint.HintSizeMax"/> hints.
        /// 
        /// <see cref="CoreUI.Gfx.IHint.HintSizeRestrictedMax"/> is intended for mostly internal usage and widget developers, and <see cref="CoreUI.Gfx.IHint.HintSizeMax"/> is intended to be set from application side. <see cref="CoreUI.Gfx.IHint.GetHintSizeCombinedMax"/> combines both values by taking their repective maximum (in both width and height), and is used internally to get an object&apos;s maximum size.</summary>
        /// <value>Maximum size (hint) in pixels.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Size2D HintSizeCombinedMax {
            get { return GetHintSizeCombinedMax(); }
        }

        /// <summary>Hints on the object&apos;s minimum size.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate. The object container is in charge of fetching this property and placing the object accordingly.
        /// 
        /// Value 0 will be treated as unset hint components, when queried by managers.
        /// 
        /// <b>NOTE: </b>This property is meant to be set by applications and not by EFL itself. Use this to request a specific size (treated as minimum size).
        /// 
        /// <b>NOTE: </b>It is an error for the <see cref="CoreUI.Gfx.IHint.HintSizeMax"/> to be smaller in either axis than <see cref="CoreUI.Gfx.IHint.HintSizeMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.</summary>
        /// <value>Minimum size (hint) in pixels.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Size2D HintSizeMin {
            get { return GetHintSizeMin(); }
            set { SetHintSizeMin(value); }
        }

        /// <summary>Internal hints for an object&apos;s minimum size.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
        /// 
        /// Values 0 will be treated as unset hint components, when queried by managers.
        /// 
        /// <b>NOTE: </b>This property is internal and meant for widget developers to define the absolute minimum size of the object. EFL itself sets this size internally, so any change to it from an application might be ignored. Use <see cref="CoreUI.Gfx.IHint.HintSizeMin"/> instead.
        /// 
        /// <b>NOTE: </b>It is an error for the <see cref="CoreUI.Gfx.IHint.HintSizeRestrictedMax"/> to be smaller in either axis than <see cref="CoreUI.Gfx.IHint.HintSizeRestrictedMin"/>. In this scenario, the max size hint will be prioritized over the user min size hint.<br/>
        /// <b>Note on writing:</b> This function is protected as it is meant for widgets to indicate their &quot;intrinsic&quot; minimum size.<br/>
        /// <b>Note on reading:</b> Get the &quot;intrinsic&quot; minimum size of this object.</summary>
        /// <value>Minimum size (hint) in pixels.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Size2D HintSizeRestrictedMin {
            get { return GetHintSizeRestrictedMin(); }
            protected set { SetHintSizeRestrictedMin(value); }
        }

        /// <summary>Read-only minimum size combining both <see cref="CoreUI.Gfx.IHint.HintSizeRestrictedMin"/> and <see cref="CoreUI.Gfx.IHint.HintSizeMin"/> hints.
        /// 
        /// <see cref="CoreUI.Gfx.IHint.HintSizeRestrictedMin"/> is intended for mostly internal usage and widget developers, and <see cref="CoreUI.Gfx.IHint.HintSizeMin"/> is intended to be set from application side. <see cref="CoreUI.Gfx.IHint.GetHintSizeCombinedMin"/> combines both values by taking their repective maximum (in both width and height), and is used internally to get an object&apos;s minimum size.</summary>
        /// <value>Minimum size (hint) in pixels.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Size2D HintSizeCombinedMin {
            get { return GetHintSizeCombinedMin(); }
        }

        /// <summary>Hints for an object&apos;s margin or padding space.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
        /// 
        /// The object container is in charge of fetching this property and placing the object accordingly.
        /// 
        /// <b>NOTE: </b>Smart objects (such as elementary) can have their own hint policy. So calling this API may or may not affect the size of smart objects.</summary>
        /// <value>Integer to specify left padding.</value>
        /// <since_tizen> 6 </since_tizen>
        public (int, int, int, int) HintMargin {
            get {
                int _out_l = default(int);
                int _out_r = default(int);
                int _out_t = default(int);
                int _out_b = default(int);
                GetHintMargin(out _out_l, out _out_r, out _out_t, out _out_b);
                return (_out_l, _out_r, _out_t, _out_b);
            }
            set { SetHintMargin( value.Item1,  value.Item2,  value.Item3,  value.Item4); }
        }

        /// <summary>Hints for an object&apos;s weight.
        /// 
        /// This is a hint on how a container object should resize a given child within its area. Containers may adhere to the simpler logic of just expanding the child object&apos;s dimensions to fit its own (see the <see cref="CoreUI.Gfx.Constants.HintExpand"/> helper weight macro) or the complete one of taking each child&apos;s weight hint as real weights to how much of its size to allocate for them in each axis. A container is supposed to, after normalizing the weights of its children (with weight  hints), distribut the space it has to layout them by those factors -- most weighted children get larger in this process than the least ones.
        /// 
        /// Accepted values are zero or positive values. Some containers might use this hint as a boolean, but some others might consider it as a proportion, see documentation of each container.
        /// 
        /// <b>NOTE: </b>Default weight hint values are 0.0, for both axis.</summary>
        /// <value>Non-negative double value to use as horizontal weight hint.</value>
        /// <since_tizen> 6 </since_tizen>
        public (double, double) HintWeight {
            get {
                double _out_x = default(double);
                double _out_y = default(double);
                GetHintWeight(out _out_x, out _out_y);
                return (_out_x, _out_y);
            }
            set { SetHintWeight( value.Item1,  value.Item2); }
        }

        /// <summary>Hints for an object&apos;s alignment.
        /// 
        /// These are hints on how to align this object inside the boundaries of its container/manager.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.</summary>
        /// <value>Controls the horizontal alignment.</value>
        /// <since_tizen> 6 </since_tizen>
        public (CoreUI.Gfx.Align, CoreUI.Gfx.Align) HintAlign {
            get {
                CoreUI.Gfx.Align _out_x = default(CoreUI.Gfx.Align);
                CoreUI.Gfx.Align _out_y = default(CoreUI.Gfx.Align);
                GetHintAlign(out _out_x, out _out_y);
                return (_out_x, _out_y);
            }
            set { SetHintAlign( value.Item1,  value.Item2); }
        }

        /// <summary>Hints for an object&apos;s fill property that used to specify &quot;justify&quot; or &quot;fill&quot; by some users. <see cref="CoreUI.Gfx.IHint.HintFill"/> specify whether to fill the space inside the boundaries of a container/manager.
        /// 
        /// Maximum hints should be enforced with higher priority, if they are set. Also, any <see cref="CoreUI.Gfx.IHint.HintMargin"/> set on objects should add up to the object space on the final scene composition.
        /// 
        /// See documentation of possible users: in Evas, they are the <see cref="CoreUI.UI.Box"/> &quot;box&quot; and <see cref="CoreUI.UI.Table"/> &quot;table&quot; smart objects.
        /// 
        /// This is not a size enforcement in any way, it&apos;s just a hint that should be used whenever appropriate.
        /// 
        /// <b>NOTE: </b>Default fill hint values are true, for both axes.</summary>
        /// <value><c>true</c> if to fill the object space, <c>false</c> otherwise, to use as horizontal fill hint.</value>
        /// <since_tizen> 6 </since_tizen>
        public (bool, bool) HintFill {
            get {
                bool _out_x = default(bool);
                bool _out_y = default(bool);
                GetHintFill(out _out_x, out _out_y);
                return (_out_x, _out_y);
            }
            set { SetHintFill( value.Item1,  value.Item2); }
        }

        /// <summary>Number of points of a map.
        /// 
        /// This sets the number of points of map. Currently, the number of points must be multiples of 4.</summary>
        /// <value>The number of points of map</value>
        /// <since_tizen> 6 </since_tizen>
        public int MappingPointCount {
            get { return GetMappingPointCount(); }
            set { SetMappingPointCount(value); }
        }

        /// <summary>Clockwise state of a map (read-only).
        /// 
        /// This determines if the output points (X and Y. Z is not used) are clockwise or counter-clockwise. This can be used for &quot;back-face culling&quot;. This is where you hide objects that &quot;face away&quot; from you. In this case objects that are not clockwise.</summary>
        /// <value><c>true</c> if clockwise, <c>false</c> if counter clockwise</value>
        /// <since_tizen> 6 </since_tizen>
        public bool MappingClockwise {
            get { return GetMappingClockwise(); }
        }

        /// <summary>Smoothing state for map rendering.
        /// 
        /// This sets smoothing for map rendering. If the object is a type that has its own smoothing settings, then both the smooth settings for this object and the map must be turned off. By default smooth maps are enabled.</summary>
        /// <value><c>true</c> by default.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool MappingSmooth {
            get { return GetMappingSmooth(); }
            set { SetMappingSmooth(value); }
        }

        /// <summary>Alpha flag for map rendering.
        /// 
        /// This sets alpha flag for map rendering. If the object is a type that has its own alpha settings, then this will take precedence. Only image objects support this currently (<span class="text-muted">CoreUI.Canvas.Image (object still in beta stage)</span> and its friends). Setting this to off stops alpha blending of the map area, and is useful if you know the object and/or all sub-objects is 100% solid.
        /// 
        /// Note that this may conflict with <see cref="CoreUI.Gfx.IMapping.MappingSmooth"/> depending on which algorithm is used for anti-aliasing.</summary>
        /// <value><c>true</c> by default.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool MappingAlpha {
            get { return GetMappingAlpha(); }
            set { SetMappingAlpha(value); }
        }

        /// <summary>The layer of its canvas that the given object will be part of.
        /// 
        /// If you don&apos;t use this property, you&apos;ll be dealing with a unique layer of objects (the default one). Additional layers are handy when you don&apos;t want a set of objects to interfere with another set with regard to stacking. Two layers are completely disjoint in that matter.
        /// 
        /// This is a low-level function, which you&apos;d be using when something should be always on top, for example.
        /// 
        /// <b>WARNING: </b>Don&apos;t change the layer of smart objects&apos; children. Smart objects have a layer of their own, which should contain all their child objects.</summary>
        /// <value>The number of the layer to place the object on. Must be between <see cref="CoreUI.Gfx.Constants.StackLayerMin"/> and <see cref="CoreUI.Gfx.Constants.StackLayerMax"/>.</value>
        /// <since_tizen> 6 </since_tizen>
        public short Layer {
            get { return GetLayer(); }
            set { SetLayer(value); }
        }

        /// <summary>The Evas object stacked right below this object.
        /// 
        /// This function will traverse layers in its search, if there are objects on layers below the one <c>obj</c> is placed at.
        /// 
        /// See also <see cref="CoreUI.Gfx.IStack.Layer"/>.</summary>
        /// <value>The <see cref="CoreUI.Gfx.IStack"/> object directly below <c>obj</c>, if any, or <c>null</c>, if none.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Gfx.IStack Below {
            get { return GetBelow(); }
        }

        /// <summary>Get the Evas object stacked right above this object.
        /// 
        /// This function will traverse layers in its search, if there are objects on layers above the one <c>obj</c> is placed at.
        /// 
        /// See also <see cref="CoreUI.Gfx.IStack.Layer"/> and <see cref="CoreUI.Gfx.IStack.GetBelow"/></summary>
        /// <value>The <see cref="CoreUI.Gfx.IStack"/> object directly below <c>obj</c>, if any, or <c>null</c>, if none.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Gfx.IStack Above {
            get { return GetAbove(); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.Canvas.Object.efl_canvas_object_class_get();
        }

        /// <summary>Wrapper for native methods and virtual method delegates.
        /// For internal use by generated code only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new class NativeMethods : CoreUI.LoopConsumer.NativeMethods
        {
            private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Evas);

            /// <summary>Gets the list of Eo operations to override.
        /// </summary>
            /// <returns>The list of Eo operations to be overload.</returns>
            internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
            {
                var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
                var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

                if (efl_canvas_object_render_op_get_static_delegate == null)
                {
                    efl_canvas_object_render_op_get_static_delegate = new efl_canvas_object_render_op_get_delegate(render_op_get);
                }

                if (methods.Contains("GetRenderOp"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_render_op_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_render_op_get_static_delegate) });
                }

                if (efl_canvas_object_render_op_set_static_delegate == null)
                {
                    efl_canvas_object_render_op_set_static_delegate = new efl_canvas_object_render_op_set_delegate(render_op_set);
                }

                if (methods.Contains("SetRenderOp"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_render_op_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_render_op_set_static_delegate) });
                }

                if (efl_canvas_object_clipper_get_static_delegate == null)
                {
                    efl_canvas_object_clipper_get_static_delegate = new efl_canvas_object_clipper_get_delegate(clipper_get);
                }

                if (methods.Contains("GetClipper"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_clipper_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_clipper_get_static_delegate) });
                }

                if (efl_canvas_object_clipper_set_static_delegate == null)
                {
                    efl_canvas_object_clipper_set_static_delegate = new efl_canvas_object_clipper_set_delegate(clipper_set);
                }

                if (methods.Contains("SetClipper"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_clipper_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_clipper_set_static_delegate) });
                }

                if (efl_canvas_object_repeat_events_get_static_delegate == null)
                {
                    efl_canvas_object_repeat_events_get_static_delegate = new efl_canvas_object_repeat_events_get_delegate(repeat_events_get);
                }

                if (methods.Contains("GetRepeatEvents"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_repeat_events_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_repeat_events_get_static_delegate) });
                }

                if (efl_canvas_object_repeat_events_set_static_delegate == null)
                {
                    efl_canvas_object_repeat_events_set_static_delegate = new efl_canvas_object_repeat_events_set_delegate(repeat_events_set);
                }

                if (methods.Contains("SetRepeatEvents"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_repeat_events_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_repeat_events_set_static_delegate) });
                }

                if (efl_canvas_object_key_focus_get_static_delegate == null)
                {
                    efl_canvas_object_key_focus_get_static_delegate = new efl_canvas_object_key_focus_get_delegate(key_focus_get);
                }

                if (methods.Contains("GetKeyFocus"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_key_focus_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_key_focus_get_static_delegate) });
                }

                if (efl_canvas_object_key_focus_set_static_delegate == null)
                {
                    efl_canvas_object_key_focus_set_static_delegate = new efl_canvas_object_key_focus_set_delegate(key_focus_set);
                }

                if (methods.Contains("SetKeyFocus"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_key_focus_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_key_focus_set_static_delegate) });
                }

                if (efl_canvas_object_seat_focus_get_static_delegate == null)
                {
                    efl_canvas_object_seat_focus_get_static_delegate = new efl_canvas_object_seat_focus_get_delegate(seat_focus_get);
                }

                if (methods.Contains("GetSeatFocus"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_seat_focus_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_seat_focus_get_static_delegate) });
                }

                if (efl_canvas_object_precise_is_inside_get_static_delegate == null)
                {
                    efl_canvas_object_precise_is_inside_get_static_delegate = new efl_canvas_object_precise_is_inside_get_delegate(precise_is_inside_get);
                }

                if (methods.Contains("GetPreciseIsInside"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_precise_is_inside_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_precise_is_inside_get_static_delegate) });
                }

                if (efl_canvas_object_precise_is_inside_set_static_delegate == null)
                {
                    efl_canvas_object_precise_is_inside_set_static_delegate = new efl_canvas_object_precise_is_inside_set_delegate(precise_is_inside_set);
                }

                if (methods.Contains("SetPreciseIsInside"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_precise_is_inside_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_precise_is_inside_set_static_delegate) });
                }

                if (efl_canvas_object_propagate_events_get_static_delegate == null)
                {
                    efl_canvas_object_propagate_events_get_static_delegate = new efl_canvas_object_propagate_events_get_delegate(propagate_events_get);
                }

                if (methods.Contains("GetPropagateEvents"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_propagate_events_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_propagate_events_get_static_delegate) });
                }

                if (efl_canvas_object_propagate_events_set_static_delegate == null)
                {
                    efl_canvas_object_propagate_events_set_static_delegate = new efl_canvas_object_propagate_events_set_delegate(propagate_events_set);
                }

                if (methods.Contains("SetPropagateEvents"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_propagate_events_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_propagate_events_set_static_delegate) });
                }

                if (efl_canvas_object_pass_events_get_static_delegate == null)
                {
                    efl_canvas_object_pass_events_get_static_delegate = new efl_canvas_object_pass_events_get_delegate(pass_events_get);
                }

                if (methods.Contains("GetPassEvents"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_pass_events_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_pass_events_get_static_delegate) });
                }

                if (efl_canvas_object_pass_events_set_static_delegate == null)
                {
                    efl_canvas_object_pass_events_set_static_delegate = new efl_canvas_object_pass_events_set_delegate(pass_events_set);
                }

                if (methods.Contains("SetPassEvents"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_pass_events_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_pass_events_set_static_delegate) });
                }

                if (efl_canvas_object_anti_alias_get_static_delegate == null)
                {
                    efl_canvas_object_anti_alias_get_static_delegate = new efl_canvas_object_anti_alias_get_delegate(anti_alias_get);
                }

                if (methods.Contains("GetAntiAlias"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_anti_alias_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_anti_alias_get_static_delegate) });
                }

                if (efl_canvas_object_anti_alias_set_static_delegate == null)
                {
                    efl_canvas_object_anti_alias_set_static_delegate = new efl_canvas_object_anti_alias_set_delegate(anti_alias_set);
                }

                if (methods.Contains("SetAntiAlias"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_anti_alias_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_anti_alias_set_static_delegate) });
                }

                if (efl_canvas_object_clipped_objects_get_static_delegate == null)
                {
                    efl_canvas_object_clipped_objects_get_static_delegate = new efl_canvas_object_clipped_objects_get_delegate(clipped_objects_get);
                }

                if (methods.Contains("GetClippedObjects"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_clipped_objects_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_clipped_objects_get_static_delegate) });
                }

                if (efl_canvas_object_render_parent_get_static_delegate == null)
                {
                    efl_canvas_object_render_parent_get_static_delegate = new efl_canvas_object_render_parent_get_delegate(render_parent_get);
                }

                if (methods.Contains("GetRenderParent"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_render_parent_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_render_parent_get_static_delegate) });
                }

                if (efl_canvas_object_paragraph_direction_get_static_delegate == null)
                {
                    efl_canvas_object_paragraph_direction_get_static_delegate = new efl_canvas_object_paragraph_direction_get_delegate(paragraph_direction_get);
                }

                if (methods.Contains("GetParagraphDirection"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_paragraph_direction_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_paragraph_direction_get_static_delegate) });
                }

                if (efl_canvas_object_paragraph_direction_set_static_delegate == null)
                {
                    efl_canvas_object_paragraph_direction_set_static_delegate = new efl_canvas_object_paragraph_direction_set_delegate(paragraph_direction_set);
                }

                if (methods.Contains("SetParagraphDirection"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_paragraph_direction_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_paragraph_direction_set_static_delegate) });
                }

                if (efl_canvas_object_no_render_get_static_delegate == null)
                {
                    efl_canvas_object_no_render_get_static_delegate = new efl_canvas_object_no_render_get_delegate(no_render_get);
                }

                if (methods.Contains("GetNoRender"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_no_render_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_no_render_get_static_delegate) });
                }

                if (efl_canvas_object_no_render_set_static_delegate == null)
                {
                    efl_canvas_object_no_render_set_static_delegate = new efl_canvas_object_no_render_set_delegate(no_render_set);
                }

                if (methods.Contains("SetNoRender"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_no_render_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_no_render_set_static_delegate) });
                }

                if (efl_canvas_object_coords_inside_get_static_delegate == null)
                {
                    efl_canvas_object_coords_inside_get_static_delegate = new efl_canvas_object_coords_inside_get_delegate(coords_inside_get);
                }

                if (methods.Contains("GetCoordsInside"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_coords_inside_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_coords_inside_get_static_delegate) });
                }

                if (efl_canvas_object_clipped_objects_count_static_delegate == null)
                {
                    efl_canvas_object_clipped_objects_count_static_delegate = new efl_canvas_object_clipped_objects_count_delegate(clipped_objects_count);
                }

                if (methods.Contains("ClippedObjectsCount"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_clipped_objects_count"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_clipped_objects_count_static_delegate) });
                }

                if (efl_canvas_object_key_grab_static_delegate == null)
                {
                    efl_canvas_object_key_grab_static_delegate = new efl_canvas_object_key_grab_delegate(key_grab);
                }

                if (methods.Contains("GrabKey"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_key_grab"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_key_grab_static_delegate) });
                }

                if (efl_canvas_object_key_ungrab_static_delegate == null)
                {
                    efl_canvas_object_key_ungrab_static_delegate = new efl_canvas_object_key_ungrab_delegate(key_ungrab);
                }

                if (methods.Contains("UngrabKey"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_object_key_ungrab"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_object_key_ungrab_static_delegate) });
                }

                if (efl_gfx_hint_size_restricted_max_set_static_delegate == null)
                {
                    efl_gfx_hint_size_restricted_max_set_static_delegate = new efl_gfx_hint_size_restricted_max_set_delegate(hint_size_restricted_max_set);
                }

                if (methods.Contains("SetHintSizeRestrictedMax"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_size_restricted_max_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_size_restricted_max_set_static_delegate) });
                }

                if (efl_gfx_hint_size_restricted_min_set_static_delegate == null)
                {
                    efl_gfx_hint_size_restricted_min_set_static_delegate = new efl_gfx_hint_size_restricted_min_set_delegate(hint_size_restricted_min_set);
                }

                if (methods.Contains("SetHintSizeRestrictedMin"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_hint_size_restricted_min_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_hint_size_restricted_min_set_static_delegate) });
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
                return CoreUI.Canvas.Object.efl_canvas_object_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            
            private delegate CoreUI.Gfx.RenderOp efl_canvas_object_render_op_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate CoreUI.Gfx.RenderOp efl_canvas_object_render_op_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_render_op_get_api_delegate> efl_canvas_object_render_op_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_render_op_get_api_delegate>(Module, "efl_canvas_object_render_op_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.Gfx.RenderOp render_op_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_canvas_object_render_op_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.Gfx.RenderOp _ret_var = default(CoreUI.Gfx.RenderOp);
                    try
                    {
                        _ret_var = ((Object)ws.Target).GetRenderOp();
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
                    return efl_canvas_object_render_op_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_canvas_object_render_op_get_delegate efl_canvas_object_render_op_get_static_delegate;

            
            private delegate void efl_canvas_object_render_op_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.Gfx.RenderOp render_op);

            
            internal delegate void efl_canvas_object_render_op_set_api_delegate(System.IntPtr obj,  CoreUI.Gfx.RenderOp render_op);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_render_op_set_api_delegate> efl_canvas_object_render_op_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_render_op_set_api_delegate>(Module, "efl_canvas_object_render_op_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void render_op_set(System.IntPtr obj, System.IntPtr pd, CoreUI.Gfx.RenderOp render_op)
            {
                CoreUI.DataTypes.Log.Debug("function efl_canvas_object_render_op_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Object)ws.Target).SetRenderOp(render_op);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_canvas_object_render_op_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), render_op);
                }
            }

            private static efl_canvas_object_render_op_set_delegate efl_canvas_object_render_op_set_static_delegate;

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            private delegate CoreUI.Canvas.Object efl_canvas_object_clipper_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            internal delegate CoreUI.Canvas.Object efl_canvas_object_clipper_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_clipper_get_api_delegate> efl_canvas_object_clipper_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_clipper_get_api_delegate>(Module, "efl_canvas_object_clipper_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.Canvas.Object clipper_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_canvas_object_clipper_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.Canvas.Object _ret_var = default(CoreUI.Canvas.Object);
                    try
                    {
                        _ret_var = ((Object)ws.Target).GetClipper();
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
                    return efl_canvas_object_clipper_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_canvas_object_clipper_get_delegate efl_canvas_object_clipper_get_static_delegate;

            
            private delegate void efl_canvas_object_clipper_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Canvas.Object clipper);

            
            internal delegate void efl_canvas_object_clipper_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Canvas.Object clipper);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_clipper_set_api_delegate> efl_canvas_object_clipper_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_clipper_set_api_delegate>(Module, "efl_canvas_object_clipper_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void clipper_set(System.IntPtr obj, System.IntPtr pd, CoreUI.Canvas.Object clipper)
            {
                CoreUI.DataTypes.Log.Debug("function efl_canvas_object_clipper_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Object)ws.Target).SetClipper(clipper);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_canvas_object_clipper_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), clipper);
                }
            }

            private static efl_canvas_object_clipper_set_delegate efl_canvas_object_clipper_set_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_canvas_object_repeat_events_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_canvas_object_repeat_events_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_repeat_events_get_api_delegate> efl_canvas_object_repeat_events_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_repeat_events_get_api_delegate>(Module, "efl_canvas_object_repeat_events_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool repeat_events_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_canvas_object_repeat_events_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Object)ws.Target).GetRepeatEvents();
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
                    return efl_canvas_object_repeat_events_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_canvas_object_repeat_events_get_delegate efl_canvas_object_repeat_events_get_static_delegate;

            
            private delegate void efl_canvas_object_repeat_events_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool repeat);

            
            internal delegate void efl_canvas_object_repeat_events_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool repeat);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_repeat_events_set_api_delegate> efl_canvas_object_repeat_events_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_repeat_events_set_api_delegate>(Module, "efl_canvas_object_repeat_events_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void repeat_events_set(System.IntPtr obj, System.IntPtr pd, bool repeat)
            {
                CoreUI.DataTypes.Log.Debug("function efl_canvas_object_repeat_events_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Object)ws.Target).SetRepeatEvents(repeat);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_canvas_object_repeat_events_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), repeat);
                }
            }

            private static efl_canvas_object_repeat_events_set_delegate efl_canvas_object_repeat_events_set_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_canvas_object_key_focus_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_canvas_object_key_focus_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_key_focus_get_api_delegate> efl_canvas_object_key_focus_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_key_focus_get_api_delegate>(Module, "efl_canvas_object_key_focus_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool key_focus_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_canvas_object_key_focus_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Object)ws.Target).GetKeyFocus();
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
                    return efl_canvas_object_key_focus_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_canvas_object_key_focus_get_delegate efl_canvas_object_key_focus_get_static_delegate;

            
            private delegate void efl_canvas_object_key_focus_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool focus);

            
            internal delegate void efl_canvas_object_key_focus_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool focus);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_key_focus_set_api_delegate> efl_canvas_object_key_focus_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_key_focus_set_api_delegate>(Module, "efl_canvas_object_key_focus_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void key_focus_set(System.IntPtr obj, System.IntPtr pd, bool focus)
            {
                CoreUI.DataTypes.Log.Debug("function efl_canvas_object_key_focus_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Object)ws.Target).SetKeyFocus(focus);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_canvas_object_key_focus_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), focus);
                }
            }

            private static efl_canvas_object_key_focus_set_delegate efl_canvas_object_key_focus_set_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_canvas_object_seat_focus_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_canvas_object_seat_focus_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_seat_focus_get_api_delegate> efl_canvas_object_seat_focus_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_seat_focus_get_api_delegate>(Module, "efl_canvas_object_seat_focus_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool seat_focus_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_canvas_object_seat_focus_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Object)ws.Target).GetSeatFocus();
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
                    return efl_canvas_object_seat_focus_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_canvas_object_seat_focus_get_delegate efl_canvas_object_seat_focus_get_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_canvas_object_precise_is_inside_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_canvas_object_precise_is_inside_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_precise_is_inside_get_api_delegate> efl_canvas_object_precise_is_inside_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_precise_is_inside_get_api_delegate>(Module, "efl_canvas_object_precise_is_inside_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool precise_is_inside_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_canvas_object_precise_is_inside_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Object)ws.Target).GetPreciseIsInside();
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
                    return efl_canvas_object_precise_is_inside_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_canvas_object_precise_is_inside_get_delegate efl_canvas_object_precise_is_inside_get_static_delegate;

            
            private delegate void efl_canvas_object_precise_is_inside_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool precise);

            
            internal delegate void efl_canvas_object_precise_is_inside_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool precise);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_precise_is_inside_set_api_delegate> efl_canvas_object_precise_is_inside_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_precise_is_inside_set_api_delegate>(Module, "efl_canvas_object_precise_is_inside_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void precise_is_inside_set(System.IntPtr obj, System.IntPtr pd, bool precise)
            {
                CoreUI.DataTypes.Log.Debug("function efl_canvas_object_precise_is_inside_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Object)ws.Target).SetPreciseIsInside(precise);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_canvas_object_precise_is_inside_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), precise);
                }
            }

            private static efl_canvas_object_precise_is_inside_set_delegate efl_canvas_object_precise_is_inside_set_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_canvas_object_propagate_events_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_canvas_object_propagate_events_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_propagate_events_get_api_delegate> efl_canvas_object_propagate_events_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_propagate_events_get_api_delegate>(Module, "efl_canvas_object_propagate_events_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool propagate_events_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_canvas_object_propagate_events_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Object)ws.Target).GetPropagateEvents();
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
                    return efl_canvas_object_propagate_events_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_canvas_object_propagate_events_get_delegate efl_canvas_object_propagate_events_get_static_delegate;

            
            private delegate void efl_canvas_object_propagate_events_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool propagate);

            
            internal delegate void efl_canvas_object_propagate_events_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool propagate);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_propagate_events_set_api_delegate> efl_canvas_object_propagate_events_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_propagate_events_set_api_delegate>(Module, "efl_canvas_object_propagate_events_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void propagate_events_set(System.IntPtr obj, System.IntPtr pd, bool propagate)
            {
                CoreUI.DataTypes.Log.Debug("function efl_canvas_object_propagate_events_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Object)ws.Target).SetPropagateEvents(propagate);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_canvas_object_propagate_events_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), propagate);
                }
            }

            private static efl_canvas_object_propagate_events_set_delegate efl_canvas_object_propagate_events_set_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_canvas_object_pass_events_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_canvas_object_pass_events_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_pass_events_get_api_delegate> efl_canvas_object_pass_events_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_pass_events_get_api_delegate>(Module, "efl_canvas_object_pass_events_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool pass_events_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_canvas_object_pass_events_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Object)ws.Target).GetPassEvents();
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
                    return efl_canvas_object_pass_events_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_canvas_object_pass_events_get_delegate efl_canvas_object_pass_events_get_static_delegate;

            
            private delegate void efl_canvas_object_pass_events_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool pass);

            
            internal delegate void efl_canvas_object_pass_events_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool pass);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_pass_events_set_api_delegate> efl_canvas_object_pass_events_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_pass_events_set_api_delegate>(Module, "efl_canvas_object_pass_events_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void pass_events_set(System.IntPtr obj, System.IntPtr pd, bool pass)
            {
                CoreUI.DataTypes.Log.Debug("function efl_canvas_object_pass_events_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Object)ws.Target).SetPassEvents(pass);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_canvas_object_pass_events_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), pass);
                }
            }

            private static efl_canvas_object_pass_events_set_delegate efl_canvas_object_pass_events_set_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_canvas_object_anti_alias_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_canvas_object_anti_alias_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_anti_alias_get_api_delegate> efl_canvas_object_anti_alias_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_anti_alias_get_api_delegate>(Module, "efl_canvas_object_anti_alias_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool anti_alias_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_canvas_object_anti_alias_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Object)ws.Target).GetAntiAlias();
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
                    return efl_canvas_object_anti_alias_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_canvas_object_anti_alias_get_delegate efl_canvas_object_anti_alias_get_static_delegate;

            
            private delegate void efl_canvas_object_anti_alias_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool anti_alias);

            
            internal delegate void efl_canvas_object_anti_alias_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool anti_alias);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_anti_alias_set_api_delegate> efl_canvas_object_anti_alias_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_anti_alias_set_api_delegate>(Module, "efl_canvas_object_anti_alias_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void anti_alias_set(System.IntPtr obj, System.IntPtr pd, bool anti_alias)
            {
                CoreUI.DataTypes.Log.Debug("function efl_canvas_object_anti_alias_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Object)ws.Target).SetAntiAlias(anti_alias);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_canvas_object_anti_alias_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), anti_alias);
                }
            }

            private static efl_canvas_object_anti_alias_set_delegate efl_canvas_object_anti_alias_set_static_delegate;

            
            private delegate System.IntPtr efl_canvas_object_clipped_objects_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate System.IntPtr efl_canvas_object_clipped_objects_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_clipped_objects_get_api_delegate> efl_canvas_object_clipped_objects_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_clipped_objects_get_api_delegate>(Module, "efl_canvas_object_clipped_objects_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static System.IntPtr clipped_objects_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_canvas_object_clipped_objects_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    IEnumerable<CoreUI.Canvas.Object> _ret_var = null;
                    try
                    {
                        _ret_var = ((Object)ws.Target).GetClippedObjects();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return CoreUI.Wrapper.Globals.IEnumerableToIterator(_ret_var, true);
                }
                else
                {
                    return efl_canvas_object_clipped_objects_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_canvas_object_clipped_objects_get_delegate efl_canvas_object_clipped_objects_get_static_delegate;

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            private delegate CoreUI.Canvas.Object efl_canvas_object_render_parent_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            internal delegate CoreUI.Canvas.Object efl_canvas_object_render_parent_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_render_parent_get_api_delegate> efl_canvas_object_render_parent_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_render_parent_get_api_delegate>(Module, "efl_canvas_object_render_parent_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.Canvas.Object render_parent_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_canvas_object_render_parent_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.Canvas.Object _ret_var = default(CoreUI.Canvas.Object);
                    try
                    {
                        _ret_var = ((Object)ws.Target).GetRenderParent();
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
                    return efl_canvas_object_render_parent_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_canvas_object_render_parent_get_delegate efl_canvas_object_render_parent_get_static_delegate;

            
            private delegate CoreUI.TextBidirectionalType efl_canvas_object_paragraph_direction_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate CoreUI.TextBidirectionalType efl_canvas_object_paragraph_direction_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_paragraph_direction_get_api_delegate> efl_canvas_object_paragraph_direction_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_paragraph_direction_get_api_delegate>(Module, "efl_canvas_object_paragraph_direction_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.TextBidirectionalType paragraph_direction_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_canvas_object_paragraph_direction_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.TextBidirectionalType _ret_var = default(CoreUI.TextBidirectionalType);
                    try
                    {
                        _ret_var = ((Object)ws.Target).GetParagraphDirection();
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
                    return efl_canvas_object_paragraph_direction_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_canvas_object_paragraph_direction_get_delegate efl_canvas_object_paragraph_direction_get_static_delegate;

            
            private delegate void efl_canvas_object_paragraph_direction_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.TextBidirectionalType dir);

            
            internal delegate void efl_canvas_object_paragraph_direction_set_api_delegate(System.IntPtr obj,  CoreUI.TextBidirectionalType dir);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_paragraph_direction_set_api_delegate> efl_canvas_object_paragraph_direction_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_paragraph_direction_set_api_delegate>(Module, "efl_canvas_object_paragraph_direction_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void paragraph_direction_set(System.IntPtr obj, System.IntPtr pd, CoreUI.TextBidirectionalType dir)
            {
                CoreUI.DataTypes.Log.Debug("function efl_canvas_object_paragraph_direction_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Object)ws.Target).SetParagraphDirection(dir);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_canvas_object_paragraph_direction_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), dir);
                }
            }

            private static efl_canvas_object_paragraph_direction_set_delegate efl_canvas_object_paragraph_direction_set_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_canvas_object_no_render_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_canvas_object_no_render_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_no_render_get_api_delegate> efl_canvas_object_no_render_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_no_render_get_api_delegate>(Module, "efl_canvas_object_no_render_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool no_render_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_canvas_object_no_render_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Object)ws.Target).GetNoRender();
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
                    return efl_canvas_object_no_render_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_canvas_object_no_render_get_delegate efl_canvas_object_no_render_get_static_delegate;

            
            private delegate void efl_canvas_object_no_render_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool enable);

            
            internal delegate void efl_canvas_object_no_render_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool enable);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_no_render_set_api_delegate> efl_canvas_object_no_render_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_no_render_set_api_delegate>(Module, "efl_canvas_object_no_render_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void no_render_set(System.IntPtr obj, System.IntPtr pd, bool enable)
            {
                CoreUI.DataTypes.Log.Debug("function efl_canvas_object_no_render_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Object)ws.Target).SetNoRender(enable);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_canvas_object_no_render_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), enable);
                }
            }

            private static efl_canvas_object_no_render_set_delegate efl_canvas_object_no_render_set_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_canvas_object_coords_inside_get_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.DataTypes.Position2D pos);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_canvas_object_coords_inside_get_api_delegate(System.IntPtr obj,  CoreUI.DataTypes.Position2D pos);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_coords_inside_get_api_delegate> efl_canvas_object_coords_inside_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_coords_inside_get_api_delegate>(Module, "efl_canvas_object_coords_inside_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool coords_inside_get(System.IntPtr obj, System.IntPtr pd, CoreUI.DataTypes.Position2D pos)
            {
                CoreUI.DataTypes.Log.Debug("function efl_canvas_object_coords_inside_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.DataTypes.Position2D _in_pos = pos;
bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Object)ws.Target).GetCoordsInside(_in_pos);
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
                    return efl_canvas_object_coords_inside_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), pos);
                }
            }

            private static efl_canvas_object_coords_inside_get_delegate efl_canvas_object_coords_inside_get_static_delegate;

            
            private delegate uint efl_canvas_object_clipped_objects_count_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate uint efl_canvas_object_clipped_objects_count_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_clipped_objects_count_api_delegate> efl_canvas_object_clipped_objects_count_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_clipped_objects_count_api_delegate>(Module, "efl_canvas_object_clipped_objects_count");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static uint clipped_objects_count(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_canvas_object_clipped_objects_count was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    uint _ret_var = default(uint);
                    try
                    {
                        _ret_var = ((Object)ws.Target).ClippedObjectsCount();
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
                    return efl_canvas_object_clipped_objects_count_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_canvas_object_clipped_objects_count_delegate efl_canvas_object_clipped_objects_count_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_canvas_object_key_grab_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String keyname,  CoreUI.Input.Modifier modifiers,  CoreUI.Input.Modifier not_modifiers, [MarshalAs(UnmanagedType.U1)] bool exclusive);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_canvas_object_key_grab_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String keyname,  CoreUI.Input.Modifier modifiers,  CoreUI.Input.Modifier not_modifiers, [MarshalAs(UnmanagedType.U1)] bool exclusive);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_key_grab_api_delegate> efl_canvas_object_key_grab_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_key_grab_api_delegate>(Module, "efl_canvas_object_key_grab");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool key_grab(System.IntPtr obj, System.IntPtr pd, System.String keyname, CoreUI.Input.Modifier modifiers, CoreUI.Input.Modifier not_modifiers, bool exclusive)
            {
                CoreUI.DataTypes.Log.Debug("function efl_canvas_object_key_grab was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Object)ws.Target).GrabKey(keyname, modifiers, not_modifiers, exclusive);
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
                    return efl_canvas_object_key_grab_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), keyname, modifiers, not_modifiers, exclusive);
                }
            }

            private static efl_canvas_object_key_grab_delegate efl_canvas_object_key_grab_static_delegate;

            
            private delegate void efl_canvas_object_key_ungrab_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String keyname,  CoreUI.Input.Modifier modifiers,  CoreUI.Input.Modifier not_modifiers);

            
            internal delegate void efl_canvas_object_key_ungrab_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String keyname,  CoreUI.Input.Modifier modifiers,  CoreUI.Input.Modifier not_modifiers);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_key_ungrab_api_delegate> efl_canvas_object_key_ungrab_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_object_key_ungrab_api_delegate>(Module, "efl_canvas_object_key_ungrab");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void key_ungrab(System.IntPtr obj, System.IntPtr pd, System.String keyname, CoreUI.Input.Modifier modifiers, CoreUI.Input.Modifier not_modifiers)
            {
                CoreUI.DataTypes.Log.Debug("function efl_canvas_object_key_ungrab was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Object)ws.Target).UngrabKey(keyname, modifiers, not_modifiers);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_canvas_object_key_ungrab_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), keyname, modifiers, not_modifiers);
                }
            }

            private static efl_canvas_object_key_ungrab_delegate efl_canvas_object_key_ungrab_static_delegate;

            
            private delegate void efl_gfx_hint_size_restricted_max_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.DataTypes.Size2D sz);

            
            internal delegate void efl_gfx_hint_size_restricted_max_set_api_delegate(System.IntPtr obj,  CoreUI.DataTypes.Size2D sz);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_size_restricted_max_set_api_delegate> efl_gfx_hint_size_restricted_max_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_size_restricted_max_set_api_delegate>(Module, "efl_gfx_hint_size_restricted_max_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void hint_size_restricted_max_set(System.IntPtr obj, System.IntPtr pd, CoreUI.DataTypes.Size2D sz)
            {
                CoreUI.DataTypes.Log.Debug("function efl_gfx_hint_size_restricted_max_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.DataTypes.Size2D _in_sz = sz;

                    try
                    {
                        ((Object)ws.Target).SetHintSizeRestrictedMax(_in_sz);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_gfx_hint_size_restricted_max_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), sz);
                }
            }

            private static efl_gfx_hint_size_restricted_max_set_delegate efl_gfx_hint_size_restricted_max_set_static_delegate;

            
            private delegate void efl_gfx_hint_size_restricted_min_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.DataTypes.Size2D sz);

            
            internal delegate void efl_gfx_hint_size_restricted_min_set_api_delegate(System.IntPtr obj,  CoreUI.DataTypes.Size2D sz);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_size_restricted_min_set_api_delegate> efl_gfx_hint_size_restricted_min_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_hint_size_restricted_min_set_api_delegate>(Module, "efl_gfx_hint_size_restricted_min_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void hint_size_restricted_min_set(System.IntPtr obj, System.IntPtr pd, CoreUI.DataTypes.Size2D sz)
            {
                CoreUI.DataTypes.Log.Debug("function efl_gfx_hint_size_restricted_min_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.DataTypes.Size2D _in_sz = sz;

                    try
                    {
                        ((Object)ws.Target).SetHintSizeRestrictedMin(_in_sz);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_gfx_hint_size_restricted_min_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), sz);
                }
            }

            private static efl_gfx_hint_size_restricted_min_set_delegate efl_gfx_hint_size_restricted_min_set_static_delegate;

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

namespace CoreUI.Canvas {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class ObjectExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.Gfx.RenderOp> RenderOp<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Canvas.Object, T>magic = null) where T : CoreUI.Canvas.Object {
            return new CoreUI.BindableProperty<CoreUI.Gfx.RenderOp>("render_op", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.Canvas.Object> Clipper<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Canvas.Object, T>magic = null) where T : CoreUI.Canvas.Object {
            return new CoreUI.BindableProperty<CoreUI.Canvas.Object>("clipper", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> RepeatEvents<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Canvas.Object, T>magic = null) where T : CoreUI.Canvas.Object {
            return new CoreUI.BindableProperty<bool>("repeat_events", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> KeyFocus<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Canvas.Object, T>magic = null) where T : CoreUI.Canvas.Object {
            return new CoreUI.BindableProperty<bool>("key_focus", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> PreciseIsInside<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Canvas.Object, T>magic = null) where T : CoreUI.Canvas.Object {
            return new CoreUI.BindableProperty<bool>("precise_is_inside", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> PropagateEvents<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Canvas.Object, T>magic = null) where T : CoreUI.Canvas.Object {
            return new CoreUI.BindableProperty<bool>("propagate_events", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> PassEvents<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Canvas.Object, T>magic = null) where T : CoreUI.Canvas.Object {
            return new CoreUI.BindableProperty<bool>("pass_events", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> AntiAlias<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Canvas.Object, T>magic = null) where T : CoreUI.Canvas.Object {
            return new CoreUI.BindableProperty<bool>("anti_alias", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.TextBidirectionalType> ParagraphDirection<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Canvas.Object, T>magic = null) where T : CoreUI.Canvas.Object {
            return new CoreUI.BindableProperty<CoreUI.TextBidirectionalType>("paragraph_direction", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> NoRender<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Canvas.Object, T>magic = null) where T : CoreUI.Canvas.Object {
            return new CoreUI.BindableProperty<bool>("no_render", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> AnimationPause<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Canvas.Object, T>magic = null) where T : CoreUI.Canvas.Object {
            return new CoreUI.BindableProperty<bool>("animation_pause", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<System.String> ColorCode<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Canvas.Object, T>magic = null) where T : CoreUI.Canvas.Object {
            return new CoreUI.BindableProperty<System.String>("color_code", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.DataTypes.Position2D> Position<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Canvas.Object, T>magic = null) where T : CoreUI.Canvas.Object {
            return new CoreUI.BindableProperty<CoreUI.DataTypes.Position2D>("position", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.DataTypes.Size2D> Size<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Canvas.Object, T>magic = null) where T : CoreUI.Canvas.Object {
            return new CoreUI.BindableProperty<CoreUI.DataTypes.Size2D>("size", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.DataTypes.Rect> Geometry<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Canvas.Object, T>magic = null) where T : CoreUI.Canvas.Object {
            return new CoreUI.BindableProperty<CoreUI.DataTypes.Rect>("geometry", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> Visible<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Canvas.Object, T>magic = null) where T : CoreUI.Canvas.Object {
            return new CoreUI.BindableProperty<bool>("visible", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> Scale<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Canvas.Object, T>magic = null) where T : CoreUI.Canvas.Object {
            return new CoreUI.BindableProperty<double>("scale", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.DataTypes.Size2D> HintSizeMax<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Canvas.Object, T>magic = null) where T : CoreUI.Canvas.Object {
            return new CoreUI.BindableProperty<CoreUI.DataTypes.Size2D>("hint_size_max", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.DataTypes.Size2D> HintSizeRestrictedMax<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Canvas.Object, T>magic = null) where T : CoreUI.Canvas.Object {
            return new CoreUI.BindableProperty<CoreUI.DataTypes.Size2D>("hint_size_restricted_max", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.DataTypes.Size2D> HintSizeMin<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Canvas.Object, T>magic = null) where T : CoreUI.Canvas.Object {
            return new CoreUI.BindableProperty<CoreUI.DataTypes.Size2D>("hint_size_min", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.DataTypes.Size2D> HintSizeRestrictedMin<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Canvas.Object, T>magic = null) where T : CoreUI.Canvas.Object {
            return new CoreUI.BindableProperty<CoreUI.DataTypes.Size2D>("hint_size_restricted_min", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<int> MappingPointCount<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Canvas.Object, T>magic = null) where T : CoreUI.Canvas.Object {
            return new CoreUI.BindableProperty<int>("mapping_point_count", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> MappingSmooth<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Canvas.Object, T>magic = null) where T : CoreUI.Canvas.Object {
            return new CoreUI.BindableProperty<bool>("mapping_smooth", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> MappingAlpha<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Canvas.Object, T>magic = null) where T : CoreUI.Canvas.Object {
            return new CoreUI.BindableProperty<bool>("mapping_alpha", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<short> Layer<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Canvas.Object, T>magic = null) where T : CoreUI.Canvas.Object {
            return new CoreUI.BindableProperty<short>("layer", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

namespace CoreUI {
    /// <summary>EFL event animator tick data structure</summary>
    /// <since_tizen> 6 </since_tizen>
    [StructLayout(LayoutKind.Sequential)]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public struct EventAnimatorTick : IEquatable<EventAnimatorTick>
    {
        
        private CoreUI.DataTypes.Rect updateArea;

        /// <summary>Area of the canvas that will be pushed to screen.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value>A rectangle in pixel dimensions.</value>
        public CoreUI.DataTypes.Rect UpdateArea { get => updateArea; }
        /// <summary>Constructor for EventAnimatorTick.
        /// </summary>
        /// <param name="updateArea">Area of the canvas that will be pushed to screen.</param>
        /// <since_tizen> 6 </since_tizen>
        public EventAnimatorTick(
            CoreUI.DataTypes.Rect updateArea = default(CoreUI.DataTypes.Rect))
        {
            this.updateArea = updateArea;
        }

        /// <summary>Unpacks EventAnimatorTick into tuple.
        /// <para>Since EFL 1.24.</para>
        /// </summary>
        public void Deconstruct(
            out CoreUI.DataTypes.Rect updateArea
        )
        {
            updateArea = this.UpdateArea;
        }
        /// <summary>Get a hash code for this item.
        /// </summary>
        public override int GetHashCode()
        {
            return UpdateArea.GetHashCode();
        }
        /// <summary>Equality comparison.
        /// </summary>
        public bool Equals(EventAnimatorTick other)
        {
            return UpdateArea == other.UpdateArea;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public override bool Equals(object other)
            => ((other is EventAnimatorTick) ? Equals((EventAnimatorTick)other) : false);
        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator ==(EventAnimatorTick lhs, EventAnimatorTick rhs)
            => lhs.Equals(rhs);        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator !=(EventAnimatorTick lhs, EventAnimatorTick rhs)
            => !lhs.Equals(rhs);        /// <summary>Implicit conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static implicit operator EventAnimatorTick(IntPtr ptr)
        {
            return (EventAnimatorTick)Marshal.PtrToStructure(ptr, typeof(EventAnimatorTick));
        }

        /// <summary>Conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static EventAnimatorTick FromIntPtr(IntPtr ptr)
        {
            return ptr;
        }

    }

}

