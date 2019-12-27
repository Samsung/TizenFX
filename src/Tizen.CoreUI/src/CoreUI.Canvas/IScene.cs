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
namespace CoreUI.Canvas {
    /// <summary>Interface containing basic canvas-related methods and events.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Canvas.ISceneNativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface IScene : 
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>The maximum image size the canvas can possibly handle.
        /// 
        /// This function returns the largest image or surface size that the canvas can handle in pixels, and if there is one, returns <c>true</c>. It returns <c>false</c> if no extra constraint on maximum image size exists.
        /// 
        /// The default limit is 65535x65535.</summary>
        /// <param name="max">The maximum image size (in pixels).</param>
        /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
        /// <since_tizen> 6 </since_tizen>
        bool GetImageMaxSize(out CoreUI.DataTypes.Size2D max);

        /// <summary>Get if the canvas is currently calculating group objects.</summary>
        /// <returns><c>true</c> if currently calculating group objects.</returns>
        /// <since_tizen> 6 </since_tizen>
        bool GetGroupObjectsCalculating();

        /// <summary>Call user-provided <c>calculate</c> group functions and unset the flag signalling that the object needs to get recalculated to all group objects in the canvas.</summary>
        /// <since_tizen> 6 </since_tizen>
        void CalculateGroupObjects();

        /// <summary>Retrieve a list of objects at a given position in a canvas.
        /// 
        /// This function will traverse all the layers of the given canvas, from top to bottom, querying for objects with areas covering the given position. The user can exclude from the query objects which are hidden and/or which are set to pass events.
        /// 
        /// <b>WARNING: </b>This function will only evaluate top-level objects; child or &quot;sub&quot; objects will be skipped.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="pos">The pixel position.</param>
        /// <param name="include_pass_events_objects">Boolean flag to include or not objects which pass events in this calculation.</param>
        /// <param name="include_hidden_objects">Boolean flag to include or not hidden objects in this calculation.</param>
        /// <returns>The list of objects that are over the given position in <c>e</c>.</returns>
        IEnumerable<CoreUI.Gfx.IEntity> GetObjectsAtXy(CoreUI.DataTypes.Position2D pos, bool include_pass_events_objects, bool include_hidden_objects);

        /// <summary>Retrieve the object stacked at the top of a given position in a canvas.
        /// 
        /// This function will traverse all the layers of the given canvas, from top to bottom, querying for objects with areas covering the given position. The user can exclude from the query objects which are hidden and/or which are set to pass events.
        /// 
        /// <b>WARNING: </b>This function will only evaluate top-level objects; child or &quot;sub&quot; objects will be skipped.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="pos">The pixel position.</param>
        /// <param name="include_pass_events_objects">Boolean flag to include or not objects which pass events in this calculation.</param>
        /// <param name="include_hidden_objects">Boolean flag to include or not hidden objects in this calculation.</param>
        /// <returns>The canvas object that is over all other objects at the given position.</returns>
        CoreUI.Gfx.IEntity GetObjectTopAtXy(CoreUI.DataTypes.Position2D pos, bool include_pass_events_objects, bool include_hidden_objects);

        /// <summary>Retrieve a list of objects overlapping a given rectangular region in a canvas.
        /// 
        /// This function will traverse all the layers of the given canvas, from top to bottom, querying for objects with areas overlapping with the given rectangular region. The user can exclude from the query objects which are hidden and/or which are set to pass events.
        /// 
        /// <b>WARNING: </b>This function will only evaluate top-level objects; child or &quot;sub&quot; objects will be skipped.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="rect">The rectangular region.</param>
        /// <param name="include_pass_events_objects">Boolean flag to include or not objects which pass events in this calculation.</param>
        /// <param name="include_hidden_objects">Boolean flag to include or not hidden objects in this calculation.</param>
        /// <returns>Iterator to objects</returns>
        IEnumerable<CoreUI.Gfx.IEntity> GetObjectsInRectangle(CoreUI.DataTypes.Rect rect, bool include_pass_events_objects, bool include_hidden_objects);

        /// <summary>Retrieve the canvas object stacked at the top of a given rectangular region in a canvas
        /// 
        /// This function will traverse all the layers of the given canvas, from top to bottom, querying for objects with areas overlapping with the given rectangular region. The user can exclude from the query objects which are hidden and/or which are set to pass events.
        /// 
        /// <b>WARNING: </b>This function will only evaluate top-level objects; child or &quot;sub&quot; objects will be skipped.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="rect">The rectangular region.</param>
        /// <param name="include_pass_events_objects">Boolean flag to include or not objects which pass events in this calculation.</param>
        /// <param name="include_hidden_objects">Boolean flag to include or not hidden objects in this calculation.</param>
        /// <returns>The object that is over all other objects at the given rectangular region.</returns>
        CoreUI.Gfx.IEntity GetObjectTopInRectangle(CoreUI.DataTypes.Rect rect, bool include_pass_events_objects, bool include_hidden_objects);

        /// <summary>Called when scene got focus</summary>
        /// <since_tizen> 6 </since_tizen>
        event EventHandler SceneFocusIn;
        /// <summary>Called when scene lost focus</summary>
        /// <since_tizen> 6 </since_tizen>
        event EventHandler SceneFocusOut;
        /// <summary>Called when object got focus</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Canvas.SceneObjectFocusInEventArgs"/></value>
        event EventHandler<CoreUI.Canvas.SceneObjectFocusInEventArgs> ObjectFocusIn;
        /// <summary>Called when object lost focus</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Canvas.SceneObjectFocusOutEventArgs"/></value>
        event EventHandler<CoreUI.Canvas.SceneObjectFocusOutEventArgs> ObjectFocusOut;
        /// <summary>Called when pre render happens</summary>
        /// <since_tizen> 6 </since_tizen>
        event EventHandler RenderPre;
        /// <summary>The maximum image size the canvas can possibly handle.
        /// 
        /// This function returns the largest image or surface size that the canvas can handle in pixels, and if there is one, returns <c>true</c>. It returns <c>false</c> if no extra constraint on maximum image size exists.
        /// 
        /// The default limit is 65535x65535.</summary>
        /// <value><c>true</c> on success, <c>false</c> otherwise</value>
        /// <since_tizen> 6 </since_tizen>
        CoreUI.DataTypes.Size2D ImageMaxSize {
            get;
        }

        /// <summary>Get if the canvas is currently calculating group objects.</summary>
        /// <value><c>true</c> if currently calculating group objects.</value>
        /// <since_tizen> 6 </since_tizen>
        bool GroupObjectsCalculating {
            get;
        }

    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.Canvas.IScene.ObjectFocusIn"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class SceneObjectFocusInEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Called when object got focus</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Input.Focus Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.Canvas.IScene.ObjectFocusOut"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class SceneObjectFocusOutEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Called when object lost focus</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Input.Focus Arg { get; set; }
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class ISceneNativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Evas)] internal static extern System.IntPtr
            efl_canvas_scene_interface_get();
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Evas);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_canvas_scene_image_max_size_get_static_delegate == null)
            {
                efl_canvas_scene_image_max_size_get_static_delegate = new efl_canvas_scene_image_max_size_get_delegate(image_max_size_get);
            }

            if (methods.Contains("GetImageMaxSize"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_scene_image_max_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_scene_image_max_size_get_static_delegate) });
            }

            if (efl_canvas_scene_group_objects_calculating_get_static_delegate == null)
            {
                efl_canvas_scene_group_objects_calculating_get_static_delegate = new efl_canvas_scene_group_objects_calculating_get_delegate(group_objects_calculating_get);
            }

            if (methods.Contains("GetGroupObjectsCalculating"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_scene_group_objects_calculating_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_scene_group_objects_calculating_get_static_delegate) });
            }

            if (efl_canvas_scene_group_objects_calculate_static_delegate == null)
            {
                efl_canvas_scene_group_objects_calculate_static_delegate = new efl_canvas_scene_group_objects_calculate_delegate(group_objects_calculate);
            }

            if (methods.Contains("CalculateGroupObjects"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_scene_group_objects_calculate"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_scene_group_objects_calculate_static_delegate) });
            }

            if (efl_canvas_scene_objects_at_xy_get_static_delegate == null)
            {
                efl_canvas_scene_objects_at_xy_get_static_delegate = new efl_canvas_scene_objects_at_xy_get_delegate(objects_at_xy_get);
            }

            if (methods.Contains("GetObjectsAtXy"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_scene_objects_at_xy_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_scene_objects_at_xy_get_static_delegate) });
            }

            if (efl_canvas_scene_object_top_at_xy_get_static_delegate == null)
            {
                efl_canvas_scene_object_top_at_xy_get_static_delegate = new efl_canvas_scene_object_top_at_xy_get_delegate(object_top_at_xy_get);
            }

            if (methods.Contains("GetObjectTopAtXy"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_scene_object_top_at_xy_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_scene_object_top_at_xy_get_static_delegate) });
            }

            if (efl_canvas_scene_objects_in_rectangle_get_static_delegate == null)
            {
                efl_canvas_scene_objects_in_rectangle_get_static_delegate = new efl_canvas_scene_objects_in_rectangle_get_delegate(objects_in_rectangle_get);
            }

            if (methods.Contains("GetObjectsInRectangle"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_scene_objects_in_rectangle_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_scene_objects_in_rectangle_get_static_delegate) });
            }

            if (efl_canvas_scene_object_top_in_rectangle_get_static_delegate == null)
            {
                efl_canvas_scene_object_top_in_rectangle_get_static_delegate = new efl_canvas_scene_object_top_in_rectangle_get_delegate(object_top_in_rectangle_get);
            }

            if (methods.Contains("GetObjectTopInRectangle"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_scene_object_top_in_rectangle_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_scene_object_top_in_rectangle_get_static_delegate) });
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
            return efl_canvas_scene_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_scene_image_max_size_get_delegate(System.IntPtr obj, System.IntPtr pd,  out CoreUI.DataTypes.Size2D max);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_canvas_scene_image_max_size_get_api_delegate(System.IntPtr obj,  out CoreUI.DataTypes.Size2D max);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_scene_image_max_size_get_api_delegate> efl_canvas_scene_image_max_size_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_scene_image_max_size_get_api_delegate>(Module, "efl_canvas_scene_image_max_size_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool image_max_size_get(System.IntPtr obj, System.IntPtr pd, out CoreUI.DataTypes.Size2D max)
        {
            CoreUI.DataTypes.Log.Debug("function efl_canvas_scene_image_max_size_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Size2D _out_max = default(CoreUI.DataTypes.Size2D);
bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IScene)ws.Target).GetImageMaxSize(out _out_max);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

        max = _out_max;
        return _ret_var;
            }
            else
            {
                return efl_canvas_scene_image_max_size_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out max);
            }
        }

        private static efl_canvas_scene_image_max_size_get_delegate efl_canvas_scene_image_max_size_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_canvas_scene_group_objects_calculating_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_canvas_scene_group_objects_calculating_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_scene_group_objects_calculating_get_api_delegate> efl_canvas_scene_group_objects_calculating_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_scene_group_objects_calculating_get_api_delegate>(Module, "efl_canvas_scene_group_objects_calculating_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool group_objects_calculating_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_canvas_scene_group_objects_calculating_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IScene)ws.Target).GetGroupObjectsCalculating();
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
                return efl_canvas_scene_group_objects_calculating_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_canvas_scene_group_objects_calculating_get_delegate efl_canvas_scene_group_objects_calculating_get_static_delegate;

        
        private delegate void efl_canvas_scene_group_objects_calculate_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate void efl_canvas_scene_group_objects_calculate_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_scene_group_objects_calculate_api_delegate> efl_canvas_scene_group_objects_calculate_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_scene_group_objects_calculate_api_delegate>(Module, "efl_canvas_scene_group_objects_calculate");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void group_objects_calculate(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_canvas_scene_group_objects_calculate was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IScene)ws.Target).CalculateGroupObjects();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_canvas_scene_group_objects_calculate_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_canvas_scene_group_objects_calculate_delegate efl_canvas_scene_group_objects_calculate_static_delegate;

        
        private delegate System.IntPtr efl_canvas_scene_objects_at_xy_get_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.DataTypes.Position2D pos, [MarshalAs(UnmanagedType.U1)] bool include_pass_events_objects, [MarshalAs(UnmanagedType.U1)] bool include_hidden_objects);

        
        internal delegate System.IntPtr efl_canvas_scene_objects_at_xy_get_api_delegate(System.IntPtr obj,  CoreUI.DataTypes.Position2D pos, [MarshalAs(UnmanagedType.U1)] bool include_pass_events_objects, [MarshalAs(UnmanagedType.U1)] bool include_hidden_objects);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_scene_objects_at_xy_get_api_delegate> efl_canvas_scene_objects_at_xy_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_scene_objects_at_xy_get_api_delegate>(Module, "efl_canvas_scene_objects_at_xy_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static System.IntPtr objects_at_xy_get(System.IntPtr obj, System.IntPtr pd, CoreUI.DataTypes.Position2D pos, bool include_pass_events_objects, bool include_hidden_objects)
        {
            CoreUI.DataTypes.Log.Debug("function efl_canvas_scene_objects_at_xy_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Position2D _in_pos = pos;
IEnumerable<CoreUI.Gfx.IEntity> _ret_var = null;
                try
                {
                    _ret_var = ((IScene)ws.Target).GetObjectsAtXy(_in_pos, include_pass_events_objects, include_hidden_objects);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return CoreUI.Wrapper.Globals.IEnumerableToIterator(_ret_var, true);
            }
            else
            {
                return efl_canvas_scene_objects_at_xy_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), pos, include_pass_events_objects, include_hidden_objects);
            }
        }

        private static efl_canvas_scene_objects_at_xy_get_delegate efl_canvas_scene_objects_at_xy_get_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
        private delegate CoreUI.Gfx.IEntity efl_canvas_scene_object_top_at_xy_get_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.DataTypes.Position2D pos, [MarshalAs(UnmanagedType.U1)] bool include_pass_events_objects, [MarshalAs(UnmanagedType.U1)] bool include_hidden_objects);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
        internal delegate CoreUI.Gfx.IEntity efl_canvas_scene_object_top_at_xy_get_api_delegate(System.IntPtr obj,  CoreUI.DataTypes.Position2D pos, [MarshalAs(UnmanagedType.U1)] bool include_pass_events_objects, [MarshalAs(UnmanagedType.U1)] bool include_hidden_objects);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_scene_object_top_at_xy_get_api_delegate> efl_canvas_scene_object_top_at_xy_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_scene_object_top_at_xy_get_api_delegate>(Module, "efl_canvas_scene_object_top_at_xy_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.Gfx.IEntity object_top_at_xy_get(System.IntPtr obj, System.IntPtr pd, CoreUI.DataTypes.Position2D pos, bool include_pass_events_objects, bool include_hidden_objects)
        {
            CoreUI.DataTypes.Log.Debug("function efl_canvas_scene_object_top_at_xy_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Position2D _in_pos = pos;
CoreUI.Gfx.IEntity _ret_var = default(CoreUI.Gfx.IEntity);
                try
                {
                    _ret_var = ((IScene)ws.Target).GetObjectTopAtXy(_in_pos, include_pass_events_objects, include_hidden_objects);
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
                return efl_canvas_scene_object_top_at_xy_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), pos, include_pass_events_objects, include_hidden_objects);
            }
        }

        private static efl_canvas_scene_object_top_at_xy_get_delegate efl_canvas_scene_object_top_at_xy_get_static_delegate;

        
        private delegate System.IntPtr efl_canvas_scene_objects_in_rectangle_get_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.DataTypes.Rect rect, [MarshalAs(UnmanagedType.U1)] bool include_pass_events_objects, [MarshalAs(UnmanagedType.U1)] bool include_hidden_objects);

        
        internal delegate System.IntPtr efl_canvas_scene_objects_in_rectangle_get_api_delegate(System.IntPtr obj,  CoreUI.DataTypes.Rect rect, [MarshalAs(UnmanagedType.U1)] bool include_pass_events_objects, [MarshalAs(UnmanagedType.U1)] bool include_hidden_objects);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_scene_objects_in_rectangle_get_api_delegate> efl_canvas_scene_objects_in_rectangle_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_scene_objects_in_rectangle_get_api_delegate>(Module, "efl_canvas_scene_objects_in_rectangle_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static System.IntPtr objects_in_rectangle_get(System.IntPtr obj, System.IntPtr pd, CoreUI.DataTypes.Rect rect, bool include_pass_events_objects, bool include_hidden_objects)
        {
            CoreUI.DataTypes.Log.Debug("function efl_canvas_scene_objects_in_rectangle_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Rect _in_rect = rect;
IEnumerable<CoreUI.Gfx.IEntity> _ret_var = null;
                try
                {
                    _ret_var = ((IScene)ws.Target).GetObjectsInRectangle(_in_rect, include_pass_events_objects, include_hidden_objects);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return CoreUI.Wrapper.Globals.IEnumerableToIterator(_ret_var, true);
            }
            else
            {
                return efl_canvas_scene_objects_in_rectangle_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), rect, include_pass_events_objects, include_hidden_objects);
            }
        }

        private static efl_canvas_scene_objects_in_rectangle_get_delegate efl_canvas_scene_objects_in_rectangle_get_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
        private delegate CoreUI.Gfx.IEntity efl_canvas_scene_object_top_in_rectangle_get_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.DataTypes.Rect rect, [MarshalAs(UnmanagedType.U1)] bool include_pass_events_objects, [MarshalAs(UnmanagedType.U1)] bool include_hidden_objects);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
        internal delegate CoreUI.Gfx.IEntity efl_canvas_scene_object_top_in_rectangle_get_api_delegate(System.IntPtr obj,  CoreUI.DataTypes.Rect rect, [MarshalAs(UnmanagedType.U1)] bool include_pass_events_objects, [MarshalAs(UnmanagedType.U1)] bool include_hidden_objects);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_scene_object_top_in_rectangle_get_api_delegate> efl_canvas_scene_object_top_in_rectangle_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_scene_object_top_in_rectangle_get_api_delegate>(Module, "efl_canvas_scene_object_top_in_rectangle_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.Gfx.IEntity object_top_in_rectangle_get(System.IntPtr obj, System.IntPtr pd, CoreUI.DataTypes.Rect rect, bool include_pass_events_objects, bool include_hidden_objects)
        {
            CoreUI.DataTypes.Log.Debug("function efl_canvas_scene_object_top_in_rectangle_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Rect _in_rect = rect;
CoreUI.Gfx.IEntity _ret_var = default(CoreUI.Gfx.IEntity);
                try
                {
                    _ret_var = ((IScene)ws.Target).GetObjectTopInRectangle(_in_rect, include_pass_events_objects, include_hidden_objects);
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
                return efl_canvas_scene_object_top_in_rectangle_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), rect, include_pass_events_objects, include_hidden_objects);
            }
        }

        private static efl_canvas_scene_object_top_in_rectangle_get_delegate efl_canvas_scene_object_top_in_rectangle_get_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

