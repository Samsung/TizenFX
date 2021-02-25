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
        private EventHandler<TransitionCompletedEventArgs> transitionCompletedEventHandler;
        private TransitionCompletedCallbackDelegate _transitionCompletedCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void TransitionCompletedCallbackDelegate(IntPtr cubeTransition, IntPtr cubeTexture);

        /// <summary>
        /// The constructor.
        /// </summary>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CubeTransitionEffect() : this(Interop.CubeTransitionEffect.NewCubeTransitionEffect(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(CubeTransitionEffect obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        internal CubeTransitionEffect(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetTransitionDuration(float duration)
        {
            Interop.CubeTransitionEffect.SetTransitionDuration(SwigCPtr, duration);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetTransitionDuration()
        {
            float result = Interop.CubeTransitionEffect.GetTransitionDuration(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetCubeDisplacement(float displacement)
        {
            Interop.CubeTransitionEffect.SetCubeDisplacement(SwigCPtr, displacement);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetCubeDisplacement()
        {
            float result = Interop.CubeTransitionEffect.GetCubeDisplacement(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsTransitioning()
        {
            bool result = Interop.CubeTransitionEffect.IsTransitioning(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetCurrentTexture(Texture texture)
        {
            Interop.CubeTransitionEffect.SetCurrentTexture(SwigCPtr, Texture.getCPtr(texture));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetTargetTexture(Texture texture)
        {
            Interop.CubeTransitionEffect.SetTargetTexture(SwigCPtr, Texture.getCPtr(texture));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void StartTransition(bool toNextImage = true)
        {
            Interop.CubeTransitionEffect.StartTransitionSwig1(SwigCPtr, toNextImage);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void StartTransition(Vector2 panPosition, Vector2 panDisplacement)
        {
            Interop.CubeTransitionEffect.StartTransitionSwig2(SwigCPtr, Vector2.getCPtr(panPosition), Vector2.getCPtr(panDisplacement));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void PauseTransition()
        {
            Interop.CubeTransitionEffect.PauseTransition(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ResumeTransition()
        {
            Interop.CubeTransitionEffect.ResumeTransition(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void StopTransition()
        {
            Interop.CubeTransitionEffect.StopTransition(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        CubeTransitionEffectSignal TransitionCompletedSignal()
        {
            CubeTransitionEffectSignal ret = new CubeTransitionEffectSignal(Interop.CubeTransitionEffect.TransitionCompletedSignal(SwigCPtr), false);
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
                if (transitionCompletedEventHandler == null)
                {
                    _transitionCompletedCallbackDelegate = (OnTransitionCompleted);
                    TransitionCompletedSignal().Connect(_transitionCompletedCallbackDelegate);
                }
                transitionCompletedEventHandler += value;
            }
            remove
            {
                transitionCompletedEventHandler -= value;
                if (transitionCompletedEventHandler == null && TransitionCompletedSignal().Empty() == false)
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

            if (transitionCompletedEventHandler != null)
            {
                //here we send all data to user event handlers
                transitionCompletedEventHandler(this, e);
            }
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.CubeTransitionEffect.DeleteCubeTransitionEffect(swigCPtr);
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class TransitionCompletedEventArgs : EventArgs
        {
            private CubeTransitionEffect cubeTransitionEffect;
            private Texture cubeTransitonTexture;

            /// <summary>
            /// CubeTransitionEffect.
            /// </summary>
            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public CubeTransitionEffect CubeTransitionEffect
            {
                get
                {
                    return cubeTransitionEffect;
                }
                set
                {
                    cubeTransitionEffect = value;
                }
            }

            /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Texture CubeTransitonTexture
            {
                get
                {
                    return cubeTransitonTexture;
                }
                set
                {
                    cubeTransitonTexture = value;
                }
            }
        }
    }

    internal class CubeTransitionEffectSignal : Disposable
    {

        internal CubeTransitionEffectSignal(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }


        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Empty()
        {
            bool ret = Interop.CubeTransitionEffect.CubeTransitionEffectSignalEmpty(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetConnectionCount()
        {
            uint ret = Interop.CubeTransitionEffect.CubeTransitionEffectSignalGetConnectionCount(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Connect(System.Delegate func)
        {
            System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(func);
            {
                Interop.CubeTransitionEffect.CubeTransitionEffectSignalConnect(SwigCPtr, new System.Runtime.InteropServices.HandleRef(this, ip));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Disconnect(System.Delegate func)
        {
            System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(func);
            {
                Interop.CubeTransitionEffect.CubeTransitionEffectSignalDisconnect(SwigCPtr, new System.Runtime.InteropServices.HandleRef(this, ip));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Emit(CubeTransitionEffect arg)
        {
            Interop.TextField.TextFieldSignalEmit(SwigCPtr, CubeTransitionEffect.getCPtr(arg));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CubeTransitionEffectSignal() : this(Interop.CubeTransitionEffect.NewCubeTransitionEffectSignal(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.CubeTransitionEffect.DeleteCubeTransitionEffectSignal(swigCPtr);
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
        public CubeTransitionWaveEffect(uint numRows, uint numColumns) : this(Interop.CubeTransitionWaveEffect.New(numRows, numColumns), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }


        internal CubeTransitionWaveEffect(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// This will be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.CubeTransitionWaveEffect.DeleteCubeTransitionWaveEffect(swigCPtr);
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
        public CubeTransitionCrossEffect(uint numRows, uint numColumns) : this(Interop.CubeTransitionCrossEffect.New(numRows, numColumns), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }


        internal CubeTransitionCrossEffect(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.CubeTransitionCrossEffect.DeleteCubeTransitionCrossEffect(swigCPtr);
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
        public CubeTransitionFoldEffect(uint numRows, uint numColumns) : this(Interop.CubeTransitionFoldEffect.New(numRows, numColumns), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }


        internal CubeTransitionFoldEffect(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.CubeTransitionFoldEffect.DeleteCubeTransitionFoldEffect(swigCPtr);
        }
    }
}
