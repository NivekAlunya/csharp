using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCompany.Controls
{
    public partial class NavigationBar: UserControl
    {
        public enum NavigationBarEvent
        {
            First,
            Prev,
            Next,
            Last,
        }
        public event EventHandler<NavigationBarEventArgs> Navigation;
        protected virtual void OnNavigation(NavigationBarEventArgs e)
        {
            EventHandler<NavigationBarEventArgs> handler = Navigation;
            if (null != handler) handler(this, e);
        }

        public class NavigationBarEventArgs : EventArgs
        {
            private NavigationBarEvent _nbe;
            public NavigationBarEvent NavigationBarEvent
            {
                get { return _nbe; }
                set { _nbe = value; }
            }
            public NavigationBarEventArgs(NavigationBarEvent nbe)
            {
                NavigationBarEvent = nbe;
            }
        }
        public string LinkFirst
        {
            get { return this.lnkFirst.Text; }
            set { this.lnkFirst.Text = value; } 
        }
        public Image LinkFirstImage
        {
            set { this.lnkFirst.Image = value; }
        }
        public string LinkLast
        {
            get { return this.lnkLast.Text; }
            set { this.lnkLast.Text = value; }
        }
        public Image LinkLastImage
        {
            set { this.lnkLast.Image = value; }
        }
        public string LinkNext
        {
            get { return this.lnkNext.Text; }
            set { this.lnkNext.Text = value; }
        }
        public Image LinkNextImage
        {
            set { this.lnkNext.Image = value; }
        }
        public string LinkPrevious
        {
            get { return this.lnkPrev.Text; }
            set { this.lnkPrev.Text = value; }
        }
        public Image LinkPreviousImage
        {
            set { this.lnkPrev.Image = value; }
        }
        private Color _lnkColor;
        public Color LinkColor
        {
            get { return _lnkColor; }
            set 
            {
                _lnkColor = value;
                foreach (Control c in this.tableLayoutPanel1.Controls)
                    if (c is LinkLabel) ((LinkLabel)c).LinkColor = _lnkColor;
            }
        }

        private bool _enabled;
        public bool LinkEnabled
        {
            get { return _enabled; }
            set
            {
                _enabled = value;
                foreach (Control c in this.tableLayoutPanel1.Controls)
                    if (c is LinkLabel) ((LinkLabel)c).Enabled = _enabled;
            }
        }
        
        public NavigationBar()
        {
            InitializeComponent();
            lnkFirst.Click += (object sender, EventArgs e) =>
            {
                this.OnNavigation(new NavigationBarEventArgs(NavigationBarEvent.First));
            };
            lnkLast.Click += (object sender, EventArgs e) =>
            {
                this.OnNavigation(new NavigationBarEventArgs(NavigationBarEvent.Last));
            };
            lnkPrev.Click += (object sender, EventArgs e) =>
            {
                this.OnNavigation(new NavigationBarEventArgs(NavigationBarEvent.Prev));
            };
            lnkNext.Click += (object sender, EventArgs e) =>
            {
                this.OnNavigation(new NavigationBarEventArgs(NavigationBarEvent.Next));
            };
        }
    }
}
