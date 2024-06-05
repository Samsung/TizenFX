// Copyright (c) 2024 Samsung Electronics Co., Ltd.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace Tizen.NUI.Visuals
{
    /// <summary>
    /// The base class of all visual in namespace Tizen.NUI.Visuals.
    /// This class is abstract class. We cannot use it without type of Properties.
    /// </summary>
    /// <remarks>
    /// Visual is the smallest rendering unit that application can control without custom renderer.
    /// It will be used when we want to add a new visual to the View.
    /// We can change the size or offset of visuals, and sibling order.
    ///
    /// When we change the property of visual, the visual will be recreated at end of event loop.
    /// </remarks>
    /// <code>
    /// animation.AnimateTo(view, "BorderlineOffset", -1.0f);
    /// </code>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class VisualBase : BaseHandle
    {
        #region Internal And Private
        internal PropertyMap cachedVisualPropertyMap = null;
        internal PropertyMap changedPropertyMap = null;

        internal bool visualCreationRequiredFlag = true; // The first time should create visual.
        internal bool visualUpdateRequiredFlag = false;

        internal bool visualCreationManually = false;

        private int internalType = (int)Tizen.NUI.Visual.Type.Invalid;

        private bool visualPropertyUpdateProcessAttachedFlag = false;

        private bool visualFittingModeApplied = false; // Whether we use fitting mode, or DontCare.

        internal struct VisualTransformInfo
        {
            public float width;
            public float height;
            public float offsetX;
            public float offsetY;

            public VisualTransformPolicyType widthPolicy;
            public VisualTransformPolicyType heightPolicy;
            public VisualTransformPolicyType offsetXPolicy;
            public VisualTransformPolicyType offsetYPolicy;

            public Visual.AlignType origin;
            public Visual.AlignType pivotPoint;

            public float extraWidth;
            public float extraHeight;

            public PropertyMap cachedVisualTransformPropertyMap;

            internal bool changed;
            
            public void Clear()
            {
                width = 1.0f;
                height = 1.0f;
                offsetX = 0.0f;
                offsetY = 0.0f;

                widthPolicy = VisualTransformPolicyType.Relative;
                heightPolicy = VisualTransformPolicyType.Relative;
                offsetXPolicy = VisualTransformPolicyType.Relative;
                offsetYPolicy = VisualTransformPolicyType.Relative;

                origin = Visual.AlignType.TopBegin;
                pivotPoint = Visual.AlignType.TopBegin;

                extraWidth = 0.0f;
                extraHeight = 0.0f;

                cachedVisualTransformPropertyMap = null;

                changed = true;
            }

            internal void ConvertToPropertyMap()
            {
                if (cachedVisualTransformPropertyMap == null)
                {
                    cachedVisualTransformPropertyMap = new PropertyMap();
                }

                cachedVisualTransformPropertyMap.Clear();
                cachedVisualTransformPropertyMap.Add((int)VisualTransformPropertyType.Size, new PropertyValue(new Vector2(width, height)))
                                                .Add((int)VisualTransformPropertyType.Offset, new PropertyValue(new Vector2(offsetX, offsetY)))
                                                .Add((int)VisualTransformPropertyType.SizePolicy, new PropertyValue(new Vector2((float)widthPolicy, (float)heightPolicy)))
                                                .Add((int)VisualTransformPropertyType.OffsetPolicy, new PropertyValue(new Vector2((float)offsetXPolicy, (float)offsetYPolicy)))
                                                .Add((int)VisualTransformPropertyType.Origin, new PropertyValue((int)origin))
                                                .Add((int)VisualTransformPropertyType.AnchorPoint, new PropertyValue((int)pivotPoint))
                                                .Add((int)VisualTransformPropertyType.ExtraSize, new PropertyValue(new Vector2(extraWidth, extraHeight)));
            }

            internal void ConvertFromPropertyMap(PropertyMap inputMap)
            {
                PropertyValue value = null;

                if ((value = inputMap?.Find((int)VisualTransformPropertyType.Size)) != null)
                {
                    using var size = new Size();
                    if (value.Get(size))
                    {
                        width = size.Width;
                        height = size.Height;
                    }
                }
                if ((value = inputMap?.Find((int)VisualTransformPropertyType.Offset)) != null)
                {
                    using var offset = new Position();
                    if (value.Get(offset))
                    {
                        offsetX = offset.X;
                        offsetY = offset.Y;
                    }
                }
                if ((value = inputMap?.Find((int)VisualTransformPropertyType.SizePolicy)) != null)
                {
                    using var policyValue = new Vector2();
                    if (value.Get(policyValue))
                    {
                        widthPolicy = (VisualTransformPolicyType)policyValue.X;
                        heightPolicy = (VisualTransformPolicyType)policyValue.Y;
                    }
                }
                if ((value = inputMap?.Find((int)VisualTransformPropertyType.OffsetPolicy)) != null)
                {
                    using var policyValue = new Vector2();
                    if (value.Get(policyValue))
                    {
                        offsetXPolicy = (VisualTransformPolicyType)policyValue.X;
                        offsetYPolicy = (VisualTransformPolicyType)policyValue.Y;
                    }
                }
                if ((value = inputMap?.Find((int)VisualTransformPropertyType.Origin)) != null)
                {
                    int ret = 0;
                    if (value.Get(out ret))
                    {
                        origin = (Visual.AlignType)ret;
                    }
                }
                if ((value = inputMap?.Find((int)VisualTransformPropertyType.AnchorPoint)) != null)
                {
                    int ret = 0;
                    if (value.Get(out ret))
                    {
                        pivotPoint = (Visual.AlignType)ret;
                    }
                }
                if ((value = inputMap?.Find((int)VisualTransformPropertyType.ExtraSize)) != null)
                {
                    using var extraValue = new Vector2();
                    if (value.Get(extraValue))
                    {
                        extraWidth = extraValue.Width;
                        extraHeight = extraValue.Height;
                    }
                }
                value?.Dispose();
            }
        };
        internal VisualTransformInfo transformInfo;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates an visual object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VisualBase() : this(Interop.VisualObject.VisualObjectNew(), true)
        {
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        internal VisualBase(global::System.IntPtr cPtr, bool cMemoryOwn) : this(cPtr, cMemoryOwn, cMemoryOwn)
        {
        }

        internal VisualBase(global::System.IntPtr cPtr, bool cMemoryOwn, bool cRegister) : base(cPtr, cMemoryOwn, cRegister)
        {
            transformInfo.Clear();
        }
        #endregion

        #region Enum
        /// <summary>
        /// The update mode of this VisualBase property.
        /// Default is Auto.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum PropertyUpdateModeType
        {
            /// <summary>
            /// Update property automatically, by NUI event loop.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Auto,
            /// <summary>
            /// Update property manually.
            /// Need to call <see cref="UpdateProperty"/> function manually to update property.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Manual,
        }
        #endregion

        #region Properties
        /// <summary>
        /// Sibling order of this VisualBase.
        /// </summary>
        /// <remarks>
        /// The sibling order is used to determine the draw order of the visuals.
        /// The visuals with smaller sibling order are drawn bottom,
        /// and the visuals with larger sibling order are drawn top.
        ///
        /// It will be changed automatically when the visuals are added to the view.
        /// The default value is 0.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint SiblingOrder
        {
            set
            {
                Interop.VisualObject.SetSiblingOrder(SwigCPtr, value);
                NDalicPINVOKE.ThrowExceptionIfExists();
            }
            get
            {
                uint ret = Interop.VisualObject.GetSiblingOrder(SwigCPtr);
                NDalicPINVOKE.ThrowExceptionIfExists();
                return ret;
            }
        }

        /// <summary>
        /// Type of this VisualObject. It will be set at construction time.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Type
        {
            internal set
            {
                if(internalType != value)
                {
                    internalType = value;
                    UpdateVisualProperty((int)Tizen.NUI.Visual.Property.Type, new PropertyValue(value), true);
                }
            }
            get
            {
                return internalType;
            }
        }

        /// <summary>
        /// Name of the visual.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Name { get; set; }

        /// <summary>
        /// The way of visual property update.
        /// Default is PropertyUpdateModeType.Auto.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyUpdateModeType PropertyUpdateMode
        {
            set
            {
                visualCreationManually = (value == PropertyUpdateModeType.Manual);
            }
            get
            {
                return visualCreationManually ? PropertyUpdateModeType.Manual : PropertyUpdateModeType.Auto;
            }
        }
        #endregion

        #region Visual Properties
        /// <summary>
        /// Color for the visual. Default color is White
        /// </summary>
        /// <remarks>
        /// This is exclusive with the Opacity property.
        /// Opacity property be applied as Color.A.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Tizen.NUI.Color Color
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.Visual.Property.MixColor, new PropertyValue(value), false);

                // warning : We should set cached Opacity after set MixColor.
                UpdateVisualProperty((int)Tizen.NUI.Visual.Property.Opacity, new PropertyValue(value.A), false);
            }
            get
            {
                Tizen.NUI.Color ret = new Tizen.NUI.Color(1.0f, 1.0f, 1.0f, 1.0f);
                var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.Visual.Property.MixColor);
                propertyValue?.Get(ret);
                return ret;
            }
        }

        /// <summary>
        /// Opacity for the visual.
        /// </summary>
        /// <remarks>
        /// This is exclusive with the Color property.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Opacity
        {
            set
            {
                UpdateVisualProperty((int)Tizen.NUI.Visual.Property.Opacity, new PropertyValue(value), false);
            }
            get
            {
                float ret = 1.0f;
                var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.Visual.Property.Opacity);
                propertyValue?.Get(out ret);
                return ret;
            }
        }
        #endregion

        #region Visual Transform Properties
        /// <summary>
        /// FittingMode for the visual.
        /// </summary>
        /// <remarks>
        /// The fitting mode is used to decide how the visual should be fitted to the control area.
        /// The default value is VisualFittingModeType.DontCare.
        /// If user set one of Transform property, it will be set as VisualFittingModeType.DontCare automatically.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VisualFittingModeType FittingMode
        {
            set
            {
                if (value != VisualFittingModeType.DontCare)
                {
                    visualFittingModeApplied = true;
                }
                else
                {
                    visualFittingModeApplied = false;
                }
                UpdateVisualProperty((int)Tizen.NUI.Visual.Property.VisualFittingMode, new PropertyValue((int)value));
            }
            get
            {
                int ret = (int)VisualFittingModeType.DontCare;
                var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.Visual.Property.VisualFittingMode);
                propertyValue?.Get(out ret);
                return (VisualFittingModeType)ret;
            }
        }

        /// <summary>
        /// Width of the visual.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Width
        {
            set
            {
                if (visualFittingModeApplied)
                {
                    FittingMode = VisualFittingModeType.DontCare;
                }
                if (transformInfo.width != value)
                {
                    transformInfo.width = value;
                    TransformPropertyChanged();
                }
            }
            get
            {
                return transformInfo.width;
            }
        }

        /// <summary>
        /// Height of the visual.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Height
        {
            set
            {
                if (visualFittingModeApplied)
                {
                    FittingMode = VisualFittingModeType.DontCare;
                }
                if (transformInfo.height != value)
                {
                    transformInfo.height = value;
                    TransformPropertyChanged();
                }
            }
            get
            {
                return transformInfo.height;
            }
        }

        /// <summary>
        /// Policy of width.
        /// If it is Relative, The width will be relative by the View's width.
        /// If it is Absolute, The width will be used as the absolute Width value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VisualTransformPolicyType WidthPolicy
        {
            set
            {
                if (visualFittingModeApplied)
                {
                    FittingMode = VisualFittingModeType.DontCare;
                }
                if (transformInfo.widthPolicy != value)
                {
                    transformInfo.widthPolicy = value;
                    TransformPropertyChanged();
                }
            }
            get
            {
                return transformInfo.widthPolicy;
            }
        }

        /// <summary>
        /// Policy of height.
        /// If it is Relative, The height will be relative by the View's height.
        /// If it is Absolute, The height will be used as the absolute Height value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VisualTransformPolicyType HeightPolicy
        {
            set
            {
                if (visualFittingModeApplied)
                {
                    FittingMode = VisualFittingModeType.DontCare;
                }
                if (transformInfo.heightPolicy != value)
                {
                    transformInfo.heightPolicy = value;
                    TransformPropertyChanged();
                }
            }
            get
            {
                return transformInfo.heightPolicy;
            }
        }

        /// <summary>
        /// OffsetX of the visual.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float OffsetX
        {
            set
            {
                if (visualFittingModeApplied)
                {
                    FittingMode = VisualFittingModeType.DontCare;
                }
                if (transformInfo.offsetX != value)
                {
                    transformInfo.offsetX = value;
                    TransformPropertyChanged();
                }
            }
            get
            {
                return transformInfo.offsetX;
            }
        }

        /// <summary>
        /// OffsetY of the visual.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float OffsetY
        {
            set
            {
                if (visualFittingModeApplied)
                {
                    FittingMode = VisualFittingModeType.DontCare;
                }
                if (transformInfo.offsetY != value)
                {
                    transformInfo.offsetY = value;
                    TransformPropertyChanged();
                }
            }
            get
            {
                return transformInfo.offsetY;
            }
        }

        /// <summary>
        /// Policy of offsetX.
        /// If it is Relative, The offsetX will be relative by the View's width.
        /// If it is Absolute, The offsetX will be used as the absolute OffsetX value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VisualTransformPolicyType OffsetXPolicy
        {
            set
            {
                if (visualFittingModeApplied)
                {
                    FittingMode = VisualFittingModeType.DontCare;
                }
                if (transformInfo.offsetXPolicy != value)
                {
                    transformInfo.offsetXPolicy = value;
                    TransformPropertyChanged();
                }
            }
            get
            {
                return transformInfo.offsetXPolicy;
            }
        }

        /// <summary>
        /// Policy of offsetY.
        /// If it is Relative, The offsetY will be relative by the View's height.
        /// If it is Absolute, The offsetY will be used as the absolute OffsetY value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VisualTransformPolicyType OffsetYPolicy
        {
            set
            {
                if (visualFittingModeApplied)
                {
                    FittingMode = VisualFittingModeType.DontCare;
                }
                if (transformInfo.offsetYPolicy != value)
                {
                    transformInfo.offsetYPolicy = value;
                    TransformPropertyChanged();
                }
            }
            get
            {
                return transformInfo.offsetYPolicy;
            }
        }

        /// <summary>
        /// Origin of the visual from view.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Visual.AlignType Origin
        {
            set
            {
                if (visualFittingModeApplied)
                {
                    FittingMode = VisualFittingModeType.DontCare;
                }
                if (transformInfo.origin != value)
                {
                    transformInfo.origin = value;
                    TransformPropertyChanged();
                }
            }
            get
            {
                return transformInfo.origin;
            }
        }

        /// <summary>
        /// Pivot point of the visual from view.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Visual.AlignType PivotPoint
        {
            set
            {
                if (visualFittingModeApplied)
                {
                    FittingMode = VisualFittingModeType.DontCare;
                }
                if (transformInfo.pivotPoint != value)
                {
                    transformInfo.pivotPoint = value;
                    TransformPropertyChanged();
                }
            }
            get
            {
                return transformInfo.pivotPoint;
            }
        }

        /// <summary>
        /// Extra width of the visual as absolute policy.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float ExtraWidth
        {
            set
            {
                if (visualFittingModeApplied)
                {
                    FittingMode = VisualFittingModeType.DontCare;
                }
                if (transformInfo.extraWidth != value)
                {
                    transformInfo.extraWidth = value;
                    TransformPropertyChanged();
                }
            }
            get
            {
                return transformInfo.extraWidth;
            }
        }

        /// <summary>
        /// Extra height of the visual as absolute policy.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float ExtraHeight
        {
            set
            {
                if (visualFittingModeApplied)
                {
                    FittingMode = VisualFittingModeType.DontCare;
                }
                if (transformInfo.extraHeight != value)
                {
                    transformInfo.extraHeight = value;
                    TransformPropertyChanged();
                }
            }
            get
            {
                return transformInfo.extraHeight;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Get attached View.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Tizen.NUI.BaseComponents.View GetOwner()
        {
            var container = GetVisualContainer();
            if (container != null)
            {
                return container.GetView();
            }
            return null;
        }

        /// <summary>
        /// Detach from View.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Detach()
        {
            if (Disposed)
            {
                return;
            }

            var container = GetVisualContainer();
            if (container != null)
            {
                container.RemoveVisualObject(this);
            }

            Interop.VisualObject.Detach(SwigCPtr);
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        /// <summary>
        /// Raise above the next sibling visual object
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Raise()
        {
            Interop.VisualObject.Raise(SwigCPtr);
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        /// <summary>
        /// Lower below the previous sibling visual object
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Lower()
        {
            Interop.VisualObject.Lower(SwigCPtr);
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        /// <summary>
        /// Raise above all other sibling visual objects
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RaiseToTop()
        {
            Interop.VisualObject.RaiseToTop(SwigCPtr);
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        /// <summary>
        /// Raise below all other sibling visual objects
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void LowerToBottom()
        {
            Interop.VisualObject.LowerToBottom(SwigCPtr);
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        /// <summary>
        /// Raise above target visual objects. No effects if visual object is already above target.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RaiseAbove(Visuals.VisualBase target)
        {
            Interop.VisualObject.RaiseAbove(SwigCPtr, Visuals.VisualBase.getCPtr(target));
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        /// <summary>
        /// Lower below target visual objects. No effects if visual object is already below target.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void LowerBelow(Visuals.VisualBase target)
        {
            Interop.VisualObject.LowerBelow(SwigCPtr, Visuals.VisualBase.getCPtr(target));
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        /// <summary>
        /// Update visual properties manually.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void UpdateProperty()
        {
            UpdateVisualPropertyMap();
        }
        #endregion

        #region Internal Methods
        internal Visuals.VisualObjectsContainer GetVisualContainer()
        {
            global::System.IntPtr cPtr = Interop.VisualObject.GetContainer(SwigCPtr);
            Visuals.VisualObjectsContainer ret = null;
            if (Interop.RefObject.GetRefObjectPtr(cPtr) == global::System.IntPtr.Zero)
            {
                // Visual contianer is not created yet. Return null.
                Interop.BaseHandle.DeleteBaseHandle(new global::System.Runtime.InteropServices.HandleRef(this, cPtr));
            }
            else
            {
                ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as Visuals.VisualObjectsContainer;
                if (ret != null)
                {
                    Interop.BaseHandle.DeleteBaseHandle(new global::System.Runtime.InteropServices.HandleRef(this, cPtr));
                }
                else
                {
                    ret = new Visuals.VisualObjectsContainer(cPtr, true);
                }
            }
            NDalicPINVOKE.ThrowExceptionIfExists();
            return ret;
        }

        /// <summary>
        /// Unregister visual from control. It will not remove cached data.
        /// </summary>
        internal void UnregisterVisual()
        {
            using var tempPropertyMap = new PropertyMap();
            Interop.VisualObject.CreateVisual(SwigCPtr, PropertyMap.getCPtr(tempPropertyMap));
        }

        /// <summary>
        /// Set or Get visual property.
        /// </summary>
        /// <remarks>
        /// This property might change the type of visual. We should not set it from subclass of VisualBase.
        /// </remarks>
        internal PropertyMap Properties
        {
            private set
            {
                visualCreationRequiredFlag = true;
                cachedVisualPropertyMap = value;

                visualUpdateRequiredFlag = false;
                changedPropertyMap?.Dispose();
                changedPropertyMap = null;

                transformInfo.Clear();

                // Get transform informations from input property map.
                using var transformValue = cachedVisualPropertyMap?.Find((int)Tizen.NUI.Visual.Property.Transform);
                if (transformValue != null)
                {
                    PropertyMap transformMap = new PropertyMap();
                    if (transformValue.Get(ref transformMap) && transformMap != null)
                    {
                        transformInfo.ConvertFromPropertyMap(transformMap);
                    }
                }
                transformInfo.changed = false;

                // Get type from the property map.
                internalType = (int)Tizen.NUI.Visual.Type.Invalid;
                if (cachedVisualPropertyMap?.Find((int)Tizen.NUI.Visual.Property.Type)?.Get(out internalType) ?? false)
                {
                    UpdateVisualPropertyMap();
                }
                else
                {
                    // If type is not set, then remove the visual.
                    UnregisterVisual();
                }
            }
            get
            {
                // Sync as current properties
                UpdateVisualPropertyMap();

                PropertyMap ret = new PropertyMap();
                Interop.VisualObject.RetrieveVisualPropertyMap(SwigCPtr, PropertyMap.getCPtr(ret));
                return ret;
            }
        }

        virtual internal void OnUpdateVisualPropertyMap()
        {
        }

        virtual internal void OnVisualCreated()
        {
        }

        /// <summary>
        /// Lazy call to UpdateVisualPropertyMap.
        /// Collect Properties need to be update, and set properties that starts the Processing.
        ///
        /// If you want to update cachedVisualPropertyMap, but don't want to request new visual creation, make requiredVisualCreation value as false.
        /// (Example : if we change SynchronousLoading property from 'true' to 'false', or if we call this function during OnUpdateVisualPropertyMap)
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        virtual internal void UpdateVisualProperty(int key, PropertyValue value, bool requiredVisualCreation = true)
        {
            // Update visual property map value as inputed value.
            if (key != 0)
            {
                if (!HasBody())
                {
                    // Throw exception if VisualBase is disposed.
                    throw new global::System.InvalidOperationException($"[NUI][VisualBase] Someone try to change disposed VisualBase property.\n");
                }

                if (cachedVisualPropertyMap == null)
                {
                    cachedVisualPropertyMap = new PropertyMap();
                }

                visualCreationRequiredFlag |= requiredVisualCreation;
                if (value != null)
                {
                    cachedVisualPropertyMap[key] = value;

                    // Store the changed values in the changedPropertyMap, only if visualCreationRequiredFlag is false.
                    // It will be used when we create the visual, only by UpdateVisualPropertyMap
                    if (!visualCreationRequiredFlag)
                    {
                        visualUpdateRequiredFlag = true;
                        if (changedPropertyMap == null)
                        {
                            changedPropertyMap = new PropertyMap();
                        }
                        changedPropertyMap[key] = value;
                    }
                }
                else
                {
                    // Remove value from cachedVisualPropertyMap if input property map is null.
                    cachedVisualPropertyMap.Remove(key);
                }

                ReqeustProcessorOnceEvent();
            }
        }

        internal void UpdateVisualPropertyMap(object o, global::System.EventArgs e)
        {
            // Note : To allow event attachment during UpdateVisualPropertyMap, let we make flag as false before call UpdateVisualPropertyMap().
            visualPropertyUpdateProcessAttachedFlag = false;
            if (!visualCreationManually)
            {
                UpdateVisualPropertyMap();
            }
        }

        internal void UpdateVisualPropertyMap()
        {
            if (Disposed)
            {
                return;
            }

            if (internalType == (int)Tizen.NUI.Visual.Type.Invalid)
            {
                Tizen.Log.Error("NUI", "Invalid visual type.\n");
                return;
            }

            if (!visualCreationRequiredFlag)
            {
                if (visualUpdateRequiredFlag && changedPropertyMap != null)
                {
                    // We can change property map of visuals without creating them.
                    Interop.VisualObject.UpdateVisualPropertyMap(SwigCPtr, PropertyMap.getCPtr(changedPropertyMap));

                    changedPropertyMap?.Dispose();
                    changedPropertyMap = null;
                }
                return;
            }

            visualCreationRequiredFlag = false;
            visualUpdateRequiredFlag = false;

            changedPropertyMap?.Dispose();
            changedPropertyMap = null;

            if (cachedVisualPropertyMap == null)
            {
                cachedVisualPropertyMap = new PropertyMap();
            }

            if (transformInfo.changed)
            {
                transformInfo.changed = false;
                cachedVisualPropertyMap.Remove((int)Tizen.NUI.Visual.Property.Transform);

                transformInfo.ConvertToPropertyMap();

                if (transformInfo.cachedVisualTransformPropertyMap != null)
                {
                    using var transformValue = new PropertyValue(transformInfo.cachedVisualTransformPropertyMap);
                    cachedVisualPropertyMap.Add((int)Tizen.NUI.Visual.Property.Transform, transformValue);
                }
            }

            // Update the sub classes property map.
            OnUpdateVisualPropertyMap();

            Interop.VisualObject.CreateVisual(SwigCPtr, PropertyMap.getCPtr(cachedVisualPropertyMap));

            // Post process for sub classes.
            OnVisualCreated();

            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        /// <summary>
        /// Get visual property by key.
        /// If we found value in local cached result, return that.
        /// Else, get synced native map and return that.
        /// </summary>
        /// <returns>Matched value. If there is no matched value, return null.</returns>
        internal PropertyValue GetVisualProperty(int key)
        {
            PropertyValue ret = GetCachedVisualProperty(key);
            if (ret == null)
            {
                // If we cannot find result from cached map, Get value from native engine.
                GetCurrentVisualProperty(key);
            }
            return ret;
        }

        /// <summary>
        /// Get visual property by key from native engine.
        /// </summary>
        /// <returns>Matched value. If there is no matched value, return null.</returns>
        internal PropertyValue GetCurrentVisualProperty(int key)
        {
            return Properties?.Find(key);
        }

        /// <summary>
        /// Get visual property from NUI cached map by key.
        /// </summary>
        /// <returns>Matched value. If there is no matched value, return null.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal virtual PropertyValue GetCachedVisualProperty(int key)
        {
            return cachedVisualPropertyMap?.Find(key);
        }

        /// <summary>
        /// Change visual transform information.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal void TransformPropertyChanged()
        {
            if (transformInfo.cachedVisualTransformPropertyMap == null)
            {
                transformInfo.cachedVisualTransformPropertyMap = new PropertyMap();
            }

            // Mark as transform property map.
            visualCreationRequiredFlag = true;
            transformInfo.changed = true;

            ReqeustProcessorOnceEvent();
        }

        internal void ReqeustProcessorOnceEvent()
        {
            if (!visualCreationManually && !visualPropertyUpdateProcessAttachedFlag)
            {
                visualPropertyUpdateProcessAttachedFlag = true;
                ProcessorController.Instance.ProcessorOnceEvent += UpdateVisualPropertyMap;
                // Call process hardly.
                ProcessorController.Instance.Awake();
            }
        }

        /// <summary>
        /// Dispose for VisualObject
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (Disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.

                // Note : Do not call this function in Implicit dispose case.
                // Since if visual is already under some VisualObjectsContainer,
                // it will never be GC.
                Detach();
            }

            visualCreationRequiredFlag = false;
            visualUpdateRequiredFlag = false;

            changedPropertyMap?.Dispose();
            changedPropertyMap = null;
            cachedVisualPropertyMap?.Dispose();
            cachedVisualPropertyMap = null;

            base.Dispose(type);
        }
        #endregion
    }
}