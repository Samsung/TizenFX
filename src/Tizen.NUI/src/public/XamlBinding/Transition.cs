using System.ComponentModel;
using static Tizen.NUI.Animation;

namespace Tizen.NUI
{
    /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Transition : BaseHandle
    {
        private string name;

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        private int duration;

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Duration
        {
            get
            {
                return duration;
            }
            set
            {
                duration = value;
            }
        }

        private int loopCount;

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int LoopCount
        {
            get
            {
                return loopCount;
            }
            set
            {
                loopCount = value;
            }
        }

        private EndActions endAction;

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public EndActions EndAction
        {
            get
            {
                return endAction;
            }
            set
            {
                endAction = value;
            }
        }

        private string[] _properties = null;

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string[] Properties
        {
            get
            {
                return _properties;
            }
            set
            {
                _properties = value;
            }
        }

        private string[] _destValue = null;

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string[] DestValue
        {
            get
            {
                return _destValue;
            }
            set
            {
                _destValue = value;
            }
        }

        private int[] _startTime = null;

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int[] StartTime
        {
            get
            {
                return _startTime;
            }
            set
            {
                _startTime = value;
            }
        }

        private int[] _endTime = null;

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int[] EndTime
        {
            get
            {
                return _endTime;
            }
            set
            {
                _endTime = value;
            }
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Animation CreateAnimation()
        {
            Animation ani = new Animation();

            ani.Duration = Duration;
            ani.LoopCount = LoopCount;
            ani.EndAction = EndAction;

            ani.Properties = Properties;
            ani.DestValue = DestValue;
            ani.StartTime = StartTime;
            ani.EndTime = EndTime;

            return ani;
        }
    }
}