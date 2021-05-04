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
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// View is the base class for all views.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class View
    {
        private ViewSelectorData selectorData;

        internal string styleName;

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
                float returnValue = 0.0f;
                PropertyValue wordPositionX = GetProperty(View.Property.WorldPositionX);
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
                PropertyValue wordPositionY = GetProperty(View.Property.WorldPositionY);
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
                PropertyValue wordPositionZ = GetProperty(View.Property.WorldPositionZ);
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
            Window.Instance.LayoutController.CreateProcessCallback();
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
                float returnValue = 0.0f;
                PropertyValue parentOriginX = GetProperty(View.Property.ParentOriginX);
                parentOriginX?.Get(out returnValue);
                parentOriginX?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(View.Property.ParentOriginX, setValue);
                setValue.Dispose();
                NotifyPropertyChanged();
            }
        }

        internal float ParentOriginY
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue parentOriginY = GetProperty(View.Property.ParentOriginY);
                parentOriginY?.Get(out returnValue);
                parentOriginY?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(View.Property.ParentOriginY, setValue);
                setValue.Dispose();
                NotifyPropertyChanged();
            }
        }

        internal float ParentOriginZ
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue parentOriginZ = GetProperty(View.Property.ParentOriginZ);
                parentOriginZ?.Get(out returnValue);
                parentOriginZ?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(View.Property.ParentOriginZ, setValue);
                setValue.Dispose();
                NotifyPropertyChanged();
            }
        }

        internal float PivotPointX
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue anchorPointX = GetProperty(View.Property.AnchorPointX);
                anchorPointX?.Get(out returnValue);
                anchorPointX?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(View.Property.AnchorPointX, setValue);
                setValue.Dispose();
            }
        }

        internal float PivotPointY
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue anchorPointY = GetProperty(View.Property.AnchorPointY);
                anchorPointY?.Get(out returnValue);
                anchorPointY?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(View.Property.AnchorPointY, setValue);
                setValue.Dispose();
            }
        }

        internal float PivotPointZ
        {
            get
            {
                float returnValue = 0.0f;
                PropertyValue anchorPointZ = GetProperty(View.Property.AnchorPointZ);
                anchorPointZ?.Get(out returnValue);
                anchorPointZ?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(View.Property.AnchorPointZ, setValue);
                setValue.Dispose();
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
        /// Indicates that this View should listen Touch event to handle its ControlState.
        /// </summary>
        private bool enableControlState = false;

        private int LeftFocusableViewId
        {
            get
            {
                int returnValue = 0;
                PropertyValue leftFocusableViewId = GetProperty(View.Property.LeftFocusableViewId);
                leftFocusableViewId?.Get(out returnValue);
                leftFocusableViewId?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(View.Property.LeftFocusableViewId, setValue);
                setValue.Dispose();
            }
        }

        private int RightFocusableViewId
        {
            get
            {
                int returnValue = 0;
                PropertyValue rightFocusableViewId = GetProperty(View.Property.RightFocusableViewId);
                rightFocusableViewId?.Get(out returnValue);
                rightFocusableViewId?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(View.Property.RightFocusableViewId, setValue);
                setValue.Dispose();
            }
        }

        private int UpFocusableViewId
        {
            get
            {
                int returnValue = 0;
                PropertyValue upFocusableViewId = GetProperty(View.Property.UpFocusableViewId);
                upFocusableViewId?.Get(out returnValue);
                upFocusableViewId?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(View.Property.UpFocusableViewId, setValue);
                setValue.Dispose();
            }
        }

        private int DownFocusableViewId
        {
            get
            {
                int returnValue = 0;
                PropertyValue downFocusableViewId = GetProperty(View.Property.DownFocusableViewId);
                downFocusableViewId?.Get(out returnValue);
                downFocusableViewId?.Dispose();
                return returnValue;
            }
            set
            {
                PropertyValue setValue = new Tizen.NUI.PropertyValue(value);
                SetProperty(View.Property.DownFocusableViewId, setValue);
                setValue.Dispose();
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

                    Interop.NDalic.Raise(SwigCPtr);
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

                    Interop.NDalic.Lower(SwigCPtr);
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

                    Interop.NDalic.RaiseAbove(SwigCPtr, View.getCPtr(target));
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

                    Interop.NDalic.LowerBelow(SwigCPtr, View.getCPtr(target));
                    if (NDalicPINVOKE.SWIGPendingException.Pending)
                        throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
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

        internal void SetParentOrigin(Vector3 origin)
        {
            Interop.ActorInternal.SetParentOrigin(SwigCPtr, Vector3.getCPtr(origin));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector3 GetCurrentParentOrigin()
        {
            Vector3 ret = new Vector3(Interop.ActorInternal.GetCurrentParentOrigin(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetAnchorPoint(Vector3 anchorPoint)
        {
            Interop.Actor.SetAnchorPoint(SwigCPtr, Vector3.getCPtr(anchorPoint));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector3 GetCurrentAnchorPoint()
        {
            Vector3 ret = new Vector3(Interop.ActorInternal.GetCurrentAnchorPoint(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
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
            Vector3 ret = new Vector3(Interop.ActorInternal.GetTargetSize(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Size2D GetCurrentSize()
        {
            Size ret = new Size(Interop.Actor.GetCurrentSize(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            Size2D size = new Size2D((int)ret.Width, (int)ret.Height);
            ret.Dispose();
            return size;
        }

        internal Size2D GetCurrentSizeFloat()
        {
            Size ret = new Size(Interop.Actor.GetCurrentSize(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Vector3 GetNaturalSize()
        {
            Vector3 ret = new Vector3(Interop.Actor.GetNaturalSize(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetPosition(float x, float y)
        {
            Interop.ActorInternal.SetPosition(SwigCPtr, x, y);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetPosition(float x, float y, float z)
        {
            Interop.ActorInternal.SetPosition(SwigCPtr, x, y, z);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetPosition(Vector3 position)
        {
            Interop.ActorInternal.SetPosition(SwigCPtr, Vector3.getCPtr(position));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
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
            Position ret = new Position(Interop.Actor.GetCurrentPosition(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Vector3 GetCurrentWorldPosition()
        {
            Vector3 ret = new Vector3(Interop.ActorInternal.GetCurrentWorldPosition(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
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
            Vector3 ret = new Vector3(Interop.ActorInternal.GetCurrentScale(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Vector3 GetCurrentWorldScale()
        {
            Vector3 ret = new Vector3(Interop.ActorInternal.GetCurrentWorldScale(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
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
            Vector4 ret = new Vector4(Interop.ActorInternal.GetCurrentColor(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
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
            Vector4 ret = new Vector4(Interop.ActorInternal.GetCurrentWorldColor(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
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
            Vector3 ret = new Vector3(Interop.Actor.GetSizeModeFactor(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetMinimumSize(Vector2 size)
        {
            Interop.ActorInternal.SetMinimumSize(SwigCPtr, Vector2.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector2 GetMinimumSize()
        {
            Vector2 ret = new Vector2(Interop.ActorInternal.GetMinimumSize(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetMaximumSize(Vector2 size)
        {
            Interop.ActorInternal.SetMaximumSize(SwigCPtr, Vector2.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector2 GetMaximumSize()
        {
            Vector2 ret = new Vector2(Interop.ActorInternal.GetMaximumSize(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
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
            // Do actual child removal
            Interop.Actor.Remove(SwigCPtr, View.getCPtr(child));
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

            var cornerRadius = backgroundExtraData.CornerRadius == null ? new PropertyValue() : new PropertyValue(backgroundExtraData.CornerRadius);

            // Apply to the background visual
            PropertyMap backgroundMap = new PropertyMap();
            PropertyValue background = Tizen.NUI.Object.GetProperty(SwigCPtr, View.Property.BACKGROUND);
            if (background.Get(backgroundMap) && !backgroundMap.Empty())
            {
                backgroundMap[Visual.Property.CornerRadius] = cornerRadius;
                backgroundMap[Visual.Property.CornerRadiusPolicy] = new PropertyValue((int)backgroundExtraData.CornerRadiusPolicy);
                var temp = new PropertyValue(backgroundMap);
                Tizen.NUI.Object.SetProperty(SwigCPtr, View.Property.BACKGROUND, temp);
                temp.Dispose();
            }
            backgroundMap.Dispose();
            background.Dispose();
            cornerRadius.Dispose();

            // Apply to the shadow visual
            PropertyMap shadowMap = new PropertyMap();
            PropertyValue shadow = Tizen.NUI.Object.GetProperty(SwigCPtr, View.Property.SHADOW);
            if (shadow.Get(shadowMap) && !shadowMap.Empty())
            {
                shadowMap[Visual.Property.CornerRadius] = cornerRadius;
                shadowMap[Visual.Property.CornerRadiusPolicy] = new PropertyValue((int)backgroundExtraData.CornerRadiusPolicy);
                var temp = new PropertyValue(shadowMap);
                Tizen.NUI.Object.SetProperty(SwigCPtr, View.Property.SHADOW, temp);
                temp.Dispose();
            }
            shadowMap.Dispose();
            shadow.Dispose();
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
                    ThemeManager.ThemeChangedInternal.Remove(OnThemeChanged);
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

        private void DisConnectFromSignals()
        {
            // Save current CPtr.
            global::System.Runtime.InteropServices.HandleRef currentCPtr = SwigCPtr;

            // Use BaseHandle CPtr as current might have been deleted already in derived classes.
            SwigCPtr = GetBaseHandleCPtrHandleRef;

            if (onRelayoutEventCallback != null)
            {
                ViewSignal signal = this.OnRelayoutSignal();
                signal?.Disconnect(onRelayoutEventCallback);
                signal?.Dispose();
                onRelayoutEventCallback = null;
            }

            if (offWindowEventCallback != null)
            {
                ViewSignal signal = this.OffWindowSignal();
                signal?.Disconnect(offWindowEventCallback);
                signal?.Dispose();
                offWindowEventCallback = null;
            }

            if (onWindowEventCallback != null)
            {
                ViewSignal signal = this.OnWindowSignal();
                signal?.Disconnect(onWindowEventCallback);
                signal?.Dispose();
                onWindowEventCallback = null;
            }

            if (wheelEventCallback != null)
            {
                WheelSignal signal = this.WheelEventSignal();
                signal?.Disconnect(wheelEventCallback);
                signal?.Dispose();
            }

            if (WindowWheelEventHandler != null)
            {
                NUIApplication.GetDefaultWindow().WheelEvent -= OnWindowWheelEvent;
            }

            if (hoverEventCallback != null)
            {
                HoverSignal signal = this.HoveredSignal();
                signal?.Disconnect(hoverEventCallback);
                signal?.Dispose();
            }

            if (interceptTouchDataCallback != null)
            {
                TouchDataSignal signal = this.InterceptTouchSignal();
                signal?.Disconnect(interceptTouchDataCallback);
                signal?.Dispose();
            }

            if (touchDataCallback != null)
            {
                TouchDataSignal signal = this.TouchSignal();
                signal?.Disconnect(touchDataCallback);
                signal?.Dispose();
            }

            if (ResourcesLoadedCallback != null)
            {
                ViewSignal signal = this.ResourcesLoadedSignal();
                signal?.Disconnect(ResourcesLoadedCallback);
                signal?.Dispose();
                ResourcesLoadedCallback = null;
            }

            if (keyCallback != null)
            {
                ControlKeySignal signal = this.KeyEventSignal();
                signal?.Disconnect(keyCallback);
                signal?.Dispose();
            }

            if (keyInputFocusLostCallback != null)
            {
                KeyInputFocusSignal signal = this.KeyInputFocusLostSignal();
                signal?.Disconnect(keyInputFocusLostCallback);
                signal?.Dispose();
            }

            if (keyInputFocusGainedCallback != null)
            {
                KeyInputFocusSignal signal = this.KeyInputFocusGainedSignal();
                signal?.Disconnect(keyInputFocusGainedCallback);
                signal?.Dispose();
            }

            if (backgroundResourceLoadedCallback != null)
            {
                ViewSignal signal = this.ResourcesLoadedSignal();
                signal?.Disconnect(backgroundResourceLoadedCallback);
                signal?.Dispose();
                backgroundResourceLoadedCallback = null;
            }

            if (onWindowSendEventCallback != null)
            {
                ViewSignal signal = this.OnWindowSignal();
                signal?.Disconnect(onWindowSendEventCallback);
                signal?.Dispose();
                onWindowSendEventCallback = null;
            }

            // BaseHandle CPtr is used in Registry and there is danger of deletion if we keep using it here.
            // Restore current CPtr.
            SwigCPtr = currentCPtr;
        }

        /// <summary>
        /// Apply initial style to the view.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void InitializeStyle(ViewStyle style = null)
        {
            if (style != null) ApplyStyle(style); // Use given style
            else UpdateStyle(); // Use style in the current theme
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

        private bool EmptyOnTouch(object target, TouchEventArgs args)
        {
            return false;
        }

        private void UpdateStyle()
        {
            ViewStyle newStyle;
            if (string.IsNullOrEmpty(styleName)) newStyle = ThemeManager.GetStyleWithoutClone(GetType());
            else newStyle = ThemeManager.GetStyleWithoutClone(styleName);

            if (newStyle != null)
            {
                ApplyStyle(newStyle);
            }
        }

        private ViewSelectorData EnsureSelectorData() => selectorData ?? (selectorData = new ViewSelectorData());
    }
}
