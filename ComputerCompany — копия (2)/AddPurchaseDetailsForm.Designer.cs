namespace ComputerCompany
{
    partial class AddPurchaseDetailsForm
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
            this.buttonComponents = new System.Windows.Forms.Button();
            this.comboBoxComponentId = new System.Windows.Forms.ComboBox();
            this.componentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.computerCompanyDBDataSet = new ComputerCompany.ComputerCompanyDBDataSet();
            this.textBoxUnitPrice = new System.Windows.Forms.TextBox();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxPurchaseId = new System.Windows.Forms.ComboBox();
            this.purchasesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonPurchases = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.purchasesTableAdapter = new ComputerCompany.ComputerCompanyDBDataSetTableAdapters.PurchasesTableAdapter();
            this.componentsTableAdapter = new ComputerCompany.ComputerCompanyDBDataSetTableAdapters.ComponentsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.componentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.computerCompanyDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchasesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonComponents
            // 
            this.buttonComponents.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonComponents.Location = new System.Drawing.Point(365, 176);
            this.buttonComponents.Name = "buttonComponents";
            this.buttonComponents.Size = new System.Drawing.Size(276, 39);
            this.buttonComponents.TabIndex = 114;
            this.buttonComponents.Text = "Список компонентов";
            this.buttonComponents.UseVisualStyleBackColor = true;
            this.buttonComponents.Click += new System.EventHandler(this.buttonComponents_Click);
            // 
            // comboBoxComponentId
            // 
            this.comboBoxComponentId.DataSource = this.componentsBindingSource;
            this.comboBoxComponentId.DisplayMember = "ComponentName";
            this.comboBoxComponentId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxComponentId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxComponentId.FormattingEnabled = true;
            this.comboBoxComponentId.Location = new System.Drawing.Point(366, 140);
            this.comboBoxComponentId.Name = "comboBoxComponentId";
            this.comboBoxComponentId.Size = new System.Drawing.Size(275, 30);
            this.comboBoxComponentId.TabIndex = 113;
            this.comboBoxComponentId.ValueMember = "ComponentID";
            // 
            // componentsBindingSource
            // 
            this.componentsBindingSource.DataMember = "Components";
            this.componentsBindingSource.DataSource = this.computerCompanyDBDataSet;
            // 
            // computerCompanyDBDataSet
            // 
            this.computerCompanyDBDataSet.DataSetName = "ComputerCompanyDBDataSet";
            this.computerCompanyDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBoxUnitPrice
            // 
            this.textBoxUnitPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxUnitPrice.Location = new System.Drawing.Point(371, 309);
            this.textBoxUnitPrice.Name = "textBoxUnitPrice";
            this.textBoxUnitPrice.Size = new System.Drawing.Size(275, 28);
            this.textBoxUnitPrice.TabIndex = 112;
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxQuantity.Location = new System.Drawing.Point(371, 246);
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(275, 28);
            this.textBoxQuantity.TabIndex = 111;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(101, 315);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(218, 22);
            this.label4.TabIndex = 110;
            this.label4.Text = "Стоимость за эту деталь";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(122, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 22);
            this.label2.TabIndex = 108;
            this.label2.Text = "Название компонента";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(210, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 22);
            this.label3.TabIndex = 109;
            this.label3.Text = "Количество";
            // 
            // comboBoxPurchaseId
            // 
            this.comboBoxPurchaseId.DataSource = this.purchasesBindingSource;
            this.comboBoxPurchaseId.DisplayMember = "PurchaseID";
            this.comboBoxPurchaseId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPurchaseId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxPurchaseId.FormattingEnabled = true;
            this.comboBoxPurchaseId.Location = new System.Drawing.Point(365, 45);
            this.comboBoxPurchaseId.Name = "comboBoxPurchaseId";
            this.comboBoxPurchaseId.Size = new System.Drawing.Size(275, 30);
            this.comboBoxPurchaseId.TabIndex = 117;
            this.comboBoxPurchaseId.ValueMember = "PurchaseID";
            // 
            // purchasesBindingSource
            // 
            this.purchasesBindingSource.DataMember = "Purchases";
            this.purchasesBindingSource.DataSource = this.computerCompanyDBDataSet;
            // 
            // buttonPurchases
            // 
            this.buttonPurchases.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPurchases.Location = new System.Drawing.Point(365, 81);
            this.buttonPurchases.Name = "buttonPurchases";
            this.buttonPurchases.Size = new System.Drawing.Size(275, 39);
            this.buttonPurchases.TabIndex = 116;
            this.buttonPurchases.Text = "Список покупок";
            this.buttonPurchases.UseVisualStyleBackColor = true;
            this.buttonPurchases.Click += new System.EventHandler(this.buttonPurchases_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(181, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 22);
            this.label1.TabIndex = 115;
            this.label1.Text = "Номер покупки";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.Location = new System.Drawing.Point(454, 364);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(198, 51);
            this.buttonCancel.TabIndex = 147;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAdd.Location = new System.Drawing.Point(105, 364);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(198, 51);
            this.buttonAdd.TabIndex = 146;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // purchasesTableAdapter
            // 
            this.purchasesTableAdapter.ClearBeforeFill = true;
            // 
            // componentsTableAdapter
            // 
            this.componentsTableAdapter.ClearBeforeFill = true;
            // 
            // AddPurchaseDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.comboBoxPurchaseId);
            this.Controls.Add(this.buttonPurchases);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonComponents);
            this.Controls.Add(this.comboBoxComponentId);
            this.Controls.Add(this.textBoxUnitPrice);
            this.Controls.Add(this.textBoxQuantity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AddPurchaseDetailsForm";
            this.Text = "Добавление деталей покупки";
            this.Load += new System.EventHandler(this.AddPurchaseDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.componentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.computerCompanyDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchasesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonComponents;
        public System.Windows.Forms.ComboBox comboBoxComponentId;
        private System.Windows.Forms.TextBox textBoxUnitPrice;
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox comboBoxPurchaseId;
        private System.Windows.Forms.Button buttonPurchases;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.BindingSource componentsBindingSource;
        private ComputerCompanyDBDataSetTableAdapters.ComponentsTableAdapter componentsTableAdapter;
        public ComputerCompanyDBDataSet computerCompanyDBDataSet;
        public System.Windows.Forms.BindingSource purchasesBindingSource;
        public ComputerCompanyDBDataSetTableAdapters.PurchasesTableAdapter purchasesTableAdapter;
    }
}