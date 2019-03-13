#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Efl media playable interface</summary>
[PlayableNativeInherit]
public interface Playable : 
   Efl.Eo.IWrapper, IDisposable
{
   /// <summary>Get the length of play for the media file.</summary>
/// <returns>The length of the stream in seconds.</returns>
double GetLength();
   /// <summary></summary>
/// <returns></returns>
bool GetPlayable();
   /// <summary>Get whether the media file is seekable.</summary>
/// <returns><c>true</c> if seekable.</returns>
bool GetSeekable();
            /// <summary>Get the length of play for the media file.</summary>
/// <value>The length of the stream in seconds.</value>
   double Length {
      get ;
   }
   /// <summary></summary>
/// <value></value>
   bool Playable {
      get ;
   }
   /// <summary>Get whether the media file is seekable.</summary>
/// <value><c>true</c> if seekable.</value>
   bool Seekable {
      get ;
   }
}
/// <summary>Efl media playable interface</summary>
sealed public class PlayableConcrete : 

Playable
   
{
   ///<summary>Pointer to the native class description.</summary>
   public System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (PlayableConcrete))
            return Efl.PlayableNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
      }
   }
   private  System.IntPtr handle;
   ///<summary>Pointer to the native instance.</summary>
   public System.IntPtr NativeHandle {
      get { return handle; }
   }
   [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)] internal static extern System.IntPtr
      efl_playable_interface_get();
   ///<summary>Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
   public PlayableConcrete(System.IntPtr raw)
   {
      handle = raw;
      register_event_proxies();
   }
   ///<summary>Destructor.</summary>
   ~PlayableConcrete()
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
      Dispose(true);
      GC.SuppressFinalize(this);
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public static PlayableConcrete static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new PlayableConcrete(obj.NativeHandle);
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
   /// <summary>Get the length of play for the media file.</summary>
   /// <returns>The length of the stream in seconds.</returns>
   public double GetLength() {
       var _ret_var = Efl.PlayableNativeInherit.efl_playable_length_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary></summary>
   /// <returns></returns>
   public bool GetPlayable() {
       var _ret_var = Efl.PlayableNativeInherit.efl_playable_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Get whether the media file is seekable.</summary>
   /// <returns><c>true</c> if seekable.</returns>
   public bool GetSeekable() {
       var _ret_var = Efl.PlayableNativeInherit.efl_playable_seekable_get_ptr.Value.Delegate(this.NativeHandle);
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   /// <summary>Get the length of play for the media file.</summary>
/// <value>The length of the stream in seconds.</value>
   public double Length {
      get { return GetLength(); }
   }
   /// <summary></summary>
/// <value></value>
   public bool Playable {
      get { return GetPlayable(); }
   }
   /// <summary>Get whether the media file is seekable.</summary>
/// <value><c>true</c> if seekable.</value>
   public bool Seekable {
      get { return GetSeekable(); }
   }
}
public class PlayableNativeInherit  : Efl.Eo.NativeClass{
   public  static Efl.Eo.NativeModule _Module = new Efl.Eo.NativeModule(efl.Libs.Efl);
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      if (efl_playable_length_get_static_delegate == null)
      efl_playable_length_get_static_delegate = new efl_playable_length_get_delegate(length_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_playable_length_get"), func = Marshal.GetFunctionPointerForDelegate(efl_playable_length_get_static_delegate)});
      if (efl_playable_get_static_delegate == null)
      efl_playable_get_static_delegate = new efl_playable_get_delegate(playable_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_playable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_playable_get_static_delegate)});
      if (efl_playable_seekable_get_static_delegate == null)
      efl_playable_seekable_get_static_delegate = new efl_playable_seekable_get_delegate(seekable_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(_Module.Module, "efl_playable_seekable_get"), func = Marshal.GetFunctionPointerForDelegate(efl_playable_seekable_get_static_delegate)});
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.PlayableConcrete.efl_playable_interface_get();
   }
   public static  IntPtr GetEflClassStatic()
   {
      return Efl.PlayableConcrete.efl_playable_interface_get();
   }


    private delegate double efl_playable_length_get_delegate(System.IntPtr obj, System.IntPtr pd);


    public delegate double efl_playable_length_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_playable_length_get_api_delegate> efl_playable_length_get_ptr = new Efl.Eo.FunctionWrapper<efl_playable_length_get_api_delegate>(_Module, "efl_playable_length_get");
    private static double length_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_playable_length_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  double _ret_var = default(double);
         try {
            _ret_var = ((Playable)wrapper).GetLength();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_playable_length_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_playable_length_get_delegate efl_playable_length_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_playable_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_playable_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_playable_get_api_delegate> efl_playable_get_ptr = new Efl.Eo.FunctionWrapper<efl_playable_get_api_delegate>(_Module, "efl_playable_get");
    private static bool playable_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_playable_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Playable)wrapper).GetPlayable();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_playable_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_playable_get_delegate efl_playable_get_static_delegate;


    [return: MarshalAs(UnmanagedType.U1)] private delegate bool efl_playable_seekable_get_delegate(System.IntPtr obj, System.IntPtr pd);


    [return: MarshalAs(UnmanagedType.U1)] public delegate bool efl_playable_seekable_get_api_delegate(System.IntPtr obj);
    public static Efl.Eo.FunctionWrapper<efl_playable_seekable_get_api_delegate> efl_playable_seekable_get_ptr = new Efl.Eo.FunctionWrapper<efl_playable_seekable_get_api_delegate>(_Module, "efl_playable_seekable_get");
    private static bool seekable_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_playable_seekable_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  bool _ret_var = default(bool);
         try {
            _ret_var = ((Playable)wrapper).GetSeekable();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_playable_seekable_get_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private static efl_playable_seekable_get_delegate efl_playable_seekable_get_static_delegate;
}
} 
