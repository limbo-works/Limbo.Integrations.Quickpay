using Limbo.Integrations.Quickpay.Models.Account;
using Skybrud.Essentials.Http;

namespace Limbo.Integrations.Quickpay.Responses.Account {

    /// <summary>
    /// Class representing a response with a single <see cref="QuickpayMerchant"/> as the response body.
    /// </summary>
    public class QuickpayMerchantResponse : QuickpayResponse<QuickpayMerchant> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public QuickpayMerchantResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, QuickpayMerchant.Parse);
        }

    }

}