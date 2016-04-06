using System;
using System.Collections.Generic;
using Gilgamesh.Entities;
using Gilgamesh.Entities.Instruments;
using Gilgamesh.Entities.StaticData.Reference;


namespace Gilgamesh.DataMigration
{
    public class InstrumentImporter
    {
        public static void ImportInstruments()
        {
            ImportCashInstruments();
            ImportShares();
        }


        public static void ImportCashInstruments()
        {
            CashStandardMetaModel cashStandardMetaModel= new CashStandardMetaModel();
            foreach (KeyValuePair<int, string> currency in CurrenciesList.Currencies)
            {
                CashInstrument cash = new CashInstrument {CurrencyId = currency.Key,MetaModel = cashStandardMetaModel,Name = String.Format("Cash Instrument {0}",currency.Value),Reference = new Reference{Name = String.Format("Cash Instrument {0}", currency.Value) ,ReferecenceTypeId = 1} };
                UnitOfWorkFactory.Instance.UnitOfWork.Instruments.Add(cash);
            }
            UnitOfWorkFactory.Instance.UnitOfWork.Complete();
        }

        public static void ImportShares()
        {
            ShareStandardMetaModel shareStandardMetaModel = new ShareStandardMetaModel();

            Share share = new Share{Reference = new Reference {Name = "VOO", ReferecenceTypeId = 1} ,CurrencyId = 1,Name = "VANGUARD 500 ETF", MetaModel = shareStandardMetaModel,MarketId = 109};
            UnitOfWorkFactory.Instance.UnitOfWork.Instruments.Add(share);
            UnitOfWorkFactory.Instance.UnitOfWork.Complete();
        }

    }
}