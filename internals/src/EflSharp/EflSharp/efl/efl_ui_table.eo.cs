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

/// <summary>Widget container that arranges its elements in a grid.
/// The amount of rows and columns can be controlled with <see cref="Efl.IPackTable.TableRows"/> and <see cref="Efl.IPackTable.TableColumns"/>, and elements can be manually positioned with <see cref="Efl.IPackTable.PackTable"/>. Additionally, a fill direction can be defined with <see cref="Efl.Ui.ILayoutOrientable.Orientation"/> and elements added with <see cref="Efl.IPack.Pack"/>. Elements are then added following this direction (horizontal or vertical) and when the amount of columns or rows has been reached, a step is taken in the orthogonal direction. In this second case there is no need to define both the amount of columns and rows, as the table will expand as needed. The default fill direction is <see cref="Efl.Ui.LayoutOrientation.Horizontal"/>.</summary>
[Efl.Ui.Table.NativeMethods]
[Efl.Eo.BindingEntity]
public class Table : Efl.Ui.Widget, Efl.IContainer, Efl.IPack, Efl.IPackLayout, Efl.IPackTable, Efl.Gfx.IArrangement, Efl.Ui.ILayoutOrientable
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Table))
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
        efl_ui_table_class_get();
    /// <summary>Initializes a new instance of the <see cref="Table"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="Efl.Ui.Widget.SetStyle" /></param>
    public Table(Efl.Object parent
            , System.String style = null) : base(efl_ui_table_class_get(), parent)
    {
        if (Efl.Eo.Globals.ParamHelperCheck(style))
        {
            SetStyle(Efl.Eo.Globals.GetParamHelper(style));
        }

        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected Table(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Table"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Table(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Table"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Table(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Sent after a new sub-object was added.
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.ContainerContentAddedEventArgs"/></value>
    public event EventHandler<Efl.ContainerContentAddedEventArgs> ContentAddedEvent
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
                        Efl.ContainerContentAddedEventArgs args = new Efl.ContainerContentAddedEventArgs();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Gfx.EntityConcrete);
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

                string key = "_EFL_CONTAINER_EVENT_CONTENT_ADDED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_CONTAINER_EVENT_CONTENT_ADDED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ContentAddedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnContentAddedEvent(Efl.ContainerContentAddedEventArgs e)
    {
        var key = "_EFL_CONTAINER_EVENT_CONTENT_ADDED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Sent after a sub-object was removed, before unref.
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.ContainerContentRemovedEventArgs"/></value>
    public event EventHandler<Efl.ContainerContentRemovedEventArgs> ContentRemovedEvent
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
                        Efl.ContainerContentRemovedEventArgs args = new Efl.ContainerContentRemovedEventArgs();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Gfx.EntityConcrete);
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

                string key = "_EFL_CONTAINER_EVENT_CONTENT_REMOVED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_CONTAINER_EVENT_CONTENT_REMOVED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event ContentRemovedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnContentRemovedEvent(Efl.ContainerContentRemovedEventArgs e)
    {
        var key = "_EFL_CONTAINER_EVENT_CONTENT_REMOVED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>Sent after the layout was updated.</summary>
    public event EventHandler LayoutUpdatedEvent
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
                        EventArgs args = EventArgs.Empty;
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

                string key = "_EFL_PACK_EVENT_LAYOUT_UPDATED";
                AddNativeEventHandler(efl.Libs.Elementary, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_PACK_EVENT_LAYOUT_UPDATED";
                RemoveNativeEventHandler(efl.Libs.Elementary, key, value);
            }
        }
    }
    /// <summary>Method to raise event LayoutUpdatedEvent.</summary>
    /// <param name="e">Event to raise.</param>
    public void OnLayoutUpdatedEvent(EventArgs e)
    {
        var key = "_EFL_PACK_EVENT_LAYOUT_UPDATED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Elementary, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, IntPtr.Zero);
    }
    /// <summary>Control homogeneous mode.
    /// This will enable the homogeneous mode where cells are of the same weight and of the same min size which is determined by maximum min size of cells.</summary>
    /// <param name="homogeneoush"><c>true</c> if the box is homogeneous horizontally, <c>false</c> otherwise</param>
    /// <param name="homogeneousv"><c>true</c> if the box is homogeneous vertically, <c>false</c> otherwise</param>
    public virtual void GetHomogeneous(out bool homogeneoush, out bool homogeneousv) {
                                                         Efl.Ui.Table.NativeMethods.efl_ui_table_homogeneous_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out homogeneoush, out homogeneousv);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Control homogeneous mode.
    /// This will enable the homogeneous mode where cells are of the same weight and of the same min size which is determined by maximum min size of cells.</summary>
    /// <param name="homogeneoush"><c>true</c> if the box is homogeneous horizontally, <c>false</c> otherwise</param>
    /// <param name="homogeneousv"><c>true</c> if the box is homogeneous vertically, <c>false</c> otherwise</param>
    public virtual void SetHomogeneous(bool homogeneoush, bool homogeneousv) {
                                                         Efl.Ui.Table.NativeMethods.efl_ui_table_homogeneous_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),homogeneoush, homogeneousv);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Begin iterating over this object&apos;s contents.
    /// (Since EFL 1.22)</summary>
    /// <returns>Iterator on object&apos;s content.</returns>
    public virtual Eina.Iterator<Efl.Gfx.IEntity> ContentIterate() {
         var _ret_var = Efl.ContainerConcrete.NativeMethods.efl_content_iterate_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Iterator<Efl.Gfx.IEntity>(_ret_var, true);
 }
    /// <summary>Returns the number of contained sub-objects.
    /// (Since EFL 1.22)</summary>
    /// <returns>Number of sub-objects.</returns>
    public virtual int ContentCount() {
         var _ret_var = Efl.ContainerConcrete.NativeMethods.efl_content_count_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Removes all packed sub-objects and unreferences them.</summary>
    /// <returns><c>true</c> on success, <c>false</c> otherwise.</returns>
    public virtual bool ClearPack() {
         var _ret_var = Efl.PackConcrete.NativeMethods.efl_pack_clear_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Removes all packed sub-objects without unreferencing them.
    /// Use with caution.</summary>
    /// <returns><c>true</c> on success, <c>false</c> otherwise.</returns>
    public virtual bool UnpackAll() {
         var _ret_var = Efl.PackConcrete.NativeMethods.efl_pack_unpack_all_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Removes an existing sub-object from the container without deleting it.</summary>
    /// <param name="subobj">The sub-object to unpack.</param>
    /// <returns><c>false</c> if <c>subobj</c> wasn&apos;t in the container or couldn&apos;t be removed.</returns>
    public virtual bool Unpack(Efl.Gfx.IEntity subobj) {
                                 var _ret_var = Efl.PackConcrete.NativeMethods.efl_pack_unpack_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),subobj);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Adds a sub-object to this container.
    /// Depending on the container this will either fill in the default spot, replacing any already existing element or append to the end of the container if there is no default part.
    /// 
    /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
    /// <param name="subobj">The object to pack.</param>
    /// <returns><c>false</c> if <c>subobj</c> could not be packed.</returns>
    public virtual bool Pack(Efl.Gfx.IEntity subobj) {
                                 var _ret_var = Efl.PackConcrete.NativeMethods.efl_pack_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),subobj);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Requests EFL to recalculate the layout of this object.
    /// Internal layout methods might be called asynchronously.</summary>
    public virtual void LayoutRequest() {
         Efl.PackLayoutConcrete.NativeMethods.efl_pack_layout_request_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>Implementation of this container&apos;s layout algorithm.
    /// EFL will call this function whenever the contents of this container need to be re-laid out on the canvas.
    /// 
    /// This can be overridden to implement custom layout behaviors.</summary>
    protected virtual void UpdateLayout() {
         Efl.PackLayoutConcrete.NativeMethods.efl_pack_layout_update_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
         }
    /// <summary>column of the <c>subobj</c> in this container.</summary>
    /// <param name="subobj">Child object</param>
    /// <param name="col">Column number</param>
    /// <param name="colspan">Column span</param>
    /// <returns>Returns false if item is not a child</returns>
    public virtual bool GetTableCellColumn(Efl.Gfx.IEntity subobj, out int col, out int colspan) {
                                                                                 var _ret_var = Efl.PackTableConcrete.NativeMethods.efl_pack_table_cell_column_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),subobj, out col, out colspan);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>column of the <c>subobj</c> in this container.</summary>
    /// <param name="subobj">Child object</param>
    /// <param name="col">Column number</param>
    /// <param name="colspan">Column span</param>
    public virtual void SetTableCellColumn(Efl.Gfx.IEntity subobj, int col, int colspan) {
                                                                                 Efl.PackTableConcrete.NativeMethods.efl_pack_table_cell_column_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),subobj, col, colspan);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>row of the <c>subobj</c> in this container.</summary>
    /// <param name="subobj">Child object</param>
    /// <param name="row">Row number</param>
    /// <param name="rowspan">Row span</param>
    /// <returns>Returns false if item is not a child</returns>
    public virtual bool GetTableCellRow(Efl.Gfx.IEntity subobj, out int row, out int rowspan) {
                                                                                 var _ret_var = Efl.PackTableConcrete.NativeMethods.efl_pack_table_cell_row_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),subobj, out row, out rowspan);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>row of the <c>subobj</c> in this container.</summary>
    /// <param name="subobj">Child object</param>
    /// <param name="row">Row number</param>
    /// <param name="rowspan">Row span</param>
    public virtual void SetTableCellRow(Efl.Gfx.IEntity subobj, int row, int rowspan) {
                                                                                 Efl.PackTableConcrete.NativeMethods.efl_pack_table_cell_row_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),subobj, row, rowspan);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Combines <see cref="Efl.IPackTable.TableColumns"/> and <see cref="Efl.IPackTable.TableRows"/></summary>
    /// <param name="cols">Number of columns</param>
    /// <param name="rows">Number of rows</param>
    public virtual void GetTableSize(out int cols, out int rows) {
                                                         Efl.PackTableConcrete.NativeMethods.efl_pack_table_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out cols, out rows);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Combines <see cref="Efl.IPackTable.TableColumns"/> and <see cref="Efl.IPackTable.TableRows"/></summary>
    /// <param name="cols">Number of columns</param>
    /// <param name="rows">Number of rows</param>
    public virtual void SetTableSize(int cols, int rows) {
                                                         Efl.PackTableConcrete.NativeMethods.efl_pack_table_size_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cols, rows);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Specifies the amount of columns the table will have when the fill direction is horizontal. If it is vertical, the amount of columns depends on the amount of cells added and <see cref="Efl.IPackTable.TableRows"/>.</summary>
    /// <returns>Amount of columns.</returns>
    public virtual int GetTableColumns() {
         var _ret_var = Efl.PackTableConcrete.NativeMethods.efl_pack_table_columns_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Specifies the amount of columns the table will have when the fill direction is horizontal. If it is vertical, the amount of columns depends on the amount of cells added and <see cref="Efl.IPackTable.TableRows"/>.</summary>
    /// <param name="cols">Amount of columns.</param>
    public virtual void SetTableColumns(int cols) {
                                 Efl.PackTableConcrete.NativeMethods.efl_pack_table_columns_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),cols);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Specifies the amount of rows the table will have when the fill direction is vertical. If it is horizontal, the amount of rows depends on the amount of cells added and <see cref="Efl.IPackTable.TableColumns"/>.</summary>
    /// <returns>Amount of rows.</returns>
    public virtual int GetTableRows() {
         var _ret_var = Efl.PackTableConcrete.NativeMethods.efl_pack_table_rows_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Specifies the amount of rows the table will have when the fill direction is vertical. If it is horizontal, the amount of rows depends on the amount of cells added and <see cref="Efl.IPackTable.TableColumns"/>.</summary>
    /// <param name="rows">Amount of rows.</param>
    public virtual void SetTableRows(int rows) {
                                 Efl.PackTableConcrete.NativeMethods.efl_pack_table_rows_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),rows);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Pack object at a given location in the table.
    /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
    /// <param name="subobj">A child object to pack in this table.</param>
    /// <param name="col">Column number</param>
    /// <param name="row">Row number</param>
    /// <param name="colspan">0 means 1, -1 means <see cref="Efl.IPackTable.TableColumns"/></param>
    /// <param name="rowspan">0 means 1, -1 means <see cref="Efl.IPackTable.TableRows"/></param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    public virtual bool PackTable(Efl.Gfx.IEntity subobj, int col, int row, int colspan, int rowspan) {
                                                                                                                                 var _ret_var = Efl.PackTableConcrete.NativeMethods.efl_pack_table_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),subobj, col, row, colspan, rowspan);
        Eina.Error.RaiseIfUnhandledException();
                                                                                        return _ret_var;
 }
    /// <summary>Returns all objects at a given position in this table.</summary>
    /// <param name="col">Column number</param>
    /// <param name="row">Row number</param>
    /// <param name="below">If <c>true</c> get objects spanning over this cell.</param>
    /// <returns>Iterator to table contents</returns>
    public virtual Eina.Iterator<Efl.Gfx.IEntity> GetTableContents(int col, int row, bool below) {
                                                                                 var _ret_var = Efl.PackTableConcrete.NativeMethods.efl_pack_table_contents_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),col, row, below);
        Eina.Error.RaiseIfUnhandledException();
                                                        return new Eina.Iterator<Efl.Gfx.IEntity>(_ret_var, true);
 }
    /// <summary>Returns a child at a given position, see <see cref="Efl.IPackTable.GetTableContents"/>.</summary>
    /// <param name="col">Column number</param>
    /// <param name="row">Row number</param>
    /// <returns>Child object</returns>
    public virtual Efl.Gfx.IEntity GetTableContent(int col, int row) {
                                                         var _ret_var = Efl.PackTableConcrete.NativeMethods.efl_pack_table_content_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),col, row);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>This property determines how contents will be aligned within a container if there is unused space.
    /// It is different than the <see cref="Efl.Gfx.IHint.GetHintAlign"/> property in that it affects the position of all the contents within the container. For example, if a box widget has extra space on the horizontal axis, this property can be used to align the box&apos;s contents to the left or the right side.
    /// 
    /// See also <see cref="Efl.Gfx.IHint.GetHintAlign"/>.
    /// (Since EFL 1.23)</summary>
    /// <param name="align_horiz">Double, ranging from 0.0 to 1.0, where 0.0 is at the start of the horizontal axis and 1.0 is at the end. The default value is 0.5.</param>
    /// <param name="align_vert">Double, ranging from 0.0 to 1.0, where 0.0 is at the start of the vertical axis and 1.0 is at the end. The default value is 0.5.</param>
    public virtual void GetContentAlign(out double align_horiz, out double align_vert) {
                                                         Efl.Gfx.ArrangementConcrete.NativeMethods.efl_gfx_arrangement_content_align_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out align_horiz, out align_vert);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>This property determines how contents will be aligned within a container if there is unused space.
    /// It is different than the <see cref="Efl.Gfx.IHint.GetHintAlign"/> property in that it affects the position of all the contents within the container. For example, if a box widget has extra space on the horizontal axis, this property can be used to align the box&apos;s contents to the left or the right side.
    /// 
    /// See also <see cref="Efl.Gfx.IHint.GetHintAlign"/>.
    /// (Since EFL 1.23)</summary>
    /// <param name="align_horiz">Double, ranging from 0.0 to 1.0, where 0.0 is at the start of the horizontal axis and 1.0 is at the end. The default value is 0.5.</param>
    /// <param name="align_vert">Double, ranging from 0.0 to 1.0, where 0.0 is at the start of the vertical axis and 1.0 is at the end. The default value is 0.5.</param>
    public virtual void SetContentAlign(double align_horiz, double align_vert) {
                                                         Efl.Gfx.ArrangementConcrete.NativeMethods.efl_gfx_arrangement_content_align_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),align_horiz, align_vert);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>This property determines the space between a container&apos;s content items.
    /// It is different than the <see cref="Efl.Gfx.IHint.GetHintMargin"/> property in that it is applied to each content item within the container instead of a single item. The calculation for these two properties is cumulative.
    /// 
    /// See also <see cref="Efl.Gfx.IHint.GetHintMargin"/>.
    /// (Since EFL 1.23)</summary>
    /// <param name="pad_horiz">Horizontal padding. The default value is 0.0.</param>
    /// <param name="pad_vert">Vertical padding. The default value is 0.0.</param>
    /// <param name="scalable"><c>true</c> if scalable, <c>false</c> otherwise. The default value is <c>false</c>.</param>
    public virtual void GetContentPadding(out double pad_horiz, out double pad_vert, out bool scalable) {
                                                                                 Efl.Gfx.ArrangementConcrete.NativeMethods.efl_gfx_arrangement_content_padding_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),out pad_horiz, out pad_vert, out scalable);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>This property determines the space between a container&apos;s content items.
    /// It is different than the <see cref="Efl.Gfx.IHint.GetHintMargin"/> property in that it is applied to each content item within the container instead of a single item. The calculation for these two properties is cumulative.
    /// 
    /// See also <see cref="Efl.Gfx.IHint.GetHintMargin"/>.
    /// (Since EFL 1.23)</summary>
    /// <param name="pad_horiz">Horizontal padding. The default value is 0.0.</param>
    /// <param name="pad_vert">Vertical padding. The default value is 0.0.</param>
    /// <param name="scalable"><c>true</c> if scalable, <c>false</c> otherwise. The default value is <c>false</c>.</param>
    public virtual void SetContentPadding(double pad_horiz, double pad_vert, bool scalable) {
                                                                                 Efl.Gfx.ArrangementConcrete.NativeMethods.efl_gfx_arrangement_content_padding_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),pad_horiz, pad_vert, scalable);
        Eina.Error.RaiseIfUnhandledException();
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
    /// <summary>Control homogeneous mode.
    /// This will enable the homogeneous mode where cells are of the same weight and of the same min size which is determined by maximum min size of cells.</summary>
    /// <value><c>true</c> if the box is homogeneous horizontally, <c>false</c> otherwise</value>
    public (bool, bool) Homogeneous {
        get {
            bool _out_homogeneoush = default(bool);
            bool _out_homogeneousv = default(bool);
            GetHomogeneous(out _out_homogeneoush,out _out_homogeneousv);
            return (_out_homogeneoush,_out_homogeneousv);
        }
        set { SetHomogeneous( value.Item1,  value.Item2); }
    }
    /// <summary>Combines <see cref="Efl.IPackTable.TableColumns"/> and <see cref="Efl.IPackTable.TableRows"/></summary>
    /// <value>Number of columns</value>
    public (int, int) TableSize {
        get {
            int _out_cols = default(int);
            int _out_rows = default(int);
            GetTableSize(out _out_cols,out _out_rows);
            return (_out_cols,_out_rows);
        }
        set { SetTableSize( value.Item1,  value.Item2); }
    }
    /// <summary>Specifies the amount of columns the table will have when the fill direction is horizontal. If it is vertical, the amount of columns depends on the amount of cells added and <see cref="Efl.IPackTable.TableRows"/>.</summary>
    /// <value>Amount of columns.</value>
    public int TableColumns {
        get { return GetTableColumns(); }
        set { SetTableColumns(value); }
    }
    /// <summary>Specifies the amount of rows the table will have when the fill direction is vertical. If it is horizontal, the amount of rows depends on the amount of cells added and <see cref="Efl.IPackTable.TableColumns"/>.</summary>
    /// <value>Amount of rows.</value>
    public int TableRows {
        get { return GetTableRows(); }
        set { SetTableRows(value); }
    }
    /// <summary>This property determines how contents will be aligned within a container if there is unused space.
    /// It is different than the <see cref="Efl.Gfx.IHint.GetHintAlign"/> property in that it affects the position of all the contents within the container. For example, if a box widget has extra space on the horizontal axis, this property can be used to align the box&apos;s contents to the left or the right side.
    /// 
    /// See also <see cref="Efl.Gfx.IHint.GetHintAlign"/>.
    /// (Since EFL 1.23)</summary>
    /// <value>Double, ranging from 0.0 to 1.0, where 0.0 is at the start of the horizontal axis and 1.0 is at the end. The default value is 0.5.</value>
    public (double, double) ContentAlign {
        get {
            double _out_align_horiz = default(double);
            double _out_align_vert = default(double);
            GetContentAlign(out _out_align_horiz,out _out_align_vert);
            return (_out_align_horiz,_out_align_vert);
        }
        set { SetContentAlign( value.Item1,  value.Item2); }
    }
    /// <summary>This property determines the space between a container&apos;s content items.
    /// It is different than the <see cref="Efl.Gfx.IHint.GetHintMargin"/> property in that it is applied to each content item within the container instead of a single item. The calculation for these two properties is cumulative.
    /// 
    /// See also <see cref="Efl.Gfx.IHint.GetHintMargin"/>.
    /// (Since EFL 1.23)</summary>
    /// <value>Horizontal padding. The default value is 0.0.</value>
    public (double, double, bool) ContentPadding {
        get {
            double _out_pad_horiz = default(double);
            double _out_pad_vert = default(double);
            bool _out_scalable = default(bool);
            GetContentPadding(out _out_pad_horiz,out _out_pad_vert,out _out_scalable);
            return (_out_pad_horiz,_out_pad_vert,_out_scalable);
        }
        set { SetContentPadding( value.Item1,  value.Item2,  value.Item3); }
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
        return Efl.Ui.Table.efl_ui_table_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Ui.Widget.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Elementary);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_ui_table_homogeneous_get_static_delegate == null)
            {
                efl_ui_table_homogeneous_get_static_delegate = new efl_ui_table_homogeneous_get_delegate(homogeneous_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetHomogeneous") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_table_homogeneous_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_table_homogeneous_get_static_delegate) });
            }

            if (efl_ui_table_homogeneous_set_static_delegate == null)
            {
                efl_ui_table_homogeneous_set_static_delegate = new efl_ui_table_homogeneous_set_delegate(homogeneous_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetHomogeneous") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_table_homogeneous_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_table_homogeneous_set_static_delegate) });
            }

            if (efl_pack_layout_update_static_delegate == null)
            {
                efl_pack_layout_update_static_delegate = new efl_pack_layout_update_delegate(layout_update);
            }

            if (methods.FirstOrDefault(m => m.Name == "UpdateLayout") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_layout_update"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_layout_update_static_delegate) });
            }

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
            return Efl.Ui.Table.efl_ui_table_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_ui_table_homogeneous_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] out bool homogeneoush, [MarshalAs(UnmanagedType.U1)] out bool homogeneousv);

        
        public delegate void efl_ui_table_homogeneous_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] out bool homogeneoush, [MarshalAs(UnmanagedType.U1)] out bool homogeneousv);

        public static Efl.Eo.FunctionWrapper<efl_ui_table_homogeneous_get_api_delegate> efl_ui_table_homogeneous_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_table_homogeneous_get_api_delegate>(Module, "efl_ui_table_homogeneous_get");

        private static void homogeneous_get(System.IntPtr obj, System.IntPtr pd, out bool homogeneoush, out bool homogeneousv)
        {
            Eina.Log.Debug("function efl_ui_table_homogeneous_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        homogeneoush = default(bool);        homogeneousv = default(bool);                            
                try
                {
                    ((Table)ws.Target).GetHomogeneous(out homogeneoush, out homogeneousv);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_table_homogeneous_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out homogeneoush, out homogeneousv);
            }
        }

        private static efl_ui_table_homogeneous_get_delegate efl_ui_table_homogeneous_get_static_delegate;

        
        private delegate void efl_ui_table_homogeneous_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool homogeneoush, [MarshalAs(UnmanagedType.U1)] bool homogeneousv);

        
        public delegate void efl_ui_table_homogeneous_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool homogeneoush, [MarshalAs(UnmanagedType.U1)] bool homogeneousv);

        public static Efl.Eo.FunctionWrapper<efl_ui_table_homogeneous_set_api_delegate> efl_ui_table_homogeneous_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_table_homogeneous_set_api_delegate>(Module, "efl_ui_table_homogeneous_set");

        private static void homogeneous_set(System.IntPtr obj, System.IntPtr pd, bool homogeneoush, bool homogeneousv)
        {
            Eina.Log.Debug("function efl_ui_table_homogeneous_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Table)ws.Target).SetHomogeneous(homogeneoush, homogeneousv);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_ui_table_homogeneous_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), homogeneoush, homogeneousv);
            }
        }

        private static efl_ui_table_homogeneous_set_delegate efl_ui_table_homogeneous_set_static_delegate;

        
        private delegate void efl_pack_layout_update_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate void efl_pack_layout_update_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_pack_layout_update_api_delegate> efl_pack_layout_update_ptr = new Efl.Eo.FunctionWrapper<efl_pack_layout_update_api_delegate>(Module, "efl_pack_layout_update");

        private static void layout_update(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_pack_layout_update was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            
                try
                {
                    ((Table)ws.Target).UpdateLayout();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        
            }
            else
            {
                efl_pack_layout_update_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_pack_layout_update_delegate efl_pack_layout_update_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

}

#if EFL_BETA
#pragma warning disable CS1591
public static class Efl_UiTable_ExtensionMethods {
    
    
    
    
    public static Efl.BindableProperty<int> TableColumns<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Table, T>magic = null) where T : Efl.Ui.Table {
        return new Efl.BindableProperty<int>("table_columns", fac);
    }

    public static Efl.BindableProperty<int> TableRows<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Table, T>magic = null) where T : Efl.Ui.Table {
        return new Efl.BindableProperty<int>("table_rows", fac);
    }

    
    
    public static Efl.BindableProperty<Efl.Ui.LayoutOrientation> Orientation<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.Ui.Table, T>magic = null) where T : Efl.Ui.Table {
        return new Efl.BindableProperty<Efl.Ui.LayoutOrientation>("orientation", fac);
    }

}
#pragma warning restore CS1591
#endif
