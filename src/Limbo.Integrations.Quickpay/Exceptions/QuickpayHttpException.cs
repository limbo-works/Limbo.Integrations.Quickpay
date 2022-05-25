﻿using System.Net;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Exceptions;

namespace Limbo.Integrations.Quickpay.Exceptions {

    /// <summary>
    /// Class representing an exception/error returned by the Quickpay API.
    /// </summary>
    public class QuickpayHttpException : QuickpayException, IHttpException {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying <see cref="IHttpResponse"/>.
        /// </summary>
        public IHttpResponse Response { get; }

        /// <summary>
        /// Gets the HTTP status code returned by the Quickpay API.
        /// </summary>
        public HttpStatusCode StatusCode => Response.StatusCode;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new exception based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public QuickpayHttpException(IHttpResponse response) : base("Invalid response received from the Quickpay API (status: " + (int) response.StatusCode + ")") {
            Response = response;
        }


        #endregion

    }

}