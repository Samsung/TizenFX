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
namespace CoreUI.UI.PositionManager {
    /// <summary>This abstracts the basic placement of items in a not-defined form under a viewport.
    /// 
    /// The interface gets a defined set of elements that is meant to be displayed. The implementation provides a way to calculate the size that is required to display all items. Every time this absolute size of items is changed, <see cref="CoreUI.UI.PositionManager.IEntity.ContentSizeChanged"/> is emitted.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.PositionManager.IEntityNativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface IEntity : 
    CoreUI.UI.ILayoutOrientable,
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>This is the position and size of the viewport, where elements are displayed in. Entities outside this viewport will not be shown.</summary>
        /// <since_tizen> 6 </since_tizen>
        void SetViewport(CoreUI.DataTypes.Rect viewport);

        /// <summary>Move the items relative to the viewport.
        /// 
        /// The items that are managed with this position manager might be bigger than the actual viewport. The positioning of the layer where all items are on is described by these values. 0.0,0.0 means that layer is moved that the top left items are shown, 1.0,1.0 means, that the lower right items are shown.</summary>
        /// <param name="x">X position of the scroller, valid form 0 to 1.0</param>
        /// <param name="y">Y position of the scroller, valid form 0 to 1.0</param>
        /// <since_tizen> 6 </since_tizen>
        void SetScrollPosition(double x, double y);

        /// <summary>Returns the version of Data_Access that is used. This object needs to implement the interface <see cref="CoreUI.UI.PositionManager.IDataAccessV1"/> if 1 is returned.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="max">The maximum version that is available from the data-provider.</param>
        /// <returns>The version that should be used here. 0 is an error.</returns>
        int Version(int max);

        /// <summary>Return the position and size of item idx.
        /// 
        /// This method returns the size and position of the item at <c>idx</c>. Even if the item is outside the viewport, the returned rectangle must be valid. The result can be used for scrolling calculations.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="idx">The id for the item</param>
        /// <returns>Position and Size in canvas coordinates.</returns>
        CoreUI.DataTypes.Rect PositionSingleItem(int idx);

        /// <summary>The new item <c>subobj</c> has been added at the <c>added_index</c> field.
        /// 
        /// The accessor provided through <see cref="CoreUI.UI.PositionManager.IDataAccessV1.SetDataAccess"/> will contain updated Entities.</summary>
        /// <since_tizen> 6 </since_tizen>
        void ItemAdded(int added_index, CoreUI.Gfx.IEntity subobj);

        /// <summary>The item <c>subobj</c> previously at position <c>removed_index</c> has been removed. The accessor provided through <see cref="CoreUI.UI.PositionManager.IDataAccessV1.SetDataAccess"/> will contain updated Entities.</summary>
        /// <since_tizen> 6 </since_tizen>
        void ItemRemoved(int removed_index, CoreUI.Gfx.IEntity subobj);

        /// <summary>The size of the items from <c>start_id</c> to <c>end_id</c> have been changed. The positioning and sizing of all items will be updated</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="start_id">The first item that has a new size</param>
        /// <param name="end_id">The last item that has a new size</param>
        void ItemSizeChanged(int start_id, int end_id);

        /// <summary>The items from <c>start_id</c> to <c>end_id</c> now have their entities ready
        /// 
        /// The position manager will reapply the geometry to the elements if they are visible.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="start_id">The first item that is available</param>
        /// <param name="end_id">The last item that is available</param>
        void EntitiesReady(uint start_id, uint end_id);

        /// <summary>Translates the <c>current_id</c>, into a new id which is oriented in the <c>direction</c> of <c>current_id</c>. In case that there is no item, -1 is returned</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="current_id">The id where the direction is oriented at</param>
        /// <param name="direction">The direction where the new id is</param>
        /// <param name="index">The relative item index after the translation has been applied.</param>
        /// <returns><c>true</c> if there is a next item, <c>false</c> otherwise.</returns>
        bool RelativeItem(uint current_id, CoreUI.UI.Focus.Direction direction, out uint index);

        /// <summary>Emitted when the aggregate size of all items has changed. This can be used to resize an enclosing Pan object.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.PositionManager.EntityContentSizeChangedEventArgs"/></value>
        event EventHandler<CoreUI.UI.PositionManager.EntityContentSizeChangedEventArgs> ContentSizeChanged;
        /// <summary>Emitted when the minimum size of all items has changed. The minimum size is the size that this position_manager needs to display a single item.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.PositionManager.EntityContentMinSizeChangedEventArgs"/></value>
        event EventHandler<CoreUI.UI.PositionManager.EntityContentMinSizeChangedEventArgs> ContentMinSizeChanged;
        /// <value><see cref="CoreUI.UI.PositionManager.EntityVisibleRangeChangedEventArgs"/></value>
        event EventHandler<CoreUI.UI.PositionManager.EntityVisibleRangeChangedEventArgs> VisibleRangeChanged;
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.UI.PositionManager.IEntity.ContentSizeChanged"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class EntityContentSizeChangedEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Emitted when the aggregate size of all items has changed. This can be used to resize an enclosing Pan object.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Size2D Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.UI.PositionManager.IEntity.ContentMinSizeChanged"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class EntityContentMinSizeChangedEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Emitted when the minimum size of all items has changed. The minimum size is the size that this position_manager needs to display a single item.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Size2D Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.UI.PositionManager.IEntity.VisibleRangeChanged"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class EntityVisibleRangeChangedEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value></value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.UI.PositionManager.RangeUpdate Arg { get; set; }
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IEntityNativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Elementary)] internal static extern System.IntPtr
            efl_ui_position_manager_entity_interface_get();
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Elementary);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_ui_position_manager_entity_viewport_set_static_delegate == null)
            {
                efl_ui_position_manager_entity_viewport_set_static_delegate = new efl_ui_position_manager_entity_viewport_set_delegate(viewport_set);
            }

            if (methods.Contains("SetViewport"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_position_manager_entity_viewport_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_position_manager_entity_viewport_set_static_delegate) });
            }

            if (efl_ui_position_manager_entity_scroll_position_set_static_delegate == null)
            {
                efl_ui_position_manager_entity_scroll_position_set_static_delegate = new efl_ui_position_manager_entity_scroll_position_set_delegate(scroll_position_set);
            }

            if (methods.Contains("SetScrollPosition"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_position_manager_entity_scroll_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_position_manager_entity_scroll_position_set_static_delegate) });
            }

            if (efl_ui_position_manager_entity_version_static_delegate == null)
            {
                efl_ui_position_manager_entity_version_static_delegate = new efl_ui_position_manager_entity_version_delegate(version);
            }

            if (methods.Contains("Version"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_position_manager_entity_version"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_position_manager_entity_version_static_delegate) });
            }

            if (efl_ui_position_manager_entity_position_single_item_static_delegate == null)
            {
                efl_ui_position_manager_entity_position_single_item_static_delegate = new efl_ui_position_manager_entity_position_single_item_delegate(position_single_item);
            }

            if (methods.Contains("PositionSingleItem"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_position_manager_entity_position_single_item"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_position_manager_entity_position_single_item_static_delegate) });
            }

            if (efl_ui_position_manager_entity_item_added_static_delegate == null)
            {
                efl_ui_position_manager_entity_item_added_static_delegate = new efl_ui_position_manager_entity_item_added_delegate(item_added);
            }

            if (methods.Contains("ItemAdded"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_position_manager_entity_item_added"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_position_manager_entity_item_added_static_delegate) });
            }

            if (efl_ui_position_manager_entity_item_removed_static_delegate == null)
            {
                efl_ui_position_manager_entity_item_removed_static_delegate = new efl_ui_position_manager_entity_item_removed_delegate(item_removed);
            }

            if (methods.Contains("ItemRemoved"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_position_manager_entity_item_removed"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_position_manager_entity_item_removed_static_delegate) });
            }

            if (efl_ui_position_manager_entity_item_size_changed_static_delegate == null)
            {
                efl_ui_position_manager_entity_item_size_changed_static_delegate = new efl_ui_position_manager_entity_item_size_changed_delegate(item_size_changed);
            }

            if (methods.Contains("ItemSizeChanged"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_position_manager_entity_item_size_changed"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_position_manager_entity_item_size_changed_static_delegate) });
            }

            if (efl_ui_position_manager_entity_entities_ready_static_delegate == null)
            {
                efl_ui_position_manager_entity_entities_ready_static_delegate = new efl_ui_position_manager_entity_entities_ready_delegate(entities_ready);
            }

            if (methods.Contains("EntitiesReady"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_position_manager_entity_entities_ready"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_position_manager_entity_entities_ready_static_delegate) });
            }

            if (efl_ui_position_manager_entity_relative_item_static_delegate == null)
            {
                efl_ui_position_manager_entity_relative_item_static_delegate = new efl_ui_position_manager_entity_relative_item_delegate(relative_item);
            }

            if (methods.Contains("RelativeItem"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_position_manager_entity_relative_item"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_position_manager_entity_relative_item_static_delegate) });
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
            return efl_ui_position_manager_entity_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_ui_position_manager_entity_viewport_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.DataTypes.Rect viewport);

        
        internal delegate void efl_ui_position_manager_entity_viewport_set_api_delegate(System.IntPtr obj,  CoreUI.DataTypes.Rect viewport);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_position_manager_entity_viewport_set_api_delegate> efl_ui_position_manager_entity_viewport_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_position_manager_entity_viewport_set_api_delegate>(Module, "efl_ui_position_manager_entity_viewport_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void viewport_set(System.IntPtr obj, System.IntPtr pd, CoreUI.DataTypes.Rect viewport)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_position_manager_entity_viewport_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Rect _in_viewport = viewport;

                try
                {
                    ((IEntity)ws.Target).SetViewport(_in_viewport);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_position_manager_entity_viewport_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), viewport);
            }
        }

        private static efl_ui_position_manager_entity_viewport_set_delegate efl_ui_position_manager_entity_viewport_set_static_delegate;

        
        private delegate void efl_ui_position_manager_entity_scroll_position_set_delegate(System.IntPtr obj, System.IntPtr pd,  double x,  double y);

        
        internal delegate void efl_ui_position_manager_entity_scroll_position_set_api_delegate(System.IntPtr obj,  double x,  double y);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_position_manager_entity_scroll_position_set_api_delegate> efl_ui_position_manager_entity_scroll_position_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_position_manager_entity_scroll_position_set_api_delegate>(Module, "efl_ui_position_manager_entity_scroll_position_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void scroll_position_set(System.IntPtr obj, System.IntPtr pd, double x, double y)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_position_manager_entity_scroll_position_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IEntity)ws.Target).SetScrollPosition(x, y);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_position_manager_entity_scroll_position_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), x, y);
            }
        }

        private static efl_ui_position_manager_entity_scroll_position_set_delegate efl_ui_position_manager_entity_scroll_position_set_static_delegate;

        
        private delegate int efl_ui_position_manager_entity_version_delegate(System.IntPtr obj, System.IntPtr pd,  int max);

        
        internal delegate int efl_ui_position_manager_entity_version_api_delegate(System.IntPtr obj,  int max);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_position_manager_entity_version_api_delegate> efl_ui_position_manager_entity_version_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_position_manager_entity_version_api_delegate>(Module, "efl_ui_position_manager_entity_version");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static int version(System.IntPtr obj, System.IntPtr pd, int max)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_position_manager_entity_version was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                int _ret_var = default(int);
                try
                {
                    _ret_var = ((IEntity)ws.Target).Version(max);
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
                return efl_ui_position_manager_entity_version_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), max);
            }
        }

        private static efl_ui_position_manager_entity_version_delegate efl_ui_position_manager_entity_version_static_delegate;

        
        private delegate CoreUI.DataTypes.Rect efl_ui_position_manager_entity_position_single_item_delegate(System.IntPtr obj, System.IntPtr pd,  int idx);

        
        internal delegate CoreUI.DataTypes.Rect efl_ui_position_manager_entity_position_single_item_api_delegate(System.IntPtr obj,  int idx);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_position_manager_entity_position_single_item_api_delegate> efl_ui_position_manager_entity_position_single_item_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_position_manager_entity_position_single_item_api_delegate>(Module, "efl_ui_position_manager_entity_position_single_item");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.DataTypes.Rect position_single_item(System.IntPtr obj, System.IntPtr pd, int idx)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_position_manager_entity_position_single_item was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.DataTypes.Rect _ret_var = default(CoreUI.DataTypes.Rect);
                try
                {
                    _ret_var = ((IEntity)ws.Target).PositionSingleItem(idx);
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
                return efl_ui_position_manager_entity_position_single_item_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), idx);
            }
        }

        private static efl_ui_position_manager_entity_position_single_item_delegate efl_ui_position_manager_entity_position_single_item_static_delegate;

        
        private delegate void efl_ui_position_manager_entity_item_added_delegate(System.IntPtr obj, System.IntPtr pd,  int added_index, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity subobj);

        
        internal delegate void efl_ui_position_manager_entity_item_added_api_delegate(System.IntPtr obj,  int added_index, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity subobj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_position_manager_entity_item_added_api_delegate> efl_ui_position_manager_entity_item_added_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_position_manager_entity_item_added_api_delegate>(Module, "efl_ui_position_manager_entity_item_added");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void item_added(System.IntPtr obj, System.IntPtr pd, int added_index, CoreUI.Gfx.IEntity subobj)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_position_manager_entity_item_added was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IEntity)ws.Target).ItemAdded(added_index, subobj);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_position_manager_entity_item_added_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), added_index, subobj);
            }
        }

        private static efl_ui_position_manager_entity_item_added_delegate efl_ui_position_manager_entity_item_added_static_delegate;

        
        private delegate void efl_ui_position_manager_entity_item_removed_delegate(System.IntPtr obj, System.IntPtr pd,  int removed_index, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity subobj);

        
        internal delegate void efl_ui_position_manager_entity_item_removed_api_delegate(System.IntPtr obj,  int removed_index, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity subobj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_position_manager_entity_item_removed_api_delegate> efl_ui_position_manager_entity_item_removed_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_position_manager_entity_item_removed_api_delegate>(Module, "efl_ui_position_manager_entity_item_removed");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void item_removed(System.IntPtr obj, System.IntPtr pd, int removed_index, CoreUI.Gfx.IEntity subobj)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_position_manager_entity_item_removed was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IEntity)ws.Target).ItemRemoved(removed_index, subobj);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_position_manager_entity_item_removed_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), removed_index, subobj);
            }
        }

        private static efl_ui_position_manager_entity_item_removed_delegate efl_ui_position_manager_entity_item_removed_static_delegate;

        
        private delegate void efl_ui_position_manager_entity_item_size_changed_delegate(System.IntPtr obj, System.IntPtr pd,  int start_id,  int end_id);

        
        internal delegate void efl_ui_position_manager_entity_item_size_changed_api_delegate(System.IntPtr obj,  int start_id,  int end_id);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_position_manager_entity_item_size_changed_api_delegate> efl_ui_position_manager_entity_item_size_changed_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_position_manager_entity_item_size_changed_api_delegate>(Module, "efl_ui_position_manager_entity_item_size_changed");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void item_size_changed(System.IntPtr obj, System.IntPtr pd, int start_id, int end_id)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_position_manager_entity_item_size_changed was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IEntity)ws.Target).ItemSizeChanged(start_id, end_id);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_position_manager_entity_item_size_changed_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), start_id, end_id);
            }
        }

        private static efl_ui_position_manager_entity_item_size_changed_delegate efl_ui_position_manager_entity_item_size_changed_static_delegate;

        
        private delegate void efl_ui_position_manager_entity_entities_ready_delegate(System.IntPtr obj, System.IntPtr pd,  uint start_id,  uint end_id);

        
        internal delegate void efl_ui_position_manager_entity_entities_ready_api_delegate(System.IntPtr obj,  uint start_id,  uint end_id);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_position_manager_entity_entities_ready_api_delegate> efl_ui_position_manager_entity_entities_ready_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_position_manager_entity_entities_ready_api_delegate>(Module, "efl_ui_position_manager_entity_entities_ready");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void entities_ready(System.IntPtr obj, System.IntPtr pd, uint start_id, uint end_id)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_position_manager_entity_entities_ready was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IEntity)ws.Target).EntitiesReady(start_id, end_id);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_position_manager_entity_entities_ready_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), start_id, end_id);
            }
        }

        private static efl_ui_position_manager_entity_entities_ready_delegate efl_ui_position_manager_entity_entities_ready_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_ui_position_manager_entity_relative_item_delegate(System.IntPtr obj, System.IntPtr pd,  uint current_id,  CoreUI.UI.Focus.Direction direction,  out uint index);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_ui_position_manager_entity_relative_item_api_delegate(System.IntPtr obj,  uint current_id,  CoreUI.UI.Focus.Direction direction,  out uint index);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_position_manager_entity_relative_item_api_delegate> efl_ui_position_manager_entity_relative_item_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_position_manager_entity_relative_item_api_delegate>(Module, "efl_ui_position_manager_entity_relative_item");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool relative_item(System.IntPtr obj, System.IntPtr pd, uint current_id, CoreUI.UI.Focus.Direction direction, out uint index)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_position_manager_entity_relative_item was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                index = default(uint);bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IEntity)ws.Target).RelativeItem(current_id, direction, out index);
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
                return efl_ui_position_manager_entity_relative_item_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), current_id, direction, out index);
            }
        }

        private static efl_ui_position_manager_entity_relative_item_delegate efl_ui_position_manager_entity_relative_item_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

namespace CoreUI.UI.PositionManager {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class EntityExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.DataTypes.Rect> Viewport<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.PositionManager.IEntity, T>magic = null) where T : CoreUI.UI.PositionManager.IEntity {
            return new CoreUI.BindableProperty<CoreUI.DataTypes.Rect>("viewport", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.UI.LayoutOrientation> Orientation<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.PositionManager.IEntity, T>magic = null) where T : CoreUI.UI.PositionManager.IEntity {
            return new CoreUI.BindableProperty<CoreUI.UI.LayoutOrientation>("orientation", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

namespace CoreUI.UI.PositionManager {
    /// <summary>A structure containing the updated range of visible items in this position manger.</summary>
    /// <since_tizen> 6 </since_tizen>
    [StructLayout(LayoutKind.Sequential)]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public struct RangeUpdate : IEquatable<RangeUpdate>
    {
        
        private uint startId;
        
        private uint endId;

        /// <summary>The first item that is visible</summary>
        /// <since_tizen> 6 </since_tizen>
        public uint StartId { get => startId; }
        /// <summary>The last item that is visible</summary>
        /// <since_tizen> 6 </since_tizen>
        public uint EndId { get => endId; }
        /// <summary>Constructor for RangeUpdate.
        /// </summary>
        /// <param name="startId">The first item that is visible</param>
        /// <param name="endId">The last item that is visible</param>
        /// <since_tizen> 6 </since_tizen>
        public RangeUpdate(
            uint startId = default(uint),
            uint endId = default(uint))
        {
            this.startId = startId;
            this.endId = endId;
        }

        /// <summary>Packs tuple into RangeUpdate object.
        ///<para>Since EFL 1.24.</para>
        ///</summary>
        public static implicit operator RangeUpdate((uint startId, uint endId) tuple)
            => new RangeUpdate(tuple.startId, tuple.endId);

        /// <summary>Unpacks RangeUpdate into tuple.
        /// <para>Since EFL 1.24.</para>
        /// </summary>
        public void Deconstruct(
            out uint startId,
            out uint endId
        )
        {
            startId = this.StartId;
            endId = this.EndId;
        }
        /// <summary>Get a hash code for this item.
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + StartId.GetHashCode();
            hash = hash * 23 + EndId.GetHashCode();
            return hash;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public bool Equals(RangeUpdate other)
        {
            return StartId == other.StartId && EndId == other.EndId;
        }
        /// <summary>Equality comparison.
        /// </summary>
        public override bool Equals(object other)
            => ((other is RangeUpdate) ? Equals((RangeUpdate)other) : false);
        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator ==(RangeUpdate lhs, RangeUpdate rhs)
            => lhs.Equals(rhs);        /// <summary>Equality comparison.
        /// </summary>
        public static bool operator !=(RangeUpdate lhs, RangeUpdate rhs)
            => !lhs.Equals(rhs);        /// <summary>Implicit conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static implicit operator RangeUpdate(IntPtr ptr)
        {
            return (RangeUpdate)Marshal.PtrToStructure(ptr, typeof(RangeUpdate));
        }

        /// <summary>Conversion to the managed representation from a native pointer.
        /// </summary>
        /// <param name="ptr">Native pointer to be converted.</param>
        public static RangeUpdate FromIntPtr(IntPtr ptr)
        {
            return ptr;
        }

    }

}

