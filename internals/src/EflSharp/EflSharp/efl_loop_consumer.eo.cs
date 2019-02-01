#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
namespace Efl { 
/// <summary>An Efl.Loop_Consumer is a class which requires one of the parents to provide an Efl.Loop interface when performing provider_find. It will enforce this by only allowing parents which provide such an interface or <c>NULL</c>.</summary>
[LoopConsumerNativeInherit]
public class LoopConsumer : Efl.Object, Efl.Eo.IWrapper
{
   public new static System.IntPtr klass = System.IntPtr.Zero;
   public new static Efl.LoopConsumerNativeInherit nativeInherit = new Efl.LoopConsumerNativeInherit();
   ///<summary>Pointer to the native class description.</summary>
   public override System.IntPtr NativeClass {
      get {
         if (((object)this).GetType() == typeof (LoopConsumer))
            return Efl.LoopConsumerNativeInherit.GetEflClassStatic();
         else
            return Efl.Eo.Globals.klasses[((object)this).GetType()];
      }
   }
   ///<summary>Delegate for function to be called from inside the native constructor.</summary>
   public new delegate void ConstructingMethod(LoopConsumer obj);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
      efl_loop_consumer_class_get();
   ///<summary>Creates a new instance.</summary>
   ///<param name="parent">Parent instance.</param>
   ///<param name="init_cb">Delegate to call constructing methods that should be run inside the constructor.</param>
   public LoopConsumer(Efl.Object parent = null, ConstructingMethod init_cb=null) : base("LoopConsumer", efl_loop_consumer_class_get(), typeof(LoopConsumer), parent)
   {
      if (init_cb != null) {
         init_cb(this);
      }
      FinishInstantiation();
   }
   ///<summary>Internal constructor to forward the wrapper initialization to the root class.</summary>
   protected LoopConsumer(String klass_name, IntPtr base_klass, System.Type managed_type, Efl.Object parent) : base(klass_name, base_klass, managed_type, parent) {}
   ///<summary>Constructs an instance from a native pointer.</summary>
   public LoopConsumer(System.IntPtr raw) : base(raw)
   {
            register_event_proxies();
   }
   ///<summary>Casts obj into an instance of this type.</summary>
   public new static LoopConsumer static_cast(Efl.Object obj)
   {
      if (obj == null)
         throw new System.ArgumentNullException("obj");
      return new LoopConsumer(obj.NativeHandle);
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
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Loop, Efl.Eo.NonOwnTag>))] protected static extern Efl.Loop efl_loop_get(System.IntPtr obj);
   /// <summary>Gets a handle to the loop.</summary>
   /// <returns>Efl loop</returns>
   virtual public Efl.Loop GetLoop() {
       var _ret_var = efl_loop_get((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] protected static extern  Eina.Future efl_loop_future_resolved(System.IntPtr obj,    Eina.ValueNative result);
   /// <summary>Creates a new future that is already resolved to a value.
   /// This function creates a new future with an already known value, that will be resolved and dispatched by the loop scheduler as usual.
   /// 
   /// This is a helper that behaves the same as eina_future_resolved.</summary>
   /// <param name="result">The value to be delivered.
   /// Note that the value contents must survive this function scope, that is, do not use stack allocated blobs, arrays, structures or types that keep references to memory you give. Values will be automatically cleaned up using @ref eina_value_flush() once they are unused (no more future or futures returned a new value)</param>
   /// <returns>The future or <c>NULL</c> on error.</returns>
   virtual public  Eina.Future FutureResolved(  Eina.Value result) {
       var _in_result = result.GetNative();
                  var _ret_var = efl_loop_future_resolved((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  _in_result);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] protected static extern  Eina.Future efl_loop_future_rejected(System.IntPtr obj,    Eina.Error error);
   /// <summary>Creates a new future that is already rejected to a specified error using the <see cref="Efl.LoopConsumer.GetLoop"/>.
   /// This function creates a new future with an already known error, that will be resolved and dispatched by the loop scheduler as usual.
   /// 
   /// This is a helper that behaves the same as @ref eina_future_rejected.</summary>
   /// <param name="error">An Eina_Error value</param>
   /// <returns>The future or <c>NULL</c> on error.</returns>
   virtual public  Eina.Future FutureRejected(  Eina.Error error) {
                         var _ret_var = efl_loop_future_rejected((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle),  error);
      Eina.Error.RaiseIfUnhandledException();
                  return _ret_var;
 }


   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]
    protected static extern Eina.Promise efl_loop_promise_new(System.IntPtr obj);
   /// <summary>Create a new promise with the scheduler coming from the loop provided by this object.
   /// Note: You should not use eina_promise_data_set as this function rely on controlling the promise data.</summary>
   /// <returns>The new promise.</returns>
   virtual public Eina.Promise NewPromise() {
       var _ret_var = efl_loop_promise_new((inherited ? Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass) : this.NativeHandle));
      Eina.Error.RaiseIfUnhandledException();
      return _ret_var;
 }
   public System.Threading.Tasks.Task<Eina.Value> FutureResolvedAsync(  Eina.Value result, System.Threading.CancellationToken token=default(System.Threading.CancellationToken))
   {
      Eina.Future future = FutureResolved(  result);
      return Efl.Eo.Globals.WrapAsync(future, token);
   }
   public System.Threading.Tasks.Task<Eina.Value> FutureRejectedAsync(  Eina.Error error, System.Threading.CancellationToken token=default(System.Threading.CancellationToken))
   {
      Eina.Future future = FutureRejected(  error);
      return Efl.Eo.Globals.WrapAsync(future, token);
   }
   /// <summary>The loop to which this object belongs to.</summary>
   public Efl.Loop Loop {
      get { return GetLoop(); }
   }
}
public class LoopConsumerNativeInherit : Efl.ObjectNativeInherit{
   public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
   {
      var descs = new System.Collections.Generic.List<Efl_Op_Description>();
      efl_loop_get_static_delegate = new efl_loop_get_delegate(loop_get);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_loop_get"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_get_static_delegate)});
      efl_loop_future_resolved_static_delegate = new efl_loop_future_resolved_delegate(future_resolved);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_loop_future_resolved"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_future_resolved_static_delegate)});
      efl_loop_future_rejected_static_delegate = new efl_loop_future_rejected_delegate(future_rejected);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_loop_future_rejected"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_future_rejected_static_delegate)});
      efl_loop_promise_new_static_delegate = new efl_loop_promise_new_delegate(promise_new);
      descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.Globals.dlsym(Efl.Eo.Globals.RTLD_DEFAULT, "efl_loop_promise_new"), func = Marshal.GetFunctionPointerForDelegate(efl_loop_promise_new_static_delegate)});
      descs.AddRange(base.GetEoOps(type));
      return descs;
   }
   public override IntPtr GetEflClass()
   {
      return Efl.LoopConsumer.efl_loop_consumer_class_get();
   }
   public static new  IntPtr GetEflClassStatic()
   {
      return Efl.LoopConsumer.efl_loop_consumer_class_get();
   }


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Loop, Efl.Eo.NonOwnTag>))] private delegate Efl.Loop efl_loop_get_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Efl.Eo.MarshalTest<Efl.Loop, Efl.Eo.NonOwnTag>))] private static extern Efl.Loop efl_loop_get(System.IntPtr obj);
    private static Efl.Loop loop_get(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_loop_get was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Efl.Loop _ret_var = default(Efl.Loop);
         try {
            _ret_var = ((LoopConsumer)wrapper).GetLoop();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_loop_get(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_loop_get_delegate efl_loop_get_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] private delegate  Eina.Future efl_loop_future_resolved_delegate(System.IntPtr obj, System.IntPtr pd,    Eina.ValueNative result);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] private static extern  Eina.Future efl_loop_future_resolved(System.IntPtr obj,    Eina.ValueNative result);
    private static  Eina.Future future_resolved(System.IntPtr obj, System.IntPtr pd,   Eina.ValueNative result)
   {
      Eina.Log.Debug("function efl_loop_future_resolved was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
               var _in_result = new  Eina.Value(result);
                      Eina.Future _ret_var = default( Eina.Future);
         try {
            _ret_var = ((LoopConsumer)wrapper).FutureResolved( _in_result);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_loop_future_resolved(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  result);
      }
   }
   private efl_loop_future_resolved_delegate efl_loop_future_resolved_static_delegate;


   [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] private delegate  Eina.Future efl_loop_future_rejected_delegate(System.IntPtr obj, System.IntPtr pd,    Eina.Error error);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Eina.FutureMarshaler))] private static extern  Eina.Future efl_loop_future_rejected(System.IntPtr obj,    Eina.Error error);
    private static  Eina.Future future_rejected(System.IntPtr obj, System.IntPtr pd,   Eina.Error error)
   {
      Eina.Log.Debug("function efl_loop_future_rejected was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                                     Eina.Future _ret_var = default( Eina.Future);
         try {
            _ret_var = ((LoopConsumer)wrapper).FutureRejected( error);
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
                  return _ret_var;
      } else {
         return efl_loop_future_rejected(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)),  error);
      }
   }
   private efl_loop_future_rejected_delegate efl_loop_future_rejected_static_delegate;


    private delegate Eina.Promise efl_loop_promise_new_delegate(System.IntPtr obj, System.IntPtr pd);
   [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)]  private static extern Eina.Promise efl_loop_promise_new(System.IntPtr obj);
    private static Eina.Promise promise_new(System.IntPtr obj, System.IntPtr pd)
   {
      Eina.Log.Debug("function efl_loop_promise_new was called");
      Efl.Eo.IWrapper wrapper = Efl.Eo.Globals.data_get(pd);
      if(wrapper != null) {
                  Eina.Promise _ret_var = default(Eina.Promise);
         try {
            _ret_var = ((LoopConsumer)wrapper).NewPromise();
         } catch (Exception e) {
            Eina.Log.Warning($"Callback error: {e.ToString()}");
            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
         }
      return _ret_var;
      } else {
         return efl_loop_promise_new(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
      }
   }
   private efl_loop_promise_new_delegate efl_loop_promise_new_static_delegate;
}
} 
