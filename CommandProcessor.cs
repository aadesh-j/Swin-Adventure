using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task5_1
{
    public class CommandProcessor
    {
        /*--------------------------------------------------------------------------------------*/
        private List<Command> _commandList = new List<Command>() 
        { 
            //adding new commands
            new LookCommand(new string[] { "look" }) , 
            new MoveCommand(new string[]{"move", "go", "leave", "head" }), 
            new TakeCommand(new string[] {"take","pickup" }),
            new PutCommand(new string[]{"put","drop"})        
        };
        public List<Command> CommandList { get => _commandList; set => _commandList = value; }
        /*---------------------------------------------------------------------------------------*/

        public Command Find(string text)
        {
            return CommandList.Find(command => command.AreYou(text));  //searches for command
        }

        public string Process(Player p, string[] text)
        {
            var command = Find(text[0]); //stores 1st word of command
            if (command == null) //checks if command is present
            {
                return "Cannot find command! Please try again!";             
            }
            return command.Execute(p, text);
        }



    }
}
