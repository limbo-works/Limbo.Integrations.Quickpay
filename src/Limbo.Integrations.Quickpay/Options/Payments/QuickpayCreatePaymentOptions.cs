using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Options;

namespace Limbo.Integrations.Quickpay.Options.Payments {
    
    /// <summary>
    /// Class with options for creating a new payment.
    /// </summary>
    /// <see>
    ///     <cref>https://learn.quickpay.net/tech-talk/api/services/#POST-payments---format-</cref>
    /// </see>
    public class QuickpayCreatePaymentOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the order.
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// Gets or sets the currency - eg. <c>DKK</c>.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets a list of items making up the basket of the payment.
        /// </summary>
        public List<QuickpayBasketItemOption> Basket { get; set; } = new();

        #endregion
        
        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {

            JObject body = new();

            if (!string.IsNullOrWhiteSpace(OrderId)) body.Add("order_id", OrderId);
            if (!string.IsNullOrWhiteSpace(Currency)) body.Add("currency", Currency);
            if (Basket is { Count: > 0 }) body.Add("basket", JArray.FromObject(Basket));

            return HttpRequest.Post("/payments", body);

        }

        #endregion

    }

}