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
    /// <summary>This is the base class for all &quot;Part&quot; handles in CoreUI.UI widgets.
    /// 
    /// Since objects of this type are returned by CoreUI.Part.part_get, their lifetime is limited to exactly one function call only. Each widget class should expose more specific types for their API-defined parts.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.WidgetPart.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public class WidgetPart : CoreUI.Object, CoreUI.UI.IPropertyBind
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(WidgetPart))
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
            efl_ui_widget_part_class_get();

        /// <summary>Initializes a new instance of the <see cref="WidgetPart"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
        public WidgetPart(CoreUI.Object parent= null) : base(efl_ui_widget_part_class_get(), parent)
        {
            FinishInstantiation();
        }

        /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
        /// Do not call this constructor directly.
        /// </summary>
        /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
        protected WidgetPart(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="WidgetPart"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal WidgetPart(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="WidgetPart"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected WidgetPart(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }


        /// <summary>Event dispatched when a property on the object has changed due to a user interaction on the object that a model could be interested in.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.PropertyBindPropertiesChangedEventArgs"/></value>
        public event EventHandler<CoreUI.UI.PropertyBindPropertiesChangedEventArgs> PropertiesChanged
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.PropertyBindPropertiesChangedEventArgs{ Arg =  info });
                string key = "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTIES_CHANGED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTIES_CHANGED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event PropertiesChanged.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnPropertiesChanged(CoreUI.UI.PropertyBindPropertiesChangedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.Arg));
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTIES_CHANGED", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Event dispatched when a property on the object is bound to a model. This is useful to avoid generating too many events.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.PropertyBindPropertyBoundEventArgs"/></value>
        public event EventHandler<CoreUI.UI.PropertyBindPropertyBoundEventArgs> PropertyBound
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.PropertyBindPropertyBoundEventArgs{ Arg = CoreUI.DataTypes.StringConversion.NativeUtf8ToManagedString(info) });
                string key = "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTY_BOUND";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTY_BOUND";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event PropertyBound.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnPropertyBound(CoreUI.UI.PropertyBindPropertyBoundEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = CoreUI.DataTypes.StringConversion.ManagedStringToNativeUtf8Alloc(e.Arg);
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_PROPERTY_BIND_EVENT_PROPERTY_BOUND", info, (p) => CoreUI.DataTypes.MemoryNative.Free(p));
        }

        /// <summary>bind property data with the given key string. when the data is ready or changed, bind the data to the key action and process promised work.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="key">key string for bind model property data</param>
        /// <param name="property">Model property name</param>
        /// <returns>0 when it succeed, an error code otherwise.</returns>
        public virtual CoreUI.DataTypes.Error BindProperty(System.String key, System.String property) {
            var _ret_var = CoreUI.UI.IPropertyBindNativeMethods.efl_ui_property_bind_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), key, property);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.UI.WidgetPart.efl_ui_widget_part_class_get();
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
                return CoreUI.UI.WidgetPart.efl_ui_widget_part_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

