namespace ComputerCompany
{
    partial class FullForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.comboBoxSupplier = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.listBoxItems = new System.Windows.Forms.ListBox();
            this.checkBoxAllSuppliers = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridViewFull = new System.Windows.Forms.DataGridView();
            this.checkBoxAllTime = new System.Windows.Forms.CheckBox();
            this.GetPurchaseDetailsForSuppliersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.computerCompanyDBDataSet = new ComputerCompany.ComputerCompanyDBDataSet();
            this.getPurchaseDetailsForSuppliersTableAdapter = new ComputerCompany.ComputerCompanyDBDataSetTableAdapters.GetPurchaseDetailsForSuppliersTableAdapter();
            this.categoriesTableAdapter = new ComputerCompany.ComputerCompanyDBDataSetTableAdapters.CategoriesTableAdapter();
            this.componentsTableAdapter = new ComputerCompany.ComputerCompanyDBDataSetTableAdapters.ComponentsTableAdapter();
            this.purchasesTableAdapter = new ComputerCompany.ComputerCompanyDBDataSetTableAdapters.PurchasesTableAdapter();
            this.purchaseDetailsTableAdapter = new ComputerCompany.ComputerCompanyDBDataSetTableAdapters.PurchaseDetailsTableAdapter();
            this.suppliersTableAdapter = new ComputerCompany.ComputerCompanyDBDataSetTableAdapters.SuppliersTableAdapter();
            this.buttonReport = new System.Windows.Forms.Button();
            this.labelTotals = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFull)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GetPurchaseDetailsForSuppliersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.computerCompanyDBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxSupplier
            // 
            this.comboBoxSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSupplier.Enabled = false;
            this.comboBoxSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxSupplier.FormattingEnabled = true;
            this.comboBoxSupplier.Location = new System.Drawing.Point(83, 127);
            this.comboBoxSupplier.Name = "comboBoxSupplier";
            this.comboBoxSupplier.Size = new System.Drawing.Size(212, 30);
            this.comboBoxSupplier.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker1.Location = new System.Drawing.Point(641, 139);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 28);
            this.dateTimePicker1.TabIndex = 2;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Enabled = false;
            this.dateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker2.Location = new System.Drawing.Point(918, 139);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 28);
            this.dateTimePicker2.TabIndex = 3;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(1149, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(218, 50);
            this.button1.TabIndex = 4;
            this.button1.Text = "Отфильтровать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonFilter_Click);
            // 
            // listBoxItems
            // 
            this.listBoxItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxItems.FormattingEnabled = true;
            this.listBoxItems.HorizontalScrollbar = true;
            this.listBoxItems.ItemHeight = 18;
            this.listBoxItems.Location = new System.Drawing.Point(981, 186);
            this.listBoxItems.Name = "listBoxItems";
            this.listBoxItems.Size = new System.Drawing.Size(729, 524);
            this.listBoxItems.TabIndex = 5;
            // 
            // checkBoxAllSuppliers
            // 
            this.checkBoxAllSuppliers.AutoSize = true;
            this.checkBoxAllSuppliers.Checked = true;
            this.checkBoxAllSuppliers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAllSuppliers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxAllSuppliers.Location = new System.Drawing.Point(83, 93);
            this.checkBoxAllSuppliers.Name = "checkBoxAllSuppliers";
            this.checkBoxAllSuppliers.Size = new System.Drawing.Size(219, 24);
            this.checkBoxAllSuppliers.TabIndex = 6;
            this.checkBoxAllSuppliers.Text = "По всем поставщикам";
            this.checkBoxAllSuppliers.UseVisualStyleBackColor = true;
            this.checkBoxAllSuppliers.CheckedChanged += new System.EventHandler(this.checkBoxAllSuppliers_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(591, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Даты закупок";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(588, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "с";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(861, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "до";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(1215, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(297, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Закупленные комплектующие";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(341, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(210, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "Полная информация";
            // 
            // dataGridViewFull
            // 
            this.dataGridViewFull.AllowUserToAddRows = false;
            this.dataGridViewFull.AllowUserToDeleteRows = false;
            this.dataGridViewFull.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewFull.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewFull.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFull.Location = new System.Drawing.Point(25, 186);
            this.dataGridViewFull.Name = "dataGridViewFull";
            this.dataGridViewFull.ReadOnly = true;
            this.dataGridViewFull.RowHeadersWidth = 60;
            this.dataGridViewFull.RowTemplate.Height = 24;
            this.dataGridViewFull.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFull.Size = new System.Drawing.Size(950, 561);
            this.dataGridViewFull.TabIndex = 0;
            this.dataGridViewFull.SelectionChanged += new System.EventHandler(this.DataGridView1_SelectionChanged);
            // 
            // checkBoxAllTime
            // 
            this.checkBoxAllTime.AutoSize = true;
            this.checkBoxAllTime.Checked = true;
            this.checkBoxAllTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAllTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxAllTime.Location = new System.Drawing.Point(766, 94);
            this.checkBoxAllTime.Name = "checkBoxAllTime";
            this.checkBoxAllTime.Size = new System.Drawing.Size(259, 24);
            this.checkBoxAllTime.TabIndex = 13;
            this.checkBoxAllTime.Text = "Без ограничений по датам";
            this.checkBoxAllTime.UseVisualStyleBackColor = true;
            this.checkBoxAllTime.CheckedChanged += new System.EventHandler(this.checkBoxAllTime_CheckedChanged);
            // 
            // GetPurchaseDetailsForSuppliersBindingSource
            // 
            this.GetPurchaseDetailsForSuppliersBindingSource.DataMember = "GetPurchaseDetailsForSuppliers";
            this.GetPurchaseDetailsForSuppliersBindingSource.DataSource = this.computerCompanyDBDataSet;
            // 
            // computerCompanyDBDataSet
            // 
            this.computerCompanyDBDataSet.DataSetName = "ComputerCompanyDBDataSet";
            this.computerCompanyDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // getPurchaseDetailsForSuppliersTableAdapter
            // 
            this.getPurchaseDetailsForSuppliersTableAdapter.ClearBeforeFill = true;
            // 
            // categoriesTableAdapter
            // 
            this.categoriesTableAdapter.ClearBeforeFill = true;
            // 
            // componentsTableAdapter
            // 
            this.componentsTableAdapter.ClearBeforeFill = true;
            // 
            // purchasesTableAdapter
            // 
            this.purchasesTableAdapter.ClearBeforeFill = true;
            // 
            // purchaseDetailsTableAdapter
            // 
            this.purchaseDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // suppliersTableAdapter
            // 
            this.suppliersTableAdapter.ClearBeforeFill = true;
            // 
            // buttonReport
            // 
            this.buttonReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonReport.Location = new System.Drawing.Point(1407, 81);
            this.buttonReport.Name = "buttonReport";
            this.buttonReport.Size = new System.Drawing.Size(268, 50);
            this.buttonReport.TabIndex = 14;
            this.buttonReport.Text = "Отчет";
            this.buttonReport.UseVisualStyleBackColor = true;
            this.buttonReport.Click += new System.EventHandler(this.buttonReport_Click);
            // 
            // labelTotals
            // 
            this.labelTotals.AutoSize = true;
            this.labelTotals.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTotals.Location = new System.Drawing.Point(25, 164);
            this.labelTotals.Name = "labelTotals";
            this.labelTotals.Size = new System.Drawing.Size(0, 20);
            this.labelTotals.TabIndex = 15;
            // 
            // FullForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1722, 733);
            this.Controls.Add(this.labelTotals);
            this.Controls.Add(this.buttonReport);
            this.Controls.Add(this.checkBoxAllTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxAllSuppliers);
            this.Controls.Add(this.listBoxItems);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.comboBoxSupplier);
            this.Controls.Add(this.dataGridViewFull);
            this.Name = "FullForm";
            this.Text = "Окно с полной информацией";
            this.Load += new System.EventHandler(this.FullForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFull)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GetPurchaseDetailsForSuppliersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.computerCompanyDBDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxSupplier;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBoxItems;
        private System.Windows.Forms.CheckBox checkBoxAllSuppliers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridViewFull;
        private ComputerCompanyDBDataSetTableAdapters.GetPurchaseDetailsForSuppliersTableAdapter getPurchaseDetailsForSuppliersTableAdapter;
        private ComputerCompanyDBDataSet computerCompanyDBDataSet;
        private System.Windows.Forms.CheckBox checkBoxAllTime;
        private ComputerCompanyDBDataSetTableAdapters.CategoriesTableAdapter categoriesTableAdapter;
        private ComputerCompanyDBDataSetTableAdapters.ComponentsTableAdapter componentsTableAdapter;
        private ComputerCompanyDBDataSetTableAdapters.PurchasesTableAdapter purchasesTableAdapter;
        private ComputerCompanyDBDataSetTableAdapters.PurchaseDetailsTableAdapter purchaseDetailsTableAdapter;
        private ComputerCompanyDBDataSetTableAdapters.SuppliersTableAdapter suppliersTableAdapter;
        private System.Windows.Forms.BindingSource GetPurchaseDetailsForSuppliersBindingSource;
        private System.Windows.Forms.Button buttonReport;
        private System.Windows.Forms.Label labelTotals;
    }
}