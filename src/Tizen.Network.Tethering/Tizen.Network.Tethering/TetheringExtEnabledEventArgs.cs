using System;

namespace Tizen.Network.Tethering
{
    /// <summary>
    /// This class contains Tethering enabled event data.
    /// </summary>
    /// <since_tizen> 13 </since_tizen>
    public class TetheringExtEnabledEventArgs : EventArgs
    {
        private int _result;
        private bool _isRequested;

        internal TetheringExtEnabledEventArgs(int result, bool isRequested)
        {
            _result = result;
            _isRequested = isRequested;
        }

        /// <summary>
        /// This function returns wether tethering was successfully enabled or not.
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
        /// This function returns wether Requested or not.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public bool Requested
        {
            get
            {
                return _isRequested;
            }
        }
    } 
}
