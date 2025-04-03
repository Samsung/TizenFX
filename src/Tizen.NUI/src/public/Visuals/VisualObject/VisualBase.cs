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
using System.Diagnostics.CodeAnalysis;

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
    public abstract class VisualBase : BaseHandle
    {
        #region Internal And Private
        internal PropertyMap cachedVisualPropertyMap;
        internal PropertyMap changedPropertyMap;

        internal bool visualCreationRequiredFlag = true; // The first time should create visual.

        internal bool visualCreationManually;

        private int internalType = (int)Tizen.NUI.Visual.Type.Invalid;

        private bool visualPropertyUpdateProcessAttachedFlag;

        private bool visualFittingModeApplied; // Whether we use fitting mode, or DontCare.

        internal class VisualTransformInfo : System.IDisposable
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

            public VisualTransformInfo()
            {
                Clear();
            }

            ~VisualTransformInfo() => Dispose(false);
            
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

                cachedVisualTransformPropertyMap?.Dispose();
                cachedVisualTransformPropertyMap = null;

                changed = true;
            }

            public void Dispose()
            {
                Dispose(true);
                global::System.GC.SuppressFinalize(this);
            }

            protected virtual void Dispose(bool disposing)
            {
                if (disposing)
                {
                    cachedVisualTransformPropertyMap?.Dispose();
                }
            }

            internal PropertyMap ConvertToPropertyMap()
            {
                if (cachedVisualTransformPropertyMap == null)
                {
                    cachedVisualTransformPropertyMap = new PropertyMap();
                }

                cachedVisualTransformPropertyMap.Clear();

                // TODO : Let we optimize here after native map add API binded
                cachedVisualTransformPropertyMap.Append((int)VisualTransformPropertyType.Size, new UIVector2(width, height))
                                                .Append((int)VisualTransformPropertyType.Offset, new UIVector2(offsetX, offsetY))
                                                .Append((int)VisualTransformPropertyType.SizePolicy, new UIVector2((float)widthPolicy, (float)heightPolicy))
                                                .Append((int)VisualTransformPropertyType.OffsetPolicy, new UIVector2((float)offsetXPolicy, (float)offsetYPolicy))
                                                .Add((int)VisualTransformPropertyType.Origin, (int)origin)
                                                .Add((int)VisualTransformPropertyType.AnchorPoint, (int)pivotPoint)
                                                .Append((int)VisualTransformPropertyType.ExtraSize, new UIVector2(extraWidth, extraHeight));

                return cachedVisualTransformPropertyMap;
            }

            internal void ConvertFromPropertyMap(PropertyMap inputMap)
            {
                using (PropertyValue value = inputMap?.Find((int)VisualTransformPropertyType.Size))
                    if (value != null)
                    {
                        using var size = new Size();
                        if (value.Get(size))
                        {
                            width = size.Width;
                            height = size.Height;
                        }
                    }
                using (PropertyValue value = inputMap?.Find((int)VisualTransformPropertyType.Offset))
                    if (value != null)
                    {
                        using var offset = new Position();
                        if (value.Get(offset))
                        {
                            offsetX = offset.X;
                            offsetY = offset.Y;
                        }
                    }
                using (PropertyValue value = inputMap?.Find((int)VisualTransformPropertyType.SizePolicy))
                    if (value != null)
                    {
                        using var policyValue = new Vector2();
                        if (value.Get(policyValue))
                        {
                            widthPolicy = (VisualTransformPolicyType)policyValue.X;
                            heightPolicy = (VisualTransformPolicyType)policyValue.Y;
                        }
                    }
                using (PropertyValue value = inputMap?.Find((int)VisualTransformPropertyType.OffsetPolicy))
                    if (value != null)
                    {
                        using var policyValue = new Vector2();
                        if (value.Get(policyValue))
                        {
                            offsetXPolicy = (VisualTransformPolicyType)policyValue.X;
                            offsetYPolicy = (VisualTransformPolicyType)policyValue.Y;
                        }
                    }
                using (PropertyValue value = inputMap?.Find((int)VisualTransformPropertyType.Origin))
                    if (value != null)
                    {
                        int ret = 0;
                        if (value.Get(out ret))
                        {
                            origin = (Visual.AlignType)ret;
                        }
                    }
                using (PropertyValue value = inputMap?.Find((int)VisualTransformPropertyType.AnchorPoint))
                    if (value != null)
                    {
                        int ret = 0;
                        if (value.Get(out ret))
                        {
                            pivotPoint = (Visual.AlignType)ret;
                        }
                    }
                using (PropertyValue value = inputMap?.Find((int)VisualTransformPropertyType.ExtraSize))
                    if (value != null)
                    {
                        using var extraValue = new Vector2();
                        if (value.Get(extraValue))
                        {
                            extraWidth = extraValue.Width;
                            extraHeight = extraValue.Height;
                        }
                    }
            }
        };
        internal VisualTransformInfo transformInfo;
        #endregion

        #region Constructor
        internal VisualBase(global::System.IntPtr cPtr, bool cMemoryOwn) : this(cPtr, cMemoryOwn, cMemoryOwn)
        {
        }

        internal VisualBase(global::System.IntPtr cPtr, bool cMemoryOwn, bool cRegister) : base(cPtr, cMemoryOwn, cRegister)
        {
            transformInfo = new VisualTransformInfo();
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
        /// It is 0 before being added to the view.
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
                    UpdateVisualProperty((int)Tizen.NUI.Visual.Property.Type, value, true);
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
                UpdateVisualProperty((int)Tizen.NUI.Visual.Property.MixColor, value, false);

                // warning : We should set cached Opacity after set MixColor.
                if (value != null)
                {
                    UpdateVisualProperty((int)Tizen.NUI.Visual.Property.Opacity, value.A, false);
                }
            }
            get
            {
                Tizen.NUI.Color ret = new Tizen.NUI.Color(1.0f, 1.0f, 1.0f, 1.0f);
                using (var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.Visual.Property.MixColor))
                {
                    propertyValue?.Get(ret);
                }
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
                using Tizen.NUI.Color currentVisualColor = Color;
                if (currentVisualColor.A != value)
                {
                    using Tizen.NUI.Color visualColor = new Tizen.NUI.Color(currentVisualColor.R, currentVisualColor.G, currentVisualColor.B, value);
                    UpdateVisualProperty((int)Tizen.NUI.Visual.Property.MixColor, visualColor, false);

                    // warning : We should set cached Opacity after set MixColor.
                    UpdateVisualProperty((int)Tizen.NUI.Visual.Property.Opacity, value, false);
                }
            }
            get
            {
                float ret = 1.0f;
                using var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.Visual.Property.Opacity);
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
        /// <remarks>
        /// Fitting mode is only available when the visual has original size.
        /// For example, ImageVisual and TextVisual support FittingMode, but ColorVisual and BorderVisual don't support.
        /// If visual doesn't have original size, Property set will be ignored.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VisualFittingModeType FittingMode
        {
            set
            {
                if (IsFittingModeAvailable())
                {
                    if (value != VisualFittingModeType.DontCare)
                    {
                        visualFittingModeApplied = true;
                    }
                    else
                    {
                        visualFittingModeApplied = false;
                    }
                    UpdateVisualProperty((int)Tizen.NUI.Visual.Property.VisualFittingMode, value);
                }
                else
                {
                    Tizen.Log.Error("NUI", $"Fitting mode is not supported by this visual type:{Type}. Set as DontCare\n");
                }
            }
            get
            {
                int ret = (int)VisualFittingModeType.DontCare;
                using var propertyValue = GetCachedVisualProperty((int)Tizen.NUI.Visual.Property.VisualFittingMode);
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
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Method used to raise the object, not event")]
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
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Method used to raise the object, not event")]
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
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Method used to raise the object, not event")]
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
#pragma warning disable CA2000 // Dispose objects before losing scope
                    ret = new Visuals.VisualObjectsContainer(cPtr, true);
#pragma warning restore CA2000 // Dispose objects before losing scope
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
                    transformMap?.Dispose();
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
        virtual internal void UpdateVisualProperty(int key, object value, bool requiredVisualCreation = true, bool reqeustProcessor = true)
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
                    using var propertyValue = PropertyValue.CreateFromObject(value);

                    cachedVisualPropertyMap[key] = propertyValue;

                    // Store the changed values in the changedPropertyMap, only if visualCreationRequiredFlag is false.
                    // It will be used when we create the visual, only by UpdateVisualPropertyMap
                    if (!visualCreationRequiredFlag)
                    {
                        if (changedPropertyMap == null)
                        {
                            changedPropertyMap = new PropertyMap();
                        }
                        changedPropertyMap[key] = propertyValue;
                    }
                }
                else
                {
                    // Remove value from cachedVisualPropertyMap if input property map is null.
                    cachedVisualPropertyMap.Remove(key);
                }

                if (reqeustProcessor)
                {
                    ReqeustProcessorOnceEvent();
                }
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

            if (transformInfo.changed)
            {
                UpdateVisualProperty((int)Tizen.NUI.Visual.Property.Transform, transformInfo.ConvertToPropertyMap(), false, false);

                transformInfo.changed = false;
            }

            if (!visualCreationRequiredFlag)
            {
                if (changedPropertyMap != null)
                {
                    // We can change property map of visuals without creating them.
                    Interop.VisualObject.UpdateVisualPropertyMap(SwigCPtr, PropertyMap.getCPtr(changedPropertyMap));

                    changedPropertyMap?.Dispose();
                    changedPropertyMap = null;
                }
                return;
            }

            visualCreationRequiredFlag = false;

            changedPropertyMap?.Dispose();
            changedPropertyMap = null;

            if (cachedVisualPropertyMap == null)
            {
                cachedVisualPropertyMap = new PropertyMap();
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
                ret = GetCurrentVisualProperty(key);
                
                // Update cached value here
                if (ret != null)
                {
                    if (cachedVisualPropertyMap == null)
                    {
                        cachedVisualPropertyMap = new PropertyMap();
                    }
                    cachedVisualPropertyMap[key] = ret;
                }
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
            // Mark as transform property map.
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
        /// Check whether given visual object is available to be use fitting mode or not.
        /// </summary>
        internal bool IsFittingModeAvailable()
        {
            switch (internalType)
            {
                case (int)Tizen.NUI.Visual.Type.Image:
                case (int)Tizen.NUI.Visual.Type.NPatch:
                case (int)Tizen.NUI.Visual.Type.AnimatedImage:
                case (int)Tizen.NUI.Visual.Type.Text:
                {
                    return true;
                }
                case (int)Tizen.NUI.Visual.Type.Invalid:
                case (int)Tizen.NUI.Visual.Type.Border:
                case (int)Tizen.NUI.Visual.Type.Color:
                {
                    return false;
                }
            }
            return false;
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

                changedPropertyMap?.Dispose();
                changedPropertyMap = null;
                cachedVisualPropertyMap?.Dispose();
                cachedVisualPropertyMap = null;
                transformInfo?.Dispose();
                transformInfo = null;
            }

            visualCreationRequiredFlag = false;

            base.Dispose(type);
        }
        #endregion
    }
}