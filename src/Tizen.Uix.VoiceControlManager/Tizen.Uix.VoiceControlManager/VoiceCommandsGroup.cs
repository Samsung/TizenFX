/*
* Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Collections.ObjectModel;
using static Interop.VoiceControlManager;
using static Interop.VoiceControlCommand;
using System.Collections.Specialized;

namespace Tizen.Uix.VoiceControlManager
{
    /// <summary>
    /// This class represents a list of the voice commands.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class VoiceCommandsGroup : IDisposable
    {
        ObservableCollection<VoiceCommand> _commands = new ObservableCollection<VoiceCommand>();
        internal SafeCommandListHandle _handle;
        private bool _disposed = false;

        /// <summary>
        /// The public constructor.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <exception cref="InvalidOperationException">This exception can be due to out of memory.</exception>
        /// <exception cref="ArgumentException">This exception can be due to an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException">This exception can be due to permission denied.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        public VoiceCommandsGroup()
        {
            SafeCommandListHandle handle;
            ErrorCode error = VcCmdListCreate(out handle);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "Create Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
            _handle = handle;
            _commands.CollectionChanged += OnCollectionChanged;
        }

        internal VoiceCommandsGroup(SafeCommandListHandle handle)
        {
            _handle = handle;

            VcCmdListCb _callback = (IntPtr vcCommand, IntPtr userData) =>
            {
                SafeCommandHandle cmdHandle = new SafeCommandHandle(vcCommand);
                _commands.Add(new VoiceCommand(cmdHandle));
                return true;
            };
            ErrorCode error = VcCmdListForeachCommands(_handle, _callback, IntPtr.Zero);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "GetAllCommands Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
            _commands.CollectionChanged += OnCollectionChanged;
        }

        /// <summary>
        /// The destructor of the VoiceCommandList class.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        ~VoiceCommandsGroup()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets the command list.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public IList<VoiceCommand> Commands { get => _commands; }

        /// <summary>
        /// Release any unmanaged resources used by this object.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Release any unmanaged resources used by this object.
        /// </summary>
        /// <param name="disposing">
        /// If true, disposes any disposable objects. If false, does not dispose disposable objects.
        /// </param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _handle?.Dispose();
                _handle = null;
                _commands.CollectionChanged -= OnCollectionChanged;
                _commands.Clear();
            }

            _disposed = true;
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (VoiceCommand item in e.NewItems)
                    Add(item);
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (VoiceCommand item in e.OldItems)
                    Remove(item);
            }
        }

        void Add(VoiceCommand command)
        {
            ErrorCode error = VcCmdListAdd(_handle, command._handle);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "Add Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }

        void Remove(VoiceCommand command)
        {
            ErrorCode error = VcCmdListRemove(_handle, command._handle);
            if (error != ErrorCode.None)
            {
                Log.Error(LogTag, "Remove Failed with error " + error);
                throw ExceptionFactory.CreateException(error);
            }
        }
    }
}
