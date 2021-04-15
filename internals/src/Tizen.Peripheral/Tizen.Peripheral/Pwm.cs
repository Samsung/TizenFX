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
using NativePwm = Interop.Peripheral.Pwm;

namespace Tizen.Peripheral.Pwm
{
    /// <summary>
    /// Enumeration for PWM polarity.
    /// </summary>
    public enum PwmPulsePolarity
    {
        /// <summary>
        /// PWM signal start in the active high state.
        /// </summary>
        ActiveHigh = 0,

        /// <summary>
        /// PWM signal start in the active low state.
        /// </summary>
        ActiveLow
    }

    /// <summary>
    /// The class allows applications to use the platform PWM peripheral.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/peripheralio</privilege>
    public class PwmPin : IDisposable
    {

        //TODO provide default values.
        private uint _period;
        private uint _dutyCycle;
        private PwmPulsePolarity _polarity;
        private bool _enabled;
        private bool _disposed = false;

        /// <summary>
        /// Native handle to PWM.
        /// </summary>
        private IntPtr _handle = IntPtr.Zero;

        /// <summary>
        /// Opens the PWM pin.
        /// </summary>
        /// <param name="chip">The PWM chip number.</param>
        /// <param name="pin">The PWM pin (channel) number to control.</param>
        public PwmPin(int chip, int pin)
        {
            var ret = NativePwm.Open(chip, pin, out _handle);
            if (ret != Internals.Errors.ErrorCode.None)
                throw ExceptionFactory.CreateException(ret);
        }

        /// <summary>
        /// Closes the PWM pin.
        /// </summary>
        ~PwmPin()
        {
            Dispose(false);
        }

        /// <summary>
        /// Closes the PWM pin.
        /// </summary>
        public void Close() => Dispose();

        /// <summary>
        /// Disposes the PWM.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the PWM.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            NativePwm.Close(_handle);
            _handle = IntPtr.Zero;
            _disposed = true;
        }

        /// <summary>
        /// Sets or gets period of the PWM pin.
        /// </summary>
        /// <remarks>Get value is initialized after successful Set call.</remarks>
        public uint Period
        {
            get => _period;
            set
            {
                var ret = NativePwm.SetPeriod(_handle, value);
                if (ret != Internals.Errors.ErrorCode.None)
                    throw ExceptionFactory.CreateException(ret);

                _period = value;
            }
        }

        /// <summary>
        /// Sets or gets duty cycle of the PWM pin.
        /// </summary>
        /// <remarks>Get value is initialized after successful Set call.</remarks>
        public uint DutyCycle
        {
            get => _dutyCycle;
            set
            {
                var ret = NativePwm.SetDutyCycle(_handle, value);
                if (ret != Internals.Errors.ErrorCode.None)
                    throw ExceptionFactory.CreateException(ret);

                _dutyCycle = value;
            }
        }

        /// <summary>
        /// Sets or gets polarity of the PWM pin.
        /// </summary>
        /// <remarks>Get value is initialized after successful Set call.</remarks>
        public PwmPulsePolarity Polarity
        {
            get => _polarity;
            set
            {
                var ret = NativePwm.SetPolarity(_handle, (NativePwm.Polarity)value);
                if (ret != Internals.Errors.ErrorCode.None)
                    throw ExceptionFactory.CreateException(ret);

                _polarity = value;
            }
        }

        /// <summary>
        /// Enables or disables the PWM pin.
        /// </summary>
        /// <remarks>Get value is initialized after successful Set call.</remarks>
        public bool Enabled
        {
            get => _enabled;
            set
            {
                var ret = NativePwm.SetEnabled(_handle, value);
                if (ret != Internals.Errors.ErrorCode.None)
                    throw ExceptionFactory.CreateException(ret);

                _enabled = value;
            }
        }
    }
}
