namespace GUI
{
    partial class frmNewCat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewCat));
            this.btnCategoryAdd = new System.Windows.Forms.PictureBox();
            this.txtCat = new System.Windows.Forms.TextBox();
            this.lblDeadline = new System.Windows.Forms.Label();
            this.dtpPlanDeadline = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.btnCategoryAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCategoryAdd
            // 
            this.btnCategoryAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnCategoryAdd.Image")));
            this.btnCategoryAdd.Location = new System.Drawing.Point(304, 34);
            this.btnCategoryAdd.Name = "btnCategoryAdd";
            this.btnCategoryAdd.Size = new System.Drawing.Size(24, 24);
            this.btnCategoryAdd.TabIndex = 5;
            this.btnCategoryAdd.TabStop = false;
            this.btnCategoryAdd.Click += new System.EventHandler(this.btnCategoryAdd_Click);
            // 
            // txtCat
            // 
            this.txtCat.Location = new System.Drawing.Point(12, 12);
            this.txtCat.Name = "txtCat";
            this.txtCat.Size = new System.Drawing.Size(286, 20);
            this.txtCat.TabIndex = 4;
            // 
            // lblDeadline
            // 
            this.lblDeadline.AutoSize = true;
            this.lblDeadline.Location = new System.Drawing.Point(14, 39);
            this.lblDeadline.Name = "lblDeadline";
            this.lblDeadline.Size = new System.Drawing.Size(49, 13);
            this.lblDeadline.TabIndex = 8;
            this.lblDeadline.Text = "Deadline";
            // 
            // dtpPlanDeadline
            // 
            this.dtpPlanDeadline.Location = new System.Drawing.Point(123, 36);
            this.dtpPlanDeadline.Name = "dtpPlanDeadline";
            this.dtpPlanDeadline.Size = new System.Drawing.Size(132, 20);
            this.dtpPlanDeadline.TabIndex = 7;
            // 
            // frmNewCat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 58);
            this.Controls.Add(this.lblDeadline);
            this.Controls.Add(this.dtpPlanDeadline);
            this.Controls.Add(this.btnCategoryAdd);
            this.Controls.Add(this.txtCat);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNewCat";
            this.Text = "Digital Diary - New Category";
            this.Load += new System.EventHandler(this.frmNewCat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnCategoryAdd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox btnCategoryAdd;
        private System.Windows.Forms.TextBox txtCat;
        private System.Windows.Forms.Label lblDeadline;
        private System.Windows.Forms.DateTimePicker dtpPlanDeadline;
    }
}