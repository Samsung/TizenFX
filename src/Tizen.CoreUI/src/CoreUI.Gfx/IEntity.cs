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
    /// <summary>CoreUI graphics interface</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Gfx.IEntityNativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface IEntity : 
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>The 2D position of a canvas object.
        /// 
        /// The position is absolute, in pixels, relative to the top-left corner of the window, within its border decorations (application space).<br/>
        /// <b>Note:</b> Retrieves the position of the given canvas object.</summary>
        /// <returns>A 2D coordinate in pixel units.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.DataTypes.Position2D GetPosition();

        /// <summary>The 2D position of a canvas object.
        /// 
        /// The position is absolute, in pixels, relative to the top-left corner of the window, within its border decorations (application space).<br/>
        /// <b>Note:</b> Moves the given canvas object to the given location inside its canvas&apos; viewport. If unchanged this call may be entirely skipped, but if changed this will trigger move events, as well as potential pointer,in or pointer,out events.</summary>
        /// <param name="pos">A 2D coordinate in pixel units.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetPosition(CoreUI.DataTypes.Position2D pos);

        /// <summary>The 2D size of a canvas object.<br/>
        /// <b>Note:</b> Retrieves the (rectangular) size of the given Evas object.</summary>
        /// <returns>A 2D size in pixel units.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.DataTypes.Size2D GetSize();

        /// <summary>The 2D size of a canvas object.<br/>
        /// <b>Note:</b> Changes the size of the given object.
        /// 
        /// Note that setting the actual size of an object might be the job of its container, so this function might have no effect. Look at <see cref="CoreUI.Gfx.IHint"/> instead, when manipulating widgets.</summary>
        /// <param name="size">A 2D size in pixel units.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetSize(CoreUI.DataTypes.Size2D size);

        /// <summary>Rectangular geometry that combines both position and size.</summary>
        /// <returns>The X,Y position and W,H size, in pixels.</returns>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.DataTypes.Rect GetGeometry();

        /// <summary>Rectangular geometry that combines both position and size.</summary>
        /// <param name="rect">The X,Y position and W,H size, in pixels.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetGeometry(CoreUI.DataTypes.Rect rect);

        /// <summary>The visibility of a canvas object.
        /// 
        /// All canvas objects will become visible by default just before render. This means that it is not required to call <see cref="CoreUI.Gfx.IEntity.SetVisible"/> after creating an object unless you want to create it without showing it. Note that this behavior is new since 1.21, and only applies to canvas objects created with the EO API (i.e. not the legacy C-only API). Other types of Gfx objects may or may not be visible by default.
        /// 
        /// Note that many other parameters can prevent a visible object from actually being &quot;visible&quot; on screen. For instance if its color is fully transparent, or its parent is hidden, or it is clipped out, etc...<br/>
        /// <b>Note:</b> Retrieves whether or not the given canvas object is visible.</summary>
        /// <returns><c>true</c> if to make the object visible, <c>false</c> otherwise</returns>
        /// <since_tizen> 6 </since_tizen>
        bool GetVisible();

        /// <summary>The visibility of a canvas object.
        /// 
        /// All canvas objects will become visible by default just before render. This means that it is not required to call <see cref="CoreUI.Gfx.IEntity.SetVisible"/> after creating an object unless you want to create it without showing it. Note that this behavior is new since 1.21, and only applies to canvas objects created with the EO API (i.e. not the legacy C-only API). Other types of Gfx objects may or may not be visible by default.
        /// 
        /// Note that many other parameters can prevent a visible object from actually being &quot;visible&quot; on screen. For instance if its color is fully transparent, or its parent is hidden, or it is clipped out, etc...<br/>
        /// <b>Note:</b> Shows or hides this object.</summary>
        /// <param name="v"><c>true</c> if to make the object visible, <c>false</c> otherwise</param>
        /// <since_tizen> 6 </since_tizen>
        void SetVisible(bool v);

        /// <summary>The scaling factor of an object.
        /// 
        /// This property is an individual scaling factor on the object (Edje or UI widget). This property (or Edje&apos;s global scaling factor, when applicable), will affect this object&apos;s part sizes. If scale is not zero, then the individual scaling will override any global scaling set, for the object obj&apos;s parts. Set it back to zero to get the effects of the global scaling again.
        /// 
        /// <b>WARNING: </b>In Edje, only parts which, at EDC level, had the &quot;scale&quot; property set to 1, will be affected by this function. Check the complete &quot;syntax reference&quot; for EDC files.<br/>
        /// <b>Note:</b> Gets an object&apos;s scaling factor.</summary>
        /// <returns>The scaling factor.</returns>
        /// <since_tizen> 6 </since_tizen>
        double GetScale();

        /// <summary>The scaling factor of an object.
        /// 
        /// This property is an individual scaling factor on the object (Edje or UI widget). This property (or Edje&apos;s global scaling factor, when applicable), will affect this object&apos;s part sizes. If scale is not zero, then the individual scaling will override any global scaling set, for the object obj&apos;s parts. Set it back to zero to get the effects of the global scaling again.
        /// 
        /// <b>WARNING: </b>In Edje, only parts which, at EDC level, had the &quot;scale&quot; property set to 1, will be affected by this function. Check the complete &quot;syntax reference&quot; for EDC files.<br/>
        /// <b>Note:</b> Sets the scaling factor of an object.</summary>
        /// <param name="scale">The scaling factor.<br/>The default value is <c>0.000000</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetScale(double scale);

        /// <summary>Object&apos;s visibility state changed, the event value is the new state.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Gfx.EntityVisibilityChangedEventArgs"/></value>
        event EventHandler<CoreUI.Gfx.EntityVisibilityChangedEventArgs> VisibilityChanged;
        /// <summary>Object was moved, its position during the event is the new one.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Gfx.EntityPositionChangedEventArgs"/></value>
        event EventHandler<CoreUI.Gfx.EntityPositionChangedEventArgs> PositionChanged;
        /// <summary>Object was resized, its size during the event is the new one.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Gfx.EntitySizeChangedEventArgs"/></value>
        event EventHandler<CoreUI.Gfx.EntitySizeChangedEventArgs> SizeChanged;
        /// <summary>The 2D position of a canvas object.
        /// 
        /// The position is absolute, in pixels, relative to the top-left corner of the window, within its border decorations (application space).<br/>
        /// <b>Note on writing:</b> Moves the given canvas object to the given location inside its canvas&apos; viewport. If unchanged this call may be entirely skipped, but if changed this will trigger move events, as well as potential pointer,in or pointer,out events.<br/>
        /// <b>Note on reading:</b> Retrieves the position of the given canvas object.</summary>
        /// <value>A 2D coordinate in pixel units.</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.DataTypes.Position2D Position {
            get;
            set;
        }

        /// <summary>The 2D size of a canvas object.<br/>
        /// <b>Note on writing:</b> Changes the size of the given object.
        /// 
        /// Note that setting the actual size of an object might be the job of its container, so this function might have no effect. Look at <see cref="CoreUI.Gfx.IHint"/> instead, when manipulating widgets.<br/>
        /// <b>Note on reading:</b> Retrieves the (rectangular) size of the given Evas object.</summary>
        /// <value>A 2D size in pixel units.</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.DataTypes.Size2D Size {
            get;
            set;
        }

        /// <summary>Rectangular geometry that combines both position and size.</summary>
        /// <value>The X,Y position and W,H size, in pixels.</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.DataTypes.Rect Geometry {
            get;
            set;
        }

        /// <summary>The visibility of a canvas object.
        /// 
        /// All canvas objects will become visible by default just before render. This means that it is not required to call <see cref="CoreUI.Gfx.IEntity.SetVisible"/> after creating an object unless you want to create it without showing it. Note that this behavior is new since 1.21, and only applies to canvas objects created with the EO API (i.e. not the legacy C-only API). Other types of Gfx objects may or may not be visible by default.
        /// 
        /// Note that many other parameters can prevent a visible object from actually being &quot;visible&quot; on screen. For instance if its color is fully transparent, or its parent is hidden, or it is clipped out, etc...<br/>
        /// <b>Note on writing:</b> Shows or hides this object.<br/>
        /// <b>Note on reading:</b> Retrieves whether or not the given canvas object is visible.</summary>
        /// <value><c>true</c> if to make the object visible, <c>false</c> otherwise</value>
        /// <since_tizen> 6 </since_tizen>
        bool Visible {
            get;
            set;
        }

        /// <summary>The scaling factor of an object.
        /// 
        /// This property is an individual scaling factor on the object (Edje or UI widget). This property (or Edje&apos;s global scaling factor, when applicable), will affect this object&apos;s part sizes. If scale is not zero, then the individual scaling will override any global scaling set, for the object obj&apos;s parts. Set it back to zero to get the effects of the global scaling again.
        /// 
        /// <b>WARNING: </b>In Edje, only parts which, at EDC level, had the &quot;scale&quot; property set to 1, will be affected by this function. Check the complete &quot;syntax reference&quot; for EDC files.<br/>
        /// <b>Note on writing:</b> Sets the scaling factor of an object.<br/>
        /// <b>Note on reading:</b> Gets an object&apos;s scaling factor.</summary>
        /// <value>The scaling factor.</value>
        /// <since_tizen> 6 </since_tizen>
        double Scale {
            get;
            set;
        }

    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.Gfx.IEntity.VisibilityChanged"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class EntityVisibilityChangedEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Object&apos;s visibility state changed, the event value is the new state.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.Gfx.IEntity.PositionChanged"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class EntityPositionChangedEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Object was moved, its position during the event is the new one.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Position2D Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.Gfx.IEntity.SizeChanged"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class EntitySizeChangedEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Object was resized, its size during the event is the new one.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Size2D Arg { get; set; }
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IEntityNativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
            efl_gfx_entity_interface_get();
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.CoreUI);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_gfx_entity_position_get_static_delegate == null)
            {
                efl_gfx_entity_position_get_static_delegate = new efl_gfx_entity_position_get_delegate(position_get);
            }

            if (methods.Contains("GetPosition"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_entity_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_position_get_static_delegate) });
            }

            if (efl_gfx_entity_position_set_static_delegate == null)
            {
                efl_gfx_entity_position_set_static_delegate = new efl_gfx_entity_position_set_delegate(position_set);
            }

            if (methods.Contains("SetPosition"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_entity_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_position_set_static_delegate) });
            }

            if (efl_gfx_entity_size_get_static_delegate == null)
            {
                efl_gfx_entity_size_get_static_delegate = new efl_gfx_entity_size_get_delegate(size_get);
            }

            if (methods.Contains("GetSize"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_entity_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_size_get_static_delegate) });
            }

            if (efl_gfx_entity_size_set_static_delegate == null)
            {
                efl_gfx_entity_size_set_static_delegate = new efl_gfx_entity_size_set_delegate(size_set);
            }

            if (methods.Contains("SetSize"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_entity_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_size_set_static_delegate) });
            }

            if (efl_gfx_entity_geometry_get_static_delegate == null)
            {
                efl_gfx_entity_geometry_get_static_delegate = new efl_gfx_entity_geometry_get_delegate(geometry_get);
            }

            if (methods.Contains("GetGeometry"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_entity_geometry_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_geometry_get_static_delegate) });
            }

            if (efl_gfx_entity_geometry_set_static_delegate == null)
            {
                efl_gfx_entity_geometry_set_static_delegate = new efl_gfx_entity_geometry_set_delegate(geometry_set);
            }

            if (methods.Contains("SetGeometry"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_entity_geometry_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_geometry_set_static_delegate) });
            }

            if (efl_gfx_entity_visible_get_static_delegate == null)
            {
                efl_gfx_entity_visible_get_static_delegate = new efl_gfx_entity_visible_get_delegate(visible_get);
            }

            if (methods.Contains("GetVisible"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_entity_visible_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_visible_get_static_delegate) });
            }

            if (efl_gfx_entity_visible_set_static_delegate == null)
            {
                efl_gfx_entity_visible_set_static_delegate = new efl_gfx_entity_visible_set_delegate(visible_set);
            }

            if (methods.Contains("SetVisible"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_entity_visible_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_visible_set_static_delegate) });
            }

            if (efl_gfx_entity_scale_get_static_delegate == null)
            {
                efl_gfx_entity_scale_get_static_delegate = new efl_gfx_entity_scale_get_delegate(scale_get);
            }

            if (methods.Contains("GetScale"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_entity_scale_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_scale_get_static_delegate) });
            }

            if (efl_gfx_entity_scale_set_static_delegate == null)
            {
                efl_gfx_entity_scale_set_static_delegate = new efl_gfx_entity_scale_set_delegate(scale_set);
            }

            if (methods.Contains("SetScale"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_gfx_entity_scale_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_entity_scale_set_static_delegate) });
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
            return efl_gfx_entity_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate CoreUI.DataTypes.Position2D efl_gfx_entity_position_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.DataTypes.Position2D efl_gfx_entity_position_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_entity_position_get_api_delegate> efl_gfx_entity_position_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_entity_position_get_api_delegate>(Module, "efl_gfx_entity_position_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.DataTypes.Position2D position_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_entity_position_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Position2D _ret_var = default(CoreUI.DataTypes.Position2D);
                try
                {
                    _ret_var = ((IEntity)ws.Target).GetPosition();
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
                return efl_gfx_entity_position_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_entity_position_get_delegate efl_gfx_entity_position_get_static_delegate;

        
        private delegate void efl_gfx_entity_position_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.DataTypes.Position2D pos);

        
        internal delegate void efl_gfx_entity_position_set_api_delegate(System.IntPtr obj,  CoreUI.DataTypes.Position2D pos);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_entity_position_set_api_delegate> efl_gfx_entity_position_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_entity_position_set_api_delegate>(Module, "efl_gfx_entity_position_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void position_set(System.IntPtr obj, System.IntPtr pd, CoreUI.DataTypes.Position2D pos)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_entity_position_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Position2D _in_pos = pos;

                try
                {
                    ((IEntity)ws.Target).SetPosition(_in_pos);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_entity_position_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), pos);
            }
        }

        private static efl_gfx_entity_position_set_delegate efl_gfx_entity_position_set_static_delegate;

        
        private delegate CoreUI.DataTypes.Size2D efl_gfx_entity_size_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.DataTypes.Size2D efl_gfx_entity_size_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_entity_size_get_api_delegate> efl_gfx_entity_size_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_entity_size_get_api_delegate>(Module, "efl_gfx_entity_size_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.DataTypes.Size2D size_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_entity_size_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Size2D _ret_var = default(CoreUI.DataTypes.Size2D);
                try
                {
                    _ret_var = ((IEntity)ws.Target).GetSize();
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
                return efl_gfx_entity_size_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_entity_size_get_delegate efl_gfx_entity_size_get_static_delegate;

        
        private delegate void efl_gfx_entity_size_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.DataTypes.Size2D size);

        
        internal delegate void efl_gfx_entity_size_set_api_delegate(System.IntPtr obj,  CoreUI.DataTypes.Size2D size);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_entity_size_set_api_delegate> efl_gfx_entity_size_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_entity_size_set_api_delegate>(Module, "efl_gfx_entity_size_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void size_set(System.IntPtr obj, System.IntPtr pd, CoreUI.DataTypes.Size2D size)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_entity_size_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Size2D _in_size = size;

                try
                {
                    ((IEntity)ws.Target).SetSize(_in_size);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_entity_size_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), size);
            }
        }

        private static efl_gfx_entity_size_set_delegate efl_gfx_entity_size_set_static_delegate;

        
        private delegate CoreUI.DataTypes.Rect efl_gfx_entity_geometry_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate CoreUI.DataTypes.Rect efl_gfx_entity_geometry_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_entity_geometry_get_api_delegate> efl_gfx_entity_geometry_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_entity_geometry_get_api_delegate>(Module, "efl_gfx_entity_geometry_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.DataTypes.Rect geometry_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_entity_geometry_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Rect _ret_var = default(CoreUI.DataTypes.Rect);
                try
                {
                    _ret_var = ((IEntity)ws.Target).GetGeometry();
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
                return efl_gfx_entity_geometry_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_entity_geometry_get_delegate efl_gfx_entity_geometry_get_static_delegate;

        
        private delegate void efl_gfx_entity_geometry_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.DataTypes.Rect rect);

        
        internal delegate void efl_gfx_entity_geometry_set_api_delegate(System.IntPtr obj,  CoreUI.DataTypes.Rect rect);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_entity_geometry_set_api_delegate> efl_gfx_entity_geometry_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_entity_geometry_set_api_delegate>(Module, "efl_gfx_entity_geometry_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void geometry_set(System.IntPtr obj, System.IntPtr pd, CoreUI.DataTypes.Rect rect)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_entity_geometry_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Rect _in_rect = rect;

                try
                {
                    ((IEntity)ws.Target).SetGeometry(_in_rect);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_entity_geometry_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), rect);
            }
        }

        private static efl_gfx_entity_geometry_set_delegate efl_gfx_entity_geometry_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_gfx_entity_visible_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_gfx_entity_visible_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_entity_visible_get_api_delegate> efl_gfx_entity_visible_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_entity_visible_get_api_delegate>(Module, "efl_gfx_entity_visible_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool visible_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_entity_visible_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IEntity)ws.Target).GetVisible();
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
                return efl_gfx_entity_visible_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_entity_visible_get_delegate efl_gfx_entity_visible_get_static_delegate;

        
        private delegate void efl_gfx_entity_visible_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool v);

        
        internal delegate void efl_gfx_entity_visible_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool v);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_entity_visible_set_api_delegate> efl_gfx_entity_visible_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_entity_visible_set_api_delegate>(Module, "efl_gfx_entity_visible_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void visible_set(System.IntPtr obj, System.IntPtr pd, bool v)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_entity_visible_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IEntity)ws.Target).SetVisible(v);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_entity_visible_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), v);
            }
        }

        private static efl_gfx_entity_visible_set_delegate efl_gfx_entity_visible_set_static_delegate;

        
        private delegate double efl_gfx_entity_scale_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate double efl_gfx_entity_scale_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_entity_scale_get_api_delegate> efl_gfx_entity_scale_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_entity_scale_get_api_delegate>(Module, "efl_gfx_entity_scale_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static double scale_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_entity_scale_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                double _ret_var = default(double);
                try
                {
                    _ret_var = ((IEntity)ws.Target).GetScale();
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
                return efl_gfx_entity_scale_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_gfx_entity_scale_get_delegate efl_gfx_entity_scale_get_static_delegate;

        
        private delegate void efl_gfx_entity_scale_set_delegate(System.IntPtr obj, System.IntPtr pd,  double scale);

        
        internal delegate void efl_gfx_entity_scale_set_api_delegate(System.IntPtr obj,  double scale);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_gfx_entity_scale_set_api_delegate> efl_gfx_entity_scale_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_gfx_entity_scale_set_api_delegate>(Module, "efl_gfx_entity_scale_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void scale_set(System.IntPtr obj, System.IntPtr pd, double scale)
        {
            CoreUI.DataTypes.Log.Debug("function efl_gfx_entity_scale_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IEntity)ws.Target).SetScale(scale);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_gfx_entity_scale_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), scale);
            }
        }

        private static efl_gfx_entity_scale_set_delegate efl_gfx_entity_scale_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

namespace CoreUI.Gfx {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class EntityExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.DataTypes.Position2D> Position<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Gfx.IEntity, T>magic = null) where T : CoreUI.Gfx.IEntity {
            return new CoreUI.BindableProperty<CoreUI.DataTypes.Position2D>("position", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.DataTypes.Size2D> Size<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Gfx.IEntity, T>magic = null) where T : CoreUI.Gfx.IEntity {
            return new CoreUI.BindableProperty<CoreUI.DataTypes.Size2D>("size", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.DataTypes.Rect> Geometry<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Gfx.IEntity, T>magic = null) where T : CoreUI.Gfx.IEntity {
            return new CoreUI.BindableProperty<CoreUI.DataTypes.Rect>("geometry", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> Visible<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Gfx.IEntity, T>magic = null) where T : CoreUI.Gfx.IEntity {
            return new CoreUI.BindableProperty<bool>("visible", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> Scale<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Gfx.IEntity, T>magic = null) where T : CoreUI.Gfx.IEntity {
            return new CoreUI.BindableProperty<double>("scale", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

