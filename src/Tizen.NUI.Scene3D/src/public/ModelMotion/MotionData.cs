/*
 * Copyright(c) 2023 Samsung Electronics Co., Ltd.
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
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Collections.Generic;

namespace Tizen.NUI.Scene3D
{
    /// <summary>
    /// List of model motion definitions.
    /// Each motion has pair of <see cref="MotionIndex"/> and <see cref="MotionValue"/>.
    /// MotionIndex is abstract class that specify the target of motion.
    /// MotionValue is destination value of target for the motion. It can be expressed with <see cref="Tizen.NUI.PropertyValue"/> or <see cref="Tizen.NUI.KeyFrames"/>.
    /// </summary>
    /// <remarks>
    /// We don't check duplicated MotionIndex internally.
    /// We don't check MotionValue type is matched with MotionIndex.
    /// </remarks>
    /// <example>
    /// We can generate list of motions by MotionIndex and MotionValue classes.
    ///
    /// <code>
    /// MotionData motionData = new MotionData(3.0f);
    ///
    /// // Make MotionIndex with MotionPropertyIndex
    /// // Make MotionValue with PropertyValue
    /// motionData.Add(new MotionPropertyIndex(new PropertyKey("nodeName"), new PropertyKey("color")), new MotionValue(new PropertyValue(Color.Red)));
    ///
    /// // Make MotionIndex with MotionTransformIndex
    /// // Make MotionValue with Dali::KeyFrames
    /// KeyFrames keyFrames = new KeyFrames();
    /// keyFrames.Add(0.0f, 0.0f);
    /// keyFrames.Add(0.0f, 1.0f);
    /// motionData.Add(new MotionTransformIndex(new PropertyKey("nodeName"), MotionTransformIndex.TransformType.PositionX), new MotionValue(keyFrames));
    ///
    /// // Make MotionIndex with BlendShapeIndex
    /// motionData.Add(new BlendShapeIndex(new PropertyKey("nodeName"), new PropertyKey("blendShapeName")), motionData.GetValue(1u));
    /// </code>
    /// </example>
    /// <example>
    /// We can request to load MotionData from file or buffer asynchronously.
    /// If load completed, <see cref="LoadCompleted"/> event will be invoked.
    /// If we try to load before LoadCompleted event invoked, previous load request cancel and only latest request loaded.
    ///
    /// <code>
    /// MotionData motionData = new MotionData();
    /// motionData.LoadCompleted += OnLoadCompleted;
    /// motionData.LoadBvh("bvhFilename.bvh", Vector3.One);
    ///
    /// ...
    ///
    /// void OnLoadCompleted(object o, event e)
    /// {
    ///     MotionData motionData = o as MotionData;
    ///     /// Do something.
    /// }
    /// </code>
    /// </example>
    /// <example>
    /// We can generate animation of Scene3D.Model from MotionData class.
    /// Or, just set values.
    ///
    /// <code>
    /// // Generate animation from loaded Model
    /// Animation animation = model.GenerateMotionDataAnimation(motionData);
    /// animation.Play();
    ///
    /// // Set values from loaded Model.
    /// model2.SetMotionData(motionData);
    /// </code>
    /// </example>
    /// <since_tizen> 11 </since_tizen>
    public class MotionData : BaseHandle
    {
        private EventHandler loadCompletedEventHandler;
        private LoadCompletedCallbackType loadCompletedCallback;
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void LoadCompletedCallbackType(IntPtr motionData);

        /// <summary>
        /// Create an initialized, empty motion data.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public MotionData() : this(Interop.MotionData.MotionDataNew(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Create an initialized motion data with duration.
        /// </summary>
        /// <param name="durationMilliseconds">Duration of an Animation generated from this motion data, in milliseconds.</param>
        /// <since_tizen> 11 </since_tizen>
        public MotionData(int durationMilliseconds) : this(Interop.MotionData.MotionDataNew(MillisecondsToSeconds(durationMilliseconds)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="motionData">Source object to copy.</param>
        /// <since_tizen> 11 </since_tizen>
        public MotionData(MotionData motionData) : this(Interop.MotionData.NewMotionData(MotionData.getCPtr(motionData)), true, false)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Assignment operator.
        /// </summary>
        /// <param name="motionData">Source object to be assigned.</param>
        /// <returns>Reference to this.</returns>
        internal MotionData Assign(MotionData motionData)
        {
            MotionData ret = new MotionData(Interop.MotionData.MotionDataAssign(SwigCPtr, MotionData.getCPtr(motionData)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal MotionData(global::System.IntPtr cPtr, bool cMemoryOwn) : this(cPtr, cMemoryOwn, cMemoryOwn)
        {
        }

        internal MotionData(global::System.IntPtr cPtr, bool cMemoryOwn, bool cRegister) : base(cPtr, cMemoryOwn, cRegister)
        {
        }

        /// <summary>
        /// Get or set the duration of this motion data in milliseconds.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public int Duration
        {
            get
            {
                return SecondsToMilliseconds(GetDuration());
            }
            set
            {
                SetDuration(MillisecondsToSeconds(value));
            }
        }

        /// <summary>
        /// Get the number of contained MotionIndex / MotionValue pair what this hold.
        /// </summary>
        /// <returns>The number of contained motions.</returns>
        /// <since_tizen> 11 </since_tizen>
        public uint GetMotionCount()
        {
            uint ret = Interop.MotionData.GetMotionCount(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Append pair of MotionIndex and MotionValue to the list.
        /// </summary>
        /// <param name="index">MotionIndex to be added</param>
        /// <param name="value">MotionValue to be added</param>
        /// <since_tizen> 11 </since_tizen>
        public void Add(MotionIndex index, MotionValue value)
        {
            Interop.MotionData.Add(SwigCPtr, MotionIndex.getCPtr(index), MotionValue.getCPtr(value));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Get MotionIndex at position, or null if invalid index was given.
        /// </summary>
        /// <param name="index">The index of motion data list</param>
        /// <returns>The MotionIndex at position. Or null.</returns>
        /// <since_tizen> 11 </since_tizen>
        public MotionIndex GetIndex(uint index)
        {
            IntPtr cPtr = Interop.MotionData.GetIndex(SwigCPtr, index);
            MotionIndex ret;

            // Try to downcast as all valid type of indeces.
            ret = MotionTransformIndex.DownCastCPtr(cPtr);
            if (ret == null)
            {
                ret = BlendShapeIndex.DownCastCPtr(cPtr);
            }
            if (ret == null)
            {
                ret = MotionPropertyIndex.DownCastCPtr(cPtr);
            }
            return ret;
        }

        /// <summary>
        /// Get MotionValue at position, or null if invalid index was given.
        /// </summary>
        /// <param name="index">The index of motion data list</param>
        /// <returns>The MotionValue at position. Or null.</returns>
        /// <since_tizen> 11 </since_tizen>
        public MotionValue GetValue(uint index)
        {
            IntPtr cPtr = Interop.MotionData.GetValue(SwigCPtr, index);
            MotionValue ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as MotionValue;
            if (ret == null)
            {
                // Register new animation into Registry.
                ret = new MotionValue(cPtr, true);
            }
            else
            {
                // We found matched NUI animation. Reduce cPtr reference count.
                HandleRef handle = new HandleRef(this, cPtr);
                Interop.MotionValue.DeleteMotionValue(handle);
                handle = new HandleRef(null, IntPtr.Zero);
            }
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            if (!ret.HasBody())
            {
                ret.Dispose();
                ret = null;
            }
            return ret;
        }

        /// <summary>
        /// Load motion capture animation.
        /// We support bvh format.
        /// After load completes, <see cref="LoadCompleted"/> event will be invoked.
        /// </summary>
        /// <remarks>
        /// Scale is additional scale factor of motion capture animation. It is possible that
        /// Model's scale may not match with motion capture animation scale.
        /// If scale is null, default value will be used: <cref name="Vector3.ONE"/>
        /// </remarks>
        /// <param name="motionCaptureFilename">Name of motion capture format file.</param>
        /// <param name="scale">Scale value of motion capture animation match with model.</param>
        /// <param name="synchronousLoad">Load synchronously or not. Default is async load.</param>
        /// <since_tizen> 11 </since_tizen>
        public void LoadMotionCaptureAnimation(string motionCaptureFilename, Vector3 scale = null, bool synchronousLoad = false)
        {
            Interop.MotionData.LoadMotionCaptureAnimation(SwigCPtr, motionCaptureFilename, false, Vector3.getCPtr(scale), synchronousLoad);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Load motion capture animation.
        /// We support bvh format.
        /// After load completes, <see cref="LoadCompleted"/> event will be invoked.
        /// </summary>
        /// <remarks>
        /// Scale is additional scale factor of motion capture animation. It is possible that
        /// Model's scale may not match with motion capture animation scale.
        /// If scale is null, default value will be used: <cref name="Vector3.ONE"/>
        /// </remarks>
        /// <param name="motionCaptureFilename">Name of motion capture format file.</param>
        /// <param name="useRootTranslationOnly">True to use only root translation with rotation animation.</param>
        /// <param name="scale">Scale value of motion capture animation match with model.</param>
        /// <param name="synchronousLoad">Load synchronously or not. Default is async load.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void LoadMotionCaptureAnimation(string motionCaptureFilename, bool useRootTranslationOnly, Vector3 scale = null, bool synchronousLoad = false)
        {
            Interop.MotionData.LoadMotionCaptureAnimation(SwigCPtr, motionCaptureFilename, useRootTranslationOnly, Vector3.getCPtr(scale), synchronousLoad);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Load motion capture animation from string.
        /// We support bvh format.
        /// After load completes, <see cref="LoadCompleted"/> event will be invoked.
        /// </summary>
        /// <remarks>
        /// Scale is additional scale factor of motion capture animation. It is possible that
        /// Model's scale may not match with motion capture animation scale.
        /// If scale is null, default value will be used: <cref name="Vector3.ONE"/>
        /// </remarks>
        /// <param name="motionCaptureBuffer">Contents of motion capture format string.</param>
        /// <param name="scale">Scale value of motion capture animation match with model.</param>
        /// <param name="synchronousLoad">Load synchronously or not. Default is async load.</param>
        /// <since_tizen> 11 </since_tizen>
        public void LoadMotionCaptureAnimationFromBuffer(string motionCaptureBuffer, Vector3 scale = null, bool synchronousLoad = false)
        {
            Interop.MotionData.LoadMotionCaptureAnimationFromBuffer(SwigCPtr, motionCaptureBuffer, motionCaptureBuffer.Length, false, Vector3.getCPtr(scale), synchronousLoad);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Load motion capture animation from string.
        /// We support bvh format.
        /// After load completes, <see cref="LoadCompleted"/> event will be invoked.
        /// </summary>
        /// <remarks>
        /// Scale is additional scale factor of motion capture animation. It is possible that
        /// Model's scale may not match with motion capture animation scale.
        /// If scale is null, default value will be used: <cref name="Vector3.ONE"/>
        /// </remarks>
        /// <param name="motionCaptureBuffer">Contents of motion capture format string.</param>
        /// <param name="useRootTranslationOnly">True to use only root translation with rotation animation.</param>
        /// <param name="scale">Scale value of motion capture animation match with model.</param>
        /// <param name="synchronousLoad">Load synchronously or not. Default is async load.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void LoadMotionCaptureAnimationFromBuffer(string motionCaptureBuffer, bool useRootTranslationOnly, Vector3 scale = null, bool synchronousLoad = false)
        {
            Interop.MotionData.LoadMotionCaptureAnimationFromBuffer(SwigCPtr, motionCaptureBuffer, motionCaptureBuffer.Length, useRootTranslationOnly, Vector3.getCPtr(scale), synchronousLoad);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Load blendshape animation from json file.
        /// After load completed, <see cref="LoadCompleted"/> event will be invoked.
        /// </summary>
        /// <param name="blendShapeFilename">Name of json format file what we predefined.</param>
        /// <param name="synchronousLoad">Load synchronously or not. Default is async load.</param>
        /// <since_tizen> 11 </since_tizen>
        public void LoadBlendShapeAnimation(string blendShapeFilename, bool synchronousLoad = false)
        {
            Interop.MotionData.LoadBlendShapeAnimation(SwigCPtr, blendShapeFilename, synchronousLoad);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Load morphing animation from json string.
        /// After load completed, <see cref="LoadCompleted"/> event will be invoked.
        /// </summary>
        /// <param name="blendShapeBuffer">Contents of json format file what we predefined.</param>
        /// <param name="synchronousLoad">Load synchronously or not. Default is async load.</param>
        /// <since_tizen> 11 </since_tizen>
        public void LoadBlendShapeAnimationFromBuffer(string blendShapeBuffer, bool synchronousLoad = false)
        {
            Interop.MotionData.LoadBlendShapeAnimationFromBuffer(SwigCPtr, blendShapeBuffer, blendShapeBuffer.Length, synchronousLoad);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// LoadCompleted event.
        /// It will be invoked only for latest load request.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public event EventHandler LoadCompleted
        {
            add
            {
                if (loadCompletedEventHandler == null)
                {
                    loadCompletedCallback = OnLoadCompleted;
                    Interop.MotionData.LoadCompletedConnect(SwigCPtr, loadCompletedCallback.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                }
                loadCompletedEventHandler += value;
            }
            remove
            {
                loadCompletedEventHandler -= value;
                if (loadCompletedEventHandler == null && loadCompletedCallback != null)
                {
                    Interop.MotionData.LoadCompletedDisconnect(SwigCPtr, loadCompletedCallback.ToHandleRef(this));
                    NDalicPINVOKE.ThrowExceptionIfExists();
                    loadCompletedCallback = null;
                }
            }
        }

        private void OnLoadCompleted(IntPtr motionData)
        {
            if (loadCompletedEventHandler != null)
            {
                loadCompletedEventHandler(this, null);
            }
        }

        /// <summary>
        /// Removes all stored motions.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public void Clear()
        {
            Interop.MotionData.Clear(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetDuration(float durationSeconds)
        {
            Interop.MotionData.SetDuration(SwigCPtr, durationSeconds);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal float GetDuration()
        {
            float ret = Interop.MotionData.GetDuration(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private static float MillisecondsToSeconds(int millisec)
        {
            return (float)millisec / 1000.0f;
        }

        private static int SecondsToMilliseconds(float sec)
        {
            return (int)(sec * 1000);
        }

        /// <summary>
        /// you can override it to clean-up your own resources.
        /// </summary>
        /// <param name="type">DisposeTypes</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
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

            if (loadCompletedCallback != null)
            {
                NUILog.Debug($"[Dispose] loadCompletedCallback");

                Interop.MotionData.LoadCompletedDisconnect(SwigCPtr, loadCompletedCallback.ToHandleRef(this));
                NDalicPINVOKE.ThrowExceptionIfExists();
                loadCompletedCallback = null;
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Release swigCPtr.
        /// </summary>
        // This will be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(global::System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.MotionData.DeleteMotionData(swigCPtr);
        }
    }
}
