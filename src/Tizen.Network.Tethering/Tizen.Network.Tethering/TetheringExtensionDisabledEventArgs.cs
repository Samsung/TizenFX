using System;

namespace Tizen.Network.Tethering
{
    /// <summary>
    /// This class contains Tethering disabled event data.
    /// </summary>
    /// <since_tizen> 13 </since_tizen>
    public class TetheringExtensionDisabledEventArgs : EventArgs
    {
        private int _result;
        private TetheringDisabledCause _cause;

        internal TetheringExtensionDisabledEventArgs(int result, TetheringDisabledCause cause)
        {
            _result = result;
            _cause = cause;
        }

        /// <summary>
        /// This function returns wether tethering was successfully disabled or not.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public int Result
        {
            get
            {
                return _result;
            }
        }

        /// <summary>
        /// This function returns the cause for disabling of Tethering.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public TetheringDisabledCause Cause
        {
            get
            {
                return _cause;
            }
        }
    } 
}
