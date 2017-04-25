using System;

namespace Tizen.Applications.AttachPanel
{
    public partial class AttachPanel
    {
        private const string LogTag = "Tizen.Applications.AttachPanel";

        private static IntPtr _attachPanel;

        private static event EventHandler<StateEventArgs> _eventEventHandler;
        private static event EventHandler<ResultEventArgs> _resultEventHandler;

        private static Interop.AttachPanel.AttachPanelEventCallback SetEventListener;
        private static Interop.AttachPanel.AttachPanelResultCallback SetResultListener;

        public AttachPanel(IntPtr conformant)
        {
            _attachPanel = new IntPtr();
            Interop.AttachPanel.ErrorCode err = Interop.AttachPanel.CreateAttachPanel(conformant, ref _attachPanel);
            checkException(err);

            if (_eventEventHandler == null)
            {
                StateEventListenStart();
            }

            if (_resultEventHandler == null)
            {
                ResultEventListenStart();
            }
        }

        ~AttachPanel()
        {
            if (_attachPanel != IntPtr.Zero)
            {
                Interop.AttachPanel.ErrorCode err = Interop.AttachPanel.DestroyAttachPanel(_attachPanel);
                checkException(err);
                _attachPanel = IntPtr.Zero;
            }
        }

        public int State
        {
            get
            {
                int state;
                Interop.AttachPanel.ErrorCode err = Interop.AttachPanel.GetState(_attachPanel, out state);
                checkException(err);
                return state;
            }
        }
        public int Visible
        {
            get
            {
                int visible;
                Interop.AttachPanel.ErrorCode err = Interop.AttachPanel.GetVisibility(_attachPanel, out visible);
                checkException(err);
                return visible;
            }
        }

        public void AddCategory(ContentCategory category, Bundle extraData)
        {
            IntPtr bundle = IntPtr.Zero;
            if (extraData != null)
            {
                bundle = extraData.SafeBundleHandle.DangerousGetHandle();
            }
            Interop.AttachPanel.ErrorCode err = Interop.AttachPanel.AddCategory(_attachPanel, (int)category, bundle);
            checkException(err);
        }

        public void RemoveCategory(ContentCategory category)
        {
            Interop.AttachPanel.ErrorCode err = Interop.AttachPanel.RemoveCategory(_attachPanel, (int)category);
            checkException(err);
        }

        public void SetExtraData(ContentCategory category, Bundle extraData)
        {
            IntPtr bundle = IntPtr.Zero;
            if (extraData != null)
            {
                bundle = extraData.SafeBundleHandle.DangerousGetHandle();
            }
            Interop.AttachPanel.ErrorCode err = Interop.AttachPanel.SetExtraData(_attachPanel, (int)category, bundle);
            checkException(err);
        }

        public void Show()
        {
            Interop.AttachPanel.ErrorCode err = Interop.AttachPanel.Show(_attachPanel);
            checkException(err);
        }

        public void Show(bool animation)
        {
            if (animation)
            {
                Interop.AttachPanel.ErrorCode err = Interop.AttachPanel.Show(_attachPanel);
                checkException(err);
            }
            else
            {
                Interop.AttachPanel.ErrorCode err = Interop.AttachPanel.ShowWithoutAnimation(_attachPanel);
                checkException(err);
            }
        }

        public void Hide()
        {
            Interop.AttachPanel.ErrorCode err = Interop.AttachPanel.Hide(_attachPanel);
            checkException(err);
        }

        public void Hide(bool animation)
        {
            if (animation)
            {
                Interop.AttachPanel.ErrorCode err = Interop.AttachPanel.Hide(_attachPanel);
                checkException(err);
            }
            else
            {
                Interop.AttachPanel.ErrorCode err = Interop.AttachPanel.HideWithoutAnimation(_attachPanel);
                checkException(err);
            }
        }

        public event EventHandler<StateEventArgs> EventChanged
        {
            add
            {
                if (_eventEventHandler == null)
                {
                    StateEventListenStart();
                }
                _eventEventHandler += value;
            }
            remove
            {
                _eventEventHandler -= value;
                if (_eventEventHandler == null)
                {
                    StateEventListenStop();
                }
            }
        }

        public event EventHandler<ResultEventArgs> ResultCallback
        {
            add
            {
                if (_resultEventHandler == null)
                {
                    ResultEventListenStart();
                }
                _resultEventHandler += value;
            }
            remove
            {
                _resultEventHandler -= value;
                if (_resultEventHandler == null)
                {
                    ResultEventListenStop();
                }
            }
        }
    }
}
