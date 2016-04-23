using System;
using System.Data;
using System.Text;

namespace Gilgamesh.Business.Reports.ReportOutputFormat
{
    public class MailReportOutputFormat : IReportOutputFormat
    {

        public void GenerateReportOutput(DataTable data)
        {
            var message = new StringBuilder();
            message.AppendFormat("Report for your portfolio at date : {0} \n", DateTime.Today.ToShortDateString());
            message.AppendLine().AppendLine().Append(GetHtml(data));
            var adressTo = System.Configuration.ConfigurationManager.AppSettings["mailAdressTo"];
            Utils.Mail.MailUtil.SendMail(adressTo, "Portfolio Status", message.ToString());
        }

        private static string GetHtml(DataTable dt)

        {
            StringBuilder myBuilder = new StringBuilder();

            myBuilder.Append("<table border='1px' cellpadding='5' cellspacing='0' ");
            myBuilder.Append("style='border: solid 1px Silver; font-size: x-small;'>");

            myBuilder.Append("<tr align='left' valign='top'>");
            foreach (DataColumn myColumn in dt.Columns)
            {
                myBuilder.Append("<td align='left' valign='top'>");
                myBuilder.Append(myColumn.ColumnName);
                myBuilder.Append("</td>");
            }
            myBuilder.Append("</tr>");

            foreach (DataRow myRow in dt.Rows)
            {
                myBuilder.Append("<tr align='left' valign='top'>");
                foreach (DataColumn myColumn in dt.Columns)
                {
                    myBuilder.Append("<td align='left' valign='top'>");
                    myBuilder.Append(myRow[myColumn.ColumnName].ToString());
                    myBuilder.Append("</td>");
                }
                myBuilder.Append("</tr>");
            }
            myBuilder.Append("</table>");

            return myBuilder.ToString();
        }
    }
}