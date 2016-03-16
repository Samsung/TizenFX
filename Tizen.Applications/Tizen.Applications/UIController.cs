/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;
using Tizen.UI;

namespace Tizen.Applications
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class UIController : Controller, IUIContext
    {
        private bool _isResumed = false;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler Resumed;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler Paused;

        /// <summary>
        /// 
        /// </summary>
        public Window Window { get; internal set; }

        internal Guid TaskId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        protected internal Page MainPage { get; set; }

        public string ResolveResourcePath(string res)
        {
            throw new NotImplementedException();
        }

        internal override void SendCreate()
        {
            Window = OnPrepareWindow();
            base.SendCreate();
        }

        internal void SendPause()
        {
            if (_isResumed)
            {
                if (Paused != null)
                {
                    OnPause();
                    Paused(this, EventArgs.Empty);
                }
                _isResumed = false;
            }
        }

        internal void SendResume()
        {
            if (!_isResumed)
            {
                if (Resumed != null)
                {
                    OnResume();
                    Resumed(this, EventArgs.Empty);
                }
                _isResumed = true;
                MainPage.Show();
            }
        }

        protected virtual Window OnPrepareWindow()
        {
            return Window;
        }

        protected virtual void OnResume()
        {
        }

        protected virtual void OnPause()
        {
        }

        protected override void Finish()
        {
            Application.StopController(this);
        }
    }
}

