using System;
using System.Collections.Generic;

namespace Tizen.Applications.AttachPanel
{
    /// <summary>
    /// Attach panel internal implementation
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public partial class AttachPanel
    {
        private static IntPtr _attachPanel;
        private bool isCreationSucceed;

        private static event EventHandler<StateEventArgs> _eventEventHandler;
        private static event EventHandler<ResultEventArgs> _resultEventHandler;

        private static Interop.AttachPanel.AttachPanelEventCallback SetEventListener;
        private static Interop.AttachPanel.AttachPanelResultCallback SetResultListener;

        private void StateEventListenStart()
        {
            Interop.AttachPanel.ErrorCode err = 0;

            SetEventListener = (attachPanel, eventType, eventInfo, userData) =>
            {
                _eventEventHandler?.Invoke(null, new StateEventArgs((EventType)eventType));
            };
            err = Interop.AttachPanel.SetEventCb(_attachPanel, SetEventListener, IntPtr.Zero);
            CheckException(err);
        }

        private void StateEventListenStop()
        {
            Interop.AttachPanel.ErrorCode err = 0;
            err = Interop.AttachPanel.UnsetEventCb(_attachPanel);
            CheckException(err);
        }

        private void ResultEventListenStart()
        {
            Interop.AttachPanel.ErrorCode err = 0;
            SetResultListener = (attachPanel, category, resulthandler, resultCode, userData) =>
            {
                SafeAppControlHandle handle = new SafeAppControlHandle(resulthandler, false);
                AppControl result = new AppControl(handle);
                _resultEventHandler?.Invoke(null, new ResultEventArgs((ContentCategory)category, result, (AppControlReplyResult)resultCode));
            };
            err = Interop.AttachPanel.SetResultCb(_attachPanel, SetResultListener, IntPtr.Zero);
            CheckException(err);
        }

        private void ResultEventListenStop()
        {
            Interop.AttachPanel.ErrorCode err = 0;
            err = Interop.AttachPanel.UnsetResultCb(_attachPanel);
            CheckException(err);
        }

        internal static void CheckException(Interop.AttachPanel.ErrorCode err)
        {
            switch (err)
            {
                case Interop.AttachPanel.ErrorCode.InvalidParameter:
                    throw new ArgumentOutOfRangeException("Invalid parameter error at unmanaged code");
                case Interop.AttachPanel.ErrorCode.OutOfMemory:
                    throw new OutOfMemoryException("Out of Memory");
                case Interop.AttachPanel.ErrorCode.PermissionDenied:
                    throw new UnauthorizedAccessException();
                case Interop.AttachPanel.ErrorCode.AlreadyExists:
                    throw new InvalidOperationException("Already Exists");
                case Interop.AttachPanel.ErrorCode.NotInitialized:
                    throw new InvalidOperationException("Not initialized");
                case Interop.AttachPanel.ErrorCode.UnsupportedContentCategory:
                    throw new NotSupportedException("Unsupported Content Category");
                case Interop.AttachPanel.ErrorCode.AlreadyDestroyed:
                    throw new InvalidOperationException("Already Destroyed");
            }
        }
    }
}
