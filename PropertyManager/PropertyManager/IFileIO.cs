using PropertyManager.Model;
using System.Collections.ObjectModel;

namespace PropertyManager
{
    public interface IFileIO
    {
        ObservableCollection<Property> LoadProperties();
        void SaveProperties(ObservableCollection<Property> properties);
        string getSaveFolder();
        string getPropertyFile();
    }
}
