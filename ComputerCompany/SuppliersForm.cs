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
    public partial class SuppliersForm : Form
    {
        private AddSuppliersForm addSuppliersForm;
        private bool promptOnClose; // Флаг для показа MessageBox
        public SuppliersForm(bool promptOnClose = false) // По умолчанию false
        {
            InitializeComponent();
            this.promptOnClose = promptOnClose;
        }

        private void suppliersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.suppliersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.computerCompanyDBDataSet);

        }

        private void SuppliersForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "computerCompanyDBDataSet.Suppliers". При необходимости она может быть перемещена или удалена.
            this.suppliersTableAdapter.Fill(this.computerCompanyDBDataSet.Suppliers);
            suppliersBindingSource.DataSource = computerCompanyDBDataSet.Suppliers;

            // Привязка элементов управления к полям данных
            //textBoxSupplierId.DataBindings.Add("Text", suppliersBindingSource, "SupplierID", true, DataSourceUpdateMode.Never);
            textBoxSupplierName.DataBindings.Add("Text", suppliersBindingSource, "SupplierName", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxContactInfo.DataBindings.Add("Text", suppliersBindingSource, "ContactInfo", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxAddress.DataBindings.Add("Text", suppliersBindingSource, "Address", true, DataSourceUpdateMode.OnPropertyChanged);

            suppliersDataGridView.Columns[0].Visible = false;
            suppliersDataGridView.Columns[1].HeaderText = "Имя поставщика";
            suppliersDataGridView.Columns[2].HeaderText = "Контакты";
            suppliersDataGridView.Columns[3].HeaderText = "Адрес";
            suppliersDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // Столбец "Имя поставщика" подстраивается под содержимое
            suppliersDataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Остальные заполняют оставшееся пространство
            suppliersDataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void btFirst_Click(object sender, EventArgs e)
        {
            suppliersBindingSource.MoveFirst();
        }

        private void btLast_Click(object sender, EventArgs e)
        {
            suppliersBindingSource.MoveLast();
        }

        private void btPrevious_Click(object sender, EventArgs e)
        {
            suppliersBindingSource.MovePrevious();
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            suppliersBindingSource.MoveNext();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            addSuppliersForm = new AddSuppliersForm();
            if (addSuppliersForm.ShowDialog() == DialogResult.OK)
            {
                // Получение данных из формы
                string supplierName = addSuppliersForm.SupplierName;
                string contacts = addSuppliersForm.Contacts;
                string address = addSuppliersForm.Address;

                // Добавление новой записи в временную таблицу
                DataRow newRow = computerCompanyDBDataSet.Suppliers.NewRow();
                newRow["SupplierName"] = supplierName;
                newRow["ContactInfo"] = contacts;
                newRow["Address"] = address;
                computerCompanyDBDataSet.Suppliers.Rows.Add(newRow);

                // Обновление привязки данных
                suppliersBindingSource.ResetBindings(false);
            }
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            suppliersBindingSource.RemoveCurrent();
        }


        private void btSave_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.suppliersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.computerCompanyDBDataSet);
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            computerCompanyDBDataSet.Suppliers.RejectChanges();
        }

        private void SuppliersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (promptOnClose)
            {
                DialogResult result = MessageBox.Show(
                    "Вы хотите обновить список поставщиков?",
                    "Обновление данных",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    this.Validate();
                    this.suppliersBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.computerCompanyDBDataSet);

                    if (this.Owner is PurchasesForm purchaseForm)
                    {
                        if (purchaseForm.comboBoxSupplierId.Items.Count > 0)
                        {
                            object prevSupplierId = purchaseForm.comboBoxSupplierId.SelectedValue;
                            purchaseForm.suppliersTableAdapter.Fill(purchaseForm.computerCompanyDBDataSet.Suppliers);

                            if (prevSupplierId != null && purchaseForm.comboBoxSupplierId.Items.Contains(prevSupplierId))
                            {
                                purchaseForm.comboBoxSupplierId.SelectedValue = prevSupplierId;
                            }
                            else
                            {
                                purchaseForm.comboBoxSupplierId.SelectedIndex = 0;
                            }
                        }
                    }
                    else if (this.Owner is AddPurchasesForm addPurchase)
                    {
                        if (addPurchase.comboBoxSupplierId.Items.Count > 0)
                        {
                            object prevSupplierId = addPurchase.comboBoxSupplierId.SelectedValue;
                            addPurchase.suppliersTableAdapter.Fill(addPurchase.computerCompanyDBDataSet.Suppliers);

                            if (prevSupplierId != null && addPurchase.comboBoxSupplierId.Items.Contains(prevSupplierId))
                            {
                                addPurchase.comboBoxSupplierId.SelectedValue = prevSupplierId;
                            }
                            else
                            {
                                addPurchase.comboBoxSupplierId.SelectedIndex = 0;
                            }
                        }
                    }
                    else if (this.Owner is MainForm mainForm)
                    {
                        if (mainForm.comboBoxSupplier.Items.Count > 0)
                        {
                            object prevSupplierId = mainForm.comboBoxSupplier.SelectedValue;
                            mainForm.suppliersTableAdapter.Fill(mainForm.computerCompanyDBDataSet.Suppliers);

                            if (prevSupplierId != null && mainForm.comboBoxSupplier.Items.Contains(prevSupplierId))
                            {
                                mainForm.comboBoxSupplier.SelectedValue = prevSupplierId;
                            }
                            else
                            {
                                mainForm.comboBoxSupplier.SelectedIndex = 0;
                            }
                        }
                    }
                }
            }
        }


        private void textBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox.Tag.ToString() == "Имя поставщика" ||
                textBox.Tag.ToString() == "Контакты" ||
                textBox.Tag.ToString() == "Адрес")
            {
                // Проверка на пустое значение
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    MessageBox.Show($"Поле '{textBox.Tag}' не может быть пустым.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    suppliersBindingSource.CancelEdit();
                    e.Cancel = true; // Отменяем событие, чтобы фокус остался на поле
                }
            }
        }
    }
}
