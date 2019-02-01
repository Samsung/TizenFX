#pragma warning disable 1591

using System;
using System.Runtime.InteropServices;

using static eldbus.EldbusConnectionNativeFunctions;

namespace eldbus {


public static class EldbusConnectionNativeFunctions
{
    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_connection_get(eldbus.Connection.Type type);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_private_connection_get(eldbus.Connection.Type type);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_address_connection_get(string address);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_private_address_connection_get(string address);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_connection_ref(IntPtr conn);

    [DllImport(efl.Libs.Eldbus)] public static extern void
        eldbus_connection_unref(IntPtr conn);

    [DllImport(efl.Libs.Eldbus)] public static extern void
        eldbus_connection_free_cb_add(IntPtr conn, IntPtr cb, IntPtr data);

    [DllImport(efl.Libs.Eldbus)] public static extern void
        eldbus_connection_free_cb_del(IntPtr conn, IntPtr cb, IntPtr data);

    [DllImport(efl.Libs.Eldbus)] public static extern void
        eldbus_connection_data_set(IntPtr conn, IntPtr key, IntPtr data);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_connection_data_get(IntPtr conn, IntPtr key);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_connection_data_del(IntPtr conn, IntPtr key);

    [DllImport(efl.Libs.Eldbus)] public static extern void
        eldbus_connection_event_callback_add(IntPtr conn, int type, IntPtr cb, IntPtr cb_data);

    [DllImport(efl.Libs.Eldbus)] public static extern void
        eldbus_connection_event_callback_del(IntPtr conn, int type, IntPtr cb, IntPtr cb_data);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_connection_send(IntPtr conn, IntPtr msg, IntPtr cb, IntPtr cb_data, double timeout);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_connection_unique_name_get(IntPtr conn);

    // FreeDesktop.Org Methods

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_name_request(IntPtr conn, string bus, uint flags, IntPtr cb, IntPtr cb_data);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_name_release(IntPtr conn, string bus, IntPtr cb, IntPtr cb_data);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_name_owner_get(IntPtr conn, string bus, IntPtr cb, IntPtr cb_data);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_name_owner_has(IntPtr conn, string bus, IntPtr cb, IntPtr cb_data);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_names_list(IntPtr conn, IntPtr cb, IntPtr cb_data);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_names_activatable_list(IntPtr conn, IntPtr cb, IntPtr cb_data);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_hello(IntPtr conn, IntPtr cb, IntPtr cb_data);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_name_start(IntPtr conn, string bus, uint flags, IntPtr cb, IntPtr cb_data);

//     typedef void (*Eldbus_Name_Owner_Changed_Cb)(void *data, const char *bus, const char *old_id, const char *new_id);
//     [DllImport(efl.Libs.Eldbus)] public static extern void
//         eldbus_name_owner_changed_callback_add(IntPtr conn, string bus, Eldbus_Name_Owner_Changed_Cb cb, IntPtr cb_data, [MarshalAs(UnmanagedType.U1)] bool allow_initial_call);
//     [DllImport(efl.Libs.Eldbus)] public static extern void
//         eldbus_name_owner_changed_callback_del(IntPtr conn, string bus, Eldbus_Name_Owner_Changed_Cb cb, IntPtr cb_data);
}

public class Connection : IDisposable
{
    public enum Type
    {
        Unknown = 0, // sentinel, not a real type
        Session,
        System,
        Starter,
        Address,
        Last         // sentinel, not a real type
    };

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

    public Connection(IntPtr handle, bool own)
    {
        InitNew(handle, own);
    }


    public Connection(eldbus.Connection.Type type)
    {
        InitNew(eldbus_connection_get(type), true);
    }

    public Connection(string address)
    {
        InitNew(eldbus_address_connection_get(address), true);
    }

    public static eldbus.Connection GetPrivate(eldbus.Connection.Type type)
    {
        return new eldbus.Connection(eldbus_private_connection_get(type), true);
    }

    public static eldbus.Connection GetPrivate(string address)
    {
        return new eldbus.Connection(eldbus_private_address_connection_get(address), true);
    }


    ~Connection()
    {
        Dispose(false);
    }

    protected virtual void Dispose(bool disposing)
    {
        IntPtr h = Handle;
        Handle = IntPtr.Zero;
        if (h == IntPtr.Zero)
            return;

        if (Own)
            eldbus_connection_unref(h);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
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

    public eldbus.Pending Send(eldbus.Message msg, eldbus.MessageDelegate dlgt = null, double timeout = -1)
    {
        CheckHandle();

        if (msg == null)
            throw new ArgumentNullException("msg");

        IntPtr cb_wrapper = (dlgt == null ? IntPtr.Zero : eldbus.Common.GetMessageCbWrapperPtr());
        IntPtr cb_data = (dlgt == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(dlgt));

        var pending_hdl = eldbus_connection_send(Handle, msg.Handle, cb_wrapper, cb_data, timeout);

        if(pending_hdl == IntPtr.Zero)
            throw new SEHException("Eldbus: could not get `Pending' object from eldbus_connection_send");

        msg.Ref();

        return new eldbus.Pending(pending_hdl, false);
    }

    public string GetUniqueName()
    {
        CheckHandle();
        var ptr = eldbus_connection_unique_name_get(Handle);
        if (ptr == IntPtr.Zero)
            return null;
        return Marshal.PtrToStringAuto(ptr);
    }

    public eldbus.Pending NameRequest(string bus, uint flags, eldbus.MessageDelegate dlgt = null)
    {
        CheckHandle();

        if (bus == null)
            throw new ArgumentNullException("bus");

        IntPtr cb_wrapper = (dlgt == null ? IntPtr.Zero : eldbus.Common.GetMessageCbWrapperPtr());
        IntPtr cb_data = (dlgt == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(dlgt));

        var pending_hdl = eldbus_name_request(Handle, bus, flags, cb_wrapper, cb_data);

        if(pending_hdl == IntPtr.Zero)
            throw new SEHException("Eldbus: could not get `Pending' object from eldbus_name_request");

        return new eldbus.Pending(pending_hdl, false);
    }

    public eldbus.Pending NameRelease(string bus, eldbus.MessageDelegate dlgt = null)
    {
        CheckHandle();

        if (bus == null)
            throw new ArgumentNullException("bus");

        IntPtr cb_wrapper = (dlgt == null ? IntPtr.Zero : eldbus.Common.GetMessageCbWrapperPtr());
        IntPtr cb_data = (dlgt == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(dlgt));

        var pending_hdl = eldbus_name_release(Handle, bus, cb_wrapper, cb_data);

        if(pending_hdl == IntPtr.Zero)
            throw new SEHException("Eldbus: could not get `Pending' object from eldbus_name_release");

        return new eldbus.Pending(pending_hdl, false);
    }

    public eldbus.Pending GetNameOwner(string bus, eldbus.MessageDelegate dlgt = null)
    {
        CheckHandle();

        if (bus == null)
            throw new ArgumentNullException("bus");

        IntPtr cb_wrapper = (dlgt == null ? IntPtr.Zero : eldbus.Common.GetMessageCbWrapperPtr());
        IntPtr cb_data = (dlgt == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(dlgt));

        var pending_hdl = eldbus_name_owner_get(Handle, bus, cb_wrapper, cb_data);

        if(pending_hdl == IntPtr.Zero)
            throw new SEHException("Eldbus: could not get `Pending' object from eldbus_name_owner_get");

        return new eldbus.Pending(pending_hdl, false);
    }

    public eldbus.Pending HasNameOwner(string bus, eldbus.MessageDelegate dlgt = null)
    {
        CheckHandle();

        if (bus == null)
            throw new ArgumentNullException("bus");

        IntPtr cb_wrapper = (dlgt == null ? IntPtr.Zero : eldbus.Common.GetMessageCbWrapperPtr());
        IntPtr cb_data = (dlgt == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(dlgt));

        var pending_hdl = eldbus_name_owner_has(Handle, bus, cb_wrapper, cb_data);

        if(pending_hdl == IntPtr.Zero)
            throw new SEHException("Eldbus: could not get `Pending' object from eldbus_name_owner_has");

        return new eldbus.Pending(pending_hdl, false);
    }

    public eldbus.Pending NameList(eldbus.MessageDelegate dlgt = null)
    {
        CheckHandle();

        IntPtr cb_wrapper = (dlgt == null ? IntPtr.Zero : eldbus.Common.GetMessageCbWrapperPtr());
        IntPtr cb_data = (dlgt == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(dlgt));

        var pending_hdl = eldbus_names_list(Handle, cb_wrapper, cb_data);

        if(pending_hdl == IntPtr.Zero)
            throw new SEHException("Eldbus: could not get `Pending' object from eldbus_names_list");

        return new eldbus.Pending(pending_hdl, false);
    }

    public eldbus.Pending ActivatableList(eldbus.MessageDelegate dlgt = null)
    {
        CheckHandle();

        IntPtr cb_wrapper = (dlgt == null ? IntPtr.Zero : eldbus.Common.GetMessageCbWrapperPtr());
        IntPtr cb_data = (dlgt == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(dlgt));

        var pending_hdl = eldbus_names_activatable_list(Handle, cb_wrapper, cb_data);

        if(pending_hdl == IntPtr.Zero)
            throw new SEHException("Eldbus: could not get `Pending' object from eldbus_names_activatable_list");

        return new eldbus.Pending(pending_hdl, false);
    }

    public eldbus.Pending Hello(eldbus.MessageDelegate dlgt = null)
    {
        CheckHandle();

        IntPtr cb_wrapper = (dlgt == null ? IntPtr.Zero : eldbus.Common.GetMessageCbWrapperPtr());
        IntPtr cb_data = (dlgt == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(dlgt));

        var pending_hdl = eldbus_hello(Handle, cb_wrapper, cb_data);

        if(pending_hdl == IntPtr.Zero)
            throw new SEHException("Eldbus: could not get `Pending' object from eldbus_hello");

        return new eldbus.Pending(pending_hdl, false);
    }

    public eldbus.Pending NameStart(string bus, uint flags, eldbus.MessageDelegate dlgt = null)
    {
        CheckHandle();

        if (bus == null)
            throw new ArgumentNullException("bus");

        IntPtr cb_wrapper = (dlgt == null ? IntPtr.Zero : eldbus.Common.GetMessageCbWrapperPtr());
        IntPtr cb_data = (dlgt == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(dlgt));

        var pending_hdl = eldbus_name_start(Handle, bus, flags, cb_wrapper, cb_data);

        if(pending_hdl == IntPtr.Zero)
            throw new SEHException("Eldbus: could not get `Pending' object from eldbus_name_start");

        return new eldbus.Pending(pending_hdl, false);
    }

}

}
