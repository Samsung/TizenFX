// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;

namespace Tizen.Applications.CoreBackend
{
    /// <summary>
    /// Interface that represents the backend lifecycles.
    /// </summary>
    public interface ICoreBackend : IDisposable
    {
        /// <summary>
        /// Adds an event handler.
        /// </summary>
        /// <param name="evType">The type of event.</param>
        /// <param name="handler">The handler method without arguments.</param>
        void AddEventHandler(EventType evType, Action handler);

        /// <summary>
        /// Adds an event handler.
        /// </summary>
        /// <typeparam name="TEventArgs">The EventArgs type used in arguments of the handler method.</typeparam>
        /// <param name="evType">The type of event.</param>
        /// <param name="handler">The handler method with a TEventArgs type argument.</param>
        void AddEventHandler<TEventArgs>(EventType evType, Action<TEventArgs> handler) where TEventArgs : EventArgs;

        /// <summary>
        /// Runs the mainloop of backend.
        /// </summary>
        /// <param name="args"></param>
        void Run(string[] args);

        /// <summary>
        /// Exits the mainloop of backend.
        /// </summary>
        void Exit();
    }
}
