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
namespace CoreUI.Gfx {
/// <since_tizen> 6 </since_tizen>
public static partial class Constants
{
    /// <summary>bottom-most layer number</summary>
    /// <since_tizen> 6 </since_tizen>
    public static readonly short StackLayerMin = -32768;
}
}

namespace CoreUI.Gfx {
/// <since_tizen> 6 </since_tizen>
public static partial class Constants
{
    /// <summary>top-most layer number</summary>
    /// <since_tizen> 6 </since_tizen>
    public static readonly short StackLayerMax = 32767;
}
}

namespace CoreUI.Gfx {
    /// <summary>CoreUI graphics stack interface</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Gfx.IStackNativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface IStack : 
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>The layer of its canvas that the given object will be part of.
        /// 
        /// If you don&apos;t use this property, you&apos;ll be dealing with a unique layer of objects (the default one). Additional layers are handy when you don&apos;t want a set of objects to interfere with another set with regard to stacking. Two layers are completely disjoint in that matter.
        /// 
        /// This is a low-level function, which you&apos;d be using when something should be always on top, for example.
        /// 
        /// <b>WARNING: </b>Don&apos;t change the layer of smart objects&apos; children. Smart objects have a layer of their own, which should contain all their child objects.</summary>
        /// <returns>The number of the layer to place the object on. Must be between <see cref="CoreUI.Gfx.Constants.StackLayerMin"/> and <see cref="CoreUI.Gfx.Constants.StackLayerMax"/>.</returns>
        /// <since_tizen> 6 </since_tizen>
        short GetLayer();

        /// <summary>The layer of its canvas that the given object will be part of.
        /// 
        /// If you don&apos;t use this property, you&apos;ll be dealing with a unique layer of objects (the default one). Additional layers are handy when you don&apos;t want a set of objects to interfere with another set with regard to stacking. Two layers are completely disjoint in that matter.
        /// 
        /// This is a low-level function, which you&apos;d be using when something should be always on top, for example.
        /// 
        /// <b>WARNING: </b>Don&apos;t change the layer of smart objects&apos; children. Smart objects have a layer of their own, which should contain all their child objects.</summary>
        /// <param name="l">The number of the layer to place the object on. Must be between <see cref="CoreUI.Gfx.Constants.StackLayerMin"/> and <see cref="CoreUI.Gfx.Constants.StackLayerMax"/>.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetLayer(short l);

        /// <summary>The Evas object stacked right below this object.
        /// 
        /// This function will traverse layers in its search, if there are objects on layers below the one <c>obj</c> is placed at.
        /// 
        /// See also <see cref="CoreUI.Gfx.IStack.Layer"/>.</summary>
        /// <returns>The <see cref="CoreUI.Gfx.IStack"/> object directly below <c>obj</c>, if any, or <c>null</c>, if none.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.Gfx.IStack GetBelow();

        /// <summary>Get the Evas object stacked right above this object.
        /// 
        /// This function will traverse layers in its search, if there are objects on layers above the one <c>obj</c> is placed at.
        /// 
        /// See also <see cref="CoreUI.Gfx.IStack.Layer"/> and <see cref="CoreUI.Gfx.IStack.GetBelow"/></summary>
        /// <returns>The <see cref="CoreUI.Gfx.IStack"/> object directly below <c>obj</c>, if any, or <c>null</c>, if none.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.Gfx.IStack GetAbove();

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
        void StackBelow(CoreUI.Gfx.IStack below);

        /// <summary>Raise <c>obj</c> to the top of its layer.
        /// 
        /// <c>obj</c> will, then, be the highest one in the layer it belongs to. Object on other layers won&apos;t get touched.
        /// 
        /// See also <see cref="CoreUI.Gfx.IStack.StackAbove"/>, <see cref="CoreUI.Gfx.IStack.StackBelow"/> and <see cref="CoreUI.Gfx.IStack.LowerToBottom"/></summary>
        /// <since_tizen> 6 </since_tizen>
        void RaiseToTop();

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
        void StackAbove(CoreUI.Gfx.IStack above);

        /// <summary>Lower <c>obj</c> to the bottom of its layer.
        /// 
        /// <c>obj</c> will, then, be the lowest one in the layer it belongs to. Objects on other layers won&apos;t get touched.
        /// 
        /// See also <see cref="CoreUI.Gfx.IStack.StackAbove"/>, <see cref="CoreUI.Gfx.IStack.StackBelow"/> and <see cref="CoreUI.Gfx.IStack.RaiseToTop"/></summary>
        /// <since_tizen> 6 </since_tizen>
        void LowerToBottom();

        /// <summary>Object stacking was changed.</summary>
        /// <since_tizen> 6 </since_tizen>
        event EventHandler StackingChanged;
        /// <summary>The layer of its canvas that the given object will be part of.
        /// 
        /// If you don&apos;t use this property, you&apos;ll be dealing with a unique layer of objects (the default one). Additional layers are handy when you don&apos;t want a set of objects to interfere with another set with regard to stacking. Two layers are completely disjoint in that matter.
        /// 
        /// This is a low-level function, which you&apos;d be using when something should be always on top, for example.
        /// 
        /// <b>WARNING: </b>Don&apos;t change the layer of smart objects&apos; children. Smart objects have a layer of their own, which should contain all their child objects.</summary>
        /// <value>The number of the layer to place the object on. Must be between <see cref="CoreUI.Gfx.Constants.StackLayerMin"/> and <see cref="CoreUI.Gfx.Constants.StackLayerMax"/>.</value>
        /// <since_tizen> 6 </since_tizen>
        short Layer {
            get;
            set;
        }

        /// <summary>The Evas object stacked right below this object.
        /// 
        /// This function will traverse layers in its search, if there are objects on layers below the one <c>obj</c> is placed at.
        /// 
        /// See also <see cref="CoreUI.Gfx.IStack.Layer"/>.</summary>
        /// <value>The <see cref="CoreUI.Gfx.IStack"/> object directly below <c>obj</c>, if any, or <c>null</c>, if none.</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.Gfx.IStack Below {
            get;
        }

        /// <summary>Get the Evas object stacked right above this object.
        /// 
        /// This function will traverse layers in its search, if there are objects on layers above the one <c>obj</c> is placed at.
        /// 
        /// See also <see cref="CoreUI.Gfx.IStack.Layer"/> and <see cref="CoreUI.Gfx.IStack.GetBelow"/></summary>
        /// <value>The <see cref="CoreUI.Gfx.IStack"/> object directly below <c>obj</c>, if any, or <c>null</c>, if none.</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.Gfx.IStack Above {
            get;
        }

    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IStackNativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
            efl_gfx_stack_interface_get();
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.CoreUI);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_gfx_stack_layer_get_static_delegate == null)
            {
                efl_gfx_stack_layer_get_static_delegate = new efl_gfx_stack_layer_get_delegate(layer_get);
            }

            if (methods.Contains("GetLayer"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_stack_layer_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_layer_get_static_delegate) });
            }

            if (efl_gfx_stack_layer_set_static_delegate == null)
            {
                efl_gfx_stack_layer_set_static_delegate = new efl_gfx_stack_layer_set_delegate(layer_set);
            }

            if (methods.Contains("SetLayer"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_stack_layer_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_layer_set_static_delegate) });
            }

            if (efl_gfx_stack_below_get_static_delegate == null)
            {
                efl_gfx_stack_below_get_static_delegate = new efl_gfx_stack_below_get_delegate(below_get);
            }

            if (methods.Contains("GetBelow"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_stack_below_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_below_get_static_delegate) });
            }

            if (efl_gfx_stack_above_get_static_delegate == null)
            {
                efl_gfx_stack_above_get_static_delegate = new efl_gfx_stack_above_get_delegate(above_get);
            }

            if (methods.Contains("GetAbove"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_stack_above_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_above_get_static_delegate) });
            }

            if (efl_gfx_stack_below_static_delegate == null)
            {
                efl_gfx_stack_below_static_delegate = new efl_gfx_stack_below_delegate(stack_below);
            }

            if (methods.Contains("StackBelow"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_stack_below"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_below_static_delegate) });
            }

            if (efl_gfx_stack_raise_to_top_static_delegate == null)
            {
                efl_gfx_stack_raise_to_top_static_delegate = new efl_gfx_stack_raise_to_top_delegate(raise_to_top);
            }

            if (methods.Contains("RaiseToTop"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_stack_raise_to_top"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_raise_to_top_static_delegate) });
            }

            if (efl_gfx_stack_above_static_delegate == null)
            {
                efl_gfx_stack_above_static_delegate = new efl_gfx_stack_above_delegate(stack_above);
            }

            if (methods.Contains("StackAbove"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_stack_above"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_above_static_delegate) });
            }

            if (efl_gfx_stack_lower_to_bottom_static_delegate == null)
            {
                efl_gfx_stack_lower_to_bottom_static_delegate = new efl_gfx_stack_lower_to_bottom_delegate(lower_to_bottom);
            }

            if (methods.Contains("LowerToBottom"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_stack_lower_to_bottom"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_stack_lower_to_bottom_static_delegate) });
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
            return efl_gfx_stack_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate short efl_gfx_stack_layer_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate short efl_gfx_stack_layer_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_stack_layer_get_api_delegate> efl_gfx_stack_layer_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_stack_layer_get_api_delegate>(Module, "efl_gfx_stack_layer_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static short layer_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_stack_layer_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                short _ret_var = default(short);
                try
                {
                    _ret_var = ((IStack)ws.Target).GetLayer();
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
                return efl_gfx_stack_layer_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_stack_layer_get_delegate efl_gfx_stack_layer_get_static_delegate;

        
        private delegate void efl_gfx_stack_layer_set_delegate(System.IntPtr obj, System.IntPtr pd,  short l);

        
        internal delegate void efl_gfx_stack_layer_set_api_delegate(System.IntPtr obj,  short l);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_stack_layer_set_api_delegate> efl_gfx_stack_layer_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_stack_layer_set_api_delegate>(Module, "efl_gfx_stack_layer_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void layer_set(System.IntPtr obj, System.IntPtr pd, short l)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_stack_layer_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IStack)ws.Target).SetLayer(l);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_stack_layer_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), l);
            }
        }

        private static efl_gfx_stack_layer_set_delegate efl_gfx_stack_layer_set_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
        private delegate CoreUI.Gfx.IStack efl_gfx_stack_below_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
        internal delegate CoreUI.Gfx.IStack efl_gfx_stack_below_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_stack_below_get_api_delegate> efl_gfx_stack_below_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_stack_below_get_api_delegate>(Module, "efl_gfx_stack_below_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.Gfx.IStack below_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_stack_below_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.Gfx.IStack _ret_var = default(CoreUI.Gfx.IStack);
                try
                {
                    _ret_var = ((IStack)ws.Target).GetBelow();
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
                return efl_gfx_stack_below_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_stack_below_get_delegate efl_gfx_stack_below_get_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
        private delegate CoreUI.Gfx.IStack efl_gfx_stack_above_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
        internal delegate CoreUI.Gfx.IStack efl_gfx_stack_above_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_stack_above_get_api_delegate> efl_gfx_stack_above_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_stack_above_get_api_delegate>(Module, "efl_gfx_stack_above_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.Gfx.IStack above_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_stack_above_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.Gfx.IStack _ret_var = default(CoreUI.Gfx.IStack);
                try
                {
                    _ret_var = ((IStack)ws.Target).GetAbove();
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
                return efl_gfx_stack_above_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_stack_above_get_delegate efl_gfx_stack_above_get_static_delegate;

        
        private delegate void efl_gfx_stack_below_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IStack below);

        
        internal delegate void efl_gfx_stack_below_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IStack below);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_stack_below_api_delegate> efl_gfx_stack_below_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_stack_below_api_delegate>(Module, "efl_gfx_stack_below");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void stack_below(System.IntPtr obj, System.IntPtr pd, CoreUI.Gfx.IStack below)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_stack_below was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IStack)ws.Target).StackBelow(below);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_stack_below_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), below);
            }
        }

        private static efl_gfx_stack_below_delegate efl_gfx_stack_below_static_delegate;

        
        private delegate void efl_gfx_stack_raise_to_top_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate void efl_gfx_stack_raise_to_top_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_stack_raise_to_top_api_delegate> efl_gfx_stack_raise_to_top_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_stack_raise_to_top_api_delegate>(Module, "efl_gfx_stack_raise_to_top");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void raise_to_top(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_stack_raise_to_top was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IStack)ws.Target).RaiseToTop();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_stack_raise_to_top_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_stack_raise_to_top_delegate efl_gfx_stack_raise_to_top_static_delegate;

        
        private delegate void efl_gfx_stack_above_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IStack above);

        
        internal delegate void efl_gfx_stack_above_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IStack above);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_stack_above_api_delegate> efl_gfx_stack_above_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_stack_above_api_delegate>(Module, "efl_gfx_stack_above");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void stack_above(System.IntPtr obj, System.IntPtr pd, CoreUI.Gfx.IStack above)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_stack_above was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IStack)ws.Target).StackAbove(above);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_stack_above_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), above);
            }
        }

        private static efl_gfx_stack_above_delegate efl_gfx_stack_above_static_delegate;

        
        private delegate void efl_gfx_stack_lower_to_bottom_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate void efl_gfx_stack_lower_to_bottom_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_stack_lower_to_bottom_api_delegate> efl_gfx_stack_lower_to_bottom_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_stack_lower_to_bottom_api_delegate>(Module, "efl_gfx_stack_lower_to_bottom");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void lower_to_bottom(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_stack_lower_to_bottom was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IStack)ws.Target).LowerToBottom();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_stack_lower_to_bottom_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_stack_lower_to_bottom_delegate efl_gfx_stack_lower_to_bottom_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

namespace CoreUI.Gfx {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class StackExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<short> Layer<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Gfx.IStack, T>magic = null) where T : CoreUI.Gfx.IStack {
            return new CoreUI.BindableProperty<short>("layer", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

