using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DockingControl
{
    public partial class frmMain : Form,IMessagePromptDelegate
    {
        private MessageBoxButtons _msgbuttons;
        
        private MessageBoxIcon _msgicon;
        
        private MessageBoxDefaultButton _msgdefaultbutton;

        public frmMain()
        {
            InitializeComponent();
            EventHandler evtRdButton = (object sender, EventArgs e) => {
                RadioButton rd = (RadioButton)sender;
                if (rd.Checked)
                {
                    _msgbuttons = (MessageBoxButtons)rd.Tag;
                    _refreshGroupbutton((MessageBoxButtons)rd.Tag);
                }
            };
            this.rdOK.Tag = MessageBoxButtons.OK;
            this.rdOKCancel.Tag = MessageBoxButtons.OKCancel;
            this.rdTryCancel.Tag = MessageBoxButtons.RetryCancel;
            this.rdYesNo.Tag = MessageBoxButtons.YesNo;
            this.rdYesNoCancel.Tag = MessageBoxButtons.YesNoCancel;
            foreach (RadioButton rd in this.grpChoice.Controls)
                rd.CheckedChanged += evtRdButton;

            this.rdOK.Checked = true;

            EventHandler evtRdIcon = (object sender, EventArgs e) =>
            {
                RadioButton rd = (RadioButton)sender;
                if (rd.Checked) {
                    _msgicon = (MessageBoxIcon)rd.Tag;
                    this.rdButton1.Checked =true;
                }
            };
            this.rdInformation.Tag = MessageBoxIcon.Information;
            this.rdAlert.Tag = MessageBoxIcon.Exclamation;
            this.rdQuestion.Tag = MessageBoxIcon.Question;
            this.rdError.Tag = MessageBoxIcon.Error;
            foreach (RadioButton rd in this.grpIcons.Controls)
                rd.CheckedChanged += evtRdIcon;

            this.rdInformation.Checked = true;

            EventHandler evtRdButtonDefault = (object sender, EventArgs e) =>
            {
                RadioButton rd = (RadioButton)sender;
                if (rd.Checked) _msgdefaultbutton = (MessageBoxDefaultButton)rd.Tag;
            };
            
            this.rdButton1.Tag = MessageBoxDefaultButton.Button1;
            this.rdButton2.Tag = MessageBoxDefaultButton.Button2;
            this.rdButton3.Tag = MessageBoxDefaultButton.Button3;
            foreach (RadioButton rd in this.grpButton.Controls)
                rd.CheckedChanged += evtRdButtonDefault;
        }

        private void _refreshGroupbutton(MessageBoxButtons btn)
        {
            if (MessageBoxButtons.OK == btn)
            {
                this.rdButton1.Text = "OK";
                this.rdButton1.Enabled = true;
                this.rdButton2.Enabled = this.rdButton3.Enabled = false;
                this.rdButton2.Text = this.rdButton3.Text = "";
            }
            else if (MessageBoxButtons.OKCancel == btn || MessageBoxButtons.RetryCancel == btn || MessageBoxButtons.YesNo == btn)
            {
                this.rdButton1.Enabled = this.rdButton2.Enabled =true;
                this.rdButton3.Enabled = false;
                this.rdButton3.Text = "";
            } else {
                this.rdButton1.Enabled = this.rdButton2.Enabled = this.rdButton3.Enabled = true;
            }

            if (rdButton1.Enabled) this.rdButton1.Text = MessageBoxButtons.OKCancel == btn || MessageBoxButtons.OK == btn ? "OK" : MessageBoxButtons.RetryCancel == btn ? "Retry" : "YES";
            if (rdButton2.Enabled) this.rdButton2.Text = MessageBoxButtons.OKCancel == btn || MessageBoxButtons.RetryCancel == btn  ? "Cancel" : "NO";
            if (rdButton3.Enabled) this.rdButton3.Text = "Cancel";
        }

        private void btnDialog_Click(object sender, EventArgs e)
        {
            if ((new MessagePrompt(this.txtMessage.Text, this)).ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MessageBox.Show(this.txtMessage.Text, "Message Box", _msgbuttons, _msgicon, _msgdefaultbutton);
            }
        }

        public void success(string s)
        {
            this.txtMessage.Text = s;
        }
    }
}
