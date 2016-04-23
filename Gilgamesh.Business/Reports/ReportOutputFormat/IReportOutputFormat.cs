using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace Gilgamesh.Business.Reports.ReportOutputFormat
{
    public interface IReportOutputFormat
    {
        void GenerateReportOutput(DataTable data);
    }


    public class CsvReportOutputFormat : IReportOutputFormat
    {
        public void GenerateReportOutput(DataTable data)
        {

        }
    }
}