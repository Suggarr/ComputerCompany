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
    public partial class AddPurchaseDetailsForm : Form
    {
        public int SelectedPurchaseId { get; private set; }
        public int SelectedComponentId { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }

        public AddPurchaseDetailsForm()
        {
            InitializeComponent();
        }

        private void buttonPurchases_Click(object sender, EventArgs e)
        {
            PurchasesForm purchasesForm = new PurchasesForm(true); // Включаем MessageBox
            purchasesForm.Owner = this;
            purchasesForm.ShowDialog();
        }

        private void buttonComponents_Click(object sender, EventArgs e)
        {
            ComponentsForm componentsForm = new ComponentsForm(true); // Включаем MessageBox
            componentsForm.Owner = this;
            componentsForm.ShowDialog();
        }

        private void AddPurchaseDetailsForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "computerCompanyDBDataSet.Components". При необходимости она может быть перемещена или удалена.
            this.componentsTableAdapter.Fill(this.computerCompanyDBDataSet.Components);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "computerCompanyDBDataSet.Purchases". При необходимости она может быть перемещена или удалена.
            this.purchasesTableAdapter.Fill(this.computerCompanyDBDataSet.Purchases);

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // Валидация ввода
            if (comboBoxPurchaseId.SelectedValue == null ||
                comboBoxComponentId.SelectedValue == null ||
                !int.TryParse(textBoxQuantity.Text, out int quantity))
            {
                MessageBox.Show("Пожалуйста, заполните все поля корректно.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Сохранение данных
            SelectedPurchaseId = (int)comboBoxPurchaseId.SelectedValue;
            SelectedComponentId = (int)comboBoxComponentId.SelectedValue;
            Quantity = quantity;

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
