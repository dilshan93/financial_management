namespace financial_management
{
    partial class DashBordView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCategories = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnTransaction = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCategories);
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Controls.Add(this.btnTransaction);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 437);
            this.panel1.TabIndex = 0;
            // 
            // btnCategories
            // 
            this.btnCategories.Location = new System.Drawing.Point(265, 231);
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.Size = new System.Drawing.Size(180, 51);
            this.btnCategories.TabIndex = 2;
            this.btnCategories.Text = "Categories";
            this.btnCategories.UseVisualStyleBackColor = true;
            this.btnCategories.Click += new System.EventHandler(this.OpenCategory);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(265, 141);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(180, 51);
            this.btnView.TabIndex = 1;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.OpenView);
            // 
            // btnTransaction
            // 
            this.btnTransaction.Location = new System.Drawing.Point(265, 49);
            this.btnTransaction.Name = "btnTransaction";
            this.btnTransaction.Size = new System.Drawing.Size(180, 51);
            this.btnTransaction.TabIndex = 0;
            this.btnTransaction.Text = "Transactions";
            this.btnTransaction.UseVisualStyleBackColor = true;
            this.btnTransaction.Click += new System.EventHandler(this.OpenTransactions);
            // 
            // DashBordView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "DashBordView";
            this.Text = "DashBordView";
            this.Load += new System.EventHandler(this.Add_InitialData);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnTransaction;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnCategories;
    }
}