using System;
using System.Collections.Generic;
using System.Threading;

namespace Tizen.Application
{
    internal class TizenSynchronizationContext : SynchronizationContext
    {
        public static void Initialize()
        {
            SetSynchronizationContext(new TizenSynchronizationContext());
        }
        private Interop.Glib.GSourceFunc wrapperHandler;
        private Object transactionLock = new Object();
        private int transactionID = 0;
        private Dictionary<int, Action> handlerMap = new Dictionary<int, Action>();

        TizenSynchronizationContext()
        {
            wrapperHandler = new Interop.Glib.GSourceFunc(Handler);
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
            lock (transactionLock)
            {
                id = transactionID++;
            }
            handlerMap.Add(id, action);
            Interop.Glib.IdleAdd(wrapperHandler, (IntPtr)id);
        }

        public bool Handler(IntPtr userData)
        {
            int key = (int)userData;
            if (handlerMap.ContainsKey(key))
            {
                handlerMap[key]();
                handlerMap.Remove(key);
            }
            return false;
        }

    }
}
