using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Interfaces;

namespace BSP_BuechereiMapper
{
    public class BinaryMapper<T> : Mapper<T>
    {

        private readonly string _dateiPfad;

        public BinaryMapper(string dateiPfad)
        {
            _dateiPfad = dateiPfad;
        } 

        public List<T> Wiederherstellen()
        {
            List<T> result = null;


            using (var stream = File.Open(_dateiPfad, FileMode.OpenOrCreate))
            {
                var serializer = new BinaryFormatter();
                result = serializer.Deserialize(stream) as List<T>;
            }

            return result;
        }

        public void Abbilden(List<T> t)
        {
            using (var stream = File.Open(_dateiPfad, FileMode.Create))
            {
                var serializer = new BinaryFormatter();
                serializer.Serialize(stream, t);
            }
        }
    }
}
