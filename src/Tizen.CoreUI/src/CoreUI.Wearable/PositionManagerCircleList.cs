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
namespace CoreUI.Wearable.PositionManager {
    /// <summary>Implementation of <see cref="CoreUI.UI.PositionManager.IEntity"/> for a circle list
    /// 
    /// Every item in the list will get at least his minsize applied, changes to the misize are listened to and change the layout of all items. This supports the vertical and horizontal orientation.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wearable.PositionManager.CircleList.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public class CircleList : CoreUI.Object, CoreUI.UI.ILayoutOrientable, CoreUI.UI.PositionManager.IDataAccessV1, CoreUI.UI.PositionManager.IEntity
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(CircleList))
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
            efl_wearable_position_manager_circle_list_class_get();

        /// <summary>Initializes a new instance of the <see cref="CircleList"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
        public CircleList(CoreUI.Object parent= null) : base(efl_wearable_position_manager_circle_list_class_get(), parent)
        {
            FinishInstantiation();
        }

        /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
        /// Do not call this constructor directly.
        /// </summary>
        /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
        protected CircleList(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="CircleList"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal CircleList(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="CircleList"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected CircleList(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }


        /// <summary>Emitted when the aggregate size of all items has changed. This can be used to resize an enclosing Pan object.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.PositionManager.EntityContentSizeChangedEventArgs"/></value>
        public event EventHandler<CoreUI.UI.PositionManager.EntityContentSizeChangedEventArgs> ContentSizeChanged
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.PositionManager.EntityContentSizeChangedEventArgs{ Arg =  info });
                string key = "_EFL_UI_POSITION_MANAGER_ENTITY_EVENT_CONTENT_SIZE_CHANGED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_POSITION_MANAGER_ENTITY_EVENT_CONTENT_SIZE_CHANGED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event ContentSizeChanged.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnContentSizeChanged(CoreUI.UI.PositionManager.EntityContentSizeChangedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.Arg));
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_POSITION_MANAGER_ENTITY_EVENT_CONTENT_SIZE_CHANGED", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Emitted when the minimum size of all items has changed. The minimum size is the size that this position_manager needs to display a single item.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.PositionManager.EntityContentMinSizeChangedEventArgs"/></value>
        public event EventHandler<CoreUI.UI.PositionManager.EntityContentMinSizeChangedEventArgs> ContentMinSizeChanged
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.PositionManager.EntityContentMinSizeChangedEventArgs{ Arg =  info });
                string key = "_EFL_UI_POSITION_MANAGER_ENTITY_EVENT_CONTENT_MIN_SIZE_CHANGED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_POSITION_MANAGER_ENTITY_EVENT_CONTENT_MIN_SIZE_CHANGED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event ContentMinSizeChanged.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnContentMinSizeChanged(CoreUI.UI.PositionManager.EntityContentMinSizeChangedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.Arg));
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_POSITION_MANAGER_ENTITY_EVENT_CONTENT_MIN_SIZE_CHANGED", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <value><see cref="CoreUI.UI.PositionManager.EntityVisibleRangeChangedEventArgs"/></value>
        public event EventHandler<CoreUI.UI.PositionManager.EntityVisibleRangeChangedEventArgs> VisibleRangeChanged
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.UI.PositionManager.EntityVisibleRangeChangedEventArgs{ Arg =  info });
                string key = "_EFL_UI_POSITION_MANAGER_ENTITY_EVENT_VISIBLE_RANGE_CHANGED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_UI_POSITION_MANAGER_ENTITY_EVENT_VISIBLE_RANGE_CHANGED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event VisibleRangeChanged.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        protected virtual void OnVisibleRangeChanged(CoreUI.UI.PositionManager.EntityVisibleRangeChangedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.Arg));
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_UI_POSITION_MANAGER_ENTITY_EVENT_VISIBLE_RANGE_CHANGED", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Return the item in given position.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="pos">Position in canvas coordinates.</param>
        /// <returns>The id of the item in that position.</returns>
        public virtual int GetPositionedItem(CoreUI.DataTypes.Position2D pos) {
            CoreUI.DataTypes.Position2D _in_pos = pos;
var _ret_var = CoreUI.Wearable.PositionManager.CircleList.NativeMethods.efl_wearable_position_manager_circle_list_positioned_item_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), _in_pos);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Control the direction of a given widget.
        /// 
        /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
        /// 
        /// Mirroring as defined in <span class="text-muted">CoreUI.UI.II18n (object still in beta stage)</span> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
        /// <returns>Direction of the widget.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.UI.LayoutOrientation GetOrientation() {
            var _ret_var = CoreUI.UI.ILayoutOrientableNativeMethods.efl_ui_layout_orientation_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Control the direction of a given widget.
        /// 
        /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
        /// 
        /// Mirroring as defined in <span class="text-muted">CoreUI.UI.II18n (object still in beta stage)</span> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
        /// <param name="dir">Direction of the widget.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetOrientation(CoreUI.UI.LayoutOrientation dir) {
            CoreUI.UI.ILayoutOrientableNativeMethods.efl_ui_layout_orientation_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), dir);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>This gives access to items to be managed. The manager reads this information and modifies the retrieved items&apos; positions and sizes.
        /// 
        /// <c>obj_access</c> gives access to the graphical entities to manage. Some of them might be <c>NULL</c>, meaning they are not yet ready to be displayed. Their size in the <c>size_access</c> array will be correct, though, so other entities can still be positioned correctly. Typically, only entities inside the viewport will be retrieved.
        /// 
        /// <c>size_access</c> gives access to the 2D sizes for the items to manage. All sizes will always be valid, and might change over time (indicated through the <see cref="CoreUI.UI.PositionManager.IEntity.ItemSizeChanged"/> method). The whole range might need to be traversed in order to calculate the position of all items in some arrangements.
        /// 
        /// You can access a batch of objects or sizes by calling the here passed function callbacks. Further details can be found at the function definitions.</summary>
        /// <param name="canvas">Will use this object to freeze/thaw canvas events.</param>
        /// <param name="obj_access">Function callback for canvas objects, even if the start_id is valid, the returned objects may be <c>NULL</c>.</param>
        /// <param name="size_access">Function callback for the size, returned values are always valid, but might be changed later on.</param>
        /// <param name="size">valid size for start_id, 0 &lt;= i &lt; size</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetDataAccess(CoreUI.UI.Win canvas, CoreUI.UI.PositionManager.ObjectBatchCallback obj_access, CoreUI.UI.PositionManager.SizeBatchCallback size_access, int size) {
            GCHandle obj_access_handle = GCHandle.Alloc(obj_access);
GCHandle size_access_handle = GCHandle.Alloc(size_access);
CoreUI.UI.PositionManager.IDataAccessV1NativeMethods.efl_ui_position_manager_data_access_v1_data_access_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), canvas, GCHandle.ToIntPtr(obj_access_handle), CoreUI.UI.PositionManager.ObjectBatchCallbackWrapper.Cb, CoreUI.Wrapper.Globals.free_gchandle, GCHandle.ToIntPtr(size_access_handle), CoreUI.UI.PositionManager.SizeBatchCallbackWrapper.Cb, CoreUI.Wrapper.Globals.free_gchandle, size);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>This is the position and size of the viewport, where elements are displayed in. Entities outside this viewport will not be shown.</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetViewport(CoreUI.DataTypes.Rect viewport) {
            CoreUI.DataTypes.Rect _in_viewport = viewport;
CoreUI.UI.PositionManager.IEntityNativeMethods.efl_ui_position_manager_entity_viewport_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), _in_viewport);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Move the items relative to the viewport.
        /// 
        /// The items that are managed with this position manager might be bigger than the actual viewport. The positioning of the layer where all items are on is described by these values. 0.0,0.0 means that layer is moved that the top left items are shown, 1.0,1.0 means, that the lower right items are shown.</summary>
        /// <param name="x">X position of the scroller, valid form 0 to 1.0</param>
        /// <param name="y">Y position of the scroller, valid form 0 to 1.0</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetScrollPosition(double x, double y) {
            CoreUI.UI.PositionManager.IEntityNativeMethods.efl_ui_position_manager_entity_scroll_position_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), x, y);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Returns the version of Data_Access that is used. This object needs to implement the interface <see cref="CoreUI.UI.PositionManager.IDataAccessV1"/> if 1 is returned.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="max">The maximum version that is available from the data-provider.</param>
        /// <returns>The version that should be used here. 0 is an error.</returns>
        public virtual int Version(int max) {
            var _ret_var = CoreUI.UI.PositionManager.IEntityNativeMethods.efl_ui_position_manager_entity_version_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), max);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Return the position and size of item idx.
        /// 
        /// This method returns the size and position of the item at <c>idx</c>. Even if the item is outside the viewport, the returned rectangle must be valid. The result can be used for scrolling calculations.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="idx">The id for the item</param>
        /// <returns>Position and Size in canvas coordinates.</returns>
        public virtual CoreUI.DataTypes.Rect PositionSingleItem(int idx) {
            var _ret_var = CoreUI.UI.PositionManager.IEntityNativeMethods.efl_ui_position_manager_entity_position_single_item_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), idx);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The new item <c>subobj</c> has been added at the <c>added_index</c> field.
        /// 
        /// The accessor provided through <see cref="CoreUI.UI.PositionManager.IDataAccessV1.SetDataAccess"/> will contain updated Entities.</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void ItemAdded(int added_index, CoreUI.Gfx.IEntity subobj) {
            CoreUI.UI.PositionManager.IEntityNativeMethods.efl_ui_position_manager_entity_item_added_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), added_index, subobj);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The item <c>subobj</c> previously at position <c>removed_index</c> has been removed. The accessor provided through <see cref="CoreUI.UI.PositionManager.IDataAccessV1.SetDataAccess"/> will contain updated Entities.</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void ItemRemoved(int removed_index, CoreUI.Gfx.IEntity subobj) {
            CoreUI.UI.PositionManager.IEntityNativeMethods.efl_ui_position_manager_entity_item_removed_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), removed_index, subobj);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The size of the items from <c>start_id</c> to <c>end_id</c> have been changed. The positioning and sizing of all items will be updated</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="start_id">The first item that has a new size</param>
        /// <param name="end_id">The last item that has a new size</param>
        public virtual void ItemSizeChanged(int start_id, int end_id) {
            CoreUI.UI.PositionManager.IEntityNativeMethods.efl_ui_position_manager_entity_item_size_changed_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), start_id, end_id);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The items from <c>start_id</c> to <c>end_id</c> now have their entities ready
        /// 
        /// The position manager will reapply the geometry to the elements if they are visible.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="start_id">The first item that is available</param>
        /// <param name="end_id">The last item that is available</param>
        public virtual void EntitiesReady(uint start_id, uint end_id) {
            CoreUI.UI.PositionManager.IEntityNativeMethods.efl_ui_position_manager_entity_entities_ready_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), start_id, end_id);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Translates the <c>current_id</c>, into a new id which is oriented in the <c>direction</c> of <c>current_id</c>. In case that there is no item, -1 is returned</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="current_id">The id where the direction is oriented at</param>
        /// <param name="direction">The direction where the new id is</param>
        /// <param name="index">The relative item index after the translation has been applied.</param>
        /// <returns><c>true</c> if there is a next item, <c>false</c> otherwise.</returns>
        public virtual bool RelativeItem(uint current_id, CoreUI.UI.Focus.Direction direction, out uint index) {
            var _ret_var = CoreUI.UI.PositionManager.IEntityNativeMethods.efl_ui_position_manager_entity_relative_item_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), current_id, direction, out index);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Control the direction of a given widget.
        /// 
        /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
        /// 
        /// Mirroring as defined in <span class="text-muted">CoreUI.UI.II18n (object still in beta stage)</span> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
        /// <value>Direction of the widget.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.UI.LayoutOrientation Orientation {
            get { return GetOrientation(); }
            set { SetOrientation(value); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.Wearable.PositionManager.CircleList.efl_wearable_position_manager_circle_list_class_get();
        }

        /// <summary>Wrapper for native methods and virtual method delegates.
        /// For internal use by generated code only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new class NativeMethods : CoreUI.Object.NativeMethods
        {
            private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Elementary);

            /// <summary>Gets the list of Eo operations to override.
        /// </summary>
            /// <returns>The list of Eo operations to be overload.</returns>
            internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
            {
                var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
                var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

                if (efl_wearable_position_manager_circle_list_positioned_item_get_static_delegate == null)
                {
                    efl_wearable_position_manager_circle_list_positioned_item_get_static_delegate = new efl_wearable_position_manager_circle_list_positioned_item_get_delegate(positioned_item_get);
                }

                if (methods.Contains("GetPositionedItem"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_wearable_position_manager_circle_list_positioned_item_get"), func = Marshal.GetFunctionPointerForDelegate(efl_wearable_position_manager_circle_list_positioned_item_get_static_delegate) });
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
                return CoreUI.Wearable.PositionManager.CircleList.efl_wearable_position_manager_circle_list_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            
            private delegate int efl_wearable_position_manager_circle_list_positioned_item_get_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.DataTypes.Position2D pos);

            
            internal delegate int efl_wearable_position_manager_circle_list_positioned_item_get_api_delegate(System.IntPtr obj,  CoreUI.DataTypes.Position2D pos);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_wearable_position_manager_circle_list_positioned_item_get_api_delegate> efl_wearable_position_manager_circle_list_positioned_item_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_wearable_position_manager_circle_list_positioned_item_get_api_delegate>(Module, "efl_wearable_position_manager_circle_list_positioned_item_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static int positioned_item_get(System.IntPtr obj, System.IntPtr pd, CoreUI.DataTypes.Position2D pos)
            {
                CoreUI.DataTypes.Log.Debug("function efl_wearable_position_manager_circle_list_positioned_item_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.DataTypes.Position2D _in_pos = pos;
int _ret_var = default(int);
                    try
                    {
                        _ret_var = ((CircleList)ws.Target).GetPositionedItem(_in_pos);
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
                    return efl_wearable_position_manager_circle_list_positioned_item_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), pos);
                }
            }

            private static efl_wearable_position_manager_circle_list_positioned_item_get_delegate efl_wearable_position_manager_circle_list_positioned_item_get_static_delegate;

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

namespace CoreUI.Wearable.PositionManager {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class CircleListExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.UI.LayoutOrientation> Orientation<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Wearable.PositionManager.CircleList, T>magic = null) where T : CoreUI.Wearable.PositionManager.CircleList {
            return new CoreUI.BindableProperty<CoreUI.UI.LayoutOrientation>("orientation", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.DataTypes.Rect> Viewport<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Wearable.PositionManager.CircleList, T>magic = null) where T : CoreUI.Wearable.PositionManager.CircleList {
            return new CoreUI.BindableProperty<CoreUI.DataTypes.Rect>("viewport", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

