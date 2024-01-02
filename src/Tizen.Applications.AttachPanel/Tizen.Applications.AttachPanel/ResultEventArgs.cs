using System;

namespace Tizen.Applications.AttachPanel
{
    /// <summary>
    /// A class for the event arguments of the result event.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    [Obsolete("Deprecated since API Level 12. Will be removed in API Level 14.")]
    public class ResultEventArgs : EventArgs
    {
        private readonly ContentCategory _category;
        private readonly AppControl _result;
        private readonly AppControlReplyResult _resultCode;

        internal ResultEventArgs(ContentCategory category, AppControl result, AppControlReplyResult resultCode)
        {
            _category = category;
            _result = result;
            _resultCode = resultCode;
        }

        /// <summary>
        /// Results are from the content category.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API Level 12. Will be removed in API Level 14.")]
        public ContentCategory Category
        {
            get
            {
                return _category;
            }
        }

        /// <summary>
        /// Property for the result.
        /// The caller application has to use the ExtraData property to get received data.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API Level 12. Will be removed in API Level 14.")]
        public AppControl Result
        {
            get
            {
                return _result;
            }
        }

        /// <summary>
        /// Property for the result of the AppControl.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated since API Level 12. Will be removed in API Level 14.")]
        public AppControlReplyResult ResultCode
        {
            get
            {
                return _resultCode;
            }
        }
    }
}
