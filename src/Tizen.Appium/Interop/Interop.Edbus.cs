using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Libraries
    {
        internal const string Edbus = "libedbus.so.1";
        internal const string dbus = "libdbus-1.so.3";
    }

    internal enum DbusBusType
    {
        DBUS_BUS_SESSION,
        DBUS_BUS_SYSTEM,
        DBUS_BUS_STARTER
    }

    internal enum DbusDataType
    {
        DBUS_TYPE_INT_32 = 0x69,
        DBUS_TYPE_UINT_32 = 0x75,
        DBUS_TYPE_STRING = 0x73,
        DBUS_TYPE_BOOLEAN = 0x62,
    }

    internal enum NameFlags
    {
        None,
        AllowReplacement,
        ReplaceExisting,
        DoNotQueue
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct DbusMessageIter
    {
        IntPtr dummy1;
        IntPtr dummy2;
        int dummy3;
        int dummy4;
        int dummy5;
        int dummy6;
        int dummy7;
        int dummy8;
        int dummy9;
        int dummy10;
        int dummy11;
        int pad1;
        IntPtr pad2;
        IntPtr pad3;
    }

    internal static class Edbus
    {
        internal delegate void RequestCallback(IntPtr data, IntPtr msg, IntPtr error);

        internal delegate IntPtr MethodCallback(IntPtr obj, IntPtr message);

        internal delegate IntPtr MethodReturnCallback(IntPtr data, IntPtr message, IntPtr error);

        [DllImport(Libraries.Edbus)]
        internal static extern void dbus_threads_init_default();

        [DllImport(Libraries.Edbus)]
        internal static extern void dbus_error_init(out IntPtr error);

        [DllImport(Libraries.Edbus)]
        internal static extern int e_dbus_init();

        [DllImport(Libraries.Edbus)]
        internal static extern IntPtr e_dbus_bus_get(DbusBusType type);

        [DllImport(Libraries.Edbus)]
        internal static extern IntPtr dbus_bus_get(DbusBusType type, IntPtr error);

        [DllImport(Libraries.Edbus)]
        internal static extern IntPtr dbus_bus_get_private(DbusBusType type, IntPtr error);

        [DllImport(Libraries.Edbus)]
        internal static extern IntPtr e_dbus_request_name(IntPtr conn, string bus_name, NameFlags flags, RequestCallback callback, IntPtr data);

        [DllImport(Libraries.Edbus)]
        internal static extern IntPtr dbus_bus_set_unique_name(IntPtr conn, string bus_name);

        [DllImport(Libraries.Edbus)]
        internal static extern int dbus_bus_request_name(IntPtr conn, string bus_name, int flags, IntPtr error);

        [DllImport(Libraries.Edbus)]
        internal static extern IntPtr dbus_bus_request_name(IntPtr conn, string bus_name, NameFlags flags, IntPtr error);

        [DllImport(Libraries.Edbus)]
        internal static extern IntPtr e_dbus_object_add(IntPtr conn, string path, IntPtr data);

        [DllImport(Libraries.Edbus)]
        internal static extern void e_dbus_connection_ref(IntPtr conn);

        [DllImport(Libraries.Edbus)]
        internal static extern IntPtr e_dbus_interface_new(string iface);

        [DllImport(Libraries.Edbus)]
        internal static extern IntPtr e_dbus_object_interface_attach(IntPtr obj, IntPtr iface);

        [DllImport(Libraries.Edbus)]
        internal static extern IntPtr e_dbus_interface_method_add(IntPtr iface, string member, string signature, string reply_signature, MethodCallback callback);

        [DllImport(Libraries.Edbus)]
        internal static extern IntPtr dbus_message_new_signal(string path, string iface, string name);

        [DllImport(Libraries.Edbus)]
        internal static extern IntPtr e_dbus_message_send(IntPtr conn, IntPtr msg, MethodReturnCallback callback, int timeout, IntPtr data);

        [DllImport(Libraries.dbus)]
        internal static extern bool dbus_message_iter_init(IntPtr msg, ref DbusMessageIter iter);

        [DllImport(Libraries.Edbus)]
        internal static extern IntPtr dbus_message_new_method_return(IntPtr msg);

        [DllImport(Libraries.Edbus)]
        internal static extern void dbus_message_iter_init_append(IntPtr msg, ref DbusMessageIter iter);

        [DllImport(Libraries.Edbus)]
        internal static extern bool dbus_message_iter_append_basic(ref DbusMessageIter iter, int type, ref IntPtr value);

        [DllImport(Libraries.Edbus)]
        internal static extern int dbus_message_iter_get_arg_type(ref DbusMessageIter iter);

        [DllImport(Libraries.Edbus)]
        internal static extern void dbus_message_iter_get_basic(ref DbusMessageIter iter, out IntPtr value);

        [DllImport(Libraries.Edbus)]
        internal static extern bool dbus_message_iter_next(ref DbusMessageIter iter);

        [DllImport(Libraries.Edbus)]
        internal static extern bool dbus_message_iter_has_next(ref DbusMessageIter iter);

        [DllImport(Libraries.Edbus)]
        internal static extern int dbus_message_iter_get_element_count(ref DbusMessageIter iter);

        [DllImport(Libraries.Edbus)]
        internal static extern int dbus_message_iter_get_element_type(ref DbusMessageIter iter);

        [DllImport(Libraries.Edbus)]
        internal static extern void dbus_message_iter_recurse(ref DbusMessageIter iter, ref DbusMessageIter sub);

        [DllImport(Libraries.Edbus)]
        internal static extern bool dbus_message_iter_open_container(ref DbusMessageIter iter, int type, string container_sig, ref DbusMessageIter sub_iter);

        [DllImport(Libraries.Edbus)]
        internal static extern bool dbus_message_iter_close_container(ref DbusMessageIter iter, ref DbusMessageIter sub_iter);

        [DllImport(Libraries.Edbus)]
        internal static extern bool dbus_message_get_args(IntPtr msg, out IntPtr err, int type, out IntPtr data, int quit);

        [DllImport(Libraries.Edbus)]
        internal static extern bool e_dbus_connection_close(IntPtr conn);

        [DllImport(Libraries.Edbus)]
        internal static extern void dbus_connection_close(IntPtr conn);

        [DllImport(Libraries.Edbus)]
        internal static extern void dbus_connection_unref(IntPtr conn);

        [DllImport(Libraries.Edbus)]
        internal static extern int e_dbus_shutdown();

        [DllImport(Libraries.Edbus)]
        internal static extern IntPtr e_dbus_connection_setup(IntPtr conn);
    }
}