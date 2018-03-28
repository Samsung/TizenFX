/*
 * Copyright(c) 2017 Samsung Electronics Co., Ltd.
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
using System.Runtime.InteropServices;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.UIComponents
{
    /// <summary>
    /// The Popup widget provides a configurable popup dialog with a built-in layout of three main fields.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Popup : View
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal Popup(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.Popup_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Popup obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <param name="type">The dispose type</param>
        /// <since_tizen> 3 </since_tizen>
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
            if (this != null)
            {
                if (_popUpHiddenEventCallbackDelegate != null)
                {
                    HiddenSignal().Disconnect(_popUpHiddenEventCallbackDelegate);
                }

                if (_popUpHidingEventCallbackDelegate != null)
                {
                    HidingSignal().Disconnect(_popUpHidingEventCallbackDelegate);
                }
            }

            if (_popUpShownEventCallbackDelegate != null)
            {
                ShownSignal().Disconnect(_popUpShownEventCallbackDelegate);
            }

            if (_popUpShowingEventCallbackDelegate != null)
            {
                ShowingSignal().Disconnect(_popUpShowingEventCallbackDelegate);
            }

            if (_popUpOutsideTouchedEventCallbackDelegate != null)
            {
                this.OutsideTouchedSignal().Disconnect(_popUpOutsideTouchedEventCallbackDelegate);
            }

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    NDalicPINVOKE.delete_Popup(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }




        /// <summary>
        /// Event arguments that passed via the OutsideTouchedEvent.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class TouchedOutsideEventArgs : EventArgs
        {
        }

        /// <summary>
        /// Event arguments that passed via the ShowingEventArgs.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class ShowingEventArgs : EventArgs
        {
        }

        /// <summary>
        /// Event arguments that passed via the ShownEventArgs.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class ShownEventArgs : EventArgs
        {
        }

        /// <summary>
        /// Event arguments that passed via the HidingEventArgs.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class HidingEventArgs : EventArgs
        {
        }

        /// <summary>
        /// Event arguments that passed via the HiddenEventArgs.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class HiddenEventArgs : EventArgs
        {
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void OutsideTouchedEventCallbackDelegate();
        private EventHandler<TouchedOutsideEventArgs> _popUpOutsideTouchedEventHandler;
        private OutsideTouchedEventCallbackDelegate _popUpOutsideTouchedEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void ShowingEventCallbackDelegate();
        private EventHandler<ShowingEventArgs> _popUpShowingEventHandler;
        private ShowingEventCallbackDelegate _popUpShowingEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void ShownEventCallbackDelegate();
        private EventHandler<ShownEventArgs> _popUpShownEventHandler;
        private ShownEventCallbackDelegate _popUpShownEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void HidingEventCallbackDelegate();
        private EventHandler<HidingEventArgs> _popUpHidingEventHandler;
        private HidingEventCallbackDelegate _popUpHidingEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void HiddenEventCallbackDelegate();
        private EventHandler<HiddenEventArgs> _popUpHiddenEventHandler;
        private HiddenEventCallbackDelegate _popUpHiddenEventCallbackDelegate;

        /// <summary>
        /// An event is sent when the user has touched outside the dialog.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<TouchedOutsideEventArgs> TouchedOutside
        {
            add
            {
                if (_popUpOutsideTouchedEventHandler == null)
                {
                    _popUpOutsideTouchedEventCallbackDelegate = (OnOutsideTouched);
                    OutsideTouchedSignal().Connect(_popUpOutsideTouchedEventCallbackDelegate);
                }
                _popUpOutsideTouchedEventHandler += value;
            }
            remove
            {
                _popUpOutsideTouchedEventHandler -= value;
                if (_popUpOutsideTouchedEventHandler == null && OutsideTouchedSignal().Empty() == false)
                {
                    this.OutsideTouchedSignal().Disconnect(_popUpOutsideTouchedEventCallbackDelegate);
                }
            }
        }

        // Callback for Popup OutsideTouchedSignal
        private void OnOutsideTouched()
        {
            TouchedOutsideEventArgs e = new TouchedOutsideEventArgs();

            if (_popUpOutsideTouchedEventHandler != null)
            {
                //here we send all data to user event handlers
                _popUpOutsideTouchedEventHandler(this, e);
            }
        }

        /// <summary>
        /// An event is sent when the popup starts showing.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<ShowingEventArgs> Showing
        {
            add
            {
                if (_popUpShowingEventHandler == null)
                {
                    _popUpShowingEventCallbackDelegate = (OnShowing);
                    ShowingSignal().Connect(_popUpShowingEventCallbackDelegate);
                }
                _popUpShowingEventHandler += value;
            }
            remove
            {
                _popUpShowingEventHandler -= value;
                if (_popUpShowingEventHandler == null && ShowingSignal().Empty() == false)
                {
                    ShowingSignal().Disconnect(_popUpShowingEventCallbackDelegate);
                }
            }
        }

        // Callback for ShowingSignal
        private void OnShowing()
        {
            ShowingEventArgs e = new ShowingEventArgs();

            if (_popUpShowingEventHandler != null)
            {
                //here we send all data to user event handlers
                _popUpShowingEventHandler(this, e);
            }
        }


        /// <summary>
        /// An event is sent when the popup has been fully displayed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<ShownEventArgs> Shown
        {
            add
            {
                if (_popUpShownEventHandler == null)
                {
                    _popUpShownEventCallbackDelegate = (OnShown);
                    ShownSignal().Connect(_popUpShownEventCallbackDelegate);
                }
                _popUpShownEventHandler += value;
            }
            remove
            {
                _popUpShownEventHandler -= value;
                if (_popUpShownEventHandler == null && ShownSignal().Empty() == false)
                {
                    ShownSignal().Disconnect(_popUpShownEventCallbackDelegate);
                }
            }
        }

        // Callback for ShownSignal
        private void OnShown()
        {
            ShownEventArgs e = new ShownEventArgs();

            if (_popUpShownEventHandler != null)
            {
                //here we send all data to user event handlers
                _popUpShownEventHandler(this, e);
            }
        }

        /// <summary>
        /// An event is sent when the popup starts to hide.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<HidingEventArgs> Hiding
        {
            add
            {
                if (_popUpHidingEventHandler == null)
                {
                    _popUpHidingEventCallbackDelegate = (OnHiding);
                    HidingSignal().Connect(_popUpHidingEventCallbackDelegate);
                }
                _popUpHidingEventHandler += value;
            }
            remove
            {
                _popUpHidingEventHandler -= value;
                if (_popUpHidingEventHandler == null && HidingSignal().Empty() == false)
                {
                    HidingSignal().Disconnect(_popUpHidingEventCallbackDelegate);
                }
            }
        }

        // Callback for HidingSignal
        private void OnHiding()
        {
            HidingEventArgs e = new HidingEventArgs();

            if (_popUpHidingEventHandler != null)
            {
                //here we send all data to user event handlers
                _popUpHidingEventHandler(this, e);
            }
        }

        /// <summary>
        /// An event is sent when the popup has been completely hidden.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<HiddenEventArgs> Hidden
        {
            add
            {
                if (_popUpHiddenEventHandler == null)
                {
                    _popUpHiddenEventCallbackDelegate = (OnHidden);
                    HiddenSignal().Connect(_popUpHiddenEventCallbackDelegate);
                }
                _popUpHiddenEventHandler += value;
            }
            remove
            {
                _popUpHiddenEventHandler -= value;
                if (_popUpHiddenEventHandler == null && HiddenSignal().Empty() == false)
                {
                    HiddenSignal().Disconnect(_popUpHiddenEventCallbackDelegate);
                }
            }
        }

        // Callback for HiddenSignal
        private void OnHidden()
        {
            HiddenEventArgs e = new HiddenEventArgs();

            if (_popUpHiddenEventHandler != null)
            {
                //here we send all data to user event handlers
                _popUpHiddenEventHandler(this, e);
            }
        }

        internal new class Property
        {
            internal static readonly int TITLE = NDalicPINVOKE.Popup_Property_TITLE_get();
            internal static readonly int CONTENT = NDalicPINVOKE.Popup_Property_CONTENT_get();
            internal static readonly int FOOTER = NDalicPINVOKE.Popup_Property_FOOTER_get();
            internal static readonly int DISPLAY_STATE = NDalicPINVOKE.Popup_Property_DISPLAY_STATE_get();
            internal static readonly int TOUCH_TRANSPARENT = NDalicPINVOKE.Popup_Property_TOUCH_TRANSPARENT_get();
            internal static readonly int TAIL_VISIBILITY = NDalicPINVOKE.Popup_Property_TAIL_VISIBILITY_get();
            internal static readonly int TAIL_POSITION = NDalicPINVOKE.Popup_Property_TAIL_POSITION_get();
            internal static readonly int CONTEXTUAL_MODE = NDalicPINVOKE.Popup_Property_CONTEXTUAL_MODE_get();
            internal static readonly int ANIMATION_DURATION = NDalicPINVOKE.Popup_Property_ANIMATION_DURATION_get();
            internal static readonly int ANIMATION_MODE = NDalicPINVOKE.Popup_Property_ANIMATION_MODE_get();
            internal static readonly int ENTRY_ANIMATION = NDalicPINVOKE.Popup_Property_ENTRY_ANIMATION_get();
            internal static readonly int EXIT_ANIMATION = NDalicPINVOKE.Popup_Property_EXIT_ANIMATION_get();
            internal static readonly int AUTO_HIDE_DELAY = NDalicPINVOKE.Popup_Property_AUTO_HIDE_DELAY_get();
            internal static readonly int BACKING_ENABLED = NDalicPINVOKE.Popup_Property_BACKING_ENABLED_get();
            internal static readonly int BACKING_COLOR = NDalicPINVOKE.Popup_Property_BACKING_COLOR_get();
            internal static readonly int POPUP_BACKGROUND_IMAGE = NDalicPINVOKE.Popup_Property_POPUP_BACKGROUND_IMAGE_get();
            internal static readonly int POPUP_BACKGROUND_BORDER = NDalicPINVOKE.Popup_Property_POPUP_BACKGROUND_BORDER_get();
            internal static readonly int TAIL_UP_IMAGE = NDalicPINVOKE.Popup_Property_TAIL_UP_IMAGE_get();
            internal static readonly int TAIL_DOWN_IMAGE = NDalicPINVOKE.Popup_Property_TAIL_DOWN_IMAGE_get();
            internal static readonly int TAIL_LEFT_IMAGE = NDalicPINVOKE.Popup_Property_TAIL_LEFT_IMAGE_get();
            internal static readonly int TAIL_RIGHT_IMAGE = NDalicPINVOKE.Popup_Property_TAIL_RIGHT_IMAGE_get();
        }

        /// <summary>
        /// Creates the popup.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Popup() : this(NDalicPINVOKE.Popup_New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        /// <summary>
        /// Sets the title for this popup.
        /// </summary>
        /// <param name="titleView">The actor to set the title.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetTitle(View titleView)
        {
            NDalicPINVOKE.Popup_SetTitle(swigCPtr, View.getCPtr(titleView));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal View GetTitle()
        {
            //to fix memory leak issue, match the handle count with native side.
            IntPtr cPtr = NDalicPINVOKE.Popup_GetTitle(swigCPtr);
            HandleRef CPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            View ret = Registry.GetManagedBaseHandleFromNativePtr(CPtr.Handle) as View;
            NDalicPINVOKE.delete_BaseHandle(CPtr);
            CPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the content actor.
        /// </summary>
        /// <param name="content">The actor to use.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetContent(View content)
        {
            NDalicPINVOKE.Popup_SetContent(swigCPtr, View.getCPtr(content));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal View GetContent()
        {
            //to fix memory leak issue, match the handle count with native side.
            IntPtr cPtr = NDalicPINVOKE.Popup_GetContent(swigCPtr);
            HandleRef CPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            View ret = Registry.GetManagedBaseHandleFromNativePtr(CPtr.Handle) as View;
            NDalicPINVOKE.delete_BaseHandle(CPtr);
            CPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the actor to use for the footer in this popup.
        /// </summary>
        /// <param name="footer">The footer actor to be added to this popup.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetFooter(View footer)
        {
            NDalicPINVOKE.Popup_SetFooter(swigCPtr, View.getCPtr(footer));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal View GetFooter()
        {
            //to fix memory leak issue, match the handle count with native side.
            IntPtr cPtr = NDalicPINVOKE.Popup_GetFooter(swigCPtr);
            HandleRef CPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            View ret = Registry.GetManagedBaseHandleFromNativePtr(CPtr.Handle) as View;
            NDalicPINVOKE.delete_BaseHandle(CPtr);
            CPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the display state of popup.<br />
        /// There are 4 total display states.<br />
        /// Only 2 can be set, but all four can be read for better inspection of the current popup state.<br />
        /// <br />
        /// The other two states are getable, but not setable, and are there for consistency.<br />
        /// <br />
        /// | Value    | Setting the state              | Getting the state              |<br />
        /// |----------|--------------------------------|--------------------------------|<br />
        /// | SHOWN    | Show the popup                 | The popup is fully shown       |<br />
        /// | HIDDEN   | Hide the popup                 | The popup is fully hidden      |<br />
        /// | SHOWING  |                                | The popup is transitioning in  |<br />
        /// | HIDING   |                                | The popup is transitioning out |<br />
        /// <br />
        /// All 4 states changes cause notifications via 4 respective signals that can be connected to.<br />
        /// </summary>
        /// <param name="displayState">The desired display state to change to.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetDisplayState(Popup.DisplayStateType displayState)
        {
            NDalicPINVOKE.Popup_SetDisplayState(swigCPtr, (int)displayState);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Popup.DisplayStateType GetDisplayState()
        {
            Popup.DisplayStateType ret = (Popup.DisplayStateType)NDalicPINVOKE.Popup_GetDisplayState(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal VoidSignal OutsideTouchedSignal()
        {
            VoidSignal ret = new VoidSignal(NDalicPINVOKE.Popup_OutsideTouchedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal VoidSignal ShowingSignal()
        {
            VoidSignal ret = new VoidSignal(NDalicPINVOKE.Popup_ShowingSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal VoidSignal ShownSignal()
        {
            VoidSignal ret = new VoidSignal(NDalicPINVOKE.Popup_ShownSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal VoidSignal HidingSignal()
        {
            VoidSignal ret = new VoidSignal(NDalicPINVOKE.Popup_HidingSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal VoidSignal HiddenSignal()
        {
            VoidSignal ret = new VoidSignal(NDalicPINVOKE.Popup_HiddenSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// The display states of the popup.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum DisplayStateType
        {
            /// <summary>
            /// The popup is transitioning in
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Showing,
            /// <summary>
            /// The popup is fully shown
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Shown,
            /// <summary>
            /// The popup is transitioning out
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Hiding,
            /// <summary>
            /// The popup is fully hidden
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Hidden
        }

        /// <summary>
        /// The animation modes within the popup.<br />
        /// Choose from a predefined mode or "CUSTOM" to use the ANIMATION_IN and ANIMATION_OUT properties.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum AnimationModeType
        {
            /// <summary>
            /// No animation.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            None,
            /// <summary>
            /// Popup zooms in and out animating the scale property.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Zoom,
            /// <summary>
            /// Popup fades in and out
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Fade,
            /// <summary>
            /// Use the EntryAnimation and ExitAnimation animation properties.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Custom
        }

        /// <summary>
        /// The types of the contextual layout.<br />
        /// The popup is positioned adjacent to it's parent in the direction specified by this mode.<br />
        /// NON_CONTEXTUAL disables any contextual positioning.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum ContextualModeType
        {
            /// <summary>
            /// any contextual positioning
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            NonContextual,
            /// <summary>
            /// Above
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Above,
            /// <summary>
            /// Rright
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Rright,
            /// <summary>
            /// Below
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Below,
            /// <summary>
            /// Left
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Left
        }

        /// <summary>
        /// The popup title.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap Title
        {
            get
            {
                PropertyMap temp = new PropertyMap();
                GetProperty(Popup.Property.TITLE).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(Popup.Property.TITLE, new Tizen.NUI.PropertyValue(value));
            }
        }
        /// <summary>
        /// The popup content.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap Content
        {
            get
            {
                PropertyMap temp = new PropertyMap();
                GetProperty(Popup.Property.CONTENT).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(Popup.Property.CONTENT, new Tizen.NUI.PropertyValue(value));
            }
        }
        /// <summary>
        /// The popup footer.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap Footer
        {
            get
            {
                PropertyMap temp = new PropertyMap();
                GetProperty(Popup.Property.FOOTER).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(Popup.Property.FOOTER, new Tizen.NUI.PropertyValue(value));
            }
        }
        /// <summary>
        /// The popup display state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public DisplayStateType DisplayState
        {
            get
            {
                string temp;
                if (GetProperty(Popup.Property.DISPLAY_STATE).Get(out temp) == false)
                {
                    NUILog.Error("DisplayState get error!");
                }
                switch (temp)
                {
                    case "SHOWING":
                        return DisplayStateType.Showing;
                    case "SHOWN":
                        return DisplayStateType.Shown;
                    case "HIDING":
                        return DisplayStateType.Hiding;
                    case "HIDDEN":
                        return DisplayStateType.Hidden;
                    default:
                        return DisplayStateType.Hidden;
                }
            }
            set
            {
                string valueToString = "";
                switch (value)
                {
                    case DisplayStateType.Showing:
                        {
                            valueToString = "SHOWING";
                            break;
                        }
                    case DisplayStateType.Shown:
                        {
                            valueToString = "SHOWN";
                            break;
                        }
                    case DisplayStateType.Hiding:
                        {
                            valueToString = "HIDING";
                            break;
                        }
                    case DisplayStateType.Hidden:
                        {
                            valueToString = "HIDDEN";
                            break;
                        }
                    default:
                        {
                            valueToString = "HIDDEN";
                            break;
                        }
                }
                SetProperty(Popup.Property.DISPLAY_STATE, new Tizen.NUI.PropertyValue(valueToString));
            }
        }
        /// <summary>
        /// The touch transparent.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool TouchTransparent
        {
            get
            {
                bool temp = false;
                GetProperty(Popup.Property.TOUCH_TRANSPARENT).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Popup.Property.TOUCH_TRANSPARENT, new Tizen.NUI.PropertyValue(value));
            }
        }
        /// <summary>
        /// The popup tail visibility.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool TailVisibility
        {
            get
            {
                bool temp = false;
                GetProperty(Popup.Property.TAIL_VISIBILITY).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Popup.Property.TAIL_VISIBILITY, new Tizen.NUI.PropertyValue(value));
            }
        }
        /// <summary>
        /// The popup tail position.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector3 TailPosition
        {
            get
            {
                Vector3 temp = new Vector3(0.0f, 0.0f, 0.0f);
                GetProperty(Popup.Property.TAIL_POSITION).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(Popup.Property.TAIL_POSITION, new Tizen.NUI.PropertyValue(value));
            }
        }
        /// <summary>
        /// The contextual mode.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ContextualModeType ContextualMode
        {
            get
            {
                string temp;
                if (GetProperty(Popup.Property.CONTEXTUAL_MODE).Get(out temp) == false)
                {
                    NUILog.Error("ContextualMode get error!");
                }
                switch (temp)
                {
                    case "NON_CONTEXTUAL":
                        return ContextualModeType.NonContextual;
                    case "ABOVE":
                        return ContextualModeType.Above;
                    case "RIGHT":
                        return ContextualModeType.Rright;
                    case "BELOW":
                        return ContextualModeType.Below;
                    case "LEFT":
                        return ContextualModeType.Left;
                    default:
                        return ContextualModeType.Below;
                }
            }
            set
            {
                string valueToString = "";
                switch (value)
                {
                    case ContextualModeType.NonContextual:
                        {
                            valueToString = "NON_CONTEXTUAL";
                            break;
                        }
                    case ContextualModeType.Above:
                        {
                            valueToString = "ABOVE";
                            break;
                        }
                    case ContextualModeType.Rright:
                        {
                            valueToString = "RIGHT";
                            break;
                        }
                    case ContextualModeType.Below:
                        {
                            valueToString = "BELOW";
                            break;
                        }
                    case ContextualModeType.Left:
                        {
                            valueToString = "LEFT";
                            break;
                        }
                    default:
                        {
                            valueToString = "BELOW";
                            break;
                        }
                }
                SetProperty(Popup.Property.CONTEXTUAL_MODE, new Tizen.NUI.PropertyValue(valueToString));
            }
        }
        /// <summary>
        /// The animation duration.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float AnimationDuration
        {
            get
            {
                float temp = 0.0f;
                GetProperty(Popup.Property.ANIMATION_DURATION).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Popup.Property.ANIMATION_DURATION, new Tizen.NUI.PropertyValue(value));
            }
        }
        /// <summary>
        /// The animation mode.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public AnimationModeType AnimationMode
        {
            get
            {
                string temp;
                if (GetProperty(Popup.Property.ANIMATION_MODE).Get(out temp) == false)
                {
                    NUILog.Error("AnimationMode get error!");
                }
                switch (temp)
                {
                    case "NONE":
                        return AnimationModeType.None;
                    case "ZOOM":
                        return AnimationModeType.Zoom;
                    case "FADE":
                        return AnimationModeType.Fade;
                    case "CUSTOM":
                        return AnimationModeType.Custom;
                    default:
                        return AnimationModeType.Fade;
                }
            }
            set
            {
                string valueToString = "";
                switch (value)
                {
                    case AnimationModeType.None:
                        {
                            valueToString = "NONE";
                            break;
                        }
                    case AnimationModeType.Zoom:
                        {
                            valueToString = "ZOOM";
                            break;
                        }
                    case AnimationModeType.Fade:
                        {
                            valueToString = "FADE";
                            break;
                        }
                    case AnimationModeType.Custom:
                        {
                            valueToString = "CUSTOM";
                            break;
                        }
                    default:
                        {
                            valueToString = "FADE";
                            break;
                        }
                }
                SetProperty(Popup.Property.ANIMATION_MODE, new Tizen.NUI.PropertyValue(valueToString));
            }
        }
        /// <summary>
        /// The entry animation.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap EntryAnimation
        {
            get
            {
                PropertyMap temp = new PropertyMap();
                GetProperty(Popup.Property.ENTRY_ANIMATION).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(Popup.Property.ENTRY_ANIMATION, new Tizen.NUI.PropertyValue(value));
            }
        }
        /// <summary>
        /// The exit animation.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap ExitAnimation
        {
            get
            {
                PropertyMap temp = new PropertyMap();
                GetProperty(Popup.Property.EXIT_ANIMATION).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(Popup.Property.EXIT_ANIMATION, new Tizen.NUI.PropertyValue(value));
            }
        }
        /// <summary>
        /// The auto hide delay.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int AutoHideDelay
        {
            get
            {
                int temp = 0;
                GetProperty(Popup.Property.AUTO_HIDE_DELAY).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Popup.Property.AUTO_HIDE_DELAY, new Tizen.NUI.PropertyValue(value));
            }
        }
        /// <summary>
        /// The backing enabled.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool BackingEnabled
        {
            get
            {
                bool temp = false;
                GetProperty(Popup.Property.BACKING_ENABLED).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Popup.Property.BACKING_ENABLED, new Tizen.NUI.PropertyValue(value));
            }
        }
        /// <summary>
        /// The backing color.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector4 BackingColor
        {
            get
            {
                Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                GetProperty(Popup.Property.BACKING_COLOR).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(Popup.Property.BACKING_COLOR, new Tizen.NUI.PropertyValue(value));
            }
        }
        /// <summary>
        /// The background image.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string PopupBackgroundImage
        {
            get
            {
                string temp;
                GetProperty(Popup.Property.POPUP_BACKGROUND_IMAGE).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Popup.Property.POPUP_BACKGROUND_IMAGE, new Tizen.NUI.PropertyValue(value));
            }
        }
        /// <summary>
        /// The background border.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Rectangle PopupBackgroundBorder
        {
            get
            {
                Rectangle temp = new Rectangle(0, 0, 0, 0);
                GetProperty(Popup.Property.POPUP_BACKGROUND_BORDER).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(Popup.Property.POPUP_BACKGROUND_BORDER, new Tizen.NUI.PropertyValue(value));
            }
        }
        /// <summary>
        /// The tail up image.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string TailUpImage
        {
            get
            {
                string temp;
                GetProperty(Popup.Property.TAIL_UP_IMAGE).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Popup.Property.TAIL_UP_IMAGE, new Tizen.NUI.PropertyValue(value));
            }
        }
        /// <summary>
        /// The tail down image.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string TailDownImage
        {
            get
            {
                string temp;
                GetProperty(Popup.Property.TAIL_DOWN_IMAGE).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Popup.Property.TAIL_DOWN_IMAGE, new Tizen.NUI.PropertyValue(value));
            }
        }
        /// <summary>
        /// The tail left image.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string TailLeftImage
        {
            get
            {
                string temp;
                GetProperty(Popup.Property.TAIL_LEFT_IMAGE).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Popup.Property.TAIL_LEFT_IMAGE, new Tizen.NUI.PropertyValue(value));
            }
        }
        /// <summary>
        /// The tail right image.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string TailRightImage
        {
            get
            {
                string temp;
                GetProperty(Popup.Property.TAIL_RIGHT_IMAGE).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(Popup.Property.TAIL_RIGHT_IMAGE, new Tizen.NUI.PropertyValue(value));
            }
        }

    }

}