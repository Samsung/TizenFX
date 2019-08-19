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
using System.ComponentModel;
using System.Reflection;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{

    internal class ViewImpl : CustomActorImpl
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal ViewImpl(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.ViewImpl.ViewImpl_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ViewImpl obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

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

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    throw new global::System.MethodAccessException("C++ destructor does not have public access");
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }


        public static View New()
        {
            View ret = new View(Interop.ViewImpl.ViewImpl_New(), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetStyleName(string styleName)
        {
            Interop.ViewImpl.ViewImpl_SetStyleName(swigCPtr, styleName);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public string GetStyleName()
        {
            string ret = Interop.ViewImpl.ViewImpl_GetStyleName(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetBackgroundColor(Vector4 color)
        {
            Interop.ViewImpl.ViewImpl_SetBackgroundColor(swigCPtr, Vector4.getCPtr(color));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Vector4 GetBackgroundColor()
        {
            Vector4 ret = new Vector4(Interop.ViewImpl.ViewImpl_GetBackgroundColor(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
        public void SetBackground(PropertyMap map)
        {
            Interop.ViewImpl.ViewImpl_SetBackground(swigCPtr, PropertyMap.getCPtr(map));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void ClearBackground()
        {
            Interop.ViewImpl.ViewImpl_ClearBackground(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void EnableGestureDetection(Gesture.GestureType type)
        {
            Interop.ViewImpl.ViewImpl_EnableGestureDetection(swigCPtr, (int)type);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void DisableGestureDetection(Gesture.GestureType type)
        {
            Interop.ViewImpl.ViewImpl_DisableGestureDetection(swigCPtr, (int)type);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public PinchGestureDetector GetPinchGestureDetector()
        {
            PinchGestureDetector ret = new PinchGestureDetector(Interop.ViewImpl.ViewImpl_GetPinchGestureDetector(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public PanGestureDetector GetPanGestureDetector()
        {
            PanGestureDetector ret = new PanGestureDetector(Interop.ViewImpl.ViewImpl_GetPanGestureDetector(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public TapGestureDetector GetTapGestureDetector()
        {
            TapGestureDetector ret = new TapGestureDetector(Interop.ViewImpl.ViewImpl_GetTapGestureDetector(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public LongPressGestureDetector GetLongPressGestureDetector()
        {
            LongPressGestureDetector ret = new LongPressGestureDetector(Interop.ViewImpl.ViewImpl_GetLongPressGestureDetector(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetKeyboardNavigationSupport(bool isSupported)
        {
            Interop.ViewImpl.ViewImpl_SetKeyboardNavigationSupport(swigCPtr, isSupported);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool IsKeyboardNavigationSupported()
        {
            bool ret = Interop.ViewImpl.ViewImpl_IsKeyboardNavigationSupported(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetKeyInputFocus()
        {
            Interop.ViewImpl.ViewImpl_SetKeyInputFocus(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool HasKeyInputFocus()
        {
            bool ret = Interop.ViewImpl.ViewImpl_HasKeyInputFocus(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void ClearKeyInputFocus()
        {
            Interop.ViewImpl.ViewImpl_ClearKeyInputFocus(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetAsFocusGroup(bool isFocusGroup)
        {
            Interop.ViewImpl.ViewImpl_SetAsKeyboardFocusGroup(swigCPtr, isFocusGroup);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool IsFocusGroup()
        {
            bool ret = Interop.ViewImpl.ViewImpl_IsKeyboardFocusGroup(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// [Obsolete("Please do not use! this will be deprecated")]
        /// </summary>
        /// Please do not use! this will be deprecated!
        /// <since_tizen> 5 </since_tizen>
        [Obsolete("Please do not use! this will be deprecated.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AccessibilityActivate()
        {
            Interop.ViewImpl.ViewImpl_AccessibilityActivate(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// [Obsolete("Please do not use! this will be deprecated")]
        /// </summary>
        /// Please do not use! this will be deprecated!
        /// <since_tizen> 5 </since_tizen>
        [Obsolete("Please do not use! this will be deprecated.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void KeyboardEnter()
        {
            Interop.ViewImpl.ViewImpl_KeyboardEnter(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal ControlKeySignal KeyEventSignal()
        {
            ControlKeySignal ret = new ControlKeySignal(Interop.ViewImplSignal.ViewImpl_KeyEventSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal KeyInputFocusSignal KeyInputFocusGainedSignal()
        {
            KeyInputFocusSignal ret = new KeyInputFocusSignal(Interop.ViewImplSignal.ViewImpl_KeyInputFocusGainedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal KeyInputFocusSignal KeyInputFocusLostSignal()
        {
            KeyInputFocusSignal ret = new KeyInputFocusSignal(Interop.ViewImplSignal.ViewImpl_KeyInputFocusLostSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// [Obsolete("Please do not use! this will be deprecated")]
        /// </summary>
        /// Please do not use! this will be deprecated!
        /// <since_tizen> 5 </since_tizen>
        [Obsolete("Please do not use! this will be deprecated.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EmitKeyEventSignal(Key arg0)
        {
            bool ret = Interop.ViewImplSignal.ViewImpl_EmitKeyEventSignal(swigCPtr, Key.getCPtr(arg0));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        protected virtual new void OnStageConnection(int depth)
        {
            if (SwigDerivedClassHasMethod("OnStageConnection", swigMethodTypes0)) Interop.ViewImplSignal.ViewImpl_OnStageConnectionSwigExplicitViewImpl(swigCPtr, depth); else Interop.ViewImplSignal.ViewImpl_OnStageConnection(swigCPtr, depth);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        protected virtual new void OnStageDisconnection()
        {
            if (SwigDerivedClassHasMethod("OnStageDisconnection", swigMethodTypes1)) Interop.ViewImplSignal.ViewImpl_OnStageDisconnectionSwigExplicitViewImpl(swigCPtr); else Interop.ViewImplSignal.ViewImpl_OnStageDisconnection(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        protected virtual new void OnChildAdd(View child)
        {
            if (SwigDerivedClassHasMethod("OnChildAdd", swigMethodTypes2)) Interop.ViewImplSignal.ViewImpl_OnChildAddSwigExplicitViewImpl(swigCPtr, View.getCPtr(child)); else Interop.ViewImplSignal.ViewImpl_OnChildAdd(swigCPtr, View.getCPtr(child));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        protected virtual new void OnChildRemove(View child)
        {
            if (SwigDerivedClassHasMethod("OnChildRemove", swigMethodTypes3)) Interop.ViewImplSignal.ViewImpl_OnChildRemoveSwigExplicitViewImpl(swigCPtr, View.getCPtr(child)); else Interop.ViewImplSignal.ViewImpl_OnChildRemove(swigCPtr, View.getCPtr(child));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        protected virtual new void OnPropertySet(int index, PropertyValue propertyValue)
        {
            if (SwigDerivedClassHasMethod("OnPropertySet", swigMethodTypes4)) Interop.ViewImplSignal.ViewImpl_OnPropertySetSwigExplicitViewImpl(swigCPtr, index, PropertyValue.getCPtr(propertyValue)); else Interop.ViewImplSignal.ViewImpl_OnPropertySet(swigCPtr, index, PropertyValue.getCPtr(propertyValue));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        protected virtual new void OnSizeSet(Vector3 targetSize)
        {
            if (SwigDerivedClassHasMethod("OnSizeSet", swigMethodTypes5)) Interop.ViewImplSignal.ViewImpl_OnSizeSetSwigExplicitViewImpl(swigCPtr, Vector3.getCPtr(targetSize)); else Interop.ViewImplSignal.ViewImpl_OnSizeSet(swigCPtr, Vector3.getCPtr(targetSize));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        protected virtual new void OnSizeAnimation(Animation animation, Vector3 targetSize)
        {
            if (SwigDerivedClassHasMethod("OnSizeAnimation", swigMethodTypes6)) Interop.ViewImplSignal.ViewImpl_OnSizeAnimationSwigExplicitViewImpl(swigCPtr, Animation.getCPtr(animation), Vector3.getCPtr(targetSize)); else Interop.ViewImplSignal.ViewImpl_OnSizeAnimation(swigCPtr, Animation.getCPtr(animation), Vector3.getCPtr(targetSize));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal virtual new bool OnTouchEvent(SWIGTYPE_p_Dali__TouchEvent arg0)
        {
            bool ret = (SwigDerivedClassHasMethod("OnTouchEvent", swigMethodTypes7) ? Interop.ViewImplSignal.ViewImpl_OnTouchEventSwigExplicitViewImpl(swigCPtr, SWIGTYPE_p_Dali__TouchEvent.getCPtr(arg0)) : Interop.ViewImplSignal.ViewImpl_OnTouchEvent(swigCPtr, SWIGTYPE_p_Dali__TouchEvent.getCPtr(arg0)));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        protected virtual new bool OnHoverEvent(Hover arg0)
        {
            bool ret = (SwigDerivedClassHasMethod("OnHoverEvent", swigMethodTypes8) ? Interop.ViewImplSignal.ViewImpl_OnHoverEventSwigExplicitViewImpl(swigCPtr, Hover.getCPtr(arg0)) : Interop.ViewImplSignal.ViewImpl_OnHoverEvent(swigCPtr, Hover.getCPtr(arg0)));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        protected virtual new bool OnKeyEvent(Key arg0)
        {
            bool ret = (SwigDerivedClassHasMethod("OnKeyEvent", swigMethodTypes9) ? Interop.ViewImplSignal.ViewImpl_OnKeyEventSwigExplicitViewImpl(swigCPtr, Key.getCPtr(arg0)) : Interop.ViewImplSignal.ViewImpl_OnKeyEvent(swigCPtr, Key.getCPtr(arg0)));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        protected virtual new bool OnWheelEvent(Wheel arg0)
        {
            bool ret = (SwigDerivedClassHasMethod("OnWheelEvent", swigMethodTypes10) ? Interop.ViewImplSignal.ViewImpl_OnWheelEventSwigExplicitViewImpl(swigCPtr, Wheel.getCPtr(arg0)) : Interop.ViewImplSignal.ViewImpl_OnWheelEvent(swigCPtr, Wheel.getCPtr(arg0)));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        protected virtual new void OnRelayout(Vector2 size, RelayoutContainer container)
        {
            if (SwigDerivedClassHasMethod("OnRelayout", swigMethodTypes11)) Interop.ViewImplSignal.ViewImpl_OnRelayoutSwigExplicitViewImpl(swigCPtr, Vector2.getCPtr(size), RelayoutContainer.getCPtr(container)); else Interop.ViewImplSignal.ViewImpl_OnRelayout(swigCPtr, Vector2.getCPtr(size), RelayoutContainer.getCPtr(container));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        protected virtual new void OnSetResizePolicy(ResizePolicyType policy, DimensionType dimension)
        {
            if (SwigDerivedClassHasMethod("OnSetResizePolicy", swigMethodTypes12)) Interop.ViewImplSignal.ViewImpl_OnSetResizePolicySwigExplicitViewImpl(swigCPtr, (int)policy, (int)dimension); else Interop.ViewImplSignal.ViewImpl_OnSetResizePolicy(swigCPtr, (int)policy, (int)dimension);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        protected virtual new Vector3 GetNaturalSize()
        {
            Vector3 ret = new Vector3((SwigDerivedClassHasMethod("GetNaturalSize", swigMethodTypes13) ? Interop.ViewImpl.ViewImpl_GetNaturalSizeSwigExplicitViewImpl(swigCPtr) : Interop.ViewImpl.ViewImpl_GetNaturalSize(swigCPtr)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        protected virtual new float CalculateChildSize(View child, DimensionType dimension)
        {
            float ret = (SwigDerivedClassHasMethod("CalculateChildSize", swigMethodTypes14) ? Interop.ViewImpl.ViewImpl_CalculateChildSizeSwigExplicitViewImpl(swigCPtr, View.getCPtr(child), (int)dimension) : Interop.ViewImpl.ViewImpl_CalculateChildSize(swigCPtr, View.getCPtr(child), (int)dimension));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        protected virtual new float GetHeightForWidth(float width)
        {
            float ret = (SwigDerivedClassHasMethod("GetHeightForWidth", swigMethodTypes15) ? Interop.ViewImpl.ViewImpl_GetHeightForWidthSwigExplicitViewImpl(swigCPtr, width) : Interop.ViewImpl.ViewImpl_GetHeightForWidth(swigCPtr, width));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        protected virtual new float GetWidthForHeight(float height)
        {
            float ret = (SwigDerivedClassHasMethod("GetWidthForHeight", swigMethodTypes16) ? Interop.ViewImpl.ViewImpl_GetWidthForHeightSwigExplicitViewImpl(swigCPtr, height) : Interop.ViewImpl.ViewImpl_GetWidthForHeight(swigCPtr, height));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        protected virtual new bool RelayoutDependentOnChildren(DimensionType dimension)
        {
            bool ret = (SwigDerivedClassHasMethod("RelayoutDependentOnChildren", swigMethodTypes17) ? Interop.ViewImpl.ViewImpl_RelayoutDependentOnChildrenSwigExplicitViewImpl__SWIG_0(swigCPtr, (int)dimension) : Interop.ViewImpl.ViewImpl_RelayoutDependentOnChildren__SWIG_0(swigCPtr, (int)dimension));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        protected virtual new bool RelayoutDependentOnChildren()
        {
            bool ret = (SwigDerivedClassHasMethod("RelayoutDependentOnChildren", swigMethodTypes18) ? Interop.ViewImpl.ViewImpl_RelayoutDependentOnChildrenSwigExplicitViewImpl__SWIG_1(swigCPtr) : Interop.ViewImpl.ViewImpl_RelayoutDependentOnChildren__SWIG_1(swigCPtr));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        protected virtual new void OnCalculateRelayoutSize(DimensionType dimension)
        {
            if (SwigDerivedClassHasMethod("OnCalculateRelayoutSize", swigMethodTypes19)) Interop.ViewImplSignal.ViewImpl_OnCalculateRelayoutSizeSwigExplicitViewImpl(swigCPtr, (int)dimension); else Interop.ViewImplSignal.ViewImpl_OnCalculateRelayoutSize(swigCPtr, (int)dimension);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        protected virtual new void OnLayoutNegotiated(float size, DimensionType dimension)
        {
            if (SwigDerivedClassHasMethod("OnLayoutNegotiated", swigMethodTypes20)) Interop.ViewImplSignal.ViewImpl_OnLayoutNegotiatedSwigExplicitViewImpl(swigCPtr, size, (int)dimension); else Interop.ViewImplSignal.ViewImpl_OnLayoutNegotiated(swigCPtr, size, (int)dimension);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public virtual void OnInitialize()
        {
            if (SwigDerivedClassHasMethod("OnInitialize", swigMethodTypes21)) Interop.ViewImplSignal.ViewImpl_OnInitializeSwigExplicitViewImpl(swigCPtr); else Interop.ViewImplSignal.ViewImpl_OnInitialize(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public virtual void OnControlChildAdd(View child)
        {
            if (SwigDerivedClassHasMethod("OnControlChildAdd", swigMethodTypes22)) Interop.ViewImplSignal.ViewImpl_OnControlChildAddSwigExplicitViewImpl(swigCPtr, View.getCPtr(child)); else Interop.ViewImplSignal.ViewImpl_OnControlChildAdd(swigCPtr, View.getCPtr(child));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public virtual void OnControlChildRemove(View child)
        {
            if (SwigDerivedClassHasMethod("OnControlChildRemove", swigMethodTypes23)) Interop.ViewImplSignal.ViewImpl_OnControlChildRemoveSwigExplicitViewImpl(swigCPtr, View.getCPtr(child)); else Interop.ViewImplSignal.ViewImpl_OnControlChildRemove(swigCPtr, View.getCPtr(child));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public virtual void OnStyleChange(StyleManager styleManager, StyleChangeType change)
        {
            if (SwigDerivedClassHasMethod("OnStyleChange", swigMethodTypes24)) Interop.ViewImplSignal.ViewImpl_OnStyleChangeSwigExplicitViewImpl(swigCPtr, StyleManager.getCPtr(styleManager), (int)change); else Interop.ViewImplSignal.ViewImpl_OnStyleChange(swigCPtr, StyleManager.getCPtr(styleManager), (int)change);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public virtual bool OnAccessibilityActivated()
        {
            bool ret = (SwigDerivedClassHasMethod("OnAccessibilityActivated", swigMethodTypes25) ? Interop.ViewImplSignal.ViewImpl_OnAccessibilityActivatedSwigExplicitViewImpl(swigCPtr) : Interop.ViewImplSignal.ViewImpl_OnAccessibilityActivated(swigCPtr));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual bool OnAccessibilityPan(PanGesture gesture)
        {
            bool ret = (SwigDerivedClassHasMethod("OnAccessibilityPan", swigMethodTypes26) ? Interop.ViewImplSignal.ViewImpl_OnAccessibilityPanSwigExplicitViewImpl(swigCPtr, PanGesture.getCPtr(gesture)) : Interop.ViewImplSignal.ViewImpl_OnAccessibilityPan(swigCPtr, PanGesture.getCPtr(gesture)));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal virtual bool OnAccessibilityTouch(SWIGTYPE_p_Dali__TouchEvent touchEvent)
        {
            bool ret = (SwigDerivedClassHasMethod("OnAccessibilityTouch", swigMethodTypes27) ? Interop.ViewImplSignal.ViewImpl_OnAccessibilityTouchSwigExplicitViewImpl(swigCPtr, SWIGTYPE_p_Dali__TouchEvent.getCPtr(touchEvent)) : Interop.ViewImplSignal.ViewImpl_OnAccessibilityTouch(swigCPtr, SWIGTYPE_p_Dali__TouchEvent.getCPtr(touchEvent)));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual bool OnAccessibilityValueChange(bool isIncrease)
        {
            bool ret = (SwigDerivedClassHasMethod("OnAccessibilityValueChange", swigMethodTypes28) ? Interop.ViewImplSignal.ViewImpl_OnAccessibilityValueChangeSwigExplicitViewImpl(swigCPtr, isIncrease) : Interop.ViewImplSignal.ViewImpl_OnAccessibilityValueChange(swigCPtr, isIncrease));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual bool OnAccessibilityZoom()
        {
            bool ret = (SwigDerivedClassHasMethod("OnAccessibilityZoom", swigMethodTypes29) ? Interop.ViewImplSignal.ViewImpl_OnAccessibilityZoomSwigExplicitViewImpl(swigCPtr) : Interop.ViewImplSignal.ViewImpl_OnAccessibilityZoom(swigCPtr));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual void OnKeyInputFocusGained()
        {
            if (SwigDerivedClassHasMethod("OnKeyInputFocusGained", swigMethodTypes30)) Interop.ViewImplSignal.ViewImpl_OnKeyInputFocusGainedSwigExplicitViewImpl(swigCPtr); else Interop.ViewImplSignal.ViewImpl_OnKeyInputFocusGained(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public virtual void OnKeyInputFocusLost()
        {
            if (SwigDerivedClassHasMethod("OnKeyInputFocusLost", swigMethodTypes31)) Interop.ViewImplSignal.ViewImpl_OnKeyInputFocusLostSwigExplicitViewImpl(swigCPtr); else Interop.ViewImplSignal.ViewImpl_OnKeyInputFocusLost(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public virtual View GetNextFocusableView(View currentFocusedView, View.FocusDirection direction, bool loopEnabled)
        {
            View ret = new View((SwigDerivedClassHasMethod("GetNextFocusableView", swigMethodTypes32) ? Interop.ViewImpl.ViewImpl_GetNextKeyboardFocusableActorSwigExplicitViewImpl(swigCPtr, View.getCPtr(currentFocusedView), (int)direction, loopEnabled) : Interop.ViewImpl.ViewImpl_GetNextKeyboardFocusableActor(swigCPtr, View.getCPtr(currentFocusedView), (int)direction, loopEnabled)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual void OnFocusChangeCommitted(View commitedFocusableView)
        {
            if (SwigDerivedClassHasMethod("OnFocusChangeCommitted", swigMethodTypes33)) Interop.ViewImplSignal.ViewImpl_OnKeyboardFocusChangeCommittedSwigExplicitViewImpl(swigCPtr, View.getCPtr(commitedFocusableView)); else Interop.ViewImplSignal.ViewImpl_OnKeyboardFocusChangeCommitted(swigCPtr, View.getCPtr(commitedFocusableView));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public virtual bool OnKeyboardEnter()
        {
            bool ret = (SwigDerivedClassHasMethod("OnKeyboardEnter", swigMethodTypes34) ? Interop.ViewImplSignal.ViewImpl_OnKeyboardEnterSwigExplicitViewImpl(swigCPtr) : Interop.ViewImplSignal.ViewImpl_OnKeyboardEnter(swigCPtr));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual void OnPinch(PinchGesture pinch)
        {
            if (SwigDerivedClassHasMethod("OnPinch", swigMethodTypes35)) Interop.ViewImplSignal.ViewImpl_OnPinchSwigExplicitViewImpl(swigCPtr, PinchGesture.getCPtr(pinch)); else Interop.ViewImplSignal.ViewImpl_OnPinch(swigCPtr, PinchGesture.getCPtr(pinch));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public virtual void OnPan(PanGesture pan)
        {
            if (SwigDerivedClassHasMethod("OnPan", swigMethodTypes36)) Interop.ViewImplSignal.ViewImpl_OnPanSwigExplicitViewImpl(swigCPtr, PanGesture.getCPtr(pan)); else Interop.ViewImplSignal.ViewImpl_OnPan(swigCPtr, PanGesture.getCPtr(pan));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public virtual void OnTap(TapGesture tap)
        {
            if (SwigDerivedClassHasMethod("OnTap", swigMethodTypes37)) Interop.ViewImplSignal.ViewImpl_OnTapSwigExplicitViewImpl(swigCPtr, TapGesture.getCPtr(tap)); else Interop.ViewImplSignal.ViewImpl_OnTap(swigCPtr, TapGesture.getCPtr(tap));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public virtual void OnLongPress(LongPressGesture longPress)
        {
            if (SwigDerivedClassHasMethod("OnLongPress", swigMethodTypes38)) Interop.ViewImplSignal.ViewImpl_OnLongPressSwigExplicitViewImpl(swigCPtr, LongPressGesture.getCPtr(longPress)); else Interop.ViewImplSignal.ViewImpl_OnLongPress(swigCPtr, LongPressGesture.getCPtr(longPress));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal virtual void SignalConnected(SlotObserver slotObserver, SWIGTYPE_p_Dali__CallbackBase callback)
        {
            if (SwigDerivedClassHasMethod("SignalConnected", swigMethodTypes39)) Interop.ViewImplSignal.ViewImpl_SignalConnectedSwigExplicitViewImpl(swigCPtr, SlotObserver.getCPtr(slotObserver), SWIGTYPE_p_Dali__CallbackBase.getCPtr(callback)); else Interop.ViewImplSignal.ViewImpl_SignalConnected(swigCPtr, SlotObserver.getCPtr(slotObserver), SWIGTYPE_p_Dali__CallbackBase.getCPtr(callback));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal virtual void SignalDisconnected(SlotObserver slotObserver, SWIGTYPE_p_Dali__CallbackBase callback)
        {
            if (SwigDerivedClassHasMethod("SignalDisconnected", swigMethodTypes40)) Interop.ViewImplSignal.ViewImpl_SignalDisconnectedSwigExplicitViewImpl(swigCPtr, SlotObserver.getCPtr(slotObserver), SWIGTYPE_p_Dali__CallbackBase.getCPtr(callback)); else Interop.ViewImplSignal.ViewImpl_SignalDisconnected(swigCPtr, SlotObserver.getCPtr(slotObserver), SWIGTYPE_p_Dali__CallbackBase.getCPtr(callback));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private void SwigDirectorConnect()
        {
            if (SwigDerivedClassHasMethod("OnStageConnection", swigMethodTypes0))
                swigDelegate0 = new SwigDelegateViewImpl_0(SwigDirectorOnStageConnection);
            if (SwigDerivedClassHasMethod("OnStageDisconnection", swigMethodTypes1))
                swigDelegate1 = new SwigDelegateViewImpl_1(SwigDirectorOnStageDisconnection);
            if (SwigDerivedClassHasMethod("OnChildAdd", swigMethodTypes2))
                swigDelegate2 = new SwigDelegateViewImpl_2(SwigDirectorOnChildAdd);
            if (SwigDerivedClassHasMethod("OnChildRemove", swigMethodTypes3))
                swigDelegate3 = new SwigDelegateViewImpl_3(SwigDirectorOnChildRemove);
            if (SwigDerivedClassHasMethod("OnPropertySet", swigMethodTypes4))
                swigDelegate4 = new SwigDelegateViewImpl_4(SwigDirectorOnPropertySet);
            if (SwigDerivedClassHasMethod("OnSizeSet", swigMethodTypes5))
                swigDelegate5 = new SwigDelegateViewImpl_5(SwigDirectorOnSizeSet);
            if (SwigDerivedClassHasMethod("OnSizeAnimation", swigMethodTypes6))
                swigDelegate6 = new SwigDelegateViewImpl_6(SwigDirectorOnSizeAnimation);
            if (SwigDerivedClassHasMethod("OnTouchEvent", swigMethodTypes7))
                swigDelegate7 = new SwigDelegateViewImpl_7(SwigDirectorOnTouchEvent);
            if (SwigDerivedClassHasMethod("OnHoverEvent", swigMethodTypes8))
                swigDelegate8 = new SwigDelegateViewImpl_8(SwigDirectorOnHoverEvent);
            if (SwigDerivedClassHasMethod("OnKeyEvent", swigMethodTypes9))
                swigDelegate9 = new SwigDelegateViewImpl_9(SwigDirectorOnKeyEvent);
            if (SwigDerivedClassHasMethod("OnWheelEvent", swigMethodTypes10))
                swigDelegate10 = new SwigDelegateViewImpl_10(SwigDirectorOnWheelEvent);
            if (SwigDerivedClassHasMethod("OnRelayout", swigMethodTypes11))
                swigDelegate11 = new SwigDelegateViewImpl_11(SwigDirectorOnRelayout);
            if (SwigDerivedClassHasMethod("OnSetResizePolicy", swigMethodTypes12))
                swigDelegate12 = new SwigDelegateViewImpl_12(SwigDirectorOnSetResizePolicy);
            if (SwigDerivedClassHasMethod("GetNaturalSize", swigMethodTypes13))
                swigDelegate13 = new SwigDelegateViewImpl_13(SwigDirectorGetNaturalSize);
            if (SwigDerivedClassHasMethod("CalculateChildSize", swigMethodTypes14))
                swigDelegate14 = new SwigDelegateViewImpl_14(SwigDirectorCalculateChildSize);
            if (SwigDerivedClassHasMethod("GetHeightForWidth", swigMethodTypes15))
                swigDelegate15 = new SwigDelegateViewImpl_15(SwigDirectorGetHeightForWidth);
            if (SwigDerivedClassHasMethod("GetWidthForHeight", swigMethodTypes16))
                swigDelegate16 = new SwigDelegateViewImpl_16(SwigDirectorGetWidthForHeight);
            if (SwigDerivedClassHasMethod("RelayoutDependentOnChildren", swigMethodTypes17))
                swigDelegate17 = new SwigDelegateViewImpl_17(SwigDirectorRelayoutDependentOnChildren__SWIG_0);
            if (SwigDerivedClassHasMethod("RelayoutDependentOnChildren", swigMethodTypes18))
                swigDelegate18 = new SwigDelegateViewImpl_18(SwigDirectorRelayoutDependentOnChildren__SWIG_1);
            if (SwigDerivedClassHasMethod("OnCalculateRelayoutSize", swigMethodTypes19))
                swigDelegate19 = new SwigDelegateViewImpl_19(SwigDirectorOnCalculateRelayoutSize);
            if (SwigDerivedClassHasMethod("OnLayoutNegotiated", swigMethodTypes20))
                swigDelegate20 = new SwigDelegateViewImpl_20(SwigDirectorOnLayoutNegotiated);
            if (SwigDerivedClassHasMethod("OnInitialize", swigMethodTypes21))
                swigDelegate21 = new SwigDelegateViewImpl_21(SwigDirectorOnInitialize);
            if (SwigDerivedClassHasMethod("OnControlChildAdd", swigMethodTypes22))
                swigDelegate22 = new SwigDelegateViewImpl_22(SwigDirectorOnControlChildAdd);
            if (SwigDerivedClassHasMethod("OnControlChildRemove", swigMethodTypes23))
                swigDelegate23 = new SwigDelegateViewImpl_23(SwigDirectorOnControlChildRemove);
            if (SwigDerivedClassHasMethod("OnStyleChange", swigMethodTypes24))
                swigDelegate24 = new SwigDelegateViewImpl_24(SwigDirectorOnStyleChange);
            if (SwigDerivedClassHasMethod("OnAccessibilityActivated", swigMethodTypes25))
                swigDelegate25 = new SwigDelegateViewImpl_25(SwigDirectorOnAccessibilityActivated);
            if (SwigDerivedClassHasMethod("OnAccessibilityPan", swigMethodTypes26))
                swigDelegate26 = new SwigDelegateViewImpl_26(SwigDirectorOnAccessibilityPan);
            if (SwigDerivedClassHasMethod("OnAccessibilityTouch", swigMethodTypes27))
                swigDelegate27 = new SwigDelegateViewImpl_27(SwigDirectorOnAccessibilityTouch);
            if (SwigDerivedClassHasMethod("OnAccessibilityValueChange", swigMethodTypes28))
                swigDelegate28 = new SwigDelegateViewImpl_28(SwigDirectorOnAccessibilityValueChange);
            if (SwigDerivedClassHasMethod("OnAccessibilityZoom", swigMethodTypes29))
                swigDelegate29 = new SwigDelegateViewImpl_29(SwigDirectorOnAccessibilityZoom);
            if (SwigDerivedClassHasMethod("OnKeyInputFocusGained", swigMethodTypes30))
                swigDelegate30 = new SwigDelegateViewImpl_30(SwigDirectorOnKeyInputFocusGained);
            if (SwigDerivedClassHasMethod("OnKeyInputFocusLost", swigMethodTypes31))
                swigDelegate31 = new SwigDelegateViewImpl_31(SwigDirectorOnKeyInputFocusLost);
            if (SwigDerivedClassHasMethod("GetNextFocusableView", swigMethodTypes32))
                swigDelegate32 = new SwigDelegateViewImpl_32(SwigDirectorGetNextKeyboardFocusableView);
            if (SwigDerivedClassHasMethod("OnFocusChangeCommitted", swigMethodTypes33))
                swigDelegate33 = new SwigDelegateViewImpl_33(SwigDirectorOnKeyboardFocusChangeCommitted);
            if (SwigDerivedClassHasMethod("OnKeyboardEnter", swigMethodTypes34))
                swigDelegate34 = new SwigDelegateViewImpl_34(SwigDirectorOnKeyboardEnter);
            if (SwigDerivedClassHasMethod("OnPinch", swigMethodTypes35))
                swigDelegate35 = new SwigDelegateViewImpl_35(SwigDirectorOnPinch);
            if (SwigDerivedClassHasMethod("OnPan", swigMethodTypes36))
                swigDelegate36 = new SwigDelegateViewImpl_36(SwigDirectorOnPan);
            if (SwigDerivedClassHasMethod("OnTap", swigMethodTypes37))
                swigDelegate37 = new SwigDelegateViewImpl_37(SwigDirectorOnTap);
            if (SwigDerivedClassHasMethod("OnLongPress", swigMethodTypes38))
                swigDelegate38 = new SwigDelegateViewImpl_38(SwigDirectorOnLongPress);
            if (SwigDerivedClassHasMethod("SignalConnected", swigMethodTypes39))
                swigDelegate39 = new SwigDelegateViewImpl_39(SwigDirectorSignalConnected);
            if (SwigDerivedClassHasMethod("SignalDisconnected", swigMethodTypes40))
                swigDelegate40 = new SwigDelegateViewImpl_40(SwigDirectorSignalDisconnected);
            Interop.ViewImpl.ViewImpl_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40);
        }


        private bool SwigDerivedClassHasMethod(string methodName, global::System.Type[] methodTypes)
        {
            global::System.Reflection.MethodInfo methodInfo = this.GetType().GetMethod(methodName, methodTypes);
            bool hasDerivedMethod = this.GetType().GetTypeInfo().IsSubclassOf(typeof(ViewImpl));

            NUILog.Debug("hasDerivedMethod=" + hasDerivedMethod);

            return hasDerivedMethod && (methodInfo != null);
        }

        private void SwigDirectorOnStageConnection(int depth)
        {
            OnStageConnection(depth);
        }

        private void SwigDirectorOnStageDisconnection()
        {
            OnStageDisconnection();
        }

        private void SwigDirectorOnChildAdd(global::System.IntPtr child)
        {
            View view = Registry.GetManagedBaseHandleFromNativePtr(child) as View;

            if (view)
            {
                OnChildAdd(view);
            }
        }

        private void SwigDirectorOnChildRemove(global::System.IntPtr child)
        {
            View view = Registry.GetManagedBaseHandleFromNativePtr(child) as View;

            if (view)
            {
                OnChildRemove(view);
            }
        }

        private void SwigDirectorOnPropertySet(int index, global::System.IntPtr propertyValue)
        {
            OnPropertySet(index, new PropertyValue(propertyValue, true));
        }

        private void SwigDirectorOnSizeSet(global::System.IntPtr targetSize)
        {
            OnSizeSet(new Vector3(targetSize, false));
        }

        private void SwigDirectorOnSizeAnimation(global::System.IntPtr animation, global::System.IntPtr targetSize)
        {
            OnSizeAnimation(new Animation(animation, false), new Vector3(targetSize, false));
        }

        private bool SwigDirectorOnTouchEvent(global::System.IntPtr arg0)
        {
            return OnTouchEvent(new SWIGTYPE_p_Dali__TouchEvent(arg0, false));
        }

        private bool SwigDirectorOnHoverEvent(global::System.IntPtr arg0)
        {
            return OnHoverEvent(new Hover(arg0, false));
        }

        private bool SwigDirectorOnKeyEvent(global::System.IntPtr arg0)
        {
            return OnKeyEvent(new Key(arg0, false));
        }

        private bool SwigDirectorOnWheelEvent(global::System.IntPtr arg0)
        {
            return OnWheelEvent(new Wheel(arg0, false));
        }

        private void SwigDirectorOnRelayout(global::System.IntPtr size, global::System.IntPtr container)
        {
            OnRelayout(new Vector2(size, false), new RelayoutContainer(container, false));
        }

        private void SwigDirectorOnSetResizePolicy(int policy, int dimension)
        {
            OnSetResizePolicy((ResizePolicyType)policy, (DimensionType)dimension);
        }

        private global::System.IntPtr SwigDirectorGetNaturalSize()
        {
            return Vector3.getCPtr(GetNaturalSize()).Handle;
        }

        private float SwigDirectorCalculateChildSize(global::System.IntPtr child, int dimension)
        {
            View view = Registry.GetManagedBaseHandleFromNativePtr(child) as View;
            if (view)
            {
                return CalculateChildSize(view, (DimensionType)dimension);
            }
            return 0.0f;
        }

        private float SwigDirectorGetHeightForWidth(float width)
        {
            return GetHeightForWidth(width);
        }

        private float SwigDirectorGetWidthForHeight(float height)
        {
            return GetWidthForHeight(height);
        }

        private bool SwigDirectorRelayoutDependentOnChildren__SWIG_0(int dimension)
        {
            return RelayoutDependentOnChildren((DimensionType)dimension);
        }

        private bool SwigDirectorRelayoutDependentOnChildren__SWIG_1()
        {
            return RelayoutDependentOnChildren();
        }

        private void SwigDirectorOnCalculateRelayoutSize(int dimension)
        {
            OnCalculateRelayoutSize((DimensionType)dimension);
        }

        private void SwigDirectorOnLayoutNegotiated(float size, int dimension)
        {
            OnLayoutNegotiated(size, (DimensionType)dimension);
        }

        private void SwigDirectorOnInitialize()
        {
            OnInitialize();
        }

        private void SwigDirectorOnControlChildAdd(global::System.IntPtr child)
        {
            View view = Registry.GetManagedBaseHandleFromNativePtr(child) as View;
            if (view)
            {
                OnControlChildAdd(view);
            }
        }

        private void SwigDirectorOnControlChildRemove(global::System.IntPtr child)
        {
            View view = Registry.GetManagedBaseHandleFromNativePtr(child) as View;
            if (view)
            {
                OnControlChildRemove(view);
            }
        }

        private void SwigDirectorOnStyleChange(global::System.IntPtr styleManager, int change)
        {
            StyleManager stManager = Registry.GetManagedBaseHandleFromNativePtr(styleManager) as StyleManager;
            if (stManager)
            {
                OnStyleChange(stManager, (StyleChangeType)change);
            }
        }

        private bool SwigDirectorOnAccessibilityActivated()
        {
            return OnAccessibilityActivated();
        }

        private bool SwigDirectorOnAccessibilityPan(global::System.IntPtr gesture)
        {
            return OnAccessibilityPan(new PanGesture(gesture, true));
        }

        private bool SwigDirectorOnAccessibilityTouch(global::System.IntPtr touchEvent)
        {
            return OnAccessibilityTouch(new SWIGTYPE_p_Dali__TouchEvent(touchEvent, false));
        }

        private bool SwigDirectorOnAccessibilityValueChange(bool isIncrease)
        {
            return OnAccessibilityValueChange(isIncrease);
        }

        private bool SwigDirectorOnAccessibilityZoom()
        {
            return OnAccessibilityZoom();
        }

        private void SwigDirectorOnKeyInputFocusGained()
        {
            OnKeyInputFocusGained();
        }

        private void SwigDirectorOnKeyInputFocusLost()
        {
            OnKeyInputFocusLost();
        }

        private global::System.IntPtr SwigDirectorGetNextKeyboardFocusableView(global::System.IntPtr currentFocusedView, int direction, bool loopEnabled)
        {
            return View.getCPtr(GetNextFocusableView(Registry.GetManagedBaseHandleFromNativePtr(currentFocusedView) as View, (View.FocusDirection)direction, loopEnabled)).Handle;
        }

        private void SwigDirectorOnKeyboardFocusChangeCommitted(global::System.IntPtr commitedFocusableView)
        {
            OnFocusChangeCommitted(Registry.GetManagedBaseHandleFromNativePtr(commitedFocusableView) as View);
        }

        private bool SwigDirectorOnKeyboardEnter()
        {
            return OnKeyboardEnter();
        }

        private void SwigDirectorOnPinch(global::System.IntPtr pinch)
        {
            OnPinch(new PinchGesture(pinch, false));
        }

        private void SwigDirectorOnPan(global::System.IntPtr pan)
        {
            OnPan(new PanGesture(pan, false));
        }

        private void SwigDirectorOnTap(global::System.IntPtr tap)
        {
            OnTap(new TapGesture(tap, false));
        }

        private void SwigDirectorOnLongPress(global::System.IntPtr longPress)
        {
            OnLongPress(new LongPressGesture(longPress, false));
        }

        private void SwigDirectorSignalConnected(global::System.IntPtr slotObserver, global::System.IntPtr callback)
        {
            SignalConnected((slotObserver == global::System.IntPtr.Zero) ? null : new SlotObserver(slotObserver, false), (callback == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_Dali__CallbackBase(callback, false));
        }

        private void SwigDirectorSignalDisconnected(global::System.IntPtr slotObserver, global::System.IntPtr callback)
        {
            SignalDisconnected((slotObserver == global::System.IntPtr.Zero) ? null : new SlotObserver(slotObserver, false), (callback == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_Dali__CallbackBase(callback, false));
        }

        /// <since_tizen> 3 </since_tizen>
        public delegate void SwigDelegateViewImpl_0(int depth);
        /// <since_tizen> 3 </since_tizen>
        public delegate void SwigDelegateViewImpl_1();
        /// <since_tizen> 3 </since_tizen>
        public delegate void SwigDelegateViewImpl_2(global::System.IntPtr child);
        /// <since_tizen> 3 </since_tizen>
        public delegate void SwigDelegateViewImpl_3(global::System.IntPtr child);
        /// <since_tizen> 3 </since_tizen>
        public delegate void SwigDelegateViewImpl_4(int index, global::System.IntPtr propertyValue);
        /// <since_tizen> 3 </since_tizen>
        public delegate void SwigDelegateViewImpl_5(global::System.IntPtr targetSize);
        /// <since_tizen> 3 </since_tizen>
        public delegate void SwigDelegateViewImpl_6(global::System.IntPtr animation, global::System.IntPtr targetSize);
        /// <since_tizen> 3 </since_tizen>
        public delegate bool SwigDelegateViewImpl_7(global::System.IntPtr arg0);
        /// <since_tizen> 3 </since_tizen>
        public delegate bool SwigDelegateViewImpl_8(global::System.IntPtr arg0);
        /// <since_tizen> 3 </since_tizen>
        public delegate bool SwigDelegateViewImpl_9(global::System.IntPtr arg0);
        /// <since_tizen> 3 </since_tizen>
        public delegate bool SwigDelegateViewImpl_10(global::System.IntPtr arg0);
        /// <since_tizen> 3 </since_tizen>
        public delegate void SwigDelegateViewImpl_11(global::System.IntPtr size, global::System.IntPtr container);
        /// <since_tizen> 3 </since_tizen>
        public delegate void SwigDelegateViewImpl_12(int policy, int dimension);
        /// <since_tizen> 3 </since_tizen>
        public delegate global::System.IntPtr SwigDelegateViewImpl_13();
        /// <since_tizen> 3 </since_tizen>
        public delegate float SwigDelegateViewImpl_14(global::System.IntPtr child, int dimension);
        /// <since_tizen> 3 </since_tizen>
        public delegate float SwigDelegateViewImpl_15(float width);
        /// <since_tizen> 3 </since_tizen>
        public delegate float SwigDelegateViewImpl_16(float height);
        /// <since_tizen> 3 </since_tizen>
        public delegate bool SwigDelegateViewImpl_17(int dimension);
        /// <since_tizen> 3 </since_tizen>
        public delegate bool SwigDelegateViewImpl_18();
        /// <since_tizen> 3 </since_tizen>
        public delegate void SwigDelegateViewImpl_19(int dimension);
        /// <since_tizen> 3 </since_tizen>
        public delegate void SwigDelegateViewImpl_20(float size, int dimension);
        /// <since_tizen> 3 </since_tizen>
        public delegate void SwigDelegateViewImpl_21();
        /// <since_tizen> 3 </since_tizen>
        public delegate void SwigDelegateViewImpl_22(global::System.IntPtr child);
        /// <since_tizen> 3 </since_tizen>
        public delegate void SwigDelegateViewImpl_23(global::System.IntPtr child);
        /// <since_tizen> 3 </since_tizen>
        public delegate void SwigDelegateViewImpl_24(global::System.IntPtr styleManager, int change);
        /// <since_tizen> 3 </since_tizen>
        public delegate bool SwigDelegateViewImpl_25();
        /// <since_tizen> 3 </since_tizen>
        public delegate bool SwigDelegateViewImpl_26(global::System.IntPtr gesture);
        /// <since_tizen> 3 </since_tizen>
        public delegate bool SwigDelegateViewImpl_27(global::System.IntPtr touchEvent);
        /// <since_tizen> 3 </since_tizen>
        public delegate bool SwigDelegateViewImpl_28(bool isIncrease);
        /// <since_tizen> 3 </since_tizen>
        public delegate bool SwigDelegateViewImpl_29();
        /// <since_tizen> 3 </since_tizen>
        public delegate void SwigDelegateViewImpl_30();
        /// <since_tizen> 3 </since_tizen>
        public delegate void SwigDelegateViewImpl_31();
        /// <since_tizen> 3 </since_tizen>
        public delegate global::System.IntPtr SwigDelegateViewImpl_32(global::System.IntPtr currentFocusedActor, int direction, bool loopEnabled);
        /// <since_tizen> 3 </since_tizen>
        public delegate void SwigDelegateViewImpl_33(global::System.IntPtr commitedFocusableActor);
        /// <since_tizen> 3 </since_tizen>
        public delegate bool SwigDelegateViewImpl_34();
        /// <since_tizen> 3 </since_tizen>
        public delegate void SwigDelegateViewImpl_35(global::System.IntPtr pinch);
        /// <since_tizen> 3 </since_tizen>
        public delegate void SwigDelegateViewImpl_36(global::System.IntPtr pan);
        /// <since_tizen> 3 </since_tizen>
        public delegate void SwigDelegateViewImpl_37(global::System.IntPtr tap);
        /// <since_tizen> 3 </since_tizen>
        public delegate void SwigDelegateViewImpl_38(global::System.IntPtr longPress);
        /// <since_tizen> 3 </since_tizen>
        public delegate void SwigDelegateViewImpl_39(global::System.IntPtr slotObserver, global::System.IntPtr callback);
        /// <since_tizen> 3 </since_tizen>
        public delegate void SwigDelegateViewImpl_40(global::System.IntPtr slotObserver, global::System.IntPtr callback);

        private SwigDelegateViewImpl_0 swigDelegate0;
        private SwigDelegateViewImpl_1 swigDelegate1;
        private SwigDelegateViewImpl_2 swigDelegate2;
        private SwigDelegateViewImpl_3 swigDelegate3;
        private SwigDelegateViewImpl_4 swigDelegate4;
        private SwigDelegateViewImpl_5 swigDelegate5;
        private SwigDelegateViewImpl_6 swigDelegate6;
        private SwigDelegateViewImpl_7 swigDelegate7;
        private SwigDelegateViewImpl_8 swigDelegate8;
        private SwigDelegateViewImpl_9 swigDelegate9;
        private SwigDelegateViewImpl_10 swigDelegate10;
        private SwigDelegateViewImpl_11 swigDelegate11;
        private SwigDelegateViewImpl_12 swigDelegate12;
        private SwigDelegateViewImpl_13 swigDelegate13;
        private SwigDelegateViewImpl_14 swigDelegate14;
        private SwigDelegateViewImpl_15 swigDelegate15;
        private SwigDelegateViewImpl_16 swigDelegate16;
        private SwigDelegateViewImpl_17 swigDelegate17;
        private SwigDelegateViewImpl_18 swigDelegate18;
        private SwigDelegateViewImpl_19 swigDelegate19;
        private SwigDelegateViewImpl_20 swigDelegate20;
        private SwigDelegateViewImpl_21 swigDelegate21;
        private SwigDelegateViewImpl_22 swigDelegate22;
        private SwigDelegateViewImpl_23 swigDelegate23;
        private SwigDelegateViewImpl_24 swigDelegate24;
        private SwigDelegateViewImpl_25 swigDelegate25;
        private SwigDelegateViewImpl_26 swigDelegate26;
        private SwigDelegateViewImpl_27 swigDelegate27;
        private SwigDelegateViewImpl_28 swigDelegate28;
        private SwigDelegateViewImpl_29 swigDelegate29;
        private SwigDelegateViewImpl_30 swigDelegate30;
        private SwigDelegateViewImpl_31 swigDelegate31;
        private SwigDelegateViewImpl_32 swigDelegate32;
        private SwigDelegateViewImpl_33 swigDelegate33;
        private SwigDelegateViewImpl_34 swigDelegate34;
        private SwigDelegateViewImpl_35 swigDelegate35;
        private SwigDelegateViewImpl_36 swigDelegate36;
        private SwigDelegateViewImpl_37 swigDelegate37;
        private SwigDelegateViewImpl_38 swigDelegate38;
        private SwigDelegateViewImpl_39 swigDelegate39;
        private SwigDelegateViewImpl_40 swigDelegate40;

        private static global::System.Type[] swigMethodTypes0 = new global::System.Type[] { typeof(int) };
        private static global::System.Type[] swigMethodTypes1 = new global::System.Type[] { };
        private static global::System.Type[] swigMethodTypes2 = new global::System.Type[] { typeof(View) };
        private static global::System.Type[] swigMethodTypes3 = new global::System.Type[] { typeof(View) };
        private static global::System.Type[] swigMethodTypes4 = new global::System.Type[] { typeof(int), typeof(PropertyValue) };
        private static global::System.Type[] swigMethodTypes5 = new global::System.Type[] { typeof(Vector3) };
        private static global::System.Type[] swigMethodTypes6 = new global::System.Type[] { typeof(Animation), typeof(Vector3) };
        private static global::System.Type[] swigMethodTypes7 = new global::System.Type[] { typeof(SWIGTYPE_p_Dali__TouchEvent) };
        private static global::System.Type[] swigMethodTypes8 = new global::System.Type[] { typeof(Hover) };
        private static global::System.Type[] swigMethodTypes9 = new global::System.Type[] { typeof(Key) };
        private static global::System.Type[] swigMethodTypes10 = new global::System.Type[] { typeof(Wheel) };
        private static global::System.Type[] swigMethodTypes11 = new global::System.Type[] { typeof(Vector2), typeof(RelayoutContainer) };
        private static global::System.Type[] swigMethodTypes12 = new global::System.Type[] { typeof(ResizePolicyType), typeof(DimensionType) };
        private static global::System.Type[] swigMethodTypes13 = new global::System.Type[] { };
        private static global::System.Type[] swigMethodTypes14 = new global::System.Type[] { typeof(View), typeof(DimensionType) };
        private static global::System.Type[] swigMethodTypes15 = new global::System.Type[] { typeof(float) };
        private static global::System.Type[] swigMethodTypes16 = new global::System.Type[] { typeof(float) };
        private static global::System.Type[] swigMethodTypes17 = new global::System.Type[] { typeof(DimensionType) };
        private static global::System.Type[] swigMethodTypes18 = new global::System.Type[] { };
        private static global::System.Type[] swigMethodTypes19 = new global::System.Type[] { typeof(DimensionType) };
        private static global::System.Type[] swigMethodTypes20 = new global::System.Type[] { typeof(float), typeof(DimensionType) };
        private static global::System.Type[] swigMethodTypes21 = new global::System.Type[] { };
        private static global::System.Type[] swigMethodTypes22 = new global::System.Type[] { typeof(View) };
        private static global::System.Type[] swigMethodTypes23 = new global::System.Type[] { typeof(View) };
        private static global::System.Type[] swigMethodTypes24 = new global::System.Type[] { typeof(StyleManager), typeof(StyleChangeType) };
        private static global::System.Type[] swigMethodTypes25 = new global::System.Type[] { };
        private static global::System.Type[] swigMethodTypes26 = new global::System.Type[] { typeof(PanGesture) };
        private static global::System.Type[] swigMethodTypes27 = new global::System.Type[] { typeof(SWIGTYPE_p_Dali__TouchEvent) };
        private static global::System.Type[] swigMethodTypes28 = new global::System.Type[] { typeof(bool) };
        private static global::System.Type[] swigMethodTypes29 = new global::System.Type[] { };
        private static global::System.Type[] swigMethodTypes30 = new global::System.Type[] { };
        private static global::System.Type[] swigMethodTypes31 = new global::System.Type[] { };
        private static global::System.Type[] swigMethodTypes32 = new global::System.Type[] { typeof(View), typeof(View.FocusDirection), typeof(bool) };
        private static global::System.Type[] swigMethodTypes33 = new global::System.Type[] { typeof(View) };
        private static global::System.Type[] swigMethodTypes34 = new global::System.Type[] { };
        private static global::System.Type[] swigMethodTypes35 = new global::System.Type[] { typeof(PinchGesture) };
        private static global::System.Type[] swigMethodTypes36 = new global::System.Type[] { typeof(PanGesture) };
        private static global::System.Type[] swigMethodTypes37 = new global::System.Type[] { typeof(TapGesture) };
        private static global::System.Type[] swigMethodTypes38 = new global::System.Type[] { typeof(LongPressGesture) };
        private static global::System.Type[] swigMethodTypes39 = new global::System.Type[] { typeof(SlotObserver), typeof(SWIGTYPE_p_Dali__CallbackBase) };
        private static global::System.Type[] swigMethodTypes40 = new global::System.Type[] { typeof(SlotObserver), typeof(SWIGTYPE_p_Dali__CallbackBase) };
    }

}