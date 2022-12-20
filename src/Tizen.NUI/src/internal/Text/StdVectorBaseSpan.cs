/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;
using System.Collections.Generic;
using Tizen.NUI.Text.Spans;

namespace Tizen.NUI.Text
{
    /// This will not be public opened.
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class StdVectorBaseSpan : Disposable
    {

        internal StdVectorBaseSpan(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        public BaseSpan ValueOfIndex(uint index)
        {
            global::System.IntPtr cPtr = Interop.StdVectorBaseSpan.ValueOfIndex(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            TextSpanType type = (TextSpanType)Interop.StdVectorBaseSpan.TypeOfIndex(SwigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            BaseSpan ret = BaseSpanFactory.CreateBaseSpanFromPtr(cPtr, type);

            return ret;
        }

        public int Size()
        {
            int size = Interop.StdVectorBaseSpan.Size(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return size;
        }

        public List<BaseSpan> CreateListFromNativeVector( )
        {
            int count = this.Size();
            List<BaseSpan> list = new List<BaseSpan>();

            for(int i = 0; i < count; i++)
                list.Add( ValueOfIndex((uint)i));

            return list;
        }

        public List<BaseSpan> FillListFromNativeVector(List<BaseSpan> list)
        {
            if(list != null)
            {
                int count = this.Size();

                for(int i = 0; i < count; i++)
                    list.Add( ValueOfIndex((uint)i));
            }
            return list;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.StdVectorBaseSpan.ReleaseVector(swigCPtr);
        }
    }
}