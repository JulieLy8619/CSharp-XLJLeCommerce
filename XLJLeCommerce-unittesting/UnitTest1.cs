using System;
using XLJLeCommerce.Models;
using Xunit;

namespace XLJLeCommerce_unittesting
{
    public class UnitTest1
    {
        //application user Model ====================
        //getter first name
        [Fact]
        public void TestGetFirstName()
        {
            ApplicationUser testAppUser1 = new ApplicationUser();
            testAppUser1.FirstName = "aFirstName";
            Assert.Equal("aFirstName", testAppUser1.FirstName);
        }

        //setter first name
        [Fact]
        public void TestSetFirstName()
        {
            ApplicationUser testAppUser2 = new ApplicationUser();
            testAppUser2.FirstName = "aFirstName";
            testAppUser2.FirstName = "NewFirstName";
            Assert.Equal("NewFirstName", testAppUser2.FirstName);
        }

        //getter last name
        [Fact]
        public void TestGetLastName()
        {
            ApplicationUser testAppUser3 = new ApplicationUser();
            testAppUser3.LastName = "aLastName";
            Assert.Equal("aLastName", testAppUser3.LastName);
        }

        //setter last name
        [Fact]
        public void TestSetLastName()
        {
            ApplicationUser testAppUser4 = new ApplicationUser();
            testAppUser4.LastName = "aLastName";
            testAppUser4.LastName = "NewLastName";
            Assert.Equal("NewLastName", testAppUser4.LastName);
        }

        //getter birthdate
        [Fact]
        public void TestGetBirthdate()
        {
            ApplicationUser testAppUser5 = new ApplicationUser();
            DateTime value = new DateTime(2019, 2, 21);
            testAppUser5.Birthdate = value;
            Assert.Equal(value, testAppUser5.Birthdate);
        }

        //setter birthdate
        [Fact]
        public void TestSetBirthdate()
        {
            ApplicationUser testAppUser6 = new ApplicationUser();
            DateTime value1 = new DateTime(2019, 2, 21);
            DateTime value2 = new DateTime(2019, 2, 23);
            testAppUser6.Birthdate = value1;
            testAppUser6.Birthdate = value2;

            Assert.Equal(value2, testAppUser6.Birthdate);
        }

        //will need getter and setter for registereddate

        //product model ========================
        //getter name
        [Fact]
        public void TestGetProdName()
        {
            Product testProd1 = new Product();
            testProd1.Name = "aName";
            Assert.Equal("aName", testProd1.Name);
        }

        //setter name
        [Fact]
        public void TestSetProdName()
        {
            Product testProd2 = new Product();
            testProd2.Name = "aName";
            testProd2.Name = "NewName";
            Assert.Equal("NewName", testProd2.Name);
        }

        //getter sku
        [Fact]
        public void TestGetProdSku()
        {
            Product testProd3 = new Product();
            testProd3.Sku = "aSku";
            Assert.Equal("aSku", testProd3.Sku);
        }

        //setter sku
        [Fact]
        public void TestSetProdSku()
        {
            Product testProd4 = new Product();
            testProd4.Sku = "aSku";
            testProd4.Sku = "NewSku";
            Assert.Equal("NewSku", testProd4.Sku);
        }

        //getter price
        [Fact]
        public void TestGetProdPrice()
        {
            Product testProd5 = new Product();
            testProd5.Price = 20;
            Assert.Equal(20, testProd5.Price);
        }

        //setter price
        [Fact]
        public void TestSetProdPrice()
        {
            Product testProd6 = new Product();
            testProd6.Price = 20;
            testProd6.Price = 200;
            Assert.Equal(200, testProd6.Price);
        }

        //getter description
        [Fact]
        public void TestGetProdDescription()
        {
            Product testProd7 = new Product();
            testProd7.Description = "aDescription";
            Assert.Equal("aDescription", testProd7.Description);
        }

        //setter description
        [Fact]
        public void TestSetProdDescription()
        {
            Product testProd8 = new Product();
            testProd8.Description = "aDescription";
            testProd8.Description = "NewDescription";
            Assert.Equal("NewDescription", testProd8.Description);
        }

        //getter image url
        [Fact]
        public void TestGetProdImageURL()
        {
            Product testProd9 = new Product();
            testProd9.ImageURL = "anImageURL";
            Assert.Equal("anImageURL", testProd9.ImageURL);
        }

        //setter image url
        [Fact]
        public void TestSetProdImageURL()
        {
            Product testProd10 = new Product();
            testProd10.ImageURL = "anImageURL";
            testProd10.ImageURL = "aNewImageURL";
            Assert.Equal("aNewImageURL", testProd10.ImageURL);
        }


    }
}
