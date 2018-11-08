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
using System.Runtime.InteropServices;

namespace Tizen.Network.Connection
{
    /// <summary>
    /// This is the CellularProfile class. It provides functions to manage the cellular profile.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class CellularProfile : ConnectionProfile
    {
        internal CellularProfile(IntPtr handle): base(handle)
        {
        }

        private CellularAuthInformation _cellularAuthInfo = null;

        /// <summary>
        /// Destroy the CellularProfile object
        /// </summary>
        ~CellularProfile()
        {
        }

        /// <summary>
        /// The APN (access point name).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Cellular access point name.</value>
        /// <exception cref="System.NotSupportedException">Thrown during set when a feature is not supported.</exception>
        /// <exception cref="System.ArgumentException">Thrown during set when a value is an invalid parameter.</exception>
        /// <exception cref="System.ArgumentNullException">Thrown during set when a value is null.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown during set when a profile instance is invalid or when a method fails due to an invalid operation.</exception>
        /// <exception cref="System.ObjectDisposedException">Thrown when an operation is performed on a disposed object.</exception>
        public string Apn
        {
            get
            {
                Log.Debug(Globals.LogTag, "Get Apn");
                IntPtr Value;
                int ret = Interop.ConnectionCellularProfile.GetApn(ProfileHandle, out Value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get apn, " + (ConnectionError)ret);
                }
                string result = Marshal.PtrToStringAnsi(Value);
                Interop.Libc.Free(Value);
                return result;
            }

            set
            {
                Log.Debug(Globals.LogTag, "Set Apn");
                CheckDisposed();
                if (value != null)
                {
                    int ret = Interop.ConnectionCellularProfile.SetApn(ProfileHandle, value);
                    if ((ConnectionError)ret != ConnectionError.None)
                    {
                        Log.Error(Globals.LogTag, "It failed to set apn, " + (ConnectionError)ret);
                        ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.telephony");
                        ConnectionErrorFactory.CheckHandleNullException(ret, (ProfileHandle == IntPtr.Zero), "ProfileHandle may have been disposed or released");
                        ConnectionErrorFactory.ThrowConnectionException(ret);
                    }
                }

                else
                {
                    throw new ArgumentNullException("Value of Apn is null");
                }
            }
        }

        /// <summary>
        /// The home URL.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Cellular home URL.</value>
        /// <exception cref="System.NotSupportedException">Thrown during set when a feature is not supported.</exception>
        /// <exception cref="System.ArgumentException">Thrown during set when a value is an invalid parameter.</exception>
        /// <exception cref="System.ArgumentNullException">Thrown during set when a value is null.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown during set when a profile instance is invalid or when a method fails due to an invalid operation.</exception>
        /// <exception cref="System.ObjectDisposedException">Thrown when an operation is performed on a disposed object.</exception>
        public string HomeUri
        {
            get
            {
                Log.Debug(Globals.LogTag, "Get HomeUri");
                IntPtr Value;
                int ret = Interop.ConnectionCellularProfile.GetHomeUrl(ProfileHandle, out Value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get home url, " + (ConnectionError)ret);
                }
                string result = Marshal.PtrToStringAnsi(Value);
                Interop.Libc.Free(Value);
                return result;
            }

            set
            {
                Log.Debug(Globals.LogTag, "Set HomeUri");
                CheckDisposed();
                if (value != null)
                {
                    int ret = Interop.ConnectionCellularProfile.SetHomeUrl(ProfileHandle, value);
                    if ((ConnectionError)ret != ConnectionError.None)
                    {
                        Log.Error(Globals.LogTag, "It failed to set home url, " + (ConnectionError)ret);
                        ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.telephony");
                        ConnectionErrorFactory.CheckHandleNullException(ret, (ProfileHandle == IntPtr.Zero), "ProfileHandle may have been disposed or released");
                        ConnectionErrorFactory.ThrowConnectionException(ret);
                    }
                }

                else
                {
                    throw new ArgumentNullException("Value of HomeUri is null");
                }
            }
        }

        /// <summary>
        /// The service type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Cellular service type.</value>
        /// <exception cref="System.NotSupportedException">Thrown during set when a feature is not supported.</exception>
        /// <exception cref="System.ArgumentException">Thrown during set when a value is an invalid parameter.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown during set when a profile instance is invalid or when a method fails due to an invalid operation.</exception>
        /// <exception cref="System.ObjectDisposedException">Thrown when an operation is performed on a disposed object.</exception>
        public CellularServiceType ServiceType
        {
            get
            {
                Log.Debug(Globals.LogTag, "Get ServiceType");
                int value;
                int ret = Interop.ConnectionCellularProfile.GetServiceType(ProfileHandle, out value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get service type, " + (ConnectionError)ret);
                }
                return (CellularServiceType)value;
            }

            set
            {
                Log.Debug(Globals.LogTag, "Set ServiceType");
                CheckDisposed();
                int ret = Interop.ConnectionCellularProfile.SetServiceType(ProfileHandle, (int)value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to set service type, " + (ConnectionError)ret);
                    ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.telephony");
                    ConnectionErrorFactory.CheckHandleNullException(ret, (ProfileHandle == IntPtr.Zero), "ProfileHandle may have been disposed or released");
                    ConnectionErrorFactory.ThrowConnectionException(ret);
                }
            }
        }

        /// <summary>
        /// The cellular pdn type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Cellular pdn type.</value>
        /// <exception cref="System.NotSupportedException">Thrown during set when a feature is not supported.</exception>
        /// <exception cref="System.ArgumentException">Thrown during set when a value is an invalid parameter.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown during set when a profile instance is invalid or when a method fails due to an invalid operation.</exception>
        /// <exception cref="System.ObjectDisposedException">Thrown when an operation is performed on a disposed object.</exception>
        public CellularPdnType PdnType
        {
            get
            {
                Log.Debug(Globals.LogTag, "Get PdnType");
                int value;
                int ret = Interop.ConnectionCellularProfile.GetPdnType(ProfileHandle, out value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get pdn type, " + (ConnectionError)ret);
                }
                return (CellularPdnType)value;
            }

            set
            {
                Log.Debug(Globals.LogTag, "Set PdnType");
                CheckDisposed();
                int ret = Interop.ConnectionCellularProfile.SetPdnType(ProfileHandle, (int)value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to set pdn type, " + (ConnectionError)ret);
                    ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.telephony");
                    ConnectionErrorFactory.CheckHandleNullException(ret, (ProfileHandle == IntPtr.Zero), "ProfileHandle may have been disposed or released");
                    ConnectionErrorFactory.ThrowConnectionException(ret);
                }
            }
        }

        /// <summary>
        /// The cellular roaming pdn type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Cellular roaming pdn type.</value>
        /// <exception cref="System.NotSupportedException">Thrown during set when a feature is not supported.</exception>
        /// <exception cref="System.ArgumentException">Thrown during set when a value is an invalid parameter.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown during set when a profile instance is invalid or when a method fails due to an invalid operation.</exception>
        /// <exception cref="System.ObjectDisposedException">Thrown when a operation is performed on a disposed object.</exception>
        public CellularPdnType RoamingPdnType
        {
            get
            {
                Log.Debug(Globals.LogTag, "Get RoamingPdnType");
                int value;
                int ret = Interop.ConnectionCellularProfile.GetRoamingPdnType(ProfileHandle, out value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get roam pdn type, " + (ConnectionError)ret);
                }
                return (CellularPdnType)value;
            }

            set
            {
                Log.Debug(Globals.LogTag, "Set RoamingPdnType");
                CheckDisposed();
                int ret = Interop.ConnectionCellularProfile.SetRoamingPdnType(ProfileHandle, (int)value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to set roam pdn type, " + (ConnectionError)ret);
                    ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.telephony");
                    ConnectionErrorFactory.CheckHandleNullException(ret, (ProfileHandle == IntPtr.Zero), "ProfileHandle may have been disposed or released");
                    ConnectionErrorFactory.ThrowConnectionException(ret);
                }
            }
        }

		/// <summary>
		/// Checks whether the connection is in roaming state.
		/// </summary>
		/// <since_tizen> 6 </since_tizen>
		/// <value> True if the cellular profile is in roaming state, otherwise false.</value>
		public bool IsRoming
		{
			get
			{
				Log.Debug(Globals.LogTag, "Get IsRoming");
				bool value = false;
				int ret = Interop.ConnectionCellularProfile.IsRoaming, out value);
				if ((ConnectionError)ret != ConnectionError.None)
				{
					Log.Error(Globals.LogTag, "It failed to get isRoaming, " + (ConnectionError)ret);
				}
				return value;
			}
		}

        /// <summary>
        /// The cellular authentication information.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Instance of CellularAuthInformation.</value>
        /// <exception cref="System.NotSupportedException">Thrown during set when a feature is not supported.</exception>
        /// <exception cref="System.ArgumentException">Thrown during set when a value is an invalid parameter.</exception>
        /// <exception cref="System.ArgumentNullException">Thrown during set when a value is null.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown during set when a profile instance is invalid or when a method fails due to an invalid operation.</exception>
        /// <exception cref="System.ObjectDisposedException">Thrown when an operation is performed on a disposed object.</exception>
        public CellularAuthInformation CellularAuthInfo
        {
            get
            {
                int type;
                string name;
                string password;
                int ret = Interop.ConnectionCellularProfile.GetAuthInfo(ProfileHandle, out type, out name, out password);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get cellular authentication information, " + (ConnectionError)ret);
                    return null;
                }

                if (_cellularAuthInfo == null)
                    _cellularAuthInfo = new CellularAuthInformation();
                _cellularAuthInfo.AuthType = (CellularAuthType)type;
                _cellularAuthInfo.UserName = name;
                _cellularAuthInfo.Password = password;
                return _cellularAuthInfo;
            }

            set
            {
                CheckDisposed();
                if (value != null)
                {
                    _cellularAuthInfo = value;
                    int type = (int)_cellularAuthInfo.AuthType;
                    string name = _cellularAuthInfo.UserName;
                    string password = _cellularAuthInfo.Password;
                    int ret = Interop.ConnectionCellularProfile.SetAuthInfo(ProfileHandle, type, name, password);
                    if ((ConnectionError)ret != ConnectionError.None)
                    {
                        Log.Error(Globals.LogTag, "It failed to set auth information, " + (ConnectionError)ret);
                        ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.telephony");
                        ConnectionErrorFactory.CheckHandleNullException(ret, (ProfileHandle == IntPtr.Zero), "ProfileHandle may have been disposed or released");
                        ConnectionErrorFactory.ThrowConnectionException(ret);
                    }
                }

                else
                {
                    throw new ArgumentNullException("CellularAuthInformation value is null");
                }
            }
        }

        /// <summary>
        /// Checks whether the profile is hidden.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>True if the cellular profile is hidden, otherwise false.</value>
        public bool Hidden
        {
            get
            {
                bool value;
                int ret = Interop.ConnectionCellularProfile.IsHidden(ProfileHandle, out value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get hidden value, " + (ConnectionError)ret);
                }
                return value;
            }
        }

        /// <summary>
        /// Checks whether the profile is editable.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>True if the cellular profile is editable, otherwise false.</value>
        public bool Editable
        {
            get
            {
                bool value;
                int ret = Interop.ConnectionCellularProfile.IsEditable(ProfileHandle, out value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get editable value, " + (ConnectionError)ret);
                }
                return value;
            }
        }

        /// <summary>
        /// Checks whether the profile is default.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>True if the cellular profile is default, otherwise false.</value>
        public bool IsDefault
        {
            get
            {
                bool value;
                int ret = Interop.ConnectionCellularProfile.IsDefault(ProfileHandle, out value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get IsDefault value, " + (ConnectionError)ret);
                }
                return value;
            }
        }
    }

    /// <summary>
    /// This is the CellularAuthInformation class. It provides the properties to get and set the cellular authentication information.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class CellularAuthInformation
    {
        /// <summary>
        /// Default constructor. Initializes an object of the CellularAuthInformation.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public CellularAuthInformation()
        {
        }

        /// <summary>
        /// The user name.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Cellular user name.</value>
        public string UserName { get; set;}
        /// <summary>
        /// The password.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Cellular password.</value>
        public string Password { get; set; }

        /// <summary>
        /// The authentication type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Cellular authentication type.</value>
        public CellularAuthType AuthType { get; set; }
    }
}
