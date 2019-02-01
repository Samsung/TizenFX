#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { namespace Canvas { 
/// <summary>Object factory that creates Efl.Canvas.Object objects.
/// Translates a given key to an object (item), to be later placed in a text for higher level usages. The translation implementation is left to be decided by the inheriting class, whether it is by treating the <c>key</c> as an image path, or a key associated with a real-path in a hashtable or something else entirely.
/// 1.21</summary>
[TextFactoryConcreteNativeInherit]
public interface TextFactory : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Translates a given <c>key</c> to an item object, and returns the object. The returned object should be owned by the passed <c>object</c>.
/// 1.21</summary>
/// <param name="kw_object">The parent of the created object
/// 1.21</param>
/// <param name="key">Key that is associated to an item object
/// 1.21</param>
/// <returns></returns>
Efl.Canvas.Object Create( Efl.Canvas.Object kw_object,   System.String key);
   }
/// <summary>Object factory that creates Efl.Canvas.Object objects.
/// Translates a given key to an object (item), to be later placed in a text for higher level usages. The translation implementation is left to be decided by the inheriting class, whether it is by treating the <c>key</c> as an image path, or a key associated with a real-path in a hashtable or something else entirely.
/// 1.21</summary>
sealed public class TextFactoryConcrete : 

TextFactory
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (TextFactoryConcrete))
            return Efl.Canvas.TextFactoryConcreteNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   private  System.IntPtr handle;
   public Dictionary<String, IntPtr> cached_strings = new Dictionary<String, IntPtr>();
   public Dictionary<String, IntPtr> cached_stringshares = new Dictionary<String, IntPtr>();
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] internal static extern System.IntPtr
      efl_canvas_text_factory_interface_get();
   ///<summary>Constructs an instance from a native pointer.</summary>
   public TextFactoryConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~TextFactoryConcrete()
   {
      Dispose(false);
   }
   ///<summary>Releases the underlying native instance.</summary>
   void Dispose(bool disposing)
   {
      if (handle != System.IntPtr.Zero) {
         Efl.Eo.Globals.efl_unref(handle);
         handle = System.IntPtr.Zero;
      }
   }
   ///<summary>Releases the underlying native instance.</summary>
   public void Dispose()
   {
   Efl.Eo.Globals.free_dict_values(cached_strings);
   Efl.Eo.Globals.free_stringshare_values(cached_stringshares);
      Dispose(true);
      GC.SuppressFinalize(this);
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public static TextFactoryConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new TextFactoryConcrete(obj.NativeHandle);
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
    void register_event_proxies()
   {
   }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.OwnTag>))] private static extern Efl.Canvas.Object efl_canvas_text_factory_create(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object kw_object,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);
   /// <summary>Translates a given <c>key</c> to an item object, and returns the object. The returned object should be owned by the passed <c>object</c>.
   /// 1.21</summary>
   /// <param name="kw_object">The parent of the created object
   /// 1.21</param>
   /// <param name="key">Key that is associated to an item object
   /// 1.21</param>
   /// <returns></returns>
   public Efl.Canvas.Object Create( Efl.Canvas.Object kw_object,   System.String key) {
                                           var _ret_var = efl_canvas_text_factory_create(Efl.Canvas.TextFactoryConcrete.efl_canvas_text_factory_interface_get(),  kw_object,  key);
      Eina.Error.RaiseIfUnhandledException();
                              return _ret_var;
 }
}
public class TextFactoryConcreteNativeInherit : Efl.Eo.NativeClass{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_canvas_text_factory_create_static_delegate = new efl_canvas_text_factory_create_delegate(create);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_canvas_text_factory_create"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_text_factory_create_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.Canvas.TextFactoryConcrete.efl_canvas_text_factory_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.Canvas.TextFactoryConcrete.efl_canvas_text_factory_interface_get();
   }


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.OwnTag>))] private delegate Efl.Canvas.Object efl_canvas_text_factory_create_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object kw_object,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Evas)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.OwnTag>))] private static extern Efl.Canvas.Object efl_canvas_text_factory_create(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Canvas.Object, Efl.Eo.NonOwnTag>))]  Efl.Canvas.Object kw_object,  [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))]   System.String key);
    private static Efl.Canvas.Object create(System.IntPtr obj, System.IntPtr pd,  Efl.Canvas.Object kw_object,   System.String key)
   {
      Eina.Log.Debug("function efl_canvas_text_factory_create was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                                      Efl.Canvas.Object _ret_var = default(Efl.Canvas.Object);
         try {
            _ret_var = ((TextFactory)wrapper).Create( kw_object,  key);
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
} } 
