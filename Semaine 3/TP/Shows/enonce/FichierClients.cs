using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace modele
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
		if (c.mail.Equals(mail))
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
					ligne = sr.ReadLine();
					string[] data = ligne.Split(new Char[] {';'});
					if (data[8].Equals(""))
					{
						ClientNonAbonne nab;
						nab = new ClientNonAbonne();
						nab.nom = data[0];
						nab.prenom = data[1];
						nab.mail = data[2];
						nab.tel = data[3];
						nab.numCB = data[4];
						nab.cvc = int.Parse(data[5]);
						nab.dateValide =DateTime.Parse( data[6]);
						ajouterClient(nab);
					}
					else
					{
						ClientAbonne ab;
						ab = new ClientAbonne();
						ab.nom = data[0];
						ab.prenom = data[1];
						ab.mail = data[2];
						ab.tel = data[3];
						ab.solde =double.Parse(data[7]);
						ab.anneeAbonnement = int.Parse(data[8]);
						ajouterClient(ab);
					}

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
