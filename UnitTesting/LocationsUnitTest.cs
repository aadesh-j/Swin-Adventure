using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task5_1;

namespace Iteration6
{   
    public class LocationsUnitTest
    {
        private Locations mainLocation = null;
        private Player programmer = null;

        Item pencil = new Item(new string[] { "pencil" }, "a pencil", "black lead pencil");
        Item cup = new Item(new string[] { "cup" }, "a cup", "blue coffee cup");


        [SetUp]
        public void LocationsUnitTestSetup()
        {
            mainLocation = new Locations(new string[] { "mainLocation" }, "helpdesk", "big software helpdesk");
            programmer = new Player("programmer","c++ programmer");
            mainLocation.Inventory.Put(cup);
            mainLocation.Inventory.Put(pencil);
            mainLocation.Put(programmer);
        }

        [Test()]
        public void TestLocationsIdentifiesThemselves() //Locations can identify themselves
        { 
        Assert.AreEqual(mainLocation, mainLocation.Locate("mainLocation"));
        }

        [Test()]
        public void TestLocationsLocatesItems() //Locating items
        {
            Assert.AreEqual(pencil, mainLocation.Locate("pencil"));
            Assert.AreEqual(cup, mainLocation.Locate("cup"));
        }

        [Test()]
        public void TestLocationsLocatesPlayers() //locating players
        {
            Assert.AreEqual(mainLocation, programmer.Location);
        }

        [Test()]
        public void TestLocationLocatesNothing() //null is returned 
        {
            Assert.IsNull(mainLocation.Locate("car"));
        }

        [Test()]
        public void TestLocationsFullDescription() //fulldescription test
        {
            string message = "You are in the " + mainLocation.Name + "\nThis is " + mainLocation.Description + "\nIn the " + mainLocation.Name + " you can see:\n" + "\ta cup (cup)\n\ta pencil (pencil)\n";
            Assert.AreEqual(message, mainLocation.FullDescription);
        }

    }
}
