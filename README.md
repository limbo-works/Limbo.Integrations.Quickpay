# Limbo.Integrations.Quickpay

.NET integration package and API wrapper for the [Quickpay API](https://learn.quickpay.net/tech-talk/api/).

<table>
  <tr>
    <td><strong>License:</strong></td>
    <td><a href="./LICENSE.md"><strong>MIT License</strong></a></td>
  </tr>
  <tr>
    <td><strong>Target Framework:</strong></td>
    <td>.NET Standard 2.0</td>
  </tr>
</table>

<br /><br />

## Installation

Install via [**NuGet**](https://www.nuget.org/packages/Limbo.Integrations.Quickpay/1.0.0-alpha002) - either via the .NET CLI:

```
dotnet add package Limbo.Integrations.Quickpay --version 1.0.0-alpha002
```

or the NuGet package manager:

```
Install-Package Limbo.Integrations.Quickpay -Version 1.0.0-alpha002
```

<br /><br />

## How to use

The package revolves around the `QuickpayHttpService` class. The examples below use this class as basis for accessing the Quickpay API.

The package is divided into endpoints, matching the different areas of the Quickpay API. Supported endpoints are: [**Account**](#account), [**Payments**](#payments) and [**Ping**](#ping).

<br /><br />

### Authentication

Quickpay uses API keys for restricting and handling access to their API.

You can find or generate a new API key from your Quickpay control panel. Once you have an API key, you can get started with the package like:

```csharp
// Initialize a new HTTP service instance
QuickpayHttpService quickpay = QuickpayHttpService.CreateFromApiKey(yourApiKey);
```

<br /><br />

## Account

The Quickpay APi let's you get information baout the account associated with API key being used. Quickpay also refers to the account as a *merchant*.

The code to get information about the account/merchant could look something like:

```csharp
// Make the request to the API
QuickpayMerchantResponse response = quickpay.Accounts.GetAccount();

// Get the merchant from the response body
QuickpayMerchant merchant = response.Body;

// Write out some information about the merchant
<p>ID: @merchant.ID</p>
<p>Shop Name: @merchant.ShopName</p>
<p>Contact Email: @merchant.ContactEmail</p>
<p>Contact Phone: @merchant.ContactPhone</p>
```

For a list of available properties, see the [`QuickpayMerchant` class](https://github.com/limbo-works/Limbo.Integrations.Quickpay/blob/v1/main/src/Limbo.Integrations.Quickpay/Models/Account/QuickpayMerchant.cs).

<br /><br />

## Payments

### Creating a new payment

The code below creates a new payment with the order ID `LIMBO_000001` and sets the currency to `DKK`.

Adding items to the basket is optional, but even for "virtual" products, adding an item to the basket, it can later be used to determine the product(s) that the user purchased.

> **Note**  
> Adding items to the basket does not actually set the price of the payment. The price is set by generating a payment link, which then has the price to the user should pay. The price does not necessarily have to match the sum of the price for each item in the basket. For instance if the user has received as discount, the payment link should have the discounted price.

> **Note**  
> The price is specified as a whole number - eg. the example product has a price 400.00 DKK, which then should be specified as `40000`.

```csharp
// Make the request to the API
QuickpayPaymentResponse response = quickpay.Payments.CreatePayment(new QuickpayCreatePaymentOptions {
    Currency = "DKK",
    OrderId = "LIMBO_000001",
    Basket = new List<QuickpayBasketItemOption>
    {
        new QuickpayBasketItemOption
        {
            Quantity = 1,
            ItemNumber = "1234",
            ItemName = "A product",
            ItemPrice = 400 * 100,
            VatRate = 0
        }
    }
});

// Get the payment model from the response body
QuickpayPayment payment = response.Body;

// Write out some information about the payment
<p>ID: @payment.ID</p>
```

For a list of available properties, see the [`QuickpayPayment` class](https://github.com/limbo-works/Limbo.Integrations.Quickpay/blob/v1/main/src/Limbo.Integrations.Quickpay/Models/Payments/QuickpayPayment.cs).

### Creating a payment link

```csharp
// Generate a new GUID for the payment
Guid uniqueOrderId = Guid.NewGuid();
        
// Make the request to the API
QuickpayPaymentLinkResponse response = quickpay.Payments.CreatePaymentLink(new QuickpayCreatePaymentLinkOptions {
    PaymentId = payment.Id,
    Amount = 400 * 100,
    Language = "da",
    ContinueUrl = "https://localhost/?state=success&uuid=" + uniqueOrderId,
    CancelUrl = "https://localhost/?state=cancel&uuid=" + uniqueOrderId,
    AutoCapture = true
});

// Get the link model from the response body
QuickpayPaymentLinkUrl link = response.Body;

// Write out some information about the payment
<p>URL: @link.Url</p>
```
> **Note**  
> The Quickpay API supports a number of optional parameters. For instance, it's possible to set a `ContinueUrl` the user is redirected back to once they have completed the payment flow, and a `CancelUrl`, which the user is redirected back to if they cancel the flow.
> 
> In this example, both URLs include a randomly generated GUID. It may be useful to temporarily store the GUID and payment ID locally in order to validate the user once they are redirected back to your site.

> **Note**  
> The returned model only exposes the URL of the generated link. The API doesn't have a direct route for getting additional information about a generated link, but the information is part of the model returned when getting a single payment.

### Getting an existing payment

```csharp
// Make the request to the API
QuickpayPaymentResponse response = quickpay.Payments.GetPayment(123456);

// Get the payment model from the response body
QuickpayPayment payment = response.Body;

// Write out some information about the payment
<p>ID: @payment.ID</p>

// Write out some information about the payment link
if (payment.Link != null) {
    <p>URL: @payment.Link.Url</p>
    <p>Amount: @payment.Link.Amount</p>
}
```

<br /><br />

## Ping

The *Ping* endpoint is mostly for testing purposes, and let's you send a *ping* to the Quickpay, which then responds back with a *pong*:

```csharp
// Make the request to the API
QuickpayPongResponse response = quickpay.Ping.GetPing();

// Get the pong model from the response body
QuickpayPong pong = response.Body;

// Write out some information about the payment
<p>Message: @pong.Message</p>
<p>Scope: @pong.Scope</p>
<p>Version: @pong.Version</p>
```

> **Warning**  
> The Quickpay API supports sending additional parameters to the ping endpoint, in which case these these parameters are also part of the pong response. This is currently not supported by this package.

> **Warning**  
> The example above makes a new `GET` request to the Quickpay API. The API also supports sending a pong via a `POST` request, but this is currently not supported by this package.
