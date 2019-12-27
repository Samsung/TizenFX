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
    /// <summary>CoreUI model providing helpers for custom properties used when linking a model to a view and you need to generate/adapt values for display.
    /// 
    /// There is two ways to use this class, you can either inherit from it and have a custom constructor for example. Or you can just instantiate it and manually define your property on it via callbacks.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.ViewModel.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public class ViewModel : CoreUI.CompositeModel
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(ViewModel))
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
            efl_ui_view_model_class_get();

        /// <summary>Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
    /// <param name="model">Model that is/will be See <see cref="CoreUI.UI.IView.SetModel" /></param>
    /// <param name="childrenBind">Define if we will intercept all children object reference and bind them through the ViewModel with the same property logic as this one. Be careful of recursivity. See <see cref="CoreUI.UI.ViewModel.SetChildrenBind" /></param>
    /// <param name="index">Position of this object in the parent model. See <see cref="CoreUI.CompositeModel.SetIndex" /></param>
        public ViewModel(CoreUI.Object parent, CoreUI.IModel model, bool? childrenBind = null, uint? index = null) : base(efl_ui_view_model_class_get(), parent)
        {
            if (CoreUI.Wrapper.Globals.ParamHelperCheck(model))
            {
                SetModel(CoreUI.Wrapper.Globals.GetParamHelper(model));
            }

            if (CoreUI.Wrapper.Globals.ParamHelperCheck(childrenBind))
            {
                SetChildrenBind(CoreUI.Wrapper.Globals.GetParamHelper(childrenBind));
            }

            if (CoreUI.Wrapper.Globals.ParamHelperCheck(index))
            {
                SetIndex(CoreUI.Wrapper.Globals.GetParamHelper(index));
            }

            FinishInstantiation();
        }

        /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
        /// Do not call this constructor directly.
        /// </summary>
        /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
        protected ViewModel(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ViewModel"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal ViewModel(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ViewModel"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected ViewModel(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }


        /// <summary>Define if we will intercept all children object reference and bind them through the ViewModel with the same property logic as this one. Be careful of recursivity.
        /// 
        /// This can only be applied at construction time.</summary>
        /// <returns>Do you automatically bind children. Default to true.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetChildrenBind() {
            var _ret_var = CoreUI.UI.ViewModel.NativeMethods.efl_ui_view_model_children_bind_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Define if we will intercept all children object reference and bind them through the ViewModel with the same property logic as this one. Be careful of recursivity.
        /// 
        /// This can only be applied at construction time.</summary>
        /// <param name="enable">Do you automatically bind children. Default to true.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetChildrenBind(bool enable) {
            CoreUI.UI.ViewModel.NativeMethods.efl_ui_view_model_children_bind_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), enable);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Adds a synthetic string property, generated from a <c>definition</c> string and other properties in the model.
        /// 
        /// The <c>definition</c> string, similar to how <c>printf</c> works, contains ${} placeholders that are replaced by the actual value of the property inside the placeholder tags when the synthetic property is retrieved. For example, a numeric property <c>length</c> might be strange to use as a label, since it will only display a number. However, a synthetic string can be generated with the definition &quot;Length ${length}.&quot; which renders more nicely and does not require any more code by the user of the property.
        /// 
        /// <c>not_ready</c> and <c>on_error</c> strings can be given to be used when the data is not ready or there is some error, respectively. These strings do accept placeholder tags.
        /// 
        /// See <see cref="CoreUI.UI.ViewModel.DelPropertyString"/></summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="name">The name for the new synthetic property.</param>
        /// <param name="definition">The definition string for the new synthetic property.</param>
        /// <param name="not_ready">The text to be used if any of the properties used in <c>definition</c> is not ready yet. If set to <c>null</c>, no check against EAGAIN will be done.</param>
        /// <param name="on_error">The text to be used if any of the properties used in <c>definition</c> is in error. It takes precedence over <c>not_ready</c>. If set to <c>null</c>, no error checks are performed.</param>
        public virtual CoreUI.DataTypes.Error AddPropertyString(System.String name, System.String definition, System.String not_ready, System.String on_error) {
            var _ret_var = CoreUI.UI.ViewModel.NativeMethods.efl_ui_view_model_property_string_add_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), name, definition, not_ready, on_error);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Delete a synthetic property previously defined by <see cref="CoreUI.UI.ViewModel.AddPropertyString"/>.
        /// 
        /// See <see cref="CoreUI.UI.ViewModel.AddPropertyString"/></summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="name">The name of the synthetic property to delete.</param>
        public virtual CoreUI.DataTypes.Error DelPropertyString(System.String name) {
            var _ret_var = CoreUI.UI.ViewModel.NativeMethods.efl_ui_view_model_property_string_del_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), name);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Automatically update the field for the event <see cref="CoreUI.IModel.PropertiesChanged"/> to include property that are impacted with change in a property from the composited model.
        /// 
        /// The source doesn&apos;t have to be provided at this point by the composited model.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="source">Property name in the composited model.</param>
        /// <param name="destination">Property name in the <see cref="CoreUI.UI.ViewModel"/></param>
        public virtual void BindProperty(System.String source, System.String destination) {
            CoreUI.UI.ViewModel.NativeMethods.efl_ui_view_model_property_bind_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), source, destination);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Stop automatically updating the field for the event <see cref="CoreUI.IModel.PropertiesChanged"/> to include property that are impacted with change in a property from the composited model.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="source">Property name in the composited model.</param>
        /// <param name="destination">Property name in the <see cref="CoreUI.UI.ViewModel"/></param>
        public virtual void UnbindProperty(System.String source, System.String destination) {
            CoreUI.UI.ViewModel.NativeMethods.efl_ui_view_model_property_unbind_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), source, destination);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Define if we will intercept all children object reference and bind them through the ViewModel with the same property logic as this one. Be careful of recursivity.
        /// 
        /// This can only be applied at construction time.</summary>
        /// <value>Do you automatically bind children. Default to true.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool ChildrenBind {
            get { return GetChildrenBind(); }
            set { SetChildrenBind(value); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.UI.ViewModel.efl_ui_view_model_class_get();
        }

        /// <summary>Wrapper for native methods and virtual method delegates.
        /// For internal use by generated code only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new class NativeMethods : CoreUI.CompositeModel.NativeMethods
        {
            private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Elementary);

            /// <summary>Gets the list of Eo operations to override.
        /// </summary>
            /// <returns>The list of Eo operations to be overload.</returns>
            internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
            {
                var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
                var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

                if (efl_ui_view_model_children_bind_get_static_delegate == null)
                {
                    efl_ui_view_model_children_bind_get_static_delegate = new efl_ui_view_model_children_bind_get_delegate(children_bind_get);
                }

                if (methods.Contains("GetChildrenBind"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_view_model_children_bind_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_view_model_children_bind_get_static_delegate) });
                }

                if (efl_ui_view_model_children_bind_set_static_delegate == null)
                {
                    efl_ui_view_model_children_bind_set_static_delegate = new efl_ui_view_model_children_bind_set_delegate(children_bind_set);
                }

                if (methods.Contains("SetChildrenBind"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_view_model_children_bind_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_view_model_children_bind_set_static_delegate) });
                }

                if (efl_ui_view_model_property_string_add_static_delegate == null)
                {
                    efl_ui_view_model_property_string_add_static_delegate = new efl_ui_view_model_property_string_add_delegate(property_string_add);
                }

                if (methods.Contains("AddPropertyString"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_view_model_property_string_add"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_view_model_property_string_add_static_delegate) });
                }

                if (efl_ui_view_model_property_string_del_static_delegate == null)
                {
                    efl_ui_view_model_property_string_del_static_delegate = new efl_ui_view_model_property_string_del_delegate(property_string_del);
                }

                if (methods.Contains("DelPropertyString"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_view_model_property_string_del"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_view_model_property_string_del_static_delegate) });
                }

                if (efl_ui_view_model_property_bind_static_delegate == null)
                {
                    efl_ui_view_model_property_bind_static_delegate = new efl_ui_view_model_property_bind_delegate(property_bind);
                }

                if (methods.Contains("BindProperty"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_view_model_property_bind"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_view_model_property_bind_static_delegate) });
                }

                if (efl_ui_view_model_property_unbind_static_delegate == null)
                {
                    efl_ui_view_model_property_unbind_static_delegate = new efl_ui_view_model_property_unbind_delegate(property_unbind);
                }

                if (methods.Contains("UnbindProperty"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_view_model_property_unbind"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_view_model_property_unbind_static_delegate) });
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
                return CoreUI.UI.ViewModel.efl_ui_view_model_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_ui_view_model_children_bind_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_ui_view_model_children_bind_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_view_model_children_bind_get_api_delegate> efl_ui_view_model_children_bind_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_view_model_children_bind_get_api_delegate>(Module, "efl_ui_view_model_children_bind_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool children_bind_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_view_model_children_bind_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((ViewModel)ws.Target).GetChildrenBind();
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
                    return efl_ui_view_model_children_bind_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_view_model_children_bind_get_delegate efl_ui_view_model_children_bind_get_static_delegate;

            
            private delegate void efl_ui_view_model_children_bind_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool enable);

            
            internal delegate void efl_ui_view_model_children_bind_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool enable);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_view_model_children_bind_set_api_delegate> efl_ui_view_model_children_bind_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_view_model_children_bind_set_api_delegate>(Module, "efl_ui_view_model_children_bind_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void children_bind_set(System.IntPtr obj, System.IntPtr pd, bool enable)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_view_model_children_bind_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((ViewModel)ws.Target).SetChildrenBind(enable);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_view_model_children_bind_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), enable);
                }
            }

            private static efl_ui_view_model_children_bind_set_delegate efl_ui_view_model_children_bind_set_static_delegate;

            
            private delegate CoreUI.DataTypes.Error efl_ui_view_model_property_string_add_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String definition, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String not_ready, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String on_error);

            
            internal delegate CoreUI.DataTypes.Error efl_ui_view_model_property_string_add_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String definition, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String not_ready, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String on_error);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_view_model_property_string_add_api_delegate> efl_ui_view_model_property_string_add_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_view_model_property_string_add_api_delegate>(Module, "efl_ui_view_model_property_string_add");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.DataTypes.Error property_string_add(System.IntPtr obj, System.IntPtr pd, System.String name, System.String definition, System.String not_ready, System.String on_error)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_view_model_property_string_add was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.DataTypes.Error _ret_var = default(CoreUI.DataTypes.Error);
                    try
                    {
                        _ret_var = ((ViewModel)ws.Target).AddPropertyString(name, definition, not_ready, on_error);
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
                    return efl_ui_view_model_property_string_add_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), name, definition, not_ready, on_error);
                }
            }

            private static efl_ui_view_model_property_string_add_delegate efl_ui_view_model_property_string_add_static_delegate;

            
            private delegate CoreUI.DataTypes.Error efl_ui_view_model_property_string_del_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String name);

            
            internal delegate CoreUI.DataTypes.Error efl_ui_view_model_property_string_del_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String name);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_view_model_property_string_del_api_delegate> efl_ui_view_model_property_string_del_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_view_model_property_string_del_api_delegate>(Module, "efl_ui_view_model_property_string_del");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.DataTypes.Error property_string_del(System.IntPtr obj, System.IntPtr pd, System.String name)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_view_model_property_string_del was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.DataTypes.Error _ret_var = default(CoreUI.DataTypes.Error);
                    try
                    {
                        _ret_var = ((ViewModel)ws.Target).DelPropertyString(name);
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
                    return efl_ui_view_model_property_string_del_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), name);
                }
            }

            private static efl_ui_view_model_property_string_del_delegate efl_ui_view_model_property_string_del_static_delegate;

            
            private delegate void efl_ui_view_model_property_bind_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String source, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String destination);

            
            internal delegate void efl_ui_view_model_property_bind_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String source, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String destination);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_view_model_property_bind_api_delegate> efl_ui_view_model_property_bind_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_view_model_property_bind_api_delegate>(Module, "efl_ui_view_model_property_bind");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void property_bind(System.IntPtr obj, System.IntPtr pd, System.String source, System.String destination)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_view_model_property_bind was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((ViewModel)ws.Target).BindProperty(source, destination);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_view_model_property_bind_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), source, destination);
                }
            }

            private static efl_ui_view_model_property_bind_delegate efl_ui_view_model_property_bind_static_delegate;

            
            private delegate void efl_ui_view_model_property_unbind_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String source, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String destination);

            
            internal delegate void efl_ui_view_model_property_unbind_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String source, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String destination);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_view_model_property_unbind_api_delegate> efl_ui_view_model_property_unbind_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_view_model_property_unbind_api_delegate>(Module, "efl_ui_view_model_property_unbind");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void property_unbind(System.IntPtr obj, System.IntPtr pd, System.String source, System.String destination)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_view_model_property_unbind was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((ViewModel)ws.Target).UnbindProperty(source, destination);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_view_model_property_unbind_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), source, destination);
                }
            }

            private static efl_ui_view_model_property_unbind_delegate efl_ui_view_model_property_unbind_static_delegate;

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

namespace CoreUI.UI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class ViewModelExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> ChildrenBind<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.ViewModel, T>magic = null) where T : CoreUI.UI.ViewModel {
            return new CoreUI.BindableProperty<bool>("children_bind", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

