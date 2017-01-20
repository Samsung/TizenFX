/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd.
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

namespace NUI {

using System;
using System.Runtime.InteropServices;

public class FocusManager : BaseHandle {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

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
    if (!Stage.IsInstalled()) {
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
    * @brief Event arguments that passed via PreFocusChange signal
    *
    */
  public class PreFocusChangeEventArgs : EventArgs
  {
     private View current;
     private View proposed;
     private View.KeyboardFocus.Direction direction;

     public View Current
     {
        get
        {
           return current;
        }
        set
        {
            current = value;
        }
     }

      public View Proposed
      {
          get
          {
              return proposed;
          }
          set
          {
              proposed = value;
          }
      }

      public View.KeyboardFocus.Direction Direction
      {
          get
          {
              return direction;
          }
          set
          {
              direction = value;
          }
      }
  }

  [UnmanagedFunctionPointer(CallingConvention.StdCall)]
  public delegate View PreFocusChangeEventHandler(object source, PreFocusChangeEventArgs e);
  internal PreFocusChangeEventHandler FocusManagerPreFocusChangeEventHandler;
  [UnmanagedFunctionPointer(CallingConvention.StdCall)]
  internal delegate IntPtr PreFocusChangeEventCallback(IntPtr current, IntPtr proposed, View.KeyboardFocus.Direction direction);
  internal PreFocusChangeEventCallback FocusManagerPreFocusChangeEventCallback;

  public event PreFocusChangeEventHandler PreFocusChange
  {
    add
    {
      FocusManagerPreFocusChangeEventHandler += value;
      FocusManagerPreFocusChangeEventCallback = OnPreFocusChange;
      this.PreFocusChangeSignal().Connect(FocusManagerPreFocusChangeEventCallback);
    }

    remove
    {
      if (FocusManagerPreFocusChangeEventHandler != null)
      {
        this.PreFocusChangeSignal().Disconnect(FocusManagerPreFocusChangeEventCallback);
      }
      FocusManagerPreFocusChangeEventHandler -= value;
    }
  }

  private IntPtr OnPreFocusChange(IntPtr current, IntPtr proposed, View.KeyboardFocus.Direction direction)
  {
    View view = null;
    PreFocusChangeEventArgs e = new PreFocusChangeEventArgs();

    e.Current = View.DownCast(Actor.GetActorFromPtr(current));
    e.Proposed = View.DownCast(Actor.GetActorFromPtr(proposed));
    e.Direction = direction;

    if (FocusManagerPreFocusChangeEventHandler != null)
    {
      view = FocusManagerPreFocusChangeEventHandler(this, e);
    }
    return view.GetPtrfromView();
  }




/**
  * @brief Event arguments that passed via FocusChanged signal
  *
  */
public class FocusChangedEventArgs : EventArgs
{
   private View viewCurrent;
   private View viewNext;

   public View ViewCurrent
   {
      get
      {
         return viewCurrent;
      }
      set
      {
         viewCurrent = value;
      }
   }

   public View ViewNext
   {
      get
      {
         return viewNext;
      }
      set
      {
         viewNext = value;
      }
   }
}

  [UnmanagedFunctionPointer(CallingConvention.StdCall)]
  public delegate void FocusChangedEventHandler(object source, FocusChangedEventArgs e);
  private FocusChangedEventHandler FocusManagerFocusChangedEventHandler;
  [UnmanagedFunctionPointer(CallingConvention.StdCall)]
  private delegate void FocusChangedEventCallback(IntPtr viewCurrent, IntPtr viewNext);
  private FocusChangedEventCallback FocusManagerFocusChangedEventCallback;

  public event FocusChangedEventHandler FocusChanged
  {
     add
     {
        FocusManagerFocusChangedEventHandler += value;
        FocusManagerFocusChangedEventCallback = OnFocusChanged;
        this.FocusChangedSignal().Connect(FocusManagerFocusChangedEventCallback);
     }

     remove
     {
       if (FocusManagerFocusChangedEventHandler != null)
       {
          this.FocusChangedSignal().Disconnect(FocusManagerFocusChangedEventCallback);
       }
       FocusManagerFocusChangedEventHandler -= value;
     }
  }

  private void OnFocusChanged(IntPtr viewCurrent, IntPtr viewNext)
  {
     FocusChangedEventArgs e = new FocusChangedEventArgs();

     e.ViewCurrent = View.DownCast(Actor.GetActorFromPtr(viewCurrent));
     e.ViewNext = View.DownCast(Actor.GetActorFromPtr(viewNext));

     if (FocusManagerFocusChangedEventHandler != null)
     {
        FocusManagerFocusChangedEventHandler(this, e);
     }
  }


/**
  * @brief Event arguments that passed via FocusGroupChanged signal
  *
  */
public class FocusGroupChangedEventArgs : EventArgs
{
   private View currentFocusedView;
   private bool forwardDirection;

   public View CurrentFocusedView
   {
      get
      {
         return currentFocusedView;
      }
      set
      {
         currentFocusedView = value;
      }
   }

   public bool ForwardDirection
   {
      get
      {
         return forwardDirection;
      }
      set
      {
         forwardDirection = value;
      }
   }
}

  [UnmanagedFunctionPointer(CallingConvention.StdCall)]
  public delegate void FocusGroupChangedEventHandler(object source, FocusGroupChangedEventArgs e);
  private FocusGroupChangedEventHandler FocusManagerFocusGroupChangedEventHandler;
  [UnmanagedFunctionPointer(CallingConvention.StdCall)]
  private delegate void FocusGroupChangedEventCallback(IntPtr currentFocusedView, bool forwardDirection);
  private FocusGroupChangedEventCallback FocusManagerFocusGroupChangedEventCallback;

  public event FocusGroupChangedEventHandler FocusGroupChanged
  {
     add
     {
        FocusManagerFocusGroupChangedEventHandler += value;
        FocusManagerFocusGroupChangedEventCallback = OnFocusGroupChanged;
        this.FocusGroupChangedSignal().Connect(FocusManagerFocusGroupChangedEventCallback);
     }

     remove
     {
       if (FocusManagerFocusGroupChangedEventHandler != null)
       {
          this.FocusGroupChangedSignal().Disconnect(FocusManagerFocusGroupChangedEventCallback);
       }
       FocusManagerFocusGroupChangedEventHandler -= value;
     }
  }

  private void OnFocusGroupChanged(IntPtr currentFocusedView, bool forwardDirection)
  {
     FocusGroupChangedEventArgs e = new FocusGroupChangedEventArgs();

     e.CurrentFocusedView = View.DownCast(Actor.GetActorFromPtr(currentFocusedView));
     e.ForwardDirection = forwardDirection;

     if (FocusManagerFocusGroupChangedEventHandler != null)
     {
        FocusManagerFocusGroupChangedEventHandler(this, e);
     }
  }


/**
  * @brief Event arguments that passed via FocusedActorEnterKey signal
  *
  */
public class FocusedViewEnterKeyEventArgs : EventArgs
{
   private View view;

   public View View
   {
      get
      {
         return view;
      }
      set
      {
         view = value;
      }
   }
}


  [UnmanagedFunctionPointer(CallingConvention.StdCall)]
  public delegate void FocusedViewEnterKeyEventHandler(object source, FocusedViewEnterKeyEventArgs e);
  private FocusedViewEnterKeyEventHandler FocusManagerFocusedViewEnterKeyEventHandler;
  [UnmanagedFunctionPointer(CallingConvention.StdCall)]
  private delegate void FocusedViewEnterKeyEventCallback(IntPtr view);
  private FocusedViewEnterKeyEventCallback FocusManagerFocusedViewEnterKeyEventCallback;

  public event FocusedViewEnterKeyEventHandler FocusedViewEnterKeyPressed
  {
     add
     {
        FocusManagerFocusedViewEnterKeyEventHandler += value;
        FocusManagerFocusedViewEnterKeyEventCallback = OnFocusedViewEnterKey;
        this.FocusedActorEnterKeySignal().Connect(FocusManagerFocusedViewEnterKeyEventCallback);
     }

     remove
     {
       if (FocusManagerFocusedViewEnterKeyEventHandler != null)
       {
          this.FocusedActorEnterKeySignal().Disconnect(FocusManagerFocusedViewEnterKeyEventCallback);
       }
       FocusManagerFocusedViewEnterKeyEventHandler -= value;
     }
  }

  private void OnFocusedViewEnterKey(IntPtr view)
  {
     FocusedViewEnterKeyEventArgs e = new FocusedViewEnterKeyEventArgs();

     e.View = View.DownCast(Actor.GetActorFromPtr(view));

     if (FocusManagerFocusedViewEnterKeyEventHandler != null)
     {
        FocusManagerFocusedViewEnterKeyEventHandler(this, e);
     }
  }


  internal FocusManager() : this(NDalicManualPINVOKE.new_FocusManager(), true) {
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  internal static FocusManager Get() {
    FocusManager ret = new FocusManager(NDalicManualPINVOKE.FocusManager_Get(), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool SetCurrentFocusView(View view) {
    Actor actor = (NUI.Actor)view;
    bool ret = NDalicManualPINVOKE.FocusManager_SetCurrentFocusActor(swigCPtr, Actor.getCPtr(actor));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public View GetCurrentFocusView() {
    Actor ret = new Actor(NDalicManualPINVOKE.FocusManager_GetCurrentFocusActor(swigCPtr), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return View.DownCast(ret);
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
    Actor actor = (NUI.Actor)view;
    NDalicManualPINVOKE.FocusManager_SetAsFocusGroup(swigCPtr, Actor.getCPtr(actor), isFocusGroup);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public bool IsFocusGroup(View view) {
    Actor actor = (NUI.Actor)view;
    bool ret = NDalicManualPINVOKE.FocusManager_IsFocusGroup(swigCPtr, Actor.getCPtr(actor));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public View GetFocusGroup(View view) {
    Actor actor = (NUI.Actor)view;
    Actor ret = new Actor(NDalicManualPINVOKE.FocusManager_GetFocusGroup(swigCPtr, Actor.getCPtr(actor)), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return View.DownCast(ret);
  }

  public void SetFocusIndicatorView(View indicator) {
    Actor actor = (NUI.Actor)indicator;
    NDalicManualPINVOKE.FocusManager_SetFocusIndicatorActor(swigCPtr, Actor.getCPtr(actor));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public View GetFocusIndicatorView() {
    Actor ret = new Actor(NDalicManualPINVOKE.FocusManager_GetFocusIndicatorActor(swigCPtr), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return View.DownCast(ret);
  }

  internal PreFocusChangeSignal PreFocusChangeSignal() {
    PreFocusChangeSignal ret = new PreFocusChangeSignal(NDalicManualPINVOKE.FocusManager_PreFocusChangeSignal(swigCPtr), false);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  internal FocusChangedSignal FocusChangedSignal() {
    FocusChangedSignal ret = new FocusChangedSignal(NDalicManualPINVOKE.FocusManager_FocusChangedSignal(swigCPtr), false);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  internal FocusGroupChangedSignal FocusGroupChangedSignal() {
    FocusGroupChangedSignal ret = new FocusGroupChangedSignal(NDalicManualPINVOKE.FocusManager_FocusGroupChangedSignal(swigCPtr), false);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  internal ActorSignal FocusedActorEnterKeySignal() {
    ActorSignal ret = new ActorSignal(NDalicManualPINVOKE.FocusManager_FocusedActorEnterKeySignal(swigCPtr), false);
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


}

}
