#define EFL_BETA
#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

/// <summary>Efl observable class</summary>
/// <remarks>This is a <b>BETA</b> class. It can be modified or removed in the future. Do not use it for product development.</remarks>
[Efl.Observable.NativeMethods]
[Efl.Eo.BindingEntity]
public class Observable : Efl.Object
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Observable))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_observable_class_get();
    /// <summary>Initializes a new instance of the <see cref="Observable"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public Observable(Efl.Object parent= null
            ) : base(efl_observable_class_get(), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    protected Observable(ConstructingHandle ch) : base(ch)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Observable"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    protected Observable(Efl.Eo.Globals.WrappingHandle wh) : base(wh)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Observable"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Observable(IntPtr baseKlass, Efl.Object parent) : base(baseKlass, parent)
    {
    }

    /// <summary>Add an observer to a group of observers.
    /// Note: Observers that observe this observable are grouped by the <c>key</c> and an observer can belong to multiple groups at the same time.</summary>
    /// <param name="key">A key to classify observer groups</param>
    /// <param name="obs">An observer object</param>
    virtual public void AddObserver(System.String key, Efl.IObserver obs) {
                                                         Efl.Observable.NativeMethods.efl_observable_observer_add_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),key, obs);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Delete an observer from a group of observers.
    /// See also <see cref="Efl.Observable.AddObserver"/>.</summary>
    /// <param name="key">A key to classify observer groups</param>
    /// <param name="obs">An observer object</param>
    virtual public void DelObserver(System.String key, Efl.IObserver obs) {
                                                         Efl.Observable.NativeMethods.efl_observable_observer_del_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),key, obs);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Clear an observer from all groups of observers.</summary>
    /// <param name="obs">An observer object</param>
    virtual public void ObserverClean(Efl.IObserver obs) {
                                 Efl.Observable.NativeMethods.efl_observable_observer_clean_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),obs);
        Eina.Error.RaiseIfUnhandledException();
                         }
    /// <summary>Return a new iterator associated with a group of observers.</summary>
    /// <param name="key">A key to classify observer groups</param>
    /// <returns>Iterator for observers group</returns>
    virtual public Eina.Iterator<Efl.IObserver> NewObserversIterator(System.String key) {
                                 var _ret_var = Efl.Observable.NativeMethods.efl_observable_observers_iterator_new_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),key);
        Eina.Error.RaiseIfUnhandledException();
                        return new Eina.Iterator<Efl.IObserver>(_ret_var, true);
 }
    /// <summary>Update all observers in a group by calling their update() method.</summary>
    /// <param name="key">A key to classify observer groups</param>
    /// <param name="data">Required data to update observer</param>
    virtual public void UpdateObservers(System.String key, System.IntPtr data) {
                                                         Efl.Observable.NativeMethods.efl_observable_observers_update_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)),key, data);
        Eina.Error.RaiseIfUnhandledException();
                                         }
    /// <summary>Return a new iterator associated to this observable.</summary>
    /// <returns>Iterator for observer</returns>
    virtual public Eina.Iterator<Efl.ObservableTuple> NewIteratorTuple() {
         var _ret_var = Efl.Observable.NativeMethods.efl_observable_iterator_tuple_new_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : Efl.Eo.Globals.efl_super(this.NativeHandle, this.NativeClass)));
        Eina.Error.RaiseIfUnhandledException();
        return new Eina.Iterator<Efl.ObservableTuple>(_ret_var, true);
 }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.Observable.efl_observable_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Object.NativeMethods
    {
        private static Efl.Eo.NativeModule Module = new Efl.Eo.NativeModule(    efl.Libs.Efl);
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            var methods = Efl.Eo.Globals.GetUserMethods(type);

            if (efl_observable_observer_add_static_delegate == null)
            {
                efl_observable_observer_add_static_delegate = new efl_observable_observer_add_delegate(observer_add);
            }

            if (methods.FirstOrDefault(m => m.Name == "AddObserver") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_observable_observer_add"), func = Marshal.GetFunctionPointerForDelegate(efl_observable_observer_add_static_delegate) });
            }

            if (efl_observable_observer_del_static_delegate == null)
            {
                efl_observable_observer_del_static_delegate = new efl_observable_observer_del_delegate(observer_del);
            }

            if (methods.FirstOrDefault(m => m.Name == "DelObserver") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_observable_observer_del"), func = Marshal.GetFunctionPointerForDelegate(efl_observable_observer_del_static_delegate) });
            }

            if (efl_observable_observer_clean_static_delegate == null)
            {
                efl_observable_observer_clean_static_delegate = new efl_observable_observer_clean_delegate(observer_clean);
            }

            if (methods.FirstOrDefault(m => m.Name == "ObserverClean") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_observable_observer_clean"), func = Marshal.GetFunctionPointerForDelegate(efl_observable_observer_clean_static_delegate) });
            }

            if (efl_observable_observers_iterator_new_static_delegate == null)
            {
                efl_observable_observers_iterator_new_static_delegate = new efl_observable_observers_iterator_new_delegate(observers_iterator_new);
            }

            if (methods.FirstOrDefault(m => m.Name == "NewObserversIterator") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_observable_observers_iterator_new"), func = Marshal.GetFunctionPointerForDelegate(efl_observable_observers_iterator_new_static_delegate) });
            }

            if (efl_observable_observers_update_static_delegate == null)
            {
                efl_observable_observers_update_static_delegate = new efl_observable_observers_update_delegate(observers_update);
            }

            if (methods.FirstOrDefault(m => m.Name == "UpdateObservers") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_observable_observers_update"), func = Marshal.GetFunctionPointerForDelegate(efl_observable_observers_update_static_delegate) });
            }

            if (efl_observable_iterator_tuple_new_static_delegate == null)
            {
                efl_observable_iterator_tuple_new_static_delegate = new efl_observable_iterator_tuple_new_delegate(iterator_tuple_new);
            }

            if (methods.FirstOrDefault(m => m.Name == "NewIteratorTuple") != null)
            {
                descs.Add(new Efl_Op_Description() {api_func = Efl.Eo.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_observable_iterator_tuple_new"), func = Marshal.GetFunctionPointerForDelegate(efl_observable_iterator_tuple_new_static_delegate) });
            }

            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Observable.efl_observable_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_observable_observer_add_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.IObserver obs);

        
        public delegate void efl_observable_observer_add_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.IObserver obs);

        public static Efl.Eo.FunctionWrapper<efl_observable_observer_add_api_delegate> efl_observable_observer_add_ptr = new Efl.Eo.FunctionWrapper<efl_observable_observer_add_api_delegate>(Module, "efl_observable_observer_add");

        private static void observer_add(System.IntPtr obj, System.IntPtr pd, System.String key, Efl.IObserver obs)
        {
            Eina.Log.Debug("function efl_observable_observer_add was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Observable)ws.Target).AddObserver(key, obs);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_observable_observer_add_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), key, obs);
            }
        }

        private static efl_observable_observer_add_delegate efl_observable_observer_add_static_delegate;

        
        private delegate void efl_observable_observer_del_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.IObserver obs);

        
        public delegate void efl_observable_observer_del_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.IObserver obs);

        public static Efl.Eo.FunctionWrapper<efl_observable_observer_del_api_delegate> efl_observable_observer_del_ptr = new Efl.Eo.FunctionWrapper<efl_observable_observer_del_api_delegate>(Module, "efl_observable_observer_del");

        private static void observer_del(System.IntPtr obj, System.IntPtr pd, System.String key, Efl.IObserver obs)
        {
            Eina.Log.Debug("function efl_observable_observer_del was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Observable)ws.Target).DelObserver(key, obs);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_observable_observer_del_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), key, obs);
            }
        }

        private static efl_observable_observer_del_delegate efl_observable_observer_del_static_delegate;

        
        private delegate void efl_observable_observer_clean_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.IObserver obs);

        
        public delegate void efl_observable_observer_clean_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.MarshalEo<Efl.Eo.NonOwnTag>))] Efl.IObserver obs);

        public static Efl.Eo.FunctionWrapper<efl_observable_observer_clean_api_delegate> efl_observable_observer_clean_ptr = new Efl.Eo.FunctionWrapper<efl_observable_observer_clean_api_delegate>(Module, "efl_observable_observer_clean");

        private static void observer_clean(System.IntPtr obj, System.IntPtr pd, Efl.IObserver obs)
        {
            Eina.Log.Debug("function efl_observable_observer_clean was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    
                try
                {
                    ((Observable)ws.Target).ObserverClean(obs);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                        
            }
            else
            {
                efl_observable_observer_clean_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), obs);
            }
        }

        private static efl_observable_observer_clean_delegate efl_observable_observer_clean_static_delegate;

        
        private delegate System.IntPtr efl_observable_observers_iterator_new_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key);

        
        public delegate System.IntPtr efl_observable_observers_iterator_new_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key);

        public static Efl.Eo.FunctionWrapper<efl_observable_observers_iterator_new_api_delegate> efl_observable_observers_iterator_new_ptr = new Efl.Eo.FunctionWrapper<efl_observable_observers_iterator_new_api_delegate>(Module, "efl_observable_observers_iterator_new");

        private static System.IntPtr observers_iterator_new(System.IntPtr obj, System.IntPtr pd, System.String key)
        {
            Eina.Log.Debug("function efl_observable_observers_iterator_new was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                    Eina.Iterator<Efl.IObserver> _ret_var = default(Eina.Iterator<Efl.IObserver>);
                try
                {
                    _ret_var = ((Observable)ws.Target).NewObserversIterator(key);
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
                return efl_observable_observers_iterator_new_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), key);
            }
        }

        private static efl_observable_observers_iterator_new_delegate efl_observable_observers_iterator_new_static_delegate;

        
        private delegate void efl_observable_observers_update_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key,  System.IntPtr data);

        
        public delegate void efl_observable_observers_update_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(Efl.Eo.StringKeepOwnershipMarshaler))] System.String key,  System.IntPtr data);

        public static Efl.Eo.FunctionWrapper<efl_observable_observers_update_api_delegate> efl_observable_observers_update_ptr = new Efl.Eo.FunctionWrapper<efl_observable_observers_update_api_delegate>(Module, "efl_observable_observers_update");

        private static void observers_update(System.IntPtr obj, System.IntPtr pd, System.String key, System.IntPtr data)
        {
            Eina.Log.Debug("function efl_observable_observers_update was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                                                            
                try
                {
                    ((Observable)ws.Target).UpdateObservers(key, data);
                }
                catch (Exception e)
                {
                    Eina.Log.Warning($"Callback error: {e.ToString()}");
                    Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                }

                                        
            }
            else
            {
                efl_observable_observers_update_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)), key, data);
            }
        }

        private static efl_observable_observers_update_delegate efl_observable_observers_update_static_delegate;

        
        private delegate System.IntPtr efl_observable_iterator_tuple_new_delegate(System.IntPtr obj, System.IntPtr pd);

        
        public delegate System.IntPtr efl_observable_iterator_tuple_new_api_delegate(System.IntPtr obj);

        public static Efl.Eo.FunctionWrapper<efl_observable_iterator_tuple_new_api_delegate> efl_observable_iterator_tuple_new_ptr = new Efl.Eo.FunctionWrapper<efl_observable_iterator_tuple_new_api_delegate>(Module, "efl_observable_iterator_tuple_new");

        private static System.IntPtr iterator_tuple_new(System.IntPtr obj, System.IntPtr pd)
        {
            Eina.Log.Debug("function efl_observable_iterator_tuple_new was called");
            var ws = Efl.Eo.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
            Eina.Iterator<Efl.ObservableTuple> _ret_var = default(Eina.Iterator<Efl.ObservableTuple>);
                try
                {
                    _ret_var = ((Observable)ws.Target).NewIteratorTuple();
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
                return efl_observable_iterator_tuple_new_ptr.Value.Delegate(Efl.Eo.Globals.efl_super(obj, Efl.Eo.Globals.efl_class_get(obj)));
            }
        }

        private static efl_observable_iterator_tuple_new_delegate efl_observable_iterator_tuple_new_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

#if EFL_BETA
#pragma warning disable CS1591
public static class EflObservable_ExtensionMethods {
}
#pragma warning restore CS1591
#endif
namespace Efl {

/// <summary>This type describes an observable touple</summary>
[StructLayout(LayoutKind.Sequential)]
[Efl.Eo.BindingEntity]
public struct ObservableTuple
{
    /// <summary>Touple key</summary>
    public System.String Key;
    /// <summary>Touple data</summary>
    public Eina.Iterator<Efl.IObserver> Data;
    /// <summary>Constructor for ObservableTuple.</summary>
    /// <param name="Key">Touple key</param>;
    /// <param name="Data">Touple data</param>;
    public ObservableTuple(
        System.String Key = default(System.String),
        Eina.Iterator<Efl.IObserver> Data = default(Eina.Iterator<Efl.IObserver>)    )
    {
        this.Key = Key;
        this.Data = Data;
    }

    /// <summary>Implicit conversion to the managed representation from a native pointer.</summary>
    /// <param name="ptr">Native pointer to be converted.</param>
    public static implicit operator ObservableTuple(IntPtr ptr)
    {
        var tmp = (ObservableTuple.NativeStruct)Marshal.PtrToStructure(ptr, typeof(ObservableTuple.NativeStruct));
        return tmp;
    }

    #pragma warning disable CS1591

    /// <summary>Internal wrapper for struct ObservableTuple.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeStruct
    {
        /// <summary>Internal wrapper for field Key</summary>
        public System.IntPtr Key;
        
        public System.IntPtr Data;
        /// <summary>Implicit conversion to the internal/marshalling representation.</summary>
        public static implicit operator ObservableTuple.NativeStruct(ObservableTuple _external_struct)
        {
            var _internal_struct = new ObservableTuple.NativeStruct();
            _internal_struct.Key = Eina.MemoryNative.StrDup(_external_struct.Key);
            _internal_struct.Data = _external_struct.Data.Handle;
            return _internal_struct;
        }

        /// <summary>Implicit conversion to the managed representation.</summary>
        public static implicit operator ObservableTuple(ObservableTuple.NativeStruct _internal_struct)
        {
            var _external_struct = new ObservableTuple();
            _external_struct.Key = Eina.StringConversion.NativeUtf8ToManagedString(_internal_struct.Key);
            _external_struct.Data = new Eina.Iterator<Efl.IObserver>(_internal_struct.Data, false);
            return _external_struct;
        }

    }

    #pragma warning restore CS1591

}

}

