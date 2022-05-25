using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Limbo.Integrations.Quickpay.Models.Payments {

    /// <summary>
    /// Class representing a basket item.
    /// </summary>
    public class QuickpayBasketItem : QuickpayObject {

        #region Properties

        /// <summary>
        /// Gets the quantity of the item.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the item number.
        /// </summary>
        public string ItemNumber { get; }

        /// <summary>
        /// Gets or sets the item name.
        /// </summary>
        public string ItemName { get; }

        /// <summary>
        /// Gets or sets the item price.
        /// </summary>
        public int ItemPrice { get; }

        /// <summary>
        /// Gets or sets the VAT rate.
        /// </summary>
        public float VatRate { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        protected QuickpayBasketItem(JObject json) : base(json) {
            Quantity = json.GetInt32("qty");
            ItemNumber = json.GetString("item_no");
            ItemName = json.GetString("item_name");
            ItemPrice = json.GetInt32("item_price");
            VatRate = json.GetFloat("vat_rate");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="QuickpayBasketItem"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="QuickpayBasketItem"/>.</returns>
        public static QuickpayBasketItem Parse(JObject json) {
            return json == null ? null : new QuickpayBasketItem(json);
        }

        #endregion

    }

}