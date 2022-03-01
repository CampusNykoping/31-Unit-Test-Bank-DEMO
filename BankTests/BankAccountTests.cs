using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountNS.Tests
{
    [TestClass()]
    public class BankAccountTests
    {
        BankAccount account;

        [TestInitialize]
        public void Debit_TestInitialize()
        {
            double beginningBalance = 11.99;
            account = new BankAccount("Mr. Bryan Walton", beginningBalance);
        }

        [TestMethod()]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double debitAmount = 4.55;
            double expected = 7.44;
            
            // Act
            account.Debit(debitAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        [DataRow (-100.00, BankAccount.DebitAmountLessThanZeroMessage)]
        [DataRow (100.00, BankAccount.DebitAmountExceedsBalanceMessage)]
        public void Debit_WhenAmountIsWrong_ShouldThrowException(double debitAmount, string errorMessage)
        {
            // Arrange
            
            //Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, errorMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown");
        }

        //[TestMethod()]
        //public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        //{
        //    // Arrange
        //    double debitAmount = -100.00;
            
        //    //Act
        //    try
        //    {
        //        account.Debit(debitAmount);
        //    }
        //    catch (ArgumentOutOfRangeException e)
        //    {
        //        // Assert
        //        StringAssert.Contains(e.Message, BankAccount.DebitAmountLessThanZeroMessage);
        //        return;
        //    }

        //    Assert.Fail("The expected exception was not thrown");
        //}

        //[TestMethod()]
        //public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        //{
        //    // Arrange
        //    double debitAmount = 100.00;
            
        //    //Act
        //    try
        //    {
        //        account.Debit(debitAmount);
        //    }
        //    catch (ArgumentOutOfRangeException e)
        //    {
        //        // Assert
        //        StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
        //        return;
        //    }

        //    Assert.Fail("The expected exception was not thrown");
        //}
    }
}