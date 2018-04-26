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
using System.Collections;

namespace Tizen.Network.Connection
{
    /// <summary>
    /// This is the ConnectionProfileManager class. It provides functions to add, get, connect, or modify the connection profile.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public static class ConnectionProfileManager
    {
        /// <summary>
        /// Adds a new profile.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="profile">The cellular profile object.</param>
        /// <privilege>http://tizen.org/privilege/network.profile</privilege>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <feature>http://tizen.org/feature/network.tethering.bluetooth</feature>
        /// <feature>http://tizen.org/feature/network.ethernet</feature>
        /// <exception cref="System.NotSupportedException">Thrown when a feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        /// <exception cref="System.ArgumentException">Thrown when a value is an invalid parameter.</exception>
        /// <exception cref="System.ArgumentNullException">Thrown when a value is null.</exception>
        /// <exception cref="System.OutOfMemoryException">Thrown when memory is not enough to continue execution.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when connection or profile instance is invalid or when a method fails due to an invalid operation.</exception>
        public static void AddCellularProfile(CellularProfile profile)
        {
            Log.Debug(Globals.LogTag, "AddCellularProfile");
            ConnectionInternalManager.Instance.AddCellularProfile(profile);
        }

        /// <summary>
        /// Gets the list of the profile with the profile list type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="type">The type of profile.</param>
        /// <returns>List of connection profile objects.</returns>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <feature>http://tizen.org/feature/network.tethering.bluetooth</feature>
        /// <feature>http://tizen.org/feature/network.ethernet</feature>
        /// <exception cref="System.NotSupportedException">Thrown when a feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        /// <exception cref="System.ArgumentException">Thrown when value is an invalid parameter.</exception>
        /// <exception cref="System.OutOfMemoryException">Thrown when memory is not enough to continue execution.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when a connection instance has been disposed.</exception>
        public static Task<IEnumerable<ConnectionProfile>> GetProfileListAsync(ProfileListType type)
        {
            Log.Debug(Globals.LogTag, "GetProfileListAsync");
            return ConnectionInternalManager.Instance.GetProfileListAsync(type);
        }

        /// <summary>
        /// Opens a connection of profile asynchronously.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="profile">The connection profile object.</param>
        /// <returns>A task indicates whether the ConnectProfileAsync method is done successfully or not.</returns>
        /// <remarks>
        /// This method must be called from MainThread.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <privilege>http://tizen.org/privilege/network.set</privilege>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <feature>http://tizen.org/feature/network.tethering.bluetooth</feature>
        /// <feature>http://tizen.org/feature/network.ethernet</feature>
        /// <exception cref="System.NotSupportedException">Thrown when a feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        /// <exception cref="System.ArgumentException">Thrown when value is an invalid parameter.</exception>
        /// <exception cref="System.ArgumentNullException">Thrown when a value is null.</exception>
        /// <exception cref="System.OutOfMemoryException">Thrown when memory is not enough to continue execution.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when a connection or a profile instance is invalid or when a method fails due to an invalid operation.</exception>
        public static Task ConnectProfileAsync(ConnectionProfile profile)
        {
            Log.Debug(Globals.LogTag, "ConnectProfile");
            return ConnectionInternalManager.Instance.OpenProfileAsync(profile);
        }

        /// <summary>
        /// Closes a connection of profile.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="profile">The connection profile object.</param>
        /// <returns>A task indicates whether the DisconnectProfileAsync method is done successfully or not.</returns>
        /// <remarks>
        /// This method must be called from MainThread.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <privilege>http://tizen.org/privilege/network.set</privilege>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <feature>http://tizen.org/feature/network.tethering.bluetooth</feature>
        /// <feature>http://tizen.org/feature/network.ethernet</feature>
        /// <exception cref="System.NotSupportedException">Thrown when a feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        /// <exception cref="System.ArgumentException">Thrown when a value is an invalid parameter.</exception>
        /// <exception cref="System.ArgumentNullException">Thrown when a value is null.</exception>
        /// <exception cref="System.OutOfMemoryException">Thrown when memory is not enough to continue execution.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when a connection or a profile instance is invalid or when a method fails due to invalid operation.</exception>
        public static Task DisconnectProfileAsync(ConnectionProfile profile)
        {
            Log.Debug(Globals.LogTag, "DisconnectProfileAsync");
            return ConnectionInternalManager.Instance.CloseProfileAsync(profile);
        }

        /// <summary>
        /// Removes an existing profile.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="profile">The connection profile object.</param>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <privilege>http://tizen.org/privilege/network.profile</privilege>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <feature>http://tizen.org/feature/network.tethering.bluetooth</feature>
        /// <feature>http://tizen.org/feature/network.ethernet</feature>
        /// <exception cref="System.NotSupportedException">Thrown when a feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        /// <exception cref="System.ArgumentException">Thrown when value is an invalid parameter.</exception>
        /// <exception cref="System.ArgumentNullException">Thrown when a value is null.</exception>
        /// <exception cref="System.OutOfMemoryException">Thrown when memory is not enough to continue execution.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when a connection or a profile instance is invalid or when a method fails due to invalid operation.</exception>
        public static void RemoveProfile(ConnectionProfile profile)
        {
            Log.Debug(Globals.LogTag, "RemoveProfile. Id: " + profile.Id + ", Name: " + profile.Name + ", Type: " + profile.Type);
            ConnectionInternalManager.Instance.RemoveProfile(profile);
        }

        /// <summary>
        /// Updates an existing profile.
        /// When a profile is changed, these changes will be not applied to the ConnectionProfileManager immediately.
        /// When you call this function, your changes affect the ConnectionProfileManager and the existing profile is updated.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="profile">The connection profile object.</param>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <privilege>http://tizen.org/privilege/network.profile</privilege>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <feature>http://tizen.org/feature/network.tethering.bluetooth</feature>
        /// <feature>http://tizen.org/feature/network.ethernet</feature>
        /// <exception cref="System.NotSupportedException">Thrown when a feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        /// <exception cref="System.ArgumentException">Thrown when a value is an invalid parameter.</exception>
        /// <exception cref="System.ArgumentNullException">Thrown when a value is null.</exception>
        /// <exception cref="System.OutOfMemoryException">Thrown when memory is not enough to continue execution.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when a connection or a profile instance is invalid or when a method fails due to an invalid operation.</exception>
        public static void UpdateProfile(ConnectionProfile profile)
        {
            Log.Debug(Globals.LogTag, "UpdateProfile");
            ConnectionInternalManager.Instance.UpdateProfile(profile);
        }

        /// <summary>
        /// Gets the name of the default profile.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>Connection profile object.</returns>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <feature>http://tizen.org/feature/network.tethering.bluetooth</feature>
        /// <feature>http://tizen.org/feature/network.ethernet</feature>
        /// <exception cref="System.NotSupportedException">Thrown when a feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        /// <exception cref="System.ArgumentException">Thrown when a value is an invalid parameter.</exception>
        /// <exception cref="System.OutOfMemoryException">Thrown when memory is not enough to continue execution.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when a connection instance is invalid or when a method fails due to an invalid operation.</exception>
        public static ConnectionProfile GetCurrentProfile()
        {
            Log.Debug(Globals.LogTag, "GetCurrentProfile");
            return ConnectionInternalManager.Instance.GetCurrentProfile();
        }

        /// <summary>
        /// Gets the default profile, which provides the given cellular service.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="type">The cellular service type.</param>
        /// <returns>Connection profile object.</returns>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <feature>http://tizen.org/feature/network.tethering.bluetooth</feature>
        /// <feature>http://tizen.org/feature/network.ethernet</feature>
        /// <exception cref="System.NotSupportedException">Thrown when a feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        /// <exception cref="System.ArgumentException">Thrown when a value is an invalid parameter.</exception>
        /// <exception cref="System.OutOfMemoryException">Thrown when memory is not enough to continue execution.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when a connection instance is invalid or when a method fails due to an invalid operation.</exception>
        public static ConnectionProfile GetDefaultCellularProfile(CellularServiceType type)
        {
            Log.Debug(Globals.LogTag, "GetDefaultCurrentProfile");
            return ConnectionInternalManager.Instance.GetDefaultCellularProfile(type);
        }

        /// <summary>
        /// Sets the default profile, which provides the given cellular service.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="type">The cellular service type.</param>
        /// <param name="profile">The connection profile object.</param>
        /// <returns>A task indicates whether the SetDefaultCellularProfile method is done successfully or not.</returns>
        /// <remarks>
        /// This method must be called from MainThread.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <privilege>http://tizen.org/privilege/network.profile</privilege>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <feature>http://tizen.org/feature/network.tethering.bluetooth</feature>
        /// <feature>http://tizen.org/feature/network.ethernet</feature>
        /// <exception cref="System.NotSupportedException">Thrown when a feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        /// <exception cref="System.ArgumentException">Thrown when a value is an invalid parameter.</exception>
        /// <exception cref="System.ArgumentNullException">Thrown when a value is null.</exception>
        /// <exception cref="System.OutOfMemoryException">Thrown when memory is not enough to continue execution.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when a connection or a profile instance is invalid or when a method fails due to invalid operation.</exception>
        public static Task SetDefaultCellularProfile(CellularServiceType type, ConnectionProfile profile)
        {
            Log.Debug(Globals.LogTag, "SetDefaultCellularProfile");
            return ConnectionInternalManager.Instance.SetDefaultCellularProfile(type, profile);
        }
    }

    /// <summary>
    /// An extended EventArgs class, which contains the state of changed connection profile.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class ConnectionProfileStateEventArgs : EventArgs
    {
        private  ConnectionProfileState State;

        internal ConnectionProfileStateEventArgs(ConnectionProfileState state)
        {
            State = state;
        }

        /// <summary>
        /// The connection profile state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>State of the connection profile.</value>
        public ConnectionProfileState ConnectionProfileState
        {
            get
            {
                return State;
            }
        }
    }
}
