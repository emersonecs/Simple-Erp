namespace ERP.Domain.Models
{
    public class Order
    {
        public Order( int clientId, Enums.PaymentMethod paymentMethod, decimal total)
        {
            ClientId = clientId;
            PaymentMethod = paymentMethod;
            OrderStatus = Enums.OrderStatus.Delivered;
            Total = total;
        }

        protected Order() { }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime CreationDate { get; set; }
        public Enums.PaymentMethod PaymentMethod { get; set; }
        public Enums.OrderStatus OrderStatus { get; set; }
        public decimal Total { get; set; }

        public Client Client { get; set; }
    }
}
