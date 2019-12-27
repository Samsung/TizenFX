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
    /// <summary>Object with the default implementation for <see cref="CoreUI.UI.IRadioGroup"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.RadioGroupImpl.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public class RadioGroupImpl : CoreUI.Object, CoreUI.UI.IRadioGroup, CoreUI.UI.ISingleSelectable
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(RadioGroupImpl))
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
            efl_ui_radio_group_impl_class_get();

        /// <summary>Initializes a new instance of the <see cref="RadioGroupImpl"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
        public RadioGroupImpl(CoreUI.Object parent= null) : base(efl_ui_radio_group_impl_class_get(), parent)
        {
            FinishInstantiation();
        }

        /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
        /// Do not call this constructor directly.
        /// </summary>
        /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
        protected RadioGroupImpl(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="RadioGroupImpl"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal RadioGroupImpl(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="RadioGroupImpl"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected RadioGroupImpl(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }


        /// <summary>Emitted each time the <c>selected_value</c> changes. The event information contains the <see cref="CoreUI.UI.Radio.StateValue"/> of the newly selected button or -1 if no button is now selected.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.RadioGroupValueChangedEventArgs"/></value>
        public event EventHandler<CoreUI.UI.RadioGroupValueChangedEventArgs> ValueChanged
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.RadioGroupValueChangedEventArgs{ Arg = Marshal.ReadInt32(info) });
                string key = "_EFL_UI_RADIO_GROUP_EVENT_VALUE_CHANGED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_RADIO_GROUP_EVENT_VALUE_CHANGED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event ValueChanged.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnValueChanged(CoreUI.UI.RadioGroupValueChangedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = CoreUI.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(e.Arg);
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_RADIO_GROUP_EVENT_VALUE_CHANGED", info, (p) => Marshal.FreeHGlobal(p));
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

        /// <summary>The value associated with the currently selected button in the group. Give each radio button in the group a different value using <see cref="CoreUI.UI.Radio.StateValue"/>.
        /// 
        /// A value of -1 means that no button is selected. Only values associated with the buttons in the group (and -1) can be used.</summary>
        /// <returns>The value of the currently selected radio button, or -1.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual int GetSelectedValue() {
            var _ret_var = CoreUI.UI.IRadioGroupNativeMethods.efl_ui_radio_group_selected_value_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The value associated with the currently selected button in the group. Give each radio button in the group a different value using <see cref="CoreUI.UI.Radio.StateValue"/>.
        /// 
        /// A value of -1 means that no button is selected. Only values associated with the buttons in the group (and -1) can be used.</summary>
        /// <param name="selected_value">The value of the currently selected radio button, or -1.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetSelectedValue(int selected_value) {
            CoreUI.UI.IRadioGroupNativeMethods.efl_ui_radio_group_selected_value_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), selected_value);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Register a new <see cref="CoreUI.UI.Radio"/> button to this group. Keep in mind that registering to a group will only handle button grouping, you still need to add the button to a layout for it to be rendered.
        /// 
        /// If the <see cref="CoreUI.UI.Radio.StateValue"/> of the new button is already used by a previous button in the group, the button will not be added.
        /// 
        /// See also <see cref="CoreUI.UI.IRadioGroup.Unregister"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="radio">The radio button to add to the group.</param>
        public virtual void Register(CoreUI.UI.Radio radio) {
            CoreUI.UI.IRadioGroupNativeMethods.efl_ui_radio_group_register_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), radio);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Unregister an <see cref="CoreUI.UI.Radio"/> button from this group. This will unlink the behavior of this button from the other buttons in the group, but if it still belongs to a layout, it will still be rendered.
        /// 
        /// If the button was not registered in the group the call is ignored. If the button was selected, no button will be selected in the group after this call.
        /// 
        /// See also <see cref="CoreUI.UI.IRadioGroup.Register"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="radio">The radio button to remove from the group.</param>
        public virtual void Unregister(CoreUI.UI.Radio radio) {
            CoreUI.UI.IRadioGroupNativeMethods.efl_ui_radio_group_unregister_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), radio);
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

        /// <summary>The value associated with the currently selected button in the group. Give each radio button in the group a different value using <see cref="CoreUI.UI.Radio.StateValue"/>.
        /// 
        /// A value of -1 means that no button is selected. Only values associated with the buttons in the group (and -1) can be used.</summary>
        /// <value>The value of the currently selected radio button, or -1.</value>
        /// <since_tizen> 6 </since_tizen>
        public int SelectedValue {
            get { return GetSelectedValue(); }
            set { SetSelectedValue(value); }
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
            return CoreUI.UI.RadioGroupImpl.efl_ui_radio_group_impl_class_get();
        }

        /// <summary>Wrapper for native methods and virtual method delegates.
        /// For internal use by generated code only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new class NativeMethods : CoreUI.Object.NativeMethods
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
                return CoreUI.UI.RadioGroupImpl.efl_ui_radio_group_impl_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

namespace CoreUI.UI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class RadioGroupImplExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<int> SelectedValue<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.RadioGroupImpl, T>magic = null) where T : CoreUI.UI.RadioGroupImpl {
            return new CoreUI.BindableProperty<int>("selected_value", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.UI.ISelectable> FallbackSelection<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.RadioGroupImpl, T>magic = null) where T : CoreUI.UI.RadioGroupImpl {
            return new CoreUI.BindableProperty<CoreUI.UI.ISelectable>("fallback_selection", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> AllowManualDeselection<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.RadioGroupImpl, T>magic = null) where T : CoreUI.UI.RadioGroupImpl {
            return new CoreUI.BindableProperty<bool>("allow_manual_deselection", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

