using System;
using XLJLeCommerce.Models;
using Xunit;

namespace XLJLeCommerce_unittesting
{
    public class ApplicationUserUnitTests
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

        //getter address
        [Fact]
        public void TestGetAddress()
        {
            ApplicationUser testAppUser7 = new ApplicationUser();
            testAppUser7.Address = "aAddress";
            Assert.Equal("aAddress", testAppUser7.Address);
        }

        //setter address
        [Fact]
        public void TestSetAddress()
        {
            ApplicationUser testAppUser8 = new ApplicationUser();
            testAppUser8.Address = "aAddress";
            testAppUser8.Address = "NewAddress";
            Assert.Equal("NewAddress", testAppUser8.Address);
        }

        //getter register date
        [Fact]
        public void TestGetRegDate()
        {
            ApplicationUser testAppUser9 = new ApplicationUser();
            DateTime value = new DateTime(2019, 2, 21);
            testAppUser9.RegisteredDate = value;
            Assert.Equal(value, testAppUser9.RegisteredDate);
        }

        //setter register date
        [Fact]
        public void TestSetRegDate()
        {
            ApplicationUser testAppUser10 = new ApplicationUser();
            DateTime value = new DateTime(2019, 3, 5);
            DateTime value2 = new DateTime(2019, 3, 6);
            testAppUser10.RegisteredDate = value;
            testAppUser10.RegisteredDate = value2;
            Assert.Equal(value2, testAppUser10.RegisteredDate);
        }


    }
}
