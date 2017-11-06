using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP_15_2016.Utils
{
    public class GenericSerializer
    {
        public static void Serialize<T>(string fileName, List<T> objectToSerialize) where T : class
        {

            try
            {
                var serializer = new XmlSerializer(typeof(List<T>));
                using (var sw = new StreamWriter($@"../../AppData/{fileName}"))
                {
                    serializer.Serialize(sw, objectToSerialize);
                }

            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public static List<T> Deserialize<T> (string fileName) where T : class
        {
            try
            {
                var serializer = new XmlSerializer(typeof(List<T>));
                using (var sw = new StreamReader($@"../../AppData/{fileName}"))
                {
                    return (List<T>)serializer.Deserialize(sw);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}