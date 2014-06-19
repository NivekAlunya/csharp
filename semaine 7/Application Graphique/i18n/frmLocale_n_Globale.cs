using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Globalization;
using System.Resources;
using System.Reflection;
namespace i18n
{
    
    public partial class frmLocale_n_Globale : Form
    {
        public frmLocale_n_Globale()
        {
            InitializeComponent();
            this.cmbLang.Items.Add(CultureInfo.CurrentCulture.Name);
            this.cmbLang.Items.AddRange(CultureInfo.GetCultures(CultureTypes.AllCultures));
        }

        private void cmbLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string culture = this.cmbLang.SelectedItem.ToString();
            CultureInfo newCulture = new CultureInfo(culture);
            Thread.CurrentThread.CurrentCulture = newCulture;
            this.txtDate.Text = DateTime.Now.ToString("d");
            this.txtMoney.Text = (1589.65f).ToString("C");
            ResourceManager rm = new ResourceManager("i18n.Properties.resources", Assembly.GetExecutingAssembly());
            this.lblDate.Text = rm.GetString("Date");
            this.lblMoney.Text = rm.GetString("Money");

            Thread.CurrentThread.CurrentUICulture = newCulture;
            ComponentResourceManager rmform = new ComponentResourceManager(typeof(frmLocale_n_Globale));
            rmform.ApplyResources(this, "$this");


        }
    }
}
