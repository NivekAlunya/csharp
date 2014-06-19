using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCompany.Tools;

namespace Employees.Model
{
    public class Service : ICloneable
    {
        #region attributes
        private string _code;
        private string _label;
        private event LoggerEventArgs.LoggerEventHandler evtLog;
        #endregion
        #region properties
        /// <summary>
        /// get or set the code of a service
        /// </summary>
        /// <exception cref="Exception on Code setter"></exception>
        public string Code
        {
            get
            {
                return _code;
            }
            set 
            {
                if (string.IsNullOrWhiteSpace(value)) throw new Exception("Code can't be null or empty!!!");
                if (!value.Trim().isServiceCode()) throw new Exception("Code must contain only 5 letters , digits or - or _ !!!");
                this.log("Code : " +_code + ">>" + value);
                _code = value.Trim().ToUpper();
            }
        }

        /// <summary>
        /// get or set the label of a service
        /// </summary>
        /// <exception cref="Exception on Label setter"></exception>
        public string Label 
        {
            get
            {
                return _label;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new Exception("Label can't be null or empty!!!");
                this.log("Label : " + _label + ">>" + value);
                _label = value.fisrtChar2uppperForEachWord();
            }
        }
        #endregion
        #region constructors
        /// <summary>
        /// create a Service object 
        /// throw Exception on properties setters
        /// </summary>
        /// <param name="code"></param>
        /// <param name="label"></param>
        /// <exception cref="Exception on properties setters"></exception>
        public Service(string code, string label)
            :base()
        {
            try
            {
                Code = code;
                Label = label;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
        #region methods
        /// <summary>
        /// display object in a string
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return this.Label + "(" + this.Code + ")";
        }

        private void log(string action)
        {
            
            if (null != evtLog) evtLog(this, action);
        }
        public void memorize()
        {
            Memento.setMemento(this);
        }

        public void restore()
        {
            this.Code = Memento.getMemento().Code;
            this.Label = Memento.getMemento().Label;
            this.log("Service restored....");
        }
        public void addLogger(Logger logger)
        {
            this.evtLog += logger.log;
        }
        #endregion

        #region patterns memento
        public static class Memento 
        {
            private static Service _service;
            public static void setMemento(Service service)
            {
                _service = service.Clone() as Service;
            }
            public static Service getMemento()
            {
                return _service;
            }
        }
        #endregion
        #region interfaces implements
        public object Clone()
        {
            return new Service(this.Code, this.Label);
        }
        #endregion
    }
}
