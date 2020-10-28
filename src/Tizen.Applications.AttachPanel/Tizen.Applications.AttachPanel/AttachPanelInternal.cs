using System;
using System.Collections.Generic;
using Tizen.System;

namespace Tizen.Applications.AttachPanel
{
    /// <summary>
    /// Attach panel internal implementation.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public partial class AttachPanel
    {
        private IntPtr s_attachPanel = IntPtr.Zero;

        private event EventHandler<StateEventArgs> s_eventEventHandler;

        private event EventHandler<ResultEventArgs> s_resultEventHandler;

        private Interop.AttachPanel.AttachPanelEventCallback s_setEventListener;
        private Interop.AttachPanel.AttachPanelResultCallback s_setResultListener;

        private void StateEventListenStart()
        {
            s_setEventListener = (attachPanel, eventType, eventInfo, userData) =>
            {
                s_eventEventHandler?.Invoke(null, new StateEventArgs((EventType)eventType));
            };
            var err = Interop.AttachPanel.SetEventCb(s_attachPanel, s_setEventListener, IntPtr.Zero);
            CheckException(err);
        }

        private void StateEventListenStop()
        {
            var err = Interop.AttachPanel.UnsetEventCb(s_attachPanel);
            CheckException(err);
        }

        private void ResultEventListenStart()
        {
            s_setResultListener = (attachPanel, category, resulthandler, resultCode, userData) =>
            {
                SafeAppControlHandle handle = new SafeAppControlHandle(resulthandler, false);
                AppControl result = new AppControl(handle);
                s_resultEventHandler?.Invoke(null, new ResultEventArgs((ContentCategory)category, result, (AppControlReplyResult)resultCode));
            };
            var err = Interop.AttachPanel.SetResultCb(s_attachPanel, s_setResultListener, IntPtr.Zero);
            CheckException(err);
        }

        private void ResultEventListenStop()
        {
            var err = Interop.AttachPanel.UnsetResultCb(s_attachPanel);
            CheckException(err);
        }

        internal static void CheckException(Interop.AttachPanel.ErrorCode err)
        {
            switch (err)
            {
                case Interop.AttachPanel.ErrorCode.InvalidParameter:
                    throw new ArgumentOutOfRangeException("Invalid parameter");
                case Interop.AttachPanel.ErrorCode.OutOfMemory:
                    throw new OutOfMemoryException("Out of Memory");
                case Interop.AttachPanel.ErrorCode.PermissionDenied:
                    throw new UnauthorizedAccessException();
                case Interop.AttachPanel.ErrorCode.AlreadyExists:
                    throw new InvalidOperationException("AttachPanel is already exists");
                case Interop.AttachPanel.ErrorCode.NotInitialized:
                    throw new InvalidOperationException("AttachPanel is not initialized");
                case Interop.AttachPanel.ErrorCode.UnsupportedContentCategory:
                    throw new NotSupportedException("Unsupported content category");
                case Interop.AttachPanel.ErrorCode.AlreadyDestroyed:
                    throw new InvalidOperationException("AttachPanel is already destroyed");
                case Interop.AttachPanel.ErrorCode.NotSupported:
                    throw new NotSupportedException("AttachPanel is not supported in this device");
            }
        }

        internal static bool IsAttachPanelSupported()
        {
            return Information.TryGetValue("http://tizen.org/feature/attach_panel", out bool isAttachPanelSupported) && isAttachPanelSupported;
        }

        internal bool IsInitialized()
        {
            return s_attachPanel != IntPtr.Zero;
        }
    }
}
