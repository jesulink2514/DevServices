namespace Devcode.Api.Models
{
    public enum OrderStatus
    {
        Submitted,
        AwaitingValidation,
        StockConfirmed,
        Paid,
        Shipped,
        Cancelled
    }
}