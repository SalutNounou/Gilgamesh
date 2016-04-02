using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gilgamesh.DataAccess;
using Gilgamesh.Entities.StaticData;
using NUnit.Framework;
using NFluent;

namespace Gilgamesh.DataMigration.Tests
{
    public class CurrencyMigrationTests
    {
        [Test]
        public void ShouldCalculateCorrectlyBankHolidays()
        {
            //Arrange
            //Act
            var holiday = CurrencyImporter.GetCommonNonWorkingDays();
            //Assert
            Check.That(holiday).Contains(new CommonNonWorkingDay { Day = new DateTime(2016, 1, 1) });
            Check.That(holiday).Contains(new CommonNonWorkingDay { Day = new DateTime(2016, 5, 1) });
            Check.That(holiday).Contains(new CommonNonWorkingDay { Day = new DateTime(2016, 12, 25) });

        }

    }
}
