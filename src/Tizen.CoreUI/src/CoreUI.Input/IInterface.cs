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
namespace CoreUI.Input {
    /// <summary>An object implementing this interface can send pointer events.
    /// 
    /// Windows and canvas objects may send input events.
    /// 
    /// A &quot;pointer&quot; refers to the main pointing device, which could be a mouse, trackpad, finger, pen, etc... In other words, the finger id in any pointer event will always be 0.
    /// 
    /// A &quot;finger&quot; refers to a single point of input, usually in an absolute coordinates input device, and that can support more than one input position at at time (think multi-touch screens). The first finger (id 0) is sent along with a pointer event, so be careful to not handle those events twice. Note that if the input device can support &quot;hovering&quot;, it is entirely possible to receive move events without down coming first.
    /// 
    /// A &quot;key&quot; is a key press from a keyboard or equivalent type of input device. Long, repeated, key presses will always happen like this: down...up,down...up,down...up (not down...up or down...down...down...up).</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Input.IInterfaceNativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface IInterface : 
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>Main pointer move (current and previous positions are known).</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.InterfacePointerMoveEventArgs"/></value>
        event EventHandler<CoreUI.Input.InterfacePointerMoveEventArgs> PointerMove;
        /// <summary>Main pointer button pressed (button id is known).</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.InterfacePointerDownEventArgs"/></value>
        event EventHandler<CoreUI.Input.InterfacePointerDownEventArgs> PointerDown;
        /// <summary>Main pointer button released (button id is known).</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.InterfacePointerUpEventArgs"/></value>
        event EventHandler<CoreUI.Input.InterfacePointerUpEventArgs> PointerUp;
        /// <summary>Main pointer button press was cancelled (button id is known). This can happen in rare cases when the window manager passes the focus to a more urgent window, for instance. You probably don&apos;t need to listen to this event, as it will be accompanied by an up event.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.InterfacePointerCancelEventArgs"/></value>
        event EventHandler<CoreUI.Input.InterfacePointerCancelEventArgs> PointerCancel;
        /// <summary>Pointer entered a window or a widget.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.InterfacePointerInEventArgs"/></value>
        event EventHandler<CoreUI.Input.InterfacePointerInEventArgs> PointerIn;
        /// <summary>Pointer left a window or a widget.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.InterfacePointerOutEventArgs"/></value>
        event EventHandler<CoreUI.Input.InterfacePointerOutEventArgs> PointerOut;
        /// <summary>Mouse wheel event.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.InterfacePointerWheelEventArgs"/></value>
        event EventHandler<CoreUI.Input.InterfacePointerWheelEventArgs> PointerWheel;
        /// <summary>Pen or other axis event update.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.InterfacePointerAxisEventArgs"/></value>
        event EventHandler<CoreUI.Input.InterfacePointerAxisEventArgs> PointerAxis;
        /// <summary>Finger moved (current and previous positions are known).</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.InterfaceFingerMoveEventArgs"/></value>
        event EventHandler<CoreUI.Input.InterfaceFingerMoveEventArgs> FingerMove;
        /// <summary>Finger pressed (finger id is known).</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.InterfaceFingerDownEventArgs"/></value>
        event EventHandler<CoreUI.Input.InterfaceFingerDownEventArgs> FingerDown;
        /// <summary>Finger released (finger id is known).</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.InterfaceFingerUpEventArgs"/></value>
        event EventHandler<CoreUI.Input.InterfaceFingerUpEventArgs> FingerUp;
        /// <summary>Keyboard key press.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.InterfaceKeyDownEventArgs"/></value>
        event EventHandler<CoreUI.Input.InterfaceKeyDownEventArgs> KeyDown;
        /// <summary>Keyboard key release.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.InterfaceKeyUpEventArgs"/></value>
        event EventHandler<CoreUI.Input.InterfaceKeyUpEventArgs> KeyUp;
        /// <summary>All input events are on hold or resumed.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.InterfaceHoldEventArgs"/></value>
        event EventHandler<CoreUI.Input.InterfaceHoldEventArgs> Hold;
        /// <summary>A focus in event.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.InterfaceFocusInEventArgs"/></value>
        event EventHandler<CoreUI.Input.InterfaceFocusInEventArgs> FocusIn;
        /// <summary>A focus out event.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.InterfaceFocusOutEventArgs"/></value>
        event EventHandler<CoreUI.Input.InterfaceFocusOutEventArgs> FocusOut;
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IInterface.PointerMove"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class InterfacePointerMoveEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Main pointer move (current and previous positions are known).</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Input.Pointer Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IInterface.PointerDown"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class InterfacePointerDownEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Main pointer button pressed (button id is known).</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Input.Pointer Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IInterface.PointerUp"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class InterfacePointerUpEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Main pointer button released (button id is known).</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Input.Pointer Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IInterface.PointerCancel"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class InterfacePointerCancelEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Main pointer button press was cancelled (button id is known). This can happen in rare cases when the window manager passes the focus to a more urgent window, for instance. You probably don&apos;t need to listen to this event, as it will be accompanied by an up event.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Input.Pointer Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IInterface.PointerIn"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class InterfacePointerInEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Pointer entered a window or a widget.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Input.Pointer Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IInterface.PointerOut"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class InterfacePointerOutEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Pointer left a window or a widget.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Input.Pointer Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IInterface.PointerWheel"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class InterfacePointerWheelEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Mouse wheel event.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Input.Pointer Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IInterface.PointerAxis"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class InterfacePointerAxisEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Pen or other axis event update.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Input.Pointer Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IInterface.FingerMove"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class InterfaceFingerMoveEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Finger moved (current and previous positions are known).</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Input.Pointer Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IInterface.FingerDown"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class InterfaceFingerDownEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Finger pressed (finger id is known).</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Input.Pointer Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IInterface.FingerUp"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class InterfaceFingerUpEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Finger released (finger id is known).</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Input.Pointer Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IInterface.KeyDown"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class InterfaceKeyDownEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Keyboard key press.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Input.Key Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IInterface.KeyUp"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class InterfaceKeyUpEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Keyboard key release.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Input.Key Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IInterface.Hold"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class InterfaceHoldEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>All input events are on hold or resumed.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Input.Hold Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IInterface.FocusIn"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class InterfaceFocusInEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>A focus in event.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Input.Focus Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IInterface.FocusOut"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class InterfaceFocusOutEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>A focus out event.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Input.Focus Arg { get; set; }
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IInterfaceNativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Evas)] internal static extern System.IntPtr
            efl_input_interface_interface_get();
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
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.
        /// </summary>
        /// <returns>The native class pointer.</returns>
        internal override IntPtr GetCoreUIClass()
        {
            return efl_input_interface_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

