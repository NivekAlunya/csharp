using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace modele
{
 public class Saison
 {
	private int _annee;
	private List<Spectacle> _spectacles;

	public Saison()
	{
		_spectacles = new List<Spectacle> ();
	}


	public int annee
	{
	 get { return _annee; }
	 set { _annee = value; }
	}

    public List<Spectacle> spectacles
	{
	 get
	 {
		return _spectacles;
	 }
	 set
	 {
		 _spectacles = value;
	 }
	}

	public void ajouterSpectacle(Spectacle s)
	{
		_spectacles.Add(s);
	}

	public void annulerSpectacle(Spectacle s)
	{
		foreach (Representation r in s.representations)
		{
			s.annulerRepresentation(r);
		}
	}

	public void lireFichier(String nomFichier)
	{
		StreamReader sr = null;
        //vider la liste des spectacles
        _spectacles.Clear();
		try
		{
			if (File.Exists(nomFichier))
			{
				sr = File.OpenText(nomFichier);
				String ligne;
				while (!sr.EndOfStream)
				{
					ligne = sr.ReadLine();
					string[] data = ligne.Split(new Char[] { ';' });
						Spectacle sp;
						sp= new Spectacle();
						sp.titre = data[0];
						sp.duree = int.Parse(data[1]);
						sp.producteur = data[2];
						switch (data[3])
						{
							case "concert":
								sp.type = typeSpectacle.concert;
								break;
							case "danse":
								sp.type = typeSpectacle.danse;
								break;
							case "oneManShow":
								sp.type = typeSpectacle.oneManShow;
								break;
							case "theatre" :
								sp.type = typeSpectacle.theatre;
								break;
						}
						ajouterSpectacle(sp);
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
