using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiThreadProject
{
    /// <summary>
    /// classe de gestion du thread et des données associées
    /// </summary>
    class GestionThread
    {
               
        public int compteur {get; set;}
        public MultiThreadProject.Form1.DelegateRefreshData Callback { get; set; }

        /// <summary>
        /// méthode appelée lors du démarrage du Thread
        /// respecte la signature du délégué ThreadStart
        /// </summary>
        public void traiterAction()
        {
            int cpt = 0;
            // Tant que le thread n'est pas tué, on travaille
            while (Thread.CurrentThread.IsAlive)
            {
                for (cpt = 0; cpt <= compteur; cpt++)
                {
                    // Attente de 1 ms, pour laisser le temps à l'IHM de se rafraichir
                    Thread.Sleep(1);

                    //Retourner la valeur du compteur au travers de la propriété
                    //Callback et appel du délégué (Form1.refreshData)
                    if (Callback != null)
                        Callback(cpt);
                }
            }
        }
       
    }
}
