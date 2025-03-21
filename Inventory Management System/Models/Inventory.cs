using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Xml.Linq;

namespace Inventory_Management_System.Models
{
    public class Inventory
    {
        // Properties to store products and parts
        public static BindingList<Product> Products { get; set; } = new BindingList<Product>();
        public static BindingList<Part> AllParts { get; set; } = new BindingList<Part>();

        public static BindingList<Product> GetProducts { get; set; }
        public static BindingList<Part> GetParts { get; set; }

        public static int CurrentIndex { get; set; }
        public static Part CurrentPart { get; set; }
        public static Product CurrentProduct { get; set; }

        public static void SetStartingParts()
        {
            Part widgetPart1 = new OutSourced(1, "CPU", 299.9m, 100, 10, 1000, "Intel");
            Part widgetPart2 = new OutSourced(2, "RAM", 149.9m, 100, 10, 1000, "Corsair");
            Part widgetPart3 = new OutSourced(3, "GPU", 249.9m, 100, 10, 1000, "NVIDIA");

            Part widgetPart4 = new InHouse(4, "NIC", 49.9m, 100, 10, 1000, 001);
            Part widgetPart5 = new InHouse(5, "PSU", 99.9m, 100, 10, 1000, 002);
            Part widgetPart6 = new InHouse(6, "CMOS", 99.9m, 100, 10, 1000, 003);

            // Add parts to the parts list
            Inventory.AllParts.Add(widgetPart1);
            Inventory.AllParts.Add(widgetPart2);
            Inventory.AllParts.Add(widgetPart3);
            Inventory.AllParts.Add(widgetPart4);
            Inventory.AllParts.Add(widgetPart5);
            Inventory.AllParts.Add(widgetPart6);
        }

        public static void SetStartingProducts()
        {
            Product widgetProduct1 = new Product
            {
                ProductID = 1,
                Name = "HP Z230",
                Price = 1499.99m,
                InStock = 100,
                Min = 10,
                Max = 1000
            };
            
            Product widgetProduct2 = new Product
            {
                ProductID = 2,
                Name = "MacBook Air",
                Price = 2499.99m,
                InStock = 100,
                Min = 10,
                Max = 1000
            };
            
            Product widgetProduct3 = new Product
            {
                ProductID = 3,
                Name = "Lenovo ThinkPad",
                Price = 499.99m,
                InStock = 100,
                Min = 10,
                Max = 1000
            };
            
            Product widgetProduct4 = new Product
            {
                ProductID = 4,
                Name = "HP EliteDesk",
                Price = 1499.99m,
                InStock = 100,
                Min = 10,
                Max = 1000
            };
            
            Product widgetProduct5 = new Product
            {
                ProductID = 5,
                Name = "Commodore 64",
                Price = 2499.99m,
                InStock = 100,
                Min = 10,
                Max = 1000
            };

            Product widgetProduct6 = new Product
            {
                ProductID = 6,
                Name = "HP Pavillion",
                Price = 499.99m,
                InStock = 100,
                Min = 10,
                Max = 1000
            };

            Inventory.Products.Add(widgetProduct1);
            Inventory.Products.Add(widgetProduct2);
            Inventory.Products.Add(widgetProduct3);
            Inventory.Products.Add(widgetProduct4);
            Inventory.Products.Add(widgetProduct5);
            Inventory.Products.Add(widgetProduct6);
        }

        // Method to add a product to the inventory
        public void addProduct(Product product)
        {
            Inventory.Products.Add(product);
        }

        // Method to remove a product from the inventory by its ID
        // Returns true if the product was successfully removed
        public bool removeProduct(int productId)
        {
            var product = lookupProduct(productId); // Find the product by its ID
            if (product != null) // If product is found
            {
                Inventory.Products.Remove(product); // Remove it from the list
                return true; // Indicate that removal was successful
            }
            return false; // Indicate that the product was not found
        }

        // Method to find a product in the inventory by its ID
        // Returns the product if found, otherwise returns null
        public Product lookupProduct(int productID)
        {
            foreach (var product in Products) // Iterate through the list of products
            {
                if (product.ProductID == productID) // If a product with the given ID is found
                    return product; // Return the product
            }
            return null; // Return null if no product with the given ID is found
        }

        public Part lookupPart(int partID)
        {
            foreach (var part in AllParts) // Iterate through the list of products
            {
                if (part.PartID == partID) // If a product with the given ID is found
                    return part; // Return the product
            }
            return null; // Return null if no product with the given ID is found
        }

        // Method to update an existing product in the inventory
        public void updateProduct(int productId, Product updatedProduct)
        {
            var product = lookupProduct(productId); // Find the product by its ID
            if (product != null) // If product is found
            {
                var index = Products.IndexOf(product); // Get the index of the product in the list
                Products[index] = updatedProduct; // Replace the old product with the updated one
            }
        }

        // Method to add a part to the inventory
        public void addPart(Part part)
        {
            AllParts.Add(part);
        }

        // Method to delete a part from the inventory
        // Returns true if the part was successfully deleted
        public bool deletePart(Part part)
        {
            return AllParts.Remove(part); // Remove the part and return the result
        }

        // Method to update an existing part in the inventory
        public void updatePart(int partID, Part updatedPart)
        {
            var part = lookupPart(partID); // Find the part by its ID
            if (part != null) // If part is found
            {
                var index = AllParts.IndexOf(part); // Get the index of the part in the list
                AllParts[index] = updatedPart; // Replace the old part with the updated one
            }
        }
        public void addPart(int partID, Part updatedPart)
        {
            //Part.parts.Add(updatedPart);
        }
    }
}
