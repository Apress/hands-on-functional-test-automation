
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sikuli4Net.sikuli_REST;


namespace SikuliDemo
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Screen screen = new Screen();
            Pattern pattern_SearchImage = new Pattern("F:\\SikuliImages\\Sikuli-search.png");
            Pattern pattern_searchTextField = new Pattern("F:\\SikuliImages\\sikuli-searchfield.png");
            Pattern pattern_searchResult = new Pattern("F:\\SikuliImages\\sikuli-searcresult.png");
            Pattern pattern_notepad = new Pattern("F:\\SikuliImages\\sikuli-notepad.png");
            screen.Find(pattern_SearchImage);
            screen.Click(pattern_SearchImage);
            screen.Find(pattern_searchTextField);
            screen.Type(pattern_searchTextField,"NotePad");
            screen.Find(pattern_searchResult);
            screen.Click(pattern_searchResult);
            Assert.AreEqual(true,screen.Exists(pattern_notepad));
        }
    }
}

