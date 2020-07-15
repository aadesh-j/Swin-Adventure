using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task5_1;

namespace Iteration4
{

    public class LookCommandUnitTest
    {
        //player setup
        private Player Jack = null;
        //lookcommand setup 
        private LookCommand find = null;
        // //set to public to be accessible to all methods
        public string[] message;

        //example item for testing
        Item diamond_gem = new Item(new string[] { "gem" }, "diamond_gem", "small diamond gem");
        //example bag for testing
        Bag jack_bag = new Bag(new[] { "bag" }, "jack_bag", "big_bag");

        [SetUp]
        public void Setup()
        {
            find = new LookCommand(new string[] { "look" });
            //example player for testing
            Jack = new Player("Jack", "engineer");

            //messages for testing
            message = new string[5];
            message[0] = "You are Jack the engineer\nYou are carrying:\n\tjack_bag (bag)\n\tdiamond_gem (gem)\n";
            message[1] = "small diamond book";
            message[2] = "I cannot find the new_bag";
            message[3] = "I can't find the ";
            message[4] = "I don't know how to look like that";

            //gem added to inventory
            jack_bag.Inventory.Put(diamond_gem);
            //bag added to players inventory
            Jack.Inventory.Put(jack_bag);
            //gem added to players inventory
            Jack.Inventory.Put(diamond_gem);
        }


        [Test()]
        public void TestLookAtMe() //player description return check
        {   
            Assert.AreEqual(message[0], find.Execute(Jack, new string[] { "look", "at", "inventory" }));
        }
        
       
        [Test()]
        public void TestLookAtGem() //gem descritption return check
        {
            Assert.AreEqual(message[1], find.Execute(Jack, new string[] { "look", "at", "gem" }));
        }


        [Test()]
        public void TestLookAtUnk() //no item return check
        {
            Assert.AreEqual(message[3] + "unk", find.Execute(Jack, new string[] { "look", "at", "unk" }));
        }


        [Test()]
        public void TestLookAtGemInMe() //gem description (when looking in inventory) return check
        {
            Assert.AreEqual(message[1], find.Execute(Jack, new string[] { "look", "at", "gem", "in", "inventory" }));
        }


        [Test()]
        public void TestLookAtGemInBag() //gem descritpion (when looking in a bag in inventory) return check 
        {
            Assert.AreEqual(message[1], find.Execute(Jack, new string[] { "look", "at", "gem", "in", "bag" }));
        }


        [Test()]
        public void TestLookAtGemInNoBag() //no bag return check
        {
            Assert.AreEqual(message[2], find.Execute(Jack, new string[] { "look", "at", "gem", "in", "new_bag" }));
        }


        [Test()]
        public void TestLookAtNoGemInBag() //no gem in bag return check
        {
            Assert.AreEqual("I can't find the exotic_gem", find.Execute(Jack, new string[] { "look", "at", "exotic_gem", "in", "bag" }));
        }


        [Test()]
        public void TestInvalidLook() //error condition testing
        {
            Assert.AreEqual(message[4], find.Execute(Jack, new string[] { "look", "behind"}));
            //assert.areequal(message[4], find.execute(jack, new string[] { "hi" }));
            //assert.areequal(message[2], find.execute(jack, new string[] { "look", "at", "me", "in", "there" }));
            //assert.areequal(message[4], find.execute(jack, new string[] { "look", "at", "gem", "in", "bag", "hello" }));
        }
    }

}
