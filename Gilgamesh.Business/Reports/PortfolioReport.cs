using System.Collections.Generic;
using System.Data;
using Gilgamesh.Business.Reports.ReportOutputFormat;
using Gilgamesh.Entities;
using Gilgamesh.Entities.Portfolio;
using Gilgamesh.Entities.Portfolio.PortfolioColumns;

namespace Gilgamesh.Business.Reports
{
    public class PortfolioReport : IReport
    {
        private readonly List<IReportOutputFormat> _outputsFormats;
        private readonly List<PortfolioColumn> _columns;
        private DataTable _reportData;
        private readonly int _entryPoint;

        public PortfolioReport(List<IReportOutputFormat> outputsFormats, List<PortfolioColumn> columns, int entryPoint)
        {
            _outputsFormats = outputsFormats;
            _columns = columns;
            _entryPoint = entryPoint;
            InitTable();
        }


        private void InitTable()
        {
            _reportData= new DataTable();
            _reportData.Columns.Add("Portfolio Name", typeof (string));
            _reportData.Columns.Add("Position Name", typeof(string));
            _columns.ForEach(c=>_reportData.Columns.Add(c.Name, typeof(string)));
        }

        private void PopulateReportData(int entryPoint)
        {
            var portfolio = UnitOfWorkFactory.Instance.UnitOfWork.Portfolios.Get(entryPoint);
            if (portfolio == null) return;
            portfolio.Load();
            PopulateTableForFolio(portfolio);
            var posCount = portfolio.GetPositionsCount();
            for (int currentPos = 0; currentPos < posCount; currentPos++)
            {
                var position = portfolio.GetNthPosition(currentPos);
                PopulateTableForPosition(position);
            }
            portfolio.ChildPortfolios.ForEach(c=>PopulateReportData(c.PortfolioId));
        }


        private void PopulateTableForFolio(Portfolio folio)
        {
            var dataRow = _reportData.NewRow();
            dataRow["Portfolio Name"] = folio.Name;
            dataRow["Position Name"] = string.Empty;
            foreach (var portfolioColumn in _columns)
            {
                var cellStyle = new CellStyle();
                var cellValue = new CellValue();
                portfolioColumn.GetPortfolioCell(folio.PortfolioId, cellStyle, cellValue);
                dataRow[portfolioColumn.Name] = portfolioColumn.GetStringValue(cellStyle, cellValue);
            }
            _reportData.Rows.Add(dataRow);
        }


        private void PopulateTableForPosition(Position position)
        {
            var dataRow=_reportData.NewRow();
            dataRow["Portfolio Name"] = string.Empty;
            dataRow["Position Name"] = position.Instrument.Name;
            foreach (var portfolioColumn in _columns)
            {
                var cellStyle = new CellStyle();
                var cellValue = new CellValue();
                portfolioColumn.GetPositionCell(position, cellStyle, cellValue);
                dataRow[portfolioColumn.Name] = portfolioColumn.GetStringValue(cellStyle,cellValue);
            }
            _reportData.Rows.Add(dataRow);
        }

        public void ProcessReport()
        {
            PopulateReportData(_entryPoint);
            GenerateReportOutputs();
        }


        private void GenerateReportOutputs()
        {
            _outputsFormats.ForEach(o=>o.GenerateReportOutput(_reportData));
        }
    }
}