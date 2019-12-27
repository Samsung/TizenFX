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
    /// <summary>Event argument wrapper for event <see cref="CoreUI.UI.AlertPopup.ButtonClicked"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class AlertPopupButtonClickedEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Called when an Alert_Popup button was clicked.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.UI.AlertPopupButtonClickedEvent Arg { get; set; }
    }

    /// <summary>A variant of <see cref="CoreUI.UI.Popup"/> which uses a layout containing a content object and a variable number of buttons (up to 3 total).
    /// 
    /// An Alert_Popup is a popup which can be used when an application requires user interaction. It provides functionality for easily creating button objects on the popup and passing information about which button has been pressed to the button event callback.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.AlertPopup.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public class AlertPopup : CoreUI.UI.Popup
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(AlertPopup))
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
            efl_ui_alert_popup_class_get();

        /// <summary>Initializes a new instance of the <see cref="AlertPopup"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="CoreUI.UI.Widget.SetStyle" /></param>
        public AlertPopup(CoreUI.Object parent, System.String style = null) : base(efl_ui_alert_popup_class_get(), parent)
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
        protected AlertPopup(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="AlertPopup"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal AlertPopup(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="AlertPopup"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected AlertPopup(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }

        /// <summary>Called when an Alert_Popup button was clicked.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.AlertPopupButtonClickedEventArgs"/></value>
        public event EventHandler<CoreUI.UI.AlertPopupButtonClickedEventArgs> ButtonClicked
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.AlertPopupButtonClickedEventArgs{ Arg =  info });
                string key = "_EFL_UI_ALERT_POPUP_EVENT_BUTTON_CLICKED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_ALERT_POPUP_EVENT_BUTTON_CLICKED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event ButtonClicked.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnButtonClicked(CoreUI.UI.AlertPopupButtonClickedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.Arg));
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_ALERT_POPUP_EVENT_BUTTON_CLICKED", info, (p) => Marshal.FreeHGlobal(p));
        }


        /// <summary>The title text of Alert Popup.</summary>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.UI.AlertPopupPartTitle TitlePart
        {
            get
            {
                return GetPart("title") as CoreUI.UI.AlertPopupPartTitle;
            }
        }
        /// <summary>This property changes the text and icon for the specified button object.
        /// 
        /// When set, the Alert_Popup will create a button for the specified type if it does not yet exist. The button&apos;s content and text will be set using the passed values.
        /// 
        /// Exactly one button may exist for each <see cref="CoreUI.UI.AlertPopupButton"/> type. Repeated calls to set values for the same button type will overwrite previous values.
        /// 
        /// By default, no buttons are created. Once a button is added to the Popup using this property it cannot be removed.</summary>
        /// <param name="type">Alert_Popup button type.</param>
        /// <param name="text">Text of the specified button type.</param>
        /// <param name="icon">Visual to use as an icon for the specified button type.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetButton(CoreUI.UI.AlertPopupButton type, System.String text, CoreUI.Canvas.Object icon) {
            CoreUI.UI.AlertPopup.NativeMethods.efl_ui_alert_popup_button_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), type, text, icon);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.UI.AlertPopup.efl_ui_alert_popup_class_get();
        }

        /// <summary>Wrapper for native methods and virtual method delegates.
        /// For internal use by generated code only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new class NativeMethods : CoreUI.UI.Popup.NativeMethods
        {
            private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Elementary);

            /// <summary>Gets the list of Eo operations to override.
        /// </summary>
            /// <returns>The list of Eo operations to be overload.</returns>
            internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
            {
                var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
                var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

                if (efl_ui_alert_popup_button_set_static_delegate == null)
                {
                    efl_ui_alert_popup_button_set_static_delegate = new efl_ui_alert_popup_button_set_delegate(button_set);
                }

                if (methods.Contains("SetButton"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_alert_popup_button_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_alert_popup_button_set_static_delegate) });
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
                return CoreUI.UI.AlertPopup.efl_ui_alert_popup_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            
            private delegate void efl_ui_alert_popup_button_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.UI.AlertPopupButton type, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String text, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Canvas.Object icon);

            
            internal delegate void efl_ui_alert_popup_button_set_api_delegate(System.IntPtr obj,  CoreUI.UI.AlertPopupButton type, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String text, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Canvas.Object icon);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_alert_popup_button_set_api_delegate> efl_ui_alert_popup_button_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_alert_popup_button_set_api_delegate>(Module, "efl_ui_alert_popup_button_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void button_set(System.IntPtr obj, System.IntPtr pd, CoreUI.UI.AlertPopupButton type, System.String text, CoreUI.Canvas.Object icon)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_alert_popup_button_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((AlertPopup)ws.Target).SetButton(type, text, icon);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_alert_popup_button_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), type, text, icon);
                }
            }

            private static efl_ui_alert_popup_button_set_delegate efl_ui_alert_popup_button_set_static_delegate;

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

namespace CoreUI.UI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class AlertPopupExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindablePart<CoreUI.UI.AlertPopupPartTitle> TitlePart<T>(this CoreUI.UI.IGenericFactoryPartExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.AlertPopup, T> x=null) where T : CoreUI.UI.AlertPopup
        {
            return new CoreUI.BindablePart<CoreUI.UI.AlertPopupPartTitle>("title", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

namespace CoreUI.UI {
    /// <summary>Defines the type of the alert button.</summary>
    /// <since_tizen> 6 </since_tizen>
    
    [CoreUI.Wrapper.BindingEntity]
    public enum AlertPopupButton
    {
        /// <summary>Button having positive meaning. E.g. &quot;Yes&quot;.</summary>
        /// <since_tizen> 6 </since_tizen>
        Positive = 0,
        /// <summary>Button having negative meaning. E.g. &quot;No&quot;.</summary>
        /// <since_tizen> 6 </since_tizen>
        Negative = 1,
        /// <summary>Button having user-defined meaning. E.g. &quot;More information&quot;.</summary>
        /// <since_tizen> 6 </since_tizen>
        User = 2,
    }
}

namespace CoreUI.UI {
    /// <summary>Information for <see cref="CoreUI.UI.AlertPopup.ButtonClicked"/> event.</summary>
    /// <since_tizen> 6 </since_tizen>
    [StructLayout(LayoutKind.Sequential)]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public struct AlertPopupButtonClickedEvent : IEquatable<AlertPopupButtonClickedEvent>
    {
        
        private CoreUI.UI.AlertPopupButton buttonType;

        /// <summary>Clicked button type.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value>Defines the type of the alert button.</value>
        public CoreUI.UI.AlertPopupButton ButtonType { get => buttonType; }
        /// <summary>Constructor for AlertPopupButtonClickedEvent.
        /// </summary>
        /// <param name="buttonType">Clicked button type.</param>
        /// <since_tizen> 6 </since_tizen>
        public AlertPopupButtonClickedEvent(
            CoreUI.UI.AlertPopupButton buttonType = default(CoreUI.UI.AlertPopupButton))
        {
            this.buttonType = buttonType;
        }

        /// <summary>Unpacks AlertPopupButtonClickedEvent into tuple.
        /// <para>Since EFL 1.24.</para>
        /// </summary>
        public void Deconstruct(
            out CoreUI.UI.AlertPopupButton buttonType
        )
        {
            buttonType = this.ButtonType;
        }
        /// <summary>Get a hash code for this item.
        /// </summary>
        public override int GetHashCode()
        {
            return ButtonType.GetHashCode();
        }
        /// <summary>Equality comparison.
        /// </summary>
        public bool Equals(AlertPopupButtonClickedEvent other)
        {
            return ButtonType == other.ButtonType;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public override bool Equals(object other)
            => ((other is AlertPopupButtonClickedEvent) ? Equals((AlertPopupButtonClickedEvent)other) : false);
        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator ==(AlertPopupButtonClickedEvent lhs, AlertPopupButtonClickedEvent rhs)
            => lhs.Equals(rhs);        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator !=(AlertPopupButtonClickedEvent lhs, AlertPopupButtonClickedEvent rhs)
            => !lhs.Equals(rhs);        /// <summary>Implicit conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static implicit operator AlertPopupButtonClickedEvent(IntPtr ptr)
        {
            return (AlertPopupButtonClickedEvent)Marshal.PtrToStructure(ptr, typeof(AlertPopupButtonClickedEvent));
        }

        /// <summary>Conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static AlertPopupButtonClickedEvent FromIntPtr(IntPtr ptr)
        {
            return ptr;
        }

    }

}

