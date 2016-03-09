/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;

namespace Tizen.Applications
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class Service : Context
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="actorType"></param>
        /// <param name="control"></param>
        protected override void StartActor(Type actorType, AppControl control)
        {
            Application.StartActor(null, actorType, control);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void Finish()
        {
            Application.StopService(GetType());
        }
    }
}
