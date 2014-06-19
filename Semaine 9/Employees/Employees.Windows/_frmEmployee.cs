using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Employees.Model;
using MyCompany.Controls;
using System.Reflection;
using Employees.Controler;
namespace Employees.Windows
{
    class _frmEmployee : Form
    {
        private NavigationBar navigationBar1;
        private int _cursor = -1;
        public _frmEmployee()
        {
            this.InitializeComponent();
            Label lbl;
            TextBox txt;
            int offsety = 5;
            this.SetBounds(0, 0, 300, 400);
            foreach (PropertyInfo pi in typeof(Employee).GetProperties())
            {
                lbl = new Label();
                lbl.Text = pi.Name;
                lbl.SetBounds(5, offsety, 100, 16);
                lbl.Name = "lbl" + pi.Name;
                this.Controls.Add(lbl);

                txt = new TextBox();
                txt.SetBounds(110, offsety, 170, 16);
                txt.Name = "txt" + pi.Name;
                if (pi.PropertyType.IsClass && pi.PropertyType.Name.ToLower() != "string")
                {
                    txt.AllowDrop = true;
                    txt.DragEnter += txt_DragEnter;
                    txt.DragDrop += (object sender, DragEventArgs e) =>
                    {
                        Service item = (Service)e.Data.GetData(typeof(Service));
                        if (pi.PropertyType.Name == item.GetType().Name)
                        {
                            ((TextBox)sender).Text = item.ToString();
                            ((TextBox)sender).Tag = item;
                        }
                    };
                    txt.ReadOnly = true;
                }
                if (null == pi.SetMethod)
                    txt.ReadOnly = true;

                this.Controls.Add(txt);
                this.Controls.Find("txt" + pi.Name, false);
                offsety += 20;
            }
            NavigationBar nb = new NavigationBar();
            nb.SetBounds(5, offsety, 295, 40);
            nb.Navigation += (object sender, NavigationBar.NavigationBarEventArgs e) =>
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
                _displayEmployee();
            };
            this.Controls.Add(nb);
            offsety += 40;
            this.SetBounds(0, 0, 300, offsety + 20);
            if (0 < EmployeeController.Instance.Employees.Count)
            {
                _cursor = 0;
                _displayEmployee();
            }
        }

        private void txt_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;
        }

        private void _displayEmployee()
        {
            if (_cursor > -1)
            {
                Employee e = EmployeeController.Instance.Employees.ElementAt(_cursor);
                ((TextBox)this.Controls.Find("txtSurname", false)[0]).Text = e.Surname;
                ((TextBox)this.Controls.Find("txtFirstname", false)[0]).Text = e.Firstname;
                ((TextBox)this.Controls.Find("txtDOB", false)[0]).Text = e.DOB.ToShortDateString();
                ((TextBox)this.Controls.Find("txtEmployedAt", false)[0]).Text = e.EmployedAt.ToShortDateString();
                ((TextBox)this.Controls.Find("txtEmployedAt", false)[0]).Text = e.EmployedAt.ToShortDateString();
                ((TextBox)this.Controls.Find("txtSalary", false)[0]).Text = e.Salary.ToString();

            }
        }

        private void InitializeComponent()
        {
            this.navigationBar1 = new MyCompany.Controls.NavigationBar();
            this.SuspendLayout();
            // 
            // navigationBar1
            // 
            this.navigationBar1.Font = new System.Drawing.Font("Source Code Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navigationBar1.LinkColor = System.Drawing.Color.Red;
            this.navigationBar1.LinkFirst = "1";
            this.navigationBar1.LinkLast = "n";
            this.navigationBar1.LinkNext = "+";
            this.navigationBar1.LinkPrevious = "-";
            this.navigationBar1.Location = new System.Drawing.Point(2, 1);
            this.navigationBar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.navigationBar1.Name = "navigationBar1";
            this.navigationBar1.Size = new System.Drawing.Size(130, 30);
            this.navigationBar1.TabIndex = 0;
            // 
            // frmEmployee
            // 
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.navigationBar1);
            this.Name = "frmEmployee";
            this.ResumeLayout(false);

        }


    }
}
