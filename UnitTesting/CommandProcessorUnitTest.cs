using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task5_1;

namespace Iteration8
{
    public class CommandProcessorUnitTest
    {
        // Testing Look and Move commands only using command processor

        private Path north;
        private Path south;

        //setting up player
        Player me = new Player("me", "super programmer");


        //example item for testing
        Item diamond_gem = new Item(new string[] { "gem" }, "diamond_gem", "small diamond gem");

        //example bag for testing
        Bag jack_bag = new Bag(new[] { "bag" }, "jack_bag", "big_bag");




        //adding new locations for movement
        Locations Hotel = new Locations(new string[] { "Hotel" }, "star hotel", "a huge star hotel");
        Locations Motel = new Locations(new string[] { "Motel" }, "small motel", "a small green motel");

        CommandProcessor command = new CommandProcessor(); 

        [SetUp()]
        public void PathUnitTestSetup()
        {
            //gem added to inventory
            jack_bag.Inventory.Put(diamond_gem);
            //bag added to players inventory
            me.Inventory.Put(jack_bag);
            //gem added to players inventory
            me.Inventory.Put(diamond_gem);

            //adding new paths
            north = new Path(new string[] { "north" }, "north", "a door", Hotel, Motel);
            south = new Path(new string[] { "south" }, "south", "a hallway", Motel, Hotel);

            me.Location = Hotel; //setting player location

        }

        [Test()]
        public void TestMoveCommand() //testing moving command
        {
            me.Location = Hotel;
            Hotel.Put(north);
            string expected = "You head north\nYou travel through a door\nYou have arrived at small motel";
            Assert.AreEqual(expected, command.Process(me, new string[] { "move", "north" }));
        }

        [Test()]
        public void TestMoveBackCommand() //testing moving back
        {
            Hotel.Put(south);
            string expected = "You head south\nYou travel through a hallway\nYou have arrived at star hotel";
            Assert.AreEqual(expected, command.Process(me, new string[] { "move", "south" }));
        }

        [Test()]
        public void TestLookAtMe() //player description return check using command processor
        {
            string expected = "You are me the super programmer\nYou are carrying:\n\tjack_bag (bag)\n\tdiamond_gem (gem)\n";
            Assert.AreEqual(expected, command.Process(me, new string[] { "look", "at", "inventory" }));
        }



    }
}
