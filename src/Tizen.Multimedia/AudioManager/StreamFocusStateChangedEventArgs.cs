using System;

namespace Tizen.Multimedia
{
    
    /// <summary>
    /// Class extending EventArgs and contains the necessary parameters to passed to FocusStateChanged event handler
    /// </summary>
    public class StreamFocusStateChangedEventArgs : EventArgs
    {
        private AudioStreamFocusChangedReason _reason;
        private string _extraInformation;

        internal StreamFocusStateChangedEventArgs(AudioStreamFocusChangedReason reason, string extraInformation)
        {
            _reason = reason;
            _extraInformation = extraInformation;
        }

        /// <summary>
        /// The reason for state change of the focus
        /// </summary>
        public AudioStreamFocusChangedReason FocusChangedReason 
        {
            get
            {
                return _reason;
            } 
        }
        
        /// <summary>
        /// The extra information
        /// </summary>
        public string ExtraInfoformation
        {
            get
            {
                return _extraInformation;
            } 
        }
    }
}
