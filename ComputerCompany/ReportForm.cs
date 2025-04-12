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
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace ComputerCompany
{
    public partial class ReportForm : Form
    {
        private DateTime? startDate;
        private DateTime? endDate;
        private int? supplierId;
        private string supplierName;
        private bool reportFlag;

        public ReportForm(DateTime? startDate, DateTime? endDate, int? supplierId, string supplierName, bool reportFlag)
        {
            InitializeComponent();
            this.startDate = startDate;
            this.endDate = endDate;
            this.supplierId = supplierId;
            this.supplierName = supplierName;
            this.reportFlag = reportFlag;
            this.computerCompanyDBDataSet.GetPurchaseDetailsForSuppliers.Reset();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            reportViewerMain.LocalReport.DataSources.Clear();
            string reportDataSet;
            DataTable dataTable;

            // Determine which dataset to use based on the reportFlag
            if (reportFlag)
            {
                this.getFilteredPurchasesTableAdapter.Fill(this.computerCompanyDBDataSet.GetFilteredPurchases, supplierId, startDate, endDate);
                reportViewerMain.LocalReport.ReportEmbeddedResource = "ComputerCompany.ReportTable.rdlc";
                reportDataSet = "FilteredDataSet";
                dataTable = computerCompanyDBDataSet.GetFilteredPurchases;
            }
            else
            {
                this.getPurchaseDetailsForSuppliersTableAdapter.Fill(this.computerCompanyDBDataSet.GetPurchaseDetailsForSuppliers, startDate, endDate, supplierId);
                reportViewerMain.LocalReport.ReportEmbeddedResource = "ComputerCompany.ReportOfAll.rdlc";
                reportDataSet = "PurchaseForSuppliersDataSet";
                dataTable = computerCompanyDBDataSet.GetPurchaseDetailsForSuppliers;
            }

            // Prepare the total text based on the supplied parameters
            string total;
            bool flag;

            if (supplierId == null)
            {
                total = startDate == null && endDate == null
                    ? "Отчет по закупкам комплектующих за все время для всех поставщиков"
                    : $"Отчет по закупкам комплектующих с {startDate?.ToString("dd MMM yyyy")} до {endDate?.ToString("dd MMM yyyy")} для всех поставщиков";
                flag = false;
            }
            else
            {
                total = startDate == null && endDate == null
                    ? $"Отчет по закупкам комплектующих за все время для поставщика {supplierName}"
                    : $"Отчет по закупкам комплектующих с {startDate?.ToString("dd MMM yyyy")} до {endDate?.ToString("dd MMM yyyy")} для поставщика {supplierName}";
                flag = true;
            }

            ReportDataSource rds = new ReportDataSource(reportDataSet, dataTable);
            ReportParameter totalText = new ReportParameter("TotalText", total);
            ReportParameter reportFlagParam = new ReportParameter("ReportParameterFlag", flag.ToString());

            reportViewerMain.LocalReport.SetParameters(new ReportParameter[] { totalText, reportFlagParam });
            reportViewerMain.LocalReport.DataSources.Add(rds);

            this.reportViewerMain.RefreshReport();
        }

        private void reportViewer_ReportExport(object sender, ReportExportEventArgs e)
        {
            e.Cancel = true;

            string extension = this.GetRenderingExtension(e.Extension);

            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Title = "Сохранить как",
                CheckPathExists = true,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                FileName = "Отчет",
                Filter = e.Extension.LocalizedName + " (*" + extension + ")|*" + extension + "|Все файлы(*.*)|*.*",
                FilterIndex = 0
            };

            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.reportViewerMain.ExportDialog(e.Extension, e.DeviceInfo, saveFileDialog.FileName);

                OpenFileWithPrompt(saveFileDialog.FileName);
            }
        }

        private string GetRenderingExtension(RenderingExtension extension)
        {
            switch (extension.Name)
            {
                case "PDF":
                    return ".pdf";
                case "EXCELOPENXML":
                    return ".xlsx";
                case "WORDOPENXML":
                    return ".docx";
                case "NULL":
                    throw new NotImplementedException("Расширение не реализовано");
            }

            throw new NotImplementedException("Расширение не реализовано");
        }

        public static void OpenFileWithPrompt(string file)
        {
            DialogResult result = MessageBox.Show(
                "Файл успешно сохранён.\nОткрыть его сейчас?",
                "Открыть файл",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {
                Process.Start(new ProcessStartInfo(file) { UseShellExecute = true });
            }
        }
    }
}
