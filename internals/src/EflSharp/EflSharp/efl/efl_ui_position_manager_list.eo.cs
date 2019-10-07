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

/// <summary>Implementation of <see cref="Efl.Ui.PositionManager.IEntity"/> for a list
/// Every item in the list will get at least his minsize applied, changes to the misize are listened to and change the layout of all items. This supports the vertical and horizontal orientation.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Ui.PositionManager.List.NativeMethods]
[Efl.Eo.BindingEntity]
public class List : Efl.Object, Efl.Ui.ILayoutOrientable, Efl.Ui.PositionManager.IDataAccessV1, Efl.Ui.PositionManager.IEntity
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(List))
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
        efl_ui_position_manager_list_class_get();

    /// <summary>Initializes a new instance of the <see cref="List"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public List(Efl.Object parent= null
            ) : base(efl_ui_position_manager_list_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected List(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="List"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected List(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="List"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected List(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }


    /// <summary>Emitted when the aggregate size of all items has changed. This can be used to resize an enclosing Pan object.</summary>
    /// <value><see cref="Efl.Ui.PositionManager.EntityContentSizeChangedEventArgs"/></value>
    public event EventHandler<Efl.Ui.PositionManager.EntityContentSizeChangedEventArgs> ContentSizeChangedEvent
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
                        Efl.Ui.PositionManager.EntityContentSizeChangedEventArgs args = new Efl.Ui.PositionManager.EntityContentSizeChangedEventArgs();
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

    /// <summary>Method to raise event ContentSizeChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnContentSizeChangedEvent(Efl.Ui.PositionManager.EntityContentSizeChangedEventArgs e)
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

    /// <summary>Emitted when the minimum size of all items has changed. The minimum size is the size that this position_manager needs to display a single item.</summary>
    /// <value><see cref="Efl.Ui.PositionManager.EntityContentMinSizeChangedEventArgs"/></value>
    public event EventHandler<Efl.Ui.PositionManager.EntityContentMinSizeChangedEventArgs> ContentMinSizeChangedEvent
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
                        Efl.Ui.PositionManager.EntityContentMinSizeChangedEventArgs args = new Efl.Ui.PositionManager.EntityContentMinSizeChangedEventArgs();
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

    /// <summary>Method to raise event ContentMinSizeChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnContentMinSizeChangedEvent(Efl.Ui.PositionManager.EntityContentMinSizeChangedEventArgs e)
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

    /// <value><see cref="Efl.Ui.PositionManager.EntityVisibleRangeChangedEventArgs"/></value>
    public event EventHandler<Efl.Ui.PositionManager.EntityVisibleRangeChangedEventArgs> VisibleRangeChangedEvent
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
                        Efl.Ui.PositionManager.EntityVisibleRangeChangedEventArgs args = new Efl.Ui.PositionManager.EntityVisibleRangeChangedEventArgs();
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

    /// <summary>Method to raise event VisibleRangeChangedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnVisibleRangeChangedEvent(Efl.Ui.PositionManager.EntityVisibleRangeChangedEventArgs e)
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
    public virtual Efl.Ui.LayoutOrientation GetOrientation() {
        var _ret_var = Efl.Ui.LayoutOrientableConcrete.NativeMethods.efl_ui_layout_orientation_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Control the direction of a given widget.
    /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
    /// 
    /// Mirroring as defined in <see cref="Efl.Ui.II18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
    /// <param name="dir">Direction of the widget.</param>
    public virtual void SetOrientation(Efl.Ui.LayoutOrientation dir) {
        Efl.Ui.LayoutOrientableConcrete.NativeMethods.efl_ui_layout_orientation_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),dir);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>This gives access to items to be managed. The manager reads this information and modifies the retrieved items&apos; positions and sizes.
    /// <c>obj_access</c> gives access to the graphical entities to manage. Some of them might be <c>NULL</c>, meaning they are not yet ready to be displayed. Their size in the <c>size_access</c> array will be correct, though, so other entities can still be positioned correctly. Typically, only entities inside the viewport will be retrieved.
    /// 
    /// <c>size_access</c> gives access to the 2D sizes for the items to manage. All sizes will always be valid, and might change over time (indicated through the <see cref="Efl.Ui.PositionManager.IEntity.ItemSizeChanged"/> method). The whole range might need to be traversed in order to calculate the position of all items in some arrangements.
    /// 
    /// You can access a batch of objects or sizes by calling the here passed function callbacks. Further details can be found at the function definitions.</summary>
    /// <param name="obj_access">Function callback for canvas objects, even if the start_id is valid, the returned objects may be <c>NULL</c>.</param>
    /// <param name="size_access">Function callback for the size, returned values are always valid, but might be changed later on.</param>
    /// <param name="size">valid size for start_id, 0 &lt;= i &lt; size</param>
    public virtual void SetDataAccess(Efl.Ui.PositionManager.ObjectBatchCallback obj_access, Efl.Ui.PositionManager.SizeBatchCallback size_access, int size) {
        GCHandle obj_access_handle = GCHandle.Alloc(obj_access);
GCHandle size_access_handle = GCHandle.Alloc(size_access);
Efl.Ui.PositionManager.DataAccessV1Concrete.NativeMethods.efl_ui_position_manager_data_access_v1_data_access_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),GCHandle.ToIntPtr(obj_access_handle), Efl.Ui.PositionManager.ObjectBatchCallbackWrapper.Cb, Efl.Eo.Globals.free_gchandle, GCHandle.ToIntPtr(size_access_handle), Efl.Ui.PositionManager.SizeBatchCallbackWrapper.Cb, Efl.Eo.Globals.free_gchandle, size);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>This is the position and size of the viewport, where elements are displayed in. Entities outside this viewport will not be shown.</summary>
    public virtual void SetViewport(Eina.Rect viewport) {
        Eina.Rect.NativeStruct _in_viewport = viewport;
Efl.Ui.PositionManager.EntityConcrete.NativeMethods.efl_ui_position_manager_entity_viewport_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),_in_viewport);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Move the items relative to the viewport.
    /// The items that are managed with this position manager might be bigger than the actual viewport. The positioning of the layer where all items are on is described by these values. 0.0,0.0 means that layer is moved that the top left items are shown, 1.0,1.0 means, that the lower right items are shown.</summary>
    /// <param name="x">X position of the scroller, valid form 0 to 1.0</param>
    /// <param name="y">Y position of the scroller, valid form 0 to 1.0</param>
    public virtual void SetScrollPosition(double x, double y) {
        Efl.Ui.PositionManager.EntityConcrete.NativeMethods.efl_ui_position_manager_entity_scroll_position_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),x, y);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Returns the version of Data_Access that is used. This object needs to implement the interface <see cref="Efl.Ui.PositionManager.IDataAccessV1"/> if 1 is returned.</summary>
    /// <param name="max">The maximum version that is available from the data-provider.</param>
    /// <returns>The version that should be used here. 0 is an error.</returns>
    public virtual int Version(int max) {
        var _ret_var = Efl.Ui.PositionManager.EntityConcrete.NativeMethods.efl_ui_position_manager_entity_version_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),max);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Return the position and size of item idx.
    /// This method returns the size and position of the item at <c>idx</c>. Even if the item is outside the viewport, the returned rectangle must be valid. The result can be used for scrolling calculations.</summary>
    /// <param name="idx">The id for the item</param>
    /// <returns>Position and Size in canvas coordinates.</returns>
    public virtual Eina.Rect PositionSingleItem(int idx) {
        var _ret_var = Efl.Ui.PositionManager.EntityConcrete.NativeMethods.efl_ui_position_manager_entity_position_single_item_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),idx);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>The new item <c>subobj</c> has been added at the <c>added_index</c> field.
    /// The accessor provided through <see cref="Efl.Ui.PositionManager.IDataAccessV1.SetDataAccess"/> will contain updated Entities.</summary>
    public virtual void ItemAdded(int added_index, Efl.Gfx.IEntity subobj) {
        Efl.Ui.PositionManager.EntityConcrete.NativeMethods.efl_ui_position_manager_entity_item_added_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),added_index, subobj);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The item <c>subobj</c> previously at position <c>removed_index</c> has been removed. The accessor provided through <see cref="Efl.Ui.PositionManager.IDataAccessV1.SetDataAccess"/> will contain updated Entities.</summary>
    public virtual void ItemRemoved(int removed_index, Efl.Gfx.IEntity subobj) {
        Efl.Ui.PositionManager.EntityConcrete.NativeMethods.efl_ui_position_manager_entity_item_removed_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),removed_index, subobj);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The size of the items from <c>start_id</c> to <c>end_id</c> have been changed. The positioning and sizing of all items will be updated</summary>
    /// <param name="start_id">The first item that has a new size</param>
    /// <param name="end_id">The last item that has a new size</param>
    public virtual void ItemSizeChanged(int start_id, int end_id) {
        Efl.Ui.PositionManager.EntityConcrete.NativeMethods.efl_ui_position_manager_entity_item_size_changed_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),start_id, end_id);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>The items from <c>start_id</c> to <c>end_id</c> now have their entities ready
    /// The position manager will reapply the geometry to the elements if they are visible.</summary>
    /// <param name="start_id">The first item that is available</param>
    /// <param name="end_id">The last item that is available</param>
    public virtual void EntitiesReady(uint start_id, uint end_id) {
        Efl.Ui.PositionManager.EntityConcrete.NativeMethods.efl_ui_position_manager_entity_entities_ready_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),start_id, end_id);
        Eina.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Translates the <c>current_id</c>, into a new id which is oriented in the <c>direction</c> of <c>current_id</c>. In case that there is no item, -1 is returned</summary>
    /// <param name="current_id">The id where the direction is oriented at</param>
    /// <param name="direction">The direction where the new id is</param>
    /// <returns>The id of the item in that direction, or -1 if there is no item in that direction</returns>
    public virtual int RelativeItem(uint current_id, Efl.Ui.Focus.Direction direction) {
        var _ret_var = Efl.Ui.PositionManager.EntityConcrete.NativeMethods.efl_ui_position_manager_entity_relative_item_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),current_id, direction);
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
    /// <c>obj_access</c> gives access to the graphical entities to manage. Some of them might be <c>NULL</c>, meaning they are not yet ready to be displayed. Their size in the <c>size_access</c> array will be correct, though, so other entities can still be positioned correctly. Typically, only entities inside the viewport will be retrieved.
    /// 
    /// <c>size_access</c> gives access to the 2D sizes for the items to manage. All sizes will always be valid, and might change over time (indicated through the <see cref="Efl.Ui.PositionManager.IEntity.ItemSizeChanged"/> method). The whole range might need to be traversed in order to calculate the position of all items in some arrangements.
    /// 
    /// You can access a batch of objects or sizes by calling the here passed function callbacks. Further details can be found at the function definitions.</summary>
    /// <value>Function callback for canvas objects, even if the start_id is valid, the returned objects may be <c>NULL</c>.</value>
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
        return Efl.Ui.PositionManager.List.efl_ui_position_manager_list_class_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Object.NativeMethods
    {
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            if (includeInherited)
            {
                var all_interfaces = type.GetInterfaces();
                foreach (var iface in all_interfaces)
                {
                    var moredescs = ((Efl.Eo.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is Efl.Eo.NativeClass))?.GetEoOps(type, false);
                    if (moredescs != null)
                        descs.AddRange(moredescs);
                }
            }
            descs.AddRange(base.GetEoOps(type, false));
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Ui.PositionManager.List.efl_ui_position_manager_list_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_Ui_Position_ManagerList_ExtensionMethods {
    public static Efl.BindableProperty<Efl.Ui.LayoutOrientation> Orientation<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.PositionManager.List, T>magic = null) where T : Efl.Ui.PositionManager.List {
        return new Efl.BindableProperty<Efl.Ui.LayoutOrientation>("orientation", fac);
    }

    public static Efl.BindableProperty<Eina.Rect> Viewport<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.PositionManager.List, T>magic = null) where T : Efl.Ui.PositionManager.List {
        return new Efl.BindableProperty<Eina.Rect>("viewport", fac);
    }

}
#pragma warning restore CS1591
#endif
