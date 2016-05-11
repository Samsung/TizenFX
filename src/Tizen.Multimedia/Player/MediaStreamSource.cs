using System;

namespace Tizen.Multimedia
{
	public class MediaStreamSource
	{

		/// <summary>
		/// Get audio stream configuration.
		/// </summary>
		/// <value> Audio StreamConfiguration </value>
		public MediaStreamConfiguration AudioConfiguration 
		{
			get
			{
				return _audioConfiguration;
			}
		}

		/// <summary>
		/// Get video stream configuration.
		/// </summary>
		/// <value> Video StreamConfiguration </value>
		public MediaStreamConfiguration VideoConfiguration 
		{
			get
			{
				return _videoConfiguration;
			}
		}

		public MediaStreamSource ()
		{
		}

		/// <summary>
		/// Get/Set Media format.
		/// </summary>
		/// <value> AudioMediaFormat </value>
		/// TODO: implement media format
		//MediaFormat AudioMediaFormat {set; get;}

		/// <summary>
		/// Get/Set Media format.
		/// </summary>
		/// <value> VideoMediaFormat </value>
		/// TODO: implement media format
		//MediaFormat VideoMediaFormat {set; get;}


		internal MediaStreamConfiguration _audioConfiguration;
		internal MediaStreamConfiguration _videoConfiguration;
	}
}

