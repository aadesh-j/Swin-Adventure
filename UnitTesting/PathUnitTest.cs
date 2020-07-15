using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task5_1;

namespace Iteration7
{

    public class PathUnitTest
    {

        private Path north;
        private Path south;

        //setting up player
        Player me = new Player("me", "super programmer");

        //adding new locations for movement
        Locations Hotel = new Locations(new string[] { "Hotel" }, "star hotel", "a huge star hotel");
        Locations Motel = new Locations(new string[] { "Motel" }, "small motel", "a small green motel");


        [SetUp()]
        public void PathUnitTestSetup()
        {
            //adding new paths
            north = new Path(new string[] { "north" }, "north", "a door", Hotel, Motel);
            south = new Path(new string[] { "south" }, "south", "a hallway", Motel, Hotel);

            me.Location = Hotel; //setting player location

        }


        [Test()]
        public void TestPlayerPaths() //test to check if path works
        {
            north.Go(me);
            Assert.AreEqual(me.Location, Motel);
        }

        [Test()]
        public void TestReturnPath() //test additonal paths after movement
        {
            me.Location = Motel;
            south.Go(me);
            Assert.AreEqual(me.Location, Hotel);
        }


    }
}
