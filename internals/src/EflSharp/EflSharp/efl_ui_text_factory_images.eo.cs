#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Ui { namespace TextFactory { 
/// <summary>Factory that creates images given key string
/// The key can be either a full image path, or associated with one. The factory will fallback if key was not matches with an image, and try to load it as a full path.
/// 1.21</summary>
[ImagesNativeInherit]
public class Images : Efl.Object, Efl.Eo.IWrapper,Efl.Canvas.TextFactory
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.Ui.TextFactory.ImagesNativeInherit nativeInherit = new Efl.Ui.TextFactory.ImagesNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (Images))
            return Efl.Ui.TextFactory.ImagesNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(Images obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)] internal static extern System.IntPtr
      efl_ui_text_factory_images_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public Images(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("Images", efl_ui_text_factory_images_class_get(), typeof(Images), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected Images(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public Images(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static Images static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new Images(obj.NativeHandle);
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
   protected override void register_event_proxies()
   {
      base.register_event_proxies();
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_text_factory_images_matches_add(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String path,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);
   /// <summary>Associates given name with a path of an image or EET file.
   /// This can be used for quick retrieval (instead of providing actual filenames.
   /// 
   /// This <c>file</c> is associated with <c>name</c> is considered a full file path.
   /// 
   /// see <see cref="Efl.Ui.TextFactory.Images.AddMatchesMmap"/> for mmap version see <see cref="Efl.Ui.TextFactory.Images.DelMatches"/>
   /// 1.21</summary>
   /// <param name="name">the name associated with filename
   /// 1.21</param>
   /// <param name="path">the image or EET file path
   /// 1.21</param>
   /// <param name="key">the key to use (in cases of loading an EET file
   /// 1.21</param>
   /// <returns><c>true</c> if successful, <c>false</c> otherwise
   /// 1.21</returns>
   virtual public bool AddMatches(  System.String name,   System.String path,   System.String key) {
                                                             var _ret_var = efl_ui_text_factory_images_matches_add((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  name,  path,  key);
      Eina.Error.RaiseIfUnhandledException();
                                          return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_text_factory_images_matches_del(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);
   /// <summary>Deletes an association of <c>key</c> with its respective file path.
   /// see <see cref="Efl.Ui.TextFactory.Images.AddMatches"/>
   /// 1.21</summary>
   /// <param name="key">the entry&apos;s key to delete
   /// 1.21</param>
   /// <returns><c>true</c> if successful, <c>false</c> otherwise
   /// 1.21</returns>
   virtual public bool DelMatches(  System.String key) {
                         var _ret_var = efl_ui_text_factory_images_matches_del((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  key);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_text_factory_images_matches_mmap_add(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name,   Eina.File file,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);
   /// <summary>Associates given name with a mmap&apos;d image or EET file and key.
   /// see <see cref="Efl.Ui.TextFactory.Images.AddMatches"/> for string file path version see <see cref="Efl.Ui.TextFactory.Images.DelMatchesMmap"/>
   /// 1.21</summary>
   /// <param name="name">the name associated with filename
   /// 1.21</param>
   /// <param name="file">the image or EET file
   /// 1.21</param>
   /// <param name="key">the key to use (in cases of loading an EET file
   /// 1.21</param>
   /// <returns><c>true</c> if successful, <c>false</c> otherwise
   /// 1.21</returns>
   virtual public bool AddMatchesMmap(  System.String name,  Eina.File file,   System.String key) {
                                                             var _ret_var = efl_ui_text_factory_images_matches_mmap_add((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  name,  file,  key);
      Eina.Error.RaiseIfUnhandledException();
                                          return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
    [return: MarshalAs(UnmanagedType.U1)] protected static extern bool efl_ui_text_factory_images_matches_mmap_del(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);
   /// <summary>Deletes an association of <c>key</c> with its respective file.
   /// see <see cref="Efl.Ui.TextFactory.Images.AddMatchesMmap"/>
   /// 1.21</summary>
   /// <param name="key">the entry&apos;s key to delete
   /// 1.21</param>
   /// <returns><c>true</c> if successful, <c>false</c> otherwise
   /// 1.21</returns>
   virtual public bool DelMatchesMmap(  System.String key) {
                         var _ret_var = efl_ui_text_factory_images_matches_mmap_del((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  key);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.OwnTag>))] protected static extern Efl.Canvas.Object efl_canvas_text_factory_create(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object kw_object,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);
   /// <summary>Translates a given <c>key</c> to an item object, and returns the object. The returned object should be owned by the passed <c>object</c>.
   /// 1.21</summary>
   /// <param name="kw_object">The parent of the created object
   /// 1.21</param>
   /// <param name="key">Key that is associated to an item object
   /// 1.21</param>
   /// <returns></returns>
   virtual public Efl.Canvas.Object Create( Efl.Canvas.Object kw_object,   System.String key) {
                                           var _ret_var = efl_canvas_text_factory_create((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  kw_object,  key);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
}
public class ImagesNativeInherit : Efl.ObjectNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_ui_text_factory_images_matches_add_static_delegate = new efl_ui_text_factory_images_matches_add_delegate(matches_add);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_text_factory_images_matches_add"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_factory_images_matches_add_static_delegate)});
      efl_ui_text_factory_images_matches_del_static_delegate = new efl_ui_text_factory_images_matches_del_delegate(matches_del);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_text_factory_images_matches_del"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_factory_images_matches_del_static_delegate)});
      efl_ui_text_factory_images_matches_mmap_add_static_delegate = new efl_ui_text_factory_images_matches_mmap_add_delegate(matches_mmap_add);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_text_factory_images_matches_mmap_add"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_factory_images_matches_mmap_add_static_delegate)});
      efl_ui_text_factory_images_matches_mmap_del_static_delegate = new efl_ui_text_factory_images_matches_mmap_del_delegate(matches_mmap_del);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_ui_text_factory_images_matches_mmap_del"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_text_factory_images_matches_mmap_del_static_delegate)});
      efl_canvas_text_factory_create_static_delegate = new efl_canvas_text_factory_create_delegate(create);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_text_factory_create"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_text_factory_create_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Ui.TextFactory.Images.efl_ui_text_factory_images_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.Ui.TextFactory.Images.efl_ui_text_factory_images_class_get();
   }


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_text_factory_images_matches_add_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String path,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_text_factory_images_matches_add(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String path,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);
    private static bool matches_add(System.IntPtr obj, System.IntPtr pd,   System.String name,   System.String path,   System.String key)
   {
      Eina.Log.Debug("function efl_ui_text_factory_images_matches_add was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        bool _ret_var = default(bool);
         try {
            _ret_var = ((Images)wrapper).AddMatches( name,  path,  key);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                          return _ret_var;
      } else {
         return efl_ui_text_factory_images_matches_add(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name,  path,  key);
      }
   }
   private efl_ui_text_factory_images_matches_add_delegate efl_ui_text_factory_images_matches_add_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_text_factory_images_matches_del_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_text_factory_images_matches_del(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);
    private static bool matches_del(System.IntPtr obj, System.IntPtr pd,   System.String key)
   {
      Eina.Log.Debug("function efl_ui_text_factory_images_matches_del was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Images)wrapper).DelMatches( key);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_ui_text_factory_images_matches_del(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  key);
      }
   }
   private efl_ui_text_factory_images_matches_del_delegate efl_ui_text_factory_images_matches_del_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_text_factory_images_matches_mmap_add_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name,   Eina.File file,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_text_factory_images_matches_mmap_add(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String name,   Eina.File file,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);
    private static bool matches_mmap_add(System.IntPtr obj, System.IntPtr pd,   System.String name,  Eina.File file,   System.String key)
   {
      Eina.Log.Debug("function efl_ui_text_factory_images_matches_mmap_add was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                                        bool _ret_var = default(bool);
         try {
            _ret_var = ((Images)wrapper).AddMatchesMmap( name,  file,  key);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                                          return _ret_var;
      } else {
         return efl_ui_text_factory_images_matches_mmap_add(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  name,  file,  key);
      }
   }
   private efl_ui_text_factory_images_matches_mmap_add_delegate efl_ui_text_factory_images_matches_mmap_add_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_ui_text_factory_images_matches_mmap_del_delegate(System.IntPtr obj, System.IntPtr pd,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]  [return: MarshalAs(UnmanagedType.U1)] private static extern bool efl_ui_text_factory_images_matches_mmap_del(System.IntPtr obj,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);
    private static bool matches_mmap_del(System.IntPtr obj, System.IntPtr pd,   System.String key)
   {
      Eina.Log.Debug("function efl_ui_text_factory_images_matches_mmap_del was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    bool _ret_var = default(bool);
         try {
            _ret_var = ((Images)wrapper).DelMatchesMmap( key);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_ui_text_factory_images_matches_mmap_del(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  key);
      }
   }
   private efl_ui_text_factory_images_matches_mmap_del_delegate efl_ui_text_factory_images_matches_mmap_del_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.OwnTag>))] private delegate Efl.Canvas.Object efl_canvas_text_factory_create_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object kw_object,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.OwnTag>))] private static extern Efl.Canvas.Object efl_canvas_text_factory_create(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object kw_object,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);
    private static Efl.Canvas.Object create(System.IntPtr obj, System.IntPtr pd,  Efl.Canvas.Object kw_object,   System.String key)
   {
      Eina.Log.Debug("function efl_canvas_text_factory_create was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
         try {
            _ret_var = ((Images)wrapper).Create( kw_object,  key);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                              return _ret_var;
      } else {
         return efl_canvas_text_factory_create(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  kw_object,  key);
      }
   }
   private efl_canvas_text_factory_create_delegate efl_canvas_text_factory_create_static_delegate;
}
} } } 
