using System;

namespace Tizen.Multimedia
{
    public class MaxVolumeLevel
    {
       public int this[AudioType type]
        {
            get
            {
                int maxVolume;
                int ret = Interop.Volume.GetMaxVolume(type, out maxVolume);
                if (ret != 0)
                {
                   	AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to get max volume");
                    Console.WriteLine("Max Volume Error: " + (AudioManagerError)ret);
                }

                return maxVolume;
            }
            
        }

    }
}
