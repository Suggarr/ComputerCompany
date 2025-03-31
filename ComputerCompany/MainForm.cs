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
    public partial class MainForm : Form
    {
        PurchasesForm purchasesForm;
        PurchaseDetailsForm purhaseDetailsForm;
        ComponentsForm componentsForm;
        SuppliersForm suppliersForm;
        CategoriesForm categoriesForm;
        FullForm fullForm;
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonPurchases_Click(object sender, EventArgs e)
        {
            purchasesForm = new PurchasesForm();
            purchasesForm.ShowDialog();
        }

        private void buttonPurchaseDetails_Click(object sender, EventArgs e)
        {
            purhaseDetailsForm = new PurchaseDetailsForm();
            purhaseDetailsForm.ShowDialog();
        }

        private void buttonSuppliers_Click(object sender, EventArgs e)
        {
            suppliersForm = new SuppliersForm();
            suppliersForm.ShowDialog();
        }

        private void buttonComponents_Click(object sender, EventArgs e)
        {
            componentsForm = new ComponentsForm();
            componentsForm.ShowDialog();
        }

        private void buttonCategories_Click(object sender, EventArgs e)
        {
            categoriesForm = new CategoriesForm();
            categoriesForm.ShowDialog();
        }

        private void buttonFull_Click(object sender, EventArgs e)
        {
            fullForm = new FullForm();
            fullForm.ShowDialog();
        }
    }
}
