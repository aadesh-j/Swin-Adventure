using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_1
{
    public class Path : Item
    {
        /*-------------------------------------------------------------------------*/
        private Locations _initial = null;
        private Locations _final = null;
      
        public Locations Initial { get => _initial; set => _initial = value; }
        public Locations Final { get => _final; set => _final = value; }
       
        /*-------------------------------------------------------------------------*/


        public Path(String[] ids, string name, string desc, Locations initial, Locations final) : base(ids, name, desc)
        {
            _initial = initial;
            _final = final;


        }

        
        
        public void Go(Player player)
        {
            player.Location = Final;
        }
      
    }



}
