/*
 * Copyright (c) 2023 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.System
{
    /// <summary>
    /// Provides methods to manage subsession users. Allows to register for events triggered by operations on subsession users.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class Session
    {
        /// <summary>
        /// UID of current system user.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int CurrentUID;

        /// <summary>
        /// Maximum length of any given user ID.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public const int MaxUserLength = 20;

        /// <summary>
        /// Special subsession ID, which is always present and does not represent any user.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public const string EmptyUser = "";

        private static ConcurrentDictionary<int, Session> s_sessionInstances = new ConcurrentDictionary<int, Session>();

        private readonly object _replyLock = new object();

        private IDictionary<int, Interop.Session.SubsessionReplyCallback> _replyMap = new ConcurrentDictionary<int, Interop.Session.SubsessionReplyCallback>();

        private int _replyID = 0;

        private delegate void EventDelegate(SubsessionEventInfoNative infoNative, IntPtr data);

        static Session()
        {
            CurrentUID = Interop.Session.GetUID();
        }

        private Session(int sessionUID)
        {
            SessionUID = sessionUID;
        }

        /// <summary>
        /// Gets a Session object instance for a given sessionUID.
        /// </summary>
        /// <param name="sessionUID">Session UID of a requested Session object instance</param>
        /// <returns>Returns requested Session object</returns>
        /// <remarks>
        /// To ensure thread safety, explicit creation of Session object is not allowed.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Session GetInstance(int sessionUID)
        {
            if (!s_sessionInstances.ContainsKey(sessionUID))
                s_sessionInstances.TryAdd(sessionUID, new Session(sessionUID));
            return s_sessionInstances[sessionUID];
        }

        /// <summary>
        /// Gets session UID of this session object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int SessionUID { get; private set; }

        /// <summary>
        /// Gets a list of all available subsession user IDs for this session.
        /// </summary>
        /// <remarks>
        /// The list of users depends on whether the session UID for this session object exists or not. If it
        /// doesn't, the user list is empty (in particular this is not an error).
        /// However if the session UID exists, the user list will contain the subsession
        /// IDs (if they exist), but also the default value, which is "" (empty string, see EmptyUser field).
        /// This doesn't mean that "" is a subsession ID in the same way as others; it is just a marker meaning that no subsession is
        /// enabled.
        /// </remarks>
        /// <exception cref="ArgumentException">Session UID of this object is invalid</exception>
        /// <exception cref="OutOfMemoryException">Out of memory</exception>
        /// <exception cref="IOException">Internal error</exception>
        /// <exception cref="UnauthorizedAccessException">Not permitted</exception>
        /// <exception cref="NotSupportedException">Not supported</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<string> GetUsers()
        {

            IntPtr ptr;
            int count;

            SessionError ret = Interop.Session.SubsessionGetUserList(SessionUID, out ptr, out count);
            CheckError(ret, "Interop failed to get user list");

            string[] users;
            IntPtrToStringArray(ptr, count, out users);
            Interop.Session.SubsessionFreeUserList(ptr);

            return new List<string>(users);
        }

        /// <summary>
        /// Gets a currently active subession user ID for this session.
        /// </summary>
        /// <remarks>
        /// When no subsession is enabled, "" (empty string, see EmptyUser field) is returned.
        /// This doesn't mean that "" is a subsession ID in the same way as others; it is just a marker meaning
        /// that no subsession is enabled.
        /// </remarks>
        /// <exception cref="ArgumentException">Session UID of this object is invalid</exception>
        /// <exception cref="OutOfMemoryException">Out of memory</exception>
        /// <exception cref="IOException">Internal error</exception>
        /// <exception cref="UnauthorizedAccessException">Not permitted</exception>
        /// <exception cref="NotSupportedException">Not supported</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string GetCurrentUser()
        {
            StringBuilder user = new StringBuilder(MaxUserLength);
            SessionError ret = Interop.Session.SubsessionGetCurrentUser(SessionUID, user);
            CheckError(ret, "Interop failed to get current subsession user");

            return user.ToString();
        }

        /// <summary>
        /// Request new subsession to be created.
        /// </summary>
        /// <param name="userName">Subesssion user ID to be created</param>
        /// <remarks>
        /// Subsession ID must not start with a dot or have slashes.
        /// </remarks>
        /// <exception cref="ArgumentException">Session UID of this object is invalid, or user ID is not a valid subession ID</exception>
        /// <exception cref="InvalidOperationException"> Provided subsession user ID already exists</exception>
        /// <exception cref="OutOfMemoryException">Out of memory</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Task SubsessionAddUserAsync(string userName)
        {
            var task = new TaskCompletionSource<bool>();
            int taskID = 0;

            lock (_replyLock)
            {
                taskID = _replyID++;
            }

            _replyMap[taskID] = (int result, IntPtr data) =>
            {
                try
                {
                    CheckError((SessionError)result, "Interop failed to complete adding a new subsession user");
                    task.SetResult(true);
                }
                catch (Exception exception)
                {
                    task.SetException(exception);
                }
                finally
                {
                    _replyMap.Remove((int)data);
                }
            };

            SessionError ret = Interop.Session.SubsessionAddUser(SessionUID, userName, _replyMap[taskID], (IntPtr)taskID);
            CheckError(ret, "Interop failed to register a reply for adding a user");
            return task.Task;
        }

        /// <summary>
        /// Request an existing subsession to be removed.
        /// </summary>
        /// <param name="userName">Existing subesssion user ID to be removed</param>
        /// <remarks>
        /// Subsession ID must not start with a dot or have slashes.
        /// Only inactive session ID can be removed. In order remove currently used session ID first switch to special
        /// session ID "" (empty string, see EmptyUser), and only after switch completes, remove previously active session ID.
        /// </remarks>
        /// <exception cref="ArgumentException">Session UID of this object is invalid, or user ID is not a valid subession ID</exception>
        /// <exception cref="InvalidOperationException">Provided subsession user ID does not exist</exception>
        /// <exception cref="OutOfMemoryException">Out of memory</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Task SubsessionRemoveUserAsync(string userName)
        {
            var task = new TaskCompletionSource<bool>();
            int taskID = 0;

            lock (_replyLock)
            {
                taskID = _replyID++;
            }

            _replyMap[taskID] = (int result, IntPtr data) =>
            {
                try
                {
                    CheckError((SessionError)result, "Interop failed to remove a subsession user");
                    task.SetResult(true);
                }
                catch (Exception exception)
                {
                    task.SetException(exception);
                }
                finally
                {
                    _replyMap.Remove((int)data);
                }
            };

            SessionError ret = Interop.Session.SubsessionRemoveUser(SessionUID, userName, _replyMap[taskID], (IntPtr)taskID);
            CheckError(ret, "Interop failed to register a reply for removing a user");
            return task.Task;
        }

        /// <summary>
        /// Request a subession to become currently active.
        /// </summary>
        /// <param name="userName">Existing subesssion user ID to be set as active</param>
        /// <remarks>
        /// Subsession ID must not start with a dot or have slashes.
        /// Special subsession ID "" (empty string, see EmptyUser) can be switched to, when it's required to deactivate
        /// current subsession (this step is needed when current session is to be removed).
        /// </remarks>
        /// <exception cref="ArgumentException">Session UID of this object is invalid, or user ID is not a valid subession ID</exception>
        /// <exception cref="InvalidOperationException">Provided subsession user ID to switch to does not exist</exception>
        /// <exception cref="OutOfMemoryException">Out of memory</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Task SubsessionSwitchUserAsync(string userName)
        {
            var task = new TaskCompletionSource<bool>();
            int taskID = 0;

            lock (_replyLock)
            {
                taskID = _replyID++;
            }

            _replyMap[taskID] = (int result, IntPtr data) =>
            {
                try
                {
                    CheckError((SessionError)result, "Interop failed to switch to a different subsession user");
                    task.SetResult(true);
                }
                catch (Exception exception)
                {
                    task.SetException(exception);
                }
                finally
                {
                    _replyMap.Remove((int)data);
                }
            };

            SessionError ret = Interop.Session.SubsessionSwitchUser(SessionUID, userName, _replyMap[taskID], (IntPtr)taskID);
            CheckError(ret, "Interop failed to register a reply for switching a user");
            return task.Task;
        }

        /// <summary>
        /// Mark event as completed.
        /// </summary>
        /// <param name="subsessionEventArgs">Event argument of the event (obtained from said event)</param>
        /// <remarks>
        /// This method is assumed to be called from an event handler. You can only mark an event as completed
        /// if you registered for in in the same process.
        /// </remarks>
        /// <exception cref="ArgumentException">Session UID of this object is invalid</exception>
        /// <exception cref="IOException">Internal error</exception>
        /// <exception cref="UnauthorizedAccessException">Not permitted</exception>
        /// <exception cref="NotSupportedException">Not supported</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SubsessionEventMarkAsDone(SubsessionEventArgs subsessionEventArgs)
        {
            SessionError ret = Interop.Session.SubsessionEventWaitDone(subsessionEventArgs.SessionInfo);
            CheckError(ret, $"Interop failed to mark this client's event (of type {subsessionEventArgs.SessionInfo.EventType}) as finished");
        }

        private void OnAddUserWait(SubsessionEventInfoNative infoNative, IntPtr data)
        {
            _addUserWaitHandler?.Invoke(this, new AddUserEventArgs(infoNative));
        }

        private Interop.Session.SubsessionEventCallback _addUserWaitCB = null;

        private event EventHandler<AddUserEventArgs> _addUserWaitHandler = null;

        private readonly object _addUserWaitLock = new object();

        /// <summary>
        /// Event to be invoked when a new subession user is successfully added to this session.
        /// </summary>
        /// <exception cref="ArgumentException">Session UID of this object is invalid</exception>
        /// <exception cref="OutOfMemoryException">Out of memory</exception>
        /// <exception cref="IOException">Internal error</exception>
        /// <exception cref="UnauthorizedAccessException">Not permitted</exception>
        /// <exception cref="NotSupportedException">Not supported</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<AddUserEventArgs> AddUserWait
        {
            add
            {
                lock (_addUserWaitLock)
                {
                    if (_addUserWaitHandler == null)
                        RegisterCallbackForEvent(SessionEventType.AddUserWait, ref _addUserWaitCB, OnAddUserWait);
                    _addUserWaitHandler += value;
                }
            }
            remove
            {
                lock (_addUserWaitLock)
                {
                    _addUserWaitHandler -= value;
                    if (_addUserWaitHandler == null)
                        UnregisterCallbackForEvent(SessionEventType.AddUserWait, ref _addUserWaitCB);
                }
            }
        }

        private void OnRemoveUserWait(SubsessionEventInfoNative infoNative, IntPtr data)
        {
            _removeUserWaitHandler?.Invoke(this, new RemoveUserEventArgs(infoNative));
        }

        private Interop.Session.SubsessionEventCallback _removeUserWaitCB = null;

        private event EventHandler<RemoveUserEventArgs> _removeUserWaitHandler = null;

        private readonly object _removeUserWaitLock = new object();

        /// <summary>
        /// Event to be invoked when a subession user is successfully removed from this session.
        /// </summary>
        /// <exception cref="ArgumentException">Session UID of this object is invalid</exception>
        /// <exception cref="OutOfMemoryException">Out of memory</exception>
        /// <exception cref="IOException">Internal error</exception>
        /// <exception cref="UnauthorizedAccessException">Not permitted</exception>
        /// <exception cref="NotSupportedException">Not supported</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<RemoveUserEventArgs> RemoveUserWait
        {
            add
            {
                lock (_removeUserWaitLock)
                {
                    if (_removeUserWaitHandler == null)
                        RegisterCallbackForEvent(SessionEventType.RemoveUserWait, ref _removeUserWaitCB, OnRemoveUserWait);
                    _removeUserWaitHandler += value;
                }
            }
            remove
            {
                lock (_removeUserWaitLock)
                {
                    _removeUserWaitHandler -= value;
                    if (_removeUserWaitHandler == null)
                        UnregisterCallbackForEvent(SessionEventType.RemoveUserWait, ref _removeUserWaitCB);
                }
            }
        }

        private void OnSwitchUserWait(SubsessionEventInfoNative infoNative, IntPtr data)
        {
            _switchUserWaitHandler?.Invoke(this, new SwitchUserWaitEventArgs(infoNative));
        }

        private Interop.Session.SubsessionEventCallback _switchUserWaitCB = null;

        private event EventHandler<SwitchUserWaitEventArgs> _switchUserWaitHandler = null;

        private readonly object _switchUserWaitLock = new object();

        /// <summary>
        /// Event to be invoked when an existing subession user has begun switching to an active state.
        /// </summary>
        /// <exception cref="ArgumentException">Session UID of this object is invalid</exception>
        /// <exception cref="OutOfMemoryException">Out of memory</exception>
        /// <exception cref="IOException">Internal error</exception>
        /// <exception cref="UnauthorizedAccessException">Not permitted</exception>
        /// <exception cref="NotSupportedException">Not supported</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<SwitchUserWaitEventArgs> SwitchUserWait
        {
            add
            {
                lock (_switchUserWaitLock)
                {
                    if (_switchUserWaitHandler == null)
                        RegisterCallbackForEvent(SessionEventType.SwitchUserWait, ref _switchUserWaitCB, OnSwitchUserWait);
                    _switchUserWaitHandler += value;
                }
            }
            remove
            {
                lock (_switchUserWaitLock)
                {
                    _switchUserWaitHandler -= value;
                    if (_switchUserWaitHandler == null)
                        UnregisterCallbackForEvent(SessionEventType.SwitchUserWait, ref _switchUserWaitCB);
                }
            }
        }

        private void OnSwitchUserCompletion(SubsessionEventInfoNative infoNative, IntPtr data)
        {
            _switchUserCompletionHandler?.Invoke(this, new SwitchUserCompletionEventArgs(infoNative));
        }

        private Interop.Session.SubsessionEventCallback _switchUserCompletionCB = null;

        private event EventHandler<SwitchUserCompletionEventArgs> _switchUserCompletionHandler = null;

        private readonly object _switchUserCompletionLock = new object();

        /// <summary>
        /// Event to be invoked when an existing subession user is successfully switched to an acvite state.
        /// </summary>
        /// <exception cref="ArgumentException">Session UID of this object is invalid</exception>
        /// <exception cref="OutOfMemoryException">Out of memory</exception>
        /// <exception cref="IOException">Internal error</exception>
        /// <exception cref="UnauthorizedAccessException">Not permitted</exception>
        /// <exception cref="NotSupportedException">Not supported</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<SwitchUserCompletionEventArgs> SwitchUserCompleted
        {
            add
            {
                lock (_switchUserCompletionLock)
                {
                    if (_switchUserCompletionHandler == null)
                        RegisterCallbackForEvent(SessionEventType.SwitchUserCompletion, ref _switchUserCompletionCB, OnSwitchUserCompletion);
                    _switchUserCompletionHandler += value;
                }
            }
            remove
            {
                lock (_switchUserCompletionLock)
                {
                    _switchUserCompletionHandler -= value;
                    if (_switchUserCompletionHandler == null)
                        UnregisterCallbackForEvent(SessionEventType.SwitchUserCompletion, ref _switchUserCompletionCB);
                }
            }
        }

        private void CheckError(SessionError ret, string msg)
        {
            if (ret == SessionError.None)
                return;

            Log.Error(SessionErrorFactory.LogTag, msg);
            Exception ex = SessionErrorFactory.CreateException(ret);
            if (ex == null)
            {
                Log.Error(SessionErrorFactory.LogTag,
                    "Unexpected exception type for SessionError: " + Enum.GetName(typeof(SessionError), ret));
                throw new InvalidOperationException("Unrecognized error");
            }
            throw ex;
        }

        static void IntPtrToStringArray(IntPtr unmanagedArray, int size, out string[] managedArray)
        {
            managedArray = new string[size];
            var curr = unmanagedArray;

            for (int iterator = 0; iterator < size; iterator++)
            {
                managedArray[iterator] = Marshal.PtrToStringAnsi(curr);
                curr = IntPtr.Add(curr, MaxUserLength);
            }
        }

        private void RegisterCallbackForEvent(SessionEventType eventType, ref Interop.Session.SubsessionEventCallback eventCallback,
            EventDelegate delegateToSet)
        {
            eventCallback = new Interop.Session.SubsessionEventCallback(delegateToSet);
            SessionError ret = Interop.Session.SubesssionRegisterEventCallback(SessionUID, eventType,
                eventCallback, IntPtr.Zero);
            CheckError(ret, $"Interop failed to register a callback for an event of type {eventType}");
        }

        private void UnregisterCallbackForEvent(SessionEventType eventType, ref Interop.Session.SubsessionEventCallback eventCallback)
        {
            SessionError ret = Interop.Session.SubesssionUnregisterEventCallback(SessionUID, eventType);
            CheckError(ret, $"Interop failed to unregister a callback for an event of type {eventType}");
            eventCallback = null;
        }
    }
}
