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
using System.Reflection;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    internal class ViewImpl : CustomActorImpl
    {
        internal ViewImpl(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ViewImpl obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            throw new global::System.MethodAccessException("C++ destructor does not have public access");
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                SwigDirectorDisconnect();
            }

            base.Dispose(type);
        }

        public static View New()
        {
            View ret = new View(Interop.ViewImpl.New(), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetStyleName(string styleName)
        {
            Interop.ViewImpl.SetStyleName(SwigCPtr, styleName);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public string GetStyleName()
        {
            string ret = Interop.ViewImpl.GetStyleName(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetBackgroundColor(Vector4 color)
        {
            Interop.ViewImpl.SetBackgroundColor(SwigCPtr, Vector4.getCPtr(color));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Vector4 GetBackgroundColor()
        {
            Vector4 ret = new Vector4(Interop.ViewImpl.GetBackgroundColor(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetBackground(PropertyMap map)
        {
            Interop.ViewImpl.SetBackground(SwigCPtr, PropertyMap.getCPtr(map));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void ClearBackground()
        {
            Interop.ViewImpl.ClearBackground(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void EnableGestureDetection(Gesture.GestureType type)
        {
            Interop.ViewImpl.EnableGestureDetection(SwigCPtr, (int)type);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void DisableGestureDetection(Gesture.GestureType type)
        {
            Interop.ViewImpl.DisableGestureDetection(SwigCPtr, (int)type);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public PinchGestureDetector GetPinchGestureDetector()
        {
            PinchGestureDetector ret = new PinchGestureDetector(Interop.ViewImpl.GetPinchGestureDetector(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public PanGestureDetector GetPanGestureDetector()
        {
            PanGestureDetector ret = new PanGestureDetector(Interop.ViewImpl.GetPanGestureDetector(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public TapGestureDetector GetTapGestureDetector()
        {
            TapGestureDetector ret = new TapGestureDetector(Interop.ViewImpl.GetTapGestureDetector(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public LongPressGestureDetector GetLongPressGestureDetector()
        {
            LongPressGestureDetector ret = new LongPressGestureDetector(Interop.ViewImpl.GetLongPressGestureDetector(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetKeyboardNavigationSupport(bool isSupported)
        {
            Interop.ViewImpl.SetKeyboardNavigationSupport(SwigCPtr, isSupported);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool IsKeyboardNavigationSupported()
        {
            bool ret = Interop.ViewImpl.IsKeyboardNavigationSupported(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetKeyInputFocus()
        {
            Interop.ViewImpl.SetKeyInputFocus(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool HasKeyInputFocus()
        {
            bool ret = Interop.ViewImpl.HasKeyInputFocus(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void ClearKeyInputFocus()
        {
            Interop.ViewImpl.ClearKeyInputFocus(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetAsFocusGroup(bool isFocusGroup)
        {
            Interop.ViewImpl.SetAsKeyboardFocusGroup(SwigCPtr, isFocusGroup);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool IsFocusGroup()
        {
            bool ret = Interop.ViewImpl.IsKeyboardFocusGroup(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// [Obsolete("Please do not use! this will be deprecated")]
        /// </summary>
        /// Please do not use! this will be deprecated!
        [Obsolete("Please do not use! this will be deprecated.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AccessibilityActivate()
        {
            Interop.ViewImpl.AccessibilityActivate(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// [Obsolete("Please do not use! this will be deprecated")]
        /// </summary>
        /// Please do not use! this will be deprecated!
        [Obsolete("Please do not use! this will be deprecated.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void KeyboardEnter()
        {
            Interop.ViewImpl.KeyboardEnter(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal ControlKeySignal KeyEventSignal()
        {
            ControlKeySignal ret = new ControlKeySignal(Interop.ViewImplSignal.KeyEventSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal KeyInputFocusSignal KeyInputFocusGainedSignal()
        {
            KeyInputFocusSignal ret = new KeyInputFocusSignal(Interop.ViewImplSignal.KeyInputFocusGainedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal KeyInputFocusSignal KeyInputFocusLostSignal()
        {
            KeyInputFocusSignal ret = new KeyInputFocusSignal(Interop.ViewImplSignal.KeyInputFocusLostSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// [Obsolete("Please do not use! this will be deprecated")]
        /// </summary>
        /// Please do not use! this will be deprecated!
        [Obsolete("Please do not use! this will be deprecated.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EmitKeyEventSignal(Key arg0)
        {
            bool ret = Interop.ViewImplSignal.EmitKeyEventSignal(SwigCPtr, Key.getCPtr(arg0));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        protected virtual new void OnSceneConnection(int depth)
        {
            if (SwigDerivedClassHasMethod("OnSceneConnection", swigMethodTypes0)) Interop.ViewImplSignal.OnSceneConnectionSwigExplicitViewImpl(SwigCPtr, depth); else Interop.ViewImplSignal.OnSceneConnection(SwigCPtr, depth);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        protected virtual new void OnSceneDisconnection()
        {
            if (SwigDerivedClassHasMethod("OnSceneDisconnection", swigMethodTypes1)) Interop.ViewImplSignal.OnSceneDisconnectionSwigExplicitViewImpl(SwigCPtr); else Interop.ViewImplSignal.OnSceneDisconnection(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        protected virtual new void OnChildAdd(View child)
        {
            if (SwigDerivedClassHasMethod("OnChildAdd", swigMethodTypes2)) Interop.ViewImplSignal.OnChildAddSwigExplicitViewImpl(SwigCPtr, View.getCPtr(child)); else Interop.ViewImplSignal.OnChildAdd(SwigCPtr, View.getCPtr(child));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        protected virtual new void OnChildRemove(View child)
        {
            if (SwigDerivedClassHasMethod("OnChildRemove", swigMethodTypes3)) Interop.ViewImplSignal.OnChildRemoveSwigExplicitViewImpl(SwigCPtr, View.getCPtr(child)); else Interop.ViewImplSignal.OnChildRemove(SwigCPtr, View.getCPtr(child));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        protected virtual new void OnPropertySet(int index, PropertyValue propertyValue)
        {
            if (SwigDerivedClassHasMethod("OnPropertySet", swigMethodTypes4)) Interop.ViewImplSignal.OnPropertySetSwigExplicitViewImpl(SwigCPtr, index, PropertyValue.getCPtr(propertyValue)); else Interop.ViewImplSignal.OnPropertySet(SwigCPtr, index, PropertyValue.getCPtr(propertyValue));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        protected virtual new void OnSizeSet(Vector3 targetSize)
        {
            if (SwigDerivedClassHasMethod("OnSizeSet", swigMethodTypes5)) Interop.ViewImplSignal.OnSizeSetSwigExplicitViewImpl(SwigCPtr, Vector3.getCPtr(targetSize)); else Interop.ViewImplSignal.OnSizeSet(SwigCPtr, Vector3.getCPtr(targetSize));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        protected virtual new void OnSizeAnimation(Animation animation, Vector3 targetSize)
        {
            if (SwigDerivedClassHasMethod("OnSizeAnimation", swigMethodTypes6)) Interop.ViewImplSignal.OnSizeAnimationSwigExplicitViewImpl(SwigCPtr, Animation.getCPtr(animation), Vector3.getCPtr(targetSize)); else Interop.ViewImplSignal.OnSizeAnimation(SwigCPtr, Animation.getCPtr(animation), Vector3.getCPtr(targetSize));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        protected virtual new bool OnKeyEvent(Key arg0)
        {
            bool ret = (SwigDerivedClassHasMethod("OnKeyEvent", swigMethodTypes9) ? Interop.ViewImplSignal.OnKeyEventSwigExplicitViewImpl(SwigCPtr, Key.getCPtr(arg0)) : Interop.ViewImplSignal.OnKeyEvent(SwigCPtr, Key.getCPtr(arg0)));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        protected virtual new void OnRelayout(Vector2 size, RelayoutContainer container)
        {
            if (SwigDerivedClassHasMethod("OnRelayout", swigMethodTypes11)) Interop.ViewImplSignal.OnRelayoutSwigExplicitViewImpl(SwigCPtr, Vector2.getCPtr(size), RelayoutContainer.getCPtr(container)); else Interop.ViewImplSignal.OnRelayout(SwigCPtr, Vector2.getCPtr(size), RelayoutContainer.getCPtr(container));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        protected virtual new void OnSetResizePolicy(ResizePolicyType policy, DimensionType dimension)
        {
            if (SwigDerivedClassHasMethod("OnSetResizePolicy", swigMethodTypes12)) Interop.ViewImplSignal.OnSetResizePolicySwigExplicitViewImpl(SwigCPtr, (int)policy, (int)dimension); else Interop.ViewImplSignal.OnSetResizePolicy(SwigCPtr, (int)policy, (int)dimension);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        protected virtual new Vector3 GetNaturalSize()
        {
            Vector3 ret = new Vector3((SwigDerivedClassHasMethod("GetNaturalSize", swigMethodTypes13) ? Interop.ViewImpl.GetNaturalSizeSwigExplicitViewImpl(SwigCPtr) : Interop.ViewImpl.GetNaturalSize(SwigCPtr)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        protected virtual new float CalculateChildSize(View child, DimensionType dimension)
        {
            float ret = (SwigDerivedClassHasMethod("CalculateChildSize", swigMethodTypes14) ? Interop.ViewImpl.CalculateChildSizeSwigExplicitViewImpl(SwigCPtr, View.getCPtr(child), (int)dimension) : Interop.ViewImpl.CalculateChildSize(SwigCPtr, View.getCPtr(child), (int)dimension));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        protected virtual new float GetHeightForWidth(float width)
        {
            float ret = (SwigDerivedClassHasMethod("GetHeightForWidth", swigMethodTypes15) ? Interop.ViewImpl.GetHeightForWidthSwigExplicitViewImpl(SwigCPtr, width) : Interop.ViewImpl.GetHeightForWidth(SwigCPtr, width));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        protected virtual new float GetWidthForHeight(float height)
        {
            float ret = (SwigDerivedClassHasMethod("GetWidthForHeight", swigMethodTypes16) ? Interop.ViewImpl.GetWidthForHeightSwigExplicitViewImpl(SwigCPtr, height) : Interop.ViewImpl.GetWidthForHeight(SwigCPtr, height));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        protected virtual new bool RelayoutDependentOnChildren(DimensionType dimension)
        {
            bool ret = (SwigDerivedClassHasMethod("RelayoutDependentOnChildren", swigMethodTypes17) ? Interop.ViewImpl.RelayoutDependentOnChildrenSwigExplicitViewImpl(SwigCPtr, (int)dimension) : Interop.ViewImpl.RelayoutDependentOnChildren(SwigCPtr, (int)dimension));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        protected virtual new bool RelayoutDependentOnChildren()
        {
            bool ret = (SwigDerivedClassHasMethod("RelayoutDependentOnChildren", swigMethodTypes18) ? Interop.ViewImpl.RelayoutDependentOnChildrenSwigExplicitViewImpl(SwigCPtr) : Interop.ViewImpl.RelayoutDependentOnChildren(SwigCPtr));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        protected virtual new void OnCalculateRelayoutSize(DimensionType dimension)
        {
            if (SwigDerivedClassHasMethod("OnCalculateRelayoutSize", swigMethodTypes19)) Interop.ViewImplSignal.OnCalculateRelayoutSizeSwigExplicitViewImpl(SwigCPtr, (int)dimension); else Interop.ViewImplSignal.OnCalculateRelayoutSize(SwigCPtr, (int)dimension);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        protected virtual new void OnLayoutNegotiated(float size, DimensionType dimension)
        {
            if (SwigDerivedClassHasMethod("OnLayoutNegotiated", swigMethodTypes20)) Interop.ViewImplSignal.OnLayoutNegotiatedSwigExplicitViewImpl(SwigCPtr, size, (int)dimension); else Interop.ViewImplSignal.OnLayoutNegotiated(SwigCPtr, size, (int)dimension);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public virtual void OnInitialize()
        {
            if (SwigDerivedClassHasMethod("OnInitialize", swigMethodTypes21)) Interop.ViewImplSignal.OnInitializeSwigExplicitViewImpl(SwigCPtr); else Interop.ViewImplSignal.OnInitialize(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public virtual void OnStyleChange(StyleManager styleManager, StyleChangeType change)
        {
            if (SwigDerivedClassHasMethod("OnStyleChange", swigMethodTypes24)) Interop.ViewImplSignal.OnStyleChangeSwigExplicitViewImpl(SwigCPtr, StyleManager.getCPtr(styleManager), (int)change); else Interop.ViewImplSignal.OnStyleChange(SwigCPtr, StyleManager.getCPtr(styleManager), (int)change);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public virtual bool OnAccessibilityActivated()
        {
            bool ret = (SwigDerivedClassHasMethod("OnAccessibilityActivated", swigMethodTypes25) ? Interop.ViewImplSignal.OnAccessibilityActivatedSwigExplicitViewImpl(SwigCPtr) : Interop.ViewImplSignal.OnAccessibilityActivated(SwigCPtr));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual bool OnAccessibilityPan(PanGesture gesture)
        {
            bool ret = (SwigDerivedClassHasMethod("OnAccessibilityPan", swigMethodTypes26) ? Interop.ViewImplSignal.OnAccessibilityPanSwigExplicitViewImpl(SwigCPtr, PanGesture.getCPtr(gesture)) : Interop.ViewImplSignal.OnAccessibilityPan(SwigCPtr, PanGesture.getCPtr(gesture)));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual bool OnAccessibilityValueChange(bool isIncrease)
        {
            bool ret = (SwigDerivedClassHasMethod("OnAccessibilityValueChange", swigMethodTypes28) ? Interop.ViewImplSignal.OnAccessibilityValueChangeSwigExplicitViewImpl(SwigCPtr, isIncrease) : Interop.ViewImplSignal.OnAccessibilityValueChange(SwigCPtr, isIncrease));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual bool OnAccessibilityZoom()
        {
            bool ret = (SwigDerivedClassHasMethod("OnAccessibilityZoom", swigMethodTypes29) ? Interop.ViewImplSignal.OnAccessibilityZoomSwigExplicitViewImpl(SwigCPtr) : Interop.ViewImplSignal.OnAccessibilityZoom(SwigCPtr));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual void OnKeyInputFocusGained()
        {
            if (SwigDerivedClassHasMethod("OnKeyInputFocusGained", swigMethodTypes30)) Interop.ViewImplSignal.OnKeyInputFocusGainedSwigExplicitViewImpl(SwigCPtr); else Interop.ViewImplSignal.OnKeyInputFocusGained(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public virtual void OnKeyInputFocusLost()
        {
            if (SwigDerivedClassHasMethod("OnKeyInputFocusLost", swigMethodTypes31)) Interop.ViewImplSignal.OnKeyInputFocusLostSwigExplicitViewImpl(SwigCPtr); else Interop.ViewImplSignal.OnKeyInputFocusLost(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public virtual View GetNextFocusableView(View currentFocusedView, View.FocusDirection direction, bool loopEnabled)
        {
            View ret = new View((SwigDerivedClassHasMethod("GetNextFocusableView", swigMethodTypes32) ? Interop.ViewImpl.GetNextKeyboardFocusableActorSwigExplicitViewImpl(SwigCPtr, View.getCPtr(currentFocusedView), (int)direction, loopEnabled) : Interop.ViewImpl.GetNextKeyboardFocusableActor(SwigCPtr, View.getCPtr(currentFocusedView), (int)direction, loopEnabled)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual void OnFocusChangeCommitted(View commitedFocusableView)
        {
            if (SwigDerivedClassHasMethod("OnFocusChangeCommitted", swigMethodTypes33)) Interop.ViewImplSignal.OnKeyboardFocusChangeCommittedSwigExplicitViewImpl(SwigCPtr, View.getCPtr(commitedFocusableView)); else Interop.ViewImplSignal.OnKeyboardFocusChangeCommitted(SwigCPtr, View.getCPtr(commitedFocusableView));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public virtual bool OnKeyboardEnter()
        {
            bool ret = (SwigDerivedClassHasMethod("OnKeyboardEnter", swigMethodTypes34) ? Interop.ViewImplSignal.OnKeyboardEnterSwigExplicitViewImpl(SwigCPtr) : Interop.ViewImplSignal.OnKeyboardEnter(SwigCPtr));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public virtual void OnPinch(PinchGesture pinch)
        {
            if (SwigDerivedClassHasMethod("OnPinch", swigMethodTypes35)) Interop.ViewImplSignal.OnPinchSwigExplicitViewImpl(SwigCPtr, PinchGesture.getCPtr(pinch)); else Interop.ViewImplSignal.OnPinch(SwigCPtr, PinchGesture.getCPtr(pinch));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public virtual void OnPan(PanGesture pan)
        {
            if (SwigDerivedClassHasMethod("OnPan", swigMethodTypes36)) Interop.ViewImplSignal.OnPanSwigExplicitViewImpl(SwigCPtr, PanGesture.getCPtr(pan)); else Interop.ViewImplSignal.OnPan(SwigCPtr, PanGesture.getCPtr(pan));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public virtual void OnTap(TapGesture tap)
        {
            if (SwigDerivedClassHasMethod("OnTap", swigMethodTypes37)) Interop.ViewImplSignal.OnTapSwigExplicitViewImpl(SwigCPtr, TapGesture.getCPtr(tap)); else Interop.ViewImplSignal.OnTap(SwigCPtr, TapGesture.getCPtr(tap));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public virtual void OnLongPress(LongPressGesture longPress)
        {
            if (SwigDerivedClassHasMethod("OnLongPress", swigMethodTypes38)) Interop.ViewImplSignal.OnLongPressSwigExplicitViewImpl(SwigCPtr, LongPressGesture.getCPtr(longPress)); else Interop.ViewImplSignal.OnLongPress(SwigCPtr, LongPressGesture.getCPtr(longPress));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal virtual void SignalConnected(SlotObserver slotObserver, SWIGTYPE_p_Dali__CallbackBase callback)
        {
            if (SwigDerivedClassHasMethod("SignalConnected", swigMethodTypes39)) Interop.ViewImplSignal.SignalConnectedSwigExplicitViewImpl(SwigCPtr, SlotObserver.getCPtr(slotObserver), SWIGTYPE_p_Dali__CallbackBase.getCPtr(callback)); else Interop.ViewImplSignal.SignalConnected(SwigCPtr, SlotObserver.getCPtr(slotObserver), SWIGTYPE_p_Dali__CallbackBase.getCPtr(callback));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal virtual void SignalDisconnected(SlotObserver slotObserver, SWIGTYPE_p_Dali__CallbackBase callback)
        {
            if (SwigDerivedClassHasMethod("SignalDisconnected", swigMethodTypes40)) Interop.ViewImplSignal.SignalDisconnectedSwigExplicitViewImpl(SwigCPtr, SlotObserver.getCPtr(slotObserver), SWIGTYPE_p_Dali__CallbackBase.getCPtr(callback)); else Interop.ViewImplSignal.SignalDisconnected(SwigCPtr, SlotObserver.getCPtr(slotObserver), SWIGTYPE_p_Dali__CallbackBase.getCPtr(callback));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private void SwigDirectorConnect()
        {
            if (SwigDerivedClassHasMethod("OnSceneConnection", swigMethodTypes0))
                swigDelegate0 = new SwigDelegateViewImpl_0(SwigDirectorOnSceneConnection);
            if (SwigDerivedClassHasMethod("OnSceneDisconnection", swigMethodTypes1))
                swigDelegate1 = new SwigDelegateViewImpl_1(SwigDirectorOnSceneDisconnection);
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
            if (SwigDerivedClassHasMethod("OnKeyEvent", swigMethodTypes9))
                swigDelegate9 = new SwigDelegateViewImpl_9(SwigDirectorOnKeyEvent);
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
                swigDelegate17 = new SwigDelegateViewImpl_17(SwigDirectorRelayoutDependentOnChildrenWithDimension);
            if (SwigDerivedClassHasMethod("RelayoutDependentOnChildren", swigMethodTypes18))
                swigDelegate18 = new SwigDelegateViewImpl_18(SwigDirectorRelayoutDependentOnChildren);
            if (SwigDerivedClassHasMethod("OnCalculateRelayoutSize", swigMethodTypes19))
                swigDelegate19 = new SwigDelegateViewImpl_19(SwigDirectorOnCalculateRelayoutSize);
            if (SwigDerivedClassHasMethod("OnLayoutNegotiated", swigMethodTypes20))
                swigDelegate20 = new SwigDelegateViewImpl_20(SwigDirectorOnLayoutNegotiated);
            if (SwigDerivedClassHasMethod("OnInitialize", swigMethodTypes21))
                swigDelegate21 = new SwigDelegateViewImpl_21(SwigDirectorOnInitialize);
            if (SwigDerivedClassHasMethod("OnStyleChange", swigMethodTypes24))
                swigDelegate24 = new SwigDelegateViewImpl_24(SwigDirectorOnStyleChange);
            if (SwigDerivedClassHasMethod("OnAccessibilityActivated", swigMethodTypes25))
                swigDelegate25 = new SwigDelegateViewImpl_25(SwigDirectorOnAccessibilityActivated);
            if (SwigDerivedClassHasMethod("OnAccessibilityPan", swigMethodTypes26))
                swigDelegate26 = new SwigDelegateViewImpl_26(SwigDirectorOnAccessibilityPan);
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
            Interop.ViewImpl.DirectorConnect(SwigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate9, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40);
        }

        private void SwigDirectorDisconnect()
        {
            swigDelegate0 = null;
            swigDelegate1 = null;
            swigDelegate2 = null;
            swigDelegate3 = null;
            swigDelegate4 = null;
            swigDelegate5 = null;
            swigDelegate6 = null;
            swigDelegate9 = null;
            swigDelegate11 = null;
            swigDelegate12 = null;
            swigDelegate13 = null;
            swigDelegate14 = null;
            swigDelegate15 = null;
            swigDelegate16 = null;
            swigDelegate17 = null;
            swigDelegate18 = null;
            swigDelegate19 = null;
            swigDelegate20 = null;
            swigDelegate21 = null;
            swigDelegate24 = null;
            swigDelegate25 = null;
            swigDelegate26 = null;
            swigDelegate28 = null;
            swigDelegate29 = null;
            swigDelegate30 = null;
            swigDelegate31 = null;
            swigDelegate32 = null;
            swigDelegate33 = null;
            swigDelegate34 = null;
            swigDelegate35 = null;
            swigDelegate36 = null;
            swigDelegate37 = null;
            swigDelegate38 = null;
            swigDelegate39 = null;
            swigDelegate40 = null;
            Interop.ViewImpl.DirectorConnect(SwigCPtr, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
        }

        private bool SwigDerivedClassHasMethod(string methodName, global::System.Type[] methodTypes)
        {
            global::System.Reflection.MethodInfo methodInfo = this.GetType().GetMethod(methodName, methodTypes);
            bool hasDerivedMethod = this.GetType().GetTypeInfo().IsSubclassOf(typeof(ViewImpl));

            NUILog.Debug("hasDerivedMethod=" + hasDerivedMethod);

            return hasDerivedMethod && (methodInfo != null);
        }

        private void SwigDirectorOnSceneConnection(int depth)
        {
            OnSceneConnection(depth);
        }

        private void SwigDirectorOnSceneDisconnection()
        {
            OnSceneDisconnection();
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

        private bool SwigDirectorOnKeyEvent(global::System.IntPtr arg0)
        {
            return OnKeyEvent(new Key(arg0, false));
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

        private bool SwigDirectorRelayoutDependentOnChildrenWithDimension(int dimension)
        {
            return RelayoutDependentOnChildren((DimensionType)dimension);
        }

        private bool SwigDirectorRelayoutDependentOnChildren()
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
            SignalConnected((slotObserver == global::System.IntPtr.Zero) ? null : new SlotObserver(slotObserver, false), (callback == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_Dali__CallbackBase(callback));
        }

        private void SwigDirectorSignalDisconnected(global::System.IntPtr slotObserver, global::System.IntPtr callback)
        {
            SignalDisconnected((slotObserver == global::System.IntPtr.Zero) ? null : new SlotObserver(slotObserver, false), (callback == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_Dali__CallbackBase(callback));
        }

        public delegate void SwigDelegateViewImpl_0(int depth);
        public delegate void SwigDelegateViewImpl_1();
        public delegate void SwigDelegateViewImpl_2(global::System.IntPtr child);
        public delegate void SwigDelegateViewImpl_3(global::System.IntPtr child);
        public delegate void SwigDelegateViewImpl_4(int index, global::System.IntPtr propertyValue);
        public delegate void SwigDelegateViewImpl_5(global::System.IntPtr targetSize);
        public delegate void SwigDelegateViewImpl_6(global::System.IntPtr animation, global::System.IntPtr targetSize);
        public delegate bool SwigDelegateViewImpl_9(global::System.IntPtr arg0);
        public delegate void SwigDelegateViewImpl_11(global::System.IntPtr size, global::System.IntPtr container);
        public delegate void SwigDelegateViewImpl_12(int policy, int dimension);
        public delegate global::System.IntPtr SwigDelegateViewImpl_13();
        public delegate float SwigDelegateViewImpl_14(global::System.IntPtr child, int dimension);
        public delegate float SwigDelegateViewImpl_15(float width);
        public delegate float SwigDelegateViewImpl_16(float height);
        public delegate bool SwigDelegateViewImpl_17(int dimension);
        public delegate bool SwigDelegateViewImpl_18();
        public delegate void SwigDelegateViewImpl_19(int dimension);
        public delegate void SwigDelegateViewImpl_20(float size, int dimension);
        public delegate void SwigDelegateViewImpl_21();
        public delegate void SwigDelegateViewImpl_22(global::System.IntPtr child);
        public delegate void SwigDelegateViewImpl_23(global::System.IntPtr child);
        public delegate void SwigDelegateViewImpl_24(global::System.IntPtr styleManager, int change);
        public delegate bool SwigDelegateViewImpl_25();
        public delegate bool SwigDelegateViewImpl_26(global::System.IntPtr gesture);
        public delegate bool SwigDelegateViewImpl_28(bool isIncrease);
        public delegate bool SwigDelegateViewImpl_29();
        public delegate void SwigDelegateViewImpl_30();
        public delegate void SwigDelegateViewImpl_31();
        public delegate global::System.IntPtr SwigDelegateViewImpl_32(global::System.IntPtr currentFocusedActor, int direction, bool loopEnabled);
        public delegate void SwigDelegateViewImpl_33(global::System.IntPtr commitedFocusableActor);
        public delegate bool SwigDelegateViewImpl_34();
        public delegate void SwigDelegateViewImpl_35(global::System.IntPtr pinch);
        public delegate void SwigDelegateViewImpl_36(global::System.IntPtr pan);
        public delegate void SwigDelegateViewImpl_37(global::System.IntPtr tap);
        public delegate void SwigDelegateViewImpl_38(global::System.IntPtr longPress);
        public delegate void SwigDelegateViewImpl_39(global::System.IntPtr slotObserver, global::System.IntPtr callback);
        public delegate void SwigDelegateViewImpl_40(global::System.IntPtr slotObserver, global::System.IntPtr callback);

        private SwigDelegateViewImpl_0 swigDelegate0;
        private SwigDelegateViewImpl_1 swigDelegate1;
        private SwigDelegateViewImpl_2 swigDelegate2;
        private SwigDelegateViewImpl_3 swigDelegate3;
        private SwigDelegateViewImpl_4 swigDelegate4;
        private SwigDelegateViewImpl_5 swigDelegate5;
        private SwigDelegateViewImpl_6 swigDelegate6;
        private SwigDelegateViewImpl_9 swigDelegate9;
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
        private SwigDelegateViewImpl_24 swigDelegate24;
        private SwigDelegateViewImpl_25 swigDelegate25;
        private SwigDelegateViewImpl_26 swigDelegate26;
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
        private static global::System.Type[] swigMethodTypes1 = System.Array.Empty<global::System.Type>();
        private static global::System.Type[] swigMethodTypes2 = new global::System.Type[] { typeof(View) };
        private static global::System.Type[] swigMethodTypes3 = new global::System.Type[] { typeof(View) };
        private static global::System.Type[] swigMethodTypes4 = new global::System.Type[] { typeof(int), typeof(PropertyValue) };
        private static global::System.Type[] swigMethodTypes5 = new global::System.Type[] { typeof(Vector3) };
        private static global::System.Type[] swigMethodTypes6 = new global::System.Type[] { typeof(Animation), typeof(Vector3) };
        private static global::System.Type[] swigMethodTypes9 = new global::System.Type[] { typeof(Key) };
        private static global::System.Type[] swigMethodTypes11 = new global::System.Type[] { typeof(Vector2), typeof(RelayoutContainer) };
        private static global::System.Type[] swigMethodTypes12 = new global::System.Type[] { typeof(ResizePolicyType), typeof(DimensionType) };
        private static global::System.Type[] swigMethodTypes13 = System.Array.Empty<global::System.Type>();
        private static global::System.Type[] swigMethodTypes14 = new global::System.Type[] { typeof(View), typeof(DimensionType) };
        private static global::System.Type[] swigMethodTypes15 = new global::System.Type[] { typeof(float) };
        private static global::System.Type[] swigMethodTypes16 = new global::System.Type[] { typeof(float) };
        private static global::System.Type[] swigMethodTypes17 = new global::System.Type[] { typeof(DimensionType) };
        private static global::System.Type[] swigMethodTypes18 = System.Array.Empty<global::System.Type>();
        private static global::System.Type[] swigMethodTypes19 = new global::System.Type[] { typeof(DimensionType) };
        private static global::System.Type[] swigMethodTypes20 = new global::System.Type[] { typeof(float), typeof(DimensionType) };
        private static global::System.Type[] swigMethodTypes21 = System.Array.Empty<global::System.Type>();
        private static global::System.Type[] swigMethodTypes24 = new global::System.Type[] { typeof(StyleManager), typeof(StyleChangeType) };
        private static global::System.Type[] swigMethodTypes25 = System.Array.Empty<global::System.Type>();
        private static global::System.Type[] swigMethodTypes26 = new global::System.Type[] { typeof(PanGesture) };
        private static global::System.Type[] swigMethodTypes28 = new global::System.Type[] { typeof(bool) };
        private static global::System.Type[] swigMethodTypes29 = System.Array.Empty<global::System.Type>();
        private static global::System.Type[] swigMethodTypes30 = System.Array.Empty<global::System.Type>();
        private static global::System.Type[] swigMethodTypes31 = System.Array.Empty<global::System.Type>();
        private static global::System.Type[] swigMethodTypes32 = new global::System.Type[] { typeof(View), typeof(View.FocusDirection), typeof(bool) };
        private static global::System.Type[] swigMethodTypes33 = new global::System.Type[] { typeof(View) };
        private static global::System.Type[] swigMethodTypes34 = System.Array.Empty<global::System.Type>();
        private static global::System.Type[] swigMethodTypes35 = new global::System.Type[] { typeof(PinchGesture) };
        private static global::System.Type[] swigMethodTypes36 = new global::System.Type[] { typeof(PanGesture) };
        private static global::System.Type[] swigMethodTypes37 = new global::System.Type[] { typeof(TapGesture) };
        private static global::System.Type[] swigMethodTypes38 = new global::System.Type[] { typeof(LongPressGesture) };
        private static global::System.Type[] swigMethodTypes39 = new global::System.Type[] { typeof(SlotObserver), typeof(SWIGTYPE_p_Dali__CallbackBase) };
        private static global::System.Type[] swigMethodTypes40 = new global::System.Type[] { typeof(SlotObserver), typeof(SWIGTYPE_p_Dali__CallbackBase) };
    }
}
