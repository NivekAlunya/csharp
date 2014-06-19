using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExempleBase
{
    public partial class EcranPrincipal : Form
    {
        public EcranPrincipal()
        {
            InitializeComponent();
            // permet d'ancrer un control (un composant) à un côté
            // de la fenêtre :
            btnQuitter.Dock = DockStyle.Bottom;


        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EcranPrincipal_Load(object sender, EventArgs e)
        {
            // au chargement de la fenêtre (lors de l'appel du show)
            // on initialise
            rbNoir.Checked = true;
            rbGauche.Checked = true;

          //  ckGras.Enabled = false; désactive un control
          //  gbStyle.Enabled = false; désactive tous les controls contenus dans le groupbox
        }

        private void rbCouleur_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true)
            MessageBox.Show(((RadioButton)sender).Text,
                            "titre",
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button2);
        }
    }
}
