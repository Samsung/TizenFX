#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
namespace Efl {

///<summary>Event argument wrapper for event <see cref="Efl.LoopMessage.MessageEvt"/>.</summary>
public class LoopMessageMessageEvt_Args : EventArgs {
    ///<summary>Actual event payload.</summary>
    public Efl.LoopMessage arg { get; set; }
}
/// <summary>Base message payload object class. Inherit this and extend for specific message types.</summary>
[Efl.LoopMessage.NativeMethods]
public class LoopMessage : Efl.Object
{
    ///<summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(LoopMessage))
            {
                return GetEflClassStatic();
            }
            else
            {
                return Efl.Eo.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    [System.Runtime.InteropServices.DllImport(efl.Libs.Ecore)] internal static extern System.IntPtr
        efl_loop_message_class_get();
    /// <summary>Initializes a new instance of the <see cref="LoopMessage"/> class.</summary>
    /// <param name="parent">Parent instance.</param>
    public LoopMessage(Efl.Object parent= null
            ) : base(efl_loop_message_class_get(), typeof(LoopMessage), parent)
    {
        FinishInstantiation();
    }

    /// <summary>Initializes a new instance of the <see cref="LoopMessage"/> class.
    /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="raw">The native pointer to be wrapped.</param>
    protected LoopMessage(System.IntPtr raw) : base(raw)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="LoopMessage"/> class.
    /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.</summary>
    /// <param name="baseKlass">The pointer to the base native Eo class.</param>
    /// <param name="managedType">The managed type of the public constructor that originated this call.</param>
    /// <param name="parent">The Efl.Object parent of this instance.</param>
    protected LoopMessage(IntPtr baseKlass, System.Type managedType, Efl.Object parent) : base(baseKlass, managedType, parent)
    {
    }

    /// <summary>The message payload data</summary>
    public event EventHandler<Efl.LoopMessageMessageEvt_Args> MessageEvt
    {
        add
        {
            lock (eventLock)
            {
                Efl.EventCb callerCb = (IntPtr data, ref Efl.Event.NativeStruct evt) =>
                {
                    var obj = Efl.Eo.Globals.WrapperSupervisorPtrToManaged(data).Target;
                    if (obj != null)
                    {
                        Efl.LoopMessageMessageEvt_Args args = new Efl.LoopMessageMessageEvt_Args();
                        args.arg = (Efl.Eo.Globals.CreateWrapperFor(evt.Info) as Efl.LoopMessage);
                        try
                        {
                            value?.Invoke(obj, args);
                        }
                        catch (Exception e)
                        {
                            Eina.Log.Error(e.ToString());
                            Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                        }
                    }
                };

                string key = "_EFL_LOOP_MESSAGE_EVENT_MESSAGE";
                AddNativeEventHandler(efl.Libs.Ecore, key, callerCb, value);
            }
        }

        remove
        {
            lock (eventLock)
            {
                string key = "_EFL_LOOP_MESSAGE_EVENT_MESSAGE";
                RemoveNativeEventHandler(efl.Libs.Ecore, key, value);
            }
        }
    }
    ///<summary>Method to raise event MessageEvt.</summary>
    public void OnMessageEvt(Efl.LoopMessageMessageEvt_Args e)
    {
        var key = "_EFL_LOOP_MESSAGE_EVENT_MESSAGE";
        IntPtr desc = Efl.EventDescription.GetNative(efl.Libs.Ecore, key);
        if (desc == IntPtr.Zero)
        {
            Eina.Log.Error($"Failed to get native event {key}");
            return;
        }

        IntPtr info = e.arg.NativeHandle;
        Efl.Eo.Globals.efl_event_callback_call(this.NativeHandle, desc, info);
    }
    private static IntPtr GetEflClassStatic()
    {
        return Efl.LoopMessage.efl_loop_message_class_get();
    }
    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.</summary>
    public new class NativeMethods : Efl.Object.NativeMethods
    {
        /// <summary>Gets the list of Eo operations to override.</summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        public override System.Collections.Generic.List<Efl_Op_Description> GetEoOps(System.Type type)
        {
            var descs = new System.Collections.Generic.List<Efl_Op_Description>();
            descs.AddRange(base.GetEoOps(type));
            return descs;
        }
        /// <summary>Returns the Eo class for the native methods of this class.</summary>
        /// <returns>The native class pointer.</returns>
        public override IntPtr GetEflClass()
        {
            return Efl.LoopMessage.efl_loop_message_class_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

