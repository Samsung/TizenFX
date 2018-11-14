using System;
using System.Collections.Generic;
using System.Text;
using static Interop.EventSystem;

namespace Tizen.Applications
{
    /// <summary>
    /// The EventSystem API provides functions to receive events.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class EventSystem : IDisposable
    {
        internal IntPtr _handler;
        private bool _listening = false;
        private readonly string _eventName = null;
        private Interop.EventSystem.EventCallback _eventCallBack;

        /// <summary>
        /// Initializes the instance of the Event class.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <exception cref="System.ArgumentException">Thrown when eventName is null or empty.</exception>
        /// <example>
        /// <code>
        /// EventSystem ev = new EventSystem("tizen.system.event.screen_autorotate_state");
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        public EventSystem(string eventName)
        {
            if (String.IsNullOrEmpty(eventName))
            {
                throw new InvalidOperationException("null event name");
            }
            _eventName = eventName;
        }

        /// <summary>
        /// Destructor of the Event class.
        /// </summary>
        ~EventSystem()
        {
            Dispose(false);
        }

        /// <summary>
        /// Called when a event is received.
        /// </summary>
        /// <example>
        /// <code>
        /// EventSystem ev = new EventSystem("tizen.system.event.screen_autorotate_state");
        /// ev.EventReceived += EventReceivedCallback;
        /// static void EventReceivedCallback(EventSystemArgs e)
        /// {
        ///     Console.WriteLine("Event Received ");
        /// }
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<EventSystemArgs> EventReceived;

        /// <summary>
        /// The name of the event.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string EventName
        {
            get
            {
                return _eventName;
            }
        }
        
        /// <summary>
        /// If true, the event is listening, otherwise false.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public bool Listening
        {
            get
            {
                return _listening;
            }
        }

        /// <summary>
        /// Listening event.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown when portName is already used, when there is an I/O error.</exception>
        /// <exception cref="System.ArgumentException">Thrown when there is an invalid parameter.</exception>
        /// <exception cref="System.OutOfMemoryException">Thrown when out of memory.</exception>
        /// <example>
        /// <code>
        /// EventSystem ev = new EventSystem("tizen.system.event.screen_autorotate_state");
        /// ev.EventReceived += EventReceivedCallback;
        /// ev.Listen();
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        public void Listen()
        {
            _eventCallBack = (string eventName, IntPtr eventData, IntPtr userData) =>
            {   
                EventSystemArgs args = new EventSystemArgs()
                {
                    EventSystemData = new Bundle(new SafeBundleHandle(eventData, false))
                };                
                EventReceived?.Invoke(this, args);
            };

            Interop.EventSystem.AddEventHandler(_eventName, _eventCallBack, IntPtr.Zero, out _handler);
            _listening = true;
        }

        /// <summary>
        /// Stop listening event.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown when event listening is already stopped or fail to remove handler</exception>
        /// <example>
        /// <code>
        /// EventSystem ev = new EventSystem("tizen.system.event.screen_autorotate_state");
        /// ev.EventReceived += EventReceivedCallback;
        /// ev.Listen();
        /// ev.StopListening();
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        public void StopListening()
        {
            if (!_listening)
            {
                throw new InvalidOperationException("Already stopped");
            }

            ErrorCode ret = Interop.EventSystem.RemoveEventHandler(_handler);
            if (ret != ErrorCode.None)
                throw new InvalidOperationException("fail to remove event handler");
            _listening = false;
        }

        /// <summary>
        /// Releases the unmanaged resources used by the EventSystem class specifying whether to perform a normal dispose operation.
        /// </summary>
        /// <param name="disposing">true for a normal dispose operation; false to finalize the handle.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (_listening)
            {
                try
                {
                    StopListening();
                }
                catch (Exception e)
                {
                    Log.Warn(GetType().Namespace, "Exception in Dispose :" + e);
                }
            }
        }

        /// <summary>
        /// Releases all resources used by the EventSystem class.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
