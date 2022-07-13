using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Limbo.Integrations.Quickpay.Models.Payments {

    /// <summary>
    /// Class representing the meta data of a payment.
    /// </summary>
    public class QuickpayPaymentMetadata : QuickpayObject {

        #region Properties

        /// <summary>
        /// Gets the type. Possible values are <c>card</c>, <c>mobile</c> and <c>nin</c>.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Gets the origin of this transaction or card. If set, describes where it came from.
        /// </summary>
        public string Origin { get; }

        /// <summary>
        /// Card type only: The card brand.
        /// </summary>
        public string Brand { get; }

        /// <summary>
        /// Card type only: Card BIN.
        /// </summary>
        public string Bin { get; }

        /// <summary>
        /// Card type only: Corporate status.
        /// </summary>
        public bool IsCorporate { get; }

        /// <summary>
        /// Card type only: The last 4 digits of the card number.
        /// </summary>
        public string Last4 { get; }

        /// <summary>
        /// Card type only: The expiration month.
        /// </summary>
        public int ExpMonth { get; }

        /// <summary>
        /// Card type only: The expiration year (YYYY)
        /// </summary>
        public int ExpYear { get; }

        /// <summary>
        /// Card type only: The card country in ISO 3166-1 alpha-3.
        /// </summary>
        public string Country { get; }

        /// <summary>
        /// Card type only: Verified via 3D-Secure.
        /// </summary>
        public bool Is3dSecure { get; }

        //public string 3d_secure_type { get; }

        /// <summary>
        /// Gets the name of the card holder.
        /// </summary>
        public string IssuedTo { get; }

        /// <summary>
        /// Card type only: PCI safe hash of card number.
        /// </summary>
        public string Hash { get; }

        /// <summary>
        /// Mobile type only: The mobile number.
        /// </summary>
        public string Number { get; }

        /// <summary>
        /// Customer IP.
        /// </summary>
        public string CustomerIp { get; }

        /// <summary>
        /// Customer country based on IP geo-data, ISO 3166-1 alpha-2.
        /// </summary>
        public string CustomerCountry { get; }

        /// <summary>
        /// Suspected fraud.
        /// </summary>
        public bool IsFraudSuspected { get; }

        /// <summary>
        /// Fraud remarks.
        /// </summary>
        public IReadOnlyList<string> FraudRemarks { get; }

        /// <summary>
        /// Reported as fraudulent
        /// </summary>
        public bool IsFraudReported { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        protected QuickpayPaymentMetadata(JObject json) : base(json) {
            Type = json.GetString("type");
            Origin = json.GetString("origin");
            Brand = json.GetString("brand");
            Bin = json.GetString("bin");
            IsCorporate = json.GetBoolean("corporate");
            Last4 = json.GetString("last4");
            ExpMonth = json.GetInt32("exp_month");
            ExpYear = json.GetInt32("exp_year");
            Country = json.GetString("country");
            Is3dSecure = json.GetBoolean("is_3d_secure");
            IssuedTo = json.GetString("issued_to");
            Hash = json.GetString("hash");
            Number = json.GetString("number");
            CustomerIp = json.GetString("customer_ip");
            CustomerCountry = json.GetString("customer_country");
            IsFraudSuspected = json.GetBoolean("fraud_suspected");
            FraudRemarks = json.GetStringArray("fraud_remarks");
            IsFraudReported = json.GetBoolean("fraud_reported");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="QuickpayPaymentMetadata"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="QuickpayPaymentMetadata"/>.</returns>
        public static QuickpayPaymentMetadata Parse(JObject json) {
            return json == null ? null : new QuickpayPaymentMetadata(json);
        }

        #endregion

    }

}