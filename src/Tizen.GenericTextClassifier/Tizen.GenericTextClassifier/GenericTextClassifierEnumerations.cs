using Tizen.Internals.Errors;

namespace Tizen.GenericTextClassifier
{
    /// <summary>
    /// Enumeration for the GenericTextClassifier errors.
    /// </summary>
    /// <since_tizen>8</since_tizen>
    public enum GenericTextClassifierError
    {
        /// <summary>
        /// Successful.
        /// </summary>
        None = ErrorCode.None,
        /// <summary>
        /// No more memory in system.
        /// </summary>
        OutOfMemory = ErrorCode.OutOfMemory,
        /// <summary>
        /// Invalid parameter.
        /// </summary>
        InvalidParameter = ErrorCode.InvalidParameter,
        /// <summary>
        /// Operation already done.
        /// </summary>
        AlreadyDone = -0x03070000 | 0x01,
        /// <summary>
        /// Handle not created.
        /// </summary>
        HandleNotCreated = -0x03070000 | 0x02,
        /// <summary>
        /// Wrong handle passed.
        /// </summary>
        HandleNotValid = -0x03070000 | 0x03,
        /// <summary>
        /// Initialization not done.
        /// </summary>
        InitializedNotDone = -0x03070000 | 0x04,
        /// <summary>
        /// Internal error for generic use.
        /// </summary>
        Internal = -0x03070000 | 0x05
    }
}
