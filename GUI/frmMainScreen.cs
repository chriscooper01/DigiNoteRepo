using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmMainScreen : Form
    {
        private int categoryId { get; set; }
        private int toDoCategoryId { get; set; }
        private int subjectId { get; set; }
        private int recordId { get; set; }
        private bool textChanged { get; set; }
        private bool timePaused { get; set; }
        private Stopwatch time { get; set; }
        public frmMainScreen()
        {
            try
            {
                InitializeComponent();


                lblDeadline.Text = String.Empty;
                            lblStatus.Text = String.Empty;

             
              
                rtbRecordBody.LostFocus += new EventHandler(rtbRecordBody_Leave);
                rtbRecordBody.DragDrop += new DragEventHandler(ToDoProject.DataFiles.RichTextBox_DragDrop);
                rtbRecordBody.AllowDrop = true;


                btnStartTime.Visible = false;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message+e.StackTrace);
                this.Close();
            }
            
        }


       



        private void btnCategoryAdd_Click(object sender, EventArgs e)
        {
            frmNewCat cat = new frmNewCat();
            cat.ShowDialog();
            Model.DiarySDF.Queries.CategoryQuery.Store(cat.Body.Trim());
            FormComponents.PopulateDefaultData.SetNoteCatList(categoryId);

        }



      
        private void btnSubjectAdd_Click(object sender, EventArgs e)
        {
            
            
        }

        private void btnStartTime_Click(object sender, EventArgs e)
        {

            startNote();
        }

        private  void startNote()
        {
            if (cmbNotesCategory.SelectedItem != null && cmbNotesSubject.SelectedItem != null)
            {
                if (!timePaused || time == null)
                {
                    time = new Stopwatch();
                    var cat = (Model.UniversalDataClasses.ListItem)cmbNotesCategory.SelectedItem;
                    var sub = (Model.UniversalDataClasses.ListItem)cmbNotesSubject.SelectedItem;
                    categoryId = cat.Id;
                    subjectId = sub.Id;
                    recordId = Model.DiarySDF.Queries.RecordQuery.Create(cat.Id, sub.Id);

                }
                time.Start();
                lblStatus.Text = String.Empty;

                rtbRecordBody.Enabled = true;
                btnPauseTime.Enabled = true;
                btnStopTime.Enabled = true;
                btnPauseTime.Visible = true;
                btnStopTime.Visible = true;


                btnCodeInsert.Visible = true;
                btnCodeInsert.Enabled = true;
                btnInertError.Visible = true;
                btnInertError.Enabled = true;
                btnInsertURL.Visible = true;
                btnInsertURL.Enabled = true;

                btnStartTime.Enabled = false;
                btnStartTime.Visible = false;
            }

            rtbRecordBody.Text = String.Empty;
            textChanged = false;
        }

        private void rtbRecordBody_Leave(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(rtbRecordBody.Text) && recordId > 0 && textChanged)
            {
                Model.DiarySDF.Queries.RecordQuery.Update(recordId, rtbRecordBody.Text, time.ElapsedMilliseconds);
                textChanged = false;
                pcbNotStored.Visible = false;
                pcbStored.Visible = true;
                
            }
        }

        private void cmbNotesCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNotesCategory.SelectedItem != null)
            {
             //   storeRecord();
                stopRecordingote();
                btnStartTime.Enabled = true;
                var item = (ComboBox)sender;
                var cat = (Model.UniversalDataClasses.ListItem)item.SelectedItem;
                if(!cat.Id.Equals(-1))
                {
                    categoryId = cat.Id;
                    
                    FormComponents.PopulateDefaultData.SetNoteSubjectList(-1,categoryId,subjectId);
                    btnStartTime.Visible = false;
                    btnCodeInsert.Visible = false;
                    btnCodeInsert.Enabled = false;
                    btnInertError.Visible = false;
                    btnInertError.Enabled = false;
                    btnInsertURL.Visible = false;
                    btnInsertURL.Enabled = false;
                    cmbNotesSubject.Enabled = true;
                }
                else
                {
                    cmbNotesSubject.Enabled = false;
                    categoryId = 0;
                    subjectId = 0;
                    cmbNotesSubject.Items.Clear();
                    cmbNotesCategory.Items.Clear();
                    frmNewCat frm = new frmNewCat();
                    frm.ShowDialog();
                    if(frm.Body !=null)
                        categoryId =    Model.DiarySDF.Queries.CategoryQuery.Store(frm.Body.Trim());

                    FormComponents.PopulateDefaultData.SetNoteCatList(categoryId);

                    btnStartTime.Visible = false;
                    btnCodeInsert.Visible = false;
                    btnCodeInsert.Enabled = false;
                    btnInertError.Visible = false;
                    btnInertError.Enabled = false;
                    btnInsertURL.Visible = false;
                    btnInsertURL.Enabled = false;

                }



            }
            else
            {
                cmbNotesSubject.Enabled = false;
                
            }


        }

        private void cmbNoteSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNotesCategory.SelectedItem != null && cmbNotesSubject.SelectedItem != null)
            {

             //   storeRecord();
                stopRecordingote();
                var sub = (Model.UniversalDataClasses.ListItem)cmbNotesSubject.SelectedItem;
                
                if (!sub.Id.Equals(-1))
                {
                    subjectId = sub.Id;
                    //setSubjectList(subjectId);
                    btnStartTime.Enabled = true;
                    btnStartTime.Visible = true;
                    btnCodeInsert.Visible = false;
                    btnCodeInsert.Enabled = false;
                    btnInertError.Visible = false;
                    btnInertError.Enabled = false;
                    btnInsertURL.Visible = false;
                    btnInsertURL.Enabled = false;


                    startNote();
                }
                else
                {
                    frmNewSubject subfrm = new frmNewSubject();
                    subfrm.ShowDialog();
                    if (subfrm.Body != null)
                        subjectId = Model.DiarySDF.Queries.SubjectQuery.Store(subfrm.Body.Trim(), categoryId);
                    
                    FormComponents.PopulateDefaultData.SetNoteSubjectList(subjectId, categoryId, subjectId);
                    btnStartTime.Visible = true;


                    btnCodeInsert.Visible = false;
                    btnCodeInsert.Enabled = false;
                    btnInertError.Visible = false;
                    btnInertError.Enabled = false;
                    btnInsertURL.Visible = false;
                    btnInsertURL.Enabled = false;


                }

            }




        }

        private void cmbHistoryCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cmbHistoryCategory.SelectedItem != null)
            {                
                var item = (ComboBox)sender;
                var cat = (Model.UniversalDataClasses.ListItem)item.SelectedItem;
              

                if (!cat.Id.Equals(historyCategoryId))
                {
                    historyCategoryId = cat.Id;
                    historySubjectId = -1;
                    FormComponents.PopulateDefaultData.SetHistorySubjectList(0, historyCategoryId, historySubjectId);
                    cmbHistorySubject.Enabled = true;
                    // setSubjectList();
                }
            }
            else
            {
                cmbHistorySubject.Enabled = false;
                historyCategoryId = 0;
                cmbHistorySubject.SelectedIndex = -1;
            }
        }

        private void cmbHistorySubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cbitem = (ComboBox)sender;
            var cat = (Model.UniversalDataClasses.ListItem)cbitem.SelectedItem;
            historySubjectId = cat.Id;
            if (historyCategoryId > -1 && historySubjectId > -1)
            {

                HistoryProject.PopulatFull.Populate(ref wbHistory, historyCategoryId, historySubjectId);

            }
        }



        private void rtbRecordBody_TextChanged(object sender, EventArgs e)
        {
            textChanged = true;
            pcbStored.Visible = false;
            pcbNotStored.Visible = true;
        }
        
        private void btnPauseTime_Click(object sender, EventArgs e)
        {
            timePaused = true;
            time.Stop();
            rtbRecordBody.Enabled = false;

            btnStartTime.Enabled = true;
            btnStartTime.Visible = true;


            btnCodeInsert.Visible = false;
            btnCodeInsert.Enabled = false;
            btnInertError.Visible = false;
            btnInertError.Enabled = false;
            btnInsertURL.Visible = false;
            btnInsertURL.Enabled = false;

            lblStatus.Text = String.Format("Time Paused {0}:{1}:{2}",time.Elapsed.Hours.ToString(), time.Elapsed.Minutes.ToString(),time.Elapsed.Seconds.ToString());
        }

        private void storeRecord()
        {
            if (!String.IsNullOrEmpty(rtbRecordBody.Text) && recordId > 0 && textChanged)
            {
                Model.DiarySDF.Queries.RecordQuery.Update(recordId, rtbRecordBody.Text, time.ElapsedMilliseconds);
                textChanged = false;
                pcbNotStored.Visible = false;
                pcbStored.Visible = true;

            }
            rtbRecordBody.Text = String.Empty;
            
        }

        private void stopRecordingote()
        {

            if(rtbRecordBody.Enabled)
            {
                timePaused = false;
                time.Stop();
                storeRecord();
                lblStatus.Text = String.Format("Time Stopped {0}:{1}:{2}", time.Elapsed.Hours.ToString(), time.Elapsed.Minutes.ToString(), time.Elapsed.Seconds.ToString());
                rtbRecordBody.Enabled = false;
                btnPauseTime.Enabled = false;
                btnStopTime.Enabled = false;
                btnPauseTime.Visible = false;
                btnStopTime.Visible = false;


                btnStartTime.Enabled = true;
                btnStartTime.Visible = true;

                btnCodeInsert.Visible = false;
                btnCodeInsert.Enabled = false;
                btnInertError.Visible = false;
                btnInertError.Enabled = false;
                btnInsertURL.Visible = false;
                btnInsertURL.Enabled = false;
            }
            
        }

        private void btnStopTime_Click(object sender, EventArgs e)
        {
            stopRecordingote();


        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblStatus.Text = time.Elapsed.Seconds.ToString();
        }

        private void lblHistory_Click(object sender, EventArgs e)
        {
        
        }

        private void btnDairyDayView_Click(object sender, EventArgs e)
        {
            
        }

      
        private Nullable<DateTime> DeadLine;
        private void cmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {

            var box = (ComboBox)sender;
            if (box.SelectedItem != null && box.SelectedItem != null)
            {

                var sub = (Model.UniversalDataClasses.ListItem)box.SelectedItem;
                if (sub.Id.Equals(-1))
                {

                    //Open Form
                    var frm = new frmNewCat();
                    frm.Date = DateTime.Now;
                    frm.DateNeeded = true;
                    frm.ShowDialog();
                    if (frm.Body != null && !String.IsNullOrEmpty(frm.Body.Trim()))
                        toDoCategoryId = Model.DiarySDF.Queries.ToDoCategoryQuery.Store(frm.Body.Trim(), frm.Date);
                    DeadLine = frm.Date;
                    //Select New Item
                    
                    FormComponents.PopulateDefaultData.SetToDoCatList(toDoCategoryId);
                    setToDoLists();

                    
                }
                else if(sub.Id.Equals(-2))
                {

                    showEditScreen(toDoCategoryId);

                    toDoCategoryId = sub.Id;
                    DeadLine = sub.Date;
                    setToDoLists();


                }
                else
                {

                    toDoCategoryId = sub.Id;
                    DeadLine = sub.Date;
                    setToDoLists();
                }

            }


        }


        private void setToDoLists()
        {

            pnlColumPlanning.Parent = tabTasks;

            ToDoProject.PanelItemControl.RemoveItems(pnlColumPlanning);
            ToDoProject.PanelItemControl.RemoveItems(pnlColumWorkingOn);
            ToDoProject.PanelItemControl.RemoveItems(pnlColumTesting);
            ToDoProject.PanelItemControl.RemoveItems(pnlColumCompleted);

            
            pnlColumWorkingOn.Parent = tabTasks;            
            pnlColumTesting.Parent = tabTasks;            
            pnlColumCompleted.Parent = tabTasks;         


            pnlColumPlanning.SendToBack();             
            pnlColumWorkingOn.SendToBack();            
            pnlColumTesting.SendToBack(); 
            pnlColumTesting.SendToBack();
            pnlColumCompleted.SendToBack();
            
            ToDoProject.Tasks.LoadTasks(toDoCategoryId, ref pnlColumPlanning, ref pnlColumWorkingOn, ref pnlColumTesting, ref pnlColumCompleted);


         
            if(DeadLine !=null)
            {
                var deadLine = (DateTime)DeadLine;
                var d = GetNumberOfWorkingDaysJeroen(DateTime.Now, deadLine);//.TotalDays;
                lblDeadline.Text = String.Format("DeadLine: {0} days left {1}", deadLine.ToString("dd/MM/yyyy"), d.ToString());
                if (d ==0)
                {
                    d = GetNumberOfWorkingDaysJeroen(deadLine, DateTime.Now);//.TotalDays;
                    lblDeadline.Text = String.Format("DeadLine: {0} days Over {1}", deadLine.ToString("dd/MM/yyyy"), d.ToString());
                }
                
            }
        }


        private static int GetNumberOfWorkingDaysJeroen(DateTime start, DateTime stop)
        {
            int days = 0;
            while (start <= stop)
            {
                if (start.DayOfWeek != DayOfWeek.Saturday && start.DayOfWeek != DayOfWeek.Sunday)
                {
                    ++days;
                }
                start = start.AddDays(1);
            }
            return days;
        }


        private static DateTime plannedStart;
        private static DateTime plannedComplete;
        private static string createText(ListBox cbox, int index)
        {
            if (index == -1)
                return String.Empty;

            var item = (Model.DiarySDF.Tables.ToDoTable)cbox.Items[index];
            string txt = item.Title.ToString();
            txt += Environment.NewLine;
            plannedStart = ((DateTime)item.StartDateTimePlanned);
            plannedComplete = ((DateTime)item.CompleteDateTimePlan);

            txt += String.Format("Planned Date: {0}-{1}", ((DateTime)item.StartDateTimePlanned).ToString("dd/MM/yyyy"), ((DateTime)item.CompleteDateTimePlan).ToString("dd/MM/yyyy"));
            
            return txt;
        }

        private static string createText1(ListBox cbox, int index)
        {
            if (index == -1)
                return String.Empty;

            var item = (Model.DiarySDF.Tables.ToDoTable)cbox.Items[index];
            string txt = item.Title.ToString();
            txt += Environment.NewLine;
            plannedStart = ((DateTime)item.StartDateTimePlanned);
            plannedComplete = ((DateTime)item.CompleteDateTimePlan);

            txt += String.Format("Complete Date: {0}", ((DateTime)item.CompleteDateTimePlan).ToString("dd/MM/yyyy"));

            return txt;
        }

        private static void comboBox2_DrawItem(object sender, DrawItemEventArgs e)
        {
            var cbox = (ListBox)sender;
            string txt = createText(cbox, e.Index);

            e.DrawBackground();
            Graphics g = e.Graphics;
            if (plannedStart < DateTime.Now)
                g.FillRectangle(new SolidBrush(Color.Red), e.Bounds);
            else if (plannedStart < DateTime.Now.AddDays(+1))
                g.FillRectangle(new SolidBrush(Color.Orange), e.Bounds);
             
            e.Graphics.DrawString(txt, cbox.Font, System.Drawing.Brushes.Black, new RectangleF(e.Bounds.X + 2, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height));

            e.Graphics.DrawLine(new Pen(Color.LightGray), e.Bounds.X, e.Bounds.Top + e.Bounds.Height - 1, e.Bounds.Width, e.Bounds.Top + e.Bounds.Height - 1);
            e.DrawFocusRectangle();
        }


        private static void comboBox3_DrawItem(object sender, DrawItemEventArgs e)
        {
            var cbox = (ListBox)sender;
            string txt = createText1(cbox, e.Index);

            e.DrawBackground();
            Graphics g = e.Graphics;
            if (plannedStart < DateTime.Now)
                g.FillRectangle(new SolidBrush(Color.Red), e.Bounds);
            else if (plannedStart < DateTime.Now.AddDays(+1))
                g.FillRectangle(new SolidBrush(Color.Orange), e.Bounds);

            e.Graphics.DrawString(txt, cbox.Font, System.Drawing.Brushes.Black, new RectangleF(e.Bounds.X + 2, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height));

            e.Graphics.DrawLine(new Pen(Color.LightGray), e.Bounds.X, e.Bounds.Top + e.Bounds.Height - 1, e.Bounds.Width, e.Bounds.Top + e.Bounds.Height - 1);
            e.DrawFocusRectangle();
        }


        private static void comboBox2_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            var cbox = (ListBox)sender;
            
            string txt = createText(cbox, e.Index);

            int height = Convert.ToInt32(e.Graphics.MeasureString(txt, cbox.Font).Height);
            int Width = Convert.ToInt32(e.Graphics.MeasureString(txt, cbox.Font).Width);
            if (Width > cbox.Width)
            {
                decimal w = (decimal)Width / (decimal)cbox.Width;
                decimal h = height * Decimal.Round(w, 0);
                int.TryParse(h.ToString(), out height);

            }
            e.ItemHeight = height + 4;
            e.ItemWidth = cbox.Width;

            cbox.ItemHeight = e.ItemHeight;
        }
        private static void comboBox3_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            var cbox = (ListBox)sender;

            string txt = createText1(cbox, e.Index);

            int height = Convert.ToInt32(e.Graphics.MeasureString(txt, cbox.Font).Height);
            int Width = Convert.ToInt32(e.Graphics.MeasureString(txt, cbox.Font).Width);
            if (Width > cbox.Width)
            {
                decimal w = (decimal)Width / (decimal)cbox.Width;
                decimal h = height * Decimal.Round(w, 0);
                int.TryParse(h.ToString(), out height);

            }
            e.ItemHeight = height + 4;
            e.ItemWidth = cbox.Width;

            cbox.ItemHeight = e.ItemHeight;
        }

        private void btnAddNewTask_Click(object sender, EventArgs e)
        {
            var frm = new frmToDoItem();
            frm.ShowDialog();
            if (!String.IsNullOrEmpty(frm.Title) || !String.IsNullOrEmpty(frm.Body))
                Model.DiarySDF.Queries.ToDoQuery.Insert(frm.Title, frm.Body, toDoCategoryId, frm.PlanStart, frm.PlanComplete);

            setToDoLists();
        }


        private void showEditScreen(int catId)
                    { 
            Model.UniversalDataClasses.ListItem item = null;

            foreach(Model.UniversalDataClasses.ListItem i in cmbToDoCategories.Items)
            {
                if (i.Id.Equals(catId))
                {
                    item = i;
                    break;
                }
            }
            if (item != null)
            {
                var d = (Model.UniversalDataClasses.ListItem)item;
                frmNewCat frm = new frmNewCat();
                if (d.Date != null)
                    frm.Date = (DateTime)d.Date;
                else
                    frm.Date = DateTime.Now;
                frm.Body = d.Text;
                frm.DateNeeded = true;
                frm.ShowDialog();

                d.Text = frm.Body;
                d.Date = frm.Date;
                Model.DiarySDF.Queries.ToDoCategoryQuery.Update(d);
            }


            setToDoLists();
        }

        private void moveItem(ListBox from, ListBox too, string status)
        {
            var item = (Model.DiarySDF.Tables.ToDoTable)from.SelectedItem;
            if(item != null)
            {
               
                Model.DiarySDF.Queries.ToDoQuery.UpdateStatus(item.Id, status, status.Equals(Model.DiarySDF.ENUM.TODOStatus.WorkingOn.ToString()), status.Equals(Model.DiarySDF.ENUM.TODOStatus.Completed.ToString()));
                too.Items.Add(item);
                from.Items.Remove(item);
                too.Refresh();
                from.Refresh();

            }


        }


        private Model.DiarySDF.ENUM.TODOStatus selectedList { get; set; }
        
      

     

        



        private void DisplayToDoAsEdit(int id)
        {
            var frm = new frmToDoItem();
            
            frm.VisibleMode = "view";
            frm.TaskId = id;
            frm.ShowDialog();

            if (!String.IsNullOrEmpty(frm.Title) || !String.IsNullOrEmpty(frm.Body))
                Model.DiarySDF.Queries.ToDoQuery.Edit(id, frm.Title, frm.Body, toDoCategoryId, frm.PlanStart, frm.PlanComplete);

        }

       

        private void btnCodeInsert_Click(object sender, EventArgs e)
        {
            
            rtbRecordBody.Text += String.Format("{0}[{1}]{0}{2}{0}[/{1}]", Environment.NewLine,"CODE", Clipboard.GetText().Trim());
        }

        private void btnInertError_Click(object sender, EventArgs e)
        {
            rtbRecordBody.Text += String.Format("{0}[{1}]{0}{2}{0}[/{1}]", Environment.NewLine, "ERROR", Clipboard.GetText().Trim());
        }

        private void btnInsertURL_Click(object sender, EventArgs e)
        {
            rtbRecordBody.Text += String.Format("{0}[{1}]{0}{2}{0}[/{1}]", Environment.NewLine, "URL", Clipboard.GetText().Trim());
        }

        private void frmMainScreen_Resize(object sender, EventArgs e)
        {
            int newHeight = tbcMain.Height - pnlColumCompleted.Location.Y - 10 ;
            pnlColumCompleted.Height = newHeight;
            pnlColumPlanning.Height = newHeight;
            pnlColumTesting.Height = newHeight;
            pnlColumWorkingOn.Height = newHeight;


            newHeight = tbcMain.Height - rtbRecordBody.Location.Y - 20 - pnlActionButtons.Height;


            rtbRecordBody.Height = newHeight;
            rtbRecordBody.Width = tbcMain.Width - 50;
            rtbRecordBody.Refresh();
            pnlActionButtons.Location = new Point(tbcMain.Width- pnlActionButtons.Width-30, tbcMain.Height -pnlActionButtons.Height-5);
            pnlFunctionButtons.Location = new Point(tbcMain.Width - pnlFunctionButtons.Width - 30, pnlFunctionButtons.Location.Y);
            wbHistory.Height = newHeight;
            wbHistory.Width = tbcMain.Width - 50;
            wbHistory.Refresh();
        }



        private static  int historySubjectId;
        private static int historyCategoryId;

        private void cmbHistorySubject_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            var sub = (ComboBox)sender;
            var item = (Model.UniversalDataClasses.ListItem)sub.SelectedItem;
            if (!item.Id.Equals(historySubjectId))
            {
                historySubjectId = item.Id;
                
            }
          
        }


   

        private  void setHistory()
        {
            if (historySubjectId > 0 && historyCategoryId > 0)
                HistoryProject.PopulatFull.Populate(ref wbHistory, historyCategoryId, historySubjectId);
        }

        private void frmMainScreen_Load(object sender, EventArgs e)
        {
            FormComponents.PopulateDefaultData.SetNoteCatList(categoryId);
            FormComponents.PopulateDefaultData.SetToDoCatList(toDoCategoryId);
            FormComponents.PopulateDefaultData.SetHistoryCatList(categoryId);
            

            FormComponents.PopulateDefaultData.SetNoteSubjectList(0, categoryId, subjectId);
           



            cmbNotesSubject.Enabled = (categoryId > -1);

            RegistrationProject.Register.RegisterApplication();

        }
    }
}
;