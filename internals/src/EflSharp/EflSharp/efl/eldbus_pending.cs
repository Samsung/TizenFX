#pragma warning disable 1591

using System;
using System.Runtime.InteropServices;

using static eldbus.EldbusPendingNativeFunctions;

namespace eldbus
{

public static class EldbusPendingNativeFunctions
{
    [DllImport(efl.Libs.Eldbus)] public static extern void
        eldbus_pending_data_set(IntPtr pending, string key, IntPtr data);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_pending_data_get(IntPtr pending, string key);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_pending_data_del(IntPtr pending, string key);

    [DllImport(efl.Libs.Eldbus)] public static extern void
        eldbus_pending_cancel(IntPtr pending);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_pending_destination_get(IntPtr pending);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_pending_path_get(IntPtr pending);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_pending_interface_get(IntPtr pending);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_pending_method_get(IntPtr pending);

    [DllImport(efl.Libs.Eldbus)] public static extern void
        eldbus_pending_free_cb_add(IntPtr pending, IntPtr cb, IntPtr data);

    [DllImport(efl.Libs.Eldbus)] public static extern void
        eldbus_pending_free_cb_del(IntPtr pending, IntPtr cb, IntPtr data);
}

public class Pending
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

    public Pending(IntPtr handle, bool own)
    {
        InitNew(handle, own);
    }

    public IntPtr Release()
    {
        IntPtr h = Handle;
        Handle = IntPtr.Zero;
        return h;
    }

    public void Cancel()
    {
        CheckHandle();
        eldbus_pending_cancel(Handle);
    }

    public string GetDestination()
    {
        CheckHandle();
        var ptr = eldbus_pending_destination_get(Handle);
        return Eina.StringConversion.NativeUtf8ToManagedString(ptr);
    }

    public string GetPath()
    {
        CheckHandle();
        var ptr = eldbus_pending_path_get(Handle);
        return Eina.StringConversion.NativeUtf8ToManagedString(ptr);
    }

    public string GetInterface()
    {
        CheckHandle();
        var ptr = eldbus_pending_interface_get(Handle);
        return Eina.StringConversion.NativeUtf8ToManagedString(ptr);
    }

    public string GetMethod()
    {
        CheckHandle();
        var ptr = eldbus_pending_method_get(Handle);
        return Eina.StringConversion.NativeUtf8ToManagedString(ptr);
    }
}

}
