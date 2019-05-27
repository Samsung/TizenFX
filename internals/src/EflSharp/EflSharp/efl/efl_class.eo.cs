#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

/// <summary>Abstract Efl class
/// (Since EFL 1.22)</summary>
[Efl.Class.NativeMethods]
public abstract class Class :  Efl.Eo.IWrapper, IDisposable
{
    ///<summary>Pointer to the native class description.</summary>
    public virtual System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(Class))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    protected bool inherited;
    protected  System.IntPtr handle;
    ///<summary>Pointer to the native instance.</summary>
    public System.IntPtr NativeHandle
    {
        get { return handle; }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Eo)] internal static extern System.IntPtr
        efl_class_class_get();
    /// <summary>Initializes a new instance of the <see cref="Class"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public Class(Efl.Object parent= null
            ) : this(efl_class_class_get(), typeof(Class), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="Class"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected Class(System.IntPtr raw)
    {
        handle = raw;
    }

    [Efl.Eo.PrivateNativeClass]
    private class ClassRealized : Class
    {
        private ClassRealized(IntPtr ptr) : base(ptr)
        {
        }
    }
    /// <summary>Initializes a new instance of the <see cref="Class"/> class.
    /// Internal usage: Constructor to actually call the native library constructors. C# subclasses
    /// must use the public constructor only.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected Class(IntPtr baseKlass, System.Type managedType, Efl.Object parent)
    {
        inherited = ((object)this).GetType() != managedType;
        IntPtr actual_klass = baseKlass;
        if (inherited)
        {
            actual_klass = Efl.Eo.ClassRegister.GetInheritKlassOrRegister(baseKlass, ((object)this).GetType());
        }

        handle = Efl.Eo.Globals.instantiate_start(actual_klass, parent);
        if (inherited)
        {
            Efl.Eo.Globals.PrivateDataSet(this);
        }
    }

    /// <summary>Finishes instantiating this object.
    /// Internal usage by generated code.</summary>
    protected void FinishInstantiation()
    {
        handle = Efl.Eo.Globals.instantiate_end(handle);
        Eina.Error.RaiseIfUnhandledException();
    }

    ///<summary>Destructor.</summary>
    ~Class()
    {
        Dispose(false);
    }

    ///<summary>Releases the underlying native instance.</summary>
    protected virtual void Dispose(bool disposing)
    {
        if (handle != System.IntPtr.Zero)
        {
            IntPtr h = handle;
            handle = IntPtr.Zero;

            IntPtr gcHandlePtr = IntPtr.Zero;
            if (disposing)
            {
                Efl.Eo.Globals.efl_mono_native_dispose(h, gcHandlePtr);
            }
            else
            {
                Monitor.Enter(Efl.All.InitLock);
                if (Efl.All.MainLoopInitialized)
                {
                    Efl.Eo.Globals.efl_mono_thread_safe_native_dispose(h, gcHandlePtr);
                }

                Monitor.Exit(Efl.All.InitLock);
            }
        }

    }

    ///<summary>Releases the underlying native instance.</summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>Verifies if the given object is equal to this one.</summary>
    /// <param name="instance">The object to compare to.</param>
    /// <returns>True if both objects point to the same native object.</returns>
    public override bool Equals(object instance)
    {
        var other = instance as Efl.Object;
        if (other == null)
        {
            return false;
        }
        return this.NativeHandle == other.NativeHandle;
    }

    /// <summary>Gets the hash code for this object based on the native pointer it points to.</summary>
    /// <returns>The value of the pointer, to be used as the hash code of this object.</returns>
    public override int GetHashCode()
    {
        return this.NativeHandle.ToInt32();
    }

    /// <summary>Turns the native pointer into a string representation.</summary>
    /// <returns>A string with the type and the native pointer for this object.</returns>
    public override String ToString()
    {
        return $"{this.GetType().Name}@[{this.NativeHandle.ToInt32():x}]";
    }

    private static IntPtr GetEflClassStatic()
    {
        return Efl.Class.efl_class_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public class NativeMethods  : Efl.Eo.NativeClass
    {
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.Class.efl_class_class_get();
        }

        #pragma warning disable CA1707, SA1300, SA1600

        #pragma warning restore CA1707, SA1300, SA1600

}
}
}

