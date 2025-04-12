using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        private void reportViewer_ReportExport(object sender, ReportExportEventArgs e)
        {
            e.Cancel = true;

            string extension = this.GetRenderingExtension(e.Extension);

            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Title = "Сохранить как",
                CheckPathExists = true,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                FileName = "Чек",
                Filter = e.Extension.LocalizedName + " (*" + extension + ")|*" + extension + "|Все файлы(*.*)|*.*",
                FilterIndex = 0
            };

            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.reportViewer1.ExportDialog(e.Extension, e.DeviceInfo, saveFileDialog.FileName);

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
