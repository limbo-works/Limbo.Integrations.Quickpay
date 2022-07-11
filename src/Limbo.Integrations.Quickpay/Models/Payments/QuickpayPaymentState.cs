#pragma warning disable CS1591

namespace Limbo.Integrations.Quickpay.Models.Payments {

    /// <summary>
    /// Enum class indicating the state of a Quickpay payment.
    /// </summary>
    /// <see>
    ///     <cref>https://learn.quickpay.net/tech-talk/api/services/#GET-payments--id---format-</cref>
    /// </see>
    public enum QuickpayPaymentState {
        
        Initial,
        Pending,
        New,
        Rejected,
        Processed

    }

}