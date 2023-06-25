namespace ERP.Domain.Models
{
    public class Client
    {
        public Client(string name, string address, string district, int number, string email, string phone)
        {
            Name = name;
            Address = address;
            District = district;
            Number = number;
            Email = email;
            Phone = phone;
        }

        protected Client() { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public int Number { get; set; }
        public string Email{ get; set; }
        public string Phone { get; set; }

        public void Update(string name, string address, string district, int number, string email, string phone)
        {
            Name = name;
            Address = address;
            District = district;
            Number = number;
            Email = email;
            Phone = phone;
        }

        public void AddAddress(string address, string district, int number)
        {
            Address = address;
            District = district;
            Number = number;
        }
    }
}
