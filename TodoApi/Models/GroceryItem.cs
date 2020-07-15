using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class GroceryItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Supermarket { get; set; }
        public int Quantity { get; set; }
        public bool IsComplete { get; set; }
        public DateTime Added { get; set; }
        public GroceryItem()
        {
            Added = DateTime.Now;
        }
    }
}
