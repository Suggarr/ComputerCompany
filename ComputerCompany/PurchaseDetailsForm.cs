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
    public partial class PurchaseDetailsForm : Form
    {
        private CheckForm checkForm;
        //private ReportForm reportForm;
        public PurchaseDetailsForm()
        {
            InitializeComponent();
        }

        private void purchaseDetailsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.purchaseDetailsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.computerCompanyDBDataSet);

        }

        private void PurchaseDetailsForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "computerCompanyDBDataSet.Components". При необходимости она может быть перемещена или удалена.
            this.componentsTableAdapter.Fill(this.computerCompanyDBDataSet.Components);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "computerCompanyDBDataSet.Purchases". При необходимости она может быть перемещена или удалена.
            this.purchasesTableAdapter.Fill(this.computerCompanyDBDataSet.Purchases);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "computerCompanyDBDataSet.PurchaseDetails". При необходимости она может быть перемещена или удалена.
            this.purchaseDetailsTableAdapter.Fill(this.computerCompanyDBDataSet.PurchaseDetails);
            purchaseDetailsBindingSource.DataSource = computerCompanyDBDataSet.PurchaseDetails;

            // Привязка элементов управления к полям данных
            textBoxPurchaseDetailId.DataBindings.Add("Text", fKPurchaseDPurch76969D2EBindingSource, "PurchaseDetailID", true, DataSourceUpdateMode.Never);
            //comboBoxPurchaseId.DataBindings.Add("SelectedValue", purchaseDetailsBindingSource, "PurchaseID", true, DataSourceUpdateMode.OnPropertyChanged);
            comboBoxComponentId.DataBindings.Add("SelectedValue", fKPurchaseDPurch76969D2EBindingSource, "ComponentID", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxQuantity.DataBindings.Add("Text", fKPurchaseDPurch76969D2EBindingSource, "Quantity", true, DataSourceUpdateMode.OnPropertyChanged);
            textBoxUnitPrice.DataBindings.Add("Text", fKPurchaseDPurch76969D2EBindingSource, "UnitPrice", true, DataSourceUpdateMode.OnPropertyChanged);
            // Удаляем все колонки перед добавлением новых
            purchaseDetailsDataGridView.Columns.Clear();
            purchaseDetailsDataGridView.AutoGenerateColumns = false;

            // Добавляем оригинальный (скрытый) столбец ComponentID
            DataGridViewTextBoxColumn hiddenComponentColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ComponentID",
                Name = "ComponentID"
            };
            purchaseDetailsDataGridView.Columns.Add(hiddenComponentColumn);
            hiddenComponentColumn.Visible = false;
            //// Добавляем колонку "Номер покупки" (PurchaseID)
            //purchaseDetailsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            //{
            //    DataPropertyName = "PurchaseID",
            //    HeaderText = "Номер покупки"
            //});
            // Добавляем колонку для отображения ComponentName
            DataGridViewTextBoxColumn componentNameColumn = new DataGridViewTextBoxColumn
            {
                Name = "ComponentName",
                HeaderText = "Название компонента",
                ReadOnly = true // Только для чтения
            };
            purchaseDetailsDataGridView.Columns.Add(componentNameColumn);

            // Добавляем остальные колонки
            purchaseDetailsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantity",
                HeaderText = "Количество"
            });

            purchaseDetailsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UnitPrice",
                HeaderText = "Цена за единицу"
            });

            // Привязываем событие для подмены ComponentID -> ComponentName
            purchaseDetailsDataGridView.CellFormatting += PurchaseDetailsDataGridView_CellFormatting;
        }

        // Метод подмены ComponentID на ComponentName
        private void PurchaseDetailsDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (purchaseDetailsDataGridView.Columns[e.ColumnIndex].Name == "ComponentName")
            {
                var row = purchaseDetailsDataGridView.Rows[e.RowIndex];

                if (row.Cells["ComponentID"].Value != null && int.TryParse(row.Cells["ComponentID"].Value.ToString(), out int componentID))
                {
                    DataRow[] foundRows = computerCompanyDBDataSet.Components.Select($"ComponentID = {componentID}");
                    if (foundRows.Length > 0)
                    {
                        e.Value = foundRows[0]["ComponentName"].ToString();
                        e.FormattingApplied = true;
                    }
                }
            }
        }

        private void btFirst_Click(object sender, EventArgs e)
        {
            fKPurchaseDPurch76969D2EBindingSource.MoveFirst();
        }

        private void btLast_Click(object sender, EventArgs e)
        {
            fKPurchaseDPurch76969D2EBindingSource.MoveLast();
        }

        private void btPrevious_Click(object sender, EventArgs e)
        {
            fKPurchaseDPurch76969D2EBindingSource.MovePrevious();
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            fKPurchaseDPurch76969D2EBindingSource.MoveNext();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            fKPurchaseDPurch76969D2EBindingSource.AddNew();
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            fKPurchaseDPurch76969D2EBindingSource.RemoveCurrent();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.purchaseDetailsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.computerCompanyDBDataSet);
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            computerCompanyDBDataSet.PurchaseDetails.RejectChanges();
        }

        private void buttonComponents_Click(object sender, EventArgs e)
        {
            ComponentsForm componentsForm = new ComponentsForm(true); // Включаем MessageBox
            componentsForm.Owner = this;
            componentsForm.ShowDialog();
        }

        private void buttonPurchases_Click(object sender, EventArgs e)
        {
            PurchasesForm purchasesForm = new PurchasesForm(true); // Включаем MessageBox
            purchasesForm.Owner = this;
            purchasesForm.ShowDialog();
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            if (checkForm == null || checkForm.IsDisposed)
            {
                if (comboBoxPurchaseId.SelectedItem != null)
                {
                    // Приводим SelectedItem к DataRowView
                    DataRowView selectedRow = comboBoxPurchaseId.SelectedItem as DataRowView;

                    if (selectedRow != null)
                    {
                        // Предположим, что идентификатор находится в первом столбце (индекс 0)
                        // Или используйте имя столбца, например: selectedRow["ColumnName"]
                        int purchaseId = Convert.ToInt32(selectedRow[0]); // Замените 0 на индекс нужного столбца

                        checkForm = new CheckForm(purchaseId); // Передаем purchaseId в конструктор
                        checkForm.FormClosed += (s, args) => checkForm = null;
                        checkForm.ShowDialog(this);
                    }
                }
                else
                {
                    MessageBox.Show("Пожалуйста, выберите идентификатор покупки.");
                }
            }
        }
    }
}
