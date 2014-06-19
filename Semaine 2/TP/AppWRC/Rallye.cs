using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.WRC
{

    class Rallye
    {
        #region attributes
        private int nbStages = 0;
        const int MAX_STAGES = 20;
        #endregion

        #region properties
        public Stage[] Stages { get; private set; }
        public string Title {get;private set;}
        #endregion

        #region constructors
        public Rallye(string title,DateTime dt)
        {
            Stages = new Stage[MAX_STAGES];
            Title = title;
        }
        #endregion
        
        #region methods
        public void addStage(Stage ss)
        {
            if (MAX_STAGES > nbStages + 1) this.Stages[nbStages++] = ss;
        }
        public string informations()
        {
            StringBuilder sb = new StringBuilder();
            
            return sb.AppendLine(this.Title).ToString();
        }
        public string listStages()
        {
            StringBuilder sb = new StringBuilder();
            for(int i=0;i<this.nbStages;++i)
                sb.AppendLine(this.Stages[i].Name);

            return sb.ToString();
        }
        #endregion
    }
}
