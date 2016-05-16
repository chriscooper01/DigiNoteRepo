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
    public partial class frmNewSubject : Form
    {
        public string Body { get; private set; }
        public frmNewSubject()
        {
            InitializeComponent();
        }

        private void btnCategoryAdd_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSub.Text))
            {
                Body = txtSub.Text.Trim();
                this.Close();
            }
        }
    }
}
