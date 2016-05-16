using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmToDoItem : Form
    {

        public string VisibleMode { get; set; }
        public int TaskId { get; set; }

        public string Title { get; set; }
        public string Body{ get; set; }
        public frmToDoItem()
        {
            InitializeComponent();

            PlanComplete = DateTime.Now;
            PlanStart= DateTime.Now;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Title = txtTitle.Text.Trim();
            Body = rtbBody.Text.Trim();
            if (dtpPlanComplete.Value != null && dtpPlanStart.Value != null)
                this.Close();
            else
                MessageBox.Show(@"A Planned Started\Complete date required");
        }


        public DateTime PlanStart { get; set; }
        public DateTime PlanComplete { get; set; }
        private void dtpPlanStart_ValueChanged(object sender, EventArgs e)
        {
            if (dtpPlanStart.Value != null)
                PlanStart = dtpPlanStart.Value;
        }

        private void dtpPlanComplet_ValueChanged(object sender, EventArgs e)
        {
            if (dtpPlanComplete.Value != null)
                PlanComplete= dtpPlanComplete.Value;
        }

        private void frmToDoItem_Load(object sender, EventArgs e)
        {
            
                lblCompleteTrue.Text = String.Empty;            
                lblStartTrue.Text = String.Empty;

            if (String.IsNullOrEmpty(VisibleMode) && String.IsNullOrWhiteSpace(VisibleMode))
            {
                visualModel(true);
                Edit = false;
            }
            else
            {
                Edit = true;
                visualModel(true);
                btnSave.Text = "Edit";
                loadToDo();
            }
        }
        public bool Edit;

        private void visualModel(bool enable)
        {
            txtTitle.Enabled = enable;
            rtbBody.Enabled = enable;
            dtpPlanComplete.Enabled = enable;
            dtpPlanStart.Enabled = enable;
            btnSave.Visible = enable;
        }
        private void loadToDo()
        {
            var item = Model.DiarySDF.Queries.ToDoQuery.Single(TaskId);
            if(item != null)
            {
                txtTitle.Text = item.Title;
                rtbBody.Text = item.Body ;
                dtpPlanComplete.Value= (DateTime) item.CompleteDateTimePlan;
                dtpPlanStart.Value = (DateTime)item.StartDateTimePlanned;
                if(item.CompleteDateTimeTrue !=null)
                    lblCompleteTrue.Text = String.Format("True Complete Date: {0}", ((DateTime)item.CompleteDateTimeTrue).ToString("dd/MM/yyyy hh:mm:ss"));
                if (item.StartDateTimeTrue  != null)
                    lblStartTrue.Text = String.Format("True Start Date: {0}", ((DateTime)item.StartDateTimeTrue).ToString("dd/MM/yyyy hh:mm:ss"));
            }

        }
    }
}
