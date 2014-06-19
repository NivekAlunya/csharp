using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ProjectForm
{
    public interface IPeopleFormDelegate
    {
        void saved(string surname,string firstname,string password, string comment);
    }

    public class PeopleForm : Form
    {
        private IPeopleFormDelegate _peopleFormDelegate = null;
        private bool _openForUpdate;
        public PeopleForm(string title=null, IPeopleFormDelegate peopleFormDelegate = null, bool openForUpdate = false,string surname="", string firstname="", string password="", string comment="")
        {
            if (null != title) this.Text = title;
            _openForUpdate = openForUpdate;
            _peopleFormDelegate = peopleFormDelegate;
            this.SetBounds(10, 10, 200, 220);
            Label lbl1, lbl2,lbl3, lbl4;
            TextBox txt1, txt2,txt3,txt4;
            Button btn = new Button();
            this.Controls.Add(lbl1 = new Label());
            lbl1.SetBounds(5, 5, 185, 18);
            lbl1.Text = "firstname";
            this.Controls.Add(txt1 = new TextBox());
            txt1.SetBounds(5, 25, 185, 18);
            txt1.Text = firstname;
            this.Controls.Add(lbl2 = new Label());
            lbl2.Text = "surname";
            lbl2.SetBounds(5, 45, 185, 18);
            this.Controls.Add(txt2 = new TextBox());
            txt2.SetBounds(5, 65, 165, 18);
            txt2.Text = surname;
            this.Controls.Add(lbl3 = new Label());
            lbl3.SetBounds(5, 85, 185, 18);
            lbl3.Text = "password";
            this.Controls.Add(txt3 = new TextBox());
            txt3.SetBounds(5, 105, 185, 18);
            txt3.Text = password;
            this.Controls.Add(lbl4 = new Label());
            lbl4.SetBounds(5, 125, 185, 18);
            lbl4.Text = "comment";
            this.Controls.Add(txt4 = new TextBox());
            txt4.SetBounds(5, 145, 185, 18);
            txt4.Text = comment;
            this.Controls.Add(btn);
            btn.SetBounds(5, 165, 185, 18);
            ErrorProvider ep = new ErrorProvider();
            ep.SetIconAlignment(txt2, ErrorIconAlignment.MiddleRight);
            ep.SetIconPadding(txt2, 2);
            btn.Text = openForUpdate ? "Save people" : "Add people";
            btn.Click += (object sender1, EventArgs e1) =>
            {
                if (string.IsNullOrWhiteSpace(txt2.Text))
                {
                    ep.SetError(txt2, "Surname must contain chars");
                    return;
                }
                ep.SetError(txt2, string.Empty);
                if (null != this._peopleFormDelegate) _peopleFormDelegate.saved(txt2.Text, txt1.Text, txt3.Text, txt4.Text);
                if(openForUpdate) this.Close();
            };
        }

    }
}
