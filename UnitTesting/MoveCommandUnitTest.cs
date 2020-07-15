using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task5_1;

namespace Iteration7
{
    public class MoveCommandUnitTest
    {
        private Path north;
        private Path south;
        //Setting up player
        Player me = new Player("me", "super programmer");
        
        //Adding Locations
        Locations Hotel = new Locations(new string[] { "Hotel" }, "star hotel", "a huge star hotel");
        Locations Motel = new Locations(new string[] { "Motel" }, "small motel", "a small green motel");
        
        //Adding move commands
        MoveCommand shift;

        [SetUp()]
        public void PathUnitTestSetup()
        {
            north = new Path(new string[] { "north" }, "north", "a door", Hotel, Motel);
            south = new Path(new string[] { "south" }, "south", "a hallway", Motel, Hotel);

            me.Location = Hotel; //setting players location


            shift = new MoveCommand(new string[] { "move", "go", "leave", "head" });

        }


        [Test()]
        public void TestMoveCommand() //testing moving command
        {
            me.Location = Hotel;
            Hotel.Put(north);
            string expected = "You head north\nYou travel through a door\nYou have arrived at small motel";
            Assert.AreEqual(expected, shift.Execute(me, new string[] { "move", "north" }));
        }

        [Test()]
        public void TestMoveBackCommand() //testing moving back
        {
            Hotel.Put(south);
            string expected = "You head south\nYou travel through a hallway\nYou have arrived at star hotel";
            Assert.AreEqual(expected, shift.Execute(me, new string[] { "move", "south" }));
        }

        [Test()]
        public void TestMoveWithNoPath() //testing moving to invalid path
        {
            string expected = "The path was not found!!";
            Assert.AreEqual(expected, shift.Execute(me, new string[] { "go", "under" }));
        }


}
}
