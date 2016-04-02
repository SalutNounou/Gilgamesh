using System;
using System.Collections.Generic;
using Gilgamesh.Entities;
using Gilgamesh.Entities.StaticData.Market;

namespace Gilgamesh.DataMigration
{
    public class MarketImporter
    {
        public static void ImportMarkets()
        {

            foreach (KeyValuePair<int, Tuple<string, string, int>> kvp in Markets)
            {
                UnitOfWorkFactory.Instance.UnitOfWork.Markets.Add(new Market { Id = kvp.Key, MarketName = kvp.Value.Item1, MarketAcronym = kvp.Value.Item2, MarketCurrencyId = kvp.Value.Item3 });
            }
            UnitOfWorkFactory.Instance.UnitOfWork.Complete();
        }



        private static readonly Dictionary<int, Tuple<string, string, int>> Markets = new Dictionary<int, Tuple<string, string, int>>
        {
            {100,new Tuple<string, string, int>("American Stock Exchange","",1) },
            {101,new Tuple<string, string, int>("BATS Exchange","",1) },
            {102,new Tuple<string, string, int>("Chicago Board of Trade",".CBT",1) },
            {103,new Tuple<string, string, int>("Chicago Mercantile Exchange",".CME",1) },
            {104,new Tuple<string, string, int>("Dow Jones Indexes","",1) },
            {105,new Tuple<string, string, int>("NASDAQ Stock Exchange","",1) },
            {106,new Tuple<string, string, int>("New York Board of Trade",".NYB",1) },
            {107,new Tuple<string, string, int>("New York Commodities Exchange",".CMX",1) },
            {108,new Tuple<string, string, int>("New York Mercantile Exchange",".NYM",1) },
            {109,new Tuple<string, string, int>("New York Stock Exchange","",1) },
            {110,new Tuple<string, string, int>("OTC Bulletin Board Market",".OB",1) },
            {111,new Tuple<string, string, int>("Pink Sheets",".PK",1) },
            {112,new Tuple<string, string, int>("S & P Indices","",1) },
            {113,new Tuple<string, string, int>("Buenos Aires Stock Exchange",".BA",9) },
            {114,new Tuple<string, string, int>("Vienna Stock Exchange",".VI",2) },
            {115,new Tuple<string, string, int>("Australian Stock Exchange",".AX",8) },
            {116,new Tuple<string, string, int>("Brussels Stocks",".BR",2) },
            {117,new Tuple<string, string, int>("BOVESPA – Sao Paolo Stock Exchange",".SA",11) },
            {118,new Tuple<string, string, int>("Toronto Stock Exchange",".TO",5) },
            {119,new Tuple<string, string, int>("TSX Venture Exchange",".V",5) },
            {120,new Tuple<string, string, int>("Santiago Stock Exchange",".SN",12) },
            {121,new Tuple<string, string, int>("Shanghai Stock Exchange",".SS",10) },
            {122,new Tuple<string, string, int>("Shenzhen Stock Exchange",".SZ",10) },
            {123,new Tuple<string, string, int>("Copenhagen Stock Exchange",".CO",13) },
            {124,new Tuple<string, string, int>("Euronext",".NX",2) },
            {125,new Tuple<string, string, int>("Paris Stock Exchange",".PA",2) },
            {126,new Tuple<string, string, int>("Berlin Stock Exchange",".BE",2) },
            {127,new Tuple<string, string, int>("Bremen Stock Exchange",".BM",2) },
            {128,new Tuple<string, string, int>("Dusseldorf Stock Exchange",".DU",2) },
            {129,new Tuple<string, string, int>("Frankfurt Stock Exchange",".F",2) },
            {130,new Tuple<string, string, int>("Hamburg Stock Exchange",".HM",2) },
            {131,new Tuple<string, string, int>("Hanover Stock Exchange",".HA",2) },
            {132,new Tuple<string, string, int>("Munich Stock Exchange",".MU",2) },
            {133,new Tuple<string, string, int>("Stuttgart Stock Exchange",".SG",2) },
            {134,new Tuple<string, string, int>("XETRA Stock Exchange",".DE",2) },
            {135,new Tuple<string, string, int>("Hong Kong Stock Exchange",".HK",14) },
            {136,new Tuple<string, string, int>("Bombay Stock Exchange",".BO",15) },
            {137,new Tuple<string, string, int>("National Stock Exchange of India",".NS",15) },
            {138,new Tuple<string, string, int>("Jakarta Stock Exchange",".JK",16) },
            {139,new Tuple<string, string, int>("Tel Aviv Stock Exchange",".TA",17) },
            {140,new Tuple<string, string, int>("Milan Stock Exchange",".MI",2) },
            {141,new Tuple<string, string, int>("Nikkei Indices","",7) },
            {142,new Tuple<string, string, int>("Mexico Stock Exchange",".MX",18) },
            {143,new Tuple<string, string, int>("Amsterdam Stock Exchange",".AS",2) },
            {144,new Tuple<string, string, int>("New Zealand Stock Exchange",".NZ",19) },
            {145,new Tuple<string, string, int>("Oslo Stock Exchange",".OL",20) },
            {146,new Tuple<string, string, int>("Lisbon Stocks",".LS",2) },
            {147,new Tuple<string, string, int>("Singapore Stock Exchange",".SI",6) },
            {148,new Tuple<string, string, int>("Korea Stock Exchange",".KS",21) },
            {149,new Tuple<string, string, int>("KOSDAQ",".KQ",21) },
            {150,new Tuple<string, string, int>("Barcelona Stock Exchange",".BC",2) },
            {151,new Tuple<string, string, int>("Bilbao Stock Exchange",".BI",2) },
            {152,new Tuple<string, string, int>("Madrid Fixed Income Market",".MF",2) },
            {153,new Tuple<string, string, int>("Madrid SE C.A.T.S",".MC",2) },
            {154,new Tuple<string, string, int>("Madrid Stock Exchange",".MA",2) },
            {155,new Tuple<string, string, int>("Stockholm Stock Exchange",".ST",22) },
            {156,new Tuple<string, string, int>("Swiss Exchange",".SW",3) },
            {157,new Tuple<string, string, int>("Taiwan OTC Exchange",".TWO",2) },
            {158,new Tuple<string, string, int>("Taiwan Stock Exchange",".TW",23) },
            {159,new Tuple<string, string, int>("FTSE Indices","",4) },
            {160,new Tuple<string, string, int>("London Stock Exchange",".L",4) }

        };

    }
}