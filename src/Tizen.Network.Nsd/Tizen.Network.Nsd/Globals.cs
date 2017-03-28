/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Threading;

namespace Tizen.Network.Nsd
{
    internal static class Globals
    {
        internal const string LogTag = "Tizen.Network.Nsd";

        internal static void DnssdInitialize()
        {
            int ret = Interop.Nsd.Dnssd.Initialize();
            if(ret!=(int)DnssdError.None)
            {
                Log.Error(LogTag, "Failed to initialize Dnssd, Error - "+ (DnssdError)ret);
                NsdErrorFactory.ThrowDnssdException(ret);
            }
        }

        internal static void SsdpInitialize()
        {
            int ret = Interop.Nsd.Ssdp.Initialize();
            if (ret != (int)SsdpError.None)
            {
                Log.Error(LogTag, "Failed to initialize Ssdp, Error - " + (SsdpError)ret);
                NsdErrorFactory.ThrowSsdpException(ret);
            }
        }

        internal static ThreadLocal<DnssdInitializer> s_threadDns = new ThreadLocal<DnssdInitializer>(() =>
       {
           Log.Info(LogTag, "Inside Dnssd ThreadLocal delegate");
           return new DnssdInitializer();
       });

        internal static ThreadLocal<SsdpInitializer> s_threadSsd = new ThreadLocal<SsdpInitializer>(() =>
        {
            Log.Info(LogTag, "Inside Ssdp ThreadLocal delegate");
            return new SsdpInitializer();
        });
    }
}
