/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;
using System.Collections.Generic;
using System.Threading;

namespace Tizen.Applications
{
    internal class TizenSynchronizationContext : SynchronizationContext
    {
        private readonly Interop.Glib.GSourceFunc _wrapperHandler;
        private readonly Object _transactionLock = new Object();
        private readonly Dictionary<int, Action> _handlerMap = new Dictionary<int, Action>();
        private int _transactionId = 0;

        private TizenSynchronizationContext()
        {
            _wrapperHandler = new Interop.Glib.GSourceFunc(Handler);
        }

        public static void Initialize()
        {
            SetSynchronizationContext(new TizenSynchronizationContext());
        }

        public override void Post(SendOrPostCallback d, object state)
        {
            Post(() =>
            {
                d(state);
            });
        }

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

        public void Post(Action action)
        {
            int id = 0;
            lock (_transactionLock)
            {
                id = _transactionId++;
            }
            _handlerMap.Add(id, action);
            Interop.Glib.IdleAdd(_wrapperHandler, (IntPtr)id);
        }

        public bool Handler(IntPtr userData)
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
