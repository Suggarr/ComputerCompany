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
    public partial class AddComponentsForm : Form
    {
        public int SelectedCategoryId { get; private set; }
        public string ComponentName { get; private set; }
        public decimal Price { get; private set; }

        public AddComponentsForm()
        {
            InitializeComponent();
        }

        private void AddComponentsForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "computerCompanyDBDataSet.Components". При необходимости она может быть перемещена или удалена.
            this.componentsTableAdapter.Fill(this.computerCompanyDBDataSet.Components);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "computerCompanyDBDataSet.Categories". При необходимости она может быть перемещена или удалена.
            this.categoriesTableAdapter.Fill(this.computerCompanyDBDataSet.Categories);

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // Валидация ввода
            if (string.IsNullOrWhiteSpace(textBoxComponentName.Text) ||
                !decimal.TryParse(textBoxPrice.Text, out decimal price) ||
                comboBoxCategoryId.SelectedValue == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля корректно.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Сохранение данных
            SelectedCategoryId = (int)comboBoxCategoryId.SelectedValue;
            ComponentName = textBoxComponentName.Text;
            Price = price;

            // Закрытие формы
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonCategories_Click(object sender, EventArgs e)
        {
            CategoriesForm categoriesForm = new CategoriesForm(true); // Включаем MessageBox
            categoriesForm.Owner = this;
            categoriesForm.ShowDialog();
        }
    }
}
