using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task5_1;


namespace Iteration3
{
    public class BagUnitTest
    {
       
        //new items are created
        Item pen = new Item(new string[] { "pen" }, "a pen", "blue coloured pen");
        Item book = new Item(new string[] { "book" }, "a book", "a big novel");
        

        //b1 and b2 are created for TestBaginBag
        Bag b1 = new Bag(new[] { "b1" }, "bag_1", "bag is small");
        Bag b2 = new Bag(new[] { "b2" }, "bag_2", "bag is big");

        //my bag is setup
        private Bag my_bag = null;

        [SetUp]
        public void BagTesting()
        {
            my_bag = new Bag(new[] { "aadesh_bag" }, "bag", "big_bag");
            my_bag.Inventory.Put(pen);
            my_bag.Inventory.Put(book);

            b1.Inventory.Put(pen); //item added to b1
            b2.Inventory.Put(book); //item added to b2
            b1.Inventory.Put(b2); //b2 is put into b1
        }

        [Test()]
        public void TestBagLocatesItems()
        {
            Assert.AreEqual(pen, my_bag.Locate("pen"));
            Assert.AreEqual(book, my_bag.Locate("book"));
        }

        [Test()]
        public void TestBagLocatesItself() 
        {
            Assert.AreEqual(my_bag, my_bag.Locate("aadesh_bag")); ;
        }

        [Test()]
        public void TestBagLocatesNothing() //null is returned 
        {
            Assert.IsNull(my_bag.Locate("somebody_bag"));
        }

        [Test()]
        public void TestBagFullDescritption()
        {
            string message = "In the " + my_bag.Name + " you can see:\n" + "\ta pen (pen)\n\ta book (book)\n";
            Assert.AreEqual(message, my_bag.FullDescription);
        }

        [Test()]
        public void TestBagInBag() //testing items in bag
        {
            //b1 can locate in b2
            Assert.AreEqual(b2, b1.Locate("b2"));
            //b1 can locate items in b1
            Assert.AreEqual(pen, b1.Locate("pen"));
            //b1 can not locate items in b2
            Assert.AreNotEqual(book, b1.Locate("book"));
        }
    }
}
