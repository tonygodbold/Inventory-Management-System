using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System.Models
{
    public class OutSourced : Part
    {
        public string CompanyName { get; set; }

        public OutSourced(int partID, string name, decimal price, int inStock, int min, int max, string companyName)
        {
            CompanyName = companyName;
        }
    }

}

