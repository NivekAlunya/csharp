using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace delegue {
    class ChambreDHote {
        public String nom { get; set; }
        public int nbChambres { get; set; }
        public decimal tarifNuit { get; set; }
        public bool labelQualite { get; set; }
        public String ville { get; set; }

        public override string ToString() {
            return nom + " [" + ville + "] "+(labelQualite?"avec Label Qualité ":"")+": " + nbChambres + " chambres à " + tarifNuit + "euros/nuité";
        }
    }
}
