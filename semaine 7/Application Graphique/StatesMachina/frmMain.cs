using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StatesMachina
{
    public partial class frmMain : Form
    {
        private enum ScreenModes
        {
            Stateless = 1,
            Selection = 2,
            Addition = 4,
            Modification = 8,
        }
        private ScreenModes _mode;
        private MachinaStateControler _controler;
        private ScreenModes _Mode { 
            get { return _mode; } 
            set 
            { 
                _mode = value;
                foreach(Control c in this.Controls)
                    if(c is Button) c.Enabled = ((ScreenModes)c.Tag & _mode) > 0;
                this.txtString.ReadOnly = !(((ScreenModes)this.txtString.Tag & _mode) > 0);
                if ((_mode & ScreenModes.Selection) > 0 || (_mode & ScreenModes.Modification) > 0)
                    this.txtString.Text = _controler.Strings[_controler.Strings.Count-1];
                else
                    this.txtString.Text = "";
            } 
        }
        public frmMain()
        {
            InitializeComponent();
            _controler = new MachinaStateControler();
            _mode = ScreenModes.Stateless;
            this.btnAdd.Tag = btnQuit.Tag = ScreenModes.Selection | ScreenModes.Stateless;
            this.btnValidate.Tag = btnCancel.Tag = ScreenModes.Addition | ScreenModes.Modification;
            this.btnDel.Tag = ScreenModes.Selection;
            this.btnQuit.Click += (object sender, EventArgs e) => { this.Close(); };
            this.btnAdd.Click += (object sender, EventArgs e) => { _Mode = ScreenModes.Addition; };
            this.btnValidate.Click += (object sender, EventArgs e) => { _validate(); };
            this.btnCancel.Click += (object sender, EventArgs e) => { _setModeStatelessOrSelection(); };
            this.btnDel.Click += (object sender, EventArgs e) => { _delete(); };
            this.txtString.Tag = ScreenModes.Selection | ScreenModes.Addition | ScreenModes.Modification;
            this.txtString.GotFocus += (object sender, EventArgs e) =>
                {
                    if (_Mode != ScreenModes.Addition)
                        _Mode = ScreenModes.Modification;
                        
                };
            _setModeStatelessOrSelection();
        }


        private void _setModeStatelessOrSelection()
        {
            if (this._controler.Strings.Count > 0)
                _Mode = ScreenModes.Selection;
            else
                _Mode = ScreenModes.Stateless;
        }
        private void _validate()
        {
            if (_Mode == ScreenModes.Addition)
                _controler.addString(this.txtString.Text);
            else
                _controler.updateStringAt(_controler.Strings.Count-1, this.txtString.Text);

            _setModeStatelessOrSelection();
        }

        private void _delete()
        {
            _controler.deleteStringAt(_controler.Strings.Count - 1);
            _setModeStatelessOrSelection();
        }

    }
}
