using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Employees.Model;
using Employees.Controler;
using MyCompany.Controls;

namespace Employees.Windows
{
    public partial class frmEmployee : Form
    {
        private int _cursor = -1;

        private enum ScreenModes
        {
            Stateless = 1,
            Selection = 2,
            Creation = 4,
            Updating = 8
        }
        private ScreenModes _mode;
        private Employee _selectedEmployee = null;
        private ScreenModes _Mode
        {
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

        public frmEmployee()
        {
            InitializeComponent();
            this.navBar.Focus();
            if (0 < EmployeeController.Instance.Employees.Count)
            {
                _cursor = 0;
            }

            this.cmbChief.DataSource = EmployeeController.Instance.Employees;
            this.cmbChief.DisplayMember = "Fullname";
            
            this.tsbAdd.Tag = this.tsbClose.Tag = ScreenModes.Stateless | ScreenModes.Selection;
            this.tsbValidate.Tag = this.tsbCancel.Tag = ScreenModes.Creation | ScreenModes.Updating;
            this.navBar.Tag = ScreenModes.Selection;
            this.tsbDel.Tag = ScreenModes.Selection;
            this.nudSalary.Tag = this.lblService.Tag = this.txtFirstname.Tag = this.txtSurname.Tag = this.dtDOB.Tag = this.dtEmployedAt.Tag = ScreenModes.Selection | ScreenModes.Creation | ScreenModes.Updating;
            this.lblServiceValue.AllowDrop = true;
            this.lblServiceValue.DragEnter += (object sender, DragEventArgs e) =>
            {
                e.Effect = DragDropEffects.Link;
            };
            
            this.lblServiceValue.DragDrop += (object sender, DragEventArgs e) =>
            {
                Service item = (Service)e.Data.GetData(typeof(Service));
                ((Label)sender).Text = item.ToString();
                ((Label)sender).Tag = item;
                if (ScreenModes.Selection == _Mode) _Mode = ScreenModes.Updating;
            };

            EventHandler evt = (object sender, EventArgs e) =>
            {
                if (ScreenModes.Selection == _Mode) _Mode = ScreenModes.Updating;
            };
            this.txtSurname.GotFocus += evt;
            this.txtFirstname.GotFocus += evt;
            this.cmbChief.GotFocus += evt;
            this.dtDOB.GotFocus += evt;
            this.dtEmployedAt.GotFocus += evt;
            this.nudSalary.GotFocus += evt;

            this.tsbAdd.Click += (object sender, EventArgs e) =>
            {
                _Mode = ScreenModes.Creation;
            };
            this.tsbDel.Click += (object sender, EventArgs e) =>
            {
                _delete();
            };
            this.tsbValidate.Click += (object sender, EventArgs e) =>
            {
                _validate();
            };
            this.tsbCancel.Click += (object sender, EventArgs e) =>
            {
                _setStatelessOrSelection();
                _displayEmployee();
            };
            this.tsbClose.Click += (object sender, EventArgs e) =>
            {
                this.Close();
            };

            this.navBar.Navigation += (object sender, NavigationBar.NavigationBarEventArgs e) =>
            {
                switch (e.NavigationBarEvent)
                {
                    case NavigationBar.NavigationBarEvent.First:
                        _cursor = 0;
                        break;
                    case NavigationBar.NavigationBarEvent.Prev:
                        _cursor = _cursor > 0 ? --_cursor : EmployeeController.Instance.Employees.Count - 1;
                        break;
                    case NavigationBar.NavigationBarEvent.Next:
                        _cursor = _cursor < EmployeeController.Instance.Employees.Count - 1 ? ++_cursor : 0;
                        break;
                    case NavigationBar.NavigationBarEvent.Last:
                        _cursor = EmployeeController.Instance.Employees.Count - 1;
                        break;
                    default:
                        break;
                }
                _selectedEmployee = EmployeeController.Instance.Employees.ElementAt(_cursor);
                _displayEmployee();
            };
            _setStatelessOrSelection();
        }

        private void _delete()
        {
            if (null != _selectedEmployee)
            {
                EmployeeController.Instance.deleteEmployee(_selectedEmployee);
                if (_cursor > EmployeeController.Instance.Employees.Count - 1)
                    _cursor--;
                if(-1<_cursor)_selectedEmployee = EmployeeController.Instance.Employees.ElementAt(_cursor);

                _setStatelessOrSelection();

            }
        }

        private void _validate()
        {
            if (_Mode == ScreenModes.Creation)
            {
                try
                {
                    EmployeeController.Instance.addEmployee(
                        this.txtSurname.Text,
                        this.txtFirstname.Text,
                        this.dtDOB.Value,
                        this.dtEmployedAt.Value,
                        (int)this.nudSalary.Value,
                        (Service)this.lblServiceValue.Tag,
                        (Employee)this.cmbChief.SelectedValue
                    );
                }
                catch (Exception ex)
                {
                    if (ex.Message.ToLower().Contains("code"))
                    {
                    }
                    else if (ex.Message.ToLower().Contains("label"))
                    {
                    }
                    return;
                }
           }
            else
            {
                Employee updatingEmployee = _selectedEmployee;
                try
                {

                    EmployeeController.Instance.updateEmployee(
                        updatingEmployee,
                        this.txtSurname.Text,
                        this.txtFirstname.Text,
                        this.dtDOB.Value,
                        this.dtEmployedAt.Value,
                        (int)this.nudSalary.Value,
                        (Service)this.lblServiceValue.Tag,
                        (Employee)this.cmbChief.SelectedValue);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            _Mode = ScreenModes.Selection;
        }

        private void _displayEmployee()
        {
            
            if (null == _selectedEmployee)
            {
                this.txtSurname.Text = this.txtFirstname.Text="";
                this.cmbChief.SelectedIndex = -1;
                this.dtDOB.Value = DateTime.Now.AddYears(-18);
                this.dtEmployedAt.Value = DateTime.Now;
                this.lblServiceValue.Tag = null;
                this.lblServiceValue.Text = "";
                this.nudSalary.Value = 1;
            }
            else
            {
                this.txtSurname.Text = _selectedEmployee.Surname;
                this.txtFirstname.Text = _selectedEmployee.Firstname;
                this.txtFirstname.Text = _selectedEmployee.Firstname;
                if (null != _selectedEmployee.Chief)
                {
                    int i =0;
                    foreach(Employee e in this.cmbChief.Items)
                    {   
                        if (e == _selectedEmployee.Chief)
                        {
                            this.cmbChief.SelectedIndex = i;
                            break;
                        }

                        i++;
                    }
                }
                else
                {
                    this.cmbChief.SelectedIndex = -1;
                }
                this.lblServiceValue.Tag = _selectedEmployee.Service;
                this.lblServiceValue.Text = null != this.lblServiceValue.Tag  ? this.lblServiceValue.Tag.ToString():"";
                this.dtDOB.Value = _selectedEmployee.DOB;
                this.dtEmployedAt.Value = _selectedEmployee.EmployedAt;
                this.nudSalary.Value = _selectedEmployee.Salary;
            }
        }

        private void _switchScreenMode()
        {

            foreach (ToolStripItem it in this.tsEmployee.Items)
                if (it is ToolStripButton) it.Enabled = ((ScreenModes)it.Tag & _Mode) > 0;
            this.navBar.LinkEnabled = ((ScreenModes)this.navBar.Tag & _Mode) > 0;
            this.lblServiceValue.AllowDrop = this.lblService.Enabled;
            
            switch (_Mode)
            {
                case ScreenModes.Selection:
                    _selectedEmployee = EmployeeController.Instance.Employees.ElementAt(_cursor);
                    this.navBar.Focus();
                break;
                case ScreenModes.Stateless:
                case ScreenModes.Creation:
                    _selectedEmployee = null;
                    break;
                case ScreenModes.Updating:
                    break;
                default:
                    break;
            }
            _displayEmployee();
        }

        private void _setStatelessOrSelection()
        {
            if (EmployeeController.Instance.Employees.Count > 0)
            {
                _Mode = ScreenModes.Selection;
            }
            else
                _Mode = ScreenModes.Stateless;
        }




    }
}
