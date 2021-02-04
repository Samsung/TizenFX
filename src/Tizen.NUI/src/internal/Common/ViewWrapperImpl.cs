/*
 * Copyright (c) 2020 Samsung Electronics Co., Ltd.
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
        public delegate void OnSceneConnectionDelegate(int depth);
        /// <since_tizen> 3 </since_tizen>
        public delegate void OnSceneDisconnectionDelegate();
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
        public delegate void OnStyleChangeDelegate(StyleManager styleManager, StyleChangeType change);
        /// <since_tizen> 3 </since_tizen>
        public delegate bool OnAccessibilityActivatedDelegate();
        /// <since_tizen> 3 </since_tizen>
        public delegate bool OnAccessibilityPanDelegate(PanGesture gestures);
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

        public new OnSceneConnectionDelegate OnSceneConnection;
        public new OnSceneDisconnectionDelegate OnSceneDisconnection;
        public OnSceneConnectionDelegate OnStageConnection;
        public OnSceneDisconnectionDelegate OnStageDisconnection;
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
        public new OnStyleChangeDelegate OnStyleChange;
        public new OnAccessibilityActivatedDelegate OnAccessibilityActivated;
        public new OnAccessibilityPanDelegate OnAccessibilityPan;
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

        internal ViewWrapperImpl(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ViewWrapperImpl obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                DirectorDisconnect();
            }

            base.Dispose(type);
        }

        public ViewWrapperImpl(CustomViewBehaviour behaviourFlags) : this(Interop.ViewWrapperImpl.NewViewWrapperImpl((int)behaviourFlags), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            DirectorConnect();
        }

        public static ViewWrapper New(string typeName, ViewWrapperImpl viewWrapper)
        {
            ViewWrapper ret = new ViewWrapper(Interop.ViewWrapperImpl.New(typeName, ViewWrapperImpl.getCPtr(viewWrapper)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void RelayoutRequest()
        {
            Interop.ViewWrapperImpl.RelayoutRequest(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public float GetHeightForWidthBase(float width)
        {
            float ret = Interop.ViewWrapperImpl.GetHeightForWidthBase(SwigCPtr, width);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public float GetWidthForHeightBase(float height)
        {
            float ret = Interop.ViewWrapperImpl.GetWidthForHeightBase(SwigCPtr, height);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public float CalculateChildSizeBase(View child, DimensionType dimension)
        {
            float ret = Interop.ViewWrapperImpl.CalculateChildSizeBase(SwigCPtr, View.getCPtr(child), (int)dimension);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool RelayoutDependentOnChildrenBase(DimensionType dimension)
        {
            bool ret = Interop.ViewWrapperImpl.RelayoutDependentOnChildrenBase(SwigCPtr, (int)dimension);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool RelayoutDependentOnChildrenBase()
        {
            bool ret = Interop.ViewWrapperImpl.RelayoutDependentOnChildrenBase(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void RegisterVisual(int index, VisualBase visual)
        {
            Interop.ViewWrapperImpl.RegisterVisual(SwigCPtr, index, VisualBase.getCPtr(visual));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void RegisterVisual(int index, VisualBase visual, bool enabled)
        {
            Interop.ViewWrapperImpl.RegisterVisual(SwigCPtr, index, VisualBase.getCPtr(visual), enabled);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void UnregisterVisual(int index)
        {
            Interop.ViewWrapperImpl.UnregisterVisual(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public VisualBase GetVisual(int index)
        {
            //to fix memory leak issue, match the handle count with native side.
            System.IntPtr cPtr = Interop.ViewWrapperImpl.GetVisual(SwigCPtr, index);
            VisualBase ret = this.GetInstanceSafely<VisualBase>(cPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void EnableVisual(int index, bool enable)
        {
            Interop.ViewWrapperImpl.EnableVisual(SwigCPtr, index, enable);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool IsVisualEnabled(int index)
        {
            bool ret = Interop.ViewWrapperImpl.IsVisualEnabled(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Animation CreateTransition(TransitionData transitionData)
        {
            Animation ret = new Animation(Interop.ViewWrapperImpl.CreateTransition(SwigCPtr, TransitionData.getCPtr(transitionData)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void EmitFocusSignal(bool focusGained)
        {
            Interop.ViewWrapperImpl.EmitKeyInputFocusSignal(SwigCPtr, focusGained);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void ApplyThemeStyle()
        {
            Interop.ViewWrapperImpl.ApplyThemeStyle(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private void DirectorConnect()
        {
            Delegate0 = new DelegateViewWrapperImpl_0(DirectorOnSceneConnection);
            Delegate1 = new DelegateViewWrapperImpl_1(DirectorOnSceneDisconnection);
            Delegate2 = new DelegateViewWrapperImpl_2(DirectorOnChildAdd);
            Delegate3 = new DelegateViewWrapperImpl_3(DirectorOnChildRemove);
            Delegate4 = new DelegateViewWrapperImpl_4(DirectorOnPropertySet);
            Delegate5 = new DelegateViewWrapperImpl_5(DirectorOnSizeSet);
            Delegate6 = new DelegateViewWrapperImpl_6(DirectorOnSizeAnimation);
            Delegate9 = new DelegateViewWrapperImpl_9(DirectorOnKey);
            Delegate11 = new DelegateViewWrapperImpl_11(DirectorOnRelayout);
            Delegate12 = new DelegateViewWrapperImpl_12(DirectorOnSetResizePolicy);
            Delegate13 = new DelegateViewWrapperImpl_13(DirectorGetNaturalSize);
            Delegate14 = new DelegateViewWrapperImpl_14(DirectorCalculateChildSize);
            Delegate15 = new DelegateViewWrapperImpl_15(DirectorGetHeightForWidth);
            Delegate16 = new DelegateViewWrapperImpl_16(DirectorGetWidthForHeight);
            Delegate17 = new DelegateViewWrapperImpl_17(DirectorRelayoutDependentOnChildrenWithDimension);
            Delegate18 = new DelegateViewWrapperImpl_18(DirectorRelayoutDependentOnChildren);
            Delegate19 = new DelegateViewWrapperImpl_19(DirectorOnCalculateRelayoutSize);
            Delegate20 = new DelegateViewWrapperImpl_20(DirectorOnLayoutNegotiated);
            Delegate21 = new DelegateViewWrapperImpl_21(DirectorOnInitialize);
            Delegate24 = new DelegateViewWrapperImpl_24(DirectorOnStyleChange);
            Delegate25 = new DelegateViewWrapperImpl_25(DirectorOnAccessibilityActivated);
            Delegate26 = new DelegateViewWrapperImpl_26(DirectorOnAccessibilityPan);
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
            Interop.ViewWrapperImpl.DirectorConnect(SwigCPtr, Delegate0, Delegate1, Delegate2, Delegate3, Delegate4, Delegate5, Delegate6, Delegate9, Delegate11, Delegate12, Delegate13, Delegate14, Delegate15, Delegate16, Delegate17, Delegate18, Delegate19, Delegate20, Delegate21, Delegate24, Delegate25, Delegate26, Delegate28, Delegate29, Delegate30, Delegate31, Delegate32, Delegate33, Delegate34, Delegate35, Delegate36, Delegate37, Delegate38, null, null);
        }


        private void DirectorDisconnect()
        {
            Delegate0 = null;
            Delegate1 = null;
            Delegate2 = null;
            Delegate3 = null;
            Delegate4 = null;
            Delegate5 = null;
            Delegate6 = null;
            Delegate9 = null;
            Delegate11 = null;
            Delegate12 = null;
            Delegate13 = null;
            Delegate14 = null;
            Delegate15 = null;
            Delegate16 = null;
            Delegate17 = null;
            Delegate18 = null;
            Delegate19 = null;
            Delegate20 = null;
            Delegate21 = null;
            Delegate24 = null;
            Delegate25 = null;
            Delegate26 = null;
            Delegate28 = null;
            Delegate29 = null;
            Delegate30 = null;
            Delegate31 = null;
            Delegate32 = null;
            Delegate33 = null;
            Delegate34 = null;
            Delegate35 = null;
            Delegate36 = null;
            Delegate37 = null;
            Delegate38 = null;
            Interop.ViewWrapperImpl.DirectorConnect(SwigCPtr, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
        }

        private void DirectorOnSceneConnection(int depth)
        {
            OnSceneConnection?.Invoke(depth);
            OnStageConnection?.Invoke(depth);
        }

        private void DirectorOnSceneDisconnection()
        {
            OnSceneDisconnection?.Invoke();
            OnStageDisconnection?.Invoke();
        }

        private void DirectorOnChildAdd(global::System.IntPtr child)
        {
            View view = Registry.GetManagedBaseHandleFromNativePtr(child) as View;
            if (view)
            {
                OnChildAdd?.Invoke(view);
            }
        }

        private void DirectorOnChildRemove(global::System.IntPtr child)
        {
            View view = Registry.GetManagedBaseHandleFromNativePtr(child) as View;
            if (view)
            {
                OnChildRemove?.Invoke(view);
            }
        }

        private void DirectorOnPropertySet(int index, global::System.IntPtr propertyValue)
        {
            var value = new PropertyValue(propertyValue, true);
            OnPropertySet?.Invoke(index, value);
            value.Dispose();
        }

        private void DirectorOnSizeSet(global::System.IntPtr targetSize)
        {
            var vector3 = new Vector3(targetSize, false);
            OnSizeSet?.Invoke(vector3);
            vector3.Dispose();
        }

        private void DirectorOnSizeAnimation(global::System.IntPtr animation, global::System.IntPtr targetSize)
        {
            var ani = new Animation(animation, true);
            var vector3 = new Vector3(targetSize, false);
            OnSizeAnimation?.Invoke(ani, vector3);
            ani.Dispose();
            vector3.Dispose();
        }

        private bool DirectorOnKey(global::System.IntPtr arg0)
        {
            var key = new Key(arg0, false);
            var ret = OnKey(key);
            key.Dispose();
            return ret;
        }

        private void DirectorOnRelayout(global::System.IntPtr size, global::System.IntPtr container)
        {
            var vector2 = new Vector2(size, false);
            var relayoutContainer = new RelayoutContainer(container, false);
            OnRelayout(vector2, relayoutContainer);
            vector2.Dispose();
            relayoutContainer.Dispose();
        }

        private void DirectorOnSetResizePolicy(int policy, int dimension)
        {
            OnSetResizePolicy?.Invoke((ResizePolicyType)policy, (DimensionType)dimension);
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
                return CalculateChildSize?.Invoke(view, (DimensionType)dimension) ?? 0.0f;
            }
            return 0.0f;
        }

        private float DirectorGetHeightForWidth(float width)
        {
            return GetHeightForWidth?.Invoke(width) ?? 0.0f;
        }

        private float DirectorGetWidthForHeight(float height)
        {
            return GetWidthForHeight?.Invoke(height) ?? 0.0f;
        }

        private bool DirectorRelayoutDependentOnChildrenWithDimension(int dimension)
        {
            return RelayoutDependentOnChildrenDimension?.Invoke((DimensionType)dimension) ?? false;
        }

        private bool DirectorRelayoutDependentOnChildren()
        {
            return RelayoutDependentOnChildren?.Invoke() ?? false;
        }

        private void DirectorOnCalculateRelayoutSize(int dimension)
        {
            OnCalculateRelayoutSize?.Invoke((DimensionType)dimension);
        }

        private void DirectorOnLayoutNegotiated(float size, int dimension)
        {
            OnLayoutNegotiated?.Invoke(size, (DimensionType)dimension);
        }

        private void DirectorOnInitialize()
        {
        }

        private void DirectorOnStyleChange(global::System.IntPtr styleManager, int change)
        {
            var styleManger = new StyleManager(styleManager, true);
            OnStyleChange?.Invoke(styleManger, (StyleChangeType)change);
            styleManger.Dispose();
        }

        private bool DirectorOnAccessibilityActivated()
        {
            return OnAccessibilityActivated?.Invoke() ?? false;
        }

        private bool DirectorOnAccessibilityPan(global::System.IntPtr gesture)
        {
            var panGesture = new PanGesture(gesture, true);
            var ret = OnAccessibilityPan?.Invoke(panGesture) ?? false;
            panGesture.Dispose();
            return ret;
        }

        private bool DirectorOnAccessibilityValueChange(bool isIncrease)
        {
            return OnAccessibilityValueChange?.Invoke(isIncrease) ?? false;
        }

        private bool DirectorOnAccessibilityZoom()
        {
            return OnAccessibilityZoom?.Invoke() ?? false;
        }

        private void DirectorOnFocusGained()
        {
            OnFocusGained?.Invoke();
        }

        private void DirectorOnFocusLost()
        {
            OnFocusLost?.Invoke();
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
            OnFocusChangeCommitted?.Invoke(Registry.GetManagedBaseHandleFromNativePtr(commitedFocusableView) as View);
        }

        private bool DirectorOnKeyboardEnter()
        {
            return OnKeyboardEnter?.Invoke() ?? false;
        }

        private void DirectorOnPinch(global::System.IntPtr pinch)
        {
            var pinchGesture = new PinchGesture(pinch, false);
            OnPinch?.Invoke(pinchGesture);
            pinchGesture.Dispose();
        }

        private void DirectorOnPan(global::System.IntPtr pan)
        {
            var panGesture = new PanGesture(pan, false);
            OnPan?.Invoke(panGesture);
            panGesture.Dispose();
        }

        private void DirectorOnTap(global::System.IntPtr tap)
        {
            var tapGesture = new TapGesture(tap, false);
            OnTap?.Invoke(tapGesture);
            tapGesture.Dispose();
        }

        private void DirectorOnLongPress(global::System.IntPtr longPress)
        {
            var longGesture = new LongPressGesture(longPress, false);
            OnLongPress?.Invoke(longGesture);
            longGesture.Dispose();
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
        public delegate bool DelegateViewWrapperImpl_9(global::System.IntPtr arg0);
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
        private DelegateViewWrapperImpl_9 Delegate9;
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
        private DelegateViewWrapperImpl_24 Delegate24;
        private DelegateViewWrapperImpl_25 Delegate25;
        private DelegateViewWrapperImpl_26 Delegate26;
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

        public static readonly int ViewBehaviourFlagCount = Interop.ViewWrapperImpl.ControlBehaviourFlagCountGet();
    }
}
