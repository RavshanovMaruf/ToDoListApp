using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace domain_entities
{
    public class ToDoList
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
    }
}
