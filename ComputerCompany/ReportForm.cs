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
                Filter = e.Extension.LocalizedName + " (*" + extension + ")|*" + extension + "|All files(*.*)|*.*",
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
                    throw new NotImplementedException("Extension not implemented.");
            }

            throw new NotImplementedException("Extension not implemented.");
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


        //private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string recipientEmail = toolStripTextBox1.Text;
        //    string reportFormat = toolStripComboBox1.SelectedItem.ToString();

        //    try
        //    {
        //        string reportFilePath = GenerateReport(reportFormat);
        //        SendReportByEmail(recipientEmail, reportFilePath);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Ошибка: " + ex.Message);
        //    }
        //}

        //private string GenerateReport(string format)
        //{
        //    // Укажите путь к папке для сохранения отчетов
        //    string reportsFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports");

        //    // Убедитесь, что папка существует
        //    if (!Directory.Exists(reportsFolderPath))
        //    {
        //        Directory.CreateDirectory(reportsFolderPath);
        //    }
        //    string reportFilePath = null;
        //    byte[] reportBytes;
        //    if (format == "PDF")
        //    {
        //        reportBytes = reportViewer1.LocalReport.Render("PDF");
        //        reportFilePath = Path.Combine(reportsFolderPath, $"Report.pdf");
        //    }
        //    else if (format == "Word")
        //    {
        //        reportBytes = reportViewer1.LocalReport.Render("Word");
        //        reportFilePath = Path.Combine(reportsFolderPath, $"Report.doc");
        //    }
        //    else if (format == "Excel")
        //    {
        //        reportBytes = reportViewer1.LocalReport.Render("Excel");
        //        reportFilePath = Path.Combine(reportsFolderPath, $"Report.xlsx");
        //    }
        //    else
        //    {
        //        throw new Exception("Неподдерживаемый формат отчета.");
        //    }

        //    File.WriteAllBytes(reportFilePath, reportBytes);
        //    return reportFilePath;
        //}

        //private void SendReportByEmail(string recipientEmail, string reportFilePath)
        //{
        //    if (IsInternetAvailable())
        //    {
        //        try
        //        {
        //            MailMessage mail = new MailMessage();
        //            mail.From = new MailAddress(senderEmail);
        //            mail.To.Add(recipientEmail);
        //            mail.Subject = "Ваш отчет. Компьютерная фирма";
        //            mail.Body = "Пожалуйста, найдите прикрепленный отчет.";

        //            // Создание вложения
        //            Attachment attachment = new Attachment(reportFilePath);
        //            mail.Attachments.Add(attachment);

        //            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587)
        //            {
        //                Credentials = new NetworkCredential(senderEmail, senderPassword),
        //                EnableSsl = true
        //            };

        //            smtpClient.Send(mail);
        //            MessageBox.Show("Отчет отправлен по электронной почте.");
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Ошибка при отправке электронной почты: " + ex.Message);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Отправка отчета прервана. Проверьте подключение к интернету.");
        //    }
        //}

        //private static bool IsInternetAvailable()
        //{
        //    try
        //    {
        //        using (var ping = new System.Net.NetworkInformation.Ping())
        //        {
        //            var reply = ping.Send("8.8.8.8", 1000);
        //            return reply.Status == System.Net.NetworkInformation.IPStatus.Success;
        //        }
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //private void ReportForm_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    // Укажите путь к папке для сохранения отчетов
        //    string reportsFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports");

        //    // Если папка существует, удалите все файлы в ней
        //    if (Directory.Exists(reportsFolderPath))
        //    {
        //        foreach (var file in Directory.GetFiles(reportsFolderPath))
        //        {
        //            try
        //            {
        //                File.Delete(file);
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show($"Ошибка при удалении файла {file}: {ex.Message}");
        //            }
        //        }
        //    }
        //}
    }
}
