/*
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
using System.Runtime.InteropServices;
using Tizen.NUI.BaseComponents;
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// Cube Transition Effect base class, used to apply custom effects to a
    /// Cube Transition instance.
    /// </summary>
    /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class CubeTransitionEffect : View
    {
        private EventHandler<TransitionCompletedEventArgs> _transitionCompletedEventHandler;
        private TransitionCompletedCallbackDelegate _transitionCompletedCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void TransitionCompletedCallbackDelegate(IntPtr cubeTransition, IntPtr cubeTexture);

        /// <summary>
        /// The constructor.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CubeTransitionEffect() : this(Interop.CubeTransitionEffect.new_CubeTransitionEffect(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(CubeTransitionEffect obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal CubeTransitionEffect(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.CubeTransitionEffect.CubeTransitionEffect_SWIGUpcast(cPtr), cMemoryOwn)
        {
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetTransitionDuration(float duration)
        {
            Interop.CubeTransitionEffect.CubeTransitionEffect_SetTransitionDuration(swigCPtr, duration);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetTransitionDuration()
        {
            float result = Interop.CubeTransitionEffect.CubeTransitionEffect_GetTransitionDuration(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetCubeDisplacement(float displacement)
        {
            Interop.CubeTransitionEffect.CubeTransitionEffect_SetCubeDisplacement(swigCPtr, displacement);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetCubeDisplacement()
        {
            float result = Interop.CubeTransitionEffect.CubeTransitionEffect_GetCubeDisplacement(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsTransitioning()
        {
            bool result = Interop.CubeTransitionEffect.CubeTransitionEffect_IsTransitioning(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetCurrentTexture(Texture texture)
        {
            Interop.CubeTransitionEffect.CubeTransitionEffect_SetCurrentTexture(swigCPtr, Texture.getCPtr(texture));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetTargetTexture(Texture texture)
        {
            Interop.CubeTransitionEffect.CubeTransitionEffect_SetTargetTexture(swigCPtr, Texture.getCPtr(texture));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void StartTransition(bool toNextImage = true)
        {
            Interop.CubeTransitionEffect.CubeTransitionEffect_StartTransition__SWIG1(swigCPtr, toNextImage);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void StartTransition(Vector2 panPosition, Vector2 panDisplacement)
        {
            Interop.CubeTransitionEffect.CubeTransitionEffect_StartTransition__SWIG2(swigCPtr, Vector2.getCPtr(panPosition), Vector2.getCPtr(panDisplacement));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void PauseTransition()
        {
            Interop.CubeTransitionEffect.CubeTransitionEffect_PauseTransition(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ResumeTransition()
        {
            Interop.CubeTransitionEffect.CubeTransitionEffect_ResumeTransition(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void StopTransition()
        {
            Interop.CubeTransitionEffect.CubeTransitionEffect_StopTransition(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        CubeTransitionEffectSignal TransitionCompletedSignal()
        {
            CubeTransitionEffectSignal ret = new CubeTransitionEffectSignal(Interop.CubeTransitionEffect.CubeTransitionEffect_TransitionCompletedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// The TransitionCompleted event.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<TransitionCompletedEventArgs> TransitionCompleted
        {
            add
            {
                if (_transitionCompletedEventHandler == null)
                {
                    _transitionCompletedCallbackDelegate = (OnTransitionCompleted);
                    TransitionCompletedSignal().Connect(_transitionCompletedCallbackDelegate);
                }
                _transitionCompletedEventHandler += value;
            }
            remove
            {
                _transitionCompletedEventHandler -= value;
                if (_transitionCompletedEventHandler == null && TransitionCompletedSignal().Empty() == false)
                {
                    TransitionCompletedSignal().Disconnect(_transitionCompletedCallbackDelegate);
                }
            }
        }

        private void OnTransitionCompleted(IntPtr cubeTransition, IntPtr cubeTexture)
        {
            TransitionCompletedEventArgs e = new TransitionCompletedEventArgs();

            // Populate all members of "e" (TransitionCompletedEventArgs) with real data
            //e.CubeTransitionEffect = Registry.GetManagedBaseHandleFromNativePtr(cubeTransition) as CubeTransitionEffect;

            if (_transitionCompletedEventHandler != null)
            {
                //here we send all data to user event handlers
                _transitionCompletedEventHandler(this, e);
            }
        }

        /// <summary>
        /// Release swigCPtr.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.CubeTransitionEffect.delete_CubeTransitionEffect(swigCPtr);
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class TransitionCompletedEventArgs : EventArgs
        {
            private CubeTransitionEffect _cubeTransitionEffect;
            private Texture _cubeTransitonTexture;

            /// <summary>
            /// CubeTransitionEffect.
            /// </summary>
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public CubeTransitionEffect CubeTransitionEffect
            {
                get
                {
                    return _cubeTransitionEffect;
                }
                set
                {
                    _cubeTransitionEffect = value;
                }
            }

            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Texture CubeTransitonTexture
            {
                get
                {
                    return _cubeTransitonTexture;
                }
                set
                {
                    _cubeTransitonTexture = value;
                }
            }
        }
    }

    internal class CubeTransitionEffectSignal : Disposable
    {

        internal CubeTransitionEffectSignal(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(CubeTransitionEffectSignal obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Empty()
        {
            bool ret = Interop.CubeTransitionEffect.CubeTransitionEffectSignal_Empty(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetConnectionCount()
        {
            uint ret = Interop.CubeTransitionEffect.CubeTransitionEffectSignal_GetConnectionCount(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Connect(System.Delegate func)
        {
            System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(func);
            {
                Interop.CubeTransitionEffect.CubeTransitionEffectSignal_Connect(swigCPtr, new System.Runtime.InteropServices.HandleRef(this, ip));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Disconnect(System.Delegate func)
        {
            System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(func);
            {
                Interop.CubeTransitionEffect.CubeTransitionEffectSignal_Disconnect(swigCPtr, new System.Runtime.InteropServices.HandleRef(this, ip));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Emit(CubeTransitionEffect arg)
        {
            Interop.TextField.TextFieldSignal_Emit(swigCPtr, CubeTransitionEffect.getCPtr(arg));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CubeTransitionEffectSignal() : this(Interop.CubeTransitionEffect.new_CubeTransitionEffectSignal(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.CubeTransitionEffect.delete_CubeTransitionEffectSignal(swigCPtr);
        }
    }

    /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class CubeTransitionWaveEffect : CubeTransitionEffect
    {

        /// <summary>
        /// The constructor.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CubeTransitionWaveEffect(uint numRows, uint numColumns) : this(Interop.CubeTransitionWaveEffect.CubeTransitionWaveEffect_New(numRows, numColumns), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(CubeTransitionWaveEffect obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal CubeTransitionWaveEffect(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.CubeTransitionWaveEffect.CubeTransitionWaveEffect_SWIGUpcast(cPtr), cMemoryOwn)
        {
        }

        /// <summary>
        /// Release swigCPtr.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.CubeTransitionWaveEffect.delete_CubeTransitionWaveEffect(swigCPtr);
        }
    }

    /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class CubeTransitionCrossEffect : CubeTransitionEffect
    {

        /// <summary>
        /// The constructor.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CubeTransitionCrossEffect(uint numRows, uint numColumns) : this(Interop.CubeTransitionCrossEffect.CubeTransitionCrossEffect_New(numRows, numColumns), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(CubeTransitionCrossEffect obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal CubeTransitionCrossEffect(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.CubeTransitionCrossEffect.CubeTransitionCrossEffect_SWIGUpcast(cPtr), cMemoryOwn)
        {
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.CubeTransitionCrossEffect.delete_CubeTransitionCrossEffect(swigCPtr);
        }
    }

    /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class CubeTransitionFoldEffect : CubeTransitionEffect
    {

        /// <summary>
        /// The constructor.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CubeTransitionFoldEffect(uint numRows, uint numColumns) : this(Interop.CubeTransitionFoldEffect.CubeTransitionFoldEffect_New(numRows, numColumns), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(CubeTransitionFoldEffect obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal CubeTransitionFoldEffect(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.CubeTransitionWaveEffect.CubeTransitionWaveEffect_SWIGUpcast(cPtr), cMemoryOwn)
        {
        }

        /// <summary>
        /// Release swigCPtr.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.CubeTransitionFoldEffect.delete_CubeTransitionFoldEffect(swigCPtr);
        }
    }
}