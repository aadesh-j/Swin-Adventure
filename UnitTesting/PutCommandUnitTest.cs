using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task5_1;

namespace Iteration9
{

    public class PutCommandUnitTest
    {
        //player setup
        private Player Jack = null;
        //put command setup 
        private PutCommand dropit = null;


        //example item for testing
        Item book = new Item(new string[] { "book" }, "a textbook", "big science textbook");

        //example locations and bag for testing
        Bag bag = new Bag(new[] { "bag" }, "jacks bag", "big duffle bag");
        Locations casino = new Locations(new[] { "casino" }, "crown casino", "big crown casino");


        [SetUp]
        public void Setup()
        {
            dropit = new PutCommand(new string[] { "drop", "put" });

            //example player for testing
            Jack = new Player("Jack", "engineer");

            //items added to location and bag
            Jack.Inventory.Put(bag);
            Jack.Inventory.Put(book);
            Jack.Location = casino;
        }


        [Test()]
        public void TestDroppingItem() //dropping item from players inventory
        {
            Assert.IsFalse(casino.Inventory.HasItem("book")); //checking for item before dropping
            Assert.AreEqual(dropit.Execute(Jack, new string[] { "drop", "book" }), "You have put the book in " + Jack.Location.Name);
            Assert.IsTrue(casino.Inventory.HasItem("book")); //checking for item after dropping
        }


        [Test()]
        public void TestDroppingItemInBag() //dropping item into a another inventory
        {
            Assert.IsFalse(bag.Inventory.HasItem("book")); //checking for item before dropping
            Assert.AreEqual(dropit.Execute(Jack, new string[] { "put", "book", "in", "bag" }), "You have put the book in " + bag.FirstId);
            Assert.IsTrue(bag.Inventory.HasItem("book")); //checking for item after dropping
        }


        [Test()]
        public void TestDropOnly() //using put or drop without object
        {
            Assert.AreEqual(dropit.Execute(Jack, new string[] { "put" }), "What do you want to drop?");
            Assert.AreEqual(dropit.Execute(Jack, new string[] { "drop" }), "What do you want to drop?");
        }



        [Test()]
        public void TestDropWithNoObject() //dropping invalid object
        {
            Assert.AreEqual(dropit.Execute(Jack, new string[] { "put", "null" }), "I could not find null from the " + Jack.Location.Name);
            Assert.AreEqual(dropit.Execute(Jack, new string[] { "drop", "clock" }), "I could not find clock from the " + Jack.Location.Name);
        }


        [Test()]
        public void TestDropInNullContainer() //dropping in unavailable container
        {
            Assert.AreEqual(dropit.Execute(Jack, new string[] { "put", "book", "in", "dsad" }), "I cannot find the dsad! Try again!!");
            Assert.AreEqual(dropit.Execute(Jack, new string[] { "drop", "book", "in", "dsad" }), "I cannot find the dsad! Try again!!");
        }


        [Test()]
        public void TestInvalidPut() //testing invalid put
        {
            Assert.AreEqual(dropit.Execute(Jack, new string[] { "put", "book", "dfsdf", "hotel" }), "Where do you want to drop the item?");
            Assert.AreEqual(dropit.Execute(Jack, new string[] { "putxf" }), "Error in put command");
            Assert.AreEqual(dropit.Execute(Jack, new string[] { "put","ssad","in","fdsf","dst","fds" }), "Error in put command");
        }
    }
}
