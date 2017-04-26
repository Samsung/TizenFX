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
using Tizen;
using System.Threading;
using System.Threading.Tasks;

namespace Tizen.Convergence
{
    /// <summary>
    /// DeviceFinder provides API to find all nearby Tizen D2D convergence compliant devices
    /// </summary>
    public class DeviceFinder : IDisposable
    {
        internal Interop.ConvManagerHandle _convManagerHandle;

        /// <summary>
        /// The constructor
        /// </summary>
        /// <feature>http://tizen.org/feature/convergence.d2d</feature>
        /// <exception cref="NotSupportedException">Thrown if the required feature is not supported.</exception>
        public DeviceFinder()
        {
            int ret = Interop.ConvManager.ConvCreate(out _convManagerHandle);
            if (ret != (int)ConvErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Failed to create conv manager handle");
                throw ErrorFactory.GetException(ret);
            }

        }

        /// <summary>
        /// DeviceFound event is triggered when a device is found during discovery procedure
        /// </summary>
        public event EventHandler<DeviceFoundEventArgs> DeviceFound;

        /// <summary>
        /// Starts the discovery of nearby devices
        /// </summary>
        /// <param name="timeOut">Seconds for discovery timeout. 0 will use default timeout value</param>
        /// <param name="cancellationToken">Cancellation token required to cancel the current discovery</param>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <privilege>http://tizen.org/privilege/bluetooth</privilege>
        /// <feature>http://tizen.org/feature/convergence.d2d</feature>
        /// <exception cref="NotSupportedException">Thrown if the required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the request is not supported as per Tizen D2D convergence specification </exception>
        /// <seealso cref="DeviceFound"> Devices found are delivered through this event</seealso>
        /// <returns>Task with discovery result</returns>
        public async Task StartFindingAsync(int timeOut, CancellationToken cancellationToken = default(CancellationToken))
        {
            var task = new TaskCompletionSource<bool>();
            Interop.ConvManager.ConvDiscoveryCallback discoveredCb = (IntPtr deviceHandle, Interop.ConvDiscoveryResult result, IntPtr userData) =>
            {
                Log.Debug(ErrorFactory.LogTag, "discovery callback called with result:[" + result + "]");
                switch (result)
                {
                    case Interop.ConvDiscoveryResult.Success:
                        {
                            Device device = new Device(deviceHandle);
                            DeviceFoundEventArgs deviceFoundEventArgs = new DeviceFoundEventArgs()
                            {
                                Device = device
                            };
                            DeviceFound?.Invoke(this, deviceFoundEventArgs);
                            break;
                        }
                    case Interop.ConvDiscoveryResult.Error:
                        {
                            task.TrySetException(new InvalidOperationException("Discovery error occured"));
                            break;
                        }
                    case Interop.ConvDiscoveryResult.Lost:
                        {
                            task.TrySetException(new InvalidOperationException("Discovery Lost"));
                            break;
                        }
                    case Interop.ConvDiscoveryResult.Finished:
                        {
                            Log.Debug(ErrorFactory.LogTag, "discovery process finished");
                            task.TrySetResult(true);
                            break;
                        }
                }
            };
            int ret = Interop.ConvManager.ConvDiscoveryStart(_convManagerHandle, timeOut, discoveredCb, IntPtr.Zero);
            if (ret != (int)ConvErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Failed to start finding devices");
                throw ErrorFactory.GetException(ret);
            }

            if (cancellationToken != CancellationToken.None)
            {
                cancellationToken.Register(() =>
                {
                    int error = Interop.ConvManager.ConvDiscoveryStop(_convManagerHandle);
                    if (error != (int)ConvErrorCode.None)
                    {
                        Log.Error(ErrorFactory.LogTag, "Failed to stop finding devices" + Internals.Errors.ErrorFacts.GetErrorMessage(error));
                        throw ErrorFactory.GetException(error);
                    }
                    task.TrySetCanceled();
                });
            }
            await task.Task;
        }

        /// <summary>
        /// The dispose method
        /// </summary>
        public void Dispose()
        {
            _convManagerHandle.Dispose();
        }
    }
}
