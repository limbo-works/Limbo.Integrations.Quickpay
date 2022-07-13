using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;

namespace Limbo.Integrations.Quickpay.Models.Payments {

    /// <summary>
    /// Class representing a payment as returned by the Quickpay API.
    /// </summary>
    /// <see>
    ///     <cref>https://learn.quickpay.net/tech-talk/api/services/#POST-payments---format-</cref>
    /// </see>
    /// <see>
    ///     <cref>https://learn.quickpay.net/tech-talk/api/services/#GET-payments--id---format-</cref>
    /// </see>
    public class QuickpayPayment : QuickpayObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the payment.
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Getsthe ID of the merchant.
        /// </summary>
        public int MerchantId { get; }

        /// <summary>
        /// Gets the order of the ID.
        /// </summary>
        public string OrderId { get; }

        /// <summary>
        /// Gets the transaction type - eg. <c>Payment</c>.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Gets the text on statement, if any.
        /// </summary>
        public string TextOnStatement { get; }

        /// <summary>
        /// Gets the currency of the payment - eg. <c>DKK</c>.
        /// </summary>
        public string Currency { get; }

        /// <summary>
        /// Gets the current state of the payment.
        /// </summary>
        public QuickpayPaymentState State { get; }

        /// <summary>
        /// Gets meta data about the payment.
        /// </summary>
        public QuickpayPaymentMetadata Metadata { get; }

        /// <summary>
        /// Gets the payment link.
        /// </summary>
        public QuickpayPaymentLink Link { get; }

        /// <summary>
        /// Gets a list representing the items of the basket, if any.
        /// </summary>
        public IReadOnlyList<QuickpayBasketItem> Basket { get; }

        /// <summary>
        /// Gets whether this payment was made in test mode.
        /// </summary>
        public bool TestMode { get; }

        /// <summary>
        /// Gets a timestamp for when the payment was created.
        /// </summary>
        public EssentialsTime CreatedAt { get; }

        /// <summary>
        /// Gets a timestamp for when the payment was last updated.
        /// </summary>
        public EssentialsTime UpdatedAt { get; }

        /// <summary>
        /// Gets the current balance of the payment.
        /// </summary>
        public int Balance { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        protected QuickpayPayment(JObject json) : base(json) {
            Id = json.GetInt32("id");
            MerchantId = json.GetInt32("merchant_id");
            OrderId = json.GetString("order_id");
            Type = json.GetString("type");
            TextOnStatement = json.GetString("text_on_statement");
            Currency = json.GetString("currency");
            State = json.GetEnum<QuickpayPaymentState>("state");
            Metadata = json.GetObject("metadata", QuickpayPaymentMetadata.Parse);
            Link = json.GetObject("link", QuickpayPaymentLink.Parse);
            Basket = json.GetArrayItems("basket", QuickpayBasketItem.Parse);
            TestMode = json.GetBoolean("test_mode");
            CreatedAt = json.GetString("created_at", ParseTimestamp);
            UpdatedAt = json.GetString("updated_at", ParseTimestamp);
            Balance = json.GetInt32("balance");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="QuickpayPayment"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="QuickpayPayment"/>.</returns>
        public static QuickpayPayment Parse(JObject json) {
            return json == null ? null : new QuickpayPayment(json);
        }

        #endregion

    }

}