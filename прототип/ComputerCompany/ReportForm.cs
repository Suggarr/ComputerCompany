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

namespace ComputerCompany
{
    public partial class ReportForm : Form
    {
        private DateTime? startDate;
        private DateTime? endDate;
        private int? supplierId;
        //const string senderPassword = "snio cuui zztn linv"; /// Пароль отправителя.
        //const string senderEmail = "gogle35673@gmail.com";   /// Email отправителя.
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
