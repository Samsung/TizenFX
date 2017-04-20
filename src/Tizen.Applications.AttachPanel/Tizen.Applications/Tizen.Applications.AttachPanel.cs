using System;

namespace Tizen.Applications
{
    public class AttachPanel
    {
        IntPtr attachpanel;

        public AttachPanel(IntPtr conformant)
        {
            attachpanel = new IntPtr();
            Interop.AttachPanel.ErrorCode err = Interop.AttachPanel.CreateAttachPanel(conformant, ref attachpanel);
            checkException(err);
        }

        public int State
        {
            get
            {
                int state;
                Interop.AttachPanel.ErrorCode err = Interop.AttachPanel.GetState(attachpanel, out state);
                checkException(err);
                return state;
            }
        }
        public int Visible
        {
            get
            {
                int visible;
                Interop.AttachPanel.ErrorCode err = Interop.AttachPanel.GetVisibility(attachpanel, out visible);
                checkException(err);
                return visible;
            }
        }
        internal static void checkException(Interop.AttachPanel.ErrorCode err)
        {
            switch (err)
            {
                case Interop.AttachPanel.ErrorCode.InvalidParameter:
                    throw new InvalidOperationException("Invalid parameter error at unmanaged code");
                case Interop.AttachPanel.ErrorCode.OutOfMemory:
                    throw new InvalidOperationException("Out of Memory");
                case Interop.AttachPanel.ErrorCode.PermissionDenied:
                    throw new UnauthorizedAccessException();
            }
        }
    }
}
