#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

namespace Ui {

namespace PositionManager {

/// <summary>Implementation of <see cref="Efl.Ui.PositionManager.IEntity"/> for two-dimensional grids.
/// Every item in the grid has the same size, which is the biggest minimum size of all items.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.PositionManager.Grid.NativeMethods]
[Efl.Eo.BindingEntity]
public class Grid : Efl.Object, Efl.Ui.ILayoutOrientable, Efl.Ui.PositionManager.IDataAccessV1, Efl.Ui.PositionManager.IEntity
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Grid))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_position_manager_grid_class_get();
    /// <summary>Initializes a new instance of the <see cref="Grid"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public Grid(Efl.Object parent= null
            ) : base(efl_ui_position_manager_grid_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected Grid(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Grid"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Grid(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Grid"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Grid(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Emitted when the aggregate size of all items has changed. This can be used to resize an enclosing Pan object.</summary>
    /// <value><see cref="Efl.Ui.PositionManager.IEntityContentSizeChangedEvt_Args"/></value>
    public event EventHandler<Efl.Ui.PositionManager.IEntityContentSizeChangedEvt_Args> ContentSizeChangedEvt
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Ui.PositionManager.IEntityContentSizeChangedEvt_Args args = new Efl.Ui.PositionManager.IEntityContentSizeChangedEvt_Args();
                        args.arg =  evt.Info;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_UI_POSITION_MANAGER_ENTITY_EVENT_CONTENT_SIZE_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_POSITION_MANAGER_ENTITY_EVENT_CONTENT_SIZE_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ContentSizeChangedEvt.</summary>
    public void OnContentSizeChangedEvt(Efl.Ui.PositionManager.IEntityContentSizeChangedEvt_Args e)
    {
        var key = "_EFL_UI_POSITION_MANAGER_ENTITY_EVENT_CONTENT_SIZE_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        try
        {
            Marshal.StructureToPtr(e.arg, info, false);
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Emitted when the minimum size of all items has changed. The minimum size is the size, that this position_manager needs at *least* to display a single item.</summary>
    /// <value><see cref="Efl.Ui.PositionManager.IEntityContentMinSizeChangedEvt_Args"/></value>
    public event EventHandler<Efl.Ui.PositionManager.IEntityContentMinSizeChangedEvt_Args> ContentMinSizeChangedEvt
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Ui.PositionManager.IEntityContentMinSizeChangedEvt_Args args = new Efl.Ui.PositionManager.IEntityContentMinSizeChangedEvt_Args();
                        args.arg =  evt.Info;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_UI_POSITION_MANAGER_ENTITY_EVENT_CONTENT_MIN_SIZE_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_POSITION_MANAGER_ENTITY_EVENT_CONTENT_MIN_SIZE_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ContentMinSizeChangedEvt.</summary>
    public void OnContentMinSizeChangedEvt(Efl.Ui.PositionManager.IEntityContentMinSizeChangedEvt_Args e)
    {
        var key = "_EFL_UI_POSITION_MANAGER_ENTITY_EVENT_CONTENT_MIN_SIZE_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        try
        {
            Marshal.StructureToPtr(e.arg, info, false);
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <value><see cref="Efl.Ui.PositionManager.IEntityVisibleRangeChangedEvt_Args"/></value>
    public event EventHandler<Efl.Ui.PositionManager.IEntityVisibleRangeChangedEvt_Args> VisibleRangeChangedEvt
    {
        add
        {
            lock (eflBindingEventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.Ui.PositionManager.IEntityVisibleRangeChangedEvt_Args args = new Efl.Ui.PositionManager.IEntityVisibleRangeChangedEvt_Args();
                        args.arg =  evt.Info;
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_UI_POSITION_MANAGER_ENTITY_EVENT_VISIBLE_RANGE_CHANGED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_UI_POSITION_MANAGER_ENTITY_EVENT_VISIBLE_RANGE_CHANGED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event VisibleRangeChangedEvt.</summary>
    public void OnVisibleRangeChangedEvt(Efl.Ui.PositionManager.IEntityVisibleRangeChangedEvt_Args e)
    {
        var key = "_EFL_UI_POSITION_MANAGER_ENTITY_EVENT_VISIBLE_RANGE_CHANGED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.arg));
        try
        {
            Marshal.StructureToPtr(e.arg, info, false);
            Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
        }
        finally
        {
            Marshal.FreeHGlobal(info);
        }
    }
    /// <summary>Control the direction of a given widget.
    /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
    /// 
    /// Mirroring as defined in <see cref="Efl.Ui.II18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
    /// <returns>Direction of the widget.</returns>
    virtual public Efl.Ui.LayoutOrientation GetOrientation() {
         var _ret_var = Efl.Ui.ILayoutOrientableConcrete.NativeMethods.efl_ui_layout_orientation_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the direction of a given widget.
    /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
    /// 
    /// Mirroring as defined in <see cref="Efl.Ui.II18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
    /// <param name="dir">Direction of the widget.</param>
    virtual public void SetOrientation(Efl.Ui.LayoutOrientation dir) {
                                 Efl.Ui.ILayoutOrientableConcrete.NativeMethods.efl_ui_layout_orientation_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),dir);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>This gives access to items to be managed. The manager reads this information and modifies the retrieved items&apos; positions and sizes.
    /// <c>obj_access</c> gives access to the graphical entitites to manage. Some of them might be NULL, meaning they are not yet ready to be displayed. Their size in the <c>size_access</c> array will be correct, though, so other entities can still be positioned correctly. Typically, only entities inside the viewport will be retrieved.
    /// 
    /// <c>size_access</c> gives access to the 2D sizes for the items to manage. All sizes will always be valid, and might change over time (indicated through the <see cref="Efl.Ui.PositionManager.IEntity.ItemSizeChanged"/> method). The whole range might need to be traversed in order to calculate the position of all items in some arrangements.
    /// 
    /// You can access a batch of objects or sizes by calling the here passed function callbacks. Further details can be found at the function definitions.</summary>
    /// <param name="obj_access">Function callback for canvas objects, even if the start_id is valid, the returned objects may be NULL.</param>
    /// <param name="size_access">Function callback for the size, returned values are always valid, but might be changed later on.</param>
    /// <param name="size">valid size for start_id, 0 &lt;= i &lt; size</param>
    virtual public void SetDataAccess(Efl.Ui.PositionManager.ObjectBatchCallback obj_access, Efl.Ui.PositionManager.SizeBatchCallback size_access, int size) {
                                                         GCHandle obj_access_handle = GCHandle.Alloc(obj_access);
        GCHandle size_access_handle = GCHandle.Alloc(size_access);
                Efl.Ui.PositionManager.IDataAccessV1Concrete.NativeMethods.efl_ui_position_manager_data_access_v1_data_access_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),GCHandle.ToIntPtr(obj_access_handle), Efl.Ui.PositionManager.ObjectBatchCallbackWrapper.Cb, Efl.Eo.Globals.free_gchandle, GCHandle.ToIntPtr(size_access_handle), Efl.Ui.PositionManager.SizeBatchCallbackWrapper.Cb, Efl.Eo.Globals.free_gchandle, size);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>This is the position and size of the viewport, where elements are displayed in. Entities outside this viewport will not be shown.</summary>
    virtual public void SetViewport(Eina.Rect viewport) {
         Eina.Rect.NativeStruct _in_viewport = viewport;
                        Efl.Ui.PositionManager.IEntityConcrete.NativeMethods.efl_ui_position_manager_entity_viewport_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_viewport);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Move the items relative to the viewport.
    /// The items that are managed with this position manager might be bigger than the actual viewport. The positioning of the layer where all items are on is described by these values. 0.0,0.0 means that layer is moved that the top left items are shown, 1.0,1.0 means, that the lower right items are shown.</summary>
    /// <param name="x">X position of the scroller, valid form 0 to 1.0</param>
    /// <param name="y">Y position of the scroller, valid form 0 to 1.0</param>
    virtual public void SetScrollPosition(double x, double y) {
                                                         Efl.Ui.PositionManager.IEntityConcrete.NativeMethods.efl_ui_position_manager_entity_scroll_position_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Return the version of Data_Access that is used. This object needs to implement the interface Efl.Ui.Position_Manager.Data_Access_V1 if 1 is returned. 2 if V2 (not available yet) is implemented.</summary>
    /// <param name="max">The maximum version that is available from the data-provider.</param>
    /// <returns>The version that should be used here. 0 is an error.</returns>
    virtual public int Version(int max) {
                                 var _ret_var = Efl.Ui.PositionManager.IEntityConcrete.NativeMethods.efl_ui_position_manager_entity_version_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),max);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Return the position and size of item idx
    /// This method returns the size and position of the item at <c>idx</c>. Even if the item is outside the viewport, the returned rectangle must be valid. The result can be used for scrolling calculations.</summary>
    /// <param name="idx">The id for the item</param>
    /// <returns>Position and Size in canvas coordinations</returns>
    virtual public Eina.Rect PositionSingleItem(int idx) {
                                 var _ret_var = Efl.Ui.PositionManager.IEntityConcrete.NativeMethods.efl_ui_position_manager_entity_position_single_item_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),idx);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>The new item <c>subobj</c> has been added at the <c>added_index</c> field.
    /// The accessor provided through <see cref="Efl.Ui.PositionManager.IDataAccessV1.SetDataAccess"/> will contain updated Entities.</summary>
    virtual public void ItemAdded(int added_index, Efl.Gfx.IEntity subobj) {
                                                         Efl.Ui.PositionManager.IEntityConcrete.NativeMethods.efl_ui_position_manager_entity_item_added_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),added_index, subobj);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>The item <c>subobj</c> previously at position <c>removed_index</c> has been removed. The accessor provided through <see cref="Efl.Ui.PositionManager.IDataAccessV1.SetDataAccess"/> will contain updated Entities.</summary>
    virtual public void ItemRemoved(int removed_index, Efl.Gfx.IEntity subobj) {
                                                         Efl.Ui.PositionManager.IEntityConcrete.NativeMethods.efl_ui_position_manager_entity_item_removed_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),removed_index, subobj);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>The size of the items from <c>start_id</c> to <c>end_id</c> have been changed. The positioning and sizing of all items will be updated</summary>
    /// <param name="start_id">The first item that has a new size</param>
    /// <param name="end_id">The last item that has a new size</param>
    virtual public void ItemSizeChanged(int start_id, int end_id) {
                                                         Efl.Ui.PositionManager.IEntityConcrete.NativeMethods.efl_ui_position_manager_entity_item_size_changed_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),start_id, end_id);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>translate the current_id, into a new id which is oriented in the <c>direction</c> of <c>current_id</c>. In case that there is no item, -1 is returned</summary>
    /// <param name="current_id">The id where the direction is oriented at</param>
    /// <param name="direction">The direction where the new id is</param>
    /// <returns>The id of the item in that direction, or -1 if there is no item in that direction</returns>
    virtual public int RelativeItem(uint current_id, Efl.Ui.Focus.Direction direction) {
                                                         var _ret_var = Efl.Ui.PositionManager.IEntityConcrete.NativeMethods.efl_ui_position_manager_entity_relative_item_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),current_id, direction);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Control the direction of a given widget.
    /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
    /// 
    /// Mirroring as defined in <see cref="Efl.Ui.II18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
    /// <value>Direction of the widget.</value>
    public Efl.Ui.LayoutOrientation Orientation {
        get { return GetOrientation(); }
        set { SetOrientation(value); }
    }
    /// <summary>This gives access to items to be managed. The manager reads this information and modifies the retrieved items&apos; positions and sizes.
    /// <c>obj_access</c> gives access to the graphical entitites to manage. Some of them might be NULL, meaning they are not yet ready to be displayed. Their size in the <c>size_access</c> array will be correct, though, so other entities can still be positioned correctly. Typically, only entities inside the viewport will be retrieved.
    /// 
    /// <c>size_access</c> gives access to the 2D sizes for the items to manage. All sizes will always be valid, and might change over time (indicated through the <see cref="Efl.Ui.PositionManager.IEntity.ItemSizeChanged"/> method). The whole range might need to be traversed in order to calculate the position of all items in some arrangements.
    /// 
    /// You can access a batch of objects or sizes by calling the here passed function callbacks. Further details can be found at the function definitions.</summary>
    /// <value>Function callback for canvas objects, even if the start_id is valid, the returned objects may be NULL.</value>
    public (Efl.Ui.PositionManager.ObjectBatchCallback, Efl.Ui.PositionManager.SizeBatchCallback, int) DataAccess {
        set { SetDataAccess( value.Item1,  value.Item2,  value.Item3); }
    }
    /// <summary>This is the position and size of the viewport, where elements are displayed in. Entities outside this viewport will not be shown.</summary>
    public Eina.Rect Viewport {
        set { SetViewport(value); }
    }
    /// <summary>Move the items relative to the viewport.
    /// The items that are managed with this position manager might be bigger than the actual viewport. The positioning of the layer where all items are on is described by these values. 0.0,0.0 means that layer is moved that the top left items are shown, 1.0,1.0 means, that the lower right items are shown.</summary>
    /// <value>X position of the scroller, valid form 0 to 1.0</value>
    public (double, double) ScrollPosition {
        set { SetScrollPosition( value.Item1,  value.Item2); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.PositionManager.Grid.efl_ui_position_manager_grid_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Object.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_layout_orientation_get_static_delegate == null)
            {
                efl_ui_layout_orientation_get_static_delegate = new efl_ui_layout_orientation_get_delegate(orientation_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetOrientation") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_layout_orientation_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_layout_orientation_get_static_delegate) });
            }

            if (efl_ui_layout_orientation_set_static_delegate == null)
            {
                efl_ui_layout_orientation_set_static_delegate = new efl_ui_layout_orientation_set_delegate(orientation_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetOrientation") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_layout_orientation_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_layout_orientation_set_static_delegate) });
            }

            if (efl_ui_position_manager_data_access_v1_data_access_set_static_delegate == null)
            {
                efl_ui_position_manager_data_access_v1_data_access_set_static_delegate = new efl_ui_position_manager_data_access_v1_data_access_set_delegate(data_access_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetDataAccess") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_position_manager_data_access_v1_data_access_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_position_manager_data_access_v1_data_access_set_static_delegate) });
            }

            if (efl_ui_position_manager_entity_viewport_set_static_delegate == null)
            {
                efl_ui_position_manager_entity_viewport_set_static_delegate = new efl_ui_position_manager_entity_viewport_set_delegate(viewport_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetViewport") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_position_manager_entity_viewport_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_position_manager_entity_viewport_set_static_delegate) });
            }

            if (efl_ui_position_manager_entity_scroll_position_set_static_delegate == null)
            {
                efl_ui_position_manager_entity_scroll_position_set_static_delegate = new efl_ui_position_manager_entity_scroll_position_set_delegate(scroll_position_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetScrollPosition") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_position_manager_entity_scroll_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_position_manager_entity_scroll_position_set_static_delegate) });
            }

            if (efl_ui_position_manager_entity_version_static_delegate == null)
            {
                efl_ui_position_manager_entity_version_static_delegate = new efl_ui_position_manager_entity_version_delegate(version);
            }

            if (methods.FirstOrDefault(m => m.Name == "Version") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_position_manager_entity_version"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_position_manager_entity_version_static_delegate) });
            }

            if (efl_ui_position_manager_entity_position_single_item_static_delegate == null)
            {
                efl_ui_position_manager_entity_position_single_item_static_delegate = new efl_ui_position_manager_entity_position_single_item_delegate(position_single_item);
            }

            if (methods.FirstOrDefault(m => m.Name == "PositionSingleItem") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_position_manager_entity_position_single_item"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_position_manager_entity_position_single_item_static_delegate) });
            }

            if (efl_ui_position_manager_entity_item_added_static_delegate == null)
            {
                efl_ui_position_manager_entity_item_added_static_delegate = new efl_ui_position_manager_entity_item_added_delegate(item_added);
            }

            if (methods.FirstOrDefault(m => m.Name == "ItemAdded") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_position_manager_entity_item_added"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_position_manager_entity_item_added_static_delegate) });
            }

            if (efl_ui_position_manager_entity_item_removed_static_delegate == null)
            {
                efl_ui_position_manager_entity_item_removed_static_delegate = new efl_ui_position_manager_entity_item_removed_delegate(item_removed);
            }

            if (methods.FirstOrDefault(m => m.Name == "ItemRemoved") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_position_manager_entity_item_removed"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_position_manager_entity_item_removed_static_delegate) });
            }

            if (efl_ui_position_manager_entity_item_size_changed_static_delegate == null)
            {
                efl_ui_position_manager_entity_item_size_changed_static_delegate = new efl_ui_position_manager_entity_item_size_changed_delegate(item_size_changed);
            }

            if (methods.FirstOrDefault(m => m.Name == "ItemSizeChanged") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_position_manager_entity_item_size_changed"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_position_manager_entity_item_size_changed_static_delegate) });
            }

            if (efl_ui_position_manager_entity_relative_item_static_delegate == null)
            {
                efl_ui_position_manager_entity_relative_item_static_delegate = new efl_ui_position_manager_entity_relative_item_delegate(relative_item);
            }

            if (methods.FirstOrDefault(m => m.Name == "RelativeItem") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_position_manager_entity_relative_item"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_position_manager_entity_relative_item_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.PositionManager.Grid.efl_ui_position_manager_grid_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate Efl.Ui.LayoutOrientation efl_ui_layout_orientation_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate Efl.Ui.LayoutOrientation efl_ui_layout_orientation_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_ui_layout_orientation_get_api_delegate> efl_ui_layout_orientation_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_layout_orientation_get_api_delegate>(Module, "efl_ui_layout_orientation_get");

        private static Efl.Ui.LayoutOrientation orientation_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_ui_layout_orientation_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Efl.Ui.LayoutOrientation _ret_var = default(Efl.Ui.LayoutOrientation);
                try
                {
                    _ret_var = ((Grid)ws.Target).GetOrientation();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        return _ret_var;

            }
            else
            {
                return efl_ui_layout_orientation_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_ui_layout_orientation_get_delegate efl_ui_layout_orientation_get_static_delegate;

        
        private delegate void efl_ui_layout_orientation_set_delegate(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.LayoutOrientation dir);

        
        public delegate void efl_ui_layout_orientation_set_api_delegate(System.IntPtr obj,  Efl.Ui.LayoutOrientation dir);

        public static Efl.Eo.FunctionWrapper<efl_ui_layout_orientation_set_api_delegate> efl_ui_layout_orientation_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_layout_orientation_set_api_delegate>(Module, "efl_ui_layout_orientation_set");

        private static void orientation_set(System.IntPtr obj, System.IntPtr pd, Efl.Ui.LayoutOrientation dir)
        {
            Eina.Log.Debug("function efl_ui_layout_orientation_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Grid)ws.Target).SetOrientation(dir);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_layout_orientation_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), dir);
            }
        }

        private static efl_ui_layout_orientation_set_delegate efl_ui_layout_orientation_set_static_delegate;

        
        private delegate void efl_ui_position_manager_data_access_v1_data_access_set_delegate(System.IntPtr obj, System.IntPtr pd,  IntPtr obj_access_data, Efl.Ui.PositionManager.ObjectBatchCallbackInternal obj_access, EinaFreeCb obj_access_free_cb,  IntPtr size_access_data, Efl.Ui.PositionManager.SizeBatchCallbackInternal size_access, EinaFreeCb size_access_free_cb,  int size);

        
        public delegate void efl_ui_position_manager_data_access_v1_data_access_set_api_delegate(System.IntPtr obj,  IntPtr obj_access_data, Efl.Ui.PositionManager.ObjectBatchCallbackInternal obj_access, EinaFreeCb obj_access_free_cb,  IntPtr size_access_data, Efl.Ui.PositionManager.SizeBatchCallbackInternal size_access, EinaFreeCb size_access_free_cb,  int size);

        public static Efl.Eo.FunctionWrapper<efl_ui_position_manager_data_access_v1_data_access_set_api_delegate> efl_ui_position_manager_data_access_v1_data_access_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_position_manager_data_access_v1_data_access_set_api_delegate>(Module, "efl_ui_position_manager_data_access_v1_data_access_set");

        private static void data_access_set(System.IntPtr obj, System.IntPtr pd, IntPtr obj_access_data, Efl.Ui.PositionManager.ObjectBatchCallbackInternal obj_access, EinaFreeCb obj_access_free_cb, IntPtr size_access_data, Efl.Ui.PositionManager.SizeBatchCallbackInternal size_access, EinaFreeCb size_access_free_cb, int size)
        {
            Eina.Log.Debug("function efl_ui_position_manager_data_access_v1_data_access_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            Efl.Ui.PositionManager.ObjectBatchCallbackWrapper obj_access_wrapper = new Efl.Ui.PositionManager.ObjectBatchCallbackWrapper(obj_access, obj_access_data, obj_access_free_cb);
            Efl.Ui.PositionManager.SizeBatchCallbackWrapper size_access_wrapper = new Efl.Ui.PositionManager.SizeBatchCallbackWrapper(size_access, size_access_data, size_access_free_cb);
                    
                try
                {
                    ((Grid)ws.Target).SetDataAccess(obj_access_wrapper.ManagedCb, size_access_wrapper.ManagedCb, size);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_ui_position_manager_data_access_v1_data_access_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), obj_access_data, obj_access, obj_access_free_cb, size_access_data, size_access, size_access_free_cb, size);
            }
        }

        private static efl_ui_position_manager_data_access_v1_data_access_set_delegate efl_ui_position_manager_data_access_v1_data_access_set_static_delegate;

        
        private delegate void efl_ui_position_manager_entity_viewport_set_delegate(System.IntPtr obj, System.IntPtr pd,  Eina.Rect.NativeStruct viewport);

        
        public delegate void efl_ui_position_manager_entity_viewport_set_api_delegate(System.IntPtr obj,  Eina.Rect.NativeStruct viewport);

        public static Efl.Eo.FunctionWrapper<efl_ui_position_manager_entity_viewport_set_api_delegate> efl_ui_position_manager_entity_viewport_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_position_manager_entity_viewport_set_api_delegate>(Module, "efl_ui_position_manager_entity_viewport_set");

        private static void viewport_set(System.IntPtr obj, System.IntPtr pd, Eina.Rect.NativeStruct viewport)
        {
            Eina.Log.Debug("function efl_ui_position_manager_entity_viewport_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
        Eina.Rect _in_viewport = viewport;
                            
                try
                {
                    ((Grid)ws.Target).SetViewport(_in_viewport);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_ui_position_manager_entity_viewport_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), viewport);
            }
        }

        private static efl_ui_position_manager_entity_viewport_set_delegate efl_ui_position_manager_entity_viewport_set_static_delegate;

        
        private delegate void efl_ui_position_manager_entity_scroll_position_set_delegate(System.IntPtr obj, System.IntPtr pd,  double x,  double y);

        
        public delegate void efl_ui_position_manager_entity_scroll_position_set_api_delegate(System.IntPtr obj,  double x,  double y);

        public static Efl.Eo.FunctionWrapper<efl_ui_position_manager_entity_scroll_position_set_api_delegate> efl_ui_position_manager_entity_scroll_position_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_position_manager_entity_scroll_position_set_api_delegate>(Module, "efl_ui_position_manager_entity_scroll_position_set");

        private static void scroll_position_set(System.IntPtr obj, System.IntPtr pd, double x, double y)
        {
            Eina.Log.Debug("function efl_ui_position_manager_entity_scroll_position_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Grid)ws.Target).SetScrollPosition(x, y);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_position_manager_entity_scroll_position_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), x, y);
            }
        }

        private static efl_ui_position_manager_entity_scroll_position_set_delegate efl_ui_position_manager_entity_scroll_position_set_static_delegate;

        
        private delegate int efl_ui_position_manager_entity_version_delegate(System.IntPtr obj, System.IntPtr pd,  int max);

        
        public delegate int efl_ui_position_manager_entity_version_api_delegate(System.IntPtr obj,  int max);

        public static Efl.Eo.FunctionWrapper<efl_ui_position_manager_entity_version_api_delegate> efl_ui_position_manager_entity_version_ptr = new Efl.Eo.FunctionWrapper<efl_ui_position_manager_entity_version_api_delegate>(Module, "efl_ui_position_manager_entity_version");

        private static int version(System.IntPtr obj, System.IntPtr pd, int max)
        {
            Eina.Log.Debug("function efl_ui_position_manager_entity_version was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    int _ret_var = default(int);
                try
                {
                    _ret_var = ((Grid)ws.Target).Version(max);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        return _ret_var;

            }
            else
            {
                return efl_ui_position_manager_entity_version_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), max);
            }
        }

        private static efl_ui_position_manager_entity_version_delegate efl_ui_position_manager_entity_version_static_delegate;

        
        private delegate Eina.Rect.NativeStruct efl_ui_position_manager_entity_position_single_item_delegate(System.IntPtr obj, System.IntPtr pd,  int idx);

        
        public delegate Eina.Rect.NativeStruct efl_ui_position_manager_entity_position_single_item_api_delegate(System.IntPtr obj,  int idx);

        public static Efl.Eo.FunctionWrapper<efl_ui_position_manager_entity_position_single_item_api_delegate> efl_ui_position_manager_entity_position_single_item_ptr = new Efl.Eo.FunctionWrapper<efl_ui_position_manager_entity_position_single_item_api_delegate>(Module, "efl_ui_position_manager_entity_position_single_item");

        private static Eina.Rect.NativeStruct position_single_item(System.IntPtr obj, System.IntPtr pd, int idx)
        {
            Eina.Log.Debug("function efl_ui_position_manager_entity_position_single_item was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Eina.Rect _ret_var = default(Eina.Rect);
                try
                {
                    _ret_var = ((Grid)ws.Target).PositionSingleItem(idx);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        return _ret_var;

            }
            else
            {
                return efl_ui_position_manager_entity_position_single_item_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), idx);
            }
        }

        private static efl_ui_position_manager_entity_position_single_item_delegate efl_ui_position_manager_entity_position_single_item_static_delegate;

        
        private delegate void efl_ui_position_manager_entity_item_added_delegate(System.IntPtr obj, System.IntPtr pd,  int added_index, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj);

        
        public delegate void efl_ui_position_manager_entity_item_added_api_delegate(System.IntPtr obj,  int added_index, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj);

        public static Efl.Eo.FunctionWrapper<efl_ui_position_manager_entity_item_added_api_delegate> efl_ui_position_manager_entity_item_added_ptr = new Efl.Eo.FunctionWrapper<efl_ui_position_manager_entity_item_added_api_delegate>(Module, "efl_ui_position_manager_entity_item_added");

        private static void item_added(System.IntPtr obj, System.IntPtr pd, int added_index, Efl.Gfx.IEntity subobj)
        {
            Eina.Log.Debug("function efl_ui_position_manager_entity_item_added was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Grid)ws.Target).ItemAdded(added_index, subobj);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_position_manager_entity_item_added_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), added_index, subobj);
            }
        }

        private static efl_ui_position_manager_entity_item_added_delegate efl_ui_position_manager_entity_item_added_static_delegate;

        
        private delegate void efl_ui_position_manager_entity_item_removed_delegate(System.IntPtr obj, System.IntPtr pd,  int removed_index, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj);

        
        public delegate void efl_ui_position_manager_entity_item_removed_api_delegate(System.IntPtr obj,  int removed_index, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj);

        public static Efl.Eo.FunctionWrapper<efl_ui_position_manager_entity_item_removed_api_delegate> efl_ui_position_manager_entity_item_removed_ptr = new Efl.Eo.FunctionWrapper<efl_ui_position_manager_entity_item_removed_api_delegate>(Module, "efl_ui_position_manager_entity_item_removed");

        private static void item_removed(System.IntPtr obj, System.IntPtr pd, int removed_index, Efl.Gfx.IEntity subobj)
        {
            Eina.Log.Debug("function efl_ui_position_manager_entity_item_removed was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Grid)ws.Target).ItemRemoved(removed_index, subobj);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_position_manager_entity_item_removed_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), removed_index, subobj);
            }
        }

        private static efl_ui_position_manager_entity_item_removed_delegate efl_ui_position_manager_entity_item_removed_static_delegate;

        
        private delegate void efl_ui_position_manager_entity_item_size_changed_delegate(System.IntPtr obj, System.IntPtr pd,  int start_id,  int end_id);

        
        public delegate void efl_ui_position_manager_entity_item_size_changed_api_delegate(System.IntPtr obj,  int start_id,  int end_id);

        public static Efl.Eo.FunctionWrapper<efl_ui_position_manager_entity_item_size_changed_api_delegate> efl_ui_position_manager_entity_item_size_changed_ptr = new Efl.Eo.FunctionWrapper<efl_ui_position_manager_entity_item_size_changed_api_delegate>(Module, "efl_ui_position_manager_entity_item_size_changed");

        private static void item_size_changed(System.IntPtr obj, System.IntPtr pd, int start_id, int end_id)
        {
            Eina.Log.Debug("function efl_ui_position_manager_entity_item_size_changed was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Grid)ws.Target).ItemSizeChanged(start_id, end_id);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_position_manager_entity_item_size_changed_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), start_id, end_id);
            }
        }

        private static efl_ui_position_manager_entity_item_size_changed_delegate efl_ui_position_manager_entity_item_size_changed_static_delegate;

        
        private delegate int efl_ui_position_manager_entity_relative_item_delegate(System.IntPtr obj, System.IntPtr pd,  uint current_id,  Efl.Ui.Focus.Direction direction);

        
        public delegate int efl_ui_position_manager_entity_relative_item_api_delegate(System.IntPtr obj,  uint current_id,  Efl.Ui.Focus.Direction direction);

        public static Efl.Eo.FunctionWrapper<efl_ui_position_manager_entity_relative_item_api_delegate> efl_ui_position_manager_entity_relative_item_ptr = new Efl.Eo.FunctionWrapper<efl_ui_position_manager_entity_relative_item_api_delegate>(Module, "efl_ui_position_manager_entity_relative_item");

        private static int relative_item(System.IntPtr obj, System.IntPtr pd, uint current_id, Efl.Ui.Focus.Direction direction)
        {
            Eina.Log.Debug("function efl_ui_position_manager_entity_relative_item was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            int _ret_var = default(int);
                try
                {
                    _ret_var = ((Grid)ws.Target).RelativeItem(current_id, direction);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        return _ret_var;

            }
            else
            {
                return efl_ui_position_manager_entity_relative_item_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), current_id, direction);
            }
        }

        private static efl_ui_position_manager_entity_relative_item_delegate efl_ui_position_manager_entity_relative_item_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_Ui_Position_ManagerGrid_ExtensionMethods {
    public static Efl.BindableProperty<Efl.Ui.LayoutOrientation> Orientation<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.PositionManager.Grid, T>magic = null) where T : Efl.Ui.PositionManager.Grid {
        return new Efl.BindableProperty<Efl.Ui.LayoutOrientation>("orientation", fac);
    }

    
    public static Efl.BindableProperty<Eina.Rect> Viewport<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.PositionManager.Grid, T>magic = null) where T : Efl.Ui.PositionManager.Grid {
        return new Efl.BindableProperty<Eina.Rect>("viewport", fac);
    }

    
}
#pragma warning restore CS1591
#endif
