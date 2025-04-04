namespace ComputerCompany
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.MainLabel = new System.Windows.Forms.Label();
            this.buttonCategories = new System.Windows.Forms.Button();
            this.buttonPurchaseDetails = new System.Windows.Forms.Button();
            this.buttonPurchases = new System.Windows.Forms.Button();
            this.buttonSuppliers = new System.Windows.Forms.Button();
            this.buttonComponents = new System.Windows.Forms.Button();
            this.buttonFull = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(208, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(550, 25);
            this.label1.TabIndex = 15;
            this.label1.Text = "Информационная система закупки комплектующих";
            // 
            // MainLabel
            // 
            this.MainLabel.AutoSize = true;
            this.MainLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.MainLabel.Location = new System.Drawing.Point(346, 62);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(245, 25);
            this.MainLabel.TabIndex = 14;
            this.MainLabel.Text = "Компьютерная фирма";
            // 
            // buttonCategories
            // 
            this.buttonCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCategories.Location = new System.Drawing.Point(75, 373);
            this.buttonCategories.Name = "buttonCategories";
            this.buttonCategories.Size = new System.Drawing.Size(299, 58);
            this.buttonCategories.TabIndex = 20;
            this.buttonCategories.Text = "Категории";
            this.buttonCategories.UseVisualStyleBackColor = true;
            this.buttonCategories.Click += new System.EventHandler(this.buttonCategories_Click);
            // 
            // buttonPurchaseDetails
            // 
            this.buttonPurchaseDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPurchaseDetails.Location = new System.Drawing.Point(75, 283);
            this.buttonPurchaseDetails.Name = "buttonPurchaseDetails";
            this.buttonPurchaseDetails.Size = new System.Drawing.Size(299, 58);
            this.buttonPurchaseDetails.TabIndex = 19;
            this.buttonPurchaseDetails.Text = "Журнал покупок";
            this.buttonPurchaseDetails.UseVisualStyleBackColor = true;
            this.buttonPurchaseDetails.Click += new System.EventHandler(this.buttonPurchaseDetails_Click);
            // 
            // buttonPurchases
            // 
            this.buttonPurchases.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPurchases.Location = new System.Drawing.Point(75, 200);
            this.buttonPurchases.Name = "buttonPurchases";
            this.buttonPurchases.Size = new System.Drawing.Size(299, 58);
            this.buttonPurchases.TabIndex = 18;
            this.buttonPurchases.Text = "Покупки";
            this.buttonPurchases.UseVisualStyleBackColor = true;
            this.buttonPurchases.Click += new System.EventHandler(this.buttonPurchases_Click);
            // 
            // buttonSuppliers
            // 
            this.buttonSuppliers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSuppliers.Location = new System.Drawing.Point(544, 200);
            this.buttonSuppliers.Name = "buttonSuppliers";
            this.buttonSuppliers.Size = new System.Drawing.Size(299, 58);
            this.buttonSuppliers.TabIndex = 17;
            this.buttonSuppliers.Text = "Поставщики";
            this.buttonSuppliers.UseVisualStyleBackColor = true;
            this.buttonSuppliers.Click += new System.EventHandler(this.buttonSuppliers_Click);
            // 
            // buttonComponents
            // 
            this.buttonComponents.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonComponents.Location = new System.Drawing.Point(544, 283);
            this.buttonComponents.Name = "buttonComponents";
            this.buttonComponents.Size = new System.Drawing.Size(299, 58);
            this.buttonComponents.TabIndex = 16;
            this.buttonComponents.Text = "Комплектующие";
            this.buttonComponents.UseVisualStyleBackColor = true;
            this.buttonComponents.Click += new System.EventHandler(this.buttonComponents_Click);
            // 
            // buttonFull
            // 
            this.buttonFull.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonFull.Location = new System.Drawing.Point(544, 373);
            this.buttonFull.Name = "buttonFull";
            this.buttonFull.Size = new System.Drawing.Size(299, 58);
            this.buttonFull.TabIndex = 21;
            this.buttonFull.Text = "Полное окно";
            this.buttonFull.UseVisualStyleBackColor = true;
            this.buttonFull.Click += new System.EventHandler(this.buttonFull_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(915, 489);
            this.Controls.Add(this.buttonFull);
            this.Controls.Add(this.buttonCategories);
            this.Controls.Add(this.buttonPurchaseDetails);
            this.Controls.Add(this.buttonPurchases);
            this.Controls.Add(this.buttonSuppliers);
            this.Controls.Add(this.buttonComponents);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MainLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Информационная система закупки комплектующих";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label MainLabel;
        private System.Windows.Forms.Button buttonCategories;
        private System.Windows.Forms.Button buttonPurchaseDetails;
        private System.Windows.Forms.Button buttonPurchases;
        private System.Windows.Forms.Button buttonSuppliers;
        private System.Windows.Forms.Button buttonComponents;
        private System.Windows.Forms.Button buttonFull;
    }
}

