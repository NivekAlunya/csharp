using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Controler
{
    class EmployeeController
    {
        #region attributes
        private EmployeeController _instance = null;
        #endregion
        #region properties
        public EmployeeController Instance { 
            get 
            {
                return _instance == null ? this._instance = new EmployeeController() : this._instance;
            }
        }

        #endregion
        #region constructors
        private EmployeeController()
            :base()
        { 
        
        }
        #endregion
        #region methods
        public void addEmployee()
        {
        }
        public void updateEmployee()
        {
        }
        public void removeEmployee()
        {

        }
        #endregion
        #region interfaces
        #endregion
    }
}
