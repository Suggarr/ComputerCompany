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
        private AddPurchasesForm addPurchaseForm;
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
            addPurchaseForm = new AddPurchasesForm();
            if (addPurchaseForm.ShowDialog() == DialogResult.OK)
            {
                // Получение данных из формы
                int supplierId = addPurchaseForm.SelectedSupplierId;
                DateTime purchaseDate = addPurchaseForm.PurchaseDate;
                string purchaseReason = addPurchaseForm.PurchaseReason;

                // Добавление новой записи в временную таблицу
                DataRow newRow = computerCompanyDBDataSet.Purchases.NewRow();
                newRow["SupplierId"] = supplierId;
                newRow["PurchaseDate"] = purchaseDate;
                newRow["PurchaseReason"] = purchaseReason;
                computerCompanyDBDataSet.Purchases.Rows.Add(newRow);

                // Обновление привязки данных
                purchasesBindingSource.ResetBindings(false);
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

                if (result == DialogResult.Yes)
                {
                    this.Validate();
                    this.purchasesBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.computerCompanyDBDataSet);

                    if (this.Owner is PurchaseDetailsForm purchaseDetailsForm)
                    {
                        if (purchaseDetailsForm.comboBoxPurchaseId.Items.Count > 0)
                        {
                            // Сохраняем текущий PurchaseID
                            object prevPurchaseId = purchaseDetailsForm.comboBoxPurchaseId.SelectedValue;
                            purchaseDetailsForm.purchasesTableAdapter.Fill(purchaseDetailsForm.computerCompanyDBDataSet.Purchases);

                            // Пытаемся снова выбрать предыдущий PurchaseID
                            if (prevPurchaseId != null && purchaseDetailsForm.comboBoxPurchaseId.Items.Contains(prevPurchaseId))
                            {
                                purchaseDetailsForm.comboBoxPurchaseId.SelectedValue = prevPurchaseId;
                            }
                            else
                            {
                                purchaseDetailsForm.comboBoxPurchaseId.SelectedIndex = 0; 
                            }
                        }
                    }
                    else if (this.Owner is AddPurchaseDetailsForm addPurchaseDetails)
                    {
                        if (addPurchaseDetails.comboBoxPurchaseId.Items.Count > 0)
                        {
                            object prevPurchaseId = addPurchaseDetails.comboBoxPurchaseId.SelectedValue;
                            addPurchaseDetails.purchasesTableAdapter.Fill(addPurchaseDetails.computerCompanyDBDataSet.Purchases);

                            if (prevPurchaseId != null && addPurchaseDetails.comboBoxPurchaseId.Items.Contains(prevPurchaseId))
                            {
                                addPurchaseDetails.comboBoxPurchaseId.SelectedValue = prevPurchaseId;
                            }
                            else
                            {
                                addPurchaseDetails.comboBoxPurchaseId.SelectedIndex = 0;
                            }
                        }
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

        private void textBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                MessageBox.Show($"Поле '{textBox.Tag}' не может быть пустым.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                purchasesBindingSource.CancelEdit();
                e.Cancel = true; // Отменяем событие, чтобы фокус остался на поле
            }
        }
    }
}