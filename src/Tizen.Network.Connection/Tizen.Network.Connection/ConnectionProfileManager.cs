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
    /// This class is ConnectionProfileManager
    /// </summary>
    public class ConnectionProfileManager
    {
        /// <summary>
        /// Adds a new profile
        /// </summary>
        /// <privilege>http://tizen.org/privilege/network.profile</privilege>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        static public int AddProfile(RequestProfile profile)
        {
            return ConnectionInternalManager.AddProfile(profile);
        }

        /// <summary>
        /// Gets the list of profile with profile list type
        /// </summary>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        static public Task<IEnumerable<ConnectionProfile>> GetProfileListAsync(ProfileListType type)
        {
            return ConnectionInternalManager.GetProfileListAsync(type);
        }

        /// <summary>
        /// Opens a connection of profile, asynchronously.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <privilege>http://tizen.org/privilege/network.set</privilege>
        static public Task<ConnectionError> ConnectProfileAsync(ConnectionProfile profile)
        {
            return ConnectionInternalManager.OpenProfileAsync(profile);
        }

        /// <summary>
        /// Closes a connection of profile.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/network.set</privilege>
        static public Task<ConnectionError> DisconnectProfileAsync(ConnectionProfile profile)
        {
            return ConnectionInternalManager.CloseProfileAsync(profile);
        }

        /// <summary>
        /// Removes an existing profile.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <privilege>http://tizen.org/privilege/network.profile</privilege>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        static public int RemoveProfile(ConnectionProfile profile)
        {
            Log.Debug(Globals.LogTag, "RemoveProfile. Id: " + profile.Id + ", Name: " + profile.Name + ", Type: " + profile.Type);
            return ConnectionInternalManager.RemoveProfile(profile);
        }

        /// <summary>
        /// Updates an existing profile.
        /// When a profile is changed, these changes will be not applied to the ConnectionProfileManager immediately.
        /// When you call this function, your changes affect the ConnectionProfileManager and the existing profile is updated.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <privilege>http://tizen.org/privilege/network.profile</privilege>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        static public int UpdateProfile(ConnectionProfile profile)
        {
            return ConnectionInternalManager.UpdateProfile(profile);
        }

        /// <summary>
        /// Gets the name of the default profile.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        static public ConnectionProfile GetCurrentProfile()
        {
            return ConnectionInternalManager.GetCurrentProfile();
        }

        /// <summary>
        /// Gets the default profile which provides the given cellular service.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        static public ConnectionProfile GetDefaultCellularProfile(CellularServiceType type)
        {
            return ConnectionInternalManager.GetDefaultCellularProfile(type);
        }

        /// <summary>
        /// Sets the default profile which provides the given cellular service.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <privilege>http://tizen.org/privilege/network.profile</privilege>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        static public Task<ConnectionError> SetDefaultCellularProfile(CellularServiceType type, ConnectionProfile profile)
        {
            return ConnectionInternalManager.SetDefaultCellularProfile(type, profile);
        }
    }
    
    /// <summary>
    /// An extended EventArgs class which contains the state of changed connection profile.
    /// </summary>
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
        public ConnectionProfileState ConnectionProfileState
        {
            get
            {
                return State;
            }
        }
    }
}
