using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// Gets the extra data.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class DefaultAnimationBroker : FrameBrokerBase
    {
        private Window window;
        private ImageView imgView;

        /// <summary>
        /// Gets the extra data.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DefaultAnimationBroker(Window window) : base(window)
        {
            this.window = window;
        }

        /// <summary>
        /// Gets the extra data.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnFrameResumed(FrameData frame)
        {
            base.OnFrameResumed(frame);
            imgView = frame.Image;
            imgView.Size = window.Size;
            window.Add(imgView);

            Animation ani = new Animation(500);
            if (frame.DirectionForward)
            {
                imgView.Opacity = 0.0f;
                ani.AnimateTo(imgView, "Opacity", 1.0f);
            }
            else
            {
                imgView.Opacity = 1.0f;
                ani.AnimateTo(imgView, "Opacity", 0.0f);
            }
            ani.Play();
            ani.Finished += Ani_Finished;
            StartAnimation();
        }

        private void Ani_Finished(object sender, EventArgs e)
        {
            FinishAnimation();
            imgView.Unparent();
            imgView.Dispose();
            imgView = null;
        }
    }
}
