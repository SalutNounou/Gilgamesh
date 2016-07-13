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
            CashStandardMetaModel cashStandardMetaModel = new CashStandardMetaModel();
            foreach (KeyValuePair<int, string> currency in CurrenciesList.Currencies)
            {
                CashInstrument cash = new CashInstrument {CurrencyId = currency.Key, MetaModel = cashStandardMetaModel, Name = String.Format("Cash Instrument {0}", currency.Value), Reference = new Reference { Name = String.Format("Cash Instrument {0}", currency.Value), ReferecenceTypeId = 1 } };
                UnitOfWorkFactory.Instance.UnitOfWork.Instruments.Add(cash);
            }
            UnitOfWorkFactory.Instance.UnitOfWork.Complete();
        }

        public static void ImportShares()
        {
            ShareStandardMetaModel shareStandardMetaModel = new ShareStandardMetaModel();

            foreach (Share share in Shares)
            {
                UnitOfWorkFactory.Instance.UnitOfWork.Instruments.Add(share);
            }
            UnitOfWorkFactory.Instance.UnitOfWork.Complete();
        }



        private static readonly List<Share> Shares = new List<Share>
        {
            //ETFs
            new Share{Reference = new Reference {Name = "GLD", ReferecenceTypeId = 1} ,CurrencyId = 1,Name = "SPDR Gold Shares", MetaModel = MetaModelsList.ShareStandardMetaModel,MarketId = 109, QuotationInCents = false},
            new Share{Reference = new Reference {Name = "VNQ", ReferecenceTypeId = 1} ,CurrencyId = 1,Name = "VANGUARD REIT ETF", MetaModel = MetaModelsList.ShareStandardMetaModel,MarketId = 109, QuotationInCents = false},
            new Share{Reference = new Reference {Name = "REM", ReferecenceTypeId = 1} ,CurrencyId = 1,Name = "iShares Mortgage Real Estate Capped", MetaModel = MetaModelsList.ShareStandardMetaModel,MarketId = 109, QuotationInCents = false},
            new Share{Reference = new Reference {Name = "TLO", ReferecenceTypeId = 1} ,CurrencyId = 1,Name = "SPDR Barclays Long Term Treasury ETF", MetaModel = MetaModelsList.ShareStandardMetaModel,MarketId = 109, QuotationInCents = false},
            new Share{Reference = new Reference {Name = "SHY", ReferecenceTypeId = 1} ,CurrencyId = 1,Name = "iShares 1-3 Years treasury Bonds", MetaModel = MetaModelsList.ShareStandardMetaModel,MarketId = 109, QuotationInCents = false},
            new Share{Reference = new Reference {Name = "JNK", ReferecenceTypeId = 1} ,CurrencyId = 1,Name = "SPDR Barclays High Yield Bond ETF", MetaModel = MetaModelsList.ShareStandardMetaModel,MarketId = 109, QuotationInCents = false},
            new Share{Reference = new Reference {Name = "HYG", ReferecenceTypeId = 1} ,CurrencyId = 1,Name = "iShares iBoxx high Yield Corporate Bond", MetaModel = MetaModelsList.ShareStandardMetaModel,MarketId = 109, QuotationInCents = false},
            new Share{Reference = new Reference {Name = "VOO", ReferecenceTypeId = 1} ,CurrencyId = 1,Name = "VANGUARD 500 ETF", MetaModel = MetaModelsList.ShareStandardMetaModel,MarketId = 109, QuotationInCents = false},
            new Share{Reference = new Reference {Name = "ACWX", ReferecenceTypeId = 1} ,CurrencyId = 1,Name = "iShares MSCI ACWI ex US", MetaModel = MetaModelsList.ShareStandardMetaModel,MarketId = 109, QuotationInCents = false},
            new Share{Reference = new Reference {Name = "CIU", ReferecenceTypeId = 1} ,CurrencyId = 1,Name = "iShares Intermediate Credit Bond", MetaModel = MetaModelsList.ShareStandardMetaModel,MarketId = 109, QuotationInCents = false},


            //Shares CTO
            new Share{Reference = new Reference {Name = "APWC", ReferecenceTypeId = 1} ,CurrencyId = 1,Name = "Asia Pacific Wire & Cable Ltd", MetaModel = MetaModelsList.ShareStandardMetaModel,MarketId = 109, QuotationInCents = false},
            new Share{Reference = new Reference {Name = "DSWL", ReferecenceTypeId = 1} ,CurrencyId = 1,Name = "Deswell Industries Inc", MetaModel = MetaModelsList.ShareStandardMetaModel,MarketId = 109, QuotationInCents = false},
            new Share{Reference = new Reference {Name = "DPM", ReferecenceTypeId = 1} ,CurrencyId = 5,Name = "Dundee Precious Metals Inc.", MetaModel = MetaModelsList.ShareStandardMetaModel,MarketId = 118, QuotationInCents = false},
            new Share{Reference = new Reference {Name = "MSN", ReferecenceTypeId = 1} ,CurrencyId = 1,Name = "Emerson Radio Corp.", MetaModel = MetaModelsList.ShareStandardMetaModel,MarketId = 109, QuotationInCents = false},
            new Share{Reference = new Reference {Name = "GSOL", ReferecenceTypeId = 1} ,CurrencyId = 1,Name = "Global sources Ltd", MetaModel = MetaModelsList.ShareStandardMetaModel,MarketId = 109, QuotationInCents = false},
            new Share{Reference = new Reference {Name = "HYD", ReferecenceTypeId = 1} ,CurrencyId = 5,Name = "Hyduke Energy Services Inc", MetaModel = MetaModelsList.ShareStandardMetaModel,MarketId = 118, QuotationInCents = false},
            new Share{Reference = new Reference {Name = "MUBL", ReferecenceTypeId = 1} ,CurrencyId = 4,Name = "MBL Group PLC", MetaModel = MetaModelsList.ShareStandardMetaModel,MarketId = 160, QuotationInCents = true},

            //Shares PEA
            new Share{Reference = new Reference {Name = "ALP", ReferecenceTypeId = 1} ,CurrencyId = 2,Name = "ADL Partner", MetaModel = MetaModelsList.ShareStandardMetaModel,MarketId = 125, QuotationInCents = false},
            new Share{Reference = new Reference {Name = "DBT", ReferecenceTypeId = 1} ,CurrencyId = 2,Name = "Encres Dubuit", MetaModel = MetaModelsList.ShareStandardMetaModel,MarketId = 125, QuotationInCents = false},
            new Share{Reference = new Reference {Name = "EXAC", ReferecenceTypeId = 1} ,CurrencyId = 2,Name = "Exacompta Clairefontaine", MetaModel = MetaModelsList.ShareStandardMetaModel,MarketId = 125, QuotationInCents = false},
            new Share{Reference = new Reference {Name = "GEA", ReferecenceTypeId = 1} ,CurrencyId = 2,Name = "GEA SA", MetaModel = MetaModelsList.ShareStandardMetaModel,MarketId = 125, QuotationInCents = false},
            new Share{Reference = new Reference {Name = "IRC", ReferecenceTypeId = 1} ,CurrencyId = 2,Name = "Irce Spa", MetaModel = MetaModelsList.ShareStandardMetaModel,MarketId = 140, QuotationInCents = false},
            new Share{Reference = new Reference {Name = "NTZ", ReferecenceTypeId = 1} ,CurrencyId = 1,Name = "Natuzzi Spa-ADR", MetaModel = MetaModelsList.ShareStandardMetaModel,MarketId = 109, QuotationInCents = false},
            new Share{Reference = new Reference {Name = "PHO", ReferecenceTypeId = 1} ,CurrencyId = 4,Name = "Peel Hotels PLC", MetaModel = MetaModelsList.ShareStandardMetaModel,MarketId = 160, QuotationInCents = true},
            new Share{Reference = new Reference {Name = "GIRO", ReferecenceTypeId = 1} ,CurrencyId = 2,Name = "Signaux Girod", MetaModel = MetaModelsList.ShareStandardMetaModel,MarketId = 125, QuotationInCents = false},
            new Share{Reference = new Reference {Name = "VIN", ReferecenceTypeId = 1} ,CurrencyId = 2,Name = "Vianini Industria", MetaModel = MetaModelsList.ShareStandardMetaModel,MarketId = 140, QuotationInCents = false},
            new Share{Reference = new Reference {Name = "GRVO", ReferecenceTypeId = 1} ,CurrencyId = 2,Name = "Graines Voltz SA", MetaModel = MetaModelsList.ShareStandardMetaModel,MarketId = 125, QuotationInCents = false},

            //Shares SaxoBank
            new Share{Reference = new Reference {Name = "GIGM", ReferecenceTypeId = 1} ,CurrencyId = 1,Name = "Gigamedia Ltd", MetaModel = MetaModelsList.ShareStandardMetaModel,MarketId = 109, QuotationInCents = false},
            new Share{Reference = new Reference {Name = "GRVY", ReferecenceTypeId = 1} ,CurrencyId = 1,Name = "Gravity Corp", MetaModel = MetaModelsList.ShareStandardMetaModel,MarketId = 109, QuotationInCents = false},
            new Share{Reference = new Reference {Name = "RELL", ReferecenceTypeId = 1} ,CurrencyId = 1,Name = "Richardson Electronics Ltd", MetaModel = MetaModelsList.ShareStandardMetaModel,MarketId = 109, QuotationInCents = false},
            new Share{Reference = new Reference {Name = "RBCN", ReferecenceTypeId = 1} ,CurrencyId = 1,Name = "Rubicon Technology", MetaModel = MetaModelsList.ShareStandardMetaModel,MarketId = 109, QuotationInCents = false},
            new Share{Reference = new Reference {Name = "ALVEL", ReferecenceTypeId = 1} ,CurrencyId = 2,Name = "Velcan Energy", MetaModel = MetaModelsList.ShareStandardMetaModel,MarketId = 125, QuotationInCents = false},

        };

    }

    public class MetaModelsList
    {
        public static readonly ShareStandardMetaModel ShareStandardMetaModel = new ShareStandardMetaModel();
    }
}