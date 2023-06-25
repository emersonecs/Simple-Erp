using System.ComponentModel.DataAnnotations;

namespace ERP.Application.ViewModels
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public int Number { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public class ClientInsertViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        [MaxLength(100)]
        public string District { get; set; }

        public int Number { get; set; }

        [MaxLength(200)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }
    }

    public class ClientEditViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        [MaxLength(100)]
        public string District { get; set; }

        public int Number { get; set; }

        [MaxLength(200)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }
    }
}
