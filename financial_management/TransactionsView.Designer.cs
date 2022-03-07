namespace financial_management
{
    partial class TransactionsView
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
            this.btnCreateTransaction = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreateTransaction
            // 
            this.btnCreateTransaction.Location = new System.Drawing.Point(568, 104);
            this.btnCreateTransaction.Name = "btnCreateTransaction";
            this.btnCreateTransaction.Size = new System.Drawing.Size(144, 68);
            this.btnCreateTransaction.TabIndex = 0;
            this.btnCreateTransaction.Text = "Create Transaction";
            this.btnCreateTransaction.UseVisualStyleBackColor = true;
            this.btnCreateTransaction.Click += new System.EventHandler(this.OpenTransaction_Save);
            // 
            // TransactionsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCreateTransaction);
            this.Name = "TransactionsView";
            this.Text = "TransactionsView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateTransaction;
    }
}