using System;
using Limbo.Integrations.Quickpay.Endpoints;
using Limbo.Integrations.Quickpay.Http;

namespace Limbo.Integrations.Quickpay {

    /// <summary>
    /// Class working as an entry point to making requests to the various endpoints of the Quickpay API.
    /// </summary>
    public class QuickpayHttpService {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying HTTP client.
        /// </summary>
        public QuickpayHttpClient Client { get; set; }

        /// <summary>
        /// Gets a reference to the <strong>Account</strong> endpoint.
        /// </summary>
        public QuickpayAccountEndpoint Account { get; }

        /// <summary>
        /// Gets a reference to the <strong>Payments</strong> endpoint.
        /// </summary>
        public QuickpayPaymentsEndpoint Payments { get; }

        /// <summary>
        /// Gets a reference to the <strong>Ping</strong> endpoint.
        /// </summary>
        public QuickpayPingEndpoint Ping { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options
        /// </summary>
        public QuickpayHttpService(QuickpayHttpClient client) {
            Client = client;
            Account = new QuickpayAccountEndpoint(this);
            Payments = new QuickpayPaymentsEndpoint(this);
            Ping = new QuickpayPingEndpoint(this);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new instance of <see cref="QuickpayHttpService"/> based on the specified <paramref name="client"/>.
        /// </summary>
        /// <param name="client">The HTTP/OAuth client that should be used internally.</param>
        /// <returns>A new instance of <see cref="QuickpayHttpService"/>.</returns>
        public static QuickpayHttpService CreateFromClient(QuickpayHttpClient client) {
            if (client == null) throw new ArgumentNullException(nameof(client));
            return new QuickpayHttpService(client);
        }
        /// <summary>
        /// Returns a new instance of <see cref="QuickpayHttpService"/> based on the specified <paramref name="apiKey"/>.
        /// </summary>
        /// <param name="apiKey">The API key to be used.</param>
        /// <returns>A new instance of <see cref="QuickpayHttpService"/>.</returns>
        public static QuickpayHttpService CreateFromApiKey(string apiKey) {
            if (string.IsNullOrWhiteSpace(apiKey)) throw new ArgumentNullException(nameof(apiKey));
            return new QuickpayHttpService(new QuickpayHttpClient{
                ApiKey = apiKey
            });
        }

        #endregion

    }

}