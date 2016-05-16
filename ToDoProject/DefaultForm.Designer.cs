 namespace ToDoProject

{
    partial class DefaultForm
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
            this.pnlColumn = new System.Windows.Forms.Panel();
            this.lblColumnTitle = new System.Windows.Forms.Label();
            this.pnlItem = new System.Windows.Forms.Panel();
            this.lblItemStart = new System.Windows.Forms.Label();
            this.lblItemDesciption = new System.Windows.Forms.Label();
            this.lblItemTitle = new System.Windows.Forms.Label();
            this.pnlColumn.SuspendLayout();
            this.pnlItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlColumn
            // 
            this.pnlColumn.AutoScroll = true;
            this.pnlColumn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlColumn.Controls.Add(this.lblColumnTitle);
            this.pnlColumn.Controls.Add(this.pnlItem);
            this.pnlColumn.Location = new System.Drawing.Point(29, 12);
            this.pnlColumn.Name = "pnlColumn";
            this.pnlColumn.Size = new System.Drawing.Size(269, 354);
            this.pnlColumn.TabIndex = 5;
            // 
            // lblColumnTitle
            // 
            this.lblColumnTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnTitle.Location = new System.Drawing.Point(3, 3);
            this.lblColumnTitle.Name = "lblColumnTitle";
            this.lblColumnTitle.Size = new System.Drawing.Size(261, 16);
            this.lblColumnTitle.TabIndex = 5;
            this.lblColumnTitle.Text = "Title";
            this.lblColumnTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlItem
            // 
            this.pnlItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlItem.Controls.Add(this.lblItemStart);
            this.pnlItem.Controls.Add(this.lblItemDesciption);
            this.pnlItem.Controls.Add(this.lblItemTitle);
            this.pnlItem.Location = new System.Drawing.Point(3, 22);
            this.pnlItem.Name = "pnlItem";
            this.pnlItem.Size = new System.Drawing.Size(261, 77);
            this.pnlItem.TabIndex = 6;
            // 
            // lblItemStart
            // 
            this.lblItemStart.AutoSize = true;
            this.lblItemStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemStart.Location = new System.Drawing.Point(3, 59);
            this.lblItemStart.Name = "lblItemStart";
            this.lblItemStart.Size = new System.Drawing.Size(88, 13);
            this.lblItemStart.TabIndex = 7;
            this.lblItemStart.Text = "Planned Start ";
            // 
            // lblItemDesciption
            // 
            this.lblItemDesciption.AutoEllipsis = true;
            this.lblItemDesciption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemDesciption.Location = new System.Drawing.Point(2, 23);
            this.lblItemDesciption.Name = "lblItemDesciption";
            this.lblItemDesciption.Size = new System.Drawing.Size(245, 31);
            this.lblItemDesciption.TabIndex = 6;
            this.lblItemDesciption.Text = "Item Desciption";
            // 
            // lblItemTitle
            // 
            this.lblItemTitle.AutoEllipsis = true;
            this.lblItemTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemTitle.Location = new System.Drawing.Point(2, 2);
            this.lblItemTitle.Name = "lblItemTitle";
            this.lblItemTitle.Size = new System.Drawing.Size(245, 15);
            this.lblItemTitle.TabIndex = 5;
            this.lblItemTitle.Text = "Item Title";
            // 
            // DefaultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 453);
            this.Controls.Add(this.pnlColumn);
            this.Name = "DefaultForm";
            this.Text = "DefaultForm";
            this.pnlColumn.ResumeLayout(false);
            this.pnlItem.ResumeLayout(false);
            this.pnlItem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlColumn;
        private System.Windows.Forms.Label lblColumnTitle;
        private System.Windows.Forms.Panel pnlItem;
        private System.Windows.Forms.Label lblItemStart;
        private System.Windows.Forms.Label lblItemDesciption;
        private System.Windows.Forms.Label lblItemTitle;
    }
}