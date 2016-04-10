using System.Collections.Generic;
using Gilgamesh.Entities.StaticData.Currency;

namespace Gilgamesh.Entities.Portfolio
{
    public class Portfolio
    {

        private readonly List<Position> _positions;

        public Portfolio()
        {
            _positions = new List<Position>();
        }


        public int PortfolioId { get; set; } 
        public Currency PortfolioCurrency { get; set; }
        public bool IsStrategy { get; set; }
        public Portfolio FatherPortfolio { get; set; }
        public virtual List<Portfolio> ChildPortfolios { get; set; }
        public byte [] RowVersion { get; set; }
        public string Name { get; set; }
        public void Load()
        {
            
        }

        public int GetPositionsCount()
        {
            return _positions.Count;
        }

        public Position GetNthPosition(int which)
        {
            return _positions[which];
        }

    }
}