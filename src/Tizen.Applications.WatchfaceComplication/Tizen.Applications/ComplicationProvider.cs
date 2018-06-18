using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.WatchfaceComplication
{
    abstract class ComplicationProvider
    {
        ComplicationProvider(string proivderId)
        {

        }

        protected virtual void OnDataUpdateRequest(string reqestAppId, ComplicationType type, Bundle contextData, Bundle sharedData)
        {

        }

        private int SetSharedDataType(Bundle sharedData, ComplicationType type)
        {
            return 0;
        }

        private int SetSharedDataShortText(Bundle sharedData, string shortText)
        {
            return 0;
        }

        private int SetSharedDataLongText(Bundle sharedData, string longText)
        {
            return 0;
        }

        public int NotifyUpdate()
        {
            ComplicationProviderTouchLaunch.IsTouchLaunch(null);

            return 0;
        }        
    }
}
