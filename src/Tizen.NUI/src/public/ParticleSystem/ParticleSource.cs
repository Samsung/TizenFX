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

using System.Reflection;
using System;
using System.Runtime.InteropServices;

namespace Tizen.NUI.ParticleSystem
{
    using Tizen.NUI.BaseComponents;

    public class ParticleSourceInterface
    {
        public ParticleSourceInterface()
        {
        }

        public virtual void Construct(params object[] list)
        {
        }

        public virtual uint Update(ParticleList particleList, uint count)
        {
            return 0;
        }

        public virtual void Init()
        {
            
        }

        public ParticleEmitter Emitter;
    }
    
    public partial class ParticleSource<T> : BaseHandle where T : ParticleSourceInterface, new()
    {
        static void OnInitInvoker(IntPtr cPtr)
        {
            ParticleSource<T> source = (cPtr == IntPtr.Zero) ? null : Registry.GetManagedBaseHandleFromRefObject(cPtr) as ParticleSource<T>;
            source.mInterface.Init();
        }

        static uint OnUpdateInvoker(IntPtr cPtr, IntPtr listPtr, uint count)
        {
            //var api = new ParticleListView(cPtr);
            //turn source.mInterface.Update(list, count);
            ParticleSource<T> source = (cPtr == IntPtr.Zero) ? null : Registry.GetManagedBaseHandleFromRefObject(cPtr) as ParticleSource<T>;
            ParticleList list = (listPtr == IntPtr.Zero) ? null : Registry.GetManagedBaseHandleFromRefObject(listPtr) as ParticleList;

            if (list == null)
            {
                return 0;
            }
            else
            {
                return source.mInterface.Update(list, count);
            }
        }
        
        internal ParticleSource(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal static Interop.ParticleSource.ParticleSourceInitInvokerType mOnInitInvoker = OnInitInvoker;
        internal static Interop.ParticleSource.ParticleSourceUpdateInvokerType mOnUpdateInvoker = OnUpdateInvoker;
        
        //[EditorBrowsable(EditorBrowsableState.Never)]
        public ParticleSource(params object[] list) : this(Interop.ParticleSource.New( mOnInitInvoker, mOnUpdateInvoker ), true)
        {
            // Create interface on the C# side (no direct connection with C++)
            mInterface = new T();
            mInterface.Construct(list);
            
            // Initialise native side for this interface
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetEmitter(ParticleEmitter emitter)
        {
            mInterface.Emitter = emitter;
        }

        public ParticleSourceInterface GetCallbackInterface()
        {
            return mInterface;
        }
        
        private ParticleSourceInterface mInterface = null;
    }
}