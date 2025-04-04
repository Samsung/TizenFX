/*
 * Copyright (c) 2024 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    /// <summary>
    /// WebDeviceList.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class WebDeviceList : Disposable
    {
        internal WebDeviceList(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// This will not be public opened.
        /// <param name="swigCPtr"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.WebDeviceList.Delete(swigCPtr);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal void GetTypeAndConnect(out int type, out bool connect, int idx)
        {
            Interop.WebDeviceList.GetTypeAndConnect(SwigCPtr, out type, out connect, idx);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal string GetDeviceId(int idx)
        {
            string ret = Interop.WebDeviceList.GetDeviceId(SwigCPtr, idx);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal string GetDeviceLabel(int idx)
        {
            string ret = Interop.WebDeviceList.GetDeviceLabel(SwigCPtr, idx);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public List<WebDeviceListItem> Get(int size)
        {
            List<WebDeviceListItem> ret = new List<WebDeviceListItem>();

            for (int i = 0; i < size; i++)
            {
                WebDeviceListItem item = new WebDeviceListItem();
                item.Id = GetDeviceId(i);
                item.Label = GetDeviceLabel(i);

                int type = -1;
                bool connect = false;
                GetTypeAndConnect(out type, out connect, i);
                item.Type = (WebMediaDeviceType)type;
                item.Connected = connect;
                Tizen.Log.Fatal("NT", $"@@@ [{i}] id={item.Id}, label={item.Label}, type={item.Type}, conn={item.Connected}");
                ret.Add(item);
            }

            Tizen.Log.Fatal("NT", $"list size={ret.Count}");
            return ret;
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct WebDeviceListItem
    {
        public string Id;
        public string Label;
        public WebMediaDeviceType Type;
        public bool Connected;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum WebMediaDeviceType
    {
        Unknown = -1,
        AudioInput = 0,
        VideoInput,
        AudioOutput,
    }
}
