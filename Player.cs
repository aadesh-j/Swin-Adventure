using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task5_1
{

    public class Player : GameObject, IHaveInventory
    {
        /*------------------------------------------------------*/
        private Inventory _inventory = new Inventory();
        public Inventory Inventory { get => _inventory; set => _inventory = value; }

        private Locations _location = new Locations(new string[] { }, "", "");
        public Locations Location { get => _location; set => _location = value; }

        /*------------------------------------------------------*/

        public override string FullDescription //returns full description of item
        {
            get
            {
                string message = "You are " + Name + " the " + base.FullDescription;
                return message += "\nYou are carrying:\n" + Inventory.ItemList;
                
            }
        }


        public Player(string name, string desc) : base(new string[] { "me", "inventory" }, name, desc)
        { }

        public GameObject Locate(string id)
        {

            if (AreYou(id))
            { return this; }
            else if (_inventory.HasItem(id))
            { return Inventory.Fetch(id); }
            else
            { return Location.Locate(id);
        }

            


        }
    }
}
