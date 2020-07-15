using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Task5_1
{
    public class LookCommand : Command 
    {
        public string[] message; //set to public to be accessible to all methods
        public LookCommand(string[] ids) : base(ids) {  }


        public override string Execute(Player p, string[] text)
        {
            
           
            IHaveInventory container = null;

            message = new string[6]; //return message array
            message[0] = "I don't know how to look like that";
            message[1] = "Error in look input";
            message[2] = "What do you want to look at?";
            message[3] = "What do you want to look in?";
           
          

            if (!(text.Length == 1 || text.Length == 3 || text.Length == 5)) //size 3 or 5
            {
                return message[0];

            }
            if (text[0] != "look") //1st word must be look
            {
                return message[1];
            }

            if (text.Length == 1)
            {
                if (text[0] == "look") //returning location's full descritpion when look is entered
                {
                    return p.Location.FullDescription;
                }
            }


            if (text[1] != "at") //2nd word is at
            {
                return message[2];
            }


            if (text.Length == 5 && text[3] != "in") //5 elements and 4th is "in"
            {
                return message[3];
            }


            if (text.Length == 3) //3 elements
            {
                container = p; //container is the player
            }



            if (text.Length == 5) //5 elements
            {
                container = FetchContainer(p, text[4]); //container id is the 5th word
                string containerIDD = text[4];
                message[4] = "I cannot find the " + containerIDD;

                if (container == null) //player does not have container
                {
                    return message[4];
                }
            }

            string itemID = text[2]; //3rd word becomes the item id
            message[5] = "I can't find the " + text[2];

            return LookAtIn(itemID, container); //lookatin performed with container and item id
        }

        private IHaveInventory FetchContainer(Player p, string containerID)
        {

            return p.Locate(containerID) as IHaveInventory;
        }

        string LookAtIn(string thingId, IHaveInventory container)
        {
            GameObject find = container.Locate(thingId);

            if (find == null) //if the gem could not be found
            {
                return message[5]; //not found.
            }

            else
            {
                return find.FullDescription; //descritpion returned
            }
        }
    }
}
