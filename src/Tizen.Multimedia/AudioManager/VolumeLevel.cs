using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tizen.Multimedia
{
    public class VolumeLevel
    {                
        public int this[AudioType type]
        {
            get
            {
                int volume;
                int ret = Interop.Volume.GetVolume(type, out volume);
                if (ret != 0)
                {
                    AudioManagerErrorFactory.CheckAndThrowException(ret, "unable to get volume");
                    Console.WriteLine("Get Volume Error: " + (AudioManagerError)ret);
                }  

                return volume;
            }
            set
            {
                int ret = Interop.Volume.SetVolume(type, value);
                if (ret != 0)
                {
                    AudioManagerErrorFactory.CheckAndThrowException(ret, "unable to set volume");
                    Console.WriteLine("Set Volume Error: " + (AudioManagerError)ret);
                }               
            }


        } 
    }
}
