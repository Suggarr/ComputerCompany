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
            try
            {
                categoriesBindingSource.AddNew();
            }
            catch
            {
                MessageBox.Show("Не можем выполнить добавление новой записи. Отмена добавления прошлой записи(Причина: незаполнены все строки)");
                categoriesBindingSource.CancelEdit();
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

                if (result == DialogResult.Yes && this.Owner is ComponentsForm main)
                {
                    this.Validate();
                    this.categoriesBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.computerCompanyDBDataSet);

                    // Обновляем привязку в родительской форме
                    //main.suppliersBindingSource.ResetBindings(false);
                    main.comboBoxCategoryId.DataSource = this.computerCompanyDBDataSet.Categories;

                    if (main.comboBoxCategoryId.Items.Count > 0)
                    {
                        int remInd = main.comboBoxCategoryId.SelectedIndex;
                        this.categoriesTableAdapter.Fill(this.computerCompanyDBDataSet.Categories);
                        main.comboBoxCategoryId.SelectedIndex = remInd;
                    }
                }
            }
        }
    }
}
