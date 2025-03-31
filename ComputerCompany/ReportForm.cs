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

namespace ComputerCompany
{
    public partial class ReportForm : Form
    {
        private DateTime startDate;
        private DateTime endDate;
        public ReportForm(DateTime startDate, DateTime endDate)
        {
            InitializeComponent();
            this.startDate = startDate;
            this.endDate = endDate;
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            // Вызов хранимой процедуры через TableAdapter
            this.getSupplierEarningsTableAdapter.Fill(this.computerCompanyDBDataSet.GetSupplierEarnings, startDate, endDate);
            reportViewer1.LocalReport.DataSources.Clear();
            string startDateString = startDate.ToString("dd MMM yyyy");
            string endDateString = endDate.ToString("dd MMM yyyy"); 
            // Установка источника данных для ReportViewer
            ReportDataSource rds = new ReportDataSource("SupplierEarningsDataSet", this.computerCompanyDBDataSet.GetSupplierEarnings as DataTable);
            ReportParameter ParameterStart = new ReportParameter("ReportParameterStart", startDateString);
            ReportParameter ParameterEnd = new ReportParameter("ReportParameterEnd", endDateString);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { ParameterStart, ParameterEnd });

            
            reportViewer1.LocalReport.DataSources.Add(rds);


            this.reportViewer1.RefreshReport();
        }
    }
}
