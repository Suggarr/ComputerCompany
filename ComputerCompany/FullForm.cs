using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ComputerCompany
{
    public partial class FullForm : Form
    {
        private SqlConnection connection;
        private DataSet dataSet; // Новый DataSet

        public FullForm()
        {
            InitializeComponent();
            // Чтение строки подключения из App.config
            string connectionString = ConfigurationManager.ConnectionStrings["ComputerCompany.Properties.Settings.ComputerCompanyDBConnectionString"].ConnectionString;
            connection = new SqlConnection(connectionString);
            LoadData();
        }

        private void LoadData()
        {
            dataSet = new DataSet(); // Инициализация DataSet

            try
            {
                connection.Open();

                // Загрузка данных о поставщиках
                string commandSuppliers = "SELECT SupplierID, SupplierName FROM Suppliers";
                SqlDataAdapter adapterSuppliers = new SqlDataAdapter(commandSuppliers, connection);
                adapterSuppliers.Fill(dataSet, "Suppliers");

                // Проверка наличия столбца SupplierID
                if (!dataSet.Tables["Suppliers"].Columns.Contains("SupplierID"))
                {
                    MessageBox.Show("Столбец SupplierID не найден в таблице Suppliers.");
                    return;
                }

                // Загрузка данных о покупках
                string commandPurchases = "SELECT PurchaseID, PurchaseDate, SupplierID FROM Purchases";
                SqlDataAdapter adapterPurchases = new SqlDataAdapter(commandPurchases, connection);
                adapterPurchases.Fill(dataSet, "Purchases");

                // Загрузка данных о деталях покупок
                string commandPurchaseDetails = "SELECT PurchaseDetailID, PurchaseID, ComponentID, Quantity, UnitPrice FROM PurchaseDetails";
                SqlDataAdapter adapterPurchaseDetails = new SqlDataAdapter(commandPurchaseDetails, connection);
                adapterPurchaseDetails.Fill(dataSet, "PurchaseDetails");

                // Добавление вычисляемого столбца для общей цены
                DataColumn totalPriceColumn = new DataColumn("TotalPrice", typeof(decimal), "Quantity * UnitPrice");
                dataSet.Tables["PurchaseDetails"].Columns.Add(totalPriceColumn);

                // Заполнение комбобокса с поставщиками
                comboBoxSupplier.DataSource = dataSet.Tables["Suppliers"];
                comboBoxSupplier.DisplayMember = "SupplierName";
                comboBoxSupplier.ValueMember = "SupplierID";
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

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            string filter = "";

            // Фильтрация по выбранному поставщику
            if (comboBoxSupplier.SelectedItem != null)
            {
                int supplierId = (int)((DataRowView)comboBoxSupplier.SelectedItem)["SupplierID"];
                filter += $"SupplierID = {supplierId}";
            }

            // Фильтрация по диапазону дат
            if (dateTimePicker1.Value != null && dateTimePicker2.Value != null)
            {
                if (!string.IsNullOrEmpty(filter))
                {
                    filter += " AND ";
                }
                filter += $"PurchaseDate >= '{dateTimePicker1.Value}' AND PurchaseDate <= '{dateTimePicker2.Value}'";
            }

            // Применение фильтра
            try
            {
                // Создание DataView из таблицы Purchases
                DataView view = new DataView(dataSet.Tables["Purchases"]); // использование правильного DataTable

                // Проверка доступных столбцов
                foreach (DataColumn column in view.Table.Columns)
                {
                    Console.WriteLine(column.ColumnName); // Для отладки, выводим имена столбцов
                }

                if (!string.IsNullOrWhiteSpace(filter))
                {
                    view.RowFilter = filter; // Применение фильтра
                }

                // Установка источника данных для DataGridView
                dataGridView1.DataSource = view;
                int num = dataGridView1.Columns.Count;
                // Настройка отображаемых столбцов и заголовков для вычисляемых столбцов
                //dataGridView1.Columns[0].HeaderText = "ID покупки";
                //dataGridView1.Columns[1].HeaderText = "Дата покупки";
                //dataGridView1.Columns[1].HeaderText = "ID поставщика";
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