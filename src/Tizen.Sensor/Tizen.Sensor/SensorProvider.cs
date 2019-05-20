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
using Tizen.System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace Tizen.Sensor
{
    /// <summary>
    /// The Sensor Info.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class SensorProvider : IDisposable
    {
        internal IntPtr _handle;
        private static Interop.SensorManager.SensorAddedCb _sensorAddedCallBack = null;
        private static Interop.SensorManager.SensorRemovedCb _sensorRemovedCallBack = null;
        private static Interop.SensorProvider.SensorProviderStartCb _sensorProviderStartCallBack = null;
        private static Interop.SensorProvider.SensorProviderStopCb _sensorProviderStopCallBack = null;
        private static Interop.SensorProvider.SensorProviderIntervalChangedCb _sensorProviderIntervalChangedCallBack = null;
        /// <summary>
        /// ProviderIntervalChanged
        /// </summary>
        private static event EventHandler<ProviderIntervalChangedEventArgs> ProviderIntervalChanged;

        /// <summary>
        /// SensorProvider constructor.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="handle"> The account handle.</param>
        internal SensorProvider(IntPtr handle) {
            Handle = handle;
        }

        /// <summary>
        /// SensorProvider deconstructor.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        ~SensorProvider()
        {
            Dispose(false);
        }

        internal IntPtr Handle
        {
            get
            {
                return _handle;
            }

            set
            {
                _handle = value;
            }
        }

        internal bool CheckProviderHandle()
        {
            bool result = false;
            if (Handle != IntPtr.Zero)
            {
                result = true;
            }
            else
            {
                Log.Error(Globals.LogTag, "Sensor Provider handle is null");
                throw new ArgumentException("Invalid Parameter: Sensor provider handle is null");
            }
            return result;
        }

        /// <summary>
        ///  This function creates a sensor provider handle with a given URI.
        /// </summary>
        /// <param name="uri">
        /// The URI of sensor to be created.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        public SensorProvider CreateProvider(string uri)
        {
            IntPtr handle;
            int error = Interop.SensorProvider.CreateProvider(uri, out handle);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error in creating sensor provider");
                throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.CreateProvider Failed");
            }
            return new SensorProvider(handle);
        }


        /// <summary>
        /// Registers the sensor provider.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void AddProvider(SensorProvider handle)
        {
            if (CheckProviderHandle())
            {
                AddSensorAddedCB();
                int error = Interop.SensorProvider.AddProvider(handle.Handle);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error in adding sensor provider");
                    throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.AddProvider Failed");
                }
            }
            else
            {
                Log.Error(Globals.LogTag, "Provider handle does not exist");
            }
        }

        /// <summary>
        /// Unregisters the sensor provider.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void RemoveProvider(SensorProvider handle)
        {
            if (CheckProviderHandle())
            { 
                AddSensorRemovedCB();
                int error = Interop.SensorProvider.RemoveProvider(handle.Handle);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error in removing sensor provider");
                    throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.RemoveProvider Failed");
                }
                RemoveSensorRemovedCB();
            }
            else
            {
                Log.Error(Globals.LogTag, "Provider handle does not exist");
            }
        }

        /// <summary>
        ///  Sets the name to the sensor provider.
        /// </summary>
        /// <param name="name">
        /// The name of the sensor.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        public void ProviderSetName(string name)
        {
            if (CheckProviderHandle())
            {
                int error = Interop.SensorProvider.ProviderSetName(Handle, name);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error in setting name of sensor provider");
                    throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.ProviderSetName Failed");
                }
            }
            else
            {
                Log.Error(Globals.LogTag, "Provider handle does not exist");
            }
        }

        /// <summary>
        /// Sets the vendor to the sensor provider.
        /// </summary>
        /// <param name="vendor">
        /// The vendor of the sensor.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        public void ProviderSetVendor(string vendor)
        {
            if (CheckProviderHandle())
            { 
                int error = Interop.SensorProvider.ProviderSetVendor(Handle, vendor);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error in setting vendor of sensor provider");
                    throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.ProviderSetVendor Failed");
                }
            }
            else
            {
                Log.Error(Globals.LogTag, "Provider handle does not exist");
            }
        }

        
        /// <summary>
        /// Sets the range of possible sensor values to the sensor provider.
        /// </summary>
        /// <param name="minRange">
        /// The lower bound.
        /// </param>
        /// <param name="maxRange">
        /// The upper bound.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        public void ProviderSetRange(float minRange, float maxRange)
        {
            if (CheckProviderHandle())
            { 
                int error = Interop.SensorProvider.ProviderSetRange(Handle, minRange, maxRange);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error in setting range of sensor provider");
                    throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.ProviderSetRange Failed");
                }
            }
            else
            {
                Log.Error(Globals.LogTag, "Provider handle does not exist");
            }
        }

        /// <summary>
        /// Sets the resolution of sensor values to the sensor provider.
        /// </summary>
        /// <param name="resolution">
        /// The resolution.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        public void ProviderSetResolution(float resolution)
        {
            if (CheckProviderHandle())
            { 
                int error = Interop.SensorProvider.ProviderSetResolution(Handle, resolution);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error in setting resolution of sensor provider");
                    throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.ProviderSetResolution Failed");
                }
            }
            else
            {
                Log.Error(Globals.LogTag, "Provider handle does not exist");
            }
        }

        /// <summary>
        /// Publishes a sensor event through the declared sensor.
        /// This function publishes a sensor's data to its listeners.
        /// </summary>
        /// <param name="sensorEvent">
        /// The sensor event.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        public void ProviderPublish(SensorEvent sensorEvent)
        {
            if (CheckProviderHandle())
            {
                Interop.SensorEventStruct _sensorEvent = Interop.ClassToEventStruct(sensorEvent);
                int error = Interop.SensorProvider.ProviderPublish(Handle, _sensorEvent);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error in sensor provider publish");
                    throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.ProviderPublish Failed");
                }
            }
            else
            {
                Log.Error(Globals.LogTag, "Provider handle does not exist");
            }
        }

        /// <summary>
        /// Registers the callback function to be invoked when a listener starts the sensor provider.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void SetProviderStartCb()
        {
            if (CheckProviderHandle())
            { 
                _sensorProviderStartCallBack = (IntPtr _provider, Int64 _userData) =>
                {
                };

                int error = Interop.SensorProvider.SetProviderStartCb(Handle, _sensorProviderStartCallBack, IntPtr.Zero);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error in setting start callback of sensor provider");
                    throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.ProviderSetStartCb Failed");
                }
            }
            else
            {
                Log.Error(Globals.LogTag, "Provider handle does not exist");
            }
        }

        /// <summary>
        /// Registers the callback function to be invoked when a sensor listener stops the sensor provider.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void SetProviderStopCb()
        {
            if (CheckProviderHandle())
            { 
                _sensorProviderStopCallBack = (IntPtr _provider, Int64 _userData) =>
                {
                };

                int error = Interop.SensorProvider.SetProviderStopCb(Handle, _sensorProviderStopCallBack, IntPtr.Zero);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error in setting stop callback of sensor provider");
                    throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.ProviderSetStopCb Failed");
                }
            }
            else
            {
                Log.Error(Globals.LogTag, "Provider handle does not exist");
            }
        }

        /// <summary>
        /// Registers the callback function to be invoked when the interval is changed.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        private void SetProviderIntervalChangedCb()
        {
            if (CheckProviderHandle())
            { 
                _sensorProviderIntervalChangedCallBack = (IntPtr _provider, uint IntervalMs, Int64 _userData) =>
                {
                    ProviderIntervalChangedEventArgs e = new ProviderIntervalChangedEventArgs(_provider, IntervalMs, _userData)
                    {
                    };
                    ProviderIntervalChanged?.Invoke(null, e);
                };

                int error = Interop.SensorProvider.SetProviderIntervalChangedCb(Handle, _sensorProviderIntervalChangedCallBack, IntPtr.Zero);
                if (error != (int)SensorError.None)
                {
                    Log.Error(Globals.LogTag, "Error in setting interval callback of sensor provider");
                    throw SensorErrorFactory.CheckAndThrowException(error, "Sensor.ProviderSetIntervalChangedCb Failed");
                }
            }
            else
            {
                Log.Error(Globals.LogTag, "Provider handle does not exist");
            }
        }


        /// <summary>
        /// Adds a callback function to be invoked when a new sensor is added.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        private void AddSensorAddedCB()
        {
            _sensorAddedCallBack = (String uri, Int64 _userData) =>
            {
            };

            int error = Interop.SensorManager.AddSensorAddedCB(_sensorAddedCallBack, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error in sensor add sensor added callback");
                throw SensorErrorFactory.CheckAndThrowException(error, "SensorManager.AddSensorAddedCB Failed");
            }

        }

        /// <summary>
        /// Adds a callback function to be invoked when a sensor is removed.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        private void AddSensorRemovedCB()
        {
            _sensorRemovedCallBack = (String uri, Int64 _userData) =>
            {
            };

            int error = Interop.SensorManager.AddSensorRemovedCB(_sensorRemovedCallBack, IntPtr.Zero);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error in sensor add sensor removed callback");
                throw SensorErrorFactory.CheckAndThrowException(error, "SensorManager.AddSensorRemovedCB Failed");
            }

        }

        /// <summary>
        /// Removes a callback function added using AddSensorRemovedCB()
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        private void RemoveSensorAddedCB()
        {
            _sensorAddedCallBack = (String uri, Int64 _userData) =>
            {
            };

            int error = Interop.SensorManager.RemoveSensorAddedCB(_sensorAddedCallBack);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error in sensor remove sensor added callback");
                throw SensorErrorFactory.CheckAndThrowException(error, "SensorManager.RemoveSensorAddedCB Failed");
            }

        }

        /// <summary>
        /// Removes a callback function added using AddSensorRemovedCB()
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        private void RemoveSensorRemovedCB()
        {
            _sensorRemovedCallBack = (String uri, Int64 _userData) =>
            {
            };

            int error = Interop.SensorManager.RemoveSensorRemovedCB(_sensorRemovedCallBack);
            if (error != (int)SensorError.None)
            {
                Log.Error(Globals.LogTag, "Error in sensor remove sensor removed callback");
                throw SensorErrorFactory.CheckAndThrowException(error, "SensorManager.RemoveSensorRemovedCB Failed");
            }

        }

        /// <summary>
        /// Overloaded Dispose API for destroying the SensorProvider Handle.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose API for destroying the SensorProvider handle.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="disposing">The boolean value for destoying SensorProvider handle.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                if (_handle != IntPtr.Zero)
                {
                    Interop.SensorProvider.DestroyProvider(_handle);
                    _handle = IntPtr.Zero;
                }
            }
        }



    }
}



