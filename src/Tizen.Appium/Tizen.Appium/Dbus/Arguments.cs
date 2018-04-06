using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Tizen.Appium.Dbus
{
    internal class Arguments
    {
        Dictionary<string, object> _args = new Dictionary<string, object>();

        internal Arguments()
        {
        }

        public object this[string key]
        {
            get
            {
                try
                {
                    return _args[key];
                }
                catch (Exception e)
                {
                    Log.Debug(e.ToString());
                    return null;
                }
            }
        }

        public object this[int index]
        {
            get
            {
                try
                {
                    return _args.ElementAt(index).Value;
                }
                catch (Exception e)
                {
                    Log.Debug(e.ToString());
                    return null;
                }
            }
        }

        public void SetArgument(string key, object obj)
        {
            _args[key] = obj;
        }

        public void RemoveArgument(string key)
        {
            _args.Remove(key);
        }

        public void ResetArguments()
        {
            _args.Clear();
        }

        public override string ToString()
        {
            var s = "{";
            foreach (var p in _args)
            {
                s += String.Format("{{{0}: {1}}}, ", p.Key, p.Value);
            }
            s += "}";

            return s;
        }

        public static Arguments MessageToArguments(IntPtr message, params string[] parameters)
        {
            Log.Debug("required args: " + parameters);

            Arguments args = new Arguments();

            Interop.DbusMessageIter iter = new Interop.DbusMessageIter();
            Interop.Edbus.dbus_message_iter_init(message, ref iter);

            for (int i = 0; i < parameters.Length; i++)
            {
                var type = Interop.Edbus.dbus_message_iter_get_arg_type(ref iter);
                if (type == DbusType.String)
                {
                    IntPtr ptr;
                    Interop.Edbus.dbus_message_iter_get_basic(ref iter, out ptr);
                    args.SetArgument(parameters[i], Marshal.PtrToStringAnsi(ptr));
                }
                else if (type == DbusType.Int)
                {
                    IntPtr ptr;
                    Interop.Edbus.dbus_message_iter_get_basic(ref iter, out ptr);
                    args.SetArgument(parameters[i], (int)ptr);
                }
                else if (type == DbusType.Boolean)
                {
                    IntPtr ptr;
                    Interop.Edbus.dbus_message_iter_get_basic(ref iter, out ptr);
                    args.SetArgument(parameters[i], Convert.ToBoolean((int)ptr));
                }

                if (Interop.Edbus.dbus_message_iter_has_next(ref iter))
                {
                    Interop.Edbus.dbus_message_iter_next(ref iter);
                }
                else
                {
                    Log.Debug("No more items in the message");
                    break;
                }
            }

            return args;
        }

        public static IntPtr ArgumentsToReturnMessage(IntPtr message, Arguments args, string sig)
        {
            Interop.DbusMessageIter iter = new Interop.DbusMessageIter();
            Interop.Edbus.dbus_message_iter_init(message, ref iter);

            IntPtr reply = Interop.Edbus.dbus_message_new_method_return(message);
            Interop.Edbus.dbus_message_iter_init_append(reply, ref iter);

            AppendArgumentsToMessage(ref iter, sig, args);

            return reply;
        }

        public static IntPtr ArgumentsToSignalMessage(string signalName, Arguments args, string sig)
        {
            IntPtr message = Interop.Edbus.dbus_message_new_signal(DbusNames.ObjectPath, DbusNames.InterfaceName, signalName);
            Interop.DbusMessageIter iter = new Interop.DbusMessageIter();
            Interop.Edbus.dbus_message_iter_init_append(message, ref iter);

            AppendArgumentsToMessage(ref iter, sig, args);

            return message;
        }

        static void AppendArgumentsToMessage(ref Interop.DbusMessageIter iter, string sig, Arguments args)
        {
            int i = 0;
            foreach (char type in sig)
            {
                if (type == DbusTypeAsString.Int)
                {
                    IntPtr arg = new IntPtr((int)args[i]);
                    Interop.Edbus.dbus_message_iter_append_basic(ref iter, DbusType.Int, ref arg);
                }
                else if (type == DbusTypeAsString.String)
                {
                    IntPtr arg = Marshal.StringToHGlobalAnsi((string)args[i]);
                    Interop.Edbus.dbus_message_iter_append_basic(ref iter, DbusType.String, ref arg);
                }
                else if (type == DbusType.Boolean)
                {
                    IntPtr arg = new IntPtr(Convert.ToInt32((bool)args[i]));
                    Interop.Edbus.dbus_message_iter_append_basic(ref iter, DbusType.Boolean, ref arg);
                }

                if (args[i] != null)
                {
                    i++;
                }
                else
                {
                    Log.Debug("No more items in the arguments");
                    break;
                }
            }
        }
    }
}
