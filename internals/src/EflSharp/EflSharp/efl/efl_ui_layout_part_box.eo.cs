#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Represents a Box created as part of a layout.
/// Cannot be deleted. This is only a representation of an internal object of an EFL layout.</summary>
[LayoutPartBoxNativeInherit]
public class LayoutPartBox : Efl.Ui.LayoutPart, Efl.Eo.IWrapper,Efl.IContainer,Efl.IPack,Efl.IPackLinear,Efl.Ui.IDirection,Efl.Ui.IDirectionReadonly
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass {
        get {
            if (((object)this).GetType() == typeof (LayoutPartBox))
                return Efl.Ui.LayoutPartBoxNativeInherit.GetEflClassStatic();
            else
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
        }
    }
    [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
        efl_ui_layout_part_box_class_get();
    ///<summary>Creates a new instance.</summary>
    ///<param name="parent">Parent instance.</param>
    public LayoutPartBox(Efl.Object parent= null
            ) :
        base(efl_ui_layout_part_box_class_get(), typeof(LayoutPartBox), parent)
    {
        FinishInstantiation();
    }
    ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    protected LayoutPartBox(System.IntPtr raw) : base(raw)
    {
                RegisterEventProxies();
    }
    ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    protected LayoutPartBox(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
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
                                                         Efl.Ui.LayoutPartBoxNativeInherit.efl_ui_layout_part_box_real_part_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), layout,  part);
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
    /// <summary>Prepend an object at the beginning of this container.
    /// This is the same as <see cref="Efl.IPackLinear.PackAt"/>(<c>subobj</c>, 0).
    /// 
    /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
    /// <param name="subobj">Item to pack.</param>
    /// <returns><c>false</c> if <c>subobj</c> could not be packed</returns>
    virtual public bool PackBegin( Efl.Gfx.IEntity subobj) {
                                 var _ret_var = Efl.IPackLinearNativeInherit.efl_pack_begin_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), subobj);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Append object at the end of this container.
    /// This is the same as <see cref="Efl.IPackLinear.PackAt"/>(<c>subobj</c>, -1).
    /// 
    /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
    /// <param name="subobj">Item to pack at the end.</param>
    /// <returns><c>false</c> if <c>subobj</c> could not be packed</returns>
    virtual public bool PackEnd( Efl.Gfx.IEntity subobj) {
                                 var _ret_var = Efl.IPackLinearNativeInherit.efl_pack_end_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), subobj);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Prepend item before other sub object.
    /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
    /// <param name="subobj">Item to pack before <c>existing</c>.</param>
    /// <param name="existing">Item to refer to.</param>
    /// <returns><c>false</c> if <c>existing</c> could not be found or <c>subobj</c> could not be packed.</returns>
    virtual public bool PackBefore( Efl.Gfx.IEntity subobj,  Efl.Gfx.IEntity existing) {
                                                         var _ret_var = Efl.IPackLinearNativeInherit.efl_pack_before_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), subobj,  existing);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Append item after other sub object.
    /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
    /// <param name="subobj">Item to pack after <c>existing</c>.</param>
    /// <param name="existing">Item to refer to.</param>
    /// <returns><c>false</c> if <c>existing</c> could not be found or <c>subobj</c> could not be packed.</returns>
    virtual public bool PackAfter( Efl.Gfx.IEntity subobj,  Efl.Gfx.IEntity existing) {
                                                         var _ret_var = Efl.IPackLinearNativeInherit.efl_pack_after_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), subobj,  existing);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Inserts <c>subobj</c> at the specified <c>index</c>.
    /// Valid range: -<c>count</c> to +<c>count</c>. -1 refers to the last element. Out of range indices will trigger an append.
    /// 
    /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="Efl.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
    /// <param name="subobj">Item to pack at given index.</param>
    /// <param name="index">A position.</param>
    /// <returns><c>false</c> if <c>subobj</c> could not be packed.</returns>
    virtual public bool PackAt( Efl.Gfx.IEntity subobj,  int index) {
                                                         var _ret_var = Efl.IPackLinearNativeInherit.efl_pack_at_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), subobj,  index);
        Eina.Error.RaiseIfUnhandledException();
                                        return _ret_var;
 }
    /// <summary>Content at a given index in this container.
    /// Index -1 refers to the last item. The valid range is -(count - 1) to (count - 1).</summary>
    /// <param name="index">Index number</param>
    /// <returns>The object contained at the given <c>index</c>.</returns>
    virtual public Efl.Gfx.IEntity GetPackContent( int index) {
                                 var _ret_var = Efl.IPackLinearNativeInherit.efl_pack_content_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), index);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Get the index of a child in this container.</summary>
    /// <param name="subobj">An object contained in this pack.</param>
    /// <returns>-1 in case of failure, or the index of this item.</returns>
    virtual public int GetPackIndex( Efl.Gfx.IEntity subobj) {
                                 var _ret_var = Efl.IPackLinearNativeInherit.efl_pack_index_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), subobj);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Pop out item at specified <c>index</c>.
    /// Equivalent to unpack(content_at(<c>index</c>)).</summary>
    /// <param name="index">Index number</param>
    /// <returns>The child item if it could be removed.</returns>
    virtual public Efl.Gfx.IEntity PackUnpackAt( int index) {
                                 var _ret_var = Efl.IPackLinearNativeInherit.efl_pack_unpack_at_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), index);
        Eina.Error.RaiseIfUnhandledException();
                        return _ret_var;
 }
    /// <summary>Control the direction of a given widget.
    /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
    /// 
    /// Mirroring as defined in <see cref="Efl.Ui.II18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
    /// <returns>Direction of the widget.</returns>
    virtual public Efl.Ui.Dir GetDirection() {
         var _ret_var = Efl.Ui.IDirectionNativeInherit.efl_ui_direction_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
        Eina.Error.RaiseIfUnhandledException();
        return _ret_var;
 }
    /// <summary>Control the direction of a given widget.
    /// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
    /// 
    /// Mirroring as defined in <see cref="Efl.Ui.II18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
    /// <param name="dir">Direction of the widget.</param>
    /// <returns></returns>
    virtual public void SetDirection( Efl.Ui.Dir dir) {
                                 Efl.Ui.IDirectionNativeInherit.efl_ui_direction_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), dir);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Control the direction of a given widget.
/// Use this function to change how your widget is to be disposed: vertically or horizontally or inverted vertically or inverted horizontally.
/// 
/// Mirroring as defined in <see cref="Efl.Ui.II18n"/> can invert the <c>horizontal</c> direction: it is <c>ltr</c> by default, but becomes <c>rtl</c> if the object is mirrored.</summary>
/// <value>Direction of the widget.</value>
    public Efl.Ui.Dir Direction {
        get { return GetDirection(); }
        set { SetDirection( value); }
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Ui.LayoutPartBox.efl_ui_layout_part_box_class_get();
    }
}
public class LayoutPartBoxNativeInherit : Efl.Ui.LayoutPartNativeInherit{
    public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
    public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
    {
        var descs = new System.Collections.Generic.List<Efl_Op_Description>();
        var methods = Efl.Eo.Globals.GetUserMethods(type);
        if (efl_ui_layout_part_box_real_part_set_static_delegate == null)
            efl_ui_layout_part_box_real_part_set_static_delegate = new efl_ui_layout_part_box_real_part_set_delegate(real_part_set);
        if (methods.FirstOrDefault(m => m.Name == "SetRealPart") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_layout_part_box_real_part_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_layout_part_box_real_part_set_static_delegate)});
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
        if (efl_pack_begin_static_delegate == null)
            efl_pack_begin_static_delegate = new efl_pack_begin_delegate(pack_begin);
        if (methods.FirstOrDefault(m => m.Name == "PackBegin") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_begin"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_begin_static_delegate)});
        if (efl_pack_end_static_delegate == null)
            efl_pack_end_static_delegate = new efl_pack_end_delegate(pack_end);
        if (methods.FirstOrDefault(m => m.Name == "PackEnd") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_end"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_end_static_delegate)});
        if (efl_pack_before_static_delegate == null)
            efl_pack_before_static_delegate = new efl_pack_before_delegate(pack_before);
        if (methods.FirstOrDefault(m => m.Name == "PackBefore") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_before"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_before_static_delegate)});
        if (efl_pack_after_static_delegate == null)
            efl_pack_after_static_delegate = new efl_pack_after_delegate(pack_after);
        if (methods.FirstOrDefault(m => m.Name == "PackAfter") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_after"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_after_static_delegate)});
        if (efl_pack_at_static_delegate == null)
            efl_pack_at_static_delegate = new efl_pack_at_delegate(pack_at);
        if (methods.FirstOrDefault(m => m.Name == "PackAt") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_at"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_at_static_delegate)});
        if (efl_pack_content_get_static_delegate == null)
            efl_pack_content_get_static_delegate = new efl_pack_content_get_delegate(pack_content_get);
        if (methods.FirstOrDefault(m => m.Name == "GetPackContent") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_content_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_content_get_static_delegate)});
        if (efl_pack_index_get_static_delegate == null)
            efl_pack_index_get_static_delegate = new efl_pack_index_get_delegate(pack_index_get);
        if (methods.FirstOrDefault(m => m.Name == "GetPackIndex") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_index_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_index_get_static_delegate)});
        if (efl_pack_unpack_at_static_delegate == null)
            efl_pack_unpack_at_static_delegate = new efl_pack_unpack_at_delegate(pack_unpack_at);
        if (methods.FirstOrDefault(m => m.Name == "PackUnpackAt") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_pack_unpack_at"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_unpack_at_static_delegate)});
        if (efl_ui_direction_get_static_delegate == null)
            efl_ui_direction_get_static_delegate = new efl_ui_direction_get_delegate(direction_get);
        if (methods.FirstOrDefault(m => m.Name == "GetDirection") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_direction_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_direction_get_static_delegate)});
        if (efl_ui_direction_set_static_delegate == null)
            efl_ui_direction_set_static_delegate = new efl_ui_direction_set_delegate(direction_set);
        if (methods.FirstOrDefault(m => m.Name == "SetDirection") != null)
            descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_ui_direction_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_direction_set_static_delegate)});
        descs.AddRange(base.GetEoOps(type));
        return descs;
    }
    public override IntPtr GetEflClass()
    {
        return Efl.Ui.LayoutPartBox.efl_ui_layout_part_box_class_get();
    }
    public static new  IntPtr GetEflClassStatic()
    {
        return Efl.Ui.LayoutPartBox.efl_ui_layout_part_box_class_get();
    }


     private delegate void efl_ui_layout_part_box_real_part_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object layout,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String part);


     public delegate void efl_ui_layout_part_box_real_part_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Object, Efl.Eo.NonOwnTag>))]  Efl.Object layout,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]  System.String part);
     public static Efl.Eo.FunctionWrapper<efl_ui_layout_part_box_real_part_set_api_delegate> efl_ui_layout_part_box_real_part_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_layout_part_box_real_part_set_api_delegate>(_Module, "efl_ui_layout_part_box_real_part_set");
     private static void real_part_set(System.IntPtr obj, System.IntPtr pd,  Efl.Object layout,  System.String part)
    {
        Eina.Log.Debug("function efl_ui_layout_part_box_real_part_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        
            try {
                ((LayoutPartBox)wrapper).SetRealPart( layout,  part);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                                } else {
            efl_ui_layout_part_box_real_part_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  layout,  part);
        }
    }
    private static efl_ui_layout_part_box_real_part_set_delegate efl_ui_layout_part_box_real_part_set_static_delegate;


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
                _ret_var = ((LayoutPartBox)wrapper).ContentIterate();
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
                _ret_var = ((LayoutPartBox)wrapper).ContentCount();
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
                ((LayoutPartBox)wrapper).GetPackAlign( out align_horiz,  out align_vert);
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
                ((LayoutPartBox)wrapper).SetPackAlign( align_horiz,  align_vert);
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
                ((LayoutPartBox)wrapper).GetPackPadding( out pad_horiz,  out pad_vert,  out scalable);
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
                ((LayoutPartBox)wrapper).SetPackPadding( pad_horiz,  pad_vert,  scalable);
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
                _ret_var = ((LayoutPartBox)wrapper).ClearPack();
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
                _ret_var = ((LayoutPartBox)wrapper).UnpackAll();
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
                _ret_var = ((LayoutPartBox)wrapper).Unpack( subobj);
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
                _ret_var = ((LayoutPartBox)wrapper).DoPack( subobj);
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


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_pack_begin_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.IEntity subobj);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_pack_begin_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.IEntity subobj);
     public static Efl.Eo.FunctionWrapper<efl_pack_begin_api_delegate> efl_pack_begin_ptr = new Efl.Eo.FunctionWrapper<efl_pack_begin_api_delegate>(_Module, "efl_pack_begin");
     private static bool pack_begin(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.IEntity subobj)
    {
        Eina.Log.Debug("function efl_pack_begin was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                bool _ret_var = default(bool);
            try {
                _ret_var = ((LayoutPartBox)wrapper).PackBegin( subobj);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_pack_begin_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  subobj);
        }
    }
    private static efl_pack_begin_delegate efl_pack_begin_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_pack_end_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.IEntity subobj);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_pack_end_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.IEntity subobj);
     public static Efl.Eo.FunctionWrapper<efl_pack_end_api_delegate> efl_pack_end_ptr = new Efl.Eo.FunctionWrapper<efl_pack_end_api_delegate>(_Module, "efl_pack_end");
     private static bool pack_end(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.IEntity subobj)
    {
        Eina.Log.Debug("function efl_pack_end was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                bool _ret_var = default(bool);
            try {
                _ret_var = ((LayoutPartBox)wrapper).PackEnd( subobj);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_pack_end_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  subobj);
        }
    }
    private static efl_pack_end_delegate efl_pack_end_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_pack_before_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.IEntity subobj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.IEntity existing);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_pack_before_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.IEntity subobj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.IEntity existing);
     public static Efl.Eo.FunctionWrapper<efl_pack_before_api_delegate> efl_pack_before_ptr = new Efl.Eo.FunctionWrapper<efl_pack_before_api_delegate>(_Module, "efl_pack_before");
     private static bool pack_before(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.IEntity subobj,  Efl.Gfx.IEntity existing)
    {
        Eina.Log.Debug("function efl_pack_before was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        bool _ret_var = default(bool);
            try {
                _ret_var = ((LayoutPartBox)wrapper).PackBefore( subobj,  existing);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                        return _ret_var;
        } else {
            return efl_pack_before_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  subobj,  existing);
        }
    }
    private static efl_pack_before_delegate efl_pack_before_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_pack_after_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.IEntity subobj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.IEntity existing);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_pack_after_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.IEntity subobj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.IEntity existing);
     public static Efl.Eo.FunctionWrapper<efl_pack_after_api_delegate> efl_pack_after_ptr = new Efl.Eo.FunctionWrapper<efl_pack_after_api_delegate>(_Module, "efl_pack_after");
     private static bool pack_after(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.IEntity subobj,  Efl.Gfx.IEntity existing)
    {
        Eina.Log.Debug("function efl_pack_after was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        bool _ret_var = default(bool);
            try {
                _ret_var = ((LayoutPartBox)wrapper).PackAfter( subobj,  existing);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                        return _ret_var;
        } else {
            return efl_pack_after_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  subobj,  existing);
        }
    }
    private static efl_pack_after_delegate efl_pack_after_static_delegate;


     [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_pack_at_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.IEntity subobj,   int index);


     [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_pack_at_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.IEntity subobj,   int index);
     public static Efl.Eo.FunctionWrapper<efl_pack_at_api_delegate> efl_pack_at_ptr = new Efl.Eo.FunctionWrapper<efl_pack_at_api_delegate>(_Module, "efl_pack_at");
     private static bool pack_at(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.IEntity subobj,  int index)
    {
        Eina.Log.Debug("function efl_pack_at was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                                        bool _ret_var = default(bool);
            try {
                _ret_var = ((LayoutPartBox)wrapper).PackAt( subobj,  index);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                        return _ret_var;
        } else {
            return efl_pack_at_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  subobj,  index);
        }
    }
    private static efl_pack_at_delegate efl_pack_at_static_delegate;


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Gfx.IEntity efl_pack_content_get_delegate(System.IntPtr obj, System.IntPtr pd,   int index);


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Gfx.IEntity efl_pack_content_get_api_delegate(System.IntPtr obj,   int index);
     public static Efl.Eo.FunctionWrapper<efl_pack_content_get_api_delegate> efl_pack_content_get_ptr = new Efl.Eo.FunctionWrapper<efl_pack_content_get_api_delegate>(_Module, "efl_pack_content_get");
     private static Efl.Gfx.IEntity pack_content_get(System.IntPtr obj, System.IntPtr pd,  int index)
    {
        Eina.Log.Debug("function efl_pack_content_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                Efl.Gfx.IEntity _ret_var = default(Efl.Gfx.IEntity);
            try {
                _ret_var = ((LayoutPartBox)wrapper).GetPackContent( index);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_pack_content_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  index);
        }
    }
    private static efl_pack_content_get_delegate efl_pack_content_get_static_delegate;


     private delegate int efl_pack_index_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.IEntity subobj);


     public delegate int efl_pack_index_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.IEntity subobj);
     public static Efl.Eo.FunctionWrapper<efl_pack_index_get_api_delegate> efl_pack_index_get_ptr = new Efl.Eo.FunctionWrapper<efl_pack_index_get_api_delegate>(_Module, "efl_pack_index_get");
     private static int pack_index_get(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.IEntity subobj)
    {
        Eina.Log.Debug("function efl_pack_index_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                int _ret_var = default(int);
            try {
                _ret_var = ((LayoutPartBox)wrapper).GetPackIndex( subobj);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_pack_index_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  subobj);
        }
    }
    private static efl_pack_index_get_delegate efl_pack_index_get_static_delegate;


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Gfx.IEntity efl_pack_unpack_at_delegate(System.IntPtr obj, System.IntPtr pd,   int index);


    [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.IEntityConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Gfx.IEntity efl_pack_unpack_at_api_delegate(System.IntPtr obj,   int index);
     public static Efl.Eo.FunctionWrapper<efl_pack_unpack_at_api_delegate> efl_pack_unpack_at_ptr = new Efl.Eo.FunctionWrapper<efl_pack_unpack_at_api_delegate>(_Module, "efl_pack_unpack_at");
     private static Efl.Gfx.IEntity pack_unpack_at(System.IntPtr obj, System.IntPtr pd,  int index)
    {
        Eina.Log.Debug("function efl_pack_unpack_at was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                Efl.Gfx.IEntity _ret_var = default(Efl.Gfx.IEntity);
            try {
                _ret_var = ((LayoutPartBox)wrapper).PackUnpackAt( index);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                        return _ret_var;
        } else {
            return efl_pack_unpack_at_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  index);
        }
    }
    private static efl_pack_unpack_at_delegate efl_pack_unpack_at_static_delegate;


     private delegate Efl.Ui.Dir efl_ui_direction_get_delegate(System.IntPtr obj, System.IntPtr pd);


     public delegate Efl.Ui.Dir efl_ui_direction_get_api_delegate(System.IntPtr obj);
     public static Efl.Eo.FunctionWrapper<efl_ui_direction_get_api_delegate> efl_ui_direction_get_ptr = new Efl.Eo.FunctionWrapper<efl_ui_direction_get_api_delegate>(_Module, "efl_ui_direction_get");
     private static Efl.Ui.Dir direction_get(System.IntPtr obj, System.IntPtr pd)
    {
        Eina.Log.Debug("function efl_ui_direction_get was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                        Efl.Ui.Dir _ret_var = default(Efl.Ui.Dir);
            try {
                _ret_var = ((LayoutPartBox)wrapper).GetDirection();
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
        return _ret_var;
        } else {
            return efl_ui_direction_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
        }
    }
    private static efl_ui_direction_get_delegate efl_ui_direction_get_static_delegate;


     private delegate void efl_ui_direction_set_delegate(System.IntPtr obj, System.IntPtr pd,   Efl.Ui.Dir dir);


     public delegate void efl_ui_direction_set_api_delegate(System.IntPtr obj,   Efl.Ui.Dir dir);
     public static Efl.Eo.FunctionWrapper<efl_ui_direction_set_api_delegate> efl_ui_direction_set_ptr = new Efl.Eo.FunctionWrapper<efl_ui_direction_set_api_delegate>(_Module, "efl_ui_direction_set");
     private static void direction_set(System.IntPtr obj, System.IntPtr pd,  Efl.Ui.Dir dir)
    {
        Eina.Log.Debug("function efl_ui_direction_set was called");
        Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.PrivateDataGet(pd);
        if(wrapper != null) {
                                                
            try {
                ((LayoutPartBox)wrapper).SetDirection( dir);
            } catch (Exception e) {
                Eina.Log.Warning($"Callback error: {e.ToString()}");
                Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
            }
                                } else {
            efl_ui_direction_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  dir);
        }
    }
    private static efl_ui_direction_set_delegate efl_ui_direction_set_static_delegate;
}
} } 
