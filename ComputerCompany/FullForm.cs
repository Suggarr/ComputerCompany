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
    public partial class FullForm : Form
    {
        private ReportForm reportForm;
        public FullForm()
        {
            InitializeComponent();
           
        }

        private void LoadData()
        {
            try
            {
                // Заполнение данных с использованием TableAdapter
                this.suppliersTableAdapter.Fill(computerCompanyDBDataSet.Suppliers);
                this.purchasesTableAdapter.Fill(computerCompanyDBDataSet.Purchases);
                this.purchaseDetailsTableAdapter.Fill(computerCompanyDBDataSet.PurchaseDetails);
                this.componentsTableAdapter.Fill(computerCompanyDBDataSet.Components);
                this.categoriesTableAdapter.Fill(computerCompanyDBDataSet.Categories);

                // Добавление вычисляемых столбцов
                // Проверка существования столбцов и добавление их, если необходимо
                if (!computerCompanyDBDataSet.Purchases.Columns.Contains("TotalQuantity"))
                {
                    computerCompanyDBDataSet.Purchases.Columns.Add("TotalQuantity", typeof(int));
                }
                if (!computerCompanyDBDataSet.Purchases.Columns.Contains("TotalPrice"))
                {
                    computerCompanyDBDataSet.Purchases.Columns.Add("TotalPrice", typeof(decimal));
                }
                // Заполнение комбобокса с поставщиками
                comboBoxSupplier.DataSource = computerCompanyDBDataSet.Suppliers;
                comboBoxSupplier.DisplayMember = "SupplierName";
                comboBoxSupplier.ValueMember = "SupplierID";

                // Установка источника данных для DataGridView
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
                    ReadOnly = true // Только для чтения
                };
                dataGridViewFull.Columns.Add(supplierNameColumn);
            }

            // Перемещение столбца SupplierName на вторую позицию (индекс 1)
            dataGridViewFull.Columns["SupplierName"].DisplayIndex = 1;

            // Настройка AutoSizeMode для столбцов
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

            // Добавление итоговой строки
            DataRowView totalRow = (DataRowView)computerCompanyDBDataSet.Purchases.DefaultView.AddNew();
            totalRow["TotalQuantity"] = grandTotalQuantity;
            totalRow["TotalPrice"] = grandTotalPrice;

            // Установка заголовка строки
            int totalRowIndex = computerCompanyDBDataSet.Purchases.Rows.Count; // Индекс итоговой строки
            dataGridViewFull.Rows[totalRowIndex].HeaderCell.Value = "Итого"; // Устанавливаем заголовок
            dataGridViewFull.Rows[totalRowIndex].Cells["PurchaseDate"].Style.ForeColor = Color.White;
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                MessageBox.Show("Дата начала не может быть больше даты окончания.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateTimePicker1.Value = dateTimePicker2.Value; // Сбрасываем дату начала на дату окончания
            }
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
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
            computerCompanyDBDataSet.Purchases.RejectChanges();
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

                // Перемещение столбца SupplierName на вторую позицию
                dataGridViewFull.Columns["SupplierName"].DisplayIndex = 1;

                dataGridViewFull.Columns["PurchaseID"].Visible = false; // Всегда скрываем PurchaseID
                dataGridViewFull.Columns["SupplierID"].Visible = false;
                dataGridViewFull.Columns["SupplierName"].Visible = checkBoxAllSuppliers.Checked;

                // Настройка заголовков столбцов
                dataGridViewFull.Columns["PurchaseDate"].HeaderText = "Дата Закупки";
                dataGridViewFull.Columns["PurchaseReason"].HeaderText = "Причина Закупки";
                dataGridViewFull.Columns["TotalQuantity"].HeaderText = "Общее Количество";
                dataGridViewFull.Columns["TotalPrice"].HeaderText = "Общая Стоимость";

                // Настройка AutoSizeMode для столбцов
                dataGridViewFull.Columns["PurchaseDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridViewFull.Columns["PurchaseReason"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridViewFull.Columns["TotalQuantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridViewFull.Columns["TotalPrice"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                // Обновление новых полей (TotalQuantity и TotalPrice)
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
                if (view.Count > 0) // Если есть хотя бы одна строка в отфильтрованных данных
                {
                    // Добавление итоговой строки
                    DataRowView totalRow = view.AddNew();
                    totalRow["TotalQuantity"] = grandTotalQuantity;
                    totalRow["TotalPrice"] = grandTotalPrice;

                    // Установка заголовка строки
                    int totalRowIndex = view.Count-1; // Индекс итоговой строки
                    dataGridViewFull.Rows[totalRowIndex].HeaderCell.Value = "Итого"; // Устанавливаем заголовок
                    dataGridViewFull.Rows[totalRowIndex].Cells["PurchaseDate"].Style.ForeColor = Color.White;
                }

                dataGridViewFull.Refresh();
                listBoxItems.Items.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }

        private void FullForm_Load(object sender, EventArgs e)
        {
            LoadData(); // Загрузка данных
        }

        private void checkBoxAllSuppliers_CheckedChanged(object sender, EventArgs e)
        {
            // Блокируем или разблокируем ComboBox в зависимости от состояния CheckBox
            comboBoxSupplier.Enabled = !checkBoxAllSuppliers.Checked;
        }

        private void checkBoxAllTime_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = !checkBoxAllTime.Checked;
            dateTimePicker2.Enabled = !checkBoxAllTime.Checked;
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            int? supplierId = null;
            DateTime? startDate = null;
            DateTime? endDate = null;

            // Получение выбранного SupplierID из ComboBox
            if (!checkBoxAllSuppliers.Checked)
            {
                if (comboBoxSupplier.SelectedItem != null)
                {
                    supplierId = (int)((DataRowView)comboBoxSupplier.SelectedItem)["SupplierID"];
                }
            }
            if (!checkBoxAllTime.Checked)
            {
                startDate = dateTimePicker1.Value;
                endDate = dateTimePicker2.Value;
            }
            ShowForm(startDate, endDate, supplierId); // вызываем окно с датами
        }

        private void ShowForm(DateTime? start, DateTime? end, int? supplierId)
        {
            if (reportForm == null || reportForm.IsDisposed)
            {
                reportForm = new ReportForm(start, end, supplierId); // Передаем даты в конструктор
                reportForm.FormClosed += (s, args) => reportForm = null;
                reportForm.ShowDialog(this);
            }
        }

    }
}

//using Microsoft.Reporting.WinForms;
//using System;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Runtime.InteropServices.ComTypes;
//using System.Security.Cryptography;
//using System.Windows.Forms;

//namespace ComputerCompany
//{
//    public partial class FullForm : Form
//    {
//        private SqlConnection connection;
//        private DataSet dataSet;

//        public FullForm()
//        {
//            InitializeComponent();
//            string connectionString = "Data Source=LAPTOP-6HNOPOT2;Initial Catalog=ComputerCompanyDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
//            connection = new SqlConnection(connectionString);
//            LoadData();
//        }

//        private void LoadData()
//        {
//            dataSet = new DataSet();

//            try
//            {
//                connection.Open();

//                // Загрузка данных о поставщиках
//                string commandSuppliers = "SELECT SupplierID, SupplierName FROM Suppliers";
//                SqlDataAdapter adapterSuppliers = new SqlDataAdapter(commandSuppliers, connection);
//                adapterSuppliers.Fill(dataSet, "Suppliers");

//                // Загрузка данных о покупках
//                string commandPurchases = "SELECT PurchaseID, PurchaseDate, SupplierID, PurchaseReason FROM Purchases";
//                SqlDataAdapter adapterPurchases = new SqlDataAdapter(commandPurchases, connection);
//                adapterPurchases.Fill(dataSet, "Purchases");

//                // Загрузка данных о деталях покупок
//                string commandPurchaseDetails = "SELECT PurchaseID, ComponentID, Quantity, UnitPrice FROM PurchaseDetails";
//                SqlDataAdapter adapterPurchaseDetails = new SqlDataAdapter(commandPurchaseDetails, connection);
//                adapterPurchaseDetails.Fill(dataSet, "PurchaseDetails");

//                // Загрузка данных о компонентах
//                string commandComponents = "SELECT ComponentID, ComponentName, CategoryID FROM Components";
//                SqlDataAdapter adapterComponents = new SqlDataAdapter(commandComponents, connection);
//                adapterComponents.Fill(dataSet, "Components");

//                // Загрузка данных о категориях
//                string commandCategories = "SELECT CategoryID, CategoryName, Description FROM Categories";
//                SqlDataAdapter adapterCategories = new SqlDataAdapter(commandCategories, connection);
//                adapterCategories.Fill(dataSet, "Categories");

//                // Добавление вычисляемых столбцов
//                dataSet.Tables["Purchases"].Columns.Add("TotalQuantity", typeof(int));
//                dataSet.Tables["Purchases"].Columns.Add("TotalPrice", typeof(decimal));

//                // Заполнение комбобокса с поставщиками
//                comboBoxSupplier.DataSource = dataSet.Tables["Suppliers"];
//                comboBoxSupplier.DisplayMember = "SupplierName";
//                comboBoxSupplier.ValueMember = "SupplierID";

//                // Установка источника данных для DataGridView
//                dataGridView1.DataSource = dataSet.Tables["Purchases"];

//                // Настройка заголовков столбцов
//                dataGridView1.Columns["PurchaseDate"].HeaderText = "Дата Закупки";
//                dataGridView1.Columns["PurchaseReason"].HeaderText = "Причина Закупки";
//                dataGridView1.Columns["TotalQuantity"].HeaderText = "Общее Количество";
//                dataGridView1.Columns["TotalPrice"].HeaderText = "Общая Стоимость";

//                // Обновление данных для новых полей
//                UpdateTotalColumns();

//                // Скрытие столбцов
//                dataGridView1.Columns["SupplierID"].Visible = false;
//                dataGridView1.Columns["PurchaseID"].Visible = false;

//                dataGridView1.Columns["PurchaseDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // "Имя поставщика" подстраивается под содержимое
//                dataGridView1.Columns["PurchaseReason"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // Остальные равномерно занимают оставшуюся ширину
//                dataGridView1.Columns["TotalQuantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
//                dataGridView1.Columns["TotalPrice"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
//                dataGridView1.Refresh();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
//            }
//            finally
//            {
//                connection.Close();
//            }
//        }

//        private void UpdateTotalColumns()
//        {
//            foreach (DataRow purchaseRow in dataSet.Tables["Purchases"].Rows)
//            {
//                int purchaseId = (int)purchaseRow["PurchaseID"];
//                var details = dataSet.Tables["PurchaseDetails"].AsEnumerable()
//                    .Where(d => d.Field<int>("PurchaseID") == purchaseId);

//                int totalQuantity = details.Sum(d => d.Field<int>("Quantity"));
//                decimal totalPrice = details.Sum(d => d.Field<int>("Quantity") * d.Field<decimal>("UnitPrice"));

//                purchaseRow["TotalQuantity"] = totalQuantity;
//                purchaseRow["TotalPrice"] = totalPrice;

//            }
//        }

//        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
//        {
//            if (dateTimePicker1.Value > dateTimePicker2.Value)
//            {
//                MessageBox.Show("Дата начала не может быть больше даты окончания.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                dateTimePicker1.Value = dateTimePicker2.Value; // Сбрасываем дату начала на дату окончания
//            }
//        }

//        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
//        {
//            if (dataGridView1.SelectedRows.Count > 0)
//            {
//                int selectedPurchaseId = (int)dataGridView1.SelectedRows[0].Cells["PurchaseID"].Value;

//                // Очистка ListBox
//                listBoxItems.Items.Clear();

//                // Получение деталей закупки
//                var childItems = dataSet.Tables["PurchaseDetails"].AsEnumerable()
//                    .Where(row => row.Field<int>("PurchaseID") == selectedPurchaseId);

//                decimal totalCost = 0;
//                foreach (var item in childItems)
//                {
//                    int componentId = item.Field<int>("ComponentID");
//                    int quantity = item.Field<int>("Quantity");
//                    decimal unitPrice = item.Field<decimal>("UnitPrice");
//                    decimal itemTotal = quantity * unitPrice;

//                    // Получение имени компонента
//                    var componentRow = dataSet.Tables["Components"].AsEnumerable()
//                        .FirstOrDefault(c => c.Field<int>("ComponentID") == componentId);

//                    string componentName = componentRow?.Field<string>("ComponentName") ?? "Неизвестный компонент";

//                    // Получение CategoryID
//                    int categoryId = componentRow?.Field<int>("CategoryID") ?? 0;

//                    // Получение имени категории
//                    string categoryName = dataSet.Tables["Categories"].AsEnumerable()
//                        .FirstOrDefault(c => c.Field<int>("CategoryID") == categoryId)?.Field<string>("CategoryName") ?? "Неизвестная категория";

//                    // Добавление информации в ListBox
//                    listBoxItems.Items.Add($"Компонент: {componentName}, Категория: {categoryName}, Количество: {quantity}, Цена: {unitPrice:C}, Общая стоимость: {itemTotal:C}");
//                    totalCost += itemTotal;
//                }

//                // Показ общей стоимости в последней строке ListBox
//                listBoxItems.Items.Add($"Общая стоимость товаров: {totalCost:C}");
//            }
//        }

//        private void buttonFilter_Click(object sender, EventArgs e)
//        {
//            string filter = "";

//            // Проверяем состояние CheckBox
//            if (!checkBoxAllSuppliers.Checked)
//            {
//                // Проверяем, выбран ли поставщик
//                if (comboBoxSupplier.SelectedItem == null)
//                {
//                    MessageBox.Show("Выберите поставщика.");
//                    return;
//                }

//                int supplierId = (int)((DataRowView)comboBoxSupplier.SelectedItem)["SupplierID"];
//                filter += $"SupplierID = {supplierId}";
//            }


//            // Добавляем условия для дат
//            if (dateTimePicker1.Value != null && dateTimePicker2.Value != null)
//            {
//                if (!string.IsNullOrEmpty(filter))
//                {
//                    filter += " AND ";
//                }
//                filter += $"PurchaseDate >= '{dateTimePicker1.Value:yyyy-MM-dd}' AND PurchaseDate <= '{dateTimePicker2.Value:yyyy-MM-dd}'";
//            }

//            try
//            {
//                DataView view = new DataView(dataSet.Tables["Purchases"]);

//                if (!string.IsNullOrWhiteSpace(filter))
//                {
//                    view.RowFilter = filter;
//                }

//                // Обновляем DataGridView
//                dataGridView1.DataSource = view;

//                // Обновление новых полей (TotalQuantity и TotalPrice)
//                foreach (DataRowView purchaseRow in view)
//                {
//                    int purchaseId = (int)purchaseRow["PurchaseID"];
//                    var details = dataSet.Tables["PurchaseDetails"].AsEnumerable()
//                        .Where(d => d.Field<int>("PurchaseID") == purchaseId);

//                    int totalQuantity = details.Sum(d => d.Field<int>("Quantity"));
//                    decimal totalPrice = details.Sum(d => d.Field<int>("Quantity") * d.Field<decimal>("UnitPrice"));

//                    purchaseRow["TotalQuantity"] = totalQuantity;
//                    purchaseRow["TotalPrice"] = totalPrice;
//                }

//                dataGridView1.Refresh();
//                BindReport();
//            }
//            catch (EvaluateException ex)
//            {
//                MessageBox.Show($"Ошибка фильтрации: {ex.Message}");
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Произошла ошибка: " + ex.Message);
//            }
//        }

//        private void FullForm_Load(object sender, EventArgs e)
//        {
//            LoadData(); // Загрузка данных
//            BindReport();
//        }

//        private void BindReport()
//        {
//            int? supplierId = null;
//            DateTime? startDate = null;
//            DateTime? endDate = null;
//            // Получение выбранного SupplierID из ComboBox
//            if (!checkBoxAllSuppliers.Checked)
//            {
//                if (comboBoxSupplier.SelectedItem != null)
//                {
//                    supplierId = (int)((DataRowView)comboBoxSupplier.SelectedItem)["SupplierID"];
//                }
//            }
//            if (!checkBoxAllTime.Checked)
//            {
//                startDate = dateTimePicker1.Value;
//                endDate = dateTimePicker2.Value;
//            }
//            this.computerCompanyDBDataSet.GetPurchaseDetailsForSuppliers.Reset();
//            // Вызов хранимой процедуры через TableAdapter
//            this.getPurchaseDetailsForSuppliersTableAdapter.Fill(this.computerCompanyDBDataSet.GetPurchaseDetailsForSuppliers, startDate, endDate, supplierId); // Передаем supplierId как параметр

//            // Настройка источника данных для ReportViewer
//            reportViewer1.LocalReport.DataSources.Clear();

//            // Создание источника данных для отчета
//            ReportDataSource rds = new ReportDataSource("PurchaseForSuppliersDataSet",
//                computerCompanyDBDataSet.GetPurchaseDetailsForSuppliers as DataTable);

//            // Добавление источника данных в ReportViewer
//            reportViewer1.LocalReport.DataSources.Add(rds);

//            // Обновление отчета
//            reportViewer1.RefreshReport();
//        }

//        private void checkBoxAllSuppliers_CheckedChanged(object sender, EventArgs e)
//        {
//            // Блокируем или разблокируем ComboBox в зависимости от состояния CheckBox
//            comboBoxSupplier.Enabled = !checkBoxAllSuppliers.Checked;
//        }

//        private void checkBoxAllTime_CheckedChanged(object sender, EventArgs e)
//        {
//            dateTimePicker1.Enabled = !checkBoxAllTime.Checked;
//            dateTimePicker2.Enabled = !checkBoxAllTime.Checked;
//        }
//    }
//}