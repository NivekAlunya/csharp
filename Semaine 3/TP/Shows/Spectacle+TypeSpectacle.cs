using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shows
{
    public enum TypeSpectacle {
        concert,
        theatre,
        oneManShow,
        danse
    }
    public class Spectacle
    {
        #region attributes
        private int _duree;
        private string _producteur;
        private string _titre;
        private List<Representation> _representations;
        private TypeSpectacle _type;
        #endregion
        #region properties
        public int Duree { get; set; }
        public string Producteur { get; set; }
        public string  Titre { get; set; }
        public TypeSpectacle Type { get; set; }
        public List<Representation> Representations { get { return _representations; } set { _representations = value ;} }
        #endregion
        #region constructors
        public Spectacle()
            :base()
        {
            Representations = new List<Representation>();
        }
        #endregion
        #region methods
                    
        public void ajouterRepresentation(Representation representation)
        {
            this.Representations.Add(representation);
        }

        public void annulerRepresentation(Representation representation)
        {
            foreach(Representation r in this.Representations)
            {
                if (r == representation)
                {
                    this.Representations.Remove(representation);
                    break;
                }
            }
        }
        public List<Representation> rechercherPlaceDisponible(int nb)
        {
            List<Representation> lr = new List<Representation>();
            foreach(Representation r in this.Representations)
            {
                if (r.PlacesDispo >= nb) lr.Add(r);
            }

            return lr;
        }

        #endregion
        #region overrides
        public override string ToString()
        {
            return string.Format("{3} : {2} - {1} ({0})",this.Duree,this.Producteur,this.Titre,this.Type);
        }
        #endregion

    }
}
