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
    public partial class CategoriesForm : Form
    {
        private AddCategoriesForm addCategoriesForm;
        private bool promptOnClose; // Флаг для показа MessageBox
        public CategoriesForm(bool promptOnClose = false) // По умолчанию false
        {
            InitializeComponent();
            this.promptOnClose = promptOnClose;
        }

        private void categoriesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.categoriesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.computerCompanyDBDataSet);

        }

        private void CategoriesForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "computerCompanyDBDataSet.Categories". При необходимости она может быть перемещена или удалена.
            this.categoriesTableAdapter.Fill(this.computerCompanyDBDataSet.Categories);
            categoriesBindingSource.DataSource = computerCompanyDBDataSet.Categories;

            // Привязка элементов управления к полям данных
            textBoxCategoryId.DataBindings.Add("Text", categoriesBindingSource, "CategoryID", true, DataSourceUpdateMode.Never);
            textBoxCategoryName.DataBindings.Add("Text", categoriesBindingSource, "CategoryName", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxDescription.DataBindings.Add("Text", categoriesBindingSource, "Description", true, DataSourceUpdateMode.OnPropertyChanged);

            categoriesDataGridView.Columns[0].Visible = false;
            categoriesDataGridView.Columns[1].HeaderText = "Название категории";
            categoriesDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            categoriesDataGridView.Columns[2].HeaderText = "Описание";
            categoriesDataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btFirst_Click(object sender, EventArgs e)
        {
            categoriesBindingSource.MoveFirst();
        }

        private void btLast_Click(object sender, EventArgs e)
        {
            categoriesBindingSource.MoveLast();
        }

        private void btPrevious_Click(object sender, EventArgs e)
        {
            categoriesBindingSource.MovePrevious();
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            categoriesBindingSource.MoveNext();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            addCategoriesForm = new AddCategoriesForm();
            if (addCategoriesForm.ShowDialog() == DialogResult.OK)
            {
                // Получение данных из формы
                string categoryName = addCategoriesForm.CategoryName;
                string description = addCategoriesForm.Description;

                // Добавление новой категории в временную таблицу
                DataRow newRow = computerCompanyDBDataSet.Categories.NewRow();
                newRow["CategoryName"] = categoryName;
                newRow["Description"] = description;
                computerCompanyDBDataSet.Categories.Rows.Add(newRow);

                // Обновление привязки данных
                categoriesBindingSource.ResetBindings(false);
            }
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            categoriesBindingSource.RemoveCurrent();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.categoriesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.computerCompanyDBDataSet);
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            computerCompanyDBDataSet.Categories.RejectChanges();
        }

        private void CategoriesForm_FormClosing(object sender, FormClosingEventArgs e)
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
                    this.categoriesBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.computerCompanyDBDataSet);

                    // Обновляем привязку в родительской форме
                    if (this.Owner is ComponentsForm mainComponents)
                    {
                        mainComponents.comboBoxCategoryId.DataSource = this.computerCompanyDBDataSet.Categories;

                        mainComponents.comboBoxCategoryId.DataSource = mainComponents.categoriesBindingSource; // Связываем заново
                        mainComponents.comboBoxCategoryId.DisplayMember = "CategoryName"; // Устанавливаем DisplayMember
                        mainComponents.comboBoxCategoryId.ValueMember = "CategoryID"; // Устанавливаем ValueMember

                        if (mainComponents.comboBoxCategoryId.Items.Count > 0)
                        {
                            int remInd = mainComponents.comboBoxCategoryId.SelectedIndex;
                            this.categoriesTableAdapter.Fill(this.computerCompanyDBDataSet.Categories);
                            mainComponents.comboBoxCategoryId.SelectedIndex = remInd;
                        }
                    }
                    else if (this.Owner is AddComponentsForm addComponents)
                    {
                        addComponents.comboBoxCategoryId.DataSource = this.computerCompanyDBDataSet.Categories;

                        if (addComponents.comboBoxCategoryId.Items.Count > 0)
                        {
                            int remInd = addComponents.comboBoxCategoryId.SelectedIndex;
                            this.categoriesTableAdapter.Fill(this.computerCompanyDBDataSet.Categories);
                            addComponents.comboBoxCategoryId.SelectedIndex = remInd;
                        }
                    }
                }
            }
        }
    }
}
