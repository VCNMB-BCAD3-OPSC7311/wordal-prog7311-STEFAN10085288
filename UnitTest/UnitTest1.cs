using ICE_1__words_API;

namespace UnitTest
{
    //meneer se code
    [TestClass]
    public class UnitTest1
    {
        WordsClass w = WordsClass.getInstance();

        [TestMethod]
        public void TestAll()
        {
            String[] expected = new String[10];
            expected[0] = "Freezing";
            expected[1] = "Bracing";
            expected[2] = "Chilly";
            expected[3] = "Cool";
            expected[4] = "Mild";
            expected[5] = "Warm";
            expected[6] = "Balmy";
            expected[7] = "Hot";
            expected[8] = "Sweltering";
            expected[9] = "Scorching";

            CollectionAssert.AreEqual(expected, w.All());     
        }

        [TestMethod]
        public void TestOne() 
        {
            Assert.IsNotNull(w.Single());
        }


        [TestMethod]
        public void TestSorted()
        {
            String[] expected = new String[10];
            expected[0] = "Freezing";
            expected[1] = "Bracing";
            expected[2] = "Chilly";
            expected[3] = "Cool";
            expected[4] = "Mild";
            expected[5] = "Warm";
            expected[6] = "Balmy";
            expected[7] = "Hot";
            expected[8] = "Sweltering";
            expected[9] = "Scorching";

            CollectionAssert.AreEqual(expected.OrderBy(x=>x).ToArray(), w.Sorted());
        }
    }
}