using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.ComponentModel;

namespace Tizen.NUI
{

    /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class FrameCallback : BaseHandle
    {
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FrameCallback() : this(Interop.FrameCallback.FrameUpdateCallback_New(), true)
        {

        }

        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal FrameCallback(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.FrameCallback.FrameUpdateCallback_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void FrameUpdateCallback(float progress);

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddCallback(FrameUpdateCallback callback)
        {
            System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(callback);
            {
                Interop.FrameCallback.FrameUpdateCallback_AddCallback(swigCPtr, new System.Runtime.InteropServices.HandleRef(this, ip));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddMainThreadCallback(FrameUpdateCallback callback)
        {
            System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(callback);
            {
                Interop.FrameCallback.FrameUpdateCallback_AddMainThreadCallback(swigCPtr, new System.Runtime.InteropServices.HandleRef(this, ip));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveCallback()
        {
            Interop.FrameCallback.FrameUpdateCallback_RemoveCallback(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3 GetPosition(uint actorID)
        {
            Vector3 ret = new Vector3(Interop.FrameCallback.FrameUpdateCallback_GetPosition(swigCPtr, actorID), false);
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPosition(uint actorID, Vector3 position)
        {
            Interop.FrameCallback.FrameUpdateCallback_SetPosition(swigCPtr, actorID, Vector3.getCPtr(position));
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void BakePosition(uint actorID, Vector3 position)
        {
            Interop.FrameCallback.FrameUpdateCallback_BakePosition(swigCPtr, actorID, Vector3.getCPtr(position));
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3 GetSize(uint actorID)
        {
            Vector3 ret = new Vector3(Interop.FrameCallback.FrameUpdateCallback_GetSize(swigCPtr, actorID), false);
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetSize(uint actorID, Vector3 size)
        {
            Interop.FrameCallback.FrameUpdateCallback_SetSize(swigCPtr, actorID, Vector3.getCPtr(size));
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void BakeSize(uint actorID, Vector3 size)
        {
            Interop.FrameCallback.FrameUpdateCallback_BakeSize(swigCPtr, actorID, Vector3.getCPtr(size));
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3 GetScale(uint actorID)
        {
            Vector3 ret = new Vector3(Interop.FrameCallback.FrameUpdateCallback_GetScale(swigCPtr, actorID), false);
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetScale(uint actorID, Vector3 scale)
        {
            Interop.FrameCallback.FrameUpdateCallback_SetScale(swigCPtr, actorID, Vector3.getCPtr(scale));
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void BakeScale(uint actorID, Vector3 scale)
        {
            Interop.FrameCallback.FrameUpdateCallback_BakeScale(swigCPtr, actorID, Vector3.getCPtr(scale));
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 GetColor(uint actorID)
        {
            Vector4 ret = new Vector4(Interop.FrameCallback.FrameUpdateCallback_GetColor(swigCPtr, actorID), false);
            return ret;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetColor(uint actorID, Vector4 color)
        {
            Interop.FrameCallback.FrameUpdateCallback_SetColor(swigCPtr, actorID, Vector4.getCPtr(color));
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void BakeColor(uint actorID, Vector4 color)
        {
            Interop.FrameCallback.FrameUpdateCallback_BakeColor(swigCPtr, actorID, Vector4.getCPtr(color));
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetAlphaFunction(AlphaFunction alphaFunction)
        {
            Interop.FrameCallback.FrameUpdateCallback_SetAlphaFunction(swigCPtr, AlphaFunction.getCPtr(alphaFunction));
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AlphaFunction GetAlphaFunction()
        {
            AlphaFunction alphaFunction = new AlphaFunction(Interop.FrameCallback.FrameUpdateCallback_GetAlphaFunction(swigCPtr), false);
            return alphaFunction;
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetDuration(float seconds)
        {
            Interop.FrameCallback.FrameUpdateCallback_SetDuration(swigCPtr, seconds);
        }

        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetDuration()
        {
            return Interop.FrameCallback.FrameUpdateCallback_GetDuration(swigCPtr);
        }

    }
}
