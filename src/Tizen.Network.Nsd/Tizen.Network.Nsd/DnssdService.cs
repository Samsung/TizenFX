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

namespace Tizen.Network.Nsd
{
    /// <summary>
    /// This class is used for managing local service discovery using DNSSD.
    /// </summary>
    public class DnssdService : INsdService
    {
        private uint _service;

        /// <summary>
        /// Name of DNSSD local service.
        /// </summary>
        public string Name
        {
            get
            {
                string name;
                int ret = Interop.Nsd.Dnssd.GetName(_service, out name);
                if (ret != (int)DnssdError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get name of service, Error: " + (DnssdError)ret);
                    return null;
                }

                return name;
            }

            set
            {
                int ret = Interop.Nsd.Dnssd.SetName(_service, value.ToString());
                if (ret != (int)DnssdError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set name of service, Error: " + (DnssdError)ret);
                    NsdErrorFactory.ThrowDnssdException(ret);
                }
            }
        }

        /// <summary>
        /// Type of DNSSD local/remote service.
        /// </summary>
        public string Type
        {
            get
            {
                string type;
                int ret = Interop.Nsd.Dnssd.GetType(_service, out type);
                if (ret != (int)DnssdError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get type of service, Error: " + (DnssdError)ret);
                    return null;
                }

                return type;
            }
        }
    }
}
