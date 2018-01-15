using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HospitalBed.Configuration
{
    public class XmlConfiguration : IConfiguration
    {
        private string _path = @"D:\Programs\Google Drive\ST3\PRG\Files\ConfigFiles\XMLConfig1.xml";
        public ConfigurationValues Deserialize()
        {
            var serializer = new XmlSerializer(typeof(ConfigurationValues));
            FileStream fs = new FileStream(_path, FileMode.Open);
            ConfigurationValues config = (ConfigurationValues) serializer.Deserialize(fs);

            return config;
        }
    }
}
