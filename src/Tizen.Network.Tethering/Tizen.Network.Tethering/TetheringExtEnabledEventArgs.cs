using System;

namespace Tizen.Network.Tethering
{
    public class TetheringExtEnabledEventArgs : EventArgs
    {
        private int _result;
        private bool _isRequested;

        internal TetheringExtEnabledEventArgs(int result, bool isRequested)
        {
            _result = result;
            _isRequested = isRequested;
        }


        public int Result
        {
            get
            {
                return _result;
            }
        }

        public bool Requested
        {
            get
            {
                return _isRequested;
            }
        }
    } 
}
