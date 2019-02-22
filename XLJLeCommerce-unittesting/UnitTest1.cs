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

        //getter last name
        [Fact]
        public void TestGetLastName()
        {
            ApplicationUser testAppUser3 = new ApplicationUser();
            testAppUser3.LastName = "aLastName";
            Assert.Equal("aLastName", testAppUser3.LastName);
        }

        //setter last name

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

        //getter sku
        [Fact]
        public void TestGetProdSku()
        {
            Product testProd3 = new Product();
            testProd3.Sku = "aSku";
            Assert.Equal("aSku", testProd3.Sku);
        }

        //setter sku

        //getter price
        [Fact]
        public void TestGetProdPrice()
        {
            Product testProd5 = new Product();
            testProd5.Price = 20;
            Assert.Equal(20, testProd5.Price);
        }

        //setter price

        //getter description
        [Fact]
        public void TestGetProdDescription()
        {
            Product testProd7 = new Product();
            testProd7.Description = "aDescription";
            Assert.Equal("aDescription", testProd7.Description);
        }

        //setter description

        //getter image url
        [Fact]
        public void TestGetProdImageURL()
        {
            Product testProd9 = new Product();
            testProd9.ImageURL = "anImageURL";
            Assert.Equal("anImageURL", testProd9.ImageURL);
        }

        //setter image url


    }
}
