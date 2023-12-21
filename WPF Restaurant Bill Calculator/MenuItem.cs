using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB3
{
    public class MenuItem
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        // Add more properties as needed

        public ObservableCollection<string> Categories { get; set; }
    }
}
