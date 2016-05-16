namespace GUI
{
    partial class frmMainScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainScreen));
            this.btnStartTime = new System.Windows.Forms.PictureBox();
            this.pcbNotStored = new System.Windows.Forms.PictureBox();
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tbpNotes = new System.Windows.Forms.TabPage();
            this.pnlFunctionButtons = new System.Windows.Forms.Panel();
            this.btnInsertURL = new System.Windows.Forms.Button();
            this.btnCodeInsert = new System.Windows.Forms.Button();
            this.btnInertError = new System.Windows.Forms.Button();
            this.pnlActionButtons = new System.Windows.Forms.Panel();
            this.pcbStored = new System.Windows.Forms.PictureBox();
            this.btnStopTime = new System.Windows.Forms.PictureBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnPauseTime = new System.Windows.Forms.PictureBox();
            this.rtbRecordBody = new System.Windows.Forms.RichTextBox();
            this.cmbNotesSubject = new System.Windows.Forms.ComboBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.cmbNotesCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.tbpHistory = new System.Windows.Forms.TabPage();
            this.wbHistory = new System.Windows.Forms.WebBrowser();
            this.cmbHistorySubject = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbHistoryCategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabTasks = new System.Windows.Forms.TabPage();
            this.lblDeadline = new System.Windows.Forms.Label();
            this.cmbToDoCategories = new System.Windows.Forms.ComboBox();
            this.pnlColumCompleted = new System.Windows.Forms.Panel();
            this.lblColumnTitleCompleted = new System.Windows.Forms.Label();
            this.pnlColumTesting = new System.Windows.Forms.Panel();
            this.lblColumnTitleTesting = new System.Windows.Forms.Label();
            this.pnlColumWorkingOn = new System.Windows.Forms.Panel();
            this.lblColumnTitleStart = new System.Windows.Forms.Label();
            this.pnlColumPlanning = new System.Windows.Forms.Panel();
            this.pcbAddStory = new System.Windows.Forms.PictureBox();
            this.lblColumnTitleStory = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnStartTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbNotStored)).BeginInit();
            this.tbcMain.SuspendLayout();
            this.tbpNotes.SuspendLayout();
            this.pnlFunctionButtons.SuspendLayout();
            this.pnlActionButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbStored)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStopTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPauseTime)).BeginInit();
            this.tbpHistory.SuspendLayout();
            this.tabTasks.SuspendLayout();
            this.pnlColumCompleted.SuspendLayout();
            this.pnlColumTesting.SuspendLayout();
            this.pnlColumWorkingOn.SuspendLayout();
            this.pnlColumPlanning.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbAddStory)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStartTime
            // 
            this.btnStartTime.Enabled = false;
            this.btnStartTime.Image = ((System.Drawing.Image)(resources.GetObject("btnStartTime.Image")));
            this.btnStartTime.Location = new System.Drawing.Point(141, 3);
            this.btnStartTime.Name = "btnStartTime";
            this.btnStartTime.Size = new System.Drawing.Size(16, 16);
            this.btnStartTime.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnStartTime.TabIndex = 7;
            this.btnStartTime.TabStop = false;
            this.btnStartTime.Click += new System.EventHandler(this.btnStartTime_Click);
            // 
            // pcbNotStored
            // 
            this.pcbNotStored.Enabled = false;
            this.pcbNotStored.Image = ((System.Drawing.Image)(resources.GetObject("pcbNotStored.Image")));
            this.pcbNotStored.Location = new System.Drawing.Point(184, 3);
            this.pcbNotStored.Name = "pcbNotStored";
            this.pcbNotStored.Size = new System.Drawing.Size(24, 24);
            this.pcbNotStored.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pcbNotStored.TabIndex = 12;
            this.pcbNotStored.TabStop = false;
            this.pcbNotStored.Visible = false;
            // 
            // tbcMain
            // 
            this.tbcMain.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tbcMain.Controls.Add(this.tbpNotes);
            this.tbcMain.Controls.Add(this.tbpHistory);
            this.tbcMain.Controls.Add(this.tabTasks);
            this.tbcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcMain.Location = new System.Drawing.Point(0, 0);
            this.tbcMain.Multiline = true;
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(1134, 462);
            this.tbcMain.TabIndex = 18;
            // 
            // tbpNotes
            // 
            this.tbpNotes.Controls.Add(this.pnlFunctionButtons);
            this.tbpNotes.Controls.Add(this.pnlActionButtons);
            this.tbpNotes.Controls.Add(this.rtbRecordBody);
            this.tbpNotes.Controls.Add(this.cmbNotesSubject);
            this.tbpNotes.Controls.Add(this.lblSubject);
            this.tbpNotes.Controls.Add(this.cmbNotesCategory);
            this.tbpNotes.Controls.Add(this.lblCategory);
            this.tbpNotes.Location = new System.Drawing.Point(23, 4);
            this.tbpNotes.Name = "tbpNotes";
            this.tbpNotes.Padding = new System.Windows.Forms.Padding(3);
            this.tbpNotes.Size = new System.Drawing.Size(1107, 454);
            this.tbpNotes.TabIndex = 0;
            this.tbpNotes.Text = "Notes";
            this.tbpNotes.UseVisualStyleBackColor = true;
            // 
            // pnlFunctionButtons
            // 
            this.pnlFunctionButtons.Controls.Add(this.btnInsertURL);
            this.pnlFunctionButtons.Controls.Add(this.btnCodeInsert);
            this.pnlFunctionButtons.Controls.Add(this.btnInertError);
            this.pnlFunctionButtons.Location = new System.Drawing.Point(799, 3);
            this.pnlFunctionButtons.Name = "pnlFunctionButtons";
            this.pnlFunctionButtons.Size = new System.Drawing.Size(284, 31);
            this.pnlFunctionButtons.TabIndex = 28;
            // 
            // btnInsertURL
            // 
            this.btnInsertURL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsertURL.Location = new System.Drawing.Point(206, 3);
            this.btnInsertURL.Name = "btnInsertURL";
            this.btnInsertURL.Size = new System.Drawing.Size(75, 23);
            this.btnInsertURL.TabIndex = 26;
            this.btnInsertURL.Text = "URL";
            this.btnInsertURL.UseVisualStyleBackColor = true;
            this.btnInsertURL.Visible = false;
            this.btnInsertURL.Click += new System.EventHandler(this.btnInsertURL_Click);
            // 
            // btnCodeInsert
            // 
            this.btnCodeInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCodeInsert.Location = new System.Drawing.Point(47, 3);
            this.btnCodeInsert.Name = "btnCodeInsert";
            this.btnCodeInsert.Size = new System.Drawing.Size(75, 23);
            this.btnCodeInsert.TabIndex = 24;
            this.btnCodeInsert.Text = "Code";
            this.btnCodeInsert.UseVisualStyleBackColor = true;
            this.btnCodeInsert.Visible = false;
            this.btnCodeInsert.Click += new System.EventHandler(this.btnCodeInsert_Click);
            // 
            // btnInertError
            // 
            this.btnInertError.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInertError.Location = new System.Drawing.Point(128, 3);
            this.btnInertError.Name = "btnInertError";
            this.btnInertError.Size = new System.Drawing.Size(75, 23);
            this.btnInertError.TabIndex = 25;
            this.btnInertError.Text = "Error";
            this.btnInertError.UseVisualStyleBackColor = true;
            this.btnInertError.Visible = false;
            this.btnInertError.Click += new System.EventHandler(this.btnInertError_Click);
            // 
            // pnlActionButtons
            // 
            this.pnlActionButtons.Controls.Add(this.pcbNotStored);
            this.pnlActionButtons.Controls.Add(this.pcbStored);
            this.pnlActionButtons.Controls.Add(this.btnStopTime);
            this.pnlActionButtons.Controls.Add(this.btnStartTime);
            this.pnlActionButtons.Controls.Add(this.lblStatus);
            this.pnlActionButtons.Controls.Add(this.btnPauseTime);
            this.pnlActionButtons.Location = new System.Drawing.Point(893, 424);
            this.pnlActionButtons.Name = "pnlActionButtons";
            this.pnlActionButtons.Size = new System.Drawing.Size(211, 29);
            this.pnlActionButtons.TabIndex = 27;
            // 
            // pcbStored
            // 
            this.pcbStored.Enabled = false;
            this.pcbStored.Image = ((System.Drawing.Image)(resources.GetObject("pcbStored.Image")));
            this.pcbStored.Location = new System.Drawing.Point(184, 3);
            this.pcbStored.Name = "pcbStored";
            this.pcbStored.Size = new System.Drawing.Size(24, 24);
            this.pcbStored.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pcbStored.TabIndex = 22;
            this.pcbStored.TabStop = false;
            this.pcbStored.Visible = false;
            // 
            // btnStopTime
            // 
            this.btnStopTime.Enabled = false;
            this.btnStopTime.Image = ((System.Drawing.Image)(resources.GetObject("btnStopTime.Image")));
            this.btnStopTime.Location = new System.Drawing.Point(162, 3);
            this.btnStopTime.Name = "btnStopTime";
            this.btnStopTime.Size = new System.Drawing.Size(16, 16);
            this.btnStopTime.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnStopTime.TabIndex = 20;
            this.btnStopTime.TabStop = false;
            this.btnStopTime.Visible = false;
            this.btnStopTime.Click += new System.EventHandler(this.btnStopTime_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(3, 6);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(35, 13);
            this.lblStatus.TabIndex = 23;
            this.lblStatus.Text = "label1";
            // 
            // btnPauseTime
            // 
            this.btnPauseTime.Enabled = false;
            this.btnPauseTime.Image = ((System.Drawing.Image)(resources.GetObject("btnPauseTime.Image")));
            this.btnPauseTime.Location = new System.Drawing.Point(141, 3);
            this.btnPauseTime.Name = "btnPauseTime";
            this.btnPauseTime.Size = new System.Drawing.Size(16, 16);
            this.btnPauseTime.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnPauseTime.TabIndex = 19;
            this.btnPauseTime.TabStop = false;
            this.btnPauseTime.Visible = false;
            this.btnPauseTime.Click += new System.EventHandler(this.btnPauseTime_Click);
            // 
            // rtbRecordBody
            // 
            this.rtbRecordBody.EnableAutoDragDrop = true;
            this.rtbRecordBody.Enabled = false;
            this.rtbRecordBody.Location = new System.Drawing.Point(6, 40);
            this.rtbRecordBody.Name = "rtbRecordBody";
            this.rtbRecordBody.Size = new System.Drawing.Size(1077, 386);
            this.rtbRecordBody.TabIndex = 21;
            this.rtbRecordBody.Text = "";
            this.rtbRecordBody.TextChanged += new System.EventHandler(this.rtbRecordBody_TextChanged);
            this.rtbRecordBody.Leave += new System.EventHandler(this.rtbRecordBody_Leave);
            // 
            // cmbNotesSubject
            // 
            this.cmbNotesSubject.FormattingEnabled = true;
            this.cmbNotesSubject.Location = new System.Drawing.Point(239, 9);
            this.cmbNotesSubject.Name = "cmbNotesSubject";
            this.cmbNotesSubject.Size = new System.Drawing.Size(228, 21);
            this.cmbNotesSubject.TabIndex = 18;
            this.cmbNotesSubject.SelectedIndexChanged += new System.EventHandler(this.cmbNoteSubject_SelectedIndexChanged);
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(190, 12);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(43, 13);
            this.lblSubject.TabIndex = 17;
            this.lblSubject.Text = "Subject";
            // 
            // cmbNotesCategory
            // 
            this.cmbNotesCategory.FormattingEnabled = true;
            this.cmbNotesCategory.Location = new System.Drawing.Point(63, 9);
            this.cmbNotesCategory.Name = "cmbNotesCategory";
            this.cmbNotesCategory.Size = new System.Drawing.Size(121, 21);
            this.cmbNotesCategory.TabIndex = 16;
            this.cmbNotesCategory.SelectedIndexChanged += new System.EventHandler(this.cmbNotesCategory_SelectedIndexChanged);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(11, 12);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(49, 13);
            this.lblCategory.TabIndex = 15;
            this.lblCategory.Text = "Category";
            // 
            // tbpHistory
            // 
            this.tbpHistory.Controls.Add(this.wbHistory);
            this.tbpHistory.Controls.Add(this.cmbHistorySubject);
            this.tbpHistory.Controls.Add(this.label1);
            this.tbpHistory.Controls.Add(this.cmbHistoryCategory);
            this.tbpHistory.Controls.Add(this.label2);
            this.tbpHistory.Location = new System.Drawing.Point(23, 4);
            this.tbpHistory.Name = "tbpHistory";
            this.tbpHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tbpHistory.Size = new System.Drawing.Size(1107, 454);
            this.tbpHistory.TabIndex = 1;
            this.tbpHistory.Text = "History";
            this.tbpHistory.UseVisualStyleBackColor = true;
            // 
            // wbHistory
            // 
            this.wbHistory.Location = new System.Drawing.Point(8, 27);
            this.wbHistory.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbHistory.Name = "wbHistory";
            this.wbHistory.Size = new System.Drawing.Size(1090, 419);
            this.wbHistory.TabIndex = 14;
            // 
            // cmbHistorySubject
            // 
            this.cmbHistorySubject.FormattingEnabled = true;
            this.cmbHistorySubject.Location = new System.Drawing.Point(323, 3);
            this.cmbHistorySubject.Name = "cmbHistorySubject";
            this.cmbHistorySubject.Size = new System.Drawing.Size(228, 21);
            this.cmbHistorySubject.TabIndex = 13;
            this.cmbHistorySubject.SelectedIndexChanged += new System.EventHandler(this.cmbHistorySubject_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(274, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Subject";
            // 
            // cmbHistoryCategory
            // 
            this.cmbHistoryCategory.FormattingEnabled = true;
            this.cmbHistoryCategory.Location = new System.Drawing.Point(61, 3);
            this.cmbHistoryCategory.Name = "cmbHistoryCategory";
            this.cmbHistoryCategory.Size = new System.Drawing.Size(191, 21);
            this.cmbHistoryCategory.TabIndex = 11;
            this.cmbHistoryCategory.SelectedIndexChanged += new System.EventHandler(this.cmbHistoryCategory_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Category";
            // 
            // tabTasks
            // 
            this.tabTasks.Controls.Add(this.lblDeadline);
            this.tabTasks.Controls.Add(this.cmbToDoCategories);
            this.tabTasks.Controls.Add(this.pnlColumCompleted);
            this.tabTasks.Controls.Add(this.pnlColumTesting);
            this.tabTasks.Controls.Add(this.pnlColumWorkingOn);
            this.tabTasks.Controls.Add(this.pnlColumPlanning);
            this.tabTasks.Location = new System.Drawing.Point(23, 4);
            this.tabTasks.Name = "tabTasks";
            this.tabTasks.Padding = new System.Windows.Forms.Padding(3);
            this.tabTasks.Size = new System.Drawing.Size(1107, 454);
            this.tabTasks.TabIndex = 2;
            this.tabTasks.Text = "Tasks";
            this.tabTasks.UseVisualStyleBackColor = true;
            // 
            // lblDeadline
            // 
            this.lblDeadline.AutoSize = true;
            this.lblDeadline.Location = new System.Drawing.Point(290, 6);
            this.lblDeadline.Name = "lblDeadline";
            this.lblDeadline.Size = new System.Drawing.Size(64, 13);
            this.lblDeadline.TabIndex = 25;
            this.lblDeadline.Text = "Working On";
            // 
            // cmbToDoCategories
            // 
            this.cmbToDoCategories.FormattingEnabled = true;
            this.cmbToDoCategories.Location = new System.Drawing.Point(11, 3);
            this.cmbToDoCategories.Name = "cmbToDoCategories";
            this.cmbToDoCategories.Size = new System.Drawing.Size(273, 21);
            this.cmbToDoCategories.TabIndex = 23;
            this.cmbToDoCategories.SelectedIndexChanged += new System.EventHandler(this.cmbCategories_SelectedIndexChanged);
            // 
            // pnlColumCompleted
            // 
            this.pnlColumCompleted.AutoScroll = true;
            this.pnlColumCompleted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlColumCompleted.Controls.Add(this.lblColumnTitleCompleted);
            this.pnlColumCompleted.Location = new System.Drawing.Point(824, 33);
            this.pnlColumCompleted.Name = "pnlColumCompleted";
            this.pnlColumCompleted.Size = new System.Drawing.Size(269, 385);
            this.pnlColumCompleted.TabIndex = 8;
            // 
            // lblColumnTitleCompleted
            // 
            this.lblColumnTitleCompleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnTitleCompleted.Location = new System.Drawing.Point(3, 3);
            this.lblColumnTitleCompleted.Name = "lblColumnTitleCompleted";
            this.lblColumnTitleCompleted.Size = new System.Drawing.Size(261, 16);
            this.lblColumnTitleCompleted.TabIndex = 5;
            this.lblColumnTitleCompleted.Text = "Completed";
            this.lblColumnTitleCompleted.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlColumTesting
            // 
            this.pnlColumTesting.AutoScroll = true;
            this.pnlColumTesting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlColumTesting.Controls.Add(this.lblColumnTitleTesting);
            this.pnlColumTesting.Location = new System.Drawing.Point(553, 33);
            this.pnlColumTesting.Name = "pnlColumTesting";
            this.pnlColumTesting.Size = new System.Drawing.Size(269, 385);
            this.pnlColumTesting.TabIndex = 7;
            // 
            // lblColumnTitleTesting
            // 
            this.lblColumnTitleTesting.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnTitleTesting.Location = new System.Drawing.Point(3, 3);
            this.lblColumnTitleTesting.Name = "lblColumnTitleTesting";
            this.lblColumnTitleTesting.Size = new System.Drawing.Size(261, 16);
            this.lblColumnTitleTesting.TabIndex = 5;
            this.lblColumnTitleTesting.Text = "Testing";
            this.lblColumnTitleTesting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlColumWorkingOn
            // 
            this.pnlColumWorkingOn.AutoScroll = true;
            this.pnlColumWorkingOn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlColumWorkingOn.Controls.Add(this.lblColumnTitleStart);
            this.pnlColumWorkingOn.Location = new System.Drawing.Point(282, 33);
            this.pnlColumWorkingOn.Name = "pnlColumWorkingOn";
            this.pnlColumWorkingOn.Size = new System.Drawing.Size(269, 385);
            this.pnlColumWorkingOn.TabIndex = 6;
            // 
            // lblColumnTitleStart
            // 
            this.lblColumnTitleStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnTitleStart.Location = new System.Drawing.Point(3, 3);
            this.lblColumnTitleStart.Name = "lblColumnTitleStart";
            this.lblColumnTitleStart.Size = new System.Drawing.Size(261, 16);
            this.lblColumnTitleStart.TabIndex = 5;
            this.lblColumnTitleStart.Text = "Started On";
            this.lblColumnTitleStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlColumPlanning
            // 
            this.pnlColumPlanning.AutoScroll = true;
            this.pnlColumPlanning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlColumPlanning.Controls.Add(this.pcbAddStory);
            this.pnlColumPlanning.Controls.Add(this.lblColumnTitleStory);
            this.pnlColumPlanning.Location = new System.Drawing.Point(11, 33);
            this.pnlColumPlanning.Name = "pnlColumPlanning";
            this.pnlColumPlanning.Size = new System.Drawing.Size(269, 385);
            this.pnlColumPlanning.TabIndex = 5;
            // 
            // pcbAddStory
            // 
            this.pcbAddStory.Image = global::GUI.Properties.Resources.Cinema_Add_Ticket_icon;
            this.pcbAddStory.Location = new System.Drawing.Point(240, 2);
            this.pcbAddStory.Name = "pcbAddStory";
            this.pcbAddStory.Size = new System.Drawing.Size(21, 16);
            this.pcbAddStory.TabIndex = 26;
            this.pcbAddStory.TabStop = false;
            this.pcbAddStory.Click += new System.EventHandler(this.btnAddNewTask_Click);
            // 
            // lblColumnTitleStory
            // 
            this.lblColumnTitleStory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnTitleStory.Location = new System.Drawing.Point(3, 3);
            this.lblColumnTitleStory.Name = "lblColumnTitleStory";
            this.lblColumnTitleStory.Size = new System.Drawing.Size(261, 16);
            this.lblColumnTitleStory.TabIndex = 5;
            this.lblColumnTitleStory.Text = "Story to Do";
            this.lblColumnTitleStory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 462);
            this.Controls.Add(this.tbcMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(595, 228);
            this.Name = "frmMainScreen";
            this.Text = "DigiNote";
            this.Load += new System.EventHandler(this.frmMainScreen_Load);
            this.Resize += new System.EventHandler(this.frmMainScreen_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.btnStartTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbNotStored)).EndInit();
            this.tbcMain.ResumeLayout(false);
            this.tbpNotes.ResumeLayout(false);
            this.tbpNotes.PerformLayout();
            this.pnlFunctionButtons.ResumeLayout(false);
            this.pnlActionButtons.ResumeLayout(false);
            this.pnlActionButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbStored)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStopTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPauseTime)).EndInit();
            this.tbpHistory.ResumeLayout(false);
            this.tbpHistory.PerformLayout();
            this.tabTasks.ResumeLayout(false);
            this.tabTasks.PerformLayout();
            this.pnlColumCompleted.ResumeLayout(false);
            this.pnlColumTesting.ResumeLayout(false);
            this.pnlColumWorkingOn.ResumeLayout(false);
            this.pnlColumPlanning.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbAddStory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox btnStartTime;
        private System.Windows.Forms.PictureBox pcbNotStored;
        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tbpNotes;
        private System.Windows.Forms.TabPage tbpHistory;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.PictureBox pcbStored;
        private System.Windows.Forms.RichTextBox rtbRecordBody;
        private System.Windows.Forms.PictureBox btnStopTime;
        private System.Windows.Forms.PictureBox btnPauseTime;
        private System.Windows.Forms.ComboBox cmbNotesSubject;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.ComboBox cmbNotesCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Button btnInsertURL;
        private System.Windows.Forms.Button btnInertError;
        private System.Windows.Forms.Button btnCodeInsert;
        private System.Windows.Forms.TabPage tabTasks;
        private System.Windows.Forms.Panel pnlColumCompleted;
        private System.Windows.Forms.Label lblColumnTitleCompleted;
        private System.Windows.Forms.Panel pnlColumTesting;
        private System.Windows.Forms.Label lblColumnTitleTesting;
        private System.Windows.Forms.Panel pnlColumWorkingOn;
        private System.Windows.Forms.Label lblColumnTitleStart;
        private System.Windows.Forms.Panel pnlColumPlanning;
        private System.Windows.Forms.Label lblColumnTitleStory;
        private System.Windows.Forms.Label lblDeadline;
        private System.Windows.Forms.ComboBox cmbToDoCategories;
        private System.Windows.Forms.PictureBox pcbAddStory;
        private System.Windows.Forms.ComboBox cmbHistorySubject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbHistoryCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.WebBrowser wbHistory;
        private System.Windows.Forms.Panel pnlActionButtons;
        private System.Windows.Forms.Panel pnlFunctionButtons;
    }
}

