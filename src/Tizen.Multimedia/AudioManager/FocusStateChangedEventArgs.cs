using System;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Class extending EventArgs and contains the necessary parameters to passed to FocusStateWatch event handler 
    /// </summary>
    public class FocusStateChangedEventArgs : EventArgs
    {
        private AudioStreamFocusState _focusState;
        private AudioStreamFocusChangedReason _reason;
        private string _extraInformation;

        internal FocusStateChangedEventArgs(AudioStreamFocusState focusState, AudioStreamFocusChangedReason reason, string extraInformation)
        {
            _focusState = focusState;
            _reason = reason;
            _extraInformation = extraInformation;
        }

        /// <summary>
        /// The changed focus state
        /// </summary>
        public AudioStreamFocusState FocusState 
        {
            get
            {
                return _focusState;
            }
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
        public string ExtraInformation
        {
            get
            {
                return _extraInformation;
            }
        }
    }
}
