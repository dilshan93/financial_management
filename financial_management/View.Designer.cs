namespace financial_management
{
    partial class View
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
            this.dtgTransDataView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTransDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgTransDataView
            // 
            this.dtgTransDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTransDataView.Location = new System.Drawing.Point(149, 146);
            this.dtgTransDataView.Name = "dtgTransDataView";
            this.dtgTransDataView.RowHeadersWidth = 51;
            this.dtgTransDataView.Size = new System.Drawing.Size(432, 150);
            this.dtgTransDataView.TabIndex = 0;
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtgTransDataView);
            this.Name = "View";
            this.Text = "View";
            this.Load += new System.EventHandler(this.Load_View4);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTransDataView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dtgTransDataView;
    }
}