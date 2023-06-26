using System.ComponentModel.DataAnnotations;

namespace ERP.Application.ViewModels
{
    public class ProductViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BarCode { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public DateTime CreationDate { get; }
    }

    public class ProductInsertViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        [MaxLength(50)]
        public string BarCode { get; set; }

        [Required]
        [Range(0.0, 1000000000, ErrorMessage = "The field {0} must be greater than {1}.")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public int StockQuantity { get; set; }

        public DateTime CreationDate { get; }

        public int? SupplierId { get; set; }

        public int? CategoryId { get; set; }
    }

    public class ProductEditViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        [MaxLength(50)]
        public string BarCode { get; set; }

        [Required]
        [Range(0.0, 1000000000, ErrorMessage = "The field {0} must be greater than {1}.")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public int StockQuantity { get; set; }

        public DateTime CreationDate { get; }

        public int? SupplierId { get; set; }

        public int? CategoryId { get; set; }
    }
}
