using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_1
{

    public class GameObject : IdentifiableObject 
    {
        //properties and variables
        /*--------------------------------------------------------------------------------*/
        private string _description;
        private string _name;

        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        /*--------------------------------------------------------------------------------*/

        public string ShortDescription //short description with item name
        {
            get
            {
                return Name + " (" + FirstId + ")";
            }
        }

        public virtual string FullDescription //full description of the item
        {
            get
            {
                return _description;
            }
        }

        public GameObject(string[] ids, string name, string desc) : base(ids)
        {
            _name = name;
            _description = desc;
        }
    }
}
