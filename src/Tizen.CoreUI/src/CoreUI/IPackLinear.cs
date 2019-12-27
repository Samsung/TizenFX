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
    /// <summary>Common interface for objects (containers) with multiple contents (sub-objects) which can be added and removed at runtime in a linear fashion.
    /// 
    /// This means the sub-objects are internally organized in an ordered list.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.IPackLinearNativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface IPackLinear : 
    CoreUI.IPack,
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>Prepend an object at the beginning of this container.
        /// 
        /// This is the same as <see cref="CoreUI.IPackLinear.PackAt"/> with a <c>0</c> index.
        /// 
        /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="CoreUI.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="subobj">Object to pack at the beginning.</param>
        /// <returns><c>false</c> if <c>subobj</c> could not be packed.</returns>
        bool PackBegin(CoreUI.Gfx.IEntity subobj);

        /// <summary>Append object at the end of this container.
        /// 
        /// This is the same as <see cref="CoreUI.IPackLinear.PackAt"/> with a <c>-1</c> index.
        /// 
        /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="CoreUI.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="subobj">Object to pack at the end.</param>
        /// <returns><c>false</c> if <c>subobj</c> could not be packed.</returns>
        bool PackEnd(CoreUI.Gfx.IEntity subobj);

        /// <summary>Prepend an object before the <c>existing</c> sub-object.
        /// 
        /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="CoreUI.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.
        /// 
        /// If <c>existing</c> is <c>NULL</c> this method behaves like <see cref="CoreUI.IPackLinear.PackBegin"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="subobj">Object to pack before <c>existing</c>.</param>
        /// <param name="existing">Existing reference sub-object. Must already belong to the container or be <c>NULL</c>.</param>
        /// <returns><c>false</c> if <c>existing</c> could not be found or <c>subobj</c> could not be packed.</returns>
        bool PackBefore(CoreUI.Gfx.IEntity subobj, CoreUI.Gfx.IEntity existing);

        /// <summary>Append an object after the <c>existing</c> sub-object.
        /// 
        /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="CoreUI.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.
        /// 
        /// If <c>existing</c> is <c>NULL</c> this method behaves like <see cref="CoreUI.IPackLinear.PackEnd"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="subobj">Object to pack after <c>existing</c>.</param>
        /// <param name="existing">Existing reference sub-object. Must already belong to the container or be <c>NULL</c>.</param>
        /// <returns><c>false</c> if <c>existing</c> could not be found or <c>subobj</c> could not be packed.</returns>
        bool PackAfter(CoreUI.Gfx.IEntity subobj, CoreUI.Gfx.IEntity existing);

        /// <summary>Inserts <c>subobj</c> BEFORE the sub-object at position <c>index</c>.
        /// 
        /// <c>index</c> ranges from <c>-count</c> to <c>count-1</c>, where positive numbers go from first sub-object (<c>0</c>) to last (<c>count-1</c>), and negative numbers go from last sub-object (<c>-1</c>) to first (<c>-count</c>). <c>count</c> is the number of sub-objects currently in the container as returned by <see cref="CoreUI.IContainer.ContentCount"/>.
        /// 
        /// If <c>index</c> is less than <c>-count</c>, it will trigger <see cref="CoreUI.IPackLinear.PackBegin"/> whereas <c>index</c> greater than <c>count-1</c> will trigger <see cref="CoreUI.IPackLinear.PackEnd"/>.
        /// 
        /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="CoreUI.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="subobj">Object to pack.</param>
        /// <param name="index">Index of existing sub-object to insert BEFORE. Valid range is <c>-count</c> to <c>count-1</c>).</param>
        /// <returns><c>false</c> if <c>subobj</c> could not be packed.</returns>
        bool PackAt(CoreUI.Gfx.IEntity subobj, int index);

        /// <summary>Sub-object at a given <c>index</c> in this container.
        /// 
        /// <c>index</c> ranges from <c>-count</c> to <c>count-1</c>, where positive numbers go from first sub-object (<c>0</c>) to last (<c>count-1</c>), and negative numbers go from last sub-object (<c>-1</c>) to first (<c>-count</c>). <c>count</c> is the number of sub-objects currently in the container as returned by <see cref="CoreUI.IContainer.ContentCount"/>.
        /// 
        /// If <c>index</c> is less than <c>-count</c>, it will return the first sub-object whereas <c>index</c> greater than <c>count-1</c> will return the last sub-object.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="index">Index of the existing sub-object to retrieve. Valid range is <c>-count</c> to <c>count-1</c>.</param>
        /// <returns>The sub-object contained at the given <c>index</c>.</returns>
        CoreUI.Gfx.IEntity GetPackContent(int index);

        /// <summary>Get the index of a sub-object in this container.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="subobj">An existing sub-object in this container.</param>
        /// <returns>-1 in case <c>subobj</c> is not found, or the index of <c>subobj</c> in the range <c>0</c> to <c>count-1</c>.</returns>
        int GetPackIndex(CoreUI.Gfx.IEntity subobj);

        /// <summary>Pop out (remove) the sub-object at the specified <c>index</c>.
        /// 
        /// <c>index</c> ranges from <c>-count</c> to <c>count-1</c>, where positive numbers go from first sub-object (<c>0</c>) to last (<c>count-1</c>), and negative numbers go from last sub-object (<c>-1</c>) to first (<c>-count</c>). <c>count</c> is the number of sub-objects currently in the container as returned by <see cref="CoreUI.IContainer.ContentCount"/>.
        /// 
        /// If <c>index</c> is less than -<c>count</c>, it will remove the first sub-object whereas <c>index</c> greater than <c>count</c>-1 will remove the last sub-object.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="index">Index of the sub-object to remove. Valid range is <c>-count</c> to <c>count-1</c>.</param>
        /// <returns>The sub-object if it could be removed.</returns>
        CoreUI.Gfx.IEntity PackUnpackAt(int index);

    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IPackLinearNativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
            efl_pack_linear_interface_get();
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.CoreUI);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_pack_begin_static_delegate == null)
            {
                efl_pack_begin_static_delegate = new efl_pack_begin_delegate(pack_begin);
            }

            if (methods.Contains("PackBegin"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_begin"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_begin_static_delegate) });
            }

            if (efl_pack_end_static_delegate == null)
            {
                efl_pack_end_static_delegate = new efl_pack_end_delegate(pack_end);
            }

            if (methods.Contains("PackEnd"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_end"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_end_static_delegate) });
            }

            if (efl_pack_before_static_delegate == null)
            {
                efl_pack_before_static_delegate = new efl_pack_before_delegate(pack_before);
            }

            if (methods.Contains("PackBefore"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_before"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_before_static_delegate) });
            }

            if (efl_pack_after_static_delegate == null)
            {
                efl_pack_after_static_delegate = new efl_pack_after_delegate(pack_after);
            }

            if (methods.Contains("PackAfter"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_after"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_after_static_delegate) });
            }

            if (efl_pack_at_static_delegate == null)
            {
                efl_pack_at_static_delegate = new efl_pack_at_delegate(pack_at);
            }

            if (methods.Contains("PackAt"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_at"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_at_static_delegate) });
            }

            if (efl_pack_content_get_static_delegate == null)
            {
                efl_pack_content_get_static_delegate = new efl_pack_content_get_delegate(pack_content_get);
            }

            if (methods.Contains("GetPackContent"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_content_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_content_get_static_delegate) });
            }

            if (efl_pack_index_get_static_delegate == null)
            {
                efl_pack_index_get_static_delegate = new efl_pack_index_get_delegate(pack_index_get);
            }

            if (methods.Contains("GetPackIndex"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_index_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_index_get_static_delegate) });
            }

            if (efl_pack_unpack_at_static_delegate == null)
            {
                efl_pack_unpack_at_static_delegate = new efl_pack_unpack_at_delegate(pack_unpack_at);
            }

            if (methods.Contains("PackUnpackAt"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_unpack_at"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_unpack_at_static_delegate) });
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
            return efl_pack_linear_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_pack_begin_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity subobj);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_pack_begin_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity subobj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_pack_begin_api_delegate> efl_pack_begin_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_pack_begin_api_delegate>(Module, "efl_pack_begin");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool pack_begin(System.IntPtr obj, System.IntPtr pd, CoreUI.Gfx.IEntity subobj)
        {
            CoreUI.DataTypes.Log.Debug("function efl_pack_begin was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IPackLinear)ws.Target).PackBegin(subobj);
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
                return efl_pack_begin_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), subobj);
            }
        }

        private static efl_pack_begin_delegate efl_pack_begin_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_pack_end_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity subobj);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_pack_end_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity subobj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_pack_end_api_delegate> efl_pack_end_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_pack_end_api_delegate>(Module, "efl_pack_end");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool pack_end(System.IntPtr obj, System.IntPtr pd, CoreUI.Gfx.IEntity subobj)
        {
            CoreUI.DataTypes.Log.Debug("function efl_pack_end was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IPackLinear)ws.Target).PackEnd(subobj);
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
                return efl_pack_end_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), subobj);
            }
        }

        private static efl_pack_end_delegate efl_pack_end_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_pack_before_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity subobj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity existing);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_pack_before_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity subobj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity existing);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_pack_before_api_delegate> efl_pack_before_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_pack_before_api_delegate>(Module, "efl_pack_before");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool pack_before(System.IntPtr obj, System.IntPtr pd, CoreUI.Gfx.IEntity subobj, CoreUI.Gfx.IEntity existing)
        {
            CoreUI.DataTypes.Log.Debug("function efl_pack_before was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IPackLinear)ws.Target).PackBefore(subobj, existing);
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
                return efl_pack_before_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), subobj, existing);
            }
        }

        private static efl_pack_before_delegate efl_pack_before_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_pack_after_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity subobj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity existing);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_pack_after_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity subobj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity existing);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_pack_after_api_delegate> efl_pack_after_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_pack_after_api_delegate>(Module, "efl_pack_after");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool pack_after(System.IntPtr obj, System.IntPtr pd, CoreUI.Gfx.IEntity subobj, CoreUI.Gfx.IEntity existing)
        {
            CoreUI.DataTypes.Log.Debug("function efl_pack_after was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IPackLinear)ws.Target).PackAfter(subobj, existing);
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
                return efl_pack_after_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), subobj, existing);
            }
        }

        private static efl_pack_after_delegate efl_pack_after_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_pack_at_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity subobj,  int index);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_pack_at_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity subobj,  int index);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_pack_at_api_delegate> efl_pack_at_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_pack_at_api_delegate>(Module, "efl_pack_at");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool pack_at(System.IntPtr obj, System.IntPtr pd, CoreUI.Gfx.IEntity subobj, int index)
        {
            CoreUI.DataTypes.Log.Debug("function efl_pack_at was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IPackLinear)ws.Target).PackAt(subobj, index);
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
                return efl_pack_at_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), subobj, index);
            }
        }

        private static efl_pack_at_delegate efl_pack_at_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
        private delegate CoreUI.Gfx.IEntity efl_pack_content_get_delegate(System.IntPtr obj, System.IntPtr pd,  int index);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
        internal delegate CoreUI.Gfx.IEntity efl_pack_content_get_api_delegate(System.IntPtr obj,  int index);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_pack_content_get_api_delegate> efl_pack_content_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_pack_content_get_api_delegate>(Module, "efl_pack_content_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.Gfx.IEntity pack_content_get(System.IntPtr obj, System.IntPtr pd, int index)
        {
            CoreUI.DataTypes.Log.Debug("function efl_pack_content_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.Gfx.IEntity _ret_var = default(CoreUI.Gfx.IEntity);
                try
                {
                    _ret_var = ((IPackLinear)ws.Target).GetPackContent(index);
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
                return efl_pack_content_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), index);
            }
        }

        private static efl_pack_content_get_delegate efl_pack_content_get_static_delegate;

        
        private delegate int efl_pack_index_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity subobj);

        
        internal delegate int efl_pack_index_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity subobj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_pack_index_get_api_delegate> efl_pack_index_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_pack_index_get_api_delegate>(Module, "efl_pack_index_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static int pack_index_get(System.IntPtr obj, System.IntPtr pd, CoreUI.Gfx.IEntity subobj)
        {
            CoreUI.DataTypes.Log.Debug("function efl_pack_index_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                int _ret_var = default(int);
                try
                {
                    _ret_var = ((IPackLinear)ws.Target).GetPackIndex(subobj);
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
                return efl_pack_index_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), subobj);
            }
        }

        private static efl_pack_index_get_delegate efl_pack_index_get_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
        private delegate CoreUI.Gfx.IEntity efl_pack_unpack_at_delegate(System.IntPtr obj, System.IntPtr pd,  int index);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
        internal delegate CoreUI.Gfx.IEntity efl_pack_unpack_at_api_delegate(System.IntPtr obj,  int index);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_pack_unpack_at_api_delegate> efl_pack_unpack_at_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_pack_unpack_at_api_delegate>(Module, "efl_pack_unpack_at");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.Gfx.IEntity pack_unpack_at(System.IntPtr obj, System.IntPtr pd, int index)
        {
            CoreUI.DataTypes.Log.Debug("function efl_pack_unpack_at was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.Gfx.IEntity _ret_var = default(CoreUI.Gfx.IEntity);
                try
                {
                    _ret_var = ((IPackLinear)ws.Target).PackUnpackAt(index);
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
                return efl_pack_unpack_at_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), index);
            }
        }

        private static efl_pack_unpack_at_delegate efl_pack_unpack_at_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

