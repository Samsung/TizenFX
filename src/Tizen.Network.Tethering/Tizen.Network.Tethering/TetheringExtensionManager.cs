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
using System.ComponentModel;

namespace Tizen.Network.Tethering
{

    /// <summary>
    /// A manager class that enables applications to create and manage a Wi-Fi hotspot, allowing devices to share an internet connection over a Wireless Local Area Network (WLAN).
    /// </summary>
    /// <remarks>
    /// The TetheringExtension Manager provides functionality to activate and deactivate a Wi-Fi hotspot, configure hotspot settings, and manage connected devices.
    /// </remarks>
    /// <since_tizen> 13 </since_tizen>
    static public class TetheringExtensionManager
    {
        /// <summary>
        /// Enabled is raised when the tethering is successfully enabled.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public event EventHandler<TetheringExtensionEnabledEventArgs> Enabled
        {
            add
            {
                TetheringExtensionManagerImpl.Instance.TetheringExtensionEnabled += value;
            }
            remove
            {
                TetheringExtensionManagerImpl.Instance.TetheringExtensionEnabled -= value;
            }
        }

        /// <summary>
        /// Disabled is raised when the tethering is successfully disabled.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public event EventHandler<TetheringExtensionDisabledEventArgs> Disabled
        {
            add
            {
                TetheringExtensionManagerImpl.Instance.TetheringExtensionDisabled += value;
            }
            remove
            {
                TetheringExtensionManagerImpl.Instance.TetheringExtensionDisabled -= value;
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
                TetheringExtensionManagerImpl.Instance.ConnectionStateChanged += value;
            }
            remove
            {
                TetheringExtensionManagerImpl.Instance.ConnectionStateChanged -= value;
            }
        }

        /// <summary>
        /// Activates the TetheringExtension.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public void Activate()
        {
            TetheringExtensionManagerImpl.Instance.Activate();
        }

        /// <summary>
        /// Deactivates the TetheringExtension.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public void Deactivate()
        {
            TetheringExtensionManagerImpl.Instance.DeActivate();
        }

        /// <summary>
        /// Returns whethers TetheringExtension is enabled or not.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public bool IsEnabled
        {
            get
            {
                return TetheringExtensionManagerImpl.Instance.Enabled;
            }
        }

        /// <summary>
        /// Sets the Service Set Identifier (SSID) of the Wi-Fi hotspot managed by the TetheringExtension Manager.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public void SetSsid(string ssid)
        {
            TetheringExtensionManagerImpl.Instance.Ssid(ssid);
        }

        /// <summary>
        /// Sets the Passphrase of the Wi-Fi hotspot managed by the TetheringExtension Manager.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public void SetPassphrase(string passhprase)
        {
            TetheringExtensionManagerImpl.Instance.Passphrase(passhprase);
        }

        /// <summary>
        /// Retrieves and Set the Channel of the Wi-Fi hotspot managed by the TetheringExtension Manager.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public int Channel
        {
            get
            {
                return TetheringExtensionManagerImpl.Instance.Channel;
            }
            set
            {
                TetheringExtensionManagerImpl.Instance.Channel = value;
            }
        }

        /// <summary>
        /// Returns the TetheringExtension Info of the Wi-Fi hotspot managed by the TetheringExtension Manager.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public TetheringInfo GetTetheringInfo()
        {
            return TetheringExtensionManagerImpl.Instance.GetTetheringInfo();
        }

        /// <summary>
        /// Returns the Security type of the Wi-Fi hotspot managed by the TetheringExtension Manager.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public TetheringSecurityType Security
        {
            get
            {
                return TetheringExtensionManagerImpl.Instance.Security;
            }
        }

        /// <summary>
        /// Returns the Visibility of the Wi-Fi hotspot managed by the TetheringExtension Manager.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public int Visibility
        {
            get
            {
                return TetheringExtensionManagerImpl.Instance.Visibility;
            }
        }

        /// <summary>
        /// Returns whehter Wi-Fi hotspot managed by the TetheringExtension Manager is sharing or not.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public bool Sharing
        {
            get
            {
                return TetheringExtensionManagerImpl.Instance.Sharing;
            }
        }
    } 
}
