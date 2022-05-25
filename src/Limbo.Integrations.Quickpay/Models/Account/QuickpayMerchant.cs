using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;

namespace Limbo.Integrations.Quickpay.Models.Account {

    /// <summary>
    /// Class representing a Quickpay merchant account.
    /// </summary>
    /// <see>
    ///     <cref>https://learn.quickpay.net/tech-talk/api/services/#GET-account---format-</cref>
    /// </see>
    public class QuickpayMerchant : QuickpayObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the account.
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Gets the type of the account.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Gets the contact email address of the account.
        /// </summary>
        public string ContactEmail { get; }

        /// <summary>
        /// Gets the contact phone number of the account.
        /// </summary>
        public string ContactPhone { get; }

        /// <summary>
        /// Gets the name of the shop.
        /// </summary>
        public string ShopName { get; }

        /// <summary>
        /// Gets the URL of the shop. Use the <see cref="ShopUrls"/> property.
        /// </summary>
        public string ShopUrl { get; }

        /// <summary>
        /// Gets a list of shop URLs.
        /// </summary>
        public IReadOnlyList<string> ShopUrls { get; }

        /// <summary>
        /// Gets the selected time zone of the account.
        /// </summary>
        public string TimeZone { get; }

        /// <summary>
        /// Gets the locale of the account.
        /// </summary>
        public string Locale { get; }

        /// <summary>
        /// Gets whether test transactions are enabled.
        /// </summary>
        public bool AllowTestTransactions { get; }

        /// <summary>
        /// Get the customer address associated with the account, or <c>null</c> if not specified.
        /// </summary>
        public QuickpayAddress CustomerAddress { get; }

        /// <summary>
        /// Get the billing address associated with the account, or <c>null</c> if not specified.
        /// </summary>
        public QuickpayAddress BillingAddress { get; }

        /// <summary>
        /// Gets a timestamp for when the account was created.
        /// </summary>
        public EssentialsTime CreatedAt { get; }

        /// <summary>
        /// Gets a timestamp for when the account was suspended or <c>null</c> if not suspended.
        /// </summary>
        public EssentialsTime SuspendedAt { get; }

        /// <summary>
        /// Gets a reference to the reseller of the aacount.
        /// </summary>
        public QuickpayMerchantReseller Reseller { get; }

        /// <summary>
        /// Gets whether the account has been suspended.
        /// </summary>
        public bool IsSuspended => SuspendedAt != null;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        protected QuickpayMerchant(JObject json) : base(json) {
            Id = json.GetInt64("id");
            Type = json.GetString("type");
            ShopName = json.GetString("shop_name");
            ShopUrl = json.GetString("shop_url");
            ShopUrls = json.GetStringArray("shop_urls");
            ContactEmail = json.GetString("contact_email");
            ContactPhone = json.GetString("contact_phone");
            TimeZone = json.GetString("timezone");
            Locale = json.GetString("locale");
            AllowTestTransactions = json.GetBoolean("allow_test_transactions");
            CustomerAddress = json.GetObject("customer_address", QuickpayAddress.Parse);
            BillingAddress = json.GetObject("billing_address", QuickpayAddress.Parse);
            Reseller = json.GetObject("reseller", QuickpayMerchantReseller.Parse);
            CreatedAt = json.GetString("created_at", ParseTimestamp);
            SuspendedAt = json.GetString("suspended_at", ParseTimestamp);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="QuickpayMerchant"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="QuickpayMerchant"/>.</returns>
        public static QuickpayMerchant Parse(JObject json) {
            return json == null ? null : new QuickpayMerchant(json);
        }

        #endregion

    }

}