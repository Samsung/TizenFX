#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { 
/// <summary>Efl UI window interal part class</summary>
[WinPartNativeInherit]
public class WinPart : Efl.Ui.WidgetPart, Efl.Eo.IWrapper,Efl.Content,Efl.File,Efl.Gfx.Color
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.WinPartNativeInherit nativeInherit = new Efl.Ui.WinPartNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (WinPart))
            return Efl.Ui.WinPartNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_win_part_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   public WinPart(Efl.Object parent= null
         ) :
      base(efl_ui_win_part_class_get(), typeof(WinPart), parent)
   {
      FinishInstantiation();
   }
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public WinPart(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
   protected WinPart(IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(base_klass, managed_type, parent) {}
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static WinPart static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new WinPart(obj.NativeHandle);
   }
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
private static object ContentChangedEvtKey = new object();
   /// <summary>Sent after the content is set or unset using the current content object.</summary>
   public event EventHandler<Efl.ContentContentChangedEvt_Args> ContentChangedEvt
   {
      add {
         lock (eventLock) {
            string key = "_EFL_CONTENT_EVENT_CONTENT_CHANGED";
            if (add_cpp_event_handler(efl.Libs.Efl, key, this.evt_ContentChangedEvt_delegate)) {
               eventHandlers.AddHandler(ContentChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error adding proxy for event {key}");
         }
      }
      remove {
         lock (eventLock) {
            string key = "_EFL_CONTENT_EVENT_CONTENT_CHANGED";
            if (remove_cpp_event_handler(key, this.evt_ContentChangedEvt_delegate)) { 
               eventHandlers.RemoveHandler(ContentChangedEvtKey , value);
            } else
               Eina.Log.Error($"Error removing proxy for event {key}");
         }
      }
   }
   ///<summary>Method to raise event ContentChangedEvt.</summary>
   public void On_ContentChangedEvt(Efl.ContentContentChangedEvt_Args e)
   {
      EventHandler<Efl.ContentContentChangedEvt_Args> evt;
      lock (eventLock) {
      evt = (EventHandler<Efl.ContentContentChangedEvt_Args>)eventHandlers[ContentChangedEvtKey];
      }
      evt?.Invoke(this, e);
   }
   Efl.EventCb evt_ContentChangedEvt_delegate;
   private void on_ContentChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
   {
      Efl.ContentContentChangedEvt_Args args = new Efl.ContentContentChangedEvt_Args();
      args.arg = new Efl.Gfx.EntityConcrete(evt.Info);
      try {
         On_ContentChangedEvt(args);
      } catch (Exception e) {
         Eina.Log.Error(e.ToString());
         Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
      }
   }

   protected override void register_event_proxies()
   {
      base.register_event_proxies();
      evt_ContentChangedEvt_delegate = new Efl.EventCb(on_ContentChangedEvt_NativeCallback);
   }
   /// <summary>Swallowed sub-object contained in this object.</summary>
   /// <returns>The object to swallow.</returns>
   virtual public Efl.Gfx.Entity GetContent() {
       var _ret_var = Efl.ContentNativeInherit.efl_content_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Swallowed sub-object contained in this object.</summary>
   /// <param name="content">The object to swallow.</param>
   /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
   virtual public bool SetContent( Efl.Gfx.Entity content) {
                         var _ret_var = Efl.ContentNativeInherit.efl_content_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), content);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Unswallow the object in the current container and return it.</summary>
   /// <returns>Unswallowed object</returns>
   virtual public Efl.Gfx.Entity UnsetContent() {
       var _ret_var = Efl.ContentNativeInherit.efl_content_unset_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Get the mmaped file from where an object will fetch the real data (it must be an Eina_File).</summary>
   /// <returns>The handle to an Eina_File that will be used</returns>
   virtual public Eina.File GetMmap() {
       var _ret_var = Efl.FileNativeInherit.efl_file_mmap_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Set the mmaped file from where an object will fetch the real data (it must be an Eina_File).
   /// If mmap is set during object construction, the object will automatically call <see cref="Efl.File.Load"/> during the finalize phase of construction.</summary>
   /// <param name="f">The handle to an Eina_File that will be used</param>
   /// <returns>0 on success, error code otherwise</returns>
   virtual public  Eina.Error SetMmap( Eina.File f) {
                         var _ret_var = Efl.FileNativeInherit.efl_file_mmap_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), f);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Retrieve the file path from where an object is to fetch the data.
   /// You must not modify the strings on the returned pointers.</summary>
   /// <returns>The file path.</returns>
   virtual public  System.String GetFile() {
       var _ret_var = Efl.FileNativeInherit.efl_file_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Set the file path from where an object will fetch the data.
   /// If file is set during object construction, the object will automatically call <see cref="Efl.File.Load"/> during the finalize phase of construction.</summary>
   /// <param name="file">The file path.</param>
   /// <returns>0 on success, error code otherwise</returns>
   virtual public  Eina.Error SetFile(  System.String file) {
                         var _ret_var = Efl.FileNativeInherit.efl_file_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), file);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }
   /// <summary>Get the previously-set key which corresponds to the target data within a file.
   /// Some filetypes can contain multiple data streams which are indexed by a key. Use this property for such cases.
   /// 
   /// You must not modify the strings on the returned pointers.</summary>
   /// <returns>The group that the image belongs to, in case  it&apos;s an EET(including Edje case) file. This can be used as a key inside evas image cache if this is a normal image file not eet file.</returns>
   virtual public  System.String GetKey() {
       var _ret_var = Efl.FileNativeInherit.efl_file_key_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Set the key which corresponds to the target data within a file.
   /// Some filetypes can contain multiple data streams which are indexed by a key. Use this property for such cases.</summary>
   /// <param name="key">The group that the image belongs to, in case  it&apos;s an EET(including Edje case) file. This can be used as a key inside evas image cache if this is a normal image file not eet file.</param>
   /// <returns></returns>
   virtual public  void SetKey(  System.String key) {
                         Efl.FileNativeInherit.efl_file_key_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), key);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Get the load state of the object.</summary>
   /// <returns>True if the object is loaded, otherwise false.</returns>
   virtual public bool GetLoaded() {
       var _ret_var = Efl.FileNativeInherit.efl_file_loaded_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Perform all necessary operations to open and load file data into the object using the <see cref="Efl.File.File"/> (or <see cref="Efl.File.Mmap"/>) and <see cref="Efl.File.Key"/> properties.
   /// In the case where <see cref="Efl.File.SetFile"/> has been called on an object, this will internally open the file and call <see cref="Efl.File.SetMmap"/> on the object using the opened file handle.
   /// 
   /// Calling <see cref="Efl.File.Load"/> on an object which has already performed file operations based on the currently set properties will have no effect.</summary>
   /// <returns>0 on success, error code otherwise</returns>
   virtual public  Eina.Error Load() {
       var _ret_var = Efl.FileNativeInherit.efl_file_load_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Perform all necessary operations to unload file data from the object.
   /// In the case where <see cref="Efl.File.SetMmap"/> has been externally called on an object, the file handle stored in the object will be preserved.
   /// 
   /// Calling <see cref="Efl.File.Unload"/> on an object which is not currently loaded will have no effect.</summary>
   /// <returns></returns>
   virtual public  void Unload() {
       Efl.FileNativeInherit.efl_file_unload_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
       }
   /// <summary>Retrieves the general/main color of the given Evas object.
   /// Retrieves the main color&apos;s RGB component (and alpha channel) values, which range from 0 to 255. For the alpha channel, which defines the object&apos;s transparency level, 0 means totally transparent, while 255 means opaque. These color values are premultiplied by the alpha value.
   /// 
   /// Usually youll use this attribute for text and rectangle objects, where the main color is their unique one. If set for objects which themselves have colors, like the images one, those colors get modulated by this one.
   /// 
   /// All newly created Evas rectangles get the default color values of 255 255 255 255 (opaque white).
   /// 
   /// Use null pointers on the components you&apos;re not interested in: they&apos;ll be ignored by the function.</summary>
   /// <param name="r"></param>
   /// <param name="g"></param>
   /// <param name="b"></param>
   /// <param name="a"></param>
   /// <returns></returns>
   virtual public  void GetColor( out  int r,  out  int g,  out  int b,  out  int a) {
                                                                               Efl.Gfx.ColorNativeInherit.efl_gfx_color_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), out r,  out g,  out b,  out a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Sets the general/main color of the given Evas object to the given one.
   /// See also <see cref="Efl.Gfx.Color.GetColor"/> (for an example)
   /// 
   /// These color values are expected to be premultiplied by alpha.</summary>
   /// <param name="r"></param>
   /// <param name="g"></param>
   /// <param name="b"></param>
   /// <param name="a"></param>
   /// <returns></returns>
   virtual public  void SetColor(  int r,   int g,   int b,   int a) {
                                                                               Efl.Gfx.ColorNativeInherit.efl_gfx_color_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), r,  g,  b,  a);
      Eina.Error.RaiseIfUnhandledException();
                                                       }
   /// <summary>Get hex color code of given Evas object. This returns a short lived hex color code string.</summary>
   /// <returns>the hex color code.</returns>
   virtual public  System.String GetColorCode() {
       var _ret_var = Efl.Gfx.ColorNativeInherit.efl_gfx_color_code_get_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Set the color of given Evas object to the given hex color code(#RRGGBBAA). e.g. efl_gfx_color_code_set(obj, &quot;#FFCCAACC&quot;);</summary>
   /// <param name="colorcode">the hex color code.</param>
   /// <returns></returns>
   virtual public  void SetColorCode(  System.String colorcode) {
                         Efl.Gfx.ColorNativeInherit.efl_gfx_color_code_set_ptr.Value.Delegate((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle), colorcode);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>Swallowed sub-object contained in this object.</summary>
/// <value>The object to swallow.</value>
   public Efl.Gfx.Entity Content {
      get { return GetContent(); }
      set { SetContent( value); }
   }
   /// <summary>Get the mmaped file from where an object will fetch the real data (it must be an Eina_File).</summary>
/// <value>The handle to an Eina_File that will be used</value>
   public Eina.File Mmap {
      get { return GetMmap(); }
      set { SetMmap( value); }
   }
   /// <summary>Retrieve the file path from where an object is to fetch the data.
/// You must not modify the strings on the returned pointers.</summary>
/// <value>The file path.</value>
   public  System.String File {
      get { return GetFile(); }
      set { SetFile( value); }
   }
   /// <summary>Get the previously-set key which corresponds to the target data within a file.
/// Some filetypes can contain multiple data streams which are indexed by a key. Use this property for such cases.
/// 
/// You must not modify the strings on the returned pointers.</summary>
/// <value>The group that the image belongs to, in case  it&apos;s an EET(including Edje case) file. This can be used as a key inside evas image cache if this is a normal image file not eet file.</value>
   public  System.String Key {
      get { return GetKey(); }
      set { SetKey( value); }
   }
   /// <summary>Get the load state of the object.</summary>
/// <value>True if the object is loaded, otherwise false.</value>
   public bool Loaded {
      get { return GetLoaded(); }
   }
   /// <summary>Get hex color code of given Evas object. This returns a short lived hex color code string.</summary>
/// <value>the hex color code.</value>
   public  System.String ColorCode {
      get { return GetColorCode(); }
      set { SetColorCode( value); }
   }
   private static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.WinPart.efl_ui_win_part_class_get();
   }
}
public class WinPartNativeInherit : Efl.Ui.WidgetPartNativeInherit{
   public new  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Elementary);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_content_get_static_delegate == null)
      efl_content_get_static_delegate = new efl_content_get_delegate(content_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_content_get"), func = Marshal.GetFunctionPointerForDelegate(efl_content_get_static_delegate)});
      if (efl_content_set_static_delegate == null)
      efl_content_set_static_delegate = new efl_content_set_delegate(content_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_content_set"), func = Marshal.GetFunctionPointerForDelegate(efl_content_set_static_delegate)});
      if (efl_content_unset_static_delegate == null)
      efl_content_unset_static_delegate = new efl_content_unset_delegate(content_unset);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_content_unset"), func = Marshal.GetFunctionPointerForDelegate(efl_content_unset_static_delegate)});
      if (efl_file_mmap_get_static_delegate == null)
      efl_file_mmap_get_static_delegate = new efl_file_mmap_get_delegate(mmap_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_file_mmap_get"), func = Marshal.GetFunctionPointerForDelegate(efl_file_mmap_get_static_delegate)});
      if (efl_file_mmap_set_static_delegate == null)
      efl_file_mmap_set_static_delegate = new efl_file_mmap_set_delegate(mmap_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_file_mmap_set"), func = Marshal.GetFunctionPointerForDelegate(efl_file_mmap_set_static_delegate)});
      if (efl_file_get_static_delegate == null)
      efl_file_get_static_delegate = new efl_file_get_delegate(file_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_file_get"), func = Marshal.GetFunctionPointerForDelegate(efl_file_get_static_delegate)});
      if (efl_file_set_static_delegate == null)
      efl_file_set_static_delegate = new efl_file_set_delegate(file_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_file_set"), func = Marshal.GetFunctionPointerForDelegate(efl_file_set_static_delegate)});
      if (efl_file_key_get_static_delegate == null)
      efl_file_key_get_static_delegate = new efl_file_key_get_delegate(key_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_file_key_get"), func = Marshal.GetFunctionPointerForDelegate(efl_file_key_get_static_delegate)});
      if (efl_file_key_set_static_delegate == null)
      efl_file_key_set_static_delegate = new efl_file_key_set_delegate(key_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_file_key_set"), func = Marshal.GetFunctionPointerForDelegate(efl_file_key_set_static_delegate)});
      if (efl_file_loaded_get_static_delegate == null)
      efl_file_loaded_get_static_delegate = new efl_file_loaded_get_delegate(loaded_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_file_loaded_get"), func = Marshal.GetFunctionPointerForDelegate(efl_file_loaded_get_static_delegate)});
      if (efl_file_load_static_delegate == null)
      efl_file_load_static_delegate = new efl_file_load_delegate(load);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_file_load"), func = Marshal.GetFunctionPointerForDelegate(efl_file_load_static_delegate)});
      if (efl_file_unload_static_delegate == null)
      efl_file_unload_static_delegate = new efl_file_unload_delegate(unload);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_file_unload"), func = Marshal.GetFunctionPointerForDelegate(efl_file_unload_static_delegate)});
      if (efl_gfx_color_get_static_delegate == null)
      efl_gfx_color_get_static_delegate = new efl_gfx_color_get_delegate(color_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_color_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_get_static_delegate)});
      if (efl_gfx_color_set_static_delegate == null)
      efl_gfx_color_set_static_delegate = new efl_gfx_color_set_delegate(color_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_color_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_set_static_delegate)});
      if (efl_gfx_color_code_get_static_delegate == null)
      efl_gfx_color_code_get_static_delegate = new efl_gfx_color_code_get_delegate(color_code_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_color_code_get"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_code_get_static_delegate)});
      if (efl_gfx_color_code_set_static_delegate == null)
      efl_gfx_color_code_set_static_delegate = new efl_gfx_color_code_set_delegate(color_code_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_gfx_color_code_set"), func = Marshal.GetFunctionPointerForDelegate(efl_gfx_color_code_set_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.WinPart.efl_ui_win_part_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.WinPart.efl_ui_win_part_class_get();
   }


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Gfx.Entity efl_content_get_delegate(System.IntPtr obj, System.IntPtr pd);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Gfx.Entity efl_content_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_content_get_api_delegate> efl_content_get_ptr = new Efl.Eo.FunctionWrapper<efl_content_get_api_delegate>(_Module, "efl_content_get");
    private static Efl.Gfx.Entity content_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_content_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Gfx.Entity _ret_var = default(Efl.Gfx.Entity);
         try {
            _ret_var = ((WinPart)wrapper).GetContent();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_content_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_content_get_delegate efl_content_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_content_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity content);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_content_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))]  Efl.Gfx.Entity content);
    public static Efl.Eo.FunctionWrapper<efl_content_set_api_delegate> efl_content_set_ptr = new Efl.Eo.FunctionWrapper<efl_content_set_api_delegate>(_Module, "efl_content_set");
    private static bool content_set(System.IntPtr obj, System.IntPtr pd,  Efl.Gfx.Entity content)
   {
      Eina.Log.Debug("function efl_content_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((WinPart)wrapper).SetContent( content);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_content_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  content);
      }
   }
   private static efl_content_set_delegate efl_content_set_static_delegate;


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] private delegate Efl.Gfx.Entity efl_content_unset_delegate(System.IntPtr obj, System.IntPtr pd);


   [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalTest<Efl.Gfx.EntityConcrete, Efl.Eo.NonOwnTag>))] public delegate Efl.Gfx.Entity efl_content_unset_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_content_unset_api_delegate> efl_content_unset_ptr = new Efl.Eo.FunctionWrapper<efl_content_unset_api_delegate>(_Module, "efl_content_unset");
    private static Efl.Gfx.Entity content_unset(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_content_unset was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Gfx.Entity _ret_var = default(Efl.Gfx.Entity);
         try {
            _ret_var = ((WinPart)wrapper).UnsetContent();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_content_unset_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_content_unset_delegate efl_content_unset_static_delegate;


    private delegate Eina.File efl_file_mmap_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate Eina.File efl_file_mmap_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_file_mmap_get_api_delegate> efl_file_mmap_get_ptr = new Efl.Eo.FunctionWrapper<efl_file_mmap_get_api_delegate>(_Module, "efl_file_mmap_get");
    private static Eina.File mmap_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_file_mmap_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.File _ret_var = default(Eina.File);
         try {
            _ret_var = ((WinPart)wrapper).GetMmap();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_file_mmap_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_file_mmap_get_delegate efl_file_mmap_get_static_delegate;


    private delegate  Eina.Error efl_file_mmap_set_delegate(System.IntPtr obj, System.IntPtr pd,   Eina.File f);


    public delegate  Eina.Error efl_file_mmap_set_api_delegate(System.IntPtr obj,   Eina.File f);
    public static Efl.Eo.FunctionWrapper<efl_file_mmap_set_api_delegate> efl_file_mmap_set_ptr = new Efl.Eo.FunctionWrapper<efl_file_mmap_set_api_delegate>(_Module, "efl_file_mmap_set");
    private static  Eina.Error mmap_set(System.IntPtr obj, System.IntPtr pd,  Eina.File f)
   {
      Eina.Log.Debug("function efl_file_mmap_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                     Eina.Error _ret_var = default( Eina.Error);
         try {
            _ret_var = ((WinPart)wrapper).SetMmap( f);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_file_mmap_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  f);
      }
   }
   private static efl_file_mmap_set_delegate efl_file_mmap_set_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_file_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_file_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_file_get_api_delegate> efl_file_get_ptr = new Efl.Eo.FunctionWrapper<efl_file_get_api_delegate>(_Module, "efl_file_get");
    private static  System.String file_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_file_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((WinPart)wrapper).GetFile();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_file_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_file_get_delegate efl_file_get_static_delegate;


    private delegate  Eina.Error efl_file_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String file);


    public delegate  Eina.Error efl_file_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String file);
    public static Efl.Eo.FunctionWrapper<efl_file_set_api_delegate> efl_file_set_ptr = new Efl.Eo.FunctionWrapper<efl_file_set_api_delegate>(_Module, "efl_file_set");
    private static  Eina.Error file_set(System.IntPtr obj, System.IntPtr pd,   System.String file)
   {
      Eina.Log.Debug("function efl_file_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                     Eina.Error _ret_var = default( Eina.Error);
         try {
            _ret_var = ((WinPart)wrapper).SetFile( file);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_file_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  file);
      }
   }
   private static efl_file_set_delegate efl_file_set_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_file_key_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_file_key_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_file_key_get_api_delegate> efl_file_key_get_ptr = new Efl.Eo.FunctionWrapper<efl_file_key_get_api_delegate>(_Module, "efl_file_key_get");
    private static  System.String key_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_file_key_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((WinPart)wrapper).GetKey();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_file_key_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_file_key_get_delegate efl_file_key_get_static_delegate;


    private delegate  void efl_file_key_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);


    public delegate  void efl_file_key_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);
    public static Efl.Eo.FunctionWrapper<efl_file_key_set_api_delegate> efl_file_key_set_ptr = new Efl.Eo.FunctionWrapper<efl_file_key_set_api_delegate>(_Module, "efl_file_key_set");
    private static  void key_set(System.IntPtr obj, System.IntPtr pd,   System.String key)
   {
      Eina.Log.Debug("function efl_file_key_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((WinPart)wrapper).SetKey( key);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_file_key_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  key);
      }
   }
   private static efl_file_key_set_delegate efl_file_key_set_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_file_loaded_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_file_loaded_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_file_loaded_get_api_delegate> efl_file_loaded_get_ptr = new Efl.Eo.FunctionWrapper<efl_file_loaded_get_api_delegate>(_Module, "efl_file_loaded_get");
    private static bool loaded_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_file_loaded_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((WinPart)wrapper).GetLoaded();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_file_loaded_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_file_loaded_get_delegate efl_file_loaded_get_static_delegate;


    private delegate  Eina.Error efl_file_load_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  Eina.Error efl_file_load_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_file_load_api_delegate> efl_file_load_ptr = new Efl.Eo.FunctionWrapper<efl_file_load_api_delegate>(_Module, "efl_file_load");
    private static  Eina.Error load(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_file_load was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   Eina.Error _ret_var = default( Eina.Error);
         try {
            _ret_var = ((WinPart)wrapper).Load();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_file_load_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_file_load_delegate efl_file_load_static_delegate;


    private delegate  void efl_file_unload_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate  void efl_file_unload_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_file_unload_api_delegate> efl_file_unload_ptr = new Efl.Eo.FunctionWrapper<efl_file_unload_api_delegate>(_Module, "efl_file_unload");
    private static  void unload(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_file_unload was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  
         try {
            ((WinPart)wrapper).Unload();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
            } else {
         efl_file_unload_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_file_unload_delegate efl_file_unload_static_delegate;


    private delegate  void efl_gfx_color_get_delegate(System.IntPtr obj, System.IntPtr pd,   out  int r,   out  int g,   out  int b,   out  int a);


    public delegate  void efl_gfx_color_get_api_delegate(System.IntPtr obj,   out  int r,   out  int g,   out  int b,   out  int a);
    public static Efl.Eo.FunctionWrapper<efl_gfx_color_get_api_delegate> efl_gfx_color_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_get_api_delegate>(_Module, "efl_gfx_color_get");
    private static  void color_get(System.IntPtr obj, System.IntPtr pd,  out  int r,  out  int g,  out  int b,  out  int a)
   {
      Eina.Log.Debug("function efl_gfx_color_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                       r = default( int);      g = default( int);      b = default( int);      a = default( int);                                 
         try {
            ((WinPart)wrapper).GetColor( out r,  out g,  out b,  out a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_color_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  out r,  out g,  out b,  out a);
      }
   }
   private static efl_gfx_color_get_delegate efl_gfx_color_get_static_delegate;


    private delegate  void efl_gfx_color_set_delegate(System.IntPtr obj, System.IntPtr pd,    int r,    int g,    int b,    int a);


    public delegate  void efl_gfx_color_set_api_delegate(System.IntPtr obj,    int r,    int g,    int b,    int a);
    public static Efl.Eo.FunctionWrapper<efl_gfx_color_set_api_delegate> efl_gfx_color_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_set_api_delegate>(_Module, "efl_gfx_color_set");
    private static  void color_set(System.IntPtr obj, System.IntPtr pd,   int r,   int g,   int b,   int a)
   {
      Eina.Log.Debug("function efl_gfx_color_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                                          
         try {
            ((WinPart)wrapper).SetColor( r,  g,  b,  a);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                                            } else {
         efl_gfx_color_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  r,  g,  b,  a);
      }
   }
   private static efl_gfx_color_set_delegate efl_gfx_color_set_static_delegate;


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] private delegate  System.String efl_gfx_color_code_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] public delegate  System.String efl_gfx_color_code_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_gfx_color_code_get_api_delegate> efl_gfx_color_code_get_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_code_get_api_delegate>(_Module, "efl_gfx_color_code_get");
    private static  System.String color_code_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_gfx_color_code_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.String _ret_var = default( System.String);
         try {
            _ret_var = ((WinPart)wrapper).GetColorCode();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_gfx_color_code_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_gfx_color_code_get_delegate efl_gfx_color_code_get_static_delegate;


    private delegate  void efl_gfx_color_code_set_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String colorcode);


    public delegate  void efl_gfx_color_code_set_api_delegate(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String colorcode);
    public static Efl.Eo.FunctionWrapper<efl_gfx_color_code_set_api_delegate> efl_gfx_color_code_set_ptr = new Efl.Eo.FunctionWrapper<efl_gfx_color_code_set_api_delegate>(_Module, "efl_gfx_color_code_set");
    private static  void color_code_set(System.IntPtr obj, System.IntPtr pd,   System.String colorcode)
   {
      Eina.Log.Debug("function efl_gfx_color_code_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((WinPart)wrapper).SetColorCode( colorcode);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_gfx_color_code_set_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  colorcode);
      }
   }
   private static efl_gfx_color_code_set_delegate efl_gfx_color_code_set_static_delegate;
}
} } 
