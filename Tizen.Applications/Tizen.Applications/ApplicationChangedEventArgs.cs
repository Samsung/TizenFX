/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.

using System;
using System.Collections.Generic;

namespace Tizen.Applications
{
    /// <summary>
    /// Enumeration for application state.
    /// </summary>
    public enum ApplicationState
    {
        /// <summary>
        /// Initial state.
        /// </summary>
        None = -1,
        /// <summary>
        /// Launched state.
        /// </summary>
        Launched,
        /// <summary>
        /// Terminated state.
        /// </summary>
        Terminated,
    }

    /// <summary>
    /// ApplicationChangedEventArgs class. This class is an event arguments of the ApplicationLaunched and ApplicationTerminated events.
    /// </summary>
    public class ApplicationChangedEventArgs : EventArgs
    {
        private string _appid = "";
        private int _pid = 0;
        private ApplicationState _state = ApplicationState.None;

        public ApplicationChangedEventArgs(string applicationId, int processId, int state)
        {
            _appid = applicationId;
            _pid = processId;
            _state = (ApplicationState)state;
        }

        /// <summary>
        /// ApplicationId property.
        /// </summary>
        /// <returns>string application id.</returns>
        public string ApplicationId
        {
            get
            {
                return _appid;
            }
        }

        /// <summary>
        /// ProcessId property.
        /// </summary>
        /// <returns>int process id.</returns>
        public int ProcessId
        {
            get
            {
                return _pid;
            }
        }

        /// <summary>
        /// State property.
        /// </summary>
        /// <returns>ApplicationState enum value.</returns>
        public ApplicationState State
        {
            get
            {
                return _state;
            }
        }

    }
}

