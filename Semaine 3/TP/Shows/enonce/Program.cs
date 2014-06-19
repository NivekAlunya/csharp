using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using modele;
using System.IO;
using System.Reflection;

namespace ConsoleApplication1
{
    class Program
    {

        /*
         * variable globale
         */
        static Saison s = new Saison();
        static FichierClients fc = new FichierClients();

        static void Main(string[] args)
        {
            /*
            * Menu principal
            */
            char choix = '\u0000'; //unicode de null

            initializeData();

            do
            {
                Console.Clear();
                Console.WriteLine("--- MENU PRINCIPAL ---");
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("1- Spectacles et représentations");
                Console.WriteLine("2- Clients");
                Console.WriteLine("3- Réservations");
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Esc. pour quitter");
                choix = Console.ReadKey().KeyChar;
                switch (choix)
                {
                    case '1':
                        MnuSpectacles(); //appeler le sous menu 1
                        break;
                    case '2':
                        MnuClients(); //appeler le sous menu 2
                        break;
                    case '3':
                        MnuReservations();
                        break;
                    //TODO à compléter                  
                }
            } while (choix != '\u001b'); //unicode de Esc

        }

        /// <summary>
        /// monter les données en mémoire
        /// </summary>
        private static void initializeData()
        {
            recupClients();
            recupSpectacles();
        }

        #region "Spectacles et représentations"

        /// <summary>
        /// Sous menu de gestion des spectacles et réservations
        /// </summary>
        private static void MnuSpectacles()
        {
            char choix = '\u0000'; //unicode de null
            
            do
            {
                Console.Clear();
                Console.WriteLine("--- Liste des spectacles ---");
                Console.WriteLine(Environment.NewLine);
                /*
                 * afficher les spectacles de la saison
                 */
                int num = 0;
                foreach (Spectacle spectacle in s.spectacles)
                {
                    num++;
                    Console.WriteLine("{0} - {1}", num, spectacle.ToString());
                }

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("R. représentations - P. menu principal");
                choix = Console.ReadKey().KeyChar;
                switch (choix)
                {
                    case 'r':
                    case 'R':
                        /*
                         * choisir le spectacle dans la liste
                         */
                        Console.Write("Saisir le n° du spectacle : ");
                        int numSpec = int.Parse(Console.ReadLine());
                        if ( numSpec > 0 && numSpec <= s.spectacles.Count)
                            //appeler le sous menu en lui passant le spectacle séléctionné
                            MnuRepresentations(s.spectacles.ElementAt(numSpec-1)); 
                        break;
                }
            } while (choix != 'P' && choix != 'p');
        }

        /// <summary>
        /// Lister les représentations d'un spectacle
        /// </summary>
        /// <returns></returns>
        private static char MnuRepresentations(Spectacle spectacle)
        {
            char choix = '\u0000'; //unicode de null
            do
            {
                Console.Clear();
                Console.WriteLine("--- {0} ---", spectacle.ToString());
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("--- Liste des représentations ---");
                Console.WriteLine(Environment.NewLine);
                int num = 0;
                foreach (Representation rp in spectacle.representations)
                {
                    num++;
                    Console.WriteLine("{0} - date : {1} places libres : {2} tarif : {3}", num,rp.date, rp.placesDispo, rp.tarif);
                }
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("A. ajouter - S. supprimer - P. Retour menu principal");
                choix = Console.ReadKey().KeyChar;
                switch (choix)
                {
                    case 'a':
                    case 'A':
                        enterRepresentation(spectacle);

                        break;

                    case 's':
                    case 'S':
                        break;
                }
            } while (choix != 'p' && choix != 'P'); //unicode de P et p
            return choix;
        }

        /// <summary>
        /// charger les spectacles de la saison en mémoire
        /// </summary>
        private static void recupSpectacles()
        {
            Random aleat = new Random();
            string repertoireApplication = Environment.CurrentDirectory + @"\Data\spectacles.csv";
            s.lireFichier(repertoireApplication);
            foreach (Spectacle sp in s.spectacles)
            {
                /*
                 * construction dynamique d'une représentation par spectacle
                 */
                Representation rp;
                rp = new Representation();
                rp.placesDispo = (int)(300 * aleat.NextDouble());
                rp.tarif = 25 * aleat.NextDouble();
                rp.date = DateTime.Now;
                rp.date = rp.date.AddDays(30 * aleat.NextDouble());
                /*
                 * ajouter la représentation au spectacle
                 */
                sp.ajouterRepresentation(rp);
            }
        }

        /// <summary>
        /// Ajouter une nouvelle représentation au spectacle
        /// </summary>
        /// <param name="s"></param>
        private static char enterRepresentation(Spectacle s)
        {
            char choix = '\u0000'; //unicode de null
            string _date;
            string _places;
            string _tarif;
            do
            {
                Console.Clear();
                Console.WriteLine("--- {0} ---", s.ToString());
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("--- Nouvelle représentation ---");
                Console.WriteLine(Environment.NewLine);
                /*
                 * saisir les informations
                 */
                Console.Write("Date représentation : ");
                _date = Console.ReadLine();
                Console.Write("Nb places disponibles : ");
                _places = Console.ReadLine();
                Console.Write("tarif : ");
                _tarif = Console.ReadLine();
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("V. valider - P. Retour menu principal");
                choix = Console.ReadKey().KeyChar;
                switch (choix)
                {
                    case 'v':
                    case 'V':
                        try 
	                    {	
                            /*
                             * construire la représentation en mémoire
                             */
                            Representation rp = new Representation();
                            rp.placesDispo = int.Parse(_places);
                            rp.tarif = double.Parse(_tarif);
                            rp.date = DateTime.Parse(_date);
                            /*
                            * ajouter la représentation au spectacle
                            */
		                    s.ajouterRepresentation(rp);
	                    }
	                    catch (Exception)
	                    {
		                    Console.WriteLine("Erreur lors de la création de la représentation.");
	                    }
                        
                        break;
                }
            } while (choix != 'p' && choix != 'P' && choix != 'v' && choix != 'V'); 
            return choix;
        }
        
        #endregion

        #region "Clients"
        /// <summary>
        /// Sous menu de gestion des clients
        /// </summary>
        private static void MnuClients()
        {
            char choix = '\u0000'; //unicode de null

            do
            {
                Console.Clear();
                Console.WriteLine("--- Liste des clients ---");
                Console.WriteLine(Environment.NewLine);
                /*
                 * afficher les clients
                 */
                int num = 0;
                foreach (Client client in fc.clients)
                {
                    num++;
                    if (client is ClientAbonne)
                        Console.WriteLine("{0} - {1} ({2})", num, client.ToString(), "A");
                    else
                        Console.WriteLine("{0} - {1} ({2})", num, client.ToString(), "NA");
                }

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("A. ajouter - M. modifier - P. menu principal");
                choix = Console.ReadKey().KeyChar;
                switch (choix)
                {
                    case 'a':
                    case 'A':
                        enterClient();
                        break;
                    case 'm':
                    case 'M':
                        /*
                         * choisir le client dans la liste
                         */
                        Console.Write("Saisir le n° du client à modifier : ");
                        int numCli = int.Parse(Console.ReadLine());
                        if (numCli > 0 && numCli <= fc.clients.Count)
                            //appeler le sous menu en lui passant le client séléctionné
                            enterClient(fc.clients.ElementAt(numCli - 1));
                        break;
                }
            } while (choix != 'P' && choix != 'p');
        }

        /// <summary>
        /// charger les clients en mémoire
        /// </summary>
        private static void recupClients()
        {
            string repertoireApplication = Environment.CurrentDirectory + @"\Data\clients.csv";
            fc.lireFichier(repertoireApplication);
        }

        /// <summary>
        /// Ajouter/Modifier un client
        /// </summary>
        /// <param name="s"></param>
        private static char enterClient(Client c=null)
        {
            char choix = '\u0000'; //unicode de null
            string _nom=null;
            string _prenom=null;
            string _tel=null;
            string _mail=null;
            char _reponse;
            //pour un abonné
            string _anneeA=null;
            string _solde=null;
            //pour un non abonné
            string _numCB=null;
            string _dateValide=null;
            string _cvc=null;

            bool ajout = false;
            bool abonne = false;

            do
            {
                Console.Clear();

                if (c == null)
                    ajout = true; 

                if (ajout)

                {
                    //ici, on crée un nouveau client
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("--- Nouveau client ---");
                    Console.WriteLine(Environment.NewLine);
                    /*
                     * saisir les informations
                     */
                    Console.Write("Nom : ");
                    _nom = Console.ReadLine();
                    Console.Write("Prenom : ");
                    _prenom = Console.ReadLine();
                    Console.Write("Telephone : ");
                    _tel = Console.ReadLine();
                    Console.Write("Mail : ");
                    _mail = Console.ReadLine();
                    do
                    {
                        Console.WriteLine(Environment.NewLine);
                        Console.Write("Abonné (O/N) : ");
                        _reponse = Console.ReadKey().KeyChar;
                    } while (_reponse != 'o' && _reponse != 'O' && _reponse != 'n' && _reponse != 'N');
                    switch (_reponse)
                    {
                        case 'o':
                        case 'O':
                            abonne = true;
                            Console.Write("Année abonnement : ");
                            _anneeA = Console.ReadLine();
                            Console.Write("Solde : ");
                            _solde = Console.ReadLine();
                            break;
                        case 'n':
                        case 'N' :
                            abonne = false;
                            Console.Write("N° CB : ");
                            _numCB = Console.ReadLine();
                            Console.Write("Expire fin (JJ/MM/YYYY) : ");
                            _dateValide = Console.ReadLine();
                            Console.Write("Cryptogramme (3 chiffres) : ");
                            _cvc = Console.ReadLine();
                            break;
                    }
                    Console.WriteLine(Environment.NewLine);
                }
                else
                {
                    //ici, on modifie un client existant
                    //ici, on crée un nouveau client
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("--- Modification client ---");
                    Console.WriteLine(Environment.NewLine);
                    /*
                     * saisir les informations
                     */
                    Console.Write("Nom ({0}) : ", c.nom);
                    _nom = Console.ReadLine();
                    Console.Write("Prenom ({0}) : ", c.prenom);
                    _prenom = Console.ReadLine();
                    Console.Write("Telephone ({0}) : ", c.tel);
                    _tel = Console.ReadLine();
                    Console.Write("Mail ({0}) : ", c.mail);
                    _mail = Console.ReadLine();
                    if (c is ClientAbonne)
                    {
                        abonne = true;
                        Console.Write("Année abonnement ({0}) : ",((ClientAbonne)c).anneeAbonnement);
                        _anneeA = Console.ReadLine();
                        Console.Write("Solde ({0}): ",((ClientAbonne)c).solde);
                        _solde = Console.ReadLine();
                    }
                    else
                    {
                        abonne = false;
                        Console.Write("N° CB ({0}) : ", ((ClientNonAbonne)c).numCB);
                        _numCB = Console.ReadLine();
                        Console.Write("Expire fin (JJ/MM/YYYY)({0}) : ", ((ClientNonAbonne)c).dateValide);
                        _dateValide = Console.ReadLine();
                        Console.Write("Cryptogramme (3 chiffres)  : ", ((ClientNonAbonne)c).cvc);
                        _cvc = Console.ReadLine();
                    }
                    Console.WriteLine(Environment.NewLine);
                }
                
                Console.WriteLine("V. valider - P. Retour menu principal");
                choix = Console.ReadKey().KeyChar;
                switch (choix)
                {
                    case 'v':
                    case 'V':
                        try
                        {
                            if (ajout)
                            {
                                if (abonne)
                                {
                                    //ici, on crée un nouvel abonne
                                    ClientAbonne ca = new ClientAbonne();
                                    ca.nom = _nom;
                                    ca.prenom = _prenom;
                                    ca.tel = _tel;
                                    ca.mail = _mail;
                                    ca.anneeAbonnement = int.Parse(_anneeA);
                                    ca.solde = double.Parse(_solde);

                                    //ajout de l'abonné à la liste des clients
                                    fc.clients.Add(ca);
                                }
                                else
                                {
                                    //ici, on crée un nouvel non abonné
                                    ClientNonAbonne cna = new ClientNonAbonne();
                                    cna.nom = _nom;
                                    cna.prenom = _prenom;
                                    cna.tel = _tel;
                                    cna.mail = _mail;
                                    cna.numCB = _numCB;
                                    cna.dateValide = DateTime.Parse(_dateValide);
                                    cna.cvc = int.Parse(_cvc);

                                    //ajout du non abonné à la liste des clients
                                    fc.clients.Add(cna);
                                }
                            }
                            else
                            {
                                if (abonne)
                                {
                                    //ici, on modifie un abonné
                                    ClientAbonne ca = (ClientAbonne)c;
                                    ca.nom = (_nom == null ? ca.nom:_nom);
                                    ca.prenom = (_prenom == null ? ca.prenom : _prenom);
                                    ca.tel = (_tel == null ? ca.tel:_tel);
                                    ca.mail = (_mail == null ? ca.mail:_mail);
                                    ca.anneeAbonnement = (_anneeA == null ? ca.anneeAbonnement:int.Parse(_anneeA));
                                    ca.solde = (_solde == null ? ca.solde : double.Parse(_solde));
                                }
                                else
                                {
                                    //ici, on modifie un non abonné
                                    ClientNonAbonne cna = (ClientNonAbonne)c;
                                    cna.nom = (_nom == null ? cna.nom : _nom);
                                    cna.prenom = (_prenom == null ? cna.prenom : _prenom);
                                    cna.tel = (_tel == null ? cna.tel : _tel);
                                    cna.mail = (_mail == null ? cna.mail : _mail);
                                    cna.numCB = (_numCB==null ? cna.numCB:_numCB);
                                    cna.dateValide = (_dateValide==null ? cna.dateValide : DateTime.Parse(_dateValide));
                                    cna.cvc = (_cvc==null ? cna.cvc : int.Parse(_cvc));
                                }
                            }
                            
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Erreur lors de la création/modification du client.");
                        }

                        break;
                }
            } while (choix != 'p' && choix != 'P' && choix != 'v' && choix != 'V');
            return choix;
        }
        
        #endregion

        #region "Réservations"
        /// <summary>
        /// Sous menu de gestion des spectacles et réservations
        /// </summary>
        private static void MnuReservations()
        {
            char choix = '\u0000'; //unicode de null
            Representation repChoisie = null;

            do
            {
                bool cliOK = true;
                do
                {
                    Console.Clear();
                    Console.WriteLine("--- Choisissez une représentation dans la liste ---");
                    Console.WriteLine(Environment.NewLine);
                    /*
                     * afficher les spectacles et les représentations associées de la saison
                     */
                    int num = 0;
                    foreach (Spectacle spectacle in s.spectacles)
                    {
                        num++;
                        Console.WriteLine("{0} - {1}", num, spectacle.ToString());
                        int numr = num * 10;
                        foreach (Representation representation in spectacle.representations)
                        {
                            numr++;
                            Console.WriteLine("\t {0} - date : {1} places libres : {2} tarif : {3}", numr, representation.date, representation.placesDispo, representation.tarif);
                        }
                    }
                    /*
                     * choisir le spectacle dans la liste
                     */
                    Console.Write("Saisir le n° de la représentation : ");
                    int numSaisi = int.Parse(Console.ReadLine());
                    int numSpec = (int)(numSaisi / 10);
                    int numRep = numSaisi%10;
                    
                    //la représentation existe-t-elle ?
                    if (numRep > 0 && numRep <= s.spectacles.ElementAt(numSpec - 1).representations.Count)
                    {
                        cliOK = true;
                        //conserver la référence de la représentation choisie
                        repChoisie = s.spectacles.ElementAt(numSpec - 1).representations.ElementAt(numRep - 1);
                    }
                    else
                    {
                        cliOK = false;
                        Console.WriteLine("Cette représentation n'existe pas ! Appuyez sur une touche pour revoir la liste.");
                        Console.ReadKey();
                    }
                } while (!cliOK);

                Console.Clear();
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("--- Liste des réservations pour cette représentation ---");
                Console.WriteLine(Environment.NewLine);
                int numResa = 0;
                foreach (Reservation resa in repChoisie.reservations)
                {
                    numResa++;
                    Console.WriteLine("{0} - {1}", numResa, resa.ToString());
                }
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("A. ajouter - S. supprimer - P. Retour menu principal");
                choix = Console.ReadKey().KeyChar;
                switch (choix)
                {
                    case 'a':
                    case 'A':
                        enterReservation(repChoisie);
                        break;

                    case 's':
                    case 'S':
                        delReservation(repChoisie);
                        break;
                }
            } while (choix != 'P' && choix != 'p');
        }

        private static char enterReservation(Representation rep)
        {
            char choix = '\u0000'; //unicode de null

            Client _client = null;
            string _places = null;
            do
            {
                Console.Clear();
                Console.WriteLine("--- {0} ---", rep.ToString());
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("--- Nouvelle réservation ---");
                Console.WriteLine(Environment.NewLine);
                /*
                 * saisir les informations
                 */
                bool cliOK = true;
                do
                {
                    Console.Clear();
                    Console.WriteLine("--- Choisissez un client dans la liste ---");
                    Console.WriteLine(Environment.NewLine);
                    /*
                     * afficher les clients
                     */
                    int num = 0;
                    foreach (Client client in fc.clients)
                    {
                        num++;
                        Console.WriteLine("{0} - {1}", num, client.ToString());
                    }
                    /*
                     * choisir le client dans la liste
                     */
                    Console.Write("Saisir le n° du client : ");
                    int numSaisi = int.Parse(Console.ReadLine());

                    //le client existe-t-il ?
                    if (numSaisi > 0 && numSaisi <= fc.clients.Count)
                    {
                        cliOK = true;
                        //conserver la référence du client choisi
                        _client = fc.clients.ElementAt(numSaisi - 1);
                    }
                    else
                    {
                        cliOK = false;
                        Console.WriteLine("Ce client n'existe pas ! Appuyez sur une touche pour revoir la liste.");
                        Console.ReadKey();
                    }
                } while (!cliOK);

                Console.Clear();
                Console.WriteLine("--- {0} ---", rep.ToString());
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("--- Nouvelle réservation ---");
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Client : {0}", _client.ToString());
                Console.Write("Nb places souhaitées ({0} disponibles) : ",rep.placesDispo);
                _places = Console.ReadLine();
                Console.WriteLine("Montant : {0}", rep.tarif * int.Parse(_places));
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("V. valider - P. Retour menu principal");
                choix = Console.ReadKey().KeyChar;
                switch (choix)
                {
                    case 'v':
                    case 'V':
                        try
                        {
                            /*
                            * ajouter la reservation à la représentation
                            */
                            rep.ajouterReservation(_client,int.Parse(_places));
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Erreur lors de la création de la représentation.");
                        }

                        break;
                }
            } while (choix != 'p' && choix != 'P' && choix != 'v' && choix != 'V');
            return choix;
        }

        private static void delReservation(Representation rep)
        {
            /*
             * choisir le spectacle dans la liste
             */
            Console.Write("Saisir le n° de la réservation : ");
            int numSaisi = int.Parse(Console.ReadLine());
            //la réservation existe-t-elle ?
            if (numSaisi > 0 && numSaisi <= rep.reservations.Count)
            {
                try
                {
                    //supprimer la réservation
                    rep.annulerReservation(rep.reservations.ElementAt(numSaisi - 1).client);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "\nAppuyez sur une touche pour revoir la liste.");
                    Console.ReadKey();
                }
                
            }
            else
            {
                Console.WriteLine("Cette réservation n'existe pas ! Appuyez sur une touche pour revoir la liste.");
                Console.ReadKey();
            }
        }
        #endregion
    }
        

}
 



