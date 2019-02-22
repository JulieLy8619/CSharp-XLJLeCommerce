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

        //setter name

        //getter sku

        //setter sku

        //getter price

        //setter price

        //getter description

        //setter description

        //getter image url

        //setter image url


    }
}
