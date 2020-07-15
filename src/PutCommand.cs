using System;
using System.Collections.Generic;
using System.Text;

namespace Task5_1
{
    public class PutCommand : Command
    {
        public PutCommand(string[] ids) : base(ids) { }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length != 1 && text.Length != 2 && text.Length != 4) //size check
            {
                return "Error in put command";
            }
            if (text[0] != "put" && text[0] != "drop") //1st word check
            {
                return "Error in put command";
            }
            if (text.Length == 1 && (text[0] == "put" || text[0] == "drop"))
            {
                return "What do you want to drop?";

            }

            IHaveInventory container = null; //IhaveInventory setup
            string item = ""; //stores item ID
            string containerID = ""; //stores container ID

            if (text.Length > 1)
            {
                if (text[0] == "put" || text[0] == "drop") 
                {
                    if (text.Length == 2) //2 word commands
                    {
                        item = text[1];
                        container = p.Location;
                        containerID = p.Location.Name;

                    }
                    if (text.Length == 4) //4 words commands
                    {
                        if (text[2] == "in") //3rd word should be in
                        {
                            item = text[1];
                            container = (IHaveInventory)(p.Locate(text[3]));
                            containerID = text[3];
                        }
                        else
                        {
                            return "Where do you want to drop the item?";
                        }
                    }
                }
            }

            if (container == null) //if container could not be retrieved
            { return "I cannot find the " + text[3] + "! Try again!!"; }
            else
            { return this.pickup(item, container, p, containerID); }
        }

        public string pickup(string item, IHaveInventory container, Player p, string containerID)
        {
            Item drop;
            drop = p.Inventory.Take(item);

            if (drop == null) //if item cannot be found
            {
                string message = "I could not find " + item + " from the " +
                    containerID;
                return message;
            }

            else // dropped item successfully
            {
                container.Inventory.Put(drop);
                string message = "You have put the " + item + " in " + containerID;
                return message;
            }

        }
    }
}
