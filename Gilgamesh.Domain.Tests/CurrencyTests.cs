using System;
using System.Collections.Generic;
using Gilgamesh.Entities.StaticData.Currency;
using NUnit.Framework;



namespace Gilgamesh.Entities.Tests
{
    public class CurrencyTests
    {
        [Test]
        public void ShouldTellIfADayIsABanKHoliday()
        {
            //Arrange
            ICurrency currency = new Currency(new List<BankHoliday>{new BankHoliday {Day = new DateTime(2016,5,1)} },new List<CommonNonWorkingDay> {new CommonNonWorkingDay {Day = new DateTime(2016,1,1)} }) { CurrencyName = "EUR" };
            //Act
            var actual = currency.IsABankHoliday(new DateTime(2016, 5, 1));
            //Assert
            Assert.AreEqual(true, actual);
            //Act
            //Act
            actual = currency.IsABankHoliday(new DateTime(2016, 1, 1));
            //Assert
            Assert.AreEqual(true, actual);

        }


        [Test]
        public void ShouldTellIfADayIsNotABanKHoliday()
        {
            //Arrange
            ICurrency currency = new Currency(new List<BankHoliday> { new BankHoliday { Day = new DateTime(2016, 5, 1) } }, new List<CommonNonWorkingDay>()) { CurrencyName = "EUR" };
            //Act
            var actual = currency.IsABankHoliday(new DateTime(2016, 5, 2));
            //Assert
            Assert.AreEqual(false, actual);
        }

        [Test]
        public void ShouldAddCorrectlyWorkingDays()
        {
            //Arrange
            ICurrency currency = new Currency(new List<BankHoliday> { new BankHoliday { Day = new DateTime(2016, 5, 1) } }, new List<CommonNonWorkingDay>()) { CurrencyName = "EUR" };
            //Act
            var actual = currency.AddDays(new DateTime(2016, 4, 30), 1);
            //Assert
            Assert.AreEqual(new DateTime(2016, 5, 2), actual);
            //Act
            actual = currency.AddDays(new DateTime(2016, 4, 30), -2);
            //Assert
            Assert.AreEqual(new DateTime(2016, 4, 28), actual);
        }



    }
}
