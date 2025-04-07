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
    public partial class PurchasesForm : Form
    {
        private bool promptOnClose; // Флаг для показа MessageBox
        public PurchasesForm(bool promptOnClose = false) // По умолчанию false
        {
            InitializeComponent();
            this.promptOnClose = promptOnClose;
        }

        private void purchasesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.purchasesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.computerCompanyDBDataSet);

        }

        private void PurchasesForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "computerCompanyDBDataSet.Suppliers". При необходимости она может быть перемещена или удалена.
            this.suppliersTableAdapter.Fill(this.computerCompanyDBDataSet.Suppliers);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "computerCompanyDBDataSet.Suppliers". При необходимости она может быть перемещена или удалена.
            this.suppliersTableAdapter.Fill(this.computerCompanyDBDataSet.Suppliers);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "computerCompanyDBDataSet.Purchases". При необходимости она может быть перемещена или удалена.
            this.purchasesTableAdapter.Fill(this.computerCompanyDBDataSet.Purchases);

            purchasesBindingSource.DataSource = computerCompanyDBDataSet.Purchases;
            suppliersBindingSource.DataSource = computerCompanyDBDataSet.Suppliers;

            // Привязка элементов управления к полям данных
            textBoxPurchaseId.DataBindings.Add("Text", purchasesBindingSource, "PurchaseID", true, DataSourceUpdateMode.Never);
            comboBoxSupplierId.DataBindings.Add("SelectedValue", purchasesBindingSource, "SupplierID", true, DataSourceUpdateMode.OnPropertyChanged);
            dateTimePickerPurchaseDate.DataBindings.Add("Value", purchasesBindingSource, "PurchaseDate", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxPurchaseReason.DataBindings.Add("Text", purchasesBindingSource, "PurchaseReason", true, DataSourceUpdateMode.OnPropertyChanged);

            // Удаляем все колонки перед добавлением новых
            purchasesDataGridView.Columns.Clear();
            purchasesDataGridView.AutoGenerateColumns = false;

            // Добавляем оригинальный (скрытый) столбец SupplierID
            DataGridViewTextBoxColumn hiddenSupplierColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SupplierID",
                Name = "SupplierID"
            };
            purchasesDataGridView.Columns.Add(hiddenSupplierColumn);
            hiddenSupplierColumn.Visible = false;


            DataGridViewTextBoxColumn supplierNameColumn = new DataGridViewTextBoxColumn
            {
                Name = "SupplierName",
                HeaderText = "Имя поставщика",
                ReadOnly = true // Только для чтения
            };
            purchasesDataGridView.Columns.Add(supplierNameColumn);


            DataGridViewTextBoxColumn purchaseDateColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PurchaseDate",
                HeaderText = "Дата покупки"
            };
            purchasesDataGridView.Columns.Add(purchaseDateColumn);

            DataGridViewTextBoxColumn purchaseReasonColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PurchaseReason",
                HeaderText = "Причина закупки"
            };
            purchasesDataGridView.Columns.Add(purchaseReasonColumn);

            supplierNameColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // "Имя поставщика" подстраивается под содержимое
            purchaseDateColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Остальные равномерно занимают оставшуюся ширину
            purchaseReasonColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            purchasesDataGridView.CellFormatting += PurchasesDataGridView_CellFormatting;
        }

        private void PurchasesDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (purchasesDataGridView.Columns[e.ColumnIndex].Name == "SupplierName")
            {
                var row = purchasesDataGridView.Rows[e.RowIndex];

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

        private void btFirst_Click(object sender, EventArgs e)
        {
            purchasesBindingSource.MoveFirst();
        }

        private void btLast_Click(object sender, EventArgs e)
        {
            purchasesBindingSource.MoveLast();
        }

        private void btPrevious_Click(object sender, EventArgs e)
        {
            purchasesBindingSource.MovePrevious();
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            purchasesBindingSource.MoveNext();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            try
            {
                purchasesBindingSource.AddNew();
            }
            catch
            {
                MessageBox.Show("Не можем выполнить добавление новой записи. Отмена добавления прошлой записи(Причина: незаполнены все строки)");
                purchasesBindingSource.CancelEdit();
            }
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            purchasesBindingSource.RemoveCurrent();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.purchasesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.computerCompanyDBDataSet);
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            computerCompanyDBDataSet.Purchases.RejectChanges();
        }
        private void PurchasesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (promptOnClose)
            {
                DialogResult result = MessageBox.Show(
                    "Вы хотите обновить список покупок?",
                    "Обновление данных",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes && this.Owner is PurchaseDetailsForm main)
                {
                    this.Validate();
                    this.purchasesBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.computerCompanyDBDataSet);

                    // Обновляем данные в родительской форме
                    main.purchasesTableAdapter.Fill(main.computerCompanyDBDataSet.Purchases); // Обновляем данные

                    main.comboBoxPurchaseId.DataSource = main.purchasesBindingSource; // Связываем заново
                    main.comboBoxPurchaseId.DisplayMember = "PurchaseID"; // Устанавливаем DisplayMember
                    main.comboBoxPurchaseId.ValueMember = "PurchaseID"; // Устанавливаем ValueMember

                    // Опционально: сбросить выбранный индекс
                    if (main.comboBoxPurchaseId.Items.Count > 0)
                    {
                        int remInd = main.comboBoxPurchaseId.SelectedIndex;
                        this.purchasesTableAdapter.Fill(this.computerCompanyDBDataSet.Purchases);
                        main.comboBoxPurchaseId.SelectedIndex = remInd;
                    }
                }
            }
        }

        private void buttonSuppliers_Click(object sender, EventArgs e)
        {
            SuppliersForm suppliersForm = new SuppliersForm(true); // Включаем MessageBox
            suppliersForm.Owner = this;
            suppliersForm.ShowDialog();
        }

        private void dateTimePickerPurchaseDate_ValueChanged(object sender, EventArgs e)
        {
            // Получаем сегодняшнюю дату
            DateTime today = DateTime.Today;

            // Проверяем, если значение DateTimePicker больше сегодняшней даты
            if (dateTimePickerPurchaseDate.Value > today)
            {
                MessageBox.Show("Выбранная дата не может быть больше сегодняшнего числа.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Устанавливаем значение DateTimePicker на сегодняшнюю дату
                dateTimePickerPurchaseDate.Value = today;
            }
        }
    }
}