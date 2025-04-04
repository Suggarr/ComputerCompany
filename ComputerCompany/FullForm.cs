using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace ComputerCompany
{
    public partial class FullForm : Form
    {
        private SqlConnection connection;
        private DataSet dataSet;

        public FullForm()
        {
            InitializeComponent();
            string connectionString = "Data Source=LAPTOP-6HNOPOT2;Initial Catalog=ComputerCompanyDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            connection = new SqlConnection(connectionString);
            LoadData();
        }

        private void LoadData()
        {
            dataSet = new DataSet();

            try
            {
                connection.Open();

                // Загрузка данных о поставщиках
                string commandSuppliers = "SELECT SupplierID, SupplierName FROM Suppliers";
                SqlDataAdapter adapterSuppliers = new SqlDataAdapter(commandSuppliers, connection);
                adapterSuppliers.Fill(dataSet, "Suppliers");

                // Загрузка данных о покупках
                string commandPurchases = "SELECT PurchaseID, PurchaseDate, SupplierID, PurchaseReason FROM Purchases";
                SqlDataAdapter adapterPurchases = new SqlDataAdapter(commandPurchases, connection);
                adapterPurchases.Fill(dataSet, "Purchases");

                // Загрузка данных о деталях покупок
                string commandPurchaseDetails = "SELECT PurchaseID, ComponentID, Quantity, UnitPrice FROM PurchaseDetails";
                SqlDataAdapter adapterPurchaseDetails = new SqlDataAdapter(commandPurchaseDetails, connection);
                adapterPurchaseDetails.Fill(dataSet, "PurchaseDetails");

                // Загрузка данных о компонентах
                string commandComponents = "SELECT ComponentID, ComponentName, CategoryID FROM Components";
                SqlDataAdapter adapterComponents = new SqlDataAdapter(commandComponents, connection);
                adapterComponents.Fill(dataSet, "Components");

                // Загрузка данных о категориях
                string commandCategories = "SELECT CategoryID, CategoryName, Description FROM Categories";
                SqlDataAdapter adapterCategories = new SqlDataAdapter(commandCategories, connection);
                adapterCategories.Fill(dataSet, "Categories");

                // Добавление вычисляемых столбцов
                dataSet.Tables["Purchases"].Columns.Add("TotalQuantity", typeof(int));
                dataSet.Tables["Purchases"].Columns.Add("TotalPrice", typeof(decimal));

                // Заполнение комбобокса с поставщиками
                comboBoxSupplier.DataSource = dataSet.Tables["Suppliers"];
                comboBoxSupplier.DisplayMember = "SupplierName";
                comboBoxSupplier.ValueMember = "SupplierID";

                // Установка источника данных для DataGridView
                dataGridView1.DataSource = dataSet.Tables["Purchases"];

                // Настройка заголовков столбцов
                dataGridView1.Columns["PurchaseDate"].HeaderText = "Дата Закупки";
                dataGridView1.Columns["PurchaseReason"].HeaderText = "Причина Закупки";
                dataGridView1.Columns["TotalQuantity"].HeaderText = "Общее Количество";
                dataGridView1.Columns["TotalPrice"].HeaderText = "Общая Стоимость";

                // Обновление данных для новых полей
                UpdateTotalColumns();

                // Скрытие столбцов
                dataGridView1.Columns["SupplierID"].Visible = false;
                dataGridView1.Columns["PurchaseID"].Visible = false;

                dataGridView1.Columns["PurchaseDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // "Имя поставщика" подстраивается под содержимое
                dataGridView1.Columns["PurchaseReason"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // Остальные равномерно занимают оставшуюся ширину
                dataGridView1.Columns["TotalQuantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns["TotalPrice"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void UpdateTotalColumns()
        {
            foreach (DataRow purchaseRow in dataSet.Tables["Purchases"].Rows)
            {
                int purchaseId = (int)purchaseRow["PurchaseID"];
                var details = dataSet.Tables["PurchaseDetails"].AsEnumerable()
                    .Where(d => d.Field<int>("PurchaseID") == purchaseId);

                int totalQuantity = details.Sum(d => d.Field<int>("Quantity"));
                decimal totalPrice = details.Sum(d => d.Field<int>("Quantity") * d.Field<decimal>("UnitPrice"));

                purchaseRow["TotalQuantity"] = totalQuantity;
                purchaseRow["TotalPrice"] = totalPrice;

            }
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
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedPurchaseId = (int)dataGridView1.SelectedRows[0].Cells["PurchaseID"].Value;

                // Очистка ListBox
                listBoxItems.Items.Clear();

                // Получение деталей закупки
                var childItems = dataSet.Tables["PurchaseDetails"].AsEnumerable()
                    .Where(row => row.Field<int>("PurchaseID") == selectedPurchaseId);

                decimal totalCost = 0;
                foreach (var item in childItems)
                {
                    int componentId = item.Field<int>("ComponentID");
                    int quantity = item.Field<int>("Quantity");
                    decimal unitPrice = item.Field<decimal>("UnitPrice");
                    decimal itemTotal = quantity * unitPrice;

                    // Получение имени компонента
                    var componentRow = dataSet.Tables["Components"].AsEnumerable()
                        .FirstOrDefault(c => c.Field<int>("ComponentID") == componentId);

                    string componentName = componentRow?.Field<string>("ComponentName") ?? "Неизвестный компонент";

                    // Получение CategoryID
                    int categoryId = componentRow?.Field<int>("CategoryID") ?? 0;

                    // Получение имени категории
                    string categoryName = dataSet.Tables["Categories"].AsEnumerable()
                        .FirstOrDefault(c => c.Field<int>("CategoryID") == categoryId)?.Field<string>("CategoryName") ?? "Неизвестная категория";

                    // Добавление информации в ListBox
                    listBoxItems.Items.Add($"Компонент: {componentName}, Категория: {categoryName}, Количество: {quantity}, Цена: {unitPrice:C}, Общая стоимость: {itemTotal:C}");
                    totalCost += itemTotal;
                }

                // Показ общей стоимости в последней строке ListBox
                listBoxItems.Items.Add($"Общая стоимость товаров: {totalCost:C}");
            }
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            string filter = "";

            // Проверяем состояние CheckBox
            if (!checkBoxAllSuppliers.Checked)
            {
                // Проверяем, выбран ли поставщик
                if (comboBoxSupplier.SelectedItem == null)
                {
                    MessageBox.Show("Выберите поставщика.");
                    return;
                }

                int supplierId = (int)((DataRowView)comboBoxSupplier.SelectedItem)["SupplierID"];
                filter += $"SupplierID = {supplierId}";
            }


            // Добавляем условия для дат
            if (dateTimePicker1.Value != null && dateTimePicker2.Value != null)
            {
                if (!string.IsNullOrEmpty(filter))
                {
                    filter += " AND ";
                }
                filter += $"PurchaseDate >= '{dateTimePicker1.Value:yyyy-MM-dd}' AND PurchaseDate <= '{dateTimePicker2.Value:yyyy-MM-dd}'";
            }

            try
            {
                DataView view = new DataView(dataSet.Tables["Purchases"]);

                if (!string.IsNullOrWhiteSpace(filter))
                {
                    view.RowFilter = filter;
                }

                // Обновляем DataGridView
                dataGridView1.DataSource = view;

                // Обновление новых полей (TotalQuantity и TotalPrice)
                foreach (DataRowView purchaseRow in view)
                {
                    int purchaseId = (int)purchaseRow["PurchaseID"];
                    var details = dataSet.Tables["PurchaseDetails"].AsEnumerable()
                        .Where(d => d.Field<int>("PurchaseID") == purchaseId);

                    int totalQuantity = details.Sum(d => d.Field<int>("Quantity"));
                    decimal totalPrice = details.Sum(d => d.Field<int>("Quantity") * d.Field<decimal>("UnitPrice"));

                    purchaseRow["TotalQuantity"] = totalQuantity;
                    purchaseRow["TotalPrice"] = totalPrice;
                }

                dataGridView1.Refresh();
            }
            catch (EvaluateException ex)
            {
                MessageBox.Show($"Ошибка фильтрации: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }

        private void checkBoxAllSuppliers_CheckedChanged(object sender, EventArgs e)
        {
            // Блокируем или разблокируем ComboBox в зависимости от состояния CheckBox
            comboBoxSupplier.Enabled = !checkBoxAllSuppliers.Checked;
        }
    }
}