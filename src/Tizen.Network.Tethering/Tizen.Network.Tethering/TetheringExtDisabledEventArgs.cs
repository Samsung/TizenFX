using System;

namespace Tizen.Network.Tethering
{
    public class TetheringExtDisabledEventArgs : EventArgs
    {
        private int _result;
        private TetheringDisabledCause _cause;

        internal TetheringExtDisabledEventArgs(int result, TetheringDisabledCause cause)
        {
            _result = result;
            _cause = cause;
        }

        public int Result
        {
            get
            {
                return _result;
            }
        }

        public TetheringDisabledCause Cause
        {
            get
            {
                return _cause;
            }
        }
    } 
}
