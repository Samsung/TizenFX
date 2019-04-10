using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        protected class SWIGExceptionHelper
        {

            /// <since_tizen> 3 </since_tizen>
            public delegate void ExceptionDelegate(string message);
            /// <since_tizen> 3 </since_tizen>
            public delegate void ExceptionArgumentDelegate(string message, string paramName);

            static ExceptionDelegate applicationDelegate = new ExceptionDelegate(SetPendingApplicationException);
            static ExceptionDelegate arithmeticDelegate = new ExceptionDelegate(SetPendingArithmeticException);
            static ExceptionDelegate divideByZeroDelegate = new ExceptionDelegate(SetPendingDivideByZeroException);
            static ExceptionDelegate indexOutOfRangeDelegate = new ExceptionDelegate(SetPendingIndexOutOfRangeException);
            static ExceptionDelegate invalidCastDelegate = new ExceptionDelegate(SetPendingInvalidCastException);
            static ExceptionDelegate invalidOperationDelegate = new ExceptionDelegate(SetPendingInvalidOperationException);
            static ExceptionDelegate ioDelegate = new ExceptionDelegate(SetPendingIOException);
            static ExceptionDelegate nullReferenceDelegate = new ExceptionDelegate(SetPendingNullReferenceException);
            static ExceptionDelegate outOfMemoryDelegate = new ExceptionDelegate(SetPendingOutOfMemoryException);
            static ExceptionDelegate overflowDelegate = new ExceptionDelegate(SetPendingOverflowException);
            static ExceptionDelegate systemDelegate = new ExceptionDelegate(SetPendingSystemException);

            static ExceptionArgumentDelegate argumentDelegate = new ExceptionArgumentDelegate(SetPendingArgumentException);
            static ExceptionArgumentDelegate argumentNullDelegate = new ExceptionArgumentDelegate(SetPendingArgumentNullException);
            static ExceptionArgumentDelegate argumentOutOfRangeDelegate = new ExceptionArgumentDelegate(SetPendingArgumentOutOfRangeException);

            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "SWIGRegisterExceptionCallbacks_NDalic")]
            public static extern void SWIGRegisterExceptionCallbacks_NDalic(
                                        ExceptionDelegate applicationDelegate,
                                        ExceptionDelegate arithmeticDelegate,
                                        ExceptionDelegate divideByZeroDelegate,
                                        ExceptionDelegate indexOutOfRangeDelegate,
                                        ExceptionDelegate invalidCastDelegate,
                                        ExceptionDelegate invalidOperationDelegate,
                                        ExceptionDelegate ioDelegate,
                                        ExceptionDelegate nullReferenceDelegate,
                                        ExceptionDelegate outOfMemoryDelegate,
                                        ExceptionDelegate overflowDelegate,
                                        ExceptionDelegate systemExceptionDelegate);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "SWIGRegisterExceptionArgumentCallbacks_NDalic")]
            public static extern void SWIGRegisterExceptionCallbacksArgument_NDalic(
                                        ExceptionArgumentDelegate argumentDelegate,
                                        ExceptionArgumentDelegate argumentNullDelegate,
                                        ExceptionArgumentDelegate argumentOutOfRangeDelegate);


            static void SetPendingApplicationException(string message)
            {
                SWIGPendingException.Set(new global::System.ApplicationException(message, SWIGPendingException.Retrieve()));
            }
            static void SetPendingArithmeticException(string message)
            {
                SWIGPendingException.Set(new global::System.ArithmeticException(message, SWIGPendingException.Retrieve()));
            }
            static void SetPendingDivideByZeroException(string message)
            {
                SWIGPendingException.Set(new global::System.DivideByZeroException(message, SWIGPendingException.Retrieve()));
            }
            static void SetPendingIndexOutOfRangeException(string message)
            {
                SWIGPendingException.Set(new global::System.IndexOutOfRangeException(message, SWIGPendingException.Retrieve()));
            }
            static void SetPendingInvalidCastException(string message)
            {
                SWIGPendingException.Set(new global::System.InvalidCastException(message, SWIGPendingException.Retrieve()));
            }
            static void SetPendingInvalidOperationException(string message)
            {
                SWIGPendingException.Set(new global::System.InvalidOperationException(message, SWIGPendingException.Retrieve()));
            }
            static void SetPendingIOException(string message)
            {
                SWIGPendingException.Set(new global::System.IO.IOException(message, SWIGPendingException.Retrieve()));
            }
            static void SetPendingNullReferenceException(string message)
            {
                SWIGPendingException.Set(new global::System.NullReferenceException(message, SWIGPendingException.Retrieve()));
            }
            static void SetPendingOutOfMemoryException(string message)
            {
                SWIGPendingException.Set(new global::System.OutOfMemoryException(message, SWIGPendingException.Retrieve()));
            }
            static void SetPendingOverflowException(string message)
            {
                SWIGPendingException.Set(new global::System.OverflowException(message, SWIGPendingException.Retrieve()));
            }
            static void SetPendingSystemException(string message)
            {
                SWIGPendingException.Set(new global::System.SystemException(message, SWIGPendingException.Retrieve()));
            }

            static void SetPendingArgumentException(string message, string paramName)
            {
                SWIGPendingException.Set(new global::System.ArgumentException(message, paramName, SWIGPendingException.Retrieve()));
            }
            static void SetPendingArgumentNullException(string message, string paramName)
            {
                global::System.Exception e = SWIGPendingException.Retrieve();
                if (e != null) message = message + " Inner Exception: " + e.Message;
                SWIGPendingException.Set(new global::System.ArgumentNullException(message, paramName));
            }
            static void SetPendingArgumentOutOfRangeException(string message, string paramName)
            {
                global::System.Exception e = SWIGPendingException.Retrieve();
                if (e != null) message = message + " Inner Exception: " + e.Message;
                SWIGPendingException.Set(new global::System.ArgumentOutOfRangeException(paramName, message));
            }

            static SWIGExceptionHelper()
            {
                SWIGRegisterExceptionCallbacks_NDalic(
                                          applicationDelegate,
                                          arithmeticDelegate,
                                          divideByZeroDelegate,
                                          indexOutOfRangeDelegate,
                                          invalidCastDelegate,
                                          invalidOperationDelegate,
                                          ioDelegate,
                                          nullReferenceDelegate,
                                          outOfMemoryDelegate,
                                          overflowDelegate,
                                          systemDelegate);

                SWIGRegisterExceptionCallbacksArgument_NDalic(
                                          argumentDelegate,
                                          argumentNullDelegate,
                                          argumentOutOfRangeDelegate);
            }
        }

        protected static SWIGExceptionHelper swigExceptionHelper = new SWIGExceptionHelper();

        /// <since_tizen> 3 </since_tizen>
        public class SWIGPendingException
        {
            [global::System.ThreadStatic]
            private static global::System.Exception pendingException = null;
            private static int numExceptionsPending = 0;

            /// <since_tizen> 3 </since_tizen>
            public static bool Pending
            {
                get
                {
                    bool pending = false;
                    if (numExceptionsPending > 0)
                        if (pendingException != null)
                            pending = true;
                    return pending;
                }
            }

            /// <since_tizen> 3 </since_tizen>
            public static void Set(global::System.Exception e)
            {
                if (pendingException != null)
                    throw new global::System.ApplicationException("FATAL: An earlier pending exception from unmanaged code was missed and thus not thrown (" + pendingException.ToString() + ")", e);
                pendingException = e;
                lock (typeof(NDalicPINVOKE))
                {
                    numExceptionsPending++;
                }
            }

            /// <since_tizen> 3 </since_tizen>
            public static global::System.Exception Retrieve()
            {
                global::System.Exception e = null;
                if (numExceptionsPending > 0)
                {
                    if (pendingException != null)
                    {
                        e = pendingException;
                        pendingException = null;
                        lock (typeof(NDalicPINVOKE))
                        {
                            numExceptionsPending--;
                        }
                    }
                }
                return e;
            }
        }


        protected class SWIGStringHelper
        {

            /// <since_tizen> 3 </since_tizen>
            public delegate string SWIGStringDelegate(string message);
            static SWIGStringDelegate stringDelegate = new SWIGStringDelegate(CreateString);

            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "SWIGRegisterStringCallback_NDalic")]
            public static extern void SWIGRegisterStringCallback_NDalic(SWIGStringDelegate stringDelegate);


            static string CreateString(string cString)
            {
                return cString;
            }

            static SWIGStringHelper()
            {
                SWIGRegisterStringCallback_NDalic(stringDelegate);
            }
        }

        static protected SWIGStringHelper swigStringHelper = new SWIGStringHelper();

        
    }
}
