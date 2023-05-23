/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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
using global::System.Diagnostics;
using Tizen.NUI;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// View is the base class for all views.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class View
    {
        internal string styleName;

        internal virtual LayoutItem CreateDefaultLayout()
        {
            return new AbsoluteLayout();
        }

        internal class ThemeData
        {
            [Flags]
            private enum States : byte
            {
                None = 0,
                ControlStatePropagation = 1 << 0,
                ThemeChangeSensitive = 1 << 1,
                ThemeApplied = 1 << 2, // It is true when the view has valid style name or the platform theme has a component style for this view type.
                                       // That indicates the view can have different styles by theme.
                                       // Hence if the current state has ThemeApplied and ThemeChangeSensitive, the view will change its style by theme changing.
                ListeningThemeChangeEvent = 1 << 3,
            };

            private States states = ThemeManager.ApplicationThemeChangeSensitive ? States.ThemeChangeSensitive : States.None;
            public ViewStyle viewStyle;
            public ControlState controlStates = ControlState.Normal;
            public ViewSelectorData selectorData;

            public bool ControlStatePropagation
            {
                get => ((states & States.ControlStatePropagation) != 0);
                set => SetOption(States.ControlStatePropagation, value);
            }

            public bool ThemeChangeSensitive
            {
                get => ((states & States.ThemeChangeSensitive) != 0);
                set => SetOption(States.ThemeChangeSensitive, value);
            }

            public bool ThemeApplied
            {
                get => ((states & States.ThemeApplied) != 0);
                set => SetOption(States.ThemeApplied, value);
            }

            public bool ListeningThemeChangeEvent
            {
                get => ((states & States.ListeningThemeChangeEvent) != 0);
                set => SetOption(States.ListeningThemeChangeEvent, value);
            }

            private void SetOption(States option, bool value)
            {
                if (value) states |= option;
                else states &= ~option;
            }
        }

        /// <summary>
        /// The color mode of View.
        /// This specifies whether the View uses its own color, or inherits its parent color.
        /// The default is ColorMode.UseOwnMultiplyParentColor.
        /// </summary>
        internal ColorMode ColorMode
        {
            set
            {
                SetColorMode(value);
            }
            get
            {
                return GetColorMode();
            }
        }

        internal LayoutLength SuggestedMinimumWidth
        {
            get
            {
                float result = Interop.Actor.GetSuggestedMinimumWidth(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending)
                    throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return new LayoutLength(result);
            }
        }

        internal LayoutLength SuggestedMinimumHeight
        {
            get
            {
                float result = Interop.Actor.GetSuggestedMinimumHeight(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending)
                    throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return new LayoutLength(result);
            }
        }

        internal float WorldPositionX
        {
            get
            {

                return Object.InternalGetPropertyFloat(SwigCPtr, View.Property.WorldPositionX);
            }
        }

        internal float WorldPositionY
        {
            get
            {

                return Object.InternalGetPropertyFloat(SwigCPtr, View.Property.WorldPositionY);
            }
        }

        internal float WorldPositionZ
        {
            get
            {

                return Object.InternalGetPropertyFloat(SwigCPtr, View.Property.WorldPositionZ);
            }
        }

        internal bool FocusState
        {
            get
            {
                return IsKeyboardFocusable();
            }
            set
            {
                SetKeyboardFocusable(value);
            }
        }

        internal void SetLayout(LayoutItem layout)
        {
            LayoutCount++;

            this.layout = layout;
            this.layout?.AttachToOwner(this);
            this.layout?.RequestLayout();
        }

        internal void AttachTransitionsToChildren(LayoutTransition transition)
        {
            // Iterate children, adding the transition unless a transition
            // for the same condition and property has already been
            // explicitly added.
            foreach (View view in Children)
            {
                LayoutTransitionsHelper.AddTransitionForCondition(view.LayoutTransitions, transition.Condition, transition, false);
            }
        }

        internal float ParentOriginX
        {
            get
            {

                return Object.InternalGetPropertyFloat(SwigCPtr, View.Property.ParentOriginX);
            }
            set
            {

                Object.InternalSetPropertyFloat(SwigCPtr, View.Property.WorldPositionX, value);
                NotifyPropertyChanged();
            }
        }

        internal float ParentOriginY
        {
            get
            {

                return Object.InternalGetPropertyFloat(SwigCPtr, View.Property.ParentOriginY);
            }
            set
            {

                Object.InternalSetPropertyFloat(SwigCPtr, View.Property.ParentOriginY, value);
                NotifyPropertyChanged();
            }
        }

        internal float ParentOriginZ
        {
            get
            {

                return Object.InternalGetPropertyFloat(SwigCPtr, View.Property.ParentOriginZ);
            }
            set
            {

                Object.InternalSetPropertyFloat(SwigCPtr, View.Property.ParentOriginZ, value);
                NotifyPropertyChanged();
            }
        }

        internal float PivotPointX
        {
            get
            {

                return Object.InternalGetPropertyFloat(SwigCPtr, View.Property.AnchorPointX);
            }
            set
            {

                Object.InternalSetPropertyFloat(SwigCPtr, View.Property.AnchorPointX, value);
            }
        }

        internal float PivotPointY
        {
            get
            {

                return Object.InternalGetPropertyFloat(SwigCPtr, View.Property.AnchorPointY);
            }
            set
            {

                Object.InternalSetPropertyFloat(SwigCPtr, View.Property.AnchorPointY, value);
            }
        }

        internal float PivotPointZ
        {
            get
            {

                return Object.InternalGetPropertyFloat(SwigCPtr, View.Property.AnchorPointZ);
            }
            set
            {

                Object.InternalSetPropertyFloat(SwigCPtr, View.Property.AnchorPointZ, value);
            }
        }

        internal Matrix WorldMatrix
        {
            get
            {
                Matrix returnValue = new Matrix();
                PropertyValue wordMatrix = GetProperty(View.Property.WorldMatrix);
                wordMatrix?.Get(returnValue);
                wordMatrix?.Dispose();
                return returnValue;
            }
        }

        /// <summary>
        /// The number of layouts including view's layout and children's layouts.
        /// This can be used to set/unset Process callback to calculate Layout.
        /// </summary>
        internal int LayoutCount
        {
            get
            {
                return layoutCount;
            }

            set
            {
                if (layoutCount == value) return;

                if (value < 0) throw new global::System.ArgumentOutOfRangeException(nameof(LayoutCount), "LayoutCount(" + LayoutCount + ") should not be less than zero");

                int diff = value - layoutCount;
                layoutCount = value;

                if (InternalParent != null)
                {
                    var parentView = InternalParent as View;
                    if (parentView != null)
                    {
                        parentView.LayoutCount += diff;
                    }
                    else
                    {
                        var parentLayer = InternalParent as Layer;
                        if (parentLayer != null)
                        {
                            parentLayer.LayoutCount += diff;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Indicates that this View should listen Touch event to handle its ControlState.
        /// </summary>
        private bool enableControlState = false;

        private int LeftFocusableViewId
        {
            get
            {

                return Object.InternalGetPropertyInt(SwigCPtr, View.Property.LeftFocusableViewId);
            }
            set
            {

                Object.InternalSetPropertyInt(SwigCPtr, View.Property.LeftFocusableViewId, value);
            }
        }

        private int RightFocusableViewId
        {
            get
            {

                return Object.InternalGetPropertyInt(SwigCPtr, View.Property.RightFocusableViewId);
            }
            set
            {

                Object.InternalSetPropertyInt(SwigCPtr, View.Property.RightFocusableViewId, value);
            }
        }

        private int UpFocusableViewId
        {
            get
            {

                return Object.InternalGetPropertyInt(SwigCPtr, View.Property.UpFocusableViewId);
            }
            set
            {

                Object.InternalSetPropertyInt(SwigCPtr, View.Property.UpFocusableViewId, value);
            }
        }

        private int DownFocusableViewId
        {
            get
            {

                return Object.InternalGetPropertyInt(SwigCPtr, View.Property.DownFocusableViewId);
            }
            set
            {

                Object.InternalSetPropertyInt(SwigCPtr, View.Property.DownFocusableViewId, value);
            }
        }

        private int ClockwiseFocusableViewId
        {
            get
            {

                return Object.InternalGetPropertyInt(SwigCPtr, View.Property.ClockwiseFocusableViewId);
            }
            set
            {

                Object.InternalSetPropertyInt(SwigCPtr, View.Property.ClockwiseFocusableViewId, value);
            }
        }

        private int CounterClockwiseFocusableViewId
        {
            get
            {

                return Object.InternalGetPropertyInt(SwigCPtr, View.Property.CounterClockwiseFocusableViewId);
            }
            set
            {

                Object.InternalSetPropertyInt(SwigCPtr, View.Property.CounterClockwiseFocusableViewId, value);
            }
        }

        internal string GetName()
        {
            string ret = Interop.Actor.GetName(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetName(string name)
        {
            Interop.Actor.SetName(SwigCPtr, name);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal uint GetId()
        {
            uint ret = Interop.Actor.GetId(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal bool IsRoot()
        {
            bool ret = Interop.ActorInternal.IsRoot(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal bool OnWindow()
        {
            bool ret = Interop.Actor.OnStage(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal View FindChildById(uint id)
        {
            //to fix memory leak issue, match the handle count with native side.
            IntPtr cPtr = Interop.Actor.FindChildById(SwigCPtr, id);
            View ret = this.GetInstanceSafely<View>(cPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal override View FindCurrentChildById(uint id)
        {
            return FindChildById(id);
        }

        internal void SetParentOrigin(Position origin)
        {
            Interop.ActorInternal.SetParentOrigin(SwigCPtr, Position.getCPtr(origin));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Position GetCurrentParentOrigin()
        {

            if(internalCurrentParentOrigin == null)
            {
                internalCurrentParentOrigin = new Position(0, 0, 0);
            }

            Interop.ActorInternal.RetrieveCurrentPropertyVector3(SwigCPtr, View.Property.ParentOrigin, internalCurrentParentOrigin.SwigCPtr);

            if (NDalicPINVOKE.SWIGPendingException.Pending)
            {
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            return internalCurrentParentOrigin;
        }

        internal void SetAnchorPoint(Position anchorPoint)
        {
            Interop.Actor.SetAnchorPoint(SwigCPtr, Position.getCPtr(anchorPoint));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Position GetCurrentAnchorPoint()
        {

            if(internalCurrentAnchorPoint == null)
            {
                internalCurrentAnchorPoint = new Position(0, 0, 0);
            }

            Interop.ActorInternal.RetrieveCurrentPropertyVector3(SwigCPtr, View.Property.AnchorPoint, internalCurrentAnchorPoint.SwigCPtr);

            if (NDalicPINVOKE.SWIGPendingException.Pending)
            {
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            return internalCurrentAnchorPoint;
        }

        internal void SetSize(float width, float height)
        {
            Interop.ActorInternal.SetSize(SwigCPtr, width, height);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetSize(float width, float height, float depth)
        {
            Interop.ActorInternal.SetSize(SwigCPtr, width, height, depth);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetSize(Vector2 size)
        {
            Interop.ActorInternal.SetSizeVector2(SwigCPtr, Vector2.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetSize(Vector3 size)
        {
            Interop.ActorInternal.SetSizeVector3(SwigCPtr, Vector3.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector3 GetTargetSize()
        {

            if(internalTargetSize == null)
            {
                internalTargetSize = new Vector3(0, 0, 0);
            }
            
            Interop.ActorInternal.RetrieveTargetSize(SwigCPtr, internalTargetSize.SwigCPtr);
            
            if (NDalicPINVOKE.SWIGPendingException.Pending)
            {
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            return internalTargetSize;
        }

        internal Size2D GetCurrentSize()
        {

            if(internalCurrentSize == null)
            {
                internalCurrentSize = new Size2D(0, 0);
            }
            
            Interop.ActorInternal.RetrieveCurrentPropertyVector2ActualVector3(SwigCPtr, Property.SIZE, internalCurrentSize.SwigCPtr);

            if (NDalicPINVOKE.SWIGPendingException.Pending)
            {
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            return internalCurrentSize;
        }

        internal Size2D GetCurrentSizeFloat()
        {
            Size ret = new Size(Interop.Actor.GetCurrentSize(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// GetNaturalSize() function behaviour can be changed for each subclass of View.
        /// So we make GetNaturalSize() function virtual, and make subclass can define it's owned logic
        /// </summary>
        internal virtual Vector3 GetNaturalSize()
        {
            Vector3 ret = new Vector3(Interop.Actor.GetNaturalSize(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetX(float x)
        {
            Interop.ActorInternal.SetX(SwigCPtr, x);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetY(float y)
        {
            Interop.ActorInternal.SetY(SwigCPtr, y);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetZ(float z)
        {
            Interop.ActorInternal.SetZ(SwigCPtr, z);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void TranslateBy(Vector3 distance)
        {
            Interop.ActorInternal.TranslateBy(SwigCPtr, Vector3.getCPtr(distance));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Position GetCurrentPosition()
        {

            if(internalCurrentPosition == null)
            {
                internalCurrentPosition = new Position(0, 0, 0);
            }
            
            Interop.ActorInternal.RetrieveCurrentPropertyVector3(SwigCPtr, Property.POSITION, internalCurrentPosition.SwigCPtr);

            if (NDalicPINVOKE.SWIGPendingException.Pending)
            {
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            return internalCurrentPosition;
        }
        internal Vector3 GetCurrentWorldPosition()
        {

            if(internalCurrentWorldPosition == null)
            {
                internalCurrentWorldPosition = new Vector3(0, 0, 0);
            }
            
            Interop.ActorInternal.RetrieveCurrentPropertyVector3(SwigCPtr, View.Property.WorldPosition, internalCurrentWorldPosition.SwigCPtr);

            if (NDalicPINVOKE.SWIGPendingException.Pending)
            {
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            return internalCurrentWorldPosition;
        }

        internal Vector2 GetCurrentScreenPosition()
        {

            if(internalCurrentScreenPosition == null)
            {
                internalCurrentScreenPosition = new Vector2(0, 0);
            }

            Object.InternalRetrievingPropertyVector2(SwigCPtr, View.Property.ScreenPosition, internalCurrentScreenPosition.SwigCPtr);

            if (NDalicPINVOKE.SWIGPendingException.Pending)
            {
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            return internalCurrentScreenPosition;
        }

        internal Vector4 GetCurrentScreenPositionSize()
        {
            Vector4 ret = new Vector4(Interop.Actor.CalculateScreenExtents(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
            return ret;
        }

        internal void SetInheritPosition(bool inherit)
        {
            Interop.ActorInternal.SetInheritPosition(SwigCPtr, inherit);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal bool IsPositionInherited()
        {
            bool ret = Interop.ActorInternal.IsPositionInherited(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetOrientation(Degree angle, Vector3 axis)
        {
            Interop.ActorInternal.SetOrientationDegree(SwigCPtr, Degree.getCPtr(angle), Vector3.getCPtr(axis));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetOrientation(Radian angle, Vector3 axis)
        {
            Interop.ActorInternal.SetOrientationRadian(SwigCPtr, Radian.getCPtr(angle), Vector3.getCPtr(axis));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetOrientation(Rotation orientation)
        {
            Interop.ActorInternal.SetOrientationQuaternion(SwigCPtr, Rotation.getCPtr(orientation));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Rotation GetCurrentOrientation()
        {
            Rotation ret = new Rotation(Interop.ActorInternal.GetCurrentOrientation(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetInheritOrientation(bool inherit)
        {
            Interop.ActorInternal.SetInheritOrientation(SwigCPtr, inherit);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal bool IsOrientationInherited()
        {
            bool ret = Interop.ActorInternal.IsOrientationInherited(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Rotation GetCurrentWorldOrientation()
        {
            Rotation ret = new Rotation(Interop.ActorInternal.GetCurrentWorldOrientation(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetScale(float scale)
        {
            Interop.ActorInternal.SetScale(SwigCPtr, scale);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetScale(float scaleX, float scaleY, float scaleZ)
        {
            Interop.ActorInternal.SetScale(SwigCPtr, scaleX, scaleY, scaleZ);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetScale(Vector3 scale)
        {
            Interop.ActorInternal.SetScale(SwigCPtr, Vector3.getCPtr(scale));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector3 GetCurrentScale()
        {

            if(internalCurrentScale == null)
            {
                internalCurrentScale = new Vector3(0, 0, 0);
            }
            
            Interop.ActorInternal.RetrieveCurrentPropertyVector3(SwigCPtr, View.Property.SCALE, internalCurrentScale.SwigCPtr);

            if (NDalicPINVOKE.SWIGPendingException.Pending)
            {
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            return internalCurrentScale;
        }

        internal Vector3 GetCurrentWorldScale()
        {

            if(internalCurrentWorldScale == null)
            {
                internalCurrentWorldScale = new Vector3(0, 0, 0);
            }
            
            Interop.ActorInternal.RetrieveCurrentPropertyVector3(SwigCPtr, View.Property.WorldScale, internalCurrentWorldScale.SwigCPtr);

            if (NDalicPINVOKE.SWIGPendingException.Pending)
            {
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            return internalCurrentWorldScale;
        }

        internal void SetInheritScale(bool inherit)
        {
            Interop.ActorInternal.SetInheritScale(SwigCPtr, inherit);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal bool IsScaleInherited()
        {
            bool ret = Interop.ActorInternal.IsScaleInherited(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Matrix GetCurrentWorldMatrix()
        {
            Matrix ret = new Matrix(Interop.ActorInternal.GetCurrentWorldMatrix(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetVisible(bool visible)
        {
            Interop.Actor.SetVisible(SwigCPtr, visible);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieve the View's current Visibility.
        /// </summary>
        /// <remarks>
        /// The <see cref="Visibility"/> property is set in the main thread, so it is not updated in real time when the value is changed in the render thread.
        /// However, this method can get the current actual value updated in real time.
        /// </remarks>
        internal bool IsVisible()
        {
            bool ret = Interop.ActorInternal.IsVisible(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetOpacity(float opacity)
        {
            Interop.ActorInternal.SetOpacity(SwigCPtr, opacity);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal float GetCurrentOpacity()
        {
            float ret = Interop.ActorInternal.GetCurrentOpacity(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Vector4 GetCurrentColor()
        {

            if(internalCurrentColor == null)
            {
                internalCurrentColor = new Vector4(0, 0, 0, 0);
            }
            
            Interop.ActorInternal.RetrieveCurrentPropertyVector4(SwigCPtr, Interop.ActorProperty.ColorGet(), internalCurrentColor.SwigCPtr);

            if (NDalicPINVOKE.SWIGPendingException.Pending)
            {
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            return internalCurrentColor;
        }
        internal ColorMode GetColorMode()
        {
            ColorMode ret = (ColorMode)Interop.ActorInternal.GetColorMode(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Vector4 GetCurrentWorldColor()
        {

            if(internalCurrentWorldColor == null)
            {
                internalCurrentWorldColor = new Vector4(0, 0, 0, 0);
            }
            
            Interop.ActorInternal.RetrieveCurrentPropertyVector4(SwigCPtr, Property.WorldColor, internalCurrentWorldColor.SwigCPtr);

            if (NDalicPINVOKE.SWIGPendingException.Pending)
            {
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            return internalCurrentWorldColor;
        }

        internal void SetDrawMode(DrawModeType drawMode)
        {
            Interop.ActorInternal.SetDrawMode(SwigCPtr, (int)drawMode);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal DrawModeType GetDrawMode()
        {
            DrawModeType ret = (DrawModeType)Interop.ActorInternal.GetDrawMode(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetKeyboardFocusable(bool focusable)
        {
            Interop.ActorInternal.SetKeyboardFocusable(SwigCPtr, focusable);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal bool IsKeyboardFocusable()
        {
            bool ret = Interop.ActorInternal.IsKeyboardFocusable(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetKeyboardFocusableChildren(bool focusable)
        {
            Interop.ActorInternal.SetKeyboardFocusableChildren(SwigCPtr, focusable);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal bool AreChildrenKeyBoardFocusable()
        {
            bool ret = Interop.ActorInternal.AreChildrenKeyBoardFocusable(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetFocusableInTouch(bool enabled)
        {
            Interop.ActorInternal.SetFocusableInTouch(SwigCPtr, enabled);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal bool IsFocusableInTouch()
        {
            bool ret = Interop.ActorInternal.IsFocusableInTouch(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetResizePolicy(ResizePolicyType policy, DimensionType dimension)
        {
            Interop.Actor.SetResizePolicy(SwigCPtr, (int)policy, (int)dimension);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal ResizePolicyType GetResizePolicy(DimensionType dimension)
        {
            ResizePolicyType ret = (ResizePolicyType)Interop.Actor.GetResizePolicy(SwigCPtr, (int)dimension);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Vector3 GetSizeModeFactor()
        {

                if (internalSizeModeFactor == null)
                {
                    internalSizeModeFactor = new Vector3(OnSizeModeFactorChanged, 0, 0, 0);
                }
                Object.InternalRetrievingPropertyVector3(SwigCPtr, View.Property.SizeModeFactor, internalSizeModeFactor.SwigCPtr);
                return internalSizeModeFactor;
        }

        internal void SetMinimumSize(Vector2 size)
        {
            Interop.ActorInternal.SetMinimumSize(SwigCPtr, Vector2.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector2 GetMinimumSize()
        {

            if (internalMinimumSize == null)
            {
                internalMinimumSize = new Size2D(OnMinimumSizeChanged, 0, 0);
            }
            Object.InternalRetrievingPropertyVector2(SwigCPtr, View.Property.MinimumSize, internalMinimumSize.SwigCPtr);
            return internalMinimumSize;
        }

        internal void SetMaximumSize(Vector2 size)
        {
            Interop.ActorInternal.SetMaximumSize(SwigCPtr, Vector2.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector2 GetMaximumSize()
        {

            if (internalMaximumSize == null)
            {
                internalMaximumSize = new Size2D(OnMaximumSizeChanged, 0, 0);
            }
            Object.InternalRetrievingPropertyVector2(SwigCPtr, View.Property.MaximumSize, internalMaximumSize.SwigCPtr);
            return internalMaximumSize;
        }

        internal int GetHierarchyDepth()
        {
            int ret = Interop.Actor.GetHierarchyDepth(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal uint GetRendererCount()
        {
            uint ret = Interop.Actor.GetRendererCount(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(View obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        internal bool IsTopLevelView()
        {
            if (GetParent() is Layer)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check whether Current view don't has BackgroundVisual or not.
        /// Some API (like Animation, Borderline) required non-empty backgrounds.
        /// </summary>
        internal bool IsBackgroundEmpty()
        {

            int visualType = (int)Visual.Type.Invalid;
            Interop.View.InternalRetrievingVisualPropertyInt(this.SwigCPtr, Property.BACKGROUND, Visual.Property.Type, out visualType);
            return visualType == (int)Visual.Type.Invalid;
        }

        internal void SetKeyInputFocus()
        {
            Interop.ViewInternal.SetKeyInputFocus(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void ClearKeyInputFocus()
        {
            Interop.ViewInternal.ClearKeyInputFocus(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PinchGestureDetector GetPinchGestureDetector()
        {
            PinchGestureDetector ret = new PinchGestureDetector(Interop.ViewInternal.GetPinchGestureDetector(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal PanGestureDetector GetPanGestureDetector()
        {
            PanGestureDetector ret = new PanGestureDetector(Interop.ViewInternal.GetPanGestureDetector(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal TapGestureDetector GetTapGestureDetector()
        {
            TapGestureDetector ret = new TapGestureDetector(Interop.ViewInternal.GetTapGestureDetector(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal LongPressGestureDetector GetLongPressGestureDetector()
        {
            LongPressGestureDetector ret = new LongPressGestureDetector(Interop.ViewInternal.GetLongPressGestureDetector(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal IntPtr GetPtrfromView()
        {
            return (IntPtr)SwigCPtr;
        }

        internal void RemoveChild(View child)
        {
            // If the view had focus, it clears focus.
            if (child == FocusManager.Instance.GetCurrentFocusView())
            {
                FocusManager.Instance.ClearFocus();
            }
            // Do actual child removal
            Interop.Actor.Remove(SwigCPtr, View.getCPtr(child));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            Children.Remove(child);
            child.InternalParent = null;
            LayoutCount -= child.LayoutCount;

            OnChildRemoved(child);
            if (ChildRemoved != null)
            {
                ChildRemovedEventArgs e = new ChildRemovedEventArgs
                {
                    Removed = child
                };
                ChildRemoved(this, e);
            }
        }

        /// <summary>
        /// Removes the layout from this View.
        /// </summary>
        internal void ResetLayout()
        {
            LayoutCount--;

            layout = null;
        }

        internal ResourceLoadingStatusType GetBackgroundResourceStatus()
        {
            return (ResourceLoadingStatusType)Interop.View.GetVisualResourceStatus(this.SwigCPtr, Property.BACKGROUND);
        }

        /// TODO open as a protected level
        internal virtual void ApplyCornerRadius()
        {
            if (backgroundExtraData == null) return;


            // Update corner radius properties to background and shadow by ActionUpdateProperty
            if (backgroundExtraData.CornerRadius != null)
            {
                Interop.View.InternalUpdateVisualPropertyVector4(this.SwigCPtr, View.Property.BACKGROUND, Visual.Property.CornerRadius, Vector4.getCPtr(backgroundExtraData.CornerRadius));
                Interop.View.InternalUpdateVisualPropertyVector4(this.SwigCPtr, View.Property.SHADOW, Visual.Property.CornerRadius, Vector4.getCPtr(backgroundExtraData.CornerRadius));
            }
            Interop.View.InternalUpdateVisualPropertyInt(this.SwigCPtr, View.Property.BACKGROUND, Visual.Property.CornerRadiusPolicy, (int)backgroundExtraData.CornerRadiusPolicy);
            Interop.View.InternalUpdateVisualPropertyInt(this.SwigCPtr, View.Property.SHADOW, Visual.Property.CornerRadiusPolicy, (int)backgroundExtraData.CornerRadiusPolicy);
        }

        /// TODO open as a protected level
        internal virtual void ApplyBorderline()
        {
            if (backgroundExtraData == null) return;


            // ActionUpdateProperty works well only if BACKGROUND visual setup before.
            // If view don't have BACKGROUND visual, we set transparent background color in default.
            if (IsBackgroundEmpty())
            {
                // BACKGROUND visual doesn't exist.
                SetBackgroundColor(Color.Transparent);
                // SetBackgroundColor function apply borderline internally.
                // So we can just return now.
                return;
            }

            // Update borderline properties to background by ActionUpdateProperty
            Interop.View.InternalUpdateVisualPropertyFloat(this.SwigCPtr, View.Property.BACKGROUND, Visual.Property.BorderlineWidth, backgroundExtraData.BorderlineWidth);
            Interop.View.InternalUpdateVisualPropertyVector4(this.SwigCPtr, View.Property.BACKGROUND, Visual.Property.BorderlineColor, Vector4.getCPtr(backgroundExtraData.BorderlineColor ?? Color.Black));
            Interop.View.InternalUpdateVisualPropertyFloat(this.SwigCPtr, View.Property.BACKGROUND, Visual.Property.BorderlineOffset, backgroundExtraData.BorderlineOffset);
        }

        /// <summary>
        /// Get selector value from the triggerable selector or related property.
        /// </summary>
        internal Selector<T> GetSelector<T>(TriggerableSelector<T> triggerableSelector, NUI.Binding.BindableProperty relatedProperty)
        {
            var selector = triggerableSelector?.Get();
            if (selector != null)
            {
                return selector;
            }

            var value = (T)GetValue(relatedProperty);
            return value == null ? null : new Selector<T>(value);
        }

        internal void SetThemeApplied()
        {
            if (themeData == null) themeData = new ThemeData();
            themeData.ThemeApplied = true;

            if (ThemeChangeSensitive && !themeData.ListeningThemeChangeEvent)
            {
                themeData.ListeningThemeChangeEvent = true;
                ThemeManager.ThemeChangedInternal.Add(OnThemeChanged);
            }
        }

        /// <summary>
        /// you can override it to clean-up your own resources.
        /// </summary>
        /// <param name="type">DisposeTypes</param>
        /// <since_tizen> 3 </since_tizen>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            disposeDebugging(type);

            //_mergedStyle = null;

            internalMaximumSize?.Dispose();
            internalMaximumSize = null;
            internalMinimumSize?.Dispose();
            internalMinimumSize = null;
            internalMargin?.Dispose();
            internalMargin = null;
            internalPadding?.Dispose();
            internalPadding = null;
            internalSizeModeFactor?.Dispose();
            internalSizeModeFactor = null;
            internalCellIndex?.Dispose();
            internalCellIndex = null;
            internalBackgroundColor?.Dispose();
            internalBackgroundColor = null;
            internalColor?.Dispose();
            internalColor = null;
            internalPivotPoint?.Dispose();
            internalPivotPoint = null;
            internalPosition?.Dispose();
            internalPosition = null;
            internalPosition2D?.Dispose();
            internalPosition2D = null;
            internalScale?.Dispose();
            internalScale = null;
            internalSize?.Dispose();
            internalSize = null;
            internalSize2D?.Dispose();
            internalSize2D = null;

            panGestureDetector?.Dispose();
            panGestureDetector = null;
            longGestureDetector?.Dispose();
            longGestureDetector = null;
            pinchGestureDetector?.Dispose();
            pinchGestureDetector = null;
            tapGestureDetector?.Dispose();
            tapGestureDetector = null;
            rotationGestureDetector?.Dispose();
            rotationGestureDetector = null;


            internalCurrentParentOrigin?.Dispose();
            internalCurrentParentOrigin = null;
            internalCurrentAnchorPoint?.Dispose();
            internalCurrentAnchorPoint = null;
            internalTargetSize?.Dispose();
            internalTargetSize = null;
            internalCurrentSize?.Dispose();
            internalCurrentSize = null;
            internalCurrentPosition?.Dispose();
            internalCurrentPosition = null;
            internalCurrentWorldPosition?.Dispose();
            internalCurrentWorldPosition = null;
            internalCurrentScale?.Dispose();
            internalCurrentScale = null;
            internalCurrentWorldScale?.Dispose();
            internalCurrentWorldScale = null;
            internalCurrentColor?.Dispose();
            internalCurrentColor = null;
            internalCurrentWorldColor?.Dispose();
            internalCurrentWorldColor = null;
            internalSizeModeFactor?.Dispose();
            internalSizeModeFactor = null;
            internalCurrentScreenPosition?.Dispose();
            internalCurrentScreenPosition = null;

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
                if (themeData != null)
                {
                    themeData.selectorData?.Reset(this);
                    if (themeData.ListeningThemeChangeEvent)
                    {
                        ThemeManager.ThemeChangedInternal.Remove(OnThemeChanged);
                    }
                }
                if (widthConstraint != null)
                {
                    widthConstraint.Remove();
                    widthConstraint.Dispose();
                }
                if (heightConstraint != null)
                {
                    heightConstraint.Remove();
                    heightConstraint.Dispose();
                }
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            DisConnectFromSignals();

            foreach (View view in Children)
            {
                view.InternalParent = null;
            }

            LayoutCount = 0;

            NUILog.Debug($"[Dispose] View.Dispose({type}) END");
            NUILog.Debug($"=============================");

            base.Dispose(type);
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.View.DeleteView(swigCPtr);
        }

        /// <summary>
        /// The touch event handler for ControlState.
        /// Please change ControlState value by touch state if needed.
        /// </summary>
        /// <exception cref="ArgumentNullException"> Thrown when touch is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual bool HandleControlStateOnTouch(Touch touch)
        {
            if (touch == null)
            {
                throw new global::System.ArgumentNullException(nameof(touch));
            }

            switch (touch.GetState(0))
            {
                case PointStateType.Down:
                    ControlState += ControlState.Pressed;
                    break;
                case PointStateType.Interrupted:
                case PointStateType.Up:
                    if (ControlState.Contains(ControlState.Pressed))
                    {
                        ControlState -= ControlState.Pressed;
                    }
                    break;
                default:
                    break;
            }
            return false;
        }

        /// <summary>
        /// Internal callback of enabled property changes.
        /// Inherited view can override this method to implements enabled property changes.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnEnabled(bool enabled)
        {
            if (enabled)
            {
                if (State == View.States.Disabled)
                {
                    State = View.States.Normal;
                }
                if (enableControlState)
                {
                    ControlState -= ControlState.Disabled;
                }
            }
            else
            {
                State = View.States.Disabled;
                if (enableControlState)
                {
                    ControlState += ControlState.Disabled;
                }
            }
        }


        private void DisConnectFromSignals()
        {
            if (HasBody() == false)
            {
                NUILog.Debug($"[Dispose] DisConnectFromSignals() No native body! No need to Disconnect Signals!");
                return;
            }
            NUILog.Debug($"[Dispose] DisConnectFromSignals START");
            NUILog.Debug($"[Dispose] View.DisConnectFromSignals() type:{GetType()} copyNativeHandle:{GetBaseHandleCPtrHandleRef.Handle.ToString("X8")}");
            NUILog.Debug($"[Dispose] ID:{Interop.Actor.GetId(GetBaseHandleCPtrHandleRef)} Name:{Interop.Actor.GetName(GetBaseHandleCPtrHandleRef)}");

            if (onRelayoutEventCallback != null)
            {
                NUILog.Debug($"[Dispose] onRelayoutEventCallback");

                Interop.ActorSignal.OnRelayoutDisconnect(GetBaseHandleCPtrHandleRef, onRelayoutEventCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExistsDebug();
                onRelayoutEventCallback = null;
            }

            if (offWindowEventCallback != null)
            {
                NUILog.Debug($"[Dispose] offWindowEventCallback");

                Interop.ActorSignal.OffSceneDisconnect(GetBaseHandleCPtrHandleRef, offWindowEventCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExistsDebug();
                offWindowEventCallback = null;
            }

            if (onWindowEventCallback != null)
            {
                NUILog.Debug($"[Dispose] onWindowEventCallback");

                Interop.ActorSignal.OnSceneDisconnect(GetBaseHandleCPtrHandleRef, onWindowEventCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExistsDebug();
                onWindowEventCallback = null;
            }

            if (wheelEventCallback != null)
            {
                NUILog.Debug($"[Dispose] wheelEventCallback");

                Interop.ActorSignal.WheelEventDisconnect(GetBaseHandleCPtrHandleRef, wheelEventCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExistsDebug();
                wheelEventCallback = null;
            }

            if (hoverEventCallback != null)
            {
                NUILog.Debug($"[Dispose] hoverEventCallback");

                Interop.ActorSignal.HoveredDisconnect(GetBaseHandleCPtrHandleRef, hoverEventCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExistsDebug();
                hoverEventCallback = null;
            }

            if (hitTestResultDataCallback != null)
            {
                NUILog.Debug($"[Dispose] hitTestResultDataCallback");

                Interop.ActorSignal.HitTestResultDisconnect(GetBaseHandleCPtrHandleRef, hitTestResultDataCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExistsDebug();
                hitTestResultDataCallback = null;
            }


            if (interceptTouchDataCallback != null)
            {
                NUILog.Debug($"[Dispose] interceptTouchDataCallback");

                Interop.ActorSignal.InterceptTouchDisconnect(GetBaseHandleCPtrHandleRef, interceptTouchDataCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExistsDebug();
                interceptTouchDataCallback = null;
            }

            if (touchDataCallback != null)
            {
                NUILog.Debug($"[Dispose] touchDataCallback");

                Interop.ActorSignal.TouchDisconnect(GetBaseHandleCPtrHandleRef, touchDataCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExistsDebug();
                touchDataCallback = null;
            }

            if (resourcesLoadedCallback != null)
            {
                NUILog.Debug($"[Dispose] ResourcesLoadedCallback");

                Interop.ViewSignal.ResourceReadyDisconnect(GetBaseHandleCPtrHandleRef, resourcesLoadedCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExistsDebug();
                resourcesLoadedCallback = null;
            }

            if (keyCallback != null)
            {
                NUILog.Debug($"[Dispose] keyCallback");

                Interop.ViewSignal.KeyEventDisconnect(GetBaseHandleCPtrHandleRef, keyCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExistsDebug();
                keyCallback = null;
            }

            if (keyInputFocusLostCallback != null)
            {
                NUILog.Debug($"[Dispose] keyInputFocusLostCallback");

                Interop.ViewSignal.KeyInputFocusLostDisconnect(GetBaseHandleCPtrHandleRef, keyInputFocusLostCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExistsDebug();
                keyInputFocusLostCallback = null;
                keyInputFocusLostEventHandler = null;
            }

            if (keyInputFocusGainedCallback != null)
            {
                NUILog.Debug($"[Dispose] keyInputFocusGainedCallback");

                Interop.ViewSignal.KeyInputFocusGainedDisconnect(GetBaseHandleCPtrHandleRef, keyInputFocusGainedCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExistsDebug();
                keyInputFocusGainedCallback = null;
                keyInputFocusGainedEventHandler = null;
            }

            if (backgroundResourceLoadedCallback != null)
            {
                NUILog.Debug($"[Dispose] backgroundResourceLoadedCallback");

                Interop.ViewSignal.ResourceReadyDisconnect(GetBaseHandleCPtrHandleRef, backgroundResourceLoadedCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExistsDebug();
                backgroundResourceLoadedCallback = null;
            }

            NDalicPINVOKE.ThrowExceptionIfExists();
            NUILog.Debug($"[Dispose] DisConnectFromSignals END");
        }

        /// <summary>
        /// Apply initial style to the view.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void InitializeStyle(ViewStyle style = null)
        {
            if (style == null && ThemeManager.InitialThemeDisabled)
            {
                // Fast return in most TV cases.
                return;
            }

            var initialStyle = ThemeManager.GetInitialStyleWithoutClone(GetType());
            if (style == null)
            {
                ApplyStyle(initialStyle);
            }
            else
            {
                var refinedStyle = style;
                if (style.IncludeDefaultStyle)
                {
                    refinedStyle = initialStyle?.Merge(style);
                }
                ApplyStyle(refinedStyle);
            }

            // Listen theme change event if needs.
            if (initialStyle != null)
            {
                SetThemeApplied();
            }
        }

        private View ConvertIdToView(uint id)
        {
            View view = GetParent()?.FindCurrentChildById(id);

            //If we can't find the parent's children, find in the top layer.
            if (!view)
            {
                Container parent = GetParent();
                while ((parent is View) && (parent != null))
                {
                    parent = parent.GetParent();
                    if (parent is Layer)
                    {
                        view = parent.FindCurrentChildById(id);
                        break;
                    }
                }
            }

            return view;
        }

        private void OnScaleChanged(float x, float y, float z)
        {
            Scale = new Vector3(x, y, z);
        }

        private void OnBackgroundColorChanged(float r, float g, float b, float a)
        {
            BackgroundColor = new Color(r, g, b, a);
        }

        private void OnPaddingChanged(ushort start, ushort end, ushort top, ushort bottom)
        {
            Padding = new Extents(start, end, top, bottom);
        }

        private void OnMarginChanged(ushort start, ushort end, ushort top, ushort bottom)
        {
            Margin = new Extents(start, end, top, bottom);
        }

        private void OnAnchorPointChanged(float x, float y, float z)
        {
            AnchorPoint = new Position(x, y, z);
        }

        private void OnCellIndexChanged(float x, float y)
        {
            CellIndex = new Vector2(x, y);
        }

        private void OnFlexMarginChanged(float x, float y, float z, float w)
        {
            FlexMargin = new Vector4(x, y, z, w);
        }

        private void OnPaddingEXChanged(ushort start, ushort end, ushort top, ushort bottom)
        {
            PaddingEX = new Extents(start, end, top, bottom);
        }

        private void OnSizeModeFactorChanged(float x, float y, float z)
        {
            SizeModeFactor = new Vector3(x, y, z);
        }

        private bool EmptyOnTouch(object target, TouchEventArgs args)
        {
            return false;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual bool CheckResourceReady()
        {
            return true;
        }

        private ViewSelectorData EnsureSelectorData()
        {
            if (themeData == null) themeData = new ThemeData();

            return themeData.selectorData ?? (themeData.selectorData = new ViewSelectorData());
        }

        [Conditional("NUI_DISPOSE_DEBUG_ON")]
        private void disposeDebugging(DisposeTypes type)
        {
            DebugFileLogging.Instance.WriteLog($"View.Dispose({type}) START");
            DebugFileLogging.Instance.WriteLog($"type:{GetType()} copyNativeHandle:{GetBaseHandleCPtrHandleRef.Handle.ToString("X8")}");
            if (HasBody())
            {
                DebugFileLogging.Instance.WriteLog($"ID:{Interop.Actor.GetId(GetBaseHandleCPtrHandleRef)} Name:{Interop.Actor.GetName(GetBaseHandleCPtrHandleRef)}");
            }
            else
            {
                DebugFileLogging.Instance.WriteLog($"has no native body!");
            }
        }

    }
}
