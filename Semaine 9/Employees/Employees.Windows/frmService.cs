using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using Employees.Controler;
using Employees.Model;
namespace Employees.Windows
{
    public partial class frmService : Form
    {
        private enum ScreenModes
        {
            Stateless =1,
            Selection = 2,
            Creation = 4,
            Updating = 8
        }
        private ScreenModes _mode;
        private Service _selectedService = null;
        private ScreenModes _Mode { 
            get 
            { 
                return _mode; 
            }
            set 
            { 
                _mode = value;
                _switchScreenMode();
            } 
        }
        public frmService()
        {
            InitializeComponent();
            this.btnAdd.Tag = this.btnQuit.Tag = ScreenModes.Stateless | ScreenModes.Selection;
            this.btnValidate.Tag = this.btnCancel.Tag = ScreenModes.Creation | ScreenModes.Updating;
            this.btnNext.Tag = this.btnPrevious.Tag = ScreenModes.Selection;
            this.btnDel.Tag = ScreenModes.Selection;
            this.txtCode.Tag = this.txtLabel.Tag = ScreenModes.Selection | ScreenModes.Creation | ScreenModes.Updating;
            this.lstService.Tag = ScreenModes.Selection;
            this.lstService.MouseMove +=(object sender, MouseEventArgs e) =>
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    System.Diagnostics.Debug.WriteLine((Service)this.lstService.SelectedItem);
                    this.lstService.DoDragDrop((Service)this.lstService.SelectedItem, DragDropEffects.Link);
                }
            };
            this.btnAdd.Click += (object sender, EventArgs e) =>
            {
                this.txtCode.Text = this.txtLabel.Text = "";
                _Mode = ScreenModes.Creation;
            };
            this.btnDel.Click += (object sender, EventArgs e) =>
            {
                _delete();
            };
            this.ep.SetIconAlignment(this.txtLabel, ErrorIconAlignment.MiddleRight);
            this.ep.SetIconPadding(this.txtLabel, 2);
            
            this.btnValidate.Click += (object sender, EventArgs e) =>
            {
                _validate();
            };
            EventHandler evt =  (object sender, EventArgs e) =>
            {
                if(ScreenModes.Selection == _Mode) _Mode = ScreenModes.Updating;
            };
            this.txtCode.GotFocus += evt;
            this.txtLabel.GotFocus += evt;

            this.lstService.SelectedIndexChanged += (object sender, EventArgs e) =>
            {
                _selectedService = (Service)this.lstService.SelectedItem;
                _displayService();
            };

            this.btnNext.Click += (object sender, EventArgs e) =>
            {
                _navigate(1);
            };
            this.btnPrevious.Click += (object sender, EventArgs e) =>
            {
                _navigate(-1);
            };
            this.btnCancel.Click += (object sender, EventArgs e) =>
            {
                _setStatelessOrSelection();
                _displayService();
            };
            this.btnQuit.Click += (object sender, EventArgs e) =>
            {
                this.Close();
            };
            
            foreach (Service s in ServiceController.Instance.Services) 
                this.lstService.Items.Add(s);
            
            if(0<this.lstService.Items.Count) 
                this.lstService.SetSelected(0, true);
            
            _setStatelessOrSelection();
        }

        private void _delete()
        {
            if (null != _selectedService)
            {
                ServiceController.Instance.deleteService(_selectedService);
                int i = this.lstService.SelectedIndex;
                this.lstService.Items.Remove(_selectedService);
                _selectedService = null;
                if (0 == this.lstService.Items.Count)
                    _displayService();
                else if (this.lstService.Items.Count <= i)
                    this.lstService.SelectedIndex = i - 1;
                else
                    this.lstService.SelectedIndex = i;
                _setStatelessOrSelection();

            }
        }
        private void _validate()
        {
            this.ep.SetError(this.txtLabel, "");
            if (_Mode == ScreenModes.Creation)
            {
                try
                {
                    _selectedService = ServiceController.Instance.addService(this.txtCode.Text, this.txtLabel.Text);
                }
                catch (Exception ex)
                {
                    if (ex.Message.ToLower().Contains("code"))
                    {
                        this.txtCode.Focus();

                    }
                    else if (ex.Message.ToLower().Contains("label"))
                    {
                        this.txtLabel.Focus();
                    }
                    this.ep.SetError(this.txtLabel, ex.Message);
                    return;
                }

                this.lstService.Items.Insert(0, _selectedService);
                this.lstService.SelectedItem = _selectedService;
            }
            else
            {
                Service updatingService = _selectedService;
                try
                {
                    ServiceController.Instance.updateService(updatingService, this.txtCode.Text, this.txtLabel.Text);
                }
                catch (Exception ex)
                {
                    if (ex.Message.ToLower().Contains("code"))
                    {
                        this.txtCode.Focus();

                    }
                    else if (ex.Message.ToLower().Contains("label"))
                    {
                        this.txtLabel.Focus();
                    }
                    this.ep.SetError(this.txtLabel, ex.Message);
                    return;
                }
                int pos = this.lstService.SelectedIndex;
                this.lstService.Items.RemoveAt(pos);
                this.lstService.Items.Insert(ServiceController.Instance.Services.BinarySearch(_selectedService), updatingService);
                this.lstService.SelectedItem = updatingService;
            }
            _Mode = ScreenModes.Selection;
        }
        private void _navigate(int i)
        {
            if (1 > this.lstService.Items.Count) return;

            if (1>this.lstService.SelectedItems.Count) 
                this.lstService.SelectedIndex =0;
            else
            {
                if (this.lstService.Items.Count <= this.lstService.SelectedIndex + i)
                {
                    this.lstService.SelectedIndex = 0;
                }
                else if (0 > this.lstService.SelectedIndex + i)
                {
                    this.lstService.SelectedIndex = this.lstService.Items.Count - 1;
                }
                else
                {
                    this.lstService.SelectedIndex += i;
                }
            }
        }

        private void _displayService()
        {
            if (null == _selectedService)
            {
                this.txtCode.Text = this.txtLabel.Text = "";
            }
            else
            {
                this.txtCode.Text = _selectedService.Code;
                this.txtLabel.Text = _selectedService.Label;
            }
            this.dgvEmployees.DataSource = ServiceController.Instance.retrieveEmployees(_selectedService);
        }

        private void _switchScreenMode()
        {
            foreach (Control c in this.grpAction.Controls)
                c.Enabled = ((ScreenModes)c.Tag & _Mode) > 0;
            this.txtLabel.ReadOnly = this.txtCode.ReadOnly = !(((ScreenModes)this.txtCode.Tag & _Mode) > 0);
            this.lstService.Enabled = (((ScreenModes)this.lstService.Tag & _Mode) > 0);
        }

        private void _setStatelessOrSelection()
        {
            if (ServiceController.Instance.Services.Count > 0)
                _Mode = ScreenModes.Selection;
            else
                _Mode = ScreenModes.Stateless;
        }
    }
}
