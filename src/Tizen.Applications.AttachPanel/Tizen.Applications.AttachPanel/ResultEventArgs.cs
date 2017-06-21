using System;

namespace Tizen.Applications.AttachPanel
{
    /// <summary>
    /// Class for event arguments of the result event
    /// </summary>
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

        /// <summary>
        ///  Property for attach panel object.
        /// </summary>
        public IntPtr AttachPanel { get { return _attachPanel; } }

        /// <summary>
        /// Results are from the content category.
        /// </summary>
        public ContentCategory Category { get { return _category; } }

        /// <summary>
        /// Property for result
        /// The caller app has to use ExtraData property to get received data.
        /// </summary>
        public AppControl Result {  get { return _result; } }

        /// <summary>
        /// Property for result of AppControl
        /// </summary>
        public AppControlReplyResult ResultCode { get { return _resultCode; } }

        /// <summary>
        /// Property for user data
        /// </summary>
        public IntPtr UserData { get { return _userData; } }
    }
}
