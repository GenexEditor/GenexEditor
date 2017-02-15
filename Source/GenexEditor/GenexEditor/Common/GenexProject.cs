using System;
using System.IO;
using System.Xml.Serialization;

namespace GenexEditor
{
    public class GenexProject
    {
        public string Title { get; set; }

        [XmlIgnore]
        public bool Dirty { get; set; }

        [XmlIgnore]
        public string FilePath { get; set; }

        public static GenexProject Load(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                var serializer = new XmlSerializer(typeof(GenexProject));
                var project = serializer.Deserialize(reader) as GenexProject;
                project.FilePath = filePath;

                return project;
            }
        }

        public void Save()
        {
            using (var writer = new StreamWriter(FilePath))
            {
                var serializer = new XmlSerializer(typeof(Settings));
                serializer.Serialize(writer, this);
            }
        }
    }
}
