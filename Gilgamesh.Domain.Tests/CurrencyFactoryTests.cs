using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Gilgamesh.DataAccess;

using Gilgamesh.Entities;
using Gilgamesh.Entities.StaticData;
using NSubstitute;
using NUnit.Framework;
using Currency = Gilgamesh.Entities.StaticData.Currency;

namespace Gilgamesh.Domain.Tests
{
    public class CurrencyFactoryTests
    {
        private IDbContext _context;
        private UnitOfWork _unitOfWork;
        private DbSet<Currency> dbSet;

        [SetUp]
        public void InitializeTests()
        {
            _context = Substitute.For<IDbContext>();
            
            _unitOfWork = new UnitOfWork(_context);
            UnitOfWorkFactory.Instance.UnitOfWork = _unitOfWork;
           
        }
        [Test]
        public void ShouldRetrieveCurrecncyObject()
        {
            //Arrange
          
            //using (var unitOfWork = new UnitOfWork(new ApplicationContext()))
            //{
            //    UnitOfWorkFactory.Instance.UnitOfWork = unitOfWork;

            //    CurrencyFactory factory = new CurrencyFactory();
            //    //Act
            //    var currency = factory.GetCurrency(1);
            //    //Assert
            //    Assert.AreEqual("CHF", currency.Name);


            //}
           
        }
    }
}