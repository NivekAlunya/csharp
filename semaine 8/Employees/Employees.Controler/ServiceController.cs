using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Model;
using Employees.Store;
using MyCompany.Tools;
namespace Employees.Controler
{
    public enum ServiceSearchOption {
        SearchOnService,
        SearchOnCode,
        SearchOnLabel,
    }
    public delegate void EventHandlerServiceControlerSort();

    public class ServiceController
    {
        #region event
        public event EventHandler evtUpdateService;
        public event EventHandlerServiceControlerSort evtSorted; 
        #endregion
        #region delegate
        public delegate void addServiceDelegate(Service c);
        #endregion
        #region attributes
        private List<Service> _services;
        private static ServiceController _singleton=null;
        public static ServiceController Instance
        {
            get
            {
                return null == _singleton ? _singleton = new ServiceController() : _singleton;
            }
        }
        #endregion
        #region properties
        public List<Service> Services 
        {
            get
            {
                if (null == _services)
                {
                    _services = ServiceStore.getServices();
                    this.sort();
                }
                return _services;
            }
        }
        #endregion
        #region constructors
        private ServiceController()
            :base()
        {

        }
        #endregion
        #region methods
        /// <summary>
        /// methods retreive instance of the singleton
        /// </summary>
        /// <returns>ServiceControler</returns>
        //public static ServiceControler getInstance()
        //{
        //    return null == _singleton ? _singleton = new ServiceControler() : _singleton;
        //}

        public Service retrieveService<T>(T search,ServiceSearchOption option = ServiceSearchOption.SearchOnService)
        {
            if (search is Service) 
                return (true == this.Services.Contains(search as Service))?search as Service :null;
            
            if(!(search is string)) 
                throw new Exception("Can t compare with this kind of object. Please use Service or String objects");

            switch (option)
            {
                case ServiceSearchOption.SearchOnCode:
                    return this.Services.Find((Service s) => { return search as string == s.Code; });

                case ServiceSearchOption.SearchOnLabel:
                    return this.Services.Find((Service s) => { return search as string == s.Label; });
            }
            return null;

            //foreach (Service s in this.Services)
            //{
            //    switch(option)
            //    {
            //        case ServiceSearchOption.SearchOnCode:
            //            if (s.Code == (search as string)) return s;
            //            break;
            //        case ServiceSearchOption.SearchOnLabel:
            //            if (s.Label == (search as string)) return s;
            //            break;
            //    }

            //    if (s.Code == search as string)
            //    {
            //        return s;
            //    }
            //}

            //return null;
        }

        public Service addService(string code, string label,addServiceDelegate fn = null)
        {
            if(null != this.retrieveService<string>(code,ServiceSearchOption.SearchOnCode)) {
                throw new Exception("This code is already used");
            }
            
            if(null != this.retrieveService<string>(code,ServiceSearchOption.SearchOnLabel)) {
                throw new Exception("This label is already used");
            }
            
            Service service = null;
            
            try
            {
                service = ServiceStore.addService(code, label);
            }
            catch (Exception e)
            {
                throw e;
            }
            if (null != fn) fn(service);
            this.sort();
            return service;
        }

        public void updateService(Service service,string code,string label)
        {
            Service s = null;
            s = this.retrieveService<string>(code, ServiceSearchOption.SearchOnCode);
            
            if (s != null && service != s)
            {
                throw new Exception("This code is already used");
            }
            
            s = this.retrieveService<string>(code, ServiceSearchOption.SearchOnLabel);

            if (s != null && service != s)
            {
                throw new Exception("This label is already used");
            }
            ServiceStore.updateService(service,code,label);
            if(null != evtUpdateService) evtUpdateService(service, EventArgs.Empty);
            this.sort();
        }

        public bool deleteService<T>(T target,ServiceSearchOption option = ServiceSearchOption.SearchOnService)
        {
            Service targetService = this.retrieveService<T>(target, option);
            if (null != targetService)
            {
                this.Services.Remove(targetService);
                return ServiceStore.deleteService(targetService);
            }
            return false;
        }

        private void sort()
        {
            this.Services.Sort(
                (Service s1, Service s2) => {
                    return s1.Code.CompareTo(s2.Code);
                }
            );
            if (null != this.evtSorted) this.evtSorted();
        }
        public void subscribe(EventHandlerServiceControlerSort handler)
        {
            this.evtSorted += handler;
        }
        #endregion
    }
}
