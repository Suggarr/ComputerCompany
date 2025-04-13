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

        private void SaveCategoriesData()
        {
            try
            {
                this.Validate();
                this.categoriesBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.computerCompanyDBDataSet);

                MessageBox.Show("Данные успешно сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void categoriesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            SaveCategoriesData();
        }

        private void CategoriesForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "computerCompanyDBDataSet.Categories". При необходимости она может быть перемещена или удалена.
            this.categoriesTableAdapter.Fill(this.computerCompanyDBDataSet.Categories);

            // Привязка элементов управления к полям данных
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
            categoriesBindingNavigatorSaveItem_Click(sender, e);
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            computerCompanyDBDataSet.Categories.RejectChanges();
            categoriesDataGridView.Refresh();
        }

        private void CategoriesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (promptOnClose)
            {
                DialogResult result = MessageBox.Show(
                    "Вы хотите обновить список категорий?",
                    "Обновление данных",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    SaveCategoriesData();

                    if (this.Owner is ComponentsForm mainComponents)
                    {
                        if (mainComponents.comboBoxCategoryId.Items.Count > 0)
                        {
                            object prevCategoryId = mainComponents.comboBoxCategoryId.SelectedValue;
                            mainComponents.categoriesTableAdapter.Fill(mainComponents.computerCompanyDBDataSet.Categories);

                            if (prevCategoryId != null && mainComponents.comboBoxCategoryId.Items.Cast<DataRowView>().Any(item => item.Row["CategoryID"].Equals(prevCategoryId)))
                            {
                                mainComponents.comboBoxCategoryId.SelectedValue = prevCategoryId;
                            }
                            else
                            {
                                mainComponents.comboBoxCategoryId.SelectedIndex = 0;
                            }
                        }
                    }
                    else if (this.Owner is AddComponentsForm addComponents)
                    {
                        if (addComponents.comboBoxCategoryId.Items.Count > 0)
                        {
                            object prevCategoryId = addComponents.comboBoxCategoryId.SelectedValue;
                            addComponents.categoriesTableAdapter.Fill(addComponents.computerCompanyDBDataSet.Categories);

                            if (prevCategoryId != null && addComponents.comboBoxCategoryId.Items.Cast<DataRowView>().Any(item => item.Row["CategoryID"].Equals(prevCategoryId)))
                            {
                                addComponents.comboBoxCategoryId.SelectedValue = prevCategoryId;
                            }
                            else
                            {
                                addComponents.comboBoxCategoryId.SelectedIndex = 0;
                            }
                        }
                    }
                }
            }
        }



        private void textBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                MessageBox.Show($"Поле '{textBox.Tag}' не может быть пустым.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                categoriesBindingSource.CancelEdit();
                e.Cancel = true; // Отменяем событие, чтобы фокус остался на поле
            }
        }
    }
}
