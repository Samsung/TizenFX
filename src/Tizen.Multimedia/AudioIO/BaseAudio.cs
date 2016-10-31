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

namespace Tizen.Multimedia
{
    public abstract class BaseAudio : IDisposable
    {
        #region Event
        private EventHandler<AudioStreamLengthChangedEventArgs> streamCallback;
        private EventHandler<AudioStateChangedEventArgs> stateChanged;

        public event EventHandler<AudioStreamLengthChangedEventArgs> StreamLengthChanged
        {
            add
            {
                if (streamCallback == null)
                {
                    RegisterAudioStreamLengthChanged();
                }
                streamCallback += value;
            }
            remove
            {
                streamCallback -= value;
                if (streamCallback == null)
                {
                    UnregisterAudioStreamLengthChanged();
                }
            }
        }
        public event EventHandler<AudioStateChangedEventArgs> StateChanged
        {
            add
            {
                if (streamCallback == null)
                {
                    RegisterAudioStateChangedCallback();
                }
                stateChanged += value;
            }
            remove
            {
                stateChanged -= value;
                if (streamCallback == null)
                {
                    UnregisterAudioStateChangedmCallback();
                }
            }
        }

        protected void OnStream(IntPtr handle, uint nbytes, IntPtr userdata)
        {
            if (streamCallback != null)
            {
                streamCallback(this, new AudioStreamLengthChangedEventArgs(nbytes));
            }
        }
        protected void OnStateChanged(IntPtr handle, int previous, int current, bool by_policy, IntPtr user_data)
        {
            if (streamCallback != null)
            {
                stateChanged(this, new AudioStateChangedEventArgs((AudioState)previous, (AudioState)current, by_policy));
            }
        } 
        #endregion
        protected IntPtr _handle = IntPtr.Zero;
        protected bool _bReady = false;

        public abstract int SampleRate { get;}
        public abstract AudioChannel Channel { get; }
        public abstract AudioSampleType SampleType { get; }
        public abstract int BufferSize{ get; }

        public abstract void Prepare();
        public abstract void Unprepare();
        public abstract void Pause();
        public abstract void Resume();
        public abstract void Flush();
        public abstract void SetStreamInfo(AudioStreamPolicy streamPolicy);  // 현재는 임의의 타입으로 실제 AudioPolicy가 들어와야 함.
        protected abstract void Destroy();
        protected abstract void RegisterAudioStreamLengthChanged();
        protected abstract void UnregisterAudioStreamLengthChanged();
        protected abstract void UnregisterAudioStateChangedmCallback();
        protected abstract void RegisterAudioStateChangedCallback();

        public BaseAudio() { }
        ~BaseAudio()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
        }
        protected virtual void Dispose(bool _bDisposing)
        {
            if (_bDisposing) // // Free managed objects.
            {
                // to be used if there are any other disposable objects
            }
            // // Free Unmanaged objects.
            if (_bReady)
                Unprepare();
            if (_handle != IntPtr.Zero)
                Destroy();

            GC.SuppressFinalize(this);
        }
    }    
}
