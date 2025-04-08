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
            textBoxSupplierId.DataBindings.Add("Text", suppliersBindingSource, "SupplierID", true, DataSourceUpdateMode.Never);
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
            try
            {
                suppliersBindingSource.AddNew();
            }
            catch
            {
                MessageBox.Show("Не можем выполнить данное действие. Закончите редактирование строки которую добавили недавно");
                suppliersBindingSource.CancelEdit();
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

                if (result == DialogResult.Yes && this.Owner is PurchasesForm main)
                {
                    this.Validate();
                    this.suppliersBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.computerCompanyDBDataSet);

                    // Обновляем привязку в родительской форме
                    //main.suppliersBindingSource.ResetBindings(false);
                    main.comboBoxSupplierId.DataSource = this.computerCompanyDBDataSet.Suppliers;

                    if (main.comboBoxSupplierId.Items.Count > 0)
                    {
                        int remInd = main.comboBoxSupplierId.SelectedIndex;
                        this.suppliersTableAdapter.Fill(this.computerCompanyDBDataSet.Suppliers);
                        main.comboBoxSupplierId.SelectedIndex = remInd;
                    }
                }
            }
        }
    }
}
