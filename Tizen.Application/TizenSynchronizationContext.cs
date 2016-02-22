using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace Tizen.Application {
    public class TizenSynchronizationContext : SynchronizationContext {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        delegate bool GSourceFunc(IntPtr userData);

        [DllImport("libglib-2.0.so.0 ", CallingConvention = CallingConvention.Cdecl)]
        static extern uint g_idle_add(GSourceFunc d, IntPtr data);

        public static void Initialize() {
            SynchronizationContext.SetSynchronizationContext(new TizenSynchronizationContext());
        }
        private GSourceFunc wrapperHandler;
        private Object transactionLock = new Object();
        private int transactionID = 0;
        private Dictionary<int, Action> handlerMap = new Dictionary<int, Action>();

        TizenSynchronizationContext() {
            wrapperHandler = new GSourceFunc(Handler);
        }

        public override void Post(SendOrPostCallback d, object state) {
            Post(() => {
                d(state);
            });
        }

        public override void Send(SendOrPostCallback d, object state) {
            var mre = new ManualResetEvent(false);
            Exception err = null;
            Post(() => {
                try {
                    d(state);
                } catch (Exception ex) {
                    err = ex;
                } finally {
                    mre.Set();
                }
            });
            mre.WaitOne();
            if (err != null) {
                throw err;
            }
        }

        public void Post(Action action) {
            int id = 0;
            lock (transactionLock) {
                id = transactionID++;
            }
            handlerMap.Add(id, action);
            g_idle_add(wrapperHandler, (IntPtr)id);
        }

        public bool Handler(IntPtr userData) {
            int key = (int)userData;
            if (handlerMap.ContainsKey(key)) {
                handlerMap[key]();
                handlerMap.Remove(key);
            }
            return false;
        }

    }
}
