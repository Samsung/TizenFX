/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd.
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

/// <summary>
/// WebViewLiteSignal.
/// </summary>
internal class WebViewLiteSignal : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  /// <summary>
  /// swigCMemOwn.
  /// </summary>
  protected bool swigCMemOwn;

  internal WebViewLiteSignal(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(WebViewLiteSignal obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  //A Flag to check who called Dispose(). (By User or DisposeQueue)
  private bool isDisposeQueued = false;

  /// <summary>
  /// A Flat to check if it is already disposed.
  /// </summary>
  protected bool disposed = false;

  /// <summary>
  /// Distructor.
  /// </summary>
  ~WebViewLiteSignal()
  {
      if (!isDisposeQueued)
      {
          isDisposeQueued = true;
          DisposeQueue.Instance.Add(this);
      }
  }

  /// <summary>
  /// Dispose.
  /// </summary>
  public void Dispose()
  {
      //Throw excpetion if Dispose() is called in separate thread.
      if (!Window.IsInstalled())
      {
          throw new System.InvalidOperationException("This API called from separate thread. This API must be called from MainThread.");
      }

      if (isDisposeQueued)
      {
          Dispose(DisposeTypes.Implicit);
      }
      else
      {
          Dispose(DisposeTypes.Explicit);
          System.GC.SuppressFinalize(this);
      }
  }

  /// <summary>
  /// you can override it to clean-up your own resources.
  /// </summary>
  /// <param name="type">DisposeTypes</param>
  /// <since_tizen> 3 </since_tizen>
  protected virtual void Dispose(DisposeTypes type)
  {
      if (disposed)
      {
          return;
      }

      if (type == DisposeTypes.Explicit)
      {
          //Called by User
          //Release your own managed resources here.
          //You should release all of your own disposable objects here.

      }

      //Release your own unmanaged resources here.
      //You should not access any managed member here except static instance.
      //because the execution order of Finalizes is non-deterministic.

      if (swigCPtr.Handle != global::System.IntPtr.Zero)
      {
          if (swigCMemOwn)
          {
              swigCMemOwn = false;
              NDalicPINVOKE.delete_WebViewLiteSignal(swigCPtr);
          }
          swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }

      disposed = true;
  }


  /// <summary>
  /// Empty 
  /// </summary>
  /// <returns>true if there is no signal attached</returns>
  public bool Empty() {
    bool ret = NDalicPINVOKE.WebViewLiteSignal_Empty(swigCPtr);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  /// <summary>
  /// GetConnectionCount
  /// </summary>
  /// <returns>number of attached signals</returns>
  public uint GetConnectionCount() {
    uint ret = NDalicPINVOKE.WebViewLiteSignal_GetConnectionCount(swigCPtr);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  /// <summary>
  /// signal connect
  /// </summary>
  /// <param name="func"></param>
  public void Connect(System.Delegate func) {
System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(func);
    {
      NDalicPINVOKE.WebViewLiteSignal_Connect(swigCPtr, new System.Runtime.InteropServices.HandleRef(this, ip));
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    }
  }

  /// <summary>
  /// signal disconnect
  /// </summary>
  /// <param name="func"></param>
  public void Disconnect(System.Delegate func) {
System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(func);
    {
      NDalicPINVOKE.WebViewLiteSignal_Disconnect(swigCPtr, new System.Runtime.InteropServices.HandleRef(this, ip));
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    }
  }

  /// <summary>
  /// Emit
  /// </summary>
  public void Emit(WebViewLite arg) {
    NDalicPINVOKE.WebViewLiteSignal_Emit(swigCPtr, WebViewLite.getCPtr(arg));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  /// <summary>
  /// WebViewLiteSignal
  /// </summary>
  public WebViewLiteSignal() : this(NDalicPINVOKE.new_WebViewLiteSignal(), true) {
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

}

}
