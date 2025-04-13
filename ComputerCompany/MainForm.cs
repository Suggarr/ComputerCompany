using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.Drawing;

namespace ComputerCompany
{
    public partial class MainForm : Form
    {
        private PurchasesForm purchasesForm;
        private PurchaseDetailsForm purhaseDetailsForm;
        private ComponentsForm componentsForm;
        private SuppliersForm suppliersForm;
        private CategoriesForm categoriesForm;
        private ReportForm reportForm;
        public MainForm()
        {
            InitializeComponent();
           
        }

        private void RefreshData()
        {
            this.purchasesTableAdapter.Fill(computerCompanyDBDataSet.Purchases);
            this.purchaseDetailsTableAdapter.Fill(computerCompanyDBDataSet.PurchaseDetails);
            this.componentsTableAdapter.Fill(computerCompanyDBDataSet.Components);
            this.categoriesTableAdapter.Fill(computerCompanyDBDataSet.Categories);
            this.suppliersTableAdapter.Fill(computerCompanyDBDataSet.Suppliers);
        }

        private void LoadData()
        {
            try
            {
                RefreshData();
                if (!computerCompanyDBDataSet.Purchases.Columns.Contains("TotalQuantity"))
                {
                    computerCompanyDBDataSet.Purchases.Columns.Add("TotalQuantity", typeof(int));
                }
                if (!computerCompanyDBDataSet.Purchases.Columns.Contains("TotalPrice"))
                {
                    computerCompanyDBDataSet.Purchases.Columns.Add("TotalPrice", typeof(decimal));
                }

                dataGridViewFull.DataSource = computerCompanyDBDataSet.Purchases;

                // Обновление данных для новых полей
                UpdateTotalColumns();

                // Настройка заголовков столбцов
                SetupDataGridView();

                // Скрытие столбцов
                dataGridViewFull.Columns["SupplierID"].Visible = false;
                dataGridViewFull.Columns["PurchaseID"].Visible = false;
                dataGridViewFull.CellFormatting += DataGridViewFull_CellFormatting;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }

        private void SetupDataGridView()
        {
            // Настройка заголовков столбцов
            dataGridViewFull.Columns["PurchaseDate"].HeaderText = "Дата Закупки";
            dataGridViewFull.Columns["PurchaseReason"].HeaderText = "Причина Закупки";
            dataGridViewFull.Columns["TotalQuantity"].HeaderText = "Общее Количество";
            dataGridViewFull.Columns["TotalPrice"].HeaderText = "Общая Стоимость";

            // Добавление столбца для SupplierName
            if (!dataGridViewFull.Columns.Contains("SupplierName"))
            {
                DataGridViewTextBoxColumn supplierNameColumn = new DataGridViewTextBoxColumn
                {
                    Name = "SupplierName",
                    HeaderText = "Имя Поставщика",
                    ReadOnly = true 
                };
                dataGridViewFull.Columns.Add(supplierNameColumn);
            }

            dataGridViewFull.Columns["SupplierName"].DisplayIndex = 1;

            dataGridViewFull.Columns["PurchaseDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewFull.Columns["PurchaseReason"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewFull.Columns["TotalQuantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewFull.Columns["TotalPrice"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridViewFull.Refresh();
        }

        private void DataGridViewFull_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewFull.Columns[e.ColumnIndex].Name == "SupplierName")
            {
                var row = dataGridViewFull.Rows[e.RowIndex];

                if (row.Cells["SupplierID"].Value != null && int.TryParse(row.Cells["SupplierID"].Value.ToString(), out int supplierID))
                {
                    DataRow[] foundRows = computerCompanyDBDataSet.Suppliers.Select($"SupplierID = {supplierID}");
                    if (foundRows.Length > 0)
                    {
                        e.Value = foundRows[0]["SupplierName"].ToString();
                        e.FormattingApplied = true;
                    }
                }
            }
        }

        private void UpdateTotalColumns()
        {
            int grandTotalQuantity = 0;
            decimal grandTotalPrice = 0;

            foreach (DataRow purchaseRow in computerCompanyDBDataSet.Purchases.Rows)
            {
                int purchaseId = (int)purchaseRow["PurchaseID"];
                var details = computerCompanyDBDataSet.PurchaseDetails.AsEnumerable()
                    .Where(d => d.Field<int>("PurchaseID") == purchaseId);

                int totalQuantity = details.Sum(d => d.Field<int>("Quantity"));
                decimal totalPrice = details.Sum(d => d.Field<int>("Quantity") * d.Field<decimal>("UnitPrice"));

                purchaseRow["TotalQuantity"] = totalQuantity;
                purchaseRow["TotalPrice"] = totalPrice;

                grandTotalQuantity += totalQuantity;
                grandTotalPrice += totalPrice;
            }
            labelTotals.Text = $"Итого: Количество = {grandTotalQuantity}, Сумма = {grandTotalPrice}";

            DataRowView totalRow = (DataRowView)computerCompanyDBDataSet.Purchases.DefaultView.AddNew();
            totalRow["PurchaseReason"] = "Итого";
            totalRow["TotalQuantity"] = grandTotalQuantity;
            totalRow["TotalPrice"] = grandTotalPrice;
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                MessageBox.Show("Дата начала не может быть больше даты окончания.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateTimePicker1.Value = dateTimePicker2.Value; // Сбрасываем дату начала на дату окончания
            }
        }

        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewFull.SelectedRows.Count > 0 &&
                dataGridViewFull.SelectedRows[0].Index < dataGridViewFull.Rows.Count - 1)
            {
                int selectedPurchaseId = (int)dataGridViewFull.SelectedRows[0].Cells["PurchaseID"].Value;

                // Очистка ListBox
                listBoxItems.Items.Clear();

                // Получение деталей закупки
                var childItems = computerCompanyDBDataSet.PurchaseDetails.AsEnumerable()
                    .Where(row => row.Field<int>("PurchaseID") == selectedPurchaseId);

                decimal totalCost = 0;
                foreach (var item in childItems)
                {
                    int componentId = item.Field<int>("ComponentID");
                    int quantity = item.Field<int>("Quantity");
                    decimal unitPrice = item.Field<decimal>("UnitPrice");
                    decimal itemTotal = quantity * unitPrice;

                    // Получение имени компонента
                    var componentRow = computerCompanyDBDataSet.Components.AsEnumerable()
                        .FirstOrDefault(c => c.Field<int>("ComponentID") == componentId);

                    string componentName = componentRow?.Field<string>("ComponentName") ?? "Неизвестный компонент";

                    // Получение CategoryID
                    int categoryId = componentRow?.Field<int>("CategoryID") ?? 0;

                    // Получение имени категории
                    string categoryName = computerCompanyDBDataSet.Categories.AsEnumerable()
                        .FirstOrDefault(c => c.Field<int>("CategoryID") == categoryId)?.Field<string>("CategoryName") ?? "Неизвестная категория";

                    // Добавление информации в ListBox
                    listBoxItems.Items.Add($"Компонент: {componentName}, Категория: {categoryName}, Количество: {quantity}, Цена: {unitPrice:C}, Общая стоимость: {itemTotal:C}");
                    totalCost += itemTotal;
                }

                // Показ общей стоимости в последней строке ListBox
                listBoxItems.Items.Add($"Общая стоимость товаров: {totalCost:C}");
            }
            else
            {
                listBoxItems.Items.Clear();
            }
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            // Сохраняем выбранного поставщика перед фильтрацией
            int selectedSupplier = comboBoxSupplier.SelectedIndex;

            computerCompanyDBDataSet.Purchases.RejectChanges();
            RefreshData();

            comboBoxSupplier.SelectedIndex = selectedSupplier; // Восстанавливаем выбранного поставщика
            string filter = "";


            // Проверяем состояние CheckBox
            if (!checkBoxAllSuppliers.Checked)
            {
                int supplierId = (int)((DataRowView)comboBoxSupplier.SelectedItem)["SupplierID"];
                filter += $"SupplierID = {supplierId}";
            }

            // Проверяем состояние CheckBox для дат
            if (!checkBoxAllTime.Checked)
            {
                if (dateTimePicker1.Value != null && dateTimePicker2.Value != null)
                {
                    if (!string.IsNullOrEmpty(filter))
                    {
                        filter += " AND ";
                    }
                    filter += $"PurchaseDate >= '{dateTimePicker1.Value:yyyy-MM-dd}' AND PurchaseDate <= '{dateTimePicker2.Value:yyyy-MM-dd}'";
                }
            }

            try
            {
                DataView view = new DataView(computerCompanyDBDataSet.Purchases);

                if (!string.IsNullOrWhiteSpace(filter))
                {
                    view.RowFilter = filter;
                }

                dataGridViewFull.DataSource = null; // Обновляем DataGridView
                dataGridViewFull.DataSource = view;

                // Добавление столбца SupplierName в DataGridView
                if (!dataGridViewFull.Columns.Contains("SupplierName"))
                {
                    DataGridViewTextBoxColumn supplierNameColumn = new DataGridViewTextBoxColumn
                    {
                        Name = "SupplierName",
                        HeaderText = "Имя Поставщика",
                        ReadOnly = true // Только для чтения
                    };
                    dataGridViewFull.Columns.Add(supplierNameColumn);
                }

                dataGridViewFull.Columns["SupplierName"].DisplayIndex = 1;

                dataGridViewFull.Columns["PurchaseID"].Visible = false; 
                dataGridViewFull.Columns["SupplierID"].Visible = false;
                dataGridViewFull.Columns["SupplierName"].Visible = checkBoxAllSuppliers.Checked;

                // Настройка заголовков столбцов
                dataGridViewFull.Columns["PurchaseDate"].HeaderText = "Дата Закупки";
                dataGridViewFull.Columns["PurchaseReason"].HeaderText = "Причина Закупки";
                dataGridViewFull.Columns["TotalQuantity"].HeaderText = "Общее Количество";
                dataGridViewFull.Columns["TotalPrice"].HeaderText = "Общая Стоимость";

                dataGridViewFull.Columns["PurchaseDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridViewFull.Columns["PurchaseReason"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridViewFull.Columns["TotalQuantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridViewFull.Columns["TotalPrice"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                int grandTotalQuantity = 0;
                decimal grandTotalPrice = 0;

                foreach (DataRowView purchaseRow in view)
                {
                    int purchaseId = (int)purchaseRow["PurchaseID"];
                    var details = computerCompanyDBDataSet.PurchaseDetails.AsEnumerable()
                        .Where(d => d.Field<int>("PurchaseID") == purchaseId);

                    int totalQuantity = details.Sum(d => d.Field<int>("Quantity"));
                    decimal totalPrice = details.Sum(d => d.Field<int>("Quantity") * d.Field<decimal>("UnitPrice"));

                    purchaseRow["TotalQuantity"] = totalQuantity;
                    purchaseRow["TotalPrice"] = totalPrice;

                    grandTotalQuantity += totalQuantity;
                    grandTotalPrice += totalPrice;
                }
                labelTotals.Text = $"Итого: Количество = {grandTotalQuantity}, Сумма = {grandTotalPrice}";

                // Проверка на наличие хотя бы одной строки перед добавлением итоговой строки
                if (view.Count > 0) 
                {
                    // Добавление итоговой строки
                    DataRowView totalRow = view.AddNew();
                    totalRow["PurchaseReason"] = "Итого";
                    totalRow["TotalQuantity"] = grandTotalQuantity;
                    totalRow["TotalPrice"] = grandTotalPrice;
                }

                dataGridViewFull.Refresh();
                listBoxItems.Items.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadData(); 
        }

        private void checkBoxAllSuppliers_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxSupplier.Enabled = !checkBoxAllSuppliers.Checked;
        }

        private void checkBoxAllTime_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = !checkBoxAllTime.Checked;
            dateTimePicker2.Enabled = !checkBoxAllTime.Checked;
        }

        private void ShowForm(bool reportFlag)
        {
            int? supplierId = null;
            string supplierName = null;
            DateTime? startDate = null;
            DateTime? endDate = null;

            if (!checkBoxAllSuppliers.Checked)
            {
                if (comboBoxSupplier.SelectedItem != null)
                {
                    supplierId = (int)((DataRowView)comboBoxSupplier.SelectedItem)["SupplierID"];
                    supplierName = ((DataRowView)comboBoxSupplier.SelectedItem)["SupplierName"].ToString();
                }
            }
            if (!checkBoxAllTime.Checked)
            {
                startDate = dateTimePicker1.Value;
                endDate = dateTimePicker2.Value;
            }

            if (reportForm == null || reportForm.IsDisposed)
            {
                reportForm = new ReportForm(startDate, endDate, supplierId, supplierName, reportFlag); 
                reportForm.FormClosed += (s, args) => reportForm = null;
                reportForm.ShowDialog(this);
            }
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            ShowForm(true);
        }

        private void buttonFullReport_Click(object sender, EventArgs e)
        {
            ShowForm(false);
        }

        private void toolStripButtonPurchases_Click(object sender, EventArgs e)
        {
            purchasesForm = new PurchasesForm();
            purchasesForm.ShowDialog();
        }

        private void toolStripButtonPurchaseDetails_Click(object sender, EventArgs e)
        {
            purhaseDetailsForm = new PurchaseDetailsForm();
            purhaseDetailsForm.ShowDialog();
        }

        private void toolStripButtonSuppliers_Click(object sender, EventArgs e)
        {
            suppliersForm = new SuppliersForm(true);
            suppliersForm.ShowDialog(this);
        }

        private void toolStripButtonComponents_Click(object sender, EventArgs e)
        {
            componentsForm = new ComponentsForm();
            componentsForm.ShowDialog();
        }

        private void toolStripButtonCategories_Click(object sender, EventArgs e)
        {
            categoriesForm = new CategoriesForm();
            categoriesForm.ShowDialog();
        }
    }
}
