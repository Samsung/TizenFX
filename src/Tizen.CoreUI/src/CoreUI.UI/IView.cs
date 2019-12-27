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
    /// <summary>CoreUI UI view interface.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.IViewNativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface IView : 
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>Model that is/will be</summary>
        /// <returns>CoreUI model</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.IModel GetModel();

        /// <summary>Model that is/will be</summary>
        /// <param name="model">CoreUI model</param>
        /// <since_tizen> 6 </since_tizen>
        void SetModel(CoreUI.IModel model);

        /// <summary>Event dispatched when a new model is set.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.ViewModelChangedEventArgs"/></value>
        event EventHandler<CoreUI.UI.ViewModelChangedEventArgs> ModelChanged;
        /// <summary>Model that is/will be</summary>
        /// <value>CoreUI model</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.IModel Model {
            get;
            set;
        }

    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.UI.IView.ModelChanged"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class ViewModelChangedEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Event dispatched when a new model is set.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.ModelChangedEvent Arg { get; set; }
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IViewNativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
            efl_ui_view_interface_get();
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.CoreUI);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_ui_view_model_get_static_delegate == null)
            {
                efl_ui_view_model_get_static_delegate = new efl_ui_view_model_get_delegate(model_get);
            }

            if (methods.Contains("GetModel"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_view_model_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_view_model_get_static_delegate) });
            }

            if (efl_ui_view_model_set_static_delegate == null)
            {
                efl_ui_view_model_set_static_delegate = new efl_ui_view_model_set_delegate(model_set);
            }

            if (methods.Contains("SetModel"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_view_model_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_view_model_set_static_delegate) });
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
            return efl_ui_view_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
        private delegate CoreUI.IModel efl_ui_view_model_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
        internal delegate CoreUI.IModel efl_ui_view_model_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_view_model_get_api_delegate> efl_ui_view_model_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_view_model_get_api_delegate>(Module, "efl_ui_view_model_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.IModel model_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_view_model_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.IModel _ret_var = default(CoreUI.IModel);
                try
                {
                    _ret_var = ((IView)ws.Target).GetModel();
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
                return efl_ui_view_model_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_ui_view_model_get_delegate efl_ui_view_model_get_static_delegate;

        
        private delegate void efl_ui_view_model_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.IModel model);

        
        internal delegate void efl_ui_view_model_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.IModel model);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_view_model_set_api_delegate> efl_ui_view_model_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_view_model_set_api_delegate>(Module, "efl_ui_view_model_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void model_set(System.IntPtr obj, System.IntPtr pd, CoreUI.IModel model)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_view_model_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IView)ws.Target).SetModel(model);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_view_model_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), model);
            }
        }

        private static efl_ui_view_model_set_delegate efl_ui_view_model_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

namespace CoreUI.UI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class ViewExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.IModel> Model<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.IView, T>magic = null) where T : CoreUI.UI.IView {
            return new CoreUI.BindableProperty<CoreUI.IModel>("model", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

namespace CoreUI {
    /// <summary>Every time the model is changed on the object.</summary>
    /// <since_tizen> 6 </since_tizen>
    [StructLayout(LayoutKind.Sequential)]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public struct ModelChangedEvent : IEquatable<ModelChangedEvent>
    {
        /// <summary>Internal wrapper for field current</summary>
        private System.IntPtr current;
        /// <summary>Internal wrapper for field previous</summary>
        private System.IntPtr previous;

        /// <summary>The newly set model.</summary>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.IModel Current { get => (CoreUI.IModel) CoreUI.Wrapper.Globals.CreateWrapperFor(current); }
        /// <summary>The previously set model.</summary>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.IModel Previous { get => (CoreUI.IModel) CoreUI.Wrapper.Globals.CreateWrapperFor(previous); }
        /// <summary>Constructor for ModelChangedEvent.
        /// </summary>
        /// <param name="current">The newly set model.</param>
        /// <param name="previous">The previously set model.</param>
        /// <since_tizen> 6 </since_tizen>
        public ModelChangedEvent(
            CoreUI.IModel current = default(CoreUI.IModel),
            CoreUI.IModel previous = default(CoreUI.IModel))
        {
            this.current = current?.NativeHandle ?? System.IntPtr.Zero;
            this.previous = previous?.NativeHandle ?? System.IntPtr.Zero;
        }

        /// <summary>Packs tuple into ModelChangedEvent object.
        ///<para>Since EFL 1.24.</para>
        ///</summary>
        public static implicit operator ModelChangedEvent((CoreUI.IModel current, CoreUI.IModel previous) tuple)
            => new ModelChangedEvent(tuple.current, tuple.previous);

        /// <summary>Unpacks ModelChangedEvent into tuple.
        /// <para>Since EFL 1.24.</para>
        /// </summary>
        public void Deconstruct(
            out CoreUI.IModel current,
            out CoreUI.IModel previous
        )
        {
            current = this.Current;
            previous = this.Previous;
        }
        /// <summary>Get a hash code for this item.
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + Current.GetHashCode();
            hash = hash * 23 + Previous.GetHashCode();
            return hash;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public bool Equals(ModelChangedEvent other)
        {
            return Current == other.Current && Previous == other.Previous;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public override bool Equals(object other)
            => ((other is ModelChangedEvent) ? Equals((ModelChangedEvent)other) : false);
        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator ==(ModelChangedEvent lhs, ModelChangedEvent rhs)
            => lhs.Equals(rhs);        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator !=(ModelChangedEvent lhs, ModelChangedEvent rhs)
            => !lhs.Equals(rhs);        /// <summary>Implicit conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static implicit operator ModelChangedEvent(IntPtr ptr)
        {
            return (ModelChangedEvent)Marshal.PtrToStructure(ptr, typeof(ModelChangedEvent));
        }

        /// <summary>Conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static ModelChangedEvent FromIntPtr(IntPtr ptr)
        {
            return ptr;
        }

    }

}

