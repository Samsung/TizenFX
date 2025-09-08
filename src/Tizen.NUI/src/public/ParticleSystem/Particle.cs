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
using System.ComponentModel;
using System.Reflection;

namespace Tizen.NUI.ParticleSystem
{
    using Tizen.NUI.BaseComponents;

    /// <summary>
    /// Declares types of default streams 
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum ParticleStream
    {
        Position      = 1 << 0, // Vector3, Position of particle
        Rotation      = 1 << 1, // Vector4, Rotation of particle (quaternion)
        Scale         = 1 << 2, // Vector3, Scale of particle
        Size          = 1 << 3, // Vector3, size of particle
        Color         = 1 << 4, // Vector4/Color - Color of particle, (RGBA)
        Opacity       = 1 << 5, // float, opacity (0.0-1.0)
        Velocity      = 1 << 6, // Vector3, vector of velocity
        Lifetime      = 1 << 7, // float, remaining lifetime
        LifetimeBase  = 1 << 8, // float, initial lifetime
    }

    /// <summary>
    /// Particle class provides interface to particle data streams
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Particle
    {
        /// <summary>
        /// StreamView provides functionality allowing particle
        /// data manipulation (read/write).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class StreamView
        {
            internal StreamView(HandleRef list, uint particleIndex, uint streamIndex)
            {
                mParticleIndex = particleIndex;
                mStreamIndex = (int)streamIndex;
                mEmitterRef = list;
            }
            
            internal StreamView(HandleRef list, uint particleIndex, ParticleStream builtInStream)
            {
                mEmitterRef = list;
                mParticleIndex = particleIndex;
                mStreamIndex = Interop.ParticleEmitter.GetDefaultStreamIndex(mEmitterRef, (uint)(builtInStream));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            
            private struct Value
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
            
            /// <summary>
            /// Conversion operator to float value
            /// </summary>
            /// <param name="sv">StreamView object</param>
            /// <returns>Converted value</returns>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static implicit operator float(StreamView sv)
            {
                var ret = sv.mStreamIndex >= 0 ? Interop.Particle.ReadFloat(sv.mEmitterRef, (uint)sv.mStreamIndex, sv.mParticleIndex) : 0.0f;
                if (NDalicPINVOKE.SWIGPendingException.Pending)
                    throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }

            /// <summary>
            /// Conversion operator to Vector2 value
            /// </summary>
            /// <param name="sv">StreamView object</param>
            /// <returns>Converted value</returns>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static implicit operator Vector2(StreamView sv) {
                var ret = sv.mStreamIndex >= 0 ? new Vector2(Interop.Particle.ReadVector2(sv.mEmitterRef, (uint)sv.mStreamIndex, sv.mParticleIndex), true) : Vector2.Zero;
                if (NDalicPINVOKE.SWIGPendingException.Pending)
                    throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
            
            /// <summary>
            /// Conversion operator to Vector3 value
            /// </summary>
            /// <param name="sv">StreamView object</param>
            /// <returns>Converted value</returns>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static implicit operator Vector3(StreamView sv) {
                var ret = sv.mStreamIndex >= 0 ? new Vector3(Interop.Particle.ReadVector3(sv.mEmitterRef, (uint)sv.mStreamIndex, sv.mParticleIndex), true) : Vector3.Zero;
                if (NDalicPINVOKE.SWIGPendingException.Pending)
                    throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }

            /// <summary>
            /// Conversion operator to Vecto4 value
            /// </summary>
            /// <param name="sv">StreamView object</param>
            /// <returns>Converted value</returns>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public static implicit operator Vector4(StreamView sv) {
                
                var ret = sv.mStreamIndex >= 0 ? new Vector4(Interop.Particle.ReadVector4(sv.mEmitterRef, (uint)sv.mStreamIndex, sv.mParticleIndex), true) : Vector4.Zero;
                if (NDalicPINVOKE.SWIGPendingException.Pending)
                    throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }

            private int mStreamIndex;
            private uint mParticleIndex;
            private HandleRef mEmitterRef;
            private Value value;
            private System.Type type;
        }
        
        /// <summary>
        /// Create an initialized Particle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal Particle(HandleRef emitter, uint index)
        {
            mIndex = index;
            mEmitterRef = emitter;
        }
        
        /// <summary>
        /// Returns value from specified data stream (default/custom)
        /// </summary>
        /// <param name="streamIndex">Index of stream to get value from</param>
        /// <returns>StreamView object</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StreamView GetStreamValue(uint streamIndex)
        {
            return new StreamView(mEmitterRef, mIndex, streamIndex);
        }

        /// <summary>
        /// Returns value from specified default streamIndex
        /// </summary>
        /// <param name="streamIndex">Index of stream to get value from</param>
        /// <returns>StreamView object</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StreamView GetStreamValue(ParticleStream streamIndex)
        {
            return new StreamView(mEmitterRef, mIndex, streamIndex);
        }

        /// <summary>
        /// Sets value on the specified data stream
        /// </summary>
        /// <param name="value">Value to set</param>
        /// <param name="streamIndex">Index of stream to get value from</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetStreamValue(float value, uint streamIndex)
        {
            Interop.Particle.WriteFloat(mEmitterRef, streamIndex, mIndex, value);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
        
        /// <summary>
        /// Sets value on the specified data stream
        /// </summary>
        /// <param name="value">Value to set</param>
        /// <param name="streamIndex">Index of stream to get value from</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetStreamValue(Vector2 value, uint streamIndex)
        {
            Interop.Particle.WriteVector2(mEmitterRef, streamIndex, mIndex, value.SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets value on the specified data stream
        /// </summary>
        /// <param name="value">Value to set</param>
        /// <param name="streamIndex">Index of stream to get value from</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetStreamValue(Vector3 value, uint streamIndex)
        {
            Interop.Particle.WriteVector3(mEmitterRef, streamIndex, mIndex, value.SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
        
        /// <summary>
        /// Sets value on the specified data stream
        /// </summary>
        /// <param name="value">Value to set</param>
        /// <param name="streamIndex">Index of stream to get value from</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetStreamValue(Vector4 value, uint streamIndex)
        {
            Interop.Particle.WriteVector4(mEmitterRef, streamIndex, mIndex, value.SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
        
        /// <summary>
        /// Sets value on the specified data stream
        /// </summary>
        /// <param name="value">Value to set</param>
        /// <param name="particleStream">Stream to get value from</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetStreamValue(float value, ParticleStream particleStream)
        {
            uint streamIndex = (uint)(Interop.ParticleEmitter.GetDefaultStreamIndex(mEmitterRef, (uint)(particleStream)));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            
            Interop.Particle.WriteFloat(mEmitterRef, streamIndex, mIndex, value);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
        
        /// <summary>
        /// Sets value on the specified data stream
        /// </summary>
        /// <param name="value">Value to set</param>
        /// <param name="particleStream">Stream to get value from</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetStreamValue(Vector2 value, ParticleStream particleStream)
        {
            uint streamIndex = (uint)(Interop.ParticleEmitter.GetDefaultStreamIndex(mEmitterRef, (uint)(particleStream)));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            
            Interop.Particle.WriteVector2(mEmitterRef, streamIndex, mIndex, value.SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets value on the specified data stream
        /// </summary>
        /// <param name="value">Value to set</param>
        /// <param name="particleStream">Stream to get value from</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetStreamValue(Vector3 value, ParticleStream particleStream)
        {
            uint streamIndex = (uint)(Interop.ParticleEmitter.GetDefaultStreamIndex(mEmitterRef, (uint)(particleStream)));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            
            Interop.Particle.WriteVector3(mEmitterRef, streamIndex, mIndex, value.SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
        
        /// <summary>
        /// Sets value on the specified data stream
        /// </summary>
        /// <param name="value">Value to set</param>
        /// <param name="particleStream">Stream to get value from</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetStreamValue(Vector4 value, ParticleStream particleStream)
        {
            uint streamIndex = (uint)(Interop.ParticleEmitter.GetDefaultStreamIndex(mEmitterRef, (uint)(particleStream)));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            
            Interop.Particle.WriteVector4(mEmitterRef, streamIndex, mIndex, value.SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
        

        /// <summary>
        /// Returns index of one of default streams.
        /// </summary>
        /// <param name="streamBit">Stream to get index</param>
        /// <returns>Index of stream within emitter</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private uint GetStreamIndex(ParticleStream streamBit)
        {
            uint streamIndex = (uint)(Interop.ParticleEmitter.GetDefaultStreamIndex(mEmitterRef, (uint)(streamBit)));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return streamIndex;
        }
        
        /// <summary>
        /// Position of the Particle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3 Position
        {
            get
            {
                var streamIndex = GetStreamIndex(ParticleStream.Position);
                var ret = new Vector3(Interop.Particle.ReadVector3(mEmitterRef, (uint)streamIndex, mIndex), true);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
            set
            {
                SetStreamValue( value, ParticleStream.Position);
            }
        }

        /// <summary>
        /// Color of the Particle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 Color
        {
            get
            {
                var streamIndex = GetStreamIndex(ParticleStream.Color);
                var ret = new Vector4(Interop.Particle.ReadVector4(mEmitterRef, (uint)streamIndex, mIndex), true);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
            set
            {
                SetStreamValue( value, ParticleStream.Color);
            }
        }
        
        /// <summary>
        /// Velocity of the Particle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3 Velocity
        {
            get
            {
                var streamIndex = GetStreamIndex(ParticleStream.Velocity);
                var ret = new Vector3(Interop.Particle.ReadVector3(mEmitterRef, (uint)streamIndex, mIndex), true);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
            set
            {
                SetStreamValue( value, ParticleStream.Velocity);
            }
        }
        
        /// <summary>
        /// Scale of the Particle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3 Scale
        {
            get
            {
                var streamIndex = GetStreamIndex(ParticleStream.Scale);
                var ret = new Vector3(Interop.Particle.ReadVector3(mEmitterRef, (uint)streamIndex, mIndex), true);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
            set
            {
                SetStreamValue( value, ParticleStream.Scale);
            }
        }
        
        /// <summary>
        /// Rotation of the Particle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 Rotation
        {
            get
            {
                var streamIndex = GetStreamIndex(ParticleStream.Rotation);
                var ret = new Vector4(Interop.Particle.ReadVector4(mEmitterRef, (uint)streamIndex, mIndex), true);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
            set
            {
                SetStreamValue( value, ParticleStream.Rotation);
            }
        }
        
        /// <summary>
        /// Opacity of the Particle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Opacity
        {
            get
            {
                var streamIndex = GetStreamIndex(ParticleStream.Opacity);
                var ret = Interop.Particle.ReadFloat(mEmitterRef, (uint)streamIndex, mIndex);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
            set
            {
                SetStreamValue( value, ParticleStream.Opacity);
            }
        }
        
        /// <summary>
        /// Lifetime of the Particle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Lifetime
        {
            get
            {
                var streamIndex = GetStreamIndex(ParticleStream.Lifetime);
                var ret = Interop.Particle.ReadFloat(mEmitterRef, (uint)streamIndex, mIndex);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
            set
            {
                SetStreamValue( value, ParticleStream.Lifetime);
            }
        }
        
        /// <summary>
        /// Initial lifetime of the Particle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float LifetimeBase
        {
            get
            {
                var streamIndex = GetStreamIndex(ParticleStream.LifetimeBase);
                var ret = Interop.Particle.ReadFloat(mEmitterRef, (uint)streamIndex, mIndex);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
            set
            {
                SetStreamValue( value, ParticleStream.LifetimeBase);
            }
        }

        /// <summary>
        /// Index of the Particle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal uint Index
        {
            get => mIndex;
            set
            {
                mIndex = value;
            }
        }

        private uint mIndex;
        private readonly HandleRef mEmitterRef;
    }
}
