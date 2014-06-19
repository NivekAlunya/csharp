using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectForm
{
    
    public partial class MainScreen : Form,IPeopleFormDelegate
    {
        
        private PeopleController _controler;
        private People _target;
        public MainScreen()
        {
            InitializeComponent();
            _controler = new PeopleController();
            this.btnPeople.Click += btnPeople_Click;
            this.btnPeople.Enabled = false;
            //FontStyle st = FontStyle.Bold | FontStyle.Italic;
            this.dgvPeople.DataSource = _controler.Peoples;
        }

        void btnPeople_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Debug.WriteLine(this.GetType().Attributes);
            Form f = new Form();
            Label lbl1, lbl2;
            TextBox txt1, txt2;
            f.Text = "WTF you are ?";
            f.SetBounds(10, 10, 200, 140);
            f.Controls.Add(lbl1 = new Label());
            lbl1.SetBounds(5, 5, 185,18);
            lbl1.Text = "firstname";
            f.Controls.Add(txt1 = new TextBox());
            txt1.SetBounds(5, 25, 185, 18);
            f.Controls.Add(lbl2 = new Label());
            lbl2.Text = "surname";
            lbl2.SetBounds(5, 45, 185, 18);
            f.Controls.Add(txt2 = new TextBox());
            txt2.SetBounds(5, 65, 185, 18);
            Button btn = new Button();
            btn.SetBounds(5, 85, 185, 18);
            btn.Text = "Add people";
            f.Controls.Add(btn);
            btn.Click += (object sender1, EventArgs e1) =>
            {
                this.chklistPeople.Items.Add(txt1.Text + " " + txt2.Text);
                //this.Show();
                //f.Close();
            };
            f.Show();
        }

        public void saved(string surname, string firstname, string password, string comment)
        {
            if(null == _target) 
            {
                People p = _controler.addPeople(surname, firstname, password, comment);
            }
            else
            {
                _controler.updatePeople(_target,surname, firstname, password, comment);
            }
            //this.Show();
        }

        private void btnAddPeopleDelegate_Click(object sender, EventArgs e)
        {
            //this.Hide();
            PeopleForm f = new PeopleForm("WTF you are ?" ,this);
            f.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.dgvPeople.SelectedRows.Count > 0)
            {
                _target = (People)this.dgvPeople.SelectedRows[0].DataBoundItem;
                PeopleForm f = new PeopleForm("WTF you are ?", this, true, _target.Surname, _target.Firstname, _target.Password, _target.Comment);
                f.ShowDialog();
            }
            
        }

        private void btnDeletePeople_Click(object sender, EventArgs e)
        {
            if (this.dgvPeople.SelectedRows.Count > 0)
            {
                _target = (People)this.dgvPeople.SelectedRows[0].DataBoundItem;
                _controler.Peoples.Remove(_target);
                _target = null;
            }
            
        }

    }



}
