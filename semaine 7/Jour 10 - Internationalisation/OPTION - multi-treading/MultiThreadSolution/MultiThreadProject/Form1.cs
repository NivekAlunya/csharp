using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiThreadProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region "Traitement long exécuté dans le même thread que l'application"
        /// <summary>
        /// Déclencher un traitement long pris en charge par le processus
        /// courant lié à l'application
        /// Blocage de l'IHM (le Label représentant le compteur n'est mis à jour qu'à la fin du traitement) 
        /// Impossible d'interrompre proprement le traitement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private void btStartLong_Click(object sender, EventArgs e)
        {
            //
            //initialiser la progressBar
            //
            pbLong.Minimum = 0;
            pbLong.Maximum = 100000;
            pbLong.Value = pbLong.Minimum;
            //
            //déclencher le traitement long
            //
            int cpt = 0;
            for (cpt = 0; cpt <= pbLong.Maximum; cpt++)
            {
                pbLong.Value = cpt;
                //le Label n'est mis à jour qu'à la fin du traitement
                lbLong.Text = cpt.ToString();
            }
        }
        #endregion

        #region "Traitement long pris en charge par un Thread actif (classe Thread) : Version 1"

            //Thread monThread;

            ///// <summary>
            ///// Création du Thread, affectation du traitement au Thread
            ///// L'IHM n'est pas bloquée, possibilité de stopper le Thread
            ///// Attention, un thread ne peut manipuler que des éléments dont il est le propriétaire
            ///// </summary>
            ///// <param name="sender"></param>
            ///// <param name="e"></param>
            //private void btStartThread_Click(object sender, EventArgs e)
            //{
            //    //
            //    //initialiser la progressBar
            //    //
            //    pbLong.Minimum = 0;
            //    pbLong.Maximum = 100000;
            //    pbLong.Value = pbLong.Minimum;

            //    // Instanciation du thread, on spécifie dans le 
            //    // délégué ThreadStart le nom de la méthode qui
            //    // sera exécutée lorsque l'on appelle la méthode
            //    // Start() de notre thread.
            //    monThread = new Thread(new ThreadStart(traiterAction));

            //    // Lancement du thread
            //    monThread.Start();
            //}

            //private void btStopThread_Click(object sender, EventArgs e)
            //{
            //    if (monThread.IsAlive)
            //        // Détruit notre thread
            //        monThread.Abort();
            //}

            //private void traiterAction()
            //{
            //    int cpt = 0;
            //    // Tant que le thread n'est pas tué, on travaille
            //    while (Thread.CurrentThread.IsAlive)
            //    {
            //        for (cpt = 0; cpt <= pbLong.Maximum; cpt++)
            //        {
            //            // Attente de 1 ms, pour laisser le temps à l'IHM de se rafraichir
            //            Thread.Sleep(1);
            //            pbLong.Value = cpt;
            //            lbLong.Text = cpt.ToString();
            //        }
            //    }
            //}

        #endregion

        #region "Traitement long pris en charge par un Thread actif (classe MonThread) : Version 2"

            GestionThread customThread;
            Thread monThread;
            //délégué utilisé par le gestionnaire de Thread pour demander le
            //rafraichissement du formulaire
            public delegate void DelegateRefreshData(int returnData);

            private void btStartThread_Click(object sender, EventArgs e)
            {
                //
                //initialiser la progressBar
                //
                pbThread.Minimum = 0;
                pbThread.Maximum = 1000;
                pbThread.Value = pbThread.Minimum;

                //
                //Instancier la gestionnaire de Thread
                //
                customThread = new GestionThread()
                {
                    compteur = pbThread.Maximum,
                    Callback = new DelegateRefreshData(this.refreshData)
                };
                // Instanciation du thread, on spécifie dans le 
                // délégué ThreadStart le nom de la méthode qui
                // sera exécutée lorsque l'on appelle la méthode
                // Start() de notre thread.
                monThread = new Thread(new ThreadStart(customThread.traiterAction));

                // Lancement du thread
                monThread.Start();
            }

            private void btStopThread_Click(object sender, EventArgs e)
            {
                if (monThread != null && monThread.IsAlive)
                    // Détruit notre thread
                    monThread.Abort();
            }

            /// <summary>
            /// méthode appelée par le thread actif demandant le rafraichissement des données
            /// </summary>
            /// <param name="data"></param>
            private void refreshData(int data)
            {
                // 
                // updateUI s'execute dans le Thread principale.
                // 
                this.Invoke(new DelegateRefreshData(updateUI), new Object[] { data });
            }

            private void updateUI(int data)
            {
                pbThread.Value = data;
                lbThread.Text = data.ToString();
            }

        #endregion
        
        
        #region "Traitement long pris en charge par une fonction asynchrone (C# 5)"
            
            private void btStartAsync_Click(object sender, EventArgs e)
            {
                //
                //initialiser la progressBar
                //
                pbAsync.Minimum = 0;
                pbAsync.Maximum = 100000;
                pbAsync.Value = pbLong.Minimum;

                traiterAction();
            }

            private void btStopAsync_Click(object sender, EventArgs e)
            {
                
            }

            private async void traiterAction()
            {
                await Task.Run(() =>
                    {
                        int cpt = 0;

                        for (cpt = 0; cpt <= pbAsync.Maximum; cpt++)
                        {
                            refreshDataAsync(cpt);
                        }
                    });
               
            }

            /// <summary>
            /// méthode appelée par le thread actif demandant le rafraichissement des données
            /// </summary>
            /// <param name="data"></param>
            private void refreshDataAsync(int data)
            {
                // 
                // updateUI s'execute dans le Thread principale.
                // 
                this.Invoke(new DelegateRefreshData(updateUIAsync), new Object[] { data });
            }

            private void updateUIAsync(int data)
            {
                pbAsync.Value = data;
                lbAsync.Text = data.ToString();
            }
        #endregion



    }
}



