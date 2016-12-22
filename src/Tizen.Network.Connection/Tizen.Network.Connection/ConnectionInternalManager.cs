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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Collections;

namespace Tizen.Network.Connection
{
    class HandleHolder : IDisposable
    {
        private IntPtr Handle;
        private bool disposed = false;

        public HandleHolder()
        {
            Log.Debug(Globals.LogTag, "HandleHolder() ^^");
            Interop.Connection.Create(out Handle);
            Log.Debug(Globals.LogTag, "Handle: " + Handle);
        }

        ~HandleHolder()
        {
            Dispose(false);
        }

        internal IntPtr GetHandle()
        {
            return Handle;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free managed objects.
            }
            Interop.Connection.Destroy(Handle);
            disposed = true;
        }
    }

    static class ConnectionInternalManager
    {
        private static HandleHolder Holder = new HandleHolder();

        static public IntPtr GetHandle()
        {
            return Holder.GetHandle();
        }

        static internal int GetProfileIterator(ProfileListType type, out IntPtr iterator)
        {
            return Interop.Connection.GetProfileIterator(Holder.GetHandle(), (int)type, out iterator);
        }

        static internal bool HasNext(IntPtr iterator)
        {
            return Interop.Connection.HasNextProfileIterator(iterator);
        }

        static internal int NextProfileIterator(IntPtr iterator, out IntPtr profileHandle)
        {
            return Interop.Connection.GetNextProfileIterator(iterator, out profileHandle);
        }

        static internal int DestoryProfileIterator(IntPtr iterator)
        {
            return Interop.Connection.DestroyProfileIterator(iterator);
        }

        static public string GetIpAddress(AddressFamily family)
        {
            IntPtr ip;
            int ret = Interop.Connection.GetIpAddress(Holder.GetHandle(), (int)family, out ip);
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to get IP address, " + (ConnectionError)ret);
                ConnectionErrorFactory.ThrowConnectionException(ret);
            }
            string result = Marshal.PtrToStringAnsi(ip);
            Interop.Libc.Free(ip);
            return result;
        }

        static public string GetProxy(AddressFamily family)
        {
            IntPtr ip;
            int ret = Interop.Connection.GetProxy(Holder.GetHandle(), (int)family, out ip);
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to get proxy, " + (ConnectionError)ret);
                ConnectionErrorFactory.ThrowConnectionException(ret);
            }
            string result = Marshal.PtrToStringAnsi(ip);
            Interop.Libc.Free(ip);
            return result;
        }

        static public string GetMacAddress(ConnectionType type)
        {
            IntPtr ip;
            int ret = Interop.Connection.GetMacAddress(Holder.GetHandle(), (int)type, out ip);
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to get mac address, " + (ConnectionError)ret);
                ConnectionErrorFactory.ThrowConnectionException(ret);
            }
            string result = Marshal.PtrToStringAnsi(ip);
            Interop.Libc.Free(ip);
            return result;
        }

        static public ConnectionType ConnectionType
        {
            get
            {
                int type = 0;
                Log.Debug(Globals.LogTag, "Handle: " + Holder.GetHandle());
                int ret = Interop.Connection.GetType(Holder.GetHandle(), out type);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get connection type, " + (ConnectionError)ret);
                }
                return (ConnectionType)type;
            }
        }

        static public CellularState CellularState
        {
            get
            {
                int type = 0;
                int ret = Interop.Connection.GetCellularState(Holder.GetHandle(), out type);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get cellular state, " + (ConnectionError)ret);
                }
                return (CellularState)type;
            }
        }

        static public ConnectionState WiFiState
        {
            get
            {
                int type = 0;
                int ret = Interop.Connection.GetWiFiState(Holder.GetHandle(), out type);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get wifi state, " + (ConnectionError)ret);
                }
                return (ConnectionState)type;
            }
        }

        static public ConnectionState BluetoothState
        {
            get
            {
                int type = 0;
                int ret = Interop.Connection.GetBtState(Holder.GetHandle(), out type);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get bluetooth state, " + (ConnectionError)ret);
                }
                return (ConnectionState)type;
            }
        }

        static public ConnectionState EthernetState
        {
            get
            {
                int type = 0;
                int ret = Interop.Connection.GetEthernetState(Holder.GetHandle(), out type);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get ethernet state, " + (ConnectionError)ret);
                }
                return (ConnectionState)type;
            }
        }

        static public EthernetCableState EthernetCableState
        {
            get
            {
                int type = 0;
                int ret = Interop.Connection.GetEthernetCableState(Holder.GetHandle(), out type);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get ethernet cable state, " + (ConnectionError)ret);
                }
                return (EthernetCableState)type;
            }
        }

        static public IntPtr CreateRequestProfile(ConnectionProfileType type, string keyword)
        {
            Log.Error(Globals.LogTag, "CreateRequestProfile, " + type + ", " + keyword);
            Log.Debug(Globals.LogTag, "Handle: " + GetHandle());
            IntPtr handle = IntPtr.Zero;
            int ret = Interop.ConnectionProfile.Create((int)type, keyword, out handle);
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to Create profile, " + (ConnectionError)ret);
                ConnectionErrorFactory.ThrowConnectionException(ret);
            }

            return handle;
        }

        static public int AddProfile(RequestProfile profile)
        {
            int ret = 0;
            if (profile.Type == ConnectionProfileType.Cellular)
            {
                ret = Interop.Connection.AddProfile(Holder.GetHandle(), ((RequestCellularProfile)profile).ProfileHandle);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to add profile, " + (ConnectionError)ret);
                    ConnectionErrorFactory.ThrowConnectionException(ret);
                }
            }
            else if (profile.Type == ConnectionProfileType.WiFi)
            {
                ret = Interop.Connection.AddProfile(Holder.GetHandle(), ((RequestWiFiProfile)profile).ProfileHandle);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to add profile, " + (ConnectionError)ret);
                    ConnectionErrorFactory.ThrowConnectionException(ret);
                }
            }
            return ret;
        }

        static public int RemoveProfile(ConnectionProfile profile)
        {
            int ret = Interop.Connection.RemoveProfile(Holder.GetHandle(), profile.ProfileHandle);
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to remove profile, " + (ConnectionError)ret);
                ConnectionErrorFactory.ThrowConnectionException(ret);
            }
            return ret;
        }

        static public int UpdateProfile(ConnectionProfile profile)
        {
            int ret = Interop.Connection.UpdateProfile(Holder.GetHandle(), profile.ProfileHandle);
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to update profile, " + (ConnectionError)ret);
                ConnectionErrorFactory.ThrowConnectionException(ret);
            }
            return ret;
        }

        static public ConnectionProfile GetCurrentProfile()
        {
            IntPtr ProfileHandle;
            int ret = Interop.Connection.GetCurrentProfile(Holder.GetHandle(), out ProfileHandle);
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to get current profile, " + (ConnectionError)ret);
                ConnectionErrorFactory.ThrowConnectionException(ret);
            }
            ConnectionProfile Profile = new ConnectionProfile(ProfileHandle);
            return Profile;
        }

        static public ConnectionProfile GetDefaultCellularProfile(CellularServiceType type)
        {
            IntPtr ProfileHandle;
            int ret = Interop.Connection.GetDefaultCellularServiceProfile(Holder.GetHandle(), (int)type, out ProfileHandle);
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "Error: " + ret);
                Log.Error(Globals.LogTag, "It failed to get default cellular profile, " + (ConnectionError)ret);
                ConnectionErrorFactory.ThrowConnectionException(ret);
            }
            CellularProfile Profile = new CellularProfile(ProfileHandle);
            return Profile;
        }

        static public Task<ConnectionError> SetDefaultCellularProfile(CellularServiceType type, ConnectionProfile profile)
        {
            var task = new TaskCompletionSource<ConnectionError>();
            Interop.Connection.ConnectionCallback Callback = (ConnectionError Result, IntPtr Data) =>
            {
                task.SetResult((ConnectionError)Result);
                return;
            };
            int ret = Interop.Connection.SetDefaultCellularServiceProfileAsync(Holder.GetHandle(), (int)type, profile.ProfileHandle, Callback, (IntPtr)0);
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to set default cellular profile, " + (ConnectionError)ret);
                ConnectionErrorFactory.ThrowConnectionException(ret);
            }
            return task.Task;
        }


        static public Task<IEnumerable<ConnectionProfile>> GetProfileListAsync(ProfileListType type)
        {
            var task = new TaskCompletionSource<IEnumerable<ConnectionProfile>>();

            List<ConnectionProfile> Result = new List<ConnectionProfile>();
            IntPtr iterator;
            int ret = Interop.Connection.GetProfileIterator(Holder.GetHandle(), (int)type, out iterator);
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to get profile iterator, " + (ConnectionError)ret);
            }

            while (Interop.Connection.HasNextProfileIterator(iterator))
            {
                IntPtr nextH;
                IntPtr profileH;
                Interop.Connection.GetNextProfileIterator(iterator, out nextH);
                Interop.ConnectionProfile.Clone(out profileH, nextH);

                int profileType;
                Interop.ConnectionProfile.GetType(profileH, out profileType);

                if ((ConnectionProfileType)profileType == ConnectionProfileType.WiFi)
                {
                    WiFiProfile cur = new WiFiProfile(profileH);
                    Result.Add(cur);
                }
                else if ((ConnectionProfileType)profileType == ConnectionProfileType.Cellular)
                {
                    CellularProfile cur = new CellularProfile(profileH);
                    Result.Add(cur);
                }
                else {
                    ConnectionProfile cur = new ConnectionProfile(profileH);
                    Result.Add(cur);
                }
            }
            Interop.Connection.DestroyProfileIterator(iterator);
            task.SetResult(Result);
            return task.Task;
        }

        static public Task<ConnectionError> OpenProfileAsync(ConnectionProfile profile)
        {
            var task = new TaskCompletionSource<ConnectionError>();
            Interop.Connection.ConnectionCallback Callback = (ConnectionError Result, IntPtr Data) =>
            {
                task.SetResult((ConnectionError)Result);
                return;
            };
            int ret = Interop.Connection.OpenProfile(Holder.GetHandle(), profile.ProfileHandle, Callback, IntPtr.Zero);
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to oepn profile, " + (ConnectionError)ret);
                ConnectionErrorFactory.ThrowConnectionException(ret);
            }
            return task.Task;
        }

        static public Task<ConnectionError> CloseProfileAsync(ConnectionProfile profile)
        {
            var task = new TaskCompletionSource<ConnectionError>();
            Interop.Connection.ConnectionCallback Callback = (ConnectionError Result, IntPtr Data) =>
            {
                task.SetResult((ConnectionError)Result);
                return;
            };
            int ret = Interop.Connection.CloseProfile(Holder.GetHandle(), profile.ProfileHandle, Callback, IntPtr.Zero);
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to close profile, " + (ConnectionError)ret);
                ConnectionErrorFactory.ThrowConnectionException(ret);
            }
            return task.Task;
        }
    }
}
