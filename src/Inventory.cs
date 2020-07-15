using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_1
{
    public class Inventory
    {
        /*--------------------------------------------------------------------------------*/
        List<Item> _inventoryList = new List<Item>();
        /*--------------------------------------------------------------------------------*/

        public Inventory() { }

        public List<Item> GetList()
        { return _inventoryList; }

        public bool HasItem(string id)
        {
            foreach (Item item in _inventoryList)
            {
                if (item.AreYou(id))
                {
                    return true;
                }
            }

            return false;
        }


        public void Put(Item item) //item is added to list
        {
            _inventoryList.Add(item);
        }


        public Item Take(string id) //returns the item
        {
            foreach (Item item in _inventoryList)
            {
                if (item.AreYou(id))
                {
                    _inventoryList.Remove(item);
                    return item;
                }
            }
            return null;
        }

        public Item Fetch(string id)
        {
            foreach (Item item in _inventoryList)
            {
                if (item.AreYou(id))
                {
                    return item;
                }
            }
            return null;
        }

        public string ItemList
        {
            get
            {
                string items = string.Empty;
                foreach (Item item in _inventoryList)
                {
                    items += "\t" + item.ShortDescription;
                    items += "\n";
                }
                return items;
            }
        }
    }
}
