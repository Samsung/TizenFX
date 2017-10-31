using ElmSharp;
using System;

namespace Tizen.Applications.AttachPanel
{
    /// <summary>
    /// Represents immutable class for attach panel.
    /// </summary>
    public partial class AttachPanel
    {
        /// <summary>
        /// Represents immutable class for attach panel.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="conformant">The caller's conformant</param>
        /// <exception cref="OutOfMemoryException">Thrown when an attempt to allocate memory fails.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the AttachPanel is already exist or the <paramref name="conformant"/> is not a conformant object</exception>
        public AttachPanel(EvasObject conformant)
        {
            if (conformant == IntPtr.Zero)
            {
                throw new ArgumentNullException("Use the value property, not null value");
            }

            IntPtr candidateAttachPanel = new IntPtr();
            Interop.AttachPanel.ErrorCode err = Interop.AttachPanel.CreateAttachPanel(conformant, ref candidateAttachPanel);
            CheckException(err);

            Tizen.Log.Debug("AttachPanelSharp", "Success to create an AttachPanel Instance");
            isCreationSucceed = true;
            _attachPanel = candidateAttachPanel;

            if (_eventEventHandler == null)
            {
                StateEventListenStart();
            }

            if (_resultEventHandler == null)
            {
                ResultEventListenStart();
            }
        }

        /// <summary>
        /// Represents immutable class for attach panel.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="conformant">The caller's conformant</param>
        /// <exception cref="OutOfMemoryException">Thrown when an attempt to allocate memory fails.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the AttachPanel is already exist or the <paramref name="conformant"/> is not a conformant object</exception>
        public AttachPanel(Conformant conformant)
        {
            if (conformant == IntPtr.Zero)
            {
                throw new ArgumentNullException("Use the value property, not null value");
            }

            IntPtr candidateAttachPanel = new IntPtr();
            Interop.AttachPanel.ErrorCode err = Interop.AttachPanel.CreateAttachPanel(conformant, ref candidateAttachPanel);
            CheckException(err);

            Tizen.Log.Debug("AttachPanelSharp", "Success to create an AttachPanel Instance");
            isCreationSucceed = true;
            _attachPanel = candidateAttachPanel;

            if (_eventEventHandler == null)
            {
                StateEventListenStart();
            }

            if (_resultEventHandler == null)
            {
                ResultEventListenStart();
            }
        }

        /// <summary>
        /// A destructor which deallocates attach panel resources.
        /// </summary>
        ~AttachPanel()
        {
            if (isCreationSucceed &&
                _attachPanel != IntPtr.Zero)
            {
                Interop.AttachPanel.ErrorCode err = Interop.AttachPanel.DestroyAttachPanel(_attachPanel);
                CheckException(err);
                _attachPanel = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Gets the state of the AttachPanel.
        /// </summary>
        /// <value>The AttachPanel window state</value>
        /// <since_tizen> 4 </since_tizen>
        public StateType State
        {
            get
            {
                int interopState;
                Interop.AttachPanel.ErrorCode err = Interop.AttachPanel.GetState(_attachPanel, out interopState);
                CheckException(err);
                StateType state = (StateType)Enum.ToObject(typeof(StateType), interopState);
                return state;
            }
        }

        /// <summary>
        /// Gets the value that indicates whether the AttachPanel is visible.
        /// </summary>
        /// <value>visible value of AttachPanel state</value>
        /// <since_tizen> 4 </since_tizen>
        public bool Visible
        {
            get
            {
                int visible;
                Interop.AttachPanel.ErrorCode err = Interop.AttachPanel.GetVisibility(_attachPanel, out visible);
                CheckException(err);
                return (visible == 1);
            }
        }

        /// <summary>
        /// Add a content category in the AttachPanel.
        /// </summary>
        /// <param name="category">The ContentCategory to be added in the AttachPanel</param>
        /// <param name="extraData">The AttachPanel send some information using Bundle</param>
        /// <privilege>http://tizen.org/privilege/mediastorage</privilege>
        /// <privilege>http://tizen.org/privilege/camera</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privilege>http://tizen.org/privilege/appmanager.launch</privilege>
        /// <feature>http://tizen.org/feature/camera</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <remarks>
        /// The caller app has to check the return value of this function.
        /// Content categories will be shown as the sequence of using AddCategory
        /// Some contents need time to load it all.
        /// So, it is needed to use this before the mainloop of Show
        /// Privileges,
        /// http://tizen.org/privilege/mediastorage, for using Image or Camera
        /// http://tizen.org/privilege/camera, for using Camera or TakePicture
        /// http://tizen.org/privilege/recorder, for using Voice
        /// http://tizen.org/privilege/appmanager.launch, for adding content categories on the More tab
        /// http://tizen.org/feature/camera, for using Camera or TakePicture
        /// http://tizen.org/feature/microphone, for using Voice
        /// Deliver more information to the callee with a bundle if you need.
        /// http://tizen.org/appcontrol/data/total_count
        /// http://tizen.org/appcontrol/data/total_size
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <paramref name="category"/> is not a valid category</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when application does not have privilege to access this method</exception>
        /// <exception cref="NotSupportedException">Thrown when the device does not supported the <paramref name="category"/> feature </exception>
        /// <exception cref="InvalidOperationException">Thrown when the AttachPanel is not created yet or already destroyed</exception>
        /// <since_tizen> 4 </since_tizen>
        public void AddCategory(ContentCategory category, Bundle extraData)
        {
            IntPtr bundle = IntPtr.Zero;
            if (extraData != null)
            {
                bundle = extraData.SafeBundleHandle.DangerousGetHandle();
            }

            Interop.AttachPanel.ErrorCode err = Interop.AttachPanel.AddCategory(_attachPanel, (int)category, bundle);
            CheckException(err);
        }

        /// <summary>
        /// Removes the ContentCategory from the AttachPanel
        /// </summary>
        /// <param name="category">The ContentCategory adding in the AttachPanel</param>
        ///  <exception cref="ArgumentOutOfRangeException">Thrown when the <paramref name="category"/> is not a valid category</exception>
        /// <exception cref="InvalidOperationException">Thrown when the AttachPanel is not created yet or already destroyed</exception>
        /// <since_tizen> 4 </since_tizen>
        public void RemoveCategory(ContentCategory category)
        {
            Interop.AttachPanel.ErrorCode err = Interop.AttachPanel.RemoveCategory(_attachPanel, (int)category);
            CheckException(err);
        }

        /// <summary>
        /// Sets extraData to send to the ContentCategory using a Bundle
        /// </summary>
        /// <param name="category">The ContentCategory that some information to be set in the AttachPanel.</param>
        /// <param name="extraData">The AttachPanel send some information using Bundle</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <paramref name="category"/> is not a valid category</exception>
        /// <exception cref="InvalidOperationException">Thrown when the AttachPanel is destroyed</exception>
        /// <exception cref="OutOfMemoryException">Thrown when an attempt to allocate memory fails.</exception>
        /// <since_tizen> 4 </since_tizen>
        public void SetExtraData(ContentCategory category, Bundle extraData)
        {
            if (extraData == null)
            {
                CheckException(Interop.AttachPanel.ErrorCode.InvalidParameter);
            }

            IntPtr bundle = IntPtr.Zero;
            if (extraData != null)
            {
                bundle = extraData.SafeBundleHandle.DangerousGetHandle();
            }

            Interop.AttachPanel.ErrorCode err = Interop.AttachPanel.SetExtraData(_attachPanel, (int)category, bundle);
            CheckException(err);
        }

        /// <summary>
        /// Shows the attach panel with animations
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the AttachPanel is destroyed</exception>
        /// <since_tizen> 4 </since_tizen>
        public void Show()
        {
            Interop.AttachPanel.ErrorCode err = Interop.AttachPanel.Show(_attachPanel);
            CheckException(err);
        }

        /// <summary>
        /// Shows the attach panel and selects whether or not to animate
        /// </summary>
        /// <param name="animation">A flag which turn on or turn off the animation while attach panel showing.</param>
        /// <exception cref="InvalidOperationException">Thrown when the AttachPanel is destroyed</exception>
        /// <since_tizen> 4 </since_tizen>
        public void Show(bool animation)
        {
            if (animation)
            {
                Interop.AttachPanel.ErrorCode err = Interop.AttachPanel.Show(_attachPanel);
                CheckException(err);
            }
            else
            {
                Interop.AttachPanel.ErrorCode err = Interop.AttachPanel.ShowWithoutAnimation(_attachPanel);
                CheckException(err);
            }
        }

        /// <summary>
        /// Hides the attach panel with animations
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the AttachPanel is destroyed</exception>
        /// <since_tizen> 4 </since_tizen>
        public void Hide()
        {
            Interop.AttachPanel.ErrorCode err = Interop.AttachPanel.Hide(_attachPanel);
            CheckException(err);
        }

        /// <summary>
        /// Hides the attach panel and selects whether or not to animate
        /// </summary>
        /// <param name="animation">A flag which turn on or turn off the animation while attach panel hiding.</param>
        /// <exception cref="InvalidOperationException">Thrown when the AttachPanel is destroyed</exception>
        /// <since_tizen> 4 </since_tizen>
        public void Hide(bool animation)
        {
            if (animation)
            {
                Interop.AttachPanel.ErrorCode err = Interop.AttachPanel.Hide(_attachPanel);
                CheckException(err);
            }
            else
            {
                Interop.AttachPanel.ErrorCode err = Interop.AttachPanel.HideWithoutAnimation(_attachPanel);
                CheckException(err);
            }
        }

        /// <summary>
        /// Occurs when reserved events are published from the panel-side.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
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

        /// <summary>
        /// Occurs when an user selects and confirms something to attach in the AttachPanel
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
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
