using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCompany.Tools;
using System.ComponentModel;
namespace Employees.Model
{
    [Serializable]
    public abstract class Person: INotifyPropertyChanged
    {
        [field:NonSerialized]public event PropertyChangedEventHandler PropertyChanged;
        private string _surname;
        private string _firstname;
        private DateTime _dob;
        public string Fullname
        {
            get { return Firstname + " " + Surname; }
        }
        #region properties
        /// <summary>
        ///  property Surname
        /// </summary>
        /// <exception cref="Exception"></exception>
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                //if (null == value || 1 > value.Length) throw new Exception("Surname can't be null or empty!!!");
                if (string.IsNullOrWhiteSpace(value)) throw new Exception("Surname can't be null or empty!!!");
                _surname = value.ToUpper();
                changed();
            }
        }

        public string Firstname
        {
            get
            {
                return _firstname;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new Exception("Firstname can't be null or empty!!!");
                _firstname = value;
                changed();                
            }
        }
        public DateTime DOB
        {
            get
            {
                return _dob;
            }
            set
            {
                //if (null == value || 1 > value.Length) throw new Exception("Surname can't be null or empty!!!");
                if (DateTime.Now<value) throw new Exception("DOB can't be greater than today");
                _dob = value;
            }
        }
        public Guid ID { get; set; }
        public int Age {
            get {
                return this.DOB.ageOf(DateTime.Now);
            }
        }
        #endregion

        #region constructors
        /// <summary>
        /// Dedicated constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="surname"></param>
        /// <param name="firstname"></param>
        /// <param name="dob"></param>
        /// <exception cref="Exception"></exception>
        public Person(Guid id, string surname, string firstname, DateTime dob)
            :base()
        {
            DOB = dob;
            Firstname = firstname;
            try
            {
                Surname = surname;
            }
            catch (Exception e)
            {
                
                throw e;
            }
            ID = id;
        }
        /// <summary>
        /// Create a person object with a new guid
        /// </summary>
        /// <param name="surname"></param>
        /// <param name="firstname"></param>
        /// <param name="dob"></param>
        /// <exception cref="Exception"></exception>
        public Person(string surname, string firstname, DateTime dob)
            : this(Guid.NewGuid(), surname, firstname, dob)
        {
        }
        public Person() { }
        #endregion
        
        #region methods
        /// <summary>
        /// get fullname of the person
        /// </summary>
        /// <returns>Fullname of the person</returns>
        public string display()
        {
            return this.Surname + " " + this.Firstname;
        }
        /// <summary>
        /// get fullname of the person with his age
        /// </summary>
        /// <param name="withAge">display the age or not</param>
        /// <returns>Fullname of the person</returns>
        public virtual string display(bool withAge)
        {
            return this.display() + (withAge ? " " + this.Age + " years old" : "");
        }

        public override string ToString()
        {
            return this.display(true);
        }
        public abstract string introduceYou();

        private void changed()
        {
            if (null != PropertyChanged) PropertyChanged(this, new PropertyChangedEventArgs("Fullname"));
        }

        #endregion
        
        #region destructors
        ~Person()
        {

        }
        public void dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
