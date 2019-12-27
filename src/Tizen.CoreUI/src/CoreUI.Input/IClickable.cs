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
    /// <summary>CoreUI input clickable interface.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Input.IClickableNativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface IClickable : 
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>This returns true if the given object is currently in event emission</summary>
        /// <since_tizen> 6 </since_tizen>
        bool GetInteraction();

        /// <summary>Called when object is in sequence pressed and unpressed by the primary button</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.ClickableClickedEventArgs"/></value>
        event EventHandler<CoreUI.Input.ClickableClickedEventArgs> Clicked;
        /// <summary>Called when object is in sequence pressed and unpressed by any button. The button that triggered the event can be found in the event information.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.ClickableClickedAnyEventArgs"/></value>
        event EventHandler<CoreUI.Input.ClickableClickedAnyEventArgs> ClickedAny;
        /// <summary>Called when the object is pressed, event_info is the button that got pressed</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.ClickablePressedEventArgs"/></value>
        event EventHandler<CoreUI.Input.ClickablePressedEventArgs> Pressed;
        /// <summary>Called when the object is no longer pressed, event_info is the button that got pressed</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.ClickableUnpressedEventArgs"/></value>
        event EventHandler<CoreUI.Input.ClickableUnpressedEventArgs> Unpressed;
        /// <summary>Called when the object receives a long press, event_info is the button that got pressed</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.ClickableLongpressedEventArgs"/></value>
        event EventHandler<CoreUI.Input.ClickableLongpressedEventArgs> Longpressed;
        /// <summary>This returns true if the given object is currently in event emission</summary>
        /// <since_tizen> 6 </since_tizen>
        bool Interaction {
            get;
        }

    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IClickable.Clicked"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class ClickableClickedEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Called when object is in sequence pressed and unpressed by the primary button</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Input.ClickableClicked Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IClickable.ClickedAny"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class ClickableClickedAnyEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Called when object is in sequence pressed and unpressed by any button. The button that triggered the event can be found in the event information.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Input.ClickableClicked Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IClickable.Pressed"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class ClickablePressedEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Called when the object is pressed, event_info is the button that got pressed</value>
        /// <since_tizen> 6 </since_tizen>
        public int Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IClickable.Unpressed"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class ClickableUnpressedEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Called when the object is no longer pressed, event_info is the button that got pressed</value>
        /// <since_tizen> 6 </since_tizen>
        public int Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.Input.IClickable.Longpressed"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class ClickableLongpressedEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Called when the object receives a long press, event_info is the button that got pressed</value>
        /// <since_tizen> 6 </since_tizen>
        public int Arg { get; set; }
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IClickableNativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Evas)] internal static extern System.IntPtr
            efl_input_clickable_mixin_get();
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Evas);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_input_clickable_interaction_get_static_delegate == null)
            {
                efl_input_clickable_interaction_get_static_delegate = new efl_input_clickable_interaction_get_delegate(interaction_get);
            }

            if (methods.Contains("GetInteraction"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_clickable_interaction_get"), func = Marshal.GetFunctionPointerForDelegate(efl_input_clickable_interaction_get_static_delegate) });
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
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.
        /// </summary>
        /// <returns>The native class pointer.</returns>
        internal override IntPtr GetCoreUIClass()
        {
            return efl_input_clickable_mixin_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_input_clickable_interaction_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_input_clickable_interaction_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_clickable_interaction_get_api_delegate> efl_input_clickable_interaction_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_clickable_interaction_get_api_delegate>(Module, "efl_input_clickable_interaction_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool interaction_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_input_clickable_interaction_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IClickable)ws.Target).GetInteraction();
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
                return efl_input_clickable_interaction_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_input_clickable_interaction_get_delegate efl_input_clickable_interaction_get_static_delegate;

        
        private delegate void efl_input_clickable_press_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

        
        internal delegate void efl_input_clickable_press_api_delegate(System.IntPtr obj,  uint button);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_clickable_press_api_delegate> efl_input_clickable_press_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_clickable_press_api_delegate>(Module, "efl_input_clickable_press");

        
        private delegate void efl_input_clickable_unpress_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

        
        internal delegate void efl_input_clickable_unpress_api_delegate(System.IntPtr obj,  uint button);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_clickable_unpress_api_delegate> efl_input_clickable_unpress_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_clickable_unpress_api_delegate>(Module, "efl_input_clickable_unpress");

        
        private delegate void efl_input_clickable_button_state_reset_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

        
        internal delegate void efl_input_clickable_button_state_reset_api_delegate(System.IntPtr obj,  uint button);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_clickable_button_state_reset_api_delegate> efl_input_clickable_button_state_reset_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_clickable_button_state_reset_api_delegate>(Module, "efl_input_clickable_button_state_reset");

        
        private delegate void efl_input_clickable_longpress_abort_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

        
        internal delegate void efl_input_clickable_longpress_abort_api_delegate(System.IntPtr obj,  uint button);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_clickable_longpress_abort_api_delegate> efl_input_clickable_longpress_abort_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_clickable_longpress_abort_api_delegate>(Module, "efl_input_clickable_longpress_abort");

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

namespace CoreUI.Input {
    /// <summary>A struct that expresses a click in elementary.</summary>
    /// <since_tizen> 6 </since_tizen>
    [StructLayout(LayoutKind.Sequential)]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public struct ClickableClicked : IEquatable<ClickableClicked>
    {
        
        private uint repeated;
        
        private uint button;

        /// <summary>The amount of how often the clicked event was repeated in a certain amount of time</summary>
        /// <since_tizen> 6 </since_tizen>
        public uint Repeated { get => repeated; }
        /// <summary>The Button that is pressed</summary>
        /// <since_tizen> 6 </since_tizen>
        public uint Button { get => button; }
        /// <summary>Constructor for ClickableClicked.
        /// </summary>
        /// <param name="repeated">The amount of how often the clicked event was repeated in a certain amount of time</param>
        /// <param name="button">The Button that is pressed</param>
        /// <since_tizen> 6 </since_tizen>
        public ClickableClicked(
            uint repeated = default(uint),
            uint button = default(uint))
        {
            this.repeated = repeated;
            this.button = button;
        }

        /// <summary>Packs tuple into ClickableClicked object.
        ///<para>Since EFL 1.24.</para>
        ///</summary>
        public static implicit operator ClickableClicked((uint repeated, uint button) tuple)
            => new ClickableClicked(tuple.repeated, tuple.button);

        /// <summary>Unpacks ClickableClicked into tuple.
        /// <para>Since EFL 1.24.</para>
        /// </summary>
        public void Deconstruct(
            out uint repeated,
            out uint button
        )
        {
            repeated = this.Repeated;
            button = this.Button;
        }
        /// <summary>Get a hash code for this item.
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + Repeated.GetHashCode();
            hash = hash * 23 + Button.GetHashCode();
            return hash;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public bool Equals(ClickableClicked other)
        {
            return Repeated == other.Repeated && Button == other.Button;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public override bool Equals(object other)
            => ((other is ClickableClicked) ? Equals((ClickableClicked)other) : false);
        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator ==(ClickableClicked lhs, ClickableClicked rhs)
            => lhs.Equals(rhs);        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator !=(ClickableClicked lhs, ClickableClicked rhs)
            => !lhs.Equals(rhs);        /// <summary>Implicit conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static implicit operator ClickableClicked(IntPtr ptr)
        {
            return (ClickableClicked)Marshal.PtrToStructure(ptr, typeof(ClickableClicked));
        }

        /// <summary>Conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static ClickableClicked FromIntPtr(IntPtr ptr)
        {
            return ptr;
        }

    }

}

