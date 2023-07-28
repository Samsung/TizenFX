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
using System.IO;
using System.Runtime.InteropServices;
using System;
using System.Runtime.InteropServices;
using global::System.Runtime.InteropServices;
using System.ComponentModel;
using System.Reflection;

namespace Tizen.NUI.ParticleSystem
{
    using Tizen.NUI.BaseComponents;

    /*
     * constexpr ParticleStreamTypeFlagBit POSITION_STREAM_BIT      = 1 << 0; ///< 3D Position stream
constexpr ParticleStreamTypeFlagBit ROTATION_STREAM_BIT      = 1 << 1; ///< 3D Rotation stream
constexpr ParticleStreamTypeFlagBit SCALE_STREAM_BIT         = 1 << 2; ///< 3D Scale stream
constexpr ParticleStreamTypeFlagBit SIZE_STREAM_BIT          = 1 << 3;
constexpr ParticleStreamTypeFlagBit COLOR_STREAM_BIT         = 1 << 4;
constexpr ParticleStreamTypeFlagBit OPACITY_STREAM_BIT       = 1 << 5;
constexpr ParticleStreamTypeFlagBit VELOCITY_STREAM_BIT      = 1 << 6;
constexpr ParticleStreamTypeFlagBit LIFETIME_STREAM_BIT      = 1 << 7;
constexpr ParticleStreamTypeFlagBit LIFETIME_BASE_STREAM_BIT = 1 << 8;
constexpr ParticleStreamTypeFlagBit ALL_STREAMS              = 255;
constexpr ParticleStreamTypeFlagBit DEFAULT_STREAMS          = 255; ///< Default streams
     */

    public enum ParticleStream
    {
        Position      = 1 << 0,
        Rotation      = 1 << 1,
        Scale         = 1 << 2,
        Size          = 1 << 3,
        Color         = 1 << 4,
        Opacity       = 1 << 5,
        Velocity      = 1 << 6,
        Lifetime      = 1 << 7,
        Lifetime_Base = 1 << 8,
    }

    public class Particle
    {
        /// <summary>
        /// Create an initialized  Particle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal Particle(HandleRef list, uint index)
        {
            mIndex = index;
            mParticleListRef = list;
        }
        
        public class StreamView
        {
            internal StreamView(HandleRef list, uint particleIndex, uint streamIndex)
            {
                mParticleIndex = particleIndex;
                mStreamIndex = (int)streamIndex;
                mOwnerList = list;
            }
            
            internal StreamView(HandleRef list, uint particleIndex, ParticleStream builtInStream)
            {
                mOwnerList = list;
                mParticleIndex = particleIndex;
                mStreamIndex = Interop.ParticleList.GetDefaultStreamIndex(mOwnerList, (uint)(builtInStream));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            
            internal struct Value
            {
                internal float valueFloat;
                internal Vector2 valueVector2;
                internal Vector3 valueVector3;
                internal Vector4 valueVector4;
            }

            internal StreamView(float f)
            {
                value.valueFloat = f;
                type = typeof(float);
            }
            internal StreamView(Vector2 f)
            {
                value.valueVector2 = f;
                type = typeof(Vector2);
            }
            internal StreamView(Vector3 f)
            {
                value.valueVector3 = f;
                type = typeof(Vector3);
            }
            internal StreamView(Vector4 f)
            {
                value.valueVector4 = f;
                type = typeof(Vector4);
            }
            
            public static implicit operator StreamView(float value)
            {
                return new StreamView(value);
            }
            public static implicit operator StreamView(Vector2 value)
            {
                return new StreamView(value);
            }
            public static implicit operator StreamView(Vector3 value)
            {
                return new StreamView(value);
            }
            public static implicit operator StreamView(Vector4 value)
            {
                return new StreamView(value);
            }

            public static implicit operator float(StreamView sv)
            {
                var ret = sv.mStreamIndex >= 0 ? Interop.Particle.ReadFloat(sv.mOwnerList, (uint)sv.mStreamIndex, sv.mParticleIndex) : 0.0f;
                if (NDalicPINVOKE.SWIGPendingException.Pending)
                    throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }

            public static implicit operator Vector2(StreamView sv) {
                var ret = sv.mStreamIndex >= 0 ? new Vector2(Interop.Particle.ReadVector2(sv.mOwnerList, (uint)sv.mStreamIndex, sv.mParticleIndex), true) : Vector2.Zero;
                if (NDalicPINVOKE.SWIGPendingException.Pending)
                    throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
            public static implicit operator Vector3(StreamView sv) {
                var ret = sv.mStreamIndex >= 0 ? new Vector3(Interop.Particle.ReadVector3(sv.mOwnerList, (uint)sv.mStreamIndex, sv.mParticleIndex), true) : Vector3.Zero;
                if (NDalicPINVOKE.SWIGPendingException.Pending)
                    throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
            public static implicit operator Vector4(StreamView sv) {
                
                var ret = sv.mStreamIndex >= 0 ? new Vector4(Interop.Particle.ReadVector4(sv.mOwnerList, (uint)sv.mStreamIndex, sv.mParticleIndex), true) : Vector4.Zero;
                if (NDalicPINVOKE.SWIGPendingException.Pending)
                    throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }

            private int mStreamIndex;
            private uint mParticleIndex;
            private HandleRef mOwnerList;
            private Value value;
            private System.Type type;
        }
        
        public StreamView GetStreamValue(uint streamIndex)
        {
            return new StreamView(mParticleListRef, mIndex, streamIndex);
        }
        
        public StreamView GetStreamValue(ParticleStream streamIndex)
        {
            return new StreamView(mParticleListRef, mIndex, streamIndex);
        }

        public void SetStreamValue(float value, uint streamIndex)
        {
            Interop.Particle.WriteFloat(mParticleListRef, streamIndex, mIndex, value);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
        
        public void SetStreamValue(Vector2 value, uint streamIndex)
        {
            Interop.Particle.WriteVector2(mParticleListRef, streamIndex, mIndex, value.SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetStreamValue(Vector3 value, uint streamIndex)
        {
            Interop.Particle.WriteVector3(mParticleListRef, streamIndex, mIndex, value.SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
        
        public void SetStreamValue(Vector4 value, uint streamIndex)
        {
            Interop.Particle.WriteVector4(mParticleListRef, streamIndex, mIndex, value.SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
        
        public void SetStreamValue(float value, ParticleStream particleStream)
        {
            uint streamIndex = (uint)(Interop.ParticleList.GetDefaultStreamIndex(mParticleListRef, (uint)(particleStream)));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            
            Interop.Particle.WriteFloat(mParticleListRef, streamIndex, mIndex, value);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
        
        public void SetStreamValue(Vector2 value, ParticleStream particleStream)
        {
            uint streamIndex = (uint)(Interop.ParticleList.GetDefaultStreamIndex(mParticleListRef, (uint)(particleStream)));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            
            Interop.Particle.WriteVector2(mParticleListRef, streamIndex, mIndex, value.SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetStreamValue(Vector3 value, ParticleStream particleStream)
        {
            uint streamIndex = (uint)(Interop.ParticleList.GetDefaultStreamIndex(mParticleListRef, (uint)(particleStream)));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            
            Interop.Particle.WriteVector3(mParticleListRef, streamIndex, mIndex, value.SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
        
        public void SetStreamValue(Vector4 value, ParticleStream particleStream)
        {
            uint streamIndex = (uint)(Interop.ParticleList.GetDefaultStreamIndex(mParticleListRef, (uint)(particleStream)));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            
            Interop.Particle.WriteVector4(mParticleListRef, streamIndex, mIndex, value.SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
        
        
        // Returns pointer to the element 
        public unsafe T* Get<T>(uint streamIndex, uint elementCount) where T : unmanaged
        {
            //var ptr = ParticleSystem.Interop.Particle.GetUnsafe(mNativePtr, streamIndex, elementCount, sizeof(T));
            //return (T*)ptr;
            return null;
        }


        private uint GetStreamIndex(ParticleStream streamBit)
        {
            uint streamIndex = (uint)(Interop.ParticleList.GetDefaultStreamIndex(mParticleListRef, (uint)(streamBit)));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return streamIndex;
        }
        
        // Properties
        public Vector3 Position
        {
            get
            {
                var streamIndex = GetStreamIndex(ParticleStream.Position);
                var ret = new Vector3(Interop.Particle.ReadVector3(mParticleListRef, (uint)streamIndex, mIndex), true);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
            set
            {
                SetStreamValue( value, ParticleStream.Position);
            }
        }
        
        public Vector4 Color
        {
            get
            {
                var streamIndex = GetStreamIndex(ParticleStream.Color);
                var ret = new Vector4(Interop.Particle.ReadVector4(mParticleListRef, (uint)streamIndex, mIndex), true);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
            set
            {
                SetStreamValue( value, ParticleStream.Color);
            }
        }
        
        public Vector3 Velocity
        {
            get
            {
                var streamIndex = GetStreamIndex(ParticleStream.Velocity);
                var ret = new Vector3(Interop.Particle.ReadVector3(mParticleListRef, (uint)streamIndex, mIndex), true);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
            set
            {
                SetStreamValue( value, ParticleStream.Velocity);
            }
        }
        
        public Vector3 Scale
        {
            get
            {
                var streamIndex = GetStreamIndex(ParticleStream.Scale);
                var ret = new Vector3(Interop.Particle.ReadVector3(mParticleListRef, (uint)streamIndex, mIndex), true);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
            set
            {
                SetStreamValue( value, ParticleStream.Scale);
            }
        }
        
        public Vector4 Rotation
        {
            get
            {
                var streamIndex = GetStreamIndex(ParticleStream.Rotation);
                var ret = new Vector4(Interop.Particle.ReadVector4(mParticleListRef, (uint)streamIndex, mIndex), true);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
            set
            {
                SetStreamValue( value, ParticleStream.Rotation);
            }
        }
        
        public float Opacity
        {
            get
            {
                var streamIndex = GetStreamIndex(ParticleStream.Opacity);
                var ret = Interop.Particle.ReadFloat(mParticleListRef, (uint)streamIndex, mIndex);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
            set
            {
                SetStreamValue( value, ParticleStream.Opacity);
            }
        }
        
        public float Lifetime
        {
            get
            {
                var streamIndex = GetStreamIndex(ParticleStream.Lifetime);
                var ret = Interop.Particle.ReadFloat(mParticleListRef, (uint)streamIndex, mIndex);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
            set
            {
                SetStreamValue( value, ParticleStream.Lifetime);
            }
        }
        
        public float LifetimeBase
        {
            get
            {
                var streamIndex = GetStreamIndex(ParticleStream.Lifetime_Base);
                var ret = Interop.Particle.ReadFloat(mParticleListRef, (uint)streamIndex, mIndex);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
            set
            {
                SetStreamValue( value, ParticleStream.Lifetime_Base);
            }
        }


        private uint mIndex;
        private HandleRef mParticleListRef;
    }

}