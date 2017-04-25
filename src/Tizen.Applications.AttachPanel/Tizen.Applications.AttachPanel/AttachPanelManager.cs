using System;
using System.Collections.Generic;

namespace Tizen.Applications.AttachPanel
{
    public partial class AttachPanel
    {
        private void StateEventListenStart()
        {
            Interop.AttachPanel.ErrorCode err = 0;

            SetEventListener = (attachPanel, eventType, eventInfo, userData) =>
            {
                _eventEventHandler?.Invoke(null, new StateEventArgs(attachPanel, (EventType)eventType, eventInfo, userData));
            };
            err = Interop.AttachPanel.SetEventCb(_attachPanel, SetEventListener, IntPtr.Zero);
            checkException(err);
        }
        private void StateEventListenStop()
        {
            Interop.AttachPanel.ErrorCode err = 0;
            err =  Interop.AttachPanel.UnsetEventCb(_attachPanel);
            checkException(err);
        }

        private void ResultEventListenStart()
        {
            Interop.AttachPanel.ErrorCode err = 0;
            SetResultListener = (attachPanel, category, resulthandler, resultCode, userData) =>
            {
                SafeAppControlHandle handle = new SafeAppControlHandle(resulthandler, false);
                AppControl result = new AppControl(handle);
                _resultEventHandler?.Invoke(null, new ResultEventArgs(attachPanel, (ContentCategory)category, result, (AppControlReplyResult)resultCode, userData));
            };
            err = Interop.AttachPanel.SetResultCb(_attachPanel, SetResultListener, IntPtr.Zero);
            checkException(err);
        }

        private void ResultEventListenStop()
        {
            Interop.AttachPanel.ErrorCode err = 0;
            err = Interop.AttachPanel.UnsetResultCb(_attachPanel);
            checkException(err);
        }

        internal static void checkException(Interop.AttachPanel.ErrorCode err)
        {
            switch (err)
            {
                case Interop.AttachPanel.ErrorCode.InvalidParameter:
                    throw new InvalidOperationException("Invalid parameter error at unmanaged code");
                case Interop.AttachPanel.ErrorCode.OutOfMemory:
                    throw new InvalidOperationException("Out of Memory");
                case Interop.AttachPanel.ErrorCode.PermissionDenied:
                    throw new UnauthorizedAccessException();
                case Interop.AttachPanel.ErrorCode.AlreadyExists:
                    throw new InvalidOperationException("Already Exists");
                case Interop.AttachPanel.ErrorCode.NotInitialized:
                    throw new InvalidOperationException("Not initialized");
                case Interop.AttachPanel.ErrorCode.UnsupportedContentCategory:
                    throw new InvalidOperationException("Unsupported Content Category");
                case Interop.AttachPanel.ErrorCode.AlreadyDestroyed:
                    throw new InvalidOperationException("Already Destroyed");
            }
        }
    }
}
