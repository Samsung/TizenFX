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
namespace CoreUI {
    /// <summary>CoreUI model for all composite class which provide a unified API to set source of data.
    /// 
    /// This class also provide an <see cref="CoreUI.IModel.GetProperty"/> &quot;child.index&quot; that match the value of <see cref="CoreUI.CompositeModel.Index"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.CompositeModel.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public class CompositeModel : CoreUI.LoopModel, CoreUI.UI.IView
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(CompositeModel))
                {
                    return GetCoreUIClassStatic();
                }
                else
                {
                    return CoreUI.Wrapper.ClassRegister.klassFromType[((object)this).GetType()];
                }
            }
        }

        [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Ecore)] internal static extern System.IntPtr
            efl_composite_model_class_get();

        /// <summary>Initializes a new instance of the <see cref="CompositeModel"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
    /// <param name="model">Model that is/will be See <see cref="CoreUI.UI.IView.SetModel" /></param>
    /// <param name="index">Position of this object in the parent model. See <see cref="CoreUI.CompositeModel.SetIndex" /></param>
        public CompositeModel(CoreUI.Object parent, CoreUI.IModel model, uint? index = null) : base(efl_composite_model_class_get(), parent)
        {
            if (CoreUI.Wrapper.Globals.ParamHelperCheck(model))
            {
                SetModel(CoreUI.Wrapper.Globals.GetParamHelper(model));
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
        protected CompositeModel(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="CompositeModel"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal CompositeModel(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="CompositeModel"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected CompositeModel(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }


        /// <summary>Event dispatched when a new model is set.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.ViewModelChangedEventArgs"/></value>
        public event EventHandler<CoreUI.UI.ViewModelChangedEventArgs> ModelChanged
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.ViewModelChangedEventArgs{ Arg =  info });
                string key = "_EFL_UI_VIEW_EVENT_MODEL_CHANGED";
                AddNativeEventHandler(CoreUI.Libs.Ecore, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_VIEW_EVENT_MODEL_CHANGED";
                RemoveNativeEventHandler(CoreUI.Libs.Ecore, key, value);
            }
        }

        /// <summary>Method to raise event ModelChanged.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnModelChanged(CoreUI.UI.ViewModelChangedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.Arg));
            CallNativeEventCallback(CoreUI.Libs.Ecore, "_EFL_UI_VIEW_EVENT_MODEL_CHANGED", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Position of this object in the parent model.
        /// 
        /// It can only be set before the object is finalized but after the Model it composes is set (and only if that Model does not provide an index already). It can only be retrieved after the object has been finalized.</summary>
        /// <returns>Index of the object in the parent model. The index is unique and starts from zero.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual uint GetIndex() {
            var _ret_var = CoreUI.CompositeModel.NativeMethods.efl_composite_model_index_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Position of this object in the parent model.
        /// 
        /// It can only be set before the object is finalized but after the Model it composes is set (and only if that Model does not provide an index already). It can only be retrieved after the object has been finalized.</summary>
        /// <param name="index">Index of the object in the parent model. The index is unique and starts from zero.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetIndex(uint index) {
            CoreUI.CompositeModel.NativeMethods.efl_composite_model_index_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), index);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Model that is/will be</summary>
        /// <returns>CoreUI model</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.IModel GetModel() {
            var _ret_var = CoreUI.UI.IViewNativeMethods.efl_ui_view_model_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Model that is/will be</summary>
        /// <param name="model">CoreUI model</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetModel(CoreUI.IModel model) {
            CoreUI.UI.IViewNativeMethods.efl_ui_view_model_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), model);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Position of this object in the parent model.
        /// 
        /// It can only be set before the object is finalized but after the Model it composes is set (and only if that Model does not provide an index already). It can only be retrieved after the object has been finalized.</summary>
        /// <value>Index of the object in the parent model. The index is unique and starts from zero.</value>
        /// <since_tizen> 6 </since_tizen>
        public uint Index {
            get { return GetIndex(); }
            set { SetIndex(value); }
        }

        /// <summary>Model that is/will be</summary>
        /// <value>CoreUI model</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.IModel Model {
            get { return GetModel(); }
            set { SetModel(value); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.CompositeModel.efl_composite_model_class_get();
        }

        /// <summary>Wrapper for native methods and virtual method delegates.
        /// For internal use by generated code only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new class NativeMethods : CoreUI.LoopModel.NativeMethods
        {
            private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Ecore);

            /// <summary>Gets the list of Eo operations to override.
        /// </summary>
            /// <returns>The list of Eo operations to be overload.</returns>
            internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
            {
                var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
                var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

                if (efl_composite_model_index_get_static_delegate == null)
                {
                    efl_composite_model_index_get_static_delegate = new efl_composite_model_index_get_delegate(index_get);
                }

                if (methods.Contains("GetIndex"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_composite_model_index_get"), func = Marshal.GetFunctionPointerForDelegate(efl_composite_model_index_get_static_delegate) });
                }

                if (efl_composite_model_index_set_static_delegate == null)
                {
                    efl_composite_model_index_set_static_delegate = new efl_composite_model_index_set_delegate(index_set);
                }

                if (methods.Contains("SetIndex"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_composite_model_index_set"), func = Marshal.GetFunctionPointerForDelegate(efl_composite_model_index_set_static_delegate) });
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
                return CoreUI.CompositeModel.efl_composite_model_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            
            private delegate uint efl_composite_model_index_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate uint efl_composite_model_index_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_composite_model_index_get_api_delegate> efl_composite_model_index_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_composite_model_index_get_api_delegate>(Module, "efl_composite_model_index_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static uint index_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_composite_model_index_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    uint _ret_var = default(uint);
                    try
                    {
                        _ret_var = ((CompositeModel)ws.Target).GetIndex();
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
                    return efl_composite_model_index_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_composite_model_index_get_delegate efl_composite_model_index_get_static_delegate;

            
            private delegate void efl_composite_model_index_set_delegate(System.IntPtr obj, System.IntPtr pd,  uint index);

            
            internal delegate void efl_composite_model_index_set_api_delegate(System.IntPtr obj,  uint index);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_composite_model_index_set_api_delegate> efl_composite_model_index_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_composite_model_index_set_api_delegate>(Module, "efl_composite_model_index_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void index_set(System.IntPtr obj, System.IntPtr pd, uint index)
            {
                CoreUI.DataTypes.Log.Debug("function efl_composite_model_index_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((CompositeModel)ws.Target).SetIndex(index);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_composite_model_index_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), index);
                }
            }

            private static efl_composite_model_index_set_delegate efl_composite_model_index_set_static_delegate;

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

namespace CoreUI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class CompositeModelExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<uint> Index<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.CompositeModel, T>magic = null) where T : CoreUI.CompositeModel {
            return new CoreUI.BindableProperty<uint>("index", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.IModel> Model<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.CompositeModel, T>magic = null) where T : CoreUI.CompositeModel {
            return new CoreUI.BindableProperty<CoreUI.IModel>("model", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

