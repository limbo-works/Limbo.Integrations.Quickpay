using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Limbo.Integrations.Quickpay.Models.Ping {
    
    /// <summary>
    /// Class representing the pong result of a ping request.
    /// </summary>
    /// <see>
    ///     <cref>https://learn.quickpay.net/tech-talk/api/services/#GET-ping---format-</cref>
    /// </see>
    public class QuickpayPong : QuickpayObject {

        #region Properties

        /// <summary>
        /// Gets a friendly message returned by the API.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Gets the API scope. Possible values are <c>anonymous</c>, <c>user</c>, <c>merchant</c> and <c>reseller</c>.
        /// </summary>
        public string Scope { get; }

        /// <summary>
        /// Gets the current api version. Should always be <c>v10</c>.
        /// </summary>
        public string Version { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        protected QuickpayPong(JObject json) : base(json) {
            Message = json.GetString("msg");
            Scope = json.GetString("scope");
            Version = json.GetString("version");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new <see cref="QuickpayPong"/> parsed from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="QuickpayPong"/>.</returns>
        public static QuickpayPong Parse(JObject json) {
            return json == null ? null : new QuickpayPong(json);
        }

        #endregion

    }

}