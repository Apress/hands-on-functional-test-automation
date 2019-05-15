using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace CodedUIDemo
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUITest1
    {
        public CodedUITest1()
        {
           
        }

        [TestMethod]
        public void CodedUITestMethod1()
        {
            WinWindow win1 = new WinWindow();
            win1.SearchProperties["ClassName"] = "MSTaskSwWClass";
            win1.SearchProperties["ControlType"] = "Window";
            WinToolBar toolBar = new WinToolBar(win1);
            toolBar.SearchProperties["Name"] = "Running applications";
            WinButton button = new WinButton(toolBar);
            button.SearchProperties["Name"] = "File Explorer";
            button.SearchProperties["ControlType"] = "Button";
            Mouse.Click(button);
            WinWindow win2 = new WinWindow();
            win2.SearchProperties["ClassName"] = "CabinetWClass";
            win2.SearchProperties["ControlType"] = "Window";
            WinTreeItem winTreeItem = new WinTreeItem(win2);
            winTreeItem.SearchProperties["ControlType"] = "TreeItem";
            winTreeItem.SearchProperties["Name"] = "Pictures";
            Mouse.Click(winTreeItem);
            WinListItem winListItem = new WinListItem(win2);
            winListItem.SearchProperties["ControlType"] = "ListItem";
            winListItem.SearchProperties["Name"] = "Camera Roll";
            Assert.AreEqual(winListItem.DisplayText, "Camera Roll");
            WinWindow searchArea = new WinWindow(win2);
            searchArea.SearchProperties["ClassName"] = "DirectUIHWND";
            WinPane quichAccess = new WinPane(searchArea);
            quichAccess.SearchProperties["ControlType"] = "Pane";
            quichAccess.SearchProperties["Name"] = " Search Quick access";
            WinEdit winSearch = new WinEdit(quichAccess);
            winSearch.SearchProperties["Name"] = "Search Box";
            Keyboard.SendKeys(winSearch, "Currency");   
        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if (this.map == null)
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
