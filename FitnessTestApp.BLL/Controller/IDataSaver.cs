namespace FitnessTestApp.BLL.Controller
{
    public interface IDataSaver
    {
        void Save(string fileName, object item);

        T Load<T>(string fileName);
    }
}