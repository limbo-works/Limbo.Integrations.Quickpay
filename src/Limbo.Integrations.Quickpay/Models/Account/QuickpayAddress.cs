using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Limbo.Integrations.Quickpay.Models.Account {

    /// <summary>
    /// Class representing an address.
    /// </summary>
    public class QuickpayAddress : QuickpayObject {

        #region Properties

        /// <summary>
        /// Gets the name associated with the address.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the name of the person or similar associated with the address.
        /// </summary>
        public string Att { get; }

        /// <summary>
        /// Gets the street of the address.
        /// </summary>
        public string Street { get; }

        /// <summary>
        /// Gets the city of the address.
        /// </summary>
        public string City { get; }

        /// <summary>
        /// Gets the ZIP code of the address.
        /// </summary>
        public string ZipCode { get; }

        /// <summary>
        /// Gets the region of the address.
        /// </summary>
        public string Region { get; }

        /// <summary>
        /// Gets the country code of the address.
        /// </summary>
        public string CountryCode { get; }

        /// <summary>
        /// Gets the VAT number associated with the address.
        /// </summary>
        public string VatNumber { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        protected QuickpayAddress(JObject json) : base(json) {
            Name = json.GetString("name");
            Att = json.GetString("att");
            Street = json.GetString("street");
            City = json.GetString("city");
            ZipCode = json.GetString("zip_code");
            Region = json.GetString("region");
            CountryCode = json.GetString("country_code");
            VatNumber = json.GetString("vat_no");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="QuickpayAddress"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="QuickpayAddress"/>.</returns>
        public static QuickpayAddress Parse(JObject json) {
            return json == null ? null : new QuickpayAddress(json);
        }

        #endregion

    }

}