/*
 * Copyright(c) 2018 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI {

class NDalicPINVOKE {

  protected class SWIGExceptionHelper {

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

    [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="SWIGRegisterExceptionCallbacks_NDalic")]
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

    [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="SWIGRegisterExceptionArgumentCallbacks_NDalic")]
    public static extern void SWIGRegisterExceptionCallbacksArgument_NDalic(
                                ExceptionArgumentDelegate argumentDelegate,
                                ExceptionArgumentDelegate argumentNullDelegate,
                                ExceptionArgumentDelegate argumentOutOfRangeDelegate);

    static void SetPendingApplicationException(string message) {
      SWIGPendingException.Set(new global::System.ApplicationException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingArithmeticException(string message) {
      SWIGPendingException.Set(new global::System.ArithmeticException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingDivideByZeroException(string message) {
      SWIGPendingException.Set(new global::System.DivideByZeroException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingIndexOutOfRangeException(string message) {
      SWIGPendingException.Set(new global::System.IndexOutOfRangeException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingInvalidCastException(string message) {
      SWIGPendingException.Set(new global::System.InvalidCastException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingInvalidOperationException(string message) {
      SWIGPendingException.Set(new global::System.InvalidOperationException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingIOException(string message) {
      SWIGPendingException.Set(new global::System.IO.IOException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingNullReferenceException(string message) {
      SWIGPendingException.Set(new global::System.NullReferenceException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingOutOfMemoryException(string message) {
      SWIGPendingException.Set(new global::System.OutOfMemoryException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingOverflowException(string message) {
      SWIGPendingException.Set(new global::System.OverflowException(message, SWIGPendingException.Retrieve()));
    }
    static void SetPendingSystemException(string message) {
      SWIGPendingException.Set(new global::System.SystemException(message, SWIGPendingException.Retrieve()));
    }

    static void SetPendingArgumentException(string message, string paramName) {
      SWIGPendingException.Set(new global::System.ArgumentException(message, paramName, SWIGPendingException.Retrieve()));
    }
    static void SetPendingArgumentNullException(string message, string paramName) {
      global::System.Exception e = SWIGPendingException.Retrieve();
      if (e != null) message = message + " Inner Exception: " + e.Message;
      SWIGPendingException.Set(new global::System.ArgumentNullException(message, paramName));
    }
    static void SetPendingArgumentOutOfRangeException(string message, string paramName) {
      global::System.Exception e = SWIGPendingException.Retrieve();
      if (e != null) message = message + " Inner Exception: " + e.Message;
      SWIGPendingException.Set(new global::System.ArgumentOutOfRangeException(paramName, message));
    }

    static SWIGExceptionHelper() {
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
  public class SWIGPendingException {
    [global::System.ThreadStatic]
    private static global::System.Exception pendingException = null;
    private static int numExceptionsPending = 0;

    /// <since_tizen> 3 </since_tizen>
    public static bool Pending {
      get {
        bool pending = false;
        if (numExceptionsPending > 0)
          if (pendingException != null)
            pending = true;
        return pending;
      }
    }

    /// <since_tizen> 3 </since_tizen>
    public static void Set(global::System.Exception e) {
      if (pendingException != null)
        throw new global::System.ApplicationException("FATAL: An earlier pending exception from unmanaged code was missed and thus not thrown (" + pendingException.ToString() + ")", e);
      pendingException = e;
      lock(typeof(NDalicPINVOKE)) {
        numExceptionsPending++;
      }
    }

    /// <since_tizen> 3 </since_tizen>
    public static global::System.Exception Retrieve() {
      global::System.Exception e = null;
      if (numExceptionsPending > 0) {
        if (pendingException != null) {
          e = pendingException;
          pendingException = null;
          lock(typeof(NDalicPINVOKE)) {
            numExceptionsPending--;
          }
        }
      }
      return e;
    }
  }


  protected class SWIGStringHelper {

    /// <since_tizen> 3 </since_tizen>
    public delegate string SWIGStringDelegate(string message);
    static SWIGStringDelegate stringDelegate = new SWIGStringDelegate(CreateString);

    [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="SWIGRegisterStringCallback_NDalic")]
    public static extern void SWIGRegisterStringCallback_NDalic(SWIGStringDelegate stringDelegate);

    static string CreateString(string cString) {
      return cString;
    }

    static SWIGStringHelper() {
      SWIGRegisterStringCallback_NDalic(stringDelegate);
    }
  }

  static protected SWIGStringHelper swigStringHelper = new SWIGStringHelper();


  static NDalicPINVOKE() {
  }


  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_floatp")]
  public static extern global::System.IntPtr new_floatp();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_floatp")]
  public static extern void delete_floatp(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_floatp_assign")]
  public static extern void floatp_assign(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_floatp_value")]
  public static extern float floatp_value(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_floatp_cast")]
  public static extern global::System.IntPtr floatp_cast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_floatp_frompointer")]
  public static extern global::System.IntPtr floatp_frompointer(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_intp")]
  public static extern global::System.IntPtr new_intp();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_intp")]
  public static extern void delete_intp(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_intp_assign")]
  public static extern void intp_assign(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_intp_value")]
  public static extern int intp_value(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_intp_cast")]
  public static extern global::System.IntPtr intp_cast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_intp_frompointer")]
  public static extern global::System.IntPtr intp_frompointer(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_doublep")]
  public static extern global::System.IntPtr new_doublep();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_doublep")]
  public static extern void delete_doublep(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_doublep_assign")]
  public static extern void doublep_assign(global::System.Runtime.InteropServices.HandleRef jarg1, double jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_doublep_value")]
  public static extern double doublep_value(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_doublep_cast")]
  public static extern global::System.IntPtr doublep_cast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_doublep_frompointer")]
  public static extern global::System.IntPtr doublep_frompointer(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_uintp")]
  public static extern global::System.IntPtr new_uintp();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_uintp")]
  public static extern void delete_uintp(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_uintp_assign")]
  public static extern void uintp_assign(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_uintp_value")]
  public static extern uint uintp_value(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_uintp_cast")]
  public static extern global::System.IntPtr uintp_cast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_uintp_frompointer")]
  public static extern global::System.IntPtr uintp_frompointer(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ushortp")]
  public static extern global::System.IntPtr new_ushortp();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ushortp")]
  public static extern void delete_ushortp(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ushortp_assign")]
  public static extern void ushortp_assign(global::System.Runtime.InteropServices.HandleRef jarg1, ushort jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ushortp_value")]
  public static extern ushort ushortp_value(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ushortp_cast")]
  public static extern global::System.IntPtr ushortp_cast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ushortp_frompointer")]
  public static extern global::System.IntPtr ushortp_frompointer(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_int_to_uint")]
  public static extern uint int_to_uint(int jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RefObject_Reference")]
  public static extern void RefObject_Reference(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RefObject_Unreference")]
  public static extern void RefObject_Unreference(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RefObject_ReferenceCount")]
  public static extern int RefObject_ReferenceCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Any__SWIG_0")]
  public static extern global::System.IntPtr new_Any__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Any")]
  public static extern void delete_Any(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Any_AssertAlways")]
  public static extern void Any_AssertAlways(string jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Any__SWIG_2")]
  public static extern global::System.IntPtr new_Any__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Any_Assign")]
  public static extern global::System.IntPtr Any_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Any_GetType")]
  public static extern global::System.IntPtr Any_GetType(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Any_Empty")]
  public static extern bool Any_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Any_AnyContainerBase")]
  public static extern global::System.IntPtr new_Any_AnyContainerBase(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Any_AnyContainerBase_GetType")]
  public static extern global::System.IntPtr Any_AnyContainerBase_GetType(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Any_AnyContainerBase_mType_get")]
  public static extern global::System.IntPtr Any_AnyContainerBase_mType_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Any_AnyContainerBase_mCloneFunc_set")]
  public static extern void Any_AnyContainerBase_mCloneFunc_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Any_AnyContainerBase_mCloneFunc_get")]
  public static extern global::System.IntPtr Any_AnyContainerBase_mCloneFunc_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Any_AnyContainerBase_mDeleteFunc_set")]
  public static extern void Any_AnyContainerBase_mDeleteFunc_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Any_AnyContainerBase_mDeleteFunc_get")]
  public static extern global::System.IntPtr Any_AnyContainerBase_mDeleteFunc_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Any_AnyContainerBase")]
  public static extern void delete_Any_AnyContainerBase(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Any_mContainer_set")]
  public static extern void Any_mContainer_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Any_mContainer_get")]
  public static extern global::System.IntPtr Any_mContainer_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_DaliAssertMessage")]
  public static extern void DaliAssertMessage(string jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_DaliException")]
  public static extern global::System.IntPtr new_DaliException(string jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_DaliException_location_set")]
  public static extern void DaliException_location_set(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_DaliException_location_get")]
  public static extern string DaliException_location_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_DaliException_condition_set")]
  public static extern void DaliException_condition_set(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_DaliException_condition_get")]
  public static extern string DaliException_condition_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_DaliException")]
  public static extern void delete_DaliException(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Vector2__SWIG_0")]
  public static extern global::System.IntPtr new_Vector2__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Vector2__SWIG_1")]
  public static extern global::System.IntPtr new_Vector2__SWIG_1(float jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Vector2__SWIG_2")]
  public static extern global::System.IntPtr new_Vector2__SWIG_2([global::System.Runtime.InteropServices.In, global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPArray)]float[] jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Vector2__SWIG_3")]
  public static extern global::System.IntPtr new_Vector2__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Vector2__SWIG_4")]
  public static extern global::System.IntPtr new_Vector2__SWIG_4(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector2_ONE_get")]
  public static extern global::System.IntPtr Vector2_ONE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector2_XAXIS_get")]
  public static extern global::System.IntPtr Vector2_XAXIS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector2_YAXIS_get")]
  public static extern global::System.IntPtr Vector2_YAXIS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector2_NEGATIVE_XAXIS_get")]
  public static extern global::System.IntPtr Vector2_NEGATIVE_XAXIS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector2_NEGATIVE_YAXIS_get")]
  public static extern global::System.IntPtr Vector2_NEGATIVE_YAXIS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector2_ZERO_get")]
  public static extern global::System.IntPtr Vector2_ZERO_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector2_Assign__SWIG_0")]
  public static extern global::System.IntPtr Vector2_Assign__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, [global::System.Runtime.InteropServices.In, global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPArray)]float[] jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector2_Assign__SWIG_1")]
  public static extern global::System.IntPtr Vector2_Assign__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector2_Assign__SWIG_2")]
  public static extern global::System.IntPtr Vector2_Assign__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector2_Add")]
  public static extern global::System.IntPtr Vector2_Add(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector2_AddAssign")]
  public static extern global::System.IntPtr Vector2_AddAssign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector2_Subtract__SWIG_0")]
  public static extern global::System.IntPtr Vector2_Subtract__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector2_SubtractAssign")]
  public static extern global::System.IntPtr Vector2_SubtractAssign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector2_Multiply__SWIG_0")]
  public static extern global::System.IntPtr Vector2_Multiply__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector2_Multiply__SWIG_1")]
  public static extern global::System.IntPtr Vector2_Multiply__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector2_MultiplyAssign__SWIG_0")]
  public static extern global::System.IntPtr Vector2_MultiplyAssign__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector2_MultiplyAssign__SWIG_1")]
  public static extern global::System.IntPtr Vector2_MultiplyAssign__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector2_Divide__SWIG_0")]
  public static extern global::System.IntPtr Vector2_Divide__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector2_Divide__SWIG_1")]
  public static extern global::System.IntPtr Vector2_Divide__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector2_DivideAssign__SWIG_0")]
  public static extern global::System.IntPtr Vector2_DivideAssign__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector2_DivideAssign__SWIG_1")]
  public static extern global::System.IntPtr Vector2_DivideAssign__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector2_Subtract__SWIG_1")]
  public static extern global::System.IntPtr Vector2_Subtract__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector2_EqualTo")]
  public static extern bool Vector2_EqualTo(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector2_NotEqualTo")]
  public static extern bool Vector2_NotEqualTo(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector2_ValueOfIndex__SWIG_0")]
  public static extern float Vector2_ValueOfIndex__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector2_Length")]
  public static extern float Vector2_Length(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector2_LengthSquared")]
  public static extern float Vector2_LengthSquared(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector2_Normalize")]
  public static extern void Vector2_Normalize(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector2_Clamp")]
  public static extern void Vector2_Clamp(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector2_AsFloat__SWIG_0")]
  public static extern global::System.IntPtr Vector2_AsFloat__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector2_X_set")]
  public static extern void Vector2_X_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector2_X_get")]
  public static extern float Vector2_X_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector2_Width_set")]
  public static extern void Vector2_Width_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector2_Width_get")]
  public static extern float Vector2_Width_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector2_Y_set")]
  public static extern void Vector2_Y_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector2_Y_get")]
  public static extern float Vector2_Y_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector2_Height_set")]
  public static extern void Vector2_Height_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector2_Height_get")]
  public static extern float Vector2_Height_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Vector2")]
  public static extern void delete_Vector2(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Min__SWIG_0")]
  public static extern global::System.IntPtr Min__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Max__SWIG_0")]
  public static extern global::System.IntPtr Max__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Clamp__SWIG_0")]
  public static extern global::System.IntPtr Clamp__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Vector3__SWIG_0")]
  public static extern global::System.IntPtr new_Vector3__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Vector3__SWIG_1")]
  public static extern global::System.IntPtr new_Vector3__SWIG_1(float jarg1, float jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Vector3__SWIG_2")]
  public static extern global::System.IntPtr new_Vector3__SWIG_2([global::System.Runtime.InteropServices.In, global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPArray)]float[] jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Vector3__SWIG_3")]
  public static extern global::System.IntPtr new_Vector3__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Vector3__SWIG_4")]
  public static extern global::System.IntPtr new_Vector3__SWIG_4(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_ONE_get")]
  public static extern global::System.IntPtr Vector3_ONE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_XAXIS_get")]
  public static extern global::System.IntPtr Vector3_XAXIS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_YAXIS_get")]
  public static extern global::System.IntPtr Vector3_YAXIS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_ZAXIS_get")]
  public static extern global::System.IntPtr Vector3_ZAXIS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_NEGATIVE_XAXIS_get")]
  public static extern global::System.IntPtr Vector3_NEGATIVE_XAXIS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_NEGATIVE_YAXIS_get")]
  public static extern global::System.IntPtr Vector3_NEGATIVE_YAXIS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_NEGATIVE_ZAXIS_get")]
  public static extern global::System.IntPtr Vector3_NEGATIVE_ZAXIS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_ZERO_get")]
  public static extern global::System.IntPtr Vector3_ZERO_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_Assign__SWIG_0")]
  public static extern global::System.IntPtr Vector3_Assign__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, [global::System.Runtime.InteropServices.In, global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPArray)]float[] jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_Assign__SWIG_1")]
  public static extern global::System.IntPtr Vector3_Assign__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_Assign__SWIG_2")]
  public static extern global::System.IntPtr Vector3_Assign__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_Add")]
  public static extern global::System.IntPtr Vector3_Add(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_AddAssign")]
  public static extern global::System.IntPtr Vector3_AddAssign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_Subtract__SWIG_0")]
  public static extern global::System.IntPtr Vector3_Subtract__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_SubtractAssign")]
  public static extern global::System.IntPtr Vector3_SubtractAssign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_Multiply__SWIG_0")]
  public static extern global::System.IntPtr Vector3_Multiply__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_Multiply__SWIG_1")]
  public static extern global::System.IntPtr Vector3_Multiply__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_MultiplyAssign__SWIG_0")]
  public static extern global::System.IntPtr Vector3_MultiplyAssign__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_MultiplyAssign__SWIG_1")]
  public static extern global::System.IntPtr Vector3_MultiplyAssign__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_MultiplyAssign__SWIG_2")]
  public static extern global::System.IntPtr Vector3_MultiplyAssign__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_Divide__SWIG_0")]
  public static extern global::System.IntPtr Vector3_Divide__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_Divide__SWIG_1")]
  public static extern global::System.IntPtr Vector3_Divide__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_DivideAssign__SWIG_0")]
  public static extern global::System.IntPtr Vector3_DivideAssign__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_DivideAssign__SWIG_1")]
  public static extern global::System.IntPtr Vector3_DivideAssign__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_Subtract__SWIG_1")]
  public static extern global::System.IntPtr Vector3_Subtract__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_EqualTo")]
  public static extern bool Vector3_EqualTo(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_NotEqualTo")]
  public static extern bool Vector3_NotEqualTo(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_ValueOfIndex__SWIG_0")]
  public static extern float Vector3_ValueOfIndex__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_Dot")]
  public static extern float Vector3_Dot(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_Cross")]
  public static extern global::System.IntPtr Vector3_Cross(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_Length")]
  public static extern float Vector3_Length(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_LengthSquared")]
  public static extern float Vector3_LengthSquared(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_Normalize")]
  public static extern void Vector3_Normalize(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_Clamp")]
  public static extern void Vector3_Clamp(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_AsFloat__SWIG_0")]
  public static extern global::System.IntPtr Vector3_AsFloat__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_GetVectorXY__SWIG_0")]
  public static extern global::System.IntPtr Vector3_GetVectorXY__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_GetVectorYZ__SWIG_0")]
  public static extern global::System.IntPtr Vector3_GetVectorYZ__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_X_set")]
  public static extern void Vector3_X_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_X_get")]
  public static extern float Vector3_X_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_Width_set")]
  public static extern void Vector3_Width_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_Width_get")]
  public static extern float Vector3_Width_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_r_set")]
  public static extern void Vector3_r_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_r_get")]
  public static extern float Vector3_r_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_Y_set")]
  public static extern void Vector3_Y_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_Y_get")]
  public static extern float Vector3_Y_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_Height_set")]
  public static extern void Vector3_Height_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_Height_get")]
  public static extern float Vector3_Height_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_g_set")]
  public static extern void Vector3_g_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_g_get")]
  public static extern float Vector3_g_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_Z_set")]
  public static extern void Vector3_Z_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_Z_get")]
  public static extern float Vector3_Z_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_Depth_set")]
  public static extern void Vector3_Depth_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_Depth_get")]
  public static extern float Vector3_Depth_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_b_set")]
  public static extern void Vector3_b_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector3_b_get")]
  public static extern float Vector3_b_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Vector3")]
  public static extern void delete_Vector3(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Min__SWIG_1")]
  public static extern global::System.IntPtr Min__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Max__SWIG_1")]
  public static extern global::System.IntPtr Max__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Clamp__SWIG_1")]
  public static extern global::System.IntPtr Clamp__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Vector4__SWIG_0")]
  public static extern global::System.IntPtr new_Vector4__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Vector4__SWIG_1")]
  public static extern global::System.IntPtr new_Vector4__SWIG_1(float jarg1, float jarg2, float jarg3, float jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Vector4__SWIG_2")]
  public static extern global::System.IntPtr new_Vector4__SWIG_2([global::System.Runtime.InteropServices.In, global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPArray)]float[] jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Vector4__SWIG_3")]
  public static extern global::System.IntPtr new_Vector4__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Vector4__SWIG_4")]
  public static extern global::System.IntPtr new_Vector4__SWIG_4(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_ONE_get")]
  public static extern global::System.IntPtr Vector4_ONE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_XAXIS_get")]
  public static extern global::System.IntPtr Vector4_XAXIS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_YAXIS_get")]
  public static extern global::System.IntPtr Vector4_YAXIS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_ZAXIS_get")]
  public static extern global::System.IntPtr Vector4_ZAXIS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_ZERO_get")]
  public static extern global::System.IntPtr Vector4_ZERO_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_Assign__SWIG_0")]
  public static extern global::System.IntPtr Vector4_Assign__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, [global::System.Runtime.InteropServices.In, global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPArray)]float[] jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_Assign__SWIG_1")]
  public static extern global::System.IntPtr Vector4_Assign__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_Assign__SWIG_2")]
  public static extern global::System.IntPtr Vector4_Assign__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_Add")]
  public static extern global::System.IntPtr Vector4_Add(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_AddAssign")]
  public static extern global::System.IntPtr Vector4_AddAssign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_Subtract__SWIG_0")]
  public static extern global::System.IntPtr Vector4_Subtract__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_SubtractAssign")]
  public static extern global::System.IntPtr Vector4_SubtractAssign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_Multiply__SWIG_0")]
  public static extern global::System.IntPtr Vector4_Multiply__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_Multiply__SWIG_1")]
  public static extern global::System.IntPtr Vector4_Multiply__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_MultiplyAssign__SWIG_0")]
  public static extern global::System.IntPtr Vector4_MultiplyAssign__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_MultiplyAssign__SWIG_1")]
  public static extern global::System.IntPtr Vector4_MultiplyAssign__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_Divide__SWIG_0")]
  public static extern global::System.IntPtr Vector4_Divide__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_Divide__SWIG_1")]
  public static extern global::System.IntPtr Vector4_Divide__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_DivideAssign__SWIG_0")]
  public static extern global::System.IntPtr Vector4_DivideAssign__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_DivideAssign__SWIG_1")]
  public static extern global::System.IntPtr Vector4_DivideAssign__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_Subtract__SWIG_1")]
  public static extern global::System.IntPtr Vector4_Subtract__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_EqualTo")]
  public static extern bool Vector4_EqualTo(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_NotEqualTo")]
  public static extern bool Vector4_NotEqualTo(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_ValueOfIndex__SWIG_0")]
  public static extern float Vector4_ValueOfIndex__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_Dot__SWIG_0")]
  public static extern float Vector4_Dot__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_Dot__SWIG_1")]
  public static extern float Vector4_Dot__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_Dot4")]
  public static extern float Vector4_Dot4(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_Cross")]
  public static extern global::System.IntPtr Vector4_Cross(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_Length")]
  public static extern float Vector4_Length(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_LengthSquared")]
  public static extern float Vector4_LengthSquared(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_Normalize")]
  public static extern void Vector4_Normalize(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_Clamp")]
  public static extern void Vector4_Clamp(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_AsFloat__SWIG_0")]
  public static extern global::System.IntPtr Vector4_AsFloat__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_X_set")]
  public static extern void Vector4_X_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_X_get")]
  public static extern float Vector4_X_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_r_set")]
  public static extern void Vector4_r_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_r_get")]
  public static extern float Vector4_r_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_s_set")]
  public static extern void Vector4_s_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_s_get")]
  public static extern float Vector4_s_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_Y_set")]
  public static extern void Vector4_Y_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_Y_get")]
  public static extern float Vector4_Y_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_g_set")]
  public static extern void Vector4_g_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_g_get")]
  public static extern float Vector4_g_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_t_set")]
  public static extern void Vector4_t_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_t_get")]
  public static extern float Vector4_t_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_Z_set")]
  public static extern void Vector4_Z_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_Z_get")]
  public static extern float Vector4_Z_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_b_set")]
  public static extern void Vector4_b_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_b_get")]
  public static extern float Vector4_b_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_p_set")]
  public static extern void Vector4_p_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_p_get")]
  public static extern float Vector4_p_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_W_set")]
  public static extern void Vector4_W_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_W_get")]
  public static extern float Vector4_W_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_a_set")]
  public static extern void Vector4_a_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_a_get")]
  public static extern float Vector4_a_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_q_set")]
  public static extern void Vector4_q_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Vector4_q_get")]
  public static extern float Vector4_q_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Vector4")]
  public static extern void delete_Vector4(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Min__SWIG_2")]
  public static extern global::System.IntPtr Min__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Max__SWIG_2")]
  public static extern global::System.IntPtr Max__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Clamp__SWIG_2")]
  public static extern global::System.IntPtr Clamp__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Uint16Pair__SWIG_0")]
  public static extern global::System.IntPtr new_Uint16Pair__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Uint16Pair__SWIG_1")]
  public static extern global::System.IntPtr new_Uint16Pair__SWIG_1(uint jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Uint16Pair__SWIG_2")]
  public static extern global::System.IntPtr new_Uint16Pair__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Uint16Pair_SetWidth")]
  public static extern void Uint16Pair_SetWidth(global::System.Runtime.InteropServices.HandleRef jarg1, ushort jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Uint16Pair_GetWidth")]
  public static extern ushort Uint16Pair_GetWidth(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Uint16Pair_SetHeight")]
  public static extern void Uint16Pair_SetHeight(global::System.Runtime.InteropServices.HandleRef jarg1, ushort jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Uint16Pair_GetHeight")]
  public static extern ushort Uint16Pair_GetHeight(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Uint16Pair_SetX")]
  public static extern void Uint16Pair_SetX(global::System.Runtime.InteropServices.HandleRef jarg1, ushort jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Uint16Pair_GetX")]
  public static extern ushort Uint16Pair_GetX(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Uint16Pair_SetY")]
  public static extern void Uint16Pair_SetY(global::System.Runtime.InteropServices.HandleRef jarg1, ushort jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Uint16Pair_GetY")]
  public static extern ushort Uint16Pair_GetY(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Uint16Pair_Assign")]
  public static extern global::System.IntPtr Uint16Pair_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Uint16Pair_EqualTo")]
  public static extern bool Uint16Pair_EqualTo(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Uint16Pair_NotEqualTo")]
  public static extern bool Uint16Pair_NotEqualTo(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Uint16Pair_LessThan")]
  public static extern bool Uint16Pair_LessThan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Uint16Pair_GreaterThan")]
  public static extern bool Uint16Pair_GreaterThan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Uint16Pair")]
  public static extern void delete_Uint16Pair(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Degree__SWIG_0")]
  public static extern global::System.IntPtr new_Degree__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Degree__SWIG_1")]
  public static extern global::System.IntPtr new_Degree__SWIG_1(float jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Degree__SWIG_2")]
  public static extern global::System.IntPtr new_Degree__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Degree_degree_set")]
  public static extern void Degree_degree_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Degree_degree_get")]
  public static extern float Degree_degree_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Degree")]
  public static extern void delete_Degree(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ANGLE_360_get")]
  public static extern global::System.IntPtr ANGLE_360_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ANGLE_315_get")]
  public static extern global::System.IntPtr ANGLE_315_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ANGLE_270_get")]
  public static extern global::System.IntPtr ANGLE_270_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ANGLE_225_get")]
  public static extern global::System.IntPtr ANGLE_225_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ANGLE_180_get")]
  public static extern global::System.IntPtr ANGLE_180_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ANGLE_135_get")]
  public static extern global::System.IntPtr ANGLE_135_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ANGLE_120_get")]
  public static extern global::System.IntPtr ANGLE_120_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ANGLE_90_get")]
  public static extern global::System.IntPtr ANGLE_90_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ANGLE_60_get")]
  public static extern global::System.IntPtr ANGLE_60_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ANGLE_45_get")]
  public static extern global::System.IntPtr ANGLE_45_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ANGLE_30_get")]
  public static extern global::System.IntPtr ANGLE_30_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ANGLE_0_get")]
  public static extern global::System.IntPtr ANGLE_0_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_EqualTo__SWIG_5")]
  public static extern bool EqualTo__SWIG_5(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_NotEqualTo__SWIG_4")]
  public static extern bool NotEqualTo__SWIG_4(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Clamp__SWIG_3")]
  public static extern global::System.IntPtr Clamp__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Radian__SWIG_0")]
  public static extern global::System.IntPtr new_Radian__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Radian__SWIG_1")]
  public static extern global::System.IntPtr new_Radian__SWIG_1(float jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Radian__SWIG_2")]
  public static extern global::System.IntPtr new_Radian__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Radian_Assign__SWIG_0")]
  public static extern global::System.IntPtr Radian_Assign__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Radian_Assign__SWIG_1")]
  public static extern global::System.IntPtr Radian_Assign__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Radian_ConvertToFloat")]
  public static extern float Radian_ConvertToFloat(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Radian_radian_set")]
  public static extern void Radian_radian_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Radian_radian_get")]
  public static extern float Radian_radian_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Radian")]
  public static extern void delete_Radian(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_EqualTo__SWIG_6")]
  public static extern bool EqualTo__SWIG_6(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_NotEqualTo__SWIG_5")]
  public static extern bool NotEqualTo__SWIG_5(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_EqualTo__SWIG_7")]
  public static extern bool EqualTo__SWIG_7(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_NotEqualTo__SWIG_6")]
  public static extern bool NotEqualTo__SWIG_6(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_EqualTo__SWIG_8")]
  public static extern bool EqualTo__SWIG_8(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_NotEqualTo__SWIG_7")]
  public static extern bool NotEqualTo__SWIG_7(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GreaterThan__SWIG_0")]
  public static extern bool GreaterThan__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GreaterThan__SWIG_1")]
  public static extern bool GreaterThan__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GreaterThan__SWIG_2")]
  public static extern bool GreaterThan__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LessThan__SWIG_0")]
  public static extern bool LessThan__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LessThan__SWIG_1")]
  public static extern bool LessThan__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LessThan__SWIG_2")]
  public static extern bool LessThan__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Multiply")]
  public static extern global::System.IntPtr Multiply(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Subtract")]
  public static extern global::System.IntPtr Subtract(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Clamp__SWIG_4")]
  public static extern global::System.IntPtr Clamp__SWIG_4(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Rotation__SWIG_0")]
  public static extern global::System.IntPtr new_Rotation__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Rotation__SWIG_1")]
  public static extern global::System.IntPtr new_Rotation__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Rotation")]
  public static extern void delete_Rotation(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rotation_IDENTITY_get")]
  public static extern global::System.IntPtr Rotation_IDENTITY_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rotation_IsIdentity")]
  public static extern bool Rotation_IsIdentity(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rotation_GetAxisAngle")]
  public static extern bool Rotation_GetAxisAngle(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rotation_Add")]
  public static extern global::System.IntPtr Rotation_Add(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rotation_Subtract__SWIG_0")]
  public static extern global::System.IntPtr Rotation_Subtract__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rotation_Multiply__SWIG_0")]
  public static extern global::System.IntPtr Rotation_Multiply__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rotation_Multiply__SWIG_1")]
  public static extern global::System.IntPtr Rotation_Multiply__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rotation_Divide__SWIG_0")]
  public static extern global::System.IntPtr Rotation_Divide__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rotation_Multiply__SWIG_2")]
  public static extern global::System.IntPtr Rotation_Multiply__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rotation_Divide__SWIG_1")]
  public static extern global::System.IntPtr Rotation_Divide__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rotation_Subtract__SWIG_1")]
  public static extern global::System.IntPtr Rotation_Subtract__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rotation_AddAssign")]
  public static extern global::System.IntPtr Rotation_AddAssign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rotation_SubtractAssign")]
  public static extern global::System.IntPtr Rotation_SubtractAssign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rotation_MultiplyAssign__SWIG_0")]
  public static extern global::System.IntPtr Rotation_MultiplyAssign__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rotation_MultiplyAssign__SWIG_1")]
  public static extern global::System.IntPtr Rotation_MultiplyAssign__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rotation_DivideAssign")]
  public static extern global::System.IntPtr Rotation_DivideAssign(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rotation_EqualTo")]
  public static extern bool Rotation_EqualTo(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rotation_NotEqualTo")]
  public static extern bool Rotation_NotEqualTo(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rotation_Length")]
  public static extern float Rotation_Length(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rotation_LengthSquared")]
  public static extern float Rotation_LengthSquared(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rotation_Normalize")]
  public static extern void Rotation_Normalize(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rotation_Normalized")]
  public static extern global::System.IntPtr Rotation_Normalized(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rotation_Conjugate")]
  public static extern void Rotation_Conjugate(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rotation_Invert")]
  public static extern void Rotation_Invert(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rotation_Log")]
  public static extern global::System.IntPtr Rotation_Log(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rotation_Exp")]
  public static extern global::System.IntPtr Rotation_Exp(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rotation_Dot")]
  public static extern float Rotation_Dot(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rotation_Lerp")]
  public static extern global::System.IntPtr Rotation_Lerp(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rotation_Slerp")]
  public static extern global::System.IntPtr Rotation_Slerp(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rotation_SlerpNoInvert")]
  public static extern global::System.IntPtr Rotation_SlerpNoInvert(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rotation_Squad")]
  public static extern global::System.IntPtr Rotation_Squad(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, float jarg5);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rotation_AngleBetween")]
  public static extern float Rotation_AngleBetween(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Matrix__SWIG_0")]
  public static extern global::System.IntPtr new_Matrix__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Matrix__SWIG_1")]
  public static extern global::System.IntPtr new_Matrix__SWIG_1(bool jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Matrix__SWIG_2")]
  public static extern global::System.IntPtr new_Matrix__SWIG_2([global::System.Runtime.InteropServices.In, global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPArray)]float[] jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Matrix__SWIG_3")]
  public static extern global::System.IntPtr new_Matrix__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Matrix__SWIG_4")]
  public static extern global::System.IntPtr new_Matrix__SWIG_4(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Matrix_Assign")]
  public static extern global::System.IntPtr Matrix_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Matrix_IDENTITY_get")]
  public static extern global::System.IntPtr Matrix_IDENTITY_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Matrix_SetIdentity")]
  public static extern void Matrix_SetIdentity(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Matrix_SetIdentityAndScale")]
  public static extern void Matrix_SetIdentityAndScale(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Matrix_InvertTransform")]
  public static extern void Matrix_InvertTransform(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Matrix_Invert")]
  public static extern bool Matrix_Invert(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Matrix_Transpose")]
  public static extern void Matrix_Transpose(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Matrix_GetXAxis")]
  public static extern global::System.IntPtr Matrix_GetXAxis(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Matrix_GetYAxis")]
  public static extern global::System.IntPtr Matrix_GetYAxis(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Matrix_GetZAxis")]
  public static extern global::System.IntPtr Matrix_GetZAxis(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Matrix_SetXAxis")]
  public static extern void Matrix_SetXAxis(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Matrix_SetYAxis")]
  public static extern void Matrix_SetYAxis(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Matrix_SetZAxis")]
  public static extern void Matrix_SetZAxis(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Matrix_GetTranslation")]
  public static extern global::System.IntPtr Matrix_GetTranslation(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Matrix_GetTranslation3")]
  public static extern global::System.IntPtr Matrix_GetTranslation3(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Matrix_SetTranslation__SWIG_0")]
  public static extern void Matrix_SetTranslation__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Matrix_SetTranslation__SWIG_1")]
  public static extern void Matrix_SetTranslation__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Matrix_OrthoNormalize")]
  public static extern void Matrix_OrthoNormalize(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Matrix_AsFloat__SWIG_0")]
  public static extern global::System.IntPtr Matrix_AsFloat__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Matrix_Multiply__SWIG_0")]
  public static extern void Matrix_Multiply__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Matrix_Multiply__SWIG_1")]
  public static extern void Matrix_Multiply__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Matrix_Multiply__SWIG_2")]
  public static extern global::System.IntPtr Matrix_Multiply__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Matrix_EqualTo")]
  public static extern bool Matrix_EqualTo(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Matrix_NotEqualTo")]
  public static extern bool Matrix_NotEqualTo(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Matrix_SetTransformComponents")]
  public static extern void Matrix_SetTransformComponents(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Matrix_SetInverseTransformComponents__SWIG_0")]
  public static extern void Matrix_SetInverseTransformComponents__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Matrix_SetInverseTransformComponents__SWIG_1")]
  public static extern void Matrix_SetInverseTransformComponents__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, global::System.Runtime.InteropServices.HandleRef jarg5);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Matrix_GetTransformComponents")]
  public static extern void Matrix_GetTransformComponents(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Matrix")]
  public static extern void delete_Matrix(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Matrix3_IDENTITY_get")]
  public static extern global::System.IntPtr Matrix3_IDENTITY_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Matrix3__SWIG_0")]
  public static extern global::System.IntPtr new_Matrix3__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Matrix3__SWIG_1")]
  public static extern global::System.IntPtr new_Matrix3__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Matrix3__SWIG_2")]
  public static extern global::System.IntPtr new_Matrix3__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Matrix3__SWIG_3")]
  public static extern global::System.IntPtr new_Matrix3__SWIG_3(float jarg1, float jarg2, float jarg3, float jarg4, float jarg5, float jarg6, float jarg7, float jarg8, float jarg9);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Matrix3_Assign__SWIG_0")]
  public static extern global::System.IntPtr Matrix3_Assign__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Matrix3_Assign__SWIG_1")]
  public static extern global::System.IntPtr Matrix3_Assign__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Matrix3_EqualTo")]
  public static extern bool Matrix3_EqualTo(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Matrix3_NotEqualTo")]
  public static extern bool Matrix3_NotEqualTo(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Matrix3")]
  public static extern void delete_Matrix3(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Matrix3_SetIdentity")]
  public static extern void Matrix3_SetIdentity(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Matrix3_AsFloat__SWIG_0")]
  public static extern global::System.IntPtr Matrix3_AsFloat__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Matrix3_Invert")]
  public static extern bool Matrix3_Invert(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Matrix3_Transpose")]
  public static extern bool Matrix3_Transpose(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Matrix3_Scale")]
  public static extern void Matrix3_Scale(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Matrix3_Magnitude")]
  public static extern float Matrix3_Magnitude(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Matrix3_ScaledInverseTranspose")]
  public static extern bool Matrix3_ScaledInverseTranspose(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Matrix3_Multiply")]
  public static extern void Matrix3_Multiply(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Range")]
  public static extern float Range(float jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Axis")]
  public static extern global::System.IntPtr Axis();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_AngleAxis__SWIG_0")]
  public static extern global::System.IntPtr new_AngleAxis__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_AngleAxis__SWIG_1")]
  public static extern global::System.IntPtr new_AngleAxis__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AngleAxis_angle_set")]
  public static extern void AngleAxis_angle_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AngleAxis_angle_get")]
  public static extern global::System.IntPtr AngleAxis_angle_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AngleAxis_axis_set")]
  public static extern void AngleAxis_axis_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AngleAxis_axis_get")]
  public static extern global::System.IntPtr AngleAxis_axis_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_AngleAxis")]
  public static extern void delete_AngleAxis(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_EqualTo__SWIG_9")]
  public static extern bool EqualTo__SWIG_9(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_NextPowerOfTwo")]
  public static extern uint NextPowerOfTwo(uint jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_IsPowerOfTwo")]
  public static extern bool IsPowerOfTwo(uint jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GetRangedEpsilon")]
  public static extern float GetRangedEpsilon(float jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_EqualsZero")]
  public static extern bool EqualsZero(float jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Equals__SWIG_0")]
  public static extern bool Equals__SWIG_0(float jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Equals__SWIG_1")]
  public static extern bool Equals__SWIG_1(float jarg1, float jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Round")]
  public static extern float Round(float jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_WrapInDomain")]
  public static extern float WrapInDomain(float jarg1, float jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ShortestDistanceInDomain")]
  public static extern float ShortestDistanceInDomain(float jarg1, float jarg2, float jarg3, float jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_INVALID_INDEX_get")]
  public static extern int Property_INVALID_INDEX_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_INVALID_KEY_get")]
  public static extern int Property_INVALID_KEY_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_INVALID_COMPONENT_INDEX_get")]
  public static extern int Property_INVALID_COMPONENT_INDEX_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Property__SWIG_0")]
  public static extern global::System.IntPtr new_Property__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Property__SWIG_1")]
  public static extern global::System.IntPtr new_Property__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Property__SWIG_2")]
  public static extern global::System.IntPtr new_Property__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Property__SWIG_3")]
  public static extern global::System.IntPtr new_Property__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Property")]
  public static extern void delete_Property(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property__object_set")]
  public static extern void Property__object_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property__object_get")]
  public static extern global::System.IntPtr Property__object_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_propertyIndex_set")]
  public static extern void Property_propertyIndex_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_propertyIndex_get")]
  public static extern int Property_propertyIndex_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_componentIndex_set")]
  public static extern void Property_componentIndex_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_componentIndex_get")]
  public static extern int Property_componentIndex_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Property_Array__SWIG_0")]
  public static extern global::System.IntPtr new_Property_Array__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Property_Array__SWIG_1")]
  public static extern global::System.IntPtr new_Property_Array__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Property_Array")]
  public static extern void delete_Property_Array(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Array_Size")]
  public static extern uint Property_Array_Size(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Array_Count")]
  public static extern uint Property_Array_Count(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Array_Empty")]
  public static extern bool Property_Array_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Array_Clear")]
  public static extern void Property_Array_Clear(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Array_Reserve")]
  public static extern void Property_Array_Reserve(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Array_Resize")]
  public static extern void Property_Array_Resize(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Array_Capacity")]
  public static extern uint Property_Array_Capacity(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Array_PushBack")]
  public static extern void Property_Array_PushBack(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Array_Add")]
  public static extern global::System.IntPtr Property_Array_Add(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Array_GetElementAt__SWIG_0")]
  public static extern global::System.IntPtr Property_Array_GetElementAt__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Array_ValueOfIndex__SWIG_0")]
  public static extern global::System.IntPtr Property_Array_ValueOfIndex__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Array_Assign")]
  public static extern global::System.IntPtr Property_Array_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Key_type_set")]
  public static extern void Property_Key_type_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Key_type_get")]
  public static extern int Property_Key_type_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Key_indexKey_set")]
  public static extern void Property_Key_indexKey_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Key_indexKey_get")]
  public static extern int Property_Key_indexKey_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Key_stringKey_set")]
  public static extern void Property_Key_stringKey_set(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Key_stringKey_get")]
  public static extern string Property_Key_stringKey_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Property_Key__SWIG_0")]
  public static extern global::System.IntPtr new_Property_Key__SWIG_0(string jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Property_Key__SWIG_1")]
  public static extern global::System.IntPtr new_Property_Key__SWIG_1(int jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Key_EqualTo__SWIG_0")]
  public static extern bool Property_Key_EqualTo__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Key_EqualTo__SWIG_1")]
  public static extern bool Property_Key_EqualTo__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Key_EqualTo__SWIG_2")]
  public static extern bool Property_Key_EqualTo__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Key_NotEqualTo__SWIG_0")]
  public static extern bool Property_Key_NotEqualTo__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Key_NotEqualTo__SWIG_1")]
  public static extern bool Property_Key_NotEqualTo__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Key_NotEqualTo__SWIG_2")]
  public static extern bool Property_Key_NotEqualTo__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Property_Key")]
  public static extern void delete_Property_Key(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Property_Map__SWIG_0")]
  public static extern global::System.IntPtr new_Property_Map__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Property_Map__SWIG_1")]
  public static extern global::System.IntPtr new_Property_Map__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Property_Map")]
  public static extern void delete_Property_Map(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Map_Count")]
  public static extern uint Property_Map_Count(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Map_Empty")]
  public static extern bool Property_Map_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Map_Insert__SWIG_0")]
  public static extern void Property_Map_Insert__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Map_Insert__SWIG_2")]
  public static extern void Property_Map_Insert__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Map_Add__SWIG_0")]
  public static extern global::System.IntPtr Property_Map_Add__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Map_Add__SWIG_2")]
  public static extern global::System.IntPtr Property_Map_Add__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Map_GetValue")]
  public static extern global::System.IntPtr Property_Map_GetValue(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Map_GetKey")]
  public static extern string Property_Map_GetKey(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Map_GetKeyAt")]
  public static extern global::System.IntPtr Property_Map_GetKeyAt(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Map_GetPair")]
  public static extern global::System.IntPtr Property_Map_GetPair(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Map_Find__SWIG_0")]
  public static extern global::System.IntPtr Property_Map_Find__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Map_Find__SWIG_2")]
  public static extern global::System.IntPtr Property_Map_Find__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Map_Find__SWIG_3")]
  public static extern global::System.IntPtr Property_Map_Find__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, string jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Map_Find__SWIG_4")]
  public static extern global::System.IntPtr Property_Map_Find__SWIG_4(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Map_Find__SWIG_5")]
  public static extern global::System.IntPtr Property_Map_Find__SWIG_5(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Map_Clear")]
  public static extern void Property_Map_Clear(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Map_Merge")]
  public static extern void Property_Map_Merge(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Map_ValueOfIndex__SWIG_0")]
  public static extern global::System.IntPtr Property_Map_ValueOfIndex__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Map_ValueOfIndex__SWIG_2")]
  public static extern global::System.IntPtr Property_Map_ValueOfIndex__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Map_Assign")]
  public static extern global::System.IntPtr Property_Map_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Property_Value__SWIG_0")]
  public static extern global::System.IntPtr new_Property_Value__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Property_Value__SWIG_1")]
  public static extern global::System.IntPtr new_Property_Value__SWIG_1(bool jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Property_Value__SWIG_2")]
  public static extern global::System.IntPtr new_Property_Value__SWIG_2(int jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Property_Value__SWIG_3")]
  public static extern global::System.IntPtr new_Property_Value__SWIG_3(float jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Property_Value__SWIG_4")]
  public static extern global::System.IntPtr new_Property_Value__SWIG_4(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Property_Value__SWIG_5")]
  public static extern global::System.IntPtr new_Property_Value__SWIG_5(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Property_Value__SWIG_6")]
  public static extern global::System.IntPtr new_Property_Value__SWIG_6(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Property_Value__SWIG_7")]
  public static extern global::System.IntPtr new_Property_Value__SWIG_7(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Property_Value__SWIG_8")]
  public static extern global::System.IntPtr new_Property_Value__SWIG_8(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Property_Value__SWIG_9")]
  public static extern global::System.IntPtr new_Property_Value__SWIG_9(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Property_Value__SWIG_10")]
  public static extern global::System.IntPtr new_Property_Value__SWIG_10(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Property_Value__SWIG_11")]
  public static extern global::System.IntPtr new_Property_Value__SWIG_11(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Property_Value__SWIG_12")]
  public static extern global::System.IntPtr new_Property_Value__SWIG_12(string jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Property_Value__SWIG_14")]
  public static extern global::System.IntPtr new_Property_Value__SWIG_14(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Property_Value__SWIG_15")]
  public static extern global::System.IntPtr new_Property_Value__SWIG_15(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Property_Value__SWIG_16")]
  public static extern global::System.IntPtr new_Property_Value__SWIG_16(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Property_Value__SWIG_17")]
  public static extern global::System.IntPtr new_Property_Value__SWIG_17(int jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Property_Value__SWIG_18")]
  public static extern global::System.IntPtr new_Property_Value__SWIG_18(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Value_Assign")]
  public static extern global::System.IntPtr Property_Value_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Property_Value")]
  public static extern void delete_Property_Value(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Value_GetType")]
  public static extern int Property_Value_GetType(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Value_Get__SWIG_1")]
  public static extern bool Property_Value_Get__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, out bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Value_Get__SWIG_2")]
  public static extern bool Property_Value_Get__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, out float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Value_Get__SWIG_3")]
  public static extern bool Property_Value_Get__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1, out int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Value_Get__SWIG_4")]
  public static extern bool Property_Value_Get__SWIG_4(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Value_Get__SWIG_5")]
  public static extern bool Property_Value_Get__SWIG_5(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Value_Get__SWIG_6")]
  public static extern bool Property_Value_Get__SWIG_6(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Value_Get__SWIG_7")]
  public static extern bool Property_Value_Get__SWIG_7(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Value_Get__SWIG_8")]
  public static extern bool Property_Value_Get__SWIG_8(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Value_Get__SWIG_9")]
  public static extern bool Property_Value_Get__SWIG_9(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Value_Get__SWIG_10")]
  public static extern bool Property_Value_Get__SWIG_10(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Value_Get__SWIG_11")]
  public static extern bool Property_Value_Get__SWIG_11(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Value_Get__SWIG_12")]
  public static extern bool Property_Value_Get__SWIG_12(global::System.Runtime.InteropServices.HandleRef jarg1, out string jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Value_Get__SWIG_13")]
  public static extern bool Property_Value_Get__SWIG_13(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Value_Get__SWIG_14")]
  public static extern bool Property_Value_Get__SWIG_14(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Value_Get__SWIG_15")]
  public static extern bool Property_Value_Get__SWIG_15(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Value_GetArray")]
  public static extern global::System.IntPtr Property_Value_GetArray(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Property_Value_GetMap")]
  public static extern global::System.IntPtr Property_Value_GetMap(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GetName")]
  public static extern string GetName(int jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_BaseObject_DoAction")]
  public static extern bool BaseObject_DoAction(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_BaseObject_GetTypeName")]
  public static extern string BaseObject_GetTypeName(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_BaseObject_GetTypeInfo")]
  public static extern bool BaseObject_GetTypeInfo(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_BaseObject_DoConnectSignal")]
  public static extern bool BaseObject_DoConnectSignal(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, string jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GetImplementation")]
  public static extern global::System.IntPtr GetImplementation(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_BaseHandle__SWIG_0")]
  public static extern global::System.IntPtr new_BaseHandle__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_BaseHandle__SWIG_1")]
  public static extern global::System.IntPtr new_BaseHandle__SWIG_1();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_BaseHandle")]
  public static extern void delete_BaseHandle(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_BaseHandle__SWIG_2")]
  public static extern global::System.IntPtr new_BaseHandle__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_BaseHandle_Assign")]
  public static extern global::System.IntPtr BaseHandle_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_BaseHandle_DoAction")]
  public static extern bool BaseHandle_DoAction(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_BaseHandle_GetTypeName")]
  public static extern string BaseHandle_GetTypeName(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_BaseHandle_GetTypeInfo")]
  public static extern bool BaseHandle_GetTypeInfo(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_BaseHandle_GetBaseObject__SWIG_0")]
  public static extern global::System.IntPtr BaseHandle_GetBaseObject__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_BaseHandle_Reset")]
  public static extern void BaseHandle_Reset(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_BaseHandle_EqualTo")]
  public static extern bool BaseHandle_EqualTo(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_BaseHandle_NotEqualTo")]
  public static extern bool BaseHandle_NotEqualTo(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_BaseHandle_GetObjectPtr")]
  public static extern global::System.IntPtr BaseHandle_GetObjectPtr(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_BaseHandle_HasBody")]
  public static extern bool BaseHandle_HasBody(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_BaseHandle_IsEqual")]
  public static extern bool BaseHandle_IsEqual(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LessThan__SWIG_3")]
  public static extern bool LessThan__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ConnectionTrackerInterface")]
  public static extern void delete_ConnectionTrackerInterface(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ConnectionTrackerInterface_SignalConnected")]
  public static extern void ConnectionTrackerInterface_SignalConnected(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_SignalObserver")]
  public static extern void delete_SignalObserver(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_SignalObserver_SignalDisconnected")]
  public static extern void SignalObserver_SignalDisconnected(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_SlotObserver")]
  public static extern void delete_SlotObserver(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_SlotObserver_SlotDisconnected")]
  public static extern void SlotObserver_SlotDisconnected(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ConnectionTracker")]
  public static extern void delete_ConnectionTracker(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ConnectionTracker_DisconnectAll")]
  public static extern void ConnectionTracker_DisconnectAll(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ConnectionTracker_SignalConnected")]
  public static extern void ConnectionTracker_SignalConnected(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ConnectionTracker_SignalDisconnected")]
  public static extern void ConnectionTracker_SignalDisconnected(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ConnectionTracker_GetConnectionCount")]
  public static extern uint ConnectionTracker_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ObjectRegistry__SWIG_0")]
  public static extern global::System.IntPtr new_ObjectRegistry__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ObjectRegistry")]
  public static extern void delete_ObjectRegistry(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ObjectRegistry__SWIG_1")]
  public static extern global::System.IntPtr new_ObjectRegistry__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ObjectRegistry_Assign")]
  public static extern global::System.IntPtr ObjectRegistry_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ObjectRegistry_ObjectCreatedSignal")]
  public static extern global::System.IntPtr ObjectRegistry_ObjectCreatedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ObjectRegistry_ObjectDestroyedSignal")]
  public static extern global::System.IntPtr ObjectRegistry_ObjectDestroyedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PropertyCondition__SWIG_0")]
  public static extern global::System.IntPtr new_PropertyCondition__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_PropertyCondition")]
  public static extern void delete_PropertyCondition(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PropertyCondition__SWIG_1")]
  public static extern global::System.IntPtr new_PropertyCondition__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PropertyCondition_Assign")]
  public static extern global::System.IntPtr PropertyCondition_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PropertyCondition_GetArgumentCount")]
  public static extern uint PropertyCondition_GetArgumentCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PropertyCondition_GetArgument")]
  public static extern float PropertyCondition_GetArgument(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LessThanCondition")]
  public static extern global::System.IntPtr LessThanCondition(float jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GreaterThanCondition")]
  public static extern global::System.IntPtr GreaterThanCondition(float jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_InsideCondition")]
  public static extern global::System.IntPtr InsideCondition(float jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_OutsideCondition")]
  public static extern global::System.IntPtr OutsideCondition(float jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_StepCondition__SWIG_0")]
  public static extern global::System.IntPtr StepCondition__SWIG_0(float jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_StepCondition__SWIG_1")]
  public static extern global::System.IntPtr StepCondition__SWIG_1(float jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VariableStepCondition")]
  public static extern global::System.IntPtr VariableStepCondition(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PropertyNotification__SWIG_0")]
  public static extern global::System.IntPtr new_PropertyNotification__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PropertyNotification_DownCast")]
  public static extern global::System.IntPtr PropertyNotification_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_PropertyNotification")]
  public static extern void delete_PropertyNotification(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PropertyNotification__SWIG_1")]
  public static extern global::System.IntPtr new_PropertyNotification__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PropertyNotification_Assign")]
  public static extern global::System.IntPtr PropertyNotification_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PropertyNotification_GetCondition__SWIG_0")]
  public static extern global::System.IntPtr PropertyNotification_GetCondition__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PropertyNotification_GetTarget")]
  public static extern global::System.IntPtr PropertyNotification_GetTarget(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PropertyNotification_GetTargetProperty")]
  public static extern int PropertyNotification_GetTargetProperty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PropertyNotification_SetNotifyMode")]
  public static extern void PropertyNotification_SetNotifyMode(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PropertyNotification_GetNotifyMode")]
  public static extern int PropertyNotification_GetNotifyMode(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PropertyNotification_GetNotifyResult")]
  public static extern bool PropertyNotification_GetNotifyResult(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PropertyNotification_NotifySignal")]
  public static extern global::System.IntPtr PropertyNotification_NotifySignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Handle__SWIG_0")]
  public static extern global::System.IntPtr new_Handle__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Handle_New")]
  public static extern global::System.IntPtr Handle_New();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Handle")]
  public static extern void delete_Handle(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Handle__SWIG_1")]
  public static extern global::System.IntPtr new_Handle__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Handle_Assign")]
  public static extern global::System.IntPtr Handle_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Handle_DownCast")]
  public static extern global::System.IntPtr Handle_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Handle_Supports")]
  public static extern bool Handle_Supports(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Handle_GetPropertyCount")]
  public static extern uint Handle_GetPropertyCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Handle_GetPropertyName")]
  public static extern string Handle_GetPropertyName(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Handle_GetPropertyIndex")]
  public static extern int Handle_GetPropertyIndex(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Handle_IsPropertyWritable")]
  public static extern bool Handle_IsPropertyWritable(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Handle_IsPropertyAnimatable")]
  public static extern bool Handle_IsPropertyAnimatable(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Handle_IsPropertyAConstraintInput")]
  public static extern bool Handle_IsPropertyAConstraintInput(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Handle_GetPropertyType")]
  public static extern int Handle_GetPropertyType(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Handle_SetProperty")]
  public static extern void Handle_SetProperty(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Handle_RegisterProperty__SWIG_0")]
  public static extern int Handle_RegisterProperty__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Handle_RegisterProperty__SWIG_1")]
  public static extern int Handle_RegisterProperty__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, int jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Handle_GetProperty")]
  public static extern global::System.IntPtr Handle_GetProperty(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Handle_GetPropertyIndices")]
  public static extern void Handle_GetPropertyIndices(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Handle_AddPropertyNotification__SWIG_0")]
  public static extern global::System.IntPtr Handle_AddPropertyNotification__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Handle_AddPropertyNotification__SWIG_1")]
  public static extern global::System.IntPtr Handle_AddPropertyNotification__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Handle_RemovePropertyNotification")]
  public static extern void Handle_RemovePropertyNotification(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Handle_RemovePropertyNotifications")]
  public static extern void Handle_RemovePropertyNotifications(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Handle_RemoveConstraints__SWIG_0")]
  public static extern void Handle_RemoveConstraints__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Handle_RemoveConstraints__SWIG_1")]
  public static extern void Handle_RemoveConstraints__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_WEIGHT_get")]
  public static extern int WEIGHT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_New")]
  public static extern global::System.IntPtr New();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TypeInfo__SWIG_0")]
  public static extern global::System.IntPtr new_TypeInfo__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_TypeInfo")]
  public static extern void delete_TypeInfo(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TypeInfo__SWIG_1")]
  public static extern global::System.IntPtr new_TypeInfo__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TypeInfo_Assign")]
  public static extern global::System.IntPtr TypeInfo_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TypeInfo_GetName")]
  public static extern string TypeInfo_GetName(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TypeInfo_GetBaseName")]
  public static extern string TypeInfo_GetBaseName(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TypeInfo_CreateInstance")]
  public static extern global::System.IntPtr TypeInfo_CreateInstance(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TypeInfo_GetActionCount")]
  public static extern uint TypeInfo_GetActionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TypeInfo_GetActionName")]
  public static extern string TypeInfo_GetActionName(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TypeInfo_GetSignalCount")]
  public static extern uint TypeInfo_GetSignalCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TypeInfo_GetSignalName")]
  public static extern string TypeInfo_GetSignalName(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TypeInfo_GetPropertyCount")]
  public static extern uint TypeInfo_GetPropertyCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TypeInfo_GetPropertyIndices")]
  public static extern void TypeInfo_GetPropertyIndices(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TypeInfo_GetPropertyName")]
  public static extern string TypeInfo_GetPropertyName(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TypeRegistry_Get")]
  public static extern global::System.IntPtr TypeRegistry_Get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TypeRegistry__SWIG_0")]
  public static extern global::System.IntPtr new_TypeRegistry__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_TypeRegistry")]
  public static extern void delete_TypeRegistry(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TypeRegistry__SWIG_1")]
  public static extern global::System.IntPtr new_TypeRegistry__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TypeRegistry_Assign")]
  public static extern global::System.IntPtr TypeRegistry_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TypeRegistry_GetTypeInfo__SWIG_0")]
  public static extern global::System.IntPtr TypeRegistry_GetTypeInfo__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TypeRegistry_GetTypeInfo__SWIG_1")]
  public static extern global::System.IntPtr TypeRegistry_GetTypeInfo__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TypeRegistry_GetTypeNameCount")]
  public static extern uint TypeRegistry_GetTypeNameCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TypeRegistry_GetTypeName")]
  public static extern string TypeRegistry_GetTypeName(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TypeRegistration__SWIG_0")]
  public static extern global::System.IntPtr new_TypeRegistration__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TypeRegistration__SWIG_1")]
  public static extern global::System.IntPtr new_TypeRegistration__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, bool jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TypeRegistration__SWIG_2")]
  public static extern global::System.IntPtr new_TypeRegistration__SWIG_2(string jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TypeRegistration_RegisteredName")]
  public static extern string TypeRegistration_RegisteredName(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TypeRegistration_RegisterControl")]
  public static extern void TypeRegistration_RegisterControl(string jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TypeRegistration_RegisterProperty")]
  public static extern void TypeRegistration_RegisterProperty(string jarg1, string jarg2, int jarg3, int jarg4, global::System.Runtime.InteropServices.HandleRef jarg5, global::System.Runtime.InteropServices.HandleRef jarg6);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_TypeRegistration")]
  public static extern void delete_TypeRegistration(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_SignalConnectorType")]
  public static extern global::System.IntPtr new_SignalConnectorType(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_SignalConnectorType")]
  public static extern void delete_SignalConnectorType(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TypeAction")]
  public static extern global::System.IntPtr new_TypeAction(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_TypeAction")]
  public static extern void delete_TypeAction(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PropertyRegistration")]
  public static extern global::System.IntPtr new_PropertyRegistration(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, int jarg3, int jarg4, global::System.Runtime.InteropServices.HandleRef jarg5, global::System.Runtime.InteropServices.HandleRef jarg6);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_PropertyRegistration")]
  public static extern void delete_PropertyRegistration(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_AnimatablePropertyRegistration__SWIG_0")]
  public static extern global::System.IntPtr new_AnimatablePropertyRegistration__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, int jarg3, int jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_AnimatablePropertyRegistration__SWIG_1")]
  public static extern global::System.IntPtr new_AnimatablePropertyRegistration__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, int jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_AnimatablePropertyRegistration")]
  public static extern void delete_AnimatablePropertyRegistration(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_AnimatablePropertyComponentRegistration")]
  public static extern global::System.IntPtr new_AnimatablePropertyComponentRegistration(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, int jarg3, int jarg4, uint jarg5);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_AnimatablePropertyComponentRegistration")]
  public static extern void delete_AnimatablePropertyComponentRegistration(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ChildPropertyRegistration")]
  public static extern global::System.IntPtr new_ChildPropertyRegistration(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, int jarg3, int jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ChildPropertyRegistration")]
  public static extern void delete_ChildPropertyRegistration(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RegisterType")]
  public static extern bool RegisterType(string jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RegisterProperty")]
  public static extern bool RegisterProperty(string jarg1, string jarg2, int jarg3, int jarg4, global::System.Runtime.InteropServices.HandleRef jarg5, global::System.Runtime.InteropServices.HandleRef jarg6);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ParentOriginTop_get")]
  public static extern float ParentOriginTop_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ParentOriginBottom_get")]
  public static extern float ParentOriginBottom_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ParentOriginLeft_get")]
  public static extern float ParentOriginLeft_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ParentOriginRight_get")]
  public static extern float ParentOriginRight_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ParentOriginMiddle_get")]
  public static extern float ParentOriginMiddle_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ParentOriginTopLeft_get")]
  public static extern global::System.IntPtr ParentOriginTopLeft_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ParentOriginTopCenter_get")]
  public static extern global::System.IntPtr ParentOriginTopCenter_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ParentOriginTopRight_get")]
  public static extern global::System.IntPtr ParentOriginTopRight_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ParentOriginCenterLeft_get")]
  public static extern global::System.IntPtr ParentOriginCenterLeft_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ParentOriginCenter_get")]
  public static extern global::System.IntPtr ParentOriginCenter_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ParentOriginCenterRight_get")]
  public static extern global::System.IntPtr ParentOriginCenterRight_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ParentOriginBottomLeft_get")]
  public static extern global::System.IntPtr ParentOriginBottomLeft_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ParentOriginBottomCenter_get")]
  public static extern global::System.IntPtr ParentOriginBottomCenter_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ParentOriginBottomRight_get")]
  public static extern global::System.IntPtr ParentOriginBottomRight_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AnchorPointTop_get")]
  public static extern float AnchorPointTop_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AnchorPointBottom_get")]
  public static extern float AnchorPointBottom_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AnchorPointLeft_get")]
  public static extern float AnchorPointLeft_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AnchorPointRight_get")]
  public static extern float AnchorPointRight_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AnchorPointMiddle_get")]
  public static extern float AnchorPointMiddle_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AnchorPointTopLeft_get")]
  public static extern global::System.IntPtr AnchorPointTopLeft_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AnchorPointTopCenter_get")]
  public static extern global::System.IntPtr AnchorPointTopCenter_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AnchorPointTopRight_get")]
  public static extern global::System.IntPtr AnchorPointTopRight_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AnchorPointCenterLeft_get")]
  public static extern global::System.IntPtr AnchorPointCenterLeft_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AnchorPointCenter_get")]
  public static extern global::System.IntPtr AnchorPointCenter_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AnchorPointCenterRight_get")]
  public static extern global::System.IntPtr AnchorPointCenterRight_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AnchorPointBottomLeft_get")]
  public static extern global::System.IntPtr AnchorPointBottomLeft_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AnchorPointBottomCenter_get")]
  public static extern global::System.IntPtr AnchorPointBottomCenter_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AnchorPointBottomRight_get")]
  public static extern global::System.IntPtr AnchorPointBottomRight_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_BLACK_get")]
  public static extern global::System.IntPtr BLACK_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_WHITE_get")]
  public static extern global::System.IntPtr WHITE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RED_get")]
  public static extern global::System.IntPtr RED_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GREEN_get")]
  public static extern global::System.IntPtr GREEN_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_BLUE_get")]
  public static extern global::System.IntPtr BLUE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_YELLOW_get")]
  public static extern global::System.IntPtr YELLOW_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_MAGENTA_get")]
  public static extern global::System.IntPtr MAGENTA_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CYAN_get")]
  public static extern global::System.IntPtr CYAN_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TRANSPARENT_get")]
  public static extern global::System.IntPtr TRANSPARENT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_MACHINE_EPSILON_0_get")]
  public static extern float MACHINE_EPSILON_0_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_MACHINE_EPSILON_1_get")]
  public static extern float MACHINE_EPSILON_1_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_MACHINE_EPSILON_10_get")]
  public static extern float MACHINE_EPSILON_10_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_MACHINE_EPSILON_100_get")]
  public static extern float MACHINE_EPSILON_100_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_MACHINE_EPSILON_1000_get")]
  public static extern float MACHINE_EPSILON_1000_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_MACHINE_EPSILON_10000_get")]
  public static extern float MACHINE_EPSILON_10000_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PI_get")]
  public static extern float PI_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PI_2_get")]
  public static extern float PI_2_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PI_4_get")]
  public static extern float PI_4_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PI_OVER_180_get")]
  public static extern float PI_OVER_180_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ONE80_OVER_PI_get")]
  public static extern float ONE80_OVER_PI_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ResizePolicyDefault_get")]
  public static extern int ResizePolicyDefault_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorBase_Count")]
  public static extern uint VectorBase_Count(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorBase_Size")]
  public static extern uint VectorBase_Size(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorBase_Empty")]
  public static extern bool VectorBase_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorBase_Capacity")]
  public static extern uint VectorBase_Capacity(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorBase_Release")]
  public static extern void VectorBase_Release(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Image__SWIG_0")]
  public static extern global::System.IntPtr new_Image__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Image")]
  public static extern void delete_Image(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Image__SWIG_1")]
  public static extern global::System.IntPtr new_Image__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Image_Assign")]
  public static extern global::System.IntPtr Image_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Image_DownCast")]
  public static extern global::System.IntPtr Image_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Image_GetWidth")]
  public static extern uint Image_GetWidth(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Image_GetHeight")]
  public static extern uint Image_GetHeight(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Image_UploadedSignal")]
  public static extern global::System.IntPtr Image_UploadedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FIRST_VALID_PIXEL_FORMAT_get")]
  public static extern int FIRST_VALID_PIXEL_FORMAT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LAST_VALID_PIXEL_FORMAT_get")]
  public static extern int LAST_VALID_PIXEL_FORMAT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_HasAlpha")]
  public static extern bool HasAlpha(int jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GetBytesPerPixel")]
  public static extern uint GetBytesPerPixel(int jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GetAlphaOffsetAndMask")]
  public static extern void GetAlphaOffsetAndMask(int jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PixelData_New")]
  public static extern global::System.IntPtr PixelData_New([global::System.Runtime.InteropServices.In, global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPArray)]byte[] jarg1, uint jarg2, uint jarg3, uint jarg4, int jarg5, int jarg6);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PixelData__SWIG_0")]
  public static extern global::System.IntPtr new_PixelData__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_PixelData")]
  public static extern void delete_PixelData(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PixelData__SWIG_1")]
  public static extern global::System.IntPtr new_PixelData__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PixelData_Assign")]
  public static extern global::System.IntPtr PixelData_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PixelData_GetWidth")]
  public static extern uint PixelData_GetWidth(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PixelData_GetHeight")]
  public static extern uint PixelData_GetHeight(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PixelData_GetPixelFormat")]
  public static extern int PixelData_GetPixelFormat(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_POSITIVE_X_get")]
  public static extern uint POSITIVE_X_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_NEGATIVE_X_get")]
  public static extern uint NEGATIVE_X_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_POSITIVE_Y_get")]
  public static extern uint POSITIVE_Y_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_NEGATIVE_Y_get")]
  public static extern uint NEGATIVE_Y_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_POSITIVE_Z_get")]
  public static extern uint POSITIVE_Z_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_NEGATIVE_Z_get")]
  public static extern uint NEGATIVE_Z_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Texture_New__SWIG_0")]
  public static extern global::System.IntPtr Texture_New__SWIG_0(int jarg1, int jarg2, uint jarg3, uint jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Texture_New__SWIG_1")]
  public static extern global::System.IntPtr Texture_New__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Texture__SWIG_0")]
  public static extern global::System.IntPtr new_Texture__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Texture")]
  public static extern void delete_Texture(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Texture__SWIG_1")]
  public static extern global::System.IntPtr new_Texture__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Texture_DownCast")]
  public static extern global::System.IntPtr Texture_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Texture_Assign")]
  public static extern global::System.IntPtr Texture_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Texture_Upload__SWIG_0")]
  public static extern bool Texture_Upload__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Texture_Upload__SWIG_1")]
  public static extern bool Texture_Upload__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, uint jarg3, uint jarg4, uint jarg5, uint jarg6, uint jarg7, uint jarg8);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Texture_GenerateMipmaps")]
  public static extern void Texture_GenerateMipmaps(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Texture_GetWidth")]
  public static extern uint Texture_GetWidth(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Texture_GetHeight")]
  public static extern uint Texture_GetHeight(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Sampler_New")]
  public static extern global::System.IntPtr Sampler_New();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Sampler__SWIG_0")]
  public static extern global::System.IntPtr new_Sampler__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Sampler")]
  public static extern void delete_Sampler(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Sampler__SWIG_1")]
  public static extern global::System.IntPtr new_Sampler__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Sampler_DownCast")]
  public static extern global::System.IntPtr Sampler_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Sampler_Assign")]
  public static extern global::System.IntPtr Sampler_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Sampler_SetFilterMode")]
  public static extern void Sampler_SetFilterMode(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Sampler_SetWrapMode__SWIG_0")]
  public static extern void Sampler_SetWrapMode__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Sampler_SetWrapMode__SWIG_1")]
  public static extern void Sampler_SetWrapMode__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3, int jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextureSet_New")]
  public static extern global::System.IntPtr TextureSet_New();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TextureSet__SWIG_0")]
  public static extern global::System.IntPtr new_TextureSet__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_TextureSet")]
  public static extern void delete_TextureSet(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TextureSet__SWIG_1")]
  public static extern global::System.IntPtr new_TextureSet__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextureSet_DownCast")]
  public static extern global::System.IntPtr TextureSet_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextureSet_Assign")]
  public static extern global::System.IntPtr TextureSet_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextureSet_SetTexture")]
  public static extern void TextureSet_SetTexture(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextureSet_GetTexture")]
  public static extern global::System.IntPtr TextureSet_GetTexture(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextureSet_SetSampler")]
  public static extern void TextureSet_SetSampler(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextureSet_GetSampler")]
  public static extern global::System.IntPtr TextureSet_GetSampler(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextureSet_GetTextureCount")]
  public static extern uint TextureSet_GetTextureCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PropertyBuffer_New")]
  public static extern global::System.IntPtr PropertyBuffer_New(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PropertyBuffer__SWIG_0")]
  public static extern global::System.IntPtr new_PropertyBuffer__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_PropertyBuffer")]
  public static extern void delete_PropertyBuffer(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PropertyBuffer__SWIG_1")]
  public static extern global::System.IntPtr new_PropertyBuffer__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PropertyBuffer_DownCast")]
  public static extern global::System.IntPtr PropertyBuffer_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PropertyBuffer_Assign")]
  public static extern global::System.IntPtr PropertyBuffer_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PropertyBuffer_SetData")]
  public static extern void PropertyBuffer_SetData(global::System.Runtime.InteropServices.HandleRef jarg1, System.IntPtr jarg2, uint jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PropertyBuffer_GetSize")]
  public static extern uint PropertyBuffer_GetSize(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Geometry_New")]
  public static extern global::System.IntPtr Geometry_New();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Geometry__SWIG_0")]
  public static extern global::System.IntPtr new_Geometry__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Geometry")]
  public static extern void delete_Geometry(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Geometry__SWIG_1")]
  public static extern global::System.IntPtr new_Geometry__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Geometry_DownCast")]
  public static extern global::System.IntPtr Geometry_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Geometry_Assign")]
  public static extern global::System.IntPtr Geometry_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Geometry_AddVertexBuffer")]
  public static extern uint Geometry_AddVertexBuffer(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Geometry_GetNumberOfVertexBuffers")]
  public static extern uint Geometry_GetNumberOfVertexBuffers(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Geometry_RemoveVertexBuffer")]
  public static extern void Geometry_RemoveVertexBuffer(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Geometry_SetIndexBuffer")]
  public static extern void Geometry_SetIndexBuffer(global::System.Runtime.InteropServices.HandleRef jarg1, [global::System.Runtime.InteropServices.In, global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPArray)]ushort[] jarg2, uint jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Geometry_SetType")]
  public static extern void Geometry_SetType(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Geometry_GetType")]
  public static extern int Geometry_GetType(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Shader_Hint")]
  public static extern global::System.IntPtr new_Shader_Hint();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Shader_Hint")]
  public static extern void delete_Shader_Hint(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Shader_Property_PROGRAM_get")]
  public static extern int Shader_Property_PROGRAM_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Shader_Property")]
  public static extern global::System.IntPtr new_Shader_Property();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Shader_Property")]
  public static extern void delete_Shader_Property(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Shader_New__SWIG_0")]
  public static extern global::System.IntPtr Shader_New__SWIG_0(string jarg1, string jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Shader_New__SWIG_1")]
  public static extern global::System.IntPtr Shader_New__SWIG_1(string jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Shader__SWIG_0")]
  public static extern global::System.IntPtr new_Shader__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Shader")]
  public static extern void delete_Shader(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Shader__SWIG_1")]
  public static extern global::System.IntPtr new_Shader__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Shader_DownCast")]
  public static extern global::System.IntPtr Shader_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Shader_Assign")]
  public static extern global::System.IntPtr Shader_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Renderer_Property_DEPTH_INDEX_get")]
  public static extern int Renderer_Property_DEPTH_INDEX_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Renderer_Property_FACE_CULLING_MODE_get")]
  public static extern int Renderer_Property_FACE_CULLING_MODE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Renderer_Property_BLEND_MODE_get")]
  public static extern int Renderer_Property_BLEND_MODE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Renderer_Property_BLEND_EQUATION_RGB_get")]
  public static extern int Renderer_Property_BLEND_EQUATION_RGB_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Renderer_Property_BLEND_EQUATION_ALPHA_get")]
  public static extern int Renderer_Property_BLEND_EQUATION_ALPHA_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Renderer_Property_BLEND_FACTOR_SRC_RGB_get")]
  public static extern int Renderer_Property_BLEND_FACTOR_SRC_RGB_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Renderer_Property_BLEND_FACTOR_DEST_RGB_get")]
  public static extern int Renderer_Property_BLEND_FACTOR_DEST_RGB_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Renderer_Property_BLEND_FACTOR_SRC_ALPHA_get")]
  public static extern int Renderer_Property_BLEND_FACTOR_SRC_ALPHA_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Renderer_Property_BLEND_FACTOR_DEST_ALPHA_get")]
  public static extern int Renderer_Property_BLEND_FACTOR_DEST_ALPHA_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Renderer_Property_BLEND_COLOR_get")]
  public static extern int Renderer_Property_BLEND_COLOR_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Renderer_Property_BLEND_PRE_MULTIPLIED_ALPHA_get")]
  public static extern int Renderer_Property_BLEND_PRE_MULTIPLIED_ALPHA_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Renderer_Property_INDEX_RANGE_FIRST_get")]
  public static extern int Renderer_Property_INDEX_RANGE_FIRST_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Renderer_Property_INDEX_RANGE_COUNT_get")]
  public static extern int Renderer_Property_INDEX_RANGE_COUNT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Renderer_Property_DEPTH_WRITE_MODE_get")]
  public static extern int Renderer_Property_DEPTH_WRITE_MODE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Renderer_Property_DEPTH_FUNCTION_get")]
  public static extern int Renderer_Property_DEPTH_FUNCTION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Renderer_Property_DEPTH_TEST_MODE_get")]
  public static extern int Renderer_Property_DEPTH_TEST_MODE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Renderer_Property_RENDER_MODE_get")]
  public static extern int Renderer_Property_RENDER_MODE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Renderer_Property_STENCIL_FUNCTION_get")]
  public static extern int Renderer_Property_STENCIL_FUNCTION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Renderer_Property_STENCIL_FUNCTION_MASK_get")]
  public static extern int Renderer_Property_STENCIL_FUNCTION_MASK_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Renderer_Property_STENCIL_FUNCTION_REFERENCE_get")]
  public static extern int Renderer_Property_STENCIL_FUNCTION_REFERENCE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Renderer_Property_STENCIL_MASK_get")]
  public static extern int Renderer_Property_STENCIL_MASK_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Renderer_Property_STENCIL_OPERATION_ON_FAIL_get")]
  public static extern int Renderer_Property_STENCIL_OPERATION_ON_FAIL_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Renderer_Property_STENCIL_OPERATION_ON_Z_FAIL_get")]
  public static extern int Renderer_Property_STENCIL_OPERATION_ON_Z_FAIL_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Renderer_Property_STENCIL_OPERATION_ON_Z_PASS_get")]
  public static extern int Renderer_Property_STENCIL_OPERATION_ON_Z_PASS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Renderer_Property")]
  public static extern global::System.IntPtr new_Renderer_Property();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Renderer_Property")]
  public static extern void delete_Renderer_Property(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Renderer_New")]
  public static extern global::System.IntPtr Renderer_New(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Renderer__SWIG_0")]
  public static extern global::System.IntPtr new_Renderer__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Renderer")]
  public static extern void delete_Renderer(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Renderer__SWIG_1")]
  public static extern global::System.IntPtr new_Renderer__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Renderer_DownCast")]
  public static extern global::System.IntPtr Renderer_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Renderer_Assign")]
  public static extern global::System.IntPtr Renderer_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Renderer_SetGeometry")]
  public static extern void Renderer_SetGeometry(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Renderer_GetGeometry")]
  public static extern global::System.IntPtr Renderer_GetGeometry(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Renderer_SetIndexRange")]
  public static extern void Renderer_SetIndexRange(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Renderer_SetTextures")]
  public static extern void Renderer_SetTextures(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Renderer_GetTextures")]
  public static extern global::System.IntPtr Renderer_GetTextures(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Renderer_SetShader")]
  public static extern void Renderer_SetShader(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Renderer_GetShader")]
  public static extern global::System.IntPtr Renderer_GetShader(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_FrameBuffer_Attachment")]
  public static extern global::System.IntPtr new_FrameBuffer_Attachment();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_FrameBuffer_Attachment")]
  public static extern void delete_FrameBuffer_Attachment(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FrameBuffer_New")]
  public static extern global::System.IntPtr FrameBuffer_New(uint jarg1, uint jarg2, uint jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_FrameBuffer__SWIG_0")]
  public static extern global::System.IntPtr new_FrameBuffer__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_FrameBuffer")]
  public static extern void delete_FrameBuffer(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_FrameBuffer__SWIG_1")]
  public static extern global::System.IntPtr new_FrameBuffer__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FrameBuffer_DownCast")]
  public static extern global::System.IntPtr FrameBuffer_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FrameBuffer_Assign")]
  public static extern global::System.IntPtr FrameBuffer_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FrameBuffer_AttachColorTexture__SWIG_0")]
  public static extern void FrameBuffer_AttachColorTexture__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FrameBuffer_AttachColorTexture__SWIG_1")]
  public static extern void FrameBuffer_AttachColorTexture__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, uint jarg3, uint jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FrameBuffer_GetColorTexture")]
  public static extern global::System.IntPtr FrameBuffer_GetColorTexture(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_RenderTaskList__SWIG_0")]
  public static extern global::System.IntPtr new_RenderTaskList__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTaskList_DownCast")]
  public static extern global::System.IntPtr RenderTaskList_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_RenderTaskList")]
  public static extern void delete_RenderTaskList(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_RenderTaskList__SWIG_1")]
  public static extern global::System.IntPtr new_RenderTaskList__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTaskList_Assign")]
  public static extern global::System.IntPtr RenderTaskList_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTaskList_CreateTask")]
  public static extern global::System.IntPtr RenderTaskList_CreateTask(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTaskList_RemoveTask")]
  public static extern void RenderTaskList_RemoveTask(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTaskList_GetTaskCount")]
  public static extern uint RenderTaskList_GetTaskCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTaskList_GetTask")]
  public static extern global::System.IntPtr RenderTaskList_GetTask(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_Property_VIEWPORT_POSITION_get")]
  public static extern int RenderTask_Property_VIEWPORT_POSITION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_Property_VIEWPORT_SIZE_get")]
  public static extern int RenderTask_Property_VIEWPORT_SIZE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_Property_CLEAR_COLOR_get")]
  public static extern int RenderTask_Property_CLEAR_COLOR_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_Property_REQUIRES_SYNC_get")]
  public static extern int RenderTask_Property_REQUIRES_SYNC_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_RenderTask_Property")]
  public static extern global::System.IntPtr new_RenderTask_Property();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_RenderTask_Property")]
  public static extern void delete_RenderTask_Property(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_DEFAULT_SCREEN_TO_FRAMEBUFFER_FUNCTION_get")]
  public static extern global::System.IntPtr RenderTask_DEFAULT_SCREEN_TO_FRAMEBUFFER_FUNCTION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_FULLSCREEN_FRAMEBUFFER_FUNCTION_get")]
  public static extern global::System.IntPtr RenderTask_FULLSCREEN_FRAMEBUFFER_FUNCTION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_DEFAULT_EXCLUSIVE_get")]
  public static extern bool RenderTask_DEFAULT_EXCLUSIVE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_DEFAULT_INPUT_ENABLED_get")]
  public static extern bool RenderTask_DEFAULT_INPUT_ENABLED_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_DEFAULT_CLEAR_COLOR_get")]
  public static extern global::System.IntPtr RenderTask_DEFAULT_CLEAR_COLOR_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_DEFAULT_CLEAR_ENABLED_get")]
  public static extern bool RenderTask_DEFAULT_CLEAR_ENABLED_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_DEFAULT_CULL_MODE_get")]
  public static extern bool RenderTask_DEFAULT_CULL_MODE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_DEFAULT_REFRESH_RATE_get")]
  public static extern uint RenderTask_DEFAULT_REFRESH_RATE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_RenderTask__SWIG_0")]
  public static extern global::System.IntPtr new_RenderTask__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_DownCast")]
  public static extern global::System.IntPtr RenderTask_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_RenderTask")]
  public static extern void delete_RenderTask(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_RenderTask__SWIG_1")]
  public static extern global::System.IntPtr new_RenderTask__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_Assign")]
  public static extern global::System.IntPtr RenderTask_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_SetSourceActor")]
  public static extern void RenderTask_SetSourceActor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_GetSourceActor")]
  public static extern global::System.IntPtr RenderTask_GetSourceActor(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_SetExclusive")]
  public static extern void RenderTask_SetExclusive(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_IsExclusive")]
  public static extern bool RenderTask_IsExclusive(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_SetInputEnabled")]
  public static extern void RenderTask_SetInputEnabled(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_GetInputEnabled")]
  public static extern bool RenderTask_GetInputEnabled(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_SetCameraActor")]
  public static extern void RenderTask_SetCameraActor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_GetCameraActor")]
  public static extern global::System.IntPtr RenderTask_GetCameraActor(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_SetTargetFrameBuffer")]
  public static extern void RenderTask_SetTargetFrameBuffer(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_GetTargetFrameBuffer")]
  public static extern global::System.IntPtr RenderTask_GetTargetFrameBuffer(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_SetFrameBuffer")]
  public static extern void RenderTask_SetFrameBuffer(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_GetFrameBuffer")]
  public static extern global::System.IntPtr RenderTask_GetFrameBuffer(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_SetScreenToFrameBufferFunction")]
  public static extern void RenderTask_SetScreenToFrameBufferFunction(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_GetScreenToFrameBufferFunction")]
  public static extern global::System.IntPtr RenderTask_GetScreenToFrameBufferFunction(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_SetScreenToFrameBufferMappingActor")]
  public static extern void RenderTask_SetScreenToFrameBufferMappingActor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_GetScreenToFrameBufferMappingActor")]
  public static extern global::System.IntPtr RenderTask_GetScreenToFrameBufferMappingActor(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_SetViewportPosition")]
  public static extern void RenderTask_SetViewportPosition(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_GetCurrentViewportPosition")]
  public static extern global::System.IntPtr RenderTask_GetCurrentViewportPosition(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_SetViewportSize")]
  public static extern void RenderTask_SetViewportSize(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_GetCurrentViewportSize")]
  public static extern global::System.IntPtr RenderTask_GetCurrentViewportSize(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_SetViewport")]
  public static extern void RenderTask_SetViewport(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_GetViewport")]
  public static extern global::System.IntPtr RenderTask_GetViewport(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_SetClearColor")]
  public static extern void RenderTask_SetClearColor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_GetClearColor")]
  public static extern global::System.IntPtr RenderTask_GetClearColor(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_SetClearEnabled")]
  public static extern void RenderTask_SetClearEnabled(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_GetClearEnabled")]
  public static extern bool RenderTask_GetClearEnabled(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_SetCullMode")]
  public static extern void RenderTask_SetCullMode(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_GetCullMode")]
  public static extern bool RenderTask_GetCullMode(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_SetRefreshRate")]
  public static extern void RenderTask_SetRefreshRate(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_GetRefreshRate")]
  public static extern uint RenderTask_GetRefreshRate(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_WorldToViewport")]
  public static extern bool RenderTask_WorldToViewport(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, out float jarg3, out float jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_ViewportToLocal")]
  public static extern bool RenderTask_ViewportToLocal(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3, float jarg4, out float jarg5, out float jarg6);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_FinishedSignal")]
  public static extern global::System.IntPtr RenderTask_FinishedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TouchPoint__SWIG_0")]
  public static extern global::System.IntPtr new_TouchPoint__SWIG_0(int jarg1, int jarg2, float jarg3, float jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TouchPoint__SWIG_1")]
  public static extern global::System.IntPtr new_TouchPoint__SWIG_1(int jarg1, int jarg2, float jarg3, float jarg4, float jarg5, float jarg6);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_TouchPoint")]
  public static extern void delete_TouchPoint(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TouchPoint_deviceId_set")]
  public static extern void TouchPoint_deviceId_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TouchPoint_deviceId_get")]
  public static extern int TouchPoint_deviceId_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TouchPoint_state_set")]
  public static extern void TouchPoint_state_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TouchPoint_state_get")]
  public static extern int TouchPoint_state_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TouchPoint_hitActor_set")]
  public static extern void TouchPoint_hitActor_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TouchPoint_hitActor_get")]
  public static extern global::System.IntPtr TouchPoint_hitActor_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TouchPoint_local_set")]
  public static extern void TouchPoint_local_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TouchPoint_local_get")]
  public static extern global::System.IntPtr TouchPoint_local_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TouchPoint_screen_set")]
  public static extern void TouchPoint_screen_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TouchPoint_screen_get")]
  public static extern global::System.IntPtr TouchPoint_screen_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Touch__SWIG_0")]
  public static extern global::System.IntPtr new_Touch__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Touch__SWIG_1")]
  public static extern global::System.IntPtr new_Touch__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Touch")]
  public static extern void delete_Touch(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Touch_Assign")]
  public static extern global::System.IntPtr Touch_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Touch_GetTime")]
  public static extern uint Touch_GetTime(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Touch_GetPointCount")]
  public static extern uint Touch_GetPointCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Touch_GetDeviceId")]
  public static extern int Touch_GetDeviceId(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Touch_GetState")]
  public static extern int Touch_GetState(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Touch_GetHitActor")]
  public static extern global::System.IntPtr Touch_GetHitActor(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Touch_GetLocalPosition")]
  public static extern global::System.IntPtr Touch_GetLocalPosition(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Touch_GetScreenPosition")]
  public static extern global::System.IntPtr Touch_GetScreenPosition(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Touch_GetRadius")]
  public static extern float Touch_GetRadius(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Touch_GetEllipseRadius")]
  public static extern global::System.IntPtr Touch_GetEllipseRadius(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Touch_GetPressure")]
  public static extern float Touch_GetPressure(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Touch_GetAngle")]
  public static extern global::System.IntPtr Touch_GetAngle(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_GestureDetector__SWIG_0")]
  public static extern global::System.IntPtr new_GestureDetector__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GestureDetector_DownCast")]
  public static extern global::System.IntPtr GestureDetector_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_GestureDetector")]
  public static extern void delete_GestureDetector(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_GestureDetector__SWIG_1")]
  public static extern global::System.IntPtr new_GestureDetector__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GestureDetector_Assign")]
  public static extern global::System.IntPtr GestureDetector_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GestureDetector_Attach")]
  public static extern void GestureDetector_Attach(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GestureDetector_Detach")]
  public static extern void GestureDetector_Detach(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GestureDetector_DetachAll")]
  public static extern void GestureDetector_DetachAll(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GestureDetector_GetAttachedActorCount")]
  public static extern uint GestureDetector_GetAttachedActorCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GestureDetector_GetAttachedActor")]
  public static extern global::System.IntPtr GestureDetector_GetAttachedActor(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Gesture")]
  public static extern global::System.IntPtr new_Gesture(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Gesture_Assign")]
  public static extern global::System.IntPtr Gesture_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Gesture")]
  public static extern void delete_Gesture(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Gesture_type_set")]
  public static extern void Gesture_type_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Gesture_type_get")]
  public static extern int Gesture_type_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Gesture_state_set")]
  public static extern void Gesture_state_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Gesture_state_get")]
  public static extern int Gesture_state_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Gesture_time_set")]
  public static extern void Gesture_time_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Gesture_time_get")]
  public static extern uint Gesture_time_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Hover__SWIG_0")]
  public static extern global::System.IntPtr new_Hover__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Hover__SWIG_1")]
  public static extern global::System.IntPtr new_Hover__SWIG_1(uint jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Hover")]
  public static extern void delete_Hover(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Hover_points_set")]
  public static extern void Hover_points_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Hover_points_get")]
  public static extern global::System.IntPtr Hover_points_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Hover_time_set")]
  public static extern void Hover_time_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Hover_time_get")]
  public static extern uint Hover_time_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Hover_GetPointCount")]
  public static extern uint Hover_GetPointCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Hover_GetPoint")]
  public static extern global::System.IntPtr Hover_GetPoint(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Key__SWIG_0")]
  public static extern global::System.IntPtr new_Key__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Key__SWIG_1")]
  public static extern global::System.IntPtr new_Key__SWIG_1(string jarg1, string jarg2, int jarg3, int jarg4, uint jarg5, int jarg6);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Key__SWIG_2")]
  public static extern global::System.IntPtr new_Key__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Key_Assign")]
  public static extern global::System.IntPtr Key_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Key")]
  public static extern void delete_Key(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Key_IsShiftModifier")]
  public static extern bool Key_IsShiftModifier(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Key_IsCtrlModifier")]
  public static extern bool Key_IsCtrlModifier(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Key_IsAltModifier")]
  public static extern bool Key_IsAltModifier(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Key_keyPressedName_set")]
  public static extern void Key_keyPressedName_set(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Key_keyPressedName_get")]
  public static extern string Key_keyPressedName_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Key_keyPressed_set")]
  public static extern void Key_keyPressed_set(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Key_keyPressed_get")]
  public static extern string Key_keyPressed_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Key_keyCode_set")]
  public static extern void Key_keyCode_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Key_keyCode_get")]
  public static extern int Key_keyCode_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Key_keyModifier_set")]
  public static extern void Key_keyModifier_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Key_keyModifier_get")]
  public static extern int Key_keyModifier_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Key_time_set")]
  public static extern void Key_time_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Key_time_get")]
  public static extern uint Key_time_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Key_state_set")]
  public static extern void Key_state_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Key_state_get")]
  public static extern int Key_state_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_LongPressGestureDetector__SWIG_0")]
  public static extern global::System.IntPtr new_LongPressGestureDetector__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LongPressGestureDetector_New__SWIG_0")]
  public static extern global::System.IntPtr LongPressGestureDetector_New__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LongPressGestureDetector_New__SWIG_1")]
  public static extern global::System.IntPtr LongPressGestureDetector_New__SWIG_1(uint jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LongPressGestureDetector_New__SWIG_2")]
  public static extern global::System.IntPtr LongPressGestureDetector_New__SWIG_2(uint jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LongPressGestureDetector_DownCast")]
  public static extern global::System.IntPtr LongPressGestureDetector_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_LongPressGestureDetector")]
  public static extern void delete_LongPressGestureDetector(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_LongPressGestureDetector__SWIG_1")]
  public static extern global::System.IntPtr new_LongPressGestureDetector__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LongPressGestureDetector_Assign")]
  public static extern global::System.IntPtr LongPressGestureDetector_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LongPressGestureDetector_SetTouchesRequired__SWIG_0")]
  public static extern void LongPressGestureDetector_SetTouchesRequired__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LongPressGestureDetector_SetTouchesRequired__SWIG_1")]
  public static extern void LongPressGestureDetector_SetTouchesRequired__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LongPressGestureDetector_GetMinimumTouchesRequired")]
  public static extern uint LongPressGestureDetector_GetMinimumTouchesRequired(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LongPressGestureDetector_GetMaximumTouchesRequired")]
  public static extern uint LongPressGestureDetector_GetMaximumTouchesRequired(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LongPressGestureDetector_DetectedSignal")]
  public static extern global::System.IntPtr LongPressGestureDetector_DetectedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_LongPressGesture__SWIG_0")]
  public static extern global::System.IntPtr new_LongPressGesture__SWIG_0(int jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_LongPressGesture__SWIG_1")]
  public static extern global::System.IntPtr new_LongPressGesture__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LongPressGesture_Assign")]
  public static extern global::System.IntPtr LongPressGesture_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_LongPressGesture")]
  public static extern void delete_LongPressGesture(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LongPressGesture_numberOfTouches_set")]
  public static extern void LongPressGesture_numberOfTouches_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LongPressGesture_numberOfTouches_get")]
  public static extern uint LongPressGesture_numberOfTouches_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LongPressGesture_screenPoint_set")]
  public static extern void LongPressGesture_screenPoint_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LongPressGesture_screenPoint_get")]
  public static extern global::System.IntPtr LongPressGesture_screenPoint_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LongPressGesture_localPoint_set")]
  public static extern void LongPressGesture_localPoint_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LongPressGesture_localPoint_get")]
  public static extern global::System.IntPtr LongPressGesture_localPoint_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Wheel__SWIG_0")]
  public static extern global::System.IntPtr new_Wheel__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Wheel__SWIG_1")]
  public static extern global::System.IntPtr new_Wheel__SWIG_1(int jarg1, int jarg2, uint jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, int jarg5, uint jarg6);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Wheel")]
  public static extern void delete_Wheel(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Wheel_IsShiftModifier")]
  public static extern bool Wheel_IsShiftModifier(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Wheel_IsCtrlModifier")]
  public static extern bool Wheel_IsCtrlModifier(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Wheel_IsAltModifier")]
  public static extern bool Wheel_IsAltModifier(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Wheel_type_set")]
  public static extern void Wheel_type_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Wheel_type_get")]
  public static extern int Wheel_type_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Wheel_direction_set")]
  public static extern void Wheel_direction_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Wheel_direction_get")]
  public static extern int Wheel_direction_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Wheel_modifiers_set")]
  public static extern void Wheel_modifiers_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Wheel_modifiers_get")]
  public static extern uint Wheel_modifiers_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Wheel_point_set")]
  public static extern void Wheel_point_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Wheel_point_get")]
  public static extern global::System.IntPtr Wheel_point_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Wheel_z_set")]
  public static extern void Wheel_z_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Wheel_z_get")]
  public static extern int Wheel_z_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Wheel_timeStamp_set")]
  public static extern void Wheel_timeStamp_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Wheel_timeStamp_get")]
  public static extern uint Wheel_timeStamp_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GetDeviceName")]
  public static extern string GetDeviceName(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GetDeviceClass")]
  public static extern int GetDeviceClass(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GetDeviceSubClass")]
  public static extern int GetDeviceSubClass(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_PARENT_ORIGIN_get")]
  public static extern int Actor_Property_PARENT_ORIGIN_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_PARENT_ORIGIN_X_get")]
  public static extern int Actor_Property_PARENT_ORIGIN_X_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_PARENT_ORIGIN_Y_get")]
  public static extern int Actor_Property_PARENT_ORIGIN_Y_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_PARENT_ORIGIN_Z_get")]
  public static extern int Actor_Property_PARENT_ORIGIN_Z_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_ANCHOR_POINT_get")]
  public static extern int Actor_Property_ANCHOR_POINT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_ANCHOR_POINT_X_get")]
  public static extern int Actor_Property_ANCHOR_POINT_X_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_ANCHOR_POINT_Y_get")]
  public static extern int Actor_Property_ANCHOR_POINT_Y_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_ANCHOR_POINT_Z_get")]
  public static extern int Actor_Property_ANCHOR_POINT_Z_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_SIZE_get")]
  public static extern int Actor_Property_SIZE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_SIZE_WIDTH_get")]
  public static extern int Actor_Property_SIZE_WIDTH_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_SIZE_HEIGHT_get")]
  public static extern int Actor_Property_SIZE_HEIGHT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_SIZE_DEPTH_get")]
  public static extern int Actor_Property_SIZE_DEPTH_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_POSITION_get")]
  public static extern int Actor_Property_POSITION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_POSITION_X_get")]
  public static extern int Actor_Property_POSITION_X_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_POSITION_Y_get")]
  public static extern int Actor_Property_POSITION_Y_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_POSITION_Z_get")]
  public static extern int Actor_Property_POSITION_Z_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_WORLD_POSITION_get")]
  public static extern int Actor_Property_WORLD_POSITION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_WORLD_POSITION_X_get")]
  public static extern int Actor_Property_WORLD_POSITION_X_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_WORLD_POSITION_Y_get")]
  public static extern int Actor_Property_WORLD_POSITION_Y_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_WORLD_POSITION_Z_get")]
  public static extern int Actor_Property_WORLD_POSITION_Z_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_ORIENTATION_get")]
  public static extern int Actor_Property_ORIENTATION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_WORLD_ORIENTATION_get")]
  public static extern int Actor_Property_WORLD_ORIENTATION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_SCALE_get")]
  public static extern int Actor_Property_SCALE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_SCALE_X_get")]
  public static extern int Actor_Property_SCALE_X_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_SCALE_Y_get")]
  public static extern int Actor_Property_SCALE_Y_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_SCALE_Z_get")]
  public static extern int Actor_Property_SCALE_Z_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_WORLD_SCALE_get")]
  public static extern int Actor_Property_WORLD_SCALE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_VISIBLE_get")]
  public static extern int Actor_Property_VISIBLE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_COLOR_get")]
  public static extern int Actor_Property_COLOR_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_COLOR_RED_get")]
  public static extern int Actor_Property_COLOR_RED_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_COLOR_GREEN_get")]
  public static extern int Actor_Property_COLOR_GREEN_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_COLOR_BLUE_get")]
  public static extern int Actor_Property_COLOR_BLUE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_COLOR_ALPHA_get")]
  public static extern int Actor_Property_COLOR_ALPHA_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_WORLD_COLOR_get")]
  public static extern int Actor_Property_WORLD_COLOR_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_WORLD_MATRIX_get")]
  public static extern int Actor_Property_WORLD_MATRIX_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_NAME_get")]
  public static extern int Actor_Property_NAME_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_SENSITIVE_get")]
  public static extern int Actor_Property_SENSITIVE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_LEAVE_REQUIRED_get")]
  public static extern int Actor_Property_LEAVE_REQUIRED_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_INHERIT_ORIENTATION_get")]
  public static extern int Actor_Property_INHERIT_ORIENTATION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_INHERIT_SCALE_get")]
  public static extern int Actor_Property_INHERIT_SCALE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_COLOR_MODE_get")]
  public static extern int Actor_Property_COLOR_MODE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_POSITION_INHERITANCE_get")]
  public static extern int Actor_Property_POSITION_INHERITANCE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_DRAW_MODE_get")]
  public static extern int Actor_Property_DRAW_MODE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_SIZE_MODE_FACTOR_get")]
  public static extern int Actor_Property_SIZE_MODE_FACTOR_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_WIDTH_RESIZE_POLICY_get")]
  public static extern int Actor_Property_WIDTH_RESIZE_POLICY_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_HEIGHT_RESIZE_POLICY_get")]
  public static extern int Actor_Property_HEIGHT_RESIZE_POLICY_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_SIZE_SCALE_POLICY_get")]
  public static extern int Actor_Property_SIZE_SCALE_POLICY_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_WIDTH_FOR_HEIGHT_get")]
  public static extern int Actor_Property_WIDTH_FOR_HEIGHT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_HEIGHT_FOR_WIDTH_get")]
  public static extern int Actor_Property_HEIGHT_FOR_WIDTH_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_PADDING_get")]
  public static extern int Actor_Property_PADDING_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_MINIMUM_SIZE_get")]
  public static extern int Actor_Property_MINIMUM_SIZE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_MAXIMUM_SIZE_get")]
  public static extern int Actor_Property_MAXIMUM_SIZE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_INHERIT_POSITION_get")]
  public static extern int Actor_Property_INHERIT_POSITION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Property_CLIPPING_MODE_get")]
  public static extern int Actor_Property_CLIPPING_MODE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Actor_Property")]
  public static extern global::System.IntPtr new_Actor_Property();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Actor_Property")]
  public static extern void delete_Actor_Property(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Actor__SWIG_0")]
  public static extern global::System.IntPtr new_Actor__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_New")]
  public static extern global::System.IntPtr Actor_New();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_DownCast")]
  public static extern global::System.IntPtr Actor_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Actor")]
  public static extern void delete_Actor(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Actor__SWIG_1")]
  public static extern global::System.IntPtr new_Actor__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Assign")]
  public static extern global::System.IntPtr Actor_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_GetName")]
  public static extern string Actor_GetName(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_SetName")]
  public static extern void Actor_SetName(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_GetId")]
  public static extern uint Actor_GetId(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_IsRoot")]
  public static extern bool Actor_IsRoot(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_OnStage")]
  public static extern bool Actor_OnStage(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_IsLayer")]
  public static extern bool Actor_IsLayer(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_GetLayer")]
  public static extern global::System.IntPtr Actor_GetLayer(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Add")]
  public static extern void Actor_Add(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Remove")]
  public static extern void Actor_Remove(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_Unparent")]
  public static extern void Actor_Unparent(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_GetChildCount")]
  public static extern uint Actor_GetChildCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_GetChildAt")]
  public static extern global::System.IntPtr Actor_GetChildAt(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_FindChildByName")]
  public static extern global::System.IntPtr Actor_FindChildByName(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_FindChildById")]
  public static extern global::System.IntPtr Actor_FindChildById(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_GetParent")]
  public static extern global::System.IntPtr Actor_GetParent(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_SetParentOrigin")]
  public static extern void Actor_SetParentOrigin(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_GetCurrentParentOrigin")]
  public static extern global::System.IntPtr Actor_GetCurrentParentOrigin(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_SetAnchorPoint")]
  public static extern void Actor_SetAnchorPoint(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_GetCurrentAnchorPoint")]
  public static extern global::System.IntPtr Actor_GetCurrentAnchorPoint(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_SetSize__SWIG_0")]
  public static extern void Actor_SetSize__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_SetSize__SWIG_1")]
  public static extern void Actor_SetSize__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3, float jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_SetSize__SWIG_2")]
  public static extern void Actor_SetSize__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_SetSize__SWIG_3")]
  public static extern void Actor_SetSize__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_GetTargetSize")]
  public static extern global::System.IntPtr Actor_GetTargetSize(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_GetCurrentSize")]
  public static extern global::System.IntPtr Actor_GetCurrentSize(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_GetNaturalSize")]
  public static extern global::System.IntPtr Actor_GetNaturalSize(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_SetPosition__SWIG_0")]
  public static extern void Actor_SetPosition__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_SetPosition__SWIG_1")]
  public static extern void Actor_SetPosition__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3, float jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_SetPosition__SWIG_2")]
  public static extern void Actor_SetPosition__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_SetX")]
  public static extern void Actor_SetX(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_SetY")]
  public static extern void Actor_SetY(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_SetZ")]
  public static extern void Actor_SetZ(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_TranslateBy")]
  public static extern void Actor_TranslateBy(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_GetCurrentPosition")]
  public static extern global::System.IntPtr Actor_GetCurrentPosition(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_GetCurrentWorldPosition")]
  public static extern global::System.IntPtr Actor_GetCurrentWorldPosition(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_SetInheritPosition")]
  public static extern void Actor_SetInheritPosition(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_GetPositionInheritanceMode")]
  public static extern int Actor_GetPositionInheritanceMode(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_IsPositionInherited")]
  public static extern bool Actor_IsPositionInherited(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_SetOrientation__SWIG_0")]
  public static extern void Actor_SetOrientation__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_SetOrientation__SWIG_1")]
  public static extern void Actor_SetOrientation__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_SetOrientation__SWIG_2")]
  public static extern void Actor_SetOrientation__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_RotateBy__SWIG_0")]
  public static extern void Actor_RotateBy__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_RotateBy__SWIG_1")]
  public static extern void Actor_RotateBy__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_RotateBy__SWIG_2")]
  public static extern void Actor_RotateBy__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_GetCurrentOrientation")]
  public static extern global::System.IntPtr Actor_GetCurrentOrientation(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_SetInheritOrientation")]
  public static extern void Actor_SetInheritOrientation(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_IsOrientationInherited")]
  public static extern bool Actor_IsOrientationInherited(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_GetCurrentWorldOrientation")]
  public static extern global::System.IntPtr Actor_GetCurrentWorldOrientation(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_SetScale__SWIG_0")]
  public static extern void Actor_SetScale__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_SetScale__SWIG_1")]
  public static extern void Actor_SetScale__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3, float jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_SetScale__SWIG_2")]
  public static extern void Actor_SetScale__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_ScaleBy")]
  public static extern void Actor_ScaleBy(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_GetCurrentScale")]
  public static extern global::System.IntPtr Actor_GetCurrentScale(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_GetCurrentWorldScale")]
  public static extern global::System.IntPtr Actor_GetCurrentWorldScale(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_SetInheritScale")]
  public static extern void Actor_SetInheritScale(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_IsScaleInherited")]
  public static extern bool Actor_IsScaleInherited(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_GetCurrentWorldMatrix")]
  public static extern global::System.IntPtr Actor_GetCurrentWorldMatrix(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_SetVisible")]
  public static extern void Actor_SetVisible(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_IsVisible")]
  public static extern bool Actor_IsVisible(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_SetOpacity")]
  public static extern void Actor_SetOpacity(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_GetCurrentOpacity")]
  public static extern float Actor_GetCurrentOpacity(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_SetColor")]
  public static extern void Actor_SetColor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_GetCurrentColor")]
  public static extern global::System.IntPtr Actor_GetCurrentColor(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_SetColorMode")]
  public static extern void Actor_SetColorMode(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_GetColorMode")]
  public static extern int Actor_GetColorMode(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_GetCurrentWorldColor")]
  public static extern global::System.IntPtr Actor_GetCurrentWorldColor(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_SetDrawMode")]
  public static extern void Actor_SetDrawMode(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_GetDrawMode")]
  public static extern int Actor_GetDrawMode(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_SetSensitive")]
  public static extern void Actor_SetSensitive(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_IsSensitive")]
  public static extern bool Actor_IsSensitive(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_ScreenToLocal")]
  public static extern bool Actor_ScreenToLocal(global::System.Runtime.InteropServices.HandleRef jarg1, out float jarg2, out float jarg3, float jarg4, float jarg5);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_SetLeaveRequired")]
  public static extern void Actor_SetLeaveRequired(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_GetLeaveRequired")]
  public static extern bool Actor_GetLeaveRequired(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_SetKeyboardFocusable")]
  public static extern void Actor_SetKeyboardFocusable(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_IsKeyboardFocusable")]
  public static extern bool Actor_IsKeyboardFocusable(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_SetResizePolicy")]
  public static extern void Actor_SetResizePolicy(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_GetResizePolicy")]
  public static extern int Actor_GetResizePolicy(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_SetSizeScalePolicy")]
  public static extern void Actor_SetSizeScalePolicy(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_GetSizeScalePolicy")]
  public static extern int Actor_GetSizeScalePolicy(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_SetSizeModeFactor")]
  public static extern void Actor_SetSizeModeFactor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_GetSizeModeFactor")]
  public static extern global::System.IntPtr Actor_GetSizeModeFactor(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_GetHeightForWidth")]
  public static extern float Actor_GetHeightForWidth(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_GetWidthForHeight")]
  public static extern float Actor_GetWidthForHeight(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_GetRelayoutSize")]
  public static extern float Actor_GetRelayoutSize(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_SetPadding")]
  public static extern void Actor_SetPadding(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_GetPadding")]
  public static extern void Actor_GetPadding(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_SetMinimumSize")]
  public static extern void Actor_SetMinimumSize(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_GetMinimumSize")]
  public static extern global::System.IntPtr Actor_GetMinimumSize(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_SetMaximumSize")]
  public static extern void Actor_SetMaximumSize(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_GetMaximumSize")]
  public static extern global::System.IntPtr Actor_GetMaximumSize(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_GetHierarchyDepth")]
  public static extern int Actor_GetHierarchyDepth(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_AddRenderer")]
  public static extern uint Actor_AddRenderer(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_GetRendererCount")]
  public static extern uint Actor_GetRendererCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_GetRendererAt")]
  public static extern global::System.IntPtr Actor_GetRendererAt(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_RemoveRenderer__SWIG_0")]
  public static extern void Actor_RemoveRenderer__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_RemoveRenderer__SWIG_1")]
  public static extern void Actor_RemoveRenderer__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_TouchedSignal")]
  public static extern global::System.IntPtr Actor_TouchedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_TouchSignal")]
  public static extern global::System.IntPtr Actor_TouchSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_HoveredSignal")]
  public static extern global::System.IntPtr Actor_HoveredSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_WheelEventSignal")]
  public static extern global::System.IntPtr Actor_WheelEventSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_OnStageSignal")]
  public static extern global::System.IntPtr Actor_OnStageSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_OffStageSignal")]
  public static extern global::System.IntPtr Actor_OffStageSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_OnRelayoutSignal")]
  public static extern global::System.IntPtr Actor_OnRelayoutSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_UnparentAndReset")]
  public static extern void UnparentAndReset(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Raise")]
  public static extern void Raise(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Lower")]
  public static extern void Lower(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RaiseToTop")]
  public static extern void RaiseToTop(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LowerToBottom")]
  public static extern void LowerToBottom(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RaiseAbove")]
  public static extern void RaiseAbove(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LowerBelow")]
  public static extern void LowerBelow(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VisibilityChangedSignal")]
  public static extern global::System.IntPtr VisibilityChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Layer_Property_CLIPPING_ENABLE_get")]
  public static extern int Layer_Property_CLIPPING_ENABLE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Layer_Property_CLIPPING_BOX_get")]
  public static extern int Layer_Property_CLIPPING_BOX_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Layer_Property_BEHAVIOR_get")]
  public static extern int Layer_Property_BEHAVIOR_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Layer_Property")]
  public static extern global::System.IntPtr new_Layer_Property();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Layer_Property")]
  public static extern void delete_Layer_Property(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Layer__SWIG_0")]
  public static extern global::System.IntPtr new_Layer__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Layer_New")]
  public static extern global::System.IntPtr Layer_New();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Layer_DownCast")]
  public static extern global::System.IntPtr Layer_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Layer")]
  public static extern void delete_Layer(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Layer__SWIG_1")]
  public static extern global::System.IntPtr new_Layer__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Layer_Assign")]
  public static extern global::System.IntPtr Layer_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Layer_GetDepth")]
  public static extern uint Layer_GetDepth(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Layer_Raise")]
  public static extern void Layer_Raise(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Layer_Lower")]
  public static extern void Layer_Lower(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Layer_RaiseAbove")]
  public static extern void Layer_RaiseAbove(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Layer_LowerBelow")]
  public static extern void Layer_LowerBelow(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Layer_RaiseToTop")]
  public static extern void Layer_RaiseToTop(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Layer_LowerToBottom")]
  public static extern void Layer_LowerToBottom(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Layer_MoveAbove")]
  public static extern void Layer_MoveAbove(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Layer_MoveBelow")]
  public static extern void Layer_MoveBelow(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Layer_SetBehavior")]
  public static extern void Layer_SetBehavior(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Layer_GetBehavior")]
  public static extern int Layer_GetBehavior(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Layer_SetClipping")]
  public static extern void Layer_SetClipping(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Layer_IsClipping")]
  public static extern bool Layer_IsClipping(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Layer_SetClippingBox__SWIG_0")]
  public static extern void Layer_SetClippingBox__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3, int jarg4, int jarg5);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Layer_SetClippingBox__SWIG_1")]
  public static extern void Layer_SetClippingBox__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Layer_GetClippingBox")]
  public static extern global::System.IntPtr Layer_GetClippingBox(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Layer_SetDepthTestDisabled")]
  public static extern void Layer_SetDepthTestDisabled(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Layer_IsDepthTestDisabled")]
  public static extern bool Layer_IsDepthTestDisabled(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Layer_SetSortFunction")]
  public static extern void Layer_SetSortFunction(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Layer_SetTouchConsumed")]
  public static extern void Layer_SetTouchConsumed(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Layer_IsTouchConsumed")]
  public static extern bool Layer_IsTouchConsumed(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Layer_SetHoverConsumed")]
  public static extern void Layer_SetHoverConsumed(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Layer_IsHoverConsumed")]
  public static extern bool Layer_IsHoverConsumed(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Stage_DEFAULT_BACKGROUND_COLOR_get")]
  public static extern global::System.IntPtr Stage_DEFAULT_BACKGROUND_COLOR_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Stage_DEBUG_BACKGROUND_COLOR_get")]
  public static extern global::System.IntPtr Stage_DEBUG_BACKGROUND_COLOR_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Stage__SWIG_0")]
  public static extern global::System.IntPtr new_Stage__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Stage_GetCurrent")]
  public static extern global::System.IntPtr Stage_GetCurrent();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Stage_IsInstalled")]
  public static extern bool Stage_IsInstalled();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Stage")]
  public static extern void delete_Stage(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Stage__SWIG_1")]
  public static extern global::System.IntPtr new_Stage__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Stage_Assign")]
  public static extern global::System.IntPtr Stage_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Stage_Add")]
  public static extern void Stage_Add(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Stage_Remove")]
  public static extern void Stage_Remove(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Stage_GetSize")]
  public static extern global::System.IntPtr Stage_GetSize(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Stage_GetRenderTaskList")]
  public static extern global::System.IntPtr Stage_GetRenderTaskList(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Stage_GetLayerCount")]
  public static extern uint Stage_GetLayerCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Stage_GetLayer")]
  public static extern global::System.IntPtr Stage_GetLayer(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Stage_GetRootLayer")]
  public static extern global::System.IntPtr Stage_GetRootLayer(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Stage_SetBackgroundColor")]
  public static extern void Stage_SetBackgroundColor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Stage_GetBackgroundColor")]
  public static extern global::System.IntPtr Stage_GetBackgroundColor(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Stage_GetDpi")]
  public static extern global::System.IntPtr Stage_GetDpi(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Stage_GetObjectRegistry")]
  public static extern global::System.IntPtr Stage_GetObjectRegistry(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Stage_KeepRendering")]
  public static extern void Stage_KeepRendering(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Stage_KeyEventSignal")]
  public static extern global::System.IntPtr Stage_KeyEventSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Stage_EventProcessingFinishedSignal")]
  public static extern global::System.IntPtr Stage_EventProcessingFinishedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Stage_TouchSignal")]
  public static extern global::System.IntPtr Stage_TouchSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Stage_WheelEventSignal")]
  public static extern global::System.IntPtr Stage_WheelEventSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Stage_ContextLostSignal")]
  public static extern global::System.IntPtr Stage_ContextLostSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Stage_ContextRegainedSignal")]
  public static extern global::System.IntPtr Stage_ContextRegainedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Stage_SceneCreatedSignal")]
  public static extern global::System.IntPtr Stage_SceneCreatedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_RelayoutContainer")]
  public static extern void delete_RelayoutContainer(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RelayoutContainer_Add")]
  public static extern void RelayoutContainer_Add(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CustomActorImpl_Self")]
  public static extern global::System.IntPtr CustomActorImpl_Self(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CustomActorImpl_OnStageConnection")]
  public static extern void CustomActorImpl_OnStageConnection(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CustomActorImpl_OnStageDisconnection")]
  public static extern void CustomActorImpl_OnStageDisconnection(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CustomActorImpl_OnChildAdd")]
  public static extern void CustomActorImpl_OnChildAdd(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CustomActorImpl_OnChildRemove")]
  public static extern void CustomActorImpl_OnChildRemove(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CustomActorImpl_OnPropertySet")]
  public static extern void CustomActorImpl_OnPropertySet(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CustomActorImpl_OnSizeSet")]
  public static extern void CustomActorImpl_OnSizeSet(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CustomActorImpl_OnSizeAnimation")]
  public static extern void CustomActorImpl_OnSizeAnimation(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CustomActorImpl_OnTouchEvent")]
  public static extern bool CustomActorImpl_OnTouchEvent(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CustomActorImpl_OnHoverEvent")]
  public static extern bool CustomActorImpl_OnHoverEvent(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CustomActorImpl_OnKeyEvent")]
  public static extern bool CustomActorImpl_OnKeyEvent(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CustomActorImpl_OnWheelEvent")]
  public static extern bool CustomActorImpl_OnWheelEvent(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CustomActorImpl_OnRelayout")]
  public static extern void CustomActorImpl_OnRelayout(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CustomActorImpl_OnSetResizePolicy")]
  public static extern void CustomActorImpl_OnSetResizePolicy(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CustomActorImpl_GetNaturalSize")]
  public static extern global::System.IntPtr CustomActorImpl_GetNaturalSize(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CustomActorImpl_CalculateChildSize")]
  public static extern float CustomActorImpl_CalculateChildSize(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CustomActorImpl_GetHeightForWidth")]
  public static extern float CustomActorImpl_GetHeightForWidth(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CustomActorImpl_GetWidthForHeight")]
  public static extern float CustomActorImpl_GetWidthForHeight(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CustomActorImpl_RelayoutDependentOnChildren__SWIG_0")]
  public static extern bool CustomActorImpl_RelayoutDependentOnChildren__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CustomActorImpl_RelayoutDependentOnChildren__SWIG_1")]
  public static extern bool CustomActorImpl_RelayoutDependentOnChildren__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CustomActorImpl_OnCalculateRelayoutSize")]
  public static extern void CustomActorImpl_OnCalculateRelayoutSize(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CustomActorImpl_OnLayoutNegotiated")]
  public static extern void CustomActorImpl_OnLayoutNegotiated(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CustomActorImpl_RequiresTouchEvents")]
  public static extern bool CustomActorImpl_RequiresTouchEvents(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CustomActorImpl_RequiresHoverEvents")]
  public static extern bool CustomActorImpl_RequiresHoverEvents(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CustomActorImpl_RequiresWheelEvents")]
  public static extern bool CustomActorImpl_RequiresWheelEvents(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CustomActorImpl_IsRelayoutEnabled")]
  public static extern bool CustomActorImpl_IsRelayoutEnabled(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_CustomActor__SWIG_0")]
  public static extern global::System.IntPtr new_CustomActor__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CustomActor_DownCast")]
  public static extern global::System.IntPtr CustomActor_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_CustomActor")]
  public static extern void delete_CustomActor(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CustomActor_GetImplementation")]
  public static extern global::System.IntPtr CustomActor_GetImplementation(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_CustomActor__SWIG_1")]
  public static extern global::System.IntPtr new_CustomActor__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_CustomActor__SWIG_2")]
  public static extern global::System.IntPtr new_CustomActor__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CustomActor_Assign")]
  public static extern global::System.IntPtr CustomActor_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGestureDetector_Property_SCREEN_POSITION_get")]
  public static extern int PanGestureDetector_Property_SCREEN_POSITION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGestureDetector_Property_SCREEN_DISPLACEMENT_get")]
  public static extern int PanGestureDetector_Property_SCREEN_DISPLACEMENT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGestureDetector_Property_SCREEN_VELOCITY_get")]
  public static extern int PanGestureDetector_Property_SCREEN_VELOCITY_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGestureDetector_Property_LOCAL_POSITION_get")]
  public static extern int PanGestureDetector_Property_LOCAL_POSITION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGestureDetector_Property_LOCAL_DISPLACEMENT_get")]
  public static extern int PanGestureDetector_Property_LOCAL_DISPLACEMENT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGestureDetector_Property_LOCAL_VELOCITY_get")]
  public static extern int PanGestureDetector_Property_LOCAL_VELOCITY_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGestureDetector_Property_PANNING_get")]
  public static extern int PanGestureDetector_Property_PANNING_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PanGestureDetector_Property")]
  public static extern global::System.IntPtr new_PanGestureDetector_Property();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_PanGestureDetector_Property")]
  public static extern void delete_PanGestureDetector_Property(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGestureDetector_DIRECTION_LEFT_get")]
  public static extern global::System.IntPtr PanGestureDetector_DIRECTION_LEFT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGestureDetector_DIRECTION_RIGHT_get")]
  public static extern global::System.IntPtr PanGestureDetector_DIRECTION_RIGHT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGestureDetector_DIRECTION_UP_get")]
  public static extern global::System.IntPtr PanGestureDetector_DIRECTION_UP_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGestureDetector_DIRECTION_DOWN_get")]
  public static extern global::System.IntPtr PanGestureDetector_DIRECTION_DOWN_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGestureDetector_DIRECTION_HORIZONTAL_get")]
  public static extern global::System.IntPtr PanGestureDetector_DIRECTION_HORIZONTAL_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGestureDetector_DIRECTION_VERTICAL_get")]
  public static extern global::System.IntPtr PanGestureDetector_DIRECTION_VERTICAL_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGestureDetector_DEFAULT_THRESHOLD_get")]
  public static extern global::System.IntPtr PanGestureDetector_DEFAULT_THRESHOLD_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PanGestureDetector__SWIG_0")]
  public static extern global::System.IntPtr new_PanGestureDetector__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGestureDetector_New")]
  public static extern global::System.IntPtr PanGestureDetector_New();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGestureDetector_DownCast")]
  public static extern global::System.IntPtr PanGestureDetector_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_PanGestureDetector")]
  public static extern void delete_PanGestureDetector(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PanGestureDetector__SWIG_1")]
  public static extern global::System.IntPtr new_PanGestureDetector__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGestureDetector_Assign")]
  public static extern global::System.IntPtr PanGestureDetector_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGestureDetector_SetMinimumTouchesRequired")]
  public static extern void PanGestureDetector_SetMinimumTouchesRequired(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGestureDetector_SetMaximumTouchesRequired")]
  public static extern void PanGestureDetector_SetMaximumTouchesRequired(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGestureDetector_GetMinimumTouchesRequired")]
  public static extern uint PanGestureDetector_GetMinimumTouchesRequired(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGestureDetector_GetMaximumTouchesRequired")]
  public static extern uint PanGestureDetector_GetMaximumTouchesRequired(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGestureDetector_AddAngle__SWIG_0")]
  public static extern void PanGestureDetector_AddAngle__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGestureDetector_AddAngle__SWIG_1")]
  public static extern void PanGestureDetector_AddAngle__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGestureDetector_AddDirection__SWIG_0")]
  public static extern void PanGestureDetector_AddDirection__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGestureDetector_AddDirection__SWIG_1")]
  public static extern void PanGestureDetector_AddDirection__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGestureDetector_GetAngleCount")]
  public static extern uint PanGestureDetector_GetAngleCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGestureDetector_GetAngle")]
  public static extern global::System.IntPtr PanGestureDetector_GetAngle(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGestureDetector_ClearAngles")]
  public static extern void PanGestureDetector_ClearAngles(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGestureDetector_RemoveAngle")]
  public static extern void PanGestureDetector_RemoveAngle(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGestureDetector_RemoveDirection")]
  public static extern void PanGestureDetector_RemoveDirection(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGestureDetector_DetectedSignal")]
  public static extern global::System.IntPtr PanGestureDetector_DetectedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGestureDetector_SetPanGestureProperties")]
  public static extern void PanGestureDetector_SetPanGestureProperties(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PanGesture__SWIG_0")]
  public static extern global::System.IntPtr new_PanGesture__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PanGesture__SWIG_1")]
  public static extern global::System.IntPtr new_PanGesture__SWIG_1(int jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PanGesture__SWIG_2")]
  public static extern global::System.IntPtr new_PanGesture__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGesture_Assign")]
  public static extern global::System.IntPtr PanGesture_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_PanGesture")]
  public static extern void delete_PanGesture(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGesture_velocity_set")]
  public static extern void PanGesture_velocity_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGesture_velocity_get")]
  public static extern global::System.IntPtr PanGesture_velocity_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGesture_displacement_set")]
  public static extern void PanGesture_displacement_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGesture_displacement_get")]
  public static extern global::System.IntPtr PanGesture_displacement_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGesture_position_set")]
  public static extern void PanGesture_position_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGesture_position_get")]
  public static extern global::System.IntPtr PanGesture_position_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGesture_screenVelocity_set")]
  public static extern void PanGesture_screenVelocity_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGesture_screenVelocity_get")]
  public static extern global::System.IntPtr PanGesture_screenVelocity_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGesture_screenDisplacement_set")]
  public static extern void PanGesture_screenDisplacement_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGesture_screenDisplacement_get")]
  public static extern global::System.IntPtr PanGesture_screenDisplacement_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGesture_screenPosition_set")]
  public static extern void PanGesture_screenPosition_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGesture_screenPosition_get")]
  public static extern global::System.IntPtr PanGesture_screenPosition_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGesture_numberOfTouches_set")]
  public static extern void PanGesture_numberOfTouches_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGesture_numberOfTouches_get")]
  public static extern uint PanGesture_numberOfTouches_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGesture_GetSpeed")]
  public static extern float PanGesture_GetSpeed(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGesture_GetDistance")]
  public static extern float PanGesture_GetDistance(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGesture_GetScreenSpeed")]
  public static extern float PanGesture_GetScreenSpeed(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGesture_GetScreenDistance")]
  public static extern float PanGesture_GetScreenDistance(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PinchGestureDetector__SWIG_0")]
  public static extern global::System.IntPtr new_PinchGestureDetector__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PinchGestureDetector_New")]
  public static extern global::System.IntPtr PinchGestureDetector_New();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PinchGestureDetector_DownCast")]
  public static extern global::System.IntPtr PinchGestureDetector_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_PinchGestureDetector")]
  public static extern void delete_PinchGestureDetector(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PinchGestureDetector__SWIG_1")]
  public static extern global::System.IntPtr new_PinchGestureDetector__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PinchGestureDetector_Assign")]
  public static extern global::System.IntPtr PinchGestureDetector_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PinchGestureDetector_DetectedSignal")]
  public static extern global::System.IntPtr PinchGestureDetector_DetectedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PinchGesture__SWIG_0")]
  public static extern global::System.IntPtr new_PinchGesture__SWIG_0(int jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PinchGesture__SWIG_1")]
  public static extern global::System.IntPtr new_PinchGesture__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PinchGesture_Assign")]
  public static extern global::System.IntPtr PinchGesture_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_PinchGesture")]
  public static extern void delete_PinchGesture(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PinchGesture_scale_set")]
  public static extern void PinchGesture_scale_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PinchGesture_scale_get")]
  public static extern float PinchGesture_scale_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PinchGesture_speed_set")]
  public static extern void PinchGesture_speed_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PinchGesture_speed_get")]
  public static extern float PinchGesture_speed_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PinchGesture_screenCenterPoint_set")]
  public static extern void PinchGesture_screenCenterPoint_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PinchGesture_screenCenterPoint_get")]
  public static extern global::System.IntPtr PinchGesture_screenCenterPoint_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PinchGesture_localCenterPoint_set")]
  public static extern void PinchGesture_localCenterPoint_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PinchGesture_localCenterPoint_get")]
  public static extern global::System.IntPtr PinchGesture_localCenterPoint_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TapGestureDetector__SWIG_0")]
  public static extern global::System.IntPtr new_TapGestureDetector__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TapGestureDetector_New__SWIG_0")]
  public static extern global::System.IntPtr TapGestureDetector_New__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TapGestureDetector_New__SWIG_1")]
  public static extern global::System.IntPtr TapGestureDetector_New__SWIG_1(uint jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TapGestureDetector_DownCast")]
  public static extern global::System.IntPtr TapGestureDetector_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_TapGestureDetector")]
  public static extern void delete_TapGestureDetector(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TapGestureDetector__SWIG_1")]
  public static extern global::System.IntPtr new_TapGestureDetector__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TapGestureDetector_Assign")]
  public static extern global::System.IntPtr TapGestureDetector_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TapGestureDetector_SetMinimumTapsRequired")]
  public static extern void TapGestureDetector_SetMinimumTapsRequired(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TapGestureDetector_SetMaximumTapsRequired")]
  public static extern void TapGestureDetector_SetMaximumTapsRequired(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TapGestureDetector_GetMinimumTapsRequired")]
  public static extern uint TapGestureDetector_GetMinimumTapsRequired(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TapGestureDetector_GetMaximumTapsRequired")]
  public static extern uint TapGestureDetector_GetMaximumTapsRequired(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TapGestureDetector_DetectedSignal")]
  public static extern global::System.IntPtr TapGestureDetector_DetectedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TapGesture__SWIG_0")]
  public static extern global::System.IntPtr new_TapGesture__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TapGesture__SWIG_1")]
  public static extern global::System.IntPtr new_TapGesture__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TapGesture_Assign")]
  public static extern global::System.IntPtr TapGesture_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_TapGesture")]
  public static extern void delete_TapGesture(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TapGesture_numberOfTaps_set")]
  public static extern void TapGesture_numberOfTaps_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TapGesture_numberOfTaps_get")]
  public static extern uint TapGesture_numberOfTaps_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TapGesture_numberOfTouches_set")]
  public static extern void TapGesture_numberOfTouches_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TapGesture_numberOfTouches_get")]
  public static extern uint TapGesture_numberOfTouches_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TapGesture_screenPoint_set")]
  public static extern void TapGesture_screenPoint_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TapGesture_screenPoint_get")]
  public static extern global::System.IntPtr TapGesture_screenPoint_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TapGesture_localPoint_set")]
  public static extern void TapGesture_localPoint_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TapGesture_localPoint_get")]
  public static extern global::System.IntPtr TapGesture_localPoint_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_AlphaFunction__SWIG_0")]
  public static extern global::System.IntPtr new_AlphaFunction__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_AlphaFunction__SWIG_1")]
  public static extern global::System.IntPtr new_AlphaFunction__SWIG_1(int jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_AlphaFunction__SWIG_2")]
  public static extern global::System.IntPtr new_AlphaFunction__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_AlphaFunction__SWIG_3")]
  public static extern global::System.IntPtr new_AlphaFunction__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AlphaFunction_GetBezierControlPoints")]
  public static extern global::System.IntPtr AlphaFunction_GetBezierControlPoints(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AlphaFunction_GetCustomFunction")]
  public static extern global::System.IntPtr AlphaFunction_GetCustomFunction(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AlphaFunction_GetBuiltinFunction")]
  public static extern int AlphaFunction_GetBuiltinFunction(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AlphaFunction_GetMode")]
  public static extern int AlphaFunction_GetMode(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_AlphaFunction")]
  public static extern void delete_AlphaFunction(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_KeyFrames_New")]
  public static extern global::System.IntPtr KeyFrames_New();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_KeyFrames_DownCast")]
  public static extern global::System.IntPtr KeyFrames_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_KeyFrames__SWIG_0")]
  public static extern global::System.IntPtr new_KeyFrames__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_KeyFrames")]
  public static extern void delete_KeyFrames(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_KeyFrames__SWIG_1")]
  public static extern global::System.IntPtr new_KeyFrames__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_KeyFrames_Assign")]
  public static extern global::System.IntPtr KeyFrames_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_KeyFrames_GetType")]
  public static extern int KeyFrames_GetType(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_KeyFrames_Add__SWIG_0")]
  public static extern void KeyFrames_Add__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_KeyFrames_Add__SWIG_1")]
  public static extern void KeyFrames_Add__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Path_Property_POINTS_get")]
  public static extern int Path_Property_POINTS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Path_Property_CONTROL_POINTS_get")]
  public static extern int Path_Property_CONTROL_POINTS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Path_Property")]
  public static extern global::System.IntPtr new_Path_Property();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Path_Property")]
  public static extern void delete_Path_Property(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Path_New")]
  public static extern global::System.IntPtr Path_New();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Path_DownCast")]
  public static extern global::System.IntPtr Path_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Path__SWIG_0")]
  public static extern global::System.IntPtr new_Path__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Path")]
  public static extern void delete_Path(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Path__SWIG_1")]
  public static extern global::System.IntPtr new_Path__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Path_Assign")]
  public static extern global::System.IntPtr Path_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Path_AddPoint")]
  public static extern void Path_AddPoint(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Path_AddControlPoint")]
  public static extern void Path_AddControlPoint(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Path_GenerateControlPoints")]
  public static extern void Path_GenerateControlPoints(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Path_Sample")]
  public static extern void Path_Sample(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Path_GetPoint")]
  public static extern global::System.IntPtr Path_GetPoint(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Path_GetControlPoint")]
  public static extern global::System.IntPtr Path_GetControlPoint(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Path_GetPointCount")]
  public static extern uint Path_GetPointCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TimePeriod__SWIG_0")]
  public static extern global::System.IntPtr new_TimePeriod__SWIG_0(float jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TimePeriod__SWIG_1")]
  public static extern global::System.IntPtr new_TimePeriod__SWIG_1(float jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_TimePeriod")]
  public static extern void delete_TimePeriod(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TimePeriod_delaySeconds_set")]
  public static extern void TimePeriod_delaySeconds_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TimePeriod_delaySeconds_get")]
  public static extern float TimePeriod_delaySeconds_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TimePeriod_durationSeconds_set")]
  public static extern void TimePeriod_durationSeconds_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TimePeriod_durationSeconds_get")]
  public static extern float TimePeriod_durationSeconds_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  //Animation Pinvoke
  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Animation__SWIG_0")]
  public static extern global::System.IntPtr new_Animation__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_New")]
  public static extern global::System.IntPtr Animation_New(float jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_DownCast")]
  public static extern global::System.IntPtr Animation_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Animation")]
  public static extern void delete_Animation(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Animation__SWIG_1")]
  public static extern global::System.IntPtr new_Animation__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_Assign")]
  public static extern global::System.IntPtr Animation_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_SetDuration")]
  public static extern void Animation_SetDuration(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_GetDuration")]
  public static extern float Animation_GetDuration(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_SetLooping")]
  public static extern void Animation_SetLooping(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_SetLoopCount")]
  public static extern void Animation_SetLoopCount(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_GetLoopCount")]
  public static extern int Animation_GetLoopCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_GetCurrentLoop")]
  public static extern int Animation_GetCurrentLoop(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_IsLooping")]
  public static extern bool Animation_IsLooping(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_SetEndAction")]
  public static extern void Animation_SetEndAction(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_GetEndAction")]
  public static extern int Animation_GetEndAction(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_SetDisconnectAction")]
  public static extern void Animation_SetDisconnectAction(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_GetDisconnectAction")]
  public static extern int Animation_GetDisconnectAction(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_SetDefaultAlphaFunction")]
  public static extern void Animation_SetDefaultAlphaFunction(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_GetDefaultAlphaFunction")]
  public static extern global::System.IntPtr Animation_GetDefaultAlphaFunction(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_SetCurrentProgress")]
  public static extern void Animation_SetCurrentProgress(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_GetCurrentProgress")]
  public static extern float Animation_GetCurrentProgress(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_SetSpeedFactor")]
  public static extern void Animation_SetSpeedFactor(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_GetSpeedFactor")]
  public static extern float Animation_GetSpeedFactor(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_SetPlayRange")]
  public static extern void Animation_SetPlayRange(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_GetPlayRange")]
  public static extern global::System.IntPtr Animation_GetPlayRange(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_Play")]
  public static extern void Animation_Play(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_PlayFrom")]
  public static extern void Animation_PlayFrom(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_Pause")]
  public static extern void Animation_Pause(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_GetState")]
  public static extern int Animation_GetState(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_Stop")]
  public static extern void Animation_Stop(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_Clear")]
  public static extern void Animation_Clear(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_SetProgressNotification")]
  public static extern void Animation_SetProgressNotification(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_GetProgressNotification")]
  public static extern float Animation_GetProgressNotification(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_FinishedSignal")]
  public static extern global::System.IntPtr Animation_FinishedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_ProgressReachedSignal")]
  public static extern global::System.IntPtr Animation_ProgressReachedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_PlayAfter")]
  public static extern void Animation_PlayAfter(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_AnimateBy__SWIG_0")]
  public static extern void Animation_AnimateBy__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_AnimateBy__SWIG_1")]
  public static extern void Animation_AnimateBy__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_AnimateBy__SWIG_2")]
  public static extern void Animation_AnimateBy__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_AnimateBy__SWIG_3")]
  public static extern void Animation_AnimateBy__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, global::System.Runtime.InteropServices.HandleRef jarg5);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_AnimateTo__SWIG_0")]
  public static extern void Animation_AnimateTo__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_AnimateTo__SWIG_1")]
  public static extern void Animation_AnimateTo__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_AnimateTo__SWIG_2")]
  public static extern void Animation_AnimateTo__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_AnimateTo__SWIG_3")]
  public static extern void Animation_AnimateTo__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, global::System.Runtime.InteropServices.HandleRef jarg5);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_AnimateBetween__SWIG_0")]
  public static extern void Animation_AnimateBetween__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_AnimateBetween__SWIG_1")]
  public static extern void Animation_AnimateBetween__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, int jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_AnimateBetween__SWIG_2")]
  public static extern void Animation_AnimateBetween__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_AnimateBetween__SWIG_3")]
  public static extern void Animation_AnimateBetween__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, int jarg5);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_AnimateBetween__SWIG_4")]
  public static extern void Animation_AnimateBetween__SWIG_4(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_AnimateBetween__SWIG_5")]
  public static extern void Animation_AnimateBetween__SWIG_5(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, int jarg5);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_AnimateBetween__SWIG_6")]
  public static extern void Animation_AnimateBetween__SWIG_6(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, global::System.Runtime.InteropServices.HandleRef jarg5);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_AnimateBetween__SWIG_7")]
  public static extern void Animation_AnimateBetween__SWIG_7(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, global::System.Runtime.InteropServices.HandleRef jarg5, int jarg6);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_Animate__SWIG_0")]
  public static extern void Animation_Animate__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_Animate__SWIG_1")]
  public static extern void Animation_Animate__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, global::System.Runtime.InteropServices.HandleRef jarg5);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_Animate__SWIG_2")]
  public static extern void Animation_Animate__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, global::System.Runtime.InteropServices.HandleRef jarg5);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_Animate__SWIG_3")]
  public static extern void Animation_Animate__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, global::System.Runtime.InteropServices.HandleRef jarg5, global::System.Runtime.InteropServices.HandleRef jarg6);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_Show")]
  public static extern void Animation_Show(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_Hide")]
  public static extern void Animation_Hide(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LinearConstrainer_Property_VALUE_get")]
  public static extern int LinearConstrainer_Property_VALUE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LinearConstrainer_Property_PROGRESS_get")]
  public static extern int LinearConstrainer_Property_PROGRESS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_LinearConstrainer_Property")]
  public static extern global::System.IntPtr new_LinearConstrainer_Property();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_LinearConstrainer_Property")]
  public static extern void delete_LinearConstrainer_Property(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LinearConstrainer_New")]
  public static extern global::System.IntPtr LinearConstrainer_New();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LinearConstrainer_DownCast")]
  public static extern global::System.IntPtr LinearConstrainer_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_LinearConstrainer__SWIG_0")]
  public static extern global::System.IntPtr new_LinearConstrainer__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_LinearConstrainer")]
  public static extern void delete_LinearConstrainer(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_LinearConstrainer__SWIG_1")]
  public static extern global::System.IntPtr new_LinearConstrainer__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LinearConstrainer_Assign")]
  public static extern global::System.IntPtr LinearConstrainer_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LinearConstrainer_Apply__SWIG_0")]
  public static extern void LinearConstrainer_Apply__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, global::System.Runtime.InteropServices.HandleRef jarg5);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LinearConstrainer_Apply__SWIG_1")]
  public static extern void LinearConstrainer_Apply__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LinearConstrainer_Remove")]
  public static extern void LinearConstrainer_Remove(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PathConstrainer_Property_FORWARD_get")]
  public static extern int PathConstrainer_Property_FORWARD_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PathConstrainer_Property_POINTS_get")]
  public static extern int PathConstrainer_Property_POINTS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PathConstrainer_Property_CONTROL_POINTS_get")]
  public static extern int PathConstrainer_Property_CONTROL_POINTS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PathConstrainer_Property")]
  public static extern global::System.IntPtr new_PathConstrainer_Property();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_PathConstrainer_Property")]
  public static extern void delete_PathConstrainer_Property(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PathConstrainer_New")]
  public static extern global::System.IntPtr PathConstrainer_New();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PathConstrainer_DownCast")]
  public static extern global::System.IntPtr PathConstrainer_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PathConstrainer__SWIG_0")]
  public static extern global::System.IntPtr new_PathConstrainer__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_PathConstrainer")]
  public static extern void delete_PathConstrainer(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PathConstrainer__SWIG_1")]
  public static extern global::System.IntPtr new_PathConstrainer__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PathConstrainer_Assign")]
  public static extern global::System.IntPtr PathConstrainer_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PathConstrainer_Apply__SWIG_0")]
  public static extern void PathConstrainer_Apply__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, global::System.Runtime.InteropServices.HandleRef jarg5);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PathConstrainer_Apply__SWIG_1")]
  public static extern void PathConstrainer_Apply__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PathConstrainer_Remove")]
  public static extern void PathConstrainer_Remove(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FittingModeDefault_get")]
  public static extern int FittingModeDefault_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_DEFAULT_get")]
  public static extern int DEFAULT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_BufferImage__SWIG_0")]
  public static extern global::System.IntPtr new_BufferImage__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_BufferImage_New__SWIG_0")]
  public static extern global::System.IntPtr BufferImage_New__SWIG_0(uint jarg1, uint jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_BufferImage_New__SWIG_1")]
  public static extern global::System.IntPtr BufferImage_New__SWIG_1(uint jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_BufferImage_New__SWIG_2")]
  public static extern global::System.IntPtr BufferImage_New__SWIG_2([global::System.Runtime.InteropServices.In, global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPArray)]byte[] jarg1, uint jarg2, uint jarg3, int jarg4, uint jarg5);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_BufferImage_New__SWIG_3")]
  public static extern global::System.IntPtr BufferImage_New__SWIG_3([global::System.Runtime.InteropServices.In, global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPArray)]byte[] jarg1, uint jarg2, uint jarg3, int jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_BufferImage_New__SWIG_4")]
  public static extern global::System.IntPtr BufferImage_New__SWIG_4([global::System.Runtime.InteropServices.In, global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPArray)]byte[] jarg1, uint jarg2, uint jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_BufferImage_DownCast")]
  public static extern global::System.IntPtr BufferImage_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_BufferImage")]
  public static extern void delete_BufferImage(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_BufferImage__SWIG_1")]
  public static extern global::System.IntPtr new_BufferImage__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_BufferImage_Assign")]
  public static extern global::System.IntPtr BufferImage_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_BufferImage_WHITE")]
  public static extern global::System.IntPtr BufferImage_WHITE();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_BufferImage_GetBuffer")]
  public static extern global::System.IntPtr BufferImage_GetBuffer(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_BufferImage_GetBufferSize")]
  public static extern uint BufferImage_GetBufferSize(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_BufferImage_GetBufferStride")]
  public static extern uint BufferImage_GetBufferStride(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_BufferImage_GetPixelFormat")]
  public static extern int BufferImage_GetPixelFormat(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_BufferImage_Update__SWIG_0")]
  public static extern void BufferImage_Update__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_BufferImage_Update__SWIG_1")]
  public static extern void BufferImage_Update__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_BufferImage_IsDataExternal")]
  public static extern bool BufferImage_IsDataExternal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_EncodedBufferImage__SWIG_0")]
  public static extern global::System.IntPtr new_EncodedBufferImage__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_EncodedBufferImage_New__SWIG_0")]
  public static extern global::System.IntPtr EncodedBufferImage_New__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_EncodedBufferImage_New__SWIG_1")]
  public static extern global::System.IntPtr EncodedBufferImage_New__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, int jarg4, int jarg5, bool jarg6);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_EncodedBufferImage_New__SWIG_2")]
  public static extern global::System.IntPtr EncodedBufferImage_New__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, int jarg4, int jarg5);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_EncodedBufferImage_DownCast")]
  public static extern global::System.IntPtr EncodedBufferImage_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_EncodedBufferImage")]
  public static extern void delete_EncodedBufferImage(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_EncodedBufferImage__SWIG_1")]
  public static extern global::System.IntPtr new_EncodedBufferImage__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_EncodedBufferImage_Assign")]
  public static extern global::System.IntPtr EncodedBufferImage_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_NativeImage__SWIG_0")]
  public static extern global::System.IntPtr new_NativeImage__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_NativeImage")]
  public static extern void delete_NativeImage(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_NativeImage__SWIG_1")]
  public static extern global::System.IntPtr new_NativeImage__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_NativeImage_Assign")]
  public static extern global::System.IntPtr NativeImage_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_NativeImage_CreateGlTexture")]
  public static extern void NativeImage_CreateGlTexture(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_NativeImage_New")]
  public static extern global::System.IntPtr NativeImage_New(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_NativeImage_DownCast")]
  public static extern global::System.IntPtr NativeImage_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_NativeImage_GetCustomFragmentPreFix")]
  public static extern string NativeImage_GetCustomFragmentPreFix(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_NativeImage_GetCustomSamplerTypename")]
  public static extern string NativeImage_GetCustomSamplerTypename(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_NativeImageInterface_GlExtensionCreate")]
  public static extern bool NativeImageInterface_GlExtensionCreate(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_NativeImageInterface_GlExtensionDestroy")]
  public static extern void NativeImageInterface_GlExtensionDestroy(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_NativeImageInterface_TargetTexture")]
  public static extern uint NativeImageInterface_TargetTexture(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_NativeImageInterface_PrepareTexture")]
  public static extern void NativeImageInterface_PrepareTexture(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_NativeImageInterface_GetWidth")]
  public static extern uint NativeImageInterface_GetWidth(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_NativeImageInterface_GetHeight")]
  public static extern uint NativeImageInterface_GetHeight(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_NativeImageInterface_RequiresBlending")]
  public static extern bool NativeImageInterface_RequiresBlending(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ResourceImage_GetImageSize")]
  public static extern global::System.IntPtr ResourceImage_GetImageSize(string jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ResourceImage__SWIG_0")]
  public static extern global::System.IntPtr new_ResourceImage__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ResourceImage")]
  public static extern void delete_ResourceImage(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ResourceImage__SWIG_1")]
  public static extern global::System.IntPtr new_ResourceImage__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ResourceImage_Assign")]
  public static extern global::System.IntPtr ResourceImage_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ResourceImage_New__SWIG_0")]
  public static extern global::System.IntPtr ResourceImage_New__SWIG_0(string jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ResourceImage_New__SWIG_1")]
  public static extern global::System.IntPtr ResourceImage_New__SWIG_1(string jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ResourceImage_New__SWIG_2")]
  public static extern global::System.IntPtr ResourceImage_New__SWIG_2(string jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, int jarg4, bool jarg5);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ResourceImage_New__SWIG_3")]
  public static extern global::System.IntPtr ResourceImage_New__SWIG_3(string jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, int jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ResourceImage_New__SWIG_4")]
  public static extern global::System.IntPtr ResourceImage_New__SWIG_4(string jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ResourceImage_New__SWIG_5")]
  public static extern global::System.IntPtr ResourceImage_New__SWIG_5(string jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ResourceImage_DownCast")]
  public static extern global::System.IntPtr ResourceImage_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ResourceImage_GetLoadingState")]
  public static extern int ResourceImage_GetLoadingState(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ResourceImage_GetUrl")]
  public static extern string ResourceImage_GetUrl(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ResourceImage_Reload")]
  public static extern void ResourceImage_Reload(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ResourceImage_LoadingFinishedSignal")]
  public static extern global::System.IntPtr ResourceImage_LoadingFinishedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_FrameBufferImage__SWIG_0")]
  public static extern global::System.IntPtr new_FrameBufferImage__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FrameBufferImage_New__SWIG_0")]
  public static extern global::System.IntPtr FrameBufferImage_New__SWIG_0(uint jarg1, uint jarg2, int jarg3, int jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FrameBufferImage_New__SWIG_1")]
  public static extern global::System.IntPtr FrameBufferImage_New__SWIG_1(uint jarg1, uint jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FrameBufferImage_New__SWIG_2")]
  public static extern global::System.IntPtr FrameBufferImage_New__SWIG_2(uint jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FrameBufferImage_New__SWIG_3")]
  public static extern global::System.IntPtr FrameBufferImage_New__SWIG_3(uint jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FrameBufferImage_New__SWIG_4")]
  public static extern global::System.IntPtr FrameBufferImage_New__SWIG_4();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FrameBufferImage_New__SWIG_5")]
  public static extern global::System.IntPtr FrameBufferImage_New__SWIG_5(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FrameBufferImage_DownCast")]
  public static extern global::System.IntPtr FrameBufferImage_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_FrameBufferImage")]
  public static extern void delete_FrameBufferImage(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_FrameBufferImage__SWIG_1")]
  public static extern global::System.IntPtr new_FrameBufferImage__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FrameBufferImage_Assign")]
  public static extern global::System.IntPtr FrameBufferImage_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_NinePatchImage__SWIG_0")]
  public static extern global::System.IntPtr new_NinePatchImage__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_NinePatchImage_New")]
  public static extern global::System.IntPtr NinePatchImage_New(string jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_NinePatchImage_DownCast")]
  public static extern global::System.IntPtr NinePatchImage_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_NinePatchImage")]
  public static extern void delete_NinePatchImage(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_NinePatchImage__SWIG_1")]
  public static extern global::System.IntPtr new_NinePatchImage__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_NinePatchImage_Assign")]
  public static extern global::System.IntPtr NinePatchImage_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_NinePatchImage_GetStretchBorders")]
  public static extern global::System.IntPtr NinePatchImage_GetStretchBorders(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_NinePatchImage_GetStretchPixelsX")]
  public static extern global::System.IntPtr NinePatchImage_GetStretchPixelsX(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_NinePatchImage_GetStretchPixelsY")]
  public static extern global::System.IntPtr NinePatchImage_GetStretchPixelsY(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_NinePatchImage_GetChildRectangle")]
  public static extern global::System.IntPtr NinePatchImage_GetChildRectangle(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_NinePatchImage_CreateCroppedBufferImage")]
  public static extern global::System.IntPtr NinePatchImage_CreateCroppedBufferImage(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_NinePatchImage_IsNinePatchUrl")]
  public static extern bool NinePatchImage_IsNinePatchUrl(string jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CameraActor_Property_TYPE_get")]
  public static extern int CameraActor_Property_TYPE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CameraActor_Property_PROJECTION_MODE_get")]
  public static extern int CameraActor_Property_PROJECTION_MODE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CameraActor_Property_FIELD_OF_VIEW_get")]
  public static extern int CameraActor_Property_FIELD_OF_VIEW_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CameraActor_Property_ASPECT_RATIO_get")]
  public static extern int CameraActor_Property_ASPECT_RATIO_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CameraActor_Property_NEAR_PLANE_DISTANCE_get")]
  public static extern int CameraActor_Property_NEAR_PLANE_DISTANCE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CameraActor_Property_FAR_PLANE_DISTANCE_get")]
  public static extern int CameraActor_Property_FAR_PLANE_DISTANCE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CameraActor_Property_LEFT_PLANE_DISTANCE_get")]
  public static extern int CameraActor_Property_LEFT_PLANE_DISTANCE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CameraActor_Property_RIGHT_PLANE_DISTANCE_get")]
  public static extern int CameraActor_Property_RIGHT_PLANE_DISTANCE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CameraActor_Property_TOP_PLANE_DISTANCE_get")]
  public static extern int CameraActor_Property_TOP_PLANE_DISTANCE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CameraActor_Property_BOTTOM_PLANE_DISTANCE_get")]
  public static extern int CameraActor_Property_BOTTOM_PLANE_DISTANCE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CameraActor_Property_TARGET_POSITION_get")]
  public static extern int CameraActor_Property_TARGET_POSITION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CameraActor_Property_PROJECTION_MATRIX_get")]
  public static extern int CameraActor_Property_PROJECTION_MATRIX_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CameraActor_Property_VIEW_MATRIX_get")]
  public static extern int CameraActor_Property_VIEW_MATRIX_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CameraActor_Property_INVERT_Y_AXIS_get")]
  public static extern int CameraActor_Property_INVERT_Y_AXIS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_CameraActor_Property")]
  public static extern global::System.IntPtr new_CameraActor_Property();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_CameraActor_Property")]
  public static extern void delete_CameraActor_Property(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_CameraActor__SWIG_0")]
  public static extern global::System.IntPtr new_CameraActor__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CameraActor_New__SWIG_0")]
  public static extern global::System.IntPtr CameraActor_New__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CameraActor_New__SWIG_1")]
  public static extern global::System.IntPtr CameraActor_New__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CameraActor_DownCast")]
  public static extern global::System.IntPtr CameraActor_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_CameraActor")]
  public static extern void delete_CameraActor(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_CameraActor__SWIG_1")]
  public static extern global::System.IntPtr new_CameraActor__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CameraActor_Assign")]
  public static extern global::System.IntPtr CameraActor_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CameraActor_SetType")]
  public static extern void CameraActor_SetType(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CameraActor_GetType")]
  public static extern int CameraActor_GetType(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CameraActor_SetProjectionMode")]
  public static extern void CameraActor_SetProjectionMode(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CameraActor_GetProjectionMode")]
  public static extern int CameraActor_GetProjectionMode(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CameraActor_SetFieldOfView")]
  public static extern void CameraActor_SetFieldOfView(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CameraActor_GetFieldOfView")]
  public static extern float CameraActor_GetFieldOfView(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CameraActor_SetAspectRatio")]
  public static extern void CameraActor_SetAspectRatio(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CameraActor_GetAspectRatio")]
  public static extern float CameraActor_GetAspectRatio(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CameraActor_SetNearClippingPlane")]
  public static extern void CameraActor_SetNearClippingPlane(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CameraActor_GetNearClippingPlane")]
  public static extern float CameraActor_GetNearClippingPlane(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CameraActor_SetFarClippingPlane")]
  public static extern void CameraActor_SetFarClippingPlane(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CameraActor_GetFarClippingPlane")]
  public static extern float CameraActor_GetFarClippingPlane(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CameraActor_SetTargetPosition")]
  public static extern void CameraActor_SetTargetPosition(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CameraActor_GetTargetPosition")]
  public static extern global::System.IntPtr CameraActor_GetTargetPosition(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CameraActor_SetInvertYAxis")]
  public static extern void CameraActor_SetInvertYAxis(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CameraActor_GetInvertYAxis")]
  public static extern bool CameraActor_GetInvertYAxis(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CameraActor_SetPerspectiveProjection")]
  public static extern void CameraActor_SetPerspectiveProjection(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CameraActor_SetOrthographicProjection__SWIG_0")]
  public static extern void CameraActor_SetOrthographicProjection__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CameraActor_SetOrthographicProjection__SWIG_1")]
  public static extern void CameraActor_SetOrthographicProjection__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3, float jarg4, float jarg5, float jarg6, float jarg7);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_StringValuePair__SWIG_0")]
  public static extern global::System.IntPtr new_StringValuePair__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_StringValuePair__SWIG_1")]
  public static extern global::System.IntPtr new_StringValuePair__SWIG_1(string jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_StringValuePair__SWIG_2")]
  public static extern global::System.IntPtr new_StringValuePair__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_StringValuePair_first_set")]
  public static extern void StringValuePair_first_set(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_StringValuePair_first_get")]
  public static extern string StringValuePair_first_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_StringValuePair_second_set")]
  public static extern void StringValuePair_second_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_StringValuePair_second_get")]
  public static extern global::System.IntPtr StringValuePair_second_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_StringValuePair")]
  public static extern void delete_StringValuePair(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TouchPointContainer_Clear")]
  public static extern void TouchPointContainer_Clear(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TouchPointContainer_Add")]
  public static extern void TouchPointContainer_Add(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TouchPointContainer_size")]
  public static extern uint TouchPointContainer_size(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TouchPointContainer_capacity")]
  public static extern uint TouchPointContainer_capacity(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TouchPointContainer_reserve")]
  public static extern void TouchPointContainer_reserve(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TouchPointContainer__SWIG_0")]
  public static extern global::System.IntPtr new_TouchPointContainer__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TouchPointContainer__SWIG_1")]
  public static extern global::System.IntPtr new_TouchPointContainer__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TouchPointContainer__SWIG_2")]
  public static extern global::System.IntPtr new_TouchPointContainer__SWIG_2(int jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TouchPointContainer_getitemcopy")]
  public static extern global::System.IntPtr TouchPointContainer_getitemcopy(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TouchPointContainer_getitem")]
  public static extern global::System.IntPtr TouchPointContainer_getitem(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TouchPointContainer_setitem")]
  public static extern void TouchPointContainer_setitem(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TouchPointContainer_AddRange")]
  public static extern void TouchPointContainer_AddRange(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TouchPointContainer_GetRange")]
  public static extern global::System.IntPtr TouchPointContainer_GetRange(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TouchPointContainer_Insert")]
  public static extern void TouchPointContainer_Insert(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TouchPointContainer_InsertRange")]
  public static extern void TouchPointContainer_InsertRange(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TouchPointContainer_RemoveAt")]
  public static extern void TouchPointContainer_RemoveAt(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TouchPointContainer_RemoveRange")]
  public static extern void TouchPointContainer_RemoveRange(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TouchPointContainer_Repeat")]
  public static extern global::System.IntPtr TouchPointContainer_Repeat(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TouchPointContainer_Reverse__SWIG_0")]
  public static extern void TouchPointContainer_Reverse__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TouchPointContainer_Reverse__SWIG_1")]
  public static extern void TouchPointContainer_Reverse__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TouchPointContainer_SetRange")]
  public static extern void TouchPointContainer_SetRange(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_TouchPointContainer")]
  public static extern void delete_TouchPointContainer(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Rectangle__SWIG_0")]
  public static extern global::System.IntPtr new_Rectangle__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Rectangle__SWIG_1")]
  public static extern global::System.IntPtr new_Rectangle__SWIG_1(int jarg1, int jarg2, int jarg3, int jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Rectangle__SWIG_2")]
  public static extern global::System.IntPtr new_Rectangle__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rectangle_Assign")]
  public static extern global::System.IntPtr Rectangle_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rectangle_Set")]
  public static extern void Rectangle_Set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3, int jarg4, int jarg5);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rectangle_IsEmpty")]
  public static extern bool Rectangle_IsEmpty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rectangle_Left")]
  public static extern int Rectangle_Left(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rectangle_Right")]
  public static extern int Rectangle_Right(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rectangle_Top")]
  public static extern int Rectangle_Top(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rectangle_Bottom")]
  public static extern int Rectangle_Bottom(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rectangle_Area")]
  public static extern int Rectangle_Area(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rectangle_Intersects")]
  public static extern bool Rectangle_Intersects(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rectangle_Contains")]
  public static extern bool Rectangle_Contains(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rectangle_x_set")]
  public static extern void Rectangle_x_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rectangle_x_get")]
  public static extern int Rectangle_x_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rectangle_left_set")]
  public static extern void Rectangle_left_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rectangle_left_get")]
  public static extern int Rectangle_left_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rectangle_y_set")]
  public static extern void Rectangle_y_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rectangle_y_get")]
  public static extern int Rectangle_y_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rectangle_right_set")]
  public static extern void Rectangle_right_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rectangle_right_get")]
  public static extern int Rectangle_right_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rectangle_width_set")]
  public static extern void Rectangle_width_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rectangle_width_get")]
  public static extern int Rectangle_width_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rectangle_bottom_set")]
  public static extern void Rectangle_bottom_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rectangle_bottom_get")]
  public static extern int Rectangle_bottom_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rectangle_height_set")]
  public static extern void Rectangle_height_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rectangle_height_get")]
  public static extern int Rectangle_height_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rectangle_top_set")]
  public static extern void Rectangle_top_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Rectangle_top_get")]
  public static extern int Rectangle_top_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Rectangle")]
  public static extern void delete_Rectangle(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PaddingType__SWIG_0")]
  public static extern global::System.IntPtr new_PaddingType__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PaddingType__SWIG_1")]
  public static extern global::System.IntPtr new_PaddingType__SWIG_1(float jarg1, float jarg2, float jarg3, float jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PaddingType__SWIG_2")]
  public static extern global::System.IntPtr new_PaddingType__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PaddingType_Assign")]
  public static extern global::System.IntPtr PaddingType_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PaddingType_Set")]
  public static extern void PaddingType_Set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3, float jarg4, float jarg5);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PaddingType_left_set")]
  public static extern void PaddingType_left_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PaddingType_left_get")]
  public static extern float PaddingType_left_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PaddingType_start_set")]
  public static extern void PaddingType_start_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PaddingType_start_get")]
   public static extern float PaddingType_start_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PaddingType_right_set")]
  public static extern void PaddingType_right_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PaddingType_right_get")]
  public static extern float PaddingType_right_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PaddingType_end_set")]
  public static extern void PaddingType_end_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PaddingType_end_get")]
  public static extern float PaddingType_end_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PaddingType_bottom_set")]
  public static extern void PaddingType_bottom_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PaddingType_bottom_get")]
  public static extern float PaddingType_bottom_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PaddingType_top_set")]
  public static extern void PaddingType_top_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PaddingType_top_get")]
  public static extern float PaddingType_top_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_PaddingType")]
  public static extern void delete_PaddingType(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorInteger_BaseType_get")]
  public static extern int VectorInteger_BaseType_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_VectorInteger__SWIG_0")]
  public static extern global::System.IntPtr new_VectorInteger__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_VectorInteger")]
  public static extern void delete_VectorInteger(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_VectorInteger__SWIG_1")]
  public static extern global::System.IntPtr new_VectorInteger__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorInteger_Assign")]
  public static extern global::System.IntPtr VectorInteger_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorInteger_Begin")]
  public static extern global::System.IntPtr VectorInteger_Begin(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorInteger_End")]
  public static extern global::System.IntPtr VectorInteger_End(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorInteger_ValueOfIndex__SWIG_0")]
  public static extern global::System.IntPtr VectorInteger_ValueOfIndex__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorInteger_PushBack")]
  public static extern void VectorInteger_PushBack(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorInteger_Insert__SWIG_0")]
  public static extern void VectorInteger_Insert__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorInteger_Insert__SWIG_1")]
  public static extern void VectorInteger_Insert__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorInteger_Reserve")]
  public static extern void VectorInteger_Reserve(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorInteger_Resize__SWIG_0")]
  public static extern void VectorInteger_Resize__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorInteger_Resize__SWIG_1")]
  public static extern void VectorInteger_Resize__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorInteger_Erase__SWIG_0")]
  public static extern global::System.IntPtr VectorInteger_Erase__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorInteger_Erase__SWIG_1")]
  public static extern global::System.IntPtr VectorInteger_Erase__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorInteger_Remove")]
  public static extern void VectorInteger_Remove(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorInteger_Swap")]
  public static extern void VectorInteger_Swap(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorInteger_Clear")]
  public static extern void VectorInteger_Clear(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorInteger_Release")]
  public static extern void VectorInteger_Release(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorFloat_BaseType_get")]
  public static extern int VectorFloat_BaseType_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_VectorFloat__SWIG_0")]
  public static extern global::System.IntPtr new_VectorFloat__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_VectorFloat")]
  public static extern void delete_VectorFloat(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_VectorFloat__SWIG_1")]
  public static extern global::System.IntPtr new_VectorFloat__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorFloat_Assign")]
  public static extern global::System.IntPtr VectorFloat_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorFloat_Begin")]
  public static extern global::System.IntPtr VectorFloat_Begin(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorFloat_End")]
  public static extern global::System.IntPtr VectorFloat_End(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorFloat_ValueOfIndex__SWIG_0")]
  public static extern global::System.IntPtr VectorFloat_ValueOfIndex__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorFloat_PushBack")]
  public static extern void VectorFloat_PushBack(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorFloat_Insert__SWIG_0")]
  public static extern void VectorFloat_Insert__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorFloat_Insert__SWIG_1")]
  public static extern void VectorFloat_Insert__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorFloat_Reserve")]
  public static extern void VectorFloat_Reserve(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorFloat_Resize__SWIG_0")]
  public static extern void VectorFloat_Resize__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorFloat_Resize__SWIG_1")]
  public static extern void VectorFloat_Resize__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorFloat_Erase__SWIG_0")]
  public static extern global::System.IntPtr VectorFloat_Erase__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorFloat_Erase__SWIG_1")]
  public static extern global::System.IntPtr VectorFloat_Erase__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorFloat_Remove")]
  public static extern void VectorFloat_Remove(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorFloat_Swap")]
  public static extern void VectorFloat_Swap(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorFloat_Clear")]
  public static extern void VectorFloat_Clear(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorFloat_Release")]
  public static extern void VectorFloat_Release(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorUnsignedChar_BaseType_get")]
  public static extern int VectorUnsignedChar_BaseType_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_VectorUnsignedChar__SWIG_0")]
  public static extern global::System.IntPtr new_VectorUnsignedChar__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_VectorUnsignedChar")]
  public static extern void delete_VectorUnsignedChar(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_VectorUnsignedChar__SWIG_1")]
  public static extern global::System.IntPtr new_VectorUnsignedChar__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorUnsignedChar_Assign")]
  public static extern global::System.IntPtr VectorUnsignedChar_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorUnsignedChar_Begin")]
  public static extern global::System.IntPtr VectorUnsignedChar_Begin(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorUnsignedChar_End")]
  public static extern global::System.IntPtr VectorUnsignedChar_End(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorUnsignedChar_ValueOfIndex__SWIG_0")]
  public static extern global::System.IntPtr VectorUnsignedChar_ValueOfIndex__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorUnsignedChar_PushBack")]
  public static extern void VectorUnsignedChar_PushBack(global::System.Runtime.InteropServices.HandleRef jarg1, byte jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorUnsignedChar_Insert__SWIG_0")]
  public static extern void VectorUnsignedChar_Insert__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, [global::System.Runtime.InteropServices.In, global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPArray)]byte[] jarg2, byte jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorUnsignedChar_Insert__SWIG_1")]
  public static extern void VectorUnsignedChar_Insert__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, [global::System.Runtime.InteropServices.In, global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPArray)]byte[] jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorUnsignedChar_Reserve")]
  public static extern void VectorUnsignedChar_Reserve(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorUnsignedChar_Resize__SWIG_0")]
  public static extern void VectorUnsignedChar_Resize__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorUnsignedChar_Resize__SWIG_1")]
  public static extern void VectorUnsignedChar_Resize__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, byte jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorUnsignedChar_Erase__SWIG_0")]
  public static extern global::System.IntPtr VectorUnsignedChar_Erase__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, [global::System.Runtime.InteropServices.In, global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPArray)]byte[] jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorUnsignedChar_Erase__SWIG_1")]
  public static extern global::System.IntPtr VectorUnsignedChar_Erase__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, [global::System.Runtime.InteropServices.In, global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPArray)]byte[] jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorUnsignedChar_Remove")]
  public static extern void VectorUnsignedChar_Remove(global::System.Runtime.InteropServices.HandleRef jarg1, [global::System.Runtime.InteropServices.In, global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPArray)]byte[] jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorUnsignedChar_Swap")]
  public static extern void VectorUnsignedChar_Swap(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorUnsignedChar_Clear")]
  public static extern void VectorUnsignedChar_Clear(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorUnsignedChar_Release")]
  public static extern void VectorUnsignedChar_Release(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorUint16Pair_BaseType_get")]
  public static extern int VectorUint16Pair_BaseType_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_VectorUint16Pair__SWIG_0")]
  public static extern global::System.IntPtr new_VectorUint16Pair__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_VectorUint16Pair")]
  public static extern void delete_VectorUint16Pair(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_VectorUint16Pair__SWIG_1")]
  public static extern global::System.IntPtr new_VectorUint16Pair__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorUint16Pair_Assign")]
  public static extern global::System.IntPtr VectorUint16Pair_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorUint16Pair_Begin")]
  public static extern global::System.IntPtr VectorUint16Pair_Begin(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorUint16Pair_End")]
  public static extern global::System.IntPtr VectorUint16Pair_End(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorUint16Pair_ValueOfIndex__SWIG_0")]
  public static extern global::System.IntPtr VectorUint16Pair_ValueOfIndex__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorUint16Pair_PushBack")]
  public static extern void VectorUint16Pair_PushBack(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorUint16Pair_Insert__SWIG_0")]
  public static extern void VectorUint16Pair_Insert__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorUint16Pair_Insert__SWIG_1")]
  public static extern void VectorUint16Pair_Insert__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorUint16Pair_Reserve")]
  public static extern void VectorUint16Pair_Reserve(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorUint16Pair_Resize__SWIG_0")]
  public static extern void VectorUint16Pair_Resize__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorUint16Pair_Resize__SWIG_1")]
  public static extern void VectorUint16Pair_Resize__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorUint16Pair_Erase__SWIG_0")]
  public static extern global::System.IntPtr VectorUint16Pair_Erase__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorUint16Pair_Erase__SWIG_1")]
  public static extern global::System.IntPtr VectorUint16Pair_Erase__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorUint16Pair_Remove")]
  public static extern void VectorUint16Pair_Remove(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorUint16Pair_Swap")]
  public static extern void VectorUint16Pair_Swap(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorUint16Pair_Clear")]
  public static extern void VectorUint16Pair_Clear(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VectorUint16Pair_Release")]
  public static extern void VectorUint16Pair_Release(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_VoidSignal")]
  public static extern global::System.IntPtr new_VoidSignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_VoidSignal")]
  public static extern void delete_VoidSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VoidSignal_Empty")]
  public static extern bool VoidSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VoidSignal_GetConnectionCount")]
  public static extern uint VoidSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VoidSignal_Connect__SWIG_0")]
  public static extern void VoidSignal_Connect__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VoidSignal_Disconnect")]
  public static extern void VoidSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VoidSignal_Connect__SWIG_4")]
  public static extern void VoidSignal_Connect__SWIG_4(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VoidSignal_Emit")]
  public static extern void VoidSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FloatSignal_Empty")]
  public static extern bool FloatSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FloatSignal_GetConnectionCount")]
  public static extern uint FloatSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FloatSignal_Connect")]
  public static extern void FloatSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FloatSignal_Disconnect")]
  public static extern void FloatSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FloatSignal_Emit")]
  public static extern void FloatSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_FloatSignal")]
  public static extern global::System.IntPtr new_FloatSignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_FloatSignal")]
  public static extern void delete_FloatSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ObjectCreatedSignal_Empty")]
  public static extern bool ObjectCreatedSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ObjectCreatedSignal_GetConnectionCount")]
  public static extern uint ObjectCreatedSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ObjectCreatedSignal_Connect")]
  public static extern void ObjectCreatedSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ObjectCreatedSignal_Disconnect")]
  public static extern void ObjectCreatedSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ObjectCreatedSignal_Emit")]
  public static extern void ObjectCreatedSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ObjectCreatedSignal")]
  public static extern global::System.IntPtr new_ObjectCreatedSignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ObjectCreatedSignal")]
  public static extern void delete_ObjectCreatedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ObjectDestroyedSignal_Empty")]
  public static extern bool ObjectDestroyedSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ObjectDestroyedSignal_GetConnectionCount")]
  public static extern uint ObjectDestroyedSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ObjectDestroyedSignal_Connect")]
  public static extern void ObjectDestroyedSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ObjectDestroyedSignal_Disconnect")]
  public static extern void ObjectDestroyedSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ObjectDestroyedSignal_Emit")]
  public static extern void ObjectDestroyedSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ObjectDestroyedSignal")]
  public static extern global::System.IntPtr new_ObjectDestroyedSignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ObjectDestroyedSignal")]
  public static extern void delete_ObjectDestroyedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PropertyNotifySignal_Empty")]
  public static extern bool PropertyNotifySignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PropertyNotifySignal_GetConnectionCount")]
  public static extern uint PropertyNotifySignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PropertyNotifySignal_Connect")]
  public static extern void PropertyNotifySignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PropertyNotifySignal_Disconnect")]
  public static extern void PropertyNotifySignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PropertyNotifySignal_Emit")]
  public static extern void PropertyNotifySignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PropertyNotifySignal")]
  public static extern global::System.IntPtr new_PropertyNotifySignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_PropertyNotifySignal")]
  public static extern void delete_PropertyNotifySignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ImageSignal_Empty")]
  public static extern bool ImageSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ImageSignal_GetConnectionCount")]
  public static extern uint ImageSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ImageSignal_Connect")]
  public static extern void ImageSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ImageSignal_Disconnect")]
  public static extern void ImageSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ImageSignal_Emit")]
  public static extern void ImageSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ImageSignal")]
  public static extern global::System.IntPtr new_ImageSignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ImageSignal")]
  public static extern void delete_ImageSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_RenderTaskSignal")]
  public static extern global::System.IntPtr new_RenderTaskSignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_RenderTaskSignal")]
  public static extern void delete_RenderTaskSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LongPressGestureDetectedSignal_Empty")]
  public static extern bool LongPressGestureDetectedSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LongPressGestureDetectedSignal_GetConnectionCount")]
  public static extern uint LongPressGestureDetectedSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LongPressGestureDetectedSignal_Connect")]
  public static extern void LongPressGestureDetectedSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LongPressGestureDetectedSignal_Disconnect")]
  public static extern void LongPressGestureDetectedSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LongPressGestureDetectedSignal_Emit")]
  public static extern void LongPressGestureDetectedSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_LongPressGestureDetectedSignal")]
  public static extern global::System.IntPtr new_LongPressGestureDetectedSignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_LongPressGestureDetectedSignal")]
  public static extern void delete_LongPressGestureDetectedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ActorTouchDataSignal_Empty")]
  public static extern bool ActorTouchDataSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ActorTouchDataSignal_GetConnectionCount")]
  public static extern uint ActorTouchDataSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ActorTouchDataSignal_Connect")]
  public static extern void ActorTouchDataSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ActorTouchDataSignal_Disconnect")]
  public static extern void ActorTouchDataSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ActorTouchDataSignal_Emit")]
  public static extern bool ActorTouchDataSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ActorTouchDataSignal")]
  public static extern global::System.IntPtr new_ActorTouchDataSignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ActorTouchDataSignal")]
  public static extern void delete_ActorTouchDataSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ActorHoverSignal_Empty")]
  public static extern bool ActorHoverSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ActorHoverSignal_GetConnectionCount")]
  public static extern uint ActorHoverSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ActorHoverSignal_Connect")]
  public static extern void ActorHoverSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ActorHoverSignal_Disconnect")]
  public static extern void ActorHoverSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ActorHoverSignal_Emit")]
  public static extern bool ActorHoverSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ActorHoverSignal")]
  public static extern global::System.IntPtr new_ActorHoverSignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ActorHoverSignal")]
  public static extern void delete_ActorHoverSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ActorWheelSignal_Empty")]
  public static extern bool ActorWheelSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ActorWheelSignal_GetConnectionCount")]
  public static extern uint ActorWheelSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ActorWheelSignal_Connect")]
  public static extern void ActorWheelSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ActorWheelSignal_Disconnect")]
  public static extern void ActorWheelSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ActorWheelSignal_Emit")]
  public static extern bool ActorWheelSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ActorWheelSignal")]
  public static extern global::System.IntPtr new_ActorWheelSignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ActorWheelSignal")]
  public static extern void delete_ActorWheelSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ActorSignal_Empty")]
  public static extern bool ActorSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ActorSignal_GetConnectionCount")]
  public static extern uint ActorSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ActorSignal_Connect")]
  public static extern void ActorSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ActorSignal_Disconnect")]
  public static extern void ActorSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ActorSignal_Emit")]
  public static extern void ActorSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ActorSignal")]
  public static extern global::System.IntPtr new_ActorSignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ActorSignal")]
  public static extern void delete_ActorSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_KeyEventSignal_Empty")]
  public static extern bool KeyEventSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_KeyEventSignal_GetConnectionCount")]
  public static extern uint KeyEventSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_KeyEventSignal_Connect")]
  public static extern void KeyEventSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_KeyEventSignal_Disconnect")]
  public static extern void KeyEventSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_KeyEventSignal_Emit")]
  public static extern void KeyEventSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_KeyEventSignal")]
  public static extern global::System.IntPtr new_KeyEventSignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_KeyEventSignal")]
  public static extern void delete_KeyEventSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TouchSignal_Empty")]
  public static extern bool TouchSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TouchSignal_GetConnectionCount")]
  public static extern uint TouchSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TouchSignal_Connect")]
  public static extern void TouchSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TouchSignal_Disconnect")]
  public static extern void TouchSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TouchSignal_Emit")]
  public static extern void TouchSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TouchSignal")]
  public static extern global::System.IntPtr new_TouchSignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_TouchSignal")]
  public static extern void delete_TouchSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_StageWheelSignal_Empty")]
  public static extern bool StageWheelSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_StageWheelSignal_GetConnectionCount")]
  public static extern uint StageWheelSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_StageWheelSignal_Connect")]
  public static extern void StageWheelSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_StageWheelSignal_Disconnect")]
  public static extern void StageWheelSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_StageWheelSignal_Emit")]
  public static extern void StageWheelSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_StageWheelSignal")]
  public static extern global::System.IntPtr new_StageWheelSignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_StageWheelSignal")]
  public static extern void delete_StageWheelSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_AngleThresholdPair__SWIG_0")]
  public static extern global::System.IntPtr new_AngleThresholdPair__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_AngleThresholdPair__SWIG_1")]
  public static extern global::System.IntPtr new_AngleThresholdPair__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_AngleThresholdPair__SWIG_2")]
  public static extern global::System.IntPtr new_AngleThresholdPair__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AngleThresholdPair_first_set")]
  public static extern void AngleThresholdPair_first_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AngleThresholdPair_first_get")]
  public static extern global::System.IntPtr AngleThresholdPair_first_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AngleThresholdPair_second_set")]
  public static extern void AngleThresholdPair_second_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AngleThresholdPair_second_get")]
  public static extern global::System.IntPtr AngleThresholdPair_second_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_AngleThresholdPair")]
  public static extern void delete_AngleThresholdPair(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGestureDetectedSignal_Empty")]
  public static extern bool PanGestureDetectedSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGestureDetectedSignal_GetConnectionCount")]
  public static extern uint PanGestureDetectedSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGestureDetectedSignal_Connect")]
  public static extern void PanGestureDetectedSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGestureDetectedSignal_Disconnect")]
  public static extern void PanGestureDetectedSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGestureDetectedSignal_Emit")]
  public static extern void PanGestureDetectedSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PanGestureDetectedSignal")]
  public static extern global::System.IntPtr new_PanGestureDetectedSignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_PanGestureDetectedSignal")]
  public static extern void delete_PanGestureDetectedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PinchGestureDetectedSignal_Empty")]
  public static extern bool PinchGestureDetectedSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PinchGestureDetectedSignal_GetConnectionCount")]
  public static extern uint PinchGestureDetectedSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PinchGestureDetectedSignal_Connect")]
  public static extern void PinchGestureDetectedSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PinchGestureDetectedSignal_Disconnect")]
  public static extern void PinchGestureDetectedSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PinchGestureDetectedSignal_Emit")]
  public static extern void PinchGestureDetectedSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PinchGestureDetectedSignal")]
  public static extern global::System.IntPtr new_PinchGestureDetectedSignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_PinchGestureDetectedSignal")]
  public static extern void delete_PinchGestureDetectedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TapGestureDetectedSignal_Empty")]
  public static extern bool TapGestureDetectedSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TapGestureDetectedSignal_GetConnectionCount")]
  public static extern uint TapGestureDetectedSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TapGestureDetectedSignal_Connect")]
  public static extern void TapGestureDetectedSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TapGestureDetectedSignal_Disconnect")]
  public static extern void TapGestureDetectedSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TapGestureDetectedSignal_Emit")]
  public static extern void TapGestureDetectedSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TapGestureDetectedSignal")]
  public static extern global::System.IntPtr new_TapGestureDetectedSignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_TapGestureDetectedSignal")]
  public static extern void delete_TapGestureDetectedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AnimationSignal_Empty")]
  public static extern bool AnimationSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AnimationSignal_GetConnectionCount")]
  public static extern uint AnimationSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AnimationSignal_Connect")]
  public static extern void AnimationSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AnimationSignal_Disconnect")]
  public static extern void AnimationSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AnimationSignal_Emit")]
  public static extern void AnimationSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_AnimationSignal")]
  public static extern global::System.IntPtr new_AnimationSignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_AnimationSignal")]
  public static extern void delete_AnimationSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ResourceImageSignal_Empty")]
  public static extern bool ResourceImageSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ResourceImageSignal_GetConnectionCount")]
  public static extern uint ResourceImageSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ResourceImageSignal_Connect")]
  public static extern void ResourceImageSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ResourceImageSignal_Disconnect")]
  public static extern void ResourceImageSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ResourceImageSignal_Emit")]
  public static extern void ResourceImageSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ResourceImageSignal")]
  public static extern global::System.IntPtr new_ResourceImageSignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ResourceImageSignal")]
  public static extern void delete_ResourceImageSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewVisibilityChangedSignal_Empty")]
  public static extern bool ViewVisibilityChangedSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewVisibilityChangedSignal_GetConnectionCount")]
  public static extern uint ViewVisibilityChangedSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewVisibilityChangedSignal_Connect")]
  public static extern void ViewVisibilityChangedSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewVisibilityChangedSignal_Disconnect")]
  public static extern void ViewVisibilityChangedSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewVisibilityChangedSignal_Emit")]
  public static extern void ViewVisibilityChangedSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ViewVisibilityChangedSignal")]
  public static extern global::System.IntPtr new_ViewVisibilityChangedSignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ViewVisibilityChangedSignal")]
  public static extern void delete_ViewVisibilityChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);
  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Timer__SWIG_0")]
  public static extern global::System.IntPtr new_Timer__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Timer_New")]
  public static extern global::System.IntPtr Timer_New(uint jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Timer__SWIG_1")]
  public static extern global::System.IntPtr new_Timer__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Timer_Assign")]
  public static extern global::System.IntPtr Timer_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Timer")]
  public static extern void delete_Timer(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Timer_DownCast")]
  public static extern global::System.IntPtr Timer_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Timer_Start")]
  public static extern void Timer_Start(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Timer_Stop")]
  public static extern void Timer_Stop(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Timer_SetInterval")]
  public static extern void Timer_SetInterval(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Timer_GetInterval")]
  public static extern uint Timer_GetInterval(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Timer_IsRunning")]
  public static extern bool Timer_IsRunning(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Timer_TickSignal")]
  public static extern global::System.IntPtr Timer_TickSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_DragAndDropDetector")]
  public static extern global::System.IntPtr new_DragAndDropDetector();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_DragAndDropDetector")]
  public static extern void delete_DragAndDropDetector(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_DragAndDropDetector_GetContent")]
  public static extern string DragAndDropDetector_GetContent(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_DragAndDropDetector_GetCurrentScreenPosition")]
  public static extern global::System.IntPtr DragAndDropDetector_GetCurrentScreenPosition(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_DragAndDropDetector_EnteredSignal")]
  public static extern global::System.IntPtr DragAndDropDetector_EnteredSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_DragAndDropDetector_ExitedSignal")]
  public static extern global::System.IntPtr DragAndDropDetector_ExitedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_DragAndDropDetector_MovedSignal")]
  public static extern global::System.IntPtr DragAndDropDetector_MovedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_DragAndDropDetector_DroppedSignal")]
  public static extern global::System.IntPtr DragAndDropDetector_DroppedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ApplicationExtensions__SWIG_0")]
  public static extern global::System.IntPtr new_ApplicationExtensions__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ApplicationExtensions__SWIG_1")]
  public static extern global::System.IntPtr new_ApplicationExtensions__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ApplicationExtensions")]
  public static extern void delete_ApplicationExtensions(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ApplicationExtensions_Init")]
  public static extern void ApplicationExtensions_Init(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ApplicationExtensions_Start")]
  public static extern void ApplicationExtensions_Start(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ApplicationExtensions_Terminate")]
  public static extern void ApplicationExtensions_Terminate(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ApplicationExtensions_Pause")]
  public static extern void ApplicationExtensions_Pause(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ApplicationExtensions_Resume")]
  public static extern void ApplicationExtensions_Resume(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ApplicationExtensions_LanguageChange")]
  public static extern void ApplicationExtensions_LanguageChange(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Window_New__SWIG_0")]
  public static extern global::System.IntPtr Window_New__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, bool jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Window_New__SWIG_1")]
  public static extern global::System.IntPtr Window_New__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Window_New__SWIG_2")]
  public static extern global::System.IntPtr Window_New__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, string jarg3, bool jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Window_New__SWIG_3")]
  public static extern global::System.IntPtr Window_New__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, string jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Window__SWIG_0")]
  public static extern global::System.IntPtr new_Window__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Window")]
  public static extern void delete_Window(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Window__SWIG_1")]
  public static extern global::System.IntPtr new_Window__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Window_Assign")]
  public static extern global::System.IntPtr Window_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Window_ShowIndicator")]
  public static extern void Window_ShowIndicator(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Window_SetIndicatorBgOpacity")]
  public static extern void Window_SetIndicatorBgOpacity(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Window_RotateIndicator")]
  public static extern void Window_RotateIndicator(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Window_SetClass")]
  public static extern void Window_SetClass(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, string jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Window_Raise")]
  public static extern void Window_Raise(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Window_Lower")]
  public static extern void Window_Lower(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Window_Activate")]
  public static extern void Window_Activate(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Window_AddAvailableOrientation")]
  public static extern void Window_AddAvailableOrientation(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Window_RemoveAvailableOrientation")]
  public static extern void Window_RemoveAvailableOrientation(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Window_SetPreferredOrientation")]
  public static extern void Window_SetPreferredOrientation(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Window_GetPreferredOrientation")]
  public static extern int Window_GetPreferredOrientation(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Window_GetDragAndDropDetector")]
  public static extern global::System.IntPtr Window_GetDragAndDropDetector(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Window_GetNativeHandle")]
  public static extern global::System.IntPtr Window_GetNativeHandle(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FocusChangedSignal")]
  public static extern global::System.IntPtr FocusChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_SetAcceptFocus")]
  public static extern void SetAcceptFocus(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_IsFocusAcceptable")]
  public static extern bool IsFocusAcceptable(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Show")]
  public static extern void Show(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Hide")]
  public static extern void Hide(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_IsVisible")]
  public static extern bool IsVisible(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GetSupportedAuxiliaryHintCount")]
  public static extern uint GetSupportedAuxiliaryHintCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GetSupportedAuxiliaryHint")]
  public static extern string GetSupportedAuxiliaryHint(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AddAuxiliaryHint")]
  public static extern uint AddAuxiliaryHint(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, string jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RemoveAuxiliaryHint")]
  public static extern bool RemoveAuxiliaryHint(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_SetAuxiliaryHintValue")]
  public static extern bool SetAuxiliaryHintValue(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, string jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GetAuxiliaryHintValue")]
  public static extern string GetAuxiliaryHintValue(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GetAuxiliaryHintId")]
  public static extern uint GetAuxiliaryHintId(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_SetInputRegion")]
  public static extern void SetInputRegion(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_SetType")]
  public static extern void SetType(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GetType")]
  public static extern int GetType(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_SetNotificationLevel")]
  public static extern bool SetNotificationLevel(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GetNotificationLevel")]
  public static extern int GetNotificationLevel(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_SetOpaqueState")]
  public static extern void SetOpaqueState(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_IsOpaqueState")]
  public static extern bool IsOpaqueState(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_SetScreenOffMode")]
  public static extern bool SetScreenOffMode(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GetScreenOffMode")]
  public static extern int GetScreenOffMode(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_SetBrightness")]
  public static extern bool SetBrightness(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GetBrightness")]
  public static extern int GetBrightness(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_New__SWIG_0")]
  public static extern global::System.IntPtr Application_New__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_New__SWIG_1")]
  public static extern global::System.IntPtr Application_New__SWIG_1(int jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_New__SWIG_2")]
  public static extern global::System.IntPtr Application_New__SWIG_2(int jarg1, string jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_New__SWIG_3")]
  public static extern global::System.IntPtr Application_New__SWIG_3(int jarg1, string jarg3, int jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_New__MANUAL_4")]
  public static extern global::System.IntPtr Application_New__MANUAL_4(int jarg1, string jarg2, string jarg3, int jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Application__SWIG_0")]
  public static extern global::System.IntPtr new_Application__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Application__SWIG_1")]
  public static extern global::System.IntPtr new_Application__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_Assign")]
  public static extern global::System.IntPtr Application_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Application")]
  public static extern void delete_Application(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_MainLoop__SWIG_0")]
  public static extern void Application_MainLoop__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_MainLoop__SWIG_1")]
  public static extern void Application_MainLoop__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_Lower")]
  public static extern void Application_Lower(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_Quit")]
  public static extern void Application_Quit(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_AddIdle")]
  public static extern bool Application_AddIdle(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_GetWindow")]
  public static extern global::System.IntPtr Application_GetWindow(global::System.Runtime.InteropServices.HandleRef jarg1);


  //window handle test
  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_GetWindowHandleFromNUI")]
  public static extern global::System.IntPtr Application_GetWindowHandleFromNUI(global::System.Runtime.InteropServices.HandleRef jarg1);


  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_ReplaceWindow")]
  public static extern void Application_ReplaceWindow(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, string jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_GetResourcePath")]
  public static extern string Application_GetResourcePath();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_SetViewMode")]
  public static extern void Application_SetViewMode(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_GetViewMode")]
  public static extern int Application_GetViewMode(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_SetStereoBase")]
  public static extern void Application_SetStereoBase(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_GetStereoBase")]
  public static extern float Application_GetStereoBase(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Application_GetLanguage")]
  public static extern string Application_GetLanguage(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Application_GetRegion")]
  public static extern string Application_GetRegion(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_InitSignal")]
  public static extern global::System.IntPtr Application_InitSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_TerminateSignal")]
  public static extern global::System.IntPtr Application_TerminateSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_PauseSignal")]
  public static extern global::System.IntPtr Application_PauseSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_ResumeSignal")]
  public static extern global::System.IntPtr Application_ResumeSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_ResetSignal")]
  public static extern global::System.IntPtr Application_ResetSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_ResizeSignal")]
  public static extern global::System.IntPtr Application_ResizeSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_AppControlSignal")]
  public static extern global::System.IntPtr Application_AppControlSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_LanguageChangedSignal")]
  public static extern global::System.IntPtr Application_LanguageChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_RegionChangedSignal")]
  public static extern global::System.IntPtr Application_RegionChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_LowBatterySignal")]
  public static extern global::System.IntPtr Application_LowBatterySignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_LowMemorySignal")]
  public static extern global::System.IntPtr Application_LowMemorySignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ApplicationSignal_Empty")]
  public static extern bool ApplicationSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ApplicationSignal_GetConnectionCount")]
  public static extern uint ApplicationSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ApplicationSignal_Connect")]
  public static extern void ApplicationSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ApplicationSignal_Disconnect")]
  public static extern void ApplicationSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ApplicationSignal_Emit")]
  public static extern void ApplicationSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ApplicationSignal")]
  public static extern global::System.IntPtr new_ApplicationSignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ApplicationSignal")]
  public static extern void delete_ApplicationSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ApplicationControlSignal_Empty")]
  public static extern bool ApplicationControlSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ApplicationControlSignal_GetConnectionCount")]
  public static extern uint ApplicationControlSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ApplicationControlSignal_Connect")]
  public static extern void ApplicationControlSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ApplicationControlSignal_Disconnect")]
  public static extern void ApplicationControlSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ApplicationControlSignal_Emit")]
  public static extern void ApplicationControlSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, System.IntPtr jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ApplicationControlSignal")]
  public static extern global::System.IntPtr new_ApplicationControlSignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ApplicationControlSignal")]
  public static extern void delete_ApplicationControlSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_New__SWIG_4")]
  public static extern global::System.IntPtr Application_New__SWIG_4(int jarg1, string jarg3, int jarg4, global::System.Runtime.InteropServices.HandleRef jarg5);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_LowBatterySignalType_Empty")]
  public static extern bool LowBatterySignalType_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_LowBatterySignalType_GetConnectionCount")]
  public static extern uint LowBatterySignalType_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_LowBatterySignalType_Connect")]
  public static extern void LowBatterySignalType_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_LowBatterySignalType_Disconnect")]
  public static extern void LowBatterySignalType_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_LowBatterySignalType_Emit")]
  public static extern void LowBatterySignalType_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_new_LowBatterySignalType")]
  public static extern global::System.IntPtr new_LowBatterySignalType();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_delete_LowBatterySignalType")]
  public static extern void delete_LowBatterySignalType(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_LowMemorySignalType_Empty")]
  public static extern bool LowMemorySignalType_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_LowMemorySignalType_GetConnectionCount")]
  public static extern uint LowMemorySignalType_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_LowMemorySignalType_Connect")]
  public static extern void LowMemorySignalType_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_LowMemorySignalType_Disconnect")]
  public static extern void LowMemorySignalType_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_LowMemorySignalType_Emit")]
  public static extern void LowMemorySignalType_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_new_LowMemorySignalType")]
  public static extern global::System.IntPtr new_LowMemorySignalType();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_delete_LowMemorySignalType")]
  public static extern void delete_LowMemorySignalType(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TimerSignalType_Empty")]
  public static extern bool TimerSignalType_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TimerSignalType_GetConnectionCount")]
  public static extern uint TimerSignalType_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TimerSignalType_Connect")]
  public static extern void TimerSignalType_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TimerSignalType_Disconnect")]
  public static extern void TimerSignalType_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TimerSignalType_Emit")]
  public static extern bool TimerSignalType_Emit(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TimerSignalType")]
  public static extern global::System.IntPtr new_TimerSignalType();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_TimerSignalType")]
  public static extern void delete_TimerSignalType(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WindowFocusSignalType_Empty")]
  public static extern bool WindowFocusSignalType_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WindowFocusSignalType_GetConnectionCount")]
  public static extern uint WindowFocusSignalType_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WindowFocusSignalType_Connect")]
  public static extern void WindowFocusSignalType_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WindowFocusSignalType_Disconnect")]
  public static extern void WindowFocusSignalType_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WindowFocusSignalType_Emit")]
  public static extern void WindowFocusSignalType_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_WindowFocusSignalType")]
  public static extern global::System.IntPtr new_WindowFocusSignalType();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_WindowFocusSignalType")]
  public static extern void delete_WindowFocusSignalType(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VISUAL_PROPERTY_TYPE_get")]
  public static extern int VISUAL_PROPERTY_TYPE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VISUAL_PROPERTY_SHADER_get")]
  public static extern int VISUAL_PROPERTY_SHADER_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VISUAL_SHADER_VERTEX_get")]
  public static extern int VISUAL_SHADER_VERTEX_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VISUAL_SHADER_FRAGMENT_get")]
  public static extern int VISUAL_SHADER_FRAGMENT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VISUAL_SHADER_SUBDIVIDE_GRID_X_get")]
  public static extern int VISUAL_SHADER_SUBDIVIDE_GRID_X_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VISUAL_SHADER_SUBDIVIDE_GRID_Y_get")]
  public static extern int VISUAL_SHADER_SUBDIVIDE_GRID_Y_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VISUAL_SHADER_HINTS_get")]
  public static extern int VISUAL_SHADER_HINTS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_BORDER_VISUAL_COLOR_get")]
  public static extern int BORDER_VISUAL_COLOR_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_BORDER_VISUAL_SIZE_get")]
  public static extern int BORDER_VISUAL_SIZE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_BORDER_VISUAL_ANTI_ALIASING_get")]
  public static extern int BORDER_VISUAL_ANTI_ALIASING_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_COLOR_VISUAL_MIX_COLOR_get")]
  public static extern int COLOR_VISUAL_MIX_COLOR_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GRADIENT_VISUAL_START_POSITION_get")]
  public static extern int GRADIENT_VISUAL_START_POSITION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GRADIENT_VISUAL_END_POSITION_get")]
  public static extern int GRADIENT_VISUAL_END_POSITION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GRADIENT_VISUAL_CENTER_get")]
  public static extern int GRADIENT_VISUAL_CENTER_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GRADIENT_VISUAL_RADIUS_get")]
  public static extern int GRADIENT_VISUAL_RADIUS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GRADIENT_VISUAL_STOP_OFFSET_get")]
  public static extern int GRADIENT_VISUAL_STOP_OFFSET_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GRADIENT_VISUAL_STOP_COLOR_get")]
  public static extern int GRADIENT_VISUAL_STOP_COLOR_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GRADIENT_VISUAL_UNITS_get")]
  public static extern int GRADIENT_VISUAL_UNITS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GRADIENT_VISUAL_SPREAD_METHOD_get")]
  public static extern int GRADIENT_VISUAL_SPREAD_METHOD_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_IMAGE_VISUAL_URL_get")]
  public static extern int IMAGE_VISUAL_URL_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_IMAGE_VISUAL_ALPHA_MASK_URL_get")]
  public static extern int IMAGE_VISUAL_ALPHA_MASK_URL_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_IMAGE_VISUAL_FITTING_MODE_get")]
  public static extern int IMAGE_VISUAL_FITTING_MODE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_IMAGE_VISUAL_SAMPLING_MODE_get")]
  public static extern int IMAGE_VISUAL_SAMPLING_MODE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_IMAGE_VISUAL_DESIRED_WIDTH_get")]
  public static extern int IMAGE_VISUAL_DESIRED_WIDTH_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_IMAGE_VISUAL_DESIRED_HEIGHT_get")]
  public static extern int IMAGE_VISUAL_DESIRED_HEIGHT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_IMAGE_VISUAL_SYNCHRONOUS_LOADING_get")]
  public static extern int IMAGE_VISUAL_SYNCHRONOUS_LOADING_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_IMAGE_VISUAL_BORDER_ONLY_get")]
  public static extern int IMAGE_VISUAL_BORDER_ONLY_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_IMAGE_VISUAL_PIXEL_AREA_get")]
  public static extern int IMAGE_VISUAL_PIXEL_AREA_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_IMAGE_VISUAL_WRAP_MODE_U_get")]
  public static extern int IMAGE_VISUAL_WRAP_MODE_U_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_IMAGE_VISUAL_WRAP_MODE_V_get")]
  public static extern int IMAGE_VISUAL_WRAP_MODE_V_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_IMAGE_VISUAL_BATCH_SIZE_get")]
  public static extern int IMAGE_VISUAL_BATCH_SIZE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_IMAGE_VISUAL_CACHE_SIZE_get")]
  public static extern int IMAGE_VISUAL_CACHE_SIZE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_IMAGE_VISUAL_FRAME_DELAY_get")]
  public static extern int IMAGE_VISUAL_FRAME_DELAY_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_IMAGE_VISUAL_LOOP_COUNT_get")]
  public static extern int IMAGE_VISUAL_LOOP_COUNT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_IMAGE_VISUAL_MASK_CONTENT_SCALE_get")]
  public static extern int IMAGE_VISUAL_MASK_CONTENT_SCALE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_IMAGE_VISUAL_CROP_TO_MASK_get")]
  public static extern int IMAGE_VISUAL_CROP_TO_MASK_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_IMAGE_VISUAL_RELEASE_POLICY_get")]
  public static extern int IMAGE_VISUAL_RELEASE_POLICY_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_IMAGE_VISUAL_LOAD_POLICY_get")]
  public static extern int IMAGE_VISUAL_LOAD_POLICY_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint ="CSharp_Dali_IMAGE_VISUAL_ORIENTATION_CORRECTION_get")]
  public static extern int IMAGE_VISUAL_ORIENTATION_CORRECTION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint ="CSharp_Dali_IMAGE_VISUAL_AUXILIARY_IMAGE_URL_get")]
  public static extern int IMAGE_VISUAL_AUXILIARY_IMAGE_URL_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint ="CSharp_Dali_IMAGE_VISUAL_AUXILIARY_IMAGE_ALPHA_get")]
  public static extern int IMAGE_VISUAL_AUXILIARY_IMAGE_ALPHA_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_MESH_VISUAL_OBJECT_URL_get")]
  public static extern int MESH_VISUAL_OBJECT_URL_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_MESH_VISUAL_MATERIAL_URL_get")]
  public static extern int MESH_VISUAL_MATERIAL_URL_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_MESH_VISUAL_TEXTURES_PATH_get")]
  public static extern int MESH_VISUAL_TEXTURES_PATH_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_MESH_VISUAL_SHADING_MODE_get")]
  public static extern int MESH_VISUAL_SHADING_MODE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_MESH_VISUAL_USE_MIPMAPPING_get")]
  public static extern int MESH_VISUAL_USE_MIPMAPPING_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_MESH_VISUAL_USE_SOFT_NORMALS_get")]
  public static extern int MESH_VISUAL_USE_SOFT_NORMALS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_MESH_VISUAL_LIGHT_POSITION_get")]
  public static extern int MESH_VISUAL_LIGHT_POSITION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PRIMITIVE_VISUAL_SHAPE_get")]
  public static extern int PRIMITIVE_VISUAL_SHAPE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PRIMITIVE_VISUAL_MIX_COLOR_get")]
  public static extern int PRIMITIVE_VISUAL_MIX_COLOR_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PRIMITIVE_VISUAL_SLICES_get")]
  public static extern int PRIMITIVE_VISUAL_SLICES_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PRIMITIVE_VISUAL_STACKS_get")]
  public static extern int PRIMITIVE_VISUAL_STACKS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PRIMITIVE_VISUAL_SCALE_TOP_RADIUS_get")]
  public static extern int PRIMITIVE_VISUAL_SCALE_TOP_RADIUS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PRIMITIVE_VISUAL_SCALE_BOTTOM_RADIUS_get")]
  public static extern int PRIMITIVE_VISUAL_SCALE_BOTTOM_RADIUS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PRIMITIVE_VISUAL_SCALE_HEIGHT_get")]
  public static extern int PRIMITIVE_VISUAL_SCALE_HEIGHT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PRIMITIVE_VISUAL_SCALE_RADIUS_get")]
  public static extern int PRIMITIVE_VISUAL_SCALE_RADIUS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PRIMITIVE_VISUAL_SCALE_DIMENSIONS_get")]
  public static extern int PRIMITIVE_VISUAL_SCALE_DIMENSIONS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PRIMITIVE_VISUAL_BEVEL_PERCENTAGE_get")]
  public static extern int PRIMITIVE_VISUAL_BEVEL_PERCENTAGE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PRIMITIVE_VISUAL_BEVEL_SMOOTHNESS_get")]
  public static extern int PRIMITIVE_VISUAL_BEVEL_SMOOTHNESS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PRIMITIVE_VISUAL_LIGHT_POSITION_get")]
  public static extern int PRIMITIVE_VISUAL_LIGHT_POSITION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TEXT_VISUAL_TEXT_get")]
  public static extern int TEXT_VISUAL_TEXT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TEXT_VISUAL_FONT_FAMILY_get")]
  public static extern int TEXT_VISUAL_FONT_FAMILY_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TEXT_VISUAL_FONT_STYLE_get")]
  public static extern int TEXT_VISUAL_FONT_STYLE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TEXT_VISUAL_POINT_SIZE_get")]
  public static extern int TEXT_VISUAL_POINT_SIZE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TEXT_VISUAL_MULTI_LINE_get")]
  public static extern int TEXT_VISUAL_MULTI_LINE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TEXT_VISUAL_HORIZONTAL_ALIGNMENT_get")]
  public static extern int TEXT_VISUAL_HORIZONTAL_ALIGNMENT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TEXT_VISUAL_VERTICAL_ALIGNMENT_get")]
  public static extern int TEXT_VISUAL_VERTICAL_ALIGNMENT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TEXT_VISUAL_TEXT_COLOR_get")]
  public static extern int TEXT_VISUAL_TEXT_COLOR_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TEXT_VISUAL_ENABLE_MARKUP_get")]
  public static extern int TEXT_VISUAL_ENABLE_MARKUP_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Builder")]
  public static extern global::System.IntPtr new_Builder();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Builder_New")]
  public static extern global::System.IntPtr Builder_New();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Builder")]
  public static extern void delete_Builder(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Builder_LoadFromString__SWIG_0")]
  public static extern void Builder_LoadFromString__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Builder_LoadFromString__SWIG_1")]
  public static extern void Builder_LoadFromString__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Builder_AddConstants")]
  public static extern void Builder_AddConstants(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Builder_AddConstant")]
  public static extern void Builder_AddConstant(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Builder_GetConstants")]
  public static extern global::System.IntPtr Builder_GetConstants(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Builder_GetConstant")]
  public static extern global::System.IntPtr Builder_GetConstant(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Builder_CreateAnimation__SWIG_0")]
  public static extern global::System.IntPtr Builder_CreateAnimation__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Builder_CreateAnimation__SWIG_1")]
  public static extern global::System.IntPtr Builder_CreateAnimation__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Builder_CreateAnimation__SWIG_2")]
  public static extern global::System.IntPtr Builder_CreateAnimation__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Builder_CreateAnimation__SWIG_3")]
  public static extern global::System.IntPtr Builder_CreateAnimation__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Builder_Create__SWIG_0")]
  public static extern global::System.IntPtr Builder_Create__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Builder_Create__SWIG_1")]
  public static extern global::System.IntPtr Builder_Create__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Builder_CreateFromJson")]
  public static extern global::System.IntPtr Builder_CreateFromJson(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Builder_ApplyStyle")]
  public static extern bool Builder_ApplyStyle(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Builder_ApplyFromJson")]
  public static extern bool Builder_ApplyFromJson(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, string jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Builder_AddActors__SWIG_0")]
  public static extern void Builder_AddActors__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Builder_AddActors__SWIG_1")]
  public static extern void Builder_AddActors__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Builder_CreateRenderTask")]
  public static extern void Builder_CreateRenderTask(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Builder_GetFrameBufferImage")]
  public static extern global::System.IntPtr Builder_GetFrameBufferImage(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Builder_GetPath")]
  public static extern global::System.IntPtr Builder_GetPath(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Builder_GetPathConstrainer")]
  public static extern global::System.IntPtr Builder_GetPathConstrainer(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Builder_GetLinearConstrainer")]
  public static extern global::System.IntPtr Builder_GetLinearConstrainer(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Builder_QuitSignal")]
  public static extern global::System.IntPtr Builder_QuitSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TransitionData__SWIG_0")]
  public static extern global::System.IntPtr new_TransitionData__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_TransitionData")]
  public static extern void delete_TransitionData(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TransitionData_New__SWIG_0")]
  public static extern global::System.IntPtr TransitionData_New__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TransitionData_New__SWIG_1")]
  public static extern global::System.IntPtr TransitionData_New__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TransitionData_DownCast")]
  public static extern global::System.IntPtr TransitionData_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TransitionData__SWIG_1")]
  public static extern global::System.IntPtr new_TransitionData__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TransitionData_Assign")]
  public static extern global::System.IntPtr TransitionData_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TransitionData_Count")]
  public static extern uint TransitionData_Count(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TransitionData_GetAnimatorAt")]
  public static extern global::System.IntPtr TransitionData_GetAnimatorAt(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TOOLTIP_CONTENT_get")]
  public static extern int TOOLTIP_CONTENT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TOOLTIP_LAYOUT_get")]
  public static extern int TOOLTIP_LAYOUT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TOOLTIP_WAIT_TIME_get")]
  public static extern int TOOLTIP_WAIT_TIME_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TOOLTIP_BACKGROUND_get")]
  public static extern int TOOLTIP_BACKGROUND_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TOOLTIP_TAIL_get")]
  public static extern int TOOLTIP_TAIL_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TOOLTIP_POSITION_get")]
  public static extern int TOOLTIP_POSITION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TOOLTIP_HOVER_POINT_OFFSET_get")]
  public static extern int TOOLTIP_HOVER_POINT_OFFSET_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TOOLTIP_MOVEMENT_THRESHOLD_get")]
  public static extern int TOOLTIP_MOVEMENT_THRESHOLD_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TOOLTIP_DISAPPEAR_ON_MOVEMENT_get")]
  public static extern int TOOLTIP_DISAPPEAR_ON_MOVEMENT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TOOLTIP_BACKGROUND_VISUAL_get")]
  public static extern int TOOLTIP_BACKGROUND_VISUAL_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TOOLTIP_BACKGROUND_BORDER_get")]
  public static extern int TOOLTIP_BACKGROUND_BORDER_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TOOLTIP_TAIL_VISIBILITY_get")]
  public static extern int TOOLTIP_TAIL_VISIBILITY_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TOOLTIP_TAIL_ABOVE_VISUAL_get")]
  public static extern int TOOLTIP_TAIL_ABOVE_VISUAL_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TOOLTIP_TAIL_BELOW_VISUAL_get")]
  public static extern int TOOLTIP_TAIL_BELOW_VISUAL_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_New")]
  public static extern global::System.IntPtr ViewImpl_New();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_SetStyleName")]
  public static extern void ViewImpl_SetStyleName(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_GetStyleName")]
  public static extern string ViewImpl_GetStyleName(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_SetBackgroundColor")]
  public static extern void ViewImpl_SetBackgroundColor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_GetBackgroundColor")]
  public static extern global::System.IntPtr ViewImpl_GetBackgroundColor(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_SetBackgroundImage")]
  public static extern void ViewImpl_SetBackgroundImage(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_SetBackground")]
  public static extern void ViewImpl_SetBackground(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_ClearBackground")]
  public static extern void ViewImpl_ClearBackground(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_EnableGestureDetection")]
  public static extern void ViewImpl_EnableGestureDetection(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_DisableGestureDetection")]
  public static extern void ViewImpl_DisableGestureDetection(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_GetPinchGestureDetector")]
  public static extern global::System.IntPtr ViewImpl_GetPinchGestureDetector(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_GetPanGestureDetector")]
  public static extern global::System.IntPtr ViewImpl_GetPanGestureDetector(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_GetTapGestureDetector")]
  public static extern global::System.IntPtr ViewImpl_GetTapGestureDetector(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_GetLongPressGestureDetector")]
  public static extern global::System.IntPtr ViewImpl_GetLongPressGestureDetector(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_SetKeyboardNavigationSupport")]
  public static extern void ViewImpl_SetKeyboardNavigationSupport(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_IsKeyboardNavigationSupported")]
  public static extern bool ViewImpl_IsKeyboardNavigationSupported(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_SetKeyInputFocus")]
  public static extern void ViewImpl_SetKeyInputFocus(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_HasKeyInputFocus")]
  public static extern bool ViewImpl_HasKeyInputFocus(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_ClearKeyInputFocus")]
  public static extern void ViewImpl_ClearKeyInputFocus(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_SetAsKeyboardFocusGroup")]
  public static extern void ViewImpl_SetAsKeyboardFocusGroup(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_IsKeyboardFocusGroup")]
  public static extern bool ViewImpl_IsKeyboardFocusGroup(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_AccessibilityActivate")]
  public static extern void ViewImpl_AccessibilityActivate(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_KeyboardEnter")]
  public static extern void ViewImpl_KeyboardEnter(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_KeyEventSignal")]
  public static extern global::System.IntPtr ViewImpl_KeyEventSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_KeyInputFocusGainedSignal")]
  public static extern global::System.IntPtr ViewImpl_KeyInputFocusGainedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_KeyInputFocusLostSignal")]
  public static extern global::System.IntPtr ViewImpl_KeyInputFocusLostSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_EmitKeyEventSignal")]
  public static extern bool ViewImpl_EmitKeyEventSignal(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnStageConnection")]
  public static extern void ViewImpl_OnStageConnection(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnStageConnectionSwigExplicitViewImpl")]
  public static extern void ViewImpl_OnStageConnectionSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnStageDisconnection")]
  public static extern void ViewImpl_OnStageDisconnection(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnStageDisconnectionSwigExplicitViewImpl")]
  public static extern void ViewImpl_OnStageDisconnectionSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnChildAdd")]
  public static extern void ViewImpl_OnChildAdd(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnChildAddSwigExplicitViewImpl")]
  public static extern void ViewImpl_OnChildAddSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnChildRemove")]
  public static extern void ViewImpl_OnChildRemove(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnChildRemoveSwigExplicitViewImpl")]
  public static extern void ViewImpl_OnChildRemoveSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnPropertySet")]
  public static extern void ViewImpl_OnPropertySet(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnPropertySetSwigExplicitViewImpl")]
  public static extern void ViewImpl_OnPropertySetSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnSizeSet")]
  public static extern void ViewImpl_OnSizeSet(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnSizeSetSwigExplicitViewImpl")]
  public static extern void ViewImpl_OnSizeSetSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnSizeAnimation")]
  public static extern void ViewImpl_OnSizeAnimation(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnSizeAnimationSwigExplicitViewImpl")]
  public static extern void ViewImpl_OnSizeAnimationSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnTouchEvent")]
  public static extern bool ViewImpl_OnTouchEvent(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnTouchEventSwigExplicitViewImpl")]
  public static extern bool ViewImpl_OnTouchEventSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnHoverEvent")]
  public static extern bool ViewImpl_OnHoverEvent(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnHoverEventSwigExplicitViewImpl")]
  public static extern bool ViewImpl_OnHoverEventSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnKeyEvent")]
  public static extern bool ViewImpl_OnKeyEvent(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnKeyEventSwigExplicitViewImpl")]
  public static extern bool ViewImpl_OnKeyEventSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnWheelEvent")]
  public static extern bool ViewImpl_OnWheelEvent(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnWheelEventSwigExplicitViewImpl")]
  public static extern bool ViewImpl_OnWheelEventSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnRelayout")]
  public static extern void ViewImpl_OnRelayout(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnRelayoutSwigExplicitViewImpl")]
  public static extern void ViewImpl_OnRelayoutSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnSetResizePolicy")]
  public static extern void ViewImpl_OnSetResizePolicy(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnSetResizePolicySwigExplicitViewImpl")]
  public static extern void ViewImpl_OnSetResizePolicySwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_GetNaturalSize")]
  public static extern global::System.IntPtr ViewImpl_GetNaturalSize(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_GetNaturalSizeSwigExplicitViewImpl")]
  public static extern global::System.IntPtr ViewImpl_GetNaturalSizeSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_CalculateChildSize")]
  public static extern float ViewImpl_CalculateChildSize(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_CalculateChildSizeSwigExplicitViewImpl")]
  public static extern float ViewImpl_CalculateChildSizeSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_GetHeightForWidth")]
  public static extern float ViewImpl_GetHeightForWidth(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_GetHeightForWidthSwigExplicitViewImpl")]
  public static extern float ViewImpl_GetHeightForWidthSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_GetWidthForHeight")]
  public static extern float ViewImpl_GetWidthForHeight(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_GetWidthForHeightSwigExplicitViewImpl")]
  public static extern float ViewImpl_GetWidthForHeightSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_RelayoutDependentOnChildren__SWIG_0")]
  public static extern bool ViewImpl_RelayoutDependentOnChildren__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_RelayoutDependentOnChildrenSwigExplicitViewImpl__SWIG_0")]
  public static extern bool ViewImpl_RelayoutDependentOnChildrenSwigExplicitViewImpl__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_RelayoutDependentOnChildren__SWIG_1")]
  public static extern bool ViewImpl_RelayoutDependentOnChildren__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_RelayoutDependentOnChildrenSwigExplicitViewImpl__SWIG_1")]
  public static extern bool ViewImpl_RelayoutDependentOnChildrenSwigExplicitViewImpl__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnCalculateRelayoutSize")]
  public static extern void ViewImpl_OnCalculateRelayoutSize(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnCalculateRelayoutSizeSwigExplicitViewImpl")]
  public static extern void ViewImpl_OnCalculateRelayoutSizeSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnLayoutNegotiated")]
  public static extern void ViewImpl_OnLayoutNegotiated(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnLayoutNegotiatedSwigExplicitViewImpl")]
  public static extern void ViewImpl_OnLayoutNegotiatedSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnInitialize")]
  public static extern void ViewImpl_OnInitialize(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnInitializeSwigExplicitViewImpl")]
  public static extern void ViewImpl_OnInitializeSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnControlChildAdd")]
  public static extern void ViewImpl_OnControlChildAdd(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnControlChildAddSwigExplicitViewImpl")]
  public static extern void ViewImpl_OnControlChildAddSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnControlChildRemove")]
  public static extern void ViewImpl_OnControlChildRemove(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnControlChildRemoveSwigExplicitViewImpl")]
  public static extern void ViewImpl_OnControlChildRemoveSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnStyleChange")]
  public static extern void ViewImpl_OnStyleChange(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnStyleChangeSwigExplicitViewImpl")]
  public static extern void ViewImpl_OnStyleChangeSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnAccessibilityActivated")]
  public static extern bool ViewImpl_OnAccessibilityActivated(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnAccessibilityActivatedSwigExplicitViewImpl")]
  public static extern bool ViewImpl_OnAccessibilityActivatedSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnAccessibilityPan")]
  public static extern bool ViewImpl_OnAccessibilityPan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnAccessibilityPanSwigExplicitViewImpl")]
  public static extern bool ViewImpl_OnAccessibilityPanSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnAccessibilityTouch")]
  public static extern bool ViewImpl_OnAccessibilityTouch(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnAccessibilityTouchSwigExplicitViewImpl")]
  public static extern bool ViewImpl_OnAccessibilityTouchSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnAccessibilityValueChange")]
  public static extern bool ViewImpl_OnAccessibilityValueChange(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnAccessibilityValueChangeSwigExplicitViewImpl")]
  public static extern bool ViewImpl_OnAccessibilityValueChangeSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnAccessibilityZoom")]
  public static extern bool ViewImpl_OnAccessibilityZoom(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnAccessibilityZoomSwigExplicitViewImpl")]
  public static extern bool ViewImpl_OnAccessibilityZoomSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnKeyInputFocusGained")]
  public static extern void ViewImpl_OnKeyInputFocusGained(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnKeyInputFocusGainedSwigExplicitViewImpl")]
  public static extern void ViewImpl_OnKeyInputFocusGainedSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnKeyInputFocusLost")]
  public static extern void ViewImpl_OnKeyInputFocusLost(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnKeyInputFocusLostSwigExplicitViewImpl")]
  public static extern void ViewImpl_OnKeyInputFocusLostSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_GetNextKeyboardFocusableActor")]
  public static extern global::System.IntPtr ViewImpl_GetNextKeyboardFocusableActor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, bool jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_GetNextKeyboardFocusableActorSwigExplicitViewImpl")]
  public static extern global::System.IntPtr ViewImpl_GetNextKeyboardFocusableActorSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, bool jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnKeyboardFocusChangeCommitted")]
  public static extern void ViewImpl_OnKeyboardFocusChangeCommitted(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnKeyboardFocusChangeCommittedSwigExplicitViewImpl")]
  public static extern void ViewImpl_OnKeyboardFocusChangeCommittedSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnKeyboardEnter")]
  public static extern bool ViewImpl_OnKeyboardEnter(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnKeyboardEnterSwigExplicitViewImpl")]
  public static extern bool ViewImpl_OnKeyboardEnterSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnPinch")]
  public static extern void ViewImpl_OnPinch(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnPinchSwigExplicitViewImpl")]
  public static extern void ViewImpl_OnPinchSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnPan")]
  public static extern void ViewImpl_OnPan(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnPanSwigExplicitViewImpl")]
  public static extern void ViewImpl_OnPanSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnTap")]
  public static extern void ViewImpl_OnTap(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnTapSwigExplicitViewImpl")]
  public static extern void ViewImpl_OnTapSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnLongPress")]
  public static extern void ViewImpl_OnLongPress(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_OnLongPressSwigExplicitViewImpl")]
  public static extern void ViewImpl_OnLongPressSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_SignalConnected")]
  public static extern void ViewImpl_SignalConnected(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_SignalConnectedSwigExplicitViewImpl")]
  public static extern void ViewImpl_SignalConnectedSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_SignalDisconnected")]
  public static extern void ViewImpl_SignalDisconnected(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_SignalDisconnectedSwigExplicitViewImpl")]
  public static extern void ViewImpl_SignalDisconnectedSwigExplicitViewImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_director_connect")]
  public static extern void ViewImpl_director_connect(global::System.Runtime.InteropServices.HandleRef jarg1, ViewImpl.SwigDelegateViewImpl_0 delegate0, ViewImpl.SwigDelegateViewImpl_1 delegate1, ViewImpl.SwigDelegateViewImpl_2 delegate2, ViewImpl.SwigDelegateViewImpl_3 delegate3, ViewImpl.SwigDelegateViewImpl_4 delegate4, ViewImpl.SwigDelegateViewImpl_5 delegate5, ViewImpl.SwigDelegateViewImpl_6 delegate6, ViewImpl.SwigDelegateViewImpl_7 delegate7, ViewImpl.SwigDelegateViewImpl_8 delegate8, ViewImpl.SwigDelegateViewImpl_9 delegate9, ViewImpl.SwigDelegateViewImpl_10 delegate10, ViewImpl.SwigDelegateViewImpl_11 delegate11, ViewImpl.SwigDelegateViewImpl_12 delegate12, ViewImpl.SwigDelegateViewImpl_13 delegate13, ViewImpl.SwigDelegateViewImpl_14 delegate14, ViewImpl.SwigDelegateViewImpl_15 delegate15, ViewImpl.SwigDelegateViewImpl_16 delegate16, ViewImpl.SwigDelegateViewImpl_17 delegate17, ViewImpl.SwigDelegateViewImpl_18 delegate18, ViewImpl.SwigDelegateViewImpl_19 delegate19, ViewImpl.SwigDelegateViewImpl_20 delegate20, ViewImpl.SwigDelegateViewImpl_21 delegate21, ViewImpl.SwigDelegateViewImpl_22 delegate22, ViewImpl.SwigDelegateViewImpl_23 delegate23, ViewImpl.SwigDelegateViewImpl_24 delegate24, ViewImpl.SwigDelegateViewImpl_25 delegate25, ViewImpl.SwigDelegateViewImpl_26 delegate26, ViewImpl.SwigDelegateViewImpl_27 delegate27, ViewImpl.SwigDelegateViewImpl_28 delegate28, ViewImpl.SwigDelegateViewImpl_29 delegate29, ViewImpl.SwigDelegateViewImpl_30 delegate30, ViewImpl.SwigDelegateViewImpl_31 delegate31, ViewImpl.SwigDelegateViewImpl_32 delegate32, ViewImpl.SwigDelegateViewImpl_33 delegate33, ViewImpl.SwigDelegateViewImpl_34 delegate34, ViewImpl.SwigDelegateViewImpl_35 delegate35, ViewImpl.SwigDelegateViewImpl_36 delegate36, ViewImpl.SwigDelegateViewImpl_37 delegate37, ViewImpl.SwigDelegateViewImpl_38 delegate38, ViewImpl.SwigDelegateViewImpl_39 delegate39, ViewImpl.SwigDelegateViewImpl_40 delegate40);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GetImplementation__SWIG_0")]
  public static extern global::System.IntPtr GetImplementation__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_View_Property_STYLE_NAME_get")]
  public static extern int View_Property_STYLE_NAME_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_View_Property_BACKGROUND_COLOR_get")]
  public static extern int View_Property_BACKGROUND_COLOR_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_View_Property_BACKGROUND_IMAGE_get")]
  public static extern int View_Property_BACKGROUND_IMAGE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_View_Property_KEY_INPUT_FOCUS_get")]
  public static extern int View_Property_KEY_INPUT_FOCUS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_View_Property_BACKGROUND_get")]
  public static extern int View_Property_BACKGROUND_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_View_Property_MARGIN_get")]
  public static extern int View_Property_MARGIN_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_View_Property_PADDING_get")]
  public static extern int View_Property_PADDING_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_View_Property")]
  public static extern global::System.IntPtr new_View_Property();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_View_Property")]
  public static extern void delete_View_Property(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_View_KeyboardFocus")]
  public static extern global::System.IntPtr new_View_KeyboardFocus();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_View_KeyboardFocus")]
  public static extern void delete_View_KeyboardFocus(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_View_New")]
  public static extern global::System.IntPtr View_New();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_View__SWIG_0")]
  public static extern global::System.IntPtr new_View__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_View__SWIG_1")]
  public static extern global::System.IntPtr new_View__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_View")]
  public static extern void delete_View(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_View_Assign")]
  public static extern global::System.IntPtr View_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_View_DownCast")]
  public static extern global::System.IntPtr View_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_View_SetKeyInputFocus")]
  public static extern void View_SetKeyInputFocus(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_View_HasKeyInputFocus")]
  public static extern bool View_HasKeyInputFocus(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_View_ClearKeyInputFocus")]
  public static extern void View_ClearKeyInputFocus(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_View_GetPinchGestureDetector")]
  public static extern global::System.IntPtr View_GetPinchGestureDetector(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_View_GetPanGestureDetector")]
  public static extern global::System.IntPtr View_GetPanGestureDetector(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_View_GetTapGestureDetector")]
  public static extern global::System.IntPtr View_GetTapGestureDetector(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_View_GetLongPressGestureDetector")]
  public static extern global::System.IntPtr View_GetLongPressGestureDetector(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_View_SetStyleName")]
  public static extern void View_SetStyleName(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_View_GetStyleName")]
  public static extern string View_GetStyleName(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_View_SetBackgroundColor")]
  public static extern void View_SetBackgroundColor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_View_GetBackgroundColor")]
  public static extern global::System.IntPtr View_GetBackgroundColor(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_View_SetBackgroundImage")]
  public static extern void View_SetBackgroundImage(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_View_ClearBackground")]
  public static extern void View_ClearBackground(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_View_KeyEventSignal")]
  public static extern global::System.IntPtr View_KeyEventSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_View_KeyInputFocusGainedSignal")]
  public static extern global::System.IntPtr View_KeyInputFocusGainedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_View_KeyInputFocusLostSignal")]
  public static extern global::System.IntPtr View_KeyInputFocusLostSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_View__SWIG_2")]
  public static extern global::System.IntPtr new_View__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ResourceReadySignal")]
  public static extern global::System.IntPtr ResourceReadySignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_IsResourceReady")]
  public static extern bool IsResourceReady(global::System.Runtime.InteropServices.HandleRef jarg1);
  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_KeyInputFocusManager")]
  public static extern global::System.IntPtr new_KeyInputFocusManager();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_KeyInputFocusManager")]
  public static extern void delete_KeyInputFocusManager(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_KeyInputFocusManager_Get")]
  public static extern global::System.IntPtr KeyInputFocusManager_Get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_KeyInputFocusManager_SetFocus")]
  public static extern void KeyInputFocusManager_SetFocus(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_KeyInputFocusManager_GetCurrentFocusControl")]
  public static extern global::System.IntPtr KeyInputFocusManager_GetCurrentFocusControl(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_KeyInputFocusManager_RemoveFocus")]
  public static extern void KeyInputFocusManager_RemoveFocus(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_KeyInputFocusManager_KeyInputFocusChangedSignal")]
  public static extern global::System.IntPtr KeyInputFocusManager_KeyInputFocusChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Alignment_Padding__SWIG_0")]
  public static extern global::System.IntPtr new_Alignment_Padding__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Alignment_Padding__SWIG_1")]
  public static extern global::System.IntPtr new_Alignment_Padding__SWIG_1(float jarg1, float jarg2, float jarg3, float jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Alignment_Padding_left_set")]
  public static extern void Alignment_Padding_left_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Alignment_Padding_left_get")]
  public static extern float Alignment_Padding_left_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Alignment_Padding_right_set")]
  public static extern void Alignment_Padding_right_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Alignment_Padding_right_get")]
  public static extern float Alignment_Padding_right_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Alignment_Padding_top_set")]
  public static extern void Alignment_Padding_top_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Alignment_Padding_top_get")]
  public static extern float Alignment_Padding_top_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Alignment_Padding_bottom_set")]
  public static extern void Alignment_Padding_bottom_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Alignment_Padding_bottom_get")]
  public static extern float Alignment_Padding_bottom_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Alignment_Padding")]
  public static extern void delete_Alignment_Padding(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Alignment__SWIG_0")]
  public static extern global::System.IntPtr new_Alignment__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Alignment_New__SWIG_0")]
  public static extern global::System.IntPtr Alignment_New__SWIG_0(int jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Alignment_New__SWIG_1")]
  public static extern global::System.IntPtr Alignment_New__SWIG_1(int jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Alignment_New__SWIG_2")]
  public static extern global::System.IntPtr Alignment_New__SWIG_2();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Alignment__SWIG_1")]
  public static extern global::System.IntPtr new_Alignment__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Alignment")]
  public static extern void delete_Alignment(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Alignment_DownCast")]
  public static extern global::System.IntPtr Alignment_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Alignment_SetAlignmentType")]
  public static extern void Alignment_SetAlignmentType(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Alignment_GetAlignmentType")]
  public static extern int Alignment_GetAlignmentType(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Alignment_SetScaling")]
  public static extern void Alignment_SetScaling(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Alignment_GetScaling")]
  public static extern int Alignment_GetScaling(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Alignment_SetPadding")]
  public static extern void Alignment_SetPadding(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Alignment_GetPadding")]
  public static extern global::System.IntPtr Alignment_GetPadding(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Alignment_Assign")]
  public static extern global::System.IntPtr Alignment_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Button_Property_DISABLED_get")]
  public static extern int Button_Property_DISABLED_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Button_Property_AUTO_REPEATING_get")]
  public static extern int Button_Property_AUTO_REPEATING_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Button_Property_INITIAL_AUTO_REPEATING_DELAY_get")]
  public static extern int Button_Property_INITIAL_AUTO_REPEATING_DELAY_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Button_Property_NEXT_AUTO_REPEATING_DELAY_get")]
  public static extern int Button_Property_NEXT_AUTO_REPEATING_DELAY_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Button_Property_TOGGLABLE_get")]
  public static extern int Button_Property_TOGGLABLE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Button_Property_SELECTED_get")]
  public static extern int Button_Property_SELECTED_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Button_Property_UNSELECTED_STATE_IMAGE_get")]
  public static extern int Button_Property_UNSELECTED_STATE_IMAGE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Button_Property_SELECTED_STATE_IMAGE_get")]
  public static extern int Button_Property_SELECTED_STATE_IMAGE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Button_Property_DISABLED_STATE_IMAGE_get")]
  public static extern int Button_Property_DISABLED_STATE_IMAGE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Button_Property_UNSELECTED_COLOR_get")]
  public static extern int Button_Property_UNSELECTED_COLOR_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Button_Property_SELECTED_COLOR_get")]
  public static extern int Button_Property_SELECTED_COLOR_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Button_Property_LABEL_get")]
  public static extern int Button_Property_LABEL_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Button_Property_LABEL_TEXT_get")]
  public static extern int Button_Property_LABEL_TEXT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Button_Property")]
  public static extern global::System.IntPtr new_Button_Property();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Button_Property")]
  public static extern void delete_Button_Property(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Button__SWIG_0")]
  public static extern global::System.IntPtr new_Button__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Button__SWIG_1")]
  public static extern global::System.IntPtr new_Button__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Button_Assign")]
  public static extern global::System.IntPtr Button_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Button_DownCast")]
  public static extern global::System.IntPtr Button_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Button")]
  public static extern void delete_Button(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Button_IsDisabled")]
  public static extern bool Button_IsDisabled(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Button_IsAutoRepeating")]
  public static extern bool Button_IsAutoRepeating(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Button_GetInitialAutoRepeatingDelay")]
  public static extern float Button_GetInitialAutoRepeatingDelay(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Button_GetNextAutoRepeatingDelay")]
  public static extern float Button_GetNextAutoRepeatingDelay(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Button_IsTogglableButton")]
  public static extern bool Button_IsTogglableButton(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Button_IsSelected")]
  public static extern bool Button_IsSelected(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Button_GetAnimationTime")]
  public static extern float Button_GetAnimationTime(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Button_GetLabelText")]
  public static extern string Button_GetLabelText(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Button_SetLabel")]
  public static extern void Button_SetLabel(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Button_SetButtonImage")]
  public static extern void Button_SetButtonImage(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Button_SetSelectedImage")]
  public static extern void Button_SetSelectedImage(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Button_GetButtonImage")]
  public static extern global::System.IntPtr Button_GetButtonImage(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Button_GetSelectedImage")]
  public static extern global::System.IntPtr Button_GetSelectedImage(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Button_PressedSignal")]
  public static extern global::System.IntPtr Button_PressedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Button_ReleasedSignal")]
  public static extern global::System.IntPtr Button_ReleasedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Button_ClickedSignal")]
  public static extern global::System.IntPtr Button_ClickedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Button_StateChangedSignal")]
  public static extern global::System.IntPtr Button_StateChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_CheckBoxButton__SWIG_0")]
  public static extern global::System.IntPtr new_CheckBoxButton__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_CheckBoxButton__SWIG_1")]
  public static extern global::System.IntPtr new_CheckBoxButton__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CheckBoxButton_Assign")]
  public static extern global::System.IntPtr CheckBoxButton_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_CheckBoxButton")]
  public static extern void delete_CheckBoxButton(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CheckBoxButton_New")]
  public static extern global::System.IntPtr CheckBoxButton_New();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CheckBoxButton_DownCast")]
  public static extern global::System.IntPtr CheckBoxButton_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PushButton_Property_UNSELECTED_ICON_get")]
  public static extern int PushButton_Property_UNSELECTED_ICON_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PushButton_Property_SELECTED_ICON_get")]
  public static extern int PushButton_Property_SELECTED_ICON_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PushButton_Property_ICON_ALIGNMENT_get")]
  public static extern int PushButton_Property_ICON_ALIGNMENT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PushButton_Property_LABEL_PADDING_get")]
  public static extern int PushButton_Property_LABEL_PADDING_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PushButton_Property_ICON_PADDING_get")]
  public static extern int PushButton_Property_ICON_PADDING_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PushButton_Property")]
  public static extern global::System.IntPtr new_PushButton_Property();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_PushButton_Property")]
  public static extern void delete_PushButton_Property(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PushButton__SWIG_0")]
  public static extern global::System.IntPtr new_PushButton__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PushButton__SWIG_1")]
  public static extern global::System.IntPtr new_PushButton__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PushButton_Assign")]
  public static extern global::System.IntPtr PushButton_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_PushButton")]
  public static extern void delete_PushButton(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PushButton_New")]
  public static extern global::System.IntPtr PushButton_New();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PushButton_DownCast")]
  public static extern global::System.IntPtr PushButton_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PushButton_SetButtonImage__SWIG_0_0")]
  public static extern void PushButton_SetButtonImage__SWIG_0_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PushButton_SetButtonImage__SWIG_1")]
  public static extern void PushButton_SetButtonImage__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PushButton_SetBackgroundImage")]
  public static extern void PushButton_SetBackgroundImage(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PushButton_SetSelectedImage__SWIG_0_0")]
  public static extern void PushButton_SetSelectedImage__SWIG_0_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PushButton_SetSelectedImage__SWIG_1")]
  public static extern void PushButton_SetSelectedImage__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PushButton_SetSelectedBackgroundImage")]
  public static extern void PushButton_SetSelectedBackgroundImage(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PushButton_SetDisabledBackgroundImage")]
  public static extern void PushButton_SetDisabledBackgroundImage(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PushButton_SetDisabledImage")]
  public static extern void PushButton_SetDisabledImage(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PushButton_SetDisabledSelectedImage")]
  public static extern void PushButton_SetDisabledSelectedImage(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_RadioButton__SWIG_0")]
  public static extern global::System.IntPtr new_RadioButton__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_RadioButton__SWIG_1")]
  public static extern global::System.IntPtr new_RadioButton__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RadioButton_Assign")]
  public static extern global::System.IntPtr RadioButton_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_RadioButton")]
  public static extern void delete_RadioButton(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RadioButton_New__SWIG_0")]
  public static extern global::System.IntPtr RadioButton_New__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RadioButton_New__SWIG_1")]
  public static extern global::System.IntPtr RadioButton_New__SWIG_1(string jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RadioButton_DownCast")]
  public static extern global::System.IntPtr RadioButton_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FlexContainer_Property_CONTENT_DIRECTION_get")]
  public static extern int FlexContainer_Property_CONTENT_DIRECTION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FlexContainer_Property_FLEX_DIRECTION_get")]
  public static extern int FlexContainer_Property_FLEX_DIRECTION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FlexContainer_Property_FLEX_WRAP_get")]
  public static extern int FlexContainer_Property_FLEX_WRAP_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FlexContainer_Property_JUSTIFY_CONTENT_get")]
  public static extern int FlexContainer_Property_JUSTIFY_CONTENT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FlexContainer_Property_ALIGN_ITEMS_get")]
  public static extern int FlexContainer_Property_ALIGN_ITEMS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FlexContainer_Property_ALIGN_CONTENT_get")]
  public static extern int FlexContainer_Property_ALIGN_CONTENT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_FlexContainer_Property")]
  public static extern global::System.IntPtr new_FlexContainer_Property();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_FlexContainer_Property")]
  public static extern void delete_FlexContainer_Property(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FlexContainer_ChildProperty_FLEX_get")]
  public static extern int FlexContainer_ChildProperty_FLEX_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FlexContainer_ChildProperty_ALIGN_SELF_get")]
  public static extern int FlexContainer_ChildProperty_ALIGN_SELF_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FlexContainer_ChildProperty_FLEX_MARGIN_get")]
  public static extern int FlexContainer_ChildProperty_FLEX_MARGIN_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_FlexContainer_ChildProperty")]
  public static extern global::System.IntPtr new_FlexContainer_ChildProperty();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_FlexContainer_ChildProperty")]
  public static extern void delete_FlexContainer_ChildProperty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_FlexContainer__SWIG_0")]
  public static extern global::System.IntPtr new_FlexContainer__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_FlexContainer__SWIG_1")]
  public static extern global::System.IntPtr new_FlexContainer__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FlexContainer_Assign")]
  public static extern global::System.IntPtr FlexContainer_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_FlexContainer")]
  public static extern void delete_FlexContainer(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FlexContainer_New")]
  public static extern global::System.IntPtr FlexContainer_New();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FlexContainer_DownCast")]
  public static extern global::System.IntPtr FlexContainer_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ImageView_Property_RESOURCE_URL_get")]
  public static extern int ImageView_Property_RESOURCE_URL_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ImageView_Property_IMAGE_get")]
  public static extern int ImageView_Property_IMAGE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ImageView_Property_PRE_MULTIPLIED_ALPHA_get")]
  public static extern int ImageView_Property_PRE_MULTIPLIED_ALPHA_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ImageView_Property_PIXEL_AREA_get")]
  public static extern int ImageView_Property_PIXEL_AREA_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ImageView_Property")]
  public static extern global::System.IntPtr new_ImageView_Property();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ImageView_Property")]
  public static extern void delete_ImageView_Property(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ImageView__SWIG_0")]
  public static extern global::System.IntPtr new_ImageView__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ImageView_New__SWIG_0")]
  public static extern global::System.IntPtr ImageView_New__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ImageView_New__SWIG_1")]
  public static extern global::System.IntPtr ImageView_New__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ImageView_New__SWIG_2")]
  public static extern global::System.IntPtr ImageView_New__SWIG_2(string jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ImageView_New__SWIG_3")]
  public static extern global::System.IntPtr ImageView_New__SWIG_3(string jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ImageView")]
  public static extern void delete_ImageView(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ImageView__SWIG_1")]
  public static extern global::System.IntPtr new_ImageView__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ImageView_Assign")]
  public static extern global::System.IntPtr ImageView_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ImageView_DownCast")]
  public static extern global::System.IntPtr ImageView_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ImageView_SetImage__SWIG_0")]
  public static extern void ImageView_SetImage__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ImageView_SetImage__SWIG_1")]
  public static extern void ImageView_SetImage__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ImageView_SetImage__SWIG_2")]
  public static extern void ImageView_SetImage__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ImageView_GetImage")]
  public static extern global::System.IntPtr ImageView_GetImage(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Model3dView_Property_GEOMETRY_URL_get")]
  public static extern int Model3dView_Property_GEOMETRY_URL_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Model3dView_Property_MATERIAL_URL_get")]
  public static extern int Model3dView_Property_MATERIAL_URL_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Model3dView_Property_IMAGES_URL_get")]
  public static extern int Model3dView_Property_IMAGES_URL_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Model3dView_Property_ILLUMINATION_TYPE_get")]
  public static extern int Model3dView_Property_ILLUMINATION_TYPE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Model3dView_Property_TEXTURE0_URL_get")]
  public static extern int Model3dView_Property_TEXTURE0_URL_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Model3dView_Property_TEXTURE1_URL_get")]
  public static extern int Model3dView_Property_TEXTURE1_URL_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Model3dView_Property_TEXTURE2_URL_get")]
  public static extern int Model3dView_Property_TEXTURE2_URL_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Model3dView_Property_LIGHT_POSITION_get")]
  public static extern int Model3dView_Property_LIGHT_POSITION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Model3dView_Property")]
  public static extern global::System.IntPtr new_Model3dView_Property();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Model3dView_Property")]
  public static extern void delete_Model3dView_Property(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Model3dView_New__SWIG_0")]
  public static extern global::System.IntPtr Model3dView_New__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Model3dView_New__SWIG_1")]
  public static extern global::System.IntPtr Model3dView_New__SWIG_1(string jarg1, string jarg2, string jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Model3dView__SWIG_0")]
  public static extern global::System.IntPtr new_Model3dView__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Model3dView")]
  public static extern void delete_Model3dView(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Model3dView__SWIG_1")]
  public static extern global::System.IntPtr new_Model3dView__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Model3dView_Assign")]
  public static extern global::System.IntPtr Model3dView_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Model3dView_DownCast")]
  public static extern global::System.IntPtr Model3dView_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollBar_Property_SCROLL_DIRECTION_get")]
  public static extern int ScrollBar_Property_SCROLL_DIRECTION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollBar_Property_INDICATOR_HEIGHT_POLICY_get")]
  public static extern int ScrollBar_Property_INDICATOR_HEIGHT_POLICY_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollBar_Property_INDICATOR_FIXED_HEIGHT_get")]
  public static extern int ScrollBar_Property_INDICATOR_FIXED_HEIGHT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollBar_Property_INDICATOR_SHOW_DURATION_get")]
  public static extern int ScrollBar_Property_INDICATOR_SHOW_DURATION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollBar_Property_INDICATOR_HIDE_DURATION_get")]
  public static extern int ScrollBar_Property_INDICATOR_HIDE_DURATION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollBar_Property_SCROLL_POSITION_INTERVALS_get")]
  public static extern int ScrollBar_Property_SCROLL_POSITION_INTERVALS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollBar_Property_INDICATOR_MINIMUM_HEIGHT_get")]
  public static extern int ScrollBar_Property_INDICATOR_MINIMUM_HEIGHT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollBar_Property_INDICATOR_START_PADDING_get")]
  public static extern int ScrollBar_Property_INDICATOR_START_PADDING_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollBar_Property_INDICATOR_END_PADDING_get")]
  public static extern int ScrollBar_Property_INDICATOR_END_PADDING_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ScrollBar_Property")]
  public static extern global::System.IntPtr new_ScrollBar_Property();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ScrollBar_Property")]
  public static extern void delete_ScrollBar_Property(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ScrollBar__SWIG_0")]
  public static extern global::System.IntPtr new_ScrollBar__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ScrollBar__SWIG_1")]
  public static extern global::System.IntPtr new_ScrollBar__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollBar_Assign")]
  public static extern global::System.IntPtr ScrollBar_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ScrollBar")]
  public static extern void delete_ScrollBar(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollBar_New__SWIG_0")]
  public static extern global::System.IntPtr ScrollBar_New__SWIG_0(int jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollBar_New__SWIG_1")]
  public static extern global::System.IntPtr ScrollBar_New__SWIG_1();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollBar_DownCast")]
  public static extern global::System.IntPtr ScrollBar_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollBar_SetScrollPropertySource")]
  public static extern void ScrollBar_SetScrollPropertySource(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, int jarg4, int jarg5, int jarg6);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollBar_SetScrollIndicator")]
  public static extern void ScrollBar_SetScrollIndicator(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollBar_GetScrollIndicator")]
  public static extern global::System.IntPtr ScrollBar_GetScrollIndicator(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollBar_SetScrollPositionIntervals")]
  public static extern void ScrollBar_SetScrollPositionIntervals(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollBar_GetScrollPositionIntervals")]
  public static extern global::System.IntPtr ScrollBar_GetScrollPositionIntervals(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollBar_SetScrollDirection")]
  public static extern void ScrollBar_SetScrollDirection(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollBar_GetScrollDirection")]
  public static extern int ScrollBar_GetScrollDirection(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollBar_SetIndicatorHeightPolicy")]
  public static extern void ScrollBar_SetIndicatorHeightPolicy(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollBar_GetIndicatorHeightPolicy")]
  public static extern int ScrollBar_GetIndicatorHeightPolicy(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollBar_SetIndicatorFixedHeight")]
  public static extern void ScrollBar_SetIndicatorFixedHeight(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollBar_GetIndicatorFixedHeight")]
  public static extern float ScrollBar_GetIndicatorFixedHeight(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollBar_SetIndicatorShowDuration")]
  public static extern void ScrollBar_SetIndicatorShowDuration(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollBar_GetIndicatorShowDuration")]
  public static extern float ScrollBar_GetIndicatorShowDuration(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollBar_SetIndicatorHideDuration")]
  public static extern void ScrollBar_SetIndicatorHideDuration(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollBar_GetIndicatorHideDuration")]
  public static extern float ScrollBar_GetIndicatorHideDuration(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollBar_ShowIndicator")]
  public static extern void ScrollBar_ShowIndicator(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollBar_HideIndicator")]
  public static extern void ScrollBar_HideIndicator(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollBar_PanFinishedSignal")]
  public static extern global::System.IntPtr ScrollBar_PanFinishedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollBar_ScrollPositionIntervalReachedSignal")]
  public static extern global::System.IntPtr ScrollBar_ScrollPositionIntervalReachedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Scrollable_Property_OVERSHOOT_EFFECT_COLOR_get")]
  public static extern int Scrollable_Property_OVERSHOOT_EFFECT_COLOR_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Scrollable_Property_OVERSHOOT_ANIMATION_SPEED_get")]
  public static extern int Scrollable_Property_OVERSHOOT_ANIMATION_SPEED_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Scrollable_Property_OVERSHOOT_ENABLED_get")]
  public static extern int Scrollable_Property_OVERSHOOT_ENABLED_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Scrollable_Property_OVERSHOOT_SIZE_get")]
  public static extern int Scrollable_Property_OVERSHOOT_SIZE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Scrollable_Property_SCROLL_TO_ALPHA_FUNCTION_get")]
  public static extern int Scrollable_Property_SCROLL_TO_ALPHA_FUNCTION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Scrollable_Property_SCROLL_RELATIVE_POSITION_get")]
  public static extern int Scrollable_Property_SCROLL_RELATIVE_POSITION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Scrollable_Property_SCROLL_POSITION_MIN_get")]
  public static extern int Scrollable_Property_SCROLL_POSITION_MIN_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Scrollable_Property_SCROLL_POSITION_MIN_X_get")]
  public static extern int Scrollable_Property_SCROLL_POSITION_MIN_X_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Scrollable_Property_SCROLL_POSITION_MIN_Y_get")]
  public static extern int Scrollable_Property_SCROLL_POSITION_MIN_Y_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Scrollable_Property_SCROLL_POSITION_MAX_get")]
  public static extern int Scrollable_Property_SCROLL_POSITION_MAX_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Scrollable_Property_SCROLL_POSITION_MAX_X_get")]
  public static extern int Scrollable_Property_SCROLL_POSITION_MAX_X_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Scrollable_Property_SCROLL_POSITION_MAX_Y_get")]
  public static extern int Scrollable_Property_SCROLL_POSITION_MAX_Y_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Scrollable_Property_CAN_SCROLL_VERTICAL_get")]
  public static extern int Scrollable_Property_CAN_SCROLL_VERTICAL_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Scrollable_Property_CAN_SCROLL_HORIZONTAL_get")]
  public static extern int Scrollable_Property_CAN_SCROLL_HORIZONTAL_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Scrollable_Property")]
  public static extern global::System.IntPtr new_Scrollable_Property();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Scrollable_Property")]
  public static extern void delete_Scrollable_Property(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Scrollable__SWIG_0")]
  public static extern global::System.IntPtr new_Scrollable__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Scrollable__SWIG_1")]
  public static extern global::System.IntPtr new_Scrollable__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Scrollable_Assign")]
  public static extern global::System.IntPtr Scrollable_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Scrollable")]
  public static extern void delete_Scrollable(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Scrollable_DownCast")]
  public static extern global::System.IntPtr Scrollable_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Scrollable_IsOvershootEnabled")]
  public static extern bool Scrollable_IsOvershootEnabled(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Scrollable_SetOvershootEnabled")]
  public static extern void Scrollable_SetOvershootEnabled(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Scrollable_SetOvershootEffectColor")]
  public static extern void Scrollable_SetOvershootEffectColor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Scrollable_GetOvershootEffectColor")]
  public static extern global::System.IntPtr Scrollable_GetOvershootEffectColor(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Scrollable_SetOvershootAnimationSpeed")]
  public static extern void Scrollable_SetOvershootAnimationSpeed(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Scrollable_GetOvershootAnimationSpeed")]
  public static extern float Scrollable_GetOvershootAnimationSpeed(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Scrollable_ScrollStartedSignal")]
  public static extern global::System.IntPtr Scrollable_ScrollStartedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Scrollable_ScrollUpdatedSignal")]
  public static extern global::System.IntPtr Scrollable_ScrollUpdatedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Scrollable_ScrollCompletedSignal")]
  public static extern global::System.IntPtr Scrollable_ScrollCompletedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_IsVertical")]
  public static extern bool IsVertical(int jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_IsHorizontal")]
  public static extern bool IsHorizontal(int jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ItemRange__SWIG_0")]
  public static extern global::System.IntPtr new_ItemRange__SWIG_0(uint jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ItemRange__SWIG_1")]
  public static extern global::System.IntPtr new_ItemRange__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemRange_Assign")]
  public static extern global::System.IntPtr ItemRange_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemRange_Within")]
  public static extern bool ItemRange_Within(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemRange_Intersection")]
  public static extern global::System.IntPtr ItemRange_Intersection(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemRange_begin_set")]
  public static extern void ItemRange_begin_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemRange_begin_get")]
  public static extern uint ItemRange_begin_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemRange_end_set")]
  public static extern void ItemRange_end_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemRange_end_get")]
  public static extern uint ItemRange_end_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ItemRange")]
  public static extern void delete_ItemRange(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ItemLayout")]
  public static extern void delete_ItemLayout(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemLayout_SetOrientation")]
  public static extern void ItemLayout_SetOrientation(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemLayout_GetOrientation")]
  public static extern int ItemLayout_GetOrientation(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemLayout_SetLayoutProperties")]
  public static extern void ItemLayout_SetLayoutProperties(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemLayout_GetLayoutProperties")]
  public static extern global::System.IntPtr ItemLayout_GetLayoutProperties(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemLayout_GetItemSize")]
  public static extern void ItemLayout_GetItemSize(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemLayout_SetItemSize")]
  public static extern void ItemLayout_SetItemSize(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemLayout_GetMinimumLayoutPosition")]
  public static extern float ItemLayout_GetMinimumLayoutPosition(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemLayout_GetClosestAnchorPosition")]
  public static extern float ItemLayout_GetClosestAnchorPosition(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemLayout_GetItemScrollToPosition")]
  public static extern float ItemLayout_GetItemScrollToPosition(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemLayout_GetItemsWithinArea")]
  public static extern global::System.IntPtr ItemLayout_GetItemsWithinArea(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemLayout_GetClosestOnScreenLayoutPosition")]
  public static extern float ItemLayout_GetClosestOnScreenLayoutPosition(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, float jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemLayout_GetReserveItemCount")]
  public static extern uint ItemLayout_GetReserveItemCount(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemLayout_GetDefaultItemSize")]
  public static extern void ItemLayout_GetDefaultItemSize(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemLayout_GetScrollDirection")]
  public static extern global::System.IntPtr ItemLayout_GetScrollDirection(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemLayout_GetScrollSpeedFactor")]
  public static extern float ItemLayout_GetScrollSpeedFactor(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemLayout_GetMaximumSwipeSpeed")]
  public static extern float ItemLayout_GetMaximumSwipeSpeed(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemLayout_GetItemFlickAnimationDuration")]
  public static extern float ItemLayout_GetItemFlickAnimationDuration(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemLayout_GetNextFocusItemID")]
  public static extern int ItemLayout_GetNextFocusItemID(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3, int jarg4, bool jarg5);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemLayout_GetFlickSpeedFactor")]
  public static extern float ItemLayout_GetFlickSpeedFactor(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemLayout_ApplyConstraints")]
  public static extern void ItemLayout_ApplyConstraints(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, global::System.Runtime.InteropServices.HandleRef jarg5);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemLayout_GetItemPosition")]
  public static extern global::System.IntPtr ItemLayout_GetItemPosition(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, float jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_NewItemLayout")]
  public static extern global::System.IntPtr NewItemLayout(int jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ItemFactory")]
  public static extern void delete_ItemFactory(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemFactory_GetNumberOfItems")]
  public static extern uint ItemFactory_GetNumberOfItems(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemFactory_NewItem")]
  public static extern global::System.IntPtr ItemFactory_NewItem(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemFactory_ItemReleased")]
  public static extern void ItemFactory_ItemReleased(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemFactory_ItemReleasedSwigExplicitItemFactory")]
  public static extern void ItemFactory_ItemReleasedSwigExplicitItemFactory(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ItemFactory")]
  public static extern global::System.IntPtr new_ItemFactory();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemFactory_director_connect")]
  public static extern void ItemFactory_director_connect(global::System.Runtime.InteropServices.HandleRef jarg1, ItemFactory.SwigDelegateItemFactory_0 delegate0, ItemFactory.SwigDelegateItemFactory_1 delegate1, ItemFactory.SwigDelegateItemFactory_2 delegate2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_Property_MINIMUM_SWIPE_SPEED_get")]
  public static extern int ItemView_Property_MINIMUM_SWIPE_SPEED_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_Property_MINIMUM_SWIPE_DISTANCE_get")]
  public static extern int ItemView_Property_MINIMUM_SWIPE_DISTANCE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_Property_WHEEL_SCROLL_DISTANCE_STEP_get")]
  public static extern int ItemView_Property_WHEEL_SCROLL_DISTANCE_STEP_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_Property_SNAP_TO_ITEM_ENABLED_get")]
  public static extern int ItemView_Property_SNAP_TO_ITEM_ENABLED_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_Property_REFRESH_INTERVAL_get")]
  public static extern int ItemView_Property_REFRESH_INTERVAL_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_Property_LAYOUT_POSITION_get")]
  public static extern int ItemView_Property_LAYOUT_POSITION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_Property_SCROLL_SPEED_get")]
  public static extern int ItemView_Property_SCROLL_SPEED_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_Property_OVERSHOOT_get")]
  public static extern int ItemView_Property_OVERSHOOT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_Property_SCROLL_DIRECTION_get")]
  public static extern int ItemView_Property_SCROLL_DIRECTION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_Property_LAYOUT_ORIENTATION_get")]
  public static extern int ItemView_Property_LAYOUT_ORIENTATION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_Property_SCROLL_CONTENT_SIZE_get")]
  public static extern int ItemView_Property_SCROLL_CONTENT_SIZE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ItemView_Property")]
  public static extern global::System.IntPtr new_ItemView_Property();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ItemView_Property")]
  public static extern void delete_ItemView_Property(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ItemView__SWIG_0")]
  public static extern global::System.IntPtr new_ItemView__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ItemView__SWIG_1")]
  public static extern global::System.IntPtr new_ItemView__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_Assign")]
  public static extern global::System.IntPtr ItemView_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ItemView")]
  public static extern void delete_ItemView(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_New")]
  public static extern global::System.IntPtr ItemView_New(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_DownCast")]
  public static extern global::System.IntPtr ItemView_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_GetLayoutCount")]
  public static extern uint ItemView_GetLayoutCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_AddLayout")]
  public static extern void ItemView_AddLayout(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_RemoveLayout")]
  public static extern void ItemView_RemoveLayout(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_GetLayout")]
  public static extern global::System.IntPtr ItemView_GetLayout(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_GetActiveLayout")]
  public static extern global::System.IntPtr ItemView_GetActiveLayout(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_GetCurrentLayoutPosition")]
  public static extern float ItemView_GetCurrentLayoutPosition(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_ActivateLayout")]
  public static extern void ItemView_ActivateLayout(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, float jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_DeactivateCurrentLayout")]
  public static extern void ItemView_DeactivateCurrentLayout(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_SetMinimumSwipeSpeed")]
  public static extern void ItemView_SetMinimumSwipeSpeed(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_GetMinimumSwipeSpeed")]
  public static extern float ItemView_GetMinimumSwipeSpeed(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_SetMinimumSwipeDistance")]
  public static extern void ItemView_SetMinimumSwipeDistance(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_GetMinimumSwipeDistance")]
  public static extern float ItemView_GetMinimumSwipeDistance(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_SetWheelScrollDistanceStep")]
  public static extern void ItemView_SetWheelScrollDistanceStep(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_GetWheelScrollDistanceStep")]
  public static extern float ItemView_GetWheelScrollDistanceStep(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_SetAnchoring")]
  public static extern void ItemView_SetAnchoring(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_GetAnchoring")]
  public static extern bool ItemView_GetAnchoring(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_SetAnchoringDuration")]
  public static extern void ItemView_SetAnchoringDuration(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_GetAnchoringDuration")]
  public static extern float ItemView_GetAnchoringDuration(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_ScrollToItem")]
  public static extern void ItemView_ScrollToItem(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_SetRefreshInterval")]
  public static extern void ItemView_SetRefreshInterval(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_GetRefreshInterval")]
  public static extern float ItemView_GetRefreshInterval(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_Refresh")]
  public static extern void ItemView_Refresh(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_GetItem")]
  public static extern global::System.IntPtr ItemView_GetItem(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_GetItemId")]
  public static extern uint ItemView_GetItemId(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_InsertItem")]
  public static extern void ItemView_InsertItem(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_InsertItems")]
  public static extern void ItemView_InsertItems(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_RemoveItem")]
  public static extern void ItemView_RemoveItem(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_RemoveItems")]
  public static extern void ItemView_RemoveItems(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_ReplaceItem")]
  public static extern void ItemView_ReplaceItem(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_ReplaceItems")]
  public static extern void ItemView_ReplaceItems(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_SetItemsParentOrigin")]
  public static extern void ItemView_SetItemsParentOrigin(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_GetItemsParentOrigin")]
  public static extern global::System.IntPtr ItemView_GetItemsParentOrigin(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_SetItemsAnchorPoint")]
  public static extern void ItemView_SetItemsAnchorPoint(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_GetItemsAnchorPoint")]
  public static extern global::System.IntPtr ItemView_GetItemsAnchorPoint(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_GetItemsRange")]
  public static extern void ItemView_GetItemsRange(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_LayoutActivatedSignal")]
  public static extern global::System.IntPtr ItemView_LayoutActivatedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_MoveActorConstraint")]
  public static extern void MoveActorConstraint(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_WrapActorConstraint")]
  public static extern void WrapActorConstraint(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ScrollViewEffect")]
  public static extern global::System.IntPtr new_ScrollViewEffect();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ScrollViewEffect")]
  public static extern void delete_ScrollViewEffect(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollViewPagePathEffect_New")]
  public static extern global::System.IntPtr ScrollViewPagePathEffect_New(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, uint jarg5);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ScrollViewPagePathEffect")]
  public static extern global::System.IntPtr new_ScrollViewPagePathEffect();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollViewPagePathEffect_DownCast")]
  public static extern global::System.IntPtr ScrollViewPagePathEffect_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollViewPagePathEffect_ApplyToPage")]
  public static extern void ScrollViewPagePathEffect_ApplyToPage(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, uint jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ScrollViewPagePathEffect")]
  public static extern void delete_ScrollViewPagePathEffect(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ClampState2D_x_set")]
  public static extern void ClampState2D_x_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ClampState2D_x_get")]
  public static extern int ClampState2D_x_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ClampState2D_y_set")]
  public static extern void ClampState2D_y_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ClampState2D_y_get")]
  public static extern int ClampState2D_y_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ClampState2D")]
  public static extern global::System.IntPtr new_ClampState2D();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ClampState2D")]
  public static extern void delete_ClampState2D(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_RulerDomain__SWIG_0")]
  public static extern global::System.IntPtr new_RulerDomain__SWIG_0(float jarg1, float jarg2, bool jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_RulerDomain__SWIG_1")]
  public static extern global::System.IntPtr new_RulerDomain__SWIG_1(float jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerDomain_min_set")]
  public static extern void RulerDomain_min_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerDomain_min_get")]
  public static extern float RulerDomain_min_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerDomain_max_set")]
  public static extern void RulerDomain_max_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerDomain_max_get")]
  public static extern float RulerDomain_max_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerDomain_enabled_set")]
  public static extern void RulerDomain_enabled_set(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerDomain_enabled_get")]
  public static extern bool RulerDomain_enabled_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerDomain_Clamp__SWIG_0")]
  public static extern float RulerDomain_Clamp__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3, float jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerDomain_Clamp__SWIG_1")]
  public static extern float RulerDomain_Clamp__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerDomain_Clamp__SWIG_2")]
  public static extern float RulerDomain_Clamp__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerDomain_Clamp__SWIG_3")]
  public static extern float RulerDomain_Clamp__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3, float jarg4, global::System.Runtime.InteropServices.HandleRef jarg5);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerDomain_GetSize")]
  public static extern float RulerDomain_GetSize(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_RulerDomain")]
  public static extern void delete_RulerDomain(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Ruler_Snap__SWIG_0")]
  public static extern float Ruler_Snap__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Ruler_Snap__SWIG_1")]
  public static extern float Ruler_Snap__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Ruler_GetPositionFromPage")]
  public static extern float Ruler_GetPositionFromPage(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, out uint jarg3, bool jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Ruler_GetPageFromPosition")]
  public static extern uint Ruler_GetPageFromPosition(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, bool jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Ruler_GetTotalPages")]
  public static extern uint Ruler_GetTotalPages(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Ruler_GetType")]
  public static extern int Ruler_GetType(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Ruler_IsEnabled")]
  public static extern bool Ruler_IsEnabled(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Ruler_Enable")]
  public static extern void Ruler_Enable(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Ruler_Disable")]
  public static extern void Ruler_Disable(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Ruler_SetDomain")]
  public static extern void Ruler_SetDomain(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Ruler_GetDomain")]
  public static extern global::System.IntPtr Ruler_GetDomain(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Ruler_DisableDomain")]
  public static extern void Ruler_DisableDomain(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Ruler_Clamp__SWIG_0")]
  public static extern float Ruler_Clamp__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3, float jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Ruler_Clamp__SWIG_1")]
  public static extern float Ruler_Clamp__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Ruler_Clamp__SWIG_2")]
  public static extern float Ruler_Clamp__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Ruler_Clamp__SWIG_3")]
  public static extern float Ruler_Clamp__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3, float jarg4, global::System.Runtime.InteropServices.HandleRef jarg5);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Ruler_SnapAndClamp__SWIG_0")]
  public static extern float Ruler_SnapAndClamp__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3, float jarg4, float jarg5);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Ruler_SnapAndClamp__SWIG_1")]
  public static extern float Ruler_SnapAndClamp__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3, float jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Ruler_SnapAndClamp__SWIG_2")]
  public static extern float Ruler_SnapAndClamp__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Ruler_SnapAndClamp__SWIG_3")]
  public static extern float Ruler_SnapAndClamp__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Ruler_SnapAndClamp__SWIG_4")]
  public static extern float Ruler_SnapAndClamp__SWIG_4(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3, float jarg4, float jarg5, global::System.Runtime.InteropServices.HandleRef jarg6);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_DefaultRuler")]
  public static extern global::System.IntPtr new_DefaultRuler();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_DefaultRuler_Snap")]
  public static extern float DefaultRuler_Snap(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_DefaultRuler_GetPositionFromPage")]
  public static extern float DefaultRuler_GetPositionFromPage(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, out uint jarg3, bool jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_DefaultRuler_GetPageFromPosition")]
  public static extern uint DefaultRuler_GetPageFromPosition(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, bool jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_DefaultRuler_GetTotalPages")]
  public static extern uint DefaultRuler_GetTotalPages(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_DefaultRuler")]
  public static extern void delete_DefaultRuler(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_FixedRuler__SWIG_0")]
  public static extern global::System.IntPtr new_FixedRuler__SWIG_0(float jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_FixedRuler__SWIG_1")]
  public static extern global::System.IntPtr new_FixedRuler__SWIG_1();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FixedRuler_Snap")]
  public static extern float FixedRuler_Snap(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FixedRuler_GetPositionFromPage")]
  public static extern float FixedRuler_GetPositionFromPage(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, out uint jarg3, bool jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FixedRuler_GetPageFromPosition")]
  public static extern uint FixedRuler_GetPageFromPosition(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, bool jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FixedRuler_GetTotalPages")]
  public static extern uint FixedRuler_GetTotalPages(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_FixedRuler")]
  public static extern void delete_FixedRuler(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_ClampEvent_scale_set")]
  public static extern void ScrollView_ClampEvent_scale_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_ClampEvent_scale_get")]
  public static extern global::System.IntPtr ScrollView_ClampEvent_scale_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_ClampEvent_position_set")]
  public static extern void ScrollView_ClampEvent_position_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_ClampEvent_position_get")]
  public static extern global::System.IntPtr ScrollView_ClampEvent_position_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_ClampEvent_rotation_set")]
  public static extern void ScrollView_ClampEvent_rotation_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_ClampEvent_rotation_get")]
  public static extern int ScrollView_ClampEvent_rotation_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ScrollView_ClampEvent")]
  public static extern global::System.IntPtr new_ScrollView_ClampEvent();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ScrollView_ClampEvent")]
  public static extern void delete_ScrollView_ClampEvent(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_SnapEvent_type_set")]
  public static extern void ScrollView_SnapEvent_type_set(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_SnapEvent_type_get")]
  public static extern int ScrollView_SnapEvent_type_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_SnapEvent_position_set")]
  public static extern void ScrollView_SnapEvent_position_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_SnapEvent_position_get")]
  public static extern global::System.IntPtr ScrollView_SnapEvent_position_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_SnapEvent_duration_set")]
  public static extern void ScrollView_SnapEvent_duration_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_SnapEvent_duration_get")]
  public static extern float ScrollView_SnapEvent_duration_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ScrollView_SnapEvent")]
  public static extern global::System.IntPtr new_ScrollView_SnapEvent();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ScrollView_SnapEvent")]
  public static extern void delete_ScrollView_SnapEvent(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_Property_WRAP_ENABLED_get")]
  public static extern int ScrollView_Property_WRAP_ENABLED_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_Property_PANNING_ENABLED_get")]
  public static extern int ScrollView_Property_PANNING_ENABLED_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_Property_AXIS_AUTO_LOCK_ENABLED_get")]
  public static extern int ScrollView_Property_AXIS_AUTO_LOCK_ENABLED_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_Property_WHEEL_SCROLL_DISTANCE_STEP_get")]
  public static extern int ScrollView_Property_WHEEL_SCROLL_DISTANCE_STEP_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_Property_SCROLL_MODE_get")]
  public static extern int ScrollView_Property_SCROLL_MODE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_Property_SCROLL_POSITION_get")]
  public static extern int ScrollView_Property_SCROLL_POSITION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_Property_SCROLL_PRE_POSITION_get")]
  public static extern int ScrollView_Property_SCROLL_PRE_POSITION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_Property_SCROLL_PRE_POSITION_X_get")]
  public static extern int ScrollView_Property_SCROLL_PRE_POSITION_X_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_Property_SCROLL_PRE_POSITION_Y_get")]
  public static extern int ScrollView_Property_SCROLL_PRE_POSITION_Y_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_Property_SCROLL_PRE_POSITION_MAX_get")]
  public static extern int ScrollView_Property_SCROLL_PRE_POSITION_MAX_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_Property_SCROLL_PRE_POSITION_MAX_X_get")]
  public static extern int ScrollView_Property_SCROLL_PRE_POSITION_MAX_X_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_Property_SCROLL_PRE_POSITION_MAX_Y_get")]
  public static extern int ScrollView_Property_SCROLL_PRE_POSITION_MAX_Y_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_Property_OVERSHOOT_X_get")]
  public static extern int ScrollView_Property_OVERSHOOT_X_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_Property_OVERSHOOT_Y_get")]
  public static extern int ScrollView_Property_OVERSHOOT_Y_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_Property_SCROLL_FINAL_get")]
  public static extern int ScrollView_Property_SCROLL_FINAL_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_Property_SCROLL_FINAL_X_get")]
  public static extern int ScrollView_Property_SCROLL_FINAL_X_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_Property_SCROLL_FINAL_Y_get")]
  public static extern int ScrollView_Property_SCROLL_FINAL_Y_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_Property_WRAP_get")]
  public static extern int ScrollView_Property_WRAP_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_Property_PANNING_get")]
  public static extern int ScrollView_Property_PANNING_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_Property_SCROLLING_get")]
  public static extern int ScrollView_Property_SCROLLING_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_Property_SCROLL_DOMAIN_SIZE_get")]
  public static extern int ScrollView_Property_SCROLL_DOMAIN_SIZE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_Property_SCROLL_DOMAIN_SIZE_X_get")]
  public static extern int ScrollView_Property_SCROLL_DOMAIN_SIZE_X_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_Property_SCROLL_DOMAIN_SIZE_Y_get")]
  public static extern int ScrollView_Property_SCROLL_DOMAIN_SIZE_Y_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_Property_SCROLL_DOMAIN_OFFSET_get")]
  public static extern int ScrollView_Property_SCROLL_DOMAIN_OFFSET_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_Property_SCROLL_POSITION_DELTA_get")]
  public static extern int ScrollView_Property_SCROLL_POSITION_DELTA_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_Property_START_PAGE_POSITION_get")]
  public static extern int ScrollView_Property_START_PAGE_POSITION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ScrollView_Property")]
  public static extern global::System.IntPtr new_ScrollView_Property();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ScrollView_Property")]
  public static extern void delete_ScrollView_Property(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ScrollView__SWIG_0")]
  public static extern global::System.IntPtr new_ScrollView__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ScrollView__SWIG_1")]
  public static extern global::System.IntPtr new_ScrollView__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_Assign")]
  public static extern global::System.IntPtr ScrollView_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ScrollView")]
  public static extern void delete_ScrollView(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_New")]
  public static extern global::System.IntPtr ScrollView_New();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_DownCast")]
  public static extern global::System.IntPtr ScrollView_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_GetScrollSnapAlphaFunction")]
  public static extern global::System.IntPtr ScrollView_GetScrollSnapAlphaFunction(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_SetScrollSnapAlphaFunction")]
  public static extern void ScrollView_SetScrollSnapAlphaFunction(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_GetScrollFlickAlphaFunction")]
  public static extern global::System.IntPtr ScrollView_GetScrollFlickAlphaFunction(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_SetScrollFlickAlphaFunction")]
  public static extern void ScrollView_SetScrollFlickAlphaFunction(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_GetScrollSnapDuration")]
  public static extern float ScrollView_GetScrollSnapDuration(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_SetScrollSnapDuration")]
  public static extern void ScrollView_SetScrollSnapDuration(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_GetScrollFlickDuration")]
  public static extern float ScrollView_GetScrollFlickDuration(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_SetScrollFlickDuration")]
  public static extern void ScrollView_SetScrollFlickDuration(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_SetRulerX")]
  public static extern void ScrollView_SetRulerX(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_SetRulerY")]
  public static extern void ScrollView_SetRulerY(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_SetScrollSensitive")]
  public static extern void ScrollView_SetScrollSensitive(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_SetMaxOvershoot")]
  public static extern void ScrollView_SetMaxOvershoot(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_SetSnapOvershootAlphaFunction")]
  public static extern void ScrollView_SetSnapOvershootAlphaFunction(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_SetSnapOvershootDuration")]
  public static extern void ScrollView_SetSnapOvershootDuration(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_SetActorAutoSnap")]
  public static extern void ScrollView_SetActorAutoSnap(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_SetWrapMode")]
  public static extern void ScrollView_SetWrapMode(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_GetScrollUpdateDistance")]
  public static extern int ScrollView_GetScrollUpdateDistance(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_SetScrollUpdateDistance")]
  public static extern void ScrollView_SetScrollUpdateDistance(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_GetAxisAutoLock")]
  public static extern bool ScrollView_GetAxisAutoLock(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_SetAxisAutoLock")]
  public static extern void ScrollView_SetAxisAutoLock(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_GetAxisAutoLockGradient")]
  public static extern float ScrollView_GetAxisAutoLockGradient(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_SetAxisAutoLockGradient")]
  public static extern void ScrollView_SetAxisAutoLockGradient(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_GetFrictionCoefficient")]
  public static extern float ScrollView_GetFrictionCoefficient(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_SetFrictionCoefficient")]
  public static extern void ScrollView_SetFrictionCoefficient(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_GetFlickSpeedCoefficient")]
  public static extern float ScrollView_GetFlickSpeedCoefficient(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_SetFlickSpeedCoefficient")]
  public static extern void ScrollView_SetFlickSpeedCoefficient(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_GetMinimumDistanceForFlick")]
  public static extern global::System.IntPtr ScrollView_GetMinimumDistanceForFlick(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_SetMinimumDistanceForFlick")]
  public static extern void ScrollView_SetMinimumDistanceForFlick(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_GetMinimumSpeedForFlick")]
  public static extern float ScrollView_GetMinimumSpeedForFlick(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_SetMinimumSpeedForFlick")]
  public static extern void ScrollView_SetMinimumSpeedForFlick(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_GetMaxFlickSpeed")]
  public static extern float ScrollView_GetMaxFlickSpeed(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_SetMaxFlickSpeed")]
  public static extern void ScrollView_SetMaxFlickSpeed(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_GetWheelScrollDistanceStep")]
  public static extern global::System.IntPtr ScrollView_GetWheelScrollDistanceStep(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_SetWheelScrollDistanceStep")]
  public static extern void ScrollView_SetWheelScrollDistanceStep(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_GetCurrentScrollPosition")]
  public static extern global::System.IntPtr ScrollView_GetCurrentScrollPosition(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_GetCurrentPage")]
  public static extern uint ScrollView_GetCurrentPage(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_ScrollTo__SWIG_0")]
  public static extern void ScrollView_ScrollTo__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_ScrollTo__SWIG_1")]
  public static extern void ScrollView_ScrollTo__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_ScrollTo__SWIG_2")]
  public static extern void ScrollView_ScrollTo__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_ScrollTo__SWIG_3")]
  public static extern void ScrollView_ScrollTo__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3, int jarg4, int jarg5);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_ScrollTo__SWIG_4")]
  public static extern void ScrollView_ScrollTo__SWIG_4(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3, global::System.Runtime.InteropServices.HandleRef jarg4, int jarg5, int jarg6);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_ScrollTo__SWIG_5")]
  public static extern void ScrollView_ScrollTo__SWIG_5(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_ScrollTo__SWIG_6")]
  public static extern void ScrollView_ScrollTo__SWIG_6(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_ScrollTo__SWIG_7")]
  public static extern void ScrollView_ScrollTo__SWIG_7(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, float jarg3, int jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_ScrollTo__SWIG_8")]
  public static extern void ScrollView_ScrollTo__SWIG_8(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_ScrollTo__SWIG_9")]
  public static extern void ScrollView_ScrollTo__SWIG_9(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_ScrollToSnapPoint")]
  public static extern bool ScrollView_ScrollToSnapPoint(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_ApplyConstraintToChildren")]
  public static extern void ScrollView_ApplyConstraintToChildren(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_RemoveConstraintsFromChildren")]
  public static extern void ScrollView_RemoveConstraintsFromChildren(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_ApplyEffect")]
  public static extern void ScrollView_ApplyEffect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_RemoveEffect")]
  public static extern void ScrollView_RemoveEffect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_RemoveAllEffects")]
  public static extern void ScrollView_RemoveAllEffects(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_BindActor")]
  public static extern void ScrollView_BindActor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_UnbindActor")]
  public static extern void ScrollView_UnbindActor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_SetScrollingDirection__SWIG_0")]
  public static extern void ScrollView_SetScrollingDirection__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_SetScrollingDirection__SWIG_1")]
  public static extern void ScrollView_SetScrollingDirection__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_RemoveScrollingDirection")]
  public static extern void ScrollView_RemoveScrollingDirection(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_SnapStartedSignal")]
  public static extern global::System.IntPtr ScrollView_SnapStartedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_Property_ROWS_get")]
  public static extern int TableView_Property_ROWS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_Property_COLUMNS_get")]
  public static extern int TableView_Property_COLUMNS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_Property_CELL_PADDING_get")]
  public static extern int TableView_Property_CELL_PADDING_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_Property_LAYOUT_ROWS_get")]
  public static extern int TableView_Property_LAYOUT_ROWS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_Property_LAYOUT_COLUMNS_get")]
  public static extern int TableView_Property_LAYOUT_COLUMNS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TableView_Property")]
  public static extern global::System.IntPtr new_TableView_Property();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_TableView_Property")]
  public static extern void delete_TableView_Property(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_ChildProperty_CELL_INDEX_get")]
  public static extern int TableView_ChildProperty_CELL_INDEX_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_ChildProperty_ROW_SPAN_get")]
  public static extern int TableView_ChildProperty_ROW_SPAN_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_ChildProperty_COLUMN_SPAN_get")]
  public static extern int TableView_ChildProperty_COLUMN_SPAN_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_ChildProperty_CELL_HORIZONTAL_ALIGNMENT_get")]
  public static extern int TableView_ChildProperty_CELL_HORIZONTAL_ALIGNMENT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_ChildProperty_CELL_VERTICAL_ALIGNMENT_get")]
  public static extern int TableView_ChildProperty_CELL_VERTICAL_ALIGNMENT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TableView_ChildProperty")]
  public static extern global::System.IntPtr new_TableView_ChildProperty();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_TableView_ChildProperty")]
  public static extern void delete_TableView_ChildProperty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TableView_CellPosition__SWIG_0")]
  public static extern global::System.IntPtr new_TableView_CellPosition__SWIG_0(uint jarg1, uint jarg2, uint jarg3, uint jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TableView_CellPosition__SWIG_1")]
  public static extern global::System.IntPtr new_TableView_CellPosition__SWIG_1(uint jarg1, uint jarg2, uint jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TableView_CellPosition__SWIG_2")]
  public static extern global::System.IntPtr new_TableView_CellPosition__SWIG_2(uint jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TableView_CellPosition__SWIG_3")]
  public static extern global::System.IntPtr new_TableView_CellPosition__SWIG_3(uint jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TableView_CellPosition__SWIG_4")]
  public static extern global::System.IntPtr new_TableView_CellPosition__SWIG_4();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_CellPosition_rowIndex_set")]
  public static extern void TableView_CellPosition_rowIndex_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_CellPosition_rowIndex_get")]
  public static extern uint TableView_CellPosition_rowIndex_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_CellPosition_columnIndex_set")]
  public static extern void TableView_CellPosition_columnIndex_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_CellPosition_columnIndex_get")]
  public static extern uint TableView_CellPosition_columnIndex_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_CellPosition_rowSpan_set")]
  public static extern void TableView_CellPosition_rowSpan_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_CellPosition_rowSpan_get")]
  public static extern uint TableView_CellPosition_rowSpan_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_CellPosition_columnSpan_set")]
  public static extern void TableView_CellPosition_columnSpan_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_CellPosition_columnSpan_get")]
  public static extern uint TableView_CellPosition_columnSpan_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_TableView_CellPosition")]
  public static extern void delete_TableView_CellPosition(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TableView__SWIG_0")]
  public static extern global::System.IntPtr new_TableView__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TableView__SWIG_1")]
  public static extern global::System.IntPtr new_TableView__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_Assign")]
  public static extern global::System.IntPtr TableView_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_TableView")]
  public static extern void delete_TableView(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_New")]
  public static extern global::System.IntPtr TableView_New(uint jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_DownCast")]
  public static extern global::System.IntPtr TableView_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_AddChild")]
  public static extern bool TableView_AddChild(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_GetChildAt")]
  public static extern global::System.IntPtr TableView_GetChildAt(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_RemoveChildAt")]
  public static extern global::System.IntPtr TableView_RemoveChildAt(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_FindChildPosition")]
  public static extern bool TableView_FindChildPosition(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_InsertRow")]
  public static extern void TableView_InsertRow(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_DeleteRow__SWIG_0")]
  public static extern void TableView_DeleteRow__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_DeleteRow__SWIG_1")]
  public static extern void TableView_DeleteRow__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_InsertColumn")]
  public static extern void TableView_InsertColumn(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_DeleteColumn__SWIG_0")]
  public static extern void TableView_DeleteColumn__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_DeleteColumn__SWIG_1")]
  public static extern void TableView_DeleteColumn__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_Resize__SWIG_0")]
  public static extern void TableView_Resize__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_Resize__SWIG_1")]
  public static extern void TableView_Resize__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_SetCellPadding")]
  public static extern void TableView_SetCellPadding(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_GetCellPadding")]
  public static extern global::System.IntPtr TableView_GetCellPadding(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_SetFitHeight")]
  public static extern void TableView_SetFitHeight(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_IsFitHeight")]
  public static extern bool TableView_IsFitHeight(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_SetFitWidth")]
  public static extern void TableView_SetFitWidth(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_IsFitWidth")]
  public static extern bool TableView_IsFitWidth(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_SetFixedHeight")]
  public static extern void TableView_SetFixedHeight(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_GetFixedHeight")]
  public static extern float TableView_GetFixedHeight(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_SetRelativeHeight")]
  public static extern void TableView_SetRelativeHeight(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_GetRelativeHeight")]
  public static extern float TableView_GetRelativeHeight(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_SetFixedWidth")]
  public static extern void TableView_SetFixedWidth(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_GetFixedWidth")]
  public static extern float TableView_GetFixedWidth(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_SetRelativeWidth")]
  public static extern void TableView_SetRelativeWidth(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_GetRelativeWidth")]
  public static extern float TableView_GetRelativeWidth(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_GetRows")]
  public static extern uint TableView_GetRows(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_GetColumns")]
  public static extern uint TableView_GetColumns(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_SetCellAlignment")]
  public static extern void TableView_SetCellAlignment(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, int jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_DEFAULT_RENDERING_BACKEND_get")]
  public static extern uint DEFAULT_RENDERING_BACKEND_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_Property_RENDERING_BACKEND_get")]
  public static extern int TextEditor_Property_RENDERING_BACKEND_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_Property_TEXT_get")]
  public static extern int TextEditor_Property_TEXT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_Property_TEXT_COLOR_get")]
  public static extern int TextEditor_Property_TEXT_COLOR_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_Property_FONT_FAMILY_get")]
  public static extern int TextEditor_Property_FONT_FAMILY_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_Property_FONT_STYLE_get")]
  public static extern int TextEditor_Property_FONT_STYLE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_Property_POINT_SIZE_get")]
  public static extern int TextEditor_Property_POINT_SIZE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_Property_HORIZONTAL_ALIGNMENT_get")]
  public static extern int TextEditor_Property_HORIZONTAL_ALIGNMENT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_Property_SCROLL_THRESHOLD_get")]
  public static extern int TextEditor_Property_SCROLL_THRESHOLD_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_Property_SCROLL_SPEED_get")]
  public static extern int TextEditor_Property_SCROLL_SPEED_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_Property_PRIMARY_CURSOR_COLOR_get")]
  public static extern int TextEditor_Property_PRIMARY_CURSOR_COLOR_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_Property_SECONDARY_CURSOR_COLOR_get")]
  public static extern int TextEditor_Property_SECONDARY_CURSOR_COLOR_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_Property_ENABLE_CURSOR_BLINK_get")]
  public static extern int TextEditor_Property_ENABLE_CURSOR_BLINK_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_Property_CURSOR_BLINK_INTERVAL_get")]
  public static extern int TextEditor_Property_CURSOR_BLINK_INTERVAL_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_Property_CURSOR_BLINK_DURATION_get")]
  public static extern int TextEditor_Property_CURSOR_BLINK_DURATION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_Property_CURSOR_WIDTH_get")]
  public static extern int TextEditor_Property_CURSOR_WIDTH_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_Property_GRAB_HANDLE_IMAGE_get")]
  public static extern int TextEditor_Property_GRAB_HANDLE_IMAGE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_Property_GRAB_HANDLE_PRESSED_IMAGE_get")]
  public static extern int TextEditor_Property_GRAB_HANDLE_PRESSED_IMAGE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_Property_SELECTION_HANDLE_IMAGE_LEFT_get")]
  public static extern int TextEditor_Property_SELECTION_HANDLE_IMAGE_LEFT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_Property_SELECTION_HANDLE_IMAGE_RIGHT_get")]
  public static extern int TextEditor_Property_SELECTION_HANDLE_IMAGE_RIGHT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_Property_SELECTION_HANDLE_PRESSED_IMAGE_LEFT_get")]
  public static extern int TextEditor_Property_SELECTION_HANDLE_PRESSED_IMAGE_LEFT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_Property_SELECTION_HANDLE_PRESSED_IMAGE_RIGHT_get")]
  public static extern int TextEditor_Property_SELECTION_HANDLE_PRESSED_IMAGE_RIGHT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_Property_SELECTION_HANDLE_MARKER_IMAGE_LEFT_get")]
  public static extern int TextEditor_Property_SELECTION_HANDLE_MARKER_IMAGE_LEFT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_Property_SELECTION_HANDLE_MARKER_IMAGE_RIGHT_get")]
  public static extern int TextEditor_Property_SELECTION_HANDLE_MARKER_IMAGE_RIGHT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_Property_SELECTION_HIGHLIGHT_COLOR_get")]
  public static extern int TextEditor_Property_SELECTION_HIGHLIGHT_COLOR_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_Property_DECORATION_BOUNDING_BOX_get")]
  public static extern int TextEditor_Property_DECORATION_BOUNDING_BOX_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_Property_ENABLE_MARKUP_get")]
  public static extern int TextEditor_Property_ENABLE_MARKUP_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_Property_INPUT_COLOR_get")]
  public static extern int TextEditor_Property_INPUT_COLOR_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_Property_INPUT_FONT_FAMILY_get")]
  public static extern int TextEditor_Property_INPUT_FONT_FAMILY_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_Property_INPUT_FONT_STYLE_get")]
  public static extern int TextEditor_Property_INPUT_FONT_STYLE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_Property_INPUT_POINT_SIZE_get")]
  public static extern int TextEditor_Property_INPUT_POINT_SIZE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_Property_LINE_SPACING_get")]
  public static extern int TextEditor_Property_LINE_SPACING_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_Property_INPUT_LINE_SPACING_get")]
  public static extern int TextEditor_Property_INPUT_LINE_SPACING_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_Property_UNDERLINE_get")]
  public static extern int TextEditor_Property_UNDERLINE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_Property_INPUT_UNDERLINE_get")]
  public static extern int TextEditor_Property_INPUT_UNDERLINE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_Property_SHADOW_get")]
  public static extern int TextEditor_Property_SHADOW_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_Property_INPUT_SHADOW_get")]
  public static extern int TextEditor_Property_INPUT_SHADOW_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_Property_EMBOSS_get")]
  public static extern int TextEditor_Property_EMBOSS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_Property_INPUT_EMBOSS_get")]
  public static extern int TextEditor_Property_INPUT_EMBOSS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_Property_OUTLINE_get")]
  public static extern int TextEditor_Property_OUTLINE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_Property_INPUT_OUTLINE_get")]
  public static extern int TextEditor_Property_INPUT_OUTLINE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TextEditor_Property")]
  public static extern global::System.IntPtr new_TextEditor_Property();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_TextEditor_Property")]
  public static extern void delete_TextEditor_Property(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TextEditor_InputStyle")]
  public static extern global::System.IntPtr new_TextEditor_InputStyle();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_TextEditor_InputStyle")]
  public static extern void delete_TextEditor_InputStyle(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_New")]
  public static extern global::System.IntPtr TextEditor_New();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TextEditor__SWIG_0")]
  public static extern global::System.IntPtr new_TextEditor__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TextEditor__SWIG_1")]
  public static extern global::System.IntPtr new_TextEditor__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_Assign")]
  public static extern global::System.IntPtr TextEditor_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_TextEditor")]
  public static extern void delete_TextEditor(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_DownCast")]
  public static extern global::System.IntPtr TextEditor_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_GetInputMethodContext")]
  public static extern global::System.IntPtr TextEditor_GetInputMethodContext(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_TextChangedSignal")]
  public static extern global::System.IntPtr TextEditor_TextChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_InputStyleChangedSignal")]
  public static extern global::System.IntPtr TextEditor_InputStyleChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_RENDERING_BACKEND_get")]
  public static extern int TextField_Property_RENDERING_BACKEND_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_TEXT_get")]
  public static extern int TextField_Property_TEXT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_PLACEHOLDER_TEXT_get")]
  public static extern int TextField_Property_PLACEHOLDER_TEXT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_PLACEHOLDER_TEXT_FOCUSED_get")]
  public static extern int TextField_Property_PLACEHOLDER_TEXT_FOCUSED_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_FONT_FAMILY_get")]
  public static extern int TextField_Property_FONT_FAMILY_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_FONT_STYLE_get")]
  public static extern int TextField_Property_FONT_STYLE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_POINT_SIZE_get")]
  public static extern int TextField_Property_POINT_SIZE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_MAX_LENGTH_get")]
  public static extern int TextField_Property_MAX_LENGTH_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_EXCEED_POLICY_get")]
  public static extern int TextField_Property_EXCEED_POLICY_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_HORIZONTAL_ALIGNMENT_get")]
  public static extern int TextField_Property_HORIZONTAL_ALIGNMENT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_VERTICAL_ALIGNMENT_get")]
  public static extern int TextField_Property_VERTICAL_ALIGNMENT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_TEXT_COLOR_get")]
  public static extern int TextField_Property_TEXT_COLOR_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_PLACEHOLDER_TEXT_COLOR_get")]
  public static extern int TextField_Property_PLACEHOLDER_TEXT_COLOR_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_SHADOW_OFFSET_get")]
  public static extern int TextField_Property_SHADOW_OFFSET_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_SHADOW_COLOR_get")]
  public static extern int TextField_Property_SHADOW_COLOR_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_PRIMARY_CURSOR_COLOR_get")]
  public static extern int TextField_Property_PRIMARY_CURSOR_COLOR_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_SECONDARY_CURSOR_COLOR_get")]
  public static extern int TextField_Property_SECONDARY_CURSOR_COLOR_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_ENABLE_CURSOR_BLINK_get")]
  public static extern int TextField_Property_ENABLE_CURSOR_BLINK_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_CURSOR_BLINK_INTERVAL_get")]
  public static extern int TextField_Property_CURSOR_BLINK_INTERVAL_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_CURSOR_BLINK_DURATION_get")]
  public static extern int TextField_Property_CURSOR_BLINK_DURATION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_CURSOR_WIDTH_get")]
  public static extern int TextField_Property_CURSOR_WIDTH_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_GRAB_HANDLE_IMAGE_get")]
  public static extern int TextField_Property_GRAB_HANDLE_IMAGE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_GRAB_HANDLE_PRESSED_IMAGE_get")]
  public static extern int TextField_Property_GRAB_HANDLE_PRESSED_IMAGE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_SCROLL_THRESHOLD_get")]
  public static extern int TextField_Property_SCROLL_THRESHOLD_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_SCROLL_SPEED_get")]
  public static extern int TextField_Property_SCROLL_SPEED_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_SELECTION_HANDLE_IMAGE_LEFT_get")]
  public static extern int TextField_Property_SELECTION_HANDLE_IMAGE_LEFT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_SELECTION_HANDLE_IMAGE_RIGHT_get")]
  public static extern int TextField_Property_SELECTION_HANDLE_IMAGE_RIGHT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_SELECTION_HANDLE_PRESSED_IMAGE_LEFT_get")]
  public static extern int TextField_Property_SELECTION_HANDLE_PRESSED_IMAGE_LEFT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_SELECTION_HANDLE_PRESSED_IMAGE_RIGHT_get")]
  public static extern int TextField_Property_SELECTION_HANDLE_PRESSED_IMAGE_RIGHT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_SELECTION_HANDLE_MARKER_IMAGE_LEFT_get")]
  public static extern int TextField_Property_SELECTION_HANDLE_MARKER_IMAGE_LEFT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_SELECTION_HANDLE_MARKER_IMAGE_RIGHT_get")]
  public static extern int TextField_Property_SELECTION_HANDLE_MARKER_IMAGE_RIGHT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_SELECTION_HIGHLIGHT_COLOR_get")]
  public static extern int TextField_Property_SELECTION_HIGHLIGHT_COLOR_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_DECORATION_BOUNDING_BOX_get")]
  public static extern int TextField_Property_DECORATION_BOUNDING_BOX_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_INPUT_METHOD_SETTINGS_get")]
  public static extern int TextField_Property_INPUT_METHOD_SETTINGS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_INPUT_COLOR_get")]
  public static extern int TextField_Property_INPUT_COLOR_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_ENABLE_MARKUP_get")]
  public static extern int TextField_Property_ENABLE_MARKUP_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_INPUT_FONT_FAMILY_get")]
  public static extern int TextField_Property_INPUT_FONT_FAMILY_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_INPUT_FONT_STYLE_get")]
  public static extern int TextField_Property_INPUT_FONT_STYLE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_INPUT_POINT_SIZE_get")]
  public static extern int TextField_Property_INPUT_POINT_SIZE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_UNDERLINE_get")]
  public static extern int TextField_Property_UNDERLINE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_INPUT_UNDERLINE_get")]
  public static extern int TextField_Property_INPUT_UNDERLINE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_SHADOW_get")]
  public static extern int TextField_Property_SHADOW_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_INPUT_SHADOW_get")]
  public static extern int TextField_Property_INPUT_SHADOW_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_EMBOSS_get")]
  public static extern int TextField_Property_EMBOSS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_INPUT_EMBOSS_get")]
  public static extern int TextField_Property_INPUT_EMBOSS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_OUTLINE_get")]
  public static extern int TextField_Property_OUTLINE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Property_INPUT_OUTLINE_get")]
  public static extern int TextField_Property_INPUT_OUTLINE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TextField_Property")]
  public static extern global::System.IntPtr new_TextField_Property();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_TextField_Property")]
  public static extern void delete_TextField_Property(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TextField_InputStyle")]
  public static extern global::System.IntPtr new_TextField_InputStyle();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_TextField_InputStyle")]
  public static extern void delete_TextField_InputStyle(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_New")]
  public static extern global::System.IntPtr TextField_New();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TextField__SWIG_0")]
  public static extern global::System.IntPtr new_TextField__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TextField__SWIG_1")]
  public static extern global::System.IntPtr new_TextField__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_Assign")]
  public static extern global::System.IntPtr TextField_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_TextField")]
  public static extern void delete_TextField(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_DownCast")]
  public static extern global::System.IntPtr TextField_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_GetInputMethodContext")]
  public static extern global::System.IntPtr TextField_GetInputMethodContext(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_TextChangedSignal")]
  public static extern global::System.IntPtr TextField_TextChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_MaxLengthReachedSignal")]
  public static extern global::System.IntPtr TextField_MaxLengthReachedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_InputStyleChangedSignal")]
  public static extern global::System.IntPtr TextField_InputStyleChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextLabel_Property_RENDERING_BACKEND_get")]
  public static extern int TextLabel_Property_RENDERING_BACKEND_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextLabel_Property_TEXT_get")]
  public static extern int TextLabel_Property_TEXT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextLabel_Property_FONT_FAMILY_get")]
  public static extern int TextLabel_Property_FONT_FAMILY_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextLabel_Property_FONT_STYLE_get")]
  public static extern int TextLabel_Property_FONT_STYLE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextLabel_Property_POINT_SIZE_get")]
  public static extern int TextLabel_Property_POINT_SIZE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextLabel_Property_MULTI_LINE_get")]
  public static extern int TextLabel_Property_MULTI_LINE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextLabel_Property_HORIZONTAL_ALIGNMENT_get")]
  public static extern int TextLabel_Property_HORIZONTAL_ALIGNMENT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextLabel_Property_VERTICAL_ALIGNMENT_get")]
  public static extern int TextLabel_Property_VERTICAL_ALIGNMENT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextLabel_Property_TEXT_COLOR_get")]
  public static extern int TextLabel_Property_TEXT_COLOR_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextLabel_Property_SHADOW_OFFSET_get")]
  public static extern int TextLabel_Property_SHADOW_OFFSET_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextLabel_Property_SHADOW_COLOR_get")]
  public static extern int TextLabel_Property_SHADOW_COLOR_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextLabel_Property_UNDERLINE_ENABLED_get")]
  public static extern int TextLabel_Property_UNDERLINE_ENABLED_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextLabel_Property_UNDERLINE_COLOR_get")]
  public static extern int TextLabel_Property_UNDERLINE_COLOR_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextLabel_Property_UNDERLINE_HEIGHT_get")]
  public static extern int TextLabel_Property_UNDERLINE_HEIGHT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextLabel_Property_ENABLE_MARKUP_get")]
  public static extern int TextLabel_Property_ENABLE_MARKUP_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextLabel_Property_ENABLE_AUTO_SCROLL_get")]
  public static extern int TextLabel_Property_ENABLE_AUTO_SCROLL_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextLabel_Property_AUTO_SCROLL_SPEED_get")]
  public static extern int TextLabel_Property_AUTO_SCROLL_SPEED_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextLabel_Property_AUTO_SCROLL_LOOP_COUNT_get")]
  public static extern int TextLabel_Property_AUTO_SCROLL_LOOP_COUNT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextLabel_Property_AUTO_SCROLL_GAP_get")]
  public static extern int TextLabel_Property_AUTO_SCROLL_GAP_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextLabel_Property_LINE_SPACING_get")]
  public static extern int TextLabel_Property_LINE_SPACING_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextLabel_Property_UNDERLINE_get")]
  public static extern int TextLabel_Property_UNDERLINE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextLabel_Property_SHADOW_get")]
  public static extern int TextLabel_Property_SHADOW_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextLabel_Property_EMBOSS_get")]
  public static extern int TextLabel_Property_EMBOSS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextLabel_Property_OUTLINE_get")]
  public static extern int TextLabel_Property_OUTLINE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TextLabel_Property")]
  public static extern global::System.IntPtr new_TextLabel_Property();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_TextLabel_Property")]
  public static extern void delete_TextLabel_Property(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextLabel_New__SWIG_0")]
  public static extern global::System.IntPtr TextLabel_New__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextLabel_New__SWIG_1")]
  public static extern global::System.IntPtr TextLabel_New__SWIG_1(string jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TextLabel__SWIG_0")]
  public static extern global::System.IntPtr new_TextLabel__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TextLabel__SWIG_1")]
  public static extern global::System.IntPtr new_TextLabel__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextLabel_Assign")]
  public static extern global::System.IntPtr TextLabel_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_TextLabel")]
  public static extern void delete_TextLabel(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextLabel_DownCast")]
  public static extern global::System.IntPtr TextLabel_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_AccessibilityManager")]
  public static extern global::System.IntPtr new_AccessibilityManager();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_AccessibilityManager")]
  public static extern void delete_AccessibilityManager(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_Get")]
  public static extern global::System.IntPtr AccessibilityManager_Get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_SetAccessibilityAttribute")]
  public static extern void AccessibilityManager_SetAccessibilityAttribute(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, string jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_GetAccessibilityAttribute")]
  public static extern string AccessibilityManager_GetAccessibilityAttribute(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_SetFocusOrder")]
  public static extern void AccessibilityManager_SetFocusOrder(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, uint jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_GetFocusOrder")]
  public static extern uint AccessibilityManager_GetFocusOrder(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_GenerateNewFocusOrder")]
  public static extern uint AccessibilityManager_GenerateNewFocusOrder(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_GetActorByFocusOrder")]
  public static extern global::System.IntPtr AccessibilityManager_GetActorByFocusOrder(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_SetCurrentFocusActor")]
  public static extern bool AccessibilityManager_SetCurrentFocusActor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_GetCurrentFocusActor")]
  public static extern global::System.IntPtr AccessibilityManager_GetCurrentFocusActor(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_GetCurrentFocusGroup")]
  public static extern global::System.IntPtr AccessibilityManager_GetCurrentFocusGroup(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_GetCurrentFocusOrder")]
  public static extern uint AccessibilityManager_GetCurrentFocusOrder(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_MoveFocusForward")]
  public static extern bool AccessibilityManager_MoveFocusForward(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_MoveFocusBackward")]
  public static extern bool AccessibilityManager_MoveFocusBackward(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_ClearFocus")]
  public static extern void AccessibilityManager_ClearFocus(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_Reset")]
  public static extern void AccessibilityManager_Reset(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_SetFocusGroup")]
  public static extern void AccessibilityManager_SetFocusGroup(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, bool jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_IsFocusGroup")]
  public static extern bool AccessibilityManager_IsFocusGroup(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_SetGroupMode")]
  public static extern void AccessibilityManager_SetGroupMode(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_GetGroupMode")]
  public static extern bool AccessibilityManager_GetGroupMode(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_SetWrapMode")]
  public static extern void AccessibilityManager_SetWrapMode(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_GetWrapMode")]
  public static extern bool AccessibilityManager_GetWrapMode(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_SetFocusIndicatorActor")]
  public static extern void AccessibilityManager_SetFocusIndicatorActor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_GetFocusIndicatorActor")]
  public static extern global::System.IntPtr AccessibilityManager_GetFocusIndicatorActor(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_GetFocusGroup")]
  public static extern global::System.IntPtr AccessibilityManager_GetFocusGroup(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_GetReadPosition")]
  public static extern global::System.IntPtr AccessibilityManager_GetReadPosition(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_FocusChangedSignal")]
  public static extern global::System.IntPtr AccessibilityManager_FocusChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_FocusOvershotSignal")]
  public static extern global::System.IntPtr AccessibilityManager_FocusOvershotSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_FocusedActorActivatedSignal")]
  public static extern global::System.IntPtr AccessibilityManager_FocusedActorActivatedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_StatusChangedSignal")]
  public static extern global::System.IntPtr AccessibilityManager_StatusChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_ActionNextSignal")]
  public static extern global::System.IntPtr AccessibilityManager_ActionNextSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_ActionPreviousSignal")]
  public static extern global::System.IntPtr AccessibilityManager_ActionPreviousSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_ActionActivateSignal")]
  public static extern global::System.IntPtr AccessibilityManager_ActionActivateSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_ActionReadSignal")]
  public static extern global::System.IntPtr AccessibilityManager_ActionReadSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_ActionOverSignal")]
  public static extern global::System.IntPtr AccessibilityManager_ActionOverSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_ActionReadNextSignal")]
  public static extern global::System.IntPtr AccessibilityManager_ActionReadNextSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_ActionReadPreviousSignal")]
  public static extern global::System.IntPtr AccessibilityManager_ActionReadPreviousSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_ActionUpSignal")]
  public static extern global::System.IntPtr AccessibilityManager_ActionUpSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_ActionDownSignal")]
  public static extern global::System.IntPtr AccessibilityManager_ActionDownSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_ActionClearFocusSignal")]
  public static extern global::System.IntPtr AccessibilityManager_ActionClearFocusSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_ActionBackSignal")]
  public static extern global::System.IntPtr AccessibilityManager_ActionBackSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_ActionScrollUpSignal")]
  public static extern global::System.IntPtr AccessibilityManager_ActionScrollUpSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_ActionScrollDownSignal")]
  public static extern global::System.IntPtr AccessibilityManager_ActionScrollDownSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_ActionPageLeftSignal")]
  public static extern global::System.IntPtr AccessibilityManager_ActionPageLeftSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_ActionPageRightSignal")]
  public static extern global::System.IntPtr AccessibilityManager_ActionPageRightSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_ActionPageUpSignal")]
  public static extern global::System.IntPtr AccessibilityManager_ActionPageUpSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_ActionPageDownSignal")]
  public static extern global::System.IntPtr AccessibilityManager_ActionPageDownSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_ActionMoveToFirstSignal")]
  public static extern global::System.IntPtr AccessibilityManager_ActionMoveToFirstSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_ActionMoveToLastSignal")]
  public static extern global::System.IntPtr AccessibilityManager_ActionMoveToLastSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_ActionReadFromTopSignal")]
  public static extern global::System.IntPtr AccessibilityManager_ActionReadFromTopSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_ActionReadFromNextSignal")]
  public static extern global::System.IntPtr AccessibilityManager_ActionReadFromNextSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_ActionZoomSignal")]
  public static extern global::System.IntPtr AccessibilityManager_ActionZoomSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_ActionReadIndicatorInformationSignal")]
  public static extern global::System.IntPtr AccessibilityManager_ActionReadIndicatorInformationSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_ActionReadPauseResumeSignal")]
  public static extern global::System.IntPtr AccessibilityManager_ActionReadPauseResumeSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_ActionStartStopSignal")]
  public static extern global::System.IntPtr AccessibilityManager_ActionStartStopSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_ActionScrollSignal")]
  public static extern global::System.IntPtr AccessibilityManager_ActionScrollSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_StyleManager")]
  public static extern global::System.IntPtr new_StyleManager();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_StyleManager")]
  public static extern void delete_StyleManager(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_StyleManager_Get")]
  public static extern global::System.IntPtr StyleManager_Get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_StyleManager_ApplyTheme")]
  public static extern void StyleManager_ApplyTheme(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_StyleManager_ApplyDefaultTheme")]
  public static extern void StyleManager_ApplyDefaultTheme(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_StyleManager_SetStyleConstant")]
  public static extern void StyleManager_SetStyleConstant(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_StyleManager_GetStyleConstant")]
  public static extern bool StyleManager_GetStyleConstant(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_StyleManager_ApplyStyle")]
  public static extern void StyleManager_ApplyStyle(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, string jarg3, string jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_StyleManager_StyleChangedSignal")]
  public static extern global::System.IntPtr StyleManager_StyleChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Slider_Property_LOWER_BOUND_get")]
  public static extern int Slider_Property_LOWER_BOUND_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Slider_Property_UPPER_BOUND_get")]
  public static extern int Slider_Property_UPPER_BOUND_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Slider_Property_VALUE_get")]
  public static extern int Slider_Property_VALUE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Slider_Property_TRACK_VISUAL_get")]
  public static extern int Slider_Property_TRACK_VISUAL_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Slider_Property_HANDLE_VISUAL_get")]
  public static extern int Slider_Property_HANDLE_VISUAL_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Slider_Property_PROGRESS_VISUAL_get")]
  public static extern int Slider_Property_PROGRESS_VISUAL_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Slider_Property_POPUP_VISUAL_get")]
  public static extern int Slider_Property_POPUP_VISUAL_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Slider_Property_POPUP_ARROW_VISUAL_get")]
  public static extern int Slider_Property_POPUP_ARROW_VISUAL_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Slider_Property_DISABLED_COLOR_get")]
  public static extern int Slider_Property_DISABLED_COLOR_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Slider_Property_VALUE_PRECISION_get")]
  public static extern int Slider_Property_VALUE_PRECISION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Slider_Property_SHOW_POPUP_get")]
  public static extern int Slider_Property_SHOW_POPUP_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Slider_Property_SHOW_VALUE_get")]
  public static extern int Slider_Property_SHOW_VALUE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Slider_Property_MARKS_get")]
  public static extern int Slider_Property_MARKS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Slider_Property_SNAP_TO_MARKS_get")]
  public static extern int Slider_Property_SNAP_TO_MARKS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Slider_Property_MARK_TOLERANCE_get")]
  public static extern int Slider_Property_MARK_TOLERANCE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Slider_Property")]
  public static extern global::System.IntPtr new_Slider_Property();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Slider_Property")]
  public static extern void delete_Slider_Property(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Slider_New")]
  public static extern global::System.IntPtr Slider_New();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Slider__SWIG_0")]
  public static extern global::System.IntPtr new_Slider__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Slider__SWIG_1")]
  public static extern global::System.IntPtr new_Slider__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Slider_Assign")]
  public static extern global::System.IntPtr Slider_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Slider")]
  public static extern void delete_Slider(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Slider_DownCast")]
  public static extern global::System.IntPtr Slider_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Slider_ValueChangedSignal")]
  public static extern global::System.IntPtr Slider_ValueChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Slider_SlidingFinishedSignal")]
  public static extern global::System.IntPtr Slider_SlidingFinishedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Slider_MarkReachedSignal")]
  public static extern global::System.IntPtr Slider_MarkReachedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VideoView_Property_VIDEO_get")]
  public static extern int VideoView_Property_VIDEO_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VideoView_Property_LOOPING_get")]
  public static extern int VideoView_Property_LOOPING_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VideoView_Property_MUTED_get")]
  public static extern int VideoView_Property_MUTED_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VideoView_Property_VOLUME_get")]
  public static extern int VideoView_Property_VOLUME_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VideoView_Property_UNDERLAY_get")]
  public static extern int VideoView_Property_UNDERLAY_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_VideoView_Property")]
  public static extern global::System.IntPtr new_VideoView_Property();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_VideoView_Property")]
  public static extern void delete_VideoView_Property(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VideoView_New__SWIG_0")]
  public static extern global::System.IntPtr VideoView_New__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VideoView_New__SWIG_1")]
  public static extern global::System.IntPtr VideoView_New__SWIG_1(string jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_VideoView__SWIG_0")]
  public static extern global::System.IntPtr new_VideoView__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_VideoView")]
  public static extern void delete_VideoView(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_VideoView__SWIG_1")]
  public static extern global::System.IntPtr new_VideoView__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VideoView_Assign")]
  public static extern global::System.IntPtr VideoView_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VideoView_DownCast")]
  public static extern global::System.IntPtr VideoView_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VideoView_Play")]
  public static extern void VideoView_Play(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VideoView_Pause")]
  public static extern void VideoView_Pause(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VideoView_Stop")]
  public static extern void VideoView_Stop(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VideoView_Forward")]
  public static extern void VideoView_Forward(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VideoView_Backward")]
  public static extern void VideoView_Backward(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VideoView_FinishedSignal")]
  public static extern global::System.IntPtr VideoView_FinishedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Popup_Property_TITLE_get")]
  public static extern int Popup_Property_TITLE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Popup_Property_CONTENT_get")]
  public static extern int Popup_Property_CONTENT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Popup_Property_FOOTER_get")]
  public static extern int Popup_Property_FOOTER_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Popup_Property_DISPLAY_STATE_get")]
  public static extern int Popup_Property_DISPLAY_STATE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Popup_Property_TOUCH_TRANSPARENT_get")]
  public static extern int Popup_Property_TOUCH_TRANSPARENT_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Popup_Property_TAIL_VISIBILITY_get")]
  public static extern int Popup_Property_TAIL_VISIBILITY_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Popup_Property_TAIL_POSITION_get")]
  public static extern int Popup_Property_TAIL_POSITION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Popup_Property_CONTEXTUAL_MODE_get")]
  public static extern int Popup_Property_CONTEXTUAL_MODE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Popup_Property_ANIMATION_DURATION_get")]
  public static extern int Popup_Property_ANIMATION_DURATION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Popup_Property_ANIMATION_MODE_get")]
  public static extern int Popup_Property_ANIMATION_MODE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Popup_Property_ENTRY_ANIMATION_get")]
  public static extern int Popup_Property_ENTRY_ANIMATION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Popup_Property_EXIT_ANIMATION_get")]
  public static extern int Popup_Property_EXIT_ANIMATION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Popup_Property_AUTO_HIDE_DELAY_get")]
  public static extern int Popup_Property_AUTO_HIDE_DELAY_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Popup_Property_BACKING_ENABLED_get")]
  public static extern int Popup_Property_BACKING_ENABLED_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Popup_Property_BACKING_COLOR_get")]
  public static extern int Popup_Property_BACKING_COLOR_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Popup_Property_POPUP_BACKGROUND_IMAGE_get")]
  public static extern int Popup_Property_POPUP_BACKGROUND_IMAGE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Popup_Property_POPUP_BACKGROUND_BORDER_get")]
  public static extern int Popup_Property_POPUP_BACKGROUND_BORDER_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Popup_Property_TAIL_UP_IMAGE_get")]
  public static extern int Popup_Property_TAIL_UP_IMAGE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Popup_Property_TAIL_DOWN_IMAGE_get")]
  public static extern int Popup_Property_TAIL_DOWN_IMAGE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Popup_Property_TAIL_LEFT_IMAGE_get")]
  public static extern int Popup_Property_TAIL_LEFT_IMAGE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Popup_Property_TAIL_RIGHT_IMAGE_get")]
  public static extern int Popup_Property_TAIL_RIGHT_IMAGE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Popup_Property")]
  public static extern global::System.IntPtr new_Popup_Property();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Popup_Property")]
  public static extern void delete_Popup_Property(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Popup__SWIG_0")]
  public static extern global::System.IntPtr new_Popup__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Popup_New")]
  public static extern global::System.IntPtr Popup_New();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Popup")]
  public static extern void delete_Popup(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Popup__SWIG_1")]
  public static extern global::System.IntPtr new_Popup__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Popup_Assign")]
  public static extern global::System.IntPtr Popup_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Popup_DownCast")]
  public static extern global::System.IntPtr Popup_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Popup_SetTitle")]
  public static extern void Popup_SetTitle(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Popup_GetTitle")]
  public static extern global::System.IntPtr Popup_GetTitle(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Popup_SetContent")]
  public static extern void Popup_SetContent(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Popup_GetContent")]
  public static extern global::System.IntPtr Popup_GetContent(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Popup_SetFooter")]
  public static extern void Popup_SetFooter(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Popup_GetFooter")]
  public static extern global::System.IntPtr Popup_GetFooter(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Popup_SetDisplayState")]
  public static extern void Popup_SetDisplayState(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Popup_GetDisplayState")]
  public static extern int Popup_GetDisplayState(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Popup_OutsideTouchedSignal")]
  public static extern global::System.IntPtr Popup_OutsideTouchedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Popup_ShowingSignal")]
  public static extern global::System.IntPtr Popup_ShowingSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Popup_ShownSignal")]
  public static extern global::System.IntPtr Popup_ShownSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Popup_HidingSignal")]
  public static extern global::System.IntPtr Popup_HidingSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Popup_HiddenSignal")]
  public static extern global::System.IntPtr Popup_HiddenSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ProgressBar_Property_PROGRESS_VALUE_get")]
  public static extern int ProgressBar_Property_PROGRESS_VALUE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ProgressBar_Property_SECONDARY_PROGRESS_VALUE_get")]
  public static extern int ProgressBar_Property_SECONDARY_PROGRESS_VALUE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ProgressBar_Property_INDETERMINATE_get")]
  public static extern int ProgressBar_Property_INDETERMINATE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ProgressBar_Property_TRACK_VISUAL_get")]
  public static extern int ProgressBar_Property_TRACK_VISUAL_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ProgressBar_Property_PROGRESS_VISUAL_get")]
  public static extern int ProgressBar_Property_PROGRESS_VISUAL_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ProgressBar_Property_SECONDARY_PROGRESS_VISUAL_get")]
  public static extern int ProgressBar_Property_SECONDARY_PROGRESS_VISUAL_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ProgressBar_Property_INDETERMINATE_VISUAL_get")]
  public static extern int ProgressBar_Property_INDETERMINATE_VISUAL_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ProgressBar_Property_INDETERMINATE_VISUAL_ANIMATION_get")]
  public static extern int ProgressBar_Property_INDETERMINATE_VISUAL_ANIMATION_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ProgressBar_Property_LABEL_VISUAL_get")]
  public static extern int ProgressBar_Property_LABEL_VISUAL_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ProgressBar_Property")]
  public static extern global::System.IntPtr new_ProgressBar_Property();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ProgressBar_Property")]
  public static extern void delete_ProgressBar_Property(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ProgressBar_New")]
  public static extern global::System.IntPtr ProgressBar_New();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ProgressBar__SWIG_0")]
  public static extern global::System.IntPtr new_ProgressBar__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ProgressBar__SWIG_1")]
  public static extern global::System.IntPtr new_ProgressBar__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ProgressBar_Assign")]
  public static extern global::System.IntPtr ProgressBar_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ProgressBar")]
  public static extern void delete_ProgressBar(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ProgressBar_DownCast")]
  public static extern global::System.IntPtr ProgressBar_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ProgressBar_ValueChangedSignal")]
  public static extern global::System.IntPtr ProgressBar_ValueChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_GaussianBlurView__SWIG_0")]
  public static extern global::System.IntPtr new_GaussianBlurView__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_GaussianBlurView__SWIG_1")]
  public static extern global::System.IntPtr new_GaussianBlurView__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GaussianBlurView_Assign")]
  public static extern global::System.IntPtr GaussianBlurView_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_GaussianBlurView")]
  public static extern void delete_GaussianBlurView(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GaussianBlurView_DownCast")]
  public static extern global::System.IntPtr GaussianBlurView_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GaussianBlurView_New__SWIG_0")]
  public static extern global::System.IntPtr GaussianBlurView_New__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GaussianBlurView_New__SWIG_1")]
  public static extern global::System.IntPtr GaussianBlurView_New__SWIG_1(uint jarg1, float jarg2, int jarg3, float jarg4, float jarg5, bool jarg6);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GaussianBlurView_New__SWIG_2")]
  public static extern global::System.IntPtr GaussianBlurView_New__SWIG_2(uint jarg1, float jarg2, int jarg3, float jarg4, float jarg5);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GaussianBlurView_Add")]
  public static extern void GaussianBlurView_Add(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GaussianBlurView_Remove")]
  public static extern void GaussianBlurView_Remove(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GaussianBlurView_Activate")]
  public static extern void GaussianBlurView_Activate(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GaussianBlurView_ActivateOnce")]
  public static extern void GaussianBlurView_ActivateOnce(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GaussianBlurView_Deactivate")]
  public static extern void GaussianBlurView_Deactivate(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GaussianBlurView_SetUserImageAndOutputRenderTarget")]
  public static extern void GaussianBlurView_SetUserImageAndOutputRenderTarget(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GaussianBlurView_GetBlurStrengthPropertyIndex")]
  public static extern int GaussianBlurView_GetBlurStrengthPropertyIndex(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GaussianBlurView_GetBlurredRenderTarget")]
  public static extern global::System.IntPtr GaussianBlurView_GetBlurredRenderTarget(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GaussianBlurView_SetBackgroundColor")]
  public static extern void GaussianBlurView_SetBackgroundColor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GaussianBlurView_GetBackgroundColor")]
  public static extern global::System.IntPtr GaussianBlurView_GetBackgroundColor(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GaussianBlurView_FinishedSignal")]
  public static extern global::System.IntPtr GaussianBlurView_FinishedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_PageFactory")]
  public static extern void delete_PageFactory(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PageFactory_GetNumberOfPages")]
  public static extern uint PageFactory_GetNumberOfPages(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PageFactory_NewPage")]
  public static extern global::System.IntPtr PageFactory_NewPage(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PageTurnView_Property_PAGE_SIZE_get")]
  public static extern int PageTurnView_Property_PAGE_SIZE_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PageTurnView_Property_CURRENT_PAGE_ID_get")]
  public static extern int PageTurnView_Property_CURRENT_PAGE_ID_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PageTurnView_Property_SPINE_SHADOW_get")]
  public static extern int PageTurnView_Property_SPINE_SHADOW_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PageTurnView_Property")]
  public static extern global::System.IntPtr new_PageTurnView_Property();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_PageTurnView_Property")]
  public static extern void delete_PageTurnView_Property(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PageTurnView__SWIG_0")]
  public static extern global::System.IntPtr new_PageTurnView__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PageTurnView__SWIG_1")]
  public static extern global::System.IntPtr new_PageTurnView__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PageTurnView_Assign")]
  public static extern global::System.IntPtr PageTurnView_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_PageTurnView")]
  public static extern void delete_PageTurnView(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PageTurnView_DownCast")]
  public static extern global::System.IntPtr PageTurnView_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PageTurnView_PageTurnStartedSignal")]
  public static extern global::System.IntPtr PageTurnView_PageTurnStartedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PageTurnView_PageTurnFinishedSignal")]
  public static extern global::System.IntPtr PageTurnView_PageTurnFinishedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PageTurnView_PagePanStartedSignal")]
  public static extern global::System.IntPtr PageTurnView_PagePanStartedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PageTurnView_PagePanFinishedSignal")]
  public static extern global::System.IntPtr PageTurnView_PagePanFinishedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PageTurnLandscapeView__SWIG_0")]
  public static extern global::System.IntPtr new_PageTurnLandscapeView__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PageTurnLandscapeView__SWIG_1")]
  public static extern global::System.IntPtr new_PageTurnLandscapeView__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PageTurnLandscapeView_Assign")]
  public static extern global::System.IntPtr PageTurnLandscapeView_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_PageTurnLandscapeView")]
  public static extern void delete_PageTurnLandscapeView(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PageTurnLandscapeView_New")]
  public static extern global::System.IntPtr PageTurnLandscapeView_New(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PageTurnLandscapeView_DownCast")]
  public static extern global::System.IntPtr PageTurnLandscapeView_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PageTurnPortraitView__SWIG_0")]
  public static extern global::System.IntPtr new_PageTurnPortraitView__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PageTurnPortraitView__SWIG_1")]
  public static extern global::System.IntPtr new_PageTurnPortraitView__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PageTurnPortraitView_Assign")]
  public static extern global::System.IntPtr PageTurnPortraitView_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_PageTurnPortraitView")]
  public static extern void delete_PageTurnPortraitView(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PageTurnPortraitView_New")]
  public static extern global::System.IntPtr PageTurnPortraitView_New(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PageTurnPortraitView_DownCast")]
  public static extern global::System.IntPtr PageTurnPortraitView_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ToggleButton_Property_STATE_VISUALS_get")]
  public static extern int ToggleButton_Property_STATE_VISUALS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ToggleButton_Property_TOOLTIPS_get")]
  public static extern int ToggleButton_Property_TOOLTIPS_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ToggleButton_Property_CURRENT_STATE_INDEX_get")]
  public static extern int ToggleButton_Property_CURRENT_STATE_INDEX_get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ToggleButton_Property")]
  public static extern global::System.IntPtr new_ToggleButton_Property();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ToggleButton_Property")]
  public static extern void delete_ToggleButton_Property(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ToggleButton__SWIG_0")]
  public static extern global::System.IntPtr new_ToggleButton__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ToggleButton__SWIG_1")]
  public static extern global::System.IntPtr new_ToggleButton__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ToggleButton_Assign")]
  public static extern global::System.IntPtr ToggleButton_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ToggleButton")]
  public static extern void delete_ToggleButton(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ToggleButton_New")]
  public static extern global::System.IntPtr ToggleButton_New();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ToggleButton_DownCast")]
  public static extern global::System.IntPtr ToggleButton_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_VisualBase__SWIG_0")]
  public static extern global::System.IntPtr new_VisualBase__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_VisualBase")]
  public static extern void delete_VisualBase(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_VisualBase__SWIG_1")]
  public static extern global::System.IntPtr new_VisualBase__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VisualBase_Assign")]
  public static extern global::System.IntPtr VisualBase_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VisualBase_SetName")]
  public static extern void VisualBase_SetName(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VisualBase_GetName")]
  public static extern string VisualBase_GetName(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VisualBase_SetTransformAndSize")]
  public static extern void VisualBase_SetTransformAndSize(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VisualBase_GetHeightForWidth")]
  public static extern float VisualBase_GetHeightForWidth(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VisualBase_GetWidthForHeight")]
  public static extern float VisualBase_GetWidthForHeight(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VisualBase_GetNaturalSize")]
  public static extern void VisualBase_GetNaturalSize(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VisualBase_SetDepthIndex")]
  public static extern void VisualBase_SetDepthIndex(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VisualBase_GetDepthIndex")]
  public static extern int VisualBase_GetDepthIndex(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VisualBase_CreatePropertyMap")]
  public static extern void VisualBase_CreatePropertyMap(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VisualFactory_Get")]
  public static extern global::System.IntPtr VisualFactory_Get();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_VisualFactory__SWIG_0")]
  public static extern global::System.IntPtr new_VisualFactory__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_VisualFactory")]
  public static extern void delete_VisualFactory(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_VisualFactory__SWIG_1")]
  public static extern global::System.IntPtr new_VisualFactory__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VisualFactory_Assign")]
  public static extern global::System.IntPtr VisualFactory_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VisualFactory_CreateVisual__SWIG_0")]
  public static extern global::System.IntPtr VisualFactory_CreateVisual__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VisualFactory_CreateVisual__SWIG_1")]
  public static extern global::System.IntPtr VisualFactory_CreateVisual__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VisualFactory_CreateVisual__SWIG_2")]
  public static extern global::System.IntPtr VisualFactory_CreateVisual__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_AsyncImageLoader__SWIG_0")]
  public static extern global::System.IntPtr new_AsyncImageLoader__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_AsyncImageLoader")]
  public static extern void delete_AsyncImageLoader(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_AsyncImageLoader__SWIG_1")]
  public static extern global::System.IntPtr new_AsyncImageLoader__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AsyncImageLoader_Assign")]
  public static extern global::System.IntPtr AsyncImageLoader_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AsyncImageLoader_New")]
  public static extern global::System.IntPtr AsyncImageLoader_New();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AsyncImageLoader_DownCast")]
  public static extern global::System.IntPtr AsyncImageLoader_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AsyncImageLoader_Load__SWIG_0")]
  public static extern uint AsyncImageLoader_Load__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AsyncImageLoader_Load__SWIG_1")]
  public static extern uint AsyncImageLoader_Load__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AsyncImageLoader_Load__SWIG_2")]
  public static extern uint AsyncImageLoader_Load__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, int jarg4, int jarg5, bool jarg6);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AsyncImageLoader_Cancel")]
  public static extern bool AsyncImageLoader_Cancel(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AsyncImageLoader_CancelAll")]
  public static extern void AsyncImageLoader_CancelAll(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AsyncImageLoader_ImageLoadedSignal")]
  public static extern global::System.IntPtr AsyncImageLoader_ImageLoadedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LoadImageSynchronously__SWIG_0")]
  public static extern global::System.IntPtr LoadImageSynchronously__SWIG_0(string jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LoadImageSynchronously__SWIG_1")]
  public static extern global::System.IntPtr LoadImageSynchronously__SWIG_1(string jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LoadImageSynchronously__SWIG_2")]
  public static extern global::System.IntPtr LoadImageSynchronously__SWIG_2(string jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, int jarg4, bool jarg5);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_CustomAlgorithmInterface")]
  public static extern void delete_CustomAlgorithmInterface(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CustomAlgorithmInterface_GetNextFocusableActor")]
  public static extern global::System.IntPtr CustomAlgorithmInterface_GetNextFocusableActor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, int jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_CustomAlgorithmInterface")]
  public static extern global::System.IntPtr new_CustomAlgorithmInterface();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CustomAlgorithmInterface_director_connect")]
  public static extern void CustomAlgorithmInterface_director_connect(global::System.Runtime.InteropServices.HandleRef jarg1, CustomAlgorithmInterface.SwigDelegateCustomAlgorithmInterface_0 delegate0);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_SetCustomAlgorithm")]
  public static extern void SetCustomAlgorithm(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemIdContainer_Clear")]
  public static extern void ItemIdContainer_Clear(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemIdContainer_Add")]
  public static extern void ItemIdContainer_Add(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemIdContainer_size")]
  public static extern uint ItemIdContainer_size(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemIdContainer_capacity")]
  public static extern uint ItemIdContainer_capacity(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemIdContainer_reserve")]
  public static extern void ItemIdContainer_reserve(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ItemIdContainer__SWIG_0")]
  public static extern global::System.IntPtr new_ItemIdContainer__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ItemIdContainer__SWIG_1")]
  public static extern global::System.IntPtr new_ItemIdContainer__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ItemIdContainer__SWIG_2")]
  public static extern global::System.IntPtr new_ItemIdContainer__SWIG_2(int jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemIdContainer_getitemcopy")]
  public static extern uint ItemIdContainer_getitemcopy(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemIdContainer_getitem")]
  public static extern uint ItemIdContainer_getitem(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemIdContainer_setitem")]
  public static extern void ItemIdContainer_setitem(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, uint jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemIdContainer_AddRange")]
  public static extern void ItemIdContainer_AddRange(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemIdContainer_GetRange")]
  public static extern global::System.IntPtr ItemIdContainer_GetRange(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemIdContainer_Insert")]
  public static extern void ItemIdContainer_Insert(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, uint jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemIdContainer_InsertRange")]
  public static extern void ItemIdContainer_InsertRange(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemIdContainer_RemoveAt")]
  public static extern void ItemIdContainer_RemoveAt(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemIdContainer_RemoveRange")]
  public static extern void ItemIdContainer_RemoveRange(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemIdContainer_Repeat")]
  public static extern global::System.IntPtr ItemIdContainer_Repeat(uint jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemIdContainer_Reverse__SWIG_0")]
  public static extern void ItemIdContainer_Reverse__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemIdContainer_Reverse__SWIG_1")]
  public static extern void ItemIdContainer_Reverse__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemIdContainer_SetRange")]
  public static extern void ItemIdContainer_SetRange(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemIdContainer_Contains")]
  public static extern bool ItemIdContainer_Contains(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemIdContainer_IndexOf")]
  public static extern int ItemIdContainer_IndexOf(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemIdContainer_LastIndexOf")]
  public static extern int ItemIdContainer_LastIndexOf(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemIdContainer_Remove")]
  public static extern bool ItemIdContainer_Remove(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ItemIdContainer")]
  public static extern void delete_ItemIdContainer(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Item__SWIG_0")]
  public static extern global::System.IntPtr new_Item__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Item__SWIG_1")]
  public static extern global::System.IntPtr new_Item__SWIG_1(uint jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Item__SWIG_2")]
  public static extern global::System.IntPtr new_Item__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Item_first_set")]
  public static extern void Item_first_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Item_first_get")]
  public static extern uint Item_first_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Item_second_set")]
  public static extern void Item_second_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Item_second_get")]
  public static extern global::System.IntPtr Item_second_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_Item")]
  public static extern void delete_Item(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemContainer_Clear")]
  public static extern void ItemContainer_Clear(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemContainer_Add")]
  public static extern void ItemContainer_Add(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemContainer_size")]
  public static extern uint ItemContainer_size(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemContainer_capacity")]
  public static extern uint ItemContainer_capacity(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemContainer_reserve")]
  public static extern void ItemContainer_reserve(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ItemContainer__SWIG_0")]
  public static extern global::System.IntPtr new_ItemContainer__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ItemContainer__SWIG_1")]
  public static extern global::System.IntPtr new_ItemContainer__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ItemContainer__SWIG_2")]
  public static extern global::System.IntPtr new_ItemContainer__SWIG_2(int jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemContainer_getitemcopy")]
  public static extern global::System.IntPtr ItemContainer_getitemcopy(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemContainer_getitem")]
  public static extern global::System.IntPtr ItemContainer_getitem(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemContainer_setitem")]
  public static extern void ItemContainer_setitem(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemContainer_AddRange")]
  public static extern void ItemContainer_AddRange(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemContainer_GetRange")]
  public static extern global::System.IntPtr ItemContainer_GetRange(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemContainer_Insert")]
  public static extern void ItemContainer_Insert(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemContainer_InsertRange")]
  public static extern void ItemContainer_InsertRange(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemContainer_RemoveAt")]
  public static extern void ItemContainer_RemoveAt(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemContainer_RemoveRange")]
  public static extern void ItemContainer_RemoveRange(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemContainer_Repeat")]
  public static extern global::System.IntPtr ItemContainer_Repeat(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemContainer_Reverse__SWIG_0")]
  public static extern void ItemContainer_Reverse__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemContainer_Reverse__SWIG_1")]
  public static extern void ItemContainer_Reverse__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemContainer_SetRange")]
  public static extern void ItemContainer_SetRange(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ItemContainer")]
  public static extern void delete_ItemContainer(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ActorContainer_Clear")]
  public static extern void ActorContainer_Clear(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ActorContainer_Add")]
  public static extern void ActorContainer_Add(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ActorContainer_size")]
  public static extern uint ActorContainer_size(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ActorContainer_capacity")]
  public static extern uint ActorContainer_capacity(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ActorContainer_reserve")]
  public static extern void ActorContainer_reserve(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ActorContainer__SWIG_0")]
  public static extern global::System.IntPtr new_ActorContainer__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ActorContainer__SWIG_1")]
  public static extern global::System.IntPtr new_ActorContainer__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ActorContainer__SWIG_2")]
  public static extern global::System.IntPtr new_ActorContainer__SWIG_2(int jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ActorContainer_getitemcopy")]
  public static extern global::System.IntPtr ActorContainer_getitemcopy(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ActorContainer_getitem")]
  public static extern global::System.IntPtr ActorContainer_getitem(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ActorContainer_setitem")]
  public static extern void ActorContainer_setitem(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ActorContainer_AddRange")]
  public static extern void ActorContainer_AddRange(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ActorContainer_GetRange")]
  public static extern global::System.IntPtr ActorContainer_GetRange(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ActorContainer_Insert")]
  public static extern void ActorContainer_Insert(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ActorContainer_InsertRange")]
  public static extern void ActorContainer_InsertRange(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ActorContainer_RemoveAt")]
  public static extern void ActorContainer_RemoveAt(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ActorContainer_RemoveRange")]
  public static extern void ActorContainer_RemoveRange(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ActorContainer_Repeat")]
  public static extern global::System.IntPtr ActorContainer_Repeat(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ActorContainer_Reverse__SWIG_0")]
  public static extern void ActorContainer_Reverse__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ActorContainer_Reverse__SWIG_1")]
  public static extern void ActorContainer_Reverse__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ActorContainer_SetRange")]
  public static extern void ActorContainer_SetRange(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ActorContainer")]
  public static extern void delete_ActorContainer(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityActionSignal_Empty")]
  public static extern bool AccessibilityActionSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityActionSignal_GetConnectionCount")]
  public static extern uint AccessibilityActionSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityActionSignal_Connect")]
  public static extern void AccessibilityActionSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityActionSignal_Disconnect")]
  public static extern void AccessibilityActionSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityActionSignal_Emit")]
  public static extern bool AccessibilityActionSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_AccessibilityActionSignal")]
  public static extern global::System.IntPtr new_AccessibilityActionSignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_AccessibilityActionSignal")]
  public static extern void delete_AccessibilityActionSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityFocusOvershotSignal_Empty")]
  public static extern bool AccessibilityFocusOvershotSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityFocusOvershotSignal_GetConnectionCount")]
  public static extern uint AccessibilityFocusOvershotSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityFocusOvershotSignal_Connect")]
  public static extern void AccessibilityFocusOvershotSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityFocusOvershotSignal_Disconnect")]
  public static extern void AccessibilityFocusOvershotSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityFocusOvershotSignal_Emit")]
  public static extern void AccessibilityFocusOvershotSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_AccessibilityFocusOvershotSignal")]
  public static extern global::System.IntPtr new_AccessibilityFocusOvershotSignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_AccessibilityFocusOvershotSignal")]
  public static extern void delete_AccessibilityFocusOvershotSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FocusChangedSignal_Empty")]
  public static extern bool FocusChangedSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FocusChangedSignal_GetConnectionCount")]
  public static extern uint FocusChangedSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FocusChangedSignal_Connect")]
  public static extern void FocusChangedSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FocusChangedSignal_Disconnect")]
  public static extern void FocusChangedSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FocusChangedSignal_Emit")]
  public static extern void FocusChangedSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_FocusChangedSignal")]
  public static extern global::System.IntPtr new_FocusChangedSignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_FocusChangedSignal")]
  public static extern void delete_FocusChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FocusGroupChangedSignal_Empty")]
  public static extern bool FocusGroupChangedSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FocusGroupChangedSignal_GetConnectionCount")]
  public static extern uint FocusGroupChangedSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FocusGroupChangedSignal_Connect")]
  public static extern void FocusGroupChangedSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FocusGroupChangedSignal_Disconnect")]
  public static extern void FocusGroupChangedSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FocusGroupChangedSignal_Emit")]
  public static extern void FocusGroupChangedSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, bool jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_FocusGroupChangedSignal")]
  public static extern global::System.IntPtr new_FocusGroupChangedSignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_FocusGroupChangedSignal")]
  public static extern void delete_FocusGroupChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_StyleChangedSignal_Empty")]
  public static extern bool StyleChangedSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_StyleChangedSignal_GetConnectionCount")]
  public static extern uint StyleChangedSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_StyleChangedSignal_Connect")]
  public static extern void StyleChangedSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_StyleChangedSignal_Disconnect")]
  public static extern void StyleChangedSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_StyleChangedSignal_Emit")]
  public static extern void StyleChangedSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_StyleChangedSignal")]
  public static extern global::System.IntPtr new_StyleChangedSignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_StyleChangedSignal")]
  public static extern void delete_StyleChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ButtonSignal_Empty")]
  public static extern bool ButtonSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ButtonSignal_GetConnectionCount")]
  public static extern uint ButtonSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ButtonSignal_Connect")]
  public static extern void ButtonSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ButtonSignal_Disconnect")]
  public static extern void ButtonSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ButtonSignal_Emit")]
  public static extern bool ButtonSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ButtonSignal")]
  public static extern global::System.IntPtr new_ButtonSignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ButtonSignal")]
  public static extern void delete_ButtonSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GaussianBlurViewSignal_Empty")]
  public static extern bool GaussianBlurViewSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GaussianBlurViewSignal_GetConnectionCount")]
  public static extern uint GaussianBlurViewSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GaussianBlurViewSignal_Connect")]
  public static extern void GaussianBlurViewSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GaussianBlurViewSignal_Disconnect")]
  public static extern void GaussianBlurViewSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GaussianBlurViewSignal_Emit")]
  public static extern void GaussianBlurViewSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_GaussianBlurViewSignal")]
  public static extern global::System.IntPtr new_GaussianBlurViewSignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_GaussianBlurViewSignal")]
  public static extern void delete_GaussianBlurViewSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PageTurnSignal_Empty")]
  public static extern bool PageTurnSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PageTurnSignal_GetConnectionCount")]
  public static extern uint PageTurnSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PageTurnSignal_Connect")]
  public static extern void PageTurnSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PageTurnSignal_Disconnect")]
  public static extern void PageTurnSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PageTurnSignal_Emit")]
  public static extern void PageTurnSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, uint jarg3, bool jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PageTurnSignal")]
  public static extern global::System.IntPtr new_PageTurnSignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_PageTurnSignal")]
  public static extern void delete_PageTurnSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PagePanSignal_Empty")]
  public static extern bool PagePanSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PagePanSignal_GetConnectionCount")]
  public static extern uint PagePanSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PagePanSignal_Connect")]
  public static extern void PagePanSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PagePanSignal_Disconnect")]
  public static extern void PagePanSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PagePanSignal_Emit")]
  public static extern void PagePanSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PagePanSignal")]
  public static extern global::System.IntPtr new_PagePanSignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_PagePanSignal")]
  public static extern void delete_PagePanSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ProgressBarValueChangedSignal_Empty")]
  public static extern bool ProgressBarValueChangedSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ProgressBarValueChangedSignal_GetConnectionCount")]
  public static extern uint ProgressBarValueChangedSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ProgressBarValueChangedSignal_Connect")]
  public static extern void ProgressBarValueChangedSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ProgressBarValueChangedSignal_Disconnect")]
  public static extern void ProgressBarValueChangedSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ProgressBarValueChangedSignal_Emit")]
  public static extern void ProgressBarValueChangedSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3, float jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ProgressBarValueChangedSignal")]
  public static extern global::System.IntPtr new_ProgressBarValueChangedSignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ProgressBarValueChangedSignal")]
  public static extern void delete_ProgressBarValueChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollViewSnapStartedSignal_Empty")]
  public static extern bool ScrollViewSnapStartedSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollViewSnapStartedSignal_GetConnectionCount")]
  public static extern uint ScrollViewSnapStartedSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollViewSnapStartedSignal_Connect")]
  public static extern void ScrollViewSnapStartedSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollViewSnapStartedSignal_Disconnect")]
  public static extern void ScrollViewSnapStartedSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollViewSnapStartedSignal_Emit")]
  public static extern void ScrollViewSnapStartedSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ScrollViewSnapStartedSignal")]
  public static extern global::System.IntPtr new_ScrollViewSnapStartedSignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ScrollViewSnapStartedSignal")]
  public static extern void delete_ScrollViewSnapStartedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollableSignal_Empty")]
  public static extern bool ScrollableSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollableSignal_GetConnectionCount")]
  public static extern uint ScrollableSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollableSignal_Connect")]
  public static extern void ScrollableSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollableSignal_Disconnect")]
  public static extern void ScrollableSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollableSignal_Emit")]
  public static extern void ScrollableSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ScrollableSignal")]
  public static extern global::System.IntPtr new_ScrollableSignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ScrollableSignal")]
  public static extern void delete_ScrollableSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditorSignal_Empty")]
  public static extern bool TextEditorSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditorSignal_GetConnectionCount")]
  public static extern uint TextEditorSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditorSignal_Connect")]
  public static extern void TextEditorSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditorSignal_Disconnect")]
  public static extern void TextEditorSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditorSignal_Emit")]
  public static extern void TextEditorSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TextEditorSignal")]
  public static extern global::System.IntPtr new_TextEditorSignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_TextEditorSignal")]
  public static extern void delete_TextEditorSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextFieldSignal_Empty")]
  public static extern bool TextFieldSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextFieldSignal_GetConnectionCount")]
  public static extern uint TextFieldSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextFieldSignal_Connect")]
  public static extern void TextFieldSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextFieldSignal_Disconnect")]
  public static extern void TextFieldSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextFieldSignal_Emit")]
  public static extern void TextFieldSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_TextFieldSignal")]
  public static extern global::System.IntPtr new_TextFieldSignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_TextFieldSignal")]
  public static extern void delete_TextFieldSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ControlKeySignal_Empty")]
  public static extern bool ControlKeySignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ControlKeySignal_GetConnectionCount")]
  public static extern uint ControlKeySignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ControlKeySignal_Connect")]
  public static extern void ControlKeySignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ControlKeySignal_Disconnect")]
  public static extern void ControlKeySignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ControlKeySignal_Emit")]
  public static extern bool ControlKeySignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ControlKeySignal")]
  public static extern global::System.IntPtr new_ControlKeySignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ControlKeySignal")]
  public static extern void delete_ControlKeySignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_KeyInputFocusSignal_Empty")]
  public static extern bool KeyInputFocusSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_KeyInputFocusSignal_GetConnectionCount")]
  public static extern uint KeyInputFocusSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_KeyInputFocusSignal_Connect")]
  public static extern void KeyInputFocusSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_KeyInputFocusSignal_Disconnect")]
  public static extern void KeyInputFocusSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_KeyInputFocusSignal_Emit")]
  public static extern void KeyInputFocusSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_KeyInputFocusSignal")]
  public static extern global::System.IntPtr new_KeyInputFocusSignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_KeyInputFocusSignal")]
  public static extern void delete_KeyInputFocusSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VideoViewSignal_Empty")]
  public static extern bool VideoViewSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VideoViewSignal_GetConnectionCount")]
  public static extern uint VideoViewSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VideoViewSignal_Connect")]
  public static extern void VideoViewSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VideoViewSignal_Disconnect")]
  public static extern void VideoViewSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VideoViewSignal_Emit")]
  public static extern void VideoViewSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_VideoViewSignal")]
  public static extern global::System.IntPtr new_VideoViewSignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_VideoViewSignal")]
  public static extern void delete_VideoViewSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_SliderValueChangedSignal_Empty")]
  public static extern bool SliderValueChangedSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_SliderValueChangedSignal_GetConnectionCount")]
  public static extern uint SliderValueChangedSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_SliderValueChangedSignal_Connect")]
  public static extern void SliderValueChangedSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_SliderValueChangedSignal_Disconnect")]
  public static extern void SliderValueChangedSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_SliderValueChangedSignal_Emit")]
  public static extern bool SliderValueChangedSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_SliderValueChangedSignal")]
  public static extern global::System.IntPtr new_SliderValueChangedSignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_SliderValueChangedSignal")]
  public static extern void delete_SliderValueChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_SliderMarkReachedSignal_Empty")]
  public static extern bool SliderMarkReachedSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_SliderMarkReachedSignal_GetConnectionCount")]
  public static extern uint SliderMarkReachedSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_SliderMarkReachedSignal_Connect")]
  public static extern void SliderMarkReachedSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_SliderMarkReachedSignal_Disconnect")]
  public static extern void SliderMarkReachedSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_SliderMarkReachedSignal_Emit")]
  public static extern bool SliderMarkReachedSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_SliderMarkReachedSignal")]
  public static extern global::System.IntPtr new_SliderMarkReachedSignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_SliderMarkReachedSignal")]
  public static extern void delete_SliderMarkReachedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_RulerPtr__SWIG_0")]
  public static extern global::System.IntPtr new_RulerPtr__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_RulerPtr__SWIG_1")]
  public static extern global::System.IntPtr new_RulerPtr__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_RulerPtr__SWIG_2")]
  public static extern global::System.IntPtr new_RulerPtr__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_RulerPtr")]
  public static extern void delete_RulerPtr(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerPtr_Get")]
  public static extern global::System.IntPtr RulerPtr_Get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerPtr___deref__")]
  public static extern global::System.IntPtr RulerPtr___deref__(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerPtr___ref__")]
  public static extern global::System.IntPtr RulerPtr___ref__(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerPtr_Assign__SWIG_0")]
  public static extern global::System.IntPtr RulerPtr_Assign__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerPtr_Assign__SWIG_1")]
  public static extern global::System.IntPtr RulerPtr_Assign__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerPtr_Reset__SWIG_0")]
  public static extern void RulerPtr_Reset__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerPtr_Reset__SWIG_1")]
  public static extern void RulerPtr_Reset__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerPtr_Detach")]
  public static extern global::System.IntPtr RulerPtr_Detach(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerPtr_Snap__SWIG_0")]
  public static extern float RulerPtr_Snap__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerPtr_Snap__SWIG_1")]
  public static extern float RulerPtr_Snap__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerPtr_GetPositionFromPage")]
  public static extern float RulerPtr_GetPositionFromPage(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, out uint jarg3, bool jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerPtr_GetPageFromPosition")]
  public static extern uint RulerPtr_GetPageFromPosition(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, bool jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerPtr_GetTotalPages")]
  public static extern uint RulerPtr_GetTotalPages(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerPtr_GetType")]
  public static extern int RulerPtr_GetType(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerPtr_IsEnabled")]
  public static extern bool RulerPtr_IsEnabled(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerPtr_Enable")]
  public static extern void RulerPtr_Enable(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerPtr_Disable")]
  public static extern void RulerPtr_Disable(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerPtr_SetDomain")]
  public static extern void RulerPtr_SetDomain(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerPtr_GetDomain")]
  public static extern global::System.IntPtr RulerPtr_GetDomain(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerPtr_DisableDomain")]
  public static extern void RulerPtr_DisableDomain(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerPtr_Clamp__SWIG_0")]
  public static extern float RulerPtr_Clamp__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3, float jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerPtr_Clamp__SWIG_1")]
  public static extern float RulerPtr_Clamp__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerPtr_Clamp__SWIG_2")]
  public static extern float RulerPtr_Clamp__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerPtr_Clamp__SWIG_3")]
  public static extern float RulerPtr_Clamp__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3, float jarg4, global::System.Runtime.InteropServices.HandleRef jarg5);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerPtr_SnapAndClamp__SWIG_0")]
  public static extern float RulerPtr_SnapAndClamp__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3, float jarg4, float jarg5);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerPtr_SnapAndClamp__SWIG_1")]
  public static extern float RulerPtr_SnapAndClamp__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3, float jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerPtr_SnapAndClamp__SWIG_2")]
  public static extern float RulerPtr_SnapAndClamp__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerPtr_SnapAndClamp__SWIG_3")]
  public static extern float RulerPtr_SnapAndClamp__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerPtr_SnapAndClamp__SWIG_4")]
  public static extern float RulerPtr_SnapAndClamp__SWIG_4(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3, float jarg4, float jarg5, global::System.Runtime.InteropServices.HandleRef jarg6);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerPtr_Reference")]
  public static extern void RulerPtr_Reference(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerPtr_Unreference")]
  public static extern void RulerPtr_Unreference(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RulerPtr_ReferenceCount")]
  public static extern int RulerPtr_ReferenceCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewResourceReadySignal_Empty")]
  public static extern bool ViewResourceReadySignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewResourceReadySignal_GetConnectionCount")]
  public static extern uint ViewResourceReadySignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewResourceReadySignal_Connect")]
  public static extern void ViewResourceReadySignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewResourceReadySignal_Disconnect")]
  public static extern void ViewResourceReadySignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewResourceReadySignal_Emit")]
  public static extern void ViewResourceReadySignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_ViewResourceReadySignal")]
  public static extern global::System.IntPtr new_ViewResourceReadySignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_ViewResourceReadySignal")]
  public static extern void delete_ViewResourceReadySignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GetRefObjectPtr")]
  public static extern global::System.IntPtr GetRefObjectPtr(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_BaseObject_SWIGUpcast")]
  public static extern global::System.IntPtr BaseObject_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ConnectionTrackerInterface_SWIGUpcast")]
  public static extern global::System.IntPtr ConnectionTrackerInterface_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ConnectionTracker_SWIGUpcast")]
  public static extern global::System.IntPtr ConnectionTracker_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ObjectRegistry_SWIGUpcast")]
  public static extern global::System.IntPtr ObjectRegistry_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PropertyCondition_SWIGUpcast")]
  public static extern global::System.IntPtr PropertyCondition_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PropertyNotification_SWIGUpcast")]
  public static extern global::System.IntPtr PropertyNotification_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Handle_SWIGUpcast")]
  public static extern global::System.IntPtr Handle_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TypeInfo_SWIGUpcast")]
  public static extern global::System.IntPtr TypeInfo_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TypeRegistry_SWIGUpcast")]
  public static extern global::System.IntPtr TypeRegistry_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Image_SWIGUpcast")]
  public static extern global::System.IntPtr Image_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PixelData_SWIGUpcast")]
  public static extern global::System.IntPtr PixelData_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Texture_SWIGUpcast")]
  public static extern global::System.IntPtr Texture_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Sampler_SWIGUpcast")]
  public static extern global::System.IntPtr Sampler_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextureSet_SWIGUpcast")]
  public static extern global::System.IntPtr TextureSet_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PropertyBuffer_SWIGUpcast")]
  public static extern global::System.IntPtr PropertyBuffer_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Geometry_SWIGUpcast")]
  public static extern global::System.IntPtr Geometry_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Shader_SWIGUpcast")]
  public static extern global::System.IntPtr Shader_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Renderer_SWIGUpcast")]
  public static extern global::System.IntPtr Renderer_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FrameBuffer_SWIGUpcast")]
  public static extern global::System.IntPtr FrameBuffer_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTaskList_SWIGUpcast")]
  public static extern global::System.IntPtr RenderTaskList_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RenderTask_SWIGUpcast")]
  public static extern global::System.IntPtr RenderTask_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Touch_SWIGUpcast")]
  public static extern global::System.IntPtr Touch_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GestureDetector_SWIGUpcast")]
  public static extern global::System.IntPtr GestureDetector_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LongPressGestureDetector_SWIGUpcast")]
  public static extern global::System.IntPtr LongPressGestureDetector_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LongPressGesture_SWIGUpcast")]
  public static extern global::System.IntPtr LongPressGesture_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Actor_SWIGUpcast")]
  public static extern global::System.IntPtr Actor_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Layer_SWIGUpcast")]
  public static extern global::System.IntPtr Layer_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Stage_SWIGUpcast")]
  public static extern global::System.IntPtr Stage_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CustomActorImpl_SWIGUpcast")]
  public static extern global::System.IntPtr CustomActorImpl_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CustomActor_SWIGUpcast")]
  public static extern global::System.IntPtr CustomActor_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGestureDetector_SWIGUpcast")]
  public static extern global::System.IntPtr PanGestureDetector_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PanGesture_SWIGUpcast")]
  public static extern global::System.IntPtr PanGesture_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PinchGestureDetector_SWIGUpcast")]
  public static extern global::System.IntPtr PinchGestureDetector_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PinchGesture_SWIGUpcast")]
  public static extern global::System.IntPtr PinchGesture_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TapGestureDetector_SWIGUpcast")]
  public static extern global::System.IntPtr TapGestureDetector_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TapGesture_SWIGUpcast")]
  public static extern global::System.IntPtr TapGesture_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_KeyFrames_SWIGUpcast")]
  public static extern global::System.IntPtr KeyFrames_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Path_SWIGUpcast")]
  public static extern global::System.IntPtr Path_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Animation_SWIGUpcast")]
  public static extern global::System.IntPtr Animation_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LinearConstrainer_SWIGUpcast")]
  public static extern global::System.IntPtr LinearConstrainer_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PathConstrainer_SWIGUpcast")]
  public static extern global::System.IntPtr PathConstrainer_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_BufferImage_SWIGUpcast")]
  public static extern global::System.IntPtr BufferImage_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_EncodedBufferImage_SWIGUpcast")]
  public static extern global::System.IntPtr EncodedBufferImage_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_NativeImage_SWIGUpcast")]
  public static extern global::System.IntPtr NativeImage_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_NativeImageInterface_SWIGUpcast")]
  public static extern global::System.IntPtr NativeImageInterface_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ResourceImage_SWIGUpcast")]
  public static extern global::System.IntPtr ResourceImage_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FrameBufferImage_SWIGUpcast")]
  public static extern global::System.IntPtr FrameBufferImage_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_NinePatchImage_SWIGUpcast")]
  public static extern global::System.IntPtr NinePatchImage_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CameraActor_SWIGUpcast")]
  public static extern global::System.IntPtr CameraActor_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Timer_SWIGUpcast")]
  public static extern global::System.IntPtr Timer_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_DragAndDropDetector_SWIGUpcast")]
  public static extern global::System.IntPtr DragAndDropDetector_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Window_SWIGUpcast")]
  public static extern global::System.IntPtr Window_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Application_SWIGUpcast")]
  public static extern global::System.IntPtr Application_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Builder_SWIGUpcast")]
  public static extern global::System.IntPtr Builder_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TransitionData_SWIGUpcast")]
  public static extern global::System.IntPtr TransitionData_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ViewImpl_SWIGUpcast")]
  public static extern global::System.IntPtr ViewImpl_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_View_SWIGUpcast")]
  public static extern global::System.IntPtr View_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_KeyInputFocusManager_SWIGUpcast")]
  public static extern global::System.IntPtr KeyInputFocusManager_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Alignment_SWIGUpcast")]
  public static extern global::System.IntPtr Alignment_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Button_SWIGUpcast")]
  public static extern global::System.IntPtr Button_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_CheckBoxButton_SWIGUpcast")]
  public static extern global::System.IntPtr CheckBoxButton_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PushButton_SWIGUpcast")]
  public static extern global::System.IntPtr PushButton_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_RadioButton_SWIGUpcast")]
  public static extern global::System.IntPtr RadioButton_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FlexContainer_SWIGUpcast")]
  public static extern global::System.IntPtr FlexContainer_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ImageView_SWIGUpcast")]
  public static extern global::System.IntPtr ImageView_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Model3dView_SWIGUpcast")]
  public static extern global::System.IntPtr Model3dView_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollBar_SWIGUpcast")]
  public static extern global::System.IntPtr ScrollBar_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Scrollable_SWIGUpcast")]
  public static extern global::System.IntPtr Scrollable_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemLayout_SWIGUpcast")]
  public static extern global::System.IntPtr ItemLayout_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ItemView_SWIGUpcast")]
  public static extern global::System.IntPtr ItemView_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollViewEffect_SWIGUpcast")]
  public static extern global::System.IntPtr ScrollViewEffect_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollViewPagePathEffect_SWIGUpcast")]
  public static extern global::System.IntPtr ScrollViewPagePathEffect_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Ruler_SWIGUpcast")]
  public static extern global::System.IntPtr Ruler_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_DefaultRuler_SWIGUpcast")]
  public static extern global::System.IntPtr DefaultRuler_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_FixedRuler_SWIGUpcast")]
  public static extern global::System.IntPtr FixedRuler_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ScrollView_SWIGUpcast")]
  public static extern global::System.IntPtr ScrollView_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TableView_SWIGUpcast")]
  public static extern global::System.IntPtr TableView_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextEditor_SWIGUpcast")]
  public static extern global::System.IntPtr TextEditor_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextField_SWIGUpcast")]
  public static extern global::System.IntPtr TextField_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_TextLabel_SWIGUpcast")]
  public static extern global::System.IntPtr TextLabel_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AccessibilityManager_SWIGUpcast")]
  public static extern global::System.IntPtr AccessibilityManager_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_StyleManager_SWIGUpcast")]
  public static extern global::System.IntPtr StyleManager_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Slider_SWIGUpcast")]
  public static extern global::System.IntPtr Slider_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VideoView_SWIGUpcast")]
  public static extern global::System.IntPtr VideoView_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_Popup_SWIGUpcast")]
  public static extern global::System.IntPtr Popup_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ProgressBar_SWIGUpcast")]
  public static extern global::System.IntPtr ProgressBar_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GaussianBlurView_SWIGUpcast")]
  public static extern global::System.IntPtr GaussianBlurView_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PageTurnView_SWIGUpcast")]
  public static extern global::System.IntPtr PageTurnView_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PageTurnLandscapeView_SWIGUpcast")]
  public static extern global::System.IntPtr PageTurnLandscapeView_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PageTurnPortraitView_SWIGUpcast")]
  public static extern global::System.IntPtr PageTurnPortraitView_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_ToggleButton_SWIGUpcast")]
  public static extern global::System.IntPtr ToggleButton_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VisualBase_SWIGUpcast")]
  public static extern global::System.IntPtr VisualBase_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_VisualFactory_SWIGUpcast")]
  public static extern global::System.IntPtr VisualFactory_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_AsyncImageLoader_SWIGUpcast")]
  public static extern global::System.IntPtr AsyncImageLoader_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_WebViewLite_New")]
  public static extern global::System.IntPtr WebViewLite_New();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_WebViewLite__SWIG_0")]
  public static extern global::System.IntPtr new_WebViewLite__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_WebViewLite")]
  public static extern void delete_WebViewLite(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_WebViewLite__SWIG_1")]
  public static extern global::System.IntPtr new_WebViewLite__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_WebViewLite_Assign")]
  public static extern global::System.IntPtr WebViewLite_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_WebViewLite_DownCast")]
  public static extern global::System.IntPtr WebViewLite_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_WebViewLite_CreateInstance")]
  public static extern void WebViewLite_CreateInstance(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3, int jarg4, int jarg5, string jarg6, string jarg7);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_WebViewLite_DestroyInstance")]
  public static extern void WebViewLite_DestroyInstance(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_WebViewLite_LoadHtml")]
  public static extern void WebViewLite_LoadHtml(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_WebViewLite_FinishedSignal")]
  public static extern global::System.IntPtr WebViewLite_FinishedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_WebViewLiteSignal_Empty")]
  public static extern bool WebViewLiteSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_WebViewLiteSignal_GetConnectionCount")]
  public static extern uint WebViewLiteSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_WebViewLiteSignal_Connect")]
  public static extern void WebViewLiteSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_WebViewLiteSignal_Disconnect")]
  public static extern void WebViewLiteSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_WebViewLiteSignal_Emit")]
  public static extern void WebViewLiteSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_WebViewLiteSignal")]
  public static extern global::System.IntPtr new_WebViewLiteSignal();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_WebViewLiteSignal")]
  public static extern void delete_WebViewLiteSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_WebViewLite_SWIGUpcast")]
  public static extern global::System.IntPtr WebViewLite_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Extents__SWIG_0")]
  public static extern global::System.IntPtr new_Extents__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_Extents__SWIG_1")]
  public static extern global::System.IntPtr new_Extents__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_Extents__SWIG_2")]
  public static extern global::System.IntPtr new_Extents__SWIG_2(ushort jarg1, ushort jarg2, ushort jarg3, ushort jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Extents_Assign__SWIG_0")]
  public static extern global::System.IntPtr Extents_Assign__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Extents_Assign__SWIG_1")]
  public static extern global::System.IntPtr Extents_Assign__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Extents_EqualTo")]
  public static extern bool Extents_EqualTo(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Extents_NotEqualTo")]
  public static extern bool Extents_NotEqualTo(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Extents_start_set")]
  public static extern void Extents_start_set(global::System.Runtime.InteropServices.HandleRef jarg1, ushort jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Extents_start_get")]
  public static extern ushort Extents_start_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Extents_end_set")]
  public static extern void Extents_end_set(global::System.Runtime.InteropServices.HandleRef jarg1, ushort jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Extents_end_get")]
  public static extern ushort Extents_end_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Extents_top_set")]
  public static extern void Extents_top_set(global::System.Runtime.InteropServices.HandleRef jarg1, ushort jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Extents_top_get")]
  public static extern ushort Extents_top_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Extents_bottom_set")]
  public static extern void Extents_bottom_set(global::System.Runtime.InteropServices.HandleRef jarg1, ushort jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Extents_bottom_get")]
  public static extern ushort Extents_bottom_get(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_Extents")]
  public static extern void delete_Extents(global::System.Runtime.InteropServices.HandleRef jarg1);


  //for PixelBuffer and ImageLoading
  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_PixelBuffer_SWIGUpcast")]
  public static extern global::System.IntPtr PixelBuffer_SWIGUpcast(global::System.IntPtr jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PixelBuffer_New")]
  public static extern global::System.IntPtr PixelBuffer_New(uint jarg1, uint jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PixelBuffer__SWIG_0")]
  public static extern global::System.IntPtr new_PixelBuffer__SWIG_0();

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_delete_PixelBuffer")]
  public static extern void delete_PixelBuffer(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_new_PixelBuffer__SWIG_1")]
  public static extern global::System.IntPtr new_PixelBuffer__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PixelBuffer_Assign")]
  public static extern global::System.IntPtr PixelBuffer_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PixelBuffer_Convert")]
  public static extern global::System.IntPtr PixelBuffer_Convert(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PixelBuffer_CreatePixelData")]
  public static extern global::System.IntPtr PixelBuffer_CreatePixelData(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PixelBuffer_GetBuffer")]
  public static extern global::System.IntPtr PixelBuffer_GetBuffer(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PixelBuffer_GetWidth")]
  public static extern uint PixelBuffer_GetWidth(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PixelBuffer_GetHeight")]
  public static extern uint PixelBuffer_GetHeight(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PixelBuffer_GetPixelFormat")]
  public static extern int PixelBuffer_GetPixelFormat(global::System.Runtime.InteropServices.HandleRef jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PixelBuffer_ApplyMask__SWIG_0")]
  public static extern void PixelBuffer_ApplyMask__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3, bool jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PixelBuffer_ApplyMask__SWIG_1")]
  public static extern void PixelBuffer_ApplyMask__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PixelBuffer_ApplyMask__SWIG_2")]
  public static extern void PixelBuffer_ApplyMask__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PixelBuffer_ApplyGaussianBlur")]
  public static extern void PixelBuffer_ApplyGaussianBlur(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PixelBuffer_Crop")]
  public static extern void PixelBuffer_Crop(global::System.Runtime.InteropServices.HandleRef jarg1, ushort jarg2, ushort jarg3, ushort jarg4, ushort jarg5);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_PixelBuffer_Resize")]
  public static extern void PixelBuffer_Resize(global::System.Runtime.InteropServices.HandleRef jarg1, ushort jarg2, ushort jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LoadImageFromFile__SWIG_0")]
  public static extern global::System.IntPtr LoadImageFromFile__SWIG_0(string jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, int jarg4, bool jarg5);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LoadImageFromFile__SWIG_1")]
  public static extern global::System.IntPtr LoadImageFromFile__SWIG_1(string jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, int jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LoadImageFromFile__SWIG_2")]
  public static extern global::System.IntPtr LoadImageFromFile__SWIG_2(string jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LoadImageFromFile__SWIG_3")]
  public static extern global::System.IntPtr LoadImageFromFile__SWIG_3(string jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_LoadImageFromFile__SWIG_4")]
  public static extern global::System.IntPtr LoadImageFromFile__SWIG_4(string jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GetClosestImageSize__SWIG_0")]
  public static extern global::System.IntPtr GetClosestImageSize__SWIG_0(string jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, int jarg4, bool jarg5);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GetClosestImageSize__SWIG_1")]
  public static extern global::System.IntPtr GetClosestImageSize__SWIG_1(string jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, int jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GetClosestImageSize__SWIG_2")]
  public static extern global::System.IntPtr GetClosestImageSize__SWIG_2(string jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GetClosestImageSize__SWIG_3")]
  public static extern global::System.IntPtr GetClosestImageSize__SWIG_3(string jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GetClosestImageSize__SWIG_4")]
  public static extern global::System.IntPtr GetClosestImageSize__SWIG_4(string jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_DownloadImageSynchronously__SWIG_0")]
  public static extern global::System.IntPtr DownloadImageSynchronously__SWIG_0(string jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, int jarg4, bool jarg5);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_DownloadImageSynchronously__SWIG_1")]
  public static extern global::System.IntPtr DownloadImageSynchronously__SWIG_1(string jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3, int jarg4);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_DownloadImageSynchronously__SWIG_2")]
  public static extern global::System.IntPtr DownloadImageSynchronously__SWIG_2(string jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_DownloadImageSynchronously__SWIG_3")]
  public static extern global::System.IntPtr DownloadImageSynchronously__SWIG_3(string jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_DownloadImageSynchronously__SWIG_4")]
  public static extern global::System.IntPtr DownloadImageSynchronously__SWIG_4(string jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_SetMaxTextureSize")]
  public static extern void SetMaxTextureSize(uint jarg1);

  [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint="CSharp_Dali_GetMaxTextureSize")]
  public static extern uint GetMaxTextureSize();

    }
}

