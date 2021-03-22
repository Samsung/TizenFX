/*
* Copyright (c) 2020 - 2021 Samsung Electronics Co., Ltd All Rights Reserved
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
using Tizen.Internals.Errors;
using NativeGpio = Interop.Peripheral.Gpio;

namespace Tizen.Peripheral.Gpio
{
    /// <summary>
    /// Enumeration of GPIO direction options.
    /// </summary>
    public enum GpioPinDriveMode
    {
        /// <summary>
        /// Input Mode.
        /// </summary>
        Input,

        /// <summary>
        /// Output mode with high value.
        /// </summary>
        OutputInitiallyLow,

        /// <summary>
        /// Output mode with low value.
        /// </summary>
        OutputInitiallyHigh,
    }

    /// <summary>
    /// Enumeration of GPIO values.
    /// </summary>
    public enum GpioPinValue
    {
        /// <summary>
        /// Low value.
        /// </summary>
        Low = 0,

        /// <summary>
        /// High value.
        /// </summary>
        High
    }

    /// <summary>
    /// Enumeration of edge types for the GPIO interrupt.
    /// </summary>
    public enum GpioChangePolarity
    {
        /// <summary>
        /// No interrupt on GPIO.
        /// </summary>
        None = 0,

        /// <summary>
        /// Interrupt on rising only.
        /// </summary>
        Rising,

        /// <summary>
        /// Interrupt on falling only.
        /// </summary>
        Falling,

        /// <summary>
        /// Interrupt on rising and falling.
        /// </summary>
        Both
    }

    /// <summary>
    /// The class allows applications to use the platform Digital Pins as Input/Output.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/peripheralio</privilege>
    public class GpioPin : IDisposable
    {

        private GpioChangePolarity _polarityType;
        private NativeGpio.InterruptedEventCallback _interruptedEventCallback;

        /// <summary>
        /// Native handle to Gpio.
        /// </summary>
        private IntPtr _handle = IntPtr.Zero;
        private bool _disposed = false;

        /// <summary>
        /// Invoked when Gpio pin was interrupted.
        /// </summary>
        public event EventHandler<PinUpdatedEventArgs> ValueChanged;

        /// <summary>
        /// Opens a GPIO pin.
        /// </summary>
        /// <param name="pinNumber">The GPIO pin number.</param>
        /// <param name="mode">GPIO direction.</param>
        public GpioPin(int pinNumber, GpioPinDriveMode mode)
        {
            var ret = NativeGpio.Open(pinNumber, out _handle);
            try
            {
                if (ret != ErrorCode.None)
                    throw ExceptionFactory.CreateException(ret);

                PinNumber = pinNumber;
                switch (mode)
                {
                    case GpioPinDriveMode.Input:
                        ret = NativeGpio.SetEdgeMode(_handle, NativeGpio.EdgeType.Both);
                        if (ret != ErrorCode.None)
                            throw ExceptionFactory.CreateException(ret);

                        ret = NativeGpio.SetDirection(_handle, NativeGpio.Direction.In);
                        if (ret != ErrorCode.None)
                            throw ExceptionFactory.CreateException(ret);
                        SetIntteruptedCallback();
                        break;
                    case GpioPinDriveMode.OutputInitiallyLow:
                        ret = NativeGpio.SetDirection(_handle, NativeGpio.Direction.OutLow);
                        if (ret != ErrorCode.None)
                            throw ExceptionFactory.CreateException(ret);
                        break;
                    case GpioPinDriveMode.OutputInitiallyHigh:
                        ret = NativeGpio.SetDirection(_handle, NativeGpio.Direction.OutHigh);
                        if (ret != ErrorCode.None)
                            throw ExceptionFactory.CreateException(ret);
                        break;
                }
            }
            catch (Exception err)
            {
                Dispose();
                throw;
            }
        }


        /// <summary>
        /// Closes the GPIO pin.
        /// </summary>
        ~GpioPin()
        {
            Dispose(false);
        }

        private void SetIntteruptedCallback()
        {
            _interruptedEventCallback = OnInterrupted;
            var ret = NativeGpio.SetInterruptedCb(_handle, _interruptedEventCallback, IntPtr.Zero);
            if (ret != ErrorCode.None)
                throw ExceptionFactory.CreateException(ret);
        }

        private void OnInterrupted(IntPtr handle, ErrorCode error, IntPtr data)
        {
            NativeGpio.PeripherialGpio pio = (NativeGpio.PeripherialGpio)
                                            System.Runtime.InteropServices.Marshal.PtrToStructure(handle,
                                                typeof(NativeGpio.PeripherialGpio));
            // check magic values to verify capi structures integrity
            if (pio.vermagic != 13712 || pio.cbInfo.vermagic != 14469)
            {
                Log.Error("Peripheral",
                        "Unable to parse gpio structure in callback - vermagic is wrong");
                return;
            }
            ValueChanged?.Invoke(this, new PinUpdatedEventArgs(PinNumber, pio.cbInfo.gpioPinValue == 1 ?
                                                                GpioPinValue.High : GpioPinValue.Low));
        }

        /// <summary>
        /// Closes a GPIO pin.
        /// </summary>
        public void Close() => Dispose();

        /// <summary>
        /// Disposes GPIO.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes GPIO.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }
            NativeGpio.UnsetInterruptedCb(_handle);
            NativeGpio.Close(_handle);
            _handle = IntPtr.Zero;
            _disposed = true;
        }

        /// <summary>
        /// GPIO pin number.
        /// </summary>
        public int PinNumber { get; }

        /// <summary>
        /// Gets pin value.
        /// </summary>
        /// <returns>Pin value</returns>
        public GpioPinValue Read()
        {
            var ret = NativeGpio.Read(_handle, out uint value);
            if (ret != ErrorCode.None)
                throw ExceptionFactory.CreateException(ret);

            return value == 1 ? GpioPinValue.High : GpioPinValue.Low;
        }

        /// <summary>
        /// Sets pin value.
        /// </summary>
        public void Write(GpioPinValue value)
        {
            var ret = NativeGpio.Write(_handle, value == GpioPinValue.High ? 1 : (uint)0);
            if (ret != ErrorCode.None)
                throw ExceptionFactory.CreateException(ret);
        }

        /// <summary>
        /// Sets or gets the GPIO edge mode.
        /// </summary>
        /// <remarks>Get value is initialized after successful Set call.</remarks>
        public GpioChangePolarity Polarity
        {
            get => _polarityType;
            set
            {
                var ret = NativeGpio.SetEdgeMode(_handle, (NativeGpio.EdgeType)value);
                if (ret != ErrorCode.None)
                    throw ExceptionFactory.CreateException(ret);
                _polarityType = value;
            }
        }
    }
}
