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
using System.Runtime.InteropServices;
using Tizen.NUI.BaseComponents;
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// Provides the functionality of handling keyboard navigation and maintaining the two-dimensional keyboard focus chain.<br />
    /// It provides functionality of setting the focus and moving the focus in four directions( i.e., left, right, up, and down).<br />
    /// It also draws a highlight for the focused view and sends an event when the focus is changed.<br />
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class FocusManager : BaseHandle
    {
        private static readonly FocusManager instance = FocusManager.Get();
        private CustomAlgorithmInterfaceWrapper customAlgorithmInterfaceWrapper;

        private EventHandlerWithReturnType<object, PreFocusChangeEventArgs, View> preFocusChangeEventHandler;
        private PreFocusChangeEventCallback preFocusChangeCallback;

        private EventHandler<FocusChangedEventArgs> focusChangedEventHandler;
        private FocusChangedEventCallback focusChangedEventCallback;

        private EventHandler<FocusGroupChangedEventArgs> focusGroupChangedEventHandler;
        private FocusGroupChangedEventCallback focusGroupChangedEventCallback;

        private EventHandler<FocusedViewActivatedEventArgs> focusedViewEnterKeyEventHandler;
        private FocusedViewEnterKeyEventCallback focusedViewEnterKeyEventCallback;

        private EventHandler<FocusedViewActivatedEventArgs> focusedViewEnterKeyEventHandler2;
        private FocusedViewEnterKeyEventCallback2 focusedViewEnterKeyEventCallback2;

        internal FocusManager(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal FocusManager() : this(Interop.FocusManager.NewFocusManager(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        internal delegate IntPtr PreFocusChangeEventCallback(IntPtr current, IntPtr proposed, View.FocusDirection direction);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        internal delegate void FocusChangedEventCallback(IntPtr current, IntPtr next);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void FocusGroupChangedEventCallback(IntPtr current, bool forwardDirection);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void FocusedViewEnterKeyEventCallback(IntPtr view);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void FocusedViewEnterKeyEventCallback2(IntPtr view);

        /// <summary>
        /// PreFocusChange will be triggered before the focus is going to be changed.<br />
        /// The FocusManager makes the best guess for which view to focus towards the given direction, but applications might want to change that.<br />
        /// By connecting with this event, they can check the proposed view to focus and return a different view if they wish.<br />
        /// This event is only triggered when the navigation key is pressed and KeyboardFocusManager tries to move the focus automatically.<br />
        /// It won't be emitted for focus movement by calling the SetCurrentFocusView directly.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandlerWithReturnType<object, PreFocusChangeEventArgs, View> PreFocusChange
        {
            add
            {
                if (preFocusChangeEventHandler == null)
                {
                    preFocusChangeCallback = OnPreFocusChange;
                    PreFocusChangeSignal().Connect(preFocusChangeCallback);
                }
                preFocusChangeEventHandler += value;
            }
            remove
            {
                preFocusChangeEventHandler -= value;
                if (preFocusChangeEventHandler == null && PreFocusChangeSignal().Empty() == false)
                {
                    PreFocusChangeSignal().Disconnect(preFocusChangeCallback);
                }
            }
        }

        /// <summary>
        /// The FocusGroupChanged will be triggered after the current focused view has been changed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<FocusChangedEventArgs> FocusChanged
        {
            add
            {
                if (focusChangedEventCallback == null)
                {
                    focusChangedEventCallback = OnFocusChanged;
                    FocusChangedSignal().Connect(focusChangedEventCallback);
                }
                focusChangedEventHandler += value;
            }
            remove
            {
                focusChangedEventHandler -= value;

                if (focusChangedEventCallback == null && FocusChangedSignal().Empty() == false)
                {
                    FocusChangedSignal().Disconnect(focusChangedEventCallback);
                }
            }
        }

        /// <summary>
        /// The FocusGroupChanged will be triggered when the focus group has been changed.<br />
        /// If the current focus group has a parent layout control, the FocusManager will make the best guess for the next focus group to move the focus to in the given direction (forward or backward).<br />
        /// If not, the application has to set the new focus.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<FocusGroupChangedEventArgs> FocusGroupChanged
        {
            add
            {
                if (focusGroupChangedEventCallback == null)
                {
                    focusGroupChangedEventCallback = OnFocusGroupChanged;
                    FocusGroupChangedSignal().Connect(focusGroupChangedEventCallback);
                }
                focusGroupChangedEventHandler += value;
            }
            remove
            {
                focusGroupChangedEventHandler -= value;

                if (focusGroupChangedEventCallback == null && FocusGroupChangedSignal().Empty() == false)
                {
                    FocusGroupChangedSignal().Disconnect(focusGroupChangedEventCallback);
                }
            }
        }

        /// <summary>
        /// The FocusedViewActivated will be triggered when the current focused view has the enter key pressed on it.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<FocusedViewActivatedEventArgs> FocusedViewActivated
        {
            add
            {
                if (focusedViewEnterKeyEventCallback == null)
                {
                    focusedViewEnterKeyEventCallback = OnFocusedViewEnterKey;
                    FocusedViewEnterKeySignal().Connect(focusedViewEnterKeyEventCallback);
                }
                focusedViewEnterKeyEventHandler += value;
            }
            remove
            {
                focusedViewEnterKeyEventHandler -= value;

                if (focusedViewEnterKeyEventCallback != null && FocusedViewEnterKeySignal().Empty() == false)
                {
                    FocusedViewEnterKeySignal().Disconnect(focusedViewEnterKeyEventCallback);
                }
            }
        }

        /// <summary>
        /// [Obsolete("Please do not use! this will be deprecated")]
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// Please do not use! this will be deprecated!
        /// Instead please use FocusedViewActivated.
        [Obsolete("Please do not use! This will be deprecated! Please use FocusManager.FocusedViewActivated instead! " +
            "Like: " +
            "FocusManager.Instance.FocusedViewActivated = OnFocusedViewActivated; " +
            "private void OnFocusedViewActivated(object source, FocusManager.FocusedViewActivatedEventArgs args) {...}")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<FocusedViewActivatedEventArgs> FocusedViewEnterKeyPressed
        {
            add
            {
                if (focusedViewEnterKeyEventCallback2 == null)
                {
                    focusedViewEnterKeyEventCallback2 = OnFocusedViewEnterKey2;
                    FocusedViewEnterKeySignal().Connect(focusedViewEnterKeyEventCallback2);
                }
                focusedViewEnterKeyEventHandler2 += value;
            }
            remove
            {
                focusedViewEnterKeyEventHandler2 -= value;

                if (focusedViewEnterKeyEventCallback2 != null && FocusedViewEnterKeySignal().Empty() == false)
                {
                    FocusedViewEnterKeySignal().Disconnect(focusedViewEnterKeyEventCallback2);
                }
            }
        }

        /// <summary>
        /// ICustomFocusAlgorithm is used to provide the custom keyboard focus algorithm for retrieving the next focusable view.<br />
        /// The application can implement the interface and override the keyboard focus behavior.<br />
        /// If the focus is changing within a layout container, then the layout container is queried first to provide the next focusable view.<br />
        /// If this does not provide a valid view, then the Keyboard FocusManager will check focusable properties to determine the next focusable actor.<br />
        /// If focusable properties are not set, then the keyboard FocusManager calls the GetNextFocusableView() method of this interface.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public interface ICustomFocusAlgorithm
        {
            /// <summary>
            /// Get the next focus actor.
            /// </summary>
            /// <param name="current">The current focus view.</param>
            /// <param name="proposed">The proposed focus view</param>
            /// <param name="direction">The focus move direction</param>
            /// <returns>The next focus actor.</returns>
            /// <since_tizen> 3 </since_tizen>
            View GetNextFocusableView(View current, View proposed, View.FocusDirection direction);
        }

        /// <summary>
        /// Gets or sets the status of whether the focus movement should be looped within the same focus group.<br />
        /// The focus movement is not looped by default.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool FocusGroupLoop
        {
            set
            {
                SetFocusGroupLoop(value);
            }
            get
            {
                return GetFocusGroupLoop();
            }
        }

        /// <summary>
        /// Gets or sets the focus indicator view.<br />
        /// This will replace the default focus indicator view in the FocusManager and will be added to the focused view as a highlight.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public View FocusIndicator
        {
            set
            {
                SetFocusIndicatorView(value);
            }
            get
            {
                return GetFocusIndicatorView();
            }
        }

        /// <summary>
        /// Gets the singleton of the FocusManager object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static FocusManager Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// Moves the keyboard focus to the given view.<br />
        /// Only one view can be focused at the same time.<br />
        /// The view must be in the stage already and keyboard focusable.<br />
        /// </summary>
        /// <param name="view">The view to be focused.</param>
        /// <returns>Whether the focus is successful or not.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool SetCurrentFocusView(View view)
        {
            if (view == null)
            {
                throw new ArgumentNullException(nameof(view), "the target view should not be null");
            }

            bool ret = Interop.FocusManager.SetCurrentFocusActor(SwigCPtr, View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the current focused view.
        /// </summary>
        /// <returns>A handle to the current focused view or an empty handle if no view is focused.</returns>
        /// <since_tizen> 3 </since_tizen>
        public View GetCurrentFocusView()
        {
            //to fix memory leak issue, match the handle count with native side.
            IntPtr cPtr = Interop.FocusManager.GetCurrentFocusActor(SwigCPtr);
            View ret = this.GetInstanceSafely<View>(cPtr);
            return ret;
        }

        /// <summary>
        /// Moves the focus to the next focusable view in the focus chain in the given direction (according to the focus traversal order).
        /// </summary>
        /// <param name="direction">The direction of the focus movement.</param>
        /// <returns>True if the movement was successful.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool MoveFocus(View.FocusDirection direction)
        {
            bool ret = Interop.FocusManager.MoveFocus(SwigCPtr, (int)direction);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Clears the focus from the current focused view if any, so that no view is focused in the focus chain.<br />
        /// It will emit the FocusChanged event without the current focused view.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void ClearFocus()
        {
            Interop.FocusManager.ClearFocus(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Move the focus to previous focused view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void MoveFocusBackward()
        {
            Interop.FocusManager.MoveFocusBackward(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets whether the view is a focus group that can limit the scope of the focus movement to its child views in the focus chain.<br />
        /// Layout controls set themselves as focus groups by default.<br />
        /// </summary>
        /// <param name="view">The view to be set as a focus group.</param>
        /// <param name="isFocusGroup">Whether to set the view as a focus group or not.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetAsFocusGroup(View view, bool isFocusGroup)
        {
            Interop.FocusManager.SetAsFocusGroup(SwigCPtr, View.getCPtr(view), isFocusGroup);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Checks whether the view is set as a focus group or not.
        /// </summary>
        /// <param name="view">The view to be checked.</param>
        /// <returns>Whether the view is set as a focus group.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool IsFocusGroup(View view)
        {
            bool ret = Interop.FocusManager.IsFocusGroup(SwigCPtr, View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns the closest ancestor of the given view that is a focus group.
        /// </summary>
        /// <param name="view">The view to be checked for its focus group.</param>
        /// <returns>The focus group the given view belongs to or an empty handle if the given view.</returns>
        /// <since_tizen> 3 </since_tizen>
        public View GetFocusGroup(View view)
        {
            //to fix memory leak issue, match the handle count with native side.
            IntPtr cPtr = Interop.FocusManager.GetFocusGroup(SwigCPtr, View.getCPtr(view));
            View ret = this.GetInstanceSafely<View>(cPtr);
            return ret;
        }

        /// <summary>
        /// Provides the implementation of a custom focus algorithm interface to allow the application to define the focus logic.<br />
        /// </summary>
        /// <param name="arg0">The user's implementation of ICustomFocusAlgorithm.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetCustomAlgorithm(ICustomFocusAlgorithm arg0)
        {
            if (arg0 != null)
            {
                customAlgorithmInterfaceWrapper = new CustomAlgorithmInterfaceWrapper();
                customAlgorithmInterfaceWrapper.SetFocusAlgorithm(arg0);

                Interop.NDalic.SetCustomAlgorithm(SwigCPtr, CustomAlgorithmInterface.getCPtr(customAlgorithmInterfaceWrapper));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            else
            {
                Interop.NDalic.SetCustomAlgorithm(SwigCPtr, new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        internal static FocusManager Get()
        {
            FocusManager ret = new FocusManager(Interop.FocusManager.Get(), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetFocusGroupLoop(bool enabled)
        {
            Interop.FocusManager.SetFocusGroupLoop(SwigCPtr, enabled);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal bool GetFocusGroupLoop()
        {
            bool ret = Interop.FocusManager.GetFocusGroupLoop(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetFocusIndicatorView(View indicator)
        {
            Interop.FocusManager.SetFocusIndicatorActor(SwigCPtr, View.getCPtr(indicator));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal View GetFocusIndicatorView()
        {
            //to fix memory leak issue, match the handle count with native side.
            IntPtr cPtr = Interop.FocusManager.GetFocusIndicatorActor(SwigCPtr);
            View ret = this.GetInstanceSafely<View>(cPtr);
            return ret;
        }

        internal PreFocusChangeSignal PreFocusChangeSignal()
        {
            PreFocusChangeSignal ret = new PreFocusChangeSignal(Interop.FocusManager.PreFocusChangeSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal FocusChangedSignal FocusChangedSignal()
        {
            FocusChangedSignal ret = new FocusChangedSignal(Interop.FocusManager.FocusChangedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal FocusGroupChangedSignal FocusGroupChangedSignal()
        {
            FocusGroupChangedSignal ret = new FocusGroupChangedSignal(Interop.FocusManager.FocusGroupChangedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ViewSignal FocusedViewEnterKeySignal()
        {
            ViewSignal ret = new ViewSignal(Interop.FocusManager.FocusedActorEnterKeySignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private IntPtr OnPreFocusChange(IntPtr current, IntPtr proposed, View.FocusDirection direction)
        {
            View view = null;
            PreFocusChangeEventArgs e = new PreFocusChangeEventArgs();

            if (current != global::System.IntPtr.Zero)
            {
                e.CurrentView = Registry.GetManagedBaseHandleFromNativePtr(current) as View;
            }
            if (proposed != global::System.IntPtr.Zero)
            {
                e.ProposedView = Registry.GetManagedBaseHandleFromNativePtr(proposed) as View;
            }
            e.Direction = direction;

            if (preFocusChangeEventHandler != null)
            {
                view = preFocusChangeEventHandler(this, e);
            }

            if (view != null)
            {
                return view.GetPtrfromView();
            }
            else
            {
                if (e.ProposedView) return proposed;
                else return current;
            }
        }

        private void OnFocusChanged(IntPtr current, IntPtr next)
        {
            if (focusChangedEventHandler != null)
            {
                FocusChangedEventArgs e = new FocusChangedEventArgs();

                e.CurrentView = Registry.GetManagedBaseHandleFromNativePtr(current) as View;
                e.NextView = Registry.GetManagedBaseHandleFromNativePtr(next) as View;
                focusChangedEventHandler(this, e);
            }
        }

        private void OnFocusGroupChanged(IntPtr current, bool forwardDirection)
        {
            if (focusGroupChangedEventHandler != null)
            {
                FocusGroupChangedEventArgs e = new FocusGroupChangedEventArgs();

                e.CurrentView = Registry.GetManagedBaseHandleFromNativePtr(current) as View;
                e.ForwardDirection = forwardDirection;
                focusGroupChangedEventHandler(this, e);
            }
        }

        private void OnFocusedViewEnterKey(IntPtr view)
        {
            if (focusedViewEnterKeyEventHandler != null)
            {
                FocusedViewActivatedEventArgs e = new FocusedViewActivatedEventArgs();
                e.View = Registry.GetManagedBaseHandleFromNativePtr(view) as View;
                focusedViewEnterKeyEventHandler(this, e);
            }
        }

        /// <summary>
        /// Please do not use! this will be deprecated!
        /// </summary>
        /// Please do not use! this will be deprecated!
        /// Instead please use OnFocusedViewEnterKey.
        [Obsolete("Please do not use! This will be deprecated! Please use FocusManager.OnFocusedViewEnterKey instead!")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private void OnFocusedViewEnterKey2(IntPtr view)
        {
            if (focusedViewEnterKeyEventHandler != null)
            {
                FocusedViewActivatedEventArgs e = new FocusedViewActivatedEventArgs();
                e.View = Registry.GetManagedBaseHandleFromNativePtr(view) as View;
                focusedViewEnterKeyEventHandler(this, e);
            }
        }

        ///<summary>
        /// Event arguments that passed via the PreFocusChange signal.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class PreFocusChangeEventArgs : EventArgs
        {
            private View current;
            private View proposed;
            private View.FocusDirection direction;

            /// <summary>
            /// The current focus view.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public View CurrentView
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

            /// <summary>
            /// The  proposed view.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public View ProposedView
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

            /// <summary>
            /// The focus move direction.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public View.FocusDirection Direction
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

        ///<summary>
        /// Event arguments that passed via the FocusChanged signal.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class FocusChangedEventArgs : EventArgs
        {
            private View current;
            private View next;

            /// <summary>
            /// The current focus view.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public View CurrentView
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
            /// <summary>
            /// The next focus view.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public View NextView
            {
                get
                {
                    return next;
                }
                set
                {
                    next = value;
                }
            }
        }

        ///<summary>
        /// Event arguments that passed via the FocusGroupChanged signal.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class FocusGroupChangedEventArgs : EventArgs
        {
            private View current;
            private bool forwardDirection;

            /// <summary>
            /// The current focus view.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public View CurrentView
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

            /// <summary>
            /// The forward direction.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
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

        ///<summary>
        /// Event arguments that passed via the FocusedViewEnterKey signal.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class FocusedViewActivatedEventArgs : EventArgs
        {
            private View view;

            /// <summary>
            /// View.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
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

        /// <summary>
        /// Please do not use! this will be deprecated
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// Please do not use! this will be deprecated.
        /// Instead please use FocusedViewActivatedEventArgs.
        [Obsolete("Please do not use! This will be deprecated! Please use FocusedViewActivatedEventArgs instead! " +
            "Like: " +
            "FocusManager.Instance.FocusedViewActivated = OnFocusedViewActivated; " +
            "private void OnFocusedViewActivated(object source, FocusManager.FocusedViewActivatedEventArgs arg)" +
            "{...}")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public class FocusedViewEnterKeyEventArgs : EventArgs
        {
            private View view;

            /// <summary>
            /// View.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
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

        private class CustomAlgorithmInterfaceWrapper : CustomAlgorithmInterface
        {
            private FocusManager.ICustomFocusAlgorithm customFocusAlgorithm;

            public CustomAlgorithmInterfaceWrapper()
            {
            }

            public void SetFocusAlgorithm(FocusManager.ICustomFocusAlgorithm customFocusAlgorithm)
            {
                this.customFocusAlgorithm = customFocusAlgorithm;
            }

            public override View GetNextFocusableView(View current, View proposed, View.FocusDirection direction)
            {
                if (customFocusAlgorithm == null)
                {
                    Tizen.Log.Error("NUI", $"[ERROR] User defined ICustomFocusAlgorithm interface class becomes unreachable. Null will be proposed for next focusing!");
                    return null;
                }
                return customFocusAlgorithm.GetNextFocusableView(current, proposed, direction);
            }
        }
    }
}
