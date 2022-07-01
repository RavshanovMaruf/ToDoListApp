using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace domain_entities
{
    public class Account
    {
        public int Id { get; set; }

        [Required]
        public string Login { get; set; }
        
        [Required]
        public string Password { get; set; }

    }
}
