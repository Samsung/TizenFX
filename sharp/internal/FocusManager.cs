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

namespace Dali {

using System;
using System.Runtime.InteropServices;

public class FocusManager : BaseHandle {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  private CustomAlgorithmInterfaceWrapper _customAlgorithmInterfaceWrapper;

  internal FocusManager(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicManualPINVOKE.FocusManager_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(FocusManager obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~FocusManager() {
    DisposeQueue.Instance.Add(this);
  }

  public override void Dispose() {
    if (!Window.IsInstalled()) {
      DisposeQueue.Instance.Add(this);
      return;
    }

    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          NDalicManualPINVOKE.delete_FocusManager(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }


/**
  * @brief Event arguments that passed via FocusChanged signal
  *
  */
public class FocusChangedEventArgs : EventArgs
{
   private View _viewCurrent;
   private View _viewNext;

   /**
     * @brief ViewCurrent - is the original focused View
     *
     */
   public View ViewCurrent
   {
      get
      {
         return _viewCurrent;
      }
      set
      {
        _viewCurrent = value;
      }
   }

   /**
     * @brief ViewNext - is the current focused View
     *
     */
   public View ViewNext
   {
      get
      {
         return _viewNext;
      }
      set
      {
        _viewNext = value;
      }
   }
}

/**
  * @brief Event arguments that passed via FocusGroupChanged signal
  *
  */
public class FocusGroupChangedEventArgs : EventArgs
{
   private View _currentFocusedView;
   private bool _forwardDirection;

   /**
     * @brief CurrentFocusedView - is the current focused View
     *
     */
   public View CurrentFocusedView
   {
      get
      {
         return _currentFocusedView;
      }
      set
      {
         _currentFocusedView = value;
      }
   }

   /**
     * @brief ForwardDirection - is the direction (forward or backward) in which to move the focus next
     *
     */
   public bool ForwardDirection
   {
      get
      {
         return _forwardDirection;
      }
      set
      {
         _forwardDirection = value;
      }
   }
}

/**
  * @brief Event arguments that passed via FocusedViewEnterKey signal
  *
  */
public class FocusedViewEnterKeyEventArgs : EventArgs
{
   private View _view;

   /**
     * @brief View - is the current focused View which has the enter key pressed on it.
     *
     */
   public View View
   {
      get
      {
         return _view;
      }
      set
      {
        _view = value;
      }
   }
}

/**
  * @brief Event arguments that passed via PreFocusChange signal
  *
  */
public class PreFocusChangeEventArgs : EventArgs
{
   private View _current;
   private View _proposed;
   private View.KeyboardFocus.Direction _direction;

   /**
    * @brief Current - is the current focused View.
    *
    */
   public View Current
   {
      get
      {
         return _current;
      }
      set
      {
          _current = value;
      }
   }

    /**
    * @brief Proposed - is the proposed focused View.
    *
    */
    public View Proposed
    {
        get
        {
            return _proposed;
        }
        set
        {
            _proposed = value;
        }
    }

    /**
    * @brief Direction - is the direction of Focus change.
    *
    */
    public View.KeyboardFocus.Direction Direction
    {
        get
        {
            return _direction;
        }
        set
        {
            _direction = value;
        }
    }
}

  [UnmanagedFunctionPointer(CallingConvention.StdCall)]
  public delegate void FocusChangedEventHandler(object source, FocusChangedEventArgs e);

  [UnmanagedFunctionPointer(CallingConvention.StdCall)]
  public delegate void FocusGroupChangedEventHandler(object source, FocusGroupChangedEventArgs e);

  [UnmanagedFunctionPointer(CallingConvention.StdCall)]
  public delegate void FocusedViewEnterKeyEventHandler(object source, FocusedViewEnterKeyEventArgs e);

  [UnmanagedFunctionPointer(CallingConvention.StdCall)]
  public delegate View PreFocusChangeEventHandler(object source, PreFocusChangeEventArgs e);

  [UnmanagedFunctionPointer(CallingConvention.StdCall)]
  public delegate IntPtr PreFocusChangeEventCallbackDelegate(IntPtr current, IntPtr proposed, View.KeyboardFocus.Direction direction);
  private PreFocusChangeEventHandler _FocusManagerPreFocusChangeEventHandler;
  private PreFocusChangeEventCallbackDelegate _FocusManagerPreFocusChangeEventCallbackDelegate;

  [UnmanagedFunctionPointer(CallingConvention.StdCall)]
  private delegate void FocusChangedEventCallbackDelegate(IntPtr actorCurrent, IntPtr actorNext);
  private FocusChangedEventHandler _FocusManagerFocusChangedEventHandler;
  private FocusChangedEventCallbackDelegate _FocusManagerFocusChangedEventCallbackDelegate;

  [UnmanagedFunctionPointer(CallingConvention.StdCall)]
  private delegate void FocusGroupChangedEventCallbackDelegate(IntPtr currentFocusedActor, bool forwardDirection);
  private FocusGroupChangedEventHandler _FocusManagerFocusGroupChangedEventHandler;
  private FocusGroupChangedEventCallbackDelegate _FocusManagerFocusGroupChangedEventCallbackDelegate;

  [UnmanagedFunctionPointer(CallingConvention.StdCall)]
  private delegate void FocusedViewEnterKeyEventCallbackDelegate(IntPtr actor);
  private FocusedViewEnterKeyEventHandler _FocusManagerFocusedViewEnterKeyEventHandler;
  private FocusedViewEnterKeyEventCallbackDelegate _FocusManagerFocusedViewEnterKeyEventCallbackDelegate;

  public event PreFocusChangeEventHandler PreFocusChange
  {
     add
     {
        lock(this)
        {
           // Restricted to only one listener
           if (_FocusManagerPreFocusChangeEventHandler == null)
           {
               _FocusManagerPreFocusChangeEventHandler += value;

               _FocusManagerPreFocusChangeEventCallbackDelegate = new PreFocusChangeEventCallbackDelegate(OnPreFocusChange);
              this.PreFocusChangeSignal().Connect(_FocusManagerPreFocusChangeEventCallbackDelegate);
           }
        }
     }

     remove
     {
        lock(this)
        {
           if (_FocusManagerPreFocusChangeEventHandler != null)
           {
              this.PreFocusChangeSignal().Disconnect(_FocusManagerPreFocusChangeEventCallbackDelegate);
           }

           _FocusManagerPreFocusChangeEventHandler -= value;
        }
     }
  }

  // Callback for FocusManager PreFocusChangeSignal
  private IntPtr OnPreFocusChange(IntPtr current, IntPtr proposed, View.KeyboardFocus.Direction direction)
  {
      View view = null;
      PreFocusChangeEventArgs e = new PreFocusChangeEventArgs();

      // Populate all members of "e" (PreFocusChangeEventArgs) with real data
      if (current != global::System.IntPtr.Zero)
      {
        e.Current = View.GetViewFromPtr(current);
      }

      if (proposed != global::System.IntPtr.Zero)
      {
        e.Proposed = View.GetViewFromPtr(proposed);
      }

      e.Direction = direction;

      if (_FocusManagerPreFocusChangeEventHandler != null)
      {
        //here we send all data to user event handlers
        view = _FocusManagerPreFocusChangeEventHandler(this, e);
      }

      if (view)
      {
        return view.GetPtrfromView();
      }
      else
      {
        return current;
      }
  }

  /**
    * @brief Event for FocusChanged signal which can be used to subscribe/unsubscribe the event handler
    * (in the type of FocusChangedEventHandler) provided by the user.
    * FocusChanged signal is emitted after the current focused view has been changed.
    */
  public event FocusChangedEventHandler FocusChanged
  {
     add
     {
        lock(this)
        {
           // Restricted to only one listener
           if (_FocusManagerFocusChangedEventHandler == null)
           {
              _FocusManagerFocusChangedEventHandler += value;

              _FocusManagerFocusChangedEventCallbackDelegate = new FocusChangedEventCallbackDelegate(OnFocusChanged);
              this.FocusChangedSignal().Connect(_FocusManagerFocusChangedEventCallbackDelegate);
           }
        }
     }

     remove
     {
        lock(this)
        {
           if (_FocusManagerFocusChangedEventHandler != null)
           {
              this.FocusChangedSignal().Disconnect(_FocusManagerFocusChangedEventCallbackDelegate);
           }

           _FocusManagerFocusChangedEventHandler -= value;
        }
     }
  }

  // Callback for FocusManager FocusChangedSignal
  private void OnFocusChanged(IntPtr viewCurrent, IntPtr viewNext)
  {
     FocusChangedEventArgs e = new FocusChangedEventArgs();

     // Populate all members of "e" (FocusChangedEventArgs) with real data
     e.ViewCurrent = View.GetViewFromPtr(viewCurrent);
     e.ViewNext = View.GetViewFromPtr(viewNext);

     if (_FocusManagerFocusChangedEventHandler != null)
     {
        //here we send all data to user event handlers
        _FocusManagerFocusChangedEventHandler(this, e);
     }
  }

  /**
    * @brief Event for FocusGroupChanged signal which can be used to subscribe/unsubscribe the event handler
    * (in the type of FocusGroupChangedEventHandler) provided by the user.
    * FocusGroupChanged signal is emitted when the focus group has been changed.
    */
  public event FocusGroupChangedEventHandler FocusGroupChanged
  {
     add
     {
        lock(this)
        {
           // Restricted to only one listener
           if (_FocusManagerFocusGroupChangedEventHandler == null)
           {
              _FocusManagerFocusGroupChangedEventHandler += value;

              _FocusManagerFocusGroupChangedEventCallbackDelegate = new FocusGroupChangedEventCallbackDelegate(OnFocusGroupChanged);
              this.FocusGroupChangedSignal().Connect(_FocusManagerFocusGroupChangedEventCallbackDelegate);
           }
        }
     }

     remove
     {
        lock(this)
        {
           if (_FocusManagerFocusGroupChangedEventHandler != null)
           {
              this.FocusGroupChangedSignal().Disconnect(_FocusManagerFocusGroupChangedEventCallbackDelegate);
           }

           _FocusManagerFocusGroupChangedEventHandler -= value;
        }
     }
  }

  // Callback for FocusManager FocusGroupChangedSignal
  private void OnFocusGroupChanged(IntPtr currentFocusedView, bool forwardDirection)
  {
     FocusGroupChangedEventArgs e = new FocusGroupChangedEventArgs();

     // Populate all members of "e" (FocusGroupChangedEventArgs) with real data
     e.CurrentFocusedView = View.GetViewFromPtr(currentFocusedView);
     e.ForwardDirection = forwardDirection;

     if (_FocusManagerFocusGroupChangedEventHandler != null)
     {
        //here we send all data to user event handlers
        _FocusManagerFocusGroupChangedEventHandler(this, e);
     }
  }

  /**
    * @brief Event for FocusedViewEnterKeyPressed signal which can be used to subscribe/unsubscribe the event handler
    * (in the type of FocusedViewEnterKeyEventHandler) provided by the user.
    * FocusedViewEnterKeyPressed signal is emitted when the current focused view has the enter key pressed on it.
    */
  public event FocusedViewEnterKeyEventHandler FocusedViewEnterKeyPressed
  {
     add
     {
        lock(this)
        {
           // Restricted to only one listener
           if (_FocusManagerFocusedViewEnterKeyEventHandler == null)
           {
              _FocusManagerFocusedViewEnterKeyEventHandler += value;

              _FocusManagerFocusedViewEnterKeyEventCallbackDelegate = new FocusedViewEnterKeyEventCallbackDelegate(OnFocusedViewEnterKey);
              this.FocusedViewEnterKeySignal().Connect(_FocusManagerFocusedViewEnterKeyEventCallbackDelegate);
           }
        }
     }

     remove
     {
        lock(this)
        {
           if (_FocusManagerFocusedViewEnterKeyEventHandler != null)
           {
              this.FocusedViewEnterKeySignal().Disconnect(_FocusManagerFocusedViewEnterKeyEventCallbackDelegate);
           }

           _FocusManagerFocusedViewEnterKeyEventHandler -= value;
        }
     }
  }

  // Callback for FocusManager FocusedViewEnterKeySignal
  private void OnFocusedViewEnterKey(IntPtr view)
  {
     FocusedViewEnterKeyEventArgs e = new FocusedViewEnterKeyEventArgs();

     // Populate all members of "e" (FocusedViewEnterKeyEventArgs) with real data
     e.View = View.GetViewFromPtr(view);

     if (_FocusManagerFocusedViewEnterKeyEventHandler != null)
     {
        //here we send all data to user event handlers
        _FocusManagerFocusedViewEnterKeyEventHandler(this, e);
     }
  }

  public FocusManager() : this(NDalicManualPINVOKE.new_FocusManager(), true) {
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public static FocusManager Get() {
    FocusManager ret = new FocusManager(NDalicManualPINVOKE.FocusManager_Get(), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool SetCurrentFocusView(View view) {
    bool ret = NDalicManualPINVOKE.FocusManager_SetCurrentFocusActor(swigCPtr, View.getCPtr(view));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public View GetCurrentFocusView() {
    View ret = new View(NDalicManualPINVOKE.FocusManager_GetCurrentFocusActor(swigCPtr), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool MoveFocus(View.KeyboardFocus.Direction direction) {
    bool ret = NDalicManualPINVOKE.FocusManager_MoveFocus(swigCPtr, (int)direction);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void ClearFocus() {
    NDalicManualPINVOKE.FocusManager_ClearFocus(swigCPtr);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public void SetFocusGroupLoop(bool enabled) {
    NDalicManualPINVOKE.FocusManager_SetFocusGroupLoop(swigCPtr, enabled);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public bool GetFocusGroupLoop() {
    bool ret = NDalicManualPINVOKE.FocusManager_GetFocusGroupLoop(swigCPtr);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void SetAsFocusGroup(View view, bool isFocusGroup) {
    NDalicManualPINVOKE.FocusManager_SetAsFocusGroup(swigCPtr, View.getCPtr(view), isFocusGroup);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public bool IsFocusGroup(View view) {
    bool ret = NDalicManualPINVOKE.FocusManager_IsFocusGroup(swigCPtr, View.getCPtr(view));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public View GetFocusGroup(View view) {
    View ret = new View(NDalicManualPINVOKE.FocusManager_GetFocusGroup(swigCPtr, View.getCPtr(view)), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void SetFocusIndicatorView(View indicator) {
    NDalicManualPINVOKE.FocusManager_SetFocusIndicatorActor(swigCPtr, View.getCPtr(indicator));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public View GetFocusIndicatorView() {
    View ret = new View(NDalicManualPINVOKE.FocusManager_GetFocusIndicatorActor(swigCPtr), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void SetCustomAlgorithm(ICustomFocusAlgorithm arg0) {
    _customAlgorithmInterfaceWrapper = new CustomAlgorithmInterfaceWrapper();
    _customAlgorithmInterfaceWrapper.SetFocusAlgorithm(arg0);

    NDalicPINVOKE.SetCustomAlgorithm(swigCPtr, CustomAlgorithmInterface.getCPtr(_customAlgorithmInterfaceWrapper));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public PreFocusChangeSignal PreFocusChangeSignal() {
    PreFocusChangeSignal ret = new PreFocusChangeSignal(NDalicManualPINVOKE.FocusManager_PreFocusChangeSignal(swigCPtr), false);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public FocusChangedSignal FocusChangedSignal() {
    FocusChangedSignal ret = new FocusChangedSignal(NDalicManualPINVOKE.FocusManager_FocusChangedSignal(swigCPtr), false);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public FocusGroupChangedSignal FocusGroupChangedSignal() {
    FocusGroupChangedSignal ret = new FocusGroupChangedSignal(NDalicManualPINVOKE.FocusManager_FocusGroupChangedSignal(swigCPtr), false);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public ViewSignal FocusedViewEnterKeySignal() {
    ViewSignal ret = new ViewSignal(NDalicManualPINVOKE.FocusManager_FocusedActorEnterKeySignal(swigCPtr), false);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  private static readonly FocusManager instance = FocusManager.Get();

  public static FocusManager Instance
  {
      get
      {
          return instance;
      }
  }

  public interface ICustomFocusAlgorithm
  {
      View GetNextFocusableView(View current, View proposed, View.KeyboardFocus.Direction direction);
  }

  private class CustomAlgorithmInterfaceWrapper : CustomAlgorithmInterface
  {
      private FocusManager.ICustomFocusAlgorithm _customFocusAlgorithm;

      public CustomAlgorithmInterfaceWrapper()
      {
      }

      public void SetFocusAlgorithm(FocusManager.ICustomFocusAlgorithm customFocusAlgorithm)
      {
          _customFocusAlgorithm = customFocusAlgorithm;
      }

      public override View GetNextFocusableView(View current, View proposed, View.KeyboardFocus.Direction direction)
      {
          View currentView = View.DownCast<View>(current);
          View proposedView = View.DownCast<View>(proposed);
          return _customFocusAlgorithm.GetNextFocusableView(currentView, proposedView, direction);
      }
  }
}

}
