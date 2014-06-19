using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Internationalisation
{
    public partial class LocalForm : Form
    {
        public LocalForm()
        {
            InitializeComponent();
            lbCultureEnCours.Text = CultureInfo.CurrentCulture.Name;

            cbCultures.Items.Add(CultureInfo.CurrentCulture.Name);
            cbCultures.Items.Add("fr-BE");
            cbCultures.Items.Add("en");
            cbCultures.Items.Add("de");
        }

        private void cbCultures_SelectedIndexChanged(object sender, EventArgs e)
        {
            // localisation
            //*******************
            // on va récupérer la valeur sélectionnée afin de créer
            // une nouvelle instance de type CultureInfo
            string chaineCulture = cbCultures.SelectedItem.ToString();
            CultureInfo NouvelleCulture = new CultureInfo(chaineCulture);

            // cette nouvelle "Culture", on va la définir comme culture par défaut
            // pour le Thread dans lequel on est.
            // localisation = currentculture !
            Thread.CurrentThread.CurrentCulture = NouvelleCulture;

            // on vérifie en récupérant la nouvelle valeur de CultureInfo.CurrentCulture.Name 
            lbCultureEnCours.Text = CultureInfo.CurrentCulture.Name;

            //lbUneDate.Text =  DateTime.Now.ToString("d");
            //lbMonnaie.Text = (4512.36).ToString("C");

            /*
             * Globalisation = formatage en fonction de la culture
             * ************************************
             * globalisation = currentUICulture
             * * */
           Thread.CurrentThread.CurrentUICulture = NouvelleCulture;
            // pour récupérer la culture par défaut !! (sans le nom de la culture)
           // string AfficheravantDate=global::Internationalisation.Properties.Resources.Date ;//= global::;
            // si on souhaite récupérer la fichier resource associé à une culture,
            // il faut passer par "un resourceManager"
 
            ResourceManager resmgr =
                new ResourceManager("Internationalisation.Properties.Resources",
                            Assembly.GetExecutingAssembly());
            string AfficheravantDate;
            AfficheravantDate = resmgr.GetString("Date");
            lbUneDate.Text = AfficheravantDate + DateTime.Now.ToString("d");
            lbMonnaie.Text = resmgr.GetString("Monnaie") + (4512.36).ToString("C");

            // raffraichir l'écran en fonction del a culture choisie
            ComponentResourceManager resources = 
                new ComponentResourceManager(typeof(LocalForm));
            resources.ApplyResources(this, "$this");
            resources.ApplyResources(this.btnSortir, "btnSortir");
            resources.ApplyResources(this.gbExemples, "gbExemples");

        }

        private void btnSortir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
