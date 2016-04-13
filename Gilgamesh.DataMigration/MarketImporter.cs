using System;
using System.Collections.Generic;
using Gilgamesh.Entities;
using Gilgamesh.Entities.StaticData.Currency;
using Gilgamesh.Entities.StaticData.Market;

namespace Gilgamesh.DataMigration
{
    public class MarketImporter
    {
        public static void ImportMarkets()
        {

            foreach (KeyValuePair<int, Tuple<string, string, int, List<BankHoliday>>> kvp in Markets)
            {
                UnitOfWorkFactory.Instance.UnitOfWork.Markets.Add(new Market(kvp.Value.Item4) { Id = kvp.Key, MarketName = kvp.Value.Item1, MarketAcronym = kvp.Value.Item2, MarketCurrencyId = kvp.Value.Item3 });
            }
            UnitOfWorkFactory.Instance.UnitOfWork.Complete();
        }



        private static readonly Dictionary<int, Tuple<string, string, int, List<BankHoliday>>> Markets = new Dictionary<int, Tuple<string, string, int, List<BankHoliday>>>
        {
            {100,new Tuple<string, string, int,List<BankHoliday>>("American Stock Exchange","",1, new List<BankHoliday>()) },
            {101,new Tuple<string, string, int,List<BankHoliday>>("BATS Exchange","",1, new List<BankHoliday>()) },
            {102,new Tuple<string, string, int,List<BankHoliday>>("Chicago Board of Trade",".CBT",1, new List<BankHoliday>()) },
            {103,new Tuple<string, string, int,List<BankHoliday>>("Chicago Mercantile Exchange",".CME",1, new List<BankHoliday>()) },
            {104,new Tuple<string, string, int,List<BankHoliday>>("Dow Jones Indexes","",1, new List<BankHoliday>()) },
            {105,new Tuple<string, string, int,List<BankHoliday>>("NASDAQ Stock Exchange","",1, new List<BankHoliday>()) },
            {106,new Tuple<string, string, int,List<BankHoliday>>("New York Board of Trade",".NYB",1, new List<BankHoliday>()) },
            {107,new Tuple<string, string, int,List<BankHoliday>>("New York Commodities Exchange",".CMX",1, new List<BankHoliday>()) },
            {108,new Tuple<string, string, int,List<BankHoliday>>("New York Mercantile Exchange",".NYM",1, new List<BankHoliday>()) },
            {109,new Tuple<string, string, int,List<BankHoliday>>("New York Stock Exchange","",1, new List<BankHoliday>
            {
                new BankHoliday(new DateTime(2015,1,1)),
                new BankHoliday(new DateTime(2015,1,19)),
                new BankHoliday(new DateTime(2015,2,16)),
                new BankHoliday(new DateTime(2015,4,3)),
                new BankHoliday(new DateTime(2015,5,25)),
                new BankHoliday(new DateTime(2015,7,3)),
                new BankHoliday(new DateTime(2015,9,7)),
                new BankHoliday(new DateTime(2015,11,26)),
                new BankHoliday(new DateTime(2015,12,25)),
                new BankHoliday(new DateTime(2017,1,2)),
                new BankHoliday(new DateTime(2017,1,16)),
                new BankHoliday(new DateTime(2017,2,20)),
                new BankHoliday(new DateTime(2017,4,14)),
                new BankHoliday(new DateTime(2017,5,29)),
                new BankHoliday(new DateTime(2017,7,4)),
                new BankHoliday(new DateTime(2017,9,4)),
                new BankHoliday(new DateTime(2017,11,23)),
                new BankHoliday(new DateTime(2017,12,25)),
                new BankHoliday(new DateTime(2016,1,18)),
                new BankHoliday(new DateTime(2016,2,15)),
                new BankHoliday(new DateTime(2016,3,25)),
                new BankHoliday(new DateTime(2016,5,30)),
                new BankHoliday(new DateTime(2016,7,4)),
                new BankHoliday(new DateTime(2016,9,5)),
                new BankHoliday(new DateTime(2016,11,24)),
                new BankHoliday(new DateTime(2016,12,26)),
                new BankHoliday(new DateTime(2016,1,1))
            }) },
            {110,new Tuple<string, string, int,List<BankHoliday>>("OTC Bulletin Board Market",".OB",1, new List<BankHoliday>()) },
            {111,new Tuple<string, string, int,List<BankHoliday>>("Pink Sheets",".PK",1, new List<BankHoliday>()) },
            {112,new Tuple<string, string, int,List<BankHoliday>>("S & P Indices","",1, new List<BankHoliday>()) },
            {113,new Tuple<string, string, int,List<BankHoliday>>("Buenos Aires Stock Exchange",".BA",9, new List<BankHoliday>()) },
            {114,new Tuple<string, string, int,List<BankHoliday>>("Vienna Stock Exchange",".VI",2, new List<BankHoliday>()) },
            {115,new Tuple<string, string, int,List<BankHoliday>>("Australian Stock Exchange",".AX",8, new List<BankHoliday>()) },
            {116,new Tuple<string, string, int,List<BankHoliday>>("Brussels Stocks",".BR",2, new List<BankHoliday>()) },
            {117,new Tuple<string, string, int,List<BankHoliday>>("BOVESPA – Sao Paolo Stock Exchange",".SA",11, new List<BankHoliday>()) },
            {118,new Tuple<string, string, int,List<BankHoliday>>("Toronto Stock Exchange",".TO",5,  new List<BankHoliday>
            {
                new BankHoliday(new DateTime(2015,1,1)),
                new BankHoliday(new DateTime(2015,2,16)),
                new BankHoliday(new DateTime(2015,4,3)),
                new BankHoliday(new DateTime(2015,5,18)),
                new BankHoliday(new DateTime(2015,7,1)),
                new BankHoliday(new DateTime(2015,8,3)),
                new BankHoliday(new DateTime(2015,9,7)),
                new BankHoliday(new DateTime(2015,10,12)),
                new BankHoliday(new DateTime(2015,12,25)),
                new BankHoliday(new DateTime(2015,12,28)),

                new BankHoliday(new DateTime(2016,1,1)),
                new BankHoliday(new DateTime(2016,2,15)),
                new BankHoliday(new DateTime(2016,3,25)),
                new BankHoliday(new DateTime(2016,5,23)),
                new BankHoliday(new DateTime(2016,7,1)),
                new BankHoliday(new DateTime(2016,8,1)),
                new BankHoliday(new DateTime(2016,9,5)),
                new BankHoliday(new DateTime(2016,10,10)),
                new BankHoliday(new DateTime(2016,12,26)),
                new BankHoliday(new DateTime(2016,12,27)),

                new BankHoliday(new DateTime(2017,1,2)),
                new BankHoliday(new DateTime(2017,2,20)),
                new BankHoliday(new DateTime(2017,4,14)),
                new BankHoliday(new DateTime(2017,5,22)),
                new BankHoliday(new DateTime(2017,7,03)),
                new BankHoliday(new DateTime(2017,8,7)),
                new BankHoliday(new DateTime(2017,9,4)),
                new BankHoliday(new DateTime(2017,10,9)),
                new BankHoliday(new DateTime(2017,12,25)),
                new BankHoliday(new DateTime(2017,12,26))

            }) },
            {119,new Tuple<string, string, int,List<BankHoliday>>("TSX Venture Exchange",".V",5, new List<BankHoliday>()) },
            {120,new Tuple<string, string, int,List<BankHoliday>>("Santiago Stock Exchange",".SN",12, new List<BankHoliday>()) },
            {121,new Tuple<string, string, int,List<BankHoliday>>("Shanghai Stock Exchange",".SS",10, new List<BankHoliday>()) },
            {122,new Tuple<string, string, int,List<BankHoliday>>("Shenzhen Stock Exchange",".SZ",10, new List<BankHoliday>()) },
            {123,new Tuple<string, string, int,List<BankHoliday>>("Copenhagen Stock Exchange",".CO",13, new List<BankHoliday>()) },
            {124,new Tuple<string, string, int,List<BankHoliday>>("Euronext",".NX",2, new List<BankHoliday>()) },
            {125,new Tuple<string, string, int,List<BankHoliday>>("Paris Stock Exchange",".PA",2, new List<BankHoliday>
            {
                new BankHoliday(new DateTime(2015,1,1)),
                new BankHoliday(new DateTime(2015,4,3)),
                new BankHoliday(new DateTime(2015,4,6)),
                new BankHoliday(new DateTime(2015,5,1)),
                new BankHoliday(new DateTime(2015,12,25)),
                new BankHoliday(new DateTime(2015,12,31)),

                new BankHoliday(new DateTime(2016,1,1)),
                new BankHoliday(new DateTime(2016,3,25)),
                new BankHoliday(new DateTime(2016,3,28)),
                new BankHoliday(new DateTime(2016,12,26)),

                new BankHoliday(new DateTime(2017,4,14)),
                new BankHoliday(new DateTime(2017,4,17)),
                new BankHoliday(new DateTime(2017,5,1)),
                new BankHoliday(new DateTime(2017,12,25)),
                new BankHoliday(new DateTime(2017,12,26))

            })},
            {126,new Tuple<string, string, int,List<BankHoliday>>("Berlin Stock Exchange",".BE",2, new List<BankHoliday>()) },
            {127,new Tuple<string, string, int,List<BankHoliday>>("Bremen Stock Exchange",".BM",2, new List<BankHoliday>()) },
            {128,new Tuple<string, string, int,List<BankHoliday>>("Dusseldorf Stock Exchange",".DU",2, new List<BankHoliday>()) },
            {129,new Tuple<string, string, int,List<BankHoliday>>("Frankfurt Stock Exchange",".F",2, new List<BankHoliday>
            {
                new BankHoliday(new DateTime(2015,1,1)),
                new BankHoliday(new DateTime(2015,4,3)),
                new BankHoliday(new DateTime(2015,4,6)),
                new BankHoliday(new DateTime(2015,5,1)),
                new BankHoliday(new DateTime(2015,5,25)),
                new BankHoliday(new DateTime(2015,12,24)),
                new BankHoliday(new DateTime(2015,12,25)),
                new BankHoliday(new DateTime(2015,12,31)),

                new BankHoliday(new DateTime(2016,1,1)),
                new BankHoliday(new DateTime(2016,3,25)),
                new BankHoliday(new DateTime(2016,3,28)),
                new BankHoliday(new DateTime(2016,5,16)),
                new BankHoliday(new DateTime(2016,10,3)),
                new BankHoliday(new DateTime(2016,12,26)),

                new BankHoliday(new DateTime(2017,4,14)),
                new BankHoliday(new DateTime(2017,4,17)),
                new BankHoliday(new DateTime(2017,5,1)),
                new BankHoliday(new DateTime(2017,12,25)),
                new BankHoliday(new DateTime(2017,12,26))
            }) },
            {130,new Tuple<string, string, int,List<BankHoliday>>("Hamburg Stock Exchange",".HM",2, new List<BankHoliday>()) },
            {131,new Tuple<string, string, int,List<BankHoliday>>("Hanover Stock Exchange",".HA",2, new List<BankHoliday>()) },
            {132,new Tuple<string, string, int,List<BankHoliday>>("Munich Stock Exchange",".MU",2, new List<BankHoliday>()) },
            {133,new Tuple<string, string, int,List<BankHoliday>>("Stuttgart Stock Exchange",".SG",2, new List<BankHoliday>()) },
            {134,new Tuple<string, string, int,List<BankHoliday>>("XETRA Stock Exchange",".DE",2, new List<BankHoliday>()) },
            {135,new Tuple<string, string, int,List<BankHoliday>>("Hong Kong Stock Exchange",".HK",14, new List<BankHoliday>()) },
            {136,new Tuple<string, string, int,List<BankHoliday>>("Bombay Stock Exchange",".BO",15, new List<BankHoliday>()) },
            {137,new Tuple<string, string, int,List<BankHoliday>>("National Stock Exchange of India",".NS",15, new List<BankHoliday>()) },
            {138,new Tuple<string, string, int,List<BankHoliday>>("Jakarta Stock Exchange",".JK",16, new List<BankHoliday>()) },
            {139,new Tuple<string, string, int,List<BankHoliday>>("Tel Aviv Stock Exchange",".TA",17, new List<BankHoliday>()) },
            {140,new Tuple<string, string, int,List<BankHoliday>>("Milan Stock Exchange",".MI",2, new List<BankHoliday>
            {
                new BankHoliday(new DateTime(2015,1,1)),
                new BankHoliday(new DateTime(2015,4,3)),
                new BankHoliday(new DateTime(2015,4,6)),
                new BankHoliday(new DateTime(2015,5,1)),
                new BankHoliday(new DateTime(2015,5,25)),
                new BankHoliday(new DateTime(2015,12,24)),
                new BankHoliday(new DateTime(2015,12,25)),
                new BankHoliday(new DateTime(2015,12,31)),

                new BankHoliday(new DateTime(2016,1,1)),
                new BankHoliday(new DateTime(2016,3,25)),
                new BankHoliday(new DateTime(2016,3,28)),
                new BankHoliday(new DateTime(2016,5,15)),
                new BankHoliday(new DateTime(2016,12,26)),

                new BankHoliday(new DateTime(2017,4,14)),
                new BankHoliday(new DateTime(2017,4,17)),
                new BankHoliday(new DateTime(2017,5,1)),
                new BankHoliday(new DateTime(2017,8,15)),
                new BankHoliday(new DateTime(2017,12,25)),
                new BankHoliday(new DateTime(2017,12,26))
            }) },
            {141,new Tuple<string, string, int,List<BankHoliday>>("Nikkei Indices","",7, new List<BankHoliday>()) },
            {142,new Tuple<string, string, int,List<BankHoliday>>("Mexico Stock Exchange",".MX",18, new List<BankHoliday>()) },
            {143,new Tuple<string, string, int,List<BankHoliday>>("Amsterdam Stock Exchange",".AS",2, new List<BankHoliday>()) },
            {144,new Tuple<string, string, int,List<BankHoliday>>("New Zealand Stock Exchange",".NZ",19, new List<BankHoliday>()) },
            {145,new Tuple<string, string, int,List<BankHoliday>>("Oslo Stock Exchange",".OL",20, new List<BankHoliday>()) },
            {146,new Tuple<string, string, int,List<BankHoliday>>("Lisbon Stocks",".LS",2, new List<BankHoliday>()) },
            {147,new Tuple<string, string, int,List<BankHoliday>>("Singapore Stock Exchange",".SI",6, new List<BankHoliday>()) },
            {148,new Tuple<string, string, int,List<BankHoliday>>("Korea Stock Exchange",".KS",21, new List<BankHoliday>()) },
            {149,new Tuple<string, string, int,List<BankHoliday>>("KOSDAQ",".KQ",21, new List<BankHoliday>()) },
            {150,new Tuple<string, string, int,List<BankHoliday>>("Barcelona Stock Exchange",".BC",2, new List<BankHoliday>()) },
            {151,new Tuple<string, string, int,List<BankHoliday>>("Bilbao Stock Exchange",".BI",2, new List<BankHoliday>()) },
            {152,new Tuple<string, string, int,List<BankHoliday>>("Madrid Fixed Income Market",".MF",2, new List<BankHoliday>()) },
            {153,new Tuple<string, string, int,List<BankHoliday>>("Madrid SE C.A.T.S",".MC",2, new List<BankHoliday>()) },
            {154,new Tuple<string, string, int,List<BankHoliday>>("Madrid Stock Exchange",".MA",2, new List<BankHoliday>()) },
            {155,new Tuple<string, string, int,List<BankHoliday>>("Stockholm Stock Exchange",".ST",22, new List<BankHoliday>()) },
            {156,new Tuple<string, string, int,List<BankHoliday>>("Swiss Exchange",".SW",3,  new List<BankHoliday>
            {
                new BankHoliday(new DateTime(2015,1,1)),
                new BankHoliday(new DateTime(2015,1,2)),
                new BankHoliday(new DateTime(2015,4,3)),
                new BankHoliday(new DateTime(2015,4,6)),
                new BankHoliday(new DateTime(2015,5,1)),
                new BankHoliday(new DateTime(2015,5,14)),
                new BankHoliday(new DateTime(2015,5,25)),
                new BankHoliday(new DateTime(2015,12,24)),
                new BankHoliday(new DateTime(2015,12,25)),
                new BankHoliday(new DateTime(2015,12,31)),

                new BankHoliday(new DateTime(2016,1,1)),
                new BankHoliday(new DateTime(2016,3,25)),
                new BankHoliday(new DateTime(2016,3,28)),
                new BankHoliday(new DateTime(2016,5,5)),
                new BankHoliday(new DateTime(2016,5,16)),
                new BankHoliday(new DateTime(2016,8,1)),
                new BankHoliday(new DateTime(2016,12,26)),

                new BankHoliday(new DateTime(2017,1,2)),
                new BankHoliday(new DateTime(2017,4,14)),
                new BankHoliday(new DateTime(2017,4,17)),
                new BankHoliday(new DateTime(2017,5,1)),
                new BankHoliday(new DateTime(2017,5,25)),
                new BankHoliday(new DateTime(2017,6,5)),
                new BankHoliday(new DateTime(2017,8,1)),
                new BankHoliday(new DateTime(2017,12,25)),
                new BankHoliday(new DateTime(2017,12,26))
            }) },
            {157,new Tuple<string, string, int,List<BankHoliday>>("Taiwan OTC Exchange",".TWO",2, new List<BankHoliday>()) },
            {158,new Tuple<string, string, int,List<BankHoliday>>("Taiwan Stock Exchange",".TW",23, new List<BankHoliday>()) },
            {159,new Tuple<string, string, int,List<BankHoliday>>("FTSE Indices","",4, new List<BankHoliday>()) },
            {160,new Tuple<string, string, int,List<BankHoliday>>("London Stock Exchange",".L",4,new List<BankHoliday>
            {
                new BankHoliday(new DateTime(2015,1,1)),
                new BankHoliday(new DateTime(2015,4,3)),
                new BankHoliday(new DateTime(2015,4,6)),
                new BankHoliday(new DateTime(2015,5,4)),
                new BankHoliday(new DateTime(2015,5,25)),
                new BankHoliday(new DateTime(2015,8,31)),
                new BankHoliday(new DateTime(2015,12,25)),
                new BankHoliday(new DateTime(2015,12,28)),

                new BankHoliday(new DateTime(2016,1,1)),
                new BankHoliday(new DateTime(2016,3,25)),
                new BankHoliday(new DateTime(2016,3,28)),
                new BankHoliday(new DateTime(2016,5,2)),
                new BankHoliday(new DateTime(2016,5,30)),
                new BankHoliday(new DateTime(2016,8,29)),
                new BankHoliday(new DateTime(2016,12,26)),
                new BankHoliday(new DateTime(2016,12,27)),

                new BankHoliday(new DateTime(2017,1,2)),
                new BankHoliday(new DateTime(2017,4,14)),
                new BankHoliday(new DateTime(2017,4,17)),
                new BankHoliday(new DateTime(2017,5,1)),
                new BankHoliday(new DateTime(2017,5,29)),
                new BankHoliday(new DateTime(2017,8,28)),
                new BankHoliday(new DateTime(2017,12,25)),
                new BankHoliday(new DateTime(2017,12,26)),

                new BankHoliday(new DateTime(2018,1,1)),
                new BankHoliday(new DateTime(2018,3,30)),
                new BankHoliday(new DateTime(2018,4,2)),
                new BankHoliday(new DateTime(2018,5,7)),
                new BankHoliday(new DateTime(2018,5,28)),
                new BankHoliday(new DateTime(2018,8,27)),
                new BankHoliday(new DateTime(2018,12,25)),
                new BankHoliday(new DateTime(2018,12,26))
            } ) }

        };

    }
}