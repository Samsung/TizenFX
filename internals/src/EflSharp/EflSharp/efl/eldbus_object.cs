
#pragma warning disable 1591

using System.Runtime.InteropServices;

using static eldbus.EldbusObjectNativeFunctions;

using IntPtr = System.IntPtr;

namespace eldbus
{

public static class EldbusObjectNativeFunctions
{
    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_object_get(IntPtr conn, string bus, string path);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_object_ref(IntPtr obj);

    [DllImport(efl.Libs.Eldbus)] public static extern void
        eldbus_object_unref(IntPtr obj);

    [DllImport(efl.Libs.Eldbus)] public static extern void
        eldbus_object_free_cb_add(IntPtr obj, IntPtr cb, IntPtr data);

    [DllImport(efl.Libs.Eldbus)] public static extern void
        eldbus_object_free_cb_del(IntPtr obj, IntPtr cb, IntPtr data);

// typedef enum
// {
//    ELDBUS_OBJECT_EVENT_IFACE_ADDED = 0, /**< a parent path must have a ObjectManager interface */
//    ELDBUS_OBJECT_EVENT_IFACE_REMOVED, /**< a parent path must have a ObjectManager interface */
//    ELDBUS_OBJECT_EVENT_PROPERTY_CHANGED, /**< a property has changes */
//    ELDBUS_OBJECT_EVENT_PROPERTY_REMOVED, /**< a property was removed */
//    ELDBUS_OBJECT_EVENT_DEL,
//    ELDBUS_OBJECT_EVENT_LAST    /**< sentinel, not a real event type */
// } Eldbus_Object_Event_Type;
//
//     [DllImport(efl.Libs.Eldbus)] public static extern void
//         eldbus_object_event_callback_add(IntPtr obj, Eldbus_Object_Event_Type type, IntPtr cb, IntPtr cb_data);
//
//     [DllImport(efl.Libs.Eldbus)] public static extern void
//         eldbus_object_event_callback_del(IntPtr obj, Eldbus_Object_Event_Type type, IntPtr cb, IntPtr cb_data);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_object_connection_get(IntPtr obj);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_object_bus_name_get(IntPtr obj);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_object_path_get(IntPtr obj);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_object_send(IntPtr obj, IntPtr msg, IntPtr cb, IntPtr cb_data, double timeout);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_object_signal_handler_add(IntPtr obj, string _interface, string member, IntPtr cb, IntPtr cb_data);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_object_method_call_new(IntPtr obj, string _interface, string member);

    // FreeDesktop.Org Methods

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_object_peer_ping(IntPtr obj, IntPtr cb, IntPtr data);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_object_peer_machine_id_get(IntPtr obj, IntPtr cb, IntPtr data);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_object_introspect(IntPtr obj, IntPtr cb, IntPtr data);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_object_managed_objects_get(IntPtr obj, IntPtr cb, IntPtr data);

//     [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
//         eldbus_object_manager_interfaces_added(IntPtr obj, Eldbus_Signal_Cb cb, IntPtr cb_data);
//
//     [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
//         eldbus_object_manager_interfaces_removed(IntPtr obj, Eldbus_Signal_Cb cb, IntPtr cb_data);
}


public class Object : System.IDisposable
{

    public IntPtr Handle {get;set;} = IntPtr.Zero;
    public bool Own {get;set;} = true;

    private void InitNew(IntPtr handle, bool own)
    {
        Handle = handle;
        Own = own;
        CheckHandle();
    }

    private void CheckHandle()
    {
        if (Handle == IntPtr.Zero)
        {
            eldbus.Common.RaiseNullHandle();
        }
    }

    public Object(IntPtr handle, bool own)
    {
        InitNew(handle, own);
    }

    public Object(eldbus.Connection conn, string bus, string path)
    {
        if (conn == null)
        {
            throw new System.ArgumentNullException("conn");
        }

        if (bus == null)
        {
            throw new System.ArgumentNullException("bus");
        }

        if (path == null)
        {
            throw new System.ArgumentNullException("path");
        }

        var handle = eldbus_object_get(conn.Handle, bus, path);

        if (handle == IntPtr.Zero)
        {
            throw new SEHException("Eldbus: could not get `Object' object from eldbus_object_get");
        }

        InitNew(handle, true);
    }

    ~Object()
    {
        Dispose(false);
    }

    protected virtual void Dispose(bool disposing)
    {
        IntPtr h = Handle;
        Handle = IntPtr.Zero;
        if (h == IntPtr.Zero)
        {
            return;
        }

        if (Own)
        {
            eldbus_object_unref(h);
        }
    }

    public void Dispose()
    {
        Dispose(true);
        System.GC.SuppressFinalize(this);
    }

    public void Free()
    {
        Dispose();
    }

    public IntPtr Release()
    {
        IntPtr h = Handle;
        Handle = IntPtr.Zero;
        return h;
    }

    public eldbus.Connection GetConnection()
    {
        CheckHandle();
        var conn = eldbus_object_connection_get(Handle);

        if (conn == IntPtr.Zero)
        {
            throw new SEHException("Eldbus: could not get `Connection' object from eldbus_object_connection_get");
        }

        return new eldbus.Connection(conn, false);
    }

    public string GetBusName()
    {
        CheckHandle();
        var ptr = eldbus_object_bus_name_get(Handle);
        return Eina.StringConversion.NativeUtf8ToManagedString(ptr);
    }

    public string GetPath()
    {
        CheckHandle();
        var ptr = eldbus_object_path_get(Handle);
        return Eina.StringConversion.NativeUtf8ToManagedString(ptr);
    }

    public void Ref()
    {
        CheckHandle();
        eldbus_object_ref(Handle);
    }

    public void Unref()
    {
        CheckHandle();
        eldbus_object_unref(Handle);
    }

    public eldbus.Pending Send(eldbus.Message msg, eldbus.MessageDelegate dlgt = null, double timeout = -1)
    {
        CheckHandle();

        if (msg == null)
        {
            throw new System.ArgumentNullException("msg");
        }

        IntPtr cb_wrapper = dlgt == null ? IntPtr.Zero : eldbus.Common.GetMessageCbWrapperPtr();
        IntPtr cb_data = dlgt == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(dlgt);

        var pending_hdl = eldbus_object_send(Handle, msg.Handle, cb_wrapper, cb_data, timeout);

        if (pending_hdl == IntPtr.Zero)
        {
            throw new SEHException("Eldbus: could not get `Pending' object from eldbus_object_send");
        }

        return new eldbus.Pending(pending_hdl, false);
    }

    public eldbus.Message NewMethodCall(string _interface, string member)
    {
        CheckHandle();

        var hdl = eldbus_object_method_call_new(Handle, _interface, member);

        if (hdl == IntPtr.Zero)
        {
            throw new SEHException("Eldbus: could not get `Message' object from eldbus_object_method_call_new");
        }

        return new eldbus.Message(hdl, false);
    }

    public eldbus.Pending PeerPing(eldbus.MessageDelegate dlgt = null)
    {
        CheckHandle();

        IntPtr cb_wrapper = dlgt == null ? IntPtr.Zero : eldbus.Common.GetMessageCbWrapperPtr();
        IntPtr cb_data = dlgt == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(dlgt);

        var pending_hdl = eldbus_object_peer_ping(Handle, cb_wrapper, cb_data);

        if (pending_hdl == IntPtr.Zero)
        {
            throw new SEHException("Eldbus: could not get `Pending' object from eldbus_object_peer_ping");
        }

        return new eldbus.Pending(pending_hdl, false);
    }

    public eldbus.Pending GetPeerMachineId(eldbus.MessageDelegate dlgt = null)
    {
        CheckHandle();

        IntPtr cb_wrapper = dlgt == null ? IntPtr.Zero : eldbus.Common.GetMessageCbWrapperPtr();
        IntPtr cb_data = dlgt == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(dlgt);

        var pending_hdl = eldbus_object_peer_machine_id_get(Handle, cb_wrapper, cb_data);

        if (pending_hdl == IntPtr.Zero)
        {
            throw new SEHException("Eldbus: could not get `Pending' object from eldbus_object_peer_machine_id_get");
        }

        return new eldbus.Pending(pending_hdl, false);
    }

    public eldbus.Pending Introspect(eldbus.MessageDelegate dlgt = null)
    {
        CheckHandle();

        IntPtr cb_wrapper = dlgt == null ? IntPtr.Zero : eldbus.Common.GetMessageCbWrapperPtr();
        IntPtr cb_data = dlgt == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(dlgt);

        var pending_hdl = eldbus_object_introspect(Handle, cb_wrapper, cb_data);

        if (pending_hdl == IntPtr.Zero)
        {
            throw new SEHException("Eldbus: could not get `Pending' object from eldbus_object_introspect");
        }

        return new eldbus.Pending(pending_hdl, false);
    }

    public eldbus.Pending GetManagedObjects(eldbus.MessageDelegate dlgt = null)
    {
        CheckHandle();

        IntPtr cb_wrapper = dlgt == null ? IntPtr.Zero : eldbus.Common.GetMessageCbWrapperPtr();
        IntPtr cb_data = dlgt == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(dlgt);

        var pending_hdl = eldbus_object_managed_objects_get(Handle, cb_wrapper, cb_data);

        if (pending_hdl == IntPtr.Zero)
        {
            throw new SEHException("Eldbus: could not get `Pending' object from eldbus_object_managed_objects_get");
        }

        return new eldbus.Pending(pending_hdl, false);
    }
}

}
