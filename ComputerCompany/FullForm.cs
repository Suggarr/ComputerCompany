using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
                string commandPurchaseDetails = "SELECT PurchaseDetailID, PurchaseID, ComponentID, Quantity, UnitPrice FROM PurchaseDetails";
                SqlDataAdapter adapterPurchaseDetails = new SqlDataAdapter(commandPurchaseDetails, connection);
                adapterPurchaseDetails.Fill(dataSet, "PurchaseDetails");

                // Загрузка данных о компонентах
                string commandComponents = "SELECT ComponentID, ComponentName FROM Components";
                SqlDataAdapter adapterComponents = new SqlDataAdapter(commandComponents, connection);
                adapterComponents.Fill(dataSet, "Components");

                // Добавление вычисляемого столбца для общей цены
                DataColumn totalPriceColumn = new DataColumn("TotalPrice", typeof(decimal), "Quantity * UnitPrice");
                dataSet.Tables["PurchaseDetails"].Columns.Add(totalPriceColumn);

                // Заполнение комбобокса с поставщиками
                comboBoxSupplier.DataSource = dataSet.Tables["Suppliers"];
                comboBoxSupplier.DisplayMember = "SupplierName";
                comboBoxSupplier.ValueMember = "SupplierID";

                // Установка источника данных для DataGridView
                dataGridView1.DataSource = dataSet.Tables["Purchases"];
                dataGridView1.SelectionChanged += DataGridView1_SelectionChanged; // Подписка на событие выбора
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

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedPurchaseId = (int)dataGridView1.SelectedRows[0].Cells["PurchaseID"].Value;

                // Очистка ListBox
                listBoxItems.Items.Clear();

                // Получение дочерних элементов
                var childItems = dataSet.Tables["PurchaseDetails"].AsEnumerable()
                    .Where(row => row.Field<int>("PurchaseID") == selectedPurchaseId);

                decimal totalCost = 0;

                foreach (var item in childItems)
                {
                    int componentId = item.Field<int>("ComponentID");
                    int quantity = item.Field<int>("Quantity");
                    decimal unitPrice = item.Field<decimal>("UnitPrice");
                    decimal itemTotal = quantity * unitPrice;

                    // Поиск названия компонента
                    string componentName = dataSet.Tables["Components"].AsEnumerable()
                        .FirstOrDefault(c => c.Field<int>("ComponentID") == componentId)?.Field<string>("ComponentName") ?? "Неизвестный компонент";

                    listBoxItems.Items.Add($"Компонент: {componentName}, Количество: {quantity}, Цена: {unitPrice:C}, Общая стоимость: {itemTotal:C}");
                    totalCost += itemTotal;
                }

                // Показ общей стоимости в последней строке ListBox
                listBoxItems.Items.Add($"Общая стоимость товаров: {totalCost:C}");
            }
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            string filter = "";

            if (comboBoxSupplier.SelectedItem == null)
            {
                MessageBox.Show("Выберите поставщика.");
                return;
            }

            int supplierId = (int)((DataRowView)comboBoxSupplier.SelectedItem)["SupplierID"];
            filter += $"SupplierID = {supplierId}";

            if (dateTimePicker1.Value != null && dateTimePicker2.Value != null)
            {
                filter += $" AND PurchaseDate >= '{dateTimePicker1.Value:yyyy-MM-dd}' AND PurchaseDate <= '{dateTimePicker2.Value:yyyy-MM-dd}'";
            }

            try
            {
                DataView view = new DataView(dataSet.Tables["Purchases"]);

                if (!string.IsNullOrWhiteSpace(filter))
                {
                    view.RowFilter = filter;
                }

                if (view.Count > 0)
                {
                    dataGridView1.DataSource = view;
                    dataGridView1.Refresh();
                }
                else
                {
                    MessageBox.Show("Нет данных для отображения.");
                    dataGridView1.Refresh();
                }
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
    }
}