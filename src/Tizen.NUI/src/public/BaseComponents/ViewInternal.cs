﻿/*
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
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// View is the base class for all views.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class View
    {
        private MergedStyle mergedStyle = null;
        private ViewSelectorData selectorData;
        internal string styleName;

        internal MergedStyle _mergedStyle
        {
            get
            {
                if (null == mergedStyle)
                {
                    mergedStyle = new MergedStyle(GetType(), this);
                }

                return mergedStyle;
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

        internal float WorldPositionX
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue wordPositionX = GetProperty(View.Property.WORLD_POSITION_X);
                wordPositionX?.Get(out returnValue);
                wordPositionX?.Dispose();
                return returnValue;
            }
        }

        internal float WorldPositionY
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue wordPositionY = GetProperty(View.Property.WORLD_POSITION_Y);
                wordPositionY?.Get(out returnValue);
                wordPositionY?.Dispose();
                return returnValue;
            }
        }

        internal float WorldPositionZ
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue wordPositionZ = GetProperty(View.Property.WORLD_POSITION_Z);
                wordPositionZ?.Get(out returnValue);
                wordPositionZ?.Dispose();
                return returnValue;
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
            _layout = layout;
            _layout?.AttachToOwner(this);
            _layout?.RequestLayout();
        }

        /// <summary>
        /// Stores the calculated width value and its ModeType. Width component.
        /// </summary>
        internal MeasureSpecification MeasureSpecificationWidth
        {
            set
            {
                _measureSpecificationWidth = value;
                _layout?.RequestLayout();
            }
            get
            {
                return _measureSpecificationWidth;
            }
        }

        /// <summary>
        /// Stores the calculated width value and its ModeType. Height component.
        /// </summary>
        internal MeasureSpecification MeasureSpecificationHeight
        {
            set
            {
                _measureSpecificationHeight = value;
                _layout?.RequestLayout();
            }
            get
            {
                return _measureSpecificationHeight;
            }
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
                float returnValue = 0.0f;
                PropertyValue parentOriginX = GetProperty(View.Property.PARENT_ORIGIN_X);
                parentOriginX?.Get(out returnValue);
                parentOriginX?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(View.Property.PARENT_ORIGIN_X, setValue);
                setValue.Dispose();
                NotifyPropertyChanged();
            }
        }

        internal float ParentOriginY
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue parentOriginY = GetProperty(View.Property.PARENT_ORIGIN_Y);
                parentOriginY?.Get(out returnValue);
                parentOriginY?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(View.Property.PARENT_ORIGIN_Y, setValue);
                setValue.Dispose();
                NotifyPropertyChanged();
            }
        }

        internal float ParentOriginZ
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue parentOriginZ = GetProperty(View.Property.PARENT_ORIGIN_Z);
                parentOriginZ?.Get(out returnValue);
                parentOriginZ?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(View.Property.PARENT_ORIGIN_Z, setValue);
                setValue.Dispose();
                NotifyPropertyChanged();
            }
        }

        internal float PivotPointX
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue anchorPointX = GetProperty(View.Property.ANCHOR_POINT_X);
                anchorPointX?.Get(out returnValue);
                anchorPointX?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(View.Property.ANCHOR_POINT_X, setValue);
                setValue.Dispose();
            }
        }

        internal float PivotPointY
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue anchorPointY = GetProperty(View.Property.ANCHOR_POINT_Y);
                anchorPointY?.Get(out returnValue);
                anchorPointY?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(View.Property.ANCHOR_POINT_Y, setValue);
                setValue.Dispose();
            }
        }

        internal float PivotPointZ
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue anchorPointZ = GetProperty(View.Property.ANCHOR_POINT_Z);
                anchorPointZ?.Get(out returnValue);
                anchorPointZ?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(View.Property.ANCHOR_POINT_Z, setValue);
                setValue.Dispose();
            }
        }

        internal Matrix WorldMatrix
        {
            get
            {
                Matrix returnValue = new Matrix();
                PropertyValue wordMatrix = GetProperty(View.Property.WORLD_MATRIX);
                wordMatrix?.Get(returnValue);
                wordMatrix?.Dispose();
                return returnValue;
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
                int returnValue = 0;
                PropertyValue leftFocusableViewId = GetProperty(View.Property.LEFT_FOCUSABLE_VIEW_ID);
                leftFocusableViewId?.Get(out returnValue);
                leftFocusableViewId?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(View.Property.LEFT_FOCUSABLE_VIEW_ID, setValue);
                setValue.Dispose();
            }
        }

        private int RightFocusableViewId
        {
            get
            {
                int returnValue = 0;
                PropertyValue rightFocusableViewId = GetProperty(View.Property.RIGHT_FOCUSABLE_VIEW_ID);
                rightFocusableViewId?.Get(out returnValue);
                rightFocusableViewId?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(View.Property.RIGHT_FOCUSABLE_VIEW_ID, setValue);
                setValue.Dispose();
            }
        }

        private int UpFocusableViewId
        {
            get
            {
                int returnValue = 0;
                PropertyValue upFocusableViewId = GetProperty(View.Property.UP_FOCUSABLE_VIEW_ID);
                upFocusableViewId?.Get(out returnValue);
                upFocusableViewId?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(View.Property.UP_FOCUSABLE_VIEW_ID, setValue);
                setValue.Dispose();
            }
        }

        private int DownFocusableViewId
        {
            get
            {
                int returnValue = 0;
                PropertyValue downFocusableViewId = GetProperty(View.Property.DOWN_FOCUSABLE_VIEW_ID);
                downFocusableViewId?.Get(out returnValue);
                downFocusableViewId?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(View.Property.DOWN_FOCUSABLE_VIEW_ID, setValue);
                setValue.Dispose();
            }
        }

        private ViewSelectorData SelectorData
        {
            get
            {
                if (selectorData == null)
                {
                    selectorData = new ViewSelectorData();
                }
                return selectorData;
            }
        }

        internal void Raise()
        {
            var parentChildren = GetParent()?.Children;

            if (parentChildren != null)
            {
                int currentIndex = parentChildren.IndexOf(this);

                // If the view is not already the last item in the list.
                if (currentIndex >= 0 && currentIndex < parentChildren.Count - 1)
                {
                    View temp = parentChildren[currentIndex + 1];
                    parentChildren[currentIndex + 1] = this;
                    parentChildren[currentIndex] = temp;

                    Interop.NDalic.Raise(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending)
                        throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
            }
        }

        internal void Lower()
        {
            var parentChildren = GetParent()?.Children;

            if (parentChildren != null)
            {
                int currentIndex = parentChildren.IndexOf(this);

                // If the view is not already the first item in the list.
                if (currentIndex > 0 && currentIndex < parentChildren.Count)
                {
                    View temp = parentChildren[currentIndex - 1];
                    parentChildren[currentIndex - 1] = this;
                    parentChildren[currentIndex] = temp;

                    Interop.NDalic.Lower(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending)
                        throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
            }
        }

        /// <summary>
        /// Raises the view to above the target view.
        /// </summary>
        /// <remarks>The sibling order of views within the parent will be updated automatically.
        /// Views on the level above the target view will still be shown above this view.
        /// Raising this view above views with the same sibling order as each other will raise this view above them.
        /// Once a raise or lower API is used that view will then have an exclusive sibling order independent of insertion.
        /// </remarks>
        /// <param name="target">Will be raised above this view.</param>
        internal void RaiseAbove(View target)
        {
            var parentChildren = GetParent()?.Children;

            if (parentChildren != null)
            {
                int currentIndex = parentChildren.IndexOf(this);
                int targetIndex = parentChildren.IndexOf(target);

                if (currentIndex < 0 || targetIndex < 0 ||
                    currentIndex >= parentChildren.Count || targetIndex >= parentChildren.Count)
                {
                    NUILog.Error("index should be bigger than 0 and less than children of layer count");
                    return;
                }
                // If the currentIndex is less than the target index and the target has the same parent.
                if (currentIndex < targetIndex)
                {
                    parentChildren.Remove(this);
                    parentChildren.Insert(targetIndex, this);

                    Interop.NDalic.RaiseAbove(swigCPtr, View.getCPtr(target));
                    if (NDalicPINVOKE.SWIGPendingException.Pending)
                        throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
            }

        }

        /// <summary>
        /// Lowers the view to below the target view.
        /// </summary>
        /// <remarks>The sibling order of views within the parent will be updated automatically.
        /// Lowering this view below views with the same sibling order as each other will lower this view above them.
        /// Once a raise or lower API is used that view will then have an exclusive sibling order independent of insertion.
        /// </remarks>
        /// <param name="target">Will be lowered below this view.</param>
        internal void LowerBelow(View target)
        {
            var parentChildren = GetParent()?.Children;

            if (parentChildren != null)
            {
                int currentIndex = parentChildren.IndexOf(this);
                int targetIndex = parentChildren.IndexOf(target);
                if (currentIndex < 0 || targetIndex < 0 ||
                   currentIndex >= parentChildren.Count || targetIndex >= parentChildren.Count)
                {
                    NUILog.Error("index should be bigger than 0 and less than children of layer count");
                    return;
                }

                // If the currentIndex is not already the 0th index and the target has the same parent.
                if ((currentIndex != 0) && (targetIndex != -1) &&
                    (currentIndex > targetIndex))
                {
                    parentChildren.Remove(this);
                    parentChildren.Insert(targetIndex, this);

                    Interop.NDalic.LowerBelow(swigCPtr, View.getCPtr(target));
                    if (NDalicPINVOKE.SWIGPendingException.Pending)
                        throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
            }

        }

        internal string GetName()
        {
            string ret = Interop.Actor.ActorGetName(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetName(string name)
        {
            Interop.Actor.ActorSetName(swigCPtr, name);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal uint GetId()
        {
            uint ret = Interop.Actor.ActorGetId(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal bool IsRoot()
        {
            bool ret = Interop.ActorInternal.ActorIsRoot(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal bool OnWindow()
        {
            bool ret = Interop.Actor.ActorOnStage(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal View FindChildById(uint id)
        {
            //to fix memory leak issue, match the handle count with native side.
            IntPtr cPtr = Interop.Actor.ActorFindChildById(swigCPtr, id);
            View ret = this.GetInstanceSafely<View>(cPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal override View FindCurrentChildById(uint id)
        {
            return FindChildById(id);
        }

        internal void SetParentOrigin(Vector3 origin)
        {
            Interop.ActorInternal.ActorSetParentOrigin(swigCPtr, Vector3.getCPtr(origin));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector3 GetCurrentParentOrigin()
        {
            Vector3 ret = new Vector3(Interop.ActorInternal.ActorGetCurrentParentOrigin(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetAnchorPoint(Vector3 anchorPoint)
        {
            Interop.Actor.ActorSetAnchorPoint(swigCPtr, Vector3.getCPtr(anchorPoint));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector3 GetCurrentAnchorPoint()
        {
            Vector3 ret = new Vector3(Interop.ActorInternal.ActorGetCurrentAnchorPoint(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetSize(float width, float height)
        {
            Interop.ActorInternal.ActorSetSize(swigCPtr, width, height);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetSize(float width, float height, float depth)
        {
            Interop.ActorInternal.ActorSetSize(swigCPtr, width, height, depth);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetSize(Vector2 size)
        {
            Interop.ActorInternal.ActorSetSizeVector2(swigCPtr, Vector2.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetSize(Vector3 size)
        {
            Interop.ActorInternal.ActorSetSizeVector3(swigCPtr, Vector3.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector3 GetTargetSize()
        {
            Vector3 ret = new Vector3(Interop.ActorInternal.ActorGetTargetSize(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Size2D GetCurrentSize()
        {
            Size ret = new Size(Interop.Actor.ActorGetCurrentSize(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            Size2D size = new Size2D((int)ret.Width, (int)ret.Height);
            ret.Dispose();
            return size;
        }

        internal Size2D GetCurrentSizeFloat()
        {
            Size ret = new Size(Interop.Actor.ActorGetCurrentSize(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Vector3 GetNaturalSize()
        {
            Vector3 ret = new Vector3(Interop.Actor.ActorGetNaturalSize(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetPosition(float x, float y)
        {
            Interop.ActorInternal.ActorSetPosition(swigCPtr, x, y);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetPosition(float x, float y, float z)
        {
            Interop.ActorInternal.ActorSetPosition(swigCPtr, x, y, z);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetPosition(Vector3 position)
        {
            Interop.ActorInternal.ActorSetPosition(swigCPtr, Vector3.getCPtr(position));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetX(float x)
        {
            Interop.ActorInternal.ActorSetX(swigCPtr, x);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetY(float y)
        {
            Interop.ActorInternal.ActorSetY(swigCPtr, y);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetZ(float z)
        {
            Interop.ActorInternal.ActorSetZ(swigCPtr, z);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void TranslateBy(Vector3 distance)
        {
            Interop.ActorInternal.ActorTranslateBy(swigCPtr, Vector3.getCPtr(distance));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Position GetCurrentPosition()
        {
            Position ret = new Position(Interop.Actor.ActorGetCurrentPosition(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Vector3 GetCurrentWorldPosition()
        {
            Vector3 ret = new Vector3(Interop.ActorInternal.ActorGetCurrentWorldPosition(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetInheritPosition(bool inherit)
        {
            Interop.ActorInternal.ActorSetInheritPosition(swigCPtr, inherit);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal bool IsPositionInherited()
        {
            bool ret = Interop.ActorInternal.ActorIsPositionInherited(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetOrientation(Degree angle, Vector3 axis)
        {
            Interop.ActorInternal.ActorSetOrientationDegree(swigCPtr, Degree.getCPtr(angle), Vector3.getCPtr(axis));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetOrientation(Radian angle, Vector3 axis)
        {
            Interop.ActorInternal.ActorSetOrientationRadian(swigCPtr, Radian.getCPtr(angle), Vector3.getCPtr(axis));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetOrientation(Rotation orientation)
        {
            Interop.ActorInternal.ActorSetOrientationQuaternion(swigCPtr, Rotation.getCPtr(orientation));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Rotation GetCurrentOrientation()
        {
            Rotation ret = new Rotation(Interop.ActorInternal.ActorGetCurrentOrientation(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetInheritOrientation(bool inherit)
        {
            Interop.ActorInternal.ActorSetInheritOrientation(swigCPtr, inherit);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal bool IsOrientationInherited()
        {
            bool ret = Interop.ActorInternal.ActorIsOrientationInherited(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Rotation GetCurrentWorldOrientation()
        {
            Rotation ret = new Rotation(Interop.ActorInternal.ActorGetCurrentWorldOrientation(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetScale(float scale)
        {
            Interop.ActorInternal.ActorSetScale(swigCPtr, scale);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetScale(float scaleX, float scaleY, float scaleZ)
        {
            Interop.ActorInternal.ActorSetScale(swigCPtr, scaleX, scaleY, scaleZ);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetScale(Vector3 scale)
        {
            Interop.ActorInternal.ActorSetScale(swigCPtr, Vector3.getCPtr(scale));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector3 GetCurrentScale()
        {
            Vector3 ret = new Vector3(Interop.ActorInternal.ActorGetCurrentScale(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Vector3 GetCurrentWorldScale()
        {
            Vector3 ret = new Vector3(Interop.ActorInternal.ActorGetCurrentWorldScale(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetInheritScale(bool inherit)
        {
            Interop.ActorInternal.ActorSetInheritScale(swigCPtr, inherit);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal bool IsScaleInherited()
        {
            bool ret = Interop.ActorInternal.ActorIsScaleInherited(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Matrix GetCurrentWorldMatrix()
        {
            Matrix ret = new Matrix(Interop.ActorInternal.ActorGetCurrentWorldMatrix(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetVisible(bool visible)
        {
            Interop.Actor.ActorSetVisible(swigCPtr, visible);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal bool IsVisible()
        {
            bool ret = Interop.ActorInternal.ActorIsVisible(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetOpacity(float opacity)
        {
            Interop.ActorInternal.ActorSetOpacity(swigCPtr, opacity);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal float GetCurrentOpacity()
        {
            float ret = Interop.ActorInternal.ActorGetCurrentOpacity(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetColor(Vector4 color)
        {
            Interop.ActorInternal.ActorSetColor(swigCPtr, Vector4.getCPtr(color));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector4 GetCurrentColor()
        {
            Vector4 ret = new Vector4(Interop.ActorInternal.ActorGetCurrentColor(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
        internal ColorMode GetColorMode()
        {
            ColorMode ret = (ColorMode)Interop.ActorInternal.ActorGetColorMode(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Vector4 GetCurrentWorldColor()
        {
            Vector4 ret = new Vector4(Interop.ActorInternal.ActorGetCurrentWorldColor(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetDrawMode(DrawModeType drawMode)
        {
            Interop.ActorInternal.ActorSetDrawMode(swigCPtr, (int)drawMode);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal DrawModeType GetDrawMode()
        {
            DrawModeType ret = (DrawModeType)Interop.ActorInternal.ActorGetDrawMode(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetKeyboardFocusable(bool focusable)
        {
            Interop.ActorInternal.ActorSetKeyboardFocusable(swigCPtr, focusable);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal bool IsKeyboardFocusable()
        {
            bool ret = Interop.ActorInternal.ActorIsKeyboardFocusable(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetResizePolicy(ResizePolicyType policy, DimensionType dimension)
        {
            Interop.Actor.ActorSetResizePolicy(swigCPtr, (int)policy, (int)dimension);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal ResizePolicyType GetResizePolicy(DimensionType dimension)
        {
            ResizePolicyType ret = (ResizePolicyType)Interop.Actor.ActorGetResizePolicy(swigCPtr, (int)dimension);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Vector3 GetSizeModeFactor()
        {
            Vector3 ret = new Vector3(Interop.Actor.ActorGetSizeModeFactor(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetMinimumSize(Vector2 size)
        {
            Interop.ActorInternal.ActorSetMinimumSize(swigCPtr, Vector2.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector2 GetMinimumSize()
        {
            Vector2 ret = new Vector2(Interop.ActorInternal.ActorGetMinimumSize(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetMaximumSize(Vector2 size)
        {
            Interop.ActorInternal.ActorSetMaximumSize(swigCPtr, Vector2.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector2 GetMaximumSize()
        {
            Vector2 ret = new Vector2(Interop.ActorInternal.ActorGetMaximumSize(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal int GetHierarchyDepth()
        {
            int ret = Interop.Actor.ActorGetHierarchyDepth(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal uint GetRendererCount()
        {
            uint ret = Interop.Actor.ActorGetRendererCount(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(View obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal bool IsTopLevelView()
        {
            if (GetParent() is Layer)
            {
                return true;
            }
            return false;
        }

        internal void SetKeyInputFocus()
        {
            Interop.ViewInternal.View_SetKeyInputFocus(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void ClearKeyInputFocus()
        {
            Interop.ViewInternal.View_ClearKeyInputFocus(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PinchGestureDetector GetPinchGestureDetector()
        {
            PinchGestureDetector ret = new PinchGestureDetector(Interop.ViewInternal.View_GetPinchGestureDetector(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal PanGestureDetector GetPanGestureDetector()
        {
            PanGestureDetector ret = new PanGestureDetector(Interop.ViewInternal.View_GetPanGestureDetector(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal TapGestureDetector GetTapGestureDetector()
        {
            TapGestureDetector ret = new TapGestureDetector(Interop.ViewInternal.View_GetTapGestureDetector(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal LongPressGestureDetector GetLongPressGestureDetector()
        {
            LongPressGestureDetector ret = new LongPressGestureDetector(Interop.ViewInternal.View_GetLongPressGestureDetector(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal IntPtr GetPtrfromView()
        {
            return (IntPtr)swigCPtr;
        }

        internal void RemoveChild(View child)
        {
            // Do actual child removal
            Interop.Actor.ActorRemove(swigCPtr, View.getCPtr(child));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            Children.Remove(child);
            child.InternalParent = null;

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
            _layout = null;
        }

        internal ResourceLoadingStatusType GetBackgroundResourceStatus()
        {
            return (ResourceLoadingStatusType)Interop.View.View_GetVisualResourceStatus(this.swigCPtr, Property.BACKGROUND);
        }

        internal virtual void UpdateCornerRadius(float value)
        {
            if (value != 0)
            {
                (backgroundExtraData ?? (backgroundExtraData = new BackgroundExtraData())).CornerRadius = value;
            }

            Tizen.NUI.PropertyMap backgroundMap = new Tizen.NUI.PropertyMap();
            PropertyValue background = Tizen.NUI.Object.GetProperty(swigCPtr, View.Property.BACKGROUND);
            background?.Get(backgroundMap);

            if (!backgroundMap.Empty())
            {
                backgroundMap[Visual.Property.CornerRadius] = new PropertyValue(value);
                PropertyValue setValue = new Tizen.NUI.PropertyValue(backgroundMap);
                Tizen.NUI.Object.SetProperty(swigCPtr, View.Property.BACKGROUND, setValue);
                setValue?.Dispose();
            }
            UpdateShadowCornerRadius(value);
            backgroundMap?.Dispose();
            background?.Dispose();
        }

        internal void UpdateStyle()
        {
            ViewStyle newStyle;
            if (styleName == null) newStyle = ThemeManager.GetStyle(GetType());
            else newStyle = ThemeManager.GetStyle(styleName);

            if (newStyle != null && (viewStyle == null || viewStyle.GetType() == newStyle.GetType())) ApplyStyle(newStyle);
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

            //_mergedStyle = null;

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
                selectorData?.Reset(this);
                if (themeChangeSensitive)
                {
                    ThemeManager.ThemeChanged -= OnThemeChanged;
                }
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.
            if (this != null)
            {
                DisConnectFromSignals();
            }

            foreach (View view in Children)
            {
                view.InternalParent = null;
            }

            base.Dispose(type);
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.View.delete_View(swigCPtr);
        }

        /// <summary>
        /// The touch event handler for ControlState.
        /// Please change ControlState value by touch state if needed.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual bool HandleControlStateOnTouch(Touch touch)
        {
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

        private void DisConnectFromSignals()
        {
            // Save current CPtr.
            global::System.Runtime.InteropServices.HandleRef currentCPtr = swigCPtr;

            // Use BaseHandle CPtr as current might have been deleted already in derived classes.
            swigCPtr = GetBaseHandleCPtrHandleRef;

            if (_onRelayoutEventCallback != null)
            {
                ViewSignal signal = this.OnRelayoutSignal();
                signal?.Disconnect(_onRelayoutEventCallback);
                signal?.Dispose();
                _onRelayoutEventCallback = null;
            }

            if (_offWindowEventCallback != null)
            {
                ViewSignal signal = this.OffWindowSignal();
                signal?.Disconnect(_offWindowEventCallback);
                signal?.Dispose();
                _offWindowEventCallback = null;
            }

            if (_onWindowEventCallback != null)
            {
                ViewSignal signal = this.OnWindowSignal();
                signal?.Disconnect(_onWindowEventCallback);
                signal?.Dispose();
                _onWindowEventCallback = null;
            }

            if (_wheelEventCallback != null)
            {
                WheelSignal signal = this.WheelEventSignal();
                signal?.Disconnect(_wheelEventCallback);
                signal?.Dispose();
            }

            if (WindowWheelEventHandler != null)
            {
                NUIApplication.GetDefaultWindow().WheelEvent -= OnWindowWheelEvent;
            }

            if (_hoverEventCallback != null)
            {
                HoverSignal signal = this.HoveredSignal();
                signal?.Disconnect(_hoverEventCallback);
                signal?.Dispose();
            }

            if (_interceptTouchDataCallback != null)
            {
                TouchDataSignal signal = this.InterceptTouchSignal();
                signal?.Disconnect(_interceptTouchDataCallback);
                signal?.Dispose();
            }

            if (_touchDataCallback != null)
            {
                TouchDataSignal signal = this.TouchSignal();
                signal?.Disconnect(_touchDataCallback);
                signal?.Dispose();
            }

            if (_ResourcesLoadedCallback != null)
            {
                ViewSignal signal = this.ResourcesLoadedSignal();
                signal?.Disconnect(_ResourcesLoadedCallback);
                signal?.Dispose();
                _ResourcesLoadedCallback = null;
            }

            if (_keyCallback != null)
            {
                ControlKeySignal signal = this.KeyEventSignal();
                signal?.Disconnect(_keyCallback);
                signal?.Dispose();
            }

            if (_keyInputFocusLostCallback != null)
            {
                KeyInputFocusSignal signal = this.KeyInputFocusLostSignal();
                signal?.Disconnect(_keyInputFocusLostCallback);
                signal?.Dispose();
            }

            if (_keyInputFocusGainedCallback != null)
            {
                KeyInputFocusSignal signal = this.KeyInputFocusGainedSignal();
                signal?.Disconnect(_keyInputFocusGainedCallback);
                signal?.Dispose();
            }

            if (_backgroundResourceLoadedCallback != null)
            {
                ViewSignal signal = this.ResourcesLoadedSignal();
                signal?.Disconnect(_backgroundResourceLoadedCallback);
                signal?.Dispose();
                _backgroundResourceLoadedCallback = null;
            }

            if (_onWindowSendEventCallback != null)
            {
                ViewSignal signal = this.OnWindowSignal();
                signal?.Disconnect(_onWindowSendEventCallback);
                signal?.Dispose();
            }

            // BaseHandle CPtr is used in Registry and there is danger of deletion if we keep using it here.
            // Restore current CPtr.
            swigCPtr = currentCPtr;
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

        private void LoadTransitions()
        {
            foreach (string str in transitionNames)
            {
                string resourceName = str + ".xaml";
                Transition trans = null;

                string resource = Tizen.Applications.Application.Current.DirectoryInfo.Resource;

                string likelyResourcePath = resource + "animation/" + resourceName;

                if (File.Exists(likelyResourcePath))
                {
                    trans = Xaml.Extensions.LoadObject<Transition>(likelyResourcePath);
                }
                if (trans != null)
                {
                    transDictionary.Add(trans.Name, trans);
                }
            }
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

        private void OnColorChanged(float r, float g, float b, float a)
        {
            Color = new Color(r, g, b, a);
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

        private void UpdateShadowCornerRadius(float value)
        {
            // TODO Update corner radius property only whe DALi supports visual property update.
            PropertyMap map = new PropertyMap();

            PropertyValue shadowVal = Tizen.NUI.Object.GetProperty(swigCPtr, View.Property.SHADOW);
            if (shadowVal.Get(map) && !map.Empty())
            {
                map[Visual.Property.CornerRadius] = new PropertyValue(value);

                PropertyValue setValue = new PropertyValue(map);
                Tizen.NUI.Object.SetProperty(swigCPtr, View.Property.SHADOW, setValue);
                setValue?.Dispose();
            }
            map?.Dispose();
            shadowVal?.Dispose();
        }

        private bool EmptyOnTouch(object target, TouchEventArgs args)
        {
            return false;
        }
    }
}
