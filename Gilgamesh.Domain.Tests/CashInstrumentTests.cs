using Gilgamesh.Entities.Instruments;
using Gilgamesh.Entities.MarketData;
using Gilgamesh.Entities.StaticData.Reference;
using NUnit.Framework;

namespace Gilgamesh.Entities.Tests
{
    public class CashInstrumentTests
    {
        [Test]
        public void ShouldPriceCorrectlyCashInstrument()
        {
            //Arrange
            IInstrument cash = new CashInstrument {CurrencyId=1,InstrumentId = 1,MarketId=0,MetaModel=new CashStandardMetaModel(),Name ="Cash USD", Reference = new Reference {InstrumentId = 1,ReferenceId = 1, ReferecenceTypeId = 1,Name = "CashInstrument"} };
            //Act
            var price = cash.GetTheoreticalValue(NSubstitute.Substitute.For<IMarketData>());
            //Assert
            Assert.AreEqual(1,price);
        }
    }
}