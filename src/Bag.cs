using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_1
{
    public class Bag : Item, IHaveInventory 
    {
        /*--------------------------------------------------------------------------------*/
        private Inventory _inventory = new Inventory();
        public Inventory Inventory { get => _inventory; set => _inventory = value; }
        /*--------------------------------------------------------------------------------*/

        public Bag(String[] ids, string name, string desc) : base(ids, name, desc) { }


        public GameObject Locate(string id)
        {
            if (AreYou(id)) { return this; }
            else { return _inventory.Fetch(id); }
        }

        public override string FullDescription
        {      
            get
            {
                string message = "In the " + Name + " you can see:\n" + Inventory.ItemList;
                return message; 
            }
        }

    }
}
