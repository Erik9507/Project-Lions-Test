using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_Lions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_Lions.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TakeLoan_With_Positive_Amount_Return_Same_Amount_As_New_Loan()
        {
            //Arrange
            Customer testingLoan = new Customer("testingLoan", "testingLoan123!", new Account() { Balance = 1000, Name = "test" });
            List<Account> Accounts = testingLoan.Accounts;
            string Password = testingLoan.Password;
            decimal LoanSum = 0;
            string testInput = "100";
            //Act
            decimal IntrestCal;
            decimal total = 0;
            decimal accountSum = 0;
            decimal loanAmount;
            string loanInput = testInput;
            while (!decimal.TryParse(loanInput, out loanAmount) ^ loanInput == "ESC")
            {
            }
            if (loanInput != "ESC")
            {
                foreach (Account u in Accounts)
                {
                    accountSum = accountSum + u.Balance;
                }
                if (accountSum * 5 < loanAmount + LoanSum)
                {
                }
                else
                {
                    if (loanAmount < 100000)
                    {
                        IntrestCal = 1.05m;
                        total = loanAmount * IntrestCal;
                    }
                    else if (loanAmount >= 100000)
                    {
                        IntrestCal = 1.02m;
                        total = loanAmount * IntrestCal;
                    }
                    else if (loanAmount >= 500000)
                    {
                        IntrestCal = 1.015m;
                        total = loanAmount * IntrestCal;
                    }
                    bool loanCon = true;
                    while (loanCon)
                    {
                        if (accountSum * 5 > loanAmount + LoanSum)
                        {
                            string pass = testingLoan.Password;
                            while (pass != Password && pass != "ESC")
                            {
                            }
                            if (pass == Password)
                            {
                                LoanSum = LoanSum + total;
                                Accounts[0].Balance += loanAmount;
                                loanCon = false;
                            }
                            else if (pass == "ESC")
                            {
                                loanCon = false;
                            }
                        }
                    }
                }
            }
            // Act
            var actual = LoanSum;
            var expected = 105;
            //Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Take_loan_With_Negative_Amount_Return_Error()
        {//Arrange
            Customer testingLoan = new Customer("testingLoan", "testingLoan123!", new Account() { Balance = 1000, Name = "test" });
            List<Account> Accounts = testingLoan.Accounts;
            string Password = testingLoan.Password;
            decimal LoanSum = 0;
            string testInput = "-100";
            //Act
            decimal IntrestCal;
            decimal total = 0;
            decimal accountSum = 0;
            decimal loanAmount;
            string loanInput = testInput;
            while (!decimal.TryParse(loanInput, out loanAmount) ^ loanInput == "ESC")
            {
            }
            if (loanInput != "ESC")
            {
                foreach (Account u in Accounts)
                {
                    accountSum = accountSum + u.Balance;
                }
                if (accountSum * 5 < loanAmount + LoanSum)
                {
                }
                else
                {
                    if (loanAmount < 100000)
                    {
                        IntrestCal = 1.05m;
                        total = loanAmount * IntrestCal;
                    }
                    else if (loanAmount >= 100000)
                    {
                        IntrestCal = 1.02m;
                        total = loanAmount * IntrestCal;
                    }
                    else if (loanAmount >= 500000)
                    {
                        IntrestCal = 1.015m;
                        total = loanAmount * IntrestCal;
                    }
                    bool loanCon = true;
                    while (loanCon)
                    {
                        if (accountSum * 5 > loanAmount + LoanSum)
                        {
                            string pass = testingLoan.Password;
                            while (pass != Password && pass != "ESC")
                            {
                            }
                            if (pass == Password)
                            {
                                LoanSum = LoanSum + total;
                                Accounts[0].Balance += loanAmount;
                                loanCon = false;
                            }
                            else if (pass == "ESC")
                            {
                                loanCon = false;
                            }
                        }
                    }
                }
            }
            // Act
            var actual = LoanSum;
            bool expected = actual < 0;
            //Assert
            Assert.IsFalse(expected);
        }

        [TestMethod]
        public void Admin_Set_New_Positive_Dollar_Interest_Rate_Return_Same_Amount()
        {
            //Arrange
            decimal DollarRate = Admin.DollarRate;
            decimal InterestRate = Admin.InterestRate;
            string testDollarRateAmount = "10";
            Admin testAdmin = new Admin("TestAdmin", "TestAdminPass");
            //Act

            decimal tempDollarRate = 0m;
            string dollarAmountIn = testDollarRateAmount;
            while ((!decimal.TryParse(dollarAmountIn, out tempDollarRate)) && dollarAmountIn != "ESC")
            {
            }
            if (dollarAmountIn != "ESC")
            {
                DollarRate = tempDollarRate;
            }

            //Assert
            var actual = DollarRate;
            var expected = 10;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Admin_Set_New_Negative_Dollar_Interest_Rate_Return_Error()
        {
            //Arrange
            decimal DollarRate = Admin.DollarRate;
            decimal InterestRate = Admin.InterestRate;
            string testDollarRateAmount = "-10";
            Admin testAdmin = new Admin("TestAdmin", "TestAdminPass");

            //Act
            decimal tempDollarRate = 0m;
            string dollarAmountIn = testDollarRateAmount;
            while ((!decimal.TryParse(dollarAmountIn, out tempDollarRate)) && dollarAmountIn != "ESC")
            {
            }
            if (dollarAmountIn != "ESC")
            {
                DollarRate = tempDollarRate;
            }

            //Assert
            var actual = DollarRate;
            bool expected = actual < 0;
            Assert.IsFalse(expected);
        }

        [TestMethod]
        public void External_Transfer_Send_Money_To_Same_User_Return_Error()
        {
            //Arrange
            Customer testingTransfer = new Customer("testingTransfer", "testingLoan123!", new Account() { Balance = 1000, Name = "test" });
            List<Account> Accounts = testingTransfer.Accounts;
            BankSystem.AllCustomers.Add(testingTransfer);
            decimal amount = 0;
            string usernameSearch = "testingTransfer";
            bool userFound = false;
            int index = 0;

            //Act
            for (int i = 0; i < BankSystem.AllCustomers.Count; i++)
            {
                if (BankSystem.AllCustomers[i].Username == usernameSearch)
                {
                    userFound = true;
                    index = i;
                    break;
                }
            }
            if (userFound)
            {
                for (int i = 0; i < Accounts.Count; i++)
                {
                }
                int moveFrom = 1;
                string amountIn = "100";
                while (((!decimal.TryParse(amountIn, out amount)) || amount < 0 || amount > Accounts[moveFrom - 1].Balance) && amountIn != "ESC")
                {
                }
                if (BankSystem.AllCustomers[index].Accounts[0].Currency == Accounts[moveFrom - 1].Currency)
                {
                    Accounts[moveFrom - 1].Balance -= amount;
                    BankSystem.AllCustomers[index].Accounts[0].Balance += amount;
                }
            }

            //Assert
            var actual = amount;
            var expected = 100;
            Assert.AreNotEqual(expected, actual);
        }
    }
}