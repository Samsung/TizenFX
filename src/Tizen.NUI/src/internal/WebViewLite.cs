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

using System;
using System.Runtime.InteropServices;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI {

/// <summary>
/// WebViewLite.
/// </summary>
internal class WebViewLite : View
{
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal WebViewLite(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.WebViewLite_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(WebViewLite obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  /// <summary>
  /// To make Button instance be disposed.
  /// </summary>
  protected override void Dispose(DisposeTypes type)
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

      DisConnectFromSignals();

      if (swigCPtr.Handle != global::System.IntPtr.Zero)
      {
          if (swigCMemOwn)
          {
              swigCMemOwn = false;
              NDalicPINVOKE.delete_WebViewLite(swigCPtr);
          }
          swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }

      base.Dispose(type);
  }

  private void DisConnectFromSignals()
  {
      // Save current CPtr.
      global::System.Runtime.InteropServices.HandleRef currentCPtr = swigCPtr;

      // Use BaseHandle CPtr as current might have been deleted already in derived classes.
      swigCPtr = GetBaseHandleCPtrHandleRef;

      if (_loadingFinishedEventCallback != null)
      {
          FinishedSignal().Disconnect(_loadingFinishedEventCallback);
      }

      // BaseHandle CPtr is used in Registry and there is danger of deletion if we keep using it here.
      // Restore current CPtr.
      swigCPtr = currentCPtr;
  }

  private LoadingFinishedCallbackType _loadingFinishedEventCallback;
  [UnmanagedFunctionPointer(CallingConvention.StdCall)]
  private delegate void LoadingFinishedCallbackType(global::System.IntPtr data);
  private EventHandler _loadingFinishedEventHandler;

  /// <summary>
  /// Web View loading finished event.
  /// </summary>
  public event EventHandler LoadingFinished
  {
      add
      {
          if (_loadingFinishedEventHandler == null)
          {
              NUILog.Debug("[add before]FinishedSignal().Empty=" + FinishedSignal().Empty() + " GetConnectionCount=" + FinishedSignal().GetConnectionCount());
              _loadingFinishedEventCallback = OnFinished;
              FinishedSignal().Connect(_loadingFinishedEventCallback);
              NUILog.Debug("[add after]FinishedSignal().Empty=" + FinishedSignal().Empty() + " GetConnectionCount=" + FinishedSignal().GetConnectionCount());
          }
          _loadingFinishedEventHandler += value;
      }
      remove
      {
          _loadingFinishedEventHandler -= value;

          if (_loadingFinishedEventHandler == null && FinishedSignal().Empty() == false)
          {
              NUILog.Debug("[remove before]FinishedSignal().Empty=" + FinishedSignal().Empty() + " GetConnectionCount=" + FinishedSignal().GetConnectionCount());
              FinishedSignal().Disconnect(_loadingFinishedEventCallback);
              NUILog.Debug("[remove after]FinishedSignal().Empty=" + FinishedSignal().Empty() + " GetConnectionCount=" + FinishedSignal().GetConnectionCount());
          }
      }
  }
  private void OnFinished(IntPtr data)
  {
      if (_loadingFinishedEventHandler != null)
      {
          //here we send all data to user event handlers
          _loadingFinishedEventHandler(this, null);
      }
  }

  /// <summary>
  /// Creates an uninitialized WebViewLite.
  /// </summary>
  public WebViewLite () : this (NDalicPINVOKE.WebViewLite_New(), true) {
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

  }

  /// <summary>
  /// Copy constructor.
  /// <param name="webViewLite">WebViewLite to copy. The copied WebViewLite will point at the same implementation</param>
  /// </summary>
  public WebViewLite(WebViewLite webViewLite) : this(NDalicPINVOKE.new_WebViewLite__SWIG_1(WebViewLite.getCPtr(webViewLite)), true) {
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  internal WebViewLite Assign(WebViewLite webViewLite) {
    WebViewLite ret = new WebViewLite(NDalicPINVOKE.WebViewLite_Assign(swigCPtr, WebViewLite.getCPtr(webViewLite)), false);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  internal static WebViewLite DownCast(BaseHandle handle) {
    WebViewLite ret = new WebViewLite(NDalicPINVOKE.WebViewLite_DownCast(BaseHandle.getCPtr(handle)), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  /// <summary>
  /// Creates an internal web view instance (e.g. minimized web engine instance).
  /// <param name="width">The width of Web</param>
  /// <param name="height">The height of Web</param>
  /// <param name="windowX">The x position of window</param>
  /// <param name="windowY">The y position of window</param>
  /// <param name="locale">The locale of Web</param>
  /// <param name="timezoneID">The timezoneID of Web</param>
  /// </summary>
  public void CreateInstance(int width, int height, int windowX, int windowY, string locale, string timezoneID) {
    NDalicPINVOKE.WebViewLite_CreateInstance(swigCPtr, width, height, windowX, windowY, locale, timezoneID);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  /// <summary>
  /// Destroys an internal web view instance (e.g. minimized web engine instance).
  /// </summary>
  public void DestroyInstance() {
    NDalicPINVOKE.WebViewLite_DestroyInstance(swigCPtr);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  /// <summary>
  /// Loads a html file.
  /// <param name="path">The path of Web</param>
  /// </summary>
  public void LoadHtml(string path) {
    NDalicPINVOKE.WebViewLite_LoadHtml(swigCPtr, path);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  internal WebViewLiteSignal FinishedSignal() {
    WebViewLiteSignal ret = new WebViewLiteSignal(NDalicPINVOKE.WebViewLite_FinishedSignal(swigCPtr), false);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

}

}
