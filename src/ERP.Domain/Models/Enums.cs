namespace ERP.Domain.Models
{
    public class Enums
    {
        public enum PaymentMethod
        {
            CreditCard,
            Money,
            Pix,
            Other
        }

        public enum OrderStatus
        {
            Delivered,
            Canceled
        }
    }
}
