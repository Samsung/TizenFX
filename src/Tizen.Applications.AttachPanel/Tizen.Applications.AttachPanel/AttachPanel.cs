using ElmSharp;
using System;

namespace Tizen.Applications.AttachPanel
{
    /// <summary>
    /// Represents the immutable class for the attach panel.
    /// </summary>
    public partial class AttachPanel
    {
        /// <summary>
        /// Represents the immutable class for the attach panel.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="conformant">The caller's conformant.</param>
        /// <feature>http://tizen.org/feature/attach_panel</feature>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null</exception>
        /// <exception cref="OutOfMemoryException">Thrown when an attempt to allocate the memory fails.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the AttachPanel already exists or the <paramref name="conformant"/> is not a conformant object.</exception>
        /// <exception cref="NotSupportedException">Thrown when the AttachPanel is not supported in the device.</exception>
        public AttachPanel(EvasObject conformant)
        {
            if (conformant == IntPtr.Zero)
            {
                throw new ArgumentNullException("Invalid conformant, it's null");
            }

            if (IsAttachPanelSupported() == false)
            {
                CheckException(Interop.AttachPanel.ErrorCode.NotSupported);
            }

            if (IsInitialized())
            {
                CheckException(Interop.AttachPanel.ErrorCode.AlreadyExists);
            }

            var candidateAttachPanel = IntPtr.Zero;
            var err = Interop.AttachPanel.CreateAttachPanel(conformant, out candidateAttachPanel);
            CheckException(err);

            Tizen.Log.Debug("AttachPanelSharp", "Success to create an AttachPanel Instance");
            s_attachPanel = candidateAttachPanel;

            if (s_eventEventHandler == null)
            {
                StateEventListenStart();
            }

            if (s_resultEventHandler == null)
            {
                ResultEventListenStart();
            }
        }

        /// <summary>
        /// Represents the immutable class for the attach panel.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="conformant">The caller's conformant.</param>
        /// <feature>http://tizen.org/feature/attach_panel</feature>
        /// <exception cref="OutOfMemoryException">Thrown when an attempt to allocate the memory fails.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the AttachPanel already exists or the <paramref name="conformant"/> is not a conformant object.</exception>
        /// <exception cref="NotSupportedException">Thrown when the AttachPanel is not supported in the device.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the parameter is null</exception>
        public AttachPanel(Conformant conformant) : this(conformant as EvasObject)
        {
        }

        /// <summary>
        /// A destructor which deallocates the attach panel resources.
        /// </summary>
        ~AttachPanel()
        {
            if (IsInitialized())
            {
                Interop.AttachPanel.DestroyAttachPanel(s_attachPanel);
                s_attachPanel = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Gets the state of the AttachPanel.
        /// </summary>
        /// <value>The AttachPanel window state.</value>
        /// <since_tizen> 4 </since_tizen>
        /// <feature>http://tizen.org/feature/attach_panel</feature>
        /// <exception cref="InvalidOperationException">Thrown when the AttachPanel is not created yet or is already destroyed.</exception>
        /// <exception cref="NotSupportedException">Thrown when the AttachPanel is not supported in the device.</exception>
        /// <exception cref="ArgumentException">Thrown when the parameter is invalid</exception>
        public StateType State
        {
            get
            {
                if (IsAttachPanelSupported() == false)
                {
                    CheckException(Interop.AttachPanel.ErrorCode.NotSupported);
                }

                if (IsInitialized() == false)
                {
                    CheckException(Interop.AttachPanel.ErrorCode.NotInitialized);
                }

                var err = Interop.AttachPanel.GetState(s_attachPanel, out int interopState);
                CheckException(err);

                return (StateType)Enum.ToObject(typeof(StateType), interopState);
            }
        }

        /// <summary>
        /// Gets the value that indicates whether the AttachPanel is visible.
        /// </summary>
        /// <value>Visible value of the AttachPanel state.</value>
        /// <since_tizen> 4 </since_tizen>
        /// <feature>http://tizen.org/feature/attach_panel</feature>
        /// <exception cref="InvalidOperationException">Thrown when the AttachPanel is not created yet or is already destroyed.</exception>
        /// <exception cref="NotSupportedException">Thrown when the AttachPanel is not supported in the device.</exception>
        public bool Visible
        {
            get
            {
                if (IsAttachPanelSupported() == false)
                {
                    CheckException(Interop.AttachPanel.ErrorCode.NotSupported);
                }

                if (IsInitialized() == false)
                {
                    CheckException(Interop.AttachPanel.ErrorCode.NotInitialized);
                }

                var err = Interop.AttachPanel.GetVisibility(s_attachPanel, out int visible);
                CheckException(err);

                return visible == 1;
            }
        }

        /// <summary>
        /// Adds a content category in the AttachPanel.
        /// </summary>
        /// <param name="category">The ContentCategory to be added in the AttachPanel.</param>
        /// <param name="extraData">The AttachPanel sends some information using the Bundle.</param>
        /// <privilege>http://tizen.org/privilege/mediastorage</privilege>
        /// <privilege>http://tizen.org/privilege/camera</privilege>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <privilege>http://tizen.org/privilege/appmanager.launch</privilege>
        /// <feature>http://tizen.org/feature/camera</feature>
        /// <feature>http://tizen.org/feature/microphone</feature>
        /// <feature>http://tizen.org/feature/attach_panel</feature>
        /// <remarks>
        /// The caller application has to check the return value of this function.
        /// Content categories will be shown as the sequence of using AddCategory.
        /// Some contents need time to load it all.
        /// So, it is needed to use this before the main-loop of the Show.
        /// Privileges,
        /// http://tizen.org/privilege/mediastorage, for using Image or Camera.
        /// http://tizen.org/privilege/camera, for using Camera or TakePicture.
        /// http://tizen.org/privilege/telephony, for using Camera, Since(5.0).
        /// http://tizen.org/privilege/recorder, for using Voice.
        /// http://tizen.org/privilege/appmanager.launch, for adding content categories on the More tab.
        /// http://tizen.org/feature/camera, for using Camera or TakePicture.
        /// http://tizen.org/feature/microphone, for using Voice.
        /// http://tizen.org/feature/attach_panel, for using attach panel
        /// Deliver more information to the callee with a bundle if you need.
        /// http://tizen.org/appcontrol/data/total_count
        /// http://tizen.org/appcontrol/data/total_size
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <paramref name="category"/> is not a valid category.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application does not have the privilege to access this method.</exception>
        /// <exception cref="NotSupportedException">Thrown when the device does not support the <paramref name="category"/> feature.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the AttachPanel is not created yet or is already destroyed.</exception>
        /// <exception cref="NotSupportedException">Thrown when the AttachPanel is not supported in the device.</exception>
        /// <since_tizen> 4 </since_tizen>
        public void AddCategory(ContentCategory category, Bundle extraData)
        {
            if (IsAttachPanelSupported() == false)
            {
                CheckException(Interop.AttachPanel.ErrorCode.NotSupported);
            }

            if (IsInitialized() == false)
            {
                CheckException(Interop.AttachPanel.ErrorCode.NotInitialized);
            }

            var bundle = IntPtr.Zero;
            if (extraData != null)
            {
                bundle = extraData.SafeBundleHandle.DangerousGetHandle();
            }

            var err = Interop.AttachPanel.AddCategory(s_attachPanel, (int)category, bundle);
            CheckException(err);
        }

        /// <summary>
        /// Removes the ContentCategory from the AttachPanel.
        /// </summary>
        /// <param name="category">The ContentCategory to be added in the AttachPanel.</param>
        /// <feature>http://tizen.org/feature/attach_panel</feature>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <paramref name="category"/> is not a valid category.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the AttachPanel is not created yet or is already destroyed.</exception>
        /// <exception cref="NotSupportedException">Thrown when the AttachPanel is not supported in the device.</exception>
        /// <since_tizen> 4 </since_tizen>
        public void RemoveCategory(ContentCategory category)
        {
            if (IsAttachPanelSupported() == false)
            {
                CheckException(Interop.AttachPanel.ErrorCode.NotSupported);
            }

            if (IsInitialized() == false)
            {
                CheckException(Interop.AttachPanel.ErrorCode.NotInitialized);
            }

            var err = Interop.AttachPanel.RemoveCategory(s_attachPanel, (int)category);
            CheckException(err);
        }

        /// <summary>
        /// Sets the extraData to be sent to the ContentCategory using a Bundle.
        /// </summary>
        /// <param name="category">The ContentCategory that some information is to be set, in the AttachPanel.</param>
        /// <param name="extraData">The AttachPanel sends some information using a Bundle.</param>
        /// <feature>http://tizen.org/feature/attach_panel</feature>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the <paramref name="category"/> is not a valid category.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the AttachPanel is destroyed.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when an attempt to allocate the memory fails.</exception>
        /// <exception cref="NotSupportedException">Thrown when the AttachPanel is not supported in the device.</exception>
        /// <since_tizen> 4 </since_tizen>
        public void SetExtraData(ContentCategory category, Bundle extraData)
        {
            if (extraData == null)
            {
                CheckException(Interop.AttachPanel.ErrorCode.InvalidParameter);
            }

            if (IsAttachPanelSupported() == false)
            {
                CheckException(Interop.AttachPanel.ErrorCode.NotSupported);
            }

            if (IsInitialized() == false)
            {
                CheckException(Interop.AttachPanel.ErrorCode.NotInitialized);
            }

            var bundle = IntPtr.Zero;
            if (extraData != null)
            {
                bundle = extraData.SafeBundleHandle.DangerousGetHandle();
            }

            var err = Interop.AttachPanel.SetExtraData(s_attachPanel, (int)category, bundle);
            CheckException(err);
        }

        /// <summary>
        /// Shows the attach panel with the animations.
        /// </summary>
        /// <feature>http://tizen.org/feature/attach_panel</feature>
        /// <exception cref="InvalidOperationException">Thrown when the AttachPanel is destroyed.</exception>
        /// <exception cref="NotSupportedException">Thrown when the AttachPanel is not supported in the device.</exception>
        /// <since_tizen> 4 </since_tizen>
        public void Show()
        {
            if (IsAttachPanelSupported() == false)
            {
                CheckException(Interop.AttachPanel.ErrorCode.NotSupported);
            }

            if (IsInitialized() == false)
            {
                CheckException(Interop.AttachPanel.ErrorCode.NotInitialized);
            }

            var err = Interop.AttachPanel.Show(s_attachPanel);
            CheckException(err);
        }

        /// <summary>
        /// Shows the attach panel and selects whether or not to animate.
        /// </summary>
        /// <param name="animation">A flag which turns on or turns off the animation while the attach panel is showing.</param>
        /// <feature>http://tizen.org/feature/attach_panel</feature>
        /// <exception cref="InvalidOperationException">Thrown when the AttachPanel is destroyed.</exception>
        /// <exception cref="NotSupportedException">Thrown when the AttachPanel is not supported in the device.</exception>
        /// <since_tizen> 4 </since_tizen>
        public void Show(bool animation)
        {
            if (IsAttachPanelSupported() == false)
            {
                CheckException(Interop.AttachPanel.ErrorCode.NotSupported);
            }

            if (IsInitialized() == false)
            {
                CheckException(Interop.AttachPanel.ErrorCode.NotInitialized);
            }

            if (animation)
            {
                var err = Interop.AttachPanel.Show(s_attachPanel);
                CheckException(err);
            }
            else
            {
                var err = Interop.AttachPanel.ShowWithoutAnimation(s_attachPanel);
                CheckException(err);
            }
        }

        /// <summary>
        /// Hides the attach panel with the animations.
        /// </summary>
        /// <feature>http://tizen.org/feature/attach_panel</feature>
        /// <exception cref="InvalidOperationException">Thrown when the AttachPanel is destroyed.</exception>
        /// <exception cref="NotSupportedException">Thrown when the AttachPanel is not supported in the device.</exception>
        /// <since_tizen> 4 </since_tizen>
        public void Hide()
        {
            if (IsAttachPanelSupported() == false)
            {
                CheckException(Interop.AttachPanel.ErrorCode.NotSupported);
            }

            if (IsInitialized() == false)
            {
                CheckException(Interop.AttachPanel.ErrorCode.NotInitialized);
            }

            var err = Interop.AttachPanel.Hide(s_attachPanel);
            CheckException(err);
        }

        /// <summary>
        /// Hides the attach panel and selects whether or not to animate.
        /// </summary>
        /// <param name="animation">A flag which turns on or turns off the animation while the attach panel is hiding.</param>
        /// <feature>http://tizen.org/feature/attach_panel</feature>
        /// <exception cref="InvalidOperationException">Thrown when the AttachPanel is destroyed.</exception>
        /// <exception cref="NotSupportedException">Thrown when the AttachPanel is not supported in the device.</exception>
        /// <since_tizen> 4 </since_tizen>
        public void Hide(bool animation)
        {
            if (IsAttachPanelSupported() == false)
            {
                CheckException(Interop.AttachPanel.ErrorCode.NotSupported);
            }

            if (IsInitialized() == false)
            {
                CheckException(Interop.AttachPanel.ErrorCode.NotInitialized);
            }

            if (animation)
            {
                var err = Interop.AttachPanel.Hide(s_attachPanel);
                CheckException(err);
            }
            else
            {
                var err = Interop.AttachPanel.HideWithoutAnimation(s_attachPanel);
                CheckException(err);
            }
        }

        /// <summary>
        /// Occurs when the reserved events are published from the panel-side.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler<StateEventArgs> EventChanged
        {
            add
            {
                if (s_eventEventHandler == null)
                {
                    StateEventListenStart();
                }

                s_eventEventHandler += value;
            }

            remove
            {
                s_eventEventHandler -= value;
                if (s_eventEventHandler == null)
                {
                    StateEventListenStop();
                }
            }
        }

        /// <summary>
        /// Occurs when a user selects and confirms something to attach in the AttachPanel.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler<ResultEventArgs> ResultCallback
        {
            add
            {
                if (s_resultEventHandler == null)
                {
                    ResultEventListenStart();
                }

                s_resultEventHandler += value;
            }

            remove
            {
                s_resultEventHandler -= value;
                if (s_resultEventHandler == null)
                {
                    ResultEventListenStop();
                }
            }
        }
    }
}
