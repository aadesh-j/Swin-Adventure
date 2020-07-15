using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_1
{
    public class Locations : GameObject,  IHaveInventory
    { 
        /*---------------------------------------------------------------------------*/
        private Inventory _inventory = new Inventory();
        public Inventory Inventory { get => _inventory; set => _inventory = value; }

        private List<Path> _path = new List<Path>();
        public List<Path> Path { get => _path; set => _path = value; }

        /*---------------------------------------------------------------------------*/

        public Locations(String[] ids, string name, string desc) : base(ids, name, desc) { }

        public GameObject Locate(string id)
        {
            if (AreYou(id)) { return this; }
            else { return Inventory.Fetch(id); }
        }

        public void Put(Player player) //player to location
        {
            player.Location = this;
            
        }

        public void Put(Path path) //adding item to inventory
        { 
            _path.Add(path);
        }

        public Path ReturnPath(string id)
        {
            foreach (Path p in _path)
            {
                if (p.AreYou(id))
                    return p;
            }
            return null;

        }


        public override string FullDescription //returns full description of item
        {
            get
            {
                string message = "You are in the " + Name +"\nThis is "+ Description +"\nIn the " + Name + " you can see:\n" + Inventory.ItemList;
                return message;
            }
        }

   
    }
}
