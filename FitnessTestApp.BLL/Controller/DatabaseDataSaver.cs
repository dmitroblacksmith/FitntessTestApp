using FitnessTestApp.BLL.Model;

namespace FitnessTestApp.BLL.Controller
{ public class DatabaseDataSaver : IDataSaver
    {
        public void Save(string fileName, object item)
        {
            throw new System.NotImplementedException();
        }

        public T Load<T>(string fileName)
        {
            throw new System.NotImplementedException();
        }
    }
}