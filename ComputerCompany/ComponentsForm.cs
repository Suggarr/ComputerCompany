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
    public partial class ComponentsForm : Form
    {
        private AddComponentsForm addComponentsForm;
        private bool promptOnClose; // Флаг для показа MessageBox
        public ComponentsForm(bool promptOnClose = false)
        {
            InitializeComponent();
            this.promptOnClose = promptOnClose;
        }

        private void SaveComponentsData()
        {
            try
            {
                this.Validate();
                this.componentsBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.computerCompanyDBDataSet);

                MessageBox.Show("Данные успешно сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void componentsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            SaveComponentsData();
        }

        private void ComponentsForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "computerCompanyDBDataSet.Categories". При необходимости она может быть перемещена или удалена.
            this.categoriesTableAdapter.Fill(this.computerCompanyDBDataSet.Categories);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "computerCompanyDBDataSet.Components". При необходимости она может быть перемещена или удалена.
            this.componentsTableAdapter.Fill(this.computerCompanyDBDataSet.Components);

            // Привязка элементов управления к полям данных
            textBoxComponentName.DataBindings.Add("Text", fKComponentCateg6EF57B66BindingSource, "ComponentName", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxPrice.DataBindings.Add("Text", fKComponentCateg6EF57B66BindingSource, "Price", true, DataSourceUpdateMode.OnPropertyChanged);

            // Удаляем все колонки перед добавлением новых
            componentsDataGridView.Columns.Clear();
            componentsDataGridView.AutoGenerateColumns = false;

            // Добавляем оригинальный (скрытый) столбец CategoryID
            DataGridViewTextBoxColumn hiddenCategoryColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CategoryID",
                Name = "CategoryID"
            };
            componentsDataGridView.Columns.Add(hiddenCategoryColumn);
            hiddenCategoryColumn.Visible = false;

            componentsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ComponentName",
                HeaderText = "Название комплектующего"
            });

            componentsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Price",
                HeaderText = "Цена"
            });

            DataGridViewTextBoxColumn categoryNameColumn = new DataGridViewTextBoxColumn
            {
                Name = "CategoryName",
                HeaderText = "Категория",
                ReadOnly = true // Только для чтения
            };
            componentsDataGridView.Columns.Add(categoryNameColumn);
            categoryNameColumn.Visible = false;

            componentsDataGridView.CellFormatting += ComponentsDataGridView_CellFormatting;
        }

        private void btFirst_Click(object sender, EventArgs e)
        {
            fKComponentCateg6EF57B66BindingSource.MoveFirst();
        }

        private void btLast_Click(object sender, EventArgs e)
        {
            fKComponentCateg6EF57B66BindingSource.MoveLast();
        }

        private void btPrevious_Click(object sender, EventArgs e)
        {
            fKComponentCateg6EF57B66BindingSource.MovePrevious();
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            fKComponentCateg6EF57B66BindingSource.MoveNext();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            addComponentsForm = new AddComponentsForm();
            if (addComponentsForm.ShowDialog() == DialogResult.OK)
            {
                string componentName = addComponentsForm.ComponentName;
                decimal price = addComponentsForm.Price;
                int categoryId = addComponentsForm.SelectedCategoryId;

                DataRow newRow = computerCompanyDBDataSet.Components.NewRow();
                newRow["ComponentName"] = componentName;
                newRow["Price"] = price;
                newRow["CategoryID"] = categoryId;
                computerCompanyDBDataSet.Components.Rows.Add(newRow);

                componentsBindingSource.ResetBindings(false);

                comboBoxCategoryId.SelectedValue = categoryId;
            }
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            fKComponentCateg6EF57B66BindingSource.RemoveCurrent();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            SaveComponentsData();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            computerCompanyDBDataSet.Components.RejectChanges();
            componentsDataGridView.Refresh();
        }

        private void ComponentsDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (componentsDataGridView.Columns[e.ColumnIndex].Name == "CategoryName")
            {
                var row = componentsDataGridView.Rows[e.RowIndex];

                if (row.Cells["CategoryID"].Value != null && int.TryParse(row.Cells["CategoryID"].Value.ToString(), out int categoryID))
                {
                    DataRow[] foundRows = computerCompanyDBDataSet.Categories.Select($"CategoryID = {categoryID}");
                    if (foundRows.Length > 0)
                    {
                        e.Value = foundRows[0]["CategoryName"].ToString();
                        e.FormattingApplied = true;
                    }
                }
            }
        }

        private void ComponentsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (promptOnClose)
            {
                DialogResult result = MessageBox.Show(
                    "Вы хотите обновить список компонентов?",
                    "Обновление данных",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    SaveComponentsData();

                    if (this.Owner is PurchaseDetailsForm main)
                    {
                        if (main.comboBoxComponentId.Items.Count > 0)
                        {
                            object prevComponentId = main.comboBoxComponentId.SelectedValue;
                            main.componentsTableAdapter.Fill(main.computerCompanyDBDataSet.Components);

                            if (prevComponentId != null && main.comboBoxComponentId.Items.Cast<DataRowView>().Any(item => item.Row["ComponentID"].Equals(prevComponentId)))
                            {
                                main.comboBoxComponentId.SelectedValue = prevComponentId;
                            }
                            else
                            {
                                main.comboBoxComponentId.SelectedIndex = 0;
                            }
                        }
                    }
                    else if (this.Owner is AddPurchaseDetailsForm addPurchaseDetails)
                    {
                        if (addPurchaseDetails.comboBoxComponentId.Items.Count > 0)
                        {
                            object prevComponentId = addPurchaseDetails.comboBoxComponentId.SelectedValue;
                            addPurchaseDetails.componentsTableAdapter.Fill(addPurchaseDetails.computerCompanyDBDataSet.Components);

                            if (prevComponentId != null && addPurchaseDetails.comboBoxComponentId.Items.Cast<DataRowView>().Any(item => item.Row["ComponentID"].Equals(prevComponentId)))
                            {
                                addPurchaseDetails.comboBoxComponentId.SelectedValue = prevComponentId;
                            }
                            else
                            {
                                addPurchaseDetails.comboBoxComponentId.SelectedIndex = 0;
                            }
                        }
                    }
                }
            }
        }



        private void buttonCategories_Click(object sender, EventArgs e)
        {
            CategoriesForm categoriesForm = new CategoriesForm(true); // Включаем MessageBox
            categoriesForm.Owner = this;
            categoriesForm.ShowDialog();
        }

        private void textBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox.Tag.ToString() == "Название комплектующего")
            {
                // Валидация для названия
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    MessageBox.Show($"Поле '{textBox.Tag}' не может быть пустым.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    fKComponentCateg6EF57B66BindingSource.CancelEdit();
                    e.Cancel = true;
                }
            }
            else if (textBox.Tag.ToString() == "Цена")
            {
                // Валидация для цены
                if (!decimal.TryParse(textBox.Text, out decimal price) || price <= 0)
                {
                    MessageBox.Show($"Поле '{textBox.Tag}' должно содержать положительное число.", "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    fKComponentCateg6EF57B66BindingSource.CancelEdit();
                    e.Cancel = true; 
                }
            }
        }
    }
}
