#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

/// <summary>Interface for 2D containers which arrange their elements on a table with rows and columns.
/// Elements can be positioned on a specific row and column, or they can be simply added to the table using <see cref="Efl.IPack.Pack"/> and the container will chose where to put them.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.IPackTableConcrete.NativeMethods]
[Efl.Eo.BindingEntity]
public interface IPackTable : 
    Efl.IPack ,
    Efl.Eo.IWrapper, IDisposable
{
    /// <summary>column of the <c>subobj</c> in this container.</summary>
/// <param name="subobj">Child object</param>
/// <param name="col">Column number</param>
/// <param name="colspan">Column span</param>
/// <returns>Returns false if item is not a child</returns>
bool GetTableCellColumn(Efl.Gfx.IEntity subobj, out int col, out int colspan);
    /// <summary>column of the <c>subobj</c> in this container.</summary>
/// <param name="subobj">Child object</param>
/// <param name="col">Column number</param>
/// <param name="colspan">Column span</param>
void SetTableCellColumn(Efl.Gfx.IEntity subobj, int col, int colspan);
    /// <summary>row of the <c>subobj</c> in this container.</summary>
/// <param name="subobj">Child object</param>
/// <param name="row">Row number</param>
/// <param name="rowspan">Row span</param>
/// <returns>Returns false if item is not a child</returns>
bool GetTableCellRow(Efl.Gfx.IEntity subobj, out int row, out int rowspan);
    /// <summary>row of the <c>subobj</c> in this container.</summary>
/// <param name="subobj">Child object</param>
/// <param name="row">Row number</param>
/// <param name="rowspan">Row span</param>
void SetTableCellRow(Efl.Gfx.IEntity subobj, int row, int rowspan);
    /// <summary>Combines <see cref="Efl.IPackTable.TableColumns"/> and <see cref="Efl.IPackTable.TableRows"/></summary>
/// <param name="cols">Number of columns</param>
/// <param name="rows">Number of rows</param>
void GetTableSize(out int cols, out int rows);
    /// <summary>Combines <see cref="Efl.IPackTable.TableColumns"/> and <see cref="Efl.IPackTable.TableRows"/></summary>
/// <param name="cols">Number of columns</param>
/// <param name="rows">Number of rows</param>
void SetTableSize(int cols, int rows);
    /// <summary>Specifies the amount of columns the table will have when the fill direction is horizontal. If it is vertical, the amount of columns depends on the amount of cells added and <see cref="Efl.IPackTable.TableRows"/>.</summary>
/// <returns>Amount of columns.</returns>
int GetTableColumns();
    /// <summary>Specifies the amount of columns the table will have when the fill direction is horizontal. If it is vertical, the amount of columns depends on the amount of cells added and <see cref="Efl.IPackTable.TableRows"/>.</summary>
/// <param name="cols">Amount of columns.</param>
void SetTableColumns(int cols);
    /// <summary>Specifies the amount of rows the table will have when the fill direction is vertical. If it is horizontal, the amount of rows depends on the amount of cells added and <see cref="Efl.IPackTable.TableColumns"/>.</summary>
/// <returns>Amount of rows.</returns>
int GetTableRows();
    /// <summary>Specifies the amount of rows the table will have when the fill direction is vertical. If it is horizontal, the amount of rows depends on the amount of cells added and <see cref="Efl.IPackTable.TableColumns"/>.</summary>
/// <param name="rows">Amount of rows.</param>
void SetTableRows(int rows);
    /// <summary>Pack object at a given location in the table.
/// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
/// <param name="subobj">A child object to pack in this table.</param>
/// <param name="col">Column number</param>
/// <param name="row">Row number</param>
/// <param name="colspan">0 means 1, -1 means <see cref="Efl.IPackTable.TableColumns"/></param>
/// <param name="rowspan">0 means 1, -1 means <see cref="Efl.IPackTable.TableRows"/></param>
/// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
bool PackTable(Efl.Gfx.IEntity subobj, int col, int row, int colspan, int rowspan);
    /// <summary>Returns all objects at a given position in this table.</summary>
/// <param name="col">Column number</param>
/// <param name="row">Row number</param>
/// <param name="below">If <c>true</c> get objects spanning over this cell.</param>
/// <returns>Iterator to table contents</returns>
Eina.Iterator<Efl.Gfx.IEntity> GetTableContents(int col, int row, bool below);
    /// <summary>Returns a child at a given position, see <see cref="Efl.IPackTable.GetTableContents"/>.</summary>
/// <param name="col">Column number</param>
/// <param name="row">Row number</param>
/// <returns>Child object</returns>
Efl.Gfx.IEntity GetTableContent(int col, int row);
                                                        /// <summary>Combines <see cref="Efl.IPackTable.TableColumns"/> and <see cref="Efl.IPackTable.TableRows"/></summary>
    /// <value>Number of columns</value>
    (int, int) TableSize {
        get;
        set;
    }
    /// <summary>Specifies the amount of columns the table will have when the fill direction is horizontal. If it is vertical, the amount of columns depends on the amount of cells added and <see cref="Efl.IPackTable.TableRows"/>.</summary>
    /// <value>Amount of columns.</value>
    int TableColumns {
        get;
        set;
    }
    /// <summary>Specifies the amount of rows the table will have when the fill direction is vertical. If it is horizontal, the amount of rows depends on the amount of cells added and <see cref="Efl.IPackTable.TableColumns"/>.</summary>
    /// <value>Amount of rows.</value>
    int TableRows {
        get;
        set;
    }
}
/// <summary>Interface for 2D containers which arrange their elements on a table with rows and columns.
/// Elements can be positioned on a specific row and column, or they can be simply added to the table using <see cref="Efl.IPack.Pack"/> and the container will chose where to put them.</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
sealed public  class IPackTableConcrete :
    Efl.Eo.EoWrapper
    , IPackTable
    , Efl.IContainer, Efl.IPack
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(IPackTableConcrete))
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
    private IPackTableConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_pack_table_interface_get();
    /// <summary>Initializes a new instance of the <see cref="IPackTable"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private IPackTableConcrete(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Sent after a new sub-object was added.
    /// (Since EFL 1.22)</summary>
    /// <value><see cref="Efl.IContainerContentAddedEvt_Args"/></value>
    public event EventHandler<Efl.IContainerContentAddedEvt_Args> ContentAddedEvt
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
                        Efl.IContainerContentAddedEvt_Args args = new Efl.IContainerContentAddedEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Gfx.IEntityConcrete);
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
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_CONTAINER_EVENT_CONTENT_ADDED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    /// <summary>Method to raise event ContentAddedEvt.</summary>
    public void OnContentAddedEvt(Efl.IContainerContentAddedEvt_Args e)
    {
        var key = "_EFL_CONTAINER_EVENT_CONTENT_ADDED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
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
    /// <value><see cref="Efl.IContainerContentRemovedEvt_Args"/></value>
    public event EventHandler<Efl.IContainerContentRemovedEvt_Args> ContentRemovedEvt
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
                        Efl.IContainerContentRemovedEvt_Args args = new Efl.IContainerContentRemovedEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Gfx.IEntityConcrete);
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
                AddNativeEventHandler(efl.Libs.Efl, key, callerCb, value);
            }
        }

        remove
        {
            lock (eflBindingEventLock)
            {
                string key = "_EFL_CONTAINER_EVENT_CONTENT_REMOVED";
                RemoveNativeEventHandler(efl.Libs.Efl, key, value);
            }
        }
    }
    /// <summary>Method to raise event ContentRemovedEvt.</summary>
    public void OnContentRemovedEvt(Efl.IContainerContentRemovedEvt_Args e)
    {
        var key = "_EFL_CONTAINER_EVENT_CONTENT_REMOVED";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Efl, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    /// <summary>column of the <c>subobj</c> in this container.</summary>
    /// <param name="subobj">Child object</param>
    /// <param name="col">Column number</param>
    /// <param name="colspan">Column span</param>
    /// <returns>Returns false if item is not a child</returns>
    public bool GetTableCellColumn(Efl.Gfx.IEntity subobj, out int col, out int colspan) {
                                                                                 var _ret_var = Efl.IPackTableConcrete.NativeMethods.efl_pack_table_cell_column_get_ptr.Value.Delegate(this.NativeHandle,subobj, out col, out colspan);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>column of the <c>subobj</c> in this container.</summary>
    /// <param name="subobj">Child object</param>
    /// <param name="col">Column number</param>
    /// <param name="colspan">Column span</param>
    public void SetTableCellColumn(Efl.Gfx.IEntity subobj, int col, int colspan) {
                                                                                 Efl.IPackTableConcrete.NativeMethods.efl_pack_table_cell_column_set_ptr.Value.Delegate(this.NativeHandle,subobj, col, colspan);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>row of the <c>subobj</c> in this container.</summary>
    /// <param name="subobj">Child object</param>
    /// <param name="row">Row number</param>
    /// <param name="rowspan">Row span</param>
    /// <returns>Returns false if item is not a child</returns>
    public bool GetTableCellRow(Efl.Gfx.IEntity subobj, out int row, out int rowspan) {
                                                                                 var _ret_var = Efl.IPackTableConcrete.NativeMethods.efl_pack_table_cell_row_get_ptr.Value.Delegate(this.NativeHandle,subobj, out row, out rowspan);
        Eina.Error.RaiseIfUnhandledException();
                                                        return _ret_var;
 }
    /// <summary>row of the <c>subobj</c> in this container.</summary>
    /// <param name="subobj">Child object</param>
    /// <param name="row">Row number</param>
    /// <param name="rowspan">Row span</param>
    public void SetTableCellRow(Efl.Gfx.IEntity subobj, int row, int rowspan) {
                                                                                 Efl.IPackTableConcrete.NativeMethods.efl_pack_table_cell_row_set_ptr.Value.Delegate(this.NativeHandle,subobj, row, rowspan);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Combines <see cref="Efl.IPackTable.TableColumns"/> and <see cref="Efl.IPackTable.TableRows"/></summary>
    /// <param name="cols">Number of columns</param>
    /// <param name="rows">Number of rows</param>
    public void GetTableSize(out int cols, out int rows) {
                                                         Efl.IPackTableConcrete.NativeMethods.efl_pack_table_size_get_ptr.Value.Delegate(this.NativeHandle,out cols, out rows);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Combines <see cref="Efl.IPackTable.TableColumns"/> and <see cref="Efl.IPackTable.TableRows"/></summary>
    /// <param name="cols">Number of columns</param>
    /// <param name="rows">Number of rows</param>
    public void SetTableSize(int cols, int rows) {
                                                         Efl.IPackTableConcrete.NativeMethods.efl_pack_table_size_set_ptr.Value.Delegate(this.NativeHandle,cols, rows);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Specifies the amount of columns the table will have when the fill direction is horizontal. If it is vertical, the amount of columns depends on the amount of cells added and <see cref="Efl.IPackTable.TableRows"/>.</summary>
    /// <returns>Amount of columns.</returns>
    public int GetTableColumns() {
         var _ret_var = Efl.IPackTableConcrete.NativeMethods.efl_pack_table_columns_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Specifies the amount of columns the table will have when the fill direction is horizontal. If it is vertical, the amount of columns depends on the amount of cells added and <see cref="Efl.IPackTable.TableRows"/>.</summary>
    /// <param name="cols">Amount of columns.</param>
    public void SetTableColumns(int cols) {
                                 Efl.IPackTableConcrete.NativeMethods.efl_pack_table_columns_set_ptr.Value.Delegate(this.NativeHandle,cols);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Specifies the amount of rows the table will have when the fill direction is vertical. If it is horizontal, the amount of rows depends on the amount of cells added and <see cref="Efl.IPackTable.TableColumns"/>.</summary>
    /// <returns>Amount of rows.</returns>
    public int GetTableRows() {
         var _ret_var = Efl.IPackTableConcrete.NativeMethods.efl_pack_table_rows_get_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Specifies the amount of rows the table will have when the fill direction is vertical. If it is horizontal, the amount of rows depends on the amount of cells added and <see cref="Efl.IPackTable.TableColumns"/>.</summary>
    /// <param name="rows">Amount of rows.</param>
    public void SetTableRows(int rows) {
                                 Efl.IPackTableConcrete.NativeMethods.efl_pack_table_rows_set_ptr.Value.Delegate(this.NativeHandle,rows);
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
    public bool PackTable(Efl.Gfx.IEntity subobj, int col, int row, int colspan, int rowspan) {
                                                                                                                                 var _ret_var = Efl.IPackTableConcrete.NativeMethods.efl_pack_table_ptr.Value.Delegate(this.NativeHandle,subobj, col, row, colspan, rowspan);
        Eina.Error.RaiseIfUnhandledException();
                                                                                        return _ret_var;
 }
    /// <summary>Returns all objects at a given position in this table.</summary>
    /// <param name="col">Column number</param>
    /// <param name="row">Row number</param>
    /// <param name="below">If <c>true</c> get objects spanning over this cell.</param>
    /// <returns>Iterator to table contents</returns>
    public Eina.Iterator<Efl.Gfx.IEntity> GetTableContents(int col, int row, bool below) {
                                                                                 var _ret_var = Efl.IPackTableConcrete.NativeMethods.efl_pack_table_contents_get_ptr.Value.Delegate(this.NativeHandle,col, row, below);
        Eina.Error.RaiseIfUnhandledException();
                                                        return new Eina.Iterator<Efl.Gfx.IEntity>(_ret_var, true);
 }
    /// <summary>Returns a child at a given position, see <see cref="Efl.IPackTable.GetTableContents"/>.</summary>
    /// <param name="col">Column number</param>
    /// <param name="row">Row number</param>
    /// <returns>Child object</returns>
    public Efl.Gfx.IEntity GetTableContent(int col, int row) {
                                                         var _ret_var = Efl.IPackTableConcrete.NativeMethods.efl_pack_table_content_get_ptr.Value.Delegate(this.NativeHandle,col, row);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Begin iterating over this object&apos;s contents.
    /// (Since EFL 1.22)</summary>
    /// <returns>Iterator on object&apos;s content.</returns>
    public Eina.Iterator<Efl.Gfx.IEntity> ContentIterate() {
         var _ret_var = Efl.IContainerConcrete.NativeMethods.efl_content_iterate_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Iterator<Efl.Gfx.IEntity>(_ret_var, true);
 }
    /// <summary>Returns the number of contained sub-objects.
    /// (Since EFL 1.22)</summary>
    /// <returns>Number of sub-objects.</returns>
    public int ContentCount() {
         var _ret_var = Efl.IContainerConcrete.NativeMethods.efl_content_count_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Removes all packed sub-objects and unreferences them.</summary>
    /// <returns><c>true</c> on success, <c>false</c> otherwise.</returns>
    public bool ClearPack() {
         var _ret_var = Efl.IPackConcrete.NativeMethods.efl_pack_clear_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Removes all packed sub-objects without unreferencing them.
    /// Use with caution.</summary>
    /// <returns><c>true</c> on success, <c>false</c> otherwise.</returns>
    public bool UnpackAll() {
         var _ret_var = Efl.IPackConcrete.NativeMethods.efl_pack_unpack_all_ptr.Value.Delegate(this.NativeHandle);
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Removes an existing sub-object from the container without deleting it.</summary>
    /// <param name="subobj">The sub-object to unpack.</param>
    /// <returns><c>false</c> if <c>subobj</c> wasn&apos;t in the container or couldn&apos;t be removed.</returns>
    public bool Unpack(Efl.Gfx.IEntity subobj) {
                                 var _ret_var = Efl.IPackConcrete.NativeMethods.efl_pack_unpack_ptr.Value.Delegate(this.NativeHandle,subobj);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Adds a sub-object to this container.
    /// Depending on the container this will either fill in the default spot, replacing any already existing element or append to the end of the container if there is no default part.
    /// 
    /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
    /// <param name="subobj">The object to pack.</param>
    /// <returns><c>false</c> if <c>subobj</c> could not be packed.</returns>
    public bool Pack(Efl.Gfx.IEntity subobj) {
                                 var _ret_var = Efl.IPackConcrete.NativeMethods.efl_pack_ptr.Value.Delegate(this.NativeHandle,subobj);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
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
    private static IntPtr GetEflClassStatic()
    {
        return Efl.IPackTableConcrete.efl_pack_table_interface_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Eo.EoWrapper.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Efl);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_pack_table_cell_column_get_static_delegate == null)
            {
                efl_pack_table_cell_column_get_static_delegate = new efl_pack_table_cell_column_get_delegate(table_cell_column_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetTableCellColumn") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_table_cell_column_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_cell_column_get_static_delegate) });
            }

            if (efl_pack_table_cell_column_set_static_delegate == null)
            {
                efl_pack_table_cell_column_set_static_delegate = new efl_pack_table_cell_column_set_delegate(table_cell_column_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetTableCellColumn") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_table_cell_column_set"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_cell_column_set_static_delegate) });
            }

            if (efl_pack_table_cell_row_get_static_delegate == null)
            {
                efl_pack_table_cell_row_get_static_delegate = new efl_pack_table_cell_row_get_delegate(table_cell_row_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetTableCellRow") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_table_cell_row_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_cell_row_get_static_delegate) });
            }

            if (efl_pack_table_cell_row_set_static_delegate == null)
            {
                efl_pack_table_cell_row_set_static_delegate = new efl_pack_table_cell_row_set_delegate(table_cell_row_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetTableCellRow") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_table_cell_row_set"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_cell_row_set_static_delegate) });
            }

            if (efl_pack_table_size_get_static_delegate == null)
            {
                efl_pack_table_size_get_static_delegate = new efl_pack_table_size_get_delegate(table_size_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetTableSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_table_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_size_get_static_delegate) });
            }

            if (efl_pack_table_size_set_static_delegate == null)
            {
                efl_pack_table_size_set_static_delegate = new efl_pack_table_size_set_delegate(table_size_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetTableSize") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_table_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_size_set_static_delegate) });
            }

            if (efl_pack_table_columns_get_static_delegate == null)
            {
                efl_pack_table_columns_get_static_delegate = new efl_pack_table_columns_get_delegate(table_columns_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetTableColumns") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_table_columns_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_columns_get_static_delegate) });
            }

            if (efl_pack_table_columns_set_static_delegate == null)
            {
                efl_pack_table_columns_set_static_delegate = new efl_pack_table_columns_set_delegate(table_columns_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetTableColumns") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_table_columns_set"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_columns_set_static_delegate) });
            }

            if (efl_pack_table_rows_get_static_delegate == null)
            {
                efl_pack_table_rows_get_static_delegate = new efl_pack_table_rows_get_delegate(table_rows_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetTableRows") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_table_rows_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_rows_get_static_delegate) });
            }

            if (efl_pack_table_rows_set_static_delegate == null)
            {
                efl_pack_table_rows_set_static_delegate = new efl_pack_table_rows_set_delegate(table_rows_set);
            }

            if (methods.FirstOrDefault(m => m.Name == "SetTableRows") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_table_rows_set"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_rows_set_static_delegate) });
            }

            if (efl_pack_table_static_delegate == null)
            {
                efl_pack_table_static_delegate = new efl_pack_table_delegate(pack_table);
            }

            if (methods.FirstOrDefault(m => m.Name == "PackTable") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_table"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_static_delegate) });
            }

            if (efl_pack_table_contents_get_static_delegate == null)
            {
                efl_pack_table_contents_get_static_delegate = new efl_pack_table_contents_get_delegate(table_contents_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetTableContents") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_table_contents_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_contents_get_static_delegate) });
            }

            if (efl_pack_table_content_get_static_delegate == null)
            {
                efl_pack_table_content_get_static_delegate = new efl_pack_table_content_get_delegate(table_content_get);
            }

            if (methods.FirstOrDefault(m => m.Name == "GetTableContent") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_table_content_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_content_get_static_delegate) });
            }

            if (efl_content_iterate_static_delegate == null)
            {
                efl_content_iterate_static_delegate = new efl_content_iterate_delegate(content_iterate);
            }

            if (methods.FirstOrDefault(m => m.Name == "ContentIterate") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_content_iterate"), func = Marshal.GetFunctionPointerForDelegate(efl_content_iterate_static_delegate) });
            }

            if (efl_content_count_static_delegate == null)
            {
                efl_content_count_static_delegate = new efl_content_count_delegate(content_count);
            }

            if (methods.FirstOrDefault(m => m.Name == "ContentCount") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_content_count"), func = Marshal.GetFunctionPointerForDelegate(efl_content_count_static_delegate) });
            }

            if (efl_pack_clear_static_delegate == null)
            {
                efl_pack_clear_static_delegate = new efl_pack_clear_delegate(pack_clear);
            }

            if (methods.FirstOrDefault(m => m.Name == "ClearPack") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_clear_static_delegate) });
            }

            if (efl_pack_unpack_all_static_delegate == null)
            {
                efl_pack_unpack_all_static_delegate = new efl_pack_unpack_all_delegate(unpack_all);
            }

            if (methods.FirstOrDefault(m => m.Name == "UnpackAll") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_unpack_all"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_unpack_all_static_delegate) });
            }

            if (efl_pack_unpack_static_delegate == null)
            {
                efl_pack_unpack_static_delegate = new efl_pack_unpack_delegate(unpack);
            }

            if (methods.FirstOrDefault(m => m.Name == "Unpack") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_unpack"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_unpack_static_delegate) });
            }

            if (efl_pack_static_delegate == null)
            {
                efl_pack_static_delegate = new efl_pack_delegate(pack);
            }

            if (methods.FirstOrDefault(m => m.Name == "Pack") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_static_delegate) });
            }

            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.IPackTableConcrete.efl_pack_table_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_pack_table_cell_column_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj,  out int col,  out int colspan);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_pack_table_cell_column_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj,  out int col,  out int colspan);

        public static Efl.Eo.FunctionWrapper<efl_pack_table_cell_column_get_api_delegate> efl_pack_table_cell_column_get_ptr = new Efl.Eo.FunctionWrapper<efl_pack_table_cell_column_get_api_delegate>(Module, "efl_pack_table_cell_column_get");

        private static bool table_cell_column_get(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.IEntity subobj, out int col, out int colspan)
        {
            Eina.Log.Debug("function efl_pack_table_cell_column_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        col = default(int);        colspan = default(int);                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IPackTable)ws.Target).GetTableCellColumn(subobj, out col, out colspan);
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
                return efl_pack_table_cell_column_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), subobj, out col, out colspan);
            }
        }

        private static efl_pack_table_cell_column_get_delegate efl_pack_table_cell_column_get_static_delegate;

        
        private delegate void efl_pack_table_cell_column_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj,  int col,  int colspan);

        
        public delegate void efl_pack_table_cell_column_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj,  int col,  int colspan);

        public static Efl.Eo.FunctionWrapper<efl_pack_table_cell_column_set_api_delegate> efl_pack_table_cell_column_set_ptr = new Efl.Eo.FunctionWrapper<efl_pack_table_cell_column_set_api_delegate>(Module, "efl_pack_table_cell_column_set");

        private static void table_cell_column_set(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.IEntity subobj, int col, int colspan)
        {
            Eina.Log.Debug("function efl_pack_table_cell_column_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                    
                try
                {
                    ((IPackTable)ws.Target).SetTableCellColumn(subobj, col, colspan);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_pack_table_cell_column_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), subobj, col, colspan);
            }
        }

        private static efl_pack_table_cell_column_set_delegate efl_pack_table_cell_column_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_pack_table_cell_row_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj,  out int row,  out int rowspan);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_pack_table_cell_row_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj,  out int row,  out int rowspan);

        public static Efl.Eo.FunctionWrapper<efl_pack_table_cell_row_get_api_delegate> efl_pack_table_cell_row_get_ptr = new Efl.Eo.FunctionWrapper<efl_pack_table_cell_row_get_api_delegate>(Module, "efl_pack_table_cell_row_get");

        private static bool table_cell_row_get(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.IEntity subobj, out int row, out int rowspan)
        {
            Eina.Log.Debug("function efl_pack_table_cell_row_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                        row = default(int);        rowspan = default(int);                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IPackTable)ws.Target).GetTableCellRow(subobj, out row, out rowspan);
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
                return efl_pack_table_cell_row_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), subobj, out row, out rowspan);
            }
        }

        private static efl_pack_table_cell_row_get_delegate efl_pack_table_cell_row_get_static_delegate;

        
        private delegate void efl_pack_table_cell_row_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj,  int row,  int rowspan);

        
        public delegate void efl_pack_table_cell_row_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj,  int row,  int rowspan);

        public static Efl.Eo.FunctionWrapper<efl_pack_table_cell_row_set_api_delegate> efl_pack_table_cell_row_set_ptr = new Efl.Eo.FunctionWrapper<efl_pack_table_cell_row_set_api_delegate>(Module, "efl_pack_table_cell_row_set");

        private static void table_cell_row_set(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.IEntity subobj, int row, int rowspan)
        {
            Eina.Log.Debug("function efl_pack_table_cell_row_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                    
                try
                {
                    ((IPackTable)ws.Target).SetTableCellRow(subobj, row, rowspan);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        
            }
            else
            {
                efl_pack_table_cell_row_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), subobj, row, rowspan);
            }
        }

        private static efl_pack_table_cell_row_set_delegate efl_pack_table_cell_row_set_static_delegate;

        
        private delegate void efl_pack_table_size_get_delegate(System.IntPtr obj, System.IntPtr pd,  out int cols,  out int rows);

        
        public delegate void efl_pack_table_size_get_api_delegate(System.IntPtr obj,  out int cols,  out int rows);

        public static Efl.Eo.FunctionWrapper<efl_pack_table_size_get_api_delegate> efl_pack_table_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_pack_table_size_get_api_delegate>(Module, "efl_pack_table_size_get");

        private static void table_size_get(System.IntPtr obj, System.IntPtr pd, out int cols, out int rows)
        {
            Eina.Log.Debug("function efl_pack_table_size_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                        cols = default(int);        rows = default(int);                            
                try
                {
                    ((IPackTable)ws.Target).GetTableSize(out cols, out rows);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_pack_table_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), out cols, out rows);
            }
        }

        private static efl_pack_table_size_get_delegate efl_pack_table_size_get_static_delegate;

        
        private delegate void efl_pack_table_size_set_delegate(System.IntPtr obj, System.IntPtr pd,  int cols,  int rows);

        
        public delegate void efl_pack_table_size_set_api_delegate(System.IntPtr obj,  int cols,  int rows);

        public static Efl.Eo.FunctionWrapper<efl_pack_table_size_set_api_delegate> efl_pack_table_size_set_ptr = new Efl.Eo.FunctionWrapper<efl_pack_table_size_set_api_delegate>(Module, "efl_pack_table_size_set");

        private static void table_size_set(System.IntPtr obj, System.IntPtr pd, int cols, int rows)
        {
            Eina.Log.Debug("function efl_pack_table_size_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((IPackTable)ws.Target).SetTableSize(cols, rows);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_pack_table_size_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cols, rows);
            }
        }

        private static efl_pack_table_size_set_delegate efl_pack_table_size_set_static_delegate;

        
        private delegate int efl_pack_table_columns_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_pack_table_columns_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_pack_table_columns_get_api_delegate> efl_pack_table_columns_get_ptr = new Efl.Eo.FunctionWrapper<efl_pack_table_columns_get_api_delegate>(Module, "efl_pack_table_columns_get");

        private static int table_columns_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_pack_table_columns_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((IPackTable)ws.Target).GetTableColumns();
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
                return efl_pack_table_columns_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_pack_table_columns_get_delegate efl_pack_table_columns_get_static_delegate;

        
        private delegate void efl_pack_table_columns_set_delegate(System.IntPtr obj, System.IntPtr pd,  int cols);

        
        public delegate void efl_pack_table_columns_set_api_delegate(System.IntPtr obj,  int cols);

        public static Efl.Eo.FunctionWrapper<efl_pack_table_columns_set_api_delegate> efl_pack_table_columns_set_ptr = new Efl.Eo.FunctionWrapper<efl_pack_table_columns_set_api_delegate>(Module, "efl_pack_table_columns_set");

        private static void table_columns_set(System.IntPtr obj, System.IntPtr pd, int cols)
        {
            Eina.Log.Debug("function efl_pack_table_columns_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IPackTable)ws.Target).SetTableColumns(cols);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_pack_table_columns_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), cols);
            }
        }

        private static efl_pack_table_columns_set_delegate efl_pack_table_columns_set_static_delegate;

        
        private delegate int efl_pack_table_rows_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_pack_table_rows_get_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_pack_table_rows_get_api_delegate> efl_pack_table_rows_get_ptr = new Efl.Eo.FunctionWrapper<efl_pack_table_rows_get_api_delegate>(Module, "efl_pack_table_rows_get");

        private static int table_rows_get(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_pack_table_rows_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((IPackTable)ws.Target).GetTableRows();
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
                return efl_pack_table_rows_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_pack_table_rows_get_delegate efl_pack_table_rows_get_static_delegate;

        
        private delegate void efl_pack_table_rows_set_delegate(System.IntPtr obj, System.IntPtr pd,  int rows);

        
        public delegate void efl_pack_table_rows_set_api_delegate(System.IntPtr obj,  int rows);

        public static Efl.Eo.FunctionWrapper<efl_pack_table_rows_set_api_delegate> efl_pack_table_rows_set_ptr = new Efl.Eo.FunctionWrapper<efl_pack_table_rows_set_api_delegate>(Module, "efl_pack_table_rows_set");

        private static void table_rows_set(System.IntPtr obj, System.IntPtr pd, int rows)
        {
            Eina.Log.Debug("function efl_pack_table_rows_set was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((IPackTable)ws.Target).SetTableRows(rows);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_pack_table_rows_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), rows);
            }
        }

        private static efl_pack_table_rows_set_delegate efl_pack_table_rows_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_pack_table_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj,  int col,  int row,  int colspan,  int rowspan);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_pack_table_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj,  int col,  int row,  int colspan,  int rowspan);

        public static Efl.Eo.FunctionWrapper<efl_pack_table_api_delegate> efl_pack_table_ptr = new Efl.Eo.FunctionWrapper<efl_pack_table_api_delegate>(Module, "efl_pack_table");

        private static bool pack_table(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.IEntity subobj, int col, int row, int colspan, int rowspan)
        {
            Eina.Log.Debug("function efl_pack_table was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                                                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IPackTable)ws.Target).PackTable(subobj, col, row, colspan, rowspan);
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
                return efl_pack_table_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), subobj, col, row, colspan, rowspan);
            }
        }

        private static efl_pack_table_delegate efl_pack_table_static_delegate;

        
        private delegate System.IntPtr efl_pack_table_contents_get_delegate(System.IntPtr obj, System.IntPtr pd,  int col,  int row, [MarshalAs(UnmanagedType.U1)] bool below);

        
        public delegate System.IntPtr efl_pack_table_contents_get_api_delegate(System.IntPtr obj,  int col,  int row, [MarshalAs(UnmanagedType.U1)] bool below);

        public static Efl.Eo.FunctionWrapper<efl_pack_table_contents_get_api_delegate> efl_pack_table_contents_get_ptr = new Efl.Eo.FunctionWrapper<efl_pack_table_contents_get_api_delegate>(Module, "efl_pack_table_contents_get");

        private static System.IntPtr table_contents_get(System.IntPtr obj, System.IntPtr pd, int col, int row, bool below)
        {
            Eina.Log.Debug("function efl_pack_table_contents_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                                                    Eina.Iterator<Efl.Gfx.IEntity> _ret_var = default(Eina.Iterator<Efl.Gfx.IEntity>);
                try
                {
                    _ret_var = ((IPackTable)ws.Target).GetTableContents(col, row, below);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                                        _ret_var.Own = false; return _ret_var.Handle;

            }
            else
            {
                return efl_pack_table_contents_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), col, row, below);
            }
        }

        private static efl_pack_table_contents_get_delegate efl_pack_table_contents_get_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        private delegate Efl.Gfx.IEntity efl_pack_table_content_get_delegate(System.IntPtr obj, System.IntPtr pd,  int col,  int row);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))]
        public delegate Efl.Gfx.IEntity efl_pack_table_content_get_api_delegate(System.IntPtr obj,  int col,  int row);

        public static Efl.Eo.FunctionWrapper<efl_pack_table_content_get_api_delegate> efl_pack_table_content_get_ptr = new Efl.Eo.FunctionWrapper<efl_pack_table_content_get_api_delegate>(Module, "efl_pack_table_content_get");

        private static Efl.Gfx.IEntity table_content_get(System.IntPtr obj, System.IntPtr pd, int col, int row)
        {
            Eina.Log.Debug("function efl_pack_table_content_get was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            Efl.Gfx.IEntity _ret_var = default(Efl.Gfx.IEntity);
                try
                {
                    _ret_var = ((IPackTable)ws.Target).GetTableContent(col, row);
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
                return efl_pack_table_content_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), col, row);
            }
        }

        private static efl_pack_table_content_get_delegate efl_pack_table_content_get_static_delegate;

        
        private delegate System.IntPtr efl_content_iterate_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_content_iterate_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_content_iterate_api_delegate> efl_content_iterate_ptr = new Efl.Eo.FunctionWrapper<efl_content_iterate_api_delegate>(Module, "efl_content_iterate");

        private static System.IntPtr content_iterate(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_content_iterate was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Iterator<Efl.Gfx.IEntity> _ret_var = default(Eina.Iterator<Efl.Gfx.IEntity>);
                try
                {
                    _ret_var = ((IPackTable)ws.Target).ContentIterate();
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

        _ret_var.Own = false; return _ret_var.Handle;

            }
            else
            {
                return efl_content_iterate_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_content_iterate_delegate efl_content_iterate_static_delegate;

        
        private delegate int efl_content_count_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate int efl_content_count_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_content_count_api_delegate> efl_content_count_ptr = new Efl.Eo.FunctionWrapper<efl_content_count_api_delegate>(Module, "efl_content_count");

        private static int content_count(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_content_count was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            int _ret_var = default(int);
                try
                {
                    _ret_var = ((IPackTable)ws.Target).ContentCount();
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
                return efl_content_count_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_content_count_delegate efl_content_count_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_pack_clear_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_pack_clear_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_pack_clear_api_delegate> efl_pack_clear_ptr = new Efl.Eo.FunctionWrapper<efl_pack_clear_api_delegate>(Module, "efl_pack_clear");

        private static bool pack_clear(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_pack_clear was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IPackTable)ws.Target).ClearPack();
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
                return efl_pack_clear_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_pack_clear_delegate efl_pack_clear_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_pack_unpack_all_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_pack_unpack_all_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_pack_unpack_all_api_delegate> efl_pack_unpack_all_ptr = new Efl.Eo.FunctionWrapper<efl_pack_unpack_all_api_delegate>(Module, "efl_pack_unpack_all");

        private static bool unpack_all(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_pack_unpack_all was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IPackTable)ws.Target).UnpackAll();
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
                return efl_pack_unpack_all_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_pack_unpack_all_delegate efl_pack_unpack_all_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_pack_unpack_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_pack_unpack_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj);

        public static Efl.Eo.FunctionWrapper<efl_pack_unpack_api_delegate> efl_pack_unpack_ptr = new Efl.Eo.FunctionWrapper<efl_pack_unpack_api_delegate>(Module, "efl_pack_unpack");

        private static bool unpack(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.IEntity subobj)
        {
            Eina.Log.Debug("function efl_pack_unpack was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IPackTable)ws.Target).Unpack(subobj);
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
                return efl_pack_unpack_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), subobj);
            }
        }

        private static efl_pack_unpack_delegate efl_pack_unpack_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_pack_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj);

        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool efl_pack_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.Gfx.IEntity subobj);

        public static Efl.Eo.FunctionWrapper<efl_pack_api_delegate> efl_pack_ptr = new Efl.Eo.FunctionWrapper<efl_pack_api_delegate>(Module, "efl_pack");

        private static bool pack(System.IntPtr obj, System.IntPtr pd, Efl.Gfx.IEntity subobj)
        {
            Eina.Log.Debug("function efl_pack was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IPackTable)ws.Target).Pack(subobj);
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
                return efl_pack_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), subobj);
            }
        }

        private static efl_pack_delegate efl_pack_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class EflIPackTableConcrete_ExtensionMethods {
    
    
    
    public static Efl.BindableProperty<int> TableColumns<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.IPackTable, T>magic = null) where T : Efl.IPackTable {
        return new Efl.BindableProperty<int>("table_columns", fac);
    }

    public static Efl.BindableProperty<int> TableRows<T>(this Efl.Ui.ItemFactory<T> fac, Efl.Csharp.ExtensionTag<Efl.IPackTable, T>magic = null) where T : Efl.IPackTable {
        return new Efl.BindableProperty<int>("table_rows", fac);
    }

}
#pragma warning restore CS1591
#endif
