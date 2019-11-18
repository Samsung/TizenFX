/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd.
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
using System.Runtime.InteropServices;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    internal sealed class ViewWrapperImpl : ViewImpl
    {
        /// <since_tizen> 3 </since_tizen>
        public delegate void OnStageConnectionDelegate(int depth);
        /// <since_tizen> 3 </since_tizen>
        public delegate void OnStageDisconnectionDelegate();
        /// <since_tizen> 3 </since_tizen>
        public delegate void OnChildAddDelegate(View view);
        /// <since_tizen> 3 </since_tizen>
        public delegate void OnChildRemoveDelegate(View view);
        /// <since_tizen> 3 </since_tizen>
        public delegate void OnPropertySetDelegate(int index, PropertyValue propertyValue);
        /// <since_tizen> 3 </since_tizen>
        public delegate void OnSizeSetDelegate(Vector3 targetSize);
        /// <since_tizen> 3 </since_tizen>
        public delegate void OnSizeAnimationDelegate(Animation animation, Vector3 targetSize);
        /// <since_tizen> 3 </since_tizen>
        public delegate bool OnTouchDelegate(Touch touch);
        /// <since_tizen> 3 </since_tizen>
        public delegate bool OnHoverDelegate(Hover hover);
        /// <since_tizen> 3 </since_tizen>
        public delegate bool OnKeyDelegate(Key key);
        /// <since_tizen> 3 </since_tizen>
        public delegate bool OnWheelDelegate(Wheel wheel);
        /// <since_tizen> 3 </since_tizen>
        public delegate void OnRelayoutDelegate(Vector2 size, RelayoutContainer container);
        /// <since_tizen> 3 </since_tizen>
        public delegate void OnSetResizePolicyDelegate(ResizePolicyType policy, DimensionType dimension);
        /// <since_tizen> 3 </since_tizen>
        public delegate Size2D GetNaturalSizeDelegate();
        /// <since_tizen> 3 </since_tizen>
        public delegate float CalculateChildSizeDelegate(View child, DimensionType dimension);
        /// <since_tizen> 3 </since_tizen>
        public delegate float GetHeightForWidthDelegate(float width);
        /// <since_tizen> 3 </since_tizen>
        public delegate float GetWidthForHeightDelegate(float height);
        /// <since_tizen> 3 </since_tizen>
        public delegate bool RelayoutDependentOnChildrenDimensionDelegate(DimensionType dimension);
        /// <since_tizen> 3 </since_tizen>
        public delegate bool RelayoutDependentOnChildrenDelegate();
        /// <since_tizen> 3 </since_tizen>
        public delegate void OnCalculateRelayoutSizeDelegate(DimensionType dimension);
        /// <since_tizen> 3 </since_tizen>
        public delegate void OnLayoutNegotiatedDelegate(float size, DimensionType dimension);
        /// <since_tizen> 3 </since_tizen>
        public delegate void OnControlChildAddDelegate(View child);
        /// <since_tizen> 3 </since_tizen>
        public delegate void OnControlChildRemoveDelegate(View child);
        /// <since_tizen> 3 </since_tizen>
        public delegate void OnStyleChangeDelegate(StyleManager styleManager, StyleChangeType change);
        /// <since_tizen> 3 </since_tizen>
        public delegate bool OnAccessibilityActivatedDelegate();
        /// <since_tizen> 3 </since_tizen>
        public delegate bool OnAccessibilityPanDelegate(PanGesture gestures);
        /// <since_tizen> 3 </since_tizen>
        public delegate bool OnAccessibilityTouchDelegate(Touch touch);
        /// <since_tizen> 3 </since_tizen>
        public delegate bool OnAccessibilityValueChangeDelegate(bool isIncrease);
        /// <since_tizen> 3 </since_tizen>
        public delegate bool OnAccessibilityZoomDelegate();
        /// <since_tizen> 3 </since_tizen>
        public delegate void OnFocusGainedDelegate();
        /// <since_tizen> 3 </since_tizen>
        public delegate void OnFocusLostDelegate();
        /// <since_tizen> 3 </since_tizen>
        public delegate View GetNextFocusableViewDelegate(View currentFocusedView, View.FocusDirection direction, bool loopEnabled);
        /// <since_tizen> 3 </since_tizen>
        public delegate void OnFocusChangeCommittedDelegate(View commitedFocusableView);
        /// <since_tizen> 3 </since_tizen>
        public delegate bool OnKeyboardEnterDelegate();
        /// <since_tizen> 3 </since_tizen>
        public delegate void OnPinchDelegate(PinchGesture pinch);
        /// <since_tizen> 3 </since_tizen>
        public delegate void OnPanDelegate(PanGesture pan);
        /// <since_tizen> 3 </since_tizen>
        public delegate void OnTapDelegate(TapGesture tap);
        /// <since_tizen> 3 </since_tizen>
        public delegate void OnLongPressDelegate(LongPressGesture longPress);

        public new OnStageConnectionDelegate OnStageConnection;
        public new OnStageDisconnectionDelegate OnStageDisconnection;
        public new OnChildAddDelegate OnChildAdd;
        public new OnChildRemoveDelegate OnChildRemove;
        public new OnPropertySetDelegate OnPropertySet;
        public new OnSizeSetDelegate OnSizeSet;
        public new OnSizeAnimationDelegate OnSizeAnimation;
        public OnTouchDelegate OnTouch;
        public OnHoverDelegate OnHover;
        public OnKeyDelegate OnKey;
        public OnWheelDelegate OnWheel;
        public new OnRelayoutDelegate OnRelayout;
        public new OnSetResizePolicyDelegate OnSetResizePolicy;
        public new GetNaturalSizeDelegate GetNaturalSize;
        public new CalculateChildSizeDelegate CalculateChildSize;
        public new GetHeightForWidthDelegate GetHeightForWidth;
        public new GetWidthForHeightDelegate GetWidthForHeight;
        public RelayoutDependentOnChildrenDimensionDelegate RelayoutDependentOnChildrenDimension;
        public new RelayoutDependentOnChildrenDelegate RelayoutDependentOnChildren;
        public new OnCalculateRelayoutSizeDelegate OnCalculateRelayoutSize;
        public new OnLayoutNegotiatedDelegate OnLayoutNegotiated;
        public new OnControlChildAddDelegate OnControlChildAdd;
        public new OnControlChildRemoveDelegate OnControlChildRemove;
        public new OnStyleChangeDelegate OnStyleChange;
        public new OnAccessibilityActivatedDelegate OnAccessibilityActivated;
        public new OnAccessibilityPanDelegate OnAccessibilityPan;
        public new OnAccessibilityTouchDelegate OnAccessibilityTouch;
        public new OnAccessibilityValueChangeDelegate OnAccessibilityValueChange;
        public new OnAccessibilityZoomDelegate OnAccessibilityZoom;
        public OnFocusGainedDelegate OnFocusGained;
        public OnFocusLostDelegate OnFocusLost;
        public new GetNextFocusableViewDelegate GetNextFocusableView;
        public new OnFocusChangeCommittedDelegate OnFocusChangeCommitted;
        public new OnKeyboardEnterDelegate OnKeyboardEnter;
        public new OnPinchDelegate OnPinch;
        public new OnPanDelegate OnPan;
        public new OnTapDelegate OnTap;
        public new OnLongPressDelegate OnLongPress;

        internal ViewWrapperImpl(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.ViewWrapperImpl.ViewWrapperImpl_SWIGUpcast(cPtr), cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ViewWrapperImpl obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
        }

        public ViewWrapperImpl(CustomViewBehaviour behaviourFlags) : this(Interop.ViewWrapperImpl.new_ViewWrapperImpl((int)behaviourFlags), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            DirectorConnect();
        }

        public static ViewWrapper New(string typeName, ViewWrapperImpl viewWrapper)
        {
            ViewWrapper ret = new ViewWrapper(Interop.ViewWrapperImpl.ViewWrapperImpl_New(typeName, ViewWrapperImpl.getCPtr(viewWrapper)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void RelayoutRequest()
        {
            Interop.ViewWrapperImpl.ViewWrapperImpl_RelayoutRequest(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public float GetHeightForWidthBase(float width)
        {
            float ret = Interop.ViewWrapperImpl.ViewWrapperImpl_GetHeightForWidthBase(swigCPtr, width);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public float GetWidthForHeightBase(float height)
        {
            float ret = Interop.ViewWrapperImpl.ViewWrapperImpl_GetWidthForHeightBase(swigCPtr, height);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public float CalculateChildSizeBase(View child, DimensionType dimension)
        {
            float ret = Interop.ViewWrapperImpl.ViewWrapperImpl_CalculateChildSizeBase(swigCPtr, View.getCPtr(child), (int)dimension);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool RelayoutDependentOnChildrenBase(DimensionType dimension)
        {
            bool ret = Interop.ViewWrapperImpl.ViewWrapperImpl_RelayoutDependentOnChildrenBase__SWIG_0(swigCPtr, (int)dimension);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool RelayoutDependentOnChildrenBase()
        {
            bool ret = Interop.ViewWrapperImpl.ViewWrapperImpl_RelayoutDependentOnChildrenBase__SWIG_1(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void RegisterVisual(int index, VisualBase visual)
        {
            Interop.ViewWrapperImpl.ViewWrapperImpl_RegisterVisual__SWIG_0(swigCPtr, index, VisualBase.getCPtr(visual));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void RegisterVisual(int index, VisualBase visual, bool enabled)
        {
            Interop.ViewWrapperImpl.ViewWrapperImpl_RegisterVisual__SWIG_1(swigCPtr, index, VisualBase.getCPtr(visual), enabled);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void UnregisterVisual(int index)
        {
            Interop.ViewWrapperImpl.ViewWrapperImpl_UnregisterVisual(swigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public VisualBase GetVisual(int index)
        {
            //to fix memory leak issue, match the handle count with native side.
            System.IntPtr cPtr = Interop.ViewWrapperImpl.ViewWrapperImpl_GetVisual(swigCPtr, index);
            VisualBase ret = this.GetInstanceSafely<VisualBase>(cPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void EnableVisual(int index, bool enable)
        {
            Interop.ViewWrapperImpl.ViewWrapperImpl_EnableVisual(swigCPtr, index, enable);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool IsVisualEnabled(int index)
        {
            bool ret = Interop.ViewWrapperImpl.ViewWrapperImpl_IsVisualEnabled(swigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Animation CreateTransition(TransitionData transitionData)
        {
            Animation ret = new Animation(Interop.ViewWrapperImpl.ViewWrapperImpl_CreateTransition(swigCPtr, TransitionData.getCPtr(transitionData)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void EmitFocusSignal(bool focusGained)
        {
            Interop.ViewWrapperImpl.ViewWrapperImpl_EmitKeyInputFocusSignal(swigCPtr, focusGained);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void ApplyThemeStyle()
        {
            Interop.ViewWrapperImpl.ViewWrapperImpl_ApplyThemeStyle(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private void DirectorConnect()
        {
            Delegate0 = new DelegateViewWrapperImpl_0(DirectorOnStageConnection);
            Delegate1 = new DelegateViewWrapperImpl_1(DirectorOnStageDisconnection);
            Delegate2 = new DelegateViewWrapperImpl_2(DirectorOnChildAdd);
            Delegate3 = new DelegateViewWrapperImpl_3(DirectorOnChildRemove);
            Delegate4 = new DelegateViewWrapperImpl_4(DirectorOnPropertySet);
            Delegate5 = new DelegateViewWrapperImpl_5(DirectorOnSizeSet);
            Delegate6 = new DelegateViewWrapperImpl_6(DirectorOnSizeAnimation);
            Delegate7 = new DelegateViewWrapperImpl_7(DirectorOnTouch);
            Delegate8 = new DelegateViewWrapperImpl_8(DirectorOnHover);
            Delegate9 = new DelegateViewWrapperImpl_9(DirectorOnKey);
            Delegate10 = new DelegateViewWrapperImpl_10(DirectorOnWheel);
            Delegate11 = new DelegateViewWrapperImpl_11(DirectorOnRelayout);
            Delegate12 = new DelegateViewWrapperImpl_12(DirectorOnSetResizePolicy);
            Delegate13 = new DelegateViewWrapperImpl_13(DirectorGetNaturalSize);
            Delegate14 = new DelegateViewWrapperImpl_14(DirectorCalculateChildSize);
            Delegate15 = new DelegateViewWrapperImpl_15(DirectorGetHeightForWidth);
            Delegate16 = new DelegateViewWrapperImpl_16(DirectorGetWidthForHeight);
            Delegate17 = new DelegateViewWrapperImpl_17(DirectorRelayoutDependentOnChildren__SWIG_0);
            Delegate18 = new DelegateViewWrapperImpl_18(DirectorRelayoutDependentOnChildren__SWIG_1);
            Delegate19 = new DelegateViewWrapperImpl_19(DirectorOnCalculateRelayoutSize);
            Delegate20 = new DelegateViewWrapperImpl_20(DirectorOnLayoutNegotiated);
            Delegate21 = new DelegateViewWrapperImpl_21(DirectorOnInitialize);
            Delegate22 = new DelegateViewWrapperImpl_22(DirectorOnControlChildAdd);
            Delegate23 = new DelegateViewWrapperImpl_23(DirectorOnControlChildRemove);
            Delegate24 = new DelegateViewWrapperImpl_24(DirectorOnStyleChange);
            Delegate25 = new DelegateViewWrapperImpl_25(DirectorOnAccessibilityActivated);
            Delegate26 = new DelegateViewWrapperImpl_26(DirectorOnAccessibilityPan);
            Delegate27 = new DelegateViewWrapperImpl_27(DirectorOnAccessibilityTouch);
            Delegate28 = new DelegateViewWrapperImpl_28(DirectorOnAccessibilityValueChange);
            Delegate29 = new DelegateViewWrapperImpl_29(DirectorOnAccessibilityZoom);
            Delegate30 = new DelegateViewWrapperImpl_30(DirectorOnFocusGained);
            Delegate31 = new DelegateViewWrapperImpl_31(DirectorOnFocusLost);
            Delegate32 = new DelegateViewWrapperImpl_32(DirectorGetNextFocusableActor);
            Delegate33 = new DelegateViewWrapperImpl_33(DirectorOnFocusChangeCommitted);
            Delegate34 = new DelegateViewWrapperImpl_34(DirectorOnKeyboardEnter);
            Delegate35 = new DelegateViewWrapperImpl_35(DirectorOnPinch);
            Delegate36 = new DelegateViewWrapperImpl_36(DirectorOnPan);
            Delegate37 = new DelegateViewWrapperImpl_37(DirectorOnTap);
            Delegate38 = new DelegateViewWrapperImpl_38(DirectorOnLongPress);
            Interop.ViewWrapperImpl.ViewWrapperImpl_director_connect(swigCPtr, Delegate0, Delegate1, Delegate2, Delegate3, Delegate4, Delegate5, Delegate6, Delegate7, Delegate8, Delegate9, Delegate10, Delegate11, Delegate12, Delegate13, Delegate14, Delegate15, Delegate16, Delegate17, Delegate18, Delegate19, Delegate20, Delegate21, Delegate22, Delegate23, Delegate24, Delegate25, Delegate26, Delegate27, Delegate28, Delegate29, Delegate30, Delegate31, Delegate32, Delegate33, Delegate34, Delegate35, Delegate36, Delegate37, Delegate38, null, null);
        }

        private void DirectorOnStageConnection(int depth)
        {
            OnStageConnection(depth);
        }

        private void DirectorOnStageDisconnection()
        {
            OnStageDisconnection();
        }

        private void DirectorOnChildAdd(global::System.IntPtr child)
        {
            View view = Registry.GetManagedBaseHandleFromNativePtr(child) as View;
            if (view)
            {
                OnChildAdd(view);
            }
        }

        private void DirectorOnChildRemove(global::System.IntPtr child)
        {
            View view = Registry.GetManagedBaseHandleFromNativePtr(child) as View;
            if (view)
            {
                OnChildRemove(view);
            }
        }

        private void DirectorOnPropertySet(int index, global::System.IntPtr propertyValue)
        {
            if (OnPropertySet != null)
            {
                OnPropertySet(index, new PropertyValue(propertyValue, true));
            }
        }

        private void DirectorOnSizeSet(global::System.IntPtr targetSize)
        {
            OnSizeSet(new Vector3(targetSize, false));
        }

        private void DirectorOnSizeAnimation(global::System.IntPtr animation, global::System.IntPtr targetSize)
        {
            OnSizeAnimation(new Animation(animation, false), new Vector3(targetSize, false));
        }

        private bool DirectorOnTouch(global::System.IntPtr arg0)
        {
            return OnTouch(new Touch(arg0, false));
        }

        private bool DirectorOnHover(global::System.IntPtr arg0)
        {
            return OnHover(new Hover(arg0, false));
        }

        private bool DirectorOnKey(global::System.IntPtr arg0)
        {
            return OnKey(new Key(arg0, false));
        }

        private bool DirectorOnWheel(global::System.IntPtr arg0)
        {
            return OnWheel(new Wheel(arg0, false));
        }

        private void DirectorOnRelayout(global::System.IntPtr size, global::System.IntPtr container)
        {
            OnRelayout(new Vector2(size, false), new RelayoutContainer(container, false));
        }

        private void DirectorOnSetResizePolicy(int policy, int dimension)
        {
            OnSetResizePolicy((ResizePolicyType)policy, (DimensionType)dimension);
        }

        private global::System.IntPtr DirectorGetNaturalSize()
        {
            return Size2D.getCPtr(GetNaturalSize()).Handle;
        }

        private float DirectorCalculateChildSize(global::System.IntPtr child, int dimension)
        {
            View view = Registry.GetManagedBaseHandleFromNativePtr(child) as View;
            if (view)
            {
                return CalculateChildSize(view, (DimensionType)dimension);
            }
            return 0.0f;
        }

        private float DirectorGetHeightForWidth(float width)
        {
            return GetHeightForWidth(width);
        }

        private float DirectorGetWidthForHeight(float height)
        {
            return GetWidthForHeight(height);
        }

        private bool DirectorRelayoutDependentOnChildren__SWIG_0(int dimension)
        {
            return RelayoutDependentOnChildrenDimension((DimensionType)dimension);
        }

        private bool DirectorRelayoutDependentOnChildren__SWIG_1()
        {
            return RelayoutDependentOnChildren();
        }

        private void DirectorOnCalculateRelayoutSize(int dimension)
        {
            OnCalculateRelayoutSize((DimensionType)dimension);
        }

        private void DirectorOnLayoutNegotiated(float size, int dimension)
        {
            OnLayoutNegotiated(size, (DimensionType)dimension);
        }

        private void DirectorOnInitialize()
        {
        }

        private void DirectorOnControlChildAdd(global::System.IntPtr child)
        {
            View view = Registry.GetManagedBaseHandleFromNativePtr(child) as View;
            if (view)
            {
                OnControlChildAdd(view);
            }
        }

        private void DirectorOnControlChildRemove(global::System.IntPtr child)
        {
            View view = Registry.GetManagedBaseHandleFromNativePtr(child) as View;
            if (view)
            {
                OnControlChildRemove(view);
            }
        }

        private void DirectorOnStyleChange(global::System.IntPtr styleManager, int change)
        {
            if (OnStyleChange != null)
            {
                OnStyleChange(new StyleManager(styleManager, false), (StyleChangeType)change);
            }
        }

        private bool DirectorOnAccessibilityActivated()
        {
            return OnAccessibilityActivated();
        }

        private bool DirectorOnAccessibilityPan(global::System.IntPtr gesture)
        {
            return OnAccessibilityPan(new PanGesture(gesture, false));
        }

        private bool DirectorOnAccessibilityTouch(global::System.IntPtr touch)
        {
            return OnAccessibilityTouch(new Touch(touch, false));
        }

        private bool DirectorOnAccessibilityValueChange(bool isIncrease)
        {
            return OnAccessibilityValueChange(isIncrease);
        }

        private bool DirectorOnAccessibilityZoom()
        {
            return OnAccessibilityZoom();
        }

        private void DirectorOnFocusGained()
        {
            OnFocusGained();
        }

        private void DirectorOnFocusLost()
        {
            OnFocusLost();
        }

        private global::System.IntPtr DirectorGetNextFocusableActor(global::System.IntPtr currentFocusedActor, int direction, bool loopEnabled)
        {
            View view = GetNextFocusableView(Registry.GetManagedBaseHandleFromNativePtr(currentFocusedActor) as View, (View.FocusDirection)direction, loopEnabled);
            if (view)
            {
                return View.getCPtr(view).Handle;
            }
            else
            {
                return currentFocusedActor;
            }
        }

        private void DirectorOnFocusChangeCommitted(global::System.IntPtr commitedFocusableView)
        {
            OnFocusChangeCommitted(Registry.GetManagedBaseHandleFromNativePtr(commitedFocusableView) as View);
        }

        private bool DirectorOnKeyboardEnter()
        {
            return OnKeyboardEnter();
        }

        private void DirectorOnPinch(global::System.IntPtr pinch)
        {
            OnPinch(new PinchGesture(pinch, false));
        }

        private void DirectorOnPan(global::System.IntPtr pan)
        {
            OnPan(new PanGesture(pan, false));
        }

        private void DirectorOnTap(global::System.IntPtr tap)
        {
            OnTap(new TapGesture(tap, false));
        }

        private void DirectorOnLongPress(global::System.IntPtr longPress)
        {
            OnLongPress(new LongPressGesture(longPress, false));
        }

        /// <since_tizen> 3 </since_tizen>
        public delegate void DelegateViewWrapperImpl_0(int depth);
        /// <since_tizen> 3 </since_tizen>
        public delegate void DelegateViewWrapperImpl_1();
        /// <since_tizen> 3 </since_tizen>
        public delegate void DelegateViewWrapperImpl_2(global::System.IntPtr child);
        /// <since_tizen> 3 </since_tizen>
        public delegate void DelegateViewWrapperImpl_3(global::System.IntPtr child);
        /// <since_tizen> 3 </since_tizen>
        public delegate void DelegateViewWrapperImpl_4(int index, global::System.IntPtr propertyValue);
        /// <since_tizen> 3 </since_tizen>
        public delegate void DelegateViewWrapperImpl_5(global::System.IntPtr targetSize);
        /// <since_tizen> 3 </since_tizen>
        public delegate void DelegateViewWrapperImpl_6(global::System.IntPtr animation, global::System.IntPtr targetSize);
        /// <since_tizen> 3 </since_tizen>
        public delegate bool DelegateViewWrapperImpl_7(global::System.IntPtr arg0);
        /// <since_tizen> 3 </since_tizen>
        public delegate bool DelegateViewWrapperImpl_8(global::System.IntPtr arg0);
        /// <since_tizen> 3 </since_tizen>
        public delegate bool DelegateViewWrapperImpl_9(global::System.IntPtr arg0);
        /// <since_tizen> 3 </since_tizen>
        public delegate bool DelegateViewWrapperImpl_10(global::System.IntPtr arg0);
        /// <since_tizen> 3 </since_tizen>
        public delegate void DelegateViewWrapperImpl_11(global::System.IntPtr size, global::System.IntPtr container);
        /// <since_tizen> 3 </since_tizen>
        public delegate void DelegateViewWrapperImpl_12(int policy, int dimension);
        /// <since_tizen> 3 </since_tizen>
        public delegate global::System.IntPtr DelegateViewWrapperImpl_13();
        /// <since_tizen> 3 </since_tizen>
        public delegate float DelegateViewWrapperImpl_14(global::System.IntPtr child, int dimension);
        /// <since_tizen> 3 </since_tizen>
        public delegate float DelegateViewWrapperImpl_15(float width);
        /// <since_tizen> 3 </since_tizen>
        public delegate float DelegateViewWrapperImpl_16(float height);
        /// <since_tizen> 3 </since_tizen>
        public delegate bool DelegateViewWrapperImpl_17(int dimension);
        /// <since_tizen> 3 </since_tizen>
        public delegate bool DelegateViewWrapperImpl_18();
        /// <since_tizen> 3 </since_tizen>
        public delegate void DelegateViewWrapperImpl_19(int dimension);
        /// <since_tizen> 3 </since_tizen>
        public delegate void DelegateViewWrapperImpl_20(float size, int dimension);
        /// <since_tizen> 3 </since_tizen>
        public delegate void DelegateViewWrapperImpl_21();
        /// <since_tizen> 3 </since_tizen>
        public delegate void DelegateViewWrapperImpl_22(global::System.IntPtr child);
        /// <since_tizen> 3 </since_tizen>
        public delegate void DelegateViewWrapperImpl_23(global::System.IntPtr child);
        /// <since_tizen> 3 </since_tizen>
        public delegate void DelegateViewWrapperImpl_24(global::System.IntPtr styleManager, int change);
        /// <since_tizen> 3 </since_tizen>
        public delegate bool DelegateViewWrapperImpl_25();
        /// <since_tizen> 3 </since_tizen>
        public delegate bool DelegateViewWrapperImpl_26(global::System.IntPtr gesture);
        /// <since_tizen> 3 </since_tizen>
        public delegate bool DelegateViewWrapperImpl_27(global::System.IntPtr touch);
        /// <since_tizen> 3 </since_tizen>
        public delegate bool DelegateViewWrapperImpl_28(bool isIncrease);
        /// <since_tizen> 3 </since_tizen>
        public delegate bool DelegateViewWrapperImpl_29();
        /// <since_tizen> 3 </since_tizen>
        public delegate void DelegateViewWrapperImpl_30();
        /// <since_tizen> 3 </since_tizen>
        public delegate void DelegateViewWrapperImpl_31();
        /// <since_tizen> 3 </since_tizen>
        public delegate global::System.IntPtr DelegateViewWrapperImpl_32(global::System.IntPtr currentFocusedActor, int direction, bool loopEnabled);
        /// <since_tizen> 3 </since_tizen>
        public delegate void DelegateViewWrapperImpl_33(global::System.IntPtr commitedFocusableActor);
        /// <since_tizen> 3 </since_tizen>
        public delegate bool DelegateViewWrapperImpl_34();
        /// <since_tizen> 3 </since_tizen>
        public delegate void DelegateViewWrapperImpl_35(global::System.IntPtr pinch);
        /// <since_tizen> 3 </since_tizen>
        public delegate void DelegateViewWrapperImpl_36(global::System.IntPtr pan);
        /// <since_tizen> 3 </since_tizen>
        public delegate void DelegateViewWrapperImpl_37(global::System.IntPtr tap);
        /// <since_tizen> 3 </since_tizen>
        public delegate void DelegateViewWrapperImpl_38(global::System.IntPtr longPress);
        /// <since_tizen> 3 </since_tizen>
        public delegate void DelegateViewWrapperImpl_39(global::System.IntPtr slotObserver, global::System.IntPtr callback);
        /// <since_tizen> 3 </since_tizen>
        public delegate void DelegateViewWrapperImpl_40(global::System.IntPtr slotObserver, global::System.IntPtr callback);

        private DelegateViewWrapperImpl_0 Delegate0;
        private DelegateViewWrapperImpl_1 Delegate1;
        private DelegateViewWrapperImpl_2 Delegate2;
        private DelegateViewWrapperImpl_3 Delegate3;
        private DelegateViewWrapperImpl_4 Delegate4;
        private DelegateViewWrapperImpl_5 Delegate5;
        private DelegateViewWrapperImpl_6 Delegate6;
        private DelegateViewWrapperImpl_7 Delegate7;
        private DelegateViewWrapperImpl_8 Delegate8;
        private DelegateViewWrapperImpl_9 Delegate9;
        private DelegateViewWrapperImpl_10 Delegate10;
        private DelegateViewWrapperImpl_11 Delegate11;
        private DelegateViewWrapperImpl_12 Delegate12;
        private DelegateViewWrapperImpl_13 Delegate13;
        private DelegateViewWrapperImpl_14 Delegate14;
        private DelegateViewWrapperImpl_15 Delegate15;
        private DelegateViewWrapperImpl_16 Delegate16;
        private DelegateViewWrapperImpl_17 Delegate17;
        private DelegateViewWrapperImpl_18 Delegate18;
        private DelegateViewWrapperImpl_19 Delegate19;
        private DelegateViewWrapperImpl_20 Delegate20;
        private DelegateViewWrapperImpl_21 Delegate21;
        private DelegateViewWrapperImpl_22 Delegate22;
        private DelegateViewWrapperImpl_23 Delegate23;
        private DelegateViewWrapperImpl_24 Delegate24;
        private DelegateViewWrapperImpl_25 Delegate25;
        private DelegateViewWrapperImpl_26 Delegate26;
        private DelegateViewWrapperImpl_27 Delegate27;
        private DelegateViewWrapperImpl_28 Delegate28;
        private DelegateViewWrapperImpl_29 Delegate29;
        private DelegateViewWrapperImpl_30 Delegate30;
        private DelegateViewWrapperImpl_31 Delegate31;
        private DelegateViewWrapperImpl_32 Delegate32;
        private DelegateViewWrapperImpl_33 Delegate33;
        private DelegateViewWrapperImpl_34 Delegate34;
        private DelegateViewWrapperImpl_35 Delegate35;
        private DelegateViewWrapperImpl_36 Delegate36;
        private DelegateViewWrapperImpl_37 Delegate37;
        private DelegateViewWrapperImpl_38 Delegate38;

        public static readonly int VIEW_BEHAVIOUR_FLAG_COUNT = Interop.ViewWrapperImpl.ViewWrapperImpl_CONTROL_BEHAVIOUR_FLAG_COUNT_get();
    }
}
