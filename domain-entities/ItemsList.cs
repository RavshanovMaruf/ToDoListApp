using System;
using System.Collections.Generic;
using System.Text;

namespace domain_entities
{
    public class ItemsList
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int ListId { get; set; }
        public virtual ToDoItems Item { get; set; }
        public virtual ToDoList ToDoList { get; set; }
    }
}
