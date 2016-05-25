using System;

namespace Tizen.Multimedia
{
   
    /// <summary>
    /// The Stream Policy API provides functions to control a sound stream.
    /// </summary>
    public class AudioStreamPolicy : IDisposable
    {
        private IntPtr _streamInfo;
        private AudioStreamType _streamType;
        private bool _disposed = false;
        private static int _focusStateWatchCounter = 0;
        
        private static EventHandler<FocusStateChangedEventArgs> _focusStateWatchForPlayback;
        private static Interop.SoundStreamFocusStateWatchCallback _focusStateWatchCallback;
        private static EventHandler<FocusStateChangedEventArgs> _focusStateWatchForRecording;
        private EventHandler<StreamFocusStateChangedEventArgs> _focusStateChanged;
        private Interop.SoundStreamFocusStateChangedCallback _focusStateChangedCallback;

        /// <summary>
        /// Auto focus reacquisition property
        /// </summary>
        /// <remarks>
        /// The focus reacquistion is set as default. If you don't want to reacquire the focus you've lost automatically, disable the focus reacqusition setting by using this API and vice versa.
        /// </remarks>
        public bool FocusReacquisitionEnabled 
        {
            get 
            {
                bool enabled;
				int ret = Interop.StreamPolicy.GetFocusReacquisition(_streamInfo, out enabled);
                AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to get focus reacquisition");
				//Console.Write("get focus reacquisition: " + ret);
                return enabled;
            }
            set
            {
				int ret = Interop.StreamPolicy.SetFocusReacquisition(_streamInfo, value);
				AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to set focus reacquisition");
            }
        }

        /// <summary>
        ///  The sound type of the stream information. 
        /// </summary>
        public AudioType Type 
        {            
            get 
            {
                AudioType soundType;
				int ret = Interop.StreamPolicy.GetSoundType(_streamInfo, out soundType);
                AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to get sound type");
                return soundType;
            } 
        }

        /// <summary>
        /// The state of focus for playback. 
        /// </summary>
        public AudioStreamFocusState PlaybackFocusState 
        { 
            get 
            {
                AudioStreamFocusState stateForPlayback;
                AudioStreamFocusState stateForRecording;
                int ret = Interop.StreamPolicy.GetFocusState(_streamInfo, out stateForPlayback, out stateForRecording);
                AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to get focus state");

                return stateForPlayback;
            } 
        }

        /// <summary>
        /// The state of focus for recording. 
        /// </summary>
        public AudioStreamFocusState RecordingFocusState
        {
            get
            {
                AudioStreamFocusState stateForPlayback;
                AudioStreamFocusState stateForRecording;
                int ret = Interop.StreamPolicy.GetFocusState(_streamInfo, out stateForPlayback, out stateForRecording);
                AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to get focus state");
                return stateForRecording;
            } 
        }

       
        /// <summary>
        /// Constructor: creates and returns a StreamPolicy object (to SoundManager class)
        /// </summary>
        /// <remarks>
        /// To apply the stream policy according to this stream information, this object should be passed to other APIs
        /// related to playback or recording. (e.g., player, wav-player, audio-io, etc.)
        /// </remarks>
        /// <param name="streamType">Type of sound stream for which policy needs to be created</param>
        /// <returns>StreamPolicy object</returns>
        public AudioStreamPolicy(AudioStreamType streamType)
        {            
            _streamType = streamType;
            _focusStateChangedCallback = (IntPtr streamInfo, int reason, string extraInfo, IntPtr userData) =>
            {
                StreamFocusStateChangedEventArgs eventArgs = new StreamFocusStateChangedEventArgs((AudioStreamFocusChangedReason)reason, extraInfo);
                _focusStateChanged?.Invoke(this, eventArgs);
            };

            int ret = Interop.StreamPolicy.CreateStreamInformation((int)streamType, _focusStateChangedCallback, IntPtr.Zero, out _streamInfo);
            AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to create stream information");
        }

        /// <summary>
        /// Acquires the stream focus.
        /// </summary>
        /// <param name="focusMask">The focus mask that user wants to acquire</param>
        /// <param name="extraInformation">The Extra information for this request (optional, this can be null)</param>
        /// <remarks>
        /// Do not call this API within event handlers of FocuStateChanged and StreamFocusStateWatch else it will throw and exception
        /// </remarks>
        public void AcquireFocus(AudioStreamFocusOptions options, string extraInformation)
        {

            int ret = Interop.StreamPolicy.AcquireFocus(_streamInfo, options, extraInformation);
            Console.WriteLine("Acquire focus return {0}", ret);
            AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to acquire focus");
        }

        /// <summary>
        /// Releases the acquired focus.
        /// </summary>
        /// <param name="options">The focus mask that user wants to release</param>
        /// <param name="?">he Extra information for this request (optional, this can be null)</param>
        /// <remarks>
        /// Do not call this API within event handlers of FocuStateChanged and StreamFocusStateWatch else it will throw and exception
        /// </remarks>
        public void ReleaseFocus(AudioStreamFocusOptions options, string extraInformation)
        {
            int ret = Interop.StreamPolicy.ReleaseFocus(_streamInfo, options, extraInformation);
            Console.WriteLine("Release focus return {0}", ret);
            AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to release focus");
        }
        
        

        /// <summary>
        /// Applies the stream routing.
        /// </summary>
        /// <remarks>
        /// If the stream has not been made yet, this setting will be applied when the stream starts to play.
        /// Precondition: Call AddDeviceForStreamRouting() before calling this function.
        /// </remarks>
        public void ApplyStreamRouting()
        {
            int ret = Interop.StreamPolicy.ApplyStreamRouting(_streamInfo);
            Console.WriteLine("Apply Routing: " + (AudioManagerError)ret);
            AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to apply stream routing");
        }

        /// <summary>
        /// Adds the device to the stream information for the stream routing.
        /// </summary>
        /// <remarks>
        /// Remarks: Use SoundManager.GetCurrentDeviceList() to get the device.
        /// The available types of the StreamInfo for this API are SoundStreamTypeVoip and SoundStreamTypeMediaExternalOnly.
        /// Postcondition: You can apply this setting by calling ApplyStreamRouting().
        /// </remarks>
        /// <param name="soundDevice">The device item from the current sound devices list.</param>
        public void AddDeviceForStreamRouting(AudioDevice soundDevice)
        {
            int ret = Interop.StreamPolicy.AddDeviceForStreamRouting(_streamInfo, soundDevice._handle);
            Console.WriteLine("Add stream routing: " + (AudioManagerError)ret);
            AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to add device for stream routing");
        }

        /// <summary>
        /// Removes the device to the stream information for the stream routing.
        /// </summary>
        /// <remarks>
        /// Remarks: Use SoundManager.GetCurrentDeviceList() to get the device.
        /// The available types of the StreamInfo for this API are SoundStreamTypeVoip and SoundStreamTypeMediaExternalOnly.
        /// Postcondition: You can apply this setting by calling ApplyStreamRouting().
        /// </remarks>
        /// <param name="soundDevice">The device item from the current sound devices list.</param>
        public void RemoveDeviceForStreamRouting(AudioDevice soundDevice)
        {
            int ret = Interop.StreamPolicy.RemoveDeviceForStreamRouting(_streamInfo, soundDevice._handle);
            Console.WriteLine("Remove stream routing: " + (AudioManagerError)ret);
            AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to remove device for stream routing");
        }
    

        /// <summary>
        /// Registers the watch function to be invoked when the focus state for each sound stream type is changed regardless of the process.
        /// <remarks> 
        /// Remarks: You can set this only once per process.
        /// </remarks>
        /// </summary>
        public static event EventHandler<FocusStateChangedEventArgs> PlaybackFocusStateWatch
        {
            add
            {
                if (_focusStateWatchCounter == 0)
                {
                    RegisterFocusStateWatchEvent();
                }
                _focusStateWatchCounter++;
                _focusStateWatchForPlayback += value;
            }
            remove
            {
                _focusStateWatchForPlayback -= value;
                _focusStateWatchCounter--;
                if (_focusStateWatchCounter == 0)
                {
                    UnregisterFocusStateWatch();
                }
            }
        }

        /// <summary>
        /// Registers the watch function to be invoked when the focus state for each sound stream type is changed regardless of the process.
        /// <remarks> 
        /// Remarks: You can set this only once per process.
        /// </remarks>
        /// </summary>
        public static event EventHandler<FocusStateChangedEventArgs> RecordingFocusStateWatch
        {
            add
            {
                if (_focusStateWatchCounter == 0)
                {
                    RegisterFocusStateWatchEvent();
                }
                _focusStateWatchCounter++;
                _focusStateWatchForRecording += value;
            }
            remove
            {
                _focusStateWatchForRecording -= value;
                _focusStateWatchCounter--;
                if (_focusStateWatchCounter == 0)
                {
                    UnregisterFocusStateWatch();
                }
            }
        }

        private static void RegisterFocusStateWatchEvent()
        {
            _focusStateWatchCallback = (AudioStreamFocusOptions options, AudioStreamFocusState focusState, AudioStreamFocusChangedReason reason, string extraInfo, IntPtr userData) =>
                {
                    FocusStateChangedEventArgs eventArgs = new FocusStateChangedEventArgs(focusState, reason, extraInfo);
                    if (options == AudioStreamFocusOptions.Playback)
                    {
                        _focusStateWatchForPlayback?.Invoke(null, eventArgs);
                    }
                    else if (options == AudioStreamFocusOptions.Recording)
                    {
                        _focusStateWatchForRecording?.Invoke(null, eventArgs);
                    }
                    else if (options == (AudioStreamFocusOptions.Playback | AudioStreamFocusOptions.Recording))
                    {
                        _focusStateWatchForPlayback?.Invoke(null, eventArgs);
                        _focusStateWatchForRecording?.Invoke(null, eventArgs);
                    }
                };
            int ret = Interop.StreamPolicy.SetFocusStateWatchCallback(AudioStreamFocusOptions.Playback | AudioStreamFocusOptions.Recording, _focusStateWatchCallback, IntPtr.Zero);
			AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to set focus state watch callback");
        }

        private static void UnregisterFocusStateWatch()
        {
            int ret = Interop.StreamPolicy.UnsetFocusStateWatchCallback();
            AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to unset focus state watch callback");
        }

        /// <summary>
        /// Registers function to be called when the state of focus that belongs to the stream_info is changed.
        /// </summary>
        /// <remarks> 
        /// Remarks: This function is issued in the internal thread of the sound manager. Therefore it is recommended not to call UI update function in this function.
        /// Postcondition : FocusStateForPlayback and FokcusStateForRecording in the registered event handler to figure out how the focus state of the StreamInfo has been changed.
        /// </remarks>
        public event EventHandler<StreamFocusStateChangedEventArgs> StreamFocusStateChanged
       {
            add
            {
                _focusStateChanged += value;
            }
            remove
            {
                _focusStateChanged -= value;
            }
        }

        ~AudioStreamPolicy()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
                 if (!_disposed)
                 {
                     if (disposing)
                     {
                         // to be used if there are any other disposable objects
                     }
                     if (_streamInfo != IntPtr.Zero)      
                     {
                         Interop.StreamPolicy.DestroyStreamInformation(_streamInfo);  // Destroy the handle
                         _streamInfo = IntPtr.Zero;
                     }
                     _disposed = true;
                 } 
        }

       
    }

   
}
