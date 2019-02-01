#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>Used internally for futures on the loop</summary>
[LoopMessageFutureNativeInherit]
public class LoopMessageFuture : Efl.LoopMessage, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.LoopMessageFutureNativeInherit nativeInherit = new Efl.LoopMessageFutureNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (LoopMessageFuture))
            return Efl.LoopMessageFutureNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(LoopMessageFuture obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
      efl_loop_message_future_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public LoopMessageFuture(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("LoopMessageFuture", efl_loop_message_future_class_get(), typeof(LoopMessageFuture), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected LoopMessageFuture(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public LoopMessageFuture(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static LoopMessageFuture static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new LoopMessageFuture(obj.NativeHandle);
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


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  System.IntPtr efl_loop_message_future_data_get(System.IntPtr obj);
   /// <summary>No description supplied.</summary>
   /// <returns>No description supplied.</returns>
   virtual public  System.IntPtr GetData() {
       var _ret_var = efl_loop_message_future_data_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern  void efl_loop_message_future_data_set(System.IntPtr obj,    System.IntPtr data);
   /// <summary>No description supplied.</summary>
   /// <param name="data">No description supplied.</param>
   /// <returns></returns>
   virtual public  void SetData(  System.IntPtr data) {
                         efl_loop_message_future_data_set((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  data);
      Eina.Error.RaiseIfUnhandledException();
                   }
   /// <summary>No description supplied.</summary>
   public  System.IntPtr Data {
      get { return GetData(); }
      set { SetData( value); }
   }
}
public class LoopMessageFutureNativeInherit : Efl.LoopMessageNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_loop_message_future_data_get_static_delegate = new efl_loop_message_future_data_get_delegate(data_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_loop_message_future_data_get"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_message_future_data_get_static_delegate)});
      efl_loop_message_future_data_set_static_delegate = new efl_loop_message_future_data_set_delegate(data_set);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_loop_message_future_data_set"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_message_future_data_set_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.LoopMessageFuture.efl_loop_message_future_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.LoopMessageFuture.efl_loop_message_future_class_get();
   }


    private delegate  System.IntPtr efl_loop_message_future_data_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  System.IntPtr efl_loop_message_future_data_get(System.IntPtr obj);
    private static  System.IntPtr data_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_loop_message_future_data_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                   System.IntPtr _ret_var = default( System.IntPtr);
         try {
            _ret_var = ((LoopMessageFuture)wrapper).GetData();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_loop_message_future_data_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_loop_message_future_data_get_delegate efl_loop_message_future_data_get_static_delegate;


    private delegate  void efl_loop_message_future_data_set_delegate(System.IntPtr obj, System.IntPtr pd,    System.IntPtr data);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern  void efl_loop_message_future_data_set(System.IntPtr obj,    System.IntPtr data);
    private static  void data_set(System.IntPtr obj, System.IntPtr pd,   System.IntPtr data)
   {
      Eina.Log.Debug("function efl_loop_message_future_data_set was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                    
         try {
            ((LoopMessageFuture)wrapper).SetData( data);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                        } else {
         efl_loop_message_future_data_set(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  data);
      }
   }
   private efl_loop_message_future_data_set_delegate efl_loop_message_future_data_set_static_delegate;
}
} 
