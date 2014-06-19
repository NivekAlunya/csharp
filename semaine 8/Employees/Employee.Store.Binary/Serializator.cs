using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Employees.Store.Binary
{
    public abstract class Serializator
    {
        protected IFormatter Formatter;

        private void Serialize<T>(T object2Serialize, string file)
        {
            FileStream fs = default(FileStream);
            try
            {
                fs = new FileStream(file, FileMode.Create);
                Formatter.Serialize(fs, object2Serialize);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (null != fs) fs.Close();
            }
        }

        private T DeSerialize<T>(string file)
        {
            FileStream fs = default(FileStream);
            T deserialized;
            try
            {
                fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.None);
                deserialized = (T)Formatter.Deserialize(fs);
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                if (null != fs) fs.Close();
            }
            return deserialized;
        }

    }
}
