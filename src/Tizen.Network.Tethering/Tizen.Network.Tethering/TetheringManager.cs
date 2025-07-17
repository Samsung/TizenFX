/*
 * Copyright (c) 2025 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Tizen.Network.Tethering
{

    /// <summary>
    /// A class for managing the Tethering handle.
    /// </summary>
    /// <since_tizen> 13 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class SafeTetheringManagerHandle : SafeHandle
    {
        private int _tid;

        internal SafeTetheringManagerHandle() : base(IntPtr.Zero, true)
        {
        }

        /// <summary>
        /// Checks the validity of the handle.
        /// </summary>
        /// <value>Represents the validity of the handle.</value>
        /// <since_tizen> 13 </since_tizen>
        public override bool IsInvalid
        {
            get
            {
                return this.handle == IntPtr.Zero;
            }
        }

        /// <summary>
        /// Release the handle
        /// </summary>
        protected override bool ReleaseHandle()
        {
            return false;
        }

        internal void SetTID(int id)
        {
            _tid = id;
            Log.Info(Globals.LogTag, "New Handle for Thread " + _tid);
        }
    }

    /// <summary>
    /// A manager class that enables applications to create and manage a Wi-Fi hotspot, allowing devices to share an internet connection over a Wireless Local Area Network (WLAN).
    /// The Tethering Manager provides functionality to activate and deactivate a Wi-Fi hotspot, configure hotspot settings, and manage connected devices.
    /// </summary>
    /// <since_tizen> 13 </since_tizen>
    static public class TetheringManager
    {
        /// <summary>
        /// TetheringEnabled is raised when the tethering is successfully enabled.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public event EventHandler<TetheringEnabledEventArgs> TetheringEnabled
        {
            add
            {
            }
            remove
            {
            }
        }

        /// <summary>
        /// TetheringDisabled is raised when the tethering is successfully disabled.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public event EventHandler<TetheringDisabledEventArgs> TetheringDisabled
        {
            add
            {
            }
            remove
            {
            }
        }

        /// <summary>
        /// ConnectionStateChanged is raised when the connection state is changed.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public event EventHandler<ConnectionStateChangedEventArgs> ConnectionStateChanged
        {
            add
            {
            }
            remove
            {
            }
        }

        /// <summary>
        /// Gets the tethering safe handle.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        /// <returns>The instance of the SafeTetheringManagerHandle.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SafeTetheringManagerHandle GetTetheringHandle()
        {
            return null;
        }

        /// <summary>
        /// Activates the Tethering.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public void ActivateTethering()
        {

        }

        /// <summary>
        /// Deactivates the Tethering.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public void DeactivateTethering()
        {

        }

        /// <summary>
        /// Returns whethers Tethering is enabled or not.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public bool IsEnabled
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Retrieves and Set the Service Set Identifier (SSID) of the Wi-Fi hotspot managed by the Tethering Manager.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public string SSID
        {
            get
            {
                return "";
            }

            set
            {
            }
        }

        /// <summary>
        /// Retrieves and Set the Passphrase of the Wi-Fi hotspot managed by the Tethering Manager.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public string Passphrase
        {
            get
            {
                return "";
            }

            set
            {
            }
        }

        /// <summary>
        /// Retrieves and Set the Channel of the Wi-Fi hotspot managed by the Tethering Manager.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public int Channel
        {
            get
            {
                return -1;
            }

            set
            {
            }
        }

        /// <summary>
        /// Returns the Tethering Info of the Wi-Fi hotspot managed by the Tethering Manager.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public TetheringInfo TetheringInfo()
        {
            return null;
        }

        /// <summary>
        /// Returns the Security type of the Wi-Fi hotspot managed by the Tethering Manager.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public int Security
        {
            get
            {
                return -1;
            }
        }

        /// <summary>
        /// Returns the Visibility of the Wi-Fi hotspot managed by the Tethering Manager.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public int Visibility
        {
            get
            {
                return -1;
            }
        }

        /// <summary>
        /// Returns whehter Wi-Fi hotspot managed by the Tethering Manager is sharing or not.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public bool Sharing
        {
            get
            {
                return false;
            }
        }
    } 
}
