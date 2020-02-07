using System;

namespace Tizen.GenericTextClassifier
{
    /// <summary>
    /// A class which is used to Throw the GenericTextClassifier Error exceptions.
    /// </summary>
    static internal class GenericTextClassifierErrorFactory
    {
        /// <summary>
        /// Exceptions for GenericTextClassifier Errors.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the GenericTextClassifier Error happens.</exception>
        internal static void ThrowGenericTextClassifierException(int exception)
        {
            throw CreateGenericTextClassifierException(exception);
        }

        /// <summary>
        /// Creates GenericTextClassifier Exception.
        /// </summary>
        internal static Exception CreateGenericTextClassifierException(int exception)
        {
            GenericTextClassifierError error = (GenericTextClassifierError)exception;
            switch (error)
            {
                case GenericTextClassifierError.OutOfMemory:
                    return new InvalidOperationException("No more memory in system");

                case GenericTextClassifierError.InvalidParameter:
                    return new InvalidOperationException("Invalid parameter");

                case GenericTextClassifierError.AlreadyDone:
                    return new InvalidOperationException("Operation already done");

                case GenericTextClassifierError.HandleNotCreated:
                    return new InvalidOperationException("Handle not created");

                case GenericTextClassifierError.HandleNotValid:
                    return new InvalidOperationException("Wrong handle passed");

                case GenericTextClassifierError.InitializedNotDone:
                    return new InvalidOperationException("Initialization not done");

                case GenericTextClassifierError.Internal:
                    return new InvalidOperationException("Internal error for generic use");

                default:
                    return new InvalidOperationException("Unknown exception");
            }
        }
    }
}
