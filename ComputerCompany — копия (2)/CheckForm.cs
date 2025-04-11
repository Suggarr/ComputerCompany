using Microsoft.Reporting.WinForms;
using System;
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
    public partial class CheckForm : Form
    {
        private int? PurchaseId;
        public CheckForm(int PurchaseId)
        {
            InitializeComponent();
            this.PurchaseId = PurchaseId;
        }

        private void CheckForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "computerCompanyDBDataSet.GetPurchaseDetailsByPurchaseID". При необходимости она может быть перемещена или удалена.
            this.getPurchaseDetailsByPurchaseIDTableAdapter.Fill(this.computerCompanyDBDataSet.GetPurchaseDetailsByPurchaseID, PurchaseId);

            // Установка источника данных для ReportViewer
            ReportDataSource rds = new ReportDataSource("CheckDataSet", this.computerCompanyDBDataSet.GetPurchaseDetailsByPurchaseID as DataTable);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }
    }
}
