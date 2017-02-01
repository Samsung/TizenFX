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
using System.Threading.Tasks;

namespace Tizen.Network.WiFi
{
    /// <summary>
    /// A manager class which allows applications to connect to a Wireless Local Area Network (WLAN) and to transfer data over the network.<br>
    /// The Wi-Fi Manager enables your application to activate and deactivate a local Wi-Fi device, and to connect to a WLAN network in the infrastructure mode.
    /// </summary>
    static public class WiFiManager
    {
        /// <summary>
        /// The local MAC address.
        /// </summary>
        static public string MacAddress
        {
            get
            {
                if (Globals.IsInitialize)
                {
                    return WiFiManagerImpl.Instance.MacAddress;
                }
                return null;
            }
        }
        /// <summary>
        /// The name of the network interface.
        /// </summary>
        static public string InterfaceName
        {
            get
            {
                if (Globals.IsInitialize)
                {
                    return WiFiManagerImpl.Instance.InterfaceName;
                }
                return null;
            }
        }
        /// <summary>
        /// The networtk connection state.
        /// </summary>
        static public WiFiConnectionState ConnectionState
        {
            get
            {
                if (Globals.IsInitialize)
                {
                    return WiFiManagerImpl.Instance.ConnectionState;
                }
                return default(WiFiConnectionState);
            }
        }
        /// <summary>
        /// A property to Check whether Wi-Fi is activated.
        /// </summary>
        static public bool IsActivated
        {
            get
            {
                if (Globals.IsInitialize)
                {
                    return WiFiManagerImpl.Instance.IsActivated;
                }
                return false;
            }
        }

        /// <summary>
        /// (event) DeviceStateChanged is raised when the device state is changed.
        /// </summary>
        static public event EventHandler<DeviceStateChangedEventArgs> DeviceStateChanged
        {
            add
            {
                if (Globals.IsInitialize)
                {
                    WiFiManagerImpl.Instance.DeviceStateChanged += value;
                }
            }
            remove
            {
                if (Globals.IsInitialize)
                {
                    WiFiManagerImpl.Instance.DeviceStateChanged -= value;
                }
            }
        }
        /// <summary>
        /// (event) ConnectionStateChanged is rasied when the connection state is changed.
        /// </summary>
        static public event EventHandler<ConnectionStateChangedEventArgs> ConnectionStateChanged
        {
            add
            {
                if (Globals.IsInitialize)
                {
                    WiFiManagerImpl.Instance.ConnectionStateChanged += value;
                }
            }
            remove
            {
                if (Globals.IsInitialize)
                {
                    WiFiManagerImpl.Instance.ConnectionStateChanged -= value;
                }
            }
        }
        /// <summary>
        /// (event) RssiLevelChanged is rasied when the RSSI of connected Wi-Fi is changed.
        /// </summary>
        static public event EventHandler<RssiLevelChangedEventArgs> RssiLevelChanged
        {
            add
            {
                if (Globals.IsInitialize)
                {
                    WiFiManagerImpl.Instance.RssiLevelChanged += value;
                }
            }
            remove
            {
                if (Globals.IsInitialize)
                {
                    WiFiManagerImpl.Instance.RssiLevelChanged -= value;
                }
            }
        }
        /// <summary>
        /// (event) BackgroundScanFinished is rasied when the background scan is finished.
        /// The background scan starts automatically when wifi is activated. The callback will be invoked periodically.
        /// </summary>
        static public event EventHandler BackgroundScanFinished
        {
            add
            {
                if (Globals.IsInitialize)
                {
                    WiFiManagerImpl.Instance.BackgroundScanFinished += value;
                }
            }
            remove
            {
                if (Globals.IsInitialize)
                {
                    WiFiManagerImpl.Instance.BackgroundScanFinished -= value;
                }
            }
        }
        /// <summary>
        /// Gets the result of the scan asynchronously.
        /// </summary>
        /// <returns> A task contains the lisf for WiFiApInformation objects.</returns>
        static public IEnumerable<WiFiAp> GetFoundAps()
        {
            if (Globals.IsInitialize)
            {
                return WiFiManagerImpl.Instance.GetFoundAps();
            }
            throw new InvalidOperationException("Not initialized");
        }
        /// <summary>
        /// Gets the result of specific ap scan asynchronously.
        /// </summary>
        /// <returns> A task contains the WiFiApInformation object.</returns>
        static public IEnumerable<WiFiAp> GetFoundSpecificAps()
        {
            if (Globals.IsInitialize)
            {
                return WiFiManagerImpl.Instance.GetFoundSpecificAps();
            }
            throw new InvalidOperationException("Not initialized");
        }
        /// <summary>
        /// Gets the list of wifi configuration.
        /// </summary>
        /// <returns>A task contains the lisf for WiFiConfiguration objects.</returns>
        static public IEnumerable<WiFiConfiguration> GetWiFiConfigurations()
        {
            if (Globals.IsInitialize)
            {
                return WiFiManagerImpl.Instance.GetWiFiConfigurations();
            }
            throw new InvalidOperationException("Not initialized");
        }
        /// <summary>
        /// Saves Wi-Fi configuration of access point.
        /// </summary>
        /// <param name="configuration">The configuration to be stored</param>
        static public void SaveWiFiNetworkConfiguration(WiFiConfiguration configuration)
        {
            if (Globals.IsInitialize)
            {
                WiFiManagerImpl.Instance.SaveWiFiNetworkConfiguration(configuration);
            }
            else
            {
                throw new InvalidOperationException("Not initialized");
            }
        }
        /// <summary>
        /// Gets the handle of the connected access point.
        /// </summary>
        /// <returns> The connected wifi access point(AP) information.</returns>
        static public WiFiAp GetConnectedAp()
        {
            if (Globals.IsInitialize)
            {
                return WiFiManagerImpl.Instance.GetConnectedAp();
            }
            throw new InvalidOperationException("Not initialized");
        }
        /// <summary>
        /// Deletes the information of stored access point and disconnects it when it connected.<br>
        /// If an AP is connected, then connection information will be stored. This information is used when a connection to that AP is established automatically.
        /// </summary>
        /// <param name="ap">The access point to be removed</param>
        static public void RemoveAP(WiFiAp ap)
        {
            if (Globals.IsInitialize)
            {
                WiFiManagerImpl.Instance.RemoveAp(ap);
            }
            else
            {
                throw new InvalidOperationException("Not initialized");
            }
        }
        /// <summary>
        /// Activates Wi-Fi asynchronously.
        /// </summary>
        /// <returns> A task indicates whether the Activate method is done or not.</returns>
        static public Task ActivateAsync()
        {
            if (Globals.IsInitialize)
            {
                return WiFiManagerImpl.Instance.ActivateAsync();
            }
            throw new InvalidOperationException("Not initialized");
        }
        /// <summary>
        /// Activates Wi-Fi asynchronously and displays Wi-Fi picker (popup) when Wi-Fi is not automatically connected.
        /// </summary>
        /// <returns> A task indicates whether the ActivateWithPickerTeated method is done or not.</returns>
        static public Task ActivateWithPickerTeatedAsync()
        {
            if (Globals.IsInitialize)
            {
                return WiFiManagerImpl.Instance.ActivateWithWiFiPickerTestedAsync();
            }
            throw new InvalidOperationException("Not initialized");
        }
        /// <summary>
        /// Deactivates Wi-Fi asynchronously.
        /// </summary>
        /// <returns> A task indicates whether the Deactivate method is done or not.</returns>
        static public Task DeactivateAsync()
        {
            if (Globals.IsInitialize)
            {
                return WiFiManagerImpl.Instance.DeactivateAsync();
            }
            throw new InvalidOperationException("Not initialized");
        }
        /// <summary>
        /// Starts scan asynchronously.
        /// </summary>
        /// <returns> A task indicates whether the Scan method is done or not.</returns>
        static public Task ScanAsync()
        {
            if (Globals.IsInitialize)
            {
                Log.Debug(Globals.LogTag, "ScanAsync");
                return WiFiManagerImpl.Instance.ScanAsync();
            }
            throw new InvalidOperationException("Not initialized");
        }
        /// <summary>
        /// Starts specific ap scan, asynchronously.
        /// </summary>
        /// <returns> A task contains WiFiApInformation object.</returns>
        /// <param name="essid">The essid of hidden ap</param>
        static public Task ScanSpecificApAsync(string essid)
        {
            if (Globals.IsInitialize)
            {
                return WiFiManagerImpl.Instance.ScanSpecificApAsync(essid);
            }
            throw new InvalidOperationException("Not initialized");
        }
        /// <summary>
        /// Connects the access point asynchronously.
        /// </summary>
        /// <param name="ap">The access point</param>
        /// <returns> A task indicates whether the Connect method is done or not.</returns>
        static public Task ConnectAsync(WiFiAp ap)
        {
            if (Globals.IsInitialize)
            {
                Log.Debug(Globals.LogTag, "ConnectAsync");
                return WiFiManagerImpl.Instance.ConnectAsync(ap);
            }
            throw new InvalidOperationException("Not initialized");
        }
        /// <summary>
        /// Connects the access point with WPS PBC asynchronously.
        /// </summary>
        /// <returns> A task indicates whether the ConnectByWpsPbs method is done or not.</returns>
        /// <param name="ap">The access point(AP)</param>
        static public Task ConnectByWpsPbcAsync(WiFiAp ap)
        {
            if (Globals.IsInitialize)
            {
                Log.Debug(Globals.LogTag, "ConnectByWpsPbcAsync");
                return WiFiManagerImpl.Instance.ConnectByWpsPbcAsync(ap);
            }
            throw new InvalidOperationException("Not initialized");
        }
        /// <summary>
        /// Connects the access point with WPS PIN asynchronously.
        /// </summary>
        /// <returns> A task indicates whether the ConnectByWpsPin method is done or not.</returns>
        /// <param name="ap">The access point(AP)</param>
        /// <param name="pin">The WPS PIN is a non-NULL string with length greater than 0 and less than or equal to 8.</param>
        static public Task ConnectByWpsPinAsync(WiFiAp ap, string pin)
        {
            if (Globals.IsInitialize)
            {
                Log.Debug(Globals.LogTag, "ConnectByWpsPinAsync");
                return WiFiManagerImpl.Instance.ConnectByWpsPinAsync(ap, pin);
            }
            throw new InvalidOperationException("Not initialized");
        }
        /// <summary>
        /// Disconnects the access point asynchronously.
        /// </summary>
        /// <returns> A task indicates whether the Disconnect method is done or not.</returns>
        static public Task DisconnectAsync(WiFiAp ap)
        {
            if (Globals.IsInitialize)
            {
                return WiFiManagerImpl.Instance.DisconnectAsync(ap);
            }
            throw new InvalidOperationException("Not initialized");
        }
    }
}
