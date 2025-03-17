using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace Inventory_Management_System.Models
//{
//    public class InHouse : Part
//    {
//        public int MachineID { get; set; }

//        // Constructor for the derived class
//        public InHouse(int partID, string name, decimal price, int inStock, int min, int max, int machineID)
//        {
//           MachineID = machineID;
//        }
//    }
//}
namespace Inventory_Management_System.Models
{
    public class InHouse : Part
    {
        public int MachineID { get; set; }

        // Constructor for the derived class
        public InHouse(int partID, string name, decimal price, int inStock, int min, int max, int machineID)
            : base() // Explicitly call the base class constructor
        {
            this.PartID = partID;
            this.Name = name;
            this.Price = price;
            this.InStock = inStock;
            this.Min = min;
            this.Max = max;
            this.MachineID = machineID;
        }
    }
}
