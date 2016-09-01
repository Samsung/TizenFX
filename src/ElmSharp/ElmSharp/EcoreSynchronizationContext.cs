// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System.Threading;

namespace ElmSharp
{

    /// <summary>
    /// Provides a synchronization context for the efl application.
    /// </summary>
    public class EcoreSynchronizationContext : SynchronizationContext
    {
        /// <summary>
        /// Initializes a new instance of the EcoreSynchronizationContext class.
        /// </summary>
        public EcoreSynchronizationContext()
        {
        }

        /// <summary>
        /// Initilizes a new EcoreSynchronizationContext and install into current thread
        /// </summary>
        /// <remarks>
        /// It is equivalent
        /// <code>
        /// SetSynchronizationContext(new EcoreSynchronizationContext());
        /// </code>
        /// </remarks>
        public static void Initialize()
        {
            SetSynchronizationContext(new EcoreSynchronizationContext());
        }

        /// <summary>
        /// Dispatches an asynchronous message to a Ecore main loop.
        /// </summary>
        /// <param name="d"><see cref="System.Threading.SendOrPostCallback"/>The SendOrPostCallback delegate to call.</param>
        /// <param name="state"><see cref="System.Object"/>The object passed to the delegate.</param>
        /// <remarks>
        /// The Post method starts an asynchronous request to post a message.</remarks>
        public override void Post(SendOrPostCallback d, object state)
        {
            EcoreMainloop.PostAndWakeUp(() =>
            {
                d(state);
            });
        }

        /// <summary>
        /// Dispatches a synchronous message to a Ecore main loop
        /// </summary>
        /// <param name="d"><see cref="System.Threading.SendOrPostCallback"/>The SendOrPostCallback delegate to call.</param>
        /// <param name="state"><see cref="System.Object"/>The object passed to the delegate.</param>
        /// <remarks>
        /// The Send method starts a synchronous request to send a message.</remarks>
        public override void Send(SendOrPostCallback d, object state)
        {
            EcoreMainloop.Send(() =>
            {
                d(state);
            });
        }
    }
}
