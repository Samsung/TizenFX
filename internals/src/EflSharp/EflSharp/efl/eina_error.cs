#pragma warning disable 1591

using System;
using System.Runtime.InteropServices;

namespace Eina
{

public struct Error : IComparable<Error>
{
    int code;

    public string Message
    {
        get { return MsgGet(this); }
    }

    public static Error UNHANDLED_EXCEPTION;

    public static Error NO_ERROR = new Error(0);
    public static Error EPERM = new Error(1);
    public static Error ENOENT = new Error(2);
    public static Error ECANCELED = new Error(125);

    public Error(int value)
    {
        code = value;
    }

    static public implicit operator Error(int val)
    {
        return new Error(val);
    }

    static public implicit operator int(Error error)
    {
        return error.code;
    }

    public int CompareTo(Error err)
    {
        return code.CompareTo(err.code);
    }

    public override string ToString()
    {
        return "Eina.Error(" + code + ")";
    }

    static Error()
    {
        UNHANDLED_EXCEPTION = eina_error_msg_register("Unhandled C# exception occurred.");
    }

    [DllImport(efl.Libs.Eina)] static extern Error eina_error_msg_register(string msg);
    [DllImport(efl.Libs.Eina)] static extern Error eina_error_get();
    [DllImport(efl.Libs.Eina)] static extern void eina_error_set(Error error);
    [DllImport(efl.Libs.Eina)] static extern IntPtr eina_error_msg_get(Error error);

    public static void Set(Error error)
    {
        eina_error_set(error);
    }

    public static Error Get()
    {
        return eina_error_get();
    }

    public static String MsgGet(Error error)
    {
        IntPtr cstr = eina_error_msg_get(error);
        return Eina.StringConversion.NativeUtf8ToManagedString(cstr);
    }

    /// <summary>Raises an exception if an unhandled exception occurred before switching
    /// back to the native code. For example, in an event handler.</summary>
    public static void RaiseIfUnhandledException()
    {
        Error e = Get();
        if (e == UNHANDLED_EXCEPTION)
        {
            Clear();
            Raise(e);
        }
    }

    public static void Raise(Error e)
    {
        if (e != 0)
        {
            throw (new Efl.EflException(MsgGet(e)));
        }
    }

    public static void Clear()
    {
        Set(0);
    }

    public static Error Register(string msg)
    {
        return eina_error_msg_register(msg);
    }
}

}
