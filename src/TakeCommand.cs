using System;
using System.Collections.Generic;
using System.Text;

namespace Task5_1
{
    public class TakeCommand : Command
    {
        public TakeCommand(string[] ids) : base(ids) { }

        public override string Execute(Player p, string[] text)
        {

            if (text.Length != 1 && text.Length != 2 && text.Length != 4) //size check
            {
                return "Error in take command";
            }
            if (text[0] != "take" && text[0] != "pickup")  //1st word check
            { 
                return "Error in take command";
            }
            if (text.Length == 1 && (text[0] == "take" || text[0] == "pickup") )
            { 
                return "What do you want to take?";

            }

            IHaveInventory container = null; //IhaveInventory setup
            string item = ""; //stores item ID
            string containerID = ""; //stores container ID
            if (text.Length > 1)
            {
                if (text[0] == "take" || text[0] == "pickup")
                {
                    if (text.Length == 2) //2 word commands
                    {
                        item = text[1];
                        container = p.Location;
                        containerID = p.Location.Name ;
                         
                    }
                    if (text.Length == 4) //4 words commands
                    {
                        if (text[2] == "from") //3rd word should be from
                        {
                            item = text[1];
                            container = (IHaveInventory)(p.Locate(text[3]));
                            containerID = text[3];
                        }
                        else
                        {
                            return "Where do you want to pickup the item from?";
                        }
                    }
                
                }
            }

            if (container == null) //if container could not be retrieved
            { return "I cannot find the " + text[3] + "! Try again!!"; }
            else
            { return pickup(item, container, p,containerID); }
        }


        public string pickup(string item, IHaveInventory container, Player p,string containerID)
        {
            Item picked;
            picked = container.Inventory.Take(item);

            if (picked == null) //if item cannot be found
            {
                string message = "I could not pickup " + item + " from the " +
                    containerID;
                return message;
            }

            else
            {
                p.Inventory.Put(picked); // picked up item successfully
                string message = "You have taken the " + item + " from the " + containerID;
                return message;
            }      
        
        }

    }
}
