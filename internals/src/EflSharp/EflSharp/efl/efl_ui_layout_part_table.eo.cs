#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Represents a Table created as part of a layout.
/// Cannot be deleted. This is only a representation of an internal object of an EFL layout.</summary>
[LayoutPartTableNativeInherit]
public class LayoutPartTable : Efl.Ui.LayoutPart, Efl.Eo.IWrapper,Efl.IContainer,Efl.IPack,Efl.IPackTable
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (LayoutPartTable))
                return Efl.Ui.LayoutPartTableNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_layout_part_table_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    public LayoutPartTable(Efl.Object parent= null
            ) :
        base(efl_ui_layout_part_table_class_get(), typeof(LayoutPartTable), parent)
    {
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected LayoutPartTable(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected LayoutPartTable(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
    ///<summary>Verifies if the given object is equal to this one.</summary>
    public override bool Equals(object obj)
    {
        var other = obj as Efl.Object;
        if (other == null)
            return false;
        return this.NativeHandle == other.NativeHandle;
    }
    ///<summary>Gets the hash code for this object based on the native pointer it points to.</summary>
    public override int GetHashCode()
    {
        return this.NativeHandle.ToInt32();
    }
    ///<summary>Turns the native pointer into a string representation.</summary>
    public override String ToString()
    {
        return $"{this.GetType().Name}@[{this.NativeHandle.ToInt32():x}]";
    }
private static object ContentAddedEvtKey = new object();
    /// <summary>Sent after a new item was added.
    /// (Since EFL 1.22)</summary>
    public event EventHandler<Efl.IContainerContentAddedEvt_Args> ContentAddedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_CONTAINER_EVENT_CONTENT_ADDED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ContentAddedEvt_delegate)) {
                    eventHandlers.AddHandler(ContentAddedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_CONTAINER_EVENT_CONTENT_ADDED";
                if (RemoveNativeEventHandler(key, this.evt_ContentAddedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ContentAddedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ContentAddedEvt.</summary>
    public void On_ContentAddedEvt(Efl.IContainerContentAddedEvt_Args e)
    {
        EventHandler<Efl.IContainerContentAddedEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.IContainerContentAddedEvt_Args>)eventHandlers[ContentAddedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ContentAddedEvt_delegate;
    private void on_ContentAddedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.IContainerContentAddedEvt_Args args = new Efl.IContainerContentAddedEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Gfx.IEntityConcrete);
        try {
            On_ContentAddedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

private static object ContentRemovedEvtKey = new object();
    /// <summary>Sent after an item was removed, before unref.
    /// (Since EFL 1.22)</summary>
    public event EventHandler<Efl.IContainerContentRemovedEvt_Args> ContentRemovedEvt
    {
        add {
            lock (eventLock) {
                string key = "_EFL_CONTAINER_EVENT_CONTENT_REMOVED";
                if (AddNativeEventHandler(efl.Libs.Efl, key, this.evt_ContentRemovedEvt_delegate)) {
                    eventHandlers.AddHandler(ContentRemovedEvtKey , value);
                } else
                    Eina.Log.Error($"Error adding proxy for event {key}");
            }
        }
        remove {
            lock (eventLock) {
                string key = "_EFL_CONTAINER_EVENT_CONTENT_REMOVED";
                if (RemoveNativeEventHandler(key, this.evt_ContentRemovedEvt_delegate)) { 
                    eventHandlers.RemoveHandler(ContentRemovedEvtKey , value);
                } else
                    Eina.Log.Error($"Error removing proxy for event {key}");
            }
        }
    }
    ///<summary>Method to raise event ContentRemovedEvt.</summary>
    public void On_ContentRemovedEvt(Efl.IContainerContentRemovedEvt_Args e)
    {
        EventHandler<Efl.IContainerContentRemovedEvt_Args> evt;
        lock (eventLock) {
        evt = (EventHandler<Efl.IContainerContentRemovedEvt_Args>)eventHandlers[ContentRemovedEvtKey];
        }
        evt?.Invoke(this, e);
    }
    Efl.EventCb evt_ContentRemovedEvt_delegate;
    private void on_ContentRemovedEvt_NativeCallback(System.IntPtr data, ref Efl.Event.NativeStruct evt)
    {
        Efl.IContainerContentRemovedEvt_Args args = new Efl.IContainerContentRemovedEvt_Args();
      args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.Gfx.IEntityConcrete);
        try {
            On_ContentRemovedEvt(args);
        } catch (Exception e) {
            Eina.Log.Error(e.ToString());
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
        }
    }

    ///<summary>Register the Eo event wrappers making the bridge to C# events. Internal usage only.</summary>
    protected override void RegisterEventProxies()
    {
        base.RegisterEventProxies();
        evt_ContentAddedEvt_delegate = new Efl.EventCb(on_ContentAddedEvt_NativeCallback);
        evt_ContentRemovedEvt_delegate = new Efl.EventCb(on_ContentRemovedEvt_NativeCallback);
    }
    /// <summary>Real part property</summary>
    /// <param name="layout">Real part object</param>
    /// <param name="part">Real part name</param>
    /// <returns></returns>
    virtual public void SetRealPart( Efl.Object layout,  System.String part) {
                                                         Efl.Ui.LayoutPartTableNativeInherit.efl_ui_layout_part_table_real_part_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), layout,  part);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Begin iterating over this object&apos;s contents.
    /// (Since EFL 1.22)</summary>
    /// <returns>Iterator to object content</returns>
    virtual public Eina.Iterator<Efl.Gfx.IEntity> ContentIterate() {
         var _ret_var = Efl.IContainerNativeInherit.efl_content_iterate_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Iterator<Efl.Gfx.IEntity>(_ret_var, true, false);
 }
    /// <summary>Returns the number of UI elements packed in this container.
    /// (Since EFL 1.22)</summary>
    /// <returns>Number of packed UI elements</returns>
    virtual public int ContentCount() {
         var _ret_var = Efl.IContainerNativeInherit.efl_content_count_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Alignment of the container within its bounds</summary>
    /// <param name="align_horiz">Horizontal alignment</param>
    /// <param name="align_vert">Vertical alignment</param>
    /// <returns></returns>
    virtual public void GetPackAlign( out double align_horiz,  out double align_vert) {
                                                         Efl.IPackNativeInherit.efl_pack_align_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out align_horiz,  out align_vert);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Alignment of the container within its bounds</summary>
    /// <param name="align_horiz">Horizontal alignment</param>
    /// <param name="align_vert">Vertical alignment</param>
    /// <returns></returns>
    virtual public void SetPackAlign( double align_horiz,  double align_vert) {
                                                         Efl.IPackNativeInherit.efl_pack_align_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), align_horiz,  align_vert);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Padding between items contained in this object.</summary>
    /// <param name="pad_horiz">Horizontal padding</param>
    /// <param name="pad_vert">Vertical padding</param>
    /// <param name="scalable"><c>true</c> if scalable, <c>false</c> otherwise</param>
    /// <returns></returns>
    virtual public void GetPackPadding( out double pad_horiz,  out double pad_vert,  out bool scalable) {
                                                                                 Efl.IPackNativeInherit.efl_pack_padding_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out pad_horiz,  out pad_vert,  out scalable);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Padding between items contained in this object.</summary>
    /// <param name="pad_horiz">Horizontal padding</param>
    /// <param name="pad_vert">Vertical padding</param>
    /// <param name="scalable"><c>true</c> if scalable, <c>false</c> otherwise</param>
    /// <returns></returns>
    virtual public void SetPackPadding( double pad_horiz,  double pad_vert,  bool scalable) {
                                                                                 Efl.IPackNativeInherit.efl_pack_padding_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), pad_horiz,  pad_vert,  scalable);
        Eina.Error.RaiseIfUnhandledException();
                                                         }
    /// <summary>Removes all packed contents, and unreferences them.</summary>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    virtual public bool ClearPack() {
         var _ret_var = Efl.IPackNativeInherit.efl_pack_clear_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Removes all packed contents, without unreferencing them.
    /// Use with caution.</summary>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    virtual public bool UnpackAll() {
         var _ret_var = Efl.IPackNativeInherit.efl_pack_unpack_all_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Removes an existing item from the container, without deleting it.</summary>
    /// <param name="subobj">The unpacked object.</param>
    /// <returns><c>false</c> if <c>subobj</c> wasn&apos;t a child or can&apos;t be removed</returns>
    virtual public bool Unpack( Efl.Gfx.IEntity subobj) {
                                 var _ret_var = Efl.IPackNativeInherit.efl_pack_unpack_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), subobj);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Adds an item to this container.
    /// Depending on the container this will either fill in the default spot, replacing any already existing element or append to the end of the container if there is no default part.
    /// 
    /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
    /// <param name="subobj">An object to pack.</param>
    /// <returns><c>false</c> if <c>subobj</c> could not be packed.</returns>
    virtual public bool DoPack( Efl.Gfx.IEntity subobj) {
                                 var _ret_var = Efl.IPackNativeInherit.efl_pack_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), subobj);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Position and span of the <c>subobj</c> in this container, may be modified to move the <c>subobj</c></summary>
    /// <param name="subobj">Child object</param>
    /// <param name="col">Column number</param>
    /// <param name="row">Row number</param>
    /// <param name="colspan">Column span</param>
    /// <param name="rowspan">Row span</param>
    /// <returns>Returns false if item is not a child</returns>
    virtual public bool GetTablePosition( Efl.Gfx.IEntity subobj,  out int col,  out int row,  out int colspan,  out int rowspan) {
                                                                                                                                 var _ret_var = Efl.IPackTableNativeInherit.efl_pack_table_position_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), subobj,  out col,  out row,  out colspan,  out rowspan);
        Eina.Error.RaiseIfUnhandledException();
                                                                                        return _ret_var;
 }
    /// <summary>Combines <see cref="Efl.IPackTable.TableColumns"/> and <see cref="Efl.IPackTable.TableRows"/></summary>
    /// <param name="cols">Number of columns</param>
    /// <param name="rows">Number of rows</param>
    /// <returns></returns>
    virtual public void GetTableSize( out int cols,  out int rows) {
                                                         Efl.IPackTableNativeInherit.efl_pack_table_size_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out cols,  out rows);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Combines <see cref="Efl.IPackTable.TableColumns"/> and <see cref="Efl.IPackTable.TableRows"/></summary>
    /// <param name="cols">Number of columns</param>
    /// <param name="rows">Number of rows</param>
    /// <returns></returns>
    virtual public void SetTableSize( int cols,  int rows) {
                                                         Efl.IPackTableNativeInherit.efl_pack_table_size_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), cols,  rows);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Gird columns property</summary>
    /// <returns>Number of columns</returns>
    virtual public int GetTableColumns() {
         var _ret_var = Efl.IPackTableNativeInherit.efl_pack_table_columns_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Specifies limit for linear adds - if direction is horizontal</summary>
    /// <param name="cols">Number of columns</param>
    /// <returns></returns>
    virtual public void SetTableColumns( int cols) {
                                 Efl.IPackTableNativeInherit.efl_pack_table_columns_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), cols);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Table rows property</summary>
    /// <returns>Number of rows</returns>
    virtual public int GetTableRows() {
         var _ret_var = Efl.IPackTableNativeInherit.efl_pack_table_rows_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Specifies limit for linear adds - if direction is vertical</summary>
    /// <param name="rows">Number of rows</param>
    /// <returns></returns>
    virtual public void SetTableRows( int rows) {
                                 Efl.IPackTableNativeInherit.efl_pack_table_rows_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), rows);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Primary and secondary up/left/right/down directions for linear apis.
    /// Default is horizontal and vertical. This overrides <see cref="Efl.Ui.IDirection.Direction"/>.</summary>
    /// <param name="primary">Primary direction</param>
    /// <param name="secondary">Secondary direction</param>
    /// <returns></returns>
    virtual public void GetTableDirection( out Efl.Ui.Dir primary,  out Efl.Ui.Dir secondary) {
                                                         Efl.IPackTableNativeInherit.efl_pack_table_direction_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out primary,  out secondary);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Primary and secondary up/left/right/down directions for linear apis.
    /// Default is horizontal and vertical. This overrides <see cref="Efl.Ui.IDirection.Direction"/>.</summary>
    /// <param name="primary">Primary direction</param>
    /// <param name="secondary">Secondary direction</param>
    /// <returns></returns>
    virtual public void SetTableDirection( Efl.Ui.Dir primary,  Efl.Ui.Dir secondary) {
                                                         Efl.IPackTableNativeInherit.efl_pack_table_direction_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), primary,  secondary);
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
    virtual public bool PackTable( Efl.Gfx.IEntity subobj,  int col,  int row,  int colspan,  int rowspan) {
                                                                                                                                 var _ret_var = Efl.IPackTableNativeInherit.efl_pack_table_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), subobj,  col,  row,  colspan,  rowspan);
        Eina.Error.RaiseIfUnhandledException();
                                                                                        return _ret_var;
 }
    /// <summary>Returns all objects at a given position in this table.</summary>
    /// <param name="col">Column number</param>
    /// <param name="row">Row number</param>
    /// <param name="below">If <c>true</c> get objects spanning over this cell.</param>
    /// <returns>Iterator to table contents</returns>
    virtual public Eina.Iterator<Efl.Gfx.IEntity> GetTableContents( int col,  int row,  bool below) {
                                                                                 var _ret_var = Efl.IPackTableNativeInherit.efl_pack_table_contents_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), col,  row,  below);
        Eina.Error.RaiseIfUnhandledException();
                                                        return new Eina.Iterator<Efl.Gfx.IEntity>(_ret_var, true, false);
 }
    /// <summary>Returns a child at a given position, see <see cref="Efl.IPackTable.GetTableContents"/>.</summary>
    /// <param name="col">Column number</param>
    /// <param name="row">Row number</param>
    /// <returns>Child object</returns>
    virtual public Efl.Gfx.IEntity GetTableContent( int col,  int row) {
                                                         var _ret_var = Efl.IPackTableNativeInherit.efl_pack_table_content_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), col,  row);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Gird columns property</summary>
/// <value>Number of columns</value>
    public int TableColumns {
        get { return GetTableColumns(); }
        set { SetTableColumns( value); }
    }
    /// <summary>Table rows property</summary>
/// <value>Number of rows</value>
    public int TableRows {
        get { return GetTableRows(); }
        set { SetTableRows( value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.LayoutPartTable.efl_ui_layout_part_table_class_get();
    }
}
public class LayoutPartTableNativeInherit : Efl.Ui.LayoutPartNativeInherit{
    public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_ui_layout_part_table_real_part_set_static_delegate == null)
            efl_ui_layout_part_table_real_part_set_static_delegate = new efl_ui_layout_part_table_real_part_set_delegate(real_part_set);
        if (methods.FirstOrDefault(m => m.Name == "SetRealPart") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_layout_part_table_real_part_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_layout_part_table_real_part_set_static_delegate)});
        if (efl_content_iterate_static_delegate == null)
            efl_content_iterate_static_delegate = new efl_content_iterate_delegate(content_iterate);
        if (methods.FirstOrDefault(m => m.Name == "ContentIterate") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_content_iterate"), func = Marshal.GetFunctionPointerForDelegate(efl_content_iterate_static_delegate)});
        if (efl_content_count_static_delegate == null)
            efl_content_count_static_delegate = new efl_content_count_delegate(content_count);
        if (methods.FirstOrDefault(m => m.Name == "ContentCount") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_content_count"), func = Marshal.GetFunctionPointerForDelegate(efl_content_count_static_delegate)});
        if (efl_pack_align_get_static_delegate == null)
            efl_pack_align_get_static_delegate = new efl_pack_align_get_delegate(pack_align_get);
        if (methods.FirstOrDefault(m => m.Name == "GetPackAlign") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_align_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_align_get_static_delegate)});
        if (efl_pack_align_set_static_delegate == null)
            efl_pack_align_set_static_delegate = new efl_pack_align_set_delegate(pack_align_set);
        if (methods.FirstOrDefault(m => m.Name == "SetPackAlign") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_align_set"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_align_set_static_delegate)});
        if (efl_pack_padding_get_static_delegate == null)
            efl_pack_padding_get_static_delegate = new efl_pack_padding_get_delegate(pack_padding_get);
        if (methods.FirstOrDefault(m => m.Name == "GetPackPadding") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_padding_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_padding_get_static_delegate)});
        if (efl_pack_padding_set_static_delegate == null)
            efl_pack_padding_set_static_delegate = new efl_pack_padding_set_delegate(pack_padding_set);
        if (methods.FirstOrDefault(m => m.Name == "SetPackPadding") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_padding_set"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_padding_set_static_delegate)});
        if (efl_pack_clear_static_delegate == null)
            efl_pack_clear_static_delegate = new efl_pack_clear_delegate(pack_clear);
        if (methods.FirstOrDefault(m => m.Name == "ClearPack") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_clear"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_clear_static_delegate)});
        if (efl_pack_unpack_all_static_delegate == null)
            efl_pack_unpack_all_static_delegate = new efl_pack_unpack_all_delegate(unpack_all);
        if (methods.FirstOrDefault(m => m.Name == "UnpackAll") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_unpack_all"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_unpack_all_static_delegate)});
        if (efl_pack_unpack_static_delegate == null)
            efl_pack_unpack_static_delegate = new efl_pack_unpack_delegate(unpack);
        if (methods.FirstOrDefault(m => m.Name == "Unpack") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_unpack"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_unpack_static_delegate)});
        if (efl_pack_static_delegate == null)
            efl_pack_static_delegate = new efl_pack_delegate(pack);
        if (methods.FirstOrDefault(m => m.Name == "DoPack") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_static_delegate)});
        if (efl_pack_table_position_get_static_delegate == null)
            efl_pack_table_position_get_static_delegate = new efl_pack_table_position_get_delegate(table_position_get);
        if (methods.FirstOrDefault(m => m.Name == "GetTablePosition") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_table_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_position_get_static_delegate)});
        if (efl_pack_table_size_get_static_delegate == null)
            efl_pack_table_size_get_static_delegate = new efl_pack_table_size_get_delegate(table_size_get);
        if (methods.FirstOrDefault(m => m.Name == "GetTableSize") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_table_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_size_get_static_delegate)});
        if (efl_pack_table_size_set_static_delegate == null)
            efl_pack_table_size_set_static_delegate = new efl_pack_table_size_set_delegate(table_size_set);
        if (methods.FirstOrDefault(m => m.Name == "SetTableSize") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_table_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_size_set_static_delegate)});
        if (efl_pack_table_columns_get_static_delegate == null)
            efl_pack_table_columns_get_static_delegate = new efl_pack_table_columns_get_delegate(table_columns_get);
        if (methods.FirstOrDefault(m => m.Name == "GetTableColumns") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_table_columns_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_columns_get_static_delegate)});
        if (efl_pack_table_columns_set_static_delegate == null)
            efl_pack_table_columns_set_static_delegate = new efl_pack_table_columns_set_delegate(table_columns_set);
        if (methods.FirstOrDefault(m => m.Name == "SetTableColumns") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_table_columns_set"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_columns_set_static_delegate)});
        if (efl_pack_table_rows_get_static_delegate == null)
            efl_pack_table_rows_get_static_delegate = new efl_pack_table_rows_get_delegate(table_rows_get);
        if (methods.FirstOrDefault(m => m.Name == "GetTableRows") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_table_rows_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_rows_get_static_delegate)});
        if (efl_pack_table_rows_set_static_delegate == null)
            efl_pack_table_rows_set_static_delegate = new efl_pack_table_rows_set_delegate(table_rows_set);
        if (methods.FirstOrDefault(m => m.Name == "SetTableRows") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_table_rows_set"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_rows_set_static_delegate)});
        if (efl_pack_table_direction_get_static_delegate == null)
            efl_pack_table_direction_get_static_delegate = new efl_pack_table_direction_get_delegate(table_direction_get);
        if (methods.FirstOrDefault(m => m.Name == "GetTableDirection") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_table_direction_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_direction_get_static_delegate)});
        if (efl_pack_table_direction_set_static_delegate == null)
            efl_pack_table_direction_set_static_delegate = new efl_pack_table_direction_set_delegate(table_direction_set);
        if (methods.FirstOrDefault(m => m.Name == "SetTableDirection") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_table_direction_set"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_direction_set_static_delegate)});
        if (efl_pack_table_static_delegate == null)
            efl_pack_table_static_delegate = new efl_pack_table_delegate(pack_table);
        if (methods.FirstOrDefault(m => m.Name == "PackTable") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_table"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_static_delegate)});
        if (efl_pack_table_contents_get_static_delegate == null)
            efl_pack_table_contents_get_static_delegate = new efl_pack_table_contents_get_delegate(table_contents_get);
        if (methods.FirstOrDefault(m => m.Name == "GetTableContents") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_table_contents_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_contents_get_static_delegate)});
        if (efl_pack_table_content_get_static_delegate == null)
            efl_pack_table_content_get_static_delegate = new efl_pack_table_content_get_delegate(table_content_get);
        if (methods.FirstOrDefault(m => m.Name == "GetTableContent") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_table_content_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_content_get_static_delegate)});
        descs.AddRange(base.GetEoOps(type));
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Ui.LayoutPartTable.efl_ui_layout_part_table_class_get();
    }
    public static new  IntPtr GetEflClassStatic()
    {
        return Efl.Ui.LayoutPartTable.efl_ui_layout_part_table_class_get();
    }


     private delegate void efl_ui_layout_part_table_real_part_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object layout,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String part);


     public delegate void efl_ui_layout_part_table_real_part_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object layout,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String part);
     public static Efl.Eo.FunctionWrapper<efl_ui_layout_part_table_real_part_set_api_delegate> efl_ui_layout_part_table_real_part_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_layout_part_table_real_part_set_api_delegate>(_Module, "efl_ui_layout_part_table_real_part_set");
     private static void real_part_set(System.IntPtr obj, System.IntPtr pd,  Efl.Object layout,  System.String part)
    {
        Eina.Log.Debug("function efl_ui_layout_part_table_real_part_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        
            try {
                ((LayoutPartTable)wrapper).SetRealPart( layout,  part);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_ui_layout_part_table_real_part_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  layout,  part);
        }
    }
    private static efl_ui_layout_part_table_real_part_set_delegate efl_ui_layout_part_table_real_part_set_static_delegate;


     private delegate System.IntPtr efl_content_iterate_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate System.IntPtr efl_content_iterate_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_content_iterate_api_delegate> efl_content_iterate_ptr = new Efl.Eo.FunctionWrapper<efl_content_iterate_api_delegate>(_Module, "efl_content_iterate");
     private static System.IntPtr content_iterate(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_content_iterate was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Eina.Iterator<Efl.Gfx.IEntity> _ret_var = default(Eina.Iterator<Efl.Gfx.IEntity>);
            try {
                _ret_var = ((LayoutPartTable)wrapper).ContentIterate();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        _ret_var.Own = false; return _ret_var.Handle;
        } else {
            return efl_content_iterate_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_content_iterate_delegate efl_content_iterate_static_delegate;


     private delegate int efl_content_count_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate int efl_content_count_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_content_count_api_delegate> efl_content_count_ptr = new Efl.Eo.FunctionWrapper<efl_content_count_api_delegate>(_Module, "efl_content_count");
     private static int content_count(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_content_count was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        int _ret_var = default(int);
            try {
                _ret_var = ((LayoutPartTable)wrapper).ContentCount();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_content_count_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_content_count_delegate efl_content_count_static_delegate;


     private delegate void efl_pack_align_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double align_horiz,   out double align_vert);


     public delegate void efl_pack_align_get_api_delegate(System.IntPtr obj,   out double align_horiz,   out double align_vert);
     public static Efl.Eo.FunctionWrapper<efl_pack_align_get_api_delegate> efl_pack_align_get_ptr = new Efl.Eo.FunctionWrapper<efl_pack_align_get_api_delegate>(_Module, "efl_pack_align_get");
     private static void pack_align_get(System.IntPtr obj, System.IntPtr pd,  out double align_horiz,  out double align_vert)
    {
        Eina.Log.Debug("function efl_pack_align_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                    align_horiz = default(double);        align_vert = default(double);                            
            try {
                ((LayoutPartTable)wrapper).GetPackAlign( out align_horiz,  out align_vert);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_pack_align_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out align_horiz,  out align_vert);
        }
    }
    private static efl_pack_align_get_delegate efl_pack_align_get_static_delegate;


     private delegate void efl_pack_align_set_delegate(System.IntPtr obj, System.IntPtr pd,   double align_horiz,   double align_vert);


     public delegate void efl_pack_align_set_api_delegate(System.IntPtr obj,   double align_horiz,   double align_vert);
     public static Efl.Eo.FunctionWrapper<efl_pack_align_set_api_delegate> efl_pack_align_set_ptr = new Efl.Eo.FunctionWrapper<efl_pack_align_set_api_delegate>(_Module, "efl_pack_align_set");
     private static void pack_align_set(System.IntPtr obj, System.IntPtr pd,  double align_horiz,  double align_vert)
    {
        Eina.Log.Debug("function efl_pack_align_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        
            try {
                ((LayoutPartTable)wrapper).SetPackAlign( align_horiz,  align_vert);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_pack_align_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  align_horiz,  align_vert);
        }
    }
    private static efl_pack_align_set_delegate efl_pack_align_set_static_delegate;


     private delegate void efl_pack_padding_get_delegate(System.IntPtr obj, System.IntPtr pd,   out double pad_horiz,   out double pad_vert,  [MarshalAs(UnmanagedType.U1)]  out bool scalable);


     public delegate void efl_pack_padding_get_api_delegate(System.IntPtr obj,   out double pad_horiz,   out double pad_vert,  [MarshalAs(UnmanagedType.U1)]  out bool scalable);
     public static Efl.Eo.FunctionWrapper<efl_pack_padding_get_api_delegate> efl_pack_padding_get_ptr = new Efl.Eo.FunctionWrapper<efl_pack_padding_get_api_delegate>(_Module, "efl_pack_padding_get");
     private static void pack_padding_get(System.IntPtr obj, System.IntPtr pd,  out double pad_horiz,  out double pad_vert,  out bool scalable)
    {
        Eina.Log.Debug("function efl_pack_padding_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                            pad_horiz = default(double);        pad_vert = default(double);        scalable = default(bool);                                    
            try {
                ((LayoutPartTable)wrapper).GetPackPadding( out pad_horiz,  out pad_vert,  out scalable);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                } else {
            efl_pack_padding_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out pad_horiz,  out pad_vert,  out scalable);
        }
    }
    private static efl_pack_padding_get_delegate efl_pack_padding_get_static_delegate;


     private delegate void efl_pack_padding_set_delegate(System.IntPtr obj, System.IntPtr pd,   double pad_horiz,   double pad_vert,  [MarshalAs(UnmanagedType.U1)]  bool scalable);


     public delegate void efl_pack_padding_set_api_delegate(System.IntPtr obj,   double pad_horiz,   double pad_vert,  [MarshalAs(UnmanagedType.U1)]  bool scalable);
     public static Efl.Eo.FunctionWrapper<efl_pack_padding_set_api_delegate> efl_pack_padding_set_ptr = new Efl.Eo.FunctionWrapper<efl_pack_padding_set_api_delegate>(_Module, "efl_pack_padding_set");
     private static void pack_padding_set(System.IntPtr obj, System.IntPtr pd,  double pad_horiz,  double pad_vert,  bool scalable)
    {
        Eina.Log.Debug("function efl_pack_padding_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                
            try {
                ((LayoutPartTable)wrapper).SetPackPadding( pad_horiz,  pad_vert,  scalable);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                } else {
            efl_pack_padding_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  pad_horiz,  pad_vert,  scalable);
        }
    }
    private static efl_pack_padding_set_delegate efl_pack_padding_set_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_pack_clear_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_pack_clear_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_pack_clear_api_delegate> efl_pack_clear_ptr = new Efl.Eo.FunctionWrapper<efl_pack_clear_api_delegate>(_Module, "efl_pack_clear");
     private static bool pack_clear(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_pack_clear was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((LayoutPartTable)wrapper).ClearPack();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_pack_clear_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_pack_clear_delegate efl_pack_clear_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_pack_unpack_all_delegate(System.IntPtr obj, System.IntPtr pd);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_pack_unpack_all_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_pack_unpack_all_api_delegate> efl_pack_unpack_all_ptr = new Efl.Eo.FunctionWrapper<efl_pack_unpack_all_api_delegate>(_Module, "efl_pack_unpack_all");
     private static bool unpack_all(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_pack_unpack_all was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        bool _ret_var = default(bool);
            try {
                _ret_var = ((LayoutPartTable)wrapper).UnpackAll();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_pack_unpack_all_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_pack_unpack_all_delegate efl_pack_unpack_all_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_pack_unpack_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.IEntity subobj);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_pack_unpack_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.IEntity subobj);
     public static Efl.Eo.FunctionWrapper<efl_pack_unpack_api_delegate> efl_pack_unpack_ptr = new Efl.Eo.FunctionWrapper<efl_pack_unpack_api_delegate>(_Module, "efl_pack_unpack");
     private static bool unpack(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.IEntity subobj)
    {
        Eina.Log.Debug("function efl_pack_unpack was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                bool _ret_var = default(bool);
            try {
                _ret_var = ((LayoutPartTable)wrapper).Unpack( subobj);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_pack_unpack_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  subobj);
        }
    }
    private static efl_pack_unpack_delegate efl_pack_unpack_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_pack_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.IEntity subobj);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_pack_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.IEntity subobj);
     public static Efl.Eo.FunctionWrapper<efl_pack_api_delegate> efl_pack_ptr = new Efl.Eo.FunctionWrapper<efl_pack_api_delegate>(_Module, "efl_pack");
     private static bool pack(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.IEntity subobj)
    {
        Eina.Log.Debug("function efl_pack was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                bool _ret_var = default(bool);
            try {
                _ret_var = ((LayoutPartTable)wrapper).DoPack( subobj);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_pack_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  subobj);
        }
    }
    private static efl_pack_delegate efl_pack_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_pack_table_position_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.IEntity subobj,   out int col,   out int row,   out int colspan,   out int rowspan);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_pack_table_position_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.IEntity subobj,   out int col,   out int row,   out int colspan,   out int rowspan);
     public static Efl.Eo.FunctionWrapper<efl_pack_table_position_get_api_delegate> efl_pack_table_position_get_ptr = new Efl.Eo.FunctionWrapper<efl_pack_table_position_get_api_delegate>(_Module, "efl_pack_table_position_get");
     private static bool table_position_get(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.IEntity subobj,  out int col,  out int row,  out int colspan,  out int rowspan)
    {
        Eina.Log.Debug("function efl_pack_table_position_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                    col = default(int);        row = default(int);        colspan = default(int);        rowspan = default(int);                                                    bool _ret_var = default(bool);
            try {
                _ret_var = ((LayoutPartTable)wrapper).GetTablePosition( subobj,  out col,  out row,  out colspan,  out rowspan);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                        return _ret_var;
        } else {
            return efl_pack_table_position_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  subobj,  out col,  out row,  out colspan,  out rowspan);
        }
    }
    private static efl_pack_table_position_get_delegate efl_pack_table_position_get_static_delegate;


     private delegate void efl_pack_table_size_get_delegate(System.IntPtr obj, System.IntPtr pd,   out int cols,   out int rows);


     public delegate void efl_pack_table_size_get_api_delegate(System.IntPtr obj,   out int cols,   out int rows);
     public static Efl.Eo.FunctionWrapper<efl_pack_table_size_get_api_delegate> efl_pack_table_size_get_ptr = new Efl.Eo.FunctionWrapper<efl_pack_table_size_get_api_delegate>(_Module, "efl_pack_table_size_get");
     private static void table_size_get(System.IntPtr obj, System.IntPtr pd,  out int cols,  out int rows)
    {
        Eina.Log.Debug("function efl_pack_table_size_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                    cols = default(int);        rows = default(int);                            
            try {
                ((LayoutPartTable)wrapper).GetTableSize( out cols,  out rows);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_pack_table_size_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out cols,  out rows);
        }
    }
    private static efl_pack_table_size_get_delegate efl_pack_table_size_get_static_delegate;


     private delegate void efl_pack_table_size_set_delegate(System.IntPtr obj, System.IntPtr pd,   int cols,   int rows);


     public delegate void efl_pack_table_size_set_api_delegate(System.IntPtr obj,   int cols,   int rows);
     public static Efl.Eo.FunctionWrapper<efl_pack_table_size_set_api_delegate> efl_pack_table_size_set_ptr = new Efl.Eo.FunctionWrapper<efl_pack_table_size_set_api_delegate>(_Module, "efl_pack_table_size_set");
     private static void table_size_set(System.IntPtr obj, System.IntPtr pd,  int cols,  int rows)
    {
        Eina.Log.Debug("function efl_pack_table_size_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        
            try {
                ((LayoutPartTable)wrapper).SetTableSize( cols,  rows);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_pack_table_size_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cols,  rows);
        }
    }
    private static efl_pack_table_size_set_delegate efl_pack_table_size_set_static_delegate;


     private delegate int efl_pack_table_columns_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate int efl_pack_table_columns_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_pack_table_columns_get_api_delegate> efl_pack_table_columns_get_ptr = new Efl.Eo.FunctionWrapper<efl_pack_table_columns_get_api_delegate>(_Module, "efl_pack_table_columns_get");
     private static int table_columns_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_pack_table_columns_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        int _ret_var = default(int);
            try {
                _ret_var = ((LayoutPartTable)wrapper).GetTableColumns();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_pack_table_columns_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_pack_table_columns_get_delegate efl_pack_table_columns_get_static_delegate;


     private delegate void efl_pack_table_columns_set_delegate(System.IntPtr obj, System.IntPtr pd,   int cols);


     public delegate void efl_pack_table_columns_set_api_delegate(System.IntPtr obj,   int cols);
     public static Efl.Eo.FunctionWrapper<efl_pack_table_columns_set_api_delegate> efl_pack_table_columns_set_ptr = new Efl.Eo.FunctionWrapper<efl_pack_table_columns_set_api_delegate>(_Module, "efl_pack_table_columns_set");
     private static void table_columns_set(System.IntPtr obj, System.IntPtr pd,  int cols)
    {
        Eina.Log.Debug("function efl_pack_table_columns_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((LayoutPartTable)wrapper).SetTableColumns( cols);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_pack_table_columns_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  cols);
        }
    }
    private static efl_pack_table_columns_set_delegate efl_pack_table_columns_set_static_delegate;


     private delegate int efl_pack_table_rows_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate int efl_pack_table_rows_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_pack_table_rows_get_api_delegate> efl_pack_table_rows_get_ptr = new Efl.Eo.FunctionWrapper<efl_pack_table_rows_get_api_delegate>(_Module, "efl_pack_table_rows_get");
     private static int table_rows_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_pack_table_rows_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        int _ret_var = default(int);
            try {
                _ret_var = ((LayoutPartTable)wrapper).GetTableRows();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_pack_table_rows_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_pack_table_rows_get_delegate efl_pack_table_rows_get_static_delegate;


     private delegate void efl_pack_table_rows_set_delegate(System.IntPtr obj, System.IntPtr pd,   int rows);


     public delegate void efl_pack_table_rows_set_api_delegate(System.IntPtr obj,   int rows);
     public static Efl.Eo.FunctionWrapper<efl_pack_table_rows_set_api_delegate> efl_pack_table_rows_set_ptr = new Efl.Eo.FunctionWrapper<efl_pack_table_rows_set_api_delegate>(_Module, "efl_pack_table_rows_set");
     private static void table_rows_set(System.IntPtr obj, System.IntPtr pd,  int rows)
    {
        Eina.Log.Debug("function efl_pack_table_rows_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((LayoutPartTable)wrapper).SetTableRows( rows);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_pack_table_rows_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  rows);
        }
    }
    private static efl_pack_table_rows_set_delegate efl_pack_table_rows_set_static_delegate;


     private delegate void efl_pack_table_direction_get_delegate(System.IntPtr obj, System.IntPtr pd,   out Efl.Ui.Dir primary,   out Efl.Ui.Dir secondary);


     public delegate void efl_pack_table_direction_get_api_delegate(System.IntPtr obj,   out Efl.Ui.Dir primary,   out Efl.Ui.Dir secondary);
     public static Efl.Eo.FunctionWrapper<efl_pack_table_direction_get_api_delegate> efl_pack_table_direction_get_ptr = new Efl.Eo.FunctionWrapper<efl_pack_table_direction_get_api_delegate>(_Module, "efl_pack_table_direction_get");
     private static void table_direction_get(System.IntPtr obj, System.IntPtr pd,  out Efl.Ui.Dir primary,  out Efl.Ui.Dir secondary)
    {
        Eina.Log.Debug("function efl_pack_table_direction_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                    primary = default(Efl.Ui.Dir);        secondary = default(Efl.Ui.Dir);                            
            try {
                ((LayoutPartTable)wrapper).GetTableDirection( out primary,  out secondary);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_pack_table_direction_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out primary,  out secondary);
        }
    }
    private static efl_pack_table_direction_get_delegate efl_pack_table_direction_get_static_delegate;


     private delegate void efl_pack_table_direction_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.Dir primary,   Efl.Ui.Dir secondary);


     public delegate void efl_pack_table_direction_set_api_delegate(System.IntPtr obj,   Efl.Ui.Dir primary,   Efl.Ui.Dir secondary);
     public static Efl.Eo.FunctionWrapper<efl_pack_table_direction_set_api_delegate> efl_pack_table_direction_set_ptr = new Efl.Eo.FunctionWrapper<efl_pack_table_direction_set_api_delegate>(_Module, "efl_pack_table_direction_set");
     private static void table_direction_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Dir primary,  Efl.Ui.Dir secondary)
    {
        Eina.Log.Debug("function efl_pack_table_direction_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        
            try {
                ((LayoutPartTable)wrapper).SetTableDirection( primary,  secondary);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_pack_table_direction_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  primary,  secondary);
        }
    }
    private static efl_pack_table_direction_set_delegate efl_pack_table_direction_set_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_pack_table_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.IEntity subobj,   int col,   int row,   int colspan,   int rowspan);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_pack_table_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.IEntity subobj,   int col,   int row,   int colspan,   int rowspan);
     public static Efl.Eo.FunctionWrapper<efl_pack_table_api_delegate> efl_pack_table_ptr = new Efl.Eo.FunctionWrapper<efl_pack_table_api_delegate>(_Module, "efl_pack_table");
     private static bool pack_table(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.IEntity subobj,  int col,  int row,  int colspan,  int rowspan)
    {
        Eina.Log.Debug("function efl_pack_table was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                                                                bool _ret_var = default(bool);
            try {
                _ret_var = ((LayoutPartTable)wrapper).PackTable( subobj,  col,  row,  colspan,  rowspan);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                                                        return _ret_var;
        } else {
            return efl_pack_table_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  subobj,  col,  row,  colspan,  rowspan);
        }
    }
    private static efl_pack_table_delegate efl_pack_table_static_delegate;


     private delegate System.IntPtr efl_pack_table_contents_get_delegate(System.IntPtr obj, System.IntPtr pd,   int col,   int row,  [MarshalAs(UnmanagedType.U1)]  bool below);


     public delegate System.IntPtr efl_pack_table_contents_get_api_delegate(System.IntPtr obj,   int col,   int row,  [MarshalAs(UnmanagedType.U1)]  bool below);
     public static Efl.Eo.FunctionWrapper<efl_pack_table_contents_get_api_delegate> efl_pack_table_contents_get_ptr = new Efl.Eo.FunctionWrapper<efl_pack_table_contents_get_api_delegate>(_Module, "efl_pack_table_contents_get");
     private static System.IntPtr table_contents_get(System.IntPtr obj, System.IntPtr pd,  int col,  int row,  bool below)
    {
        Eina.Log.Debug("function efl_pack_table_contents_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                                                Eina.Iterator<Efl.Gfx.IEntity> _ret_var = default(Eina.Iterator<Efl.Gfx.IEntity>);
            try {
                _ret_var = ((LayoutPartTable)wrapper).GetTableContents( col,  row,  below);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                        _ret_var.Own = false; return _ret_var.Handle;
        } else {
            return efl_pack_table_contents_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  col,  row,  below);
        }
    }
    private static efl_pack_table_contents_get_delegate efl_pack_table_contents_get_static_delegate;


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Gfx.IEntity efl_pack_table_content_get_delegate(System.IntPtr obj, System.IntPtr pd,   int col,   int row);


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Gfx.IEntity efl_pack_table_content_get_api_delegate(System.IntPtr obj,   int col,   int row);
     public static Efl.Eo.FunctionWrapper<efl_pack_table_content_get_api_delegate> efl_pack_table_content_get_ptr = new Efl.Eo.FunctionWrapper<efl_pack_table_content_get_api_delegate>(_Module, "efl_pack_table_content_get");
     private static Efl.Gfx.IEntity table_content_get(System.IntPtr obj, System.IntPtr pd,  int col,  int row)
    {
        Eina.Log.Debug("function efl_pack_table_content_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        Efl.Gfx.IEntity _ret_var = default(Efl.Gfx.IEntity);
            try {
                _ret_var = ((LayoutPartTable)wrapper).GetTableContent( col,  row);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                        return _ret_var;
        } else {
            return efl_pack_table_content_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  col,  row);
        }
    }
    private static efl_pack_table_content_get_delegate efl_pack_table_content_get_static_delegate;
}
} } 
