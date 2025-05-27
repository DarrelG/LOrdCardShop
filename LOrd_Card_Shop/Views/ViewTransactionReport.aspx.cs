using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LOrd_Card_Shop.Handler;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.DataSet;
using LOrd_Card_Shop.Report;

namespace LOrd_Card_Shop.Views
{
    public partial class ViewTransactionReport : System.Web.UI.Page
    {
        ReportDocument rptDoc;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadReport();
            }
        }

        private void LoadReport()
        {

            List<TransactionReportModel> data = TransactionReportHandler.GetReportData();
            CrystalReport1 report = new CrystalReport1();

            CrystalReportViewer1.ReportSource = report;

            DataSet1 datas = getData(data);
            report.SetDataSource(datas);
        }

        private DataSet1 getData(List<TransactionReportModel> reports)
        {
            DataSet1 dat = new DataSet1();

            var mainTable = dat.TransactionReport;

            foreach (TransactionReportModel model in reports)
            {
                var row = mainTable.NewRow();
                row["TransactionDate"] = model.TransactionDate;
                row["TransactionID"] = model.TransactionID;
                row["CustomerName"] = model.CustomerName;
                row["CardName"] = model.CardName;
                row["Quantity"] = model.Quantity;
                row["CardPrice"] = model.CardPrice;
                row["SubTotal"] = model.SubTotal;

                mainTable.Rows.Add(row);
            }

            return dat;
        }

        protected void CrystalReportViewer1_Init(object sender, EventArgs e)
        {

        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            //if(rptDoc != null)
            //{
            //    rptDoc.Close();
            //    rptDoc.Dispose();
            //}
        }
    }
}