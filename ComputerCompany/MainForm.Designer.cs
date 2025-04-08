namespace ComputerCompany
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
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
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonPurchases = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPurchaseDetails = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSuppliers = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonComponents = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCategories = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFull)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GetPurchaseDetailsForSuppliersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.computerCompanyDBDataSet)).BeginInit();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxSupplier
            // 
            this.comboBoxSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSupplier.Enabled = false;
            this.comboBoxSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxSupplier.FormattingEnabled = true;
            this.comboBoxSupplier.Location = new System.Drawing.Point(115, 119);
            this.comboBoxSupplier.Name = "comboBoxSupplier";
            this.comboBoxSupplier.Size = new System.Drawing.Size(212, 30);
            this.comboBoxSupplier.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker1.Location = new System.Drawing.Point(551, 121);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 28);
            this.dateTimePicker1.TabIndex = 2;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Enabled = false;
            this.dateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker2.Location = new System.Drawing.Point(828, 121);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 28);
            this.dateTimePicker2.TabIndex = 3;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(1143, 111);
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
            this.listBoxItems.Location = new System.Drawing.Point(981, 236);
            this.listBoxItems.Name = "listBoxItems";
            this.listBoxItems.Size = new System.Drawing.Size(729, 506);
            this.listBoxItems.TabIndex = 5;
            // 
            // checkBoxAllSuppliers
            // 
            this.checkBoxAllSuppliers.AutoSize = true;
            this.checkBoxAllSuppliers.Checked = true;
            this.checkBoxAllSuppliers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAllSuppliers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxAllSuppliers.Location = new System.Drawing.Point(115, 78);
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
            this.label1.Location = new System.Drawing.Point(501, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Даты закупок";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(498, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "с";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(771, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "до";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(1211, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(297, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Закупленные комплектующие";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(336, 178);
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewFull.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewFull.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewFull.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewFull.Location = new System.Drawing.Point(25, 236);
            this.dataGridViewFull.Name = "dataGridViewFull";
            this.dataGridViewFull.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewFull.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewFull.RowHeadersWidth = 60;
            this.dataGridViewFull.RowTemplate.Height = 24;
            this.dataGridViewFull.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFull.Size = new System.Drawing.Size(950, 506);
            this.dataGridViewFull.TabIndex = 0;
            this.dataGridViewFull.SelectionChanged += new System.EventHandler(this.DataGridView_SelectionChanged);
            // 
            // checkBoxAllTime
            // 
            this.checkBoxAllTime.AutoSize = true;
            this.checkBoxAllTime.Checked = true;
            this.checkBoxAllTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAllTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxAllTime.Location = new System.Drawing.Point(676, 76);
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
            this.buttonReport.Location = new System.Drawing.Point(1401, 111);
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
            this.labelTotals.Location = new System.Drawing.Point(35, 208);
            this.labelTotals.Name = "labelTotals";
            this.labelTotals.Size = new System.Drawing.Size(0, 20);
            this.labelTotals.TabIndex = 15;
            // 
            // toolStripMain
            // 
            this.toolStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonPurchases,
            this.toolStripButtonPurchaseDetails,
            this.toolStripButtonSuppliers,
            this.toolStripButtonComponents,
            this.toolStripButtonCategories});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStripMain.Size = new System.Drawing.Size(1722, 27);
            this.toolStripMain.TabIndex = 16;
            this.toolStripMain.Text = "toolStripMain";
            // 
            // toolStripButtonPurchases
            // 
            this.toolStripButtonPurchases.CheckOnClick = true;
            this.toolStripButtonPurchases.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonPurchases.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPurchases.Image")));
            this.toolStripButtonPurchases.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPurchases.Name = "toolStripButtonPurchases";
            this.toolStripButtonPurchases.Size = new System.Drawing.Size(68, 24);
            this.toolStripButtonPurchases.Text = "Закупки";
            this.toolStripButtonPurchases.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolStripButtonPurchases.Click += new System.EventHandler(this.toolStripButtonPurchases_Click);
            // 
            // toolStripButtonPurchaseDetails
            // 
            this.toolStripButtonPurchaseDetails.CheckOnClick = true;
            this.toolStripButtonPurchaseDetails.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonPurchaseDetails.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPurchaseDetails.Image")));
            this.toolStripButtonPurchaseDetails.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPurchaseDetails.Name = "toolStripButtonPurchaseDetails";
            this.toolStripButtonPurchaseDetails.Size = new System.Drawing.Size(125, 24);
            this.toolStripButtonPurchaseDetails.Text = "Журнал закупок";
            this.toolStripButtonPurchaseDetails.Click += new System.EventHandler(this.toolStripButtonPurchaseDetails_Click);
            // 
            // toolStripButtonSuppliers
            // 
            this.toolStripButtonSuppliers.CheckOnClick = true;
            this.toolStripButtonSuppliers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonSuppliers.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSuppliers.Image")));
            this.toolStripButtonSuppliers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSuppliers.Name = "toolStripButtonSuppliers";
            this.toolStripButtonSuppliers.Size = new System.Drawing.Size(99, 24);
            this.toolStripButtonSuppliers.Text = "Поставщики";
            this.toolStripButtonSuppliers.Click += new System.EventHandler(this.toolStripButtonSuppliers_Click);
            // 
            // toolStripButtonComponents
            // 
            this.toolStripButtonComponents.CheckOnClick = true;
            this.toolStripButtonComponents.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonComponents.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonComponents.Image")));
            this.toolStripButtonComponents.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonComponents.Name = "toolStripButtonComponents";
            this.toolStripButtonComponents.Size = new System.Drawing.Size(128, 24);
            this.toolStripButtonComponents.Text = "Комплектующие";
            this.toolStripButtonComponents.Click += new System.EventHandler(this.toolStripButtonComponents_Click);
            // 
            // toolStripButtonCategories
            // 
            this.toolStripButtonCategories.CheckOnClick = true;
            this.toolStripButtonCategories.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonCategories.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCategories.Image")));
            this.toolStripButtonCategories.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCategories.Name = "toolStripButtonCategories";
            this.toolStripButtonCategories.Size = new System.Drawing.Size(86, 24);
            this.toolStripButtonCategories.Text = "Категории";
            this.toolStripButtonCategories.Click += new System.EventHandler(this.toolStripButtonCategories_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1722, 762);
            this.Controls.Add(this.toolStripMain);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Информационная система закупки комплектующих";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFull)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GetPurchaseDetailsForSuppliersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.computerCompanyDBDataSet)).EndInit();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
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
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton toolStripButtonPurchases;
        private System.Windows.Forms.ToolStripButton toolStripButtonPurchaseDetails;
        private System.Windows.Forms.ToolStripButton toolStripButtonSuppliers;
        private System.Windows.Forms.ToolStripButton toolStripButtonComponents;
        private System.Windows.Forms.ToolStripButton toolStripButtonCategories;
    }
}