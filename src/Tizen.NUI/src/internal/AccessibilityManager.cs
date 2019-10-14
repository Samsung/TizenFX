/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    internal partial class AccessibilityManager : BaseHandle
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal AccessibilityManager(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.AccessibilityManage.AccessibilityManager_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(AccessibilityManager obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    Interop.AccessibilityManage.delete_AccessibilityManager(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        // Callback for AccessibilityManager StatusChangedSignal
        private bool OnStatusChanged(IntPtr data)
        {
            StatusChangedEventArgs e = new StatusChangedEventArgs();

            // Populate all members of "e" (StatusChangedEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerStatusChangedEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerStatusChangedEventHandler(this, e);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionNextSignal
        private bool OnActionNext(IntPtr data)
        {
            ActionNextEventArgs e = new ActionNextEventArgs();

            // Populate all members of "e" (ActionNextEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionNextEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionNextEventHandler(this, e);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionPreviousSignal
        private bool OnActionPrevious(IntPtr data)
        {
            ActionPreviousEventArgs e = new ActionPreviousEventArgs();

            // Populate all members of "e" (ActionPreviousEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionPreviousEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionPreviousEventHandler(this, e);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionActivateSignal
        private bool OnActionActivate(IntPtr data)
        {
            ActionActivateEventArgs e = new ActionActivateEventArgs();

            // Populate all members of "e" (ActionActivateEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionActivateEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionActivateEventHandler(this, e);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionReadSignal
        private bool OnActionRead(IntPtr data)
        {
            ActionReadEventArgs e = new ActionReadEventArgs();

            // Populate all members of "e" (ActionReadEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionReadEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionReadEventHandler(this, e);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionOverSignal
        private bool OnActionOver(IntPtr data)
        {
            ActionOverEventArgs e = new ActionOverEventArgs();

            // Populate all members of "e" (ActionOverEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionOverEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionOverEventHandler(this, e);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionReadNextSignal
        private bool OnActionReadNext(IntPtr data)
        {
            ActionReadNextEventArgs e = new ActionReadNextEventArgs();

            // Populate all members of "e" (ActionReadNextEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionReadNextEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionReadNextEventHandler(this, e);
            }
            return false;
        }


        // Callback for AccessibilityManager ActionReadPreviousSignal
        private bool OnActionReadPrevious(IntPtr data)
        {
            ActionReadPreviousEventArgs e = new ActionReadPreviousEventArgs();

            // Populate all members of "e" (ActionReadPreviousEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionReadPreviousEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionReadPreviousEventHandler(this, e);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionUpSignal
        private bool OnActionUp(IntPtr data)
        {
            ActionUpEventArgs e = new ActionUpEventArgs();

            // Populate all members of "e" (ActionUpEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionUpEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionUpEventHandler(this, e);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionDownSignal
        private bool OnActionDown(IntPtr data)
        {
            ActionDownEventArgs e = new ActionDownEventArgs();

            // Populate all members of "e" (ActionDownEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionDownEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionDownEventHandler(this, e);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionClearFocusSignal
        private bool OnActionClearFocus(IntPtr data)
        {
            ActionClearFocusEventArgs e = new ActionClearFocusEventArgs();

            // Populate all members of "e" (ActionClearFocusEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionClearFocusEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionClearFocusEventHandler(this, e);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionBackSignal
        private bool OnActionBack(IntPtr data)
        {
            ActionBackEventArgs e = new ActionBackEventArgs();

            // Populate all members of "e" (ActionBackEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionBackEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionBackEventHandler(this, e);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionScrollUpSignal
        private bool OnActionScrollUp(IntPtr data)
        {
            ActionScrollUpEventArgs e = new ActionScrollUpEventArgs();

            // Populate all members of "e" (ActionScrollUpEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionScrollUpEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionScrollUpEventHandler(this, e);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionScrollDownSignal
        private bool OnActionScrollDown(IntPtr data)
        {
            ActionScrollDownEventArgs e = new ActionScrollDownEventArgs();

            // Populate all members of "e" (ActionScrollDownEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionScrollDownEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionScrollDownEventHandler(this, e);
            }
            return false;
        }


        // Callback for AccessibilityManager ActionPageLeftSignal
        private bool OnActionPageLeft(IntPtr data)
        {
            ActionPageLeftEventArgs e = new ActionPageLeftEventArgs();

            // Populate all members of "e" (ActionPageLeftEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionPageLeftEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionPageLeftEventHandler(this, e);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionPageRightSignal
        private bool OnActionPageRight(IntPtr data)
        {
            ActionPageRightEventArgs e = new ActionPageRightEventArgs();

            // Populate all members of "e" (ActionPageRightEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionPageRightEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionPageRightEventHandler(this, e);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionPageUpSignal
        private bool OnActionPageUp(IntPtr data)
        {
            ActionPageUpEventArgs e = new ActionPageUpEventArgs();

            // Populate all members of "e" (ActionPageUpEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionPageUpEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionPageUpEventHandler(this, e);
            }
            return false;
        }


        // Callback for AccessibilityManager ActionPageDownSignal
        private bool OnActionPageDown(IntPtr data)
        {
            ActionPageDownEventArgs e = new ActionPageDownEventArgs();

            // Populate all members of "e" (ActionPageDownEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionPageDownEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionPageDownEventHandler(this, e);
            }
            return false;
        }


        // Callback for AccessibilityManager ActionMoveToFirstSignal
        private bool OnActionMoveToFirst(IntPtr data)
        {
            ActionMoveToFirstEventArgs e = new ActionMoveToFirstEventArgs();

            // Populate all members of "e" (ActionMoveToFirstEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionMoveToFirstEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionMoveToFirstEventHandler(this, e);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionMoveToLastSignal
        private bool OnActionMoveToLast(IntPtr data)
        {
            ActionMoveToLastEventArgs e = new ActionMoveToLastEventArgs();

            // Populate all members of "e" (ActionMoveToLastEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionMoveToLastEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionMoveToLastEventHandler(this, e);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionReadFromTopSignal
        private bool OnActionReadFromTop(IntPtr data)
        {
            ActionReadFromTopEventArgs e = new ActionReadFromTopEventArgs();

            // Populate all members of "e" (ActionReadFromTopEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionReadFromTopEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionReadFromTopEventHandler(this, e);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionReadFromNextSignal
        private bool OnActionReadFromNext(IntPtr data)
        {
            ActionReadFromNextEventArgs e = new ActionReadFromNextEventArgs();

            // Populate all members of "e" (ActionReadFromNextEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionReadFromNextEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionReadFromNextEventHandler(this, e);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionZoomSignal
        private bool OnActionZoom(IntPtr data)
        {
            ActionZoomEventArgs e = new ActionZoomEventArgs();

            // Populate all members of "e" (ActionZoomEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionZoomEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionZoomEventHandler(this, e);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionReadIndicatorInformationSignal
        private bool OnActionReadIndicatorInformation(IntPtr data)
        {
            ActionReadIndicatorInformationEventArgs e = new ActionReadIndicatorInformationEventArgs();

            // Populate all members of "e" (ActionReadIndicatorInformationEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionReadIndicatorInformationEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionReadIndicatorInformationEventHandler(this, e);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionReadPauseResumeSignal
        private bool OnActionReadPauseResume(IntPtr data)
        {
            ActionReadPauseResumeEventArgs e = new ActionReadPauseResumeEventArgs();

            // Populate all members of "e" (ActionReadPauseResumeEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionReadPauseResumeEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionReadPauseResumeEventHandler(this, e);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionStartStopSignal
        private bool OnActionStartStop(IntPtr data)
        {
            ActionStartStopEventArgs e = new ActionStartStopEventArgs();

            // Populate all members of "e" (ActionStartStopEventArgs) with real data
            e.AccessibilityManager = AccessibilityManager.GetAccessibilityManagerFromPtr(data);

            if (_accessibilityManagerActionStartStopEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionStartStopEventHandler(this, e);
            }
            return false;
        }

        // Callback for AccessibilityManager FocusChangedSignal
        private void OnFocusChanged(IntPtr view1, IntPtr view2)
        {
            FocusChangedEventArgs e = new FocusChangedEventArgs();

            // Populate all members of "e" (FocusChangedEventArgs) with real data
            e.ViewCurrent = Registry.GetManagedBaseHandleFromNativePtr(view1) as View;
            e.ViewNext = Registry.GetManagedBaseHandleFromNativePtr(view2) as View;

            if (_accessibilityManagerFocusChangedEventHandler != null)
            {
                //here we send all data to user event handlers
                _accessibilityManagerFocusChangedEventHandler(this, e);
            }
        }

        // Callback for AccessibilityManager FocusedViewActivatedSignal
        private void OnFocusedViewActivated(IntPtr view)
        {
            FocusedViewActivatedEventArgs e = new FocusedViewActivatedEventArgs();

            // Populate all members of "e" (FocusedViewActivatedEventArgs) with real data
            e.View = Registry.GetManagedBaseHandleFromNativePtr(view) as View;

            if (_accessibilityManagerFocusedViewActivatedEventHandler != null)
            {
                //here we send all data to user event handlers
                _accessibilityManagerFocusedViewActivatedEventHandler(this, e);
            }
        }

        // Callback for AccessibilityManager FocusOvershotSignal
        private void OnFocusOvershot(IntPtr currentFocusedView, AccessibilityManager.FocusOvershotDirection direction)
        {
            FocusOvershotEventArgs e = new FocusOvershotEventArgs();

            // Populate all members of "e" (FocusOvershotEventArgs) with real data
            e.CurrentFocusedView = Registry.GetManagedBaseHandleFromNativePtr(currentFocusedView) as View;
            e.FocusOvershotDirection = direction;

            if (_accessibilityManagerFocusOvershotEventHandler != null)
            {
                //here we send all data to user event handlers
                _accessibilityManagerFocusOvershotEventHandler(this, e);
            }
        }


        public static AccessibilityManager GetAccessibilityManagerFromPtr(global::System.IntPtr cPtr)
        {
            AccessibilityManager ret = new AccessibilityManager(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }


        public AccessibilityManager() : this(Interop.AccessibilityManage.new_AccessibilityManager(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public static AccessibilityManager Get()
        {
            AccessibilityManager ret = new AccessibilityManager(Interop.AccessibilityManage.AccessibilityManager_Get(), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetAccessibilityAttribute(View view, AccessibilityManager.AccessibilityAttribute type, string text)
        {
            Interop.AccessibilityManage.AccessibilityManager_SetAccessibilityAttribute(swigCPtr, View.getCPtr(view), (int)type, text);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public string GetAccessibilityAttribute(View view, AccessibilityManager.AccessibilityAttribute type)
        {
            string ret = Interop.AccessibilityManage.AccessibilityManager_GetAccessibilityAttribute(swigCPtr, View.getCPtr(view), (int)type);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetFocusOrder(View view, uint order)
        {
            Interop.AccessibilityManage.AccessibilityManager_SetFocusOrder(swigCPtr, View.getCPtr(view), order);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public uint GetFocusOrder(View view)
        {
            uint ret = Interop.AccessibilityManage.AccessibilityManager_GetFocusOrder(swigCPtr, View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public uint GenerateNewFocusOrder()
        {
            uint ret = Interop.AccessibilityManage.AccessibilityManager_GenerateNewFocusOrder(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public View GetViewByFocusOrder(uint order)
        {
            View ret = new View(Interop.AccessibilityManage.AccessibilityManager_GetActorByFocusOrder(swigCPtr, order), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool SetCurrentFocusView(View view)
        {
            bool ret = Interop.AccessibilityManage.AccessibilityManager_SetCurrentFocusActor(swigCPtr, View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public View GetCurrentFocusView()
        {
            View ret = new View(Interop.AccessibilityManage.AccessibilityManager_GetCurrentFocusActor(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public View GetCurrentFocusGroup()
        {
            View ret = new View(Interop.AccessibilityManage.AccessibilityManager_GetCurrentFocusGroup(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public uint GetCurrentFocusOrder()
        {
            uint ret = Interop.AccessibilityManage.AccessibilityManager_GetCurrentFocusOrder(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool MoveFocusForward()
        {
            bool ret = Interop.AccessibilityManage.AccessibilityManager_MoveFocusForward(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool MoveFocusBackward()
        {
            bool ret = Interop.AccessibilityManage.AccessibilityManager_MoveFocusBackward(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void ClearFocus()
        {
            Interop.AccessibilityManage.AccessibilityManager_ClearFocus(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public new void Reset()
        {
            Interop.AccessibilityManage.AccessibilityManager_Reset(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetFocusGroup(View view, bool isFocusGroup)
        {
            Interop.AccessibilityManage.AccessibilityManager_SetFocusGroup(swigCPtr, View.getCPtr(view), isFocusGroup);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool IsFocusGroup(View view)
        {
            bool ret = Interop.AccessibilityManage.AccessibilityManager_IsFocusGroup(swigCPtr, View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetGroupMode(bool enabled)
        {
            Interop.AccessibilityManage.AccessibilityManager_SetGroupMode(swigCPtr, enabled);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool GetGroupMode()
        {
            bool ret = Interop.AccessibilityManage.AccessibilityManager_GetGroupMode(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetWrapMode(bool wrapped)
        {
            Interop.AccessibilityManage.AccessibilityManager_SetWrapMode(swigCPtr, wrapped);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool GetWrapMode()
        {
            bool ret = Interop.AccessibilityManage.AccessibilityManager_GetWrapMode(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetFocusIndicatorView(View indicator)
        {
            Interop.AccessibilityManage.AccessibilityManager_SetFocusIndicatorActor(swigCPtr, View.getCPtr(indicator));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public View GetFocusIndicatorView()
        {
            View ret = new View(Interop.AccessibilityManage.AccessibilityManager_GetFocusIndicatorActor(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public View GetFocusGroup(View view)
        {
            View ret = new View(Interop.AccessibilityManage.AccessibilityManager_GetFocusGroup(swigCPtr, View.getCPtr(view)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Vector2 GetReadPosition()
        {
            Vector2 ret = new Vector2(Interop.AccessibilityManage.AccessibilityManager_GetReadPosition(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public FocusChangedSignal FocusChangedSignal()
        {
            FocusChangedSignal ret = new FocusChangedSignal(Interop.AccessibilityManage.AccessibilityManager_FocusChangedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityFocusOvershotSignal FocusOvershotSignal()
        {
            AccessibilityFocusOvershotSignal ret = new AccessibilityFocusOvershotSignal(Interop.AccessibilityManage.AccessibilityManager_FocusOvershotSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public ViewSignal FocusedViewActivatedSignal()
        {
            ViewSignal ret = new ViewSignal(Interop.AccessibilityManage.AccessibilityManager_FocusedActorActivatedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal StatusChangedSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_StatusChangedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionNextSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionNextSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionPreviousSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionPreviousSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionActivateSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionActivateSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionReadSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionReadSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionOverSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionOverSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionReadNextSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionReadNextSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionReadPreviousSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionReadPreviousSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionUpSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionUpSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionDownSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionDownSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionClearFocusSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionClearFocusSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionBackSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionBackSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionScrollUpSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionScrollUpSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionScrollDownSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionScrollDownSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionPageLeftSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionPageLeftSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionPageRightSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionPageRightSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionPageUpSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionPageUpSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionPageDownSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionPageDownSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionMoveToFirstSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionMoveToFirstSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionMoveToLastSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionMoveToLastSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionReadFromTopSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionReadFromTopSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionReadFromNextSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionReadFromNextSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionZoomSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionZoomSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionReadIndicatorInformationSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionReadIndicatorInformationSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionReadPauseResumeSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionReadPauseResumeSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public AccessibilityActionSignal ActionStartStopSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManage.AccessibilityManager_ActionStartStopSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public SWIGTYPE_p_Dali__SignalT_bool_fDali__Toolkit__AccessibilityManager_R_Dali__TouchEvent_const_RF_t ActionScrollSignal()
        {
            SWIGTYPE_p_Dali__SignalT_bool_fDali__Toolkit__AccessibilityManager_R_Dali__TouchEvent_const_RF_t ret = new SWIGTYPE_p_Dali__SignalT_bool_fDali__Toolkit__AccessibilityManager_R_Dali__TouchEvent_const_RF_t(Interop.AccessibilityManage.AccessibilityManager_ActionScrollSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <since_tizen> 3 </since_tizen>
        public enum AccessibilityAttribute
        {
            ACCESSIBILITY_LABEL = 0,
            ACCESSIBILITY_TRAIT,
            ACCESSIBILITY_VALUE,
            ACCESSIBILITY_HINT,
            ACCESSIBILITY_ATTRIBUTE_NUM
        }

        /// <since_tizen> 3 </since_tizen>
        public enum FocusOvershotDirection
        {
            OVERSHOT_PREVIOUS = -1,
            OVERSHOT_NEXT = 1
        }
    }
}
