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

using global::System;
using global::System.ComponentModel;
using global::System.Runtime.InteropServices;
namespace Tizen.NUI
{
    /// <summary>
    /// An abstract base class for Constraints.
    /// Callback invoked every frame after Apply(), and stop to Remove().
    /// This class only use for inhouse currently.
    /// </summary>
    /// <remarks>
    /// This can be used to constrain a property of an object, after animations have been applied.
    /// Constraints are applied in the following order:
    ///  - Constraints are applied to on-stage views in a depth-first traversal.
    ///  - For each view, the constraints are applied in the same order as the calls to Apply().
    ///
    /// Use GenerateConstraint() to create new constraints.
    /// We need three parameter to create constraints : Animatable, Property (string or int), and callback.
    ///
    /// Property type and callback type not matched. For example,
    /// "SizeWidth" only allow to use Constraint.ConstraintFloatFunctionCallbackType.
    /// "Position" only allow to use Constraint.ConstraintVector3FunctionCallbackType.
    ///
    /// Vector4 type property is special. We can use both ConstraintVector4FunctionCallbackType and ConstraintColorFunctionCallbackType.
    /// "Color" allow to use Constraint.ConstraintVector4FunctionCallbackType and ConstraintColorFunctionCallbackType.
    ///
    /// You can register constraint callback at generate time, and cannot unregister or remove.
    ///
    /// AddSource used for get input inside of constraint callback.
    /// AddLocalSource is special API s.t. will use target's property.
    /// In the callback, you can get additional values ordered by AddSource API.
    ///
    /// Constraints are not applied to off-stage views.
    /// Constraints be invalidate if the target object, or any of source input objects be disposed.
    ///
    /// Create a constraint using one of the New method depending on the type of callback functions used.
    ///
    /// Note : Callback could be called even after target object or Constraint itself disposed.
    /// Note : This function will called every frame. Maybe reduce performance if you applyed too many constraints.
    /// </remarks>
    /// <example><code>
    /// Constraint constraint = Constraint.GenerateConstraint(view, "SizeWidth", new Constraint.ConstraintFloatFunctionCallbackType(YourCallback));
    /// constraint.AddSource(otherView, "SizeWidth");
    /// constraint.AddLocalSource("Position");
    /// constraint.ApplyAction = ConstraintApplyActionType.Discard;
    /// constraint.Apply();
    ///
    /// SetExtraDataById(constraint.ID, 0.0f); // You can use ID value.
    ///
    /// float YourCallback(float current, uint id, in PropertyInputContainer inputContainer)
    /// {
    ///     float input0 = inputContainer.GetFloat(0u);       // Match with AddSource or AddLocalSource order.
    ///     UIVector3 input1 = inputContainer.GetVector3(1u); // Match with AddSource or AddLocalSource order.
    ///
    ///     // Get extra data by id if you need.
    ///     float extraValue = GetExtraDataById(id);
    ///
    ///     // Implement custom logic.
    ///     float finalValue = current + input0 * 0.1f + input1.X * 0.3f + extraValue;
    ///
    ///     return finalValue;
    /// }
    /// </code></example>
    internal class Constraint : BaseHandle
    {
        public delegate bool ConstraintBooleanFunctionCallbackType(bool current, uint id, in PropertyInputContainer inputContainer);
        public delegate float ConstraintFloatFunctionCallbackType(float current, uint id, in PropertyInputContainer inputContainer);
        public delegate int ConstraintIntegerFunctionCallbackType(int current, uint id, in PropertyInputContainer inputContainer);
        public delegate UIVector2 ConstraintVector2FunctionCallbackType(UIVector2 current, uint id, in PropertyInputContainer inputContainer);
        public delegate UIVector3 ConstraintVector3FunctionCallbackType(UIVector3 current, uint id, in PropertyInputContainer inputContainer);
        public delegate UIColor ConstraintColorFunctionCallbackType(UIColor current, uint id, in PropertyInputContainer inputContainer);
        public delegate Vector4 ConstraintVector4FunctionCallbackType(in Vector4 current, uint id, in PropertyInputContainer inputContainer);
        public delegate Matrix3 ConstraintMatrix3FunctionCallbackType(in Matrix3 current, uint id, in PropertyInputContainer inputContainer);
        public delegate Matrix ConstraintMatrixFunctionCallbackType(in Matrix current, uint id, in PropertyInputContainer inputContainer);
        public delegate Rotation ConstraintRotationFunctionCallbackType(in Rotation current, uint id, in PropertyInputContainer inputContainer);

        /// <summary>
        /// Static custructor.
        /// </summary>
        /// <exception cref="ArgumentNullException"> Thrown when the target or callback is null. </exception>
        /// <exception cref="ArgumentException"> Thrown when the property is not animatable. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Constraint GenerateConstraint(Animatable target, int propertyIndex, System.Delegate callback)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }
            if (callback == null)
            {
                throw new ArgumentNullException(nameof(callback));
            }
            if (propertyIndex == Property.InvalidIndex)
            {
                throw new ArgumentException(nameof(propertyIndex));
            }
            if (!target.IsPropertyAnimatable(propertyIndex))
            {
                throw new ArgumentException("PropertyIndex is not animatable! index : " + propertyIndex);
            }

            PropertyType type = target.GetPropertyType(propertyIndex);

            ConstraintFunctionBase function;
            IntPtr cPtr;
            switch (type)
            {
                case PropertyType.Boolean:
                {
                    if (!(callback is ConstraintBooleanFunctionCallbackType))
                    {
                        throw new ArgumentException("Callback is not ConstraintBooleanFunctionCallbackType!");
                    }
                    function = new ConstraintBooleanFunction(callback as ConstraintBooleanFunctionCallbackType);
                    cPtr = Interop.Constraint.ConstraintBooleanNew(Animatable.getCPtr(target), propertyIndex, ConstraintFunctionBase.getCPtr(function));
                    break;
                }
                case PropertyType.Float:
                {
                    if (!(callback is ConstraintFloatFunctionCallbackType))
                    {
                        throw new ArgumentException("Callback is not ConstraintFloatFunctionCallbackType!");
                    }
                    function = new ConstraintFloatFunction(callback as ConstraintFloatFunctionCallbackType);
                    cPtr = Interop.Constraint.ConstraintFloatNew(Animatable.getCPtr(target), propertyIndex, ConstraintFunctionBase.getCPtr(function));
                    break;
                }
                case PropertyType.Integer:
                {
                    if (!(callback is ConstraintIntegerFunctionCallbackType))
                    {
                        throw new ArgumentException("Callback is not ConstraintIntegerFunctionCallbackType!");
                    }
                    function = new ConstraintIntegerFunction(callback as ConstraintIntegerFunctionCallbackType);
                    cPtr = Interop.Constraint.ConstraintIntegerNew(Animatable.getCPtr(target), propertyIndex, ConstraintFunctionBase.getCPtr(function));
                    break;
                }
                case PropertyType.Vector2:
                {
                    if (!(callback is ConstraintVector2FunctionCallbackType))
                    {
                        throw new ArgumentException("Callback is not ConstraintVector2FunctionCallbackType!");
                    }
                    function = new ConstraintVector2Function(callback as ConstraintVector2FunctionCallbackType);
                    cPtr = Interop.Constraint.ConstraintVector2New(Animatable.getCPtr(target), propertyIndex, ConstraintFunctionBase.getCPtr(function));
                    break;
                }
                case PropertyType.Vector3:
                {
                    if (!(callback is ConstraintVector3FunctionCallbackType))
                    {
                        throw new ArgumentException("Callback is not ConstraintVector3FunctionCallbackType!");
                    }
                    function = new ConstraintVector3Function(callback as ConstraintVector3FunctionCallbackType);
                    cPtr = Interop.Constraint.ConstraintVector3New(Animatable.getCPtr(target), propertyIndex, ConstraintFunctionBase.getCPtr(function));
                    break;
                }
                case PropertyType.Vector4:
                {
                    if (!(callback is ConstraintVector4FunctionCallbackType || callback is ConstraintColorFunctionCallbackType))
                    {
                        throw new ArgumentException("Callback is not ConstraintVector4FunctionCallbackType or ConstraintColorFunctionCallbackType");
                    }
                    if (callback is ConstraintVector4FunctionCallbackType)
                    {
                        function = new ConstraintVector4Function(callback as ConstraintVector4FunctionCallbackType);
                    }
                    else
                    {
                        function = new ConstraintColorFunction(callback as ConstraintColorFunctionCallbackType);
                    }
                    cPtr = Interop.Constraint.ConstraintVector4New(Animatable.getCPtr(target), propertyIndex, ConstraintFunctionBase.getCPtr(function));
                    break;
                }
                case PropertyType.Matrix3:
                {
                    if (!(callback is ConstraintMatrix3FunctionCallbackType))
                    {
                        throw new ArgumentException("Callback is not ConstraintMatrix3FunctionCallbackType!");
                    }
                    function = new ConstraintMatrix3Function(callback as ConstraintMatrix3FunctionCallbackType);
                    cPtr = Interop.Constraint.ConstraintMatrix3New(Animatable.getCPtr(target), propertyIndex, ConstraintFunctionBase.getCPtr(function));
                    break;
                }
                case PropertyType.Matrix:
                {
                    if (!(callback is ConstraintMatrixFunctionCallbackType))
                    {
                        throw new ArgumentException("Callback is not ConstraintMatrixFunctionCallbackType!");
                    }
                    function = new ConstraintMatrixFunction(callback as ConstraintMatrixFunctionCallbackType);
                    cPtr = Interop.Constraint.ConstraintMatrixNew(Animatable.getCPtr(target), propertyIndex, ConstraintFunctionBase.getCPtr(function));
                    break;
                }
                case PropertyType.Rotation:
                {
                    if (!(callback is ConstraintRotationFunctionCallbackType))
                    {
                        throw new ArgumentException("Callback is not ConstraintRotationFunctionCallbackType!");
                    }
                    function = new ConstraintRotationFunction(callback as ConstraintRotationFunctionCallbackType);
                    cPtr = Interop.Constraint.ConstraintRotationNew(Animatable.getCPtr(target), propertyIndex, ConstraintFunctionBase.getCPtr(function));
                    break;
                }
                default:
                {
                    throw new ArgumentException("PropertyIndex is not animatable type! index : " + propertyIndex + " type : " + type);
                }
            }
            NDalicPINVOKE.ThrowExceptionIfExists();
            Constraint ret = new Constraint(target, propertyIndex, function, cPtr);
            return ret;
        }

        /// <summary>
        /// Static custructor.
        /// </summary>
        /// <exception cref="ArgumentNullException"> Thrown when the target or callback is null. </exception>
        /// <exception cref="ArgumentException"> Thrown when the property is not animatable. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Constraint GenerateConstraint(Animatable target, string propertyName, System.Delegate callback)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }
            if (callback == null)
            {
                throw new ArgumentNullException(nameof(callback));
            }

            int propertyIndex = target.GetPropertyIndex(propertyName);
            if (propertyIndex == Property.InvalidIndex)
            {
                throw new ArgumentException("Invalid property! input name : " + propertyName);
            }

            return GenerateConstraint(target, propertyIndex, callback);
        }

        private ConstraintFunctionBase Function { get; init; }
        private WeakReference<Animatable> internalTarget { get; init; }

        private static int aliveCount;

        internal Constraint(Animatable target, int propertyIndex, ConstraintFunctionBase function, IntPtr cPtr) : this(cPtr, true)
        {
            internalTarget = new WeakReference<Animatable>(target);
            PropertyIndex = propertyIndex;
            Function = function;
        }

        internal Constraint(IntPtr cPtr, bool cMemoryOwn) : this(cPtr, cMemoryOwn, cMemoryOwn)
        {
        }

        internal Constraint(IntPtr cPtr, bool cMemoryOwn, bool cRegister) : base(cPtr, cMemoryOwn, cRegister)
        {
            ++aliveCount;
        }

        /// <summary>
        /// Gets the target of constarint
        /// Read-only
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Animatable Target
        {
            get
            {
                if (internalTarget.TryGetTarget(out Animatable ret) && (ret != null) && !ret.IsDisposedOrQueued)
                {
                    return ret;
                }
                return null;
            }
        }

        /// <summary>
        /// Gets the property index of constarint
        /// Read-only
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int PropertyIndex { get; init; }

        /// <summary>
        /// Gets the constraint's ID.
        /// Read-only
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint ID
        {
            get => (Function?.Id ?? 0u);
        }

        /// <summary>
        /// Remove action.
        /// Determine the target values action after apply current constriant.
        /// Default is ConstraintApplyActionType.Bake
        /// </summary>
        /// <remarks>
        /// If ApplyAction is ConstraintApplyActionType.Bake, next frame's current value comes as previous returned value.
        /// For example, if current value was 1.0f and callback return 2.0f, next frame's current value is 2.0f.
        ///
        /// If ApplyAction is ConstraintApplyActionType.Discard, next frame's current value comes as base value.
        /// For example, if current value was 1.0f and callback return 2.0f, next frame's current value is 1.0f.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ConstraintApplyActionType ApplyAction
        {
            set => Interop.Constraint.SetApplyAction(SwigCPtr, (int)value);
            get => (ConstraintApplyActionType) Interop.Constraint.GetApplyAction(SwigCPtr);
        }

        /// <summary>
        /// Tag number. It will be useful when you want to seperate constraints.
        /// We can only use [ConstraintTagRanges.TagMin ConstraintTagRanges.TagMax] and ConstraintTagRanges.Default.
        /// </summary>
        /// <exception cref="ArgumentException"> Thrown when the tag value out of ranges. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint Tag
        {
            set
            {
                if (value > ConstraintTagRanges.TagMax)
                {
                    throw new ArgumentException($"The given tag '{value}' is bigger than maximum tag {ConstraintTagRanges.TagMax}");
                }
                Interop.Constraint.SetTag(SwigCPtr, value);
                NDalicPINVOKE.ThrowExceptionIfExists();
            }
            get => Interop.Constraint.GetTag(SwigCPtr);
        }

        /// <summary>
        /// Gets the number of currently alived Renderable object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int AliveCount => aliveCount;

        /// <summary>
        /// Add source input.
        /// </summary>
        /// <exception cref="ArgumentNullException"> Thrown when the source is null. </exception>
        /// <exception cref="ArgumentException"> Thrown when the property index is invalid. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddSource(Animatable source, int propertyIndex)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (!source.IsPropertyAConstraintInput(propertyIndex))
            {
                throw new ArgumentException("PropertyIndex is not a valid constraint input! index : " + propertyIndex);
            }

            Interop.Constraint.AddSource(SwigCPtr, Animatable.getCPtr(source), propertyIndex);
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        /// <summary>
        /// Add source input.
        /// </summary>
        /// <exception cref="ArgumentNullException"> Thrown when the source is null. </exception>
        /// <exception cref="ArgumentException"> Thrown when the property name is invalid. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddSource(Animatable source, string propertyName)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            AddSource(source, source.GetPropertyIndex(propertyName));
        }

        /// <summary>
        /// Add local source input.
        /// </summary>
        /// <exception cref="ArgumentException"> Thrown when the property index is invalid. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddLocalSource(int propertyIndex)
        {
            var target = Target;
            if (target == null)
            {
                Tizen.Log.Error("NUI", $"Constraint {ID} lost target! Skip AddLocalSource\n");
                return;
            }

            if (!target.IsPropertyAConstraintInput(propertyIndex))
            {
                throw new ArgumentException("PropertyIndex is not a valid constraint input! index : " + propertyIndex);
            }
            Interop.Constraint.AddLocalSource(SwigCPtr, propertyIndex);
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        /// <summary>
        /// Add local source input.
        /// </summary>
        /// <exception cref="ArgumentException"> Thrown when the property name is invalid. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddLocalSource(string propertyName)
        {
            var target = Target;
            if (target == null)
            {
                Tizen.Log.Error("NUI", $"Constraint {ID} lost target! Skip AddLocalSource\n");
                return;
            }

            AddLocalSource(target.GetPropertyIndex(propertyName));
        }

        /// <summary>
        /// Apply current constraint.
        /// Constraint will work until Remove called.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Apply()
        {
            Interop.Constraint.Apply(SwigCPtr);
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        /// <summary>
        /// Apply current constraint after transform update finished.
        /// Constraint will work until Remove called.
        /// </summary>
        /// <remarks>
        /// Transform relative properties (e.g. Size, Position, Orientation) will not be changed this frame.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ApplyPost()
        {
            Interop.Constraint.ApplyPost(SwigCPtr);
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        /// <summary>
        /// Remove current constraint.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Remove()
        {
            Interop.Constraint.Remove(SwigCPtr);
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        /// <summary>
        /// Get constrainted target object
        /// </summary>
        internal Animatable GetTargetObject()
        {
            IntPtr cPtr = Interop.Constraint.GetTargetObject(SwigCPtr);
            Animatable ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as Animatable;
            if (ret != null)
            {
                Interop.BaseHandle.DeleteBaseHandle(new global::System.Runtime.InteropServices.HandleRef(this, cPtr));
                NDalicPINVOKE.ThrowExceptionIfExists();
                return ret;
            }
            else
            {
                ret = new Animatable(cPtr, true);
                return ret;
            }
        }

        /// <summary>
        /// Get constrainted target property index
        /// </summary>
        internal int GetTargetPropertyIndex()
        {
            int index = Interop.Constraint.GetTargetProperty(SwigCPtr);
            NDalicPINVOKE.ThrowExceptionIfExists();
            return index;
        }

        /// <summary>
        /// Add parent source input. Only availiable for BaseComponents.View.
        /// </summary>
        /// <remarks>
        /// We cannot throw exception even if propertyIndex is valid or not. Please use this API carefully
        /// </remarks>
        /// <exception cref="InvalidOperationException"> Thrown when the target is not a BaseComponents.View. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal void AddParentSource(int propertyIndex)
        {
            var target = Target;
            if (target == null)
            {
                Tizen.Log.Error("NUI", $"Constraint {ID} lost target! Skip AddParentSource\n");
                return;
            }

            if (!(target is BaseComponents.View))
            {
                throw new InvalidOperationException($"Error! Target is not a View! type:{target.GetType()}");
            }
            Interop.Constraint.AddParentSource(SwigCPtr, propertyIndex);
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="type"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if(disposed)
            {
                return;
            }
            if(type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
                Remove();
                Function?.Dispose();
            }

            --aliveCount;

            base.Dispose(type);
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(HandleRef swigCPtr)
        {
            Interop.Constraint.DeleteConstraint(swigCPtr);
            NDalicPINVOKE.ThrowExceptionIfExists();
        }
    }
}
