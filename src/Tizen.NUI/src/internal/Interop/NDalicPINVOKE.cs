/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System;
using System.ComponentModel;

namespace Tizen.NUI
{
    class NDalicPINVOKE
    {
        public const string Lib = "libdali2-csharp-binder.so";
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

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "SWIGRegisterExceptionCallbacks_NDalic")]
            public static extern void SWIGRegisterExceptionCallbacksNDalic(
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

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "SWIGRegisterExceptionArgumentCallbacks_NDalic")]
            public static extern void SWIGRegisterExceptionArgumentCallbacksNDalic(
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
                SWIGRegisterExceptionCallbacksNDalic(
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

                SWIGRegisterExceptionArgumentCallbacksNDalic(
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
            private static readonly object exceptionPendingLock = new object();

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
                lock (exceptionPendingLock)
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
                        lock (exceptionPendingLock)
                        {
                            numExceptionsPending--;
                        }
                    }
                }
                if (e == null)
                {
                    e = new global::System.ApplicationException($"FATAL: Exception e is null, numExceptionsPending : {numExceptionsPending}");
                }
                return e;
            }
        }
        public class SWIGStringHelper
        {
            /// <since_tizen> 3 </since_tizen>
            public delegate string SWIGStringDelegate(string message);
            static SWIGStringDelegate stringDelegate = new SWIGStringDelegate(CreateString);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "SWIGRegisterStringCallback_NDalic")]
            public static extern void SWIGRegisterStringCallbackNDalic(SWIGStringDelegate stringDelegate);
            static string CreateString(string cString)
            {
                return cString;
            }
            static SWIGStringHelper()
            {
                SWIGRegisterStringCallbackNDalic(stringDelegate);
            }

            [Obsolete("Please do not use! Deprecated in API9, will be removed in API11! Please delete this if currently used!")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static void RegistCallback()
            {
                //do nothing!
            }
        }
        static protected SWIGStringHelper swigStringHelper = new SWIGStringHelper();
        static NDalicPINVOKE()
        {
        }

        [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_BaseHandle")]
        public static extern void DeleteBaseHandle(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_SWIGUpcast")]
        public static extern global::System.IntPtr ApplicationUpcast(global::System.IntPtr jarg1);

        [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_New__MANUAL_4")]
        public static extern global::System.IntPtr ApplicationNewManual4(int jarg1, string jarg2, string jarg3, int jarg4);

        [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_New_WithWindowSizePosition")]
        public static extern global::System.IntPtr ApplicationNewWithWindowSizePosition(int jarg1, string jarg2, string jarg3, int jarg4, global::System.Runtime.InteropServices.HandleRef jarg5);

        [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_MainLoop__SWIG_0")]
        public static extern void ApplicationMainLoop(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_InitSignal")]
        public static extern global::System.IntPtr ApplicationInitSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_TerminateSignal")]
        public static extern global::System.IntPtr ApplicationTerminateSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_PauseSignal")]
        public static extern global::System.IntPtr ApplicationPauseSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_ResumeSignal")]
        public static extern global::System.IntPtr ApplicationResumeSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_ResetSignal")]
        public static extern global::System.IntPtr ApplicationResetSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_AppControlSignal")]
        public static extern global::System.IntPtr ApplicationAppControlSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_LanguageChangedSignal")]
        public static extern global::System.IntPtr ApplicationLanguageChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_RegionChangedSignal")]
        public static extern global::System.IntPtr ApplicationRegionChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_LowBatterySignal")]
        public static extern global::System.IntPtr ApplicationLowBatterySignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_LowMemorySignal")]
        public static extern global::System.IntPtr ApplicationLowMemorySignal(global::System.Runtime.InteropServices.HandleRef jarg1);


        [Obsolete("Please do not use this! Deprecated in API9, will be removed in API11! Please use NDalicPINVOKE.DeleteBaseHandle(...) instead!")]
        [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_BaseHandle")]
        public static extern void delete_BaseHandle(global::System.Runtime.InteropServices.HandleRef jarg1);
    }
}
