#pragma warning disable 1591

using System;
using System.Runtime.InteropServices;

using static eldbus.EldbusProxyNativeFunctions;

namespace eldbus {

public static class EldbusProxyNativeFunctions
{
    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_proxy_get(IntPtr obj, string _interface);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_proxy_ref(IntPtr proxy);

    [DllImport(efl.Libs.Eldbus)] public static extern void
        eldbus_proxy_unref(IntPtr proxy);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_proxy_object_get(IntPtr proxy);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_proxy_interface_get(IntPtr proxy);

    [DllImport(efl.Libs.Eldbus)] public static extern void
        eldbus_proxy_data_set(IntPtr proxy, string key, IntPtr data);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_proxy_data_get(IntPtr proxy, string key);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_proxy_data_del(IntPtr proxy, string key);

    [DllImport(efl.Libs.Eldbus)] public static extern void
        eldbus_proxy_free_cb_add(IntPtr proxy, IntPtr cb, IntPtr data);

    [DllImport(efl.Libs.Eldbus)] public static extern void
        eldbus_proxy_free_cb_del(IntPtr proxy, IntPtr cb, IntPtr data);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_proxy_method_call_new(IntPtr proxy, string member);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_proxy_send(IntPtr proxy, IntPtr msg, IntPtr cb, IntPtr cb_data, double timeout);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_proxy_send_and_block(IntPtr proxy, IntPtr msg, double timeout);

//     [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
//         eldbus_proxy_call(IntPtr proxy, string member, IntPtr cb, IntPtr cb_data, double timeout, string signature, ...);
//
//     [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
//         eldbus_proxy_vcall(IntPtr proxy, string member, IntPtr cb, IntPtr cb_data, double timeout, string signature, va_list ap);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_proxy_signal_handler_add(IntPtr proxy, string member, IntPtr cb, IntPtr cb_data);

    [DllImport(efl.Libs.Eldbus)] public static extern void
        eldbus_proxy_event_callback_add(IntPtr proxy, int type, IntPtr cb, IntPtr cb_data);

    [DllImport(efl.Libs.Eldbus)] public static extern void
        eldbus_proxy_event_callback_del(IntPtr proxy, int type, IntPtr cb, IntPtr cb_data);
}

public class Proxy : IDisposable
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

    public Proxy(IntPtr handle, bool own)
    {
        InitNew(handle, own);
    }

    public Proxy(eldbus.Object obj, string _interface)
    {
        InitNew(eldbus_proxy_get(obj.Handle, _interface), true);
    }

    ~Proxy()
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
            eldbus_proxy_unref(h);
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

    eldbus.Object GetObject()
    {
        CheckHandle();
        var ptr = eldbus_proxy_object_get(Handle);
        if (ptr == IntPtr.Zero)
            throw new SEHException("Eldbus: could not get `Object' object from eldbus_proxy_object_get");
        return new eldbus.Object(ptr, false);
    }

    string GetInterface()
    {
        CheckHandle();
        var ptr = eldbus_proxy_interface_get(Handle);
        return Marshal.PtrToStringAuto(ptr);
    }

    eldbus.Message NewMethodCall(string member)
    {
        CheckHandle();

        if (member == null)
            throw new ArgumentNullException("member");

        var ptr = eldbus_proxy_method_call_new(Handle, member);
        if (ptr == IntPtr.Zero)
            throw new SEHException("Eldbus: could not get `Message' object from eldbus_proxy_method_call_new");
        return new eldbus.Message(ptr, false);
    }

    eldbus.Pending Send(eldbus.Message msg, eldbus.MessageDelegate dlgt = null, double timeout = -1)
    {
        CheckHandle();

        if (msg == null)
            throw new ArgumentNullException("msg");

        IntPtr cb_wrapper = dlgt == null ? IntPtr.Zero : eldbus.Common.GetMessageCbWrapperPtr();
        IntPtr cb_data = dlgt == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(dlgt);

        var pending_hdl = eldbus_proxy_send(Handle, msg.Handle, cb_wrapper, cb_data, timeout);

        if (pending_hdl == IntPtr.Zero)
            throw new SEHException("Eldbus: could not get `Pending' object from eldbus_proxy_send");

        return new eldbus.Pending(pending_hdl, false);
    }

    eldbus.Message SendAndBlock(eldbus.Message msg, double timeout = -1)
    {
        CheckHandle();
        var ptr = eldbus_proxy_send_and_block(Handle, msg.Handle, timeout);
        if (ptr == IntPtr.Zero)
            throw new SEHException("Eldbus: could not get `Message' object from eldbus_proxy_send_and_block");
        return new eldbus.Message(ptr, true);
    }

    eldbus.Pending Call(string member, eldbus.MessageDelegate dlgt, double timeout, params BasicMessageArgument[] args)
    {
        CheckHandle();

        var msg = NewMethodCall(member);

        foreach (BasicMessageArgument arg in args)
        {
            arg.AppendTo(msg);
        }

        return Send(msg, dlgt, timeout);
    }

    eldbus.Pending Call(string member, params BasicMessageArgument[] args)
    {
        return Call(member, null, -1.0, args);
    }
}

}

