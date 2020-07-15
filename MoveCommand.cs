using System;
using System.Collections.Generic;
using System.Text;

namespace Task5_1
{
    public class MoveCommand : Command
    {
        public MoveCommand(string[] ids) : base(ids) { }
        
        

        public override string Execute(Player p, string[] text)
        {
            if (text.Length > 2 || text.Length < 1)
            {
                return "That path does not exist";
            }
            if (text.Length == 1)
            {
                return "Where do you want to go?";
            }

            if (text[0] != "move" && text[0] != "leave" && text[0] != "go" && text[0] != "head")
            { return "Error in move command"; }
            else
            {
                Locations l = p.Location;
                Path path = l.ReturnPath(text[1]); //location returned as per user input

                if (path == null)
                    return "The path was not found!!";
                else
                {
                    path.Go(p);
                    string message;
                    message = "You head " + path.Name + "\nYou travel through " + path.FullDescription + "\nYou have arrived at " + path.Final.Name;
                    return message;
                }
            }

        }


    }



}
