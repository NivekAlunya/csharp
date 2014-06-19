using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDIForms
{
    public partial class frMain : Form
    {
        public frMain()
        {
            InitializeComponent();
        }

        private void tsmiFileOpen_Click(object sender, EventArgs e)
        {
            frmChild1 f = new frmChild1();
            f.MdiParent = this;
            f.Show();
            this.tsmiFileOpen.Enabled = false;
            f.FormClosed += (object sender1, FormClosedEventArgs ex) =>
            {
                this.tsmiFileOpen.Enabled = true;
            };
        }

        private void tsmiWindowsClose_Click(object sender, EventArgs e)
        {
            if (null != this.ActiveMdiChild) this.ActiveMdiChild.Close();
        }
    }
}
