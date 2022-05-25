using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json;
using Skybrud.Essentials.Time;

namespace Limbo.Integrations.Quickpay.Models {

    /// <summary>
    /// Class representing a basic object from the Quickpay API derived from an instance of <see cref="JObject"/>.
    /// </summary>
    public class QuickpayObject : JsonObjectBase  {

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        public QuickpayObject(JObject json) : base(json) { }

        /// <summary>
        /// Returns a new <see cref="EssentialsTime"/> instance representing the specified <paramref name="value"/>, or
        /// <c>null</c> if <paramref name="value"/> is <c>null</c> or empty.
        /// </summary>
        /// <param name="value">The value to be parsed.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/> if successful; otherwise, <c>false</c>.</returns>
        protected static EssentialsTime ParseTimestamp(string value) {
            return string.IsNullOrWhiteSpace(value) ? null : EssentialsTime.FromIso8601(value);
        }

    }

}