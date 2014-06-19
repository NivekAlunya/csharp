using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Shows
{
 public class FichierClients
 {
	List<Client> _clients;

	public FichierClients()
	{
		_clients = new List<Client>();

	}
    public List<Client> clients
	{
		get
		{
			return _clients;
		}
		set
		{
			_clients = value;
		}
	}
	public void ajouterClient(Client c)
	{
	 _clients.Add(c);
	}

	public Client rechercherClient(String mail)
	{
	 foreach (Client c in _clients)
	 {
		if (c.Mail.Equals(mail))
		{
		 return c;
		}
	 }
	 return null;
	}
	public  void lireFichier(String nomFichier)
	{
		StreamReader sr = null;
      
		try
		{
			if (File.Exists(nomFichier))
			{
				sr = File.OpenText(nomFichier);
				String ligne;
				while (!sr.EndOfStream)
				{
                    Client client;
                    ligne = sr.ReadLine();
					string[] data = ligne.Split(new Char[] {';'});
					if (data[8].Equals(""))
					{
                        ClientNonAbonne cna = new ClientNonAbonne();
                        cna.NumCB = data[4];
                        cna.Cvc = int.Parse(data[5]);
                        cna.DateValide = DateTime.Parse(data[6]);
                        client = (Client)cna;
					}
					else
					{
                        ClientAbonne ca;
                        ca = new ClientAbonne();
                        ca.Solde = double.Parse(data[7]);
                        ca.AnneeAbonnement = int.Parse(data[8]);
                        client = (Client)ca;
					}
                    client.Nom = data[0];
                    client.Prenom = data[1];
                    client.Mail = data[2];
                    client.Tel = data[3];
                    ajouterClient(client);

				}
			}
		}
		catch (Exception e)
		{
			//En cas de problème d'accès au fichier
			Console.WriteLine(e.Message);
			Console.WriteLine("Problème de lecture du fichier.");
			Console.WriteLine("Appuyez sur une touche pour continuer...");
			Console.ReadKey();
		}
		finally
		{
			//Dans tous les cas
			if (sr != null)
				sr.Close();
		}

	}

 }
}
