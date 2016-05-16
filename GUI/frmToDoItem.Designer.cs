namespace GUI
{
    partial class frmToDoItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmToDoItem));
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitleTitle = new System.Windows.Forms.Label();
            this.rtbBody = new System.Windows.Forms.RichTextBox();
            this.lblTitleBody = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtpPlanStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpPlanComplete = new System.Windows.Forms.DateTimePicker();
            this.lblCompleteTrue = new System.Windows.Forms.Label();
            this.lblStartTrue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(108, 12);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(356, 20);
            this.txtTitle.TabIndex = 0;
            this.txtTitle.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblTitleTitle
            // 
            this.lblTitleTitle.AutoSize = true;
            this.lblTitleTitle.Location = new System.Drawing.Point(9, 15);
            this.lblTitleTitle.Name = "lblTitleTitle";
            this.lblTitleTitle.Size = new System.Drawing.Size(27, 13);
            this.lblTitleTitle.TabIndex = 1;
            this.lblTitleTitle.Text = "Title";
            // 
            // rtbBody
            // 
            this.rtbBody.Location = new System.Drawing.Point(12, 55);
            this.rtbBody.Name = "rtbBody";
            this.rtbBody.Size = new System.Drawing.Size(452, 96);
            this.rtbBody.TabIndex = 2;
            this.rtbBody.Text = "";
            // 
            // lblTitleBody
            // 
            this.lblTitleBody.AutoSize = true;
            this.lblTitleBody.Location = new System.Drawing.Point(200, 39);
            this.lblTitleBody.Name = "lblTitleBody";
            this.lblTitleBody.Size = new System.Drawing.Size(31, 13);
            this.lblTitleBody.TabIndex = 3;
            this.lblTitleBody.Text = "Body";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(383, 199);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtpPlanStart
            // 
            this.dtpPlanStart.Location = new System.Drawing.Point(121, 153);
            this.dtpPlanStart.Name = "dtpPlanStart";
            this.dtpPlanStart.Size = new System.Drawing.Size(132, 20);
            this.dtpPlanStart.TabIndex = 5;
            this.dtpPlanStart.ValueChanged += new System.EventHandler(this.dtpPlanStart_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Plan Start Task";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Plan Complete Task";
            // 
            // dtpPlanComplete
            // 
            this.dtpPlanComplete.Location = new System.Drawing.Point(121, 179);
            this.dtpPlanComplete.Name = "dtpPlanComplete";
            this.dtpPlanComplete.Size = new System.Drawing.Size(132, 20);
            this.dtpPlanComplete.TabIndex = 7;
            this.dtpPlanComplete.ValueChanged += new System.EventHandler(this.dtpPlanComplet_ValueChanged);
            // 
            // lblCompleteTrue
            // 
            this.lblCompleteTrue.AutoSize = true;
            this.lblCompleteTrue.Location = new System.Drawing.Point(257, 182);
            this.lblCompleteTrue.Name = "lblCompleteTrue";
            this.lblCompleteTrue.Size = new System.Drawing.Size(96, 13);
            this.lblCompleteTrue.TabIndex = 10;
            this.lblCompleteTrue.Text = "Plan Complet Task";
            // 
            // lblStartTrue
            // 
            this.lblStartTrue.AutoSize = true;
            this.lblStartTrue.Location = new System.Drawing.Point(257, 156);
            this.lblStartTrue.Name = "lblStartTrue";
            this.lblStartTrue.Size = new System.Drawing.Size(80, 13);
            this.lblStartTrue.TabIndex = 9;
            this.lblStartTrue.Text = "Plan Start Task";
            // 
            // frmToDoItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 225);
            this.Controls.Add(this.lblCompleteTrue);
            this.Controls.Add(this.lblStartTrue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpPlanComplete);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpPlanStart);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTitleBody);
            this.Controls.Add(this.rtbBody);
            this.Controls.Add(this.lblTitleTitle);
            this.Controls.Add(this.txtTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmToDoItem";
            this.Text = "frmToDoItem";
            this.Load += new System.EventHandler(this.frmToDoItem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitleTitle;
        private System.Windows.Forms.RichTextBox rtbBody;
        private System.Windows.Forms.Label lblTitleBody;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtpPlanStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpPlanComplete;
        private System.Windows.Forms.Label lblCompleteTrue;
        private System.Windows.Forms.Label lblStartTrue;
    }
}