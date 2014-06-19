using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class DrawingForm : Form
    {
        private Point _lastPoint;
        private Pen _p;
        Graphics _g;
        public DrawingForm()
        {
            InitializeComponent();
            _g = Graphics.FromHwnd(this.paneDrawing.Handle);
            this.paneDrawing.MouseMove += paneDrawing_MouseMove;
            this.paneDrawing.MouseDown += paneDrawing_MouseDown;
            this.paneDrawing.MouseUp += paneDrawing_MouseUp;
            this.paneDrawing.ContextMenu = new ContextMenu();
            this.paneDrawing.ContextMenu.MenuItems.Add(new MenuItem("Change Color",changeBrush_Click));
            this.MouseWheel += drawingForm_MouseWheel;
            this.Shown += DrawingForm_Shown;
            this.KeyDown += DrawingForm_KeyDown;
            this.Activated += DrawingForm_Activated;
            
        }

        void DrawingForm_Activated(object sender, EventArgs e)
        {

        }

        void drawingForm_MouseWheel(object sender, MouseEventArgs e)
        {

            if (e.Delta > 0)
            {
                if (_p.Width < 24) _p.Width++;
            }
            else
            {
                if (_p.Width > 0) _p.Width--;
            }
        }

        void DrawingForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C) changeBrush();
        }

        void DrawingForm_Shown(object sender, EventArgs e)
        {
            changeBrush();
        }

        void changeBrush_Click(object sender, EventArgs e)
        {
            changeBrush();
        }
        private void changeBrush()
        {
            ColorDialog clrdiag = new ColorDialog();
            clrdiag.ShowDialog();
            _p = new Pen(clrdiag.Color,2f); 
        }
        void paneDrawing_MouseDown(object sender, MouseEventArgs e)
        {
            _lastPoint = new Point(e.X, e.Y);
        }

        void paneDrawing_MouseUp(object sender, MouseEventArgs e)
        {
            _g.Save();
        }


        void paneDrawing_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            { 
                drawPoint(new Point(e.X, e.Y));
            }
        }

        void drawPoint(Point pt)
        {
                if (_lastPoint.X != pt.X || _lastPoint.Y != pt.Y)
                {
                    _g.DrawLine(_p, _lastPoint, pt);
                }
                _lastPoint = pt;
        }

    }
}
