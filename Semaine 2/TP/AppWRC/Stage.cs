using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.WRC
{

    class Stage
    {
        public enum StageType
        {
            qualifying,
            special,
            route
        }
        #region attributes
        private const int MAX_STAGETIME = 100;
        private int nbStageTime = 0;
        #endregion
        
        #region properties
        public string Name { get; private set; }
        public StageTime[] StageTimes { get; private set; }
        #endregion

        #region constructors
        public Stage(string name, decimal km, int day, DateTime hour, StageType st)
        {
            Name = name;
            StageTimes = new StageTime[MAX_STAGETIME];
        }
        #endregion

        #region methods
        public void addStageTime(StageTime st)
        {
            if (MAX_STAGETIME > nbStageTime + 1) this.StageTimes[nbStageTime++] = st;
        }
        #endregion
    }
}
