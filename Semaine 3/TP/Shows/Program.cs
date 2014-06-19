using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shows
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
                        if (numSpec > 0 && numSpec <= s.spectacles.Count)
                            //appeler le sous menu en lui passant le spectacle séléctionné
                            MnuRepresentations(s.spectacles.ElementAt(numSpec - 1));
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
                foreach (Representation rp in spectacle.Representations)
                {
                    num++;
                    Console.WriteLine("{0} - date : {1} places libres : {2} tarif : {3}", num, rp.Date, rp.PlacesDispo, rp.Tarif);
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
                        Console.WriteLine("\nEntrer le numero du spectacle à supprimer ?");
                        int numero;
                        if (int.TryParse(Console.ReadLine(), out numero))
                            if (0 < numero && spectacle.Representations.Count > numero-1)
                                spectacle.annulerRepresentation(spectacle.Representations[numero-1]);

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
            string repertoireApplication = @"d:\data\spectacles.csv";
            s.lireFichier(repertoireApplication);
            foreach (Spectacle sp in s.spectacles)
            {
                /*
                 * construction dynamique d'une représentation par spectacle
                 */
                Representation rp;
                rp = new Representation();
                rp.PlacesDispo = (int)(300 * aleat.NextDouble());
                rp.Tarif = 25 * aleat.NextDouble();
                rp.Date = DateTime.Now;
                rp.Date = rp.Date.AddDays(30 * aleat.NextDouble());
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
                            rp.PlacesDispo = int.Parse(_places);
                            rp.Tarif = double.Parse(_tarif);
                            rp.Date = DateTime.Parse(_date);
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
            string repertoireApplication = @"d:\data\clients.csv";
            fc.lireFichier(repertoireApplication);
        }

        /// <summary>
        /// Ajouter/Modifier un client
        /// </summary>
        /// <param name="s"></param>
        private static char enterClient(Client c = null)
        {
            char choix = '\u0000'; //unicode de null
            string _nom = null;
            string _prenom = null;
            string _tel = null;
            string _mail = null;
            char _reponse;
            //pour un abonné
            string _anneeA = null;
            string _solde = null;
            //pour un non abonné
            string _numCB = null;
            string _dateValide = null;
            string _cvc = null;

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
                        case 'N':
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
                    Console.Write("Nom ({0}) : ", c.Nom);
                    _nom = Console.ReadLine();
                    Console.Write("Prenom ({0}) : ", c.Prenom);
                    _prenom = Console.ReadLine();
                    Console.Write("Telephone ({0}) : ", c.Tel);
                    _tel = Console.ReadLine();
                    Console.Write("Mail ({0}) : ", c.Mail);
                    _mail = Console.ReadLine();
                    if (c is ClientAbonne)
                    {
                        abonne = true;
                        Console.Write("Année abonnement ({0}) : ", ((ClientAbonne)c).AnneeAbonnement);
                        _anneeA = Console.ReadLine();
                        Console.Write("Solde ({0}): ", ((ClientAbonne)c).Solde);
                        _solde = Console.ReadLine();
                    }
                    else
                    {
                        abonne = false;
                        Console.Write("N° CB ({0}) : ", ((ClientNonAbonne)c).NumCB);
                        _numCB = Console.ReadLine();
                        Console.Write("Expire fin (JJ/MM/YYYY)({0}) : ", ((ClientNonAbonne)c).DateValide);
                        _dateValide = Console.ReadLine();
                        Console.Write("Cryptogramme (3 chiffres)  : ", ((ClientNonAbonne)c).Cvc);
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
                            Client client;
                            if (ajout)
                            {
                                if (abonne)
                                {
                                    //ici, on crée un nouvel abonne
                                    ClientAbonne ca = new ClientAbonne();
                                    ca.AnneeAbonnement = int.Parse(_anneeA);
                                    ca.Solde = double.Parse(_solde);

                                    client = (Client)ca;
                                }
                                else
                                {
                                    //ici, on crée un nouvel non abonné
                                    ClientNonAbonne cna = new ClientNonAbonne();
                                    cna.NumCB = _numCB;
                                    cna.DateValide = DateTime.Parse(_dateValide);
                                    cna.Cvc = int.Parse(_cvc);
                                    client = (Client)cna;
                                }
                                
                                client.Nom = _nom;
                                client.Prenom = _prenom;
                                client.Tel = _tel;
                                client.Mail = _mail;
                                //ajout du client à la liste des clients
                                fc.clients.Add(client);
                            }
                            else
                            {
                                if (abonne)
                                {
                                    //ici, on modifie un abonné
                                    ClientAbonne ca = (ClientAbonne)c;
                                    ca.AnneeAbonnement = (_anneeA == null ? ca.AnneeAbonnement : int.Parse(_anneeA));
                                    ca.Solde = (_solde == null ? ca.Solde : double.Parse(_solde));
                                    client = (Client)ca;
                                }
                                else
                                {
                                    //ici, on modifie un non abonné
                                    ClientNonAbonne cna = (ClientNonAbonne)c;
                                    cna.NumCB = (_numCB == null ? cna.NumCB : _numCB);
                                    cna.DateValide = (_dateValide == null ? cna.DateValide : DateTime.Parse(_dateValide));
                                    cna.Cvc = (_cvc == null ? cna.Cvc : int.Parse(_cvc));
                                    client = (Client)cna;
                                }
                                client.Nom = (_nom == null ? client.Nom : _nom);
                                client.Prenom = (_prenom == null ? client.Prenom : _prenom);
                                client.Tel = (_tel == null ? client.Tel : _tel);
                                client.Mail = (_mail == null ? client.Mail : _mail);
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
                bool cliOK = false;
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
                        foreach (Representation representation in spectacle.Representations)
                        {
                            numr++;
                            Console.WriteLine("\t {0} - date : {1} places libres : {2} tarif : {3}", numr, representation.Date, representation.PlacesDispo, representation.Tarif);
                        }
                    }
                    /*
                     * choisir le spectacle dans la liste
                     */
                    Console.Write("Saisir le n° de la représentation : ");
                    int numSaisi = int.Parse(Console.ReadLine());
                    int numSpec = (int)(numSaisi / 10);
                    int numRep = numSaisi % 10;

                    //la représentation existe-t-elle ?

                    if( 0>numSpec - 1 || s.spectacles.Count <= numSpec - 1) continue;

                    if (numRep > 0 && numRep <= s.spectacles.ElementAt(numSpec - 1).Representations.Count)
                    {
                        cliOK = true;
                        //conserver la référence de la représentation choisie
                        repChoisie = s.spectacles.ElementAt(numSpec - 1).Representations.ElementAt(numRep - 1);
                    }
                    else
                    {
                        Console.WriteLine("Cette représentation n'existe pas ! Appuyez sur une touche pour revoir la liste.");
                        Console.ReadKey();
                    }
                } while (!cliOK);

                Console.Clear();
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("--- Liste des réservations pour cette représentation ---");
                Console.WriteLine(Environment.NewLine);
                int numResa = 0;
                foreach (Reservation resa in repChoisie.Reservations)
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
                Console.Write("Nb places souhaitées ({0} disponibles) : ", rep.PlacesDispo);
                _places = Console.ReadLine();
                Console.WriteLine("Montant : {0}", rep.Tarif * int.Parse(_places));
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
                            rep.ajouterReservation(_client, int.Parse(_places));
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
            if (numSaisi > 0 && numSaisi <= rep.Reservations.Count)
            {
                try
                {
                    //supprimer la réservation
                    rep.annulerReservation(rep.Reservations.ElementAt(numSaisi - 1).Client);
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
