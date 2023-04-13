using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeShop.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CoffeeShop.Menu.Tests
{
    [TestClass()]
    public class PopupAddMenuTests
    {
        [TestMethod]
        public void NoFill_WhenAllFieldIsBlank()
        {
            //arange
            PopupAddMenu addMenu = new PopupAddMenu();
            string FieldMenuName = null;
            string FieldMenuKind = null;
            string FieldMenuPrice = null;
            int expected = 0;

            //act
            int check = addMenu.addMenuItem(FieldMenuName, FieldMenuKind, FieldMenuPrice);

            //assert
            Assert.AreEqual(expected, check);
        }
        [TestMethod]
        public void FillPart_WhenOnly_PriceFieldIs_FillWell()
        {
            //arange
            PopupAddMenu addMenu = new PopupAddMenu();
            string FieldMenuName = null;
            string FieldMenuKind = null;
            string FieldMenuPrice = "22000";
            int expected = 0;

            //act
            int check = addMenu.addMenuItem(FieldMenuName, FieldMenuKind, FieldMenuPrice);
            //assert
            Assert.AreEqual(expected, check);

        }
        [TestMethod]
        public void FillPart_WhenOnly_Type_FieldIs_FillWell()
        {
            //arange
            PopupAddMenu addMenu = new PopupAddMenu();
            string FieldMenuName = null;
            string FieldMenuKind = "Coffee";
            string FieldMenuPrice = null;
            int expected = 0;

            //act
            int check = addMenu.addMenuItem(FieldMenuName, FieldMenuKind, FieldMenuPrice);
            //assert
            Assert.AreEqual(expected, check);

        }
        [TestMethod]
        public void FillPart_WhenOnly_Name_FieldIs_NotFillWell()
        {
            //arange
            PopupAddMenu addMenu = new PopupAddMenu();
            string FieldMenuName = null;
            string FieldMenuKind = "Coffee";
            string FieldMenuPrice = "22000";
            int expected = 0;

            //act
            int check = addMenu.addMenuItem(FieldMenuName, FieldMenuKind, FieldMenuPrice);
            //assert
            Assert.AreEqual(expected, check);

        }
        [TestMethod]
        public void FillPart_WhenOnly_NameFieldIs_FillWell()
        {
            //arange
            PopupAddMenu addMenu = new PopupAddMenu();
            string FieldMenuName = "Test";
            string FieldMenuKind = null;
            string FieldMenuPrice = null;
            int expected = 0;

            //act
            int check = addMenu.addMenuItem(FieldMenuName, FieldMenuKind, FieldMenuPrice);
            //assert
            Assert.AreEqual(expected, check);

        }
        [TestMethod]
        public void FillPart_WhenOnly_Type_FieldIs_NotFillWell()
        {
            //arange
            PopupAddMenu addMenu = new PopupAddMenu();
            string FieldMenuName = "Test";
            string FieldMenuKind = null;
            string FieldMenuPrice = "22000";
            int expected = 0;

            //act
            int check = addMenu.addMenuItem(FieldMenuName, FieldMenuKind, FieldMenuPrice);
            //assert
            Assert.AreEqual(expected, check);

        }
        [TestMethod]
        public void FillPart_WhenOnly_Price_FieldIs_NotFillWell()
        {
            //arange
            PopupAddMenu addMenu = new PopupAddMenu();
            string FieldMenuName = "Test";
            string FieldMenuKind = "Coffee";
            string FieldMenuPrice = null;
            int expected = 0;

            //act
            int check = addMenu.addMenuItem(FieldMenuName, FieldMenuKind, FieldMenuPrice);
            //assert
            Assert.AreEqual(expected, check);

        }
        [TestMethod]
        public void FillAll_When_Everything_FillWell()
        {
            //arange
            PopupAddMenu addMenu = new PopupAddMenu();
            string FieldMenuName = "TestFail";
            string FieldMenuKind = "Tea";
            string FieldMenuPrice = "22000";
            int expected = 0;

            //act
            int check = addMenu.addMenuItem(FieldMenuName, FieldMenuKind, FieldMenuPrice);
            //assert
            Assert.AreEqual(expected, check);

        }
        [TestMethod]
        public void FillAll_When_NameField_OutOfRange()
        {
            //arange
            PopupAddMenu addMenu = new PopupAddMenu();
            string FieldMenuName = "yyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy";
            string FieldMenuKind = "Tea";
            string FieldMenuPrice = "22000";
            int expected = 0;

            //act
            int check = addMenu.addMenuItem(FieldMenuName, FieldMenuKind, FieldMenuPrice);
            //assert
            Assert.AreEqual(expected, check);

        }
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void FillAll_When_PriceField_OutOfRange()
        {
            Application.Current.Dispatcher.Invoke((Action)delegate {
                // your code
            
            //arange
            PopupAddMenu addMenu = new PopupAddMenu();
            string FieldMenuName = "Test";
            string FieldMenuKind = "Tea";
            string FieldMenuPrice = "Fail";
            int expected = 0;

            //act
            int check = addMenu.addMenuItem(FieldMenuName, FieldMenuKind, FieldMenuPrice);
            //assert
            Assert.AreEqual(expected, check);
            });
        }
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void FillAll_When_PriceField_OutOfRange_AndTypeNull()
        {
            //arange
            PopupAddMenu addMenu = new PopupAddMenu();
            string FieldMenuName = "Test";
            string FieldMenuKind = null;
            string FieldMenuPrice = "Fail";
            int expected = 0;

            //act
            int check = addMenu.addMenuItem(FieldMenuName, FieldMenuKind, FieldMenuPrice);
            //assert
            Assert.AreEqual(expected, check);

        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void FillAll_When_PriceField_AndName_OutOfRange()
        {
            //arange
            PopupAddMenu addMenu = new PopupAddMenu();
            string FieldMenuName = "yyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy";
            string FieldMenuKind = "Tea";
            string FieldMenuPrice = "Fail";
            int expected = 0;

            //act
            int check = addMenu.addMenuItem(FieldMenuName, FieldMenuKind, FieldMenuPrice);
            //assert
            Assert.AreEqual(expected, check);

        }
        [TestMethod]
        public void FillAll_When_Name_OutOfRange_AndAllLeft_IsNull()
        {
            //arange
            PopupAddMenu addMenu = new PopupAddMenu();
            string FieldMenuName = "yyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy";
            string FieldMenuKind = null;
            string FieldMenuPrice = null;
            int expected = 0;

            //act
            int check = addMenu.addMenuItem(FieldMenuName, FieldMenuKind, FieldMenuPrice);
            //assert
            Assert.AreEqual(expected, check);

        }
        [TestMethod]
        public void FillAll_When_Name_OutOfRange_AndPrice_IsNull()
        {
            //arange
            PopupAddMenu addMenu = new PopupAddMenu();
            string FieldMenuName = "yyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy";
            string FieldMenuKind = "Tea";
            string FieldMenuPrice = null;
            int expected = 0;

            //act
            int check = addMenu.addMenuItem(FieldMenuName, FieldMenuKind, FieldMenuPrice);
            //assert
            Assert.AreEqual(expected, check);

        }
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void FillAll_When_NameAndPrice_OutOfRange_AndType_IsNull()
        {
            //arange
            PopupAddMenu addMenu = new PopupAddMenu();
            string FieldMenuName = "yyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy";
            string FieldMenuKind = null;
            string FieldMenuPrice = "Fail";
            int expected = 0;

            //act
            int check = addMenu.addMenuItem(FieldMenuName, FieldMenuKind, FieldMenuPrice);
            //assert
            Assert.AreEqual(expected, check);

        }
    }

}