using PropertyManager.Model;
using PropertyManager.Droid;
using System.IO;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

[assembly: Xamarin.Forms.Dependency(typeof(FileIO))]
namespace PropertyManager.Droid
{
    public class FileIO : IFileIO
    {
        public FileIO() {}

        public void SaveProperties(ObservableCollection<Property> properties)
        {
            using (var file = File.Open(getPropertyFile(), FileMode.OpenOrCreate, FileAccess.Write))
            using (var strm = new StreamWriter(file))
            {
                foreach (Property p in properties)
                {
                    var json = JsonConvert.SerializeObject(p, new JsonSerializerSettings
                    {
                        //ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                        NullValueHandling = NullValueHandling.Ignore
                    });
                    strm.WriteLine(json);
                }
            }
        }

        public ObservableCollection<Property> LoadProperties()
        {
            ObservableCollection<Property> properties = new ObservableCollection<Property>();
            using (var file = System.IO.File.Open(getPropertyFile(), FileMode.OpenOrCreate, FileAccess.Read))
            using (var strm = new StreamReader(file))
            {
                while (!strm.EndOfStream)
                {
                    var line = strm.ReadLine();
                    Property p = JsonConvert.DeserializeObject<Property>(line);
                    properties.Add(p);
                }
            }
            return properties;
        }

        public string getSaveFolder()
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var saveFolder = Path.Combine(documentsPath, "PropertyManager");
            if (!System.IO.Directory.Exists(saveFolder))
            {
                System.IO.Directory.CreateDirectory(saveFolder);
            }
            return saveFolder;
        }

        public string getPropertyFile()
        {
            return Path.Combine(getSaveFolder(), "properties.txt");
        }
    }
}