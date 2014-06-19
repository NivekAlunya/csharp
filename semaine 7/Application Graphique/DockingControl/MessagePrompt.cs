using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DockingControl
{
    interface IMessagePromptDelegate
    {
        void success(string s);
    }
    class MessagePrompt : Form
    {
        private IMessagePromptDelegate _delegate;
        public MessagePrompt(string msgdefault = "",IMessagePromptDelegate myDelegate = null)
        {
            _delegate = myDelegate;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.SetBounds(10, 10, 300, 60);
            TextBox t = new TextBox();
            t.SetBounds(5, 5, 280, 18);
            t.Text = msgdefault;
            this.Controls.Add(t);
            t.KeyUp += (object sender, KeyEventArgs e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    _delegate.success(((TextBox)sender).Text);
                    this.Close();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            };
        }
    }
}
