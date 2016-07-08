// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;

namespace Tizen.System.Storage
{
    /// <summary>
    /// class to access storage device information
    /// </summary>
    public class Storage
    {
        private const string LogTag = "Tizen.System";
        private Interop.Storage.StorageState _state;
        private ulong _totalSpace;

        internal Storage(int storageID, Interop.Storage.StorageArea storageType, Interop.Storage.StorageState storagestate, string rootDirectory)
        {
            Id = storageID;
            StorageType = (StorageArea)storageType;
            RootDirectory = rootDirectory;
            _state = storagestate;

            Interop.Storage.ErrorCode err = Interop.Storage.StorageGetTotalSpace(Id, out _totalSpace);
            if (err != Interop.Storage.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to get total storage space for storage Id: {0}. err = {1}", Id, err));
            }

            s_stateChangedEventCallback = (id, state, userData) =>
            {
                if (id == Id)
                {
                    _state = state;
                    s_stateChangedEventHandler?.Invoke(this, EventArgs.Empty);
                }
            };
        }

        private EventHandler s_stateChangedEventHandler;
        private Interop.Storage.StorageStateChangedCallback s_stateChangedEventCallback;

        private void RegisterStateChangedEvent()
        {
            Interop.Storage.ErrorCode err = Interop.Storage.StorageSetStateChanged(Id, s_stateChangedEventCallback, IntPtr.Zero);
            if (err != Interop.Storage.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to Register state changed event callback for storage Id: {0}. err = {1}", Id, err));
            }
        }

        private void UnregisterStateChangedEvent()
        {
            Interop.Storage.ErrorCode err = Interop.Storage.StorageUnsetStateChanged(Id, s_stateChangedEventCallback);
            if (err != Interop.Storage.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to Register state changed event callback for storage Id: {0}. err = {1}", Id, err));
            }
        }

        /// <summary>
        /// StorageStateChanged event. This event is occurred when a storage state changes.
        /// </summary>
        /// <remarks>
        /// Storage state will be updated before calling event handler.
        /// </remarks>
        /// <example>
        /// <code>
        /// myStorage.StorageStateChanged += (s, e) =>
        /// {
        ///     var storage = s as Storage;
        ///     Console.WriteLine(string.Format("State Changed to {0}", storage.State));
        /// }
        /// </code>
        /// </example>
        public event EventHandler StorageStateChanged
        {
            add
            {
                if (s_stateChangedEventHandler == null)
                {
                    _state = (Interop.Storage.StorageState)State;
                    RegisterStateChangedEvent();
                }
                s_stateChangedEventHandler += value;
            }
            remove
            {
                if (s_stateChangedEventHandler != null)
                {
                    s_stateChangedEventHandler -= value;
                    if (s_stateChangedEventHandler == null)
                    {
                        UnregisterStateChangedEvent();
                    }
                }
            }
        }

        /// <summary>
        /// Storage ID
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// Type of the storage
        /// </summary>
        public StorageArea StorageType { get; }
        /// <summary>
        /// Root directory for the storage
        /// </summary>
        public string RootDirectory { get; }
        /// <summary>
        /// Total storage size in bytes
        /// </summary>
        public ulong TotalSpace { get { return _totalSpace; } }

        /// <summary>
        /// Storage state
        /// </summary>
        public StorageState State
        {
            get
            {
                if (s_stateChangedEventHandler == null)
                {
                    Interop.Storage.ErrorCode err = Interop.Storage.StorageGetState(Id, out _state);
                    if (err != Interop.Storage.ErrorCode.None)
                    {
                        Log.Warn(LogTag, string.Format("Failed to get storage state for storage Id: {0}. err = {1}", Id, err));
                    }
                }
                return (StorageState)_state;
            }
        }

        /// <summary>
        /// Available storage size in bytes
        /// </summary>
        public ulong AvaliableSpace
        {
            get
            {
                ulong available;
                Interop.Storage.ErrorCode err = Interop.Storage.StorageGetAvailableSpace(Id, out available);
                if (err != Interop.Storage.ErrorCode.None)
                {
                    Log.Warn(LogTag, string.Format("Failed to get available storage stace for storage Id: {0}. err = {1}", Id, err));
                }

                return available;
            }
        }

        /// <summary>
        /// Absolute path for given directory type in storage
        /// </summary>
        /// <remarks>
        /// returned directory path may not exist, so you must make sure that it exists before using it.
        /// For accessing internal storage except Ringtones directory, app should have http://tizen.org/privilege/mediastorage privilege.
        /// For accessing Ringtones directory, app should have http://tizen.org/privilege/systemsettings privilege.
        /// For accessing external storage, app should have http://tizen.org/privilege/externalstorage privilege.
        /// </remarks>
        /// <param name="dirType">Directory type</param>
        /// <returns>Absolute path for given directory type in storage</returns>
        /// <exception cref="ArgumentException">Thrown when failed because of a invalid arguament</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory exception</exception>
        /// <exception cref="NotSupportedException">Thrown when failed if storage is not supported or app does not have permission to access directory path</exception>
        /// <privilege>http://tizen.org/privilege/mediastorage</privilege>
        /// <privilege>http://tizen.org/privilege/systemsettings</privilege>
        /// <privilege>http://tizen.org/privilege/externalstorage</privilege>
        /// <example>
        /// <code>
        /// // To get video directories for all supported storage,
        /// var storageList = StorageManager.Storages as List&lt;Storage&gt;;
        /// foreach (var storage in storageList)
        /// {
        ///     string pathForVideoDir = storage.GetAbsolutePath(DirectoryType.Videos);
        /// }
        /// </code>
        /// </example>
        public string GetAbsolutePath(DirectoryType dirType)
        {
            string path = string.Empty;
            Interop.Storage.ErrorCode err = Interop.Storage.StorageGetAbsoluteDirectory(Id, (Interop.Storage.DirectoryType)dirType, out path);
            if (err != Interop.Storage.ErrorCode.None)
            {
                Log.Warn(LogTag, string.Format("Failed to get package Id. err = {0}", err));
                switch (err)
                {
                    case Interop.Storage.ErrorCode.InvalidParameter:
                        throw new ArgumentException("Invalid Arguments");
                    case Interop.Storage.ErrorCode.OutOfMemory:
                        throw new OutOfMemoryException("Out of Memory");
                    case Interop.Storage.ErrorCode.NotSupported:
                        throw new NotSupportedException("Operation Not Supported");
                    default:
                        throw new InvalidOperationException("Error = " + err);
                }
            }
            return path;
        }
    }
}
