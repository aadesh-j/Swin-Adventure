using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task5_1;

namespace Iteration9
{

    public class TakeCommandUnitTest
    {
        //player setup
        private Player Jack = null;
        //put command setup 
        private TakeCommand pick = null;


        //example item for testing
        Item book = new Item(new string[] { "book" }, "a textbook", "big science textbook");
        Item watch = new Item(new string[]{"watch"},"a wristwatch","casio wristwatch");

        //example locations and bag for testing
        Bag bag = new Bag(new[] { "bag" }, "jacks bag", "big duffle bag");
        Locations casino = new Locations(new[] { "casino" }, "crown casino", "big crown casino");


        [SetUp]
        public void Setup()
        {
            pick = new TakeCommand(new string[] { "pickup", "take" });

            //example player for testing
            Jack = new Player("Jack", "engineer");

            //items added to location and bag
            
            casino.Inventory.Put(book);
            Jack.Location = casino;
            Jack.Inventory.Put(bag);
            bag.Inventory.Put(watch);
        }


        [Test()]
        public void TestDroppingItem() //taking item into player's inventory
        {
            Assert.IsFalse(Jack.Inventory.HasItem("book")); //checking for item before picking up
            Assert.AreEqual(pick.Execute(Jack, new string[] { "pickup", "book" }), "You have taken the book from the " + Jack.Location.Name);
            Assert.IsTrue(Jack.Inventory.HasItem("book")); //checking for item after picking up in inventory

        }


        [Test()]
        public void TestTakingItemFromBag() //taking from another inventory
        {
            Assert.IsFalse(Jack.Inventory.HasItem("watch")); //checking for item before picking up from bag
            Assert.IsTrue(bag.Inventory.HasItem("watch")); //checking bag for item before picking up from bag

            Assert.AreEqual(pick.Execute(Jack, new string[] { "take", "watch", "from", "bag" }), "You have taken the watch from the " + bag.FirstId);
            
            Assert.IsTrue(Jack.Inventory.HasItem("watch")); //checking for item after dropping in inventory
        }


        [Test()]
        public void TestTakeOnly() //using pickup or take without object
        {
            Assert.AreEqual(pick.Execute(Jack, new string[] { "take" }), "What do you want to take?");
            Assert.AreEqual(pick.Execute(Jack, new string[] { "pickup" }), "What do you want to take?");
        }



        [Test()]
        public void TestDropWithNoObject() //taking invalid object
        {
            Assert.AreEqual(pick.Execute(Jack, new string[] { "take", "null" }), "I could not pickup null from the " + Jack.Location.Name);
            Assert.AreEqual(pick.Execute(Jack, new string[] { "pickup", "clock" }), "I could not pickup clock from the " + Jack.Location.Name);
        }


        [Test()]
        public void TestTakeFromNullContainer() //taking from unavailable container
        {
            Assert.AreEqual(pick.Execute(Jack, new string[] { "take", "book", "from", "dsad" }), "I cannot find the dsad! Try again!!");
            Assert.AreEqual(pick.Execute(Jack, new string[] { "pickup", "book", "from", "dsad" }), "I cannot find the dsad! Try again!!");
        }


        [Test()]
        public void TestInvalidTake() //testing invalid take
        {
            Assert.AreEqual(pick.Execute(Jack, new string[] { "pickup", "book", "dfsdf", "hotel" }), "Where do you want to pickup the item from?");
            Assert.AreEqual(pick.Execute(Jack, new string[] { "takexf" }), "Error in take command");
            Assert.AreEqual(pick.Execute(Jack, new string[] { "take", "ssad", "from", "fdsf", "dst", "fds" }), "Error in take command");
        }
    }
}
