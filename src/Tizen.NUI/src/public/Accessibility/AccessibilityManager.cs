/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Accessibility
{
    /// <summary>
    /// AccessibilityManager manages registration of views in an accessibility focus chain and changing the focused view within that chain.
    /// This class provides the functionality of registering the focus order and description of views and maintaining the focus chain.
    /// It provides functionality of setting the focus and moving the focus forward and backward.
    ///  It also draws a highlight for the focused view and emits a signal when the focus is changed.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class AccessibilityManager : BaseHandle
    {
        private static readonly AccessibilityManager instance = AccessibilityManager.Get();
        private bool isForced = false;

        internal AccessibilityManager(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.AccessibilityManager.AccessibilityManager_SWIGUpcast(cPtr), cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(AccessibilityManager obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.AccessibilityManager.delete_AccessibilityManager(swigCPtr);
        }

        // Callback for AccessibilityManager StatusChangedSignal
        private bool OnStatusChanged(IntPtr data)
        {
            if (_accessibilityManagerStatusChangedEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerStatusChangedEventHandler(instance, null);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionNextSignal
        private bool OnActionNext(IntPtr data)
        {
            if (_accessibilityManagerActionNextEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionNextEventHandler(instance, null);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionPreviousSignal
        private bool OnActionPrevious(IntPtr data)
        {
            if (_accessibilityManagerActionPreviousEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionPreviousEventHandler(instance, null);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionActivateSignal
        private bool OnActionActivate(IntPtr data)
        {
            if (_accessibilityManagerActionActivateEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionActivateEventHandler(instance, null);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionReadSignal
        private bool OnActionRead(IntPtr data)
        {

            if (_accessibilityManagerActionReadEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionReadEventHandler(instance, null);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionOverSignal
        private bool OnActionOver(IntPtr data)
        {
            if (_accessibilityManagerActionOverEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionOverEventHandler(instance, null);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionReadNextSignal
        private bool OnActionReadNext(IntPtr data)
        {
            if (_accessibilityManagerActionReadNextEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionReadNextEventHandler(instance, null);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionReadPreviousSignal
        private bool OnActionReadPrevious(IntPtr data)
        {
            if (_accessibilityManagerActionReadPreviousEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionReadPreviousEventHandler(instance, null);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionUpSignal
        private bool OnActionUp(IntPtr data)
        {
            if (_accessibilityManagerActionUpEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionUpEventHandler(instance, null);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionDownSignal
        private bool OnActionDown(IntPtr data)
        {
            if (_accessibilityManagerActionDownEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionDownEventHandler(instance, null);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionClearFocusSignal
        private bool OnActionClearFocus(IntPtr data)
        {
            if (_accessibilityManagerActionClearFocusEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionClearFocusEventHandler(instance, null);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionBackSignal
        private bool OnActionBack(IntPtr data)
        {
            if (_accessibilityManagerActionBackEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionBackEventHandler(instance, null);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionScrollUpSignal
        private bool OnActionScrollUp(IntPtr data)
        {
            if (_accessibilityManagerActionScrollUpEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionScrollUpEventHandler(instance, null);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionScrollDownSignal
        private bool OnActionScrollDown(IntPtr data)
        {
            if (_accessibilityManagerActionScrollDownEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionScrollDownEventHandler(instance, null);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionPageLeftSignal
        private bool OnActionPageLeft(IntPtr data)
        {
            if (_accessibilityManagerActionPageLeftEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionPageLeftEventHandler(instance, null);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionPageRightSignal
        private bool OnActionPageRight(IntPtr data)
        {
            if (_accessibilityManagerActionPageRightEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionPageRightEventHandler(instance, null);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionPageUpSignal
        private bool OnActionPageUp(IntPtr data)
        {
            if (_accessibilityManagerActionPageUpEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionPageUpEventHandler(instance, null);
            }
            return false;
        }


        // Callback for AccessibilityManager ActionPageDownSignal
        private bool OnActionPageDown(IntPtr data)
        {
            if (_accessibilityManagerActionPageDownEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionPageDownEventHandler(instance, null);
            }
            return false;
        }


        // Callback for AccessibilityManager ActionMoveToFirstSignal
        private bool OnActionMoveToFirst(IntPtr data)
        {
            if (_accessibilityManagerActionMoveToFirstEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionMoveToFirstEventHandler(instance, null);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionMoveToLastSignal
        private bool OnActionMoveToLast(IntPtr data)
        {
            if (_accessibilityManagerActionMoveToLastEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionMoveToLastEventHandler(instance, null);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionReadFromTopSignal
        private bool OnActionReadFromTop(IntPtr data)
        {
            if (_accessibilityManagerActionReadFromTopEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionReadFromTopEventHandler(instance, null);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionReadFromNextSignal
        private bool OnActionReadFromNext(IntPtr data)
        {
            if (_accessibilityManagerActionReadFromNextEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionReadFromNextEventHandler(instance, null);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionZoomSignal
        private bool OnActionZoom(IntPtr data)
        {
            if (_accessibilityManagerActionZoomEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionZoomEventHandler(instance, null);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionReadPauseResumeSignal
        private bool OnActionReadPauseResume(IntPtr data)
        {
            if (_accessibilityManagerActionReadPauseResumeEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionReadPauseResumeEventHandler(instance, null);
            }
            return false;
        }

        // Callback for AccessibilityManager ActionStartStopSignal
        private bool OnActionStartStop(IntPtr data)
        {
            if (_accessibilityManagerActionStartStopEventHandler != null)
            {
                //here we send all data to user event handlers
                return _accessibilityManagerActionStartStopEventHandler(instance, null);
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

        /// <summary>
        /// Enumeration for accessibility that needs four information which will be read by screen-reader.
        ///
        /// Reading order : Label -> Trait -> Optional (Value and Hint)
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum AccessibilityAttribute
        {
            /// <summary>
            /// Simple text which contained in components, such as Ok or Cancel in case of a button
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Label = 0,
            /// <summary>
            /// Description of components trait, such as Button in case of a button
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Trait,
            /// <summary>
            /// Current value of components (Optional)
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Value,
            /// <summary>
            /// Hint for action (Optional)
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Hint,
            /// <summary>
            /// The number of attributes
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            AttributeNumber
        }

        /// <summary>
        /// Enumeration for overshoot direction.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum FocusOvershotDirection
        {
            /// <summary>
            /// Try to move previous of the first view
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Previous = -1,
            /// <summary>
            /// Try to move next of the last view
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Next = 1
        }


        /// <summary>
        /// Creates an AccessibilityManager handle.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AccessibilityManager() : this(Interop.AccessibilityManager.new_AccessibilityManager(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the singleton of AccessibilityManager object.
        /// </summary>
        /// <returns> A handle to the AccessibilityManager </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AccessibilityManager Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// Sets the information of the specified view's accessibility attribute.
        /// </summary>
        /// <param name="view"> The view to be set with</param>
        /// <param name="type"> The attribute type the text to be set with</param>
        /// <param name="text"> The text for the view's accessibility information</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetAccessibilityAttribute(View view, AccessibilityManager.AccessibilityAttribute type, string text)
        {
            Interop.AccessibilityManager.AccessibilityManager_SetAccessibilityAttribute(swigCPtr, View.getCPtr(view), (int)type, text);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
        
        /// <summary>
        /// Delete the information of the specified view's accessibility attribute.
        /// </summary>
        /// <param name="view"> The view to delete</param>
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void DeleteAccessibilityAttribute(View view)
        {
            Interop.AccessibilityManager.AccessibilityManager_DeleteAccessibilityAttribute(SwigCPtr, View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the text of the specified view's accessibility attribute.
        /// </summary>
        /// <param name="view"> The view to be queried</param>
        /// <param name="type"> The attribute type to be queried</param>
        /// <returns> The text of the view's accessibility information </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string GetAccessibilityAttribute(View view, AccessibilityManager.AccessibilityAttribute type)
        {
            string ret = Interop.AccessibilityManager.AccessibilityManager_GetAccessibilityAttribute(swigCPtr, View.getCPtr(view), (int)type);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the focus order of the view.
        /// The focus order of each view in the focus chain is unique.
        /// If there is another view assigned with the same focus order already, the new view will be inserted to the focus chain with that focus order,
        /// and the focus order of the original view and all the views followed in the focus chain will be increased accordingly.
        /// If the focus order assigned to the view is 0, it means that view's focus order is undefined
        /// (e.g. the view has a  description but with no focus order being set yet) and therefore that view is not focusable.
        /// </summary>
        /// <param name="view"> the view to be set with</param>
        /// <param name="order"> the focus order to be set with</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetFocusOrder(View view, uint order)
        {
            Interop.AccessibilityManager.AccessibilityManager_SetFocusOrder(swigCPtr, View.getCPtr(view), order);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the focus order of the view.
        /// When the focus order is 0, it means the focus order of the view is undefined.
        /// </summary>
        /// <param name="view"> the view to be set with</param>
        /// <returns> The focus order of the view </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetFocusOrder(View view)
        {
            uint ret = Interop.AccessibilityManager.AccessibilityManager_GetFocusOrder(swigCPtr, View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Generates a new focus order number which can be used to assign to views
        /// which need to be appended to the end of the current focus order chain.
        /// The new number will be an increment over the very last focus order number in the focus chain.
        /// If the focus chain is empty then the function returns 1,
        /// else the number returned will be FOLast + 1 where FOLast is the focus order of the very last control in the focus chain.
        /// </summary>
        /// <returns> The focus order of the view </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GenerateNewFocusOrder()
        {
            uint ret = Interop.AccessibilityManager.AccessibilityManager_GenerateNewFocusOrder(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the view that has the specified focus order.
        /// It will return an empty handle if no view in the window has the specified focus order.
        /// </summary>
        /// <param name="order"> The focus order of the view</param>
        /// <returns> The view that has the specified focus order or an empty handle if no view in the stage has the specified focus order </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View GetViewByFocusOrder(uint order)
        {
            View ret = new View(Interop.AccessibilityManager.AccessibilityManager_GetActorByFocusOrder(swigCPtr, order), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Moves the focus to the specified view.
        /// Only one view can be focused at the same time. The view must have a defined focus order
        /// and must be focusable, visible and in the window.
        /// </summary>
        /// <param name="view"> the view to be set with</param>
        /// <returns> Whether the focus is successful or not </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool SetCurrentFocusView(View view)
        {
            bool ret = Interop.AccessibilityManager.AccessibilityManager_SetCurrentFocusActor(swigCPtr, View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the current focused view.
        /// </summary>
        /// <returns> A handle to the current focused view or an empty handle if no view is focused </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View GetCurrentFocusView()
        {
            View ret = new View(Interop.AccessibilityManager.AccessibilityManager_GetCurrentFocusActor(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the focus group of current focused view.
        /// </summary>
        /// <returns> A handle to the immediate parent of the current focused view which is also a focus group, or an empty handle if no view is focused </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View GetCurrentFocusGroup()
        {
            View ret = new View(Interop.AccessibilityManager.AccessibilityManager_GetCurrentFocusGroup(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the focus order of currently focused view.
        /// </summary>
        /// <returns> The focus order of the currently focused view or 0 if no view is in focus </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetCurrentFocusOrder()
        {
            uint ret = Interop.AccessibilityManager.AccessibilityManager_GetCurrentFocusOrder(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Moves the focus to the next focusable view in the focus chain (according to the focus traversal order).
        /// When the focus movement is wrapped around, the focus will be moved to the first focusable view when it reaches the end of the focus chain.
        /// </summary>
        /// <returns> True if the moving was successful </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool MoveFocusForward()
        {
            bool ret = Interop.AccessibilityManager.AccessibilityManager_MoveFocusForward(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Moves the focus to the previous focusable view in the focus chain (according to the focus traversal order).
        /// When the focus movement is wrapped around, the focus will be moved to the last focusable view
        /// when it reaches the beginning of the focus chain.
        /// </summary>
        /// <returns> True if the moving was successful </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool MoveFocusBackward()
        {
            bool ret = Interop.AccessibilityManager.AccessibilityManager_MoveFocusBackward(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Clears the focus from the current focused view if any, so that no view is focused in the focus chain.
        /// It will emit focus changed signal without current focused view.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ClearFocus()
        {
            Interop.AccessibilityManager.AccessibilityManager_ClearFocus(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Clears every registered focusable view from focus-manager.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new void Reset()
        {
            Interop.AccessibilityManager.AccessibilityManager_Reset(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets whether an view is a focus group that can limit the scope of focus movement to its child views in the focus chain.
        /// </summary>
        /// <param name="view"> the view to be set as a focus group</param>
        /// <param name="isFocusGroup"> Whether to set the view to be a focus group or not</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetFocusGroup(View view, bool isFocusGroup)
        {
            Interop.AccessibilityManager.AccessibilityManager_SetFocusGroup(swigCPtr, View.getCPtr(view), isFocusGroup);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Checks whether the view is set as a focus group or not.
        /// </summary>
        /// <param name="view"> the view to be checked</param>
        /// <returns> Whether the view is set as a focus group </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsFocusGroup(View view)
        {
            bool ret = Interop.AccessibilityManager.AccessibilityManager_IsFocusGroup(swigCPtr, View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets whether the group mode is enabled or not.
        /// When the group mode is enabled, the focus movement will be limited to the child views  of the current focus group including the current focus group itself.
        /// The current focus group is the closest ancestor of the current focused view that is set as a focus group.
        /// </summary>
        /// <param name="enabled"> Whether the group mode is enabled or not</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetGroupMode(bool enabled)
        {
            Interop.AccessibilityManager.AccessibilityManager_SetGroupMode(swigCPtr, enabled);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets whether the group mode is enabled or not.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns> Whether the group mode is enabled or not. </returns>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool GetGroupMode()
        {
            bool ret = Interop.AccessibilityManager.AccessibilityManager_GetGroupMode(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets whether focus will be moved to the beginning of the focus chain when it reaches the end or vice versa.
        /// When both the wrap mode and the group mode are enabled, focus will be wrapped within the current focus group.
        /// Focus will not be wrapped in default.
        /// </summary>
        /// <param name="wrapped"> Whether the focus movement is wrapped around or not</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetWrapMode(bool wrapped)
        {
            Interop.AccessibilityManager.AccessibilityManager_SetWrapMode(swigCPtr, wrapped);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets whether the wrap mode is enabled or not.
        /// </summary>
        /// <returns> Whether the wrap mode is enabled or not. </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool GetWrapMode()
        {
            bool ret = Interop.AccessibilityManager.AccessibilityManager_GetWrapMode(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the focus indicator view.
        /// This will replace the default focus indicator view in AccessibilityManager and
        /// will be added to the focused view as a highlight.
        /// </summary>
        /// <param name="indicator"> The indicator view to be added</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetFocusIndicatorView(View indicator)
        {
            Interop.AccessibilityManager.AccessibilityManager_SetFocusIndicatorActor(swigCPtr, View.getCPtr(indicator));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the focus indicator view.
        /// </summary>
        /// <returns> A handle to the focus indicator view </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View GetFocusIndicatorView()
        {
            View ret = new View(Interop.AccessibilityManager.AccessibilityManager_GetFocusIndicatorActor(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns the closest ancestor of the given view that is a focus group.
        /// </summary>
        /// <param name="view"> The view to be checked for its focus group</param>
        /// <returns> The focus group the given view belongs to or an empty handle if the given view doesn't belong to any focus group </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View GetFocusGroup(View view)
        {
            View ret = new View(Interop.AccessibilityManager.AccessibilityManager_GetFocusGroup(swigCPtr, View.getCPtr(view)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns the current position of the read action.
        /// </summary>
        /// <returns> The current event position </returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 GetReadPosition()
        {
            Vector2 ret = new Vector2(Interop.AccessibilityManager.AccessibilityManager_GetReadPosition(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Enables Accessibility or not.
        /// </summary>
        /// <param name="enabled"> True if Accessibility should be enabled.</param>
        /// This will be public opened later. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void EnableAccessibility(bool enabled)
        {
            isForced = enabled;
            Interop.AccessibilityManager.EnableAccessibility(swigCPtr, enabled);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Queries whether the accessibility(screen-reader) is enabled.
        /// Basically, the accessibility will be enabled by system setting.
        /// </summary>
        /// <returns> True if the accessibility(screen-reader) is enabled. </returns>
        /// This will be public opened later. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsEnabled()
        {
            bool ret = Interop.AccessibilityManager.IsEnabled(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// Queries whether EnableAccessibility() is called and Accessibility is enabled forcibly or not.
        /// This API is only used for internal checks.
        internal bool IsForcedEnable()
        {
            return isForced;
        }

        internal static AccessibilityManager Get()
        {
            AccessibilityManager ret = new AccessibilityManager(Interop.AccessibilityManager.AccessibilityManager_Get(), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        // Signals - AccessibilityManagerEvent.cs
        internal FocusChangedSignal FocusChangedSignal()
        {
            FocusChangedSignal ret = new FocusChangedSignal(Interop.AccessibilityManager.AccessibilityManager_FocusChangedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal AccessibilityFocusOvershotSignal FocusOvershotSignal()
        {
            AccessibilityFocusOvershotSignal ret = new AccessibilityFocusOvershotSignal(Interop.AccessibilityManager.AccessibilityManager_FocusOvershotSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ViewSignal FocusedViewActivatedSignal()
        {
            ViewSignal ret = new ViewSignal(Interop.AccessibilityManager.AccessibilityManager_FocusedActorActivatedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal AccessibilityActionSignal StatusChangedSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManager.AccessibilityManager_StatusChangedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal AccessibilityActionSignal ActionNextSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManager.AccessibilityManager_ActionNextSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal AccessibilityActionSignal ActionPreviousSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManager.AccessibilityManager_ActionPreviousSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal AccessibilityActionSignal ActionActivateSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManager.AccessibilityManager_ActionActivateSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal AccessibilityActionSignal ActionReadSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManager.AccessibilityManager_ActionReadSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal AccessibilityActionSignal ActionOverSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManager.AccessibilityManager_ActionOverSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal AccessibilityActionSignal ActionReadNextSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManager.AccessibilityManager_ActionReadNextSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal AccessibilityActionSignal ActionReadPreviousSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManager.AccessibilityManager_ActionReadPreviousSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal AccessibilityActionSignal ActionUpSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManager.AccessibilityManager_ActionUpSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal AccessibilityActionSignal ActionDownSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManager.AccessibilityManager_ActionDownSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal AccessibilityActionSignal ActionClearFocusSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManager.AccessibilityManager_ActionClearFocusSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal AccessibilityActionSignal ActionBackSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManager.AccessibilityManager_ActionBackSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal AccessibilityActionSignal ActionScrollUpSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManager.AccessibilityManager_ActionScrollUpSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal AccessibilityActionSignal ActionScrollDownSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManager.AccessibilityManager_ActionScrollDownSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal AccessibilityActionSignal ActionPageLeftSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManager.AccessibilityManager_ActionPageLeftSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal AccessibilityActionSignal ActionPageRightSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManager.AccessibilityManager_ActionPageRightSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal AccessibilityActionSignal ActionPageUpSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManager.AccessibilityManager_ActionPageUpSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal AccessibilityActionSignal ActionPageDownSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManager.AccessibilityManager_ActionPageDownSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal AccessibilityActionSignal ActionMoveToFirstSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManager.AccessibilityManager_ActionMoveToFirstSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal AccessibilityActionSignal ActionMoveToLastSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManager.AccessibilityManager_ActionMoveToLastSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal AccessibilityActionSignal ActionReadFromTopSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManager.AccessibilityManager_ActionReadFromTopSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal AccessibilityActionSignal ActionReadFromNextSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManager.AccessibilityManager_ActionReadFromNextSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal AccessibilityActionSignal ActionZoomSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManager.AccessibilityManager_ActionZoomSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal AccessibilityActionSignal ActionReadPauseResumeSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManager.AccessibilityManager_ActionReadPauseResumeSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal AccessibilityActionSignal ActionStartStopSignal()
        {
            AccessibilityActionSignal ret = new AccessibilityActionSignal(Interop.AccessibilityManager.AccessibilityManager_ActionStartStopSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal SWIGTYPE_p_Dali__SignalT_bool_fDali__Toolkit__AccessibilityManager_R_Dali__TouchEvent_const_RF_t ActionScrollSignal()
        {
            SWIGTYPE_p_Dali__SignalT_bool_fDali__Toolkit__AccessibilityManager_R_Dali__TouchEvent_const_RF_t ret = new SWIGTYPE_p_Dali__SignalT_bool_fDali__Toolkit__AccessibilityManager_R_Dali__TouchEvent_const_RF_t(Interop.AccessibilityManager.AccessibilityManager_ActionScrollSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
