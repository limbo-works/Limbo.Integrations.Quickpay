using System.Net;
using Skybrud.Essentials.Http;
using Limbo.Integrations.Quickpay.Exceptions;

namespace Limbo.Integrations.Quickpay.Responses {

    /// <summary>
    /// Class representing a response from the Quickpay API.
    /// </summary>
    public class QuickpayResponse : HttpResponseBase {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public QuickpayResponse(IHttpResponse response) : base(response) {
            if (response.StatusCode == HttpStatusCode.OK) return;
            if (response.StatusCode == HttpStatusCode.Created) return;
            throw new QuickpayHttpException(response);
        }

    }

    /// <summary>
    /// Class representing a response from the Quickpay API.
    /// </summary>
    public class QuickpayResponse<T> : QuickpayResponse {

        /// <summary>
        /// /// Gets the body of the response.
        /// </summary>
        public T Body { get; protected set; }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public QuickpayResponse(IHttpResponse response) : base(response) { }

    }

}