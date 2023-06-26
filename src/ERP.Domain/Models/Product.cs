namespace ERP.Domain.Models
{
    public class Product
    {
        public Product(string name, string description, string barCode, decimal price, int stockQuantity, int? supplierId, int? categoryId)
        {
            Name = name;
            Description = description;
            BarCode = barCode;
            Price = price;
            StockQuantity = stockQuantity;
            SupplierId = supplierId;
            CategoryId = categoryId;
        }

        protected Product() { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BarCode { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public DateTime CreationDate { get; }

        public int? SupplierId { get; set; }
        public int? CategoryId { get; set; }

        public Supplier? Supplier { get; set; }
        public Category? Category { get; set; }

        public void Update(string name, string description, string barCode, decimal price, int stockQuantity, int? supplierId, int? categoryId)
        {
            Name = name;
            Description = description;
            BarCode = barCode;
            Price = price;
            StockQuantity = stockQuantity;
            SupplierId = supplierId;
            CategoryId = categoryId;
        }
    }
}
