using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.IO.Ports;

namespace Inventory_Management_System.Models
{
    public class Product
    {
        // Properties
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }

        //Creates a binding list called "Product"
        //public static BindingList<Product> products = new BindingList<Product>();
        public BindingList<Part> AssociatedParts { get; set; } = new BindingList<Part>();

        public static int CurrentIndexPart { get; set; }
        public static int CurrentIndexAssociatedPart { get; set; }

        // Method to add an associated part
        public void addAssociatedPart(Part part)
        {
            AssociatedParts.Add(part);
        }

        // Method to remove an associated part by ID
        // Returns true if the part was successfully removed
        public bool removeAssociatedPart(int partID)
        {
            var part = lookupAssociatedPart(partID);
            if (part != null)
            {
                AssociatedParts.Remove(part);
                return true;
            }
            return false;
        }

        // Method to find an associated part by ID
        // Returns the part if found, otherwise returns null
        public Part lookupAssociatedPart(int partID)
        {
            foreach (var part in AssociatedParts)
            {
                if (part.PartID == partID)
                    return part;
            }
            return null;
        }
    }
}

