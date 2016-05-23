using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Class extending EventArgs and contains the necessary parameters to passed to FocusStateWatch event handler 
    /// </summary>
    public class FocusStateChangedEventArgs : EventArgs
    {
        private AudioStreamFocusOptions _focusMask;
        private AudioStreamFocusState _focusState;
        private AudioStreamFocusChangedReason _reason;
        private string _extraInformation;

        internal FocusStateChangedEventArgs(AudioStreamFocusOptions focusMask, AudioStreamFocusState focusState, AudioStreamFocusChangedReason reason, string extraInformation)
        {
            _focusMask = focusMask;
            _focusState = focusState;
            _reason = reason;
            _extraInformation = extraInformation;
        }

        /// <summary>
        /// The changed focus mask
        /// </summary>
        public AudioStreamFocusOptions FocusMask
        {
            get
            {
                return _focusMask;
            }

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
    }
}
