using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //IdentifiableObject _identifiers = new IdentifiableObject(new string[] { });
            //Console.WriteLine(_identifiers.FirstId);

            /*----------------------------------------------------------------------------*/

            Console.WriteLine("Hello! Welcome to Swin-Adventure!!");
            Console.WriteLine("You have arrived in the Hotel" );
            Console.WriteLine("Please enter your name: ");
            string playerName = Console.ReadLine();
            Console.WriteLine("Please enter the description: ");
            string playerDescription = Console.ReadLine();

            //Creating Player Object
            Player mainPlayer = new Player(playerName, playerDescription);
            Locations Hotel = new Locations(new string[] { "hotel" }, "star hotel", "a huge star hotel. \nThere is a door facing north.");
     
            
            //Creating Two Items
            Item pencil = new Item(new string[] { "pencil" }, "lead pencil", "black lead pencil");
            Item cup = new Item(new string[] { "cup" }, "coffee cup", "blue coffee cup");
            mainPlayer.Inventory.Put(pencil);
            mainPlayer.Inventory.Put(cup);

            //Creating Bag
            Bag mainBag = new Bag(new[] { "bag" },"main bag", "green colour bag");
            mainPlayer.Inventory.Put(mainBag);

            //Creating item to add to bag
            Item bottle = new Item(new string[] { "bottle" }, "water bottle", "yellow water bottle");
            mainBag.Inventory.Put(bottle);

           
          

            mainPlayer.Location = Hotel;

            //Creating items for the location
            Item statue = new Item(new string[] { "statue" }, "an ironman statue", "a red ironman statue");
            Item fountain = new Item(new string[] { "fountain" }, "water fountain", "a big water fountain");
            Bag suitcase = new Bag(new string[] { "suitcase" },"brown suitcase","a louis vuitton suitcase");

            //Adding items to location
            Hotel.Inventory.Put(statue);
            Hotel.Inventory.Put(fountain);
            Hotel.Inventory.Put(suitcase);

            //Adding items to bag in location
            Item shirt = new Item(new string[] { "shirt" }, "white shirt", "a small white shirt");               
            suitcase.Inventory.Put(shirt);

            //Command process to find commands
            CommandProcessor command = new CommandProcessor();

            //Adding Locations and paths for user
            Locations School = new Locations(new string[] { "School" }, "swinburne", "swinburne university of technology");
            Locations Motel = new Locations(new string[] { "Motel" }, "small motel", "a small green motel. There is hallway towards the north.");
            Path north = new Path(new string[] { "north" }, "north", "a door", Hotel, Motel);
            mainPlayer.Location = Hotel;
            Hotel.Put(north);

           
            Path south = new Path(new string[] { "south" }, "south", "a hallway", Motel, Hotel);
            Motel.Put(south);



            string[] option;
            do
            {
                Console.WriteLine("Please enter your command (Type 'exit' to quit): ");
                option = Console.ReadLine().Split(' ');

                Console.WriteLine(command.Process(mainPlayer, option));      
            }
            while (option[0] != "exit");
         

        }
    }
}
