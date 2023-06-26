using ERP.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace ERP.Application.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime CreationDate { get; set; }
        public Enums.PaymentMethod PaymentMethod { get; set; }
        public Enums.OrderStatus OrderStatus { get; set; }
        public decimal Total { get; set; }
    }

    public class OrderInsertViewModel
    {
        [Required]
        public int ClientId { get; set; }

        [Required]
        public Enums.PaymentMethod PaymentMethod { get; set; }

        [Required]
        public Enums.OrderStatus OrderStatus { get; set; }

        public decimal Total { get; set; }
    }

    public class OrderEditViewModel
    {
        [Required]
        public int ClientId { get; set; }

        [Required]
        public Enums.PaymentMethod PaymentMethod { get; set; }

        [Required]
        public Enums.OrderStatus OrderStatus { get; set; }

        public decimal Total { get; set; }
    }
}
