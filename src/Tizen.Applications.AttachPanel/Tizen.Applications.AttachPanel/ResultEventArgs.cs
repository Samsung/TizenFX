using System;

namespace Tizen.Applications.AttachPanel
{
    public class ResultEventArgs : EventArgs
    {
        private readonly IntPtr _attachPanel;
        private readonly ContentCategory _category;
        private readonly AppControl _result;
        private readonly AppControlReplyResult _resultCode;
        private readonly IntPtr _userData;

        internal ResultEventArgs(IntPtr attachPanel, ContentCategory category, AppControl result, AppControlReplyResult resultCode, IntPtr userData)
        {
            _attachPanel = attachPanel;
            _category = category;
            _result = result;
            _resultCode = resultCode;
            _userData = userData;
        }

        public IntPtr AttachPanel { get { return _attachPanel; } }

        public ContentCategory Category { get { return _category; } }

        public AppControl Result {  get { return _result; } }

        public AppControlReplyResult ResultCode { get { return _resultCode; } }

        public IntPtr UserData { get { return _userData; } }
    }
}
