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
    /// <summary>CoreUI UI Factory that provides object caching.
    /// 
    /// This factory handles caching of one type of object that must be an <see cref="CoreUI.Gfx.IEntity"/> with an <see cref="CoreUI.UI.IView"/> interface defined. This factory will rely on its parent class <see cref="CoreUI.UI.WidgetFactory"/> for creating the subset of class that match the <see cref="CoreUI.UI.Widget"/> interface. The factory will automatically empty the cache when the application goes into the background (<see cref="CoreUI.App.Pause"/> event).
    /// 
    /// Creating objects is costly and time consuming, keeping a few on hand for when you next will need them helps a lot. This is what this factory caching infrastructure provides. It will create the object from the class defined on it and set the parent and the model as needed for all created items. The View has to release the Item using the release function of the Factory interface for all of this to work properly.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.CachingFactory.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public class CachingFactory : CoreUI.UI.WidgetFactory
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(CachingFactory))
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
            efl_ui_caching_factory_class_get();

        /// <summary>Initializes a new instance of the <see cref="CachingFactory"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
    /// <param name="itemClass">Define the class of the item returned by this factory. See <see cref="CoreUI.UI.WidgetFactory.SetItemClass" /></param>
        public CachingFactory(CoreUI.Object parent, Type itemClass = null) : base(efl_ui_caching_factory_class_get(), parent)
        {
            if (CoreUI.Wrapper.Globals.ParamHelperCheck(itemClass))
            {
                SetItemClass(CoreUI.Wrapper.Globals.GetParamHelper(itemClass));
            }

            FinishInstantiation();
        }

        /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
        /// Do not call this constructor directly.
        /// </summary>
        /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
        protected CachingFactory(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="CachingFactory"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal CachingFactory(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="CachingFactory"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected CachingFactory(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }


        /// <summary>Define the maximum size in Bytes that all the objects waiting on standby in the cache can take. They must provide the <span class="text-muted">CoreUI.Cached.IItem (object still in beta stage)</span> interface for an accurate accounting.</summary>
        /// <returns>When set to zero, there is no limit on the amount of memory the cache will use.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual uint GetMemoryLimit() {
            var _ret_var = CoreUI.UI.CachingFactory.NativeMethods.efl_ui_caching_factory_memory_limit_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Define the maximum size in Bytes that all the objects waiting on standby in the cache can take. They must provide the <span class="text-muted">CoreUI.Cached.IItem (object still in beta stage)</span> interface for an accurate accounting.</summary>
        /// <param name="limit">When set to zero, there is no limit on the amount of memory the cache will use.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetMemoryLimit(uint limit) {
            CoreUI.UI.CachingFactory.NativeMethods.efl_ui_caching_factory_memory_limit_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), limit);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Define how many maximum number of items are waiting on standby in the cache.</summary>
        /// <returns>When set to zero, there is no limit to the amount of items stored in the cache.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual uint GetItemsLimit() {
            var _ret_var = CoreUI.UI.CachingFactory.NativeMethods.efl_ui_caching_factory_items_limit_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Define how many maximum number of items are waiting on standby in the cache.</summary>
        /// <param name="limit">When set to zero, there is no limit to the amount of items stored in the cache.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetItemsLimit(uint limit) {
            CoreUI.UI.CachingFactory.NativeMethods.efl_ui_caching_factory_items_limit_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), limit);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Define the maximum size in Bytes that all the objects waiting on standby in the cache can take. They must provide the <span class="text-muted">CoreUI.Cached.IItem (object still in beta stage)</span> interface for an accurate accounting.</summary>
        /// <value>When set to zero, there is no limit on the amount of memory the cache will use.</value>
        /// <since_tizen> 6 </since_tizen>
        public uint MemoryLimit {
            get { return GetMemoryLimit(); }
            set { SetMemoryLimit(value); }
        }

        /// <summary>Define how many maximum number of items are waiting on standby in the cache.</summary>
        /// <value>When set to zero, there is no limit to the amount of items stored in the cache.</value>
        /// <since_tizen> 6 </since_tizen>
        public uint ItemsLimit {
            get { return GetItemsLimit(); }
            set { SetItemsLimit(value); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.UI.CachingFactory.efl_ui_caching_factory_class_get();
        }

        /// <summary>Wrapper for native methods and virtual method delegates.
        /// For internal use by generated code only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new class NativeMethods : CoreUI.UI.WidgetFactory.NativeMethods
        {
            private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Elementary);

            /// <summary>Gets the list of Eo operations to override.
        /// </summary>
            /// <returns>The list of Eo operations to be overload.</returns>
            internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
            {
                var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
                var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

                if (efl_ui_caching_factory_memory_limit_get_static_delegate == null)
                {
                    efl_ui_caching_factory_memory_limit_get_static_delegate = new efl_ui_caching_factory_memory_limit_get_delegate(memory_limit_get);
                }

                if (methods.Contains("GetMemoryLimit"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_caching_factory_memory_limit_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_caching_factory_memory_limit_get_static_delegate) });
                }

                if (efl_ui_caching_factory_memory_limit_set_static_delegate == null)
                {
                    efl_ui_caching_factory_memory_limit_set_static_delegate = new efl_ui_caching_factory_memory_limit_set_delegate(memory_limit_set);
                }

                if (methods.Contains("SetMemoryLimit"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_caching_factory_memory_limit_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_caching_factory_memory_limit_set_static_delegate) });
                }

                if (efl_ui_caching_factory_items_limit_get_static_delegate == null)
                {
                    efl_ui_caching_factory_items_limit_get_static_delegate = new efl_ui_caching_factory_items_limit_get_delegate(items_limit_get);
                }

                if (methods.Contains("GetItemsLimit"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_caching_factory_items_limit_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_caching_factory_items_limit_get_static_delegate) });
                }

                if (efl_ui_caching_factory_items_limit_set_static_delegate == null)
                {
                    efl_ui_caching_factory_items_limit_set_static_delegate = new efl_ui_caching_factory_items_limit_set_delegate(items_limit_set);
                }

                if (methods.Contains("SetItemsLimit"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_caching_factory_items_limit_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_caching_factory_items_limit_set_static_delegate) });
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
                return CoreUI.UI.CachingFactory.efl_ui_caching_factory_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            
            private delegate uint efl_ui_caching_factory_memory_limit_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate uint efl_ui_caching_factory_memory_limit_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_caching_factory_memory_limit_get_api_delegate> efl_ui_caching_factory_memory_limit_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_caching_factory_memory_limit_get_api_delegate>(Module, "efl_ui_caching_factory_memory_limit_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static uint memory_limit_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_caching_factory_memory_limit_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    uint _ret_var = default(uint);
                    try
                    {
                        _ret_var = ((CachingFactory)ws.Target).GetMemoryLimit();
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
                    return efl_ui_caching_factory_memory_limit_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_caching_factory_memory_limit_get_delegate efl_ui_caching_factory_memory_limit_get_static_delegate;

            
            private delegate void efl_ui_caching_factory_memory_limit_set_delegate(System.IntPtr obj, System.IntPtr pd,  uint limit);

            
            internal delegate void efl_ui_caching_factory_memory_limit_set_api_delegate(System.IntPtr obj,  uint limit);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_caching_factory_memory_limit_set_api_delegate> efl_ui_caching_factory_memory_limit_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_caching_factory_memory_limit_set_api_delegate>(Module, "efl_ui_caching_factory_memory_limit_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void memory_limit_set(System.IntPtr obj, System.IntPtr pd, uint limit)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_caching_factory_memory_limit_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((CachingFactory)ws.Target).SetMemoryLimit(limit);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_caching_factory_memory_limit_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), limit);
                }
            }

            private static efl_ui_caching_factory_memory_limit_set_delegate efl_ui_caching_factory_memory_limit_set_static_delegate;

            
            private delegate uint efl_ui_caching_factory_items_limit_get_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate uint efl_ui_caching_factory_items_limit_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_caching_factory_items_limit_get_api_delegate> efl_ui_caching_factory_items_limit_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_caching_factory_items_limit_get_api_delegate>(Module, "efl_ui_caching_factory_items_limit_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static uint items_limit_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_caching_factory_items_limit_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    uint _ret_var = default(uint);
                    try
                    {
                        _ret_var = ((CachingFactory)ws.Target).GetItemsLimit();
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
                    return efl_ui_caching_factory_items_limit_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_caching_factory_items_limit_get_delegate efl_ui_caching_factory_items_limit_get_static_delegate;

            
            private delegate void efl_ui_caching_factory_items_limit_set_delegate(System.IntPtr obj, System.IntPtr pd,  uint limit);

            
            internal delegate void efl_ui_caching_factory_items_limit_set_api_delegate(System.IntPtr obj,  uint limit);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_caching_factory_items_limit_set_api_delegate> efl_ui_caching_factory_items_limit_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_caching_factory_items_limit_set_api_delegate>(Module, "efl_ui_caching_factory_items_limit_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void items_limit_set(System.IntPtr obj, System.IntPtr pd, uint limit)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_caching_factory_items_limit_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((CachingFactory)ws.Target).SetItemsLimit(limit);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_ui_caching_factory_items_limit_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), limit);
                }
            }

            private static efl_ui_caching_factory_items_limit_set_delegate efl_ui_caching_factory_items_limit_set_static_delegate;

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

namespace CoreUI.UI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class CachingFactoryExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<uint> MemoryLimit<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.CachingFactory, T>magic = null) where T : CoreUI.UI.CachingFactory {
            return new CoreUI.BindableProperty<uint>("memory_limit", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<uint> ItemsLimit<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.CachingFactory, T>magic = null) where T : CoreUI.UI.CachingFactory {
            return new CoreUI.BindableProperty<uint>("items_limit", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

