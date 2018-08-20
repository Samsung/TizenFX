using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.Tapi
{
    /// <summary>
    /// This class provides functions for modem services.
    /// </summary>
    public class Modem
    {
        private IntPtr _handle;
        private Dictionary<IntPtr, Interop.Tapi.TapiResponseCallback> _response_map = new Dictionary<IntPtr, Interop.Tapi.TapiResponseCallback>();
        private int _requestId = 0;

        /// <summary>
        /// A public constructor for Modem class to create a Modem instance for the given tapi handle.
        /// </summary>
        /// <param name="handle">The tapi handle.</param>
        public Modem(TapiHandle handle)
        {
            if (handle == null)
            {
                throw new ArgumentNullException("TapiHandle parameter is null");
            }

            _handle = handle._handle;
        }

        /// <summary>
        /// Turn the modem on/off asynchronously.
        /// </summary>
        /// <param name="cmd">Power command value.</param>
        /// <returns>A task indicating whether the ProcessPowerCommand method is done or not.</returns>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when modem instance is invalid or when method failed due to invalid operation.</exception>
        public Task ProcessPowerCommand(PhonePowerCommand cmd)
        {
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id;
            id = (IntPtr)_requestId++;
            _response_map[id] = (IntPtr handle, int result, IntPtr data, IntPtr key) =>
            {
                Task resultTask = new Task(() =>
                {
                    if (result != (int)TapiError.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during turning modem on/off, " + (TapiError)result);
                        task.SetException(new InvalidOperationException("Error occurs during turning modem on/off, " + (TapiError)result));
                        return;
                    }

                    task.SetResult(true);
                });

                resultTask.Start();
                resultTask.Wait();
                _response_map.Remove(key);
            };

            int ret = Interop.Tapi.Modem.ProcessPowerCommand(_handle, cmd, _response_map[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to turn the modem on/off, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Switch the flight mode on/off asynchronously.
        /// </summary>
        /// <param name="mode">Flight mode request value.</param>
        /// <returns>A task indicating whether the SetFlightMode method is done or not.</returns>
        /// <privilege>http://tizen.org/privilege/telephony.admin</privilege>
        /// <privlevel>platform</privlevel>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when modem instance is invalid or when method failed due to invalid operation.</exception>
        public Task SetFlightMode(PowerFlightModeRequest mode)
        {
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id;
            id = (IntPtr)_requestId++;
            _response_map[id] = (IntPtr handle, int result, IntPtr data, IntPtr key) =>
            {
                Task resultTask = new Task(() =>
                {
                    if ((mode == PowerFlightModeRequest.Leave && result != (int)PowerFlightModeResponse.Off) ||
                        (mode == PowerFlightModeRequest.Enter && result != (int)PowerFlightModeResponse.On))
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during switching flight mode on/off, " + (PowerFlightModeResponse)result);
                        task.SetException(new InvalidOperationException("Error occurs during switching flight mode on/off, " + (PowerFlightModeResponse)result));
                        return;
                    }

                    task.SetResult(true);
                });

                resultTask.Start();
                resultTask.Wait();
                _response_map.Remove(key);
            };

            int ret = Interop.Tapi.Modem.SetFlightMode(_handle, mode, _response_map[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to switch the flight mode on/off, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony.admin");
            }

            return task.Task;
        }

        /// <summary>
        /// Get the flight mode asynchronously.
        /// </summary>
        /// <returns>If flight mode is On, it returns true else it returns false.</returns>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when modem instance is invalid or when method failed due to invalid operation.</exception>
        public Task<bool> GetFlightMode()
        {
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id;
            id = (IntPtr)_requestId++;
            _response_map[id] = (IntPtr handle, int result, IntPtr data, IntPtr key) =>
            {
                Task resultTask = new Task(() =>
                {
                    if (result != (int)TapiError.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during getting the flight mode, " + (TapiError)result);
                        task.SetException(new InvalidOperationException("Error occurs during getting the flight mode, " + (TapiError)result));
                        return;
                    }

                    int mode = Marshal.ReadInt32(data);
                    if (mode == 1)
                    {
                        task.SetResult(true);
                    }

                    else
                    {
                        task.SetResult(false);
                    }
                });

                resultTask.Start();
                resultTask.Wait();
                _response_map.Remove(key);
            };

            int ret = Interop.Tapi.Modem.GetFlightMode(_handle, _response_map[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get the flight mode, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return task.Task;
        }

        /// <summary>
        /// Get Me version information asynchronously.
        /// </summary>
        /// <returns>Instance of MiscVersionInformation.</returns>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when modem instance is invalid or when method failed due to invalid operation.</exception>
        public Task<MiscVersionInformation> GetMiscMeVersion()
        {
            TaskCompletionSource<MiscVersionInformation> task = new TaskCompletionSource<MiscVersionInformation>();
            IntPtr id;
            id = (IntPtr)_requestId++;
            _response_map[id] = (IntPtr handle, int result, IntPtr data, IntPtr key) =>
            {
                Task resultTask = new Task(() =>
                {
                    if (result != (int)TapiError.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during getting the Me version, " + (TapiError)result);
                        task.SetException(new InvalidOperationException("Error occurs during getting the Me version, " + (TapiError)result));
                        return;
                    }

                    MiscVersionInfoStruct infoStruct = Marshal.PtrToStructure<MiscVersionInfoStruct>(data);
                    MiscVersionInformation versionInfoClass = ModemStructConversions.ConvertVersionStruct(infoStruct);
                    task.SetResult(versionInfoClass);
                });

                resultTask.Start();
                resultTask.Wait();
                _response_map.Remove(key);
            };

            int ret = Interop.Tapi.Modem.GetMiscMeVersion(_handle, _response_map[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get the Me version information, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return task.Task;
        }

        /// <summary>
        /// Misc me version information.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <remarks>Returns null in case of failure.</remarks>
        public MiscVersionInformation MiscMeVersionSync
        {
            get
            {
                IntPtr info = Interop.Tapi.Modem.GetMiscMeVersionSync(_handle);
                MiscVersionInfoStruct infoStruct = Marshal.PtrToStructure<MiscVersionInfoStruct>(info);
                if (infoStruct.Equals(null))
                {
                    return null;
                }

                MiscVersionInformation versionInfoClass = ModemStructConversions.ConvertVersionStruct(infoStruct);
                return versionInfoClass;
            }
        }

        /// <summary>
        /// Get the Me Esn/Meid for each phone type asynchronously.
        /// </summary>
        /// <returns>Instance of MiscSerialNumberInformation.</returns>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when modem instance is invalid or when method failed due to invalid operation.</exception>
        public Task<MiscSerialNumberInformation> GetMiscMeSn()
        {
            TaskCompletionSource<MiscSerialNumberInformation> task = new TaskCompletionSource<MiscSerialNumberInformation>();
            IntPtr id;
            id = (IntPtr)_requestId++;
            _response_map[id] = (IntPtr handle, int result, IntPtr data, IntPtr key) =>
            {
                Task resultTask = new Task(() =>
                {
                    if (result != (int)TapiError.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during getting the Me Esn/Meid, " + (TapiError)result);
                        task.SetException(new InvalidOperationException("Error occurs during getting the Me Esn/Meid, " + (TapiError)result));
                        return;
                    }

                    MiscSerialNumInfoStruct infoStruct = Marshal.PtrToStructure<MiscSerialNumInfoStruct>(data);
                    MiscSerialNumberInformation serialNumberClass = ModemStructConversions.ConvertSerialNumberStruct(infoStruct);
                    task.SetResult(serialNumberClass);
                });

                resultTask.Start();
                resultTask.Wait();
                _response_map.Remove(key);
            };

            int ret = Interop.Tapi.Modem.GetMiscMeSn(_handle, _response_map[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get the Me Esn/Meid information for each phone type, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return task.Task;
        }

        /// <summary>
        /// Misc me serial number information.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <remarks>Returns null in case of failure.</remarks>
        public MiscSerialNumberInformation MiscMeSnSync
        {
            get
            {
                IntPtr info = Interop.Tapi.Modem.GetMiscMeSnSync(_handle);
                MiscSerialNumInfoStruct infoStruct = Marshal.PtrToStructure<MiscSerialNumInfoStruct>(info);
                if (infoStruct.Equals(null))
                {
                    return null;
                }

                MiscSerialNumberInformation versionInfoClass = ModemStructConversions.ConvertSerialNumberStruct(infoStruct);
                return versionInfoClass;
            }
        }

        /// <summary>
        /// Get the Misc Me Imei asynchronously.
        /// </summary>
        /// <returns>The imei string.</returns>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when modem instance is invalid or when method failed due to invalid operation.</exception>
        public Task<string> GetMiscMeImei()
        {
            TaskCompletionSource<string> task = new TaskCompletionSource<string>();
            IntPtr id;
            id = (IntPtr)_requestId++;
            _response_map[id] = (IntPtr handle, int result, IntPtr data, IntPtr key) =>
            {
                Task resultTask = new Task(() =>
                {
                    if (result != (int)TapiError.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during getting the Misc Me Imei, " + (TapiError)result);
                        task.SetException(new InvalidOperationException("Error occurs during getting the Misc Me Imei, " + (TapiError)result));
                        return;
                    }

                    task.SetResult(Marshal.PtrToStringAnsi(data));
                });

                resultTask.Start();
                resultTask.Wait();
                _response_map.Remove(key);
            };

            int ret = Interop.Tapi.Modem.GetMiscMeImei(_handle, _response_map[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get the Misc Me Imei information, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return task.Task;
        }

        /// <summary>
        /// Misc me Imei information.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <remarks>Returns null in case of failure.</remarks>
        public string MiscMeImeiSync
        {
            get
            {
                string imei = Interop.Tapi.Modem.GetMiscMeImeiSync(_handle);
                if (imei == null)
                {
                    return null;
                }

                return imei;
            }
        }

        /// <summary>
        /// Check the modem power status.
        /// </summary>
        /// <returns>Phone power status value.</returns>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when modem instance is invalid or when method failed due to invalid operation.</exception>
        public PhonePowerStatus CheckPowerStatus()
        {
            int result;
            int ret = Interop.Tapi.Modem.CheckPowerStatus(_handle, out result);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to check the modem power status, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return (PhonePowerStatus)result;
        }

        /// <summary>
        /// Get device vendor name and device name of cellular dongle.
        /// </summary>
        /// <returns>Instance of MiscDeviceInfo.</returns>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <remarks>
        /// Result can be delivered with only cellular dongle insertion.
        /// </remarks>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when privilege access is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when modem instance is invalid or when method failed due to invalid operation.</exception>
        public Task<MiscDeviceInfo> GetDeviceInfo()
        {
            TaskCompletionSource<MiscDeviceInfo> task = new TaskCompletionSource<MiscDeviceInfo>();
            IntPtr id;
            id = (IntPtr)_requestId++;
            _response_map[id] = (IntPtr handle, int result, IntPtr data, IntPtr key) =>
            {
                Task resultTask = new Task(() =>
                {
                    if (result != (int)TapiError.Success)
                    {
                        Log.Error(TapiUtility.LogTag, "Error occurs during getting the device name and vendor name, " + (TapiError)result);
                        task.SetException(new InvalidOperationException("Error occurs during getting the device name and vendor name, " + (TapiError)result));
                        return;
                    }

                    MiscDeviceInfoStruct infoStruct = Marshal.PtrToStructure<MiscDeviceInfoStruct>(data);
                    MiscDeviceInfo deviceInfo = ModemStructConversions.ConvertMiscInfoStruct(infoStruct);
                    task.SetResult(deviceInfo);
                });

                resultTask.Start();
                resultTask.Wait();
                _response_map.Remove(key);
            };

            int ret = Interop.Tapi.Modem.GetDeviceInfo(_handle, _response_map[id], id);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to get the device vendor name and device name, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, _handle, "http://tizen.org/privilege/telephony");
            }

            return task.Task;
        }
    }
}
