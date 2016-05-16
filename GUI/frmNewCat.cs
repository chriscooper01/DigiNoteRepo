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
    public partial class frmNewCat : Form
    {
        public DateTime Date { get; set; }
        public bool DateNeeded { get; set; }
        public string Body { get; set; }

        public frmNewCat()
        {
            InitializeComponent();
        }

        private void btnCategoryAdd_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(txtCat.Text))
            {
                Body = txtCat.Text.Trim();
                Date = dtpPlanDeadline.Value;
                this.Close();
            }
        }

        private void frmNewCat_Load(object sender, EventArgs e)
        {
            if (Date.Year.Equals(1))
                Date = DateTime.Now;

            lblDeadline.Visible = DateNeeded;
            dtpPlanDeadline.Visible = DateNeeded;
            dtpPlanDeadline .Value = Date;
            txtCat.Text = Body;

        }
    }
}
