namespace GUI
{
    partial class frmNewSubject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewSubject));
            this.txtSub = new System.Windows.Forms.TextBox();
            this.btnCategoryAdd = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnCategoryAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSub
            // 
            this.txtSub.Location = new System.Drawing.Point(12, 11);
            this.txtSub.Name = "txtSub";
            this.txtSub.Size = new System.Drawing.Size(286, 20);
            this.txtSub.TabIndex = 0;
            // 
            // btnCategoryAdd
            // 
            this.btnCategoryAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnCategoryAdd.Image")));
            this.btnCategoryAdd.Location = new System.Drawing.Point(304, 7);
            this.btnCategoryAdd.Name = "btnCategoryAdd";
            this.btnCategoryAdd.Size = new System.Drawing.Size(24, 24);
            this.btnCategoryAdd.TabIndex = 3;
            this.btnCategoryAdd.TabStop = false;
            this.btnCategoryAdd.Click += new System.EventHandler(this.btnCategoryAdd_Click);
            // 
            // frmNewSubject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 43);
            this.Controls.Add(this.btnCategoryAdd);
            this.Controls.Add(this.txtSub);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNewSubject";
            this.Text = "Digital Diary - New Subject";
            ((System.ComponentModel.ISupportInitialize)(this.btnCategoryAdd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSub;
        private System.Windows.Forms.PictureBox btnCategoryAdd;
    }
}