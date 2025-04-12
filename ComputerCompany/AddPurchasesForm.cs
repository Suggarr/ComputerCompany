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
    public partial class AddPurchasesForm : Form
    {
        public int SelectedSupplierId { get; private set; }
        public DateTime PurchaseDate { get; private set; }
        public string PurchaseReason { get; private set; }

        public AddPurchasesForm()
        {
            InitializeComponent();
        }

        private void buttonSuppliers_Click(object sender, EventArgs e)
        {
            SuppliersForm suppliersForm = new SuppliersForm(true); // Включаем MessageBox
            suppliersForm.Owner = this;
            suppliersForm.ShowDialog();
        }

        private void AddPurchaseForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "computerCompanyDBDataSet.Suppliers". При необходимости она может быть перемещена или удалена.
            this.suppliersTableAdapter.Fill(this.computerCompanyDBDataSet.Suppliers);

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // Валидация ввода
            if (comboBoxSupplierId.SelectedValue == null ||
                string.IsNullOrWhiteSpace(textBoxPurchaseReason.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля корректно.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Сохранение данных
            SelectedSupplierId = (int)comboBoxSupplierId.SelectedValue;
            PurchaseDate = dateTimePickerPurchaseDate.Value.Date;
            PurchaseReason = textBoxPurchaseReason.Text;

            // Закрытие формы
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
