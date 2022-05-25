using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Strings.Extensions;

namespace Limbo.Integrations.Quickpay.Models.Account {
    
    /// <summary>
    /// Class representing a Quickpay merchant reseller.
    /// </summary>
    /// <see>
    ///     <cref>https://learn.quickpay.net/tech-talk/api/services/#GET-account---format-</cref>
    /// </see>
    public class QuickpayMerchantReseller : QuickpayObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the reseller.
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Gets the name of the reseller.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the ID of the default branding, or <c>null</c>.
        /// </summary>
        public long? DefaultBrandingId { get; }

        /// <summary>
        /// Gets a list of default payment methods.
        /// </summary>
        public IReadOnlyList<string> DefaultPaymentMethods { get; }

        /// <summary>
        /// Gets the email address to reseller for support.
        /// </summary>
        public string SupportEmail { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        protected QuickpayMerchantReseller(JObject json) : base(json) {
            Id = json.GetInt64("id");
            Name = json.GetString("name");
            DefaultBrandingId = json.HasValue("default_branding_id") ? json.GetInt64("default_branding_id") : null;
            DefaultPaymentMethods = json.GetString("default_payment_methods").ToStringArray();
            SupportEmail = json.GetString("support_email");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="QuickpayMerchantReseller"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="QuickpayMerchantReseller"/>.</returns>
        public static QuickpayMerchantReseller Parse(JObject json) {
            return json == null ? null : new QuickpayMerchantReseller(json);
        }

        #endregion

    }

}