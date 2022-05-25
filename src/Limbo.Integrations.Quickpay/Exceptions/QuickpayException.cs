using System;

namespace Limbo.Integrations.Quickpay.Exceptions {

    /// <summary>
    /// Class representing a basic Quickpay exception.
    /// </summary>
    public class QuickpayException : Exception {

        /// <summary>
        /// Initializes a new exception with the specified <paramref name="message"/>.
        /// </summary>
        /// <param name="message">The message of the exception.</param>
        public QuickpayException(string message) : base(message) { }

    }

}