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
    /// A class for managing the TetheringExt handle.
    /// </summary>
    /// <since_tizen> 13 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class SafeTetheringExtManagerHandle : SafeHandle
    {
        private int _tid;

        internal SafeTetheringExtManagerHandle() : base(IntPtr.Zero, true)
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
            Interop.TetheringExt.Deinitialize(this.handle);
            this.SetHandle(IntPtr.Zero);
            return true;
        }

        // TODO: need not to implement thread safe, can remove this
        internal void SetTID(int id)
        {
            _tid = id;
            Log.Info(Globals.LogTag, "New Handle for Thread " + _tid);
        }
    }

    /// <summary>
    /// A manager class that enables applications to create and manage a Wi-Fi hotspot, allowing devices to share an internet connection over a Wireless Local Area Network (WLAN).
    /// The TetheringExt Manager provides functionality to activate and deactivate a Wi-Fi hotspot, configure hotspot settings, and manage connected devices.
    /// </summary>
    /// <since_tizen> 13 </since_tizen>
    static public class TetheringExtManager
    {
        /// <summary>
        /// TetheringExtEnabled is raised when the tethering is successfully enabled.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public event EventHandler<TetheringExtEnabledEventArgs> TetheringExtEnabled
        {
            add
            {
                TetheringExtManagerImpl.Instance.TetheringExtEnabled += value;
            }
            remove
            {
                TetheringExtManagerImpl.Instance.TetheringExtEnabled -= value;
            }
        }

        /// <summary>
        /// TetheringExtDisabled is raised when the tethering is successfully disabled.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public event EventHandler<TetheringExtDisabledEventArgs> TetheringExtDisabled
        {
            add
            {
                TetheringExtManagerImpl.Instance.TetheringExtDisabled += value;
            }
            remove
            {
                TetheringExtManagerImpl.Instance.TetheringExtDisabled -= value;
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
                TetheringExtManagerImpl.Instance.ConnectionStateChanged += value;
            }
            remove
            {
                TetheringExtManagerImpl.Instance.ConnectionStateChanged -= value;
            }
        }

        /// <summary>
        /// Gets the tethering safe handle.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        /// <returns>The instance of the SafeTetheringExtManagerHandle.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SafeTetheringExtManagerHandle GetTetheringExtHandle()
        {
            return TetheringExtManagerImpl.Instance.GetSafeHandle();
        }

        /// <summary>
        /// Activates the TetheringExt.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public void Activate()
        {
            TetheringExtManagerImpl.Instance.Activate();
        }

        /// <summary>
        /// Deactivates the TetheringExt.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public void Deactivate()
        {
            TetheringExtManagerImpl.Instance.DeActivate();
        }

        /// <summary>
        /// Returns whethers TetheringExt is enabled or not.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public bool IsEnabled
        {
            get
            {
                return TetheringExtManagerImpl.Instance.Enabled;
            }
        }

        /// <summary>
        /// Retrieves and Set the Service Set Identifier (SSID) of the Wi-Fi hotspot managed by the TetheringExt Manager.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public void SetSSID(string ssid)
        {
            TetheringExtManagerImpl.Instance.SetSSID(ssid);
        }

        /// <summary>
        /// Retrieves and Set the Passphrase of the Wi-Fi hotspot managed by the TetheringExt Manager.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public void SetPassphrase(string passphrase)
        {
            TetheringExtManagerImpl.Instance.SetPassphrase(passphrase);
        }

        /// <summary>
        /// Retrieves and Set the Channel of the Wi-Fi hotspot managed by the TetheringExt Manager.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public int Channel
        {
            get
            {
                return TetheringExtManagerImpl.Instance.Channel;
            }
            set
            {
                TetheringExtManagerImpl.Instance.Channel = value;
            }
        }

        /// <summary>
        /// Returns the TetheringExt Info of the Wi-Fi hotspot managed by the TetheringExt Manager.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public TetheringInfo GetTetheringInfo()
        {
            return TetheringExtManagerImpl.Instance.GetTetheringInfo();
        }

        /// <summary>
        /// Returns the Security type of the Wi-Fi hotspot managed by the TetheringExt Manager.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public int Security
        {
            get
            {
                return TetheringExtManagerImpl.Instance.Security;
            }
        }

        /// <summary>
        /// Returns the Visibility of the Wi-Fi hotspot managed by the TetheringExt Manager.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public int Visibility
        {
            get
            {
                return TetheringExtManagerImpl.Instance.Visibility;
            }
        }

        /// <summary>
        /// Returns whehter Wi-Fi hotspot managed by the TetheringExt Manager is sharing or not.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public bool Sharing
        {
            get
            {
                return TetheringExtManagerImpl.Instance.Sharing;
            }
        }
    } 
}
