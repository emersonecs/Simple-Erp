namespace ERP.Domain.Models
{
    public class Supplier
    {
        public Supplier(string name, string address, string phoneNumber, string email)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        protected Supplier() { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; }

        public void Update(string name, string address, string phoneNumber, string email)
        {
            Name = name;
            Address = address;
            PhoneNumber= phoneNumber;
            Email = email;
        }
    }
}
