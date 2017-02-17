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
                return WiFiManagerImpl.Instance.MacAddress;
            }
        }

        /// <summary>
        /// The name of the network interface.
        /// </summary>
        static public string InterfaceName
        {
            get
            {
                return WiFiManagerImpl.Instance.InterfaceName;
            }
        }

        /// <summary>
        /// The network connection state.
        /// </summary>
        static public WiFiConnectionState ConnectionState
        {
            get
            {
                return WiFiManagerImpl.Instance.ConnectionState;
            }
        }

        /// <summary>
        /// A property to Check whether Wi-Fi is activated.
        /// </summary>
        static public bool IsActive
        {
            get
            {
                return WiFiManagerImpl.Instance.IsActive;
            }
        }

        /// <summary>
        /// DeviceStateChanged is raised when the device state is changed.
        /// </summary>
        static public event EventHandler<DeviceStateChangedEventArgs> DeviceStateChanged
        {
            add
            {
                WiFiManagerImpl.Instance.DeviceStateChanged += value;
            }
            remove
            {
                WiFiManagerImpl.Instance.DeviceStateChanged -= value;
            }
        }

        /// <summary>
        /// ConnectionStateChanged is raised when the connection state is changed.
        /// </summary>
        static public event EventHandler<ConnectionStateChangedEventArgs> ConnectionStateChanged
        {
            add
            {
                WiFiManagerImpl.Instance.ConnectionStateChanged += value;
            }
            remove
            {
                WiFiManagerImpl.Instance.ConnectionStateChanged -= value;
            }
        }

        /// <summary>
        /// RssiLevelChanged is raised when the RSSI of connected Wi-Fi is changed.
        /// </summary>
        static public event EventHandler<RssiLevelChangedEventArgs> RssiLevelChanged
        {
            add
            {
                WiFiManagerImpl.Instance.RssiLevelChanged += value;
            }
            remove
            {
                WiFiManagerImpl.Instance.RssiLevelChanged -= value;
            }
        }

        /// <summary>
        /// BackgroundScanFinished is raised when the background scan is finished.
        /// The background scan starts automatically when wifi is activated. The callback will be invoked periodically.
        /// </summary>
        static public event EventHandler BackgroundScanFinished
        {
            add
            {
                WiFiManagerImpl.Instance.BackgroundScanFinished += value;
            }
            remove
            {
                WiFiManagerImpl.Instance.BackgroundScanFinished -= value;
            }
        }

        /// <summary>
        /// Gets the result of the scan.
        /// </summary>
        /// <returns> A list of WiFiAP objects.</returns>
        static public IEnumerable<WiFiAP> GetFoundAPs()
        {
            return WiFiManagerImpl.Instance.GetFoundAPs();
        }

        /// <summary>
        /// Gets the result of specific AP scan.
        /// </summary>
        /// <returns> A list contains the WiFiAP objects.</returns>
        static public IEnumerable<WiFiAP> GetFoundSpecificAPs()
        {
            return WiFiManagerImpl.Instance.GetFoundSpecificAPs();
        }

        /// <summary>
        /// Gets the list of wifi configurations.
        /// </summary>
        /// <returns>A list contains the WiFiConfiguration objects.</returns>
        static public IEnumerable<WiFiConfiguration> GetWiFiConfigurations()
        {
            return WiFiManagerImpl.Instance.GetWiFiConfigurations();
        }

        /// <summary>
        /// Saves Wi-Fi configuration of access point.
        /// </summary>
        /// <param name="configuration">The configuration to be stored</param>
        static public void SaveWiFiConfiguration(WiFiConfiguration configuration)
        {
            WiFiManagerImpl.Instance.SaveWiFiNetworkConfiguration(configuration);
        }

        /// <summary>
        /// Gets the object of the connected WiFiAP.
        /// </summary>
        /// <returns> The connected wifi access point(AP) information.</returns>
        static public WiFiAP GetConnectedAP()
        {
            return WiFiManagerImpl.Instance.GetConnectedAP();
        }

        /// <summary>
        /// Activates Wi-Fi asynchronously.
        /// </summary>
        /// <returns> A task indicating whether the Activate method is done or not.</returns>
        static public Task ActivateAsync()
        {
            return WiFiManagerImpl.Instance.ActivateAsync();
        }

        /// <summary>
        /// Activates Wi-Fi asynchronously and displays Wi-Fi picker (popup) when Wi-Fi is not automatically connected.
        /// </summary>
        /// <returns> A task indicating whether the ActivateWithPicker method is done or not.</returns>
        static public Task ActivateWithPickerAsync()
        {
            return WiFiManagerImpl.Instance.ActivateWithWiFiPickerTestedAsync();
        }

        /// <summary>
        /// Deactivates Wi-Fi asynchronously.
        /// </summary>
        /// <returns> A task indicating whether the Deactivate method is done or not.</returns>
        static public Task DeactivateAsync()
        {
            return WiFiManagerImpl.Instance.DeactivateAsync();
        }

        /// <summary>
        /// Starts scan asynchronously.
        /// </summary>
        /// <returns> A task indicating whether the Scan method is done or not.</returns>
        static public Task ScanAsync()
        {
            return WiFiManagerImpl.Instance.ScanAsync();
        }

        /// <summary>
        /// Starts specific access point scan, asynchronously.
        /// </summary>
        /// <returns> A task indicating whether the ScanSpecificAP method is done or not.</returns>
        /// <param name="essid">The essid of hidden ap</param>
        static public Task ScanSpecificAPAsync(string essid)
        {
            return WiFiManagerImpl.Instance.ScanSpecificAPAsync(essid);
        }
    }
}
