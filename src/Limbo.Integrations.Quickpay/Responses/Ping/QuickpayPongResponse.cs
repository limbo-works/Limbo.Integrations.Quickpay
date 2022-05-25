using Limbo.Integrations.Quickpay.Models.Ping;
using Skybrud.Essentials.Http;

namespace Limbo.Integrations.Quickpay.Responses.Ping {

    /// <summary>
    /// Class representing a response with a single <see cref="QuickpayPong"/> as the response body.
    /// </summary>
    public class QuickpayPongResponse : QuickpayResponse<QuickpayPong> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public QuickpayPongResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, QuickpayPong.Parse);
        }

    }

}