/// This File contains the Api's related to the CreateThumbnailResult class
///
/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc.("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.Content.MediaContent
{
    /// <summary>
    /// CreateThumbnailResult class API gives the information related to the thumbnail created by CreateThumbnail API</summary>
    public class CreateThumbnailResult
    {
        internal CreateThumbnailResult()
        {
            //Empty
        }

        /// <summary>
        /// Gives the Result of the opeartion.
        /// </summary>
        /// <value>
        /// It is the Result state of the operation performed.</value>
        public MediaContentError Result
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gives the Path of the thumbnail which is generated.
        /// </summary>
        /// <value>
        /// string path of the thumbnail.</value>
        public string FilePath
        {
            get;
            internal set;
        }
    }
}
