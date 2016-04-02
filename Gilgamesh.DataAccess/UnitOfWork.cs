﻿using System;
using Gilgamesh.Entities;
using Gilgamesh.Entities.StaticData.Reference;
using Gilgamesh.Entities.StaticData.Currency;

namespace Gilgamesh.DataAccess
{
    public class UnitOfWork : IUnitOfWork,IDisposable
    {

        private readonly IDbContext _context;

        public UnitOfWork(IDbContext context)
        {
            _context = context;
            CurrencyRepository = new Repository<Currency>(_context);
            CommonNonWorkingDayRepository = new Repository<CommonNonWorkingDay>(_context);
            References = new Repository<Reference>(_context);
            ReferenceTypes = new Repository<ReferenceType>(_context);
        }

        public IRepository<Currency> CurrencyRepository { get;  }
        public IRepository<CommonNonWorkingDay> CommonNonWorkingDayRepository { get; }
        public IRepository<Reference> References { get; }
        public IRepository<ReferenceType> ReferenceTypes { get; } 


        public int Complete()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException)
            {
                Rollback();
                throw;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Rollback()
        {
            _context.Rollback();
        }
    }
}
