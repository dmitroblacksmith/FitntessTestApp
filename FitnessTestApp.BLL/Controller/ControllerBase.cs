using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnessTestApp.BLL.Controller
{
    public abstract class ControllerBase
    {
        protected IDataSaver _saver = new SerializeDataSaver();

        protected void Save(string fileName, object item)
        {
            _saver.Save(fileName, item);
        }

        protected T Load<T>(string fileName)
        {
            return Load<T>(fileName);
        }
    }
}