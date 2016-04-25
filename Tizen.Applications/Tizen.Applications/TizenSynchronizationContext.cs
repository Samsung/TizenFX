// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Collections.Generic;
using System.Threading;

namespace Tizen.Applications
{

    /// <summary>
    /// Provides a synchronization context for the Tizen application model.
    /// </summary>
    public class TizenSynchronizationContext : SynchronizationContext
    {
        private readonly Interop.Glib.GSourceFunc _wrapperHandler;
        private readonly Object _transactionLock = new Object();
        private readonly Dictionary<int, Action> _handlerMap = new Dictionary<int, Action>();
        private int _transactionId = 0;

        /// <summary>
        /// Initializes a new instance of the TizenSynchronizationContext class.
        /// </summary>
        public TizenSynchronizationContext()
        {
            _wrapperHandler = new Interop.Glib.GSourceFunc(Handler);
        }

        /// <summary>
        /// Initilizes a new TizenSynchronizationContext and install into current thread
        /// </summary>
        /// <remarks>
        /// It is equivalent
        /// <code>
        /// SetSynchronizationContext(new TizenSynchronizationContext());
        /// </code>
        /// </remarks>
        public static void Initialize()
        {
            SetSynchronizationContext(new TizenSynchronizationContext());
        }


        /// <summary>
        /// Dispatches an asynchronous message to a Tizen main loop.
        /// </summary>
        /// <param name="d"><see cref="System.Threading.SendOrPostCallback"/>The SendOrPostCallback delegate to call.</param>
        /// <param name="state"><see cref="System.Object"/>The object passed to the delegate.</param>
        /// <remarks>
        /// The Post method starts an asynchronous request to post a message.</remarks>
        public override void Post(SendOrPostCallback d, object state)
        {
            Post(() =>
            {
                d(state);
            });
        }

        /// <summary>
        /// Dispatches a synchronous message to a Tizen main loop
        /// </summary>
        /// <param name="d"><see cref="System.Threading.SendOrPostCallback"/>The SendOrPostCallback delegate to call.</param>
        /// <param name="state"><see cref="System.Object"/>The object passed to the delegate.</param>
        /// <remarks>
        /// The Send method starts a synchronous request to send a message.</remarks>
        public override void Send(SendOrPostCallback d, object state)
        {
            var mre = new ManualResetEvent(false);
            Exception err = null;
            Post(() =>
            {
                try
                {
                    d(state);
                }
                catch (Exception ex)
                {
                    err = ex;
                }
                finally
                {
                    mre.Set();
                }
            });
            mre.WaitOne();
            if (err != null)
            {
                throw err;
            }
        }

        private void Post(Action action)
        {
            int id = 0;
            lock (_transactionLock)
            {
                id = _transactionId++;
            }
            _handlerMap.Add(id, action);
            Interop.Glib.IdleAdd(_wrapperHandler, (IntPtr)id);
        }

        private bool Handler(IntPtr userData)
        {
            int key = (int)userData;
            if (_handlerMap.ContainsKey(key))
            {
                _handlerMap[key]();
                _handlerMap.Remove(key);
            }
            return false;
        }
    }
}
