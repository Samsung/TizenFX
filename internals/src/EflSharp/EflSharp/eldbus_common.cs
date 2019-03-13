#pragma warning disable 1591

using System;
using System.Runtime.InteropServices;

using static eldbus.EldbusMessageNativeFunctions;

namespace eldbus {

public static class Timeout
{
    public static int Infinite = 0x7fffffff;
}

[StructLayout(LayoutKind.Sequential)]
public struct ObjectPath
{
    public string value;

    public ObjectPath(string str)
    {
        value = str;
    }

    public static implicit operator ObjectPath(string str)
    {
        return new ObjectPath(str);
    }
    public static implicit operator string(ObjectPath path)
    {
        return path.value;
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct SignatureString
{
    public string value;

    public SignatureString(string str)
    {
        value = str;
    }

    public static implicit operator SignatureString(string str)
    {
        return new SignatureString(str);
    }
    public static implicit operator string(SignatureString sig)
    {
        return sig.value;
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct UnixFd
{
    public Int32 value;

    public UnixFd(Int32 fd)
    {
        value = fd;
    }

    public static implicit operator UnixFd(Int32 fd)
    {
        return new UnixFd(fd);
    }
    public static implicit operator Int32(UnixFd unix_fd)
    {
        return unix_fd.value;
    }
}


public static class Argument
{
    public class ByteType       { public const char Code = 'y'; public const string Signature = "y"; }
    public class BooleanType    { public const char Code = 'b'; public const string Signature = "b"; }
    public class Int16Type      { public const char Code = 'n'; public const string Signature = "n"; }
    public class UInt16Type     { public const char Code = 'q'; public const string Signature = "q"; }
    public class Int32Type      { public const char Code = 'i'; public const string Signature = "i"; }
    public class UInt32Type     { public const char Code = 'u'; public const string Signature = "u"; }
    public class Int64Type      { public const char Code = 'x'; public const string Signature = "x"; }
    public class UInt64Type     { public const char Code = 't'; public const string Signature = "t"; }
    public class DoubleType     { public const char Code = 'd'; public const string Signature = "d"; }
    public class StringType     { public const char Code = 's'; public const string Signature = "s"; }
    public class ObjectPathType { public const char Code = 'o'; public const string Signature = "o"; }
    public class SignatureType  { public const char Code = 'g'; public const string Signature = "g"; }
    public class ArrayType      { public const char Code = 'a'; public const string Signature = "a"; }
    public class StructType     { public const char Code = 'r'; public const string Signature = "r"; }
    public class VariantType    { public const char Code = 'v'; public const string Signature = "v"; }
    public class DictEntryType  { public const char Code = 'e'; public const string Signature = "e"; }
    public class UnixFdType     { public const char Code = 'h'; public const string Signature = "h"; }

//     public static readonly ByteType       ByteT       = new ByteType();
//     public static readonly BooleanType    BooleanT    = new BooleanType();
//     public static readonly Int16Type      Int16T      = new Int16Type();
//     public static readonly UInt16Type     UInt16T     = new UInt16Type();
//     public static readonly Int32Type      Int32T      = new Int32Type();
//     public static readonly UInt32Type     UInt32T     = new UInt32Type();
//     public static readonly Int64Type      Int64T      = new Int64Type();
//     public static readonly UInt64Type     UInt64T     = new UInt64Type();
//     public static readonly DoubleType     DoubleT     = new DoubleType();
//     public static readonly StringType     StringT     = new StringType();
//     public static readonly ObjectPathType ObjectPathT = new ObjectPathType();
//     public static readonly SignatureType  SignatureT  = new SignatureType();
//     public static readonly ArrayType      ArrayT      = new ArrayType();
//     public static readonly StructType     StructT     = new StructType();
//     public static readonly VariantType    VariantT    = new VariantType();
//     public static readonly DictEntryType  DictEntryT  = new DictEntryType();
//     public static readonly UnixFdType     UnixFdT     = new UnixFdType();
//
//     public static readonly ByteType       y = ByteT;
//     public static readonly BooleanType    b = BooleanT;
//     public static readonly Int16Type      n = Int16T;
//     public static readonly UInt16Type     q = UInt16T;
//     public static readonly Int32Type      i = Int32T;
//     public static readonly UInt32Type     u = UInt32T;
//     public static readonly Int64Type      x = Int64T;
//     public static readonly UInt64Type     t = UInt64T;
//     public static readonly DoubleType     d = DoubleT;
//     public static readonly StringType     s = StringT;
//     public static readonly ObjectPathType o = ObjectPathT;
//     public static readonly SignatureType  g = SignatureT;
//     public static readonly ArrayType      a = ArrayT;
//     public static readonly StructType     r = StructT;
//     public static readonly VariantType    v = VariantT;
//     public static readonly DictEntryType  e = DictEntryT;
//     public static readonly UnixFdType     h = UnixFdT;
}

public abstract class BasicMessageArgument
{
    public void AppendTo(eldbus.Message msg)
    {
        if (!InternalAppendTo(msg))
            throw new SEHException("Eldbus: could not append basic type to eldbus.Message");
    }

    public void AppendTo(eldbus.MessageIterator iter)
    {
        if (!InternalAppendTo(iter))
            throw new SEHException("Eldbus: could not append basic type to eldbus.MessageIterator");
    }

    public abstract char TypeCode {get;}
    public abstract string Signature {get;}
    protected abstract bool InternalAppendTo(eldbus.Message msg);
    protected abstract bool InternalAppendTo(eldbus.MessageIterator iter);

    public static implicit operator BasicMessageArgument(byte arg)
    {
        return new ByteMessageArgument(arg);
    }

    public static implicit operator BasicMessageArgument(bool arg)
    {
        return new BoolMessageArgument(arg);
    }

    public static implicit operator BasicMessageArgument(Int16 arg)
    {
        return new Int16MessageArgument(arg);
    }

    public static implicit operator BasicMessageArgument(UInt16 arg)
    {
        return new UInt16MessageArgument(arg);
    }

    public static implicit operator BasicMessageArgument(Int32 arg)
    {
        return new Int32MessageArgument(arg);
    }

    public static implicit operator BasicMessageArgument(UInt32 arg)
    {
        return new UInt32MessageArgument(arg);
    }

    public static implicit operator BasicMessageArgument(Int64 arg)
    {
        return new Int64MessageArgument(arg);
    }

    public static implicit operator BasicMessageArgument(UInt64 arg)
    {
        return new UInt64MessageArgument(arg);
    }

    public static implicit operator BasicMessageArgument(string arg)
    {
        return new StringMessageArgument(arg);
    }

    public static implicit operator BasicMessageArgument(SignatureString arg)
    {
        return new SignatureMessageArgument(arg);
    }

    public static implicit operator BasicMessageArgument(ObjectPath arg)
    {
        return new ObjectPathMessageArgument(arg);
    }

    public static implicit operator BasicMessageArgument(UnixFd arg)
    {
        return new UnixFdMessageArgument(arg);
    }
}

public class ByteMessageArgument : BasicMessageArgument
{
    private byte value;

    public ByteMessageArgument(byte arg)
    {
        value = arg;
    }

    public override char TypeCode { get { return Argument.ByteType.Code; } }
    public override string Signature { get { return Argument.ByteType.Signature; } }

    protected override bool InternalAppendTo(eldbus.Message msg)
    {
        return eldbus_message_arguments_append(msg.Handle, Signature, value);
    }

    protected override bool InternalAppendTo(eldbus.MessageIterator iter)
    {
        return eldbus_message_iter_basic_append(iter.Handle, TypeCode, value);
    }
}

public class BoolMessageArgument : BasicMessageArgument
{
    private Int32 value;

    public BoolMessageArgument(bool arg)
    {
        value = Convert.ToInt32(arg);
    }

    public override char TypeCode { get { return Argument.BooleanType.Code; } }
    public override string Signature { get { return Argument.ByteType.Signature; } }

    protected override bool InternalAppendTo(eldbus.Message msg)
    {
        return eldbus_message_arguments_append(msg.Handle, Signature, value);
    }

    protected override bool InternalAppendTo(eldbus.MessageIterator iter)
    {
        return eldbus_message_iter_basic_append(iter.Handle, TypeCode, value);
    }
}

public class Int16MessageArgument : BasicMessageArgument
{
    private Int16 value;

    public Int16MessageArgument(Int16 arg)
    {
        value = arg;
    }

    public override char TypeCode { get { return Argument.Int16Type.Code; } }
    public override string Signature { get { return Argument.ByteType.Signature; } }

    protected override bool InternalAppendTo(eldbus.Message msg)
    {
        return eldbus_message_arguments_append(msg.Handle, Signature, value);
    }

    protected override bool InternalAppendTo(eldbus.MessageIterator iter)
    {
        return eldbus_message_iter_basic_append(iter.Handle, TypeCode, value);
    }
}

public class UInt16MessageArgument : BasicMessageArgument
{
    private UInt16 value;

    public UInt16MessageArgument(UInt16 arg)
    {
        value = arg;
    }

    public override char TypeCode { get { return Argument.UInt16Type.Code; } }
    public override string Signature { get { return Argument.ByteType.Signature; } }

    protected override bool InternalAppendTo(eldbus.Message msg)
    {
        return eldbus_message_arguments_append(msg.Handle, Signature, value);
    }

    protected override bool InternalAppendTo(eldbus.MessageIterator iter)
    {
        return eldbus_message_iter_basic_append(iter.Handle, TypeCode, value);
    }
}

public class Int32MessageArgument : BasicMessageArgument
{
    private Int32 value;

    public Int32MessageArgument(Int32 arg)
    {
        value = arg;
    }

    public override char TypeCode { get { return Argument.Int32Type.Code; } }
    public override string Signature { get { return Argument.ByteType.Signature; } }

    protected override bool InternalAppendTo(eldbus.Message msg)
    {
        return eldbus_message_arguments_append(msg.Handle, Signature, value);
    }

    protected override bool InternalAppendTo(eldbus.MessageIterator iter)
    {
        return eldbus_message_iter_basic_append(iter.Handle, TypeCode, value);
    }
}

public class UInt32MessageArgument : BasicMessageArgument
{
    private UInt32 value;

    public UInt32MessageArgument(UInt32 arg)
    {
        value = arg;
    }

    public override char TypeCode { get { return Argument.UInt32Type.Code; } }
    public override string Signature { get { return Argument.ByteType.Signature; } }

    protected override bool InternalAppendTo(eldbus.Message msg)
    {
        return eldbus_message_arguments_append(msg.Handle, Signature, value);
    }

    protected override bool InternalAppendTo(eldbus.MessageIterator iter)
    {
        return eldbus_message_iter_basic_append(iter.Handle, TypeCode, value);
    }
}

public class Int64MessageArgument : BasicMessageArgument
{
    private Int64 value;

    public Int64MessageArgument(Int64 arg)
    {
        value = arg;
    }

    public override char TypeCode { get { return Argument.Int64Type.Code; } }
    public override string Signature { get { return Argument.ByteType.Signature; } }

    protected override bool InternalAppendTo(eldbus.Message msg)
    {
        return eldbus_message_arguments_append(msg.Handle, Signature, value);
    }

    protected override bool InternalAppendTo(eldbus.MessageIterator iter)
    {
        return eldbus_message_iter_basic_append(iter.Handle, TypeCode, value);
    }
}

public class UInt64MessageArgument : BasicMessageArgument
{
    private UInt64 value;

    public UInt64MessageArgument(UInt64 arg)
    {
        value = arg;
    }

    public override char TypeCode { get { return Argument.UInt64Type.Code; } }
    public override string Signature { get { return Argument.ByteType.Signature; } }

    protected override bool InternalAppendTo(eldbus.Message msg)
    {
        return eldbus_message_arguments_append(msg.Handle, Signature, value);
    }

    protected override bool InternalAppendTo(eldbus.MessageIterator iter)
    {
        return eldbus_message_iter_basic_append(iter.Handle, TypeCode, value);
    }
}

public class DoubleMessageArgument : BasicMessageArgument
{
    private double value;

    public DoubleMessageArgument(double arg)
    {
        value = arg;
    }

    public override char TypeCode { get { return Argument.DoubleType.Code; } }
    public override string Signature { get { return Argument.ByteType.Signature; } }

    protected override bool InternalAppendTo(eldbus.Message msg)
    {
        return eldbus_message_arguments_append(msg.Handle, Signature, value);
    }

    protected override bool InternalAppendTo(eldbus.MessageIterator iter)
    {
        return eldbus_message_iter_basic_append(iter.Handle, TypeCode, value);
    }
}

public abstract class StringLikeMessageArgument : BasicMessageArgument
{
    private string value;

    public StringLikeMessageArgument(string arg)
    {
        value = arg;
    }

    protected override bool InternalAppendTo(eldbus.Message msg)
    {
        return eldbus_message_arguments_append(msg.Handle, Signature, value);
    }

    protected override bool InternalAppendTo(eldbus.MessageIterator iter)
    {
        return eldbus_message_iter_basic_append(iter.Handle, TypeCode, value);
    }
}

public class StringMessageArgument : StringLikeMessageArgument
{
    public StringMessageArgument(string arg)
        : base(arg)
    {}

    public override char TypeCode { get { return Argument.StringType.Code; } }
    public override string Signature { get { return Argument.ByteType.Signature; } }
}

public class ObjectPathMessageArgument : StringLikeMessageArgument
{
    public ObjectPathMessageArgument(ObjectPath arg)
        : base(arg.value)
    {}

    public override char TypeCode { get { return Argument.ObjectPathType.Code; } }
    public override string Signature { get { return Argument.ByteType.Signature; } }
}

public class SignatureMessageArgument : StringLikeMessageArgument
{
    public SignatureMessageArgument(SignatureString arg)
        : base(arg.value)
    {}

    public override char TypeCode { get { return Argument.SignatureType.Code; } }
    public override string Signature { get { return Argument.ByteType.Signature; } }
}

public class UnixFdMessageArgument : BasicMessageArgument
{
    private Int32 value;

    public UnixFdMessageArgument(UnixFd arg)
    {
        value = arg.value;
    }

    public override char TypeCode { get { return Argument.UnixFdType.Code; } }
    public override string Signature { get { return Argument.ByteType.Signature; } }

    protected override bool InternalAppendTo(eldbus.Message msg)
    {
        return eldbus_message_arguments_append(msg.Handle, Signature, value);
    }

    protected override bool InternalAppendTo(eldbus.MessageIterator iter)
    {
        return eldbus_message_iter_basic_append(iter.Handle, TypeCode, value);
    }
}

public delegate void MessageDelegate(eldbus.Message msg, eldbus.Pending pending);

public static class Common
{
    public static void RaiseNullHandle()
    {
        if (NullHandleError == 0)
            NullHandleError = Eina.Error.Register("Eldbus: null handle");
        Eina.Error.Raise(NullHandleError);
    }

    public delegate void Eldbus_Message_Cb(IntPtr data, IntPtr msg, IntPtr pending);

    public static IntPtr GetMessageCbWrapperPtr()
    {
        return Marshal.GetFunctionPointerForDelegate(GetMessageCbWrapper());
    }

    public static Eldbus_Message_Cb GetMessageCbWrapper()
    {
        if (message_cb_wrapper == null)
            message_cb_wrapper = new Eldbus_Message_Cb(MessageCbWrapper);
        return message_cb_wrapper;
    }

    public static void MessageCbWrapper(IntPtr data, IntPtr msg_hdl, IntPtr pending_hdl)
    {
        MessageDelegate dlgt = Marshal.GetDelegateForFunctionPointer(data, typeof(MessageDelegate)) as MessageDelegate;
        if (dlgt == null)
        {
            Eina.Log.Error("Eldbus: invalid delegate pointer from Eldbus_Message_Cb");
            return;
        }

        eldbus.Message msg;
        eldbus.Pending pending;

        try
        {
            msg = new eldbus.Message(msg_hdl, false);
            pending = new eldbus.Pending(pending_hdl, false);
        }
        catch(Exception e)
        {
            Eina.Log.Error("Eldbus: could not convert Eldbus_Message_Cb parameters. Exception: " + e.ToString());
            return;
        }

        try
        {
            dlgt(msg, pending);
        }
        catch(Exception e)
        {
            Eina.Log.Error("Eldbus: Eldbus_Message_Cb delegate error. Exception: " + e.ToString());
        }
    }

    private static Eldbus_Message_Cb message_cb_wrapper = null;
    private static Eina.Error NullHandleError = 0;
}

}


