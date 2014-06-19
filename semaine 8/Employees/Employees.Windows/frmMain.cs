using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Employees.Store;
namespace Employees.Windows
{
    public partial class frmMain : Form
    {
        private frmService _frmService = null;
        private frmEmployee _frmEmployee = null;
        
        public frmMain()
        {
            InitializeComponent();
            this.FormClosed += (object sender, FormClosedEventArgs e) =>
            {
                ApplicationPersist.Instance.save();
            };
            ApplicationPersist.Formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            ApplicationPersist.Instance.load();
        }


        private void tsmiApplicationQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmiEntriesService_Click(object sender, EventArgs e)
        {
            _displayFrmService();
        }

        private void _displayFrmService()
        {
            this.tsmiEntriesService.Checked = true;
            if (null == _frmService)
            {
                _frmService = new frmService();
                _frmService.MdiParent = this;
                _frmService.FormClosed += (object sender, FormClosedEventArgs e) =>
                {
                    this.tsmiEntriesService.Checked = false;
                    _frmService = null;
                };
                _frmService.Show();
            }
            else
            {
                _frmService.BringToFront();
            }

        }

        private void tsmiEntriesEmployee_Click(object sender, EventArgs e)
        {
            _displayFrmEmployee();
        }

        private void _displayFrmEmployee()
        {
            this.tsmiEntriesEmployee.Checked = true;
            if (null == _frmEmployee)
            {
                _frmEmployee = new frmEmployee();
                _frmEmployee.MdiParent = this;
                _frmEmployee.FormClosed += (object sender, FormClosedEventArgs e) =>
                {
                    this.tsmiEntriesEmployee.Checked = false;
                    _frmEmployee = null;
                };
                _frmEmployee.Show();
            }
            else
            {
                _frmService.BringToFront();
            }

        }
    }
}
