using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAPI.Entities
{
    public class Contact
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public string NickName { get; set; }
        public string Company { get; set; }
        public string JobTitle { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Birthday { get; set; }
        public string Notes { get; set; }
    }
}
