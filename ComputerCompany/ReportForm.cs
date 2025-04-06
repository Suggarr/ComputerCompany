using System;
using Microsoft.Reporting.WinForms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace ComputerCompany
{
    public partial class ReportForm : Form
    {
        private DateTime? startDate;
        private DateTime? endDate;
        private int? supplierId;
        public ReportForm(DateTime? startDate, DateTime? endDate, int? supplierId)
        {
            InitializeComponent();
            this.startDate = startDate;
            this.endDate = endDate;
            this.supplierId = supplierId;
            this.computerCompanyDBDataSet.GetPurchaseDetailsForSuppliers.Reset();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            this.getPurchaseDetailsForSuppliersTableAdapter.Fill(this.computerCompanyDBDataSet.GetPurchaseDetailsForSuppliers, startDate, endDate, supplierId);
            // Вызов хранимой процедуры через TableAdapter
            reportViewer1.LocalReport.DataSources.Clear();
            //string startDateString = startDate.ToString("dd MMM yyyy");
            //string endDateString = endDate.ToString("dd MMM yyyy"); 
            //Создание источника данных для отчета
            ReportDataSource rds = new ReportDataSource("PurchaseForSuppliersDataSet",
            computerCompanyDBDataSet.GetPurchaseDetailsForSuppliers as DataTable);
            //ReportParameter ParameterStart = new ReportParameter("ReportParameterStart", startDateString);
            //ReportParameter ParameterEnd = new ReportParameter("ReportParameterEnd", endDateString);
            //reportViewer1.LocalReport.SetParameters(new ReportParameter[] { ParameterStart, ParameterEnd });


            reportViewer1.LocalReport.DataSources.Add(rds);


            this.reportViewer1.RefreshReport();
        }
    }
}
