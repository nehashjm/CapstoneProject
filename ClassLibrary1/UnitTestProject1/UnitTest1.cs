using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using Assert = NUnit.Framework.Assert;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [Test]
        public void Login_Successful()
        {
            // Arrange
            Class1 admin = new Class1 { email = "nehash@gmail.com", password = "nehash@123" };

            // Act
            string result = admin.Login("nehash@gmail.com", "nehash@123");

            // Assert
            Assert.AreEqual("Success", result);
        }
    }
}
