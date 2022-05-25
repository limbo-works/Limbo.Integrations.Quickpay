using Limbo.Integrations.Quickpay.Models.Payments;
using Skybrud.Essentials.Http;

namespace Limbo.Integrations.Quickpay.Responses.Payments {

    /// <summary>
    /// Class representing a response with a single <see cref="QuickpayPayment"/> as the response body.
    /// </summary>
    public class QuickpayPaymentResponse : QuickpayResponse<QuickpayPayment> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public QuickpayPaymentResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, QuickpayPayment.Parse);
        }

    }

}