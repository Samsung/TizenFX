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

namespace NUI
{

    public class DisposeQueue
    {
        private static DisposeQueue _disposableQueue = new DisposeQueue();
        private List<IDisposable> _disposables = new List<IDisposable>();
        private Object _listLock = new object();
        private delegate int ProcessDisposablesDelegate(IntPtr ptr);
        private ProcessDisposablesDelegate _disposequeueProcessDisposablesDelegate;

        private DisposeQueue()
        {
          _disposequeueProcessDisposablesDelegate = new ProcessDisposablesDelegate(ProcessDisposables);
          Application.Instance.AddIdle(_disposequeueProcessDisposablesDelegate);
        }

        ~DisposeQueue()
        {
        }

        public static DisposeQueue Instance
        {
            get { return _disposableQueue; }
        }

        public void Add(IDisposable disposable)
        {
            lock(_listLock)
            {
                _disposables.Add(disposable);
            }
        }

        private int ProcessDisposables(IntPtr ptr)
        {
            lock(_listLock)
            {
                foreach (IDisposable disposable in _disposables)
                {
                    disposable.Dispose();
                }
                _disposables.Clear();
            }
            return 0;
        }
    }
}
