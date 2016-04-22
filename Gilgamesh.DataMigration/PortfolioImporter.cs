using System.Collections.Generic;
using Gilgamesh.Entities;
using Gilgamesh.Entities.Portfolio;

namespace Gilgamesh.DataMigration
{
    public class PortfolioImporter
    {
        public static void ImportFolios()
        {
            var chf= UnitOfWorkFactory.Instance.UnitOfWork.CurrencyRepository.Get(3);
            var eur = UnitOfWorkFactory.Instance.UnitOfWork.CurrencyRepository.Get(2);
           


            Portfolio compteTitresSaxobank = new Portfolio() {PortfolioCurrency = chf,ChildPortfolios = new List<Portfolio>(), IsStrategy = true, Name = "Compte Titres Saxobank", IsLiquidFolio = false};
            Portfolio saxoBank = new Portfolio() { PortfolioCurrency = chf, ChildPortfolios = new List<Portfolio>(), IsStrategy = false, Name = "Saxobank", IsLiquidFolio = false };
            saxoBank.ChildPortfolios.Add(compteTitresSaxobank);

            Portfolio compteTitresBinck = new Portfolio() { PortfolioCurrency = eur, ChildPortfolios = new List<Portfolio>(), IsStrategy = true, Name = "Compte Titres Binck", IsLiquidFolio = false };
            Portfolio peaBinck = new Portfolio() { PortfolioCurrency = eur, ChildPortfolios = new List<Portfolio>(), IsStrategy = true, Name = "PEA Binck", IsLiquidFolio = false };
            Portfolio binck = new Portfolio() { PortfolioCurrency = eur, ChildPortfolios = new List<Portfolio>(), IsStrategy = false, Name = "Binck", IsLiquidFolio = false };
            binck.ChildPortfolios.Add(compteTitresBinck);
            binck.ChildPortfolios.Add(peaBinck);

            Portfolio compteChequeBoursorama = new Portfolio() { PortfolioCurrency = eur, ChildPortfolios = new List<Portfolio>(), IsStrategy = true, Name = "Compte Cheque Boursorama", IsLiquidFolio = true };
            Portfolio boursorama = new Portfolio() { PortfolioCurrency = eur, ChildPortfolios = new List<Portfolio>(), IsStrategy = false, Name = "Boursorama", IsLiquidFolio = false };
            boursorama.ChildPortfolios.Add(compteChequeBoursorama);


            Portfolio compteChequeBnp = new Portfolio() { PortfolioCurrency = eur, ChildPortfolios = new List<Portfolio>(), IsStrategy = true, Name = "Compte Cheque BNP", IsLiquidFolio = true };
            Portfolio livretABnp = new Portfolio() { PortfolioCurrency = eur, ChildPortfolios = new List<Portfolio>(), IsStrategy = true, Name = "Livret A BNP", IsLiquidFolio = true };
            Portfolio celBnp = new Portfolio() { PortfolioCurrency = eur, ChildPortfolios = new List<Portfolio>(), IsStrategy = true, Name = "CEL BNP", IsLiquidFolio = true };
            Portfolio pelBnp = new Portfolio() { PortfolioCurrency = eur, ChildPortfolios = new List<Portfolio>(), IsStrategy = true, Name = "PEL BNP", IsLiquidFolio = true };
            Portfolio bnp = new Portfolio() { PortfolioCurrency = eur, ChildPortfolios = new List<Portfolio>(), IsStrategy = false, Name = "BNP Paribas", IsLiquidFolio = false };
            bnp.ChildPortfolios.Add(compteChequeBnp);
            bnp.ChildPortfolios.Add(livretABnp);
            bnp.ChildPortfolios.Add(celBnp);
            bnp.ChildPortfolios.Add(pelBnp);

            Portfolio epargneSalarialeAxa = new Portfolio() { PortfolioCurrency = eur, ChildPortfolios = new List<Portfolio>(), IsStrategy = true, Name = "Epargne Salariale Axa", IsLiquidFolio = false };
            Portfolio axa = new Portfolio() { PortfolioCurrency = eur, ChildPortfolios = new List<Portfolio>(), IsStrategy = false, Name = "AXA", IsLiquidFolio = false };
            axa.ChildPortfolios.Add(epargneSalarialeAxa);

            Portfolio compteLienhard = new Portfolio() { PortfolioCurrency = chf, ChildPortfolios = new List<Portfolio>(), IsStrategy = true, Name = "Compte Lienhardt & Partner", IsLiquidFolio = true };
            Portfolio assuranceVieSwissLife = new Portfolio() { PortfolioCurrency = chf, ChildPortfolios = new List<Portfolio>(), IsStrategy = true, Name = "Assurance Vie Swiss Life", IsLiquidFolio = false };
            Portfolio swissLifeSelect = new Portfolio() { PortfolioCurrency = chf, ChildPortfolios = new List<Portfolio>(), IsStrategy = false, Name = "Swiss Life Select", IsLiquidFolio = false };
            swissLifeSelect.ChildPortfolios.Add(compteLienhard);
            swissLifeSelect.ChildPortfolios.Add(assuranceVieSwissLife);

            Portfolio comptePaiementRaiffeisen = new Portfolio() { PortfolioCurrency = chf, ChildPortfolios = new List<Portfolio>(), IsStrategy = true, Name = "Compte Paiment Raiffeisen", IsLiquidFolio = true };
            Portfolio raiffeisen = new Portfolio() { PortfolioCurrency = chf, ChildPortfolios = new List<Portfolio>(), IsStrategy = false, Name = "Raiffeisen", IsLiquidFolio = false };
            raiffeisen.ChildPortfolios.Add(comptePaiementRaiffeisen);



            Portfolio root = new Portfolio() { PortfolioCurrency = chf, ChildPortfolios = new List<Portfolio>(), IsStrategy = false, Name = "Portefeuille Julien Husser", IsLiquidFolio = false };
            root.ChildPortfolios.Add(saxoBank);
            root.ChildPortfolios.Add(raiffeisen);
            root.ChildPortfolios.Add(swissLifeSelect);
            root.ChildPortfolios.Add(binck);
            root.ChildPortfolios.Add(boursorama);
            root.ChildPortfolios.Add(bnp);
            root.ChildPortfolios.Add(axa);

            UnitOfWorkFactory.Instance.UnitOfWork.Portfolios.Add(root);
            UnitOfWorkFactory.Instance.UnitOfWork.Complete();
        }
    }
}