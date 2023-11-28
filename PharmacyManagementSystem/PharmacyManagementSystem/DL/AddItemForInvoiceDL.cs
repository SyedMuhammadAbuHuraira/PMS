using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmacyManagementSystem.BL;

namespace PharmacyManagementSystem.DL
{
    public class AddItemForInvoiceDL
    {
        public static  List<AddItemForInvoice> AddItemForInvoices = new List<AddItemForInvoice>();



        public static bool AddItem(AddItemForInvoice item)
        {
            // check if item already exists in the list
            foreach (AddItemForInvoice existingItem in AddItemForInvoices)
            {
                if (existingItem.Company == item.Company &&
                    existingItem.type == item.type &&
                    existingItem.name == item.name &&
                    existingItem.price == item.price &&
                    existingItem.batchID == item.batchID &&
                    existingItem.Quantity == item.Quantity &&
                    existingItem.pack == item.pack)
                {
                    // item already exists, return false
                    return false;
                }
            }

            // item does not exist, add to the list and return true
            AddItemForInvoices.Add(item);
            return true;
        }

        public static string getQuantity(int index)
        {
            // check if the specified index is within the range of the list
            if (index >= 0 && index < AddItemForInvoices.Count)
            {
                // retrieve the item at the specified index
                AddItemForInvoice item = AddItemForInvoices[index];

                // check if item already exists in the list
                foreach (AddItemForInvoice existingItem in AddItemForInvoices)
                {
                    if (existingItem.Company == item.Company &&
                        existingItem.type == item.type &&
                        existingItem.name == item.name &&
                        existingItem.price == item.price &&
                        existingItem.batchID == item.batchID &&
                        existingItem.pack == item.pack)
                    {
                        // item already exists, return the Quantity as a string
                        return existingItem.Quantity.ToString();
                    }
                }
            }

            // item does not exist in the list or the index is out of range, return "0" as a string
            return "0";
        }

        public static List<AddItemForInvoice> GetItems()
        {
            return AddItemForInvoices;
        }
        public static void RemoveItem(int index)
        {
            AddItemForInvoices.RemoveAt(index);
        }
        public static void ClearItems()
        {
            AddItemForInvoices.Clear();
        }



    }
}
