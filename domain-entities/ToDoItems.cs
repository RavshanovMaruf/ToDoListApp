using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace domain_entities
{
    public class ToDoItems
    {
        private int status;
        public int Id { get; set; }

        [Required]
        public string ListName { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreationDate { get; set; }
        public int Status
        {
            get
            {
                return status;
            }
            set
            {
                if (value < 4  && value > -1)
                {
                    status = value;
                }
            }
        }
    }
}
