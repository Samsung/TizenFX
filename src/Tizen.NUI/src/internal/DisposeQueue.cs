// Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
// PROPRIETARY/CONFIDENTIAL
// This software is the confidential and proprietary
// information of SAMSUNG ELECTRONICS ("Confidential Information"). You shall
// not disclose such Confidential Information and shall use it only in
// accordance with the terms of the license agreement you entered into with
// SAMSUNG ELECTRONICS.
//

using System;
using System.Collections.Generic;

namespace Tizen.NUI
{

    internal class DisposeQueue
    {
        private static readonly DisposeQueue _disposableQueue = new DisposeQueue();
        private List<IDisposable> _disposables = new List<IDisposable>();
        private Object _listLock = new object();
        /* temporary removal because of crash issue. this will be fixed later. 2017-04-04
        private EventThreadCallback _eventThreadCallback;
        private EventThreadCallback.CallbackDelegate _disposeQueueProcessDisposablesDelegate;
        */
        private DisposeQueue()
        {
        }

        ~DisposeQueue()
        {
        }

        public static DisposeQueue Instance
        {
            get { return _disposableQueue; }
        }

        public void Initialize()
        {
            /* temporary removal because of crash issue. this will be fixed later. 2017-04-04
            _disposeQueueProcessDisposablesDelegate = new EventThreadCallback.CallbackDelegate(ProcessDisposables);
            _eventThreadCallback = new EventThreadCallback(_disposeQueueProcessDisposablesDelegate);
            */
        }

        public void Add(IDisposable disposable)
        {
            lock(_listLock)
            {
                _disposables.Add(disposable);
            }

            /* temporary removal because of crash issue. this will be fixed later. 2017-04-04
            _eventThreadCallback.Trigger();
            */
        }

        private void ProcessDisposables()
        {
            lock(_listLock)
            {
                foreach (IDisposable disposable in _disposables)
                {
                    disposable.Dispose();
                }
                _disposables.Clear();
            }
        }
    }
}
