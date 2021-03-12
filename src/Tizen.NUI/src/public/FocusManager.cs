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
        private CustomAlgorithmInterfaceWrapper _customAlgorithmInterfaceWrapper;

        private EventHandlerWithReturnType<object, PreFocusChangeEventArgs, View> _preFocusChangeEventHandler;
        private PreFocusChangeEventCallback _preFocusChangeCallback;

        private EventHandler<FocusChangedEventArgs> _focusChangedEventHandler;
        private FocusChangedEventCallback _focusChangedEventCallback;

        private EventHandler<FocusGroupChangedEventArgs> _focusGroupChangedEventHandler;
        private FocusGroupChangedEventCallback _focusGroupChangedEventCallback;

        private EventHandler<FocusedViewActivatedEventArgs> _focusedViewEnterKeyEventHandler;
        private FocusedViewEnterKeyEventCallback _focusedViewEnterKeyEventCallback;

        private EventHandler<FocusedViewActivatedEventArgs> _focusedViewEnterKeyEventHandler2;
        private FocusedViewEnterKeyEventCallback2 _focusedViewEnterKeyEventCallback2;

        internal FocusManager(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.FocusManager.FocusManager_SWIGUpcast(cPtr), cMemoryOwn)
        {
        }

        internal FocusManager() : this(Interop.FocusManager.new_FocusManager(), true)
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
                if (_preFocusChangeEventHandler == null)
                {
                    _preFocusChangeCallback = OnPreFocusChange;
                    PreFocusChangeSignal().Connect(_preFocusChangeCallback);
                }
                _preFocusChangeEventHandler += value;
            }
            remove
            {
                _preFocusChangeEventHandler -= value;
                if (_preFocusChangeEventHandler == null && PreFocusChangeSignal().Empty() == false)
                {
                    PreFocusChangeSignal().Disconnect(_preFocusChangeCallback);
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
                if (_focusChangedEventCallback == null)
                {
                    _focusChangedEventCallback = OnFocusChanged;
                    FocusChangedSignal().Connect(_focusChangedEventCallback);
                }
                _focusChangedEventHandler += value;
            }
            remove
            {
                _focusChangedEventHandler -= value;

                if (_focusChangedEventCallback == null && FocusChangedSignal().Empty() == false)
                {
                    FocusChangedSignal().Disconnect(_focusChangedEventCallback);
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
                if (_focusGroupChangedEventCallback == null)
                {
                    _focusGroupChangedEventCallback = OnFocusGroupChanged;
                    FocusGroupChangedSignal().Connect(_focusGroupChangedEventCallback);
                }
                _focusGroupChangedEventHandler += value;
            }
            remove
            {
                _focusGroupChangedEventHandler -= value;

                if (_focusGroupChangedEventCallback == null && FocusGroupChangedSignal().Empty() == false)
                {
                    FocusGroupChangedSignal().Disconnect(_focusGroupChangedEventCallback);
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
                if (_focusedViewEnterKeyEventCallback == null)
                {
                    _focusedViewEnterKeyEventCallback = OnFocusedViewEnterKey;
                    FocusedViewEnterKeySignal().Connect(_focusedViewEnterKeyEventCallback);
                }
                _focusedViewEnterKeyEventHandler += value;
            }
            remove
            {
                _focusedViewEnterKeyEventHandler -= value;

                if (_focusedViewEnterKeyEventCallback != null && FocusedViewEnterKeySignal().Empty() == false)
                {
                    FocusedViewEnterKeySignal().Disconnect(_focusedViewEnterKeyEventCallback);
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
                if (_focusedViewEnterKeyEventCallback2 == null)
                {
                    _focusedViewEnterKeyEventCallback2 = OnFocusedViewEnterKey2;
                    FocusedViewEnterKeySignal().Connect(_focusedViewEnterKeyEventCallback2);
                }
                _focusedViewEnterKeyEventHandler2 += value;
            }
            remove
            {
                _focusedViewEnterKeyEventHandler2 -= value;

                if (_focusedViewEnterKeyEventCallback2 != null && FocusedViewEnterKeySignal().Empty() == false)
                {
                    FocusedViewEnterKeySignal().Disconnect(_focusedViewEnterKeyEventCallback2);
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
                throw new ArgumentNullException("the target view should not be null");
            }

            bool ret = Interop.FocusManager.FocusManager_SetCurrentFocusActor(swigCPtr, View.getCPtr(view));
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
            IntPtr cPtr = Interop.FocusManager.FocusManager_GetCurrentFocusActor(swigCPtr);
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
            bool ret = Interop.FocusManager.FocusManager_MoveFocus(swigCPtr, (int)direction);
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
            Interop.FocusManager.FocusManager_ClearFocus(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Move the focus to previous focused view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void MoveFocusBackward()
        {
            Interop.FocusManager.FocusManager_MoveFocusBackward(swigCPtr);
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
            Interop.FocusManager.FocusManager_SetAsFocusGroup(swigCPtr, View.getCPtr(view), isFocusGroup);
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
            bool ret = Interop.FocusManager.FocusManager_IsFocusGroup(swigCPtr, View.getCPtr(view));
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
            IntPtr cPtr = Interop.FocusManager.FocusManager_GetFocusGroup(swigCPtr, View.getCPtr(view));
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
            if(arg0 != null)
            {
                _customAlgorithmInterfaceWrapper = new CustomAlgorithmInterfaceWrapper();
                _customAlgorithmInterfaceWrapper.SetFocusAlgorithm(arg0);

                Interop.NDalic.SetCustomAlgorithm(swigCPtr, CustomAlgorithmInterface.getCPtr(_customAlgorithmInterfaceWrapper));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            else
            {
                Interop.NDalic.SetCustomAlgorithm(swigCPtr, new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Sets to use the automatic focus moveing algorithm. <br />
        /// It moves the focus to the view closest to the keyboard movement direction.
        /// </summary>
        /// <param name="enable">Whether using default focus algorithm or not</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void EnableDefaultAlgorithm(bool enable)
        {
            Interop.FocusManager.EnableDefaultAlgorithm(SwigCPtr, enable);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        ///  Checks default focus moveing algorithm is enabled or not
        /// </summary>
        /// <returns>Whether default focus algorithm is enabled</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsDefaultAlgorithmEnabled()
        {
            bool ret = Interop.FocusManager.IsDefaultAlgorithmEnabled(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static FocusManager Get()
        {
            FocusManager ret = new FocusManager(Interop.FocusManager.FocusManager_Get(), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetFocusGroupLoop(bool enabled)
        {
            Interop.FocusManager.FocusManager_SetFocusGroupLoop(swigCPtr, enabled);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal bool GetFocusGroupLoop()
        {
            bool ret = Interop.FocusManager.FocusManager_GetFocusGroupLoop(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetFocusIndicatorView(View indicator)
        {
            Interop.FocusManager.FocusManager_SetFocusIndicatorActor(swigCPtr, View.getCPtr(indicator));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal View GetFocusIndicatorView()
        {
            //to fix memory leak issue, match the handle count with native side.
            IntPtr cPtr = Interop.FocusManager.FocusManager_GetFocusIndicatorActor(swigCPtr);
            View ret = this.GetInstanceSafely<View>(cPtr);
            return ret;
        }

        internal PreFocusChangeSignal PreFocusChangeSignal()
        {
            PreFocusChangeSignal ret = new PreFocusChangeSignal(Interop.FocusManager.FocusManager_PreFocusChangeSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal FocusChangedSignal FocusChangedSignal()
        {
            FocusChangedSignal ret = new FocusChangedSignal(Interop.FocusManager.FocusManager_FocusChangedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal FocusGroupChangedSignal FocusGroupChangedSignal()
        {
            FocusGroupChangedSignal ret = new FocusGroupChangedSignal(Interop.FocusManager.FocusManager_FocusGroupChangedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ViewSignal FocusedViewEnterKeySignal()
        {
            ViewSignal ret = new ViewSignal(Interop.FocusManager.FocusManager_FocusedActorEnterKeySignal(swigCPtr), false);
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

            if (_preFocusChangeEventHandler != null)
            {
                view = _preFocusChangeEventHandler(this, e);
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
            FocusChangedEventArgs e = new FocusChangedEventArgs();

            e.CurrentView = Registry.GetManagedBaseHandleFromNativePtr(current) as View;
            e.NextView = Registry.GetManagedBaseHandleFromNativePtr(next) as View;

            if (_focusChangedEventHandler != null)
            {
                _focusChangedEventHandler(this, e);
            }
        }

        private void OnFocusGroupChanged(IntPtr current, bool forwardDirection)
        {
            FocusGroupChangedEventArgs e = new FocusGroupChangedEventArgs();

            e.CurrentView = Registry.GetManagedBaseHandleFromNativePtr(current) as View;
            e.ForwardDirection = forwardDirection;

            if (_focusGroupChangedEventHandler != null)
            {
                _focusGroupChangedEventHandler(this, e);
            }
        }

        private void OnFocusedViewEnterKey(IntPtr view)
        {
            FocusedViewActivatedEventArgs e = new FocusedViewActivatedEventArgs();

            e.View = Registry.GetManagedBaseHandleFromNativePtr(view) as View;

            if (_focusedViewEnterKeyEventHandler != null)
            {
                _focusedViewEnterKeyEventHandler(this, e);
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
            FocusedViewActivatedEventArgs e = new FocusedViewActivatedEventArgs();

            e.View = Registry.GetManagedBaseHandleFromNativePtr(view) as View;

            if (_focusedViewEnterKeyEventHandler != null)
            {
                _focusedViewEnterKeyEventHandler(this, e);
            }
        }

        ///<summary>
        /// Event arguments that passed via the PreFocusChange signal.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class PreFocusChangeEventArgs : EventArgs
        {
            private View _current;
            private View _proposed;
            private View.FocusDirection _direction;

            /// <summary>
            /// The current focus view.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public View CurrentView
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

            /// <summary>
            /// The  proposed view.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public View ProposedView
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

            /// <summary>
            /// The focus move direction.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public View.FocusDirection Direction
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

        ///<summary>
        /// Event arguments that passed via the FocusChanged signal.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class FocusChangedEventArgs : EventArgs
        {
            private View _current;
            private View _next;

            /// <summary>
            /// The current focus view.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public View CurrentView
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
            /// <summary>
            /// The next focus view.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public View NextView
            {
                get
                {
                    return _next;
                }
                set
                {
                    _next = value;
                }
            }
        }

        ///<summary>
        /// Event arguments that passed via the FocusGroupChanged signal.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class FocusGroupChangedEventArgs : EventArgs
        {
            private View _current;
            private bool _forwardDirection;

            /// <summary>
            /// The current focus view.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public View CurrentView
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

            /// <summary>
            /// The forward direction.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
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

        ///<summary>
        /// Event arguments that passed via the FocusedViewEnterKey signal.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class FocusedViewActivatedEventArgs : EventArgs
        {
            private View _view;

            /// <summary>
            /// View.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
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
        public class FocusedViewEnterKeyEventArgs : EventArgs
        {
            private View _view;

            /// <summary>
            /// View.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
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

            public override View GetNextFocusableView(View current, View proposed, View.FocusDirection direction)
            {
                if(_customFocusAlgorithm == null)
                {
                    Tizen.Log.Error("NUI", $"[ERROR] User defined ICustomFocusAlgorithm interface class becomes unreachable. Null will be proposed for next focusing!");
                    return null;
                }
                return _customFocusAlgorithm.GetNextFocusableView(current, proposed, direction);
            }
        }


    }
}
