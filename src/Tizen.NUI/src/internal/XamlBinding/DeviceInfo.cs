/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Tizen.NUI.Binding
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal abstract class DeviceInfo : INotifyPropertyChanged, IDisposable
    {
        DeviceOrientation currentOrientation;
        bool disposed;

        public DeviceOrientation CurrentOrientation
        {
            get { return currentOrientation; }
            set
            {
                if (Equals(currentOrientation, value))
                    return;
                currentOrientation = value;
                OnPropertyChanged();
            }
        }

        public virtual double DisplayRound(double value) =>
            Math.Round(value);

        public abstract Size PixelScreenSize { get; }

        public abstract Size ScaledScreenSize { get; }

        public abstract double ScalingFactor { get; }

        public void Dispose()
        {
            Dispose(true);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            disposed = true;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
