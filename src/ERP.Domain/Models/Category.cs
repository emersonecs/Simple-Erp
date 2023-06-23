namespace ERP.Domain.Models
{
    public class Category
    {
        public Category(string name, string description)
        {
            Name = name;
            Description = description;
        }

        protected Category() { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void Update(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
