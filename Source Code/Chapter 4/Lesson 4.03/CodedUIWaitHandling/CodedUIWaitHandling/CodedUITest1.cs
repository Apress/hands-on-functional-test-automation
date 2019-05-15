using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace CodedUICommands
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
            
        }
        [TestMethod]
        public void Click()
        {
            Mouse.Click();
        }

        #region Commands

        [TestMethod]
        public void MouseClickonControl()
        {
            WinWindow parentWindow = new WinWindow();
            parentWindow.SearchProperties["ClassName"] = "MSTaskSwWClass";
            parentWindow.SearchProperties["ControlType"] = "Window";
            WinToolBar toolBar = new WinToolBar(parentWindow);
            toolBar.SearchProperties["Name"] = "Running applications";
            WinButton button = new WinButton(toolBar);
            button.SearchProperties["Name"] = "File Explorer";
            button.SearchProperties["ControlType"] = "Button";
            Mouse.Click(button);
        }

        [TestMethod]
        public void ClickModifierKey()
        {
            Mouse.Click(ModifierKeys.Windows);
        }

        [TestMethod]
        public void ClickOnPoint()
        {
            Mouse.Click(Point.Empty);
        }

        [TestMethod]
        public void MouseRightClick()
        {
            Mouse.Click(MouseButtons.Right);
        }

        [TestMethod]
        public void ClickControlAndModifier()//
        {
            WinWindow parentWindow = new WinWindow();
            parentWindow.SearchProperties["ClassName"] = "MSTaskSwWClass";
            parentWindow.SearchProperties["ControlType"] = "Window";
            WinToolBar toolBar = new WinToolBar(parentWindow);
            toolBar.SearchProperties["Name"] = "Running applications";
            WinButton button = new WinButton(toolBar);
            button.SearchProperties["Name"] = "File Explorer";
            button.SearchProperties["ControlType"] = "Button";
            Mouse.Click(button, ModifierKeys.Shift);
        }

        [TestMethod]
        public void RightClickonControl()
        {
            WinWindow parentWindow = new WinWindow();
            parentWindow.SearchProperties["ClassName"] = "MSTaskSwWClass";
            parentWindow.SearchProperties["ControlType"] = "Window";
            WinToolBar toolBar = new WinToolBar(parentWindow);
            toolBar.SearchProperties["Name"] = "Running applications";
            WinButton button = new WinButton(toolBar);
            button.SearchProperties["Name"] = "File Explorer";
            button.SearchProperties["ControlType"] = "Button";
            Mouse.Click(button, MouseButtons.Right);
            
        }

        [TestMethod]
        public void ClickonControlPoint()
        {
            WinWindow parentWindow = new WinWindow();
            parentWindow.SearchProperties["ClassName"] = "MSTaskSwWClass";
            parentWindow.SearchProperties["ControlType"] = "Window";
            WinToolBar toolBar = new WinToolBar(parentWindow);
            toolBar.SearchProperties["Name"] = "Running applications";
            WinButton button = new WinButton(toolBar);
            button.SearchProperties["Name"] = "File Explorer";
            button.SearchProperties["ControlType"] = "Button";
            var buttonPosition = button.BoundingRectangle;
            Point relativePoint = new Point(buttonPosition.X + 5, buttonPosition.Y - 5);
            Mouse.Click(button, relativePoint);
        }

        [TestMethod]
        public void DoubleClick()
        {
            Mouse.DoubleClick();
        }

        [TestMethod]
        public void DoubleClickMouseButton()
        {
            Mouse.DoubleClick(MouseButtons.Left);
        }

        [TestMethod]
        public void DoubleClickModifier()
        {
            Mouse.DoubleClick(ModifierKeys.Windows);
        }

        [TestMethod]
        public void DoubleClickPoint()
        {
            Mouse.DoubleClick(Point.Empty);
        }

        [TestMethod]
        public void MouseHover()
        {
            Mouse.Hover(Point.Empty);
        }

        [TestMethod]
        public void MouseHoverPoint()
        {
            Mouse.Hover(Point.Empty);
        }

        [TestMethod]
        public void MouseHoverDuration()
        {
            Mouse.Hover(Point.Empty, 2000);
        }

        [TestMethod]
        public void DoubleClickControl()
        {
            WinWindow parentWindow = new WinWindow();
            parentWindow.SearchProperties["ClassName"] = "MSTaskSwWClass";
            parentWindow.SearchProperties["ControlType"] = "Window";
            WinToolBar toolBar = new WinToolBar(parentWindow);
            toolBar.SearchProperties["Name"] = "Running applications";
            WinButton button = new WinButton(toolBar);
            button.SearchProperties["Name"] = "File Explorer";
            button.SearchProperties["ControlType"] = "Button";
            Mouse.DoubleClick(button);
        }

        [TestMethod]
        public void MouseHoverToControl()
        {
            WinWindow parentWindow = new WinWindow();
            parentWindow.SearchProperties["ClassName"] = "MSTaskSwWClass";
            parentWindow.SearchProperties["ControlType"] = "Window";
            WinToolBar toolBar = new WinToolBar(parentWindow);
            toolBar.SearchProperties["Name"] = "Running applications";
            WinButton button = new WinButton(toolBar);
            button.SearchProperties["Name"] = "File Explorer";
            button.SearchProperties["ControlType"] = "Button";
            Mouse.Hover(button);
        }

        [TestMethod]
        public void MoveScrollwithScrollCount()
        {
            Mouse.MoveScrollWheel(20);
        }

       [TestMethod]
       public void StartDragAndDrop()
        {
            WinWindow parentWindow = new WinWindow();
            parentWindow.SearchProperties["ClassName"] = "MSTaskSwWClass";
            parentWindow.SearchProperties["ControlType"] = "Window";
            WinToolBar toolBar = new WinToolBar(parentWindow);
            toolBar.SearchProperties["Name"] = "Running applications";
            WinButton button = new WinButton(toolBar);
            button.SearchProperties["Name"] = "File Explorer";
            button.SearchProperties["ControlType"] = "Button";
            Mouse.StartDragging(button);
            Rectangle desktopWindow = WinWindow.Desktop.BoundingRectangle;
            Mouse.StopDragging(desktopWindow.Width / 4, desktopWindow.Y);        
        }

        [TestMethod]

        public void TypeValues()
        {
            WinWindow dialog = new WinWindow();
            dialog.SearchProperties["ClassName"] = "MSTaskSwWClass";
            dialog.SearchProperties["ControlType"] = "Window";
            WinToolBar toolBar = new WinToolBar(dialog);
            toolBar.SearchProperties["Name"] = "Running applications";
            WinButton button = new WinButton(toolBar);
            button.SearchProperties["Name"] = "File Explorer";
            button.SearchProperties["ControlType"] = "Button";
            Mouse.Click(button);
            

            WinWindow dialog2 = new WinWindow();
            dialog2.SearchProperties["ClassName"] = "CabinetWClass";
            dialog2.SearchProperties["ControlType"] = "Window";
            WinEdit winSearch = new WinEdit(dialog2);
            winSearch.SearchProperties["Name"] = "Search Box";
            Keyboard.SendKeys(winSearch, "Currency");
        }

       
        #endregion

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

        
    }
}
