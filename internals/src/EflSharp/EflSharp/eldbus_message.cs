#pragma warning disable 1591

using System;
using System.Runtime.InteropServices;

using static eldbus.EldbusMessageNativeFunctions;

namespace eldbus {

public static class EldbusMessageNativeFunctions
{
    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_message_ref(IntPtr msg);

    [DllImport(efl.Libs.Eldbus)] public static extern void
        eldbus_message_unref(IntPtr msg);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_message_path_get(IntPtr msg);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_message_interface_get(IntPtr msg);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_message_member_get(IntPtr msg);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_message_destination_get(IntPtr msg);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_message_sender_get(IntPtr msg);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_message_signature_get(IntPtr msg);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_message_method_call_new(string dest, string path, string iface, string method);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_message_signal_new(string path, string _interface, string name);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_message_error_new(IntPtr msg, string error_name, string error_msg);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_message_method_return_new(IntPtr msg);

    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_error_get(IntPtr msg, out IntPtr name, out IntPtr text);

    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_arguments_get(IntPtr msg, string signature, out byte value);
    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_arguments_get(IntPtr msg, string signature, out Int16 value);
    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_arguments_get(IntPtr msg, string signature, out UInt16 value);
    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_arguments_get(IntPtr msg, string signature, out Int32 value);
    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_arguments_get(IntPtr msg, string signature, out UInt32 value);
    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_arguments_get(IntPtr msg, string signature, out Int64 value);
    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_arguments_get(IntPtr msg, string signature, out UInt64 value);
    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_arguments_get(IntPtr msg, string signature, out double value);
    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_arguments_get(IntPtr msg, string signature, out IntPtr value);

//     [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
//         eldbus_message_arguments_vget(IntPtr msg, string signature, va_list ap);

    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_arguments_append(IntPtr msg, string signature, byte value);
    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_arguments_append(IntPtr msg, string signature, Int16 value);
    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_arguments_append(IntPtr msg, string signature, UInt16 value);
    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_arguments_append(IntPtr msg, string signature, Int32 value);
    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_arguments_append(IntPtr msg, string signature, UInt32 value);
    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_arguments_append(IntPtr msg, string signature, Int64 value);
    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_arguments_append(IntPtr msg, string signature, UInt64 value);
    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_arguments_append(IntPtr msg, string signature, double value);
    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_arguments_append(IntPtr msg, string signature, string value);

//     [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
//         eldbus_message_arguments_vappend(IntPtr msg, string signature, va_list ap);


    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_message_iter_container_new(IntPtr iter, int type, string contained_signature);

    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_iter_basic_append(IntPtr iter, int type, byte value);
    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_iter_basic_append(IntPtr iter, int type, Int16 value);
    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_iter_basic_append(IntPtr iter, int type, UInt16 value);
    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_iter_basic_append(IntPtr iter, int type, Int32 value);
    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_iter_basic_append(IntPtr iter, int type, UInt32 value);
    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_iter_basic_append(IntPtr iter, int type, Int64 value);
    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_iter_basic_append(IntPtr iter, int type, UInt64 value);
    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_iter_basic_append(IntPtr iter, int type, double value);
    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_iter_basic_append(IntPtr iter, int type, string value);

    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_iter_arguments_append(IntPtr iter, string signature, out IntPtr value);

//     [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
//         eldbus_message_iter_arguments_vappend(IntPtr iter, string signature, va_list ap);

    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_iter_fixed_array_append(IntPtr iter, int type, IntPtr array, uint size);

    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_iter_container_close(IntPtr iter, IntPtr sub);

    [DllImport(efl.Libs.Eldbus)] public static extern IntPtr
        eldbus_message_iter_get(IntPtr msg);

    [DllImport(efl.Libs.Eldbus)] public static extern void
        eldbus_message_iter_basic_get(IntPtr iter, out byte value);
    [DllImport(efl.Libs.Eldbus)] public static extern void
        eldbus_message_iter_basic_get(IntPtr iter, out Int16 value);
    [DllImport(efl.Libs.Eldbus)] public static extern void
        eldbus_message_iter_basic_get(IntPtr iter, out UInt16 value);
    [DllImport(efl.Libs.Eldbus)] public static extern void
        eldbus_message_iter_basic_get(IntPtr iter, out Int32 value);
    [DllImport(efl.Libs.Eldbus)] public static extern void
        eldbus_message_iter_basic_get(IntPtr iter, out UInt32 value);
    [DllImport(efl.Libs.Eldbus)] public static extern void
        eldbus_message_iter_basic_get(IntPtr iter, out Int64 value);
    [DllImport(efl.Libs.Eldbus)] public static extern void
        eldbus_message_iter_basic_get(IntPtr iter, out UInt64 value);
    [DllImport(efl.Libs.Eldbus)] public static extern void
        eldbus_message_iter_basic_get(IntPtr iter, out double value);
    [DllImport(efl.Libs.Eldbus)] public static extern void
        eldbus_message_iter_basic_get(IntPtr iter, out IntPtr value);

    [DllImport(efl.Libs.Eldbus)] public static extern string
        eldbus_message_iter_signature_get(IntPtr iter);

    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_iter_next(IntPtr iter);

    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_iter_get_and_next(IntPtr iter, char signature, out byte value);
    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_iter_get_and_next(IntPtr iter, char signature, out Int16 value);
    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_iter_get_and_next(IntPtr iter, char signature, out UInt16 value);
    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_iter_get_and_next(IntPtr iter, char signature, out Int32 value);
    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_iter_get_and_next(IntPtr iter, char signature, out UInt32 value);
    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_iter_get_and_next(IntPtr iter, char signature, out Int64 value);
    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_iter_get_and_next(IntPtr iter, char signature, out UInt64 value);
    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_iter_get_and_next(IntPtr iter, char signature, out double value);
    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_iter_get_and_next(IntPtr iter, char signature, out IntPtr value);

    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_iter_fixed_array_get(IntPtr iter, int signature, out IntPtr value, out int n_elements);

    [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
        eldbus_message_iter_arguments_get(IntPtr iter, string signature, out IntPtr value);

//     [DllImport(efl.Libs.Eldbus)] [return: MarshalAs(UnmanagedType.U1)] public static extern bool
//         eldbus_message_iter_arguments_vget(IntPtr iter, string signature, va_list ap);

    [DllImport(efl.Libs.Eldbus)] public static extern void
        eldbus_message_iter_del(IntPtr iter);
}


public class Message : IDisposable
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

    public Message(IntPtr handle, bool own)
    {
        InitNew(handle, own);
    }

    ~Message()
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
            eldbus_message_unref(h);
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

    public static eldbus.Message NewMethodCall(string dest, string path, string iface, string method)
    {
        var ptr = eldbus_message_method_call_new(dest, path, iface, method);
        if (ptr == IntPtr.Zero)
            throw new SEHException("Eldbus: could not get `Message' object from eldbus_message_method_call_new");
        return new eldbus.Message(ptr, true);
    }

    public static eldbus.Message NewSignal(string path, string _interface, string name)
    {
        var ptr = eldbus_message_signal_new(path, _interface, name);
        if (ptr == IntPtr.Zero)
            throw new SEHException("Eldbus: could not get `Message' object from eldbus_message_signal_new");
        return new eldbus.Message(ptr, true);
    }

    public void Ref()
    {
        CheckHandle();
        eldbus_message_ref(Handle);
    }

    public void Unref()
    {
        CheckHandle();
        eldbus_message_unref(Handle);
    }

    public string GetPath()
    {
        CheckHandle();
        var ptr = eldbus_message_path_get(Handle);
        return Marshal.PtrToStringAuto(ptr);
    }

    public string GetInterface()
    {
        CheckHandle();
        var ptr = eldbus_message_interface_get(Handle);
        return Marshal.PtrToStringAuto(ptr);
    }

    public string GetMember()
    {
        CheckHandle();
        var ptr = eldbus_message_member_get(Handle);
        return Marshal.PtrToStringAuto(ptr);
    }

    public string GetDestination()
    {
        CheckHandle();
        var ptr = eldbus_message_destination_get(Handle);
        return Marshal.PtrToStringAuto(ptr);
    }

    public string GetSender()
    {
        CheckHandle();
        var ptr = eldbus_message_sender_get(Handle);
        return Marshal.PtrToStringAuto(ptr);
    }

    public string GetSignature()
    {
        CheckHandle();
        var ptr = eldbus_message_signature_get(Handle);
        return Marshal.PtrToStringAuto(ptr);
    }

    public eldbus.Message NewError(string error_name, string error_msg)
    {
        CheckHandle();
        var ptr = eldbus_message_error_new(Handle, error_name, error_msg);
        if (ptr == IntPtr.Zero)
            throw new SEHException("Eldbus: could not get `Message' object from eldbus_message_error_new");
        return new eldbus.Message(ptr, false);
    }

    public eldbus.Message NewMethodReturn()
    {
        CheckHandle();
        var ptr = eldbus_message_method_return_new(Handle);
        if (ptr == IntPtr.Zero)
            throw new SEHException("Eldbus: could not get `Message' object from eldbus_message_method_return_new");
        return new eldbus.Message(ptr, false);
    }

    public bool GetError(out string name, out string text)
    {
        CheckHandle();
        IntPtr name_ptr;
        IntPtr text_ptr;
        bool r = eldbus_message_error_get(Handle, out name_ptr, out text_ptr);
        name = Marshal.PtrToStringAuto(name_ptr);
        text = Marshal.PtrToStringAuto(text_ptr);
        return r;
    }

    public bool Get(out byte val)
    {
        CheckHandle();
        return eldbus_message_arguments_get(Handle, Argument.ByteType.Signature, out val);
    }

    public bool Get(out bool val)
    {
        CheckHandle();
        Int32 aux;
        var r = eldbus_message_arguments_get(Handle, Argument.BooleanType.Signature, out aux);
        val = (aux != 0);
        return r;
    }

    public bool Get(out Int16 val)
    {
        CheckHandle();
        return eldbus_message_arguments_get(Handle, Argument.Int16Type.Signature, out val);
    }

    public bool Get(out UInt16 val)
    {
        CheckHandle();
        return eldbus_message_arguments_get(Handle, Argument.UInt16Type.Signature, out val);
    }

    public bool Get(out Int32 val)
    {
        CheckHandle();
        return eldbus_message_arguments_get(Handle, Argument.Int32Type.Signature, out val);
    }

    public bool Get(out UInt32 val)
    {
        CheckHandle();
        return eldbus_message_arguments_get(Handle, Argument.UInt32Type.Signature, out val);
    }

    public bool Get(out Int64 val)
    {
        CheckHandle();
        return eldbus_message_arguments_get(Handle, Argument.Int64Type.Signature, out val);
    }

    public bool Get(out UInt64 val)
    {
        CheckHandle();
        return eldbus_message_arguments_get(Handle, Argument.UInt64Type.Signature, out val);
    }

    public bool Get(out double val)
    {
        CheckHandle();
        return eldbus_message_arguments_get(Handle, Argument.DoubleType.Signature, out val);
    }

    public bool Get(out string val)
    {
        CheckHandle();
        IntPtr aux;
        var r = eldbus_message_arguments_get(Handle, Argument.StringType.Signature, out aux);
        val = Marshal.PtrToStringAuto(aux);
        return r;
    }

    public bool Get(out eldbus.ObjectPath val)
    {
        CheckHandle();
        IntPtr aux;
        var r = eldbus_message_arguments_get(Handle, Argument.ObjectPathType.Signature, out aux);
        val = Marshal.PtrToStringAuto(aux);
        return r;
    }

    public bool Get(out eldbus.SignatureString val)
    {
        CheckHandle();
        IntPtr aux;
        var r = eldbus_message_arguments_get(Handle, Argument.SignatureType.Signature, out aux);
        val = Marshal.PtrToStringAuto(aux);
        return r;
    }

    public bool Get(out eldbus.UnixFd val)
    {
        CheckHandle();
        Int32 aux;
        var r = eldbus_message_arguments_get(Handle, Argument.UnixFdType.Signature, out aux);
        val = aux;
        return r;
    }

    public void Append(params BasicMessageArgument[] args)
    {
        CheckHandle();
        foreach (BasicMessageArgument arg in args)
        {
            arg.AppendTo(this);
        }
    }

    public eldbus.MessageIterator AppendOpenContainer(string signature)
    {
        var iter = GetMessageIterator();
        return iter.AppendOpenContainer(signature);
    }

    public eldbus.MessageIterator GetMessageIterator()
    {
        CheckHandle();
        var ptr = eldbus_message_iter_get(Handle);
        if (ptr == IntPtr.Zero)
            throw new SEHException("Eldbus: could not get `MessageIterator' object from eldbus_message_iter_get");
        return new eldbus.MessageIterator(ptr, IntPtr.Zero);
    }
}

public class MessageIterator
{
    public IntPtr Handle {get;set;} = IntPtr.Zero;
    public IntPtr Parent {get;set;} = IntPtr.Zero;

    private void InitNew(IntPtr handle, IntPtr parent)
    {
        Handle = handle;
        Parent = parent;
        CheckHandle();
    }

    private void CheckHandle()
    {
        if (Handle == IntPtr.Zero)
        {
            eldbus.Common.RaiseNullHandle();
        }
    }

    public MessageIterator(IntPtr handle, IntPtr parent)
    {
        InitNew(handle, parent);
    }

    public IntPtr Release()
    {
        IntPtr h = Handle;
        Handle = IntPtr.Zero;
        Parent = IntPtr.Zero;
        return h;
    }

    public void Append(params BasicMessageArgument[] args)
    {
        CheckHandle();

        foreach (BasicMessageArgument arg in args)
        {
            arg.AppendTo(this);
        }
    }

    public eldbus.MessageIterator AppendOpenContainer(string signature)
    {
        CheckHandle();

        IntPtr new_iter = IntPtr.Zero;

        if (signature[0] == 'v')
            new_iter = eldbus_message_iter_container_new(Handle, 'v', signature.Substring(1));
        else if (!eldbus_message_iter_arguments_append(Handle, signature, out new_iter))
            throw new SEHException("Eldbus: could not append container type");

        if (new_iter == IntPtr.Zero)
            throw new SEHException("Eldbus: could not get `MessageIterator' object from eldbus_message_iter_arguments_append");

        return new eldbus.MessageIterator(new_iter, Handle);
    }

    public eldbus.MessageIterator AppendOpenContainer(char type, string contained_signature)
    {
        CheckHandle();

        IntPtr new_iter = eldbus_message_iter_container_new(Handle, type, contained_signature);

        if (new_iter == IntPtr.Zero)
            throw new SEHException("Eldbus: could not get `MessageIterator' object from eldbus_message_iter_container_new");

        return new eldbus.MessageIterator(new_iter, Handle);
    }

    public void CloseContainer()
    {
        CheckHandle();

        if (Parent == IntPtr.Zero)
            throw new SEHException("Eldbus: can not close MessageIterator open container without a parent");

        if (!eldbus_message_iter_container_close(Parent, Handle))
            throw new SEHException("Eldbus: could not close MessageIterator");

        Handle = IntPtr.Zero;
        Parent = IntPtr.Zero;
    }

    public string GetSignature()
    {
        return eldbus_message_iter_signature_get(Handle);
    }

    public bool GetAndNext(out byte val)
    {
        CheckHandle();
        return eldbus_message_iter_get_and_next(Handle, Argument.ByteType.Code, out val);
    }

    public bool GetAndNext(out bool val)
    {
        CheckHandle();
        Int32 aux;
        bool r = eldbus_message_iter_get_and_next(Handle, Argument.BooleanType.Code, out aux);
        val = (aux != 0);
        return r;
    }

    public bool GetAndNext(out Int16 val)
    {
        CheckHandle();
        return eldbus_message_iter_get_and_next(Handle, Argument.Int16Type.Code, out val);
    }

    public bool GetAndNext(out UInt16 val)
    {
        CheckHandle();
        return eldbus_message_iter_get_and_next(Handle, Argument.UInt16Type.Code, out val);
    }

    public bool GetAndNext(out Int32 val)
    {
        CheckHandle();
        return eldbus_message_iter_get_and_next(Handle, Argument.Int32Type.Code, out val);
    }

    public bool GetAndNext(out UInt32 val)
    {
        CheckHandle();
        return eldbus_message_iter_get_and_next(Handle, Argument.UInt32Type.Code, out val);
    }

    public bool GetAndNext(out Int64 val)
    {
        CheckHandle();
        return eldbus_message_iter_get_and_next(Handle, Argument.Int64Type.Code, out val);
    }

    public bool GetAndNext(out UInt64 val)
    {
        CheckHandle();
        return eldbus_message_iter_get_and_next(Handle, Argument.UInt64Type.Code, out val);
    }

    public bool GetAndNext(out double val)
    {
        CheckHandle();
        return eldbus_message_iter_get_and_next(Handle, Argument.DoubleType.Code, out val);
    }

    public bool GetAndNext(out string val)
    {
        CheckHandle();
        IntPtr aux;
        bool r = eldbus_message_iter_get_and_next(Handle, Argument.StringType.Code, out aux);
        val = Marshal.PtrToStringAuto(aux);
        return r;
    }

    public bool GetAndNext(out eldbus.ObjectPath val)
    {
        CheckHandle();
        IntPtr aux;
        bool r = eldbus_message_iter_get_and_next(Handle, Argument.ObjectPathType.Code, out aux);
        val = Marshal.PtrToStringAuto(aux);
        return r;
    }

    public bool GetAndNext(out eldbus.SignatureString val)
    {
        CheckHandle();
        IntPtr aux;
        bool r = eldbus_message_iter_get_and_next(Handle, Argument.SignatureType.Code, out aux);
        val = Marshal.PtrToStringAuto(aux);
        return r;
    }

    public bool GetAndNext(out eldbus.UnixFd val)
    {
        CheckHandle();
        Int32 aux;
        bool r = eldbus_message_iter_get_and_next(Handle, Argument.UnixFdType.Code, out aux);
        val = aux;
        return r;
    }

    public bool GetAndNext(out eldbus.MessageIterator iter, char typecode)
    {
        CheckHandle();
        IntPtr hdl = IntPtr.Zero;
        bool r = eldbus_message_iter_get_and_next(Handle, typecode, out hdl);
        if (hdl == IntPtr.Zero)
            throw new SEHException("Eldbus: could not get argument");
        iter = new eldbus.MessageIterator(hdl, Handle);

        return r;
    }

    public bool GetAndNext(out eldbus.MessageIterator iter, string signatue)
    {
        CheckHandle();
        IntPtr hdl = IntPtr.Zero;
        if (!eldbus_message_iter_arguments_get(Handle, signatue, out hdl) || hdl == IntPtr.Zero)
            throw new SEHException("Eldbus: could not get argument");
        iter = new eldbus.MessageIterator(hdl, Handle);

        return Next();
    }

    public void Get(out byte val)
    {
        CheckHandle();
        eldbus_message_iter_basic_get(Handle, out val);
    }

    public void Get(out bool val)
    {
        CheckHandle();
        Int32 aux;
        eldbus_message_iter_basic_get(Handle, out aux);
        val = (aux != 0);
    }

    public void Get(out Int16 val)
    {
        CheckHandle();
        eldbus_message_iter_basic_get(Handle, out val);
    }

    public void Get(out UInt16 val)
    {
        CheckHandle();
        eldbus_message_iter_basic_get(Handle, out val);
    }

    public void Get(out Int32 val)
    {
        CheckHandle();
        eldbus_message_iter_basic_get(Handle, out val);
    }

    public void Get(out UInt32 val)
    {
        CheckHandle();
        eldbus_message_iter_basic_get(Handle, out val);
    }

    public void Get(out Int64 val)
    {
        CheckHandle();
        eldbus_message_iter_basic_get(Handle, out val);
    }

    public void Get(out UInt64 val)
    {
        CheckHandle();
        eldbus_message_iter_basic_get(Handle, out val);
    }

    public void Get(out double val)
    {
        CheckHandle();
        eldbus_message_iter_basic_get(Handle, out val);
    }

    public void Get(out string val)
    {
        CheckHandle();
        IntPtr aux;
        eldbus_message_iter_basic_get(Handle, out aux);
        val = Marshal.PtrToStringAuto(aux);
    }

    public void Get(out eldbus.ObjectPath val)
    {
        CheckHandle();
        IntPtr aux;
        eldbus_message_iter_basic_get(Handle, out aux);
        val = Marshal.PtrToStringAuto(aux);
    }

    public void Get(out eldbus.SignatureString val)
    {
        CheckHandle();
        IntPtr aux;
        eldbus_message_iter_basic_get(Handle, out aux);
        val = Marshal.PtrToStringAuto(aux);
    }

    public void Get(out eldbus.UnixFd val)
    {
        CheckHandle();
        Int32 aux;
        eldbus_message_iter_basic_get(Handle, out aux);
        val = aux;
    }

    public void Get(out eldbus.MessageIterator iter, string signatue)
    {
        CheckHandle();
        IntPtr hdl = IntPtr.Zero;
        if (!eldbus_message_iter_arguments_get(Handle, signatue, out hdl) || hdl == IntPtr.Zero)
            throw new SEHException("Eldbus: could not get argument");
        iter = new eldbus.MessageIterator(hdl, Handle);
    }

    public bool Next()
    {
        CheckHandle();
        return eldbus_message_iter_next(Handle);
    }

    public void Del()
    {
        CheckHandle();

        eldbus_message_iter_del(Handle);

        Handle = IntPtr.Zero;
        Parent = IntPtr.Zero;
    }

    private void GetFixedArrayInternal(int type_code, out IntPtr value, out int n_elements)
    {
        CheckHandle();

        if (!eldbus_message_iter_fixed_array_get(Handle, type_code, out value, out n_elements))
            throw new SEHException("Eldbus: could not get fixed array");
    }

    public void GetFixedArray(out byte[] array)
    {
        IntPtr value;
        int n_elements;
        GetFixedArrayInternal(Argument.ByteType.Code, out value, out n_elements);
        array = new byte[n_elements];
        Marshal.Copy(value, array, 0, n_elements);
    }

    public void GetFixedArray(out bool[] array)
    {
        IntPtr value;
        int n_elements;
        GetFixedArrayInternal(Argument.BooleanType.Code, out value, out n_elements);
        var aux = new Int32[n_elements];
        Marshal.Copy(value, aux, 0, n_elements);

        // array = aux.Select(Convert.ToBoolean).ToArray();
        array = Array.ConvertAll(aux, Convert.ToBoolean);
    }

    public void GetFixedArray(out Int16[] array)
    {
        IntPtr value;
        int n_elements;
        GetFixedArrayInternal(Argument.Int16Type.Code, out value, out n_elements);
        array = new Int16[n_elements];
        Marshal.Copy(value, array, 0, n_elements);
    }

//     public void GetFixedArray(out UInt16[] array)
//     {
//         IntPtr value;
//         int n_elements;
//         GetFixedArrayInternal(Argument.UInt16Type.Code, out value, out n_elements);
//         array = new UInt16[n_elements];
//         Marshal.Copy(value, array, 0, n_elements);
//     }

    public void GetFixedArray(out Int32[] array)
    {
        IntPtr value;
        int n_elements;
        GetFixedArrayInternal(Argument.Int32Type.Code, out value, out n_elements);
        array = new Int32[n_elements];
        Marshal.Copy(value, array, 0, n_elements);
    }

//     public void GetFixedArray(out UInt32[] array)
//     {
//         IntPtr value;
//         int n_elements;
//         GetFixedArrayInternal(Argument.UInt32Type.Code, out value, out n_elements);
//         array = new UInt32[n_elements];
//         Marshal.Copy(value, array, 0, n_elements);
//     }

    public void GetFixedArray(out Int64[] array)
    {
        IntPtr value;
        int n_elements;
        GetFixedArrayInternal(Argument.Int64Type.Code, out value, out n_elements);
        array = new Int64[n_elements];
        Marshal.Copy(value, array, 0, n_elements);
    }

//     public void GetFixedArray(out UInt64[] array)
//     {
//         IntPtr value;
//         int n_elements;
//         GetFixedArrayInternal(Argument.UInt64Type.Code, out value, out n_elements);
//         array = new UInt64[n_elements];
//         Marshal.Copy(value, array, 0, n_elements);
//     }

    public void GetFixedArray(out eldbus.UnixFd[] array)
    {
        IntPtr value;
        int n_elements;
        GetFixedArrayInternal(Argument.DoubleType.Code, out value, out n_elements);
        var aux = new Int32[n_elements];
        Marshal.Copy(value, aux, 0, n_elements);

        array = Array.ConvertAll(aux, e => new UnixFd(e));
    }
}

}

