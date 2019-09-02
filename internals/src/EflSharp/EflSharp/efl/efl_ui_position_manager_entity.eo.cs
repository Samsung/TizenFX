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

/// <summary>This abstracts the basic placement of items in a not defined form under a viewport.
/// The interface gets a defined set of elements that is meant to be displayed. The implementation provides a way to calculate the size that is required to display all items. Every time this absolut size of items is changed, content_size,changed is called.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.PositionManager.IEntityConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IEntity : 
    Efl.Ui.ILayoutOrientable ,
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>This is the position and size of the viewport, where elements are displayed in. Entities outside this viewport will not be shown.</summary>
void SetViewport(Eina.Rect viewport);
    /// <summary>Move the items relative to the viewport.
/// The items that are managed with this position manager might be bigger than the actual viewport. The positioning of the layer where all items are on is described by these values. 0.0,0.0 means that layer is moved that the top left items are shown, 1.0,1.0 means, that the lower right items are shown.</summary>
/// <param name="x">X position of the scroller, valid form 0 to 1.0</param>
/// <param name="y">Y position of the scroller, valid form 0 to 1.0</param>
void SetScrollPosition(double x, double y);
    /// <summary>Return the version of Data_Access that is used. This object needs to implement the interface Efl.Ui.Position_Manager.Data_Access_V1 if 1 is returned. 2 if V2 (not available yet) is implemented.</summary>
/// <param name="max">The maximum version that is available from the data-provider.</param>
/// <returns>The version that should be used here. 0 is an error.</returns>
int Version(int max);
    /// <summary>Return the position and size of item idx
/// This method returns the size and position of the item at <c>idx</c>. Even if the item is outside the viewport, the returned rectangle must be valid. The result can be used for scrolling calculations.</summary>
/// <param name="idx">The id for the item</param>
/// <returns>Position and Size in canvas coordinations</returns>
Eina.Rect PositionSingleItem(int idx);
    /// <summary>The new item <c>subobj</c> has been added at the <c>added_index</c> field.
/// The accessor provided through <see cref="Efl.Ui.PositionManager.IDataAccessV1.SetDataAccess"/> will contain updated Entities.</summary>
void ItemAdded(int added_index, Efl.Gfx.IEntity subobj);
    /// <summary>The item <c>subobj</c> previously at position <c>removed_index</c> has been removed. The accessor provided through <see cref="Efl.Ui.PositionManager.IDataAccessV1.SetDataAccess"/> will contain updated Entities.</summary>
void ItemRemoved(int removed_index, Efl.Gfx.IEntity subobj);
    /// <summary>The size of the items from <c>start_id</c> to <c>end_id</c> have been changed. The positioning and sizing of all items will be updated</summary>
/// <param name="start_id">The first item that has a new size</param>
/// <param name="end_id">The last item that has a new size</param>
void ItemSizeChanged(int start_id, int end_id);
    /// <summary>translate the current_id, into a new id which is oriented in the <c>direction</c> of <c>current_id</c>. In case that there is no item, -1 is returned</summary>
/// <param name="current_id">The id where the direction is oriented at</param>
/// <param name="direction">The direction where the new id is</param>
/// <returns>The id of the item in that direction, or -1 if there is no item in that direction</returns>
int RelativeItem(uint current_id, Efl.Ui.Focus.Direction direction);
                                    /// <summary>Emitted when the aggregate size of all items has changed. This can be used to resize an enclosing Pan object.</summary>
    /// <value><see cref="Efl.Ui.PositionManager.IEntityContentSizeChangedEvt_Args"/></value>
    event EventHandler<Efl.Ui.PositionManager.IEntityContentSizeChangedEvt_Args> ContentSizeChangedEvt;
    /// <summary>Emitted when the minimum size of all items has changed. The minimum size is the size, that this position_manager needs at *least* to display a single item.</summary>
    /// <value><see cref="Efl.Ui.PositionManager.IEntityContentMinSizeChangedEvt_Args"/></value>
    event EventHandler<Efl.Ui.PositionManager.IEntityContentMinSizeChangedEvt_Args> ContentMinSizeChangedEvt;
    /// <value><see cref="Efl.Ui.PositionManager.IEntityVisibleRangeChangedEvt_Args"/></value>
    event EventHandler<Efl.Ui.PositionManager.IEntityVisibleRangeChangedEvt_Args> VisibleRangeChangedEvt;
    /// <summary>This is the position and size of the viewport, where elements are displayed in. Entities outside this viewport will not be shown.</summary>
    Eina.Rect Viewport {
        set;
    }
    /// <summary>Move the items relative to the viewport.
    /// The items that are managed with this position manager might be bigger than the actual viewport. The positioning of the layer where all items are on is described by these values. 0.0,0.0 means that layer is moved that the top left items are shown, 1.0,1.0 means, that the lower right items are shown.</summary>
    /// <value>X position of the scroller, valid form 0 to 1.0</value>
    (double, double) ScrollPosition {
        set;
    }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Ui.PositionManager.IEntity.ContentSizeChangedEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class IEntityContentSizeChangedEvt_Args : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Emitted when the aggregate size of all items has changed. This can be used to resize an enclosing Pan object.</value>
    public Eina.Size2D arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Ui.PositionManager.IEntity.ContentMinSizeChangedEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class IEntityContentMinSizeChangedEvt_Args : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value>Emitted when the minimum size of all items has changed. The minimum size is the size, that this position_manager needs at *least* to display a single item.</value>
    public Eina.Size2D arg { get; set; }
}
/// <summary>Event argument wrapper for event <see cref="Efl.Ui.PositionManager.IEntity.VisibleRangeChangedEvt"/>.</summary>
[Efl.Eo.BindingEntity]
public class IEntityVisibleRangeChangedEvt_Args : EventArgs {
    /// <summary>Actual event payload.</summary>
    /// <value></value>
    public Efl.Ui.PositionManager.RangeUpdate arg { get; set; }
}
/// <summary>This abstracts the basic placement of items in a not defined form under a viewport.
/// The interface gets a defined set of elements that is meant to be displayed. The implementation provides a way to calculate the size that is required to display all items. Every time this absolut size of items is changed, content_size,changed is called.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
sealed public  class IEntityConcrete :
    Efl.Eo.EoWrapper
    , IEntity
    , Efl.Ui.ILayoutOrientable
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IEntityConcrete))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    private IEntityConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_position_manager_entity_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IEntity"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private IEntityConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
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
    /// <summary>This is the position and size of the viewport, where elements are displayed in. Entities outside this viewport will not be shown.</summary>
    public void SetViewport(Eina.Rect viewport) {
         Eina.Rect.NativeStruct _in_viewport = viewport;
                        Efl.Ui.PositionManager.IEntityConcrete.NativeMethods.efl_ui_position_manager_entity_viewport_set_ptr.Value.Delegate(this.NativeHandle,_in_viewport);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Move the items relative to the viewport.
    /// The items that are managed with this position manager might be bigger than the actual viewport. The positioning of the layer where all items are on is described by these values. 0.0,0.0 means that layer is moved that the top left items are shown, 1.0,1.0 means, that the lower right items are shown.</summary>
    /// <param name="x">X position of the scroller, valid form 0 to 1.0</param>
    /// <param name="y">Y position of the scroller, valid form 0 to 1.0</param>
    public void SetScrollPosition(double x, double y) {
                                                         Efl.Ui.PositionManager.IEntityConcrete.NativeMethods.efl_ui_position_manager_entity_scroll_position_set_ptr.Value.Delegate(this.NativeHandle,x, y);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Return the version of Data_Access that is used. This object needs to implement the interface Efl.Ui.Position_Manager.Data_Access_V1 if 1 is returned. 2 if V2 (not available yet) is implemented.</summary>
    /// <param name="max">The maximum version that is available from the data-provider.</param>
    /// <returns>The version that should be used here. 0 is an error.</returns>
    public int Version(int max) {
                                 var _ret_var = Efl.Ui.PositionManager.IEntityConcrete.NativeMethods.efl_ui_position_manager_entity_version_ptr.Value.Delegate(this.NativeHandle,max);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Return the position and size of item idx
    /// This method returns the size and position of the item at <c>idx</c>. Even if the item is outside the viewport, the returned rectangle must be valid. The result can be used for scrolling calculations.</summary>
    /// <param name="idx">The id for the item</param>
    /// <returns>Position and Size in canvas coordinations</returns>
    public Eina.Rect PositionSingleItem(int idx) {
                                 var _ret_var = Efl.Ui.PositionManager.IEntityConcrete.NativeMethods.efl_ui_position_manager_entity_position_single_item_ptr.Value.Delegate(this.NativeHandle,idx);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>The new item <c>subobj</c> has been added at the <c>added_index</c> field.
    /// The accessor provided through <see cref="Efl.Ui.PositionManager.IDataAccessV1.SetDataAccess"/> will contain updated Entities.</summary>
    public void ItemAdded(int added_index, Efl.Gfx.IEntity subobj) {
                                                         Efl.Ui.PositionManager.IEntityConcrete.NativeMethods.efl_ui_position_manager_entity_item_added_ptr.Value.Delegate(this.NativeHandle,added_index, subobj);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>The item <c>subobj</c> previously at position <c>removed_index</c> has been removed. The accessor provided through <see cref="Efl.Ui.PositionManager.IDataAccessV1.SetDataAccess"/> will contain updated Entities.</summary>
    public void ItemRemoved(int removed_index, Efl.Gfx.IEntity subobj) {
                                                         Efl.Ui.PositionManager.IEntityConcrete.NativeMethods.efl_ui_position_manager_entity_item_removed_ptr.Value.Delegate(this.NativeHandle,removed_index, subobj);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>The size of the items from <c>start_id</c> to <c>end_id</c> have been changed. The positioning and sizing of all items will be updated</summary>
    /// <param name="start_id">The first item that has a new size</param>
    /// <param name="end_id">The last item that has a new size</param>
    public void ItemSizeChanged(int start_id, int end_id) {
                                                         Efl.Ui.PositionManager.IEntityConcrete.NativeMethods.efl_ui_position_manager_entity_item_size_changed_ptr.Value.Delegate(this.NativeHandle,start_id, end_id);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>translate the current_id, into a new id which is oriented in the <c>direction</c> of <c>current_id</c>. In case that there is no item, -1 is returned</summary>
    /// <param name="current_id">The id where the direction is oriented at</param>
    /// <param name="direction">The direction where the new id is</param>
    /// <returns>The id of the item in that direction, or -1 if there is no item in that direction</returns>
    public int RelativeItem(uint current_id, Efl.Ui.Focus.Direction direction) {
                                                         var _ret_var = Efl.Ui.PositionManager.IEntityConcrete.NativeMethods.efl_ui_position_manager_entity_relative_item_ptr.Value.Delegate(this.NativeHandle,current_id, direction);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Control the direction of a given widget.
    /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
    /// 
    /// Mirroring as defined in <see cref="Efl.Ui.II18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
    /// <returns>Direction of the widget.</returns>
    public Efl.Ui.LayoutOrientation GetOrientation() {
         var _ret_var = Efl.Ui.ILayoutOrientableConcrete.NativeMethods.efl_ui_layout_orientation_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the direction of a given widget.
    /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
    /// 
    /// Mirroring as defined in <see cref="Efl.Ui.II18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
    /// <param name="dir">Direction of the widget.</param>
    public void SetOrientation(Efl.Ui.LayoutOrientation dir) {
                                 Efl.Ui.ILayoutOrientableConcrete.NativeMethods.efl_ui_layout_orientation_set_ptr.Value.Delegate(this.NativeHandle,dir);
        Eina.Error.RaiseIfUnhandledException();
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
    /// <summary>Control the direction of a given widget.
    /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
    /// 
    /// Mirroring as defined in <see cref="Efl.Ui.II18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
    /// <value>Direction of the widget.</value>
    public Efl.Ui.LayoutOrientation Orientation {
        get { return GetOrientation(); }
        set { SetOrientation(value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.PositionManager.IEntityConcrete.efl_ui_position_manager_entity_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

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

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.PositionManager.IEntityConcrete.efl_ui_position_manager_entity_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
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
                    ((IEntity)ws.Target).SetViewport(_in_viewport);
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
                    ((IEntity)ws.Target).SetScrollPosition(x, y);
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
                    _ret_var = ((IEntity)ws.Target).Version(max);
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
                    _ret_var = ((IEntity)ws.Target).PositionSingleItem(idx);
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
                    ((IEntity)ws.Target).ItemAdded(added_index, subobj);
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
                    ((IEntity)ws.Target).ItemRemoved(removed_index, subobj);
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
                    ((IEntity)ws.Target).ItemSizeChanged(start_id, end_id);
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
                    _ret_var = ((IEntity)ws.Target).RelativeItem(current_id, direction);
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
                    _ret_var = ((IEntity)ws.Target).GetOrientation();
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
                    ((IEntity)ws.Target).SetOrientation(dir);
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

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_Ui_Position_ManagerIEntityConcrete_ExtensionMethods {
    public static Efl.BindableProperty<Eina.Rect> Viewport<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.PositionManager.IEntity, T>magic = null) where T : Efl.Ui.PositionManager.IEntity {
        return new Efl.BindableProperty<Eina.Rect>("viewport", fac);
    }

    
    public static Efl.BindableProperty<Efl.Ui.LayoutOrientation> Orientation<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.PositionManager.IEntity, T>magic = null) where T : Efl.Ui.PositionManager.IEntity {
        return new Efl.BindableProperty<Efl.Ui.LayoutOrientation>("orientation", fac);
    }

}
#pragma warning restore CS1591
#endif
namespace Efl {

namespace Ui {

namespace PositionManager {

/// <summary>A struct containing the the updated range of visible items in this position manger.</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct RangeUpdate
{
    /// <summary>The first item that is visible</summary>
    public uint Start_id;
    /// <summary>The last item that is visible</summary>
    public uint End_id;
    /// <summary>Constructor for RangeUpdate.</summary>
    /// <param name="Start_id">The first item that is visible</param>;
    /// <param name="End_id">The last item that is visible</param>;
    public RangeUpdate(
        uint Start_id = default(uint),
        uint End_id = default(uint)    )
    {
        this.Start_id = Start_id;
        this.End_id = End_id;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator RangeUpdate(IntPtr ptr)
    {
        var tmp = (RangeUpdate.NativeStruct)Marshal.PtrToStructure(ptr, typeof(RangeUpdate.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct RangeUpdate.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        
        public uint Start_id;
        
        public uint End_id;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator RangeUpdate.NativeStruct(RangeUpdate _external_struct)
        {
            var _internal_struct = new RangeUpdate.NativeStruct();
            _internal_struct.Start_id = _external_struct.Start_id;
            _internal_struct.End_id = _external_struct.End_id;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator RangeUpdate(RangeUpdate.NativeStruct _internal_struct)
        {
            var _external_struct = new RangeUpdate();
            _external_struct.Start_id = _internal_struct.Start_id;
            _external_struct.End_id = _internal_struct.End_id;
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

}

}

