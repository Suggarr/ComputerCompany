namespace ComputerCompany
{
    partial class ReportForm
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
            this.computerCompanyDBDataSet = new ComputerCompany.ComputerCompanyDBDataSet();
            this.getPurchaseDetailsForSuppliersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.getPurchaseDetailsForSuppliersTableAdapter = new ComputerCompany.ComputerCompanyDBDataSetTableAdapters.GetPurchaseDetailsForSuppliersTableAdapter();
            this.tableAdapterManager = new ComputerCompany.ComputerCompanyDBDataSetTableAdapters.TableAdapterManager();
            this.getFilteredPurchasesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.getFilteredPurchasesTableAdapter = new ComputerCompany.ComputerCompanyDBDataSetTableAdapters.GetFilteredPurchasesTableAdapter();
            this.reportViewerMain = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.computerCompanyDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getPurchaseDetailsForSuppliersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getFilteredPurchasesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // computerCompanyDBDataSet
            // 
            this.computerCompanyDBDataSet.DataSetName = "ComputerCompanyDBDataSet";
            this.computerCompanyDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // getPurchaseDetailsForSuppliersBindingSource
            // 
            this.getPurchaseDetailsForSuppliersBindingSource.DataMember = "GetPurchaseDetailsForSuppliers";
            this.getPurchaseDetailsForSuppliersBindingSource.DataSource = this.computerCompanyDBDataSet;
            // 
            // getPurchaseDetailsForSuppliersTableAdapter
            // 
            this.getPurchaseDetailsForSuppliersTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CategoriesTableAdapter = null;
            this.tableAdapterManager.ComponentsTableAdapter = null;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.PurchaseDetailsTableAdapter = null;
            this.tableAdapterManager.PurchasesTableAdapter = null;
            this.tableAdapterManager.SuppliersTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = ComputerCompany.ComputerCompanyDBDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // getFilteredPurchasesBindingSource
            // 
            this.getFilteredPurchasesBindingSource.DataMember = "GetFilteredPurchases";
            this.getFilteredPurchasesBindingSource.DataSource = this.computerCompanyDBDataSet;
            // 
            // getFilteredPurchasesTableAdapter
            // 
            this.getFilteredPurchasesTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewerMain
            // 
            this.reportViewerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerMain.Location = new System.Drawing.Point(0, 0);
            this.reportViewerMain.Name = "reportViewerMain";
            this.reportViewerMain.ServerReport.BearerToken = null;
            this.reportViewerMain.Size = new System.Drawing.Size(1256, 576);
            this.reportViewerMain.TabIndex = 0;
            this.reportViewerMain.ReportExport += new Microsoft.Reporting.WinForms.ExportEventHandler(this.reportViewer_ReportExport);
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 576);
            this.Controls.Add(this.reportViewerMain);
            this.Name = "ReportForm";
            this.Text = "Окно отчета";
            this.Load += new System.EventHandler(this.ReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.computerCompanyDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getPurchaseDetailsForSuppliersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getFilteredPurchasesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ComputerCompanyDBDataSet computerCompanyDBDataSet;
        private System.Windows.Forms.BindingSource getPurchaseDetailsForSuppliersBindingSource;
        private ComputerCompanyDBDataSetTableAdapters.GetPurchaseDetailsForSuppliersTableAdapter getPurchaseDetailsForSuppliersTableAdapter;
        private ComputerCompanyDBDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource getFilteredPurchasesBindingSource;
        private ComputerCompanyDBDataSetTableAdapters.GetFilteredPurchasesTableAdapter getFilteredPurchasesTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerMain;
    }
}