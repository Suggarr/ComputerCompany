namespace ComputerCompany
{
    partial class PurchaseDetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PurchaseDetailsForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainLabel = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonComponents = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btFirst = new System.Windows.Forms.Button();
            this.comboBoxComponentId = new System.Windows.Forms.ComboBox();
            this.componentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.computerCompanyDBDataSet = new ComputerCompany.ComputerCompanyDBDataSet();
            this.btLast = new System.Windows.Forms.Button();
            this.btPrevious = new System.Windows.Forms.Button();
            this.textBoxPurchaseDetailId = new System.Windows.Forms.TextBox();
            this.btNext = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.btRemove = new System.Windows.Forms.Button();
            this.textBoxUnitPrice = new System.Windows.Forms.TextBox();
            this.btSave = new System.Windows.Forms.Button();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.buttonReport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonPurchases = new System.Windows.Forms.Button();
            this.purchaseDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.purchaseDetailsTableAdapter = new ComputerCompany.ComputerCompanyDBDataSetTableAdapters.PurchaseDetailsTableAdapter();
            this.tableAdapterManager = new ComputerCompany.ComputerCompanyDBDataSetTableAdapters.TableAdapterManager();
            this.componentsTableAdapter = new ComputerCompany.ComputerCompanyDBDataSetTableAdapters.ComponentsTableAdapter();
            this.purchasesTableAdapter = new ComputerCompany.ComputerCompanyDBDataSetTableAdapters.PurchasesTableAdapter();
            this.purchaseDetailsBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.fKPurchaseDPurch76969D2EBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.purchasesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.purchaseDetailsBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.purchaseDetailsDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBoxPurchaseId = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.componentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.computerCompanyDBDataSet)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseDetailsBindingNavigator)).BeginInit();
            this.purchaseDetailsBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fKPurchaseDPurch76969D2EBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchasesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseDetailsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // MainLabel
            // 
            this.MainLabel.AutoSize = true;
            this.MainLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.MainLabel.Location = new System.Drawing.Point(275, 47);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(176, 25);
            this.MainLabel.TabIndex = 8;
            this.MainLabel.Text = "Журнал покупок";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(743, 70);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(870, 677);
            this.tabControl1.TabIndex = 49;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonComponents);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.btFirst);
            this.tabPage1.Controls.Add(this.comboBoxComponentId);
            this.tabPage1.Controls.Add(this.btLast);
            this.tabPage1.Controls.Add(this.btPrevious);
            this.tabPage1.Controls.Add(this.textBoxPurchaseDetailId);
            this.tabPage1.Controls.Add(this.btNext);
            this.tabPage1.Controls.Add(this.btAdd);
            this.tabPage1.Controls.Add(this.btCancel);
            this.tabPage1.Controls.Add(this.btRemove);
            this.tabPage1.Controls.Add(this.textBoxUnitPrice);
            this.tabPage1.Controls.Add(this.btSave);
            this.tabPage1.Controls.Add(this.textBoxQuantity);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(862, 644);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Данные";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonComponents
            // 
            this.buttonComponents.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonComponents.Location = new System.Drawing.Point(420, 158);
            this.buttonComponents.Name = "buttonComponents";
            this.buttonComponents.Size = new System.Drawing.Size(276, 39);
            this.buttonComponents.TabIndex = 107;
            this.buttonComponents.Text = "Список компонентов";
            this.buttonComponents.UseVisualStyleBackColor = true;
            this.buttonComponents.Click += new System.EventHandler(this.buttonComponents_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(172, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(202, 22);
            this.label5.TabIndex = 38;
            this.label5.Text = "Номер детали покупки";
            // 
            // btFirst
            // 
            this.btFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btFirst.Location = new System.Drawing.Point(101, 388);
            this.btFirst.Name = "btFirst";
            this.btFirst.Size = new System.Drawing.Size(143, 48);
            this.btFirst.TabIndex = 22;
            this.btFirst.Text = "Первая";
            this.btFirst.UseVisualStyleBackColor = true;
            this.btFirst.Click += new System.EventHandler(this.btFirst_Click);
            // 
            // comboBoxComponentId
            // 
            this.comboBoxComponentId.DataSource = this.componentsBindingSource;
            this.comboBoxComponentId.DisplayMember = "ComponentName";
            this.comboBoxComponentId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxComponentId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxComponentId.FormattingEnabled = true;
            this.comboBoxComponentId.Location = new System.Drawing.Point(421, 122);
            this.comboBoxComponentId.Name = "comboBoxComponentId";
            this.comboBoxComponentId.Size = new System.Drawing.Size(275, 30);
            this.comboBoxComponentId.TabIndex = 41;
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
            // btLast
            // 
            this.btLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btLast.Location = new System.Drawing.Point(287, 388);
            this.btLast.Name = "btLast";
            this.btLast.Size = new System.Drawing.Size(143, 48);
            this.btLast.TabIndex = 23;
            this.btLast.Text = "Последняя";
            this.btLast.UseVisualStyleBackColor = true;
            this.btLast.Click += new System.EventHandler(this.btLast_Click);
            // 
            // btPrevious
            // 
            this.btPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btPrevious.Location = new System.Drawing.Point(471, 388);
            this.btPrevious.Name = "btPrevious";
            this.btPrevious.Size = new System.Drawing.Size(143, 49);
            this.btPrevious.TabIndex = 24;
            this.btPrevious.Text = "Предыдущая";
            this.btPrevious.UseVisualStyleBackColor = true;
            this.btPrevious.Click += new System.EventHandler(this.btPrevious_Click);
            // 
            // textBoxPurchaseDetailId
            // 
            this.textBoxPurchaseDetailId.Enabled = false;
            this.textBoxPurchaseDetailId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPurchaseDetailId.Location = new System.Drawing.Point(422, 60);
            this.textBoxPurchaseDetailId.Name = "textBoxPurchaseDetailId";
            this.textBoxPurchaseDetailId.Size = new System.Drawing.Size(275, 28);
            this.textBoxPurchaseDetailId.TabIndex = 39;
            // 
            // btNext
            // 
            this.btNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btNext.Location = new System.Drawing.Point(649, 388);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(143, 49);
            this.btNext.TabIndex = 25;
            this.btNext.Text = "Следующая";
            this.btNext.UseVisualStyleBackColor = true;
            this.btNext.Click += new System.EventHandler(this.btNext_Click);
            // 
            // btAdd
            // 
            this.btAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btAdd.Location = new System.Drawing.Point(101, 469);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(143, 49);
            this.btAdd.TabIndex = 26;
            this.btAdd.Text = "Добавить";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btCancel
            // 
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btCancel.Location = new System.Drawing.Point(649, 469);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(143, 49);
            this.btCancel.TabIndex = 37;
            this.btCancel.Text = "Отменить";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btRemove
            // 
            this.btRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btRemove.Location = new System.Drawing.Point(287, 469);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(143, 49);
            this.btRemove.TabIndex = 27;
            this.btRemove.Text = "Удалить";
            this.btRemove.UseVisualStyleBackColor = true;
            this.btRemove.Click += new System.EventHandler(this.btRemove_Click);
            // 
            // textBoxUnitPrice
            // 
            this.textBoxUnitPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxUnitPrice.Location = new System.Drawing.Point(426, 291);
            this.textBoxUnitPrice.Name = "textBoxUnitPrice";
            this.textBoxUnitPrice.Size = new System.Drawing.Size(275, 28);
            this.textBoxUnitPrice.TabIndex = 36;
            // 
            // btSave
            // 
            this.btSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.btSave.Location = new System.Drawing.Point(471, 469);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(143, 49);
            this.btSave.TabIndex = 28;
            this.btSave.Text = "Сохранить";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxQuantity.Location = new System.Drawing.Point(426, 228);
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(275, 28);
            this.textBoxQuantity.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(156, 297);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(218, 22);
            this.label4.TabIndex = 32;
            this.label4.Text = "Стоимость за эту деталь";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(177, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 22);
            this.label2.TabIndex = 30;
            this.label2.Text = "Название компонента";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(265, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 22);
            this.label3.TabIndex = 31;
            this.label3.Text = "Количество";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.buttonCheck);
            this.tabPage3.Controls.Add(this.dateTimePickerEnd);
            this.tabPage3.Controls.Add(this.dateTimePickerStart);
            this.tabPage3.Controls.Add(this.buttonReport);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabPage3.Size = new System.Drawing.Size(862, 644);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Справка";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // buttonCheck
            // 
            this.buttonCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.buttonCheck.Location = new System.Drawing.Point(439, 199);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(306, 49);
            this.buttonCheck.TabIndex = 50;
            this.buttonCheck.Text = "Выдать чек";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(159, 151);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(200, 27);
            this.dateTimePickerEnd.TabIndex = 49;
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(159, 79);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(200, 27);
            this.dateTimePickerStart.TabIndex = 48;
            // 
            // buttonReport
            // 
            this.buttonReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.buttonReport.Location = new System.Drawing.Point(439, 111);
            this.buttonReport.Name = "buttonReport";
            this.buttonReport.Size = new System.Drawing.Size(306, 49);
            this.buttonReport.TabIndex = 47;
            this.buttonReport.Text = "Выдать справку";
            this.buttonReport.UseVisualStyleBackColor = true;
            this.buttonReport.Click += new System.EventHandler(this.buttonReport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(85, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 22);
            this.label1.TabIndex = 50;
            this.label1.Text = "Номер покупки";
            // 
            // buttonPurchases
            // 
            this.buttonPurchases.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPurchases.Location = new System.Drawing.Point(269, 135);
            this.buttonPurchases.Name = "buttonPurchases";
            this.buttonPurchases.Size = new System.Drawing.Size(275, 39);
            this.buttonPurchases.TabIndex = 51;
            this.buttonPurchases.Text = "Список покупок";
            this.buttonPurchases.UseVisualStyleBackColor = true;
            this.buttonPurchases.Click += new System.EventHandler(this.buttonPurchases_Click);
            // 
            // purchaseDetailsBindingSource
            // 
            this.purchaseDetailsBindingSource.DataMember = "PurchaseDetails";
            this.purchaseDetailsBindingSource.DataSource = this.computerCompanyDBDataSet;
            // 
            // purchaseDetailsTableAdapter
            // 
            this.purchaseDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CategoriesTableAdapter = null;
            this.tableAdapterManager.ComponentsTableAdapter = this.componentsTableAdapter;
            this.tableAdapterManager.PurchaseDetailsTableAdapter = this.purchaseDetailsTableAdapter;
            this.tableAdapterManager.PurchasesTableAdapter = this.purchasesTableAdapter;
            this.tableAdapterManager.SuppliersTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = ComputerCompany.ComputerCompanyDBDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // componentsTableAdapter
            // 
            this.componentsTableAdapter.ClearBeforeFill = true;
            // 
            // purchasesTableAdapter
            // 
            this.purchasesTableAdapter.ClearBeforeFill = true;
            // 
            // purchaseDetailsBindingNavigator
            // 
            this.purchaseDetailsBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.purchaseDetailsBindingNavigator.BindingSource = this.fKPurchaseDPurch76969D2EBindingSource;
            this.purchaseDetailsBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.purchaseDetailsBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.purchaseDetailsBindingNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.purchaseDetailsBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.purchaseDetailsBindingNavigatorSaveItem});
            this.purchaseDetailsBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.purchaseDetailsBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.purchaseDetailsBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.purchaseDetailsBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.purchaseDetailsBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.purchaseDetailsBindingNavigator.Name = "purchaseDetailsBindingNavigator";
            this.purchaseDetailsBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.purchaseDetailsBindingNavigator.Size = new System.Drawing.Size(1637, 27);
            this.purchaseDetailsBindingNavigator.TabIndex = 52;
            this.purchaseDetailsBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorAddNewItem.Text = "Добавить";
            // 
            // fKPurchaseDPurch76969D2EBindingSource
            // 
            this.fKPurchaseDPurch76969D2EBindingSource.DataMember = "FK__PurchaseD__Purch__76969D2E";
            this.fKPurchaseDPurch76969D2EBindingSource.DataSource = this.purchasesBindingSource;
            // 
            // purchasesBindingSource
            // 
            this.purchasesBindingSource.DataMember = "Purchases";
            this.purchasesBindingSource.DataSource = this.computerCompanyDBDataSet;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(55, 24);
            this.bindingNavigatorCountItem.Text = "для {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Общее число элементов";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorDeleteItem.Text = "Удалить";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Переместить в начало";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Переместить назад";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Положение";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Текущее положение";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveNextItem.Text = "Переместить вперед";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveLastItem.Text = "Переместить в конец";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // purchaseDetailsBindingNavigatorSaveItem
            // 
            this.purchaseDetailsBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.purchaseDetailsBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("purchaseDetailsBindingNavigatorSaveItem.Image")));
            this.purchaseDetailsBindingNavigatorSaveItem.Name = "purchaseDetailsBindingNavigatorSaveItem";
            this.purchaseDetailsBindingNavigatorSaveItem.Size = new System.Drawing.Size(29, 24);
            this.purchaseDetailsBindingNavigatorSaveItem.Text = "Сохранить данные";
            this.purchaseDetailsBindingNavigatorSaveItem.Click += new System.EventHandler(this.purchaseDetailsBindingNavigatorSaveItem_Click);
            // 
            // purchaseDetailsDataGridView
            // 
            this.purchaseDetailsDataGridView.AllowUserToAddRows = false;
            this.purchaseDetailsDataGridView.AllowUserToDeleteRows = false;
            this.purchaseDetailsDataGridView.AutoGenerateColumns = false;
            this.purchaseDetailsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.purchaseDetailsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.purchaseDetailsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.purchaseDetailsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.purchaseDetailsDataGridView.DataSource = this.fKPurchaseDPurch76969D2EBindingSource;
            this.purchaseDetailsDataGridView.Location = new System.Drawing.Point(23, 183);
            this.purchaseDetailsDataGridView.Name = "purchaseDetailsDataGridView";
            this.purchaseDetailsDataGridView.ReadOnly = true;
            this.purchaseDetailsDataGridView.RowHeadersWidth = 51;
            this.purchaseDetailsDataGridView.RowTemplate.Height = 24;
            this.purchaseDetailsDataGridView.Size = new System.Drawing.Size(689, 560);
            this.purchaseDetailsDataGridView.TabIndex = 52;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PurchaseDetailID";
            this.dataGridViewTextBoxColumn1.HeaderText = "PurchaseDetailID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "PurchaseID";
            this.dataGridViewTextBoxColumn2.HeaderText = "PurchaseID";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ComponentID";
            this.dataGridViewTextBoxColumn3.HeaderText = "ComponentID";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Quantity";
            this.dataGridViewTextBoxColumn4.HeaderText = "Quantity";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "UnitPrice";
            this.dataGridViewTextBoxColumn5.HeaderText = "UnitPrice";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // comboBoxPurchaseId
            // 
            this.comboBoxPurchaseId.DataSource = this.purchasesBindingSource;
            this.comboBoxPurchaseId.DisplayMember = "PurchaseID";
            this.comboBoxPurchaseId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPurchaseId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxPurchaseId.FormattingEnabled = true;
            this.comboBoxPurchaseId.Location = new System.Drawing.Point(269, 99);
            this.comboBoxPurchaseId.Name = "comboBoxPurchaseId";
            this.comboBoxPurchaseId.Size = new System.Drawing.Size(275, 30);
            this.comboBoxPurchaseId.TabIndex = 53;
            this.comboBoxPurchaseId.ValueMember = "PurchaseID";
            // 
            // PurchaseDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1637, 759);
            this.Controls.Add(this.comboBoxPurchaseId);
            this.Controls.Add(this.purchaseDetailsDataGridView);
            this.Controls.Add(this.purchaseDetailsBindingNavigator);
            this.Controls.Add(this.buttonPurchases);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.MainLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PurchaseDetailsForm";
            this.Text = "Журнал покупок";
            this.Load += new System.EventHandler(this.PurchaseDetailsForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.componentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.computerCompanyDBDataSet)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.purchaseDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseDetailsBindingNavigator)).EndInit();
            this.purchaseDetailsBindingNavigator.ResumeLayout(false);
            this.purchaseDetailsBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fKPurchaseDPurch76969D2EBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchasesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseDetailsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MainLabel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button buttonComponents;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btFirst;
        public System.Windows.Forms.ComboBox comboBoxComponentId;
        private System.Windows.Forms.Button btLast;
        private System.Windows.Forms.Button btPrevious;
        private System.Windows.Forms.TextBox textBoxPurchaseDetailId;
        private System.Windows.Forms.Button btNext;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btRemove;
        private System.Windows.Forms.TextBox textBoxUnitPrice;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.Button buttonReport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonPurchases;
        private ComputerCompanyDBDataSet computerCompanyDBDataSet;
        private System.Windows.Forms.BindingSource purchaseDetailsBindingSource;
        private ComputerCompanyDBDataSetTableAdapters.PurchaseDetailsTableAdapter purchaseDetailsTableAdapter;
        private ComputerCompanyDBDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator purchaseDetailsBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton purchaseDetailsBindingNavigatorSaveItem;
        private ComputerCompanyDBDataSetTableAdapters.PurchasesTableAdapter purchasesTableAdapter;
        private System.Windows.Forms.DataGridView purchaseDetailsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.BindingSource purchasesBindingSource;
        private System.Windows.Forms.BindingSource fKPurchaseDPurch76969D2EBindingSource;
        private ComputerCompanyDBDataSetTableAdapters.ComponentsTableAdapter componentsTableAdapter;
        private System.Windows.Forms.BindingSource componentsBindingSource;
        public System.Windows.Forms.ComboBox comboBoxPurchaseId;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
    }
}