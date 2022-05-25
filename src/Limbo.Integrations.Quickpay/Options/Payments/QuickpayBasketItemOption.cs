using Newtonsoft.Json;

namespace Limbo.Integrations.Quickpay.Options.Payments {
    
    /// <summary>
    /// Class describing a basket item to be added.
    /// </summary>
    public class QuickpayBasketItemOption {

        #region Properties

        /// <summary>
        /// Gets or sets the quantity of the item.
        /// </summary>
        [JsonProperty("qty")]
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the item number.
        /// </summary>
        [JsonProperty("item_no", NullValueHandling = NullValueHandling.Ignore)]
        public string ItemNumber { get; set; }

        /// <summary>
        /// Gets or sets the item name.
        /// </summary>
        [JsonProperty("item_name", NullValueHandling = NullValueHandling.Ignore)]
        public string ItemName { get; set; }

        /// <summary>
        /// Gets or sets the item price.
        /// </summary>
        [JsonProperty("item_price")]
        public int ItemPrice { get; set; }

        /// <summary>
        /// Gets or sets the VAT rate.
        /// </summary>
        [JsonProperty("vat_rate")]
        public float VatRate { get; set; }

        #endregion

    }

}